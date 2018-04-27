using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dyz1.Properties;

namespace dyz1
{
    public partial class MForm : Form
    {
        public String t1;
        public MForm()
        {
            InitializeComponent();
            
        }

        private void MFrom_Load(object sender, EventArgs e)
        {
            label1.Text = "欢迎您： "+t1+" 同学";
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StuCou stuCou = new StuCou();
            stuCou.t1 = t1;
            stuCou.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SCoursequit csqt = new SCoursequit();
            csqt.t1 = t1;
            csqt.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SMycourse mc = new SMycourse();
            mc.t1 = t1;
            mc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SOpinion op = new SOpinion();
            op.t1 = t1;
            op.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePwd chp = new ChangePwd();
            chp.t1 = t1;
            chp.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SChangeinfo sc = new SChangeinfo();
            sc.t1 = t1;
            sc.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AboutUs sc = new AboutUs();
            sc.ShowDialog();
        }
    }
}
