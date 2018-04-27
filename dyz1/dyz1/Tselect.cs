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
    public partial class Tselect : Form
    {
        public String t1;
        public Tselect()
        {
            InitializeComponent();
        }

        private void Tselect_Load(object sender, EventArgs e)
        {
            label2.Text = t1 + "老师：";
            String sql = "select * from course where teacher='"+t1+"'";
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            dataGridView1.DataSource = dv;
        }
    }
}
