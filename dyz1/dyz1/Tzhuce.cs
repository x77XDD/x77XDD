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
    public partial class Tzhuce : Form
    {
        public Tzhuce()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Tzhuce_Load(object sender, EventArgs e)
        {
            label5.Text = "*注意：①教师号第一位必须为“9”且8位数字不能为空。②姓名不能为空。③密码6-16位字符且不能为空。";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String xuehao = textBox1.Text;
            String xingming = textBox2.Text;
            String mima = textBox3.Text;



            if (xuehao.Equals("") || xingming.Equals("")  || mima.Equals(""))
            {
                MessageBox.Show("注册信息不可为空！！", "注意！");
                return;
            }
            DataSet ds1 = DB.GetDs("Select * from student where stuno='" + xuehao + "'");
            DataView dv11 = ds1.Tables[0].DefaultView;
            if (dv11.Count != 0)
            {
                MessageBox.Show("该教师号已被注册！！", "注意！");
                return;
            }
            else if (xuehao.Substring(0, 1) != "9")
            {
                MessageBox.Show("教师号必须为“9”开头！！", "注意！");
                return;
            }
            else if (xuehao.Length <= 7)
            {
                MessageBox.Show("教师号过短！", "注意！");
                return;
            }
            else if (xuehao.Length >= 13)
            {
                MessageBox.Show("教师号过长！", "注意！");
                return;
            }
            else if (mima.Length <= 5 || mima.Length >= 17)
            {
                MessageBox.Show("密码长度需6-16位", "注意！");
                return;
            }
            else
            {
                DB.Execute("insert into student(stuno,stuname,pwd) values ('" + xuehao + "','" + xingming + "','" + mima + "')");
                MessageBox.Show("您的学号：" + xuehao + ",    您的姓名：" + xingming + ",     您的密码： " + mima + "", "恭喜，注册成功！");
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
