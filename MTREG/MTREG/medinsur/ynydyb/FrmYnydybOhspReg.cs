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
using MTREG.ihsp.bll;
using MTHIS.common;

namespace MTREG.medinsur.ynydyb
{
    public partial class FrmYnydybOhspReg : Form
    {
        public FrmYnydybOhspReg()
        {
            InitializeComponent();
        }
        private string sickName;

        private string ihsp_id;
        /// <summary>
        /// 住院号
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }

        private void FrmYnydybOhspReg_Load(object sender, EventArgs e)
        {
            BillIhspcost billIhspcost = new BillIhspcost();
            DataTable dt = billIhspcost.ihspIdSearch(Ihsp_id);
            this.sickName = dt.Rows[0]["ihspname"].ToString();
        }

        private void btnDk_Click(object sender, EventArgs e)
        {
            //获取异地医保持卡人的个人基本信息和账户信息
            Dkcx_out dkcx_out1 = new Dkcx_out();

            YNYDYB ynydyb = new YNYDYB();
            int opt_dkcx = ynydyb.dkcx(dkcx_out1);
            if (opt_dkcx != 0)
            {
                MessageBox.Show(dkcx_out1.ErrorMessage + ", 获取异地医保持卡人的个人基本信息和账户信息失败！", "提示信息");
                return;
            }
            this.tbx_grbh.Text = dkcx_out1.Grbm;
            this.tbx_dkxm.Text = dkcx_out1.Xm;
        }
        /// <summary>
        /// 无费退院
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_wfty_Click(object sender, EventArgs e)
        {
            if (this.tbx_dkxm.Text.Trim() != sickName)
            {
                MessageBox.Show(string.Format(@"患者姓名与医保卡持有者不一致，请确认！(患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", sickName, this.tbx_dkxm.Text.Trim()));
                return;
            }
            YNYDYB ynydyb_ydwfty = new YNYDYB();
            Hqfsflsh_out hqfsflsh_out_ydwfty = new Hqfsflsh_out();
            int opt_hqjslsh_wfty = ynydyb_ydwfty.hqfsflsh(hqfsflsh_out_ydwfty);
            if (opt_hqjslsh_wfty != 0)
            {
                MessageBox.Show(hqfsflsh_out_ydwfty.ErrorMessage + ", 异地医保--获取【无费退院】发送方交易流水号失败！", "错误信息");
                return;
            }

            YdWfty_in ydWfty_in1 = new YdWfty_in();
            YdWfty_out ydWfty_out1 = new YdWfty_out();
            BllYnydybMethod bllYnydybMethod = new BllYnydybMethod();
            DataTable dtReg = bllYnydybMethod.readIhspRegInfo(ihsp_id);//记录的医保信息
            ydWfty_in1.Fsfjylsh = hqfsflsh_out_ydwfty.Swqjwyzym;
            ydWfty_in1.Hzcbdtcqbh = dtReg.Rows[0]["InsuredAreaNo"].ToString();
            ydWfty_in1.Hzgrbh = dtReg.Rows[0]["PersonNo"].ToString();
            ydWfty_in1.Hzybkh = dtReg.Rows[0]["SICardNo"].ToString();
            ydWfty_in1.Czybh = ProgramGlobal.User_id;
            ydWfty_in1.Ywzqh = ynydybGlobal.Ywzqh;

            ydWfty_in1.Zyh = dtReg.Rows[0]["AKC190"].ToString();
            ydWfty_in1.Djjyfhdjylsh = dtReg.Rows[0]["SenderSerialNo"].ToString();
            ydWfty_in1.Jbr = ProgramGlobal.Username;

            StringBuilder jsfjylsh_ydwfty = new StringBuilder(2048);
            int opstat = ynydyb_ydwfty.ydwfty(jsfjylsh_ydwfty, ydWfty_in1, ydWfty_out1);
            if (opstat != 0)
            {

                if (opstat == -2)
                {
                    YNYDYB ynydyb_ydwftycz = new YNYDYB();
                    Hqfsflsh_out hqfsflsh_out_ydwftycz = new Hqfsflsh_out();
                    int opt_hqjslsh_djcz = ynydyb_ydwftycz.hqfsflsh(hqfsflsh_out_ydwftycz);
                    if (opt_hqjslsh_djcz != 0)
                    {
                        MessageBox.Show(hqfsflsh_out_ydwftycz.ErrorMessage + ", 异地医保--获取【无费退院冲正】发送方交易流水号失败！", "错误信息");
                        return;
                    }

                    YdCzjy_in ydCzjy_in1 = new YdCzjy_in();
                    YdCzjy_out ydCzjy_out1 = new YdCzjy_out();

                    ydCzjy_in1.Fsfjylsh = hqfsflsh_out_ydwftycz.Swqjwyzym;
                    ydCzjy_in1.Hzcbdtcqbh = dtReg.Rows[0]["InsuredAreaNo"].ToString();
                    ydCzjy_in1.Hzgrbh = dtReg.Rows[0]["PersonNo"].ToString();
                    ydCzjy_in1.Hzybkh = dtReg.Rows[0]["SICardNo"].ToString();
                    ydCzjy_in1.Czybh = ProgramGlobal.User_id;
                    ydCzjy_in1.Ywzqh = ynydybGlobal.Ywzqh;
                    ydCzjy_in1.Yjym = "22";
                    ydCzjy_in1.Yfsfjylsh = ydWfty_in1.Djjyfhdjylsh;


                    StringBuilder jsfjylsh_ydwftycz = new StringBuilder(2048);
                    int opt_ydwftycz = ynydyb_ydwftycz.ydczjy(jsfjylsh_ydwftycz, ydCzjy_in1, ydCzjy_out1);
                    if (opt_ydwftycz != 0)
                    {
                        MessageBox.Show("异地医保--【无费退院冲正交易】失败:" + ydCzjy_out1.ErrorMessage, "错误信息");
                        return;
                    }
                    if (ydCzjy_out1.Czzt == "0")
                    {
                        MessageBox.Show("无需冲正！", "【-2】无费退院冲正");
                        return;
                    }
                    else if (ydCzjy_out1.Czzt == "1")
                    {
                        MessageBox.Show("冲正成功！", "【-2】无费退院冲正");
                        return;
                    }
                    else if (ydCzjy_out1.Czzt == "2")
                    {
                        MessageBox.Show("禁止冲正！", "【-2】无费退院冲正");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("异地医保--【无费退院】失败:" + ydWfty_out1.ErrorMessage, "错误信息");
                    return;
                }
            }
            bllYnydybMethod.upopstat("XX", ihsp_id);
            bllYnydybMethod.upinsurstat("SIGN", ihsp_id);//住院医保状态
            MessageBox.Show("医保无费退院成功！");
            this.Close();
        }        
    }
}
