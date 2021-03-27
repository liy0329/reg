using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdsch.clinic.bll;
using System.Web.UI.WebControls;
using MTREG.medinsur.hdyb.clinic.bo;

namespace MTREG.medinsur.hdsch
{
    public partial class FrmHdschClinic : Form
    {
        BllHdschClinic bllHdschClinic = new BllHdschClinic(); 
        public FrmHdschClinic()
        {
            InitializeComponent();
        }
        private InsurInfo insurInfo;

        internal InsurInfo InsurInfo
        {
            get { return insurInfo; }
            set { insurInfo = value; }
        }
        string patientType;
        /// <summary>
        /// 传递患者类型
        /// </summary>
        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }

        public void SetValue()
        {
            this.cmbPatientType.SelectedValue = patientType;
        }
        private int hdsch()
        {
            Dryjbxxhzh_out dryjbxxhzh_out = new Dryjbxxhzh_out();
            Hdsch hdsch = new Hdsch();
            int opt = hdsch.dryjbxxzhxx(dryjbxxhzh_out,tbxPersonNum.Text);
            if (opt != 0)
            {
                MessageBox.Show(dryjbxxhzh_out.Message + "，读医保API人员基本信息和账户信息失败！", "提示信息");
                lblMsg.Text = "读医保API人员基本信息和账户信息失败!";
                return -1;
            }

            //  cmbMediType.SelectedValue = dryjbxxhzh_out.Rylb;

            tbxCompanyName.Text = dryjbxxhzh_out.Dwmc;
            tbxCompanyNum.Text = dryjbxxhzh_out.Dwbh;
            tbxICCardID.Text = dryjbxxhzh_out.Ickh;
            tbxIDCard.Text = dryjbxxhzh_out.Sfzh;
            tbxName.Text = dryjbxxhzh_out.Xm;
            tbxPersonalNum.Text = dryjbxxhzh_out.Grbh;
            tbxSex.Text = dryjbxxhzh_out.Xb;
            if (dryjbxxhzh_out.Csrq != "" && dryjbxxhzh_out.Csrq != null)
            {
                try
                {
                    string year = dryjbxxhzh_out.Csrq.Substring(0, 4);
                    string moths = dryjbxxhzh_out.Csrq.Substring(4, 2);
                    string dys = dryjbxxhzh_out.Csrq.Substring(6, 2);
                    string time = year + "-" + moths + "-" + dys;
                    dryjbxxhzh_out.Csrq = Convert.ToDateTime(time).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
                    this.dtpBirth.Value = Convert.ToDateTime(dryjbxxhzh_out.Csrq);
                }
                catch (Exception ex) { }
            }

            //计算账户余额
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
            string balance = (lnjz + bnzr - zhzc).ToString();
            tbxBalance.Text = balance;
            //判断住院状态
            if (dryjbxxhzh_out.Zyzt == "住院未结算" || dryjbxxhzh_out.Zyzt == "中途结算")
            {
                MessageBox.Show("此人目前为住院状态，不能进行门诊结算操作！", "提示信息");
                return 1;
            }
            //读封锁信息
            Dqryfsxx_out dqryfsxx_out = new Dqryfsxx_out();
            int opt2 = hdsch.dqryfsxx(dryjbxxhzh_out.Grbh, dqryfsxx_out,tbxPersonNum.Text);
            if (opt2 != 0)
            {
                MessageBox.Show(dqryfsxx_out.Message + "，读医保API人员账户封锁信息失败！", "提示信息");
                lblSuccess.Text = "读医保API人员账户封锁信息失败！";
                return -1;
            }
            int fsjb = int.Parse(dqryfsxx_out.Fsjb);
            if (fsjb == 1)
            {
                tbxIsBlock.Text = "统筹不可用";
                if (MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付!", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return 1;
                }
            }
            else if (fsjb == 2)
            {
                tbxIsBlock.Text = "全封锁";
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                return 1;
            }
            else if (fsjb == 0)
            {
                tbxIsBlock.Text = "不锁";
            }
            //insurInfo.Approvenum = ;
            insurInfo.PatientType = dryjbxxhzh_out.Rylb;
            insurInfo.Balance = balance;
            insurInfo.Companyname = dryjbxxhzh_out.Dwmc;
            insurInfo.Companynum = dryjbxxhzh_out.Dwbh;
            insurInfo.Iccardid = dryjbxxhzh_out.Ickh;
            insurInfo.Idcard = dryjbxxhzh_out.Sfzh;
            insurInfo.Isblock = dqryfsxx_out.Fsjb;
            insurInfo.Name = dryjbxxhzh_out.Xm;
            insurInfo.PersonalNum = dryjbxxhzh_out.Grbh;
            insurInfo.Sex = dryjbxxhzh_out.Xb;
            insurInfo.Birth = dryjbxxhzh_out.Csrq;
            //insurInfo.Insurfee = ;
            //insurInfo.Selffee = ;
            insurInfo.Ihsptype = cmbMediType.SelectedValue.ToString();
            //insurInfo.Ihspdiagn = ;
            insurInfo.Clinicicd = lblClinicDisease.Text.ToString();
            //insurInfo.Clinicdiagn = ;
            lblSuccess.Text = "读卡成功！";
            return 0;
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            int result = hdsch();
        }

        private void FrmHdschClinic_Load(object sender, EventArgs e)
        {
            lblClinicDisease.Visible = false;
            lblMsg.Visible = false;
            //加载下拉列表
            loadSelectDrop();
        }
        private void loadSelectDrop()
        {
            //医疗类别-AKA130
            var dtm = bllHdschClinic.getMediTypeInfo();
            this.cmbMediType.ValueMember = "Id";
            this.cmbMediType.DisplayMember = "Name";
            this.cmbMediType.DataSource = dtm;
            //审批类别
            var dta = bllHdschClinic.getApproTypeInfo();
            this.cmbApproType.ValueMember = "id";
            this.cmbApproType.DisplayMember = "Name";
            this.cmbApproType.DataSource = dta;
            cmbApproType.SelectedValue = -1;

            //患者类型的初始化
            var dtp = bllHdschClinic.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            SetValue();
            this.cmbPatientType.Enabled = false;
            dgvClinicDiagn.Visible = false;
        }

        /// <summary>
        /// 医疗类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMediType_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cmbApproType.Text = "";
            this.tbxClinicDisease.Text = "";
            this.lblClinicDisease.Text = "";
            if (cmbMediType.SelectedValue == null || cmbMediType.SelectedValue.ToString() == "11" || cmbMediType.SelectedValue.ToString() == "16")
            {
                this.btnOk.Enabled = true;
                return;
            }
            this.btnOk.Enabled = false;
            string personalNum = this.tbxPersonalNum.Text.Trim();
            if (personalNum == null || personalNum == "")
            {
                MessageBox.Show("请先读卡！", "提示信息");
                return;
            }
            if (cmbMediType.SelectedValue.ToString() == "13" || cmbMediType.SelectedValue.ToString() == "15")
            {
                this.lblMsg.Text = "请选择审批类别！";
                this.lblMsg.Visible = true;
            }
            else
            {
                this.lblMsg.Visible = false;
            }
        }

        /// <summary>
        /// 审批类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbApproType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbApproType.SelectedValue == null)
            {
                return;
            }
            this.cmbApproDisease.Text = "";
            string approType = this.cmbApproType.SelectedValue.ToString();
            int approTypeI = this.cmbApproType.SelectedIndex;
            if (approType == "-1" || approTypeI < 0)
            {
                return;
            }
            string mediType = this.cmbMediType.SelectedValue.ToString();
            if (mediType == "11")
            {
                this.cmbApproType.Text = "";
                MessageBox.Show("请先选择医疗类别", "提示信息");
                return;
            }
            string personalNum = this.tbxPersonalNum.Text.Trim();
            if (personalNum == null || personalNum == "")
            {
                this.cmbApproType.Text = "";
                MessageBox.Show("请先读卡！", "提示信息");
                return;
            }
            if (mediType == "13")
            {
                if (approType != "6")
                {
                    this.cmbApproType.SelectedValue = "-1";
                    MessageBox.Show("医疗类别是慢性病，审批类别必须是慢性病！", "提示信息");
                    return;
                }
            }
            if (mediType == "15")
            {
                if (approType != "4")
                {
                    this.cmbApproType.SelectedValue = "-1";
                    MessageBox.Show("医疗类别是特殊病，审批类别必须是特殊病！", "提示信息");
                    return;
                }
            }
            Hdsch hdsch = new Hdsch();
            if (approType == "6" && mediType == "13")
            {
                Drymxbxx_out drymxbxx_out = new Drymxbxx_out();
                if (hdsch.dryyspgdmxbxx(personalNum, drymxbxx_out,tbxPersonNum.Text) == 0)
                {
                    string[] retdata = drymxbxx_out.Spxx.Split('|');
                    List<ListItem> items = new List<ListItem>();
                    items.Add(new ListItem("-1", ""));
                    for (int i = 0; i < retdata.Length; i++)
                    {
                        if (retdata[i].ToString() == "XX")
                        {
                            break;
                        }
                        if (i % 2 == 0)
                        {
                            items.Add(new ListItem(retdata[i].ToString(), retdata[i + 1].ToString()));
                            i = i + 1;
                        }
                    }
                    if (items.Count > 1)
                    {
                        this.cmbApproDisease.DisplayMember = "Text";
                        this.cmbApproDisease.ValueMember = "Value";
                        this.cmbApproDisease.DataSource = items;
                        this.cmbApproDisease.SelectedValue = "-1";
                    }
                    else
                    {
                        MessageBox.Show("审批病种为空，不能慢性病收费！", "提示信息");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(drymxbxx_out.Message + "读取慢性病信息失败", "提示信息");
                    return;
                }
            }
            else if (approType == "4" && mediType == "15")
            {
                this.cmbApproDisease.Text = "";
                List<ListItem> items = new List<ListItem>();
                items.Add(new ListItem("-1", ""));
                items.Add(new ListItem("A4000002", "尿毒症"));
                this.cmbApproDisease.DisplayMember = "Text";
                this.cmbApproDisease.ValueMember = "Value";
                this.cmbApproDisease.DataSource = items;
                this.cmbApproDisease.SelectedValue = "-1";
            }
            this.lblMsg.Text = "请选择审批病种！";
            this.lblMsg.Visible = true;
        }

        private void cmbApproDisease_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbApproDisease.SelectedValue == null)
            {
                return;
            }
            this.lblMsg.Visible = false;
            string approType = this.cmbApproType.SelectedValue.ToString();
            if (approType == "-1")
            {
                this.btnOk.Enabled = false;
                MessageBox.Show("请选择审批类别！", "提示信息");
                return;
            }
            string approDisease = this.cmbApproDisease.SelectedValue.ToString();
            if (approDisease == "-1")
            {
                this.btnOk.Enabled = false;
                return;
            }
            string personalNum = this.tbxPersonalNum.Text.Trim();
            string mediType = this.cmbMediType.SelectedValue.ToString();
            int approDisease2 = this.cmbApproDisease.SelectedIndex;
            if (approType == "4" || approType == "6")
            {
                if (approDisease2 < 0)
                {
                    this.btnOk.Enabled = false;
                    MessageBox.Show("门诊慢性病或特殊病需要选择审批病种，请选择！", "提示信息");
                    return;
                }
            }
            if (mediType == "13" || mediType == "15")
            {
                Dryspxx_in dryspxx_in = new Dryspxx_in();
                dryspxx_in.Grbh = personalNum;
                dryspxx_in.Splb = approType;
                dryspxx_in.Jbbm = this.cmbApproDisease.SelectedValue.ToString();
                Dryspxx_out dryspxx_out = new Dryspxx_out();
                Hdsch hdsch = new Hdsch();
                if (hdsch.dqryspxx(dryspxx_in, dryspxx_out,tbxPersonNum.Text) == 0)
                {
                    if (dryspxx_out.Spbz == "0")
                    {
                        this.btnOk.Enabled = false;
                        MessageBox.Show("审批未通过，请用其他方式结算！", "提示信息");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(dryspxx_out.Message + "查询审批信息失败！", "提示信息");
                    return;
                }
                this.btnOk.Enabled = true;
            }
        }

        private void tbxClinicDisease_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dgvClinicDiagn.Visible = true;
                dgvClinicDiagn.BringToFront();
                setDgvSource(tbxClinicDisease.Text.Trim());
                dgvClinicDiagn.Rows[0].Selected = true;
                dgvClinicDiagn.Focus();
            }
        }
        /// <summary>
        /// dgvIhspdiagn赋值
        /// </summary>
        /// <param name="pincode"></param>
        private void setDgvSource(string pincode)
        {
            dgvClinicDiagn.DataSource = bllHdschClinic.getClinicDisease(pincode);
            this.dgvClinicDiagn.Columns["id"].Visible = false;
            this.dgvClinicDiagn.Columns["name"].Width = 161;
            this.dgvClinicDiagn.Columns["illcode"].Visible = false;
        }

        private void dgvClinicDiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvClinicDiagn.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvClinicDiagn.CurrentRow != null)
                {
                    tbxClinicDisease.Text = dgvClinicDiagn.SelectedRows[0].Cells["name"].Value.ToString();
                    lblClinicDisease.Text = dgvClinicDiagn.SelectedRows[0].Cells["illcode"].Value.ToString();
                    dgvClinicDiagn.Visible = false;
                    dgvClinicDiagn.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvClinicDiagn.CurrentRow != null && dgvClinicDiagn.CurrentRow.Index > 0)
                {
                    dgvClinicDiagn.Rows[dgvClinicDiagn.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvClinicDiagn.CurrentRow != null && dgvClinicDiagn.CurrentRow.Index < dgvClinicDiagn.Rows.Count - 1)
                {
                    dgvClinicDiagn.Rows[dgvClinicDiagn.CurrentRow.Index + 1].Selected = true;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string mediType = this.cmbMediType.SelectedValue.ToString();
            if (mediType == "13" || mediType == "15")
            {
                string approDisease = this.cmbApproDisease.SelectedValue.ToString();
                if (approDisease == "-1" || this.cmbApproDisease.Text.Trim() == "")
                {
                    MessageBox.Show("医疗类别是慢性病或特殊病，请选择审批病种！", "提示信息");
                    return;
                }
                insurInfo.Approvenum = cmbApproDisease.SelectedValue.ToString();
                insurInfo.ApproveType = cmbApproType.SelectedValue.ToString();
            }
            else
            {
                insurInfo.Approvenum = "";
                insurInfo.ApproveType = "";
            }
            insurInfo.Clinicicd = this.lblClinicDisease.Text.Trim();
            insurInfo.Cliniciname = this.tbxClinicDisease.Text.Trim();
            if (lblSuccess.Text == "读卡成功！")
            {
                insurInfo.Msg = "0";
            }
            else
            {
                insurInfo.Msg = "-1";
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
