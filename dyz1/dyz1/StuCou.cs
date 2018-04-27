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
    public partial class StuCou : Form
    {
        public String t1;
        public StuCou()
        {
            InitializeComponent();
        }

        private void StuCou_Load(object sender, EventArgs e)
        {
             DataSet ds = DB.GetDs("Select * from course;");
            DataView dv = ds.Tables[0].DefaultView;
            dataGridView1.DataSource = dv;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            DataSet ds = DB.GetDs("Select Distinct kind from course;");
            DataView dv1 = ds.Tables[0].DefaultView;
            comboBox1.DataSource = dv1;
            comboBox1.DisplayMember = "kind";
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            DataSet ds = DB.GetDs("Select Distinct credit from course;");
            DataView dv1 = ds.Tables[0].DefaultView;
            comboBox2.DataSource = dv1;
            comboBox2.DisplayMember = "credit";
        }
        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            DataSet ds = DB.GetDs("Select Distinct schooltime from course;");
            DataView dv1 = ds.Tables[0].DefaultView;
            comboBox3.DataSource = dv1;
            comboBox3.DisplayMember = "schooltime";
        }
        private void button1_Click(object sender, EventArgs e)
        {


            String sql= "Select * from course c, department d where  d.departno = c.departno";
            if (!(comboBox1.Text.Equals(""))) {
                sql += " and c.kind='"+comboBox1.Text+"'" ;
            }
            if (!(comboBox2.Text.Equals("")))
            {
                sql += " and c.credit='"+comboBox2.Text+"'" ;
            }
            if (!(comboBox3.Text.Equals("")))
            {
                sql += " and c.schooltime='"+comboBox3.Text+"'" ;
            }
            
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            dataGridView1.DataSource = dv;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择课程！！");
                return;
            }
            else {
                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                string couno = dgvr.Cells["couno"].Value.ToString();
                DataSet ds = DB.GetDs("Select * from student where stuname='" + t1 + "'");
                DataView dv = ds.Tables[0].DefaultView;
                String stuno = dv[0]["stuno"].ToString();

                String sql1 = "select * from stucou where stuno='" + stuno + "' and couno='" + couno + "' and state='报名'";


                String sql4 = "select * from stucou where stuno='" + stuno + "' and couno='" + couno + "'";

                DataSet ds1 = DB.GetDs(sql1);
                DataView dv1 = ds1.Tables[0].DefaultView;
                DataSet ds4 = DB.GetDs(sql4);
                DataView dv4 = ds4.Tables[0].DefaultView;
                

                if (dv4.Count == 0) {
                    String sql = "insert into stucou values('" + stuno + "','" + couno + "',null,'报名','null')";
                    DB.Execute(sql);
                    DB.Execute("update course set willnum=willnum+1 where couno='" + couno + "'");
                    MessageBox.Show("恭喜你，选课成功！！");

                    String sql3 = "Select * from course c, department d where  d.departno = c.departno";
                    DataSet ds3 = DB.GetDs(sql3);
                    DataView dv3 = ds3.Tables[0].DefaultView;
                    dataGridView1.DataSource = dv3;

                }
                else {
                    
                 if (dv1.Count != 0)
                {
                    MessageBox.Show("该课程已选择，请勿重复报名！");
                }
              
                else
                {
                    String sql = "update  stucou set state='报名' where couno='"+ couno + "' and stuno='"+ stuno + "'";
                    DB.Execute(sql);
                    DB.Execute("update course set willnum=willnum+1 where couno='" + couno + "'");
                    MessageBox.Show("恭喜你，选课成功！！");

                    String sql3 = "Select * from course c, department d where  d.departno = c.departno";
                    DataSet ds3 = DB.GetDs(sql3);
                    DataView dv3 = ds3.Tables[0].DefaultView;
                    dataGridView1.DataSource = dv3;
                }

                }

              

            }
            

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
