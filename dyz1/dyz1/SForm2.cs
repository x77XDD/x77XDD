using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dyz1
{
    public partial class SForm2 : Form
    {
        public SForm2()
        {
           
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label6.Text = "*注意：①学号8位数字且不能为空。②姓名不能为空。③班级号6-16位数字且不能为空。④密码8位数字且不能为空。⑤学号开头不能加9。";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String xuehao = textBox1.Text;
            String xingming = textBox2.Text;
            String banjiming = comboBox1.Text;
            String mima = textBox4.Text;


            if (xuehao.Equals("") || xingming.Equals("") || banjiming.Equals("") || mima.Equals(""))
            {
                MessageBox.Show("注册信息不可为空！！");
                return;
            }
            

            DataSet ds = DB.GetDs("Select * from class where classname='"+ banjiming + "'");
            DataView dv1 = ds.Tables[0].DefaultView;
            String banjihao = dv1[0]["classno"].ToString();

            DataSet ds1 = DB.GetDs("Select * from student where stuno='"+ xuehao + "'");
            DataView dv11 = ds1.Tables[0].DefaultView;
            if (dv11.Count != 0) {
                MessageBox.Show("该学号已被注册！！", "注意！");
                return;
            }
            else if (xuehao.Substring(0, 1) == "9")
            {
                MessageBox.Show("学生注册学号前不能为9开头！！", "注意！");
                return;
            }
            else if (xuehao.Length<=7 )
            {
                MessageBox.Show("学生号过短！", "注意！");
                return;
            }

            else if ( xuehao.Length >= 13)
            {
                MessageBox.Show("学生号过长！", "注意！");
                return;
            }

            else if (   mima.Length <= 5 || mima.Length >= 17)
            {
                MessageBox.Show("密码长度需6-16位", "注意！");
                return;
            }
            else {
                DB.Execute("insert into student(stuno,stuname,classno,pwd) values ('" + xuehao + "','" + xingming + "','" + banjihao + "','" + mima + "')");
                MessageBox.Show("您的学号：" + xuehao + ",    您的姓名：" + xingming + ",     您的班级名：" + banjiming + ",     您的密码： " + mima + "");
            }
               
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            DataSet ds = DB.GetDs("Select * from class;");
            DataView dv1 = ds.Tables[0].DefaultView;
            comboBox1.DataSource = dv1;
            comboBox1.DisplayMember = "classname";
            comboBox1.ValueMember = "classno";
        }
    }
}
