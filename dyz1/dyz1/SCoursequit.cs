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
    public partial class SCoursequit : Form
    {
        public String t1;
        public SCoursequit()
        {
            InitializeComponent();
        }

        private void Coursequit_Load(object sender, EventArgs e)
        {
            label3.Text = "*注意：退选课程功能请谨慎操作！";

            label1.Text =  t1 + " 同学，您所选的课程：";

            DataSet ds = DB.GetDs("Select * from student where stuname='" + t1 + "'");
            DataView dv1 = ds.Tables[0].DefaultView;
            String xuehao = dv1[0]["stuno"].ToString();


            DataSet DS = DB.GetDs("select couname,course.couno,kind,credit,teacher,schooltime,state from stucou,course where stuno='" + xuehao + "' and stucou.couno=course.couno");
            DataView dv = DS.Tables[0].DefaultView;
            dataGridView1.DataSource = dv;         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dataGridView1.CurrentRow;
            string val = dgvr.Cells["state"].Value.ToString();
            string ckh = dgvr.Cells["couno"].Value.ToString();
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择退选的课程！！", "注意！");
                return;
            }
            else if(val.Equals("已退选")){
                MessageBox.Show("该课程已经退选,请勿重复操作！", "注意！");
                return;
            }


            else {
                
                DataSet ds = DB.GetDs("Select * from student where stuname='" + t1 + "'");
                DataView dv1 = ds.Tables[0].DefaultView;
                String xuehao = dv1[0]["stuno"].ToString();



               

                String tx = "已退选";
                DB.Execute("update stucou set state='" + tx + "' where couno='" + ckh + "' and  stuno='" + xuehao + "'");
                MessageBox.Show("退选课程成功！！");

                DB.Execute("update course set willnum=willnum-1 where couno='" + ckh + "'");

                DataSet DS = DB.GetDs("select couname,course.couno,kind,credit,teacher,schooltime,state from stucou,course where stuno='" + xuehao + "' and stucou.couno=course.couno");
                DataView dv = DS.Tables[0].DefaultView;
                dataGridView1.DataSource = dv;
                return;
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
    }
}
