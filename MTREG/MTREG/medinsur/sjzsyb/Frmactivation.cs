using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.clinic;
using MTREG.medinsur.sjzsyb.dor;
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.medinsur.sjzsyb
{
    public partial class Frmactivation : Form
    {
        public Frmactivation()
        {
            InitializeComponent();
        }

        private void Frmactivation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SJZYB_IN<DBNull> yb_in_dk = new SJZYB_IN<DBNull>();
            SjzybInterface sjzybInterface = new SjzybInterface();
            SJZYB_OUT yb_out_dk = new SJZYB_OUT();
            yb_in_dk.MSGNO = "2131";
            yb_in_dk.AAC001 = "0";
            //dk_out.sfcf = "0";
            int ret = sjzybInterface.activation(yb_in_dk, ref yb_out_dk);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_dk.ERRORMSG, "提示信息");
                return;
            }
            MessageBox.Show("修改卡密码成功！", "提示信息");
        }
    }
}
