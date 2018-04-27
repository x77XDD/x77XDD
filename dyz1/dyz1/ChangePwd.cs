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
    
    public partial class ChangePwd : Form
    {
        public String t1;
        public ChangePwd()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ChangePwd_Load(object sender, EventArgs e)
        {

            String sql = "select * from student where stuname='" + t1 + "'";
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            String xuehao = dv[0]["stuno"].ToString();
            
            if (xuehao.Substring(0, 1) == "9")
            {
                label4.Text = "尊敬的" + t1 + "教师，请输入：";
            }
            else {
                label4.Text = "亲爱的" + t1 + "同学，请输入：";
            }      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String jiupwd = textBox1.Text;
            String xinpwd= textBox2.Text;
            String repwd = textBox3.Text;

            if (jiupwd.Equals("") || xinpwd.Equals("") || repwd.Equals("") )
            {
                MessageBox.Show("请按要求填写内容！");
                return;
            }

            String sql = "select * from student where stuname='" + t1 + "'";
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            String mima = dv[0]["pwd"].ToString();
            String xuehao= dv[0]["stuno"].ToString();

            if (!mima.Equals(jiupwd))
            {
                MessageBox.Show("请输入正确的密码!");
                return;
            }
            else if (xinpwd.Length <= 5 || xinpwd.Length >= 17)
            {
                MessageBox.Show("密码长度需6-16位");
                return;
            }
            else if (!xinpwd.Equals(repwd))
            {
                MessageBox.Show("两次密码输入不相同！");
                return;
            }
            else if (xinpwd.Equals(jiupwd)) {
                MessageBox.Show("新密码不能与旧密码相同！");
                return;
            }
            else {
                DB.Execute("update student set pwd='" + xinpwd + "'  where stuno='" + xuehao + "'");
            }
            MessageBox.Show("修改密码成功！ 请重新登陆！！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
