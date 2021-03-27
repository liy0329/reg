using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using MTREG.medinsur.gysyb.bo;
using System.IO;
using MTREG.medinsur.gysyb.bll;
using MTREG.common;
using MTREG.medinsur.bll;
using MTREG.common.bll;

namespace MTREG.medinsur.gysyb
{
    public partial class FrmIhspMedinsrGYSYB : Form
    {
        BllInsurGYSYB bllInsur = new BllInsurGYSYB();
        public FrmIhspMedinsrGYSYB()
        {
            InitializeComponent();
        }
        private Sybdk_Entity sybdk_entity=new Sybdk_Entity();

        internal Sybdk_Entity Sybdk_entity
        {
            get { return sybdk_entity; }
            set { sybdk_entity = value; }
        }

        private String mtzyjl_iid;
        /// <summary>
        /// 主键id
        /// </summary>
        public String Mtzyjl_iid
        {
            get { return mtzyjl_iid; }
            set { mtzyjl_iid = value; }
        }
        private String mtzyjl_zyh;
        /// <summary>
        /// 住院号
        /// </summary>
        public String Mtzyjl_zyh
        {
            get { return mtzyjl_zyh; }
            set { mtzyjl_zyh = value; }
        }

        private string patientType;

        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }

        private string textBoxxm;
        /// <summary>
        /// //患者姓名
        /// </summary>
        public string TextBoxxm
        {
            get { return textBoxxm; }
            set { textBoxxm = value; }
        }
        public bool flag;

        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private bool sfzfzyb; //是否自费转医保标志
        public bool Sfzfzyb
        {
            get { return sfzfzyb; }
            set { sfzfzyb = value; }
        }
        Gysybservice gysybservice = new Gysybservice();
        private void FrmIhspMedinsrGYSYB_Load(object sender, EventArgs e)
        {
            initbxlb();
            initzflb();
            rbick.Checked = true;
            dgvwdybryzd.Visible = false;
        }
        /// <summary>
        /// 保险类别初始化
        /// </summary>
        public void initbxlb()
        {
            List<ListItem> items = new List<ListItem>();
           // 1:企业基本医疗保险；2:企业离休医疗保险；3:机关事业单位基本医疗保险；4：企业生育保险；5：机关事业单位生育保险；6：居民医保；7：工伤保险
            items.Add(new ListItem("企业基本医疗保险", "1"));
            items.Add(new ListItem("企业离休医疗保险", "2"));
            items.Add(new ListItem("机关事业单位基本医疗保险","3"));
            items.Add(new ListItem("企业生育保险","4"));
            items.Add(new ListItem("机关事业单位生育保险","5"));
            items.Add(new ListItem("居民医保","6"));
            items.Add(new ListItem("工伤保险","7"));
            cmbInsurType.DisplayMember = "Text";
            cmbInsurType.ValueMember = "Value";
            cmbInsurType.DataSource = items;
        }
        /// <summary>
        /// 清算方式
        /// </summary>
        //public void initqsfs()
        //{ 
        //    List<ListItem> items = new List<ListItem>();
        //    items.Add(new ListItem("1", "控制线清算方式（生育保险中为非包干方式）"));
        //    items.Add(new ListItem("3", "单病种按人次定额包干清算方式"));
        //    items.Add(new ListItem("4", "单病种按日定额包干清算方式"));
        //    items.Add(new ListItem("2", "重症病种清算"));
        //    items.Add(new ListItem("5", "生育保险包干清算"));
        //    items.Add(new ListItem("6", "单病种包干清算"));
        //    zdbm.DisplayMember = "Text";
        //    zdbm.ValueMember = "Value";
        //    zdbm.DataSource = items; 
        //}
        /// <summary>
        /// 初始化支付类别
        /// </summary>
        public void initzflb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("住院（或生育分娩住院）","31"));
            items.Add(new ListItem("计划生育手术住院","32"));
           // 11：普通门诊；18：特殊门诊；31：住院（或生育分娩住院）；32：计划生育手术住院；37：转院
            items.Add(new ListItem("普通住院", "12"));
            // items.Add(new ListItem("37", "转院"));
            cmbPayType.DisplayMember = "Text";
            cmbPayType.ValueMember = "Value";
            cmbPayType.DataSource = items;
        }
        /// <summary>
        /// 提取信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            if (!GetPersonalInformation())
            {
                return;
            }
        }
        /// <summary>
        /// 获得个人信息
        /// </summary>
        public bool GetPersonalInformation()
        {
            //if (rbck.Checked == true)
            //{
            //    if (tbxgysyb_kh.Text.Trim().Equals("") || tbxgysyb_mm.Text.Trim().Equals(""))
            //    {
            //        MessageBox.Show("请先输入密码");
            //        return false;
            //    }

            //}
            Hqgrxx hqgrxx = new Hqgrxx();
            string instr = "";
            //GysybInterface gysybface = new GysybInterface();
            string ksxsdysj = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");//待遇开始享受时间
            ReadYbCard_entity readybcard = new ReadYbCard_entity();

            string[] parm = new string[11];
            instr += hqgrxx.Hqgrxx_head();

            if (rbck.Checked == true)
            {

                readybcard.CarType = "1";
                readybcard.cardId = tbxCardno.Text;
                readybcard.SzPasswd = tbxCardPwd.Text;

            }
            else if (rbidk.Checked == true)
            {
                if (readybcard.Icd_Id.Equals(""))
                {
                    MessageBox.Show("请输入身份证");
                    return false;
                }
                readybcard.CarType = "3";
                readybcard.cardId = tbxCardno.Text;
                readybcard.SzPasswd = tbxCardPwd.Text;
                readybcard.Icd_Id = tbxIDNo.Text;
            }

            if (!Dqybk(readybcard))
            {
                MessageBox.Show(readybcard.IERRInfo);
                return false;
            }



            //parm[0] = "2";// readybcard.CarType;  //卡类别
            //parm[1] = "A18210279";// readybcard.cardId; //磁条数据
            //parm[2] = "520102198507243826";// readybcard.icd_Id;////社保卡卡号
            //parm[3] = "192.168.5.233";// readybcard.ZdIp;//终端机IP地址(可选)
            //parm[4] = "529900822327";// readybcard.PSAMkh;//PASM卡号  529900822327
            //parm[5] = "111111";//readybcard.SzPasswd;//密码
            //parm[6] = cmbgysyb_zflb.SelectedValue.ToString();//支付类别
            //parm[7] = cmbgysyb_bxlb.SelectedValue.ToString();//保险类别
            //parm[8] = "";//特种病编码(不确定)
            //parm[9] = "";//工伤认定编号
            //parm[10] = ksxsdysj;//待遇开始享受时间


            parm[0] = readybcard.CarType;  //卡类别
            parm[1] = readybcard.cardId; //磁条数据
            parm[2] = readybcard.icd_Id;////社保卡卡号
            parm[3] = "10.169.14.117";// readybcard.ZdIp;//终端机IP地址(可选)
            parm[4] = readybcard.PSAMkh;//PASM卡号  529900822327
            parm[5] = readybcard.SzPasswd;//密码
            parm[6] = cmbPayType.SelectedValue.ToString();//支付类别
            parm[7] = cmbInsurType.SelectedValue.ToString();//保险类别
            parm[8] = "";//特种病编码(不确定)
            parm[9] = tbxIndrsInjuryCode.Text;//tbxgysyb_fsxx.Text;//工伤认定编号
            parm[10] = ksxsdysj;//待遇开始享受时间



            //parm[0] = readybcard.CarType;  //卡类别
            //parm[1] = readybcard.cardId; //磁条数据
            //parm[2] = readybcard.cardId;////社保卡卡号
            //parm[3] = readybcard.ZdIp;//终端机IP地址(可选)
            //parm[4] = readybcard.PSAMkh;//PASM卡号
            //parm[5] = readybcard.SzPasswd;//密码
            //parm[6] = cmbgysyb_zflb.SelectedValue.ToString();//支付类别
            //parm[7] = cmbgysyb_bxlb.SelectedValue.ToString();//保险类别
            //parm[8] = "";//特种病编码(不确定)
            //parm[9] = "";//工伤认定编号
            //parm[10] = ksxsdysj;//待遇开始享受时间



            instr += hqgrxx.Hqgrxx_in(parm);
            instr += hqgrxx.Hqgrxx_tail();

            string outxml = gysybservice.getInfo(instr);

            SysWriteLogs.writeLogs1("贵阳市医院身份信息", Convert.ToDateTime(BillSysBase.currDate()), outxml);
            StringReader sd = new StringReader(outxml);
            DataSet ds = new DataSet();
            ds.ReadXml(sd);
            string ztm = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            if (ztm.Equals("-1"))
            {
                outxml = gysybservice.getInfo(instr);
                sd = new StringReader(outxml);
                ds.ReadXml(sd);
                ztm = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();
                if (ztm.Equals("-1"))
                {
                    outxml = gysybservice.getInfo(instr);
                    sd = new StringReader(outxml);
                    ds.ReadXml(sd);
                    ztm = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();
                    if (ztm.Equals("-1"))
                    {
                        MessageBox.Show(ds.Tables["DATA"].Rows[0]["INFO"].ToString()); //错误信息
                        return false;
                    }
                }
            }
            string PERSONCODE = ds.Tables["DATA"].Rows[0]["PERSONCODE"].ToString();//个人编码  
            tbxPersonalNum.Text = PERSONCODE;//个人编码
            string CENTERCODE = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码
            tbCenterCode.Text = CENTERCODE;//分中心编码
            string PERSONNAME = ds.Tables["DATA"].Rows[0]["PERSONNAME"].ToString();//姓名
            tbxName.Text = PERSONNAME;//姓名
            string SEX = "";
            if (ds.Tables["DATA"].Rows[0]["SEX"].ToString().Equals("1"))  //性别
            {
                SEX = "男";

            }
            else if (ds.Tables["DATA"].Rows[0]["SEX"].ToString().Equals("2"))
            {
                SEX = "女";
            }
            else if (ds.Tables["DATA"].Rows[0]["SEX"].ToString().Equals("9"))
            {
                SEX = "未说明性别";
            }
            tbxSex.Text = SEX;//性别

            string PID = ds.Tables["DATA"].Rows[0]["PID"].ToString();//身份证号码
            tbxIDNo.Text = PID;//身份证号码
            string BIRTHDAY = ds.Tables["DATA"].Rows[0]["BIRTHDAY"].ToString();//出生日期
            dtpBirth.Text = BIRTHDAY;//出生日期
            string PERSONTYPE = ds.Tables["DATA"].Rows[0]["PERSONTYPE"].ToString();//人员类别
            tbxPersonalType.Text = getRylb(PERSONTYPE); //PERSONTYPE;//人员类别
            string INSURETYPE = ds.Tables["DATA"].Rows[0]["INSURETYPE"].ToString();//保险类别
            string CAREPSNFLAG = ds.Tables["DATA"].Rows[0]["CAREPSNFLAG"].ToString();//医疗照顾人员标志
            tbxCarePeople.Text = CAREPSNFLAG;//医疗照顾人员标志
            string DEPTCODE = ds.Tables["DATA"].Rows[0]["DEPTCODE"].ToString();//单位编码
            tbxCompanyNum.Text = DEPTCODE;//单位编码
            string DEPTNAME = ds.Tables["DATA"].Rows[0]["DEPTNAME"].ToString();//单位名称
            tbxCompanyName.Text = DEPTNAME;//单位名称
            string ACCTBALANCE = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//账户余额
            tbxBalance.Text = ACCTBALANCE;//账户余额
            string HOSPTIMES = ds.Tables["DATA"].Rows[0]["HOSPTIMES"].ToString();//本年住院次数
            tbxgysyb_zycs.Text = HOSPTIMES;//本年住院次数
            string STARTFEE = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
            tbxgysyb_qfx.Text = STARTFEE;//本次起付线
            string STARTFEEPAID = ds.Tables["DATA"].Rows[0]["STARTFEEPAID"].ToString();//本年已支付起付线
            tbxgysyb_yzfqfx.Text = STARTFEEPAID;//本年已支付起付线
            string FUND1LMT = ds.Tables["DATA"].Rows[0]["FUND1LMT"].ToString();//基本统筹限额
            tbxgysyb_jbtcxe.Text = FUND1LMT;//基本统筹限额
            string FUND1PAID = ds.Tables["DATA"].Rows[0]["FUND1PAID"].ToString();//本年已支付基本统筹
            tbxgysyb_tczflj.Text = FUND1PAID;//本年已支付基本统筹(统筹支付累计)
            string FUND2LMT = ds.Tables["DATA"].Rows[0]["FUND2LMT"].ToString();//大额统筹限额
            tbxgysyb_detcxe.Text = FUND2LMT;//大额统筹限额
            string FUND2PAID = ds.Tables["DATA"].Rows[0]["FUND2PAID"].ToString();//本年已支付大额统筹
            tbxgysyb_dezflj.Text = FUND2PAID;//本年已支付大额统筹(大额支付累计)
            string FUND3LMT = ds.Tables["DATA"].Rows[0]["FUND3LMT"].ToString();//本年普通门诊医疗补助限额
            tbxgysyb_ptmzylbzxe.Text = FUND3LMT;//本年普通门诊医疗补助限额
            string FUND3PAID = ds.Tables["DATA"].Rows[0]["FUND3PAID"].ToString();//本年普通门诊医疗补助累计
            tbxgysyb_ptmzylbzlj.Text = FUND3PAID;//本年普通门诊医疗补助累计
            string STARTFEE2STD = ds.Tables["DATA"].Rows[0]["STARTFEE2STD"].ToString();//普通门诊医疗补助起付标准
            tbxgysyb_ptmzylbzqfbz.Text = STARTFEE2STD;//普通门诊医疗补助起付标准
            tbxgysyb_ptmzylbzqfx.Text = STARTFEE2STD;//普通门诊医疗补助起付线
            string FUND75BALANCE = ds.Tables["DATA"].Rows[0]["FUND75BALANCE"].ToString();//普通门诊医疗补助结转可使用金额
            tbxgysyb_ptmzylbzjzksy.Text = FUND75BALANCE;//普通门诊医疗补助结转可使用金额
            string LOCKINFO = ds.Tables["DATA"].Rows[0]["LOCKINFO"].ToString();//封锁信息
            tbxgysyb_fsxx.Text = LOCKINFO;//封锁信息
            string NOTE = ds.Tables["DATA"].Rows[0]["NOTE"].ToString();//备注
            tbxgysyb_bz.Text = NOTE;//备注


            tbxPayYear.Text = "";//缴费年度                                                                                                                                                      

            //this.gyyb.Klb = readybcard.CarType;//卡类别
            //this.gyyb.Ctsj = readybcard.cardId;//磁条数据
            //this.gyyb.Shbxh = readybcard.cardId;//社会保障号
            //this.gyyb.ZdjIPdz = readybcard.ZdIp;//终端机IP地址(可选)
            //this.gyyb.PASMkh1 = readybcard.PSAMkh;//PASM卡号
            //this.gyyb.Mm = readybcard.SzPasswd;//密码
            //this.gyyb.Zflb = cmbgysyb_zflb.SelectedValue.ToString();//支付类别
            //this.gyyb.Bxlb = cmbgysyb_bxlb.SelectedValue.ToString();//保险类别
            string aa = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();                                                     
            this.sybdk_entity.Xtclsj = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            this.sybdk_entity.Grbh = PERSONCODE;//个人编码
            this.sybdk_entity.Fzxbm = CENTERCODE;//分中心编码
            this.sybdk_entity.Xm = PERSONNAME;//姓名
            this.sybdk_entity.Xb = SEX;//性别
            this.sybdk_entity.Sfzhm = PID;//身份证号码
            this.sybdk_entity.Csrq = BIRTHDAY;//出生日期
            this.sybdk_entity.Rylb = PERSONTYPE;//人员类别
            this.sybdk_entity.RylbName = tbxPersonalType.Text;//人员类别名称
            this.sybdk_entity.Bxlb = INSURETYPE;//保险类别
            this.sybdk_entity.Ylzgrybz = CAREPSNFLAG;//医疗照顾人员标志
            this.sybdk_entity.Dwbm = DEPTCODE;//单位编码
            this.sybdk_entity.Dwmc = DEPTNAME;//单位名称
            this.sybdk_entity.Zhye = ACCTBALANCE;//账户余额
            this.sybdk_entity.Bnzycs = HOSPTIMES;//本年住院次数
            this.sybdk_entity.Bcqfx = STARTFEE;//本次起付线
            this.sybdk_entity.Bnyzfdetc = STARTFEEPAID;//本年已支付起付线
            this.sybdk_entity.Jbtcxe = FUND1LMT;//基本统筹限额
            this.sybdk_entity.Bnyzfdetc = FUND1PAID;//本年已支付基本统筹
            this.sybdk_entity.Detcxe = FUND2LMT;//大额统筹限额
            this.sybdk_entity.Bnyzfdetc = FUND2PAID;//本年已支付大额统筹
            this.sybdk_entity.Bnptmzylbzye = FUND3LMT;//本年普通门诊医疗补助限额
            this.sybdk_entity.Bnptmzylbzlj = FUND3PAID;//本年普通门诊医疗补助累计
            this.sybdk_entity.Ptmzylbzqfbz = STARTFEE2STD;//普通门诊医疗补助起付标准
            this.sybdk_entity.Ptmzylbzjzksyje = FUND75BALANCE;//普通门诊医疗补助结转可使用金额
            this.sybdk_entity.Fsxx = LOCKINFO;//封锁信息
            this.sybdk_entity.Bz = NOTE;//备注
            //this.sybdk_entity.Qsfs = zdbm.SelectedValue.ToString();//清算方式

            this.sybdk_entity.Klb = parm[0];//卡类别
            this.sybdk_entity.Ctsj = parm[1];//磁条数据
            this.sybdk_entity.Mm = parm[5];//密码
            this.sybdk_entity.Zdjipdz = parm[3];//终端机IP地址
            this.sybdk_entity.Pasmkh = parm[4];//pasm卡号
            this.sybdk_entity.Zflb = parm[6];//支付类别
            this.sybdk_entity.Gsrd = tbxIndrsInjuryCode.Text;//工伤认定编号

            //this.sybdk_entity.Sfzhm = readybcard.icd_Id;//社会保障号

            if (checkBoxgskfzy.Checked == true)//工伤康复住院标志
            {
                this.sybdk_entity.Gskfzybz = "1";

            }
            else
            {
                this.sybdk_entity.Gskfzybz = "0";
            }

            return true;

        }
        /// <summary>
        /// 入院类别
        /// </summary>
        /// <param name="rylb"></param>
        /// <returns></returns>
        public String getRylb(string rylb)
        {
            String ret = "";
            if (rylb.Equals("11"))
            {
                ret = "在职";
            }
            else if (rylb.Equals("21"))
            {
                ret = "退休";
            }
            else if (rylb.Equals("32"))
            {
                ret = "省属离休";
            }
            else if (rylb.Equals("34"))
            {
                ret = "市属离休";
            }
            else if (rylb.Equals("41"))
            {
                ret = "普通居民";
            }
            else if (rylb.Equals("42"))
            {
                ret = "低保对象";
            }
            else if (rylb.Equals("43"))
            {
                ret = "三无人员";
            }
            else if (rylb.Equals("44"))
            {
                ret = "低收入家庭";
            }
            else if (rylb.Equals("45"))
            {
                ret = "重度残疾";
            }
            return ret;
        }
        /// <summary>
        /// 读取医保卡号
        /// </summary>
        public bool Dqybk(ReadYbCard_entity readybcard)
        {
            int iCardType = 0;//卡类型
            if (rbck.Checked == true)
            {
                iCardType = 1;
            }
            else if (rbick.Checked == true)
            {
                iCardType = 2;
            }
            else if (rbidk.Checked == true)
            {
                iCardType = 3;
            }
            readybcard.CarType = iCardType.ToString();
            if (!ReadCardYb.ReadCard(readybcard, iCardType))
            {
                return false;
            }
            tbxCardno.Text = readybcard.cardId;//卡号
            tbxCardPwd.Text = readybcard.SzPasswd;//密码
            return true;
        }
        /// <summary>
        /// 工伤信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIndrsInjuryInfo_Click(object sender, EventArgs e)
        {
            if (cmbInsurType.SelectedValue.ToString() == "7")
            {
                StringBuilder message = new StringBuilder();

                //读卡                               

                ReadYbCard_entity readybcard = new ReadYbCard_entity();

                if (rbck.Checked == true)
                {

                    readybcard.CarType = "1";
                    readybcard.cardId = tbxCardno.Text;
                    readybcard.SzPasswd = tbxCardPwd.Text;
                }
                else if (rbidk.Checked == true)
                {
                    if (tbxIDNo.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("请输入身份证");
                        return;
                    }
                    readybcard.CarType = "3";
                    readybcard.cardId = tbxCardno.Text;
                    readybcard.SzPasswd = tbxCardPwd.Text;
                    readybcard.icd_Id = tbxIDNo.Text;
                }

                if (!Dqybk(readybcard))
                {
                    MessageBox.Show(readybcard.IERRInfo);
                    return;
                }
                string[] param = new string[7];

                param[0] = readybcard.CarType;  //卡类别
                param[1] = readybcard.cardId; //磁条数据
                param[2] = readybcard.icd_Id;////社保卡卡号
                param[3] = "192.168.0.52";// readybcard.ZdIp;//终端机IP地址(可选)
                param[4] = readybcard.PSAMkh;//PASM卡号  
                param[5] = readybcard.SzPasswd;//密码
                param[6] = cmbPayType.SelectedValue.ToString();//支付类别

                List<Gsrdxx> gsrdxxs = gysybservice.Hqgrxx(param ,message);
                if (gsrdxxs.Count == 0)
                {
                    MessageBox.Show(message.ToString());
                    return;
                }
                else
                {
                    dataGridViewgsrd.DataSource = gsrdxxs;
                    dataGridViewgsrd.Visible = true;
                }
                return;
            }
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.sybdk_entity.Zdmc = textBoxryzdname.Text;
            this.sybdk_entity.Zdicd = textBoxicdcode.Text;
            
            if (this.sybdk_entity.Xm.Trim() != TextBoxxm) //处方患者姓名与医保卡持有者姓名不一致判断
            {
                MessageBox.Show(string.Format(@"就诊卡患者姓名与医保卡持有者不一致，请确认！(就诊卡患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", TextBoxxm, this.sybdk_entity.Xm.Trim()));
                this.flag = false;
                this.Dispose();
                return;
            }

            if (this.sfzfzyb)
            {
                //说明是自费转医保患者直接调用入院登记函数
                sybzfzyb();
            }

            if (tbxPersonalNum.Text.Equals(""))
            {
                this.flag = false;
                this.Dispose();
            }
            else
            {
                this.flag = true;
                this.Dispose();

            }
        }

        //自费转医保
        public void sybzfzyb()
        {
            BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
            DataTable dt = bllInsurGYSYB.getIhspInfo(mtzyjl_iid);
            sybdk_entity.Ks = dt.Rows[0]["depart"].ToString();
            sybdk_entity.Ys = dt.Rows[0]["doctor"].ToString();
            sybdk_entity.Ryrq = dt.Rows[0]["indate"].ToString();

            StringBuilder msg = new StringBuilder();
            if (!bllInsurGYSYB.insurRegist(mtzyjl_iid, Mtzyjl_zyh, msg, sybdk_entity))
            {
                MessageBox.Show("调用市医保动态库，办理入院登记返回失败，动态库返回错误信息为：" + msg.ToString());
                return;
            }
            //入院登记成功，更新his数据
            MessageBox.Show("医保住院登记成功!", "提示信息");
            int flag = bllInsurGYSYB.upSybRyInfo(mtzyjl_iid, patientType, sybdk_entity);
                if (flag < 0)
                {
                    MessageBox.Show("更新患者信息失败!");
                    return;
              }
          
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.flag = false;
            this.Dispose();
        }
        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbidk_CheckedChanged(object sender, EventArgs e)
        {
            tbxCardno.ReadOnly = true;
            tbxCardPwd.ReadOnly = false;
            tbxIDNo.ReadOnly = false;
        }
        /// <summary>
        /// ic卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbick_CheckedChanged(object sender, EventArgs e)
        {
            tbxCardno.ReadOnly = true;
            tbxCardPwd.ReadOnly = true;
            tbxIDNo.ReadOnly = true;
        }
        /// <summary>
        /// 磁卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbck_CheckedChanged(object sender, EventArgs e)
        {
            tbxCardno.ReadOnly = false;
            tbxCardPwd.ReadOnly = false;
            tbxIDNo.ReadOnly = false;
        }

        /// <summary>
        /// 入院诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxryzdname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //简码查询icd
                DataTable dt = bllInsur.getIcdInfo(textBoxryzdname.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dgvwdybryzd.Visible = true;
                    dgvwdybryzd.BringToFront();
                    dgvwdybryzd.DataSource = dt;
                    dgvwdybryzd.Columns["ryzd_icdname"].Width = 161;
                    dgvwdybryzd.Rows[0].Selected = true;
                    dgvwdybryzd.Focus();
                }
                else
                {
                    dgvwdybryzd.Visible = false;
                }
            }
        }

        /// <summary>
        /// 入院诊断疾病信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvwdybryzd_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvwdybryzd.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvwdybryzd.CurrentRow != null)
                {
                    textBoxryzdname.Text = dgvwdybryzd.CurrentRow.Cells["ryzd_icdname"].Value.ToString();
                    textBoxicdcode.Text = dgvwdybryzd.CurrentRow.Cells["ryzd_icdcode"].Value.ToString();
                    dgvwdybryzd.Visible = false;
                    dgvwdybryzd.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvwdybryzd.CurrentRow != null && dgvwdybryzd.CurrentRow.Index > 0)
                {
                    dgvwdybryzd.Rows[dgvwdybryzd.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvwdybryzd.CurrentRow != null && dgvwdybryzd.CurrentRow.Index < dgvwdybryzd.Rows.Count - 1)
                {
                    dgvwdybryzd.Rows[dgvwdybryzd.CurrentRow.Index + 1].Selected = true;
                }
            }
        }
        /// <summary>
        /// //工伤信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewgsrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridViewgsrd.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dataGridViewgsrd.CurrentRow != null)
                {
                    tbxIndrsInjuryCode.Text = dataGridViewgsrd.SelectedRows[0].Cells["gsrdbm"].Value.ToString();
                    dataGridViewgsrd.Visible = false;
                    dataGridViewgsrd.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dataGridViewgsrd.CurrentRow != null && dataGridViewgsrd.CurrentRow.Index > 0)
                {
                    dataGridViewgsrd.Rows[dataGridViewgsrd.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dataGridViewgsrd.CurrentRow != null && dataGridViewgsrd.CurrentRow.Index < dataGridViewgsrd.Rows.Count - 1)
                {
                    dataGridViewgsrd.Rows[dataGridViewgsrd.CurrentRow.Index + 1].Selected = true;
                }
            }
        }

    }
}
