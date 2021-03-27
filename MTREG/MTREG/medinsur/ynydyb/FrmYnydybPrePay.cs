using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.ynydyb.bll;
using MTREG.medinsur.ynydyb.bo;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.ihsp;
using MTREG.medinsur.bll;

namespace MTREG.medinsur.ynydyb
{
    public partial class FrmYnydybPrePay : Form
    {
        FrmIhspAccount frmIhspAccount;
        /// <summary>
        /// 结算界面
        /// </summary>
        public FrmIhspAccount FrmIhspAccount
        {
            get { return frmIhspAccount; }
            set { frmIhspAccount = value; }
        }

        public FrmYnydybPrePay()
        {
            InitializeComponent();
        }
        BllYnydybMethod bllYnydybMethod = new BllYnydybMethod();
        private string patienttype;
        /// <summary>
        /// 患者类型
        /// </summary>
        public string Patienttype
        {
            get { return patienttype; }
            set { patienttype = value; }
        }

        private string ihsp_id;
        /// <summary>
        /// 住院id
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }

        private void FrmYnydybOhsp_Load(object sender, EventArgs e)
        {
            lblAmt.Text=getHisFee();
            this.cmbPatientType.ValueMember = "id";
            this.cmbPatientType.DisplayMember = "name";
            var dtp = bllYnydybMethod.patientTypeList();
            this.cmbPatientType.DataSource = dtp;
            cmbPatientType.SelectedValue = patienttype;
            cmbPatientType.Enabled = false;
            prePay();
            upIhspInfo();
        }
        /// <summary>
        /// 预结算
        /// </summary>
        public void prePay()
        {
            YNYDYB ynydyb = new YNYDYB();

            //获取异地医保持卡人的个人基本信息和账户信息
            Dkcx_out dkcx_out1 = new Dkcx_out();

            int opt_dkcx1 = ynydyb.dkcx(dkcx_out1);
            if (opt_dkcx1 != 0)
            {
                MessageBox.Show(dkcx_out1.ErrorMessage + ", 获取异地医保持卡人的个人基本信息和账户信息失败！", "提示信息");
                return;
            }

            DataTable dt= bllYnydybMethod.readIhspRegInfo(ihsp_id);
            YdYlfyyjs_in ydYlfyyjs_in1 = new YdYlfyyjs_in();
            YdYlfyyjs_out ydYlfyyjs_out1 = new YdYlfyyjs_out();
            ydYlfyyjs_in1.Cbdtcqbh = dt.Rows[0]["InsuredAreaNo"].ToString();
            ydYlfyyjs_in1.Hzgrbh = dt.Rows[0]["PersonNo"].ToString(); ;
            ydYlfyyjs_in1.Zyh = dt.Rows[0]["AKC190"].ToString();
            ydYlfyyjs_in1.Fyze = this.lblAmt.Text.Trim();
            ydYlfyyjs_in1.Cfjzsj = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");
            ydYlfyyjs_in1.Zhzfje = "";///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            int opstat = ynydyb.ydylfyyjs(ydYlfyyjs_in1, ydYlfyyjs_out1);
            if (opstat != 0)
            {
                MessageBox.Show("异地医保--预结算失败:" + ydYlfyyjs_out1.ErrorMessage, "错误信息");
                return;
            }

            this.Jsylfze.Text = ydYlfyyjs_out1.Ylfze;
            this.Jszhzfje.Text = ydYlfyyjs_out1.Zhzfje;
            this.Jsybzfje.Text = ydYlfyyjs_out1.Ybzfje;
            this.Jsxjzfje.Text = ydYlfyyjs_out1.Xjzfje;
            this.Jsdblp.Text = ydYlfyyjs_out1.Dblp;
            this.Jszycs.Text = ydYlfyyjs_out1.Zycs;
            this.Jsqfx.Text = ydYlfyyjs_out1.Qfx;
            this.Jsqfxsy.Text = ydYlfyyjs_out1.Qfxsy;//
            this.Jsjrjsbf.Text = ydYlfyyjs_out1.Jrjsbf;
            this.Jsqzfbf.Text = ydYlfyyjs_out1.Qzfbf;
            this.Jsggzfbf.Text = ydYlfyyjs_out1.Ggzfbf;
            this.Jsjbyltczfbf.Text = ydYlfyyjs_out1.Jbyltczifbf;
            this.Jsjbyltczhifbf.Text = ydYlfyyjs_out1.Jbyltczhifbf;
            this.Jsdbyltczfbf.Text = ydYlfyyjs_out1.Dbyltczifbf;
            this.Jsdbyltczhifbf.Text = ydYlfyyjs_out1.Dbyltczhifbf;
            this.Jscxzfbf.Text = ydYlfyyjs_out1.Cxzfbf;
            this.Jstsrqzxbzzfbf.Text = ydYlfyyjs_out1.Tsrqzxbzzifbf;
            this.Jstsrqzxbzzhifbf.Text = ydYlfyyjs_out1.Tsrqzxbzzhifbf;
            this.Jsgwyjbylbzbf.Text = ydYlfyyjs_out1.Gwyjbylbzbf;
            this.Jsgwydbylbzbf.Text = ydYlfyyjs_out1.Gwydbylbzbf;
            this.Jsgwycxbzbf.Text = ydYlfyyjs_out1.Gwycxbzbf;
            this.Jsqtbzbf.Text = ydYlfyyjs_out1.Qtbzbf1;            
            if (ydYlfyyjs_out1.Ylfze != lblAmt.Text)
            {
                MessageBox.Show("HIS和医保费用不相同！","警告");
                return;
            }
            BllInsurMethod bllInsurMethod = new BllInsurMethod();
            int flag=bllInsurMethod.upInsurinfoFee(ihsp_id, ydYlfyyjs_out1.Ybzfje, ydYlfyyjs_out1.Zhzfje);
            if (flag < 0)
            {
                MessageBox.Show("更新医保费用信息失败!");
                return;
            }
            MessageBox.Show("预结算成功！", "提示信息");
            return;
        }

        /// <summary>
        /// 获取his总费用
        /// </summary>
        /// <returns></returns>
        public string getHisFee()
        {
            string sql = "select sun(fee) as amt from ihsp_costdet where ihsp_id=" + ihsp_id;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["amt"].ToString();
        }

        /// <summary>
        /// 点击后传送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            frmIhspAccount.YnydybAccInfo.Insurefee = Jsybzfje.Text;
            frmIhspAccount.YnydybAccInfo.InsuraccountFee = Jszhzfje.Text;
            frmIhspAccount.YnydybAccInfo.Feeamt = Jsylfze.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 更新住院登记信息
        /// </summary>
        private void upIhspInfo()
        {
            DataTable dtInfo1 = bllYnydybMethod.getIhspInfo1(ihsp_id);
            DataTable dtInfo2 = bllYnydybMethod.getIhspInfo2(ihsp_id);
            YNYDYB ynydyb = new YNYDYB();
            Hqfsflsh_out hqfsflsh_out2 = new Hqfsflsh_out();
            int optopt_hqlsh2 = ynydyb.hqfsflsh(hqfsflsh_out2);
            if (optopt_hqlsh2 != 0)
            {
                MessageBox.Show(hqfsflsh_out2.ErrorMessage + ", 异地医保--获取发送方交易流水号失败！", "错误信息");
                return;
            }
            YdGxjzdjxx_in ydGxjzdjxx_in1 = new YdGxjzdjxx_in();
            YdGxjzdjxx_out ydGxjzdjxx_out1 = new YdGxjzdjxx_out();
            DataTable dtInsure = bllYnydybMethod.readIhspRegInfo(ihsp_id);
            ydGxjzdjxx_in1.Fsfjylsh = hqfsflsh_out2.Swqjwyzym;
            ydGxjzdjxx_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
            ydGxjzdjxx_in1.Hzybkh = dtInsure.Rows[0]["SICardNo"].ToString();
            ydGxjzdjxx_in1.Hzcbdtcqbh = dtInsure.Rows[0]["InsuredAreaNo"].ToString();
            ydGxjzdjxx_in1.Czybh = ProgramGlobal.User_id;
            ydGxjzdjxx_in1.Ywzqh = ynydybGlobal.Ywzqh;
            ydGxjzdjxx_in1.Zyh = dtInsure.Rows[0]["AKC190"].ToString();
            ydGxjzdjxx_in1.Cyks = dtInfo2.Rows[0]["depart"].ToString();
            ydGxjzdjxx_in1.Cycw = dtInfo2.Rows[0]["bed"].ToString();
            ydGxjzdjxx_in1.Cyzdmc = dtInfo1.Rows[0]["outdiagn"].ToString();
            ydGxjzdjxx_in1.Cyzdys = dtInfo2.Rows[0]["doctor"].ToString();
            ydGxjzdjxx_in1.Cyyy = dtInfo1.Rows[0]["outreason"].ToString();
            ydGxjzdjxx_in1.Cyjbr = dtInfo1.Rows[0]["doctor"].ToString();
            StringBuilder jsfjylsh_ydgxjzdjxx = new StringBuilder(2048);
            int opt4 = ynydyb.ydgxjzdjxx(jsfjylsh_ydgxjzdjxx, ydGxjzdjxx_in1, ydGxjzdjxx_out1);
            if (opt4 != 0)
            {
                MessageBox.Show(ydGxjzdjxx_out1.ErrorMessage + ", 异地医保--更新就诊登记信息失败！", "错误信息");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
