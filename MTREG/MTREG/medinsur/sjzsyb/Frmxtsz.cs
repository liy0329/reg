using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.tools;

namespace MTREG.medinsur.sjzsyb
{
    public partial class Frmxtsz : Form
    {
        public Frmxtsz()
        {
            InitializeComponent();
        }

        private void Frmxtsz_Load(object sender, EventArgs e)
        {
            init_pz();
        }
        public void init_pz()
        {
            string zfc = IniUtils.IniReadValue(IniUtils.syspath, "MZPZ", "MZYB");//
            if (zfc == "1")
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            string kfdsz = IniUtils.IniReadValue(IniUtils.syspath, "FEETYPE", "TYPE");//
            if (kfdsz == "null")
            {
                radioButton1.Checked = true;
            }
            else if (kfdsz == "YAOFANG")
            {
                radioButton2.Checked = true;
            }
            else if (kfdsz == "YISHENG")
            {
                radioButton3.Checked = true;
            }
            else if (kfdsz == "KESHI")
            {
                radioButton4.Checked = true;
            }
        }

        private void btn_bc_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                IniUtils.IniWriteValue(IniUtils.syspath, "MZPZ", "MZYB", "1");
            }
            else
            {
                IniUtils.IniWriteValue(IniUtils.syspath, "MZPZ", "MZYB", "0");
            }
            string type = "";
            if (radioButton4.Checked == true)
            {
                type = "KESHI";
            }
            if (radioButton3.Checked == true)
            {
                type = "YISHENG";
            }
            if (radioButton2.Checked == true)
            {
                type = "YAOFANG";
            }
            if (radioButton1.Checked == true)
            {
                type = "null";
            }
            IniUtils.IniWriteValue(IniUtils.syspath, "FEETYPE", "TYPE                                                                                      ", type);
        }
    
    }
}
