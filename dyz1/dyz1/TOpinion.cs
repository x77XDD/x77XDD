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
    public partial class TOpinion : Form
    {
        public TOpinion()
        {
            InitializeComponent();
        }

        private void TOpinion_Load(object sender, EventArgs e)
        {
            String sql = "select id'编号',name'学生姓名',con'留言内容',time'留言时间' from Opinion ";
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            dataGridView1.DataSource = dv;
        }
    }
}
