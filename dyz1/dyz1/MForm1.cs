using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace dyz1
{
    public partial class MForm1 : Form
    {
        public MForm1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;
            String t2 = textBox2.Text;
            if (textBox1.Text.Equals("")||textBox2.Text.Equals("")) {
                MessageBox.Show("用户名或密码不可为空!");
                return;
            }
            String sql = "select * from student where stuno='"+t1+"'";
            DataSet ds = DB.GetDs(sql);
            DataView dv = ds.Tables[0].DefaultView;
            //String pwd = dv[0]["pwd"].ToString();
            if (dv.Count==0||!(dv[0]["pwd"].ToString()).Equals(t2)) {
                MessageBox.Show("用户名或密码错误！！");
            }
            else
            {
                if (t1.Substring(0, 1) == "9")
                {
                    TForm tform= new TForm();
                    tform.t1= dv[0]["stuname"].ToString();
                    this.Visible = false;
                    tform.ShowDialog();
                    this.Visible = true;
                }
                else {
                    MForm mform = new MForm();
                    mform.t1 = dv[0]["stuname"].ToString();
               
                    this.Visible = false;
                    mform.ShowDialog();
                    this.Visible = true;
                }
                
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SForm2 f2 = new SForm2();
            f2.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Tzhuce f2 = new Tzhuce();
            f2.ShowDialog();
            this.Visible = true;

        }
    }
}
