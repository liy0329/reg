using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTREG.medinsur
{
    public partial class FrmMesg : Form
    {
        public FrmMesg()
        {
            InitializeComponent();
        }
        //
        private string in_mesg;
        public string In_mesg
        {
            get { return in_mesg; }
            set { in_mesg = value; }
        }
        private bool falg;
        public bool Falg
        {
            get { return falg; }
            set { falg = value; }
        }
        private void btn_qd_Click(object sender, EventArgs e)
        {
            this.falg = false;
            this.Close();
        }

        private void FrmMesg_Load(object sender, EventArgs e)
        {
            lblbcxx.Text = this.in_mesg;
            //if (in_mesg.IndexOf("限额") > 1)
            //    button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.falg = true;
            this.Close();
        }
    }
}
