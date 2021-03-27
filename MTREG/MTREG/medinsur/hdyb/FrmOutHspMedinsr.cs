using System;
using System.Windows.Forms;
using MTREG.medinsur.bll;
using MTREG.ihsp;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.bo;
using System.Data;
using MTREG.common;
using System.Text;
namespace MTREG.medinsur
{
    public partial class FrmOutHspMedinsr : Form
    {
        FrmIhspAccount frmIhspAccount;
        BillCmbList billCmbList = new BillCmbList();
        BllInsur bllInsur = new BllInsur();
        Ybjk ybjk = new Ybjk();        
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

        public FrmOutHspMedinsr()
        {
            InitializeComponent();
        }
        private string invoice;
        /// <summary>
        /// 单据号
        /// </summary>
        public string Invoice
        {
            get { return invoice; }
            set { invoice = value; }
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {           
            this.frmIhspAccount.InsurInfo.Balance = tbxBalance.Text;
            this.frmIhspAccount.InsurInfo.Companyname = tbxCompanyName.Text;
            this.frmIhspAccount.InsurInfo.InsuraccountFee = tbxInsuraccountFee.Text;
            this.frmIhspAccount.InsurInfo.PersonalNum = tbxPersonalNum.Text;
            this.frmIhspAccount.InsurInfo.Insurfee = tbxInsurefee.Text;
            this.frmIhspAccount.InsurInfo.InsuraccountFee=tbxInsuraccountFee.Text;
            this.frmIhspAccount.InsurInfo.Ihsptype = cmbYllb.SelectedValue.ToString();

            this.frmIhspAccount.InsurInfo.PersonalNum = tbxPersonalNum.Text;
            this.frmIhspAccount.InsurInfo.Maker = billCmbList.getDoctorName(ProgramGlobal.User_id);
            this.DialogResult = DialogResult.OK;
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

        /// <summary>
        /// 进入窗口加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOutHspMedinsr_Load(object sender, EventArgs e)
        {
            BillIhspAct billIhspAct = new BillIhspAct();

            #region 患者类型;医疗类别
            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatientType.ValueMember = "id";
                this.cmbPatientType.DisplayMember = "name";
                this.cmbPatientType.DataSource = dtp;
            }
            cmbPatientType.Enabled = false;

            DataTable dta = bllInsur.aka130();
            if (dta.Rows.Count > 0)
            {
                this.cmbYllb.ValueMember = "id";
                this.cmbYllb.DisplayMember = "name";
                this.cmbYllb.DataSource = dta;
            }
            #endregion

            hdsyb();
            DataTable dt= billIhspAct.insurInfo(IhspId);
            if (dt.Rows[0]["opstat"].ToString() == Insurinfostate.MIDSETT.ToString())
            {
                cmbYllb.SelectedValue = 29;//年终结算后出院
                cmbYllb.Enabled = false;
            }
        }

        /// <summary>
        /// 邯郸市医保预结算
        /// </summary>
        private void hdsyb()
        {
            BillIhspcost billIhspcost = new BillIhspcost();
            DataTable dt = billIhspcost.ihspIdSearch(ihspId);            
            BllInsur bllInsur = new BllInsur();
            StringBuilder returnMsg = new StringBuilder();
            //个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态|经办人
            DataTable dtInfo = bllInsur.readRegInfo(ihspId);
            this.cmbPatientType.SelectedValue = PatientType;
            this.tbxPersonalNum.Text = dtInfo.Rows[0]["PersonalNum"].ToString();
            this.tbxCompanyName.Text = dt.Rows[0]["companyname"].ToString();
            this.tbxCompanyNum.Text = dtInfo.Rows[0]["CompanyNo"].ToString();
            this.tbxICCardID.Text = dtInfo.Rows[0]["Iccardid"].ToString();
            this.tbxIDCard.Text = dt.Rows[0]["idcard"].ToString();
            this.tbxName.Text = dt.Rows[0]["ihspname"].ToString();
            this.tbxSex.Text = dt.Rows[0]["sex"].ToString();
            this.tbxInsurefee.Text = "0";
            this.tbxBalance.Text = dtInfo.Rows[0]["Balance"].ToString();
            //费用传输
            bllInsur.costTransfer(IhspId, PatientType, returnMsg);
            if (returnMsg.ToString() != "")
            {
                MessageBox.Show(returnMsg.ToString());
                return;
            }
            Zyjs_in zyjs_in = new Zyjs_in();
            Zyjs_out zyjs_out = new Zyjs_out();
            zyjs_in.Djh = Invoice;
            zyjs_in.Grbh = dtInfo.Rows[0]["PersonalNum"].ToString();
            zyjs_in.Jbr = billCmbList.getDoctorName(ProgramGlobal.User_id);
            zyjs_in.Mzzyh = dt.Rows[0]["ihspcode"].ToString();
            zyjs_in.Yllb = dtInfo.Rows[0]["Ihsptype"].ToString();
            zyjs_in.Zffs = "0";
            zyjs_in.Zhzfje = "0";
            int flag = ybjk.zy_yjs(zyjs_in, zyjs_out);
            if (flag < 0)
            {
                MessageBox.Show("住院预结算失败!");
                this.Close();
            }
            this.tbxFyzje.Text = zyjs_out.Ylfze;
            this.tbxBctczfje.Text = zyjs_out.Bctczfje;
            this.tbxBcxjyfzf.Text = zyjs_out.Bcxjzfje;
            this.tbxInsuraccountFee.Text = zyjs_out.Bczhzfje;
            this.tbxQfx.Text = zyjs_out.Bcqfxbz;
            this.tbxGwyjjzf.Text = zyjs_out.Bcgwybzzcje;
            this.tbxBcdbzfje.Text = zyjs_out.Bcdbzfje;

            BllInsurMethod bllInsurMethod = new BllInsurMethod();
            bllInsurMethod.upInsurinfoFee(IhspId, zyjs_out.Bctczfje, zyjs_out.Bczhyzf);
        }
    }
}
