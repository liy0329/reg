using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.main;
using MTHIS.db;
using MTHIS.common;
namespace MTHIS.sys
{
    public partial class FrmSysInitChk : Form
    {
        Form frm;
        public FrmSysInitChk()
        {
            InitializeComponent();
        }
        public FrmSysInitChk(Form s_frm)
        {
            InitializeComponent();
            this.frm = s_frm;
     
        }
     
        private void btnOK_Click(object sender, EventArgs e)
        {
            Ini.INIClass(GlobalParams.syspath);
            string initpasswd = Convert.ToString(Ini.IniReadValue("lisinit", "initpasswd"));
            if (initpasswd.Trim().Equals(this.txbInitPasswd.Text.Trim()))
            {
                ((FrmSysInit)frm).IsenabeOk = true;
            }
            else
            { 
                  ((FrmSysInit)frm).IsenabeOk = false;
           
            }
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSysInitChk_Load(object sender, EventArgs e)
        {
            txbInitPasswd.Text = "";
            txbInitPasswd.Select();
            txbInitPasswd.Focus();
        }

    

      

        private void txbInitPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

    
    }
}
