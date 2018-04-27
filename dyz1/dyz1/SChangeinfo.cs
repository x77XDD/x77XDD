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
    public partial class SChangeinfo : Form
    {
        public String t1;
        public SChangeinfo()
        {
            
            InitializeComponent();
        }

        private void SChangeinfo_Load(object sender, EventArgs e)
        {

            DataSet ds = DB.GetDs("Select * from student where stuname='" + t1 + "'");
            DataView dv1 = ds.Tables[0].DefaultView;
            String xuehao = dv1[0]["stuno"].ToString();
            String xingming = dv1[0]["stuname"].ToString();
            //String banjiming = dv1[0]["classname"].ToString();

            DataSet ds1 = DB.GetDs("Select * from student,class where class.classno=student.classno and stuno='" + xuehao + "';");
            DataView dv11 = ds1.Tables[0].DefaultView;
            comboBox1.DataSource = dv11;
            comboBox1.DisplayMember = "classname";
            comboBox1.ValueMember = "classno";

            textBox1.Text = xuehao;
            textBox2.Text = xingming;
             label5.Text = "*注意：①姓名不能为空。②学号开头不能加9。③学号不能为空。";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String xuehao = textBox1.Text;
            String xingming = textBox2.Text;
            String banjiming = comboBox1.Text;

            DataSet ds = DB.GetDs("Select * from class where classname='" + banjiming + "'");
            DataView dv1 = ds.Tables[0].DefaultView;
            String banjihao = dv1[0]["classno"].ToString();


            if ( xingming.Equals("") || banjiming.Equals("") )
            {
                MessageBox.Show("修改信息不可为空！！");
                return;
            }
            else
            {
                DB.Execute("update student set classno='" + banjihao + "' where stuno='" + xuehao + "'");
                MessageBox.Show("您的学号：" + xuehao + ",    您的姓名：" + xingming + ",     您的班级名：" + banjiming + "","修改成功");
            }




        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            DataSet ds = DB.GetDs("Select * from class;");
            DataView dv1 = ds.Tables[0].DefaultView;
            comboBox1.DataSource = dv1;
            comboBox1.DisplayMember = "classname";
            comboBox1.ValueMember = "classno";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = t1;
            DataSet ds = DB.GetDs("Select * from student where stuname='" + t1 + "'");
            DataView dv1 = ds.Tables[0].DefaultView;
            String xuehao = dv1[0]["stuno"].ToString();
            DataSet ds1 = DB.GetDs("Select * from student,class where class.classno=student.classno and stuno='" + xuehao + "';");
            DataView dv11 = ds1.Tables[0].DefaultView;
            comboBox1.DataSource = dv11;
            comboBox1.DisplayMember = "classname";
            comboBox1.ValueMember = "classno";
        }
    }
}
