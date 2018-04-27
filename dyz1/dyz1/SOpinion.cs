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
    public partial class SOpinion : Form
    {
        public String t1;
        public SOpinion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = t1;
            String content = textBox1.Text;
            DateTime time = DateTime.Now;

            String sql = "insert into Opinion(name,con,time)  values('" + t1 + "','" + content + "','" + time + "')";
            DB.Execute(sql);
            MessageBox.Show("提交成功！");
            this.Dispose();
        }
    }
}
