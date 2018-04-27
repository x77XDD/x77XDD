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
    public partial class TAddcourse : Form
    {
        public String t1;
        public TAddcourse()
        {
            InitializeComponent();
            
        }
           
        private void button1_Click(object sender, EventArgs e)
        {
            String couno = textBox1.Text;
            String couname = textBox2.Text;
            String kind = comboBox1.Text;
            String credit = comboBox2.Text;
            String departno = comboBox3.Text;
            String schooltime = comboBox4.Text;
            String limitnum = textBox3.Text;

            if (couno.Equals("") || couname.Equals("") || kind.Equals("") || credit.Equals("") || departno.Equals("") || schooltime.Equals("") || limitnum.Equals("")) {
                MessageBox.Show("提交失败，填写信息不可为空！","提示");
                return;
            }
            String sql = "insert into course values('" + couno + "','" + couname + "','" + kind + "','" + credit + "','" + t1 + "','" + departno + "','" + schooltime + "','" + limitnum + "','0',null)";
            DB.Execute(sql);
            MessageBox.Show("添加成功，请查看！");
            this.Dispose();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            DataSet ds1 = DB.GetDs("select distinct kind from course");
            DataView dv1 = ds1.Tables[0].DefaultView;
            comboBox1.DataSource = dv1;
            comboBox1.DisplayMember = "kind";
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            DataSet ds1 = DB.GetDs("select distinct credit from course");
            DataView dv1 = ds1.Tables[0].DefaultView;
            comboBox2.DataSource = dv1;
            comboBox2.DisplayMember = "credit";
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            DataSet ds1 = DB.GetDs("select distinct departno from course");
            DataView dv1 = ds1.Tables[0].DefaultView;
            comboBox3.DataSource = dv1;
            comboBox3.DisplayMember = "departno";
        }

        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            DataSet ds1 = DB.GetDs("select distinct schooltime from course");
            DataView dv1 = ds1.Tables[0].DefaultView;
            comboBox4.DataSource = dv1;
            comboBox4.DisplayMember = "schooltime";
        }

        private void Addcourse_Load(object sender, EventArgs e)
        {
            String sql1 = "select top 1 * from course order by couno desc ";
            DataSet ds = DB.GetDs(sql1);
            DataView dv = ds.Tables[0].DefaultView;
            int couno1 = int.Parse(dv[0]["couno"].ToString());
            String couno2 = "0" + (couno1 + 1).ToString();
            textBox1.Text = couno2;
        }
    }
}
