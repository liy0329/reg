using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp;
using MTREG.ihsp.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdyb.bo;
using MTHIS.common;
using MTREG.medinsur.bll;

namespace MTREG.medinsur.hdsch
{
    public partial class FrmHdschOutHsp : Form
    {
        FrmIhspAccount frmIhspAccount;
        BillCmbList billCmbList = new BillCmbList();
        BllHdsch bllHdsch = new BllHdsch();
        Hdsch hdsch = new Hdsch();
        Dryjbxxhzh_out dryjbxxhzh_out = new Dryjbxxhzh_out();
        Dqryfsxx_out dqryfsxx_out = new Dqryfsxx_out();
        public FrmIhspAccount FrmIhspAccount
        {
            get { return frmIhspAccount; }
            set { frmIhspAccount = value; }
        }
        private string ihspId;
        /// <summary>
        /// 住院号id
        /// </summary>
        public string IhspId
        {
            get { return ihspId; }
            set { ihspId = value; }
        }
        private string patientType;
        /// <summary>
        /// 患者类型
        /// </summary>
        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }
        public FrmHdschOutHsp()
        {
            InitializeComponent();
        }

        private void FrmHdschOutHsp_Load(object sender, EventArgs e)
        {
            BillIhspAct billIhspAct = new BillIhspAct();
            #region 患者类型;医疗类别
            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatientType.ValueMember = "id";
                this.cmbPatientType.DisplayMember = "name";
                this.cmbPatientType.DataSource = dtp;
                this.cmbPatientType.SelectedValue = PatientType;
            }
            cmbPatientType.Enabled = false;

            DataTable dta = bllHdsch.aka130();
            if (dta.Rows.Count > 0)
            {
                this.cmbYllb.ValueMember = "id";
                this.cmbYllb.DisplayMember = "name";
                this.cmbYllb.DataSource = dta;
            }
            #endregion
            DataTable dt = billIhspAct.insurInfo(IhspId);
            if (dt.Rows[0]["opstat"].ToString() == "MIDSETT")
            {
                cmbYllb.SelectedValue = 29;//年终结算后出院
                cmbYllb.Enabled = false;
            }
        }
        /// <summary>
        /// 单击确定按钮:邯郸市医保预结算
        /// </summary>
        private void hdschOk()
        {
            StringBuilder returnMsg = new StringBuilder();
            bllHdsch.hdschcostTransfer(IhspId, PatientType, returnMsg);
            if (returnMsg.ToString() != "")
            {
                MessageBox.Show(returnMsg.ToString());
                return;
            }
            Zyjs_in zyjs_in = new Zyjs_in();
            Zyjs_out zyjs_out = new Zyjs_out();
            BillIhspcost billIhspcost = new BillIhspcost();
            DataTable dt = billIhspcost.ihspIdSearch(IhspId);
            zyjs_in.Djh = dt.Rows[0]["ihspcode"].ToString();
            zyjs_in.Grbh = dryjbxxhzh_out.Grbh;
            zyjs_in.Jbr = billCmbList.getDoctorName(ProgramGlobal.User_id);
            zyjs_in.Mzzyh = dt.Rows[0]["ihspcode"].ToString();
            zyjs_in.Yllb = cmbYllb.SelectedValue.ToString();
            zyjs_in.Zffs = "0";
            zyjs_in.Zhzfje = "0";
            int flag = hdsch.zy_yjs(zyjs_in, zyjs_out, tbxPersonalNum.Text);            
            if (flag < 0)
            {
                MessageBox.Show("住院预结算失败!");
                this.Close();
            }
            BllInsurMethod bllInsurMethod = new BllInsurMethod();
            bllInsurMethod.upInsurinfoFee(IhspId, zyjs_out.Bctczfje, zyjs_out.Bczhyzf);
        }
        /// <summary>
        /// 邯郸市城合预结算
        /// </summary>
        private void hdsyb()
        {
            FormCollection fmCollection = System.Windows.Forms.Application.OpenForms;
            int flag = hdsch.dryjbxxzhxx(dryjbxxhzh_out,tbxPersonalNum.Text);
            if (flag < 0)
            {
                MessageBox.Show("读人员基本信息和账户信息失败!");
                return;
            }
            //判断住院状态
            if (dryjbxxhzh_out.Zyzt == "住院未结算" || dryjbxxhzh_out.Zyzt == "中途结算")
            {
                MessageBox.Show("此人目前为住院状态，不能进行住院登记操作！", "提示信息");
                this.Close();
                fmCollection["FrmIhspAccount"].Close();
            }

            //封锁状态
            int isblock = hdsch.dqryfsxx(dryjbxxhzh_out.Grbh, dqryfsxx_out, dryjbxxhzh_out.Grbh);
            if (isblock != 0)
            {
                MessageBox.Show(dqryfsxx_out.Message + ", 读医保API人员帐户封锁信息失败！", "提示信息");
                this.Close();
            }
            int fsjb = int.Parse(dqryfsxx_out.Fsjb.ToString());
            if (fsjb == 1)
            {
                DialogResult dialogresult = MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付,请先进行医保转自费后按自费进行结算!", "提示信息", MessageBoxButtons.OK);
                if (dialogresult == DialogResult.OK)
                {
                    this.Close();
                    fmCollection["FrmIhspReg"].Close();
                }

            }
            if (fsjb == 2)
            {
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                this.Close();
                fmCollection["FrmIhspReg"].Close();
            }
            if (fsjb == 0)
            {
                this.tbxIsBlock.Text = "不锁";
            }
            if (dryjbxxhzh_out.Csrq != "" && dryjbxxhzh_out.Csrq != null)
            {
                try
                {
                    string year = dryjbxxhzh_out.Csrq.Substring(0, 4);
                    string moths = dryjbxxhzh_out.Csrq.Substring(4, 2);
                    string dys = dryjbxxhzh_out.Csrq.Substring(6, 2);
                    string sj = year + "-" + moths + "-" + dys;
                    dryjbxxhzh_out.Csrq = Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
                    this.dtpBirth.Value = Convert.ToDateTime(dryjbxxhzh_out.Csrq);
                }
                catch (Exception ex) { }
            }

            string lnjz_s = dryjbxxhzh_out.ZhLnjz;
            double lnjz = 0;
            if (lnjz_s != null && lnjz_s != "")
                lnjz = double.Parse(lnjz_s);
            string bnzr_s = dryjbxxhzh_out.ZhBnzr;
            double bnzr = 0;
            if (bnzr_s != null && bnzr_s != "")
                bnzr = double.Parse(bnzr_s);
            string zhzc_s = dryjbxxhzh_out.ZhZhzc;
            double zhzc = 0;
            if (zhzc_s != null && zhzc_s != "")
                zhzc = double.Parse(zhzc_s);
            string zhye = (lnjz + bnzr - zhzc).ToString();
            this.tbxBalance.Text = zhye;//账户余额
            this.tbxInsuraccountFee.Text = zhye;//账户支付默认等于账户余额
            this.cmbPatientType.SelectedValue = PatientType;
            this.tbxCompanyName.Text = dryjbxxhzh_out.Dwmc;
            this.tbxCompanyNum.Text = dryjbxxhzh_out.Dwbh;
            this.tbxICCardID.Text = dryjbxxhzh_out.Ickh;
            this.tbxIDCard.Text = dryjbxxhzh_out.Sfzh;
            this.tbxName.Text = dryjbxxhzh_out.Xm;
            this.tbxPersonalNum.Text = dryjbxxhzh_out.Grbh;
            this.tbxSex.Text = dryjbxxhzh_out.Xb;
            this.tbxInsurefee.Text = "0";
        }

        /// <summary>
        /// 提取按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExtract_Click(object sender, EventArgs e)
        {
            hdsyb();
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            hdschOk();

            this.frmIhspAccount.InsurInfo.Balance = tbxBalance.Text;
            this.frmIhspAccount.InsurInfo.Companyname = tbxCompanyName.Text;
            this.frmIhspAccount.InsurInfo.InsuraccountFee = tbxInsuraccountFee.Text;
            this.frmIhspAccount.InsurInfo.PersonalNum = tbxPersonalNum.Text;
            this.frmIhspAccount.InsurInfo.Insurfee = tbxInsurefee.Text;
            this.frmIhspAccount.InsurInfo.InsuraccountFee = tbxInsuraccountFee.Text;

            this.frmIhspAccount.InsurInfo.PersonalNum = dryjbxxhzh_out.Grbh;
            this.frmIhspAccount.InsurInfo.Maker = billCmbList.getDoctorName(ProgramGlobal.User_id);
            this.Close();
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
