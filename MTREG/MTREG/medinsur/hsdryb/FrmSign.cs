using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hsdryb.bo;
using MTHIS.common;
using MTREG.medinsur.hsdryb.bll;

namespace MTREG.medinsur.hsdryb
{
    public partial class FrmSign : Form
    {
        public FrmSign()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            WYJK wyjk = new WYJK();
            TopParameter common = new TopParameter();
            common.AAE140 = "0";
            common.AAC001 = "0";
            common.AKB020 = ProgramGlobal.Othvar_2;//定点医疗机构编号              
            common.AKC190 = "0";
            common.AKC020 = "0";
            common.AKA130 = "0";
            common.MSGNO = "1501";
            common.MSGID = WYJK.getLsh();
            common.GRANTID = ProgramGlobal.Othvar_3;//授权码
            common.OPERID = ProgramGlobal.User_id;
            common.OPERNAME = ProgramGlobal.Username;
            common.BATNO = "0";
            var opt = wyjk.czyqd(common);
            if (opt.ReturnNum == "-1")
            {
                MessageBox.Show(opt.ErrorMsg);
                return;
            }
            if (opt == null)
            {
                MessageBox.Show("签到失败！");
                return;
            }
            ProgramGlobal.Othvar_1 = opt.BATNO;
            MessageBox.Show("签到成功！");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
