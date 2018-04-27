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
    public partial class TForm : Form
    {
        public String t1;
        public TForm()
        {
            InitializeComponent();
        }

        private void TForm_Load(object sender, EventArgs e)
        {
            label1.Text = "欢迎您： " + t1 + " 老师";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tcourse tcourse= new Tcourse();
            tcourse.t1 = t1;
            tcourse.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePwd chp = new ChangePwd();
            chp.t1 = t1;
            chp.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TAddcourse A = new TAddcourse();
            A.t1 = t1;
            A.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tselect A = new Tselect();
            A.t1 = t1;
            A.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TOpinion A = new TOpinion();
            A.ShowDialog();
        }
    }
}
