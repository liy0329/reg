/*************************************************************************************
     * CLR版本：       2.0.50727.4927
     * 类 名 称：       FrmRegister
     * 机器名称：       wzw-PC
     * 命名空间：       MTHIS
     * 文 件 名：       FrmRegister
     * 创建时间：       2016/7/15 8:16:31
     * 作    者：       
     * 说    明：       门诊挂号窗体
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MTHIS.db;
using System.Windows.Forms;
using MTHIS.main.bll;
using MTREG.clinic.bll;
using MTREG.common;
using System.Text.RegularExpressions;
using MTREG.clinic.bo;
using MTREG.clinic;
using MTREG.tools;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.medinsur;
using MTREG.idcard.bll;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.gysyb.clinic;
using MTREG.medinsur.gysyb.bo;
using MTREG.medinsur.gysyb.bll;

using Apache.NMS;
using System.Runtime.InteropServices;
using MTREG.common.bll;
using MTREG.medinsur.gzsyb.Util;
using System.Threading;
using Apache.NMS.ActiveMQ;
using MTREG.medinsur.gzsyb.bo;
using MTREG.netpay;
using MTREG.netpay.bo;
using MTREG.medinsur.sjzsyb.bll;

namespace MTHIS.common
{
    public partial class FrmClinicReg : Form
    {
        /// <summary>
        /// 读身份证使用
        /// </summary>
        CardMsgs cardmsgs = new CardMsgs();
        private int nport;
        public int Nport
        {
            get { return nport; }
            set { nport = value; }
        }
        private bool falg;
        public bool Falg
        {
            get { return falg; }
            set { falg = value; }
        }

        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        Sybdk_Entity sybdk_entity = new Sybdk_Entity();//贵阳市医保
        PersonInfo personInfo = new PersonInfo();//贵州省医保        



        DataTable dtThisReg = new DataTable();
        DataTable dtThisDagn = new DataTable();


        /// <summary>
        /// 用于时间控件转移焦点
        /// </summary>
        int i = 0;


        string clinicroom = "";
        string clinicroom_id = "";

        string member_id = "";//会员表id
        string patienttypeKeyname = "";//患者类型
        string today = "";    //日期
        string invoicekind = "";
        string nextinvoicesql = "";//发票号sql

        string netpaytype = "-1";

        string clinic_cost_id = "";
        string register_id = "";
        string register_billcode = "";
        string registDate = "";
        string clinic_invoice_id = "";
        string clinic_costdet_ids = "";

        bool ischarge = false;//控制联动
        //贵州省医保 
        string gzsyblx = "";

        //贵州省医保_END
        //发票支付表

        BllClinicReg bllClinicReg = new BllClinicReg();
        BllBasDepart bllBasDepart = new BllBasDepart();
        BillClinicRcpCost billClinicRcpCost = new BillClinicRcpCost();

        public FrmClinicReg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRegister_Load(object sender, EventArgs e)
        {

            //加载医生坐诊列表
            initDgvVisit();
            //加载挂号列表
            initRegister();
            //页面元素初始数据 
            initFormInfo();
            //初始挂号数据
            initCostInfo();


        }

        //读取医保卡按钮事件
        private void readInsurCard_btn_Click(object sender, EventArgs e)
        {
            readInsurCard();//读医保卡

        }
        /// <summary>
        /// 读医保卡返回填值
        /// </summary>
        private void readInsurCard()
        {
            if (this.patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                return;
            }
            else if (this.patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GYSYB.ToString()))
            {
                try
                {

                    FrmClinicMedinsrGYSYB frmClinicMedinsrGYSYB = new FrmClinicMedinsrGYSYB();
                    frmClinicMedinsrGYSYB.StartPosition = FormStartPosition.CenterScreen;
                    frmClinicMedinsrGYSYB.ShowDialog(this);
                    this.sybdk_entity = frmClinicMedinsrGYSYB.Sybdk_entity;

                    if (!frmClinicMedinsrGYSYB.flag)
                    {
                        lblReadCardMsg.Text = "读卡失败！";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("医保信息初始化失败!");
                    return;
                }

                lblReadCardMsg.Text = "读卡成功！";
                //读卡后赋值
                tbxAccountAmt.Text = sybdk_entity.Zhye;
                tbxPatientName.Text = sybdk_entity.Xm;
                tbxIDCard.Text = sybdk_entity.Sfzhm;
                tbxCompanyName.Text = sybdk_entity.Dwmc;
                //读卡后赋值_END
                checkIdCard();
            }
            else if (this.patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GZSYB.ToString()))
            {
                bool flag = false;
                FrmClinMedinsurGZS frmClinMedinsurGZS = new FrmClinMedinsurGZS();
                frmClinMedinsurGZS.PatientType = this.cmbPatientType.SelectedValue.ToString();
                frmClinMedinsurGZS.StartPosition = FormStartPosition.CenterScreen;
                frmClinMedinsurGZS.ShowDialog(this);
                this.personInfo = frmClinMedinsurGZS.PersonInfo;
                flag = frmClinMedinsurGZS.Flag;
                if (flag == false)
                {
                    lblReadCardMsg.Text = "读卡失败！";

                }
                else if (flag == true)
                {
                    lblReadCardMsg.Text = "读卡成功！";
                    //读卡后赋值
                    tbxPatientName.Text = personInfo.Swxm;
                    tbxIDCard.Text = personInfo.Swsfzh;
                    dtpBirthday.Value = Convert.ToDateTime(personInfo.Swcsrq);
                    tbxAccountAmt.Text = personInfo.Swgrzhye;
                    tbxCompanyName.Text = personInfo.Swdwmc;

                    checkIdCard();
                }

            }

        }
        /// <summary>
        /// 科室变化处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepart_SelectedValueChanged(object sender, EventArgs e)
        {
            //科室下拉框修改后修改医生列表
            departChange();
        }

        /// <summary>
        /// //科室变化处理: 算法修改医生信息
        /// </summary>
        private void departChange()
        {
            if (cmbDepart.Items.Count <= 0)
            {
                return;
            }
            if (null != cmbDepart.SelectedValue)
            {
                String depart_id = cmbDepart.SelectedValue.ToString();
                bindComboxData(bllClinicReg.getDoctorByDepartId(depart_id), cmbDoctor);
            }
        }

        /// <summary>
        /// 患者类型选择处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPatientType_SelectedValueChanged(object sender, EventArgs e)
        {
            patientTypeChange();
        }

        /// <summary>
        /// 选择患者类处理：算法：患者类型变化后，释放预结算资源信息，结账信息重置默认状态
        /// </summary>
        private void patientTypeChange()
        {
            if (cmbPatientType.Items.Count <= 0)
                return;

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
            setAccountInfo(keyname);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void setAccountInfo(string keyname)
        {
            if (string.IsNullOrEmpty(patienttypeKeyname))
            {
                patienttypeKeyname = keyname;
                return;
            }

            //初始化页面信息
            cmbPayType.SelectedValue = 1;//支付类型默认为现金
            tbxPayFee.Text = tbxAmount.Text;//支付金额
            tbxRcvFee.Text = tbxPayFee.Text;//实收金额

            tbxAccountAmt.Text = "";//账户余额
            tbxInsurFee.Text = "";//报销
            tbxAccountFee.Text = "";//账户
            //tbxSbpay.Text = "";//商保
            //tbxSbpayline.Text = "";//商保起付线
            lblReadCardMsg.Text = "";//读卡信息
            //初始化发票信息
            patienttypeKeyname = keyname;
            btnCostCharged.Text = "收费";
        }
        /// <summary>
        /// 医生变化处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDoctor_TextChanged(object sender, EventArgs e)
        {
            doctorChange();
        }

        /// <summary>
        /// 选中医生后，计算挂号费诊查费等信息显示
        /// </summary>
        private void doctorChange()
        {
            tbxDagnfee.Text = "0";
            tbxRegfee.Text = "0";
            cmbDagn.SelectedValue = 0;
            cmbReg.SelectedValue = 0;
            if (cmbDoctor.Items.Count <= 0)
            {
                return;
            }
            if (null != cmbDepart.SelectedValue && !cmbDoctor.SelectedIndex.Equals(0) && !cmbDoctor.SelectedIndex.Equals(-1))
            {
                String doctor_id = cmbDoctor.SelectedValue.ToString();
                DataTable dt = bllClinicReg.getPrcByDoctor(doctor_id);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["keyname"].ToString() == "REG")
                    {
                        cmbReg.SelectedValue = dt.Rows[i]["item_id"].ToString();
                        tbxRegfee.Text = dt.Rows[i]["prc"].ToString();
                        if (tbxRegfee.Text == "")
                        {
                            tbxRegfee.Text = "0";
                        }
                        dtThisReg = bllClinicReg.getItemInfo(cmbReg.SelectedValue.ToString());
                    }
                    else if (dt.Rows[i]["keyname"].ToString() == "DIGN")
                    {
                        cmbDagn.SelectedValue = dt.Rows[i]["item_id"].ToString();
                        tbxDagnfee.Text = dt.Rows[i]["prc"].ToString();
                        if (tbxDagnfee.Text == "")
                        {
                            tbxDagnfee.Text = "0";
                        }
                        dtThisDagn = bllClinicReg.getItemInfo(cmbDagn.SelectedValue.ToString());
                    }
                }
                cmbReg.SelectedValue = "96653";
                //定位医生所在诊室
                DataTable dt2 = bllClinicReg.getCurrClinicRoom(doctor_id);
                if (dt2 != null && dt2.Rows.Count >= 1)
                {
                    clinicroom = dt2.Rows[0]["clinicroom"].ToString();
                    clinicroom_id = dt2.Rows[0]["clinicroom_id"].ToString();
                }
                else
                {
                    clinicroom = "";
                    clinicroom_id = "0";
                }
            }



            double totalAmount = DataTool.stringToDouble(tbxRegfee.Text) + DataTool.stringToDouble(tbxDagnfee.Text);
            tbxAmount.Text = totalAmount.ToString("0.00"); //选择后 三个费用相同
            tbxPayFee.Text = tbxAmount.Text;
            tbxRcvFee.Text = tbxAmount.Text;
            tbxRcvFee.SelectAll();
            tbxRetFee.Text = "0.00";

        }

        /// <summary>
        ///   //加载门诊坐诊信息
        /// </summary>
        private void initDgvVisit()
        {
            //初始化左侧当前挂号信息
            dgvVisit.DataSource = bllClinicReg.getRegisterInfo();
            #region updateHeaderText
            dgvVisit.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), (FontStyle.Bold));
            this.dgvVisit.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), (FontStyle.Bold));
            dgvVisit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVisit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisit.Columns["doctor_id"].Visible = false;
            dgvVisit.Columns["depart_id"].Visible = false;
            dgvVisit.Columns["diagnlen"].Visible = false;
            dgvVisit.Columns["reg_level_id"].Visible = false;
            dgvVisit.Columns["doctor"].HeaderText = "医生";
            dgvVisit.Columns["doctor"].DisplayIndex = 0;
            dgvVisit.Columns["doctor"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvVisit.Columns["clinicroom"].HeaderText = "诊室";
            dgvVisit.Columns["clinicroom"].DisplayIndex = 1;
            dgvVisit.Columns["clinicroom"].Width = (int)(160 * ProgramGlobal.WidthScale);
            dgvVisit.Columns["waitnum"].HeaderText = "候诊人数";
            dgvVisit.Columns["waitnum"].DisplayIndex = 2;
            dgvVisit.Columns["waitnum"].Width = (int)(80 * ProgramGlobal.WidthScale);
            dgvVisit.Columns["waitnum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVisit.Columns["reglevel"].HeaderText = "级别";
            dgvVisit.Columns["reglevel"].DisplayIndex = 3;
            dgvVisit.Columns["reglevel"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvVisit.Columns["regprc"].HeaderText = "金额";
            dgvVisit.Columns["regprc"].DisplayIndex = 4;
            dgvVisit.Columns["regprc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVisit.Columns["regprc"].Width = (int)(75 * ProgramGlobal.WidthScale);
            dgvVisit.Columns["waitlen"].HeaderText = "等待时间";
            dgvVisit.Columns["waitlen"].DisplayIndex = 5;
            dgvVisit.Columns["waitlen"].Width = (int)(120 * ProgramGlobal.WidthScale);
            dgvVisit.Columns["depart"].HeaderText = "科室";
            dgvVisit.Columns["depart"].DisplayIndex = 6;
            dgvVisit.Columns["depart"].Width = (int)(90 * ProgramGlobal.WidthScale);
            #endregion

            doctorChange();

        }

        /// <summary>
        /// //初始化下拉框数据
        /// </summary>
        private void initFormInfo()
        {
            invoicekind = bllClinicReg.getInvoiceKind();
            DataTable dtDagn = bllClinicReg.getDagn();//诊查费
            var drDagn = dtDagn.NewRow();
            drDagn["id"] = 0;
            drDagn["name"] = "";
            dtDagn.Rows.InsertAt(drDagn, 0);
            cmbDagn.DisplayMember = "name";
            cmbDagn.ValueMember = "id";
            cmbDagn.DataSource = dtDagn;

            DataTable dtReg = bllClinicReg.getReg(); //挂号费
            var drReg = dtReg.NewRow();
            drReg["id"] = 0;
            drReg["name"] = "";
            dtReg.Rows.InsertAt(drReg, 0);
            cmbReg.DisplayMember = "name";
            cmbReg.ValueMember = "id";
            cmbReg.DataSource = dtReg;

            //民族
            DataTable dtrace = bllClinicReg.getRaceInfo(cmbRace.Text.Trim());
            if (dtrace.Rows.Count > 0)
            {
                this.cmbRace.DisplayMember = "name";
                this.cmbRace.ValueMember = "id";
                this.cmbRace.DataSource = dtrace;
                this.cmbRace.SelectedValue = 1;
            }

            //支付类型的初始化
            DataTable dtpt = bllClinicReg.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtpt;
                this.cmbPayType.SelectedValue = 1;
            }

            //省地址初始化
            DataTable province = bllClinicReg.provinceList("");
            var provincePay = province.NewRow();
            provincePay["id"] = 0;
            provincePay["name"] = "-请选择-";
            province.Rows.InsertAt(provincePay, 0);
            cmbProvince.DataSource = province;
            cmbProvince.ValueMember = "id";
            cmbProvince.DisplayMember = "name";
            cmbProvince.SelectedValue = "130000";


            //患者类型的初始化
            var dtp = bllClinicReg.getPatientTypeInfo();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;

            //科室

            bindComboxData(bllClinicReg.getDepartInfo(""), cmbDepart);
            //医生
            cmbDoctor.Text = "--请选择--";
            //急诊
            var dtu = bllClinicReg.getUrgent();
            this.cmbUrgent.ValueMember = "Id";
            this.cmbUrgent.DisplayMember = "Name";
            this.cmbUrgent.DataSource = dtu;
            cmbUrgent.SelectedValue = "2";
            //年龄单位
            DataTable dtunit = bllClinicReg.ageunitList();
            if (dtunit.Rows.Count > 0)
            {
                this.cmbAgesUnit.DisplayMember = "name";
                this.cmbAgesUnit.ValueMember = "id";
                this.cmbAgesUnit.DataSource = dtunit;
                this.cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
            }
            DataTable dtMonth = bllClinicReg.ageunitList();
            if (dtMonth.Rows.Count > 0)
            {
                this.cmbMonth.DisplayMember = "name";
                this.cmbMonth.ValueMember = "id";
                this.cmbMonth.DataSource = dtMonth;
                this.cmbMonth.SelectedValue = (int)AgeUnit.MOON;
                this.cmbMonth.Enabled = false;
            }
            //性别
            List<ListItem2> sexUnit = new List<ListItem2>();
            sexUnit.Add(new ListItem2("M", "男"));
            sexUnit.Add(new ListItem2("W", "女"));
            this.cmbSex.DisplayMember = "name";
            this.cmbSex.ValueMember = "value";
            this.cmbSex.DataSource = sexUnit;
            this.cmbSex.SelectedIndex = 0;

            //职业
            bindComboxData(bllClinicReg.professionList(""), cmbProfession);

            DateTime dt = DateTime.Parse(BillSysBase.currDate());
            today = dt.ToString("yyyy-MM-dd") + " 00:00:00";
            tbxPayFee.Enabled = false;

        }
        /// <summary>
        /// 下拉选择框绑定数据库数据函数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="comObject"></param>
        private void bindComboxData(DataTable dt, ComboBox comObject)
        {
            if (dt.ToString() == "")
            {
                dt.Columns.Add("name", Type.GetType("System.String"));
                dt.Columns.Add("id", Type.GetType("System.String"));
            }
            comObject.DisplayMember = "name";
            comObject.ValueMember = "id";
            try
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "--请选择--";
                dr["id"] = 0;
                dt.Rows.InsertAt(dr, 0);
                comObject.DataSource = dt;
                comObject.SelectedValue = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 加载挂号列表
        /// </summary>
        public void initRegister()
        {

            dgvRegistItem.DataSource = bllClinicReg.getRegisterById(today);//根据医院卡号查询挂号信息
            #region updateHeaderText
            dgvRegistItem.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), (System.Drawing.FontStyle.Bold));
            this.dgvRegistItem.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), (FontStyle.Bold));
            dgvRegistItem.Columns["id"].Visible = false;
            dgvRegistItem.Columns["status"].HeaderText = "状态";
            dgvRegistItem.Columns["status"].DisplayIndex = 0;
            dgvRegistItem.Columns["status"].Width = (int)(130 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["regdate"].HeaderText = "挂号时间";
            dgvRegistItem.Columns["regdate"].DisplayIndex = 1;
            dgvRegistItem.Columns["regdate"].Width = (int)(150 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["name"].HeaderText = "姓名";
            dgvRegistItem.Columns["name"].DisplayIndex = 2;
            dgvRegistItem.Columns["name"].Width = (int)(100 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["sex"].HeaderText = "性别";
            dgvRegistItem.Columns["sex"].DisplayIndex = 3;
            dgvRegistItem.Columns["sex"].Width = (int)(50 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["patienttype"].HeaderText = "患者类型";
            dgvRegistItem.Columns["patienttype"].DisplayIndex = 4;
            dgvRegistItem.Columns["patienttype"].Width = (int)(130 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["dptname"].HeaderText = "科室";
            dgvRegistItem.Columns["dptname"].DisplayIndex = 5;
            dgvRegistItem.Columns["dptname"].Width = (int)(110 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["dctname"].HeaderText = "医生";
            dgvRegistItem.Columns["dctname"].DisplayIndex = 6;
            dgvRegistItem.Columns["dctname"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["amount"].HeaderText = "金额";
            dgvRegistItem.Columns["amount"].DisplayIndex = 7;
            dgvRegistItem.Columns["amount"].Width = (int)(100 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRegistItem.Columns["username"].HeaderText = "挂号者";
            dgvRegistItem.Columns["username"].DisplayIndex = 8;
            dgvRegistItem.Columns["username"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["hspcard"].HeaderText = "卡号";
            dgvRegistItem.Columns["hspcard"].DisplayIndex = 9;
            dgvRegistItem.Columns["hspcard"].Width = (int)(140 * ProgramGlobal.WidthScale);
            #endregion
        }

        # region 身份证初始化
        private Thread thread;
        #region 关闭线程方法

        /// <summary>
        /// 关闭线程方法
        /// ReWriter:qinYangYang 2014-4-7
        /// </summary>
        /// <param name="param"></param>
        public void CloseSFZXC(object param)
        {
            try
            {
                thread.Abort();
            }
            catch (Exception ex)
            {
                //关闭线程
            }
        }

        #endregion
        #region 开启线程方法

        /// <summary>
        /// 开启线程方法 读身份信息
        /// ReWriter:qinYangYang 2014-4-6
        /// </summary>
        /// <param name="param"></param>
        public static void StartSFZXC(object param)
        {

            CustomWindowsMessages cwm = new CustomWindowsMessages();
            CardMsgs carmsg = new CardMsgs();
            int iPort = 0;
            while (true)
            {
                if (cwm.SendMessageInfo(ref iPort))
                {
                    break;
                }
                SysWriteLogs.SleepTimes(1200);
            }

        }

        #endregion
        #region 初始化身份证信息

        /// <summary>
        ///  初始化身份证信息
        ///  Writer:qinYangYang 2014/4/8
        /// </summary>
        public void initidCardInfo()
        {
            this.btnReadIDCard.Enabled = true;
            this.tbxPatientName.Text = "";//姓名
            cmbSex.Text = "";//性别
            this.dtpBirthday.Value = Convert.ToDateTime(BillSysBase.currDate().ToString());//出生日期;        
            tbxIDCard.Text = "";//身份证号
        }
        #endregion
        #region
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
        #endregion
        //读取身份证信息按钮事件
        private void readIDCard_btn_Click(object sender, EventArgs e)
        {
            initidCardInfo();
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
                        this.tbxPatientName.Text = CardMsg.Name.ToString();

                        //性别
                        string sex = (CardMsg.Sex == "男") ? "M" : "W";
                        cmbSex.Text = CardMsg.Sex;

                        //民族
                        this.cmbRace.Text = CardMsg.Nation ;

                        //出生日期
                        DateTime time = Convert.ToDateTime(CardMsg.Born);
                        this.dtpBirthday.Value = time;
                        //this.dtpBirthday.Value = Convert.ToDateTime(date);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  地址:" + CardMsg.Address;
                        //listBox1.Items.Add(stmp);
                        ////地址
                        int s = CardMsg.Address.Length;
                        cmbProvince.Text = CardMsg.Address.Substring(0, 3);
                        cmbCity.Text = CardMsg.Address.Substring(3, 3);
                        cmbCounty.Text = CardMsg.Address.Substring(6, 3);
                        tbxHmhouseNumber.Text = CardMsg.Address.Substring(9, s - 10);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  身份证号:" + CardMsg.IDCardNo;
                        //listBox1.Items.Add(stmp);
                        ////身份证号
                        this.tbxIDCard.Text = CardMsg.IDCardNo;

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
            CloseSFZXC(null);
        }
        /// <summary>
        /// 测试读身份证
        /// </summary>
        private void readIdCardButtonClick()
        {
            IdCardInfo idCardInfo = new IdCardInfo();
            idCardInfo.readInsurCard();
            tbxPatientName.Text = idCardInfo.Name;
            tbxIDCard.Text = idCardInfo.Idcard;
            tbxHmhouseNumber.Text = idCardInfo.Homeaddress;
            dtpBirthday.Value = Convert.ToDateTime(idCardInfo.Birth);
            cmbSex.Text = idCardInfo.Sex;
            cmbSex.SelectedValue = idCardInfo.Sex;
            tbxIDCard.Text = idCardInfo.Idcard;
        }
        /// <summary>
        /// 实收金额变化处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxRcvFee_TextChanged(object sender, EventArgs e)
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
                double d_retfee = DataTool.stringToDouble(rcvfee) - DataTool.stringToDouble(this.tbxPayFee.Text);
                tbxRetFee.Text = DataTool.FormatData(d_retfee.ToString(), "2");
            }
            catch (SystemException)
            {
                MessageBox.Show("实收金额输入有误，请重新输入！");
            }
        }
        /// <summary>
        ///  预结算
        /// </summary>
        /// <returns></returns>
        private bool preAccount()
        {
            string merge_sql = "";
            if (cmbReg.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("请选择挂号费！", "提示");
                cmbReg.Focus();
                this.cmbReg.DroppedDown = true;
                return false;
            }

            if (tbxPatientName.Text == "")
            {
                MessageBox.Show("患者姓名不能为空！", "提示");
                tbxPatientName.Focus();
                return false;
            }
            if ((tbxPhoneNum.Text != null || tbxPhoneNum.Text != "") && tbxPhoneNum.Text.Substring(0,1).ToUpper() != "X")
            {
                if (!Regex.IsMatch(tbxPhoneNum.Text, @"^[1]+[3,5,8,4]+\d{9}") && !string.IsNullOrEmpty(tbxPhoneNum.Text))
                {
                    MessageBox.Show("手机号格式不正确！", "提示");
                    tbxPhoneNum.Focus();
                    return false;
                }
            }

            if (cmbDoctor.SelectedIndex == -1 || cmbDoctor.SelectedIndex == 0)
            {
                MessageBox.Show("医生不能为空！", "提示");
                cmbDoctor.Focus();
                return false;
            }
            if (cmbDepart.SelectedValue.ToString() == "")
            {
                MessageBox.Show("科室不能为空！", "提示");
                cmbDepart.Focus();
                return false;
            }
            if (cmbPatientType.SelectedValue.Equals(0))
            {
                MessageBox.Show("患者类型不能为空！", "提示");
                cmbPatientType.Focus();
                return false;
            }
            if (cmbCounty.SelectedValue.ToString() == "0" && cmbProvince.SelectedValue.ToString() != "0")
            {
                MessageBox.Show("请选择县级地址！", "提示");
                cmbCounty.Focus();
                return false;
            }
            string idcard = this.tbxIDCard.Text.Trim();                 //身份证号
            Regex reg18 = new Regex(@"^([1-9]{1}\d{5}[1-2]{1}[09]{1}\d{2}(([0]{1}[1-9]{1})|([1]{1}[012]{1}))(([0]{1}[1-9]{1})|([12]{1}\d{1})|([3]{1}[01]{1}))(\d{4}|(\d{3}[x]{1})|(\d{3}[X]{1})))$");
            //身份证判断
            if (!string.IsNullOrEmpty(idcard))
            {
                if (!reg18.IsMatch(idcard))
                {
                    MessageBox.Show("身份证号位数不够或者有其他字符！", "提示");
                    this.tbxIDCard.Focus();
                    return false;
                }
                if (!idCardEcho())
                    return false;
            }

            if (string.IsNullOrEmpty(tbxAge.Text) || tbxAge.Text == "0")
            {
                MessageBox.Show("年龄不能为空或'0'!", "提示");
                this.tbxAge.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(register_id))
            {
                register_id = BillSysBase.nextId("register");
                register_billcode = BillSysBase.newBillcode("register_billcode");
                registDate = BillSysBase.currDate();

            }
            clinic_invoice_id = BillSysBase.nextId("clinic_invoice");
            if (string.IsNullOrEmpty(clinic_cost_id))
            {//收费主表

                //初始化序列
                clinic_cost_id = BillSysBase.nextId("clinic_cost");
                clinic_costdet_ids = "";
                //初始化序列_END

                ClinicCost clinicCost = new ClinicCost();
                clinicCost.Id = clinic_cost_id;
                clinicCost.Regist_id = register_id;
                clinicCost.Billcode = register_billcode;
                clinicCost.Clinic_rcp_id = "0";
                clinicCost.Executed = "N";
                clinicCost.Depart_id = cmbDepart.SelectedValue.ToString();
                clinicCost.Doctor_id = cmbDoctor.SelectedValue.ToString();
                clinicCost.Rcpdate = registDate;
                clinicCost.Recipelfee = tbxAmount.Text.Trim().ToString();
                clinicCost.Realfee = tbxAmount.Text.Trim().ToString();
                clinicCost.Unlocked = "N";
                clinicCost.Retappstat = "N";
                clinicCost.Rcptype = CostRcpType.REG.ToString();
                bllClinicReg.addClinicCost(clinicCost, ref merge_sql);
                //收费明细表
                CliniCostdet cliniCostdet = new CliniCostdet();
                cliniCostdet.Clinic_cost_id = clinicCost.Id;
                cliniCostdet.Regist_id = register_id;
                cliniCostdet.Clinic_rcpdetail_id = "0";
                cliniCostdet.Depart_id = cmbDepart.SelectedValue.ToString();
                cliniCostdet.Doctor_id = cmbDoctor.SelectedValue.ToString();
                cliniCostdet.Exedep_id = cmbDepart.SelectedValue.ToString();
                cliniCostdet.Packsole = "N";
                cliniCostdet.Drug_packsole_id = "0";
                cliniCostdet.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();

                if (cmbReg.SelectedValue.ToString() != "0")
                {
                    cliniCostdet.Id = BillSysBase.nextId("clinic_costdet");
                    cliniCostdet.Prc = tbxRegfee.Text;
                    cliniCostdet.Fee = cliniCostdet.Prc;
                    cliniCostdet.Discnt = "1";
                    cliniCostdet.Realfee = cliniCostdet.Fee;
                    cliniCostdet.Standcode = dtThisReg.Rows[0]["standcode"].ToString();
                    cliniCostdet.Item_id = dtThisReg.Rows[0]["item_id"].ToString();
                    cliniCostdet.Itemfrom = "COST";
                    cliniCostdet.Name = cmbReg.Text;
                    cliniCostdet.Unit = dtThisReg.Rows[0]["unit"].ToString();
                    cliniCostdet.Num = "1";
                    cliniCostdet.Itemtype_id = dtThisReg.Rows[0]["itemtype_id"].ToString();
                    cliniCostdet.Itemtype1_id = dtThisReg.Rows[0]["itemtype1_id"].ToString();
                    cliniCostdet.Rcptype = "REG";
                    bllClinicReg.addClinicCostDet(cliniCostdet, ref clinic_costdet_ids, ref merge_sql);
                }

                if (cmbDagn.SelectedValue.ToString() != "0")
                {

                    cliniCostdet.Id = BillSysBase.nextId("clinic_costdet");
                    cliniCostdet.Prc = tbxDagnfee.Text;
                    cliniCostdet.Fee = cliniCostdet.Prc;
                    cliniCostdet.Discnt = "1";
                    cliniCostdet.Realfee = cliniCostdet.Fee;
                    cliniCostdet.Standcode = dtThisDagn.Rows[0]["standcode"].ToString();
                    cliniCostdet.Item_id = dtThisDagn.Rows[0]["item_id"].ToString();
                    cliniCostdet.Itemfrom = "COST";
                    cliniCostdet.Name = cmbDagn.Text;
                    cliniCostdet.Unit = dtThisDagn.Rows[0]["unit"].ToString();
                    cliniCostdet.Num = "1";
                    cliniCostdet.Itemtype_id = dtThisDagn.Rows[0]["itemtype_id"].ToString();
                    cliniCostdet.Itemtype1_id = dtThisDagn.Rows[0]["itemtype1_id"].ToString();
                    cliniCostdet.Rcptype = "REG";
                    bllClinicReg.addClinicCostDet(cliniCostdet, ref clinic_costdet_ids, ref merge_sql);
                }

                if (clinic_costdet_ids != "")
                {
                    clinic_costdet_ids = clinic_costdet_ids.Substring(0, clinic_costdet_ids.Length - 1);
                }
                if (bllClinicReg.ExeSql(merge_sql) < 0)
                {
                    clinic_cost_id = ""; //费用插入失败 赋空值
                    MessageBox.Show("挂号初始化费用失败！");
                    return false;
                }
            }
            if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.GYSYB.ToString().ToUpper())
            {
                Gysybservice gysyb = new Gysybservice();
                StringBuilder message = new StringBuilder(250);
                if (!gysyb.mzgh_kls(sybdk_entity, message))
                {
                    return false;
                }
                double[] yb = new double[4];//个人账户支付  医保支付  商报起付线 商报支付
                //医保模拟结算
                if (!gysyb.mzmnjs_kls2(sybdk_entity, clinic_costdet_ids, tbxInvoiceID.Text.Trim(), message, yb))
                {
                    MessageBox.Show(message.ToString());
                    return false;
                }
                //应收金额
                tbxPayFee.Text = DataTool.FormatData((DataTool.stringToDouble(tbxAmount.Text.Trim()) - yb[0] - yb[1] - yb[3]).ToString(), "2");

                //报销金额
                tbxInsurFee.Text = (yb[1] + yb[3]).ToString();
                //个人账户支付
                tbxAccountFee.Text = yb[0].ToString();
                //实收金额 = 应收金额 且全不选择，获取焦点
                tbxRcvFee.Text = tbxPayFee.Text;
                tbxRcvFee.Focus();
                tbxRcvFee.SelectAll();


            }
            else if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.GZSYB.ToString().ToUpper().Trim())
            {
                Gzsybservice gzsybservice = new Gzsybservice();
                string info = "";
                string[] yb = new string[3];//账户支付 统筹支付  分中心编码

                ClinicInvoice clinicInvoice = new ClinicInvoice();
                clinicInvoice.Invoice = this.tbxInvoiceID.Text;
                clinicInvoice.Id = clinic_invoice_id;
                clinicInvoice.Clinic_costdet_ids = clinic_costdet_ids;
                clinicInvoice.Chargedate = registDate;
                //调用预结算

                if (!gzsybservice.mzjs_kls(personInfo, ref info, clinicInvoice, yb))
                {
                    MessageBox.Show(info);
                    return false;
                }

                //结算赋值
                string insurtype = yb[2];
                string amount = tbxAmount.Text;
                string Insuraccountfee = yb[0];//账户支付
                string insurefee = yb[1];//医保报销

                string payFee = (DataTool.stringToDouble(amount) - DataTool.stringToDouble(insurefee) - DataTool.stringToDouble(Insuraccountfee)).ToString();

                //界面赋值
                tbxPayFee.Text = DataTool.FormatData(payFee, "2");//收款金额
                tbxInsurFee.Text = insurefee;
                tbxAccountFee.Text = Insuraccountfee;
                tbxRcvFee.Text = tbxPayFee.Text;
                tbxRcvFee.SelectAll();
                tbxRcvFee.Focus();

                gzsyblx = "2";  // bas_paysumby表中的id   //默认异地医保 
                if (insurtype == "9900" || insurtype == "9907")
                {
                    gzsyblx = "1";//省直医保
                }
                else if (insurtype == "9908")
                {
                    gzsyblx = "3";//省老干
                }
            }

            return true;
        }


        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="account_id"></param>
        private bool doAccount()
        {

            string currDate = BillSysBase.currDate();



            //网络支付业务:
            string hisOrderNo = "";
            if (!doExecNetPay(currDate, ref hisOrderNo))
                return false;
            //网络支付业务_END:
            //门诊发票
            ClinicInvoice clinicInvoice = new ClinicInvoice();
            clinicInvoice.Id = clinic_invoice_id;
            clinicInvoice.Regist_id = register_id;
            clinicInvoice.Sickname = tbxPatientName.Text;
            clinicInvoice.Rcpdep_id = cmbDepart.SelectedValue.ToString();
            clinicInvoice.Exedep_id = clinicInvoice.Rcpdep_id;
            clinicInvoice.Rcpdoctor_id = cmbDoctor.SelectedValue.ToString();
            clinicInvoice.Fee = tbxAmount.Text.Trim();
            clinicInvoice.Discnt = "1";
            clinicInvoice.Realfee = (double.Parse(tbxAmount.Text.Trim().ToString()) * double.Parse(clinicInvoice.Discnt)).ToString();
            clinicInvoice.Bas_patienttype_id = cmbPatientType.SelectedValue.ToString();
            clinicInvoice.Bas_patienttype1_id = clinicInvoice.Bas_patienttype_id;
            ///支付
            clinicInvoice.Payfee = this.tbxPayFee.Text;
            clinicInvoice.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
            clinicInvoice.HisOrderNo = hisOrderNo;
            //支付_END
            clinicInvoice.Invoice = this.tbxInvoiceID.Text;//发票号
            clinicInvoice.Nextinvoicesql = nextinvoicesql;
            clinicInvoice.Depart_id = ProgramGlobal.Depart_id;
            clinicInvoice.Chargedate = currDate;
            clinicInvoice.Chargeby = ProgramGlobal.User_id;//收费人
            clinicInvoice.Charged = CostCharged.CHAR.ToString();
            clinicInvoice.Netpay_store_id = "1";
            if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                clinicInvoice.Insurstat = "";
            }
            else
            {
                clinicInvoice.Insurstat = Insurstat.SETT.ToString();
            }
            clinicInvoice.Clinic_cost_ids = clinic_cost_id;
            clinicInvoice.Clinic_costdet_ids = clinic_costdet_ids;

            //结算参数
            string insurtype = "";
            string insurefee = this.tbxInsurFee.Text;
            string insureOtherfee = "";
            string Insuraccountfee = this.tbxAccountFee.Text;
            string payfee = tbxPayFee.Text;
            string regist_sql = "";
            //结算参数_END

            List<ClinicInvoiceDet> clinicInvoiceDetList = new List<ClinicInvoiceDet>();



            //自费
            if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.SELFCOST.ToString())
            {

                ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();
                clinicInvoiceDet2.Payfee = tbxPayFee.Text;
                clinicInvoiceDet2.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                clinicInvoiceDet2.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
                clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
                clinicInvoiceDet2.Cheque = "";
                clinicInvoiceDetList.Add(clinicInvoiceDet2);

            }
            //贵州省医保结算
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GZSYB.ToString().ToUpper().Trim()))
            {
                ClinicInvoiceDet clinicInvoiceDet = new ClinicInvoiceDet();
                clinicInvoiceDet.Payfee = DataTool.stringToDouble(tbxInsurFee.Text).ToString();
                clinicInvoiceDet.Bas_paytype_id = bllClinicReg.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());//统筹支付
                clinicInvoiceDet.Bas_paysumby_id = gzsyblx;
                clinicInvoiceDet.Clinic_invoice_id = clinicInvoice.Id;
                clinicInvoiceDet.Cheque = "";
                clinicInvoiceDetList.Add(clinicInvoiceDet);
                ClinicInvoiceDet clinicInvoiceDet1 = new ClinicInvoiceDet();
                clinicInvoiceDet1.Payfee = DataTool.stringToDouble(tbxAccountFee.Text).ToString();
                clinicInvoiceDet1.Bas_paytype_id = bllClinicReg.getPaytypeId(BasPaytypeKeyname.SELFFEE.ToString());//账户支付
                clinicInvoiceDet1.Bas_paysumby_id = gzsyblx;
                clinicInvoiceDet1.Clinic_invoice_id = clinicInvoice.Id;
                clinicInvoiceDet1.Cheque = "";
                ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();
                clinicInvoiceDet2.Payfee = tbxPayFee.Text;
                clinicInvoiceDet2.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                clinicInvoiceDet2.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
                clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
                clinicInvoiceDet2.Cheque = "";
                clinicInvoiceDetList.Add(clinicInvoiceDet2);

                if (gzsyblx == "2")
                {
                    //异地医保
                    clinicInvoice.Bas_patienttype1_id = "16";
                }
                else if (gzsyblx == "1")
                {
                    //省直医保
                    clinicInvoice.Bas_patienttype1_id = "29";
                }
                else if (gzsyblx == "3")
                {
                    //省老干
                    clinicInvoice.Bas_patienttype1_id = "30";
                }
            }
            //市医保
            else if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.GYSYB.ToString().ToUpper().Trim())
            {
                Gysybservice gysyb = new Gysybservice();
                StringBuilder message = new StringBuilder(50);
                string[] yb = new string[5];//账户 统筹 商保起伏线 商保支付 分中心编码
                string amount = clinicInvoice.Fee;
                string once_zhzf = tbxAccountFee.Text;
                sybdk_entity.Invoice_id = clinic_invoice_id;
                sybdk_entity.Fph = clinicInvoice.Invoice;
                if (!gysyb.mzzsjs_kls(sybdk_entity, clinicInvoice, ref once_zhzf, yb, message))
                {
                    MessageBox.Show("挂号时医保结算失败！,用网络支付病人请及时撤退金额");
                    return false;
                }

                insurefee = DataTool.stringToDouble(yb[1]).ToString();
                insureOtherfee = DataTool.stringToDouble(yb[3]).ToString();
                Insuraccountfee = yb[0];
                payfee = (DataTool.stringToDouble(amount) - DataTool.stringToDouble(insurefee) - DataTool.stringToDouble(Insuraccountfee) - DataTool.stringToDouble(yb[3])).ToString();
                insurtype = yb[4];
                string sbzf = yb[3];
                clinicInvoiceDetList.Clear();//清空发票支付表
                //填入发票支付信息
                ClinicInvoiceDet clinicInvoiceDet = new ClinicInvoiceDet();
                clinicInvoiceDet.Payfee = DataTool.stringToDouble(yb[1]).ToString();
                clinicInvoiceDet.Bas_paytype_id = bllClinicReg.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());//统筹支付
                clinicInvoiceDet.Bas_paysumby_id = "4";
                clinicInvoiceDet.Clinic_invoice_id = clinicInvoice.Id;
                clinicInvoiceDet.Cheque = "";
                clinicInvoiceDetList.Add(clinicInvoiceDet);
                ClinicInvoiceDet clinicInvoiceDet2 = new ClinicInvoiceDet();
                clinicInvoiceDet2.Payfee = DataTool.stringToDouble(Insuraccountfee).ToString();
                clinicInvoiceDet2.Bas_paytype_id = bllClinicReg.getPaytypeId(BasPaytypeKeyname.SELFFEE.ToString());//账户支付
                clinicInvoiceDet2.Bas_paysumby_id = "4";
                clinicInvoiceDet2.Clinic_invoice_id = clinicInvoice.Id;
                clinicInvoiceDet2.Cheque = "";
                clinicInvoiceDetList.Add(clinicInvoiceDet2);
                ClinicInvoiceDet clinicInvoiceDet3 = new ClinicInvoiceDet();
                clinicInvoiceDet3.Payfee = DataTool.stringToDouble(sbzf).ToString();
                clinicInvoiceDet3.Bas_paytype_id = bllClinicReg.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());
                clinicInvoiceDet3.Bas_paysumby_id = "5";//商保
                clinicInvoiceDet3.Clinic_invoice_id = clinicInvoice.Id;
                clinicInvoiceDet3.Cheque = "";
                clinicInvoiceDetList.Add(clinicInvoiceDet3);
                ClinicInvoiceDet clinicInvoiceDet4 = new ClinicInvoiceDet();
                clinicInvoiceDet4.Payfee = payfee;
                clinicInvoiceDet4.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
                clinicInvoiceDet4.Bas_paysumby_id = bllClinicReg.getPaysumbyFor(cmbPayType.SelectedValue.ToString());
                clinicInvoiceDet4.Clinic_invoice_id = clinicInvoice.Id;
                clinicInvoiceDet4.Cheque = "";
                clinicInvoiceDetList.Add(clinicInvoiceDet4);
                //填入发票支付信息_END 
            }
            //门诊结算
            ClinicAccount clinicAccount = new ClinicAccount();
            clinicAccount.Id = BillSysBase.nextId("clinic_account");
            clinicAccount.Billcode = BillSysBase.newBillcode("clinic_account_billcode");//结算单
            clinicAccount.Regist_id = this.register_id;
            clinicAccount.Recivefee = tbxRcvFee.Text;
            clinicAccount.Realfee = tbxAmount.Text;
            clinicAccount.Retfee = tbxRetFee.Text;
            ////支付
            clinicAccount.Payfee = tbxPayFee.Text;
            clinicAccount.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
            clinicAccount.HisOrderNo = hisOrderNo;
            ////
            clinicAccount.Insurefee = insurefee.ToString();//统筹金额
            clinicAccount.Insuraccountfee = Insuraccountfee.ToString();//个人账户支付 
            clinicAccount.Settledep_id = ProgramGlobal.Depart_id;
            clinicAccount.Settledby = ProgramGlobal.User_id;
            clinicAccount.Settledate = currDate;
            clinicAccount.Bas_paytype_id = cmbPayType.SelectedValue.ToString();

            clinicInvoice.Account_id = clinicAccount.Id;
            clinicInvoice.Insurefee = insurefee.ToString();//统筹金额
            clinicInvoice.Insuraccountfee = Insuraccountfee.ToString();//个人账户支付 
            clinicInvoice.Insurotherfee = insureOtherfee.ToString();//其它医保支付
            clinicInvoice.Isregist = "1";
            ////门诊结算_END
            //if (reaInsurCardButtonClick())
            //{
            //    BllMemberReg bllMemberReg = new BllMemberReg();
            //    string balance = (Double.Parse(tbxAccountAmt.Text) - Double.Parse(tbxPayFee.Text)).ToString();
            //    if (Double.Parse(balance) < 0)
            //    {
            //        MessageBox.Show("门诊卡余额不足！当前余额未:" + tbxAccountAmt.Text + "。");
            //        return false;
            //    }

            //    if (MessageBox.Show("是否是用门诊卡支付" + tbxPayFee.Text + "？当前余额为:" + tbxAccountAmt.Text + "。收费后余额：" + balance, "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //    {
            //        return false;
            //    }
            //    regist_sql += bllMemberReg.upMember_balance(member_id, balance);
            //    string id = "";
            //    regist_sql += bllMemberReg.inMember_rechargedet(member_id, "CO", tbxPayFee.Text, "11", balance,ref id);
            //}

            regist_sql += bllRecipelCharge.doClinicInvoice(clinicInvoice, clinicInvoiceDetList);//收费发票
            regist_sql += bllRecipelCharge.doClinicAccount(clinicAccount); //结账信息单
            regist_sql += doRegistInfo();  //挂号信息
            regist_sql += bllRecipelCharge.updateClinic_costdet_unlocked(clinic_costdet_ids);//修改挂号处方信息表中的挂号费的解锁状态
            if (bllRecipelCharge.doExeSql(regist_sql) < 0)
            {
                MessageBox.Show("挂号信息生成失败！,医保病人请及时查看系统撤销情况,和网络支付病人请及时撤退金额");
                List<ClinicInvoice> clinicInvoices = new List<ClinicInvoice>();
                clinicInvoices.Add(clinicInvoice);
                bllRecipelCharge.doCancleInsurInvoice(clinicInvoices);//失败后处理医保信息
                SysWriteLogs.writeLogs1("挂号信息错误日志.log", Convert.ToDateTime(BillSysBase.currDate()), regist_sql);
                return false;
            }

            //初始化左侧当前挂号信息
            dgvVisit.DataSource = bllClinicReg.getRegisterInfo();
            if (MessageBox.Show("挂号成功！是否打印发票？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.clinic_Reginvoice(clinic_invoice_id);
            }
            return true;
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
                else if (chk_authCode.Length > 18)
                {
                    chk_authCode = chk_authCode.Substring(0, 18);
                }

                netPayIn.AuthCode = chk_authCode;
                netPayIn.Czyh = ProgramGlobal.User_id;
                hisOrderNo = netPayIn.OuterOrderNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 
                netPayIn.Paytype = netpaytype;
                netPayIn.StoreId = "0";
                netPayIn.Subject = "挂号";
                netPayIn.Ddlx = "1";//订单类型（默认1）：1挂号；2缴费；3预交金 
                netPayIn.Ddly = "1";//订单来源（默认1）：1门诊;2住院
                netPayIn.Hzxm = tbxPatientName.Text;
                netPayIn.Lxdh = tbxPhoneNum.Text.Trim();
                // netPayIn.Sfzh = tbxIDCard.Text.Trim();
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
        /// 就诊信息
        /// </summary>
        /// <returns></returns>
        private string doRegistInfo()
        {

            InCall inCall = new InCall();//给叫号系统中传递值
            inCall.Register_id = register_id;
            inCall.Depart_id = cmbDepart.SelectedValue.ToString();
            inCall.Depart = cmbDepart.Text.ToString();
            inCall.Doctor = cmbDoctor.Text.Trim();
            inCall.Sickname = tbxPatientName.Text.Trim();
            inCall.Clinicroom = this.clinicroom;
            inCall.Clinicroom_id = this.clinicroom_id;
            inCall.Calladdr = ProgramGlobal.Calladdr;
            inCall.Callserverurl = ProgramGlobal.Callserverurl;
            inCall.Seqnum = "";

            if (ProgramGlobal.Calling == "1")
            {
                bllClinicReg.sendInCallUpdateSys_calling(inCall);

            }
            string currDate = BillSysBase.currDate();
            string merge_sql = "";
            //会员卡
            Member member = new Member();
            member.Name = tbxPatientName.Text.Trim().ToString();
            member.Pincode = GetData.GetChineseSpell(tbxPatientName.Text.ToString());
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

            member.Birthday = dtpBirthday.Value.ToString("yyy-MM-dd");

            if (cmbRace.SelectedValue != null && cmbRace.SelectedValue.ToString() != "")
            {
                member.Race_id = cmbRace.SelectedValue.ToString().Trim();
                member.Race = cmbRace.Text.Trim().ToString();
            }

            member.Idcard = tbxIDCard.Text.Trim().ToString();

            if (cmbProfession.SelectedValue != null && cmbProfession.SelectedValue.ToString().Trim() != "0")
            {
                member.Profession_id = cmbProfession.SelectedValue.ToString().Trim();
                member.Profession = cmbProfession.Text.Trim().ToString();
            }
            member.Mobile = tbxPhoneNum.Text.Trim().ToString();
            member.Companyname = tbxCompanyName.Text.Trim().ToString();

            if (tbxHmhouseNumber.Text.Trim().Length > 20)
            {
                member.Homeaddress = tbxHmhouseNumber.Text;
            }
            else
            {
                member.Homeaddress = cmbProvince.Text.ToString() + cmbCity.Text.ToString() + cmbCounty.Text.ToString() + tbxHmhouseNumber.Text.ToString();//住址全称
            }

            member.Provice_id = cmbProvince.SelectedValue.ToString();
            member.City_id = cmbCity.SelectedValue.ToString();
            member.County_id = cmbCounty.SelectedValue.ToString();
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

            member.HmhouseNumber = tbxHmhouseNumber.Text.ToString();
            //挂号记录
            Register register = new Register();
            String doctor_id = cmbDoctor.SelectedValue.ToString();
            DataTable dt = bllClinicReg.getRegLevelByDoctor(doctor_id);
            String reg_level_id = dt.Rows[0]["reg_level_id"].ToString();
            register.Id = this.register_id;
            register.Billcode = register_Billcode;
            register.Regdate = currDate;
            register.clininicpay = cmbPatientType.SelectedValue.ToString() == "1" ? "B":"A";
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
                register.Healthcard = "";//磁条卡号
            }
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GYSYB.ToString().ToUpper().Trim()))
            {
                register.Insurcode = sybdk_entity.Grbh;
                register.Healthcard = "";//磁条卡号
            }
            else
            {
                register.Insurcode = "";
                register.Healthcard = "";//磁条卡号
            }
            register.Hspcard = member.Hspcard;

            register.Sys_region_id = "3";  //
            register.Reg_regclass_id = bllClinicReg.getRegclass();
            register.Urgent = bllClinicReg.getUrgent(cmbUrgent.SelectedValue.ToString());
            register.Doctor_id = cmbDoctor.SelectedValue.ToString();
            register.Depart_id = cmbDepart.SelectedValue.ToString();
            register.Users_id = ProgramGlobal.User_id;
            register.Amount = tbxAmount.Text.ToString();
            register.Status = RegisterStatus.REG.ToString();
            register.Isarchive = RegisterIsarchive.OO.ToString();

            register.Name = tbxPatientName.Text.ToString();
            register.Pincode = GetData.GetChineseSpell(tbxPatientName.Text.ToString());
            register.Sex = member.Sex;
            register.Birthday = Convert.ToDateTime( dtpBirthday.Value.ToString()).ToString("yyyy-MM-dd HH-mm-ss");
            register.Age = tbxAge.Text.ToString();
            register.Ageunit = cmbAgesUnit.SelectedValue.ToString();
            register.Moonage = tbxMonAge.Text.ToString();
            register.Moonageunit = cmbMonth.SelectedValue.ToString();
            register.Createtime = currDate;
            register.Updatetime = currDate;



            if (string.IsNullOrEmpty(inCall.Clinicroom))
            {
                register.Clinicroom = inCall.Depart;
            }
            else
            {
                register.Clinicroom = inCall.Clinicroom;
            }
            register.Regnum = inCall.Seqnum;

            //就诊人员信息表
            IhspInfo ihspInfo = new IhspInfo();
            ihspInfo.Id = BillSysBase.nextId("ihsp_info");
            ihspInfo.Ihsp_id = register.Id;
            ihspInfo.Idcard = member.Idcard;
            ihspInfo.Profession = member.Profession;
            ihspInfo.Homeaddress = member.Homeaddress;//现住址
            ihspInfo.Hmprovince = cmbProvince.SelectedValue.ToString();//省外键
            ihspInfo.Hmcity = cmbCity.SelectedValue.ToString();//市外键
            ihspInfo.Hmcounty = cmbCounty.SelectedValue.ToString();//县外键
            ihspInfo.HmhouseNumber = member.HmhouseNumber;
            ihspInfo.Hmstreetname = member.Hmstreetname;
            ihspInfo.Profession_id = member.Profession_id;
            ihspInfo.Homephone = member.Mobile;
            ihspInfo.Mobile = member.Mobile;
            ihspInfo.Companyname = member.Companyname;
            ihspInfo.Race = cmbRace.Text;
            ihspInfo.Race_id = cmbRace.SelectedValue.ToString();
            ihspInfo.Mobile = tbxPhoneNum.Text;

            string member_id = "0";
            merge_sql += bllClinicReg.doMemberItem(member, ref member_id);
            merge_sql += bllClinicReg.addRegisterItem(register, member_id);
            merge_sql += bllClinicReg.addIhspInfoItem(ihspInfo);
            return merge_sql;
        }
        /// <summary>
        /// 重置界面信息
        /// </summary>
        public void initCostInfo()
        {
            register_id = "";
            register_billcode = "";
            clinic_costdet_ids = "";
            clinic_cost_id = "";
            ischarge = false;
            tbxHmhouseNumber.Text = "";
            tbxHspcard.Text = "";
            tbxPatientName.Text = "";
            cmbRace.SelectedValue = "1";
            cmbDepart.SelectedValue = 0;
            cmbDoctor.SelectedValue = 0;
            cmbSex.SelectedIndex = 0;
            dtpBirthday.Text = BillSysBase.currDate();
            cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
            tbxIDCard.Text = "";
            tbxAmount.Text = "0.00";
            tbxCompanyName.Text = "";
            tbxPhoneNum.Text = "";
            cmbProfession.SelectedValue = "0";
            tbxAge.Text = "0";
            cmbUrgent.SelectedValue = "2";
            cmbDagn.SelectedValue = 0;
            cmbReg.SelectedValue = 0;
            //支付初始化
            cmbPayType.SelectedValue = "1";
            netpaytype = "-1";
            //支付初始化
            cmbProvince.SelectedValue = "130000";//贵州省
            cmbCity.SelectedValue = "130100";//

            btnCostCharged.Text = "收费";
            this.cmbPatientType.SelectedValue = 1;
            //患者类型
            string patientType_id = cmbPatientType.SelectedValue.ToString();
            patienttypeKeyname = billClinicRcpCost.getPatienttypeKeyname(patientType_id);

            lblReadCardMsg.Text = "";
            lblRegistBillcode.Text = BillSysBase.currBillcode("register_billcode");

            initInvoice();//获取发票信息
            dgvRegistItem.DataSource = bllClinicReg.getRegisterById(today);//根据医院卡号查询挂号信息
            tbxHspcard.Focus();
        }
        /// <summary>
        /// 获取发票信息
        /// </summary>
        public void initInvoice()
        {

            ///发票初始化
            string invoicecode = "";//发票号

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
        /// 收费按钮： 自费时 ：收费　　医保: 预结算-->收费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCostCharged_Click(object sender, EventArgs e)
        
        {
            if(!reaInsurCardButtonClick())
            {
                MessageBox.Show("读卡失败！请重试！");
                return;
            }
            
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
                initCostInfo();
            }
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SJZSYB.ToString()))
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
                initCostInfo();
            }

            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GZSYB.ToString()))
            {
                if (btnCostCharged.Text == "收费")
                {
                    if (!preAccount())
                    {
                        return;
                    }
                    btnCostCharged.Text = "结算";
                    unableEdit();
                    return;
                }
                else
                {
                    btnCostCharged.Enabled = false;
                    if (!doAccount()) //结算
                    {
                        btnCostCharged.Enabled = true;
                        return;
                    }
                    btnCostCharged.Enabled = true;
                    enableEdit();
                    initCostInfo();
                }
            }
            else if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GYSYB.ToString()))
            {
                if (btnCostCharged.Text == "收费")
                {
                    if (!preAccount())
                    {
                        return;
                    }
                    btnCostCharged.Text = "结算";
                    return;
                }
                else
                {
                    btnCostCharged.Enabled = false;
                    if (!doAccount()) //结算
                    {
                        btnCostCharged.Enabled = true;
                        return;
                    }
                    btnCostCharged.Enabled = true;
                    initCostInfo();
                }
            }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadIDCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cmbPatientType.Focus();
                cmbPatientType.DroppedDown = true;
            }
        }
        /// <summary>
        /// 医保读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadInsurCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                readInsurCard();
            }
            else if (e.KeyData == Keys.Enter)
            {
                cmbDepart.Focus();
                cmbDepart.DroppedDown = true;
            }
        }
        //左侧挂号信息表格被选中的事件
        private void dgvRegistChart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (!checkAccountStat())
                return;

            if (e.RowIndex >= 0)
            {
                String depart_id = dgvVisit.Rows[e.RowIndex].Cells["depart_id"].Value.ToString();
                String doctor_id = dgvVisit.Rows[e.RowIndex].Cells["doctor_id"].Value.ToString();
                this.cmbDepart.SelectedValue = depart_id;
                bindComboxData(bllClinicReg.getDoctorByDepartId(depart_id), cmbDoctor);
                cmbDoctor.SelectedValue = doctor_id;
            }
            tbxHspcard.Focus();
        }

        private void tbxAge_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxAge.Text))
            {
                tbxAge.Text = "0";
                tbxAge.SelectAll();
            }
            if (!Regex.IsMatch(tbxAge.Text, @"^([1-9]\d+|[0-9])(\.\d\d?)?$"))
            {
                MessageBox.Show("提示：年龄填写格式有误!");
                this.tbxAge.Focus();
                this.tbxAge.Text = "1";
                return;
            }
            ischarge = true;
            if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.AGE)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 150)
                {
                    MessageBox.Show("年龄不得大于150");
                    tbxAge.Clear();
                    tbxAge.SelectAll();
                }
                if (int.Parse(tbxAge.Text.Trim()) < 3 && int.Parse(tbxAge.Text.Trim()) >= 1)
                {
                    tbxMonAge.Visible = true;
                    cmbMonth.Visible = true;
                }
                else
                {
                    tbxMonAge.Visible = false;
                    cmbMonth.Visible = false;
                }
            }
            else
            {
                tbxMonAge.Visible = false;
                cmbMonth.Visible = false;
            }
            if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.MOON)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 12)
                {
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
                    tbxAge.Text = "1";
                    tbxAge.SelectAll();
                }
            }
            if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.DAY)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 30)
                {
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.MOON;
                    tbxAge.Text = "1";
                    tbxAge.SelectAll();
                }
            }
            if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.HOUR)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 72)
                {
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.DAY;
                    tbxAge.Text = "3";
                    tbxAge.SelectAll();
                }
            }
            ageChanged();
            ischarge = false;
        }
        //年龄数值发生改变
        private void ageChanged()
        {
            //string monthDay = "";
            //string age = tbxAge.Text.ToString();
            //if (age != null && !age.Equals("") && Regex.IsMatch(age, @"^[+-]?\d*$"))
            //{
            //    string currentYear = Convert.ToDateTime(BillSysBase.currDate()).Year.ToString();
            //    string currentMonth = Convert.ToDateTime(BillSysBase.currDate()).Month.ToString();
            //    string currentDay = Convert.ToDateTime(BillSysBase.currDate()).Day.ToString();
            //    string birthYear = (int.Parse(currentYear)).ToString();
            //    string birthMonth = (int.Parse(currentMonth)).ToString();
            //    string birthDay = (int.Parse(currentDay)).ToString();

            //    if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.AGE)
            //    {
            //        birthYear = (int.Parse(currentYear) - int.Parse(age)).ToString();
            //        birthMonth = dtpBirthday.Value.Month.ToString();
            //        birthDay = dtpBirthday.Value.Day.ToString();
            //    }
            //    else if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.MOON)
            //    {
            //        string Year = (int.Parse(age) / 12).ToString();
            //        string Month = (int.Parse(age) % 12).ToString();

            //        birthMonth = (int.Parse(currentMonth) - int.Parse(Month)).ToString();
            //        if (int.Parse(birthMonth) <= 0)
            //        {
            //            birthMonth = (int.Parse(birthMonth) + 12).ToString();
            //            birthYear = (int.Parse(birthYear) - 1).ToString();
            //        }
            //        birthYear = (int.Parse(birthYear) - int.Parse(Year)).ToString();
            //    }
            //    else if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.DAY)
            //    {
            //        birthDay = (int.Parse(currentDay) - int.Parse(age)).ToString();
            //        while (int.Parse(birthDay) <= 0)
            //        {
            //            monthDay = getMonthDay(birthMonth, birthYear);
            //            birthDay = (int.Parse(birthDay) + int.Parse(monthDay)).ToString();
            //            birthMonth = (int.Parse(birthMonth) - 1).ToString();
            //            if (int.Parse(birthMonth) <= 0)
            //            {
            //                birthMonth = (int.Parse(birthMonth) + 12).ToString();
            //                birthYear = (int.Parse(birthYear) - 1).ToString();
            //            }
            //        }
            //    }
            //    else if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.HOUR)
            //    {
            //        string Day = (int.Parse(age) / 24).ToString();
            //        birthDay = (int.Parse(currentDay) - int.Parse(Day)).ToString();
            //        if (int.Parse(birthDay) < 0)
            //        {
            //            birthDay = (int.Parse(birthDay) + 30).ToString();
            //        }

            //    }
            //    if (int.Parse(birthMonth) == 2)
            //    {
            //        if ((int.Parse(birthYear) % 4 == 0 && int.Parse(birthYear) % 100 != 0) || (int.Parse(birthYear) % 400 == 0))
            //        {
            //            if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 31)
            //            {
            //                birthDay = "29";
            //            }
            //        }
            //        else
            //        {
            //            if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 29 || int.Parse(birthDay) == 31)
            //            {
            //                birthDay = "28";
            //            }
            //        }
            //    }
            //    dtpBirthday.Value = Convert.ToDateTime(birthYear + "-" + birthMonth + "-" + birthDay);
            //}
            //else
            //{
            //    MessageBox.Show("年龄输入有误");
            //    return;
            //}
        }
        /// <summary>
        /// 获取前一个月有多少天
        /// </summary>
        /// <param name="birthMonth">当前的月</param>
        /// <param name="birthYear">当前的年</param>
        /// <returns></returns>
        public string getMonthDay(string birthMonth, string birthYear)
        {
            string monthDay = "";
            string monthy = (int.Parse(birthMonth) - 1).ToString();
            if (monthy == "1")
            {
                monthy = "12";
                birthYear = (int.Parse(birthYear) - 1).ToString();
            }
            if (monthy == "1" || monthy == "3" || monthy == "5" || monthy == "7" || monthy == "8" || monthy == "10" || monthy == "12")
            {
                monthDay = "31";
            }
            else if (monthy == "2")
            {
                if ((int.Parse(birthYear) % 4 == 0 && int.Parse(birthYear) % 100 != 0) || (int.Parse(birthYear) % 400 == 0))
                {
                    monthDay = "29";
                }
                else
                {
                    monthDay = "28";
                }
            }
            else
            {
                monthDay = "30";
            }
            return monthDay;
        }
        private void dtpBirthday_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                i++;
                SendKeys.Send("{right}");
                if (i == 3)
                {
                    SendKeys.Send("{tab}");
                    i = 0;
                }
            }
        }


        private void cmbAgesUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ischarge = true;
            if (!string.IsNullOrEmpty(tbxAge.Text))
            {
                if (int.Parse(tbxAge.Text) >= 1 && int.Parse(tbxAge.Text) < 3 && (int)cmbAgesUnit.SelectedValue == (int)AgeUnit.AGE)
                {
                    cmbMonth.Visible = true;
                    tbxMonAge.Visible = true;
                }
                else
                {
                    cmbMonth.Visible = false;
                    tbxMonAge.Visible = false;
                }
                ageChanged();
            }
            ischarge = false;
        }

        private void FrmClinicReg_Activated(object sender, EventArgs e)
        {
            tbxHspcard.Focus();
        }

        /// <summary>
        /// 身份证号得到出生日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool idCardEcho()
        {
            string idCard = tbxIDCard.Text.Trim();
            if (idCard == "")
            {
                return false;
            }
            string year = "";
            string month = "";
            string day = "";
            string sex = "";
            string birthday = "";
            if (idCard.Length == 15)
            {
                year = idCard.Substring(6, 2);
                year = "19" + year;
                month = idCard.Substring(8, 2);
                day = idCard.Substring(10, 2);
                sex = idCard.Substring(12, 3);
            }
            else if (idCard.Length == 18)
            {
                year = idCard.Substring(6, 4);
                month = idCard.Substring(10, 2);
                day = idCard.Substring(12, 2);
                sex = idCard.Substring(14, 3);
            }

            birthday = year + "-" + month + "-" + day;
            DateTime birth = new DateTime();
            try
            {
                birth = DateTime.ParseExact(birthday, "yyyy-MM-dd", null);
            }
            catch (Exception e)
            {
                MessageBox.Show("身份证出生年月输入不合法，请重新输入！");
                this.tbxIDCard.Focus();
                return false;
            }
            dtpBirthday.Value = birth;
            if (int.Parse(sex) % 2 == 0)//性别代码为偶数是女性奇数为男性
            {
                this.cmbSex.Text = "女";
            }
            else
            {
                this.cmbSex.Text = "男";
            }
            return true;
        }


        private void tbxPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cmbRace.Focus();
                cmbRace.DroppedDown = true;
            }
        }

        private void cmbDepart_KeyDown(object sender, KeyEventArgs e)
        {

            //判断输入是否 为字母键 或者 删除键，delete键 数字键
            if ((e.KeyValue >= 65) && (e.KeyValue <= 90)
                || (e.KeyCode == Keys.Back)
                || (e.KeyCode == Keys.Delete)
                || (e.KeyValue >= 48) && (e.KeyValue <= 57)
                || (e.KeyValue >= 96) && (e.KeyValue <= 105))
            {

                int l = cmbDepart.SelectionStart; //记录修改时光标位置
                cmbDepart.DroppedDown = false; //下拉框关闭

                string dep = cmbDepart.Text.Trim();
                //简码查询科室
                DataTable dtde = bllClinicReg.getDepartInfo(dep);
                //重新绑定
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dtde.Rows.InsertAt(dr, 0);
                cmbDepart.DataSource = dtde;
                cmbDepart.Text = dep;

                cmbDepart.DroppedDown = true; //打开下拉框
                cmbDepart.SelectionStart = l; //定位光标至修改时的位置
                this.Cursor = System.Windows.Forms.Cursors.Default; //显示鼠标
            }
            else if (e.KeyCode == Keys.Enter)
            {
                cmbDoctor.Focus();
                cmbDoctor.DroppedDown = true;
            }
        }

        private void cmbDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxIDCard.Focus();
            }
        }

        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbUrgent.Focus();
                this.cmbUrgent.DroppedDown = true;
            }
        }

        private void tbxAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cmbSex.Focus();
                cmbSex.DroppedDown = true;
            }
            try
            {
                if (this.tbxAge.Text == "")
                {
                    dtpBirthday.Value = DateTime.Now;
                    return;
                }
                int a = int.Parse(tbxAge.Text);

                if (cmbAgesUnit.SelectedValue.ToString() == AgeUnit.AGE.ToString())
                    dtpBirthday.Value = DateTime.Now.AddYears(-a);
                else if (cmbAgesUnit.SelectedValue.ToString() == AgeUnit.MOON.ToString())
                    dtpBirthday.Value = DateTime.Now.AddMonths(-a);
                else if (cmbAgesUnit.SelectedValue.ToString() == AgeUnit.DAY.ToString())
                    dtpBirthday.Value = DateTime.Now.AddDays(-a);
            }
            catch
            {
                MessageBox.Show("年龄输入错误！", "提示信息");
                return;
            }

        }

        private void tbxMonAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbProvince.Focus();
                this.cmbProvince.DroppedDown = true;
            }
        }

        private void cmbPatientType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cmbDepart.Focus();
                cmbDepart.DroppedDown = true;

            }
        }

        private void cmbUrgent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.cmbProvince.Focus();
                //this.cmbProvince.DroppedDown = true;
                tbxHmhouseNumber.Focus();
            }
        }

        private void tbxIDCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!checkIdCard())
                {
                    tbxIDCard.Focus();
                }
                else
                {
                    tbxAge.Focus();

                }
            }
        }
        //身份证检查校验自动生成 年龄 与 出生年月
        public bool checkIdCard()
        {

            //正则表达式 身份证验证出生年月日要合法
            //身份证号18位正则表达式
            Regex reg18 = new Regex(@"^([1-9]{1}\d{5}[1-2]{1}[09]{1}\d{2}(([0]{1}[1-9]{1})|([1]{1}[012]{1}))(([0]{1}[1-9]{1})|([12]{1}\d{1})|([3]{1}[01]{1}))(\d{4}|(\d{3}[x]{1})|(\d{3}[X]{1})))$");
            //身份证15位正则表达式
            Regex reg15 = new Regex(@"^([1-9]{1}\d{5}\d{2}(([0]{1}[1-9]{1})|([1]{1}[012]{1}))(([0]{1}[1-9]{1})|([12]{1}\d{1})|([3]{1}[01]{1}))\d{3})$");

            if (string.IsNullOrEmpty(tbxIDCard.Text) || string.IsNullOrWhiteSpace(tbxIDCard.Text))
            {
                dtpBirthday.Focus();
                return true;
            }
            string idCard = tbxIDCard.Text.Trim();
            //身份证判断
            if (!reg18.IsMatch(idCard))
            {
                MessageBox.Show("请输入正确的身份证号，请重新输入！");

                return false;
            }
            if (!idCardEcho())
                return false;

            string county = idCard.Substring(0, 6);
            string city = county.Substring(0, 4) + "00";
            string province = city.Substring(0, 2) + "0000";
            changeCmbAddress(province, city, county);
            return true;
        }
        /// <summary>
        /// 安全的给级联菜单赋值
        /// </summary>
        private void changeCmbAddress(string province, string city, string county)
        {
            if (province == "" || province == null)
            {
                MessageBox.Show("地址填写不对！");
                return;
            }
            //if (province == cmbProvince.SelectedValue.ToString())
            //{
            //    provinceChange();
            //    if (cmbCity.SelectedValue.ToString() == city)
            //    {
            //        cityChange();
            //    }
            //}
            //else
            //{
            //    cmbProvince.SelectedValue = province;
            //}
            //province = "0";

            cmbProvince.SelectedValue = province;
            provinceChange();
            cmbCity.SelectedValue = city;
            cityChange();
            cmbCounty.SelectedValue = county;


        }
        private void cmbAgesUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbMonth.Visible)
                {
                    tbxMonAge.Focus();
                }
                else
                {
                    cmbSex.Focus();
                    this.cmbSex.DroppedDown = true;
                }
            }
        }

        private void tbxPhoneNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxCompanyName.Focus();
            }
        }

        private void tbxCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPayType.Focus();
                cmbPayType.DroppedDown = true;
            }
        }

        private void tbxHmhouseNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbProfession.Focus();
                this.cmbProfession.DroppedDown = true;
            }
        }



        #region 地址 简码下拉
        private void cmbProvince_SelectedValueChanged(object sender, EventArgs e)
        {
            provinceChange();
        }
        /// <summary>
        /// 地址1
        /// </summary>
        private void provinceChange()
        {
            if (cmbProvince.SelectedValue == null) { return; }
            string value = cmbProvince.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(value) && !string.Equals(value, "System.Data.DataRowView"))
            {
                if (string.Equals(value, "0"))
                {
                    DataTable dt = new DataTable();
                    bindComboxData(dt, cmbCity);
                }
                else
                {

                    bindComboxData(bllClinicReg.cityListB(value), cmbCity);
                }

                if (cmbCity.Items.Count > 1)
                {
                    cmbCity.SelectedIndex = 1;
                }

            }
        }
        /// <summary>
        /// 地址2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCity_SelectedValueChanged(object sender, EventArgs e)
        {
            cityChange();
        }
        private void cityChange()
        {
            if (cmbCity.SelectedValue == null) { return; }
            string value = cmbCity.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(value) && !string.Equals(value, "System.Data.DataRowView"))
            {
                if (string.Equals(value, "0"))
                {
                    DataTable dt = new DataTable();
                    bindComboxData(dt, cmbCounty);
                }
                else
                {
                    bindComboxData(bllClinicReg.countyListB(value), cmbCounty);
                }
                if (value.Equals("130100"))//贵阳市
                {
                    cmbCounty.SelectedValue = "130121";//南明区
                }
                else
                {

                    if (cmbCounty.Items.Count > 1)
                    {
                        cmbCounty.SelectedIndex = 1;
                    }
                }
            }
        }
        private void cmbCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
        #endregion




        /// <summary>
        /// 刷卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                {
                    this.tbxPatientName.Focus();
                    return;
                }
                if (bllClinicReg.hasMember(tbxHspcard.Text.Trim().ToString()))
                {
                    DataTable dt = bllClinicReg.getMemberInfo(tbxHspcard.Text.Trim().ToString());
                    tbxPatientName.Text = dt.Rows[0]["name"].ToString();
                    if (!dt.Rows[0]["race_id"].ToString().Equals(""))
                    {
                        cmbRace.Text = dt.Rows[0]["race"].ToString();
                        cmbRace.SelectedValue = dt.Rows[0]["race_id"].ToString();
                    }
                    if (!dt.Rows[0]["sex"].ToString().Equals(""))
                    {
                        cmbSex.SelectedValue = dt.Rows[0]["sex"].ToString();
                    }
                    if (!dt.Rows[0]["hmhousenumber"].ToString().Equals(""))
                    {
                        tbxHmhouseNumber.Text = dt.Rows[0]["hmhousenumber"].ToString();
                    }
                    if (!dt.Rows[0]["birthday"].ToString().Equals(""))
                    {
                        dtpBirthday.Text = dt.Rows[0]["birthday"].ToString();
                    }
                    if (!dt.Rows[0]["idcard"].ToString().Equals(""))
                    {
                        tbxIDCard.Text = dt.Rows[0]["idcard"].ToString();
                    }
                    if (!dt.Rows[0]["profession_id"].ToString().Equals(""))
                    {
                        cmbProfession.SelectedValue = dt.Rows[0]["profession_id"].ToString();
                    }
                    if (!dt.Rows[0]["mobile"].ToString().Equals(""))
                    {
                        tbxPhoneNum.Text = dt.Rows[0]["mobile"].ToString();
                    }
                    if (!dt.Rows[0]["companyname"].ToString().Equals(""))
                    {
                        tbxCompanyName.Text = dt.Rows[0]["companyname"].ToString();
                    }
                    if (!dt.Rows[0]["provice_id"].ToString().Equals("0"))
                    {
                        changeCmbAddress(dt.Rows[0]["provice_id"].ToString(), dt.Rows[0]["city_id"].ToString(), dt.Rows[0]["county_id"].ToString());

                    }
                    this.cmbPatientType.Focus();
                }
                this.tbxPatientName.Focus();
            }
        }


        private void cmbReg_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbReg.SelectedValue.ToString() == "0")
            {
                tbxRegfee.Text = "0";
            }
            else
            {
                dtThisReg = bllClinicReg.getItemInfo(cmbReg.SelectedValue.ToString());
                tbxRegfee.Text = dtThisReg.Rows[i]["prc"].ToString();
            }
            if (tbxRegfee.Text == "")
            {
                tbxRegfee.Text = "0";
            }
            double totalAmount = 0.00;
            totalAmount += double.Parse(tbxRegfee.Text);
            totalAmount += double.Parse(tbxDagnfee.Text);


            tbxAmount.Text = totalAmount.ToString();
            tbxPayFee.Text = totalAmount.ToString();
            tbxRcvFee.Text = tbxAmount.Text;
            tbxRetFee.Text = "0.00";
            tbxRcvFee.SelectAll();
        }

        private void cmbDagn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDagn.SelectedValue.ToString() == "0")
            {
                tbxDagnfee.Text = "0";

            }
            else
            {
                dtThisDagn = bllClinicReg.getItemInfo(cmbDagn.SelectedValue.ToString());
                tbxDagnfee.Text = dtThisDagn.Rows[i]["prc"].ToString();
            }
            if (tbxDagnfee.Text == "")
            {
                tbxDagnfee.Text = "0";
            }
            double totalAmount = 0.00;
            totalAmount += double.Parse(tbxRegfee.Text);
            totalAmount += double.Parse(tbxDagnfee.Text);


            tbxAmount.Text = totalAmount.ToString();
            tbxPayFee.Text = totalAmount.ToString();
            tbxRcvFee.Text = tbxAmount.Text;
            tbxRetFee.Text = "0.00";
            tbxRcvFee.SelectAll();
        }





        private void tbxCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxRcvFee.Focus();
            }
        }

        private void cmbPaytype_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbPayType.SelectedValue == null)
            {
                cmbPayType.SelectedValue = 0;
            }
        }

        private void cmbProvince_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.cmbCity.Focus();
                this.cmbCity.DroppedDown = true;
            }

        }

        private void cmbCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCounty.Focus();
                this.cmbCounty.DroppedDown = true;
            }

        }

        private void cmbCounty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxHmhouseNumber.Focus();
            }

        }

        private void cmbProfession_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                tbxPhoneNum.Focus();

            }
        }

        /// <summary>
        /// 出生日期更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            if (ischarge == false)
            {
                DateTime birth = dtpBirthday.Value;
                DateTime current = Convert.ToDateTime(BillSysBase.currDate());
                TimeSpan ts = current.Subtract(birth);
                if (ts.TotalDays <= 3)
                {
                    tbxAge.Clear();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.HOUR;
                }
                else if (ts.TotalDays <= 30)
                {
                    tbxAge.Text = ((int)ts.TotalDays).ToString();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.DAY;
                }
                else if (current.Year - birth.Year < 1)
                {
                    tbxAge.Text = ((int)ts.TotalDays / 30).ToString();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.MOON;
                }
                else if (current.Year - birth.Year < 3)
                {
                    int year = current.Year - birth.Year;
                    int month = current.Month - birth.Month;
                    if (month < 0)
                    {
                        year = year - 1;
                        month = month + 12;
                    }
                    tbxAge.Text = year.ToString();
                    tbxMonAge.Text = month.ToString();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
                }
                else
                {
                    tbxAge.Text = (current.Year - birth.Year).ToString();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
                }
            }
        }


        /// <summary>
        /// 付款类型选择处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPayType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPayType.Items.Count <= 0)
                return;
            tbx_authCode.ReadOnly = true;
            tbx_authCode.Text = "";
            if (cmbPayType.SelectedValue.ToString() == "1")//现金
            {
                tbxRcvFee.ReadOnly = false;
                tbxRcvFee.Text = tbxPayFee.Text;
                tbxRcvFee.SelectAll();
                tbxRcvFee.Focus();
                netpaytype = "-1";
                lblInvoiceMsg.Text = "                   ";
            }
            else
            {

                tbxRcvFee.ReadOnly = true;
                tbxRcvFee.Text = "";
                tbxRetFee.Text = "";
                NetpayBll netpayBll = new NetpayBll();
                netpaytype = netpayBll.getNetPaytype(cmbPayType.SelectedValue.ToString());
                if (netpaytype != "-1")
                {
                    tbx_authCode.ReadOnly = false;
                    tbx_authCode.Clear();
                    tbx_authCode.Focus();
                    lblInvoiceMsg.Text = "现在选择网络支付";

                }
                else
                {
                    lblInvoiceMsg.Text = "                   ";

                }
            }

        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClinicReg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!checkAccountStat())
            {
                e.Cancel = true;
                return;
            }
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
            tbxHspcard.ReadOnly = true;
            tbxPatientName.ReadOnly = true;
            cmbRace.Enabled = false;
            cmbPatientType.Enabled = false;
            cmbDepart.Enabled = false;
            cmbDoctor.Enabled = false;
            cmbReg.Enabled = false;
            cmbDagn.Enabled = false;
        }
        /// <summary>
        /// 启用编辑
        /// </summary>
        private void enableEdit()
        {
            tbxHspcard.ReadOnly = false;
            tbxPatientName.ReadOnly = false;
            cmbRace.Enabled = true;
            cmbPatientType.Enabled = true;
            cmbDepart.Enabled = true;
            cmbDoctor.Enabled = true;
            cmbReg.Enabled = true;
            cmbDagn.Enabled = true;
        }



        private void tbxMonAge_TextChanged(object sender, EventArgs e)
        {
            #region 原先老程序
            //if (string.IsNullOrEmpty(tbxMonAge.Text))
            //{
            //    tbxMonAge.Text = "0";
            //    tbxMonAge.SelectAll();
            //}
            //if (!Regex.IsMatch(tbxMonAge.Text, @"^([1-9]\d+|[0-9])(\.\d\d?)?$"))
            //{
            //    MessageBox.Show("提示：年龄填写格式有误!");
            //    this.tbxMonAge.Focus();
            //    this.tbxMonAge.Text = "1";
            //    return;
            //}
            //else
            //{
            //    if (int.Parse(tbxMonAge.Text.Trim()) >= 12)
            //    {
            //        MessageBox.Show("月数不能大于12");
            //        tbxMonAge.Text = "0";
            //        tbxMonAge.SelectAll();
            //    }
            //}
            //ischarge = true;
            //string age = tbxMonAge.Text.ToString();
            //string currentYear = Convert.ToDateTime(BillSysBase.currDate()).Year.ToString();
            //string currentMonth = Convert.ToDateTime(BillSysBase.currDate()).Month.ToString();
            //string currentDay = Convert.ToDateTime(BillSysBase.currDate()).Day.ToString();
            //string birthYear = dtpBirthday.Value.Year.ToString();
            //string birthMonth = (int.Parse(currentMonth)).ToString();
            //string birthDay = (int.Parse(currentDay)).ToString();
            //string Year = (int.Parse(age) / 12).ToString();
            //string Month = (int.Parse(age) % 12).ToString();

            //birthMonth = (int.Parse(currentMonth) - int.Parse(Month)).ToString();
            //if (int.Parse(birthMonth) <= 0)
            //{
            //    birthMonth = (int.Parse(birthMonth) + 12).ToString();
            //    birthYear = (int.Parse(birthYear) - 1).ToString();
            //}
            //birthYear = (int.Parse(birthYear) - int.Parse(Year)).ToString();
            //if (int.Parse(birthMonth) == 4 || int.Parse(birthMonth) == 6 || int.Parse(birthMonth) == 9 || int.Parse(birthMonth) == 11)
            //{
            //    if (int.Parse(birthDay) == 31)
            //    {
            //        birthMonth = (int.Parse(birthMonth) + 1).ToString();
            //        birthDay = "1";
            //    }
            //}
            //if (int.Parse(birthMonth) == 2)
            //{
            //    if ((int.Parse(birthYear) % 4 == 0 && int.Parse(birthYear) % 100 != 0) || (int.Parse(birthYear) % 400 == 0))
            //    {
            //        if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 31)
            //        {
            //            birthDay = "29";
            //        }
            //    }
            //    else
            //    {
            //        if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 29 || int.Parse(birthDay) == 31)
            //        {
            //            birthDay = "28";
            //        }
            //    }
            //}
            //dtpBirthday.Value = Convert.ToDateTime(birthYear + "-" + birthMonth + "-" + birthDay);
            //ischarge = false;
            #endregion
            if (ischarge == false)
            {
                DateTime birth = dtpBirthday.Value;
                DateTime current = Convert.ToDateTime(BillSysBase.currDate());
                TimeSpan ts = current.Subtract(birth);
                if (ts.TotalDays <= 3)
                {
                    tbxAge.Clear();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.HOUR;
                }
                else if (ts.TotalDays <= 30)
                {
                    tbxAge.Text = ((int)ts.TotalDays).ToString();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.DAY;
                }
                else if (current.Year - birth.Year < 1)
                {
                    tbxAge.Text = ((int)ts.TotalDays / 30).ToString();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.MOON;
                }
                else if (current.Year - birth.Year < 3)
                {
                    int year = current.Year - birth.Year;
                    int month = current.Month - birth.Month;
                    if (month < 0)
                    {
                        year = year - 1;
                        month = month + 12;
                    }
                    tbxAge.Text = year.ToString();
                    tbxMonAge.Text = month.ToString();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
                }
                else
                {
                    int birthyear = current.Year - birth.Year;
                    if (current.Month < birth.Month || (current.Month == birth.Month && current.Day < birth.Day))
                    {
                        birthyear = birthyear - 1;
                    }

                    double days = DateDiff(birth, current);
                    double ages = (int)days / 365.5;
                    tbxAge.Text = birthyear.ToString(); //(current.Year - birth.Year).ToString();
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
                }
            }
        }
        private static int DateDiff(DateTime dateStart, DateTime dateEnd)
        {
            DateTime start = Convert.ToDateTime(dateStart.ToShortDateString());
            DateTime end = Convert.ToDateTime(dateEnd.ToShortDateString());

            TimeSpan sp = end.Subtract(start);
            return sp.Days;
        }

        private void cmbRace_KeyDown(object sender, KeyEventArgs e)
        {
            //判断输入是否 为字母键 或者 删除键，delete键 数字键
            if ((e.KeyValue >= 65) && (e.KeyValue <= 90)
                || (e.KeyCode == Keys.Back)
                || (e.KeyCode == Keys.Delete)
                || (e.KeyValue >= 48) && (e.KeyValue <= 57)
                || (e.KeyValue >= 96) && (e.KeyValue <= 105))
            {

                int l = cmbRace.SelectionStart; //记录修改时光标位置
                cmbRace.DroppedDown = false; //下拉框关闭

                string race = cmbRace.Text.Trim();
                //简码查询民族
                DataTable dtrace = bllClinicReg.getRaceInfo(race);
                //重新绑定
                DataRow dr = dtrace.NewRow();
                cmbRace.DataSource = dtrace;
                cmbRace.Text = race;

                cmbRace.DroppedDown = true; //打开下拉框
                cmbRace.SelectionStart = l; //定位光标至修改时的位置
                this.Cursor = System.Windows.Forms.Cursors.Default; //显示鼠标
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // this.tbxIDCard.Focus();


                cmbPatientType.Focus();
                cmbPatientType.DroppedDown = true;
            }
        }

        private void cmbDepart_KeyUp(object sender, KeyEventArgs e)
        {



        }

        private void tbxPayFee_TextChanged(object sender, EventArgs e)
        {

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

        private void tbxRcvFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCostCharged.Focus();
            }
        }

        private void lblInvoiceMsg_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reaInsurCardButtonClick();
        }
        /// <summary>
        /// 门诊卡读取信息
        /// </summary>
        private bool reaInsurCardButtonClick()
        {
            bool Falg = false;
            Mifare dk = new Mifare();
            Member member = new Member();
            dk.OpenPoint();
            string fareuid = dk.FindCard();
            dk.ClosePoint();
            member.Mzfare = fareuid;
            member.Cardstat = MemberCardStat.YES.ToString();
            BillMember billMember = new BillMember();
            DataTable dt = billMember.memberSearch(member, "", "");
            if (dt.Rows.Count > 0)
            {
                this.tbxHspcard.Text = dt.Rows[0]["hspcard"].ToString();
                this.tbxPatientName.Text = dt.Rows[0]["name"].ToString();
                this.cmbSex.Text = dt.Rows[0]["sex"].ToString();
                this.dtpBirthday.Text = dt.Rows[0]["birthday"].ToString();
                this.tbxIDCard.Text = dt.Rows[0]["idcard"].ToString();
                this.tbxAccountAmt.Text = dt.Rows[0]["balance"].ToString();
                this.tbxHspcard.Text = dt.Rows[0]["hspcard"].ToString();
                this.tbxPhoneNum.Text = dt.Rows[0]["mobile"].ToString();
                tbxPhoneNum.Enabled = false;
                member_id = dt.Rows[0]["id"].ToString();
                Falg = true;
            }
            else
            {
                MessageBox.Show("读取门诊卡失败！请重试。");
            }
            return Falg;
        }
    }
}