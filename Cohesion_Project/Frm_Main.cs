using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cohesion_Project
{
    public partial class Frm_Main : Form
    {
        private Util.ComboUtil comboUtil;
        //public Util.ComboUtil ComboUtil { get { return comboUtil; } }
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            comboUtil = new Util.ComboUtil();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_Product frm = new Frm_Product();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm_Common frm = new Frm_Common();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Frm_Inspection frm = new Frm_Inspection();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Frm_Base_4 frm = new Frm_Base_4();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Frm_Base_5 frm = new Frm_Base_5();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
