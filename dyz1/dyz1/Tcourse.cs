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
    public partial class Tcourse : Form
    {
        public String t1; 
        public Tcourse()
        {
            InitializeComponent();
        }

        private void Tcourse_Load(object sender, EventArgs e)
        {
            String sql = "select couname'课程名称',stuname'学生名' ,classname'班级',schooltime'上课时间',state'报名情况' from course,stucou,student,class where teacher='" + t1 + "' and student.stuno=stucou.stuno and stucou.couno=course.couno and class.classno=student.classno order by couname";
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            dataGridView1.DataSource = dv;

            label1.Text = t1 + "老师：";
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            String sql = "select couname from course where teacher='" + t1 + "'";
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            comboBox1.DataSource = dv;
            comboBox1.DisplayMember = "couname";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sql = "select couname'课程名称',stuname'学生名' ,classname'班级',schooltime'上课时间',state'报名情况' from course,stucou,student,class where teacher='" + t1 + "' and student.stuno=stucou.stuno and stucou.couno=course.couno and class.classno=student.classno";
            if (!comboBox1.Equals(""))
            {
                sql += " and couname='" + comboBox1.Text + "'";
            }
            else {

            }
            sql += " order by couname";
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            dataGridView1.DataSource = dv;
        }
    }
}
