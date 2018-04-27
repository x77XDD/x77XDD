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
    public partial class SMycourse : Form
    {
        public String t1;
        public SMycourse()
        {
            InitializeComponent();
        }

        private void Mycourse_Load(object sender, EventArgs e)
        {
            String sql = "select course.couno'课程编号' ,couname'课程名称',kind'课程类别',state'报名情况',schooltime'上课时间' from course,stucou,student where stuname='" + t1 + "' and student.stuno=stucou.stuno and stucou.couno=course.couno";
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            dataGridView1.DataSource = dv;

            label1.Text = t1 + "同学：";
        }
    }
}
