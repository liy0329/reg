using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MTREG.clinic.bo;
using MTREG.clinic.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.tools;
using MTREG.medinsur.hdyb.clinic.bo;
using System.Collections.Generic;
using MTREG.medinsur;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.clinic.bll;
using MTREG.medinsur.hdsch;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdsch.clinic.bll;
using MTREG.medinsur.hsdryb;
using MTREG.medinsur.hsdryb.bll;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.gysyb.clinic;
using MTREG.medinsur.gysyb.bo;
using MTREG.medinsur.gysyb.bll;
using System.Text;
using MTREG.medinsur.gzsyb;
//using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.ynsyb.bll;
using MTREG.medinsur.ynsyb.bo;
using MTREG.medinsur.ynsyb.clinic;
using MTREG.medinsur.ynsyb.clinic.bll;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.ynydyb;
using MTREG.medinsur.ynydyb.bll;
using System.Text.RegularExpressions;
using MTREG.medinsur.sjzsyb.clinic.bo;
using MTREG.common.bll;
using MTREG.netpay;
using MTREG.netpay.bo;
using MTREG.medinsur.gzsnh.bll;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.dor;
using MTHIS.tools;
using MTREG;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.medinsur.sjzsyb.bll;

namespace MTREG.clinic
{

    public partial class FrmClinicRcpCost : Form
    {
        Mzybdk mzybdk = new Mzybdk();
        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        Sybdk_Entity sybdk_entity = new Sybdk_Entity();//贵阳市医保
        mz_dk SJZ_DK = new mz_dk();//石家庄读卡out
        BllClinicReg bllClinicReg = new BllClinicReg();
        string invoicekind = "";
        string netpaytype = "-1";
        string homeaddress = "";
        string idcard = "";
        string homephone = "";
        string register_id = "";
        string Ylfkfs_id = "";//医疗付款方式id
        /// <summary>
        /// 病历本号
        /// </summary>
        string blbcard = "";
        //InsurInfo InsurInfo = new InsurInfo();
        BllClinicReg bllRegister = new BllClinicReg();
        //List<Confirm_in> confirmIns = new List<Confirm_in>();
        //结算单信息
        ClinicAccount clinicAccount = new ClinicAccount();//结算表
        List<ClinicInvoice> clinicInvoices = new List<ClinicInvoice>();
        string member_id = "";//会员卡id
        string patienttypeKeyname = "";//患者类型
        public FrmClinicRcpCost()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 收费初始化
        /// </summary>
        public void initCostInfo()
        {



            initInvoice(); //初始化发票
            reSetSearch();//重新查询
            tbxHspcard.Focus();//定位到刷卡位置

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
        private void FrmRecipelCharge_Load(object sender, EventArgs e)
        {
            initFormInfo();//界面初始数据
            initdgvList(); //gridview数据
            initCostInfo();//收费数据
        }
        /// <summary>
        /// 加载dataGridview信息
        /// </summary>
        private void initdgvList()
        {

            //加载处方编号
            loadClinicCostList();
            #region updateHeaderText
            dgvClinicCost.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvClinicCost.RowsDefaultCellStyle.Font = new Font("宋体", (float)(12 * ProgramGlobal.WidthScale));
            this.dgvClinicCost.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(12 * ProgramGlobal.WidthScale), FontStyle.Bold);
            dgvClinicCost.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClinicCost.Columns["checkrcp"].ReadOnly = false;
            dgvClinicCost.Columns["checkrcp"].Width = (int)(30 * ProgramGlobal.WidthScale);
            dgvClinicCost.Columns["checkrcp"].DisplayIndex = 1;
            dgvClinicCost.Columns["checkrcp"].HeaderText = "";
            dgvClinicCost.Columns["id"].Visible = false;
            dgvClinicCost.Columns["rcptype"].Visible = false;
            dgvClinicCost.Columns["billcode"].ReadOnly = true;
            dgvClinicCost.Columns["billcode"].Width = (int)(130 * ProgramGlobal.WidthScale);
            dgvClinicCost.Columns["billcode"].HeaderText = "处方编号";
            dgvClinicCost.Columns["billcode"].DisplayIndex = 2;
            cbxAllcheck.Checked = true;

            #endregion
            //加载处方编号_END
            //加载处方明细

            loadClinicCostDetail();
            #region updateHeaderText
            dgvClinicCostDet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvClinicCostDet.RowsDefaultCellStyle.Font = new Font("宋体", (float)(12 * ProgramGlobal.WidthScale));
            this.dgvClinicCostDet.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(12 * ProgramGlobal.WidthScale), FontStyle.Bold);
            dgvClinicCostDet.ReadOnly = true;
            dgvClinicCostDet.Columns["item_id"].HeaderText = "项目编号";
            dgvClinicCostDet.Columns["item_id"].Width = (int)(100 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["item_id"].DisplayIndex = 0;
            dgvClinicCostDet.Columns["itemtype"].HeaderText = "费用类别";
            dgvClinicCostDet.Columns["itemtype"].Width = (int)(100 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["itemtype"].DisplayIndex = 1;
            dgvClinicCostDet.Columns["depart"].HeaderText = "执行科室";
            dgvClinicCostDet.Columns["depart"].DisplayIndex = 2;
            dgvClinicCostDet.Columns["depart"].Width = (int)(120 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["name"].HeaderText = "费用名称";
            dgvClinicCostDet.Columns["name"].Width = (int)(130 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["name"].DisplayIndex = 3;
            dgvClinicCostDet.Columns["Spec"].HeaderText = "规格";
            dgvClinicCostDet.Columns["Spec"].Width = (int)(80 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["Spec"].DisplayIndex = 4;
            dgvClinicCostDet.Columns["Unit"].HeaderText = "单位";
            dgvClinicCostDet.Columns["Unit"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["Unit"].DisplayIndex = 5;
            dgvClinicCostDet.Columns["Prc"].HeaderText = "单价";
            dgvClinicCostDet.Columns["Prc"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["Prc"].DisplayIndex = 6;
            dgvClinicCostDet.Columns["Prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvClinicCostDet.Columns["Num"].HeaderText = "数量";
            dgvClinicCostDet.Columns["Num"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["Num"].DisplayIndex = 7;
            dgvClinicCostDet.Columns["Realfee"].HeaderText = "实收金额";
            dgvClinicCostDet.Columns["Realfee"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["Realfee"].DisplayIndex = 8;
            dgvClinicCostDet.Columns["Realfee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvClinicCostDet.Columns["discnt"].HeaderText = "折率";
            dgvClinicCostDet.Columns["discnt"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvClinicCostDet.Columns["discnt"].DisplayIndex = 9;


            #endregion

            //加载挂号记录
            loadRegisterList();
            #region updateHeaderText
            dgvRegister.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvRegister.RowsDefaultCellStyle.Font = new Font("宋体", (float)(12 * ProgramGlobal.WidthScale));
            this.dgvRegister.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(12 * ProgramGlobal.WidthScale), FontStyle.Bold);
            dgvRegister.Columns["id"].Visible = false;
            dgvRegister.Columns["id"].Width = 140;
            dgvRegister.Columns["billcode"].HeaderText = "挂号编号";
            dgvRegister.Columns["billcode"].DisplayIndex = 1;
            dgvRegister.Columns["billcode"].Width = (int)(100 * ProgramGlobal.WidthScale);
            dgvRegister.Columns["regname"].HeaderText = "患者姓名";
            dgvRegister.Columns["regname"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvRegister.Columns["regname"].DisplayIndex = 2;
            dgvRegister.Columns["dptname"].HeaderText = "科室";
            dgvRegister.Columns["dptname"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvRegister.Columns["dptname"].DisplayIndex = 3;
            dgvRegister.Columns["dctname"].HeaderText = "门诊医生";
            dgvRegister.Columns["dctname"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvRegister.Columns["dctname"].DisplayIndex = 4;
            dgvRegister.Columns["bas_patienttype_id"].Visible = false;
            dgvRegister.Columns["depart_id"].Visible = false;
            dgvRegister.Columns["doctor_id"].Visible = false;
            dgvRegister.ReadOnly = true;
            if (dgvRegister.Rows.Count > 0)
            {
                dgvRegister.Rows[0].Selected = true;
            }
            #endregion
        }

        /// <summary>
        ///  初始化界面信息
        /// </summary>
        private void initFormInfo()
        {
            invoicekind = bllClinicReg.getInvoiceKind(); //初始化发票类型
            //科室
            var dt1 = bllRecipelCharge.getRegDepartInfo();
            this.cmbDepart.ValueMember = "Id";
            this.cmbDepart.DisplayMember = "Name";
            var dr = dt1.NewRow();
            dr["Id"] = 0;
            dr["Name"] = "--全部--";
            dt1.Rows.InsertAt(dr, 0);
            this.cmbDepart.DataSource = dt1;

            //就诊类型
            DataTable dtp = bllRecipelCharge.getPatientType();
            this.cmbPatientType.ValueMember = "id";
            this.cmbPatientType.DisplayMember = "name";
            this.cmbPatientType.DataSource = dtp;
            cmbPatientType.SelectedValue = 34; //默认自费

            //支付类型的初始化
            DataTable dtpt = bllClinicReg.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtpt;
                this.cmbPayType.SelectedValue = 11;
            }
        }


        /// <summary>
        /// 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadRegisterList();
        }
        /// <summary>
        /// 就诊人员信息
        /// </summary>
        private void loadRegisterList()
        {
            string startDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            DataTable dt = bllRecipelCharge.getRecipelInfo(tbxName.Text.Trim(), startDate, endDate, tbxHspcard.Text.Trim(), cmbDepart.SelectedValue.ToString(), tbxRegBillcode.Text.Trim());
            dgvRegister.DataSource = dt;

            if (dt.Rows.Count <= 0)
            {
                loadClinicCostList();
                loadClinicCostDetail();
                freeSickInfo();
            }
        }
        /// <summary>
        /// 重置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            reSetSearch();

        }
        /// <summary>
        /// 重置查询条件
        /// </summary>
        private void reSetSearch()
        {
            tbxName.Text = "";
            tbxHspcard.Text = "";
            cmbDepart.Text = "--全部--";
            tbxRegBillcode.Text = "";
            dtpStartDate.Value = Convert.ToDateTime(BillSysBase.currDate());
            loadRegisterList();

        }
        /// <summary>
        /// 收费按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCostCharged_Click(object sender, EventArgs e)
        {

            string show = bllRecipelCharge.getnullnum(register_id);
            if (show != null)
            {
                MessageBox.Show(show, "提示");
                return;
            }
            js();
            loadClinicCostList();
            //loadClinicCostDetail();
            //freeSickInfo();

        }

        private void js()
        {
            #region 自费结算
            if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                if (!preAccount()) //预结算
                {

                    return;
                }
                btnCostCharged.Enabled = false;
                if (!doAccount()) //结算
                {
                    btnCostCharged.Enabled = true;
                    return;
                } 
                btnCostCharged.Enabled = true;
                if (this.cmbPayType.SelectedValue.ToString() == "1")
                {
                    Bjq.bjqts(tbxRcvFee.Text + "Y");
                    Bjq.bjqts(tbxRetFee.Text + "Z");
                }
            }
            #endregion

            //邯郸市医保

            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSYB.ToString()))
            {
                #region 邯郸市医保
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
                        if (dgvClinicCostDet.Rows.Count == 0)
                        {
                            return;
                        }
                        string err_ypdz = "";
                        if (!syb.ypdzxx(ref err_ypdz, mzybdk, dgvClinicCostDet, "0")) //读疾病药品对照信息
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
                    double ybfee = Convert.ToDouble(mzybdk.Zhye);
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

                    //clinic_costdet_id = ret_iids[0].ToString().Trim();
                    //cmbPayType.Text = "0";
                    //tbxRetFee.Text = "0";
                    btnCostCharged.Enabled = true;
                    btnCostCharged.Text = "结算";
                    tbxRcvFee.SelectAll();
                    tbxRcvFee.Focus();


                    ///////////////////
                    //if (!Mzzfsf_bf(mage, ret_iids, jsfs, mzybdk, yb))
                    //{
                    //    MessageBox.Show(mage.ToString());
                    //    Mzsf.Enabled = true;
                    //    Mzyblb.Enabled = true;
                    //    return;
                    //}
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


                //邯郸城乡
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSCH.ToString()))
            {
                #region 邯郸城乡
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
                        if (dgvClinicCostDet.Rows.Count == 0)
                        {
                            return;
                        }
                        string err_ypdz = "";
                        if (!mzch.ypdzxx(ref err_ypdz, mzybdk, dgvClinicCostDet, "0")) //读疾病药品对照信息
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
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SJZSYB.ToString()) || patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SJZSJM.ToString()))
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
                    Bjq.bjqts(tbxPayFee.Text + "J");
                    btnCostCharged.Text = "结算";
                    unableEdit();
                    return;

                }
                else
                {
                    #region
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
                    #endregion
                }
                #endregion
            }

            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GZSYB.ToString()))
            {
                #region
                if (btnCostCharged.Text == "收费")
                {
                    if (!readCardGZSYB())
                    {
                        return;
                    }
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
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GYSYB.ToString()))
            {
                #region
                if (btnCostCharged.Text == "收费")
                {
                    if (!readCardGYSYB())
                    {
                        return;
                    }
                    if (!preAccount())
                    {
                        return;
                    }
                    Bjq.bjqts(tbxPayFee.Text + "J");
                    btnCostCharged.Text = "结算";
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
                    initCostInfo();
                }
                #endregion
            }

        }


        /// <summary>
        /// 加载收费主表
        /// </summary>
        private void loadClinicCostList()
        {
            String register_id = "";
            if (this.dgvRegister.CurrentRow != null)
            {
                register_id = dgvRegister.CurrentRow.Cells["id"].Value.ToString();
            }
            string startDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";


            dgvClinicCost.DataSource = bllRecipelCharge.getClinicCost(register_id, startDate, endDate);

        }
        /// <summary>
        /// 加载收费明细表
        /// </summary>
        private void loadClinicCostDetail()
        {
            string clinicCostIds = getCliniCostIds();
            dgvClinicCostDet.DataSource = bllRecipelCharge.getClinicCostDet(clinicCostIds);
            double amount = 0;
            for (int i = 0; i < dgvClinicCostDet.Rows.Count; i++)
            {

                if (dgvClinicCostDet.Rows[i].Cells["Realfee"].Value != null)
                    if (!dgvClinicCostDet.Rows[i].Cells["Realfee"].Value.ToString().Equals(""))
                    {
                        Regex obj = new Regex(@"^(\d+(\.\d+)?)?$");

                        if (!obj.IsMatch(dgvClinicCostDet.Rows[i].Cells["Realfee"].Value.ToString()))
                        {
                            continue;
                        }
                        string str = dgvClinicCostDet.Rows[i].Cells["Realfee"].Value.ToString();
                        amount = amount + double.Parse(dgvClinicCostDet.Rows[i].Cells["Realfee"].Value.ToString());
                    }
            }
            tbxAmount.Text = amount.ToString("0.00");
            if (cmbPayType.SelectedValue.ToString() == "1")
            {
                this.tbxPayFee.Text = tbxAmount.Text;
            }
            setAccountInfo(patienttypeKeyname);
        }

        /// <summary>
        /// 获取收费主表Ids
        /// </summary>
        /// <returns></returns>
        private string getCliniCostIds()
        {
            string clinicCostIds = "";
            for (int i = 0; i < dgvClinicCost.Rows.Count; i++)
            {
                if (dgvClinicCost.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                {
                    clinicCostIds += dgvClinicCost.Rows[i].Cells["id"].Value.ToString() + ",";
                }
            }
            if (!String.IsNullOrEmpty(clinicCostIds))

                clinicCostIds = clinicCostIds.Substring(0, clinicCostIds.Length - 1);
            return clinicCostIds;
        }
        /// <summary>
        /// 处方id
        /// </summary>
        /// <returns></returns>
        private string getRcpCostIds()
        {
            string costIds = "";
            for (int i = 0; i < dgvClinicCost.Rows.Count; i++)
            {
                if (dgvClinicCost.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE" && dgvClinicCost.Rows[i].Cells["rcptype"].Value.ToString().Trim() == "RCP")
                {
                    costIds += dgvClinicCost.Rows[i].Cells["id"].Value.ToString() + ",";
                }
            }
            if (!String.IsNullOrEmpty(costIds))

                costIds = costIds.Substring(0, costIds.Length - 1);
            return costIds;
        }
        /// <summary>
        /// 检查id
        /// </summary>
        /// <returns></returns>
        private string getChkCostIds()
        {
            string costIds = "";
            for (int i = 0; i < dgvClinicCost.Rows.Count; i++)
            {
                if (dgvClinicCost.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")// && dgvClinicCost.Rows[i].Cells["rcptype"].Value.ToString().Trim() == "CHK")
                {
                    costIds += dgvClinicCost.Rows[i].Cells["id"].Value.ToString() + ",";
                }
            }
            if (!String.IsNullOrEmpty(costIds))

                costIds = costIds.Substring(0, costIds.Length - 1);
            return costIds;
        }

        /// <summary>
        /// 根据就诊加载页面患者新
        /// </summary>
        private void loadSickInfo()
        {
            if (dgvRegister.Rows.Count < 1)
                return;
            register_id = "";
            if (this.dgvRegister.CurrentRow != null)
                register_id = dgvRegister.CurrentRow.Cells["id"].Value.ToString();
            DataTable dt = bllRecipelCharge.getSickInfo(register_id);
            tbxSickName.Text = dt.Rows[0]["name"].ToString();
            tbxSickHspcard.Text = dt.Rows[0]["hspcard"].ToString();
            tbxSickSex.Text = "";
            if (dt.Rows[0]["sex"].ToString() == "M")
                tbxSickSex.Text = "男";
            if (dt.Rows[0]["sex"].ToString() == "W")
                tbxSickSex.Text = "女";
            tbxAge.Text = dt.Rows[0]["age"].ToString();
            tbxSickRegBillcode.Text = dt.Rows[0]["billcode"].ToString();
            tbxSickDepart.Text = dt.Rows[0]["dptname"].ToString();
            tbxSickDoctor.Text = dt.Rows[0]["dctname"].ToString();
            if (dt.Rows[0]["bas_patienttype_id"].ToString() == "" || dt.Rows[0]["bas_patienttype_id"].ToString() == null)
            {
                cmbPatientType.SelectedValue = 1;
            }
            //else
            //{
            //    cmbPatientType.SelectedValue = dt.Rows[0]["bas_patienttype_id"].ToString();
            //}

            homeaddress = dt.Rows[0]["homeaddress"].ToString();
            idcard = dt.Rows[0]["idcard"].ToString();
            homephone = dt.Rows[0]["homephone"].ToString();
            patienttypeKeyname = dt.Rows[0]["keyname"].ToString();
            if (dt.Rows[0]["keyname"].ToString().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                //btnCostCharged.Enabled = false;
                //cmbPatientType.Enabled = false;
            }
            else
            {
                //cmbPatientType.Enabled = true;
            }
            patientTypeChange();


        }
        /// <summary>
        /// 清空病人信息
        /// </summary>
        private void freeSickInfo()
        {
            tbxSickName.Text = "";
            tbxSickHspcard.Text = "";
            tbxSickSex.Text = "";
            tbxAge.Text = "";
            tbxSickRegBillcode.Text = "";
            tbxSickDepart.Text = "";
            tbxSickDoctor.Text = "";
            homeaddress = "";
            idcard = "";
            homephone = "";
            patienttypeKeyname = "";
        }


        /// <summary>
        /// 触发收费主表数据的复选框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRecipelIDChart_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvClinicCost.IsCurrentCellDirty)
            {
                dgvClinicCost.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        //改变患者类型
        private void patientTypeChange()
        {
            if (cmbPatientType.Items.Count <= 0)
            {
                return;
            }
            string patientType_id = cmbPatientType.SelectedValue.ToString();
            string keyname = bllRecipelCharge.getPatienttypeKeyname(patientType_id);
            if (keyname == patienttypeKeyname)
            {
                return;
            }
            if (keyname.Equals(CostInsurtypeKeyname.GYSYB.ToString()))
            {
                tbxAccountFee.ReadOnly = false;
            }
            else
            {
                tbxAccountFee.ReadOnly = true;
            }
            if (keyname.Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                Bjq.bjqts(tbxPayFee.Text + "J");//应收钱数报价器
            }
            if (keyname.Equals(CostInsurtypeKeyname.SJZSYB.ToString()))
            {
                btnCostCharged.Enabled = true;
            }
            else
            {
                btnCostCharged.Enabled = false;
            }
            setAccountInfo(keyname);
        }
        /// <summary>
        /// 设置结账显示信息
        /// </summary>
        private void setAccountInfo(string keyname)
        {
            if (string.IsNullOrEmpty(patienttypeKeyname))
            {
                patienttypeKeyname = keyname;
                return;
            }

            //初始化页面信息
            cmbPayType.SelectedValue = 11;//支付类型默认为现金
            netpaytype = "-1";
            tbxPayFee.Text = tbxAmount.Text;//支付金额
            tbxRcvFee.Text = tbxPayFee.Text;//实收金额

            //tbxAccountAmt.Text = "";//账户余额
            tbxInsurFee.Text = "";//报销
            tbxAccountFee.Text = "";//账户
            tbxSbpay.Text = "";//商保
            tbxSbpayline.Text = "";//商保起付线
            lblReadCardMsg.Text = "";//读卡信息
            patienttypeKeyname = keyname;
            btnCostCharged.Text = "收费";
        }
        /// <summary>
        /// 挂号记录行改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRegister_SelectionChanged(object sender, EventArgs e)
        {
            loadClinicCostList();
            loadClinicCostDetail();
            loadSickInfo();
        }

        /// <summary>
        /// 总复选框状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAllcheck_CheckStateChanged(object sender, EventArgs e)
        {
            allCheckChange();
        }

        /// <summary>
        /// 收费主表数据改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClinic_cost_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            loadClinicCostDetail();
        }
        /// <summary>
        ///  总复选框状态改变事件
        /// </summary>
        private void allCheckChange()
        {
            int isallchk = 0;
            if (cbxAllcheck.Checked == true)
            {
                isallchk = 1;
            }
            for (int i = 0; i < dgvClinicCost.RowCount; i++)
            {
                dgvClinicCost.Rows[i].Cells["checkrcp"].Value = isallchk;

            }
        }
        /// <summary>
        /// 省医保读卡
        /// </summary>
        /// <returns></returns>
        private bool readCardGZSYB()
        {
            //bool flag = false;
            FrmClinMedinsurGZS frmClinMedinsurGZS = new FrmClinMedinsurGZS();
            //frmClinMedinsurGZS.PatientType = this.cmbPatientType.SelectedValue.ToString();
            //frmClinMedinsurGZS.StartPosition = FormStartPosition.CenterScreen;
            //frmClinMedinsurGZS.ShowDialog(this);
            //this.personInfo = frmClinMedinsurGZS.PersonInfo;
            //flag = frmClinMedinsurGZS.Flag;
            //if (!flag)
            //{
            //    lblReadCardMsg.Text = "读卡失败！";
            //    return false;
            //}
            //lblReadCardMsg.Text = "读卡成功！";
            //this.tbxAccountAmt.Text = personInfo.Swgrzhye;

            //if (string.IsNullOrEmpty(personInfo.Swxm) || string.IsNullOrEmpty(tbxSickName.Text.Trim()))
            //{
            //    MessageBox.Show(string.Format("读取处方患者姓名或医保卡持有者姓名为空，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), personInfo.Swxm));
            //    return false;
            //}
            //else if (personInfo.Swxm != tbxSickName.Text.Trim()) //处方患者姓名与医保卡持有者姓名不一致判断
            //{
            //    MessageBox.Show(string.Format("处方患者姓名与医保卡持有者姓名不一致无法完成此次交易，请确认！(处方患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", tbxSickName.Text.Trim(), personInfo.Swxm));
            //    return false;
            //}
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
            //tbxAccountAmt.Text = sybdk_entity.Zhye;//账户余额
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
        /// 石家庄医保读卡
        /// </summary>
        /// <returns></returns>
        private bool readCardSJZYB()
        {
            bool flag = false;
            FrmMzYb frmmzyb = new FrmMzYb();
            frmmzyb.regist_id = register_id;
            frmmzyb.StartPosition = FormStartPosition.CenterScreen;
            frmmzyb.ShowDialog(this);
            this.SJZ_DK = frmmzyb.dk_out;
            this.Ylfkfs_id = frmmzyb.Ylfkfs_id;
            this.blbcard = frmmzyb.blbcard;
            flag = frmmzyb.Flag;
            if (!flag)
            {
                lblReadCardMsg.Text = "读卡失败！";
                return false;
            }
            lblReadCardMsg.Text = "读卡成功！";
            //this.tbxAccountAmt.Text = SJZ_DK.DK_OUT.AKC087;
            string yllb = SJZ_DK.DK_OUT.AKC021;

            if (yllb == "41")
            {
                cmbPatientType.SelectedValue = "35";
            }
            else
            {
                cmbPatientType.SelectedValue = "34";
            }

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
        ///  查询按钮回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                loadRegisterList();
            }
        }
        /// <summary>
        /// 重置按钮回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                reSetSearch();
            }
        }


        /// <summary>
        /// 卡号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxHspcard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//读卡号 要判断 e 是否为回车
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
            }
            loadRegisterList();
        }

        /// <summary>
        /// 患者类型改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPatientType_SelectedValueChanged(object sender, EventArgs e)
        {
            patientTypeChange();
        }


        /// <summary>
        /// 支付类型改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPayType_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cmbPayType.Text.Trim() == "现金")
            //{
            this.tbx_QT.ReadOnly = true;
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
                netPayIn.StoreId = "0";
                netPayIn.Subject = "门诊收费";
                netPayIn.Ddlx = "2";//订单类型（默认1）：1挂号；2缴费；3预交金 
                netPayIn.Ddly = "1";//订单来源（默认1）：1门诊;2住院

                netPayIn.Hzxm = tbxSickName.Text;
                netPayIn.Lxdh = homephone;
                netPayIn.Sfzh = "";
                netPayIn.Ysje = tbxPayFee.Text.Trim();
                netPayIn.Ksmc = tbxSickDepart.Text;
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

        /// <summary>
        /// 结算
        /// </summary>
        private bool doAccount()
        {
            double bx = Double.Parse(tbxInsurFee.Text);//医保报销
            double zh = Double.Parse(tbxAccountFee.Text);//账户支付
            double xj = Double.Parse(tbxRcvFee.Text);//现金支付
            double hj = Double.Parse(tbxAmount.Text);//合计
            if ((hj -(bx+zh+xj)) > 0.1)
            {
                MessageBox.Show("结算费用过大，结算失败！", "提示");
                return false;
            }

            //1定义本次收费sql
            string clinic_cost_sql = "";
            //2.结算并生成计费sql
            string invoices_sql = "";

            //网络支付处理
            string currDate = clinicAccount.Settledate;
            string hisOrderNo = "";
            if (!doExecNetPay(currDate, ref hisOrderNo))
                return false;
            addInvoiceHisOrderNo(clinicInvoices, hisOrderNo);
            ////网路支付处理_END


            if (!doClinicInvoice(clinicInvoices, ref  invoices_sql))
            {
                // bllRecipelCharge.doCancleInsurInvoice(clinicInvoices);//失败后处理医保信息
                return false;
            }
            clinic_cost_sql += invoices_sql;

            //3.生成结账信息单sql
            clinicAccount.Recivefee = tbxRcvFee.Text;
            clinicAccount.Realfee = tbxAmount.Text;
            clinicAccount.Payfee = tbxPayFee.Text;
            clinicAccount.Retfee = tbxRetFee.Text;
            clinicAccount.Insurefee = tbxInsurFee.Text;
            clinicAccount.Insuraccountfee = tbxAccountFee.Text;
            clinicAccount.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
            clinicAccount.HisOrderNo = hisOrderNo;
            clinic_cost_sql += bllRecipelCharge.doClinicAccount(clinicAccount);

            ////门诊卡支付
            string balance = "";
            if (!String.IsNullOrEmpty(reaInsurCardButtonClick()))
            {



                BllMemberReg bllMemberReg = new BllMemberReg();
                string id = "";
                if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
                {
                    balance = (Double.Parse(tbxAccountAmt.Text) - Double.Parse(tbxRcvFee.Text)).ToString();
                    if (Double.Parse(balance) < 0)
                    {
                        MessageBox.Show("门诊卡余额不足！当前余额为:" + tbxAccountAmt.Text + "。");
                        return false;
                    }

                    clinic_cost_sql += bllMemberReg.upMember_balance(member_id, balance);
                    clinic_cost_sql += bllMemberReg.inMember_rechargedet(member_id, "CO", "-" + tbxPayFee.Text, "11", (Double.Parse(balance) + Double.Parse(tbxPayFee.Text)).ToString(), ref id);
                }
                else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SJZSYB.ToString()))
                {
                    //门诊卡当前余额
                    balance = Double.Parse(tbxAccountAmt.Text).ToString();

                    double dInsurFee = Double.Parse(tbxInsurFee.Text);//医保报销
                    double dAccountFee = Double.Parse(tbxAccountFee.Text);//账户支付
                    double dPayFee = Double.Parse(tbxPayFee.Text);//应收费用

                    //当前余额+医保报销
                    double balance_add_InsurFee = Double.Parse(balance) + dInsurFee;
                    //当前余额+医保报销 + 账户支付
                    double balance_add_AccountFee = Double.Parse(balance) + dInsurFee + dAccountFee;
                    //当前余额+医保报销 + 账户支付 -应收费用
                    double balance_last = Double.Parse(balance) + dInsurFee + dAccountFee - dPayFee;

                    if (( (dInsurFee + dAccountFee) - dPayFee > 0.1) || dPayFee == 0)
                    {
                        MessageBox.Show("收费信息异常！,医保病人请及时撤销医保票据,用网络支付时，请及时撤销网络支付");
                        string mes = " 医保报销：" + dInsurFee.ToString()
                                   + " \r\n 账户支付:" + dAccountFee.ToString()
                                   + " \r\n 应收费用:" + dPayFee.ToString()
                                   + " \r\n 卡内余额:" + balance_last.ToString();
                        SysWriteLogs.writeLogs1("收费信息生成失败.log", Convert.ToDateTime(BillSysBase.currDate()), mes);
                        return false;
                    }


                    //添加统筹支付
                    clinic_cost_sql += bllMemberReg.inMember_rechargedet(member_id, "RE", dInsurFee.ToString(), "4", (balance_add_InsurFee).ToString(), ref id);
                    //添加账户支付
                    clinic_cost_sql += bllMemberReg.inMember_rechargedet(member_id, "RE", dAccountFee.ToString(), "5", (balance_add_AccountFee).ToString(), ref id);
                    //减去应收费用
                    clinic_cost_sql += bllMemberReg.inMember_rechargedet(member_id, "CO", "-" + dPayFee.ToString(), "11", (balance_last).ToString(), ref id);
                    //修改余额表
                    clinic_cost_sql += bllMemberReg.upMember_balance(member_id, (balance_last).ToString());

                    balance = (balance_last).ToString();
                }

            }
            else
            {
                return false;
            }
            //7 执行sql
            if (bllRecipelCharge.doExeSql(clinic_cost_sql) < 0)
            {
                MessageBox.Show("收费信息生成失败！,医保病人请及时撤销医保票据,用网络支付时，请及时撤销网络支付");
                //bllRecipelCharge.doCancleInsurInvoice(clinicInvoices);//失败后处理医保信息
                SysWriteLogs.writeLogs1("收费信息生成失败.log", Convert.ToDateTime(BillSysBase.currDate()), clinic_cost_sql);
                return false;
            }

            ClinicInvoice clinicInvoice1 = new ClinicInvoice();
            MessageBox.Show("使用门诊卡支付" + tbxRcvFee.Text + "？当前余额为:" + tbxAccountAmt.Text + "。收费后余额：" + balance, "提示");
            if (MessageBox.Show("收费成功！是否打印明细？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (!patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
                {
                    if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SJZSYB.ToString()))
                    {
                        for (int i = 0; i < clinicInvoices.Count; i++)
                        {

                            ClinicInvoice clinicInvoice = clinicInvoices[i];
                            FrxPrintView FrxPrintView = new bo.FrxPrintView();
                            string clinic_cost_id = clinicInvoice.Clinic_cost_ids;
                            string fph2 = clinicInvoice.Invoice;
                            FrxPrintView.clinicInvoice(clinic_cost_id, fph2);
                        }
                    }
                    //        else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSYB.ToString()))
                    //        {
                    //            for (int i = 0; i < clinicInvoices.Count; i++)
                    //            {
                    //                ClinicInvoice clinicInvoice = clinicInvoices[i];
                    //                MZSyb mzsyb = new MZSyb();

                    //                mzsyb.fpcd(clinicInvoice.Id);
                    //            }
                    //        }
                    //        else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSCH.ToString()))
                    //        {
                    //            for (int i = 0; i < clinicInvoices.Count; i++)
                    //            {
                    //                ClinicInvoice clinicInvoice = clinicInvoices[i];
                    //                MZCH mzch = new MZCH();
                    //                mzch.fpcd(clinicInvoice.Clinic_cost_ids);
                    //            }

                    //        }

                    //    }
                    //    else
                    //    {
                    //        //是否分发票
                    //        ////int isffp = ProgramGlobal.Isffp;
                    //        //FrxPrintView frxPrintView = new FrxPrintView();
                    //        ////if (isffp == 0)
                    //        ////{
                    //        ////for (int i = 0; i < clinicInvoices.Count; i++)
                    //        ////{
                    //        ////    ClinicInvoice clinicInvoice = clinicInvoices[i];
                    //        ////    frxPrintView.printInvoice( clinicInvoice.Clinic_cost_ids,clinicInvoice.Id);
                    //        ////}
                    //        ////}
                    //        ////else
                    //        ////{
                    //        //Billjc bjc = new Billjc();
                    //        ////    for (int i = 0; i < clinicInvoices.Count; i++)
                    //        ////    {                            
                    //        //ClinicInvoice clinicInvoice = clinicInvoices[0];
                    //        //DataTable dt = bjc.getffp(clinicInvoice.Clinic_cost_ids);
                    //        //for (int j = 0; j < dt.Rows.Count; j++)
                    //        //{
                    //        //    frxPrintView.printInvoice_ffp(clinicInvoice.Clinic_cost_ids, clinicInvoice.Id, dt.Rows[j]["exedep_id"].ToString());
                    //        //}
                    //        ////    }
                    //        ////}
                    //        FrxPrintView frxPrintView = new FrxPrintView();
                    //        for (int i = 0; i < clinicInvoices.Count; i++)
                    //        {
                    //            ClinicInvoice clinicInvoice = clinicInvoices[i];
                    //            frxPrintView.clinic_mzmx(clinicInvoice.Id, balance);
                    //        }

                }
            }
            return true;
        }
        /// <summary>
        /// 获取检查发票信息
        /// </summary>
        /// <param name="clinicInvoices"></param>
        /// <returns></returns>
        private int getChkInvoices(ClinicAccount clinicAccount, List<ClinicInvoice> clinicInvoices)
        {
            string chkCostdet_ids = bllRecipelCharge.getCostdet(getChkCostIds());
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
                DataTable dtChkCost = bllRecipelCharge.getCostInfo(invoiceCostdetIds);

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
            clinicInvoice.Regist_id = dgvRegister.CurrentRow.Cells["id"].Value.ToString();
            clinicInvoice.Sickname = tbxSickName.Text.Trim().ToString();
            clinicInvoice.Rcpdep_id = dgvRegister.CurrentRow.Cells["depart_id"].Value.ToString();// dtChkCost.Rows[0]["depart_id"].ToString();//dgvRegister 里的
            clinicInvoice.Rcpdoctor_id = dgvRegister.CurrentRow.Cells["doctor_id"].Value.ToString();//dtChkCost.Rows[0]["doctor_id"].ToString();
            clinicInvoice.Billcode = dgvRegister.CurrentRow.Cells["billcode"].Value.ToString();//dtChkCost.Rows[0]["billcode"].ToString();
            clinicInvoice.Exedep_id = clinicInvoice.Rcpdep_id;
            clinicInvoice.Fee = fee.ToString();
            clinicInvoice.Discnt = "1";
            clinicInvoice.Realfee = (double.Parse(clinicInvoice.Fee) * double.Parse(clinicInvoice.Discnt)).ToString();
            clinicInvoice.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();
            clinicInvoice.Chargedate = clinicAccount.Settledate;
            clinicInvoice.Depart_id = ProgramGlobal.Depart_id;
            clinicInvoice.Chargeby = ProgramGlobal.User_id;//收费人
            clinicInvoice.Charged = CostCharged.CHAR.ToString();
            clinicInvoice.Clinic_cost_ids = Clinic_cost_ids1.Remove(Clinic_cost_ids1.Length - 1);
            clinicInvoice.Clinic_costdet_ids = Clinic_costdet_ids1.Remove(Clinic_costdet_ids1.Length - 1);
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
            string chkCostdet_ids = bllRecipelCharge.getCostdet(getChkCostIds());
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
            string rcpCostIds = getRcpCostIds();
            DataTable dtRcpCost = bllRecipelCharge.getRcpClinicCosts(rcpCostIds);
            for (int i = 0; i < dtRcpCost.Rows.Count; i++)
            {
                string costId = dtRcpCost.Rows[i]["id"].ToString();
                string realfee = "";
                ClinicInvoice clinicInvoice = new ClinicInvoice();
                clinicInvoice.Id = BillSysBase.nextId("clinic_invoice");
                clinicInvoice.Account_id = clinicAccount.Id;
                clinicInvoice.Clinic_cost_ids = costId;
                clinicInvoice.Clinic_costdet_ids = bllRecipelCharge.getCostdetId_RealFee(costId, ref realfee);
                clinicInvoice.Regist_id = dgvRegister.CurrentRow.Cells["id"].Value.ToString();
                clinicInvoice.Sickname = tbxSickName.Text.Trim().ToString();
                clinicInvoice.Rcpdep_id = dtRcpCost.Rows[i]["depart_id"].ToString();
                clinicInvoice.Rcpdoctor_id = dtRcpCost.Rows[i]["doctor_id"].ToString();
                clinicInvoice.Exedep_id = dtRcpCost.Rows[i]["exedep_id"].ToString();
                clinicInvoice.Billcode = dtRcpCost.Rows[i]["billcode"].ToString();
                clinicInvoice.Fee = realfee;
                clinicInvoice.Discnt = "1";
                clinicInvoice.Realfee = realfee;
                clinicInvoice.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();
                clinicInvoice.Chargedate = clinicAccount.Settledate;
                clinicInvoice.Depart_id = ProgramGlobal.Depart_id;
                clinicInvoice.Chargeby = ProgramGlobal.User_id;//收费人
                clinicInvoice.Charged = CostCharged.CHAR.ToString();
                clinicInvoice.Clinic_tab_id = ""; //日结单号
                clinicInvoice.Isregist = "0";
                clinicInvoices.Add(clinicInvoice);
            }
            return dtRcpCost.Rows.Count;
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
                #region
                //if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.HDSYB.ToString().ToUpper().Trim()))
                //{
                //    invoices_sql += clinicInvoice.Invoice_sql;
                //    invoices_sql += bllRecipelCharge.updateClinicInvoiceZgmzFlag(clinicInvoice.Id);

                //}
                //if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.HDSCH.ToString().ToUpper().Trim()))
                //{
                //    invoices_sql += clinicInvoice.Invoice_sql;

                //}
                ////贵州省医保结算
                //if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.GZSYB.ToString().ToUpper().Trim()))
                //{
                //    invoices_sql += clinicInvoice.Invoice_sql;


                //}
                //else if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.GYSYB.ToString().ToUpper().Trim())
                //{
                //    Gysybservice gysyb = new Gysybservice();
                //    StringBuilder message = new StringBuilder(150);
                //    string[] yb = new string[5];//账户 统筹 商保起伏线 商保支付 分中心编码

                //    double double_amount = DataTool.stringToDouble(clinicInvoice.Fee);
                //    string once_zhzf = "";
                //    if ((double_zhzf - double_amount) < 0)
                //    {
                //        once_zhzf = Convert.ToString(double_zhzf);
                //    }
                //    else
                //    {
                //        once_zhzf = clinicInvoice.Fee;
                //    }
                //    string amount = clinicInvoice.Fee;
                //    if (!gysyb.mzzsjs_kls(sybdk_entity, clinicInvoice, ref once_zhzf, yb, message))
                //    {
                //        MessageBox.Show("市医保门诊接口失败！,请及时撤销医保结算票据" + err_messgae + ", 用网络支付请及时撤销相关网络支付");
                //        SysWriteLogs.writeLogs1("医保发票结算错误", DateTime.Now, err_messgae);
                //        return false;
                //    }
                //    err_messgae += "市医保结算号:[" + clinicInvoice.Id + "],";
                //    string insurefee = yb[1].ToString();//医保报销
                //    string insuraccountfee = yb[0].ToString();//账户
                //    string insur_sbzf = yb[3].ToString();//商保
                //    string payfee = (DataTool.stringToDouble(amount) - DataTool.stringToDouble(insurefee) - DataTool.stringToDouble(insuraccountfee) - DataTool.stringToDouble(insur_sbzf)).ToString("0.00");
                //    string insurtype = yb[4];
                //    double_zhzf -= Convert.ToDouble(insuraccountfee);//减去账户支付

                //    //填入发票支付信息
                //    ClinicInvoiceDet clinicInvoiceDet = new ClinicInvoiceDet();
                //    clinicInvoiceDet.Clinic_invoice_id = clinicInvoice.Id;
                //    clinicInvoiceDet.Payfee = DataTool.stringToDouble(yb[1]).ToString();
                //    clinicInvoiceDet.Bas_paytype_id = bllClinicReg.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());//统筹支付
                //    clinicInvoiceDet.Bas_paysumby_id = "4";
                //    clinicInvoiceDet.Cheque = "";
                //    clinicInvoiceDetList.Add(clinicInvoiceDet);
                //    ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();
                //    clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
                //    clinicInvoiceDet2.Payfee = DataTool.stringToDouble(insuraccountfee).ToString();
                //    clinicInvoiceDet2.Bas_paytype_id = bllClinicReg.getPaytypeId(BasPaytypeKeyname.SELFFEE.ToString());//账户支付
                //    clinicInvoiceDet2.Bas_paysumby_id = "4";
                //    clinicInvoiceDet2.Cheque = "";
                //    clinicInvoiceDetList.Add(clinicInvoiceDet2);
                //    ClinicInvoiceDet clinicInvoiceDet3 = new ClinicInvoiceDet();
                //    clinicInvoiceDet3.Clinic_invoice_id = clinicInvoice.Id;
                //    clinicInvoiceDet3.Payfee = insur_sbzf;
                //    clinicInvoiceDet3.Bas_paytype_id = bllClinicReg.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());
                //    clinicInvoiceDet3.Bas_paysumby_id = "5";//商保
                //    clinicInvoiceDet3.Cheque = "";
                //    clinicInvoiceDetList.Add(clinicInvoiceDet3);
                //    ClinicInvoiceDet clinicInvoiceDet4 = new ClinicInvoiceDet();
                //    clinicInvoiceDet4.Clinic_invoice_id = clinicInvoice.Id;
                //    clinicInvoiceDet4.Payfee = payfee;
                //    clinicInvoiceDet4.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                //    clinicInvoiceDet4.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
                //    clinicInvoiceDet4.Cheque = "";
                //    clinicInvoiceDetList.Add(clinicInvoiceDet4);

                //    clinicInvoice.Bas_patienttype1_id = clinicInvoice.Bas_patienttype_id;
                //    clinicInvoice.Insurefee = insurefee;
                //    clinicInvoice.Insurotherfee = insur_sbzf;
                //    clinicInvoice.Insuraccountfee = insuraccountfee;
                //    clinicInvoice.Payfee = payfee;
                //    clinicInvoice.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                //    //填入发票支付信息_END 
                //    invoices_sql += bllRecipelCharge.doClinicInvoice(clinicInvoice, clinicInvoiceDetList);//收费发票
                //}
                #endregion
                if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.SELFCOST.ToString().ToUpper().Trim())
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
                else if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.SJZSYB.ToString().ToUpper().Trim()) || patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.SJZSJM.ToString().ToUpper().Trim()))
                {
                    MZSyb mzsyb = new MZSyb();

                    string info = "";
                    double[] yb = new double[4];//ger tong fenzhongxin
                    if (!mzsyb.ybjs(SJZ_DK, register_id, tbxSickDoctor.Text.Trim(), tbxSickDepart.Text.Trim(), blbcard, clinicInvoice, yb))
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
                    invoices_sql = bllRecipelCharge.doClinicInvoice(clinicInvoice, clinicInvoiceDetList);//收费发票
                    //this.tbxAccountAmt.Text = yb[1].ToString().Trim();//yb[1]账户余额
                    this.tbxAccountFee.Text = yb[0].ToString().Trim();//yb[0] 账户支付
                    this.tbxInsurFee.Text = yb[2].ToString().Trim();//yb[2]医保报销
                    this.tbxRcvFee.Text = yb[3].ToString().Trim();//yb[3]现金支付
                    this.tbxRetFee.Text = "0.00";
                }
                //网络支付
                if (!string.IsNullOrEmpty(clinicInvoice.HisOrderNo))
                {
                    invoices_sql += bllRecipelCharge.addClinicInvoice(clinicInvoice);
                }
            }
            return true;
        }

        /// <summary>
        /// 预结算发票
        /// </summary>
        /// <param name="clinicInvoices"></param>
        /// <returns></returns>
        private bool preClinicInvoice(List<ClinicInvoice> clinicInvoices)
        {

            //double amount = 0;
            //double insuraccountfee = 0;//账户支付
            //double insurefee = 0;//医保报销
            //double allpayfee = 0;
            if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.SJZSYB.ToString().ToUpper().Trim()))
            {
                MZSyb mzsyb = new MZSyb();
                string err_messgae = "";
                for (int i = 0; i < clinicInvoices.Count; i++)
                {
                    ClinicInvoice clinicInvoice = clinicInvoices[i];
                    List<ClinicInvoiceDet> clinicInvoiceDetList = new List<ClinicInvoiceDet>();

                    string info = "";
                    double[] yb = new double[4];//ger tong fenzhongxin
                    if (!mzsyb.ybyjs(SJZ_DK, register_id, tbxSickDoctor.Text.Trim(), tbxSickDepart.Text.Trim(), blbcard, clinicInvoice, yb))
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
                    //this.tbxAccountAmt.Text = yb[1].ToString().Trim();//yb[1]账户余额
                    this.tbxAccountFee.Text = yb[0].ToString().Trim();//yb[0] 账户支付
                    this.tbxInsurFee.Text = yb[2].ToString().Trim();//yb[2]医保报销
                    this.tbxRcvFee.Text = yb[3].ToString().Trim();//yb[3]现金支付
                    this.tbxRetFee.Text = "0.00";
                }
            }
            #region
            //if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.HDSCH.ToString().ToUpper().Trim()))
            //{
            //MZCH mzsyb = new MZCH();
            //string err_messgae = "";
            //for (int i = 0; i < clinicInvoices.Count; i++)
            //{
            //    ClinicInvoice clinicInvoice = clinicInvoices[i];
            //    List<ClinicInvoiceDet> clinicInvoiceDetList = new List<ClinicInvoiceDet>();

            //    string info = "";
            //    double[] yb = new double[4];//ger tong fenzhongxin
            //    if (!mzsyb.ybjs(mzybdk, tbxSickDoctor.Text.Trim(), tbxSickDepart.Text.Trim(), clinicInvoice, yb))
            //    {
            //        return false;
            //    }
            //        ClinicInvoiceDet clinicInvoiceDet = new ClinicInvoiceDet();
            //        clinicInvoiceDet.Clinic_invoice_id = clinicInvoice.Id;
            //        clinicInvoiceDet.Payfee = yb[2].ToString();
            //        clinicInvoiceDet.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());//统筹支付
            //        clinicInvoiceDet.Bas_paysumby_id = "301";
            //        clinicInvoiceDet.Cheque = "";
            //        clinicInvoiceDetList.Add(clinicInvoiceDet);
            //        ClinicInvoiceDet clinicInvoiceDet1 = new ClinicInvoiceDet();
            //        clinicInvoiceDet1.Clinic_invoice_id = clinicInvoice.Id;
            //        clinicInvoiceDet1.Payfee = yb[0].ToString();
            //        clinicInvoiceDet1.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.SELFFEE.ToString());//账户支付
            //        clinicInvoiceDet1.Bas_paysumby_id = "301";
            //        clinicInvoiceDet1.Cheque = "";
            //        clinicInvoiceDetList.Add(clinicInvoiceDet1);
            //        ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();//非医保支付
            //        clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
            //        clinicInvoiceDet2.Payfee = yb[3].ToString();
            //        clinicInvoiceDet2.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
            //        clinicInvoiceDet2.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
            //        clinicInvoiceDet2.Cheque = "";
            //        clinicInvoiceDetList.Add(clinicInvoiceDet2);

            //        clinicInvoice.Insurefee = yb[2].ToString().Trim();
            //        clinicInvoice.Insuraccountfee = yb[0].ToString().Trim();
            //        clinicInvoice.Insurotherfee = "0.00";
            //        clinicInvoice.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
            //        clinicInvoice.Payfee = yb[3].ToString().Trim();
            //        clinicInvoice.Invoice_sql = bllRecipelCharge.doClinicInvoice(clinicInvoice, clinicInvoiceDetList);//收费发票
            //        this.tbxAccountAmt.Text = yb[1].ToString().Trim();//yb[1]账户余额
            //        this.tbxAccountFee.Text = yb[0].ToString().Trim();//yb[0] 账户支付
            //        this.tbxInsurFee.Text = yb[2].ToString().Trim();//yb[2]医保报销
            //        this.tbxRcvFee.Text = yb[3].ToString().Trim();//yb[3]现金支付
            //    }
            //}

            ////贵州省医保结算
            //if (patienttypeKeyname.ToUpper().Equals(CostInsurtypeKeyname.GZSYB.ToString().ToUpper().Trim()))
            //{
            //    string err_messgae = "";
            //    for (int i = 0; i < clinicInvoices.Count; i++)
            //    {
            //        ClinicInvoice clinicInvoice = clinicInvoices[i];
            //        List<ClinicInvoiceDet> clinicInvoiceDetList = new List<ClinicInvoiceDet>();
            //        Gzsybservice gzsybservice = new Gzsybservice();
            //        string info = "";
            //        string[] ybzf = new string[3];//ger tong fenzhongxin

            //        if (!gzsybservice.mzjs_kls(personInfo, ref info, clinicInvoice, ybzf))
            //        {
            //            MessageBox.Show("省医保门诊接口失败！,请及时撤销医保结算票据" + err_messgae);
            //            SysWriteLogs.writeLogs1("医保发票结算错误", DateTime.Now, err_messgae);
            //            return false;
            //        }
            //        err_messgae += "省医保结算号:[" + clinicInvoice.Id+"],";

            //        string insurtype = ybzf[2];
            //        string yblx = "2";  // : 省异地医保 
            //        clinicInvoice.Bas_patienttype1_id = "16";
            //        if (insurtype == "9900" || insurtype == "9907")
            //        {
            //            yblx = "1";//省医保
            //            clinicInvoice.Bas_patienttype1_id = "29";
            //        }
            //        else if (insurtype == "9908")
            //        {
            //            yblx = "3";//省老干
            //            clinicInvoice.Bas_patienttype1_id = "30";
            //        }
            //        amount += Convert.ToDouble(clinicInvoice.Realfee);
            //        insuraccountfee += Convert.ToDouble(ybzf[0]);// 账户支付
            //        insurefee += Convert.ToDouble(ybzf[1]);   //医保统筹报销
            //        string payfee = (DataTool.stringToDouble(clinicInvoice.Realfee) - DataTool.stringToDouble(ybzf[1]) - DataTool.stringToDouble(ybzf[0])).ToString("0.00");
            //        allpayfee += Convert.ToDouble(payfee);
            //        ClinicInvoiceDet clinicInvoiceDet = new ClinicInvoiceDet();
            //        clinicInvoiceDet.Clinic_invoice_id = clinicInvoice.Id;
            //        clinicInvoiceDet.Payfee = ybzf[1];
            //        clinicInvoiceDet.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());//统筹支付
            //        clinicInvoiceDet.Bas_paysumby_id = yblx;
            //        clinicInvoiceDet.Cheque = "";
            //        clinicInvoiceDetList.Add(clinicInvoiceDet);
            //        ClinicInvoiceDet clinicInvoiceDet1 = new ClinicInvoiceDet();
            //        clinicInvoiceDet1.Clinic_invoice_id = clinicInvoice.Id;
            //        clinicInvoiceDet1.Payfee = ybzf[0];
            //        clinicInvoiceDet1.Bas_paytype_id = bllRegister.getPaytypeId(BasPaytypeKeyname.SELFFEE.ToString());//账户支付
            //        clinicInvoiceDet1.Bas_paysumby_id = yblx;
            //        clinicInvoiceDet1.Cheque = "";
            //        clinicInvoiceDetList.Add(clinicInvoiceDet1);
            //        ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();//非医保支付
            //        clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
            //        clinicInvoiceDet2.Payfee = payfee;
            //        clinicInvoiceDet2.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
            //        clinicInvoiceDet2.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
            //        clinicInvoiceDet2.Cheque = "";
            //        clinicInvoiceDetList.Add(clinicInvoiceDet2);

            //        clinicInvoice.Insurefee = ybzf[1];
            //        clinicInvoice.Insuraccountfee = ybzf[0];
            //        clinicInvoice.Insurotherfee = "0.00";
            //        clinicInvoice.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
            //        clinicInvoice.Payfee = payfee;
            //        clinicInvoice.Invoice_sql = bllRecipelCharge.doClinicInvoice(clinicInvoice, clinicInvoiceDetList);//收费发票
            //    }
            //    //界面赋值
            //    tbxPayFee.Text = DataTool.FormatData(allpayfee.ToString(), "2");//收款金额
            //    tbxInsurFee.Text = DataTool.FormatData(insurefee.ToString(), "2");
            //    tbxAccountFee.Text = DataTool.FormatData(insuraccountfee.ToString(), "2");
            //    tbxRcvFee.Text = tbxPayFee.Text;
            //    tbxRcvFee.SelectAll();
            //    tbxRcvFee.Focus();
            //    //界面赋值_END

            //}
            //if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.GYSYB.ToString().ToUpper().Trim())
            //{
            //    Gysybservice gysyb = new Gysybservice();
            //    StringBuilder message = new StringBuilder(50);
            //    if (!gysyb.mzgh_kls(sybdk_entity, message))//
            //    {
            //        MessageBox.Show(message.ToString());
            //        return false;
            //    }
            //    double[] yb = new double[4];//个人账户支付 医保报销 商保起付线 商保支付
            //    //医保模拟结算
            //    //string clinic_costdet_ids = getSelectCostDet();
            //    string realfee = "";
            //    string clinic_costdet_ids = bllRecipelCharge.getCostdetId_RealFee(getCliniCostIds(), ref realfee);

            //    if (!gysyb.mzmnjs_kls2(sybdk_entity, clinic_costdet_ids, tbxInvoiceID.Text.Trim(), message, yb))
            //    {
            //        MessageBox.Show(message.ToString());
            //        return false;
            //    }
            //    string payfee = DataTool.FormatData((double.Parse(tbxAmount.Text.Trim()) - yb[0] - yb[1] - yb[3]).ToString(), "2");
            //    //界面赋值
            //    tbxInsurFee.Text = yb[1].ToString();//医保报销
            //    this.tbxPayFee.Text = payfee; //个人实际支付
            //    tbxSbpayline.Text = yb[2].ToString();//商保起付线
            //    tbxSbpay.Text = yb[3].ToString();//商保支付
            //    tbxAccountFee.Text = yb[0].ToString();//个人账户支付
            //    tbxRcvFee.Text = tbxPayFee.Text;
            //    tbxRcvFee.SelectAll();
            //    tbxRcvFee.Focus();
            //    //界面赋值_END
            //}
            #endregion
            return true;
        }

        /// <summary>
        /// 预结算
        /// </summary>
        private bool preAccount()
        {
            //门诊结算                   
            clinicAccount.Id = BillSysBase.nextId("clinic_account");
            clinicAccount.Billcode = BillSysBase.newBillcode("clinic_account_billcode");//结算单
            clinicAccount.Regist_id = dgvRegister.CurrentRow.Cells["id"].Value.ToString();

            clinicAccount.Settledep_id = ProgramGlobal.Depart_id;
            clinicAccount.Settledby = ProgramGlobal.User_id;
            clinicAccount.Settledate = BillSysBase.currDate();
            clinicAccount.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
            clinicInvoices.Clear();//多张发票



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
            //3.生成发票序列号。
            if (BillSysBase.currInvoiceB(ProgramGlobal.User_id, invoicekind, clinicInvoices) <= 0)
            {
                MessageBox.Show("发票已不足本次收费使用，请领取发票后，收费");
                return false;
            }
            double dPayFee = Double.Parse(tbxPayFee.Text);//应收费用

            if (dPayFee == 0)
            {
                MessageBox.Show("收费信息异常！,");
                return false;
            }
            if (!preClinicInvoice(clinicInvoices))
            {
                //bllRecipelCharge.doCancleInsurInvoice(clinicInvoices);//失败后处理医保信息
                return false;
            }
            return true;
        }

        private void groupBox_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 判断门诊收费按钮是否是结算状态
        /// </summary>
        public bool checkAccountStat()
        {
            if (this.btnCostCharged.Text.Trim().Equals("结算"))
            {
                if (this.patienttypeKeyname == CostInsurtypeKeyname.GZSYB.ToString().ToUpper())//168省医保 173异地
                {
                    MessageBox.Show("请点击结算按钮，完成当前患者收费再操作其他患者！");
                    return false;
                }
                btnCostCharged.Text = "收费";
                enableEdit();
            }
            return true;
        }
        /// <summary>
        /// 禁用编辑
        /// </summary>
        private void unableEdit()
        {
            cmbPatientType.Enabled = false;
            tbxHspcard.ReadOnly = true;
            btnSearch.Enabled = false;
            btnReset.Enabled = false;
            dgvRegister.Enabled = false;
            dgvClinicCost.Enabled = false;
            cbxAllcheck.Enabled = false;
        }
        /// <summary>
        /// 启用编辑
        /// </summary>
        private void enableEdit()
        {
            cmbPatientType.Enabled = true;
            tbxHspcard.ReadOnly = false;
            btnSearch.Enabled = true;
            btnReset.Enabled = true;
            dgvRegister.Enabled = true;
            dgvClinicCost.Enabled = true;
            cbxAllcheck.Enabled = true;
        }

        private void FrmClinicRcpCost_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!checkAccountStat())
            {
                e.Cancel = true;
                return;
            }
        }

        private void tbxAccountFee_TextChanged(object sender, EventArgs e)
        {
            if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.GYSYB.ToString().ToUpper().Trim())
            {
                double d_amount = DataTool.stringToDouble(tbxAmount.Text);
                double d_accountFee = DataTool.stringToDouble(tbxAccountFee.Text);
                double d_sbpay = DataTool.stringToDouble(tbxSbpay.Text);
                double d_insurFee = DataTool.stringToDouble(tbxInsurFee.Text);
                double d_accountAmt = DataTool.stringToDouble(tbxAccountAmt.Text);
                if (d_accountFee > d_accountAmt)
                {
                    d_accountFee = d_accountAmt;
                    tbxAccountFee.Text = d_accountFee.ToString("0.00");
                }
                double d_maxAccountFee = d_amount - d_sbpay - d_insurFee;
                if (d_accountFee > d_maxAccountFee)
                {
                    d_accountFee = d_maxAccountFee;
                    tbxAccountFee.Text = d_accountFee.ToString("0.00");
                }
                if (d_accountFee < 0)
                {
                    d_accountFee = 0;
                    tbxAccountFee.Text = "0";
                }

                string payfee = DataTool.FormatData((d_amount - d_accountFee - d_sbpay - d_insurFee).ToString(), "2");
                tbxPayFee.Text = payfee;
                tbxRcvFee.Text = payfee;
                tbxRcvFee.SelectAll();

            }
        }

        private void tbxPayFee_Click(object sender, EventArgs e)
        {
            Bjq.bjqts(tbxPayFee.Text + "J");
        }

        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbPayType.SelectedValue.ToString() == "1")//现金
                {
                    tbxRcvFee.Focus();
                    tbxRcvFee.SelectAll();
                }
            }
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
                //if (DataTool.st                //e) < DataTool.stringToDouble(tbxPayFee.Text.Trim()))
                //{
                //{
                //    gToDouble(tbxInsurFee.Text.Trim()) + DataTool.stringToDouble(tbxAccountFee.Text.Trim()) + DataTool.stringToDouble(rcvfee) - DataTool.stringToDouble(this.tbxPayFee.Text);
                //    this.tbx_QT                //    this.tbx_QT.Text = DataTool.FormatData(d_retfee2.ToString().Replace("-", ""), "2");
                //pe.                //if (cmbPayType.Text.Trim() == "现金")
                this.tbx_QT.ReadOnly = true;
                tbx_QT.Text = "0.00";
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

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadRegisterList();
            }
        }

        private void tbxAccountAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxInsurFee_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hspcard = reaInsurCardButtonClick();
            string startDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            DataTable dt = bllRecipelCharge.getRecipelInfo(tbxName.Text.Trim(), startDate, endDate, hspcard, cmbDepart.SelectedValue.ToString(), tbxRegBillcode.Text.Trim());
            dgvRegister.DataSource = dt;

            if (dt.Rows.Count <= 0)
            {
                loadClinicCostList();
                loadClinicCostDetail();
                freeSickInfo();
            }
        }
        /// <summary>
        /// 门诊卡读取信息
        /// </summary>
        private string reaInsurCardButtonClick()
        {
            string hspcard = "";
            Mifare dk = new Mifare();
            Member member = new Member();
            dk.OpenPoint();
            string fareuid = dk.FindCard();
            dk.ClosePoint();
            member.Mzfare = fareuid;
            member.Cardstat = MemberCardStat.YES.ToString();
            BillMember billMember = new BillMember();
            DataTable dt_hsp = billMember.memberSearch(member, "", "");
            if (dt_hsp.Rows.Count > 0)
            {
                this.tbxAccountAmt.Text = dt_hsp.Rows[0]["balance"].ToString();
                member_id = dt_hsp.Rows[0]["id"].ToString();

                hspcard = dt_hsp.Rows[0]["hspcard"].ToString();
            }
            else
            {
                MessageBox.Show("读取门诊卡失败！请重试。");
            }
            return hspcard;
        }
    }
}