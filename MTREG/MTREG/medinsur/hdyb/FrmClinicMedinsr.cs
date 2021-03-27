using System;
using System.Windows.Forms;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.ihsp;
using MTHIS.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.clinic.bo;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MTREG.medinsur.hdyb.clinic.bll;
using MTREG.common;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.dor;
namespace MTREG.medinsur
{
    public partial class FrmClinicMedinsr : Form
    {
        private InsurInfo insurInfo;

        internal InsurInfo InsurInfo
        {
            get { return insurInfo; }
            set { insurInfo = value; }
        }

        

        string registinfo;
        /// <summary>
        /// 医保信息字符串
        /// </summary>
        public string Registinfo
        {
            get { return registinfo; }
            set { registinfo = value; }
        }
        BllClinicMedinsr bllClinicMedinsr = new BllClinicMedinsr();
        string patientType;
        /// <summary>
        /// 传递患者类型
        /// </summary>
        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }

        private Mzybdk mzybdk;

        internal Mzybdk Mzybdk
        {
            get { return mzybdk; }
            set { mzybdk = value; }
        }
        YBCJ yw1 = new YBCJ();

        private bool flag;
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private void SetValue()
        {
            this.cmbPatientType.SelectedValue = patientType;
        }
        public FrmClinicMedinsr()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string mediType = this.cmbMediType.SelectedValue.ToString();
            if(mediType == "13" || mediType == "15")
            {
                string approDisease = this.cmbApproDisease.SelectedValue.ToString();
                if(approDisease == "-1" || this.cmbApproDisease.Text.Trim() == "")
                {
                    MessageBox.Show("医疗类别是慢性病或特殊病，请选择审批病种！","提示信息");
                    return;
                }
                mzybdk.Jbbm = cmbApproDisease.SelectedValue.ToString();
                mzybdk.Jbmc = cmbApproDisease.Text.Trim();
            }
            else
            {
                mzybdk.Jbbm = this.lblClinicDisease.Text.Trim();
                mzybdk.Jbmc = this.tbxClinicDisease.Text.Trim();
            }
            mzybdk.Yllb = mediType;
            flag = true;
            //insurInfo.Yllb = mediType;  
            //insurInfo.Clinicicd = this.lblClinicDisease.Text.Trim();
            //insurInfo.Cliniciname = this.tbxClinicDisease.Text.Trim();
            //if (lblSuccess.Text == "读卡成功！")
            //{
            //    insurInfo.Msg = "0";
            //}
            //else
            //{
            //    insurInfo.Msg = "-1";
            //}
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClinicMedinsr_Load(object sender, EventArgs e)
        {
            lblClinicDisease.Visible = false;
            lblMsg.Visible = false;
            //加载下拉列表
            loadSelectDrop();
            //读人员基本信息和封锁状态
            //int result = hdsyb();
        }

        //初始化下拉框数据
        private void loadSelectDrop()
        {
            //医疗类别-AKA130
            var dtm = bllClinicMedinsr.getMediTypeInfo();
            this.cmbMediType.ValueMember = "Id";
            this.cmbMediType.DisplayMember = "Name";
            this.cmbMediType.DataSource = dtm;
            //审批类别
            var dta = bllClinicMedinsr.getApproTypeInfo();
            this.cmbApproType.ValueMember = "id";
            this.cmbApproType.DisplayMember = "Name";
            this.cmbApproType.DataSource = dta;
            cmbApproType.SelectedValue = -1;
            
            //患者类型的初始化
            var dtp = bllClinicMedinsr.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            this.cmbPatientType.SelectedValue = "135";
            //SetValue();
            this.cmbPatientType.Enabled = false;
            dgvClinicDiagn.Visible = false;
        }
        private int hdsyb()
        {
            //Dryjbxxhzh_out dryjbxxhzh_out = new Dryjbxxhzh_out();
            //Ybjk ybjk = new Ybjk();
            //int opt = ybjk.dryjbxxzhxx(dryjbxxhzh_out);
            //if (opt != 0)
            //{
            //    MessageBox.Show(dryjbxxhzh_out.Message + "，读医保API人员基本信息和账户信息失败！", "提示信息");
            //    lblMsg.Text = "读医保API人员基本信息和账户信息失败!";
            //    return -1;
            //}
            ///////////////////////////
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            yw_in_ryjbxxhzh.Ylzh = "0";
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return -1;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');

          //  cmbMediType.SelectedValue = dryjbxxhzh_out.Rylb;
            string grbh = ryjbxxhzh_cc[0];//个人编号
            tbxCompanyName.Text = ryjbxxhzh_cc[38];//单位名称
            tbxCompanyNum.Text = ryjbxxhzh_cc[2]; //单位编号
            tbxICCardID.Text = ryjbxxhzh_cc[3]; //IC卡号
            tbxIDCard.Text = ryjbxxhzh_cc[1];//身份证号
            tbxName.Text = ryjbxxhzh_cc[4]; //姓名
            tbxPersonalNum.Text = ryjbxxhzh_cc[0];//个人编号
            tbxSex.Text = ryjbxxhzh_cc[5];//性别
            string time = "";
            if (!string.IsNullOrEmpty(ryjbxxhzh_cc[6]))
            {
                try
                {
                    string year = ryjbxxhzh_cc[6].Substring(0, 4);
                    string moths = ryjbxxhzh_cc[6].Substring(4, 2);
                    string dys = ryjbxxhzh_cc[6].Substring(6, 2);
                    time = year + "-" + moths + "-" + dys;
                    this.dtpBirth.Value = Convert.ToDateTime(Convert.ToDateTime(time).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch (Exception ex) { }
            }

            //计算账户余额
            string lnjz_s = ryjbxxhzh_cc[50];//历年结转
            double lnjz = 0;
            if (lnjz_s != null && lnjz_s != "")
                lnjz = double.Parse(lnjz_s);

            string bnzr_s = ryjbxxhzh_cc[51];//本年注入
            double bnzr = 0;
            if (bnzr_s != null && bnzr_s != "")
                bnzr = double.Parse(bnzr_s);

            string zhzc_s = ryjbxxhzh_cc[55]; //帐户支出
            double zhzc = 0;
            if (zhzc_s != null && zhzc_s != "")
                zhzc = double.Parse(zhzc_s);
            string balance = (lnjz + bnzr - zhzc).ToString();
            tbxBalance.Text = balance;
            //判断住院状态
            if (ryjbxxhzh_cc[17] == "住院未结算" || ryjbxxhzh_cc[17] == "中途结算" || ryjbxxhzh_cc[17] == "出院未结算" || ryjbxxhzh_cc[17] == "出院未结" || ryjbxxhzh_cc[17] == "在院")
            {
                MessageBox.Show("此人目前为住院状态，不能进行门诊结算操作！", "提示信息");
                return -1;
            }

            //读封锁信息
            YBCJ_IN yw_in_ryfsxx = new YBCJ_IN();
            yw_in_ryfsxx.Yw = "AB31KC08";
            yw_in_ryfsxx.Ybcjbz = "0";
            yw_in_ryfsxx.Ylzh = "0";
            yw_in_ryfsxx.Rc = grbh;
            int opt_ryfsxx = yw1.ybcjhs(yw_in_ryfsxx);
            if (opt_ryfsxx != 0)
            {
                MessageBox.Show(yw_in_ryfsxx.Mesg, "提示信息");
                return -1;
            }
            string[] ryfsxx_cc = yw_in_ryfsxx.Cc.Split('|');
            int fsjb = int.Parse(ryfsxx_cc[4]);
            if (fsjb == 1)
            {
                this.tbxIsBlock.Text = "统筹不可用";
                if (MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付!", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return -1;
                }
            }
            if (fsjb == 2)
            {
                this.tbxIsBlock.Text = "全封锁";
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                return -1;
            }
            if (fsjb == 0)
            {
                this.tbxIsBlock.Text = "不锁";
            }

            mzybdk.Grbh = ryjbxxhzh_cc[0];//个人编号 
            mzybdk.Sfzh = ryjbxxhzh_cc[1];//身份证号
            mzybdk.Ickh = ryjbxxhzh_cc[3]; //IC卡号
            mzybdk.Xm = ryjbxxhzh_cc[4]; //姓名
            mzybdk.Dwbh = ryjbxxhzh_cc[2]; //单位编号
            mzybdk.Dwmc = ryjbxxhzh_cc[38];//单位名称
            mzybdk.Xb = ryjbxxhzh_cc[5];//性别
            mzybdk.Qh = ryjbxxhzh_cc[21];//区号
            mzybdk.Csrq = Convert.ToDateTime(time).ToString("yyyy-MM-dd HH:mm:ss"); //出生日期
            mzybdk.Zhye = balance;
            mzybdk.Sfck = "1";

            //insurInfo.Approvenum =tbxIsBlock ;
            //insurInfo.PatientType = dryjbxxhzh_out.Rylb;
            //insurInfo.Balance = balance;
            //mzybdk.Csrq = balance;
            //insurInfo.Companyname = ryjbxxhzh_cc[38];//单位名称
            //insurInfo.Companynum = ryjbxxhzh_cc[2]; //单位编号
            //insurInfo.Iccardid = ryjbxxhzh_cc[3]; //IC卡号
            //insurInfo.Idcard = ryjbxxhzh_cc[1];//身份证号
            //insurInfo.Isblock = ryfsxx_cc[4];//封锁级别
            //insurInfo.Name = ryjbxxhzh_cc[4]; //姓名
            //insurInfo.PersonalNum = ryjbxxhzh_cc[0];//个人编号 
            //insurInfo.Sex = ryjbxxhzh_cc[5];//性别
            //insurInfo.Qh = ryjbxxhzh_cc[21];//区号
            //insurInfo.Birth = Convert.ToDateTime(time).ToString("yyyy-MM-dd HH:mm:ss"); //出生日期
            ////insurInfo.Insurfee = ;
            ////insurInfo.Selffee = ;
            ////insurInfo.Ihsptype = cmbMediType.SelectedValue.ToString();
            ////insurInfo.Ihspdiagn = ;
            ////insurInfo.Clinicicd = lblClinicDisease.Text.ToString();
            ////insurInfo.Clinicdiagn = ;
            //insurInfo.Sfck = "1";
            //lblSuccess.Text = "读卡成功！";
            return 0;
        }
        //医疗类别
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
                MessageBox.Show("请先读卡！","提示信息");
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

        //审批病种
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
                MessageBox.Show("请选择审批类别！","提示信息");
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
                    MessageBox.Show("门诊慢性病或特殊病需要选择审批病种，请选择！","提示信息");
                    return;
                }
            }
            if (mediType == "13" || mediType == "15")
            {

                //调用读人员审批信息
                YBCJ_IN yw_in_dryspxx = new YBCJ_IN();
                yw_in_dryspxx.Yw = "BB31KC20";
                yw_in_dryspxx.Ybcjbz = "0";
                if (Mzybdk.Sfck == "1")
                {
                    yw_in_dryspxx.Ylzh = "0";
                }
                else
                {
                    yw_in_dryspxx.Ylzh = personalNum;
                }
                yw_in_dryspxx.Hisjl = personalNum;
                yw_in_dryspxx.Rc = personalNum + "|" + approType + "|" + this.cmbApproDisease.SelectedValue.ToString().Trim();
                int opt_dryspxx = yw1.ybcjhs(yw_in_dryspxx);
                if (opt_dryspxx != 0)
                {
                    MessageBox.Show(yw_in_dryspxx.Mesg, "提示信息");
                    return;
                }
                else
                {
                    if (yw_in_dryspxx.Cc.Split('|')[0] == "0")
                    {
                        MessageBox.Show("审批未通过，请用其他方式结算！", "提示信息");
                        this.btnOk.Enabled = false;
                        return;
                    }
                }
                this.btnOk.Enabled = true;



                ///////////////////////////
                //Dryspxx_in dryspxx_in = new Dryspxx_in();
                //dryspxx_in.Grbh = personalNum;
                //dryspxx_in.Splb = approType;
                //dryspxx_in.Jbbm = this.cmbApproDisease.SelectedValue.ToString();
                //Dryspxx_out dryspxx_out = new Dryspxx_out();
                //Ybjk ybjk = new Ybjk();
                //if (ybjk.dqryspxx(dryspxx_in, dryspxx_out) == 0)
                //{
                //    if (dryspxx_out.Spbz == "0")
                //    {
                //        this.btnOk.Enabled = false;
                //        MessageBox.Show("审批未通过，请用其他方式结算！","提示信息");
                //        return;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show(dryspxx_out.Message + "查询审批信息失败！","提示信息");
                //    return;
                //}
                //this.btnOk.Enabled = true;
            }
        }
        /// <summary>
        /// 疾病简码下拉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            dgvClinicDiagn.DataSource = bllClinicMedinsr.getClinicDisease(pincode);
            this.dgvClinicDiagn.Columns["id"].Width = 100;
            this.dgvClinicDiagn.Columns["name"].Width = 400;
        }

        private void dgvClinicDiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvClinicDiagn.Rows.Count > 0)
            {
                int rowindex = this.dgvClinicDiagn.CurrentRow.Index;
                if (e.KeyData == Keys.Enter && rowindex >= 0)
                {
                    tbxClinicDisease.Text = dgvClinicDiagn.Rows[rowindex].Cells["name"].Value.ToString();
                    lblClinicDisease.Text = dgvClinicDiagn.Rows[rowindex].Cells["id"].Value.ToString();
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
        //审批类别
        private void cmbApproType_SelectionChangeCommitted(object sender, EventArgs e)
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


            Ybjk ybjk = new Ybjk();
            if (approType == "6" && mediType == "13")
            {
                //调用人员已审批过的慢性病信息
                YBCJ_IN yw_in_dryyspgdmxbxx = new YBCJ_IN();
                yw_in_dryyspgdmxbxx.Yw = "BB31SPXX";
                yw_in_dryyspgdmxbxx.Ybcjbz = "0";
                if (mzybdk.Sfck == "1")
                {
                    yw_in_dryyspgdmxbxx.Ylzh = "0";
                }
                else
                {
                    yw_in_dryyspgdmxbxx.Ylzh = personalNum;
                }
                yw_in_dryyspgdmxbxx.Hisjl = personalNum;
                yw_in_dryyspgdmxbxx.Rc = personalNum;
                int opt_dryyspgdmxbxx = yw1.ybcjhs(yw_in_dryyspgdmxbxx);
                if (opt_dryyspgdmxbxx != 0)
                {
                    MessageBox.Show(yw_in_dryyspgdmxbxx.Mesg, "提示信息");
                    return;
                }
                else
                {
                    string[] retdata = yw_in_dryyspgdmxbxx.Cc.Split('|');
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
            }
            else if (approType == "4" && mediType == "15")
            {
                this.cmbApproDisease.Text = "";
                List<ListItem> items = new List<ListItem>();
                items.Add(new ListItem("", "-1"));
                items.Add(new ListItem("尿毒症", "A4000002"));
                this.cmbApproDisease.DisplayMember = "Text";
                this.cmbApproDisease.ValueMember = "Value";
                this.cmbApproDisease.DataSource = items;
                this.cmbApproDisease.SelectedValue = "-1";
            }
            this.lblMsg.Text = "请选择审批病种！";
            this.lblMsg.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hdsyb();
        }
    }
}
