using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.common;
using MTREG.tools;
using MTHIS.common;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.clinic.bo;
using MTREG.medinsur;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.dor;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdsch.clinic.bll;
using MTREG.medinsur.hdsch;
using MTREG.medinsur.hsdryb;
using MTREG.medinsur.hsdryb.bll;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.gysyb.clinic;
using MTREG.medinsur.gysyb.bo;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.ynsyb.clinic;
using MTREG.medinsur.ynsyb.bo;
using MTREG.medinsur.ynsyb.clinic.bll;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.ynydyb;
using MTREG.medinsur.ynydyb.bll;
using MTREG.medinsur.gzsyb.bo;
using MTREG.common.bll;
using MTREG.netpay.bo;
using MTREG.netpay;
using MTHIS.tools;
using MTREG.main;
using MTHIS.main.bll;
using MTREG;
using MTREG.medinsur.sjzsyb.bean;
using System.Runtime.InteropServices;

namespace MTREG.clinic
{
    public partial class FrmClinicCost : Form
    {
        Mzybdk mzybdk = new Mzybdk();
        InsurInfo InsurInfo = new InsurInfo();
        BllClinicReg bllRegister = new BllClinicReg();
        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        BllClinicCost bllClinicCharge = new BllClinicCost();
        Register register = new Register();
        Sybdk_Entity sybdk_entity = new Sybdk_Entity();//贵阳市医保
        PersonInfo personInfo = new PersonInfo();//贵州省医保
        BllClinicReg bllClinicReg = new BllClinicReg();
        Billjc blljc = new Billjc();
        mz_dk SJZ_DK = new mz_dk();//石家庄读卡out
        string netpaytype = "-1";//支付
        /// <summary>
        /// 结算信息
        /// </summary>
        ClinicAccount clinicAccount = new ClinicAccount();
        string registInfo = "";
        string clinic_cost_ids = "";
        string clinic_costdet_ids = "";
        string clinic_rcp_id = "";
        string chk_app_ids = "";
        string Ylfkfs_id = "";//医疗付款方式id

        string register_id = "";
        string register_billcode = "";
        string patienttypeKeyname = "";
        string currDate = "";
        string member_id = "";
        string invoicekind = "";
        internal Register Register
        {
            get { return register; }
            set { register = value; }
        }

        public FrmClinicCost()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>·
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClinicCharge_Load(object sender, EventArgs e)
        {

            initFormInfo();//加载结算元素
            initDgvList();//加载界面表格
            //cbxCost.Checked = true;
            panelBasItem.Visible = false;
            tbxPincode.Focus();
            tbxPincode.Select(0, 0);
            lblReadCardMsg.Text = "";
            dtpEtime.Visible = false;
            dtpStime.Visible = false;
            MaximizeBox = false;
            initCostInfo();
        }
        /// <summary>
        /// 加载界面初始值
        /// </summary>
        private void initFormInfo()
        {
            invoicekind = bllClinicReg.getInvoiceKind(); //初始化发票类型
            //科室
            var dt = bllRecipelCharge.getRegDepartInfo();

            var dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Name"] = "--全部--";
            dt.Rows.InsertAt(dr, 0);
            cmbDepart.ValueMember = "Id";
            cmbDepart.DisplayMember = "Name";
            cmbDepart.DataSource = dt;

            cmbDoctor.Text = "--请选择--";
            //医生
            var dtd = bllRecipelCharge.getDoctorInfo("");

            var drd = dtd.NewRow();
            drd["Id"] = -1;
            drd["Name"] = "--请选择--";
            dtd.Rows.InsertAt(drd, 0);
            cmbDoctor.ValueMember = "Id";
            cmbDoctor.DisplayMember = "Name";
            cmbDoctor.DataSource = dtd;
            //性别
            DataTable dtsex = new DataTable();
            dtsex.Columns.Add("name");
            dtsex.Columns.Add("value");
            DataRow dr11 = dtsex.NewRow();
            dr11[0] = "男";
            dr11[1] = 'M';
            dtsex.Rows.Add(dr11);
            DataRow dr12 = dtsex.NewRow();
            dr12[0] = "女";
            dr12[1] = 'W';
            dtsex.Rows.Add(dr12);
            DataRow dr13 = dtsex.NewRow();
            dr13[0] = "未说明性别";
            dr13[1] = 'U';
            dtsex.Rows.Add(dr13);
            DataRow dr14 = dtsex.NewRow();
            dr14[0] = "未知性别";
            dr14[1] = "";
            dtsex.Rows.Add(dr14);
            cmbSex.DisplayMember = "name";
            cmbSex.ValueMember = "value";
            cmbSex.DataSource = dtsex;
            cmbSex.SelectedValue = 'M';
            //就诊类型
            var dtp = bllRecipelCharge.getPatientType();
            cmbPatientType.ValueMember = "Id";
            cmbPatientType.DisplayMember = "Name";
            cmbPatientType.DataSource = dtp;
            cmbPatientType.SelectedValue = "1";
            patienttypeKeyname = CostInsurtypeKeyname.SELFCOST.ToString();
            getPaytypeByPatientType(patienttypeKeyname);

            //支付类型的初始化
            DataTable dtpt = bllClinicReg.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                cmbPayType.ValueMember = "id";
                cmbPayType.DisplayMember = "name";
                cmbPayType.DataSource = dtpt;
                cmbPayType.SelectedValue = "7";
            }
            ////就诊科室
            DataTable examinedepart = bllRecipelCharge.getinitjcks();
            if (examinedepart.Rows.Count > 0)
            {
                cbx_jcks.ValueMember = "id";
                cbx_jcks.DisplayMember = "name";
                cbx_jcks.DataSource = examinedepart;
                cbx_jcks.SelectedValue = 0;
            }
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void initDgvList()
        {
            dgvCliniCostdet.Rows.Add();
            dgvCliniCostdet.Rows[0].Cells["delete"].Value = "删除";
            dgvCliniCostdet.Columns["itemid"].Visible = false;
            dgvCliniCostdet.Columns["itemfrom"].Visible = false;
            dgvCliniCostdet.Columns["qty"].Visible = false;
            dgvCliniCostdet.Columns["packsole"].Visible = false;
            dgvCliniCostdet.Columns["drug_packsole_id"].Visible = false;
            dgvCliniCostdet.Columns["exedptid"].Visible = false;
            dgvCliniCostdet.Columns["chk_opkind_id"].Visible = false;
            dgvCliniCostdet.Columns["chk_type_id"].Visible = false;
            dgvCliniCostdet.Columns["chk_sampletype_id"].Visible = false;
            dgvCliniCostdet.ClearSelection();
        }


        /// <summary>
        /// 禁用编辑
        /// </summary>
        private void unableEdit()
        {
            cmbPatientType.Enabled = false;
            tbxHspcard.ReadOnly = true;
            dgvCliniCostdet.Enabled = false;
            cmbDepart.Enabled = false;
            cmbDoctor.Enabled = false;
            tbxSickName.ReadOnly = true;
            tbxAge.ReadOnly = true;

        }
        /// <summary>
        /// 启用编辑
        /// </summary>
        private void enableEdit()
        {
            cmbPatientType.Enabled = true;
            tbxHspcard.ReadOnly = false;
            dgvCliniCostdet.Enabled = true;
            cmbDepart.Enabled = true;
            cmbDoctor.Enabled = true;
            tbxSickName.ReadOnly = false;
            tbxAge.ReadOnly = false;
        }
        /// <summary>
        /// 省医保读卡
        /// </summary>
        /// <returns></returns>
        private bool readCardGZSYB()
        {
            bool flag = false;
            FrmClinMedinsurGZS frmClinMedinsurGZS = new FrmClinMedinsurGZS();
            frmClinMedinsurGZS.PatientType = this.cmbPatientType.SelectedValue.ToString();
            frmClinMedinsurGZS.StartPosition = FormStartPosition.CenterScreen;
            frmClinMedinsurGZS.ShowDialog(this);
            this.personInfo = frmClinMedinsurGZS.PersonInfo;
            flag = frmClinMedinsurGZS.Flag;
            if (!flag)
            {
                lblReadCardMsg.Text = "读卡失败！";
                return false;
            }
            lblReadCardMsg.Text = "读卡成功！";
            this.tbxAccountAmt.Text = personInfo.Swgrzhye;

            if (string.IsNullOrEmpty(personInfo.Swxm) || string.IsNullOrEmpty(tbxSickName.Text.Trim()))
            {
                MessageBox.Show(string.Format("读取处方患者姓名或医保卡持有者姓名为空，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), personInfo.Swxm));
                return false;
            }
            else if (personInfo.Swxm != tbxSickName.Text.Trim()) //处方患者姓名与医保卡持有者姓名不一致判断
            {
                MessageBox.Show(string.Format("处方患者姓名与医保卡持有者姓名不一致无法完成此次交易，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), personInfo.Swxm));
                return false;
            }
            return true;
        }
        /// <summary>
        /// 市医保读卡
        /// </summary>
        /// <returns></returns>
        private bool readCardGYSYB()
        {
            bool flag = false;
            FrmClinicMedinsrGYSYB frmClinicMedinsrGYSYB = new FrmClinicMedinsrGYSYB();
            frmClinicMedinsrGYSYB.StartPosition = FormStartPosition.CenterScreen;
            frmClinicMedinsrGYSYB.ShowDialog(this);
            this.sybdk_entity = frmClinicMedinsrGYSYB.Sybdk_entity;
            flag = frmClinicMedinsrGYSYB.flag;
            if (!flag)
            {
                lblReadCardMsg.Text = "读卡失败！";
                return false;
            }
            lblReadCardMsg.Text = "读卡成功！";
            tbxAccountAmt.Text = sybdk_entity.Zhye;//账户余额
            if (string.IsNullOrEmpty(sybdk_entity.Xm) || string.IsNullOrEmpty(tbxSickName.Text.Trim()))
            {
                MessageBox.Show(string.Format("读取处方患者姓名或医保卡持有者姓名为空，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), sybdk_entity.Xm));
                return false;
            }
            else if (sybdk_entity.Xm != tbxSickName.Text.Trim()) //处方患者姓名与医保卡持有者姓名不一致判断
            {
                MessageBox.Show(string.Format("处方患者姓名与医保卡持有者姓名不一致无法完成此次交易，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), sybdk_entity.Xm));
                return false;
            }
            return true;
        }
        /// <summary>
        /// 收费按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCostCharged_Click(object sender, EventArgs e)
        {
            js();
        }
        private void js()
        {
            if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                #region
                if (!preAccount()) //预结算
                {

                    return;
                }
                btnCostCharged.Enabled = false;
                if (!doAccount()) //结算
                {
                    btnCostCharged.Enabled = true;
                    return;
                } btnCostCharged.Enabled = true;
                if (this.cmbPayType.SelectedValue.ToString() == "1")
                {
                    Bjq.bjqts(tbxRcvFee.Text + "Y");
                    Bjq.bjqts(tbxRetFee.Text + "Z");
                }
                initCostInfo();
                #endregion
            }
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSYB.ToString()))
            {
                #region
                if (btnCostCharged.Text == "收费")
                {
                    FrmClinicMedinsr frmmzch = new FrmClinicMedinsr();
                    frmmzch.Mzybdk = mzybdk;
                    frmmzch.PatientType = this.cmbPatientType.SelectedValue.ToString();
                    frmmzch.StartPosition = FormStartPosition.CenterScreen;
                    frmmzch.ShowDialog(this);
                    if (frmmzch.Flag == false)
                    {
                        return;
                    }
                    if (string.IsNullOrEmpty(mzybdk.Grbh))
                    {
                        MessageBox.Show("个人编号为空，请读卡！", "提示信息");
                        return;
                    }
                    MZSyb syb = new MZSyb();
                    if (mzybdk.Yllb == "13" || mzybdk.Yllb == "15")
                    {
                        if (dgvCliniCostdet.Rows.Count == 0)
                        {
                            return;
                        }
                        string err_ypdz = "";
                        if (!syb.ypdzxx(ref err_ypdz, mzybdk, dgvCliniCostdet, "0")) //读疾病药品对照信息
                        {
                            FrmMesg frmmesg = new FrmMesg();
                            frmmesg.StartPosition = FormStartPosition.CenterScreen;
                            frmmesg.In_mesg = err_ypdz;
                            frmmesg.ShowDialog(this);
                            //return;
                            if (frmmesg.Falg == false)
                            {
                                return;
                            }
                        }
                    }
                    Application.DoEvents();
                    if (string.IsNullOrEmpty(mzybdk.Xm) || string.IsNullOrEmpty(tbxSickName.Text.Trim()))
                    {
                        MessageBox.Show(string.Format("读取处方患者姓名或医保卡持有者姓名为空，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), mzybdk.Xm));
                        return;
                    }
                    else if (mzybdk.Xm.Trim() != tbxSickName.Text.Trim()) //处方患者姓名与医保卡持有者姓名不一致判断
                    {
                        MessageBox.Show("处方患者姓名与医保卡持有者姓名不一致,处方患者姓名为：" + tbxSickName.Text.Trim() + ",  医保卡持有者姓名为：" + mzybdk.Xm, "提示信息");
                        return;
                    }

                    StringBuilder mage = new StringBuilder();
                    //医保卡余额不足
                    double hisfee = Convert.ToDouble(this.tbxAmount.Text.Trim());
                    double ybfee = Convert.ToDouble(InsurInfo.Balance);
                    double cha = hisfee - ybfee;
                    if (ybfee < hisfee)
                    {
                        if (MessageBox.Show("医保卡余额不足，不足金额用现金结算吗? 现金：" + cha.ToString() + " 元", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        {
                            return;
                        }
                    }

                    int[] ret_iids = new int[1];//记录mtmzblstuff.iid
                    //yb[0] 账户支付 ，yb[1]账户余额  yb[2]医保报销 yb[3]现金支付

                    this.btnCostCharged.Enabled = false;
                    this.cmbPayType.Enabled = false;
                    if (!preAccount())
                    {
                        return;
                    }
                    Bjq.bjqts(tbxPayFee.Text + "J");
                    btnCostCharged.Text = "结算";
                    unableEdit();
                    return;
                }
                else
                {
                    MTHIS.FrmMain fm = new MTHIS.FrmMain();
                    if (fm.ybsyqx() != true)
                    {
                        return;
                    }
                    btnCostCharged.Enabled = false;
                    if (!doAccount()) //结算
                    {
                        btnCostCharged.Enabled = true;
                        return;
                    } btnCostCharged.Enabled = true;
                    if (this.cmbPayType.SelectedValue.ToString() == "1")
                    {
                        Bjq.bjqts(tbxRcvFee.Text + "Y");
                        Bjq.bjqts(tbxRetFee.Text + "Z");
                    }
                    enableEdit();
                    initCostInfo();
                }
                #endregion
            }
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSCH.ToString()))
            {
                #region
                if (btnCostCharged.Text == "收费")
                {
                    FrmMzCh frmmzch = new FrmMzCh();
                    frmmzch.PatientType = this.cmbPatientType.SelectedValue.ToString();
                    frmmzch.Mzybdk = mzybdk;
                    frmmzch.StartPosition = FormStartPosition.CenterScreen;
                    frmmzch.ShowDialog(this);
                    if (frmmzch.Flag == false)
                    {
                        return;
                    }
                    if (string.IsNullOrEmpty(mzybdk.Grbh))
                    {
                        MessageBox.Show("个人编号为空，请读卡！", "提示信息");
                        return;
                    }
                    MZCH mzch = new MZCH();
                    if (mzybdk.Yllb == "13" || mzybdk.Yllb == "15")
                    {
                        if (dgvCliniCostdet.Rows.Count == 0)
                        {
                            return;
                        }
                        string err_ypdz = "";
                        if (!mzch.ypdzxx(ref err_ypdz, mzybdk, dgvCliniCostdet, "0")) //读疾病药品对照信息
                        {
                            FrmMesg frmmesg = new FrmMesg();
                            frmmesg.StartPosition = FormStartPosition.CenterScreen;
                            frmmesg.In_mesg = err_ypdz;
                            frmmesg.ShowDialog(this);
                            //return;
                        }
                    }
                    Application.DoEvents();
                    if (string.IsNullOrEmpty(mzybdk.Xm) || string.IsNullOrEmpty(tbxSickName.Text.Trim()))
                    {
                        MessageBox.Show(string.Format("读取处方患者姓名或医保卡持有者姓名为空，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), mzybdk.Xm));
                        return;
                    }
                    else if (mzybdk.Xm.Trim() != tbxSickName.Text.Trim()) //处方患者姓名与医保卡持有者姓名不一致判断
                    {
                        if (MessageBox.Show("处方患者姓名与医保卡持有者姓名不一致,处方患者姓名为：" + tbxSickName.Text.Trim() + ",  医保卡持有者姓名为：" + mzybdk.Xm, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        {
                            return;
                        }
                    }
                    this.btnCostCharged.Enabled = false;
                    this.cmbPayType.Enabled = false;
                    if (!preAccount())
                    {
                        return;
                    }
                    btnCostCharged.Enabled = true;
                    btnCostCharged.Text = "结算";
                    tbxRcvFee.SelectAll();
                    tbxRcvFee.Focus();

                }
                else
                {
                    MTHIS.FrmMain fm = new MTHIS.FrmMain();
                    if (fm.ybsyqx() != true)
                    {
                        return;
                    }
                    if (!doAccount()) //结算
                    {
                        btnCostCharged.Enabled = true;
                        return;
                    }
                    enableEdit();
                    initCostInfo();
                }
                #endregion
            }
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SJZSYB.ToString()))
            {
                #region
                if (btnCostCharged.Text == "收费")
                {
                    if (!readCardSJZYB())
                    {
                        return;
                    }
                    if (!preAccount())
                    {
                        return;
                    }
                    btnCostCharged.Enabled = true;
                    btnCostCharged.Text = "结算";
                    tbxRcvFee.SelectAll();
                    tbxRcvFee.Focus();
                    return;
                }
                else
                {
                    MTHIS.FrmMain fm = new MTHIS.FrmMain();
                    if (fm.ybsyqx() != true)
                    {
                        return;
                    }
                    if (!doAccount()) //结算
                    {
                        btnCostCharged.Enabled = true;
                        return;
                    }
                    enableEdit();
                    initCostInfo();
                }
                #endregion

            }
        }
        /// <summary>
        /// 结算
        /// </summary>
        private bool doAccount()
        {

            clinicAccount.Settledate = BillSysBase.currDate();
            //网络支付处理
            string currDate = clinicAccount.Settledate;
            string hisOrderNo = "";
            if (!doExecNetPay(currDate, ref hisOrderNo))
                return false;
            //网路支付处理_END

            //测试自助支付
            //string currDate = clinicAccount.Settledate;
            //string hisOrderNo = "";
            //if (!doExecNetPayTradePayPrecreate(currDate, ref hisOrderNo))
            //    return false;
            //测试自助支付_END


            //门诊结算                   
            clinicAccount.Id = BillSysBase.nextId("clinic_account");
            clinicAccount.Billcode = BillSysBase.newBillcode("clinic_account_billcode");//结算单
            clinicAccount.Regist_id = this.register_id;
            clinicAccount.Recivefee = (double.Parse(tbxAmount.Text.Trim().ToString()) - double.Parse(tbxInsurFee.Text) - double.Parse(tbxAccountFee.Text)).ToString();
            clinicAccount.Realfee = clinicAccount.Recivefee;
            clinicAccount.Retfee = tbxRetFee.Text.Trim().ToString();
            clinicAccount.Settledep_id = ProgramGlobal.Depart_id;
            clinicAccount.Settledby = ProgramGlobal.User_id;

            clinicAccount.Bas_paytype_id = cmbPayType.SelectedValue.ToString();

            List<ClinicInvoice> clinicInvoices = new List<ClinicInvoice>();//多张发票

            if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                //1.获取检查发票数。
                int chkInvoices = getChkInvoices2(clinicAccount, clinicInvoices);//检查发票
            }
            else
            {
                //1.获取检查发票数。
                int chkInvoices = getChkInvoices(clinicAccount, clinicInvoices);//检查发票
            }

            //2.获取处方发票数.
            //int rcpinvoices = getRcpInvoices(clinicAccount, clinicInvoices); //处方发票   

            addInvoiceHisOrderNo(clinicInvoices, hisOrderNo);
            //3.生成发票序列号。
            if (BillSysBase.currInvoiceB(ProgramGlobal.User_id, invoicekind, clinicInvoices) <= 0)
            {
                MessageBox.Show("发票已不足本次收费使用，请领取发票后，收费");
                return false;
            }
            //4定义本次收费sql
            string clinic_cost_sql = "";
            //5.结算并生成计费sql
            string invoices_sql = "";
            if (!doClinicInvoice(clinicInvoices, ref  invoices_sql))
                return false;
            clinic_cost_sql += invoices_sql;

            //6.生成结账信息单sql
            clinic_cost_sql += bllRecipelCharge.doClinicAccount(clinicAccount);
            if (string.IsNullOrEmpty(this.member_id))
            {
                clinic_cost_sql += doRegistInfo();  //挂号信息
            }
            clinic_cost_sql += bllRecipelCharge.updateClinic_costdet_unlocked(clinic_costdet_ids);
            //7 执行sql
            if (bllRecipelCharge.doExeSql(clinic_cost_sql) < 0)
            {
                MessageBox.Show("手工收费生成失败！,请检查网络，和数据库");
                SysWriteLogs.writeLogs1("手工收费错误日志.log", Convert.ToDateTime(BillSysBase.currDate()), clinic_cost_sql);
                return false;
            }
            if (MessageBox.Show("收费成功！是否打印发票？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (!patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
                {
                    string sql = "select ";
                    if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSYB.ToString()))
                    {
                        for (int i = 0; i < clinicInvoices.Count; i++)
                        {
                            ClinicInvoice clinicInvoice = clinicInvoices[i];
                            MZSyb mzsyb = new MZSyb();
                            mzsyb.fpcd(clinicInvoice.Clinic_cost_ids);
                            mzsyb.jsdcd(clinicInvoice.Clinic_cost_ids);
                        }
                    }
                    else
                        if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSCH.ToString()))
                        {
                            for (int i = 0; i < clinicInvoices.Count; i++)
                            {
                                ClinicInvoice clinicInvoice = clinicInvoices[i];
                                MZCH mzch = new MZCH();
                                mzch.fpcd(clinicInvoice.Clinic_cost_ids);
                                mzch.jsdcd(clinicInvoice.Clinic_cost_ids);
                            }

                        }
                }
                else
                {

                    FrxPrintView frxPrintView = new FrxPrintView();
                    //是否分发票
                    //int isffp = ProgramGlobal.Isffp;
                    //if (isffp == 0)
                    //{
                    //for (int i = 0; i < clinicInvoices.Count; i++)
                    //{
                    //    ClinicInvoice clinicInvoice = clinicInvoices[i];
                    //    frxPrintView.printInvoice(clinicInvoice.Clinic_cost_ids, clinicInvoice.Id);
                    //}
                    //}
                    //else
                    //{
                    Billjc bjc = new Billjc();
                    //for (int i = 0; i < clinicInvoices.Count; i++)
                    //{
                    ClinicInvoice clinicInvoice = clinicInvoices[0];
                    DataTable dt = bjc.getffp(clinicInvoice.Clinic_cost_ids);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        frxPrintView.clinic_mzmx(clinicInvoice.Id);
                        //frxPrintView.printInvoice_ffp(clinicInvoice.Clinic_cost_ids, clinicInvoice.Id, dt.Rows[j]["exedep_id"].ToString());
                    }
                    //}
                    //}
                }
            }
            return true;
        }
        /// <summary>
        /// 石家庄医保读卡
        /// </summary>
        /// <returns></returns>
        private bool readCardSJZYB()
        {
            bool flag = false;
            FrmMzYb frmmzyb = new FrmMzYb();
            frmmzyb.StartPosition = FormStartPosition.CenterScreen;
            frmmzyb.ShowDialog(this);
            this.SJZ_DK = frmmzyb.dk_out;
            this.Ylfkfs_id = frmmzyb.Ylfkfs_id;
            flag = frmmzyb.Flag;
            if (!flag)
            {
                lblReadCardMsg.Text = "读卡失败！";
                return false;
            }
            lblReadCardMsg.Text = "读卡成功！";
            this.tbxAccountAmt.Text = SJZ_DK.DK_OUT.AKC087;

            if (string.IsNullOrEmpty(SJZ_DK.DK_OUT.AAC003) || string.IsNullOrEmpty(tbxSickName.Text.Trim()))
            {
                MessageBox.Show(string.Format("读取处方患者姓名或医保卡持有者姓名为空，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), SJZ_DK.DK_OUT.AAC003));
                return false;
            }
            else if (SJZ_DK.DK_OUT.AAC003 != tbxSickName.Text.Trim()) //处方患者姓名与医保卡持有者姓名不一致判断
            {
                MessageBox.Show(string.Format("处方患者姓名与医保卡持有者姓名不一致无法完成此次交易，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), SJZ_DK.DK_OUT.AAC003));
                return false;
            }
            return true;
        }
        /// <summary>
        /// 就诊信息
        /// </summary>
        /// <returns></returns>
        private string doRegistInfo()
        {


            string currDate = BillSysBase.currDate();
            string merge_sql = "";
            //会员卡
            Member member = new Member();
            member.Name = tbxSickName.Text.Trim().ToString();
            member.Pincode = GetData.GetChineseSpell(member.Name);
            member.Sex = cmbSex.Text.ToString();
            switch (member.Sex)
            {
                case "男":
                    member.Sex = "M";
                    break;
                case "女":
                    member.Sex = "W";
                    break;
                default:
                    member.Sex = cmbSex.SelectedValue.ToString();
                    break;
            }

            //member.Birthday = dtpBirthday.Value.ToString();

            //if (cmbRace.SelectedValue != null && cmbRace.SelectedValue.ToString() != "")
            //{
            //    member.Race_id = cmbRace.SelectedValue.ToString().Trim();
            //    member.Race = cmbRace.Text.Trim().ToString();
            //}

            //member.Idcard = tbxIDCard.Text.Trim().ToString();

            //if (cmbProfession.SelectedValue != null && cmbProfession.SelectedValue.ToString().Trim() != "0")
            //{
            //    member.Profession_id = cmbProfession.SelectedValue.ToString().Trim();
            //    member.Profession = cmbProfession.Text.Trim().ToString();
            //}
            //member.Mobile = tbxPhoneNum.Text.Trim().ToString();
            //member.Companyname = tbxCompanyName.Text.Trim().ToString();

            //if (tbxHmhouseNumber.Text.Trim().Length > 20)
            //{
            //    member.Homeaddress = tbxHmhouseNumber.Text;
            //}
            //else
            //{
            //    member.Homeaddress = cmbProvince.Text.ToString() + cmbCity.Text.ToString() + cmbCounty.Text.ToString() + tbxHmhouseNumber.Text.ToString();//住址全称
            //}

            //member.Provice_id = cmbProvince.SelectedValue.ToString();
            //member.City_id = cmbCity.SelectedValue.ToString();
            //member.County_id = cmbCounty.SelectedValue.ToString();
            member.Createdate = currDate;
            member.Createdby = ProgramGlobal.User_id;
            string register_Billcode = this.register_billcode;
            if (string.IsNullOrEmpty(tbxHspcard.Text) || string.IsNullOrWhiteSpace(tbxHspcard.Text))
            {
                member.Hspcard = "WK" + register_Billcode;
            }
            else
            {
                member.Hspcard = tbxHspcard.Text.Trim();
            }
            //member.HmhouseNumber = tbxHmhouseNumber.Text.ToString();
            //挂号记录
            Register register = new Register();
            String doctor_id = cmbDoctor.SelectedValue.ToString();
            DataTable dt = bllClinicReg.getRegLevelByDoctor(doctor_id);
            String reg_level_id = dt.Rows[0]["reg_level_id"].ToString();
            register.Id = this.register_id;
            register.clininicpay = "A";
            register.Billcode = register_Billcode;
            register.Regdate = currDate;
            register.Reg_level_id = reg_level_id;
            register.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();
            if (register.Bas_patienttype_id.ToString() != "1")
            {
                register.Insuritemtype = "3";
            }
            else
            {
                register.Insuritemtype = "0";
            }
            //个人编号
            if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GZSYB.ToString().ToUpper().Trim()))
            {
                register.Insurcode = personInfo.Swgrbh;
            }
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GYSYB.ToString().ToUpper().Trim()))
            {
                register.Insurcode = sybdk_entity.Grbh;
            }
            register.Hspcard = member.Hspcard;
            register.Healthcard = member.Hspcard;
            register.Sys_region_id = "3";  //
            register.Reg_regclass_id = bllClinicReg.getRegclass();
            // register.Urgent = bllClinicReg.getUrgent(cmbUrgent.SelectedValue.ToString());
            register.Doctor_id = cmbDoctor.SelectedValue.ToString();
            register.Depart_id = cmbDepart.SelectedValue.ToString();
            register.Users_id = ProgramGlobal.User_id;
            register.Amount = tbxAmount.Text.ToString();
            register.Status = RegisterStatus.REG.ToString();
            register.Isarchive = RegisterIsarchive.OO.ToString();

            register.Name = member.Name;
            register.Pincode = member.Pincode;
            register.Sex = member.Sex;
            register.Birthday = member.Birthday;
            register.Age = tbxAge.Text.ToString();
            register.Ageunit = "4";
            register.Moonage = "0";
            register.Moonageunit = "";
            register.Createtime = currDate;
            register.Updatetime = currDate;
            // register.Clinicroom = inCall.Clinicroom;
            // register.Regnum = inCall.Sequnm.ToString();

            //就诊人员信息表
            IhspInfo ihspInfo = new IhspInfo();
            ihspInfo.Id = BillSysBase.nextId("ihsp_info");
            ihspInfo.Ihsp_id = register.Id;
            ihspInfo.Idcard = member.Idcard;
            ihspInfo.Profession = member.Profession;
            ihspInfo.Homeaddress = member.Homeaddress;//现住址
            //ihspInfo.Hmprovince = cmbProvince.SelectedValue.ToString();//省外键
            //ihspInfo.Hmcity = cmbCity.SelectedValue.ToString();//市外键
            //ihspInfo.Hmcounty = cmbCounty.SelectedValue.ToString();//县外键
            ihspInfo.HmhouseNumber = member.HmhouseNumber;
            ihspInfo.Hmstreetname = member.Hmstreetname;
            ihspInfo.Profession_id = member.Profession_id;
            ihspInfo.Homephone = member.Mobile;
            ihspInfo.Mobile = member.Mobile;
            ihspInfo.Companyname = member.Companyname;
            //ihspInfo.Race = cmbRace.Text;
            //ihspInfo.Race_id = cmbRace.SelectedValue.ToString();
            //ihspInfo.Mobile = tbxPhoneNum.Text;

            string member_id = "0";
            merge_sql += bllClinicReg.doMemberItem(member, ref member_id);
            merge_sql += bllClinicReg.addRegisterItem(register, member_id);
            merge_sql += bllClinicReg.addIhspInfoItem(ihspInfo);
            return merge_sql;
        }
        /// <summary>
        /// 增加支付订单号
        /// </summary>
        /// <param name="?"></param>
        private void addInvoiceHisOrderNo(List<ClinicInvoice> clinicInvoices, string hisOrderNo)
        {
            for (int i = 0; i < clinicInvoices.Count; i++)
            {
                ClinicInvoice clinicInvoice = clinicInvoices[i];
                clinicInvoice.HisOrderNo = hisOrderNo;
            }
        }
        private bool doExecNetPay(string currDate, ref string hisOrderNo)
        {
            bool ret = true;
            if (!netpaytype.Equals("-1"))
            {
                NetPayIn netPayIn = new NetPayIn();
                NetPayOut netPayOut = new NetPayOut();
                NetpayBll netpayBll = new NetpayBll();
                string chk_authCode = tbx_authCode.Text.Trim();
                if (chk_authCode.Length < 18)
                {
                    tbx_authCode.Text = "";
                    MessageBox.Show("扫码失败，请重新扫码，后重新支付");
                    tbx_authCode.Focus();
                    return false;
                }
                if (chk_authCode.Length > 18)
                {
                    chk_authCode = chk_authCode.Substring(0, 18);
                }

                netPayIn.AuthCode = chk_authCode;
                netPayIn.Czyh = ProgramGlobal.User_id;
                hisOrderNo = netPayIn.OuterOrderNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 
                netPayIn.Paytype = netpaytype;
                netPayIn.StoreId = "1";
                netPayIn.Subject = "门诊收费";
                netPayIn.Ddlx = "2";//订单类型（默认1）：1挂号；2缴费；3预交金 
                netPayIn.Ddly = "1";//订单来源（默认1）：1门诊;2住院

                netPayIn.Hzxm = tbxSickName.Text;
                netPayIn.Lxdh = "";
                netPayIn.Sfzh = "";
                netPayIn.Ysje = tbxPayFee.Text.Trim();
                netPayIn.Ksmc = cmbDepart.Text;
                NetpayRetRes netpayRetRes = Netpay.execNetPay(netPayIn, netPayOut);

                NetPayData netPayData = new NetPayData();
                netPayData.AppCode = netPayIn.AppCode;
                netPayData.Czyh = netPayIn.Czyh;
                netPayData.Ddlx = netPayIn.Ddlx;
                netPayData.Ddly = netPayIn.Ddly;
                netPayData.InnerOrderNo = netPayOut.InnerOrderNo;
                netPayData.Jylx = "1"; //交易类型： 1正交易；2负交易
                netPayData.Jyrq = currDate;
                netPayData.Ksmc = netPayIn.Ksmc;
                netPayData.MerchantId = netPayIn.MerchantId;
                netPayData.MerId = netPayIn.MerId;
                netPayData.OrgCode = netPayIn.OrgCode;
                netPayData.OuterOrderNo = netPayIn.OuterOrderNo;
                netPayData.Paytype = netPayIn.Paytype;
                netPayData.SourceOuterOrderNo = "";
                netPayData.StoreId = netPayIn.StoreId;
                netPayData.TradeNo = netPayOut.TradeNo;
                netPayData.Ysje = netPayIn.Ysje;
                netPayData.Hzxm = netPayIn.Hzxm;
                netPayData.Sfzh = netPayIn.Sfzh;
                netPayData.Lxdh = netPayIn.Lxdh;
                netPayData.Yymc = ProgramGlobal.HspName;
                netPayData.Zfzt = "1"; //成功
                netPayData.Ihsp_id = register_id;
                //保存记录
                string mesg = "";
                if (netpayRetRes.Errcode > 0)
                {
                    mesg = netpayRetRes.Err_mesg + ", 请重试网络支付结算或选择其它非网络支付类型结算!";
                    netPayData.Zfzt = "0";//失败
                    ret = false;
                }
                if (netpayRetRes.Errcode < 0)
                {
                    netPayData.Zfzt = "-1";//失败[支付不确定]
                    ret = false;
                    mesg = "订单号:[" + netPayIn.OuterOrderNo + "]，姓名:[" + netPayData.Hzxm + "]网络支付超时，处于支付故障状态，请及时撤销未结算信息！";
                }
                if (netpayRetRes.Errcode == 0)
                {
                    mesg = "订单号:[" + netPayIn.OuterOrderNo + "]支付成功";
                }
                netpayBll.saveToDb(netPayData);
                MessageBox.Show(mesg);
            }
            return ret;
        }

        private bool doExecNetPayTradePayPrecreate(string currDate, ref string hisOrderNo)
        {
            bool ret = true;
            if (!netpaytype.Equals("-1"))
            {
                NetPayTradePayPrecreateIn netPayTradePayPrecreateIn = new NetPayTradePayPrecreateIn();
                NetPayTradePayPrecreateOut netPayTradePayPrecreateOut = new NetPayTradePayPrecreateOut();
                NetpayBll netpayBll = new NetpayBll();

                hisOrderNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 

                netPayTradePayPrecreateIn.Czyh = ProgramGlobal.User_id;
                netPayTradePayPrecreateIn.OuterOrderNo = hisOrderNo;
                netPayTradePayPrecreateIn.Paytype = netpaytype;
                netPayTradePayPrecreateIn.StoreId = "0";
                netPayTradePayPrecreateIn.Subject = "门诊收费";
                netPayTradePayPrecreateIn.Ddlx = "2";//订单类型（默认1）：1挂号；2缴费；3预交金 
                netPayTradePayPrecreateIn.Ddly = "1";//订单来源（默认1）：1门诊;2住院
                netPayTradePayPrecreateIn.Timeout_express = "3";//3分钟超时
                netPayTradePayPrecreateIn.Hzxm = tbxSickName.Text;
                netPayTradePayPrecreateIn.Lxdh = "";
                netPayTradePayPrecreateIn.Sfzh = "";
                netPayTradePayPrecreateIn.Ysje = tbxPayFee.Text.Trim();
                netPayTradePayPrecreateIn.Ksmc = cmbDepart.Text;
                NetpayRetRes netpayRetRes = Netpay.execNetPayTradePayPrecreate(netPayTradePayPrecreateIn, netPayTradePayPrecreateOut);

                NetPayData netPayData = new NetPayData();
                netPayData.AppCode = netPayTradePayPrecreateIn.AppCode;
                netPayData.Czyh = netPayTradePayPrecreateIn.Czyh;
                netPayData.Ddlx = netPayTradePayPrecreateIn.Ddlx;
                netPayData.Ddly = netPayTradePayPrecreateIn.Ddly;
                netPayData.InnerOrderNo = netPayTradePayPrecreateOut.InnerOrderNo;
                netPayData.Jylx = "1"; //交易类型： 1正交易；2负交易
                netPayData.Jyrq = currDate;
                netPayData.Ksmc = netPayTradePayPrecreateIn.Ksmc;
                netPayData.MerchantId = netPayTradePayPrecreateIn.MerchantId;
                netPayData.MerId = netPayTradePayPrecreateIn.MerId;
                netPayData.OrgCode = netPayTradePayPrecreateIn.OrgCode;
                netPayData.OuterOrderNo = netPayTradePayPrecreateIn.OuterOrderNo;
                netPayData.Paytype = netPayTradePayPrecreateIn.Paytype;
                netPayData.SourceOuterOrderNo = "";
                netPayData.StoreId = netPayTradePayPrecreateIn.StoreId;
                netPayData.TradeNo = "";
                netPayData.Ysje = netPayTradePayPrecreateIn.Ysje;
                netPayData.Hzxm = netPayTradePayPrecreateIn.Hzxm;
                netPayData.Sfzh = netPayTradePayPrecreateIn.Sfzh;
                netPayData.Lxdh = netPayTradePayPrecreateIn.Lxdh;
                netPayData.Yymc = ProgramGlobal.HspName;
                netPayData.Zfzt = "1"; //成功
                netPayData.Ihsp_id = register_id;
                //保存记录
                string mesg = "";
                if (netpayRetRes.Errcode > 0)
                {
                    mesg = netpayRetRes.Err_mesg + ", 请重试网络支付结算或选择其它非网络支付类型结算!";
                    netPayData.Zfzt = "0";//失败
                    ret = false;
                }
                if (netpayRetRes.Errcode < 0)
                {
                    netPayData.Zfzt = "-1";//失败[支付不确定]
                    ret = false;
                    mesg = "订单号:[" + netPayTradePayPrecreateIn.OuterOrderNo + "]，姓名:[" + netPayData.Hzxm + "]网络支付超时，处于支付故障状态，请及时撤销未结算信息！";
                }
                if (netpayRetRes.Errcode == 0)
                {
                    mesg = "订单号:[" + netPayTradePayPrecreateIn.OuterOrderNo + "]支付成功";
                }
                netpayBll.saveToDb(netPayData);
                MessageBox.Show(mesg);
            }
            return ret;
        }

        /// <summary>
        /// 处方费用
        /// </summary>
        /// <param name="clinic_cost_ids">收费id</param>
        /// <param name="clinic_costdet_ids">收费明细id</param>
        /// <returns>merge_sql</returns>
        private string rcpClinicCost(string clinic_record_id, ref string clinic_cost_ids, ref string clinic_costdet_ids)
        {
            string merge_sql = "";
            double fee_rcp = 0.00;
            double drug_amt = 0.00;
            bool isclinicrcp = false;
            bool isdrugio = false;
            string clinicRcp_id = "";
            string clinicCost_id = "";
            string drugIo_id = "";
            string objdept_id = "";

            for (int i = 0; i < dgvCliniCostdet.Rows.Count - 1; i++)
            {
                if (!dgvCliniCostdet.Rows[i].Cells["itemfrom"].Value.Equals("CHECK"))
                {
                    isclinicrcp = true;

                }
                if (dgvCliniCostdet.Rows[i].Cells["itemfrom"].Value.Equals("DRUG"))
                {
                    isdrugio = true;


                }
            }
            if (isclinicrcp)//费用药品项目
            {
                clinicRcp_id = BillSysBase.nextId("clinic_rcp");
                clinicCost_id = BillSysBase.nextId("clinic_cost");
            }
            else
            {
                return "";
            }
            if (isdrugio)//药品
            {
                drugIo_id = BillSysBase.nextId("drug_io");
            }
            for (int i = 0; i < dgvCliniCostdet.Rows.Count - 1; i++)
            {
                //if (dgvCliniCostdet.Rows[i].Cells["itemfrom"].Value.ToString() == "")
                //{
                //    break;
                //}
                //else 

                if (!dgvCliniCostdet.Rows[i].Cells["itemfrom"].Value.Equals("CHECK"))
                {

                    ClinicRcpdetail clinicRcpdetail = new ClinicRcpdetail();
                    string clinic_rcpdetail_id = BillSysBase.nextId("clinic_rcpdetail");
                    clinicRcpdetail.Id = clinic_rcpdetail_id;
                    clinicRcpdetail.Clinic_rcp_id = clinicRcp_id;
                    clinicRcpdetail.Itemfrom = dgvCliniCostdet.Rows[i].Cells["itemfrom"].Value.ToString();
                    if (dgvCliniCostdet.Rows[i].Cells["exedptid"].Value == null)
                    {
                        clinicRcpdetail.Exedep_id = "";
                    }
                    else
                    {
                        clinicRcpdetail.Exedep_id = dgvCliniCostdet.Rows[i].Cells["exedptid"].Value.ToString();
                    }
                    clinicRcpdetail.Item_id = dgvCliniCostdet.Rows[i].Cells["itemid"].Value.ToString();
                    clinicRcpdetail.Name = dgvCliniCostdet.Rows[i].Cells["name"].Value.ToString();
                    clinicRcpdetail.Spec = dgvCliniCostdet.Rows[i].Cells["spec"].Value.ToString();
                    clinicRcpdetail.Itemtype_id = dgvCliniCostdet.Rows[i].Cells["itemtype_id"].Value.ToString();//itemtype_id
                    clinicRcpdetail.Packsole = dgvCliniCostdet.Rows[i].Cells["packsole"].Value.ToString();
                    clinicRcpdetail.Drug_packsole_id = dgvCliniCostdet.Rows[i].Cells["drug_packsole_id"].Value.ToString();
                    clinicRcpdetail.Unit = dgvCliniCostdet.Rows[i].Cells["unit"].Value.ToString();
                    clinicRcpdetail.Num = dgvCliniCostdet.Rows[i].Cells["num"].Value.ToString();
                    clinicRcpdetail.Prc = dgvCliniCostdet.Rows[i].Cells["prc"].Value.ToString();
                    clinicRcpdetail.Fee = dgvCliniCostdet.Rows[i].Cells["realfee"].Value.ToString();
                    bllClinicCharge.addClinicRcpdetail(clinicRcpdetail, ref merge_sql);
                    CliniCostdet cliniCostdet = new CliniCostdet();
                    cliniCostdet.Clinic_cost_id = clinicCost_id;
                    cliniCostdet.Regist_id = register_id;
                    cliniCostdet.Clinic_rcpdetail_id = clinic_rcpdetail_id;
                    cliniCostdet.Depart_id = cmbDepart.SelectedValue.ToString();
                    cliniCostdet.Doctor_id = cmbDoctor.SelectedValue.ToString();
                    if (dgvCliniCostdet.Rows[i].Cells["exedptid"].Value.ToString() == "" || dgvCliniCostdet.Rows[i].Cells["exedptid"].Value.ToString() == null)
                    {
                        cliniCostdet.Exedep_id = cliniCostdet.Depart_id;
                    }
                    else
                    {
                        cliniCostdet.Exedep_id = dgvCliniCostdet.Rows[i].Cells["exedptid"].Value.ToString();

                    }
                    cliniCostdet.Packsole = "N";
                    cliniCostdet.Drug_packsole_id = "0";
                    cliniCostdet.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();
                    string clinic_costdet_id = BillSysBase.nextId("clinic_costdet");
                    cliniCostdet.Id = clinic_costdet_id;
                    cliniCostdet.Prc = clinicRcpdetail.Prc;
                    cliniCostdet.Fee = clinicRcpdetail.Fee;
                    cliniCostdet.Discnt = "1";
                    cliniCostdet.Realfee = cliniCostdet.Fee;
                    cliniCostdet.Standcode = "";
                    cliniCostdet.Item_id = clinicRcpdetail.Item_id;
                    cliniCostdet.Itemfrom = dgvCliniCostdet.Rows[i].Cells["itemfrom"].Value.ToString();
                    cliniCostdet.Name = clinicRcpdetail.Name;
                    cliniCostdet.Unit = clinicRcpdetail.Unit;
                    cliniCostdet.Num = clinicRcpdetail.Num;
                    cliniCostdet.Itemtype_id = dgvCliniCostdet.Rows[i].Cells["itemtype_id"].Value.ToString();
                    cliniCostdet.Itemtype1_id = dgvCliniCostdet.Rows[i].Cells["itemtype1_id"].Value.ToString();
                    cliniCostdet.Rcptype = CostRcpType.RCP.ToString();
                    bllClinicReg.addClinicCostDet(cliniCostdet, ref clinic_costdet_ids, ref merge_sql);

                    if (dgvCliniCostdet.Rows[i].Cells["itemfrom"].Value.ToString().ToUpper().Equals(BasItemFrom.DRUG.ToString()))
                    {   //药品io明细
                        objdept_id = dgvCliniCostdet.Rows[i].Cells["exedptid"].Value.ToString();   //执行科室--
                        DrugIodetail drugIodetail = new DrugIodetail();
                        drugIodetail.Id = BillSysBase.nextId("drug_iodetail");
                        drugIodetail.Drugio_id = drugIo_id;
                        drugIodetail.Costdet_id = clinic_costdet_id;
                        drugIodetail.Objdept_id = dgvCliniCostdet.Rows[i].Cells["exedptid"].Value.ToString();   //执行科室--
                        drugIodetail.Item_id = dgvCliniCostdet.Rows[i].Cells["itemid"].Value.ToString();
                        drugIodetail.Name = dgvCliniCostdet.Rows[i].Cells["name"].Value.ToString();
                        drugIodetail.Spec = dgvCliniCostdet.Rows[i].Cells["spec"].Value.ToString();
                        drugIodetail.Unit = dgvCliniCostdet.Rows[i].Cells["unit"].Value.ToString();


                        if (dgvCliniCostdet.Rows[i].Cells["packsole"].Value.ToString().Trim().Equals("N"))
                        {
                            drugIodetail.Realprc = dgvCliniCostdet.Rows[i].Cells["prc"].Value.ToString();
                            drugIodetail.Packsole = dgvCliniCostdet.Rows[i].Cells["packsole"].Value.ToString();
                            drugIodetail.Drug_packsole_id = dgvCliniCostdet.Rows[i].Cells["drug_packsole_id"].Value.ToString();
                            drugIodetail.Qty = dgvCliniCostdet.Rows[i].Cells["num"].Value.ToString();
                        }
                        else
                        {
                            drugIodetail.Packsoleunit = dgvCliniCostdet.Rows[i].Cells["unit"].Value.ToString();
                            drugIodetail.Packsoleprc = dgvCliniCostdet.Rows[i].Cells["prc"].Value.ToString();
                            drugIodetail.Drug_packsole_id = dgvCliniCostdet.Rows[i].Cells["drug_packsole_id"].Value.ToString();
                            drugIodetail.Packsoleqty = dgvCliniCostdet.Rows[i].Cells["num"].Value.ToString();
                        }

                        bllRecipelCharge.addDrugIoDetailItem(drugIodetail, ref merge_sql);
                        drug_amt += DataTool.stringToDouble(clinicRcpdetail.Fee);
                    }
                    fee_rcp += double.Parse(clinicRcpdetail.Fee);
                }
            }
            if (isclinicrcp)
            {
                ClinicRcp clinicRcp = new ClinicRcp();
                ClinicCost rcpClinicCost = new ClinicCost();
                clinicRcp.Id = clinicRcp_id;
                clinicRcp.Regist_id = register_id;   //挂号外键
                clinicRcp.Billcode = BillSysBase.newBillcode("clinic_rcp_billcode");
                clinicRcp.Dep_id = cmbDepart.SelectedValue.ToString();
                clinicRcp.Doctor_id = cmbDoctor.SelectedValue.ToString();
                clinicRcp.Rcpdate = currDate;
                clinicRcp.Clinic_record_id = clinic_record_id;
                clinicRcp.Opstat = ClinicRcpOpstat.YES.ToString();
                clinicRcp.Syncost = "N";
                rcpClinicCost.Id = clinicCost_id;
                rcpClinicCost.Regist_id = register_id;
                rcpClinicCost.Billcode = register_billcode;
                rcpClinicCost.Clinic_rcp_id = clinicRcp_id;
                rcpClinicCost.Executed = "N";
                rcpClinicCost.Depart_id = cmbDepart.SelectedValue.ToString();
                rcpClinicCost.Doctor_id = cmbDoctor.SelectedValue.ToString();
                rcpClinicCost.Rcpdate = currDate;
                rcpClinicCost.Recipelfee = tbxAmount.Text.Trim().ToString();
                rcpClinicCost.Realfee = tbxAmount.Text.Trim().ToString();
                rcpClinicCost.Unlocked = "Y";
                rcpClinicCost.Retappstat = "N";
                rcpClinicCost.Rcptype = CostRcpType.RCP.ToString();
                clinicRcp.Fee = fee_rcp.ToString();
                bllClinicCharge.addClinicRcp(clinicRcp, ref merge_sql);
                bllClinicReg.addClinicCost(rcpClinicCost, ref merge_sql);
                clinic_cost_ids += clinicCost_id + ",";
            }
            if (isdrugio)
            {
                DrugIo drugIo = new DrugIo();
                drugIo.Id = drugIo_id;
                drugIo.Objdept_id = objdept_id;
                drugIo.Actdept_id = cmbDepart.SelectedValue.ToString();
                drugIo.Clinic_cost_id = clinicCost_id;
                drugIo.Createdate = currDate;

                drugIo.Amount = DataTool.FormatData(drug_amt.ToString(), "2");
                bllRecipelCharge.addDrugIoItem(drugIo, ref merge_sql);
            }
            return merge_sql;
        }
        /// <summary>
        /// 处方费用
        /// </summary>
        /// <param name="clinic_cost_ids">收费id</param>
        /// <param name="clinic_costdet_ids">收费明细id</param>
        /// <returns>merge_sql</returns>
        private string chkClinicCost(string clinic_record_id, ref string clinic_cost_ids, ref string clinic_costdet_ids)
        {
            string merge_sql = "";
            for (int i = 0; i < dgvCliniCostdet.Rows.Count - 1; i++)
            {
                if (dgvCliniCostdet.Rows[i].Cells["itemfrom"].Value.Equals("CHECK"))
                {
                    double fee_chk = 0.00;
                    string chk_app_id = BillSysBase.nextId("chk_app");
                    ChkApp chkApp = new ChkApp();
                    chkApp.Id = chk_app_id;
                    chkApp.Billcode = BillSysBase.newBillcode("chk_app_billcode");    //检查单号
                    chkApp.Diagnset_id = dgvCliniCostdet.Rows[i].Cells["itemid"].Value.ToString();
                    chkApp.Regist_id = register_id;   //外键就诊记录表
                    chkApp.Registkind = RegistKind.CLIN.ToString();
                    chkApp.Dep_id = cmbDepart.SelectedValue.ToString();
                    chkApp.Doctor_id = cmbDoctor.SelectedValue.ToString();
                    chkApp.Rcpdate = currDate;
                    if (dgvCliniCostdet.Rows[i].Cells["exedptid"].Value == null)
                    {
                        chkApp.Exedep_id = "";
                    }
                    else
                    {
                        chkApp.Exedep_id = dgvCliniCostdet.Rows[i].Cells["exedptid"].Value.ToString();
                    }
                    chkApp.Name = dgvCliniCostdet.Rows[i].Cells["name"].Value.ToString();
                    chkApp.Clinic_record_id = clinic_record_id;
                    chkApp.Instuction = "";
                    chkApp.Chk_sampletype_id = dgvCliniCostdet.Rows[i].Cells["chk_sampletype_id"].Value.ToString();
                    chkApp.Chk_type_id = dgvCliniCostdet.Rows[i].Cells["chk_type_id"].Value.ToString();
                    chkApp.Chk_opkind_id = dgvCliniCostdet.Rows[i].Cells["chk_opkind_id"].Value.ToString();
                    chkApp.Num = dgvCliniCostdet.Rows[i].Cells["num"].Value.ToString();
                    chkApp.Sendstat = "APP";
                    chkApp.Fee = dgvCliniCostdet.Rows[i].Cells["realfee"].Value.ToString();
                    chkApp.Syncost = "Y";
                    chkApp.Opstat = ClinicRcpOpstat.YES.ToString();
                    bllClinicCharge.addChkApp(chkApp, ref merge_sql);
                    ClinicCost clinicCost = new ClinicCost();
                    clinicCost.Id = BillSysBase.nextId("clinic_cost");
                    clinicCost.Regist_id = register_id;
                    clinicCost.Billcode = register_billcode;
                    clinicCost.Clinic_rcp_id = chk_app_id;
                    clinicCost.Executed = "N";
                    clinicCost.Depart_id = cmbDepart.SelectedValue.ToString();
                    clinicCost.Doctor_id = cmbDoctor.SelectedValue.ToString();
                    clinicCost.Rcpdate = currDate;
                    //clinicCost.Recipelfee = tbxAmount.Text.Trim().ToString();
                    //clinicCost.Realfee = tbxAmount.Text.Trim().ToString();
                    clinicCost.Recipelfee = chkApp.Fee;
                    clinicCost.Realfee = chkApp.Fee;
                    clinicCost.Unlocked = "Y";
                    clinicCost.Retappstat = "N";
                    clinicCost.Rcptype = CostRcpType.CHK.ToString();
                    bllClinicReg.addClinicCost(clinicCost, ref merge_sql);
                    DataTable dt = bllClinicCharge.getChkCostdet(chkApp.Diagnset_id);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        ChkAppcost chkAppcost = new ChkAppcost();
                        string chk_appcost_id = BillSysBase.nextId("chk_appcost");
                        chkAppcost.Item_id = dt.Rows[j]["id"].ToString();
                        chkAppcost.Name = dt.Rows[j]["name"].ToString();
                        chkAppcost.Spec = dt.Rows[j]["spec"].ToString();
                        chkAppcost.Unit = dt.Rows[j]["unit"].ToString();
                        chkAppcost.Num = (Convert.ToInt32(chkApp.Num) * Convert.ToDouble(dt.Rows[j]["num"].ToString())).ToString();
                        chkAppcost.Prc = dt.Rows[j]["prc"].ToString();
                        chkAppcost.Fee = (Convert.ToDouble(dt.Rows[j]["prc"].ToString()) * Convert.ToInt32(chkApp.Num) * Convert.ToDouble(dt.Rows[j]["num"].ToString())).ToString();
                        chkAppcost.Syncost = "Y";
                        chkAppcost.Id = chk_appcost_id;
                        chkAppcost.Chk_app_id = chk_app_id;
                        bllClinicCharge.addChkAppcost(chkAppcost, ref merge_sql);
                        CliniCostdet cliniCostdet = new CliniCostdet();
                        cliniCostdet.Clinic_cost_id = clinicCost.Id;
                        cliniCostdet.Regist_id = register_id;
                        cliniCostdet.Clinic_rcpdetail_id = chk_appcost_id;
                        cliniCostdet.Depart_id = cmbDepart.SelectedValue.ToString();
                        cliniCostdet.Doctor_id = cmbDoctor.SelectedValue.ToString();
                        cliniCostdet.Exedep_id = chkApp.Exedep_id;
                        cliniCostdet.Packsole = "N";
                        cliniCostdet.Drug_packsole_id = "0";
                        cliniCostdet.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();
                        string clinic_costdet_id = BillSysBase.nextId("clinic_costdet");
                        cliniCostdet.Id = clinic_costdet_id;
                        cliniCostdet.Prc = chkAppcost.Prc;
                        cliniCostdet.Fee = chkAppcost.Fee;
                        cliniCostdet.Discnt = "1";
                        cliniCostdet.Realfee = cliniCostdet.Fee;
                        cliniCostdet.Standcode = "";
                        cliniCostdet.Item_id = chkAppcost.Item_id;
                        cliniCostdet.Itemfrom = "COST";
                        cliniCostdet.Name = chkAppcost.Name;
                        cliniCostdet.Unit = chkAppcost.Unit;
                        cliniCostdet.Num = chkAppcost.Num;
                        cliniCostdet.Itemtype_id = dt.Rows[j]["itemtype_id"].ToString();
                        cliniCostdet.Itemtype1_id = dt.Rows[j]["itemtype1_id"].ToString();
                        bllClinicReg.addClinicCostDet(cliniCostdet, ref clinic_costdet_ids, ref merge_sql);
                        fee_chk += double.Parse(chkAppcost.Fee);
                    }
                    clinic_cost_ids += clinicCost.Id + ",";
                }
            }
            return merge_sql;
        }
        /// <summary>
        /// 生成收费数据
        /// </summary>
        private int doClinicCost(ref string clinic_cost_ids, ref string clinic_costdet_ids)
        {
            string merge_sql = "";
            clinic_costdet_ids = "";
            clinic_cost_ids = "";
            string clinic_record_id = "";
            bllClinicCharge.addClinicRecord(ref clinic_record_id, register_id, cmbDepart.SelectedValue.ToString(), ref merge_sql);
            merge_sql += chkClinicCost(clinic_record_id, ref clinic_cost_ids, ref  clinic_costdet_ids);
            merge_sql += rcpClinicCost(clinic_record_id, ref clinic_cost_ids, ref  clinic_costdet_ids);
            if (clinic_cost_ids != "")
            {
                clinic_cost_ids = clinic_cost_ids.Substring(0, clinic_cost_ids.Length - 1);
            }
            if (clinic_costdet_ids != "")
            {
                clinic_costdet_ids = clinic_costdet_ids.Substring(0, clinic_costdet_ids.Length - 1);
            }
            return bllClinicCharge.doExeSql(merge_sql);
        }
        private int insertPayDrugIO(string clinic_cost_ids)
        {
            #region 药品io表    和   药品io明细表
            string merge_sql = "";
            string drug_io_id = "";
            string currDate = BillSysBase.currDate();
            DataTable dt = bllRecipelCharge.getDrugIo(clinic_cost_ids);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DrugIo drugIo = new DrugIo();
                drug_io_id = BillSysBase.nextId("drug_io");
                drugIo.Objdept_id = dt.Rows[i]["exedep_id"].ToString();
                drugIo.Amount = dt.Rows[i]["amount"].ToString();      //单据金额--
                drugIo.Createdate = currDate;   //创建时间
                drugIo.Clinic_cost_id = dt.Rows[i]["cost_id"].ToString();
                DataTable dt_costdet = bllRecipelCharge.getDrugIoDet(drugIo.Clinic_cost_id);
                int k = 0;
                for (int j = 0; j < dgvCliniCostdet.Rows.Count - 1; j++)
                {
                    if (dgvCliniCostdet.Rows[j].Cells["itemfrom"].Value.ToString().ToUpper().Equals(BasItemFrom.DRUG.ToString()))
                    {//药品io明细
                        DrugIodetail drugIodetail = new DrugIodetail();
                        drugIodetail.Drugio_id = drug_io_id;
                        drugIodetail.Costdet_id = dt_costdet.Rows[k]["id"].ToString();
                        k++;
                        if (dgvCliniCostdet.Rows[j].Cells["exedptid"].Value == null)
                        {
                            drugIodetail.Objdept_id = "";
                        }
                        else
                        {
                            drugIodetail.Objdept_id = dgvCliniCostdet.Rows[j].Cells["exedptid"].Value.ToString();   //执行科室--
                        }
                        drugIodetail.Item_id = dgvCliniCostdet.Rows[j].Cells["itemid"].Value.ToString();
                        drugIodetail.Name = dgvCliniCostdet.Rows[j].Cells["name"].Value.ToString();
                        drugIodetail.Spec = dgvCliniCostdet.Rows[j].Cells["spec"].Value.ToString();
                        drugIodetail.Unit = dgvCliniCostdet.Rows[j].Cells["unit"].Value.ToString();


                        if (dgvCliniCostdet.Rows[j].Cells["packsole"].Value.ToString().Trim().Equals("N"))
                        {
                            drugIodetail.Realprc = dgvCliniCostdet.Rows[j].Cells["prc"].Value.ToString();
                            drugIodetail.Packsole = dgvCliniCostdet.Rows[j].Cells["packsole"].Value.ToString();
                            drugIodetail.Drug_packsole_id = dgvCliniCostdet.Rows[j].Cells["drug_packsole_id"].Value.ToString();
                            drugIodetail.Qty = dgvCliniCostdet.Rows[j].Cells["num"].Value.ToString();
                        }
                        else
                        {
                            drugIodetail.Packsoleunit = dgvCliniCostdet.Rows[j].Cells["unit"].Value.ToString();
                            drugIodetail.Packsoleprc = dgvCliniCostdet.Rows[j].Cells["prc"].Value.ToString();
                            drugIodetail.Drug_packsole_id = dgvCliniCostdet.Rows[j].Cells["drug_packsole_id"].Value.ToString();
                            drugIodetail.Packsoleqty = dgvCliniCostdet.Rows[j].Cells["num"].Value.ToString();
                        }
                        if (bllRecipelCharge.addDrugIoDetailItem(drugIodetail, ref merge_sql) == -1)
                        {
                            MessageBox.Show("库存数量不满足当前需求");
                            return -3;
                        }
                    }
                }
                if (k > 0)
                {

                }
            }
            if (merge_sql != "")
            {
                return bllClinicCharge.doExeSql(merge_sql);//执行语句
            }
            else
            {
                return 0;
            }
            #endregion
        }
        /// <summary>
        /// 重置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetInfo();
        }
        private void resetInfo()
        {
            tbxSickName.Text = "";
            tbxHspcard.Text = "";
            cmbDepart.Text = "--全部--";
            tbxClinicID.Text = "";
            tbxAge.Text = "";
            cmbSex.Text = "--请选择--";
            cmbDoctor.Text = "--请选择--";
        }

        private void patientTypeChange()
        {
            if (cmbPatientType.Items.Count <= 0)
            {
                return;
            }
            string patientType_id = cmbPatientType.SelectedValue.ToString();
            patienttypeKeyname = bllRecipelCharge.getPatienttypeKeyname(patientType_id);

            if (patienttypeKeyname == CostInsurtypeKeyname.SELFCOST.ToString().ToUpper().Trim() || patienttypeKeyname == CostInsurtypeKeyname.GZSYB.ToString().ToUpper().Trim())
            {

            }
            else
            {

            }
            getPaytypeByPatientType(patienttypeKeyname);
            tbxAccountAmt.Text = "0";
            lblReadCardMsg.Text = "";
            lblReadCardMsg.Visible = false;

        }
        /// <summary>
        /// 根据患者类型加载支付类型数据
        /// </summary>
        /// <param name="cmbPatientType"></param>
        /// <param name="dgvCharge"></param>
        public void getPaytypeByPatientType(string keyname)
        {
            tbxInsurFee.Text = "0.00";
            tbxAccountFee.Text = "0.00";
            tbxSbpay.Text = "0.00";
            tbxSbpayline.Text = "0.00";
        }


        /// <summary>
        /// F3、F4快捷键事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (panelBasItem.Visible == false)
            {
                if (keyData == Keys.F3)
                {
                    if (cbxDrug.Checked == true)
                    {
                        cbxCheck.Checked = true;
                    }
                    else if (cbxCheck.Checked == true)
                    {
                        cbxCost.Checked = true;
                    }
                    else if (cbxCost.Checked == true)
                    {
                        cbxDrug.Checked = true;
                    }
                    return true;
                }
                else if (keyData == Keys.F5)
                {
                    if (dgvCliniCostdet.CurrentCell.RowIndex >= 0)
                    {
                        showDgvBasItem();
                    }
                }
                else if (keyData == Keys.F2)
                {


                }
                else if (keyData == Keys.Escape)
                {

                }
            }
            if (keyData == Keys.Escape)
            {
                //this.dataGridView1.Rows.Clear();
                this.tv_jc.Visible = false;
                //this.tv_jc.Nodes.Clear();
                this.cbx_jcks.SelectedValue = "-1";
                this.cbx_jcbw.SelectedValue = "-1";

                if (panelBasItem.Visible == true)
                {
                    panelBasItem.Visible = false;
                    tbxPincode.Text = "";
                    dgvBasItem.Columns.Clear();
                }
            }
            //DataGridView激活回车键
            if (keyData == Keys.Enter)
            {
                if (this.ActiveControl.Name == btnRegist.Name)
                {
                    cmbDepart.Focus();
                    cmbDepart.DroppedDown = true;
                }

            }
            else if (keyData == Keys.Space && ActiveControl is Button)
            {
                if (this.ActiveControl.Name == btnCostCharged.Name)
                    btnCostCharged.PerformClick();

                else if (this.ActiveControl.Name == btnReadInsurCard.Name)
                    btnReadInsurCard.PerformClick();
                else if (this.ActiveControl.Name == btnRegist.Name)
                    btnRegist.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 搜索事件--用户输入内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPincode_TextChanged(object sender, EventArgs e)
        {
            //if (!cbxCheck.Checked && !cbxCost.Checked && !cbxDrug.Checked)
            //{
            //    cbxCheck.Checked = true;
            //    tbxPincode.Clear();
            //    MessageBox.Show("请先选择费用类别!");
            //    return;
            //}
            searchDgvBasItemData();
            dgvBasItem.ClearSelection();
            #region updateHeaderText
            dgvBasItem.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
            dgvBasItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBasItem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBasItem.ReadOnly = true;
            dgvBasItem.Columns["id"].DisplayIndex = 0;
            dgvBasItem.Columns["id"].HeaderText = "编码";
            dgvBasItem.Columns["id"].Width = 80;
            dgvBasItem.Columns["itemtypename"].DisplayIndex = 1;
            dgvBasItem.Columns["itemtypename"].HeaderText = "项目类别";
            dgvBasItem.Columns["itemtypename"].Width = 130;
            dgvBasItem.Columns["itemname"].DisplayIndex = 2;
            dgvBasItem.Columns["itemname"].HeaderText = "名称";
            dgvBasItem.Columns["itemname"].Width = 200;
            dgvBasItem.Columns["spec"].DisplayIndex = 3;
            dgvBasItem.Columns["spec"].HeaderText = "规格";
            dgvBasItem.Columns["spec"].Width = 80;
            dgvBasItem.Columns["unit"].DisplayIndex = 4;
            dgvBasItem.Columns["unit"].HeaderText = "单位";
            dgvBasItem.Columns["unit"].Width = 80;
            dgvBasItem.Columns["prc"].DisplayIndex = 5;
            dgvBasItem.Columns["prc"].HeaderText = "单价";
            dgvBasItem.Columns["qty"].DisplayIndex = 6;
            dgvBasItem.Columns["qty"].HeaderText = "库存";
            dgvBasItem.Columns["useqty"].Visible = false;
            dgvBasItem.Columns["dptname"].DisplayIndex = 7;
            dgvBasItem.Columns["dptname"].HeaderText = "执行科室";
            dgvBasItem.Columns["dptname"].Width = 130;
            dgvBasItem.Columns["type"].Visible = false;
            dgvBasItem.Columns["type"].HeaderText = "所属类别";
            dgvBasItem.Columns["exedep_id"].Visible = false;
            dgvBasItem.Columns["itemfrom"].Visible = false;
            dgvBasItem.Columns["packsole"].Visible = false;
            dgvBasItem.Columns["drug_packsole_id"].Visible = false;
            dgvBasItem.Columns["itemtype_id"].Visible = false;
            dgvBasItem.Columns["itemtype1_id"].Visible = false;
            dgvBasItem.Columns["chk_opkind_id"].Visible = false;
            dgvBasItem.Columns["chk_type_id"].Visible = false;
            dgvBasItem.Columns["chk_sampletype_id"].Visible = false;
            #endregion
        }
        private void searchDgvBasItemData()
        {
            string type = "";
            if (cbxCheck.Checked == true)
            {
                type = "check";
            }
            else if (cbxCost.Checked == true)
            {
                type = "cost";
            }
            else if (cbxDrug.Checked == true)
            {
                type = "drug";
            }
            else
            {
                type = "qb";
            }
            dgvBasItem.DataSource = bllClinicCharge.getBasItemData(tbxPincode.Text.Trim(), type);
            if (cbxDrug.Checked == true)
            {
                for (int i = 0; i < dgvBasItem.Rows.Count; i++)
                {
                    if (dgvBasItem.Rows[i].Cells["useqty"].Value.ToString() == "")
                    {
                        dgvBasItem.Rows[i].Cells["useqty"].Value = "0";
                    }
                    string qty = (double.Parse(dgvBasItem.Rows[i].Cells["qty"].Value.ToString()) - double.Parse(dgvBasItem.Rows[i].Cells["useqty"].Value.ToString())).ToString();
                    dgvBasItem.Rows[i].Cells["qty"].Value = qty;
                }
            }
        }
        //搜索事件--用户输入完点击回车键事件
        private void tbxPincode_KeyDown(object sender, KeyEventArgs e)
        {

        }
        //按回车键返回
        private void dgvBasItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                dgvCliniCostdet.Rows[dgvCliniCostdet.RowCount - 1].Cells["name"].Selected = true;
                dgvCliniCostdet.BeginEdit(true);
            }
            if (dgvBasItem.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvBasItem.CurrentRow != null)
                {
                    getDataFromDgvBasItem();
                    panelBasItem.Visible = false;
                    tbxPincode.Text = "";
                    dgvBasItem.Columns.Clear();
                }
            }
            else
            {
                if (e.KeyData == Keys.Enter)
                {
                    panelBasItem.Visible = false;
                    tbxPincode.Text = "";
                    dgvBasItem.Columns.Clear();
                }
            }

        }
        //将查询出来的数据写入dgvCliniCostdet控件中
        private void getDataFromDgvBasItem()
        {
            if (dgvCliniCostdet.Rows.Count > 0)   // pincode  itemtypename   exedpt   spec   num   unit   prc   discnt   realfee   delete
            {
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"].Value = dgvBasItem.CurrentRow.Cells["itemname"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemtypename"].Value = dgvBasItem.CurrentRow.Cells["itemtypename"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["exedpt"].Value = dgvBasItem.CurrentRow.Cells["dptname"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["spec"].Value = dgvBasItem.CurrentRow.Cells["spec"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["unit"].Value = dgvBasItem.CurrentRow.Cells["unit"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["prc"].Value = dgvBasItem.CurrentRow.Cells["prc"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["num"].Value = "1";
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["discnt"].Value = "100";
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["realfee"].Value = 1 * double.Parse(dgvBasItem.CurrentRow.Cells["prc"].Value.ToString().Trim()) * (double.Parse("100") / 100);
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["delete"].Value = "删除";
                try
                {
                    dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["qty"].Value = double.Parse(dgvBasItem.CurrentRow.Cells["qty"].Value.ToString()) - double.Parse(dgvBasItem.CurrentRow.Cells["useqty"].Value.ToString());//隐藏列  库存
                }
                catch (Exception)
                {

                }

                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemfrom"].Value = dgvBasItem.CurrentRow.Cells["itemfrom"].Value;//隐藏列  类别
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemid"].Value = dgvBasItem.CurrentRow.Cells["id"].Value;//隐藏列 item_id
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["packsole"].Value = dgvBasItem.CurrentRow.Cells["packsole"].Value;//隐藏列  
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["drug_packsole_id"].Value = dgvBasItem.CurrentRow.Cells["drug_packsole_id"].Value;//隐藏列 drug_packsole_id
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["exedptid"].Value = dgvBasItem.CurrentRow.Cells["exedep_id"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["chk_sampletype_id"].Value = dgvBasItem.CurrentRow.Cells["chk_sampletype_id"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["chk_type_id"].Value = dgvBasItem.CurrentRow.Cells["chk_type_id"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["chk_opkind_id"].Value = dgvBasItem.CurrentRow.Cells["chk_opkind_id"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemtype_id"].Value = dgvBasItem.CurrentRow.Cells["itemtype_id"].Value;
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemtype1_id"].Value = dgvBasItem.CurrentRow.Cells["itemtype1_id"].Value;
            }
            panelBasItem.Visible = false;
            dgvCliniCostdet.Focus();
            if (dgvCliniCostdet.Rows.Count > 0)
            {
                if (this.dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemfrom"].Value.ToString().Equals("CHECK"))
                {

                }
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["num"];
                dgvCliniCostdet.BeginEdit(false);
            }
            dgvCliniCostdet.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
        }

        //焦点跳转
        private void showDgvBasItem()
        {
            if (this.dgvCliniCostdet.CurrentCell.RowIndex == dgvCliniCostdet.Rows.Count - 1 && dgvCliniCostdet.CurrentCell.ColumnIndex == 0)
            {
                Point location = dgvCliniCostdet.Location;
                int cellX = location.X;
                int cellY = location.Y + dgvCliniCostdet.ColumnHeadersHeight + (dgvCliniCostdet.Rows.Count - 1) * dgvCliniCostdet.RowTemplate.Height;
                dgvCliniCostdet.EndEdit();
                panelBasItem.Location = new Point(cellX, cellY);
                panelBasItem.Visible = true;
                tbxPincode.Focus();
            }
        }

        //删除一行
        private void dgvCliniCostdet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                removeCurrentRow();
            }
        }
        //删除一行项目
        private void removeCurrentRow()
        {
            DataGridViewColumn column = dgvCliniCostdet.Columns[dgvCliniCostdet.CurrentCell.ColumnIndex];
            if (column is DataGridViewButtonColumn)
            {
                if (dgvCliniCostdet.CurrentRow.Index == dgvCliniCostdet.Rows.Count - 1)
                {
                    return;
                }
                if (dgvCliniCostdet.CurrentRow.Cells["name"].Value != null && !string.IsNullOrEmpty(dgvCliniCostdet.CurrentRow.Cells["name"].Value.ToString().Trim()))
                {
                    if (MessageBox.Show("确定删除【 " + dgvCliniCostdet.CurrentRow.Cells["name"].Value.ToString() + " 】吗？", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        return;
                    }
                }
                dgvCliniCostdet.Rows.Remove(dgvCliniCostdet.CurrentRow);
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"];
                calculateAmount();
            }
        }
        //计算总费用
        private void calculateAmount()
        {
            double amount = 0;
            for (int i = 0; i < dgvCliniCostdet.Rows.Count - 1; i++)
            {
                string realfee = dgvCliniCostdet.Rows[i].Cells["realfee"].Value.ToString();
                amount += Convert.ToDouble(realfee);
            }
            tbxAmount.Text = amount.ToString("0.00");
            tbxPayFee.Text = tbxAmount.Text;
            tbxRcvFee.Text = tbxPayFee.Text;
        }



        private void dgvCharge_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //computerCashVal();
        }

        private void dgvCharge_KeyUp(object sender, KeyEventArgs e)
        {
            // computerCashVal();
        }

        private void tbxAmount_TextChanged(object sender, EventArgs e)
        {
            //computerCashVal();
        }

        private bool CostDetNumFocusEnd(DataGridViewCellEventArgs e)
        {
            if (dgvCliniCostdet.Rows[e.RowIndex].Cells["num"].Value == null)
            {
                MessageBox.Show("数量不能为空！");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"];
                dgvCliniCostdet.BeginEdit(true);
                return false;
            }
            string num = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"].Value.ToString().Trim();
            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("数量不能为空！");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"];
                dgvCliniCostdet.BeginEdit(true);
                return false;
            }
            try
            {
                double number = double.Parse(num);
            }
            catch
            {
                MessageBox.Show("数量请填写数字！");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"];
                dgvCliniCostdet.BeginEdit(true);
                return false;
            }
            if (double.Parse(num) <= 0)
            {
                MessageBox.Show("数量不能小于1");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"];
                dgvCliniCostdet.BeginEdit(true);
                return false;
            }
            //如果是药品则判断库存数量

            if (dgvCliniCostdet.Rows[e.RowIndex].Cells["itemfrom"].Value == null)
            {
                dgvCliniCostdet.Rows[e.RowIndex].Cells["num"].Value = null;

                MessageBox.Show("请选择项目!");
                return false;
            }
            string itemfrom = dgvCliniCostdet.Rows[e.RowIndex].Cells["itemfrom"].Value.ToString();
            if (itemfrom.Equals(BasItemFrom.DRUG.ToString().ToUpper()))
            {
                if (dgvCliniCostdet.Rows[e.RowIndex].Cells["qty"].Value == null)
                {
                    MessageBox.Show("请选择有库存得项目!");
                    return false;
                }
                string qtyStr = dgvCliniCostdet.Rows[e.RowIndex].Cells["qty"].Value.ToString();
                string numStr = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"].Value.ToString().Trim();
                double nums = DataTool.stringToDouble(numStr);
                double qty = DataTool.stringToDouble(qtyStr);
                if (nums > qty)
                {
                    string mesage = "库存数量是：" + qtyStr + ", 比库存数量大,\r\n 点击确定继续修改数量，\r\n 点击取消删除该项目！";
                    if (MessageBox.Show(mesage, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        bool flagsss = false;
                        if (e.RowIndex == dgvCliniCostdet.Rows.Count - 1)
                        {
                            flagsss = true;
                        }
                        dgvCliniCostdet.Rows.Remove(dgvCliniCostdet.Rows[e.RowIndex]);

                        if (flagsss == true)
                        {
                            dgvCliniCostdet.Rows.Add();
                        }
                        dgvCliniCostdet.Focus();
                        dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"];
                        dgvCliniCostdet.BeginEdit(false);
                        return false;
                    }
                    dgvCliniCostdet.Focus();
                    dgvCliniCostdet.CurrentCell.Selected = true;
                    dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["num"];
                    return false;
                }
            }


            if (e.RowIndex != dgvCliniCostdet.Rows.Count - 1)
            {
                String prc = dgvCliniCostdet.Rows[e.RowIndex].Cells["prc"].Value.ToString();//单价
                String discnt = dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"].Value.ToString().Trim();//折率
                string numb = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"].Value.ToString().Trim();//

                double realfee = double.Parse(numb) * double.Parse(prc) * (double.Parse(discnt) / 100);
                realfee = Math.Round(realfee, 2);
                dgvCliniCostdet.Rows[e.RowIndex].Cells["realfee"].Value = realfee;//折率
                calculateAmount();//计算总费用
            }
            else
            {
                try
                {
                    dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"].Value = 100;
                    dgvCliniCostdet.Focus();
                    dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"];
                    dgvCliniCostdet.BeginEdit(false);
                    if (dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"].ReadOnly == true)
                    {
                        addNewRow(e.RowIndex);
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        private bool CostDetDiscntFocusEnd(DataGridViewCellEventArgs e)
        {
            if (dgvCliniCostdet.Rows[e.RowIndex].Cells["num"].Value == null)
            {
                MessageBox.Show("数量不能为空！");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"];
                dgvCliniCostdet.BeginEdit(true);
                return false;
            }
            string num = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"].Value.ToString().Trim();
            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("数量不能为空！");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"];
                dgvCliniCostdet.BeginEdit(true);
                return false;
            }
            try
            {
                double number = double.Parse(num);

            }
            catch
            {
                MessageBox.Show("数量请填写数字！");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["num"];
                dgvCliniCostdet.BeginEdit(true);
                return false;
            }

            if (dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"].Value == null)
            {
                MessageBox.Show("折率不能为空！");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"];
                dgvCliniCostdet.BeginEdit(true);
                return false;

            }
            string discnt = dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"].Value.ToString().Trim();//折率
            if (string.IsNullOrEmpty(discnt))
            {
                MessageBox.Show("折率不能为空！");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"];
                dgvCliniCostdet.BeginEdit(true);
                return false;

            }
            try
            {
                double discount = double.Parse(discnt);

            }
            catch
            {
                MessageBox.Show("折率请填写数字！");
                dgvCliniCostdet.Focus();
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"];
                dgvCliniCostdet.BeginEdit(true);
                return false;

            }
            addNewRow(e.RowIndex);
            return true;

        }
        private void dgvCliniCostdet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvCliniCostdet.Rows.Count == 0)
            {
                return;
            }
            if (dgvCliniCostdet.CurrentCell == dgvCliniCostdet.Rows[e.RowIndex].Cells["name"])
            {
                Validate();
            }
            if (dgvCliniCostdet.CurrentCell == dgvCliniCostdet.Rows[e.RowIndex].Cells["num"]) //如果焦点在数量上
            {
                if (!CostDetNumFocusEnd(e))
                    return;
            }
            if (dgvCliniCostdet.CurrentCell == dgvCliniCostdet.Rows[e.RowIndex].Cells["discnt"])//如果焦点在折率上
            {
                if (!CostDetDiscntFocusEnd(e))
                    return;
            }


        }
        /// <summary>
        /// 年龄算出生年月
        /// </summary>
        /// <param name="age"></param>
        /// <param name="dtm"></param>
        /// <returns></returns>
        private bool getBirthDayByAge(string age, DateTime dtm)
        {
            try
            {
                if (age == "")
                {
                    dtm = DateTime.Now;
                    return false;
                }
                int a = int.Parse(age);
                dtm = DateTime.Now.AddYears(-a);

            }
            catch
            {
                return false;
            }
            return true;
        }

        # region 身份证初始化
        
       

        
        
        #region 初始化身份证信息

        #endregion
        /************************端口类API *************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetCOMBaud(int iPort, ref uint puiBaudRate);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetCOMBaud(int iPort, uint uiCurrBaud, uint uiSetBaud);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPort);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int iPort);
        /**************************SAM类函数 **************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ResetSAM", CharSet = CharSet.Ansi)]
        public static extern int Syn_ResetSAM(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMStatus", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMStatus(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMID", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMID(int iPort, ref byte pucSAMID, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMIDToStr", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMIDToStr(int iPort, ref byte pcSAMID, int iIfOpen);
        /*************************身份证卡类函数 ***************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPort, ref byte pucIIN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPort, ref byte pucSN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, ref byte pucFPMsg, ref uint puiFPMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, ref byte pcFPMsgFileName, ref uint puiFPMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadNewAppMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadNewAppMsg(int iPort, ref byte pucAppMsg, ref uint puiAppMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetBmp", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetBmp(int iPort, ref byte Wlt_File);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadFPMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData, ref byte cFPhotoname);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindReader();
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindUSBReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindUSBReader();
        /***********************设置附加功能函数 ************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoPath", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoPath(int iOption, ref byte cPhotoPath);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoName", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoName(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetSexType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetSexType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetNationType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetNationType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetBornType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetBornType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeBType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeBType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeEType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeEType(int iType, int iOption);
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name; //姓名   
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            public string Sex;   //性别
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Nation; //名族
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string Born; //出生日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
            public string Address; //住址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string IDCardNo; //身份证号
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string GrantDept; //发证机关
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeBegin; // 有效开始日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeEnd;  // 有效截止日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string reserved; // 保留
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string PhotoFileName; // 照片路径
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            int m_iPort;
            int i;
            uint[] iBaud = new uint[1];
            i = Syn_FindReader();
            m_iPort = i;


            IDCardData CardMsg = new IDCardData();
            int nRet, nPort, iPhotoType;
            string stmp;
            byte[] cPath = new byte[255];
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            nPort = m_iPort;
            //Syn_SetPhotoPath(0, ref cPath[0]);	//设置照片路径	iOption 路径选项	0=C:	1=当前路径	2=指定路径
            ////cPhotoPath	绝对路径,仅在iOption=2时有效
            //iPhotoType = 0;
            Syn_SetPhotoType(4); //0 = bmp ,1 = jpg , 2 = base64 , 3 = WLT ,4 = 不生成
            //Syn_SetPhotoName(2); // 生成照片文件名 0=tmp 1=姓名 2=身份证号 3=姓名_身份证号 

            Syn_SetSexType(1);	// 0=卡中存储的数据	1=解释之后的数据,男、女、未知
            Syn_SetNationType(2);// 0=卡中存储的数据	1=解释之后的数据 2=解释之后加"族"
            Syn_SetBornType(3);			// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            Syn_SetUserLifeBType(3);	// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            Syn_SetUserLifeEType(1, 1);	// 0=YYYYMMDD(不转换),1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD,
            // 0=长期 不转换,	1=长期转换为 有效期开始+50年           
            if (Syn_OpenPort(nPort) == 0)
            {
                if (Syn_SetMaxRFByte(nPort, 80, 0) == 0)
                {
                    nRet = Syn_StartFindIDCard(nPort, ref pucIIN[0], 0);
                    nRet = Syn_SelectIDCard(nPort, ref pucSN[0], 0);
                    nRet = Syn_ReadMsg(nPort, 0, ref CardMsg);
                    if (nRet == 0)
                    {

                        //姓名
                        this.tbxSickName.Text = CardMsg.Name.ToString().Trim();

                        //性别
                        string sex = (CardMsg.Sex == "男") ? "M" : "W";
                        cmbSex.Text = CardMsg.Sex;

                        //民族
                        //this.tbxRace.Text = CardMsg.Nation;

                        //出生日期
                        DateTime time = Convert.ToDateTime(CardMsg.Born);
                        this.tbxAge.Text = (DateTime.Now.Year - time.Year).ToString();
                        //this.dtpBirthday.Value = Convert.ToDateTime(date);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  地址:" + CardMsg.Address;
                        //listBox1.Items.Add(stmp);
                        ////地址

                        //tbxAddress.Text = CardMsg.Address;

                        //stmp = Convert.ToString(System.DateTime.Now) + "  身份证号:" + CardMsg.IDCardNo;
                        //listBox1.Items.Add(stmp);
                        ////身份证号
                        //this.tbxIdcard.Text = CardMsg.IDCardNo;

                    }
                    else
                    {
                        MessageBox.Show("读取身份证信息错误");
                    }
                }
            }
            else
            {
                MessageBox.Show("打开端口失败");
            }
        }
        private void selectRegist()
        {
            FrmSearchRegister frmSearchRegister = new FrmSearchRegister();
            frmSearchRegister.FrmClinicCharge = this;
            frmSearchRegister.ShowDialog();
            if (frmSearchRegister.DialogResult == DialogResult.OK && frmSearchRegister.operFlag)
            {
                lblRegistID.Text = register.Id;
                register_id = register.Id;
                tbxClinicID.Text = register.Billcode;
                tbxHspcard.Text = register.Hspcard;
                tbxSickName.Text = register.Name;
                cmbDepart.SelectedValue = register.Depart_id;
                departChange();
                cmbDoctor.SelectedValue = register.Doctor_id;
                tbxAge.Text = register.Age;
                cmbSex.SelectedValue = register.Sex;
                //cmbPatientType.SelectedValue ="1";
                tbxSickName.ReadOnly = true;
                tbxAge.ReadOnly = true;
                cmbSex.Enabled = false;
                this.member_id = register.Member_id;

                patientTypeChange();
            }
        }

        /// <summary>
        /// 实收金额改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepart_SelectionChangeCommitted(object sender, EventArgs e)
        {
            departChange();
        }
        private void departChange()
        {
            //医生
            var dtd = bllRegister.getDoctorByDepartId(cmbDepart.SelectedValue.ToString());
            cmbDoctor.ValueMember = "Id";
            cmbDoctor.DisplayMember = "Name";
            var drd = dtd.NewRow();
            drd["Id"] = -1;
            drd["Name"] = "--请选择--";
            dtd.Rows.InsertAt(drd, 0);
            cmbDoctor.DataSource = dtd;
            if (cmbDepart.SelectedValue.ToString() == "0")
            {
                cmbDoctor.SelectedValue = -1;
            }
        }
        /// <summary>
        /// 触发发票支付编辑改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCharge_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dgvCharge.IsCurrentCellDirty)
            //{
            //    dgvCharge.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }

        //读医保卡
        private void btnReadInsurCardClick()
        {
            if (this.patienttypeKeyname.Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                return;
            }

            else if (this.patienttypeKeyname.Equals(CostInsurtypeKeyname.GYSYB.ToString()))
            {
                bool flag = false;
                FrmClinicMedinsrGYSYB frmClinicMedinsrGYSYB = new FrmClinicMedinsrGYSYB();
                frmClinicMedinsrGYSYB.StartPosition = FormStartPosition.CenterScreen;
                frmClinicMedinsrGYSYB.ShowDialog(this);
                sybdk_entity = frmClinicMedinsrGYSYB.Sybdk_entity;
                flag = frmClinicMedinsrGYSYB.flag;
                if (flag == false)
                {
                    lblReadCardMsg.Text = "读卡失败！";
                }
                else if (flag == true)
                {
                    lblReadCardMsg.Text = "读卡成功！";

                }
                lblReadCardMsg.Visible = true;
            }
            else if (this.patienttypeKeyname.Equals(CostInsurtypeKeyname.GZSYB.ToString()))
            {
                bool flag = false;
                FrmClinMedinsurGZS frmClinMedinsurGZS = new FrmClinMedinsurGZS();
                frmClinMedinsurGZS.PatientType = cmbPatientType.SelectedValue.ToString();
                frmClinMedinsurGZS.StartPosition = FormStartPosition.CenterScreen;
                frmClinMedinsurGZS.ShowDialog(this);
                personInfo = frmClinMedinsurGZS.PersonInfo;
                flag = frmClinMedinsurGZS.Flag;
                if (flag == false)
                {
                    lblReadCardMsg.Text = "读卡失败！";
                }
                else if (flag == true)
                {
                    lblReadCardMsg.Text = "读卡成功！";

                }
                lblReadCardMsg.Visible = true;
            }
        }
        private bool preAccount()
        {
            if (string.IsNullOrEmpty(tbxSickName.Text) || string.IsNullOrWhiteSpace(tbxSickName.Text))
            {
                tbxSickName.Focus();
                MessageBox.Show("姓名不能为空！");
                return false;
            }
            //if (string.IsNullOrEmpty(tbxHspcard.Text) || string.IsNullOrWhiteSpace(tbxHspcard.Text))
            //{
            //    tbxHspcard.Focus();
            //    MessageBox.Show("卡号不能为空！");
            //    return false;
            //}
            if (cmbDoctor.SelectedIndex == -1 || cmbDoctor.SelectedIndex == 0)
            {
                cmbDoctor.Focus();
                MessageBox.Show("请选择医生！");
                return false;
            }
            if (cmbDepart.SelectedIndex == -1 || cmbDepart.SelectedIndex == 0)
            {
                cmbDepart.Focus();
                MessageBox.Show("请选择科室！");
                return false;
            }
            if (string.IsNullOrEmpty(tbxAge.Text) || string.IsNullOrWhiteSpace(tbxAge.Text))
            {
                cmbDepart.Focus();
                MessageBox.Show("请输入年龄！");
                return false;
            }
            if (dgvCliniCostdet.Rows.Count < 2)
            {
                MessageBox.Show("请录入处方信息！");
                return false;
            }

            if (string.IsNullOrEmpty(register_id))
            {
                register_id = BillSysBase.nextId("register");
                register_billcode = BillSysBase.newBillcode("register_billcode");
                currDate = BillSysBase.currDate();
            }
            if (clinic_cost_ids == "")
            {
                string cost_ids = "";
                string costdet_ids = "";
                if (doClinicCost(ref cost_ids, ref costdet_ids) != 0)//生成处方并将数据插入处方表和处方明细表
                {
                    MessageBox.Show("生成处方费用失败！");
                    return false;
                }
                clinic_cost_ids = cost_ids;
                clinic_costdet_ids = costdet_ids;
            }
            //if (patienttypeKeyname == CostInsurtypeKeyname.HDSYB.ToString().ToUpper().Trim())
            //{
            //    Gysybservice gysyb = new Gysybservice();
            //    StringBuilder message = new StringBuilder(50);
            //    if (!gysyb.mzgh_kls(sybdk_entity, message))
            //    {
            //        return false;
            //    }


            //    double[] yb = new double[4];
            //    //医保模拟结算
            //    if (!gysyb.mzmnjs_kls2(sybdk_entity, clinic_costdet_ids, tbxInvoiceID.Text.Trim(),message, yb))
            //    {
            //        MessageBox.Show(message.ToString());
            //        clinic_costdet_ids = "";
            //        return false;
            //    }
            //    string cash = (double.Parse(tbxAmount.Text.Trim()) - yb[0] - yb[1] - yb[3]).ToString();
            //    tbxInsurFee.Text = yb[1].ToString();
            //    tbxAccountFee.Text = yb[0].ToString();
            //    tbxSbpayline.Text = yb[2].ToString();
            //    tbxSbpay.Text = yb[3].ToString();
            //    tbxPayFee.Text = DataTool.FormatData(cash, "2");
            //    if (cmbPayType.SelectedValue.ToString() == "1")
            //    { 

            //    }
            //}
            return true;
        }
        public void initCostInfo()
        {
            clinic_cost_ids = "";
            clinic_costdet_ids = "";
            clinic_rcp_id = "";
            chk_app_ids = "";
            tbxInsurFee.Text = "0.00";
            tbxAccountFee.Text = "0.00";
            tbxAccountFee.Text = "0.00";
            //cmbPatientType.Enabled = false;
            btnCostCharged.Text = "收费";
            tbxClinicID.Text = "";
            tbxHspcard.Text = "";
            tbxSickName.Text = "";
            tbxInvoiceID.Text = "";
            cmbDepart.SelectedValue = 0;
            cmbDoctor.SelectedValue = 0;
            tbxAge.Text = "";
            cmbSex.SelectedValue = 'M';
            cmbPatientType.SelectedValue = 1;
            tbxSickName.ReadOnly = false;
            tbxAge.ReadOnly = false;
            cmbSex.Enabled = true;
            tbxAccountAmt.Text = "0.00";
            dgvCliniCostdet.Rows.Clear();
            tbxAmount.Text = "0.00";
            tbxRcvFee.Text = "0.00";
            tbxRetFee.Text = "0.00";
            patientTypeChange();
            panelBasItem.Visible = false;
            tbxPincode.Text = "";
            dgvBasItem.Columns.Clear();
            lblReadCardMsg.Text = "";
            tbxHspcard.Focus();
            initInvoice();
            dgvCliniCostdet.Rows.Add();
            lblRegistID.Text = "";
            register_id = "";
            member_id = "";
            cmbPayType.SelectedValue = "1";
        }
        /// <summary>
        /// 获取发票信息
        /// </summary>
        public void initInvoice()
        {

            ///发票初始化
            string invoicecode = "";//发票号
            string nextinvoicesql = "";
            int invoiceNum = BillSysBase.currInvoiceA(ProgramGlobal.User_id.Trim(), invoicekind, 1, ref invoicecode, ref nextinvoicesql);
            if (invoiceNum < 10)
            {
                lblInvoiceMsg.Text = "当前发票号已不足10张，请尽快领取新的发票！如已领取，请忽略！";
                tbxInvoiceID.Text = invoicecode;
            }
            else if (invoiceNum >= 10)
            {
                lblInvoiceMsg.Text = "";
                tbxInvoiceID.Text = invoicecode;
            }
            else
            {
                lblInvoiceMsg.Text = "发票已用光，请领取发票后，收费";
                tbxInvoiceID.Text = invoicecode;
            }
        }
        /// <summary>
        /// 计算处方日期
        /// </summary>
        private void loadRecipelTime()
        {
            int dtYear, dtMonth, dtDay;
            dtYear = dtpEtime.Value.Year;
            dtMonth = dtpEtime.Value.Month;
            dtDay = dtpEtime.Value.Day;
            dtDay = dtDay - 3;
            if (dtDay <= 0)
            {
                dtMonth = dtMonth - 1;
                int Feb;
                if ((dtYear % 4 == 0 && dtYear % 100 != 0) || (dtYear % 400 == 0))
                {
                    Feb = 29;
                }
                else
                {
                    Feb = 28;
                }
                switch (dtMonth)
                {
                    case 2:
                        dtDay = Feb + dtDay;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        dtDay = 30 + dtDay;
                        break;
                    default:
                        dtDay = 31 + dtDay;
                        break;
                }
                if (dtMonth == 0)
                {
                    dtMonth = 12;
                    dtYear = dtYear - 1;
                }
            }

            dtpStime.Value = Convert.ToDateTime(dtYear.ToString() + "-" + dtMonth.ToString() + "-" + dtDay.ToString() + " 00:00:00");
        }



        private void btnReadInsurCard_KeyDown(object sender, KeyEventArgs e)
        {

        }




        private void tbx_TextChanged(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            if (!string.IsNullOrEmpty(tbx.Text))
            {
                showDgvBasItem();
                dgvBasItem.ClearSelection();
                tbxPincode.Text = tbx.Text;
                tbxPincode.SelectionStart = tbxPincode.Text.Length;
            }

        }
        private void dgvCliniCostdet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCliniCostdet.CurrentCell.OwningColumn.Name == "name")
            {
                TextBox tbx = e.Control as TextBox;
                tbx.TextChanged += new EventHandler(tbx_TextChanged);
            }
        }

        #region 焦点变化
        private void tbxClinicID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxHspcard.Focus();
            }
        }
        private void tbxPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegist.Focus();
            }
        }


        private void cmbDepart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //departChange();
                cmbDoctor.Focus();
                cmbDoctor.DroppedDown = true;
            }
        }

        private void cmbDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxAge.Focus();
            }
            
        }

        private void tbxAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSex.Focus();
                cmbSex.DroppedDown = true;
            }
        }

        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //   cmbPatientType.Focus();
            //    cmbPatientType.DroppedDown = true;
            //}
            if (e.KeyCode == Keys.Enter)
            {
                patientTypeChange();
                if (patienttypeKeyname == CostInsurtypeKeyname.SELFCOST.ToString())
                {
                    dgvCliniCostdet.Focus();
                    dgvCliniCostdet.CurrentCell = dgvCliniCostdet[0, 0];
                    dgvCliniCostdet.BeginEdit(true);
                }
                else
                {
                    btnReadInsurCard.Focus();
                }
            }
        }

        private void cmbPatientType_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    patientTypeChange();
            //    if (patienttypeKeyname == CostInsurtypeKeyname.SELFCOST.ToString())
            //    {
            //        dgvCliniCostdet.Focus();
            //        dgvCliniCostdet.CurrentCell = dgvCliniCostdet[0, 0];
            //        dgvCliniCostdet.BeginEdit(true);
            //    }
            //    else
            //    {
            //        btnReadInsurCard.Focus();
            //    }
            //}
        }
        #endregion



        private void btnReadInsurCard_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnReadInsurCardClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                dgvCliniCostdet.Rows[0].Cells["name"].Selected = true;
                dgvCliniCostdet.BeginEdit(true);
            }
        }

        private void cbxModifyDiscnt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxModifyDiscnt.Checked)
            {
                tbxDiscnt.ReadOnly = false;
            }
            else
            {
                tbxDiscnt.ReadOnly = true;
            }
        }

        private void addNewRow(int rowIndex)
        {
            try
            {

                String prc = dgvCliniCostdet.Rows[rowIndex].Cells["prc"].Value.ToString();//单价
                string numb = dgvCliniCostdet.Rows[rowIndex].Cells["num"].Value.ToString().Trim();//
                string discnt = dgvCliniCostdet.Rows[rowIndex].Cells["discnt"].Value.ToString().Trim();//折率
                double discount = double.Parse(discnt);
                double realfee = double.Parse(numb) * double.Parse(prc) * (double.Parse(discnt) / 100);

                realfee = Math.Round(realfee, 2);
                dgvCliniCostdet.Rows[rowIndex].Cells["realfee"].Value = realfee;//金额

                if (rowIndex == dgvCliniCostdet.Rows.Count - 1)
                {

                    //添加一行
                    dgvCliniCostdet.Rows.Add();
                    calculateAmount();//计算总费用//计算总费用

                    //把有项目的行的单元格不能编辑
                    for (int i = 0; i < dgvCliniCostdet.Rows.Count - 1; i++)
                    {
                        dgvCliniCostdet.Rows[i].Cells["name"].ReadOnly = true;
                        dgvCliniCostdet.Rows[i].Cells["itemtypename"].ReadOnly = true;
                        dgvCliniCostdet.Rows[i].Cells["exedpt"].ReadOnly = true;
                        dgvCliniCostdet.Rows[i].Cells["spec"].ReadOnly = true;
                        dgvCliniCostdet.Rows[i].Cells["unit"].ReadOnly = true;
                        dgvCliniCostdet.Rows[i].Cells["prc"].ReadOnly = true;
                        dgvCliniCostdet.Rows[i].Cells["discnt"].ReadOnly = true;
                        dgvCliniCostdet.Rows[i].Cells["realfee"].ReadOnly = true;
                    }
                    dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"];
                    dgvCliniCostdet.BeginEdit(true);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tbxHspcard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string hspCard = tbxHspcard.Text.Trim();
                if (hspCard.Length > 2)
                {
                    hspCard = hspCard.Replace(";", "");
                    hspCard = hspCard.Replace("?", "");
                    tbxHspcard.Text = hspCard;
                }
                if (hspCard.Trim().Equals(""))
                    return;
                string startDate = dtpStime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string endDate = dtpEtime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                loadRecipelTime();
                if (tbxHspcard.Text.Trim() != "")
                {
                    DataTable dt = bllClinicCharge.getRegisterInfo(startDate, endDate, tbxHspcard.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        lblRegistID.Text = dt.Rows[0]["id"].ToString();
                        register_id = dt.Rows[0]["id"].ToString();
                        tbxClinicID.Text = dt.Rows[0]["billcode"].ToString();
                        tbxSickName.Text = dt.Rows[0]["regname"].ToString();
                        cmbDepart.SelectedValue = dt.Rows[0]["depart_id"].ToString();
                        cmbDoctor.SelectedValue = dt.Rows[0]["doctor_id"].ToString();
                        tbxAge.Text = dt.Rows[0]["age"].ToString();
                        cmbSex.SelectedValue = dt.Rows[0]["sex"].ToString();
                        cmbPatientType.SelectedValue = dt.Rows[0]["bas_patienttype_id"].ToString();
                        this.member_id = dt.Rows[0]["member_id"].ToString();
                        patientTypeChange();
                    }
                    else
                    {
                        tbxSickName.Focus();
                    }
                }
            }
        }




        private void dgvCliniCostdet_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (cbxDrug.Checked)
            //{
            //    if (dgvCliniCostdet.Rows.Count > 5)
            //    {
            //        MessageBox.Show("一个处方最多添加5种药品！");
            //        dgvCliniCostdet.ReadOnly = true;
            //        return;
            //    }
            //}      
        }

        private void cmbPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbPayType.Text.Trim() == "现金")
            //{
            //    this.tbx_QT.ReadOnly = true;
            //    tbx_QT.Text = "0.00";
            //    this.tbxRcvFee.Text = this.tbxPayFee.Text;
            //}
            //else
            //{
            //    this.tbx_QT.ReadOnly = false;
            //    tbx_QT.Text = "0.00";
            //}
            //try
            //{
            //    double d_retfee = DataTool.stringToDouble(tbxInsurFee.Text.Trim()) + DataTool.stringToDouble(tbxAccountFee.Text.Trim()) + DataTool.stringToDouble(tbxRcvFee.Text) + DataTool.stringToDouble(tbx_QT.Text.Trim()) - DataTool.stringToDouble(this.tbxPayFee.Text);
            //    tbxRetFee.Text = DataTool.FormatData(d_retfee.ToString(), "2");
            //}
            //catch (SystemException)
            //{
            //    MessageBox.Show("实收金额输入有误，请重新输入！");
            //}

        }

        /// <summary>
        /// 获取检查发票信息
        /// </summary>
        /// <param name="clinicInvoices"></param>
        /// <returns></returns>
        private int getChkInvoices(ClinicAccount clinicAccount, List<ClinicInvoice> clinicInvoices)
        {
            string startDate = System.DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = System.DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";
            //DataTable dt_f =  bllRecipelCharge.getRecipelInfo(this.tbxSickName.Text.Trim(), startDate, endDate, this.tbxHspcard.Text.Trim(), cmbDepart.SelectedValue.ToString(), tbxClinicID.Text.Trim());
            string chkCostdet_ids = bllRecipelCharge.getCostdet(bllRecipelCharge.getChkCostIds(clinic_cost_ids));
            if (string.IsNullOrEmpty(chkCostdet_ids))
                return 0;
            DataTable dtExedep = bllRecipelCharge.getExedep(chkCostdet_ids);
            double fee = 0;
            string Clinic_cost_ids1 = "";
            string Clinic_costdet_ids1 = "";
            for (int i = 0; i < dtExedep.Rows.Count; i++)
            {
                string invoiceCostdetIds = bllRecipelCharge.getCostdetIds(chkCostdet_ids, dtExedep.Rows[i]["exedep_id"].ToString());
                string invoiceCostIds = "";
                DataTable dtChkCost = bllRecipelCharge.getCostInfo(chkCostdet_ids);
                for (int j = 0; j < dtChkCost.Rows.Count; j++)
                {
                    invoiceCostIds += dtChkCost.Rows[j]["id"].ToString() + ",";
                }
                if (string.IsNullOrEmpty(invoiceCostIds))
                {
                    continue;
                }
                invoiceCostIds = invoiceCostIds.Remove(invoiceCostIds.Length - 1);
                fee += Convert.ToDouble(dtExedep.Rows[i]["realfee"].ToString());
                Clinic_cost_ids1 += invoiceCostIds + ",";
                Clinic_costdet_ids1 += invoiceCostdetIds + ",";
            }
            ClinicInvoice clinicInvoice = new ClinicInvoice();
            clinicInvoice.Id = BillSysBase.nextId("clinic_invoice");
            clinicInvoice.Account_id = clinicAccount.Id;
            clinicInvoice.Regist_id = register_id;
            clinicInvoice.Sickname = tbxSickName.Text.Trim().ToString();
            clinicInvoice.Rcpdep_id = cmbDepart.SelectedValue.ToString();
            clinicInvoice.Rcpdoctor_id = cmbDoctor.SelectedValue.ToString();
            clinicInvoice.Exedep_id = clinicInvoice.Rcpdep_id;
            clinicInvoice.Fee = fee.ToString();
            clinicInvoice.Discnt = "1";
            clinicInvoice.Realfee = (double.Parse(clinicInvoice.Fee) * double.Parse(clinicInvoice.Discnt)).ToString();
            clinicInvoice.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();
            clinicInvoice.Bas_patienttype1_id = cmbPatientType.SelectedValue.ToString();
            clinicInvoice.Depart_id = ProgramGlobal.Depart_id;
            clinicInvoice.Chargedate = clinicAccount.Settledate;
            clinicInvoice.Chargeby = ProgramGlobal.User_id;//收费人
            clinicInvoice.Charged = CostCharged.CHAR.ToString();
            clinicInvoice.Clinic_cost_ids = Clinic_cost_ids1.Remove(Clinic_cost_ids1.Length - 1);
            clinicInvoice.Clinic_costdet_ids = Clinic_costdet_ids1.Remove(Clinic_costdet_ids1.Length - 1);
            clinicInvoice.Payfee = tbxPayFee.Text.Trim();
            clinicInvoice.Bas_paytype_id = this.cmbPayType.SelectedValue.ToString();
            clinicInvoice.Isregist = "0";
            clinicInvoices.Add(clinicInvoice);
            return dtExedep.Rows.Count;
        }

        /// <summary>
        /// 获取检查发票信息2
        /// </summary>
        /// <param name="clinicInvoices"></param>
        /// <returns></returns>
        private int getChkInvoices2(ClinicAccount clinicAccount, List<ClinicInvoice> clinicInvoices)
        {
            string chkCostdet_ids = bllRecipelCharge.getCostdet(bllRecipelCharge.getChkCostIds(clinic_cost_ids));
            if (string.IsNullOrEmpty(chkCostdet_ids))
                return 0;
            DataTable dtExedep = bllRecipelCharge.getExedep(chkCostdet_ids);
            for (int i = 0; i < dtExedep.Rows.Count; i++)
            {
                string invoiceCostdetIds = bllRecipelCharge.getCostdetIds(chkCostdet_ids, dtExedep.Rows[i]["exedep_id"].ToString());
                string invoiceCostIds = "";
                DataTable dtChkCost = bllRecipelCharge.getCostInfo(chkCostdet_ids);
                for (int j = 0; j < dtChkCost.Rows.Count; j++)
                {
                    invoiceCostIds += dtChkCost.Rows[j]["id"].ToString() + ",";
                }
                if (string.IsNullOrEmpty(invoiceCostIds))
                {
                    continue;
                }
                invoiceCostIds = invoiceCostIds.Remove(invoiceCostIds.Length - 1);
                ClinicInvoice clinicInvoice = new ClinicInvoice();
                clinicInvoice.Id = BillSysBase.nextId("clinic_invoice");
                clinicInvoice.Account_id = clinicAccount.Id;
                clinicInvoice.Regist_id = register_id;
                clinicInvoice.Sickname = tbxSickName.Text.Trim().ToString();
                clinicInvoice.Rcpdep_id = dtChkCost.Rows[0]["depart_id"].ToString();
                clinicInvoice.Rcpdoctor_id = dtChkCost.Rows[0]["doctor_id"].ToString();
                clinicInvoice.Exedep_id = dtChkCost.Rows[0]["depart_id"].ToString();
                clinicInvoice.Fee = dtExedep.Rows[i]["realfee"].ToString();
                clinicInvoice.Discnt = "1";
                clinicInvoice.Realfee = (double.Parse(clinicInvoice.Fee) * double.Parse(clinicInvoice.Discnt)).ToString();
                clinicInvoice.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();
                clinicInvoice.Bas_patienttype1_id = cmbPatientType.SelectedValue.ToString();
                clinicInvoice.Depart_id = ProgramGlobal.Depart_id;
                clinicInvoice.Chargedate = clinicAccount.Settledate;
                clinicInvoice.Chargeby = ProgramGlobal.User_id;//收费人
                clinicInvoice.Charged = CostCharged.CHAR.ToString();
                clinicInvoice.Clinic_cost_ids = invoiceCostIds;
                clinicInvoice.Clinic_costdet_ids = invoiceCostdetIds;
                clinicInvoice.Payfee = tbxPayFee.Text.Trim();
                clinicInvoice.Bas_paytype_id = this.cmbPayType.SelectedValue.ToString();

                clinicInvoice.Isregist = "0";

                clinicInvoices.Add(clinicInvoice);
            }
            return dtExedep.Rows.Count;
        }


        /// <summary>
        /// 处方发票
        /// </summary>
        /// <param name="clinicInvoices"></param>
        /// <returns></returns>
        private int getRcpInvoices(ClinicAccount clinicAccount, List<ClinicInvoice> clinicInvoices)
        {
            string rcpCostIds = bllRecipelCharge.getRcpCostIds(clinic_cost_ids);
            DataTable dtRcpCost = bllRecipelCharge.getRcpClinicCosts(rcpCostIds);
            for (int i = 0; i < dtRcpCost.Rows.Count; i++)
            {
                string costId = dtRcpCost.Rows[0]["id"].ToString();
                string realfee = "";
                ClinicInvoice clinicInvoice = new ClinicInvoice();
                clinicInvoice.Id = BillSysBase.nextId("clinic_invoice");
                clinicInvoice.Account_id = clinicAccount.Id;
                clinicInvoice.Clinic_cost_ids = costId;
                clinicInvoice.Clinic_costdet_ids = bllRecipelCharge.getCostdetId_RealFee(costId, ref realfee);
                clinicInvoice.Regist_id = this.register_id;
                clinicInvoice.Sickname = tbxSickName.Text.Trim().ToString();
                clinicInvoice.Rcpdep_id = dtRcpCost.Rows[0]["depart_id"].ToString();
                clinicInvoice.Rcpdoctor_id = dtRcpCost.Rows[0]["doctor_id"].ToString();
                clinicInvoice.Exedep_id = dtRcpCost.Rows[0]["depart_id"].ToString();
                clinicInvoice.Fee = realfee;
                clinicInvoice.Discnt = "1";
                clinicInvoice.Realfee = realfee;
                clinicInvoice.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();
                clinicInvoice.Bas_patienttype1_id = cmbPatientType.SelectedValue.ToString();
                clinicInvoice.Depart_id = ProgramGlobal.Depart_id;
                clinicInvoice.Chargedate = clinicAccount.Settledate;
                clinicInvoice.Chargeby = ProgramGlobal.User_id;//收费人
                clinicInvoice.Charged = CostCharged.CHAR.ToString();
                clinicInvoice.Clinic_tab_id = ""; //日结单号
                clinicInvoice.Isregist = "0";
                clinicInvoices.Add(clinicInvoice);
            }
            return dtRcpCost.Rows.Count;
        }
        /// <summary>
        /// 生成发票数据
        /// </summary>
        /// <param name="clinicInvoice"></param>
        /// <returns></returns>
        private bool doClinicInvoice(List<ClinicInvoice> clinicInvoices, ref string invoices_sql)
        {

            double double_zhzf = DataTool.stringToDouble(tbxAccountFee.Text);
            string err_messgae = "";
            for (int i = 0; i < clinicInvoices.Count; i++)
            {
                ClinicInvoice clinicInvoice = clinicInvoices[i];
                List<ClinicInvoiceDet> clinicInvoiceDetList = new List<ClinicInvoiceDet>();
                //医保
                if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.HDSYB.ToString().ToUpper().Trim()))
                {
                    MZSyb mzsyb = new MZSyb();
                    double[] yb = new double[4];//ger tong fenzhongxin
                    //if (!mzsyb.ybjs(mzybdk, cmbDoctor.Text.Trim(), cmbDepart.Text.Trim(), clinicInvoice, yb))
                    //{
                    //    return false;
                    //}
                    ClinicInvoiceDet clinicInvoiceDet = new ClinicInvoiceDet();
                    clinicInvoiceDet.Clinic_invoice_id = clinicInvoice.Id;
                    clinicInvoiceDet.Payfee = yb[2].ToString();
                    clinicInvoiceDet.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());//统筹支付
                    clinicInvoiceDet.Bas_paysumby_id = "301";
                    clinicInvoiceDet.Cheque = "";
                    clinicInvoiceDetList.Add(clinicInvoiceDet);
                    ClinicInvoiceDet clinicInvoiceDet1 = new ClinicInvoiceDet();
                    clinicInvoiceDet1.Clinic_invoice_id = clinicInvoice.Id;
                    clinicInvoiceDet1.Payfee = yb[0].ToString();
                    clinicInvoiceDet1.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.SELFFEE.ToString());//账户支付
                    clinicInvoiceDet1.Bas_paysumby_id = "301";
                    clinicInvoiceDet1.Cheque = "";
                    clinicInvoiceDetList.Add(clinicInvoiceDet1);
                    ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();//非医保支付
                    clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
                    clinicInvoiceDet2.Payfee = yb[3].ToString();
                    clinicInvoiceDet2.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                    clinicInvoiceDet2.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
                    clinicInvoiceDet2.Cheque = "";
                    clinicInvoiceDetList.Add(clinicInvoiceDet2);

                    clinicInvoice.Insurefee = yb[2].ToString().Trim();
                    clinicInvoice.Insuraccountfee = yb[3].ToString().Trim();
                    clinicInvoice.Insurotherfee = "0.00";
                    clinicInvoice.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                    clinicInvoice.Payfee = yb[3].ToString().Trim();
                    clinicInvoice.Invoice_sql = bllRecipelCharge.doClinicInvoice(clinicInvoice, clinicInvoiceDetList);//收费发票
                    this.tbxAccountAmt.Text = yb[1].ToString().Trim();//yb[1]账户余额
                    this.tbxAccountFee.Text = yb[0].ToString().Trim();//yb[0] 账户支付
                    this.tbxInsurFee.Text = yb[2].ToString().Trim();//yb[2]医保报销
                    this.tbxRcvFee.Text = yb[3].ToString().Trim();//yb[3]现金支付
                    this.tbxRetFee.Text = "0.00";
                    invoices_sql += clinicInvoice.Invoice_sql;
                }
                //else if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.HDSCH.ToString().ToUpper().Trim()))
                //{
                //    double[] yb = new double[4];
                //    MZCH mzsyb = new MZCH();
                //    if (!mzsyb.ybjs(mzybdk, cmbDoctor.Text.Trim(), cmbDepart.Text.Trim(), clinicInvoice, yb))
                //    {
                //        return false;
                //    }
                //    ClinicInvoiceDet clinicInvoiceDet = new ClinicInvoiceDet();
                //    clinicInvoiceDet.Clinic_invoice_id = clinicInvoice.Id;
                //    clinicInvoiceDet.Payfee = yb[2].ToString();
                //    clinicInvoiceDet.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());//统筹支付
                //    clinicInvoiceDet.Bas_paysumby_id = "301";
                //    clinicInvoiceDet.Cheque = "";
                //    clinicInvoiceDetList.Add(clinicInvoiceDet);
                //    ClinicInvoiceDet clinicInvoiceDet1 = new ClinicInvoiceDet();
                //    clinicInvoiceDet1.Clinic_invoice_id = clinicInvoice.Id;
                //    clinicInvoiceDet1.Payfee = yb[0].ToString();
                //    clinicInvoiceDet1.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.SELFFEE.ToString());//账户支付
                //    clinicInvoiceDet1.Bas_paysumby_id = "301";
                //    clinicInvoiceDet1.Cheque = "";
                //    clinicInvoiceDetList.Add(clinicInvoiceDet1);
                //    ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();//非医保支付
                //    clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
                //    clinicInvoiceDet2.Payfee = yb[3].ToString();
                //    clinicInvoiceDet2.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                //    clinicInvoiceDet2.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
                //    clinicInvoiceDet2.Cheque = "";
                //    clinicInvoiceDetList.Add(clinicInvoiceDet2);

                //    clinicInvoice.Insurefee = yb[2].ToString().Trim();
                //    clinicInvoice.Insuraccountfee = yb[0].ToString().Trim();
                //    clinicInvoice.Insurotherfee = "0.00";
                //    clinicInvoice.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                //    clinicInvoice.Payfee = yb[3].ToString().Trim();
                //    clinicInvoice.Invoice_sql = bllRecipelCharge.doClinicInvoice(clinicInvoice, clinicInvoiceDetList);//收费发票
                //    this.tbxAccountAmt.Text = yb[1].ToString().Trim();//yb[1]账户余额
                //    this.tbxAccountFee.Text = yb[0].ToString().Trim();//yb[0] 账户支付
                //    this.tbxInsurFee.Text = yb[2].ToString().Trim();//yb[2]医保报销
                //    this.tbxRcvFee.Text = yb[3].ToString().Trim();//yb[3]现金支付
                //    invoices_sql += clinicInvoice.Invoice_sql;
                //}
                if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.SJZSYB.ToString().ToUpper().Trim()))
                {
                    MZSyb mzsyb = new MZSyb();




                    string info = "";
                    double[] yb = new double[4];//ger tong fenzhongxin
                    if (!mzsyb.ybjs(SJZ_DK, register_id, cmbDoctor.Text.Trim(), cmbDepart.Text.Trim(), "", clinicInvoice, yb))
                    {
                        return false;
                    }
                    ClinicInvoiceDet clinicInvoiceDet = new ClinicInvoiceDet();
                    clinicInvoiceDet.Clinic_invoice_id = clinicInvoice.Id;
                    clinicInvoiceDet.Payfee = yb[2].ToString();
                    clinicInvoiceDet.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());//统筹支付
                    clinicInvoiceDet.Bas_paysumby_id = "301";
                    clinicInvoiceDet.Cheque = "";
                    clinicInvoiceDetList.Add(clinicInvoiceDet);
                    ClinicInvoiceDet clinicInvoiceDet1 = new ClinicInvoiceDet();
                    clinicInvoiceDet1.Clinic_invoice_id = clinicInvoice.Id;
                    clinicInvoiceDet1.Payfee = yb[0].ToString();
                    clinicInvoiceDet1.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.SELFFEE.ToString());//账户支付
                    clinicInvoiceDet1.Bas_paysumby_id = "301";
                    clinicInvoiceDet1.Cheque = "";
                    clinicInvoiceDetList.Add(clinicInvoiceDet1);
                    ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();//非医保支付
                    clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
                    clinicInvoiceDet2.Payfee = yb[3].ToString();
                    clinicInvoiceDet2.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                    clinicInvoiceDet2.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
                    clinicInvoiceDet2.Cheque = "";
                    clinicInvoiceDetList.Add(clinicInvoiceDet2);

                    clinicInvoice.Insurefee = yb[2].ToString().Trim();
                    clinicInvoice.Insuraccountfee = yb[3].ToString().Trim();
                    clinicInvoice.Insurotherfee = "0.00";
                    clinicInvoice.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                    clinicInvoice.Payfee = yb[3].ToString().Trim();
                    clinicInvoice.Invoice_sql = bllRecipelCharge.doClinicInvoice(clinicInvoice, clinicInvoiceDetList);//收费发票
                    this.tbxAccountAmt.Text = yb[1].ToString().Trim();//yb[1]账户余额
                    this.tbxAccountFee.Text = yb[0].ToString().Trim();//yb[0] 账户支付
                    this.tbxInsurFee.Text = yb[2].ToString().Trim();//yb[2]医保报销
                    this.tbxRcvFee.Text = yb[3].ToString().Trim();//yb[3]现金支付
                    this.tbxRetFee.Text = "0.00";

                }
                else if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.SELFCOST.ToString().ToUpper().Trim())
                {
                    //ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();
                    //clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
                    //clinicInvoiceDet2.Payfee = tbxRcvFee.Text.Trim();
                    //DataTable dtpt = bllClinicReg.payPaytypexj();
                    //clinicInvoiceDet2.Bas_paytype_id = dtpt.Rows[0]["id"].ToString();
                    //clinicInvoiceDet2.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
                    //clinicInvoiceDet2.Cheque = "";
                    //clinicInvoiceDetList.Add(clinicInvoiceDet2);

                    ClinicInvoiceDet clinicInvoiceDet3 = new ClinicInvoiceDet();//其他
                    clinicInvoiceDet3.Clinic_invoice_id = clinicInvoice.Id;
                    clinicInvoiceDet3.Payfee = clinicInvoice.Realfee;
                    clinicInvoiceDet3.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                    clinicInvoiceDet3.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
                    clinicInvoiceDet3.Cheque = "";
                    clinicInvoiceDetList.Add(clinicInvoiceDet3);

                    clinicInvoice.Bas_patienttype1_id = clinicInvoice.Bas_patienttype_id;
                    clinicInvoice.Insurefee = "0.00";
                    clinicInvoice.Insurotherfee = "0.00";
                    clinicInvoice.Insuraccountfee = "0.00";
                    clinicInvoice.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                    clinicInvoice.Payfee = clinicInvoice.Realfee;
                    invoices_sql += bllRecipelCharge.doClinicInvoice(clinicInvoice, clinicInvoiceDetList);//收费发票
                }
            }
            return true;
        }

        private void tbxPayFee_Click(object sender, EventArgs e)
        {
            Bjq.bjqts(tbxPayFee.Text + "J");
        }

        private void btnReadInsurCard_Click(object sender, EventArgs e)
        {
            // btnReadInsurCardClick();
        }

        private void dgvCliniCostdet_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            departChange();
        }

        private void cbx_yibao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_yibao.Checked == true)
            {
                cbx_cx.Checked = false;
                IniUtils.IniWriteValue(IniUtils.syspath, "MZPZ", "MZYB", "1");

            }
            else
            {
                IniUtils.IniWriteValue(IniUtils.syspath, "MZPZ", "MZYB", "0");
                IniUtils.IniWriteValue(IniUtils.syspath, "MZPZ", "MZCH", "0");
            }
            mzpz();//门诊医保城乡其他配置
        }
        //门诊医保城乡其他配置
        private void mzpz()
        {
            if (IniUtils.IniReadValue(IniUtils.syspath, "MZPZ", "MZYB") == "1")//门诊医保
            {
                cbx_yibao.Checked = true;
                this.cmbPatientType.SelectedValue = "40";
            }
            else if (IniUtils.IniReadValue(IniUtils.syspath, "MZPZ", "MZCH") == "1")//门诊城乡
            {
                cbx_cx.Checked = true;
                this.cmbPatientType.SelectedValue = "41";
            }
            else                                           //其他
            {
                this.cmbPatientType.SelectedValue = "1";
                cbx_yibao.Checked = false;
                cbx_cx.Checked = false;
            }
        }

        private void cbx_cx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_cx.Checked == true)
            {
                cbx_yibao.Checked = false;
                IniUtils.IniWriteValue(IniUtils.syspath, "MZPZ", "MZCH", "1");

            }
            else
            {
                IniUtils.IniWriteValue(IniUtils.syspath, "MZPZ", "MZYB", "0");
                IniUtils.IniWriteValue(IniUtils.syspath, "MZPZ", "MZCH", "0");
            }
            mzpz();//门诊医保城乡其他配置
        }

        private void cmbPatientType_SelectedValueChanged(object sender, EventArgs e)
        {
            patientTypeChange();
        }


        private void addjcxm(DataTable dt)
        {
            dgvCliniCostdet.Rows.Add();
            if (dgvCliniCostdet.Rows.Count > 0)   // pincode  itemtypename   exedpt   spec   num   unit   prc   discnt   realfee   delete
            {
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"].Value = dt.Rows[0]["itemname"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemtypename"].Value = dt.Rows[0]["itemtypename"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["exedpt"].Value = dt.Rows[0]["dptname"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["spec"].Value = dt.Rows[0]["spec"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["unit"].Value = dt.Rows[0]["unit"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["prc"].Value = dt.Rows[0]["prc"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["num"].Value = "1";
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["discnt"].Value = "100";
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["realfee"].Value = 1 * double.Parse(dt.Rows[0]["prc"].ToString().Trim()) * (double.Parse("100") / 100);
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["delete"].Value = "删除";
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["qty"].Value = double.Parse(dt.Rows[0]["prc"].ToString().Trim()) - double.Parse(dt.Rows[0]["useqty"].ToString().Trim());//隐藏列  库存
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemfrom"].Value = dt.Rows[0]["itemfrom"].ToString().Trim();//隐藏列  类别
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemid"].Value = dt.Rows[0]["id"].ToString().Trim();//隐藏列 item_id
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["packsole"].Value = dt.Rows[0]["packsole"].ToString().Trim();//隐藏列  
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["drug_packsole_id"].Value = dt.Rows[0]["drug_packsole_id"].ToString().Trim();//隐藏列 drug_packsole_id
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["exedptid"].Value = dt.Rows[0]["exedep_id"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["chk_sampletype_id"].Value = dt.Rows[0]["chk_sampletype_id"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["chk_type_id"].Value = dt.Rows[0]["chk_type_id"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["chk_opkind_id"].Value = dt.Rows[0]["chk_opkind_id"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemtype_id"].Value = dt.Rows[0]["itemtype_id"].ToString().Trim();
                dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemtype1_id"].Value = dt.Rows[0]["itemtype1_id"].ToString().Trim();
            }
            panelBasItem.Visible = false;
            dgvCliniCostdet.Focus();
            if (dgvCliniCostdet.Rows.Count > 0)
            {
                if (this.dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["itemfrom"].Value.ToString().Equals("CHECK"))
                {

                }
                dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["num"];
                dgvCliniCostdet.BeginEdit(false);
            }
            dgvCliniCostdet.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));

        }
        //判断有没有患者
        private bool yz()
        {
            if (string.IsNullOrEmpty(tbxSickName.Text.Trim()))
            {
                MessageBox.Show("请选择患者");
                return false;
            }
            if (cmbDepart.SelectedValue == null || cmbDepart.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("请选择科室！");
                return false;
            }
            if (cmbDoctor.SelectedValue == null || cmbDoctor.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("请选择医生！");
                return false;
            }
            return true;
        }


        private void tv_jc_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Checked == true)
            {

                Color ss = e.Node.ForeColor;
                e.Node.ForeColor = Color.Red;
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = true;
                    e.Node.Nodes[i].ForeColor = Color.Red;
                    for (int y = 0; y < e.Node.Nodes[i].Nodes.Count; y++)
                    {
                        e.Node.Nodes[i].Nodes[y].Checked = true;
                        e.Node.Nodes[i].Nodes[y].ForeColor = Color.Red;
                    }
                }

            }
            else
            {
                Color ss = e.Node.ForeColor;
                e.Node.ForeColor = Color.FromArgb(0, 0, 0);
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = false;
                    e.Node.Nodes[i].ForeColor = Color.FromArgb(0, 0, 0);
                    for (int y = 0; y < e.Node.Nodes[i].Nodes.Count; y++)
                    {
                        e.Node.Nodes[i].Nodes[y].Checked = false;
                        e.Node.Nodes[i].Nodes[y].ForeColor = Color.FromArgb(0, 0, 0);
                    }
                }

                if (e.Node.Parent != null)
                {
                    e.Node.Parent.Checked = false;
                }
            }
        }



        private void tbxRcvFee_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string rcvfee = "";
                if (string.IsNullOrEmpty(tbxRcvFee.Text) || string.IsNullOrWhiteSpace(tbxRcvFee.Text))
                {
                    rcvfee = "0";
                }
                else
                    rcvfee = tbxRcvFee.Text;
                //if (DataTool.stringToDouble(rcvfee) < DataTool.stringToDouble(tbxPayFee.Text.Trim()))
                //{
                //    double d_retfee2 = DataTool.stringToDouble(tbxInsurFee.Text.Trim()) + DataTool.stringToDouble(tbxAccountFee.Text.Trim()) + DataTool.stringToDouble(rcvfee) - DataTool.stringToDouble(this.tbxPayFee.Text);
                //    this.tbx_QT.Text = DataTool.FormatData(d_retfee2.ToString().Replace("-", ""), "2");
                //}
                //if (cmbPayType.Text.Trim() == "现金")
                //{
                this.tbx_QT.ReadOnly = true;
                tbx_QT.Text = "0.00";
                //this.tbxRcvFee.Text = this.tbxPayFee.Text;
                //}
                double d_retfee = DataTool.stringToDouble(tbxInsurFee.Text.Trim()) + DataTool.stringToDouble(tbxAccountFee.Text.Trim()) + DataTool.stringToDouble(rcvfee) + DataTool.stringToDouble(tbx_QT.Text.Trim()) - DataTool.stringToDouble(this.tbxPayFee.Text);
                tbxRetFee.Text = DataTool.FormatData(d_retfee.ToString(), "2");
            }
            catch (SystemException)
            {
                MessageBox.Show("实收金额输入有误，请重新输入！");
            }
        }

        private void tbx_QT_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string rcvfee = "";
                if (string.IsNullOrEmpty(tbx_QT.Text) || string.IsNullOrWhiteSpace(tbx_QT.Text))
                {
                    rcvfee = "0";
                }
                else
                    rcvfee = tbx_QT.Text;
                //if (DataTool.stringToDouble(rcvfee) < DataTool.stringToDouble(tbxPayFee.Text.Trim()))
                //{
                //    double d_retfee2 = DataTool.stringToDouble(tbxInsurFee.Text.Trim()) + DataTool.stringToDouble(tbxAccountFee.Text.Trim()) + DataTool.stringToDouble(rcvfee) - DataTool.stringToDouble(this.tbxPayFee.Text);
                //    this.tbx_QT.Text = DataTool.FormatData(d_retfee2.ToString(), "2");
                //}
                double d_retfee = DataTool.stringToDouble(tbxInsurFee.Text.Trim()) + DataTool.stringToDouble(tbxAccountFee.Text.Trim()) + DataTool.stringToDouble(rcvfee) + DataTool.stringToDouble(tbxRcvFee.Text.Trim()) - DataTool.stringToDouble(this.tbxPayFee.Text);
                tbxRetFee.Text = DataTool.FormatData(d_retfee.ToString(), "2");
            }
            catch (SystemException)
            {
                MessageBox.Show("实收金额输入有误，请重新输入！");
            }
        }

        private void tbxRcvFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                js();
            }
        }

        private void tbx_QT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                js();
            }
        }

        private void cbx_jcks_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void tbx_jcjm_KeyDown(object sender, KeyEventArgs e)
        {

        }


        /// <summary>
        /// 判断门诊收费按钮是否是结算状态
        /// </summary>
        public bool checkMzsfButtonStatus()
        {
            if (btnCostCharged.Text.Trim().Equals("结算"))
            {
                //if (!cmbPatientType.SelectedValue.ToString().Equals("136"))//168省医保 173异地
                //{
                //    MessageBox.Show("请点击结算按钮，完成当前患者收费再操作其他患者！");
                //    return false;
                //}

                btnCostCharged.Text = "收费";
                //this.cbx_jsfs.Enabled = true;
            }
            return true;
        }
        private void cbx_jcks_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cbx_jcks.SelectedValue == null || cbx_jcks.SelectedValue.ToString() == "-1")
            {
                this.tv_jc.Visible = false;
                return;
            }

            if (!checkMzsfButtonStatus())
            {
                cbx_jcks.SelectedValue = "-1";
                return;
            }

            this.tbx_jcjm.Enabled = true;//简码能编辑
            string jcksiid = this.cbx_jcks.SelectedValue.ToString().Trim();

            //string sql = "select id,name from chk_bodypart  where chk_bodyparttype_id in (select id from chk_bodyparttype where chk_opkind_id =" + jcksiid + ") order by ordersn";
            //this.cbx_jcbw.DisplayMember = "name";
            //this.cbx_jcbw.ValueMember = "id";
            //this.cbx_jcbw.DataSource = BllMain.Db.Select(sql).Tables[0];
            addtv_jc();
            this.tv_jc.Focus();
        }

        private void cbx_jcbw_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbx_jcks.SelectedValue == null || cbx_jcks.SelectedValue.ToString() == "-1")
            {
                this.tv_jc.Visible = false;
                return;
            }
            addtv_jc();
        }

        private void tbx_jcjm_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (tv_jc.Visible == true)
                //{
                //    tv_jc.Focus();
                //}
                //else
                //{
                if (string.IsNullOrEmpty(tbx_jcjm.Text.Trim()))
                {
                    dgvCliniCostdet.Focus();
                    dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"];
                    dgvCliniCostdet.BeginEdit(false);
                }
                else if (!string.IsNullOrEmpty(tbx_jcjm.Text.Trim()))
                {
                    addtv_jc();

                }
            }
        }
        private void addtv_jc()
        {
            //this.tv_jc.Nodes.Clear();
            //DataTable dt_jc = blljc.getjc(this.cbx_jcks.SelectedValue.ToString().Trim(), this.cbx_jcbw.Text.ToString().Trim(), this.tbx_jcjm.Text.Trim());
            //for (int i = 0; i < dt_jc.Rows.Count; i++)
            //{
            //    this.tv_jc.Nodes.Add(dt_jc.Rows[i]["id"].ToString(), dt_jc.Rows[i]["name"].ToString() + "      部位：" + dt_jc.Rows[i]["name1"].ToString() + "       &价格：  " + dt_jc.Rows[i]["prc"].ToString());
            //}
            ////异步加载子项目
            //MethodInvoker mi = new MethodInvoker(addtv_jcnodes);
            //this.BeginInvoke(mi);


            //if (this.tv_jc.Nodes.Count > 0)
            //{
            //    this.tv_jc.Visible = true;
            //    //SetParent(((TreeView)tv_jc).Handle, GetForegroundWindow());//显示在最前边
            //    //this.tv_jc.Focus();
            //}
            //else
            //{
            //    this.tv_jc.Visible = false;
            //}

            this.tv_jc.Nodes.Clear();

            string wc = "";
            if (cbx_jcks.SelectedValue != null && cbx_jcks.SelectedValue.ToString() != "-1")
            {
                string jcksiid = this.cbx_jcks.SelectedValue.ToString().Trim();
                wc += " and chk_opkind_id = " + jcksiid;
            }
            if (cbx_jcbw.SelectedValue != null && cbx_jcbw.SelectedValue.ToString() != "-1")
            {
                string jcbw = this.cbx_jcbw.SelectedValue.ToString().Trim();
                wc += " and jcxm.id in (select chk_diagnset_id from chk_diagnbodypart where chk_bodypart_id =  " + DataTool.addFieldBraces(jcbw) + ")";
            }
            if (!string.IsNullOrEmpty(this.tbx_jcjm.Text.Trim()))
            {
                wc += " and pincode like '%" + this.tbx_jcjm.Text.Trim().ToLower() + "%' ";//and parentiid in (select iid from mtjcxm where  parentiid = 0) and parentiid != 0 ";
            }
            string sql = "select id,concat((select name from chk_diagnset where id = jcxm.id),'||','(','||',prc,'||',')','(简码','||',pincode,')') as name from chk_diagnset as jcxm where  isstop = 'N'" + wc + " order by id  ";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.tv_jc.Nodes.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["name"].ToString());
            }
            //异步加载子项目
            MethodInvoker mi = new MethodInvoker(addtv_jcnodes);
            this.BeginInvoke(mi);


            if (this.tv_jc.Nodes.Count > 0)
            {

                this.tv_jc.Visible = true;
                //SetParent(((TreeView)tv_jc).Handle, GetForegroundWindow());//显示在最前边
                //this.tv_jc.Focus();
            }
            else
            {
                this.tv_jc.Visible = false;
            }

        }
        //加载检查子项目
        private void addtv_jcnodes()
        {
            for (int x = 0; x < tv_jc.Nodes.Count; x++)
            {
                string st = tv_jc.Nodes[x].Text.ToString().Trim();
                string[] sArray = st.Split('&');
                DataTable dtjc = blljc.getmtjcxm(tv_jc.Nodes[x].Name.ToString().Trim());
                DataTable dt_jczx = blljc.getjczx(Convert.ToInt32(dtjc.Rows[0]["id"].ToString().Trim()));
                for (int y = 0; y < dt_jczx.Rows.Count; y++)
                {
                    tv_jc.Nodes[x].Nodes.Add(dt_jczx.Rows[y]["id"].ToString(), dt_jczx.Rows[y]["name"].ToString() + "       &价格：  " + dt_jczx.Rows[y]["prc"].ToString());
                }
            }

        }

        private void tv_jc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (!yz())//判断当前患者
                //{
                //    tv_jc.Visible = false;
                //    tv_jc.Nodes.Clear();
                //    this.cbx_jcks.SelectedValue = "-1";
                //    this.cbx_jcbw.SelectedValue = "-1";
                //    return;
                //}

                selectjc();//添加选择的检查

                this.tbx_jcjm.Text = "";
                this.tbx_jcjm.Focus();

            }
        }
        //添加检查费
        private void selectjc()
        {
            //int mtjciid_1 = 0;
            if (dgvCliniCostdet.Rows.Count != 0)
            {
                if (dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["prc"].Value == null)//&& dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["zhje"].Value == null)
                {
                    dgvCliniCostdet.Rows.Remove(dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1]);//先删除空的行
                }
            }
            if (tv_jc.Visible == true && tv_jc.Nodes.Count > 0)
            {
                for (int i = 0; i < tv_jc.Nodes.Count; i++)
                {
                    if (tv_jc.Nodes[i].Nodes.Count != 0)
                    {
                        if (tv_jc.Nodes[i].Checked == true)
                        {
                            string st = tv_jc.Nodes[i].Text.ToString().Trim();
                            string[] sArray = st.Split('&');
                            DataTable dtjc = blljc.getmtjcxm(tv_jc.Nodes[i].Name);
                            addjcxm(dtjc);
                        }
                        //for (int x = 0; x < tv_jc.Nodes[i].Nodes.Count; x++)
                        //{
                        //    if (tv_jc.Nodes[i].Nodes[x].Checked == true)
                        //    {
                        //        string st = tv_jc.Nodes[i].Text.ToString().Trim();
                        //        string[] sArray = st.Split('&');
                        //        DataTable dtjc = blljc.getmtjcxm(sArray[0].ToString().Trim());
                        //        addjcxm(dtjc);
                        //    }
                        //}   
                    }
                }
            }
            tv_jc.Visible = false;
            tv_jc.Nodes.Clear();
            dgvCliniCostdet.Rows.Add();
            calculateAmount();
        }
        private void tv_jc_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Checked == true)
            {
                Color ss = e.Node.ForeColor;
                e.Node.ForeColor = Color.Red;
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = true;
                    e.Node.Nodes[i].ForeColor = Color.Red;
                    for (int y = 0; y < e.Node.Nodes[i].Nodes.Count; y++)
                    {
                        e.Node.Nodes[i].Nodes[y].Checked = true;
                        e.Node.Nodes[i].Nodes[y].ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                Color ss = e.Node.ForeColor;
                e.Node.ForeColor = Color.FromArgb(0, 0, 0);
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = false;
                    e.Node.Nodes[i].ForeColor = Color.FromArgb(0, 0, 0);
                    for (int y = 0; y < e.Node.Nodes[i].Nodes.Count; y++)
                    {
                        e.Node.Nodes[i].Nodes[y].Checked = false;
                        e.Node.Nodes[i].Nodes[y].ForeColor = Color.FromArgb(0, 0, 0);
                    }
                }
            }
        }

        private void but_addjc_Click(object sender, EventArgs e)
        {
            this.panelBasItem.Visible = false;
            selectjc();//添加选择的检查

            dgvCliniCostdet.Focus();
            dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"];
            dgvCliniCostdet.BeginEdit(false);

            this.cbx_jcks.SelectedValue = "-1";
            this.cbx_jcbw.SelectedValue = "-1";
        }

        private void cbxCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCheck.Checked)
            {
                cbxCost.Checked = false;
                cbxDrug.Checked = false;
                //dgvCliniCostdet.Rows.Clear();
                //initDgvList();
                dgvCliniCostdet.ReadOnly = false;
                //tbxAmount.Text = "0";
                //tbxRcvFee.Text = "0";
                //cbxDrug.Enabled = false;
                //cbxCost.Enabled = false;
                cbxDrug.Enabled = true;
                cbxCheck.Enabled = false;
                cbxCost.Enabled = true;
                cbx_jcks.Enabled = true;//就诊科室
                cbx_jcbw.Enabled = true;
                tbx_jcjm.Enabled = true;
                but_addjc.Enabled = true;
                try
                {
                    dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"];
                    dgvCliniCostdet.BeginEdit(true);
                }
                catch
                { }
            }
        }

        private void cbxCost_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCost.Checked)
            {
                cbxCheck.Checked = false;
                cbxDrug.Checked = false;
                //dgvCliniCostdet.Rows.Clear();
                //initDgvList();
                dgvCliniCostdet.ReadOnly = false;
                //tbxAmount.Text = "0";
                //tbxRcvFee.Text = "0";
                //cbxCheck.Enabled = false;
                //cbxDrug.Enabled = false;
                cbxDrug.Enabled = true;
                cbxCheck.Enabled = true;
                cbxCost.Enabled = false;
                cbx_jcks.Enabled = false;//就诊科室
                cbx_jcbw.Enabled = false;
                tbx_jcjm.Enabled = false;
                but_addjc.Enabled = false;
                try
                {
                    dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"];
                    dgvCliniCostdet.BeginEdit(true);
                }
                catch
                { }
            }
        }

        private void cbxDrug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDrug.Checked)
            {
                cbxCheck.Checked = false;
                cbxCost.Checked = false;
                dgvCliniCostdet.Columns["discnt"].ReadOnly = true;
                //dgvCliniCostdet.Rows.Clear();
                //initDgvList();
                dgvCliniCostdet.ReadOnly = false;
                //tbxAmount.Text = "0";
                //tbxRcvFee.Text = "0";
                //cbxCheck.Enabled = false;
                //cbxCost.Enabled = false;
                cbxDrug.Enabled = false;
                cbxCheck.Enabled = true;
                cbxCost.Enabled = true;
                cbx_jcks.Enabled = false;//就诊科室
                cbx_jcbw.Enabled = false;
                tbx_jcjm.Enabled = false;
                but_addjc.Enabled = false;
                try
                {
                    dgvCliniCostdet.CurrentCell = dgvCliniCostdet.Rows[dgvCliniCostdet.Rows.Count - 1].Cells["name"];
                    dgvCliniCostdet.BeginEdit(true);
                }
                catch
                { }
            }
            else
            {
                //cbxCheck.Enabled = true;
                //cbxCost.Enabled = true;
                dgvCliniCostdet.Columns["discnt"].ReadOnly = false;
            }
        }

        private void dgvBasItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbDoctor_TextChanged(object sender, EventArgs e)
        {
            string doctor_name = cmbDoctor.Text;
            if (String.IsNullOrEmpty(doctor_name) || doctor_name.Equals("--请选择--"))
            {
                dataGridView1.Visible = false;
                return;
            }
            DataTable dtd = bllRecipelCharge.getDoctor_View(doctor_name);
            //if (dtd.Rows.Count <= 0)
            //    return;
            dataGridView1.Visible = true;
            dataGridView1.DataSource = dtd;
            dataGridView1.Columns["doc_id"].Visible = false;
            dataGridView1.Columns["doc_name"].HeaderText = "医生";
            dataGridView1.Columns["doc_name"].Width = 120;
            dataGridView1.Columns["doc_name"].DisplayIndex = 0;
            dataGridView1.Columns["dep_id"].Visible = false;
            dataGridView1.Columns["dep_name"].HeaderText = "科室";
            dataGridView1.Columns["dep_name"].Width = 80;
            dataGridView1.Columns["doc_name"].DisplayIndex = 1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count > 1 )
            {
                cmbDepart.SelectedValue = dataGridView1.CurrentRow.Cells["dep_id"].Value.ToString();
                cmbDoctor.SelectedValue = dataGridView1.CurrentRow.Cells["doc_id"].Value.ToString();
                dataGridView1.Visible = false;

            }
        }

        

        
    }
}