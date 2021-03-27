using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.ynydyb.bll;
using MTHIS.common;
using MTREG.common;

namespace MTREG.medinsur.ynydyb
{
    public partial class FrmYnydybSign : Form
    {
        YNYDYB Ynydyb = new YNYDYB();
        BllYnydybMethod bllYnydybMethod = new BllYnydybMethod();
        public FrmYnydybSign(string starOrEnd)
        {
            InitializeComponent();
            if (starOrEnd == "star")
            {
                btnSignOut.Enabled = false;
            }
            else if (starOrEnd == "end")
            {
                btnSignIn.Enabled = false;
            }
        }

        /// <summary>
        /// 医保初始化
        /// </summary>
        private void ybInit()
        {
            YDJYDLLINIT_out YDJYDLLINIT_out1 = new YDJYDLLINIT_out();
            int opt = Ynydyb.ydjydllinit(YDJYDLLINIT_out1);
            if (opt != 0)
            {
                MessageBox.Show(YDJYDLLINIT_out1.ErrorMessage + ", 异地医保--交易接口初始化失败！", "错误信息");
                return ;
            }
        }
        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignIn_Click(object sender, EventArgs e)
        {            
            Hqfsflsh_out hqfsflsh_out1 = new Hqfsflsh_out();
            SIGNIN_out SIGNIN_out1 = new SIGNIN_out();
            int opt1 = Ynydyb.hqfsflsh(hqfsflsh_out1);
            if (opt1 != 0)
            {
                MessageBox.Show(hqfsflsh_out1.ErrorMessage + ", 异地医保--获取发送方交易流水号失败！", "错误信息");
                return;
            }

            StringBuilder jsfjylsh = new StringBuilder(2048);
            int opt2 = Ynydyb.signin(ProgramGlobal.User_id, hqfsflsh_out1.Swqjwyzym, jsfjylsh, SIGNIN_out1);
            if (opt2 != 0)
            {
                MessageBox.Show(SIGNIN_out1.ErrorMessage + ", 异地医保--操作员签到失败！", "错误信息");
                return;
            }
            if (bllYnydybMethod.inBusiCycleNo(SIGNIN_out1.Czyywzqh, BillSysBase.currDate()) < 0)
            {
                MessageBox.Show("业务周期号记录失败!","错误信息");
                return;
            }
            ynydybGlobal.Ywzqh=SIGNIN_out1.Czyywzqh;
            ynydybGlobal.Signtime = BillSysBase.currDate();
            MessageBox.Show("签到成功!");
            this.Close();
        }
        /// <summary>
        /// 签退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            ynydybGlobal.SignOuttime = BillSysBase.currDate();            
            DataTable dtInfo = bllYnydybMethod.getSignOutInfo();
            Hqfsflsh_out hqfsflsh_out1 = new Hqfsflsh_out();
            int opt1 = Ynydyb.hqfsflsh(hqfsflsh_out1);
            if (opt1 != 0)
            {
                MessageBox.Show(hqfsflsh_out1.ErrorMessage + ", 异地医保--获取发送方交易流水号失败！", "错误信息");
                return;
            }
            Dzcx_out dzcx_out1 = new Dzcx_out();
            dzcx_out1.Zjybs = dtInfo.Rows[0]["zjysl"].ToString();
            dzcx_out1.Fjybs = dtInfo.Rows[0]["fjysl"].ToString();
            dzcx_out1.Ylfyze = DataTool.stringToDouble(dtInfo.Rows[0]["ylfyze"].ToString()).ToString();
            dzcx_out1.Xjzfze = DataTool.stringToDouble(dtInfo.Rows[0]["xjzfze"].ToString()).ToString();
            dzcx_out1.Zhzfze = DataTool.stringToDouble(dtInfo.Rows[0]["zhzfze"].ToString()).ToString();
            dzcx_out1.Tczfze = DataTool.stringToDouble(dtInfo.Rows[0]["tczfze"].ToString()).ToString();

            SIGNOUT_out SIGNOUT_out1 = new SIGNOUT_out();
            StringBuilder jsfjylsh = new StringBuilder(2048);
            int opt3 = Ynydyb.signout(ProgramGlobal.User_id, ynydybGlobal.Ywzqh, dzcx_out1, hqfsflsh_out1.Swqjwyzym, jsfjylsh, SIGNOUT_out1);
            if (opt3 != 0)
            {
                MessageBox.Show(SIGNOUT_out1.ErrorMessage + ", 异地医保--操作员签退失败！", "错误信息");
                FrmCostDownload frmCostDownload = new FrmCostDownload();
                frmCostDownload.StartPosition = FormStartPosition.CenterScreen;
                frmCostDownload.ShowDialog(this);
                return;
            }
            if (bllYnydybMethod.inBusiCycleNo("","") < 0)
            {
                MessageBox.Show("业务周期号记录失败!", "错误信息");
                return;
            }
            MessageBox.Show("签退成功!");
            this.Close();
        }

        private void FrmYnydybSign_Load(object sender, EventArgs e)
        {
            ybInit();
            DataTable dt=bllYnydybMethod.getBusiCycleNo();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["regcode"].ToString() == "")
                {
                    btnSignIn.Enabled = true;
                }
                else
                {
                    ynydybGlobal.Ywzqh = dt.Rows[0]["regcode"].ToString();
                    ynydybGlobal.Signtime = dt.Rows[0]["regdate"].ToString();
                    this.Close();
                }
            }
        }
               
    }
}
