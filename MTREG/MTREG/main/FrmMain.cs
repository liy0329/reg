/*************************************************************************************
     * CLR版本：       2.0.50727.4927
     * 类 名 称：       FrmMain
     * 机器名称：       wzw-PC
     * 命名空间：       MTHIS
     * 文 件 名：       FrmMain
     * 创建时间：       2016/7/15 8:16:31
     * 作    者：       王中文
     * 说    明：       MDI主窗体
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
using System.Windows.Forms;
using MTHIS.sys;
using MTHIS.db;
using MTHIS.help;
using MTHIS.main.bll;
using MTHIS.common;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MTHIS.tools;
using MTREG.ihsp;
using MTREG.clinic;
using MTREG.clinic.bll;
using MTREG.main.bo;
using MTREG.clintab;
using MTREG.clintab.bll;
using MTREG.clintab;
using MTREG.ihsp;
using MTREG.ihspqty;
using MTREG.medinsur.hdyb;
using MTREG.medinsur;
using MTREG.medinsur.hsdryb;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.gzsyb.nh;
using MTREG.kls;
using Apache.NMS;
using mtcalling.tools;
using Apache.NMS.ActiveMQ;
using MTREG.netpay;
using MTREG.ihsptab;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb;
using MTREG.medinsur.sjzsyb.bean;
using MTREG;
using MTREG.gsbx.bll;
using MTREG.gsbx;
using MTREG.medinsur.sjzsyb.clinic;
using zhongluyiyuan.gsbx;
using System.Threading;
using TimerTask;

namespace MTHIS
{
    public partial class FrmMain : Form
    {
        string[] mainArgs = null;
        private static yh_interface.CoClass_n_yh_interfacebaseClass yhInterface = null;
        private List<AccMenu> accmemus;
        private string userName;
        private FrmLogin frmLogin;
        public FrmLogin FrmLogin
        {
            get { return frmLogin; }
            set { frmLogin = value; }
        }


        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public FrmMain()
        {
            this.WindowState = FormWindowState.Normal;
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">用户名</param>
        public FrmMain(string name, string[] Args)
        {
            InitializeComponent();
            this.userName = name;
            mainArgs = Args;
        }
        public bool ybsyqx()
        {
            upVersionChk();
            if (ProgramGlobal.VersionChk == "N")
            {
                MessageBox.Show("版本已经在" + ProgramGlobal.Limitdate + "过期!");
                return false;
            }
            else if (ProgramGlobal.VersionChk == "Y")
            {
                DateTime startDate = DateTime.Now;
                DateTime endDate = Convert.ToDateTime(ProgramGlobal.Limitdate);
                if (endDate.Year * 12 + endDate.Month - startDate.Year * 12 - startDate.Month < 2)
                {
                    MessageBox.Show("版本将在" + ProgramGlobal.Limitdate + "过期!请及时联系工作痢人员进行维护!");
                    return true;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        //窗口加载
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = imgUtils.getImage("BgImg.jpg");
            this.IsMdiContainer = true;
            //timer1.Start();
            this.statUserInfo.Items[0].TextAlign = ContentAlignment.MiddleLeft;
            this.statUserInfo.Items[0].Text = "用户单位:" + ProgramGlobal.HspName;
            this.statUserInfo.Items[1].Text = " | ";
            this.statUserInfo.Items[2].Text = "科  室:" + ProgramGlobal.DepartName;
            this.statUserInfo.Items[3].Text = " | ";
            this.statUserInfo.Items[4].Text = "用户名:" + ProgramGlobal.Nickname;
            this.statUserInfo.Items[5].Text = " | ";
            this.statUserInfo.Items[6].Text = DateTime.Now.ToString();
            initMenu();
            inittool();

            string sfmzyb = IniUtils.IniReadValue(IniUtils.syspath, "MZPZ", "MZYB");
            if (sfmzyb == "1")
            {
                Signin();
            }
            TimerTask();
        }
        /// <summary>
        /// 定时任务
        /// 医保对账
        /// </summary>
        private void TimerTask()
        {
            TimerInfo timerInfo = new TimerInfo();
            string Start = IniUtils.IniReadValue(IniUtils.syspath, "TimerTask", "Start");
            if (Start.ToUpper().Equals("TRUE"))
            {
                string TimerType = IniUtils.IniReadValue(IniUtils.syspath, "TimerTask", "TimerType");
                if (TimerType.Equals("EveryDay"))
                {
                    string Hour = IniUtils.IniReadValue(IniUtils.syspath, "TimerTask", "Hour");
                    string Minute = IniUtils.IniReadValue(IniUtils.syspath, "TimerTask", "Minute");
                    string Second = IniUtils.IniReadValue(IniUtils.syspath, "TimerTask", "Second");

                    timerInfo.TimerType = "EveryDay";
                    timerInfo.Hour = int.Parse(Hour);
                    timerInfo.Minute = int.Parse(Minute);
                    timerInfo.Second = int.Parse(Second);

                }

                //第一次调用方法，【1121】医疗费信息对账（明细）
                TimingTask test1 = new TimingTask();
                TimerTaskDelegate trd = new TimerTaskDelegate(test1.Reconciliation);
                //创建定时任务线程
                Thread ThreadTimerTaskService1 = TimerTaskService.CreateTimerTaskService(timerInfo, trd);
                ThreadTimerTaskService1.Start();

                //第二种调用方法
                TimingTask test2 = new TimingTask();
                ParmTimerTaskDelegate ptrd = new ParmTimerTaskDelegate(test2.DownloadDirectory);
                object[] p = new object[] { "1", "2" };
                //创建定时任务线程
                Thread ThreadTimerTaskService2 = TimerTaskService.CreateTimerTaskService(timerInfo, ptrd, p);
                ThreadTimerTaskService2.Start();
            }
        }
        /// <summary>
        /// 检查是否有相同的窗口
        /// </summary>
        /// <param name="frm">需要检测的窗口</param>
        /// <returns>true : 已存在   false : 不存在 </returns>
        private bool isOpen(Form frm)
        {
            foreach (Form frmTemp in this.MdiChildren)
            {
                if (frm.Text == frmTemp.Text)
                {
                    frmTemp.Activate();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 菜单点击事件  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void windowNewMenu_Click(object sender, EventArgs e)
        {
            string itemName = ((ToolStripMenuItem)sender).Text.Trim();
            menuSelected(itemName);
        }
        void windowTools_Click(object sender, EventArgs e)
        {
            string itemName = ((ToolStripButton)sender).Name.Trim();
            menuSelected(itemName);
        }
        void menuSelected(string itemName)
        {
            Form newFrm = null;
            switch (itemName)
            {
                case "医保费用上传":
                    newFrm = new frmZyybfysc();
                    break;
                case "城乡费用上传":
                    newFrm = new frmZycjfysc();
                    break;
                case "费用上传设置":
                    newFrm = new Frm_Xtpz();
                    break;
                case "门诊挂号":
                    newFrm = new FrmClinicReg();
                    break;
                //case "城乡报销":
                //    newFrm = new frmMZcj();
                //    break;
                case "先结后报":
                    newFrm = new frmXJHB();
                    break;
                case "担保统计":
                    newFrm = new Frm_mainDbcx();
                    break;
                //case "职工报销":
                //    newFrm = new frmMzybzg();
                //    break;
                case "打印腕带":
                    newFrm = new FrmprintWristband();
                    break;
                case "门诊充值挂号":
                    newFrm = new FrmMemberReg();
                    break;
                case "处方收费":
                    newFrm = new FrmClinicRcpCost();
                    break;
                case "手工收费":
                    newFrm = new FrmClinicCost();
                    break;
                case "工伤门诊":
                    newFrm = new zhongluyiyuan.gsbx.Frmgsmz();
                    break;
                case "收费管理":
                    newFrm = new FrmClinicCostManage();
                    break;
                case "收费管理(财务)":
                    newFrm = new FrmClinicCostManage_cw();
                    break;
                case "退费管理":
                    newFrm = new FrmCliniCostRetFeeManage();
                    break;
                case "读取人员信息":
                    newFrm = new FrmMzYbdk();
                    break;
                case "市医保撤销":
                    newFrm = new FrmGysybInsurRefund();
                    break;
                case "省医保撤销":
                    newFrm = new FrmGzsybInsurRefund();
                    break;
                //case "退费解锁":
                case "发票解锁":
                    newFrm = new FrmUnlockRcpManage();
                    break;
                case "门诊日结":
                    newFrm = new FrmClicTab();
                    break;
                case "门诊班结":
                    newFrm = new FrmClicDuty();
                    break;
                case "门诊日结管理":
                    newFrm = new FrmClicTabManage();
                    break;
                case "门诊班结管理":
                    newFrm = new FrmClicDutyManage();
                    break;
                case "门诊科室核算":
                    newFrm = new FrmDepartAccount();
                    break;
                case "门诊医生核算":
                    newFrm = new FrmClicAdjustbydoctor();
                    break;
                case "门诊结算后情况":
                    newFrm = new FrmClicAfterinfo();
                    break;
                case "个人门诊费用明细查询":
                    newFrm = new FrmDetailedquery();
                    break;

                case "门诊查询":
                    newFrm = new FrmClicDaily();
                    break;


                case "住院管理":
                    newFrm = new FrmIhspInhsp();
                    break;
                case "出院管理":
                    newFrm = new FrmIhspOuthsp();
                    break;
                case "出院管理(财务)":
                    newFrm = new FrmIhspOuthsp_cw();
                    break;
                case "回退审批":
                    newFrm = new FrmIhspChkRetSetle();//结算回退审批
                    break;
                case "挂号管理":
                    newFrm = new FrmClinicRegManage();
                    break;
                case "退费确定":
                    newFrm = new FrmIhspRetfeeChk();
                    break;
                case "会员卡管理":
                    newFrm = new FrmClinicMember();
                    break;
                case "会员卡结算":
                    newFrm = new FrmMemberSett();
                    break;
                case "住院日结":
                    newFrm = new FrmIhspQtyInhsp(accmemus);
                    //newFrm = new FrmHspTab();
                    break;
                case "住院日结管理":
                    newFrm = new FrmHspTabManage();
                    break;
                case "住院班结管理":
                    newFrm = new FrmIhspDutyManage();
                    break;
                case "住院班结":
                    newFrm = new FrmIhspDuty();
                    break;
                case "住院结算后情况":
                    newFrm = new FrmHspAfterinfo();
                    break;
                case "住院科室核算":
                    newFrm = new FrmHspAdjustByDepart();
                    break;
                case "住院医生核算":
                    newFrm = new FrmHspAdjustByDoctor();
                    break;
                case "词典对照":
                    newFrm = new FrmInsurtype();
                    break;
                case "科室下载":
                    newFrm = new FrmDepartments();
                    break;
                case "医师下载":
                    newFrm = new FrmDoctor();
                    break;
                case "病种目录下载":
                    newFrm = new FrmDisease();
                    break;
                case "医保卡管理":
                    newFrm = new FrmCard();
                    break;
                case "设定门诊定点":
                    newFrm = new FrmclinicPoint();
                    break;
                case "激活UKey":
                    newFrm = new Frmactivation();
                    break;
                case "医保对账（明细）":
                    newFrm = new FrmYlFyMxDz();
                    break;
                case "医保对账":
                    newFrm = new frmDuizhang();
                    break;
                case "病种对照":
                    newFrm = new FrmgDiseases();
                    break;
                case "三目下载":
                    newFrm = new FrmDownloadDirectory();
                    break;
                case "个人慢性(或特殊)病审批信息查询":
                    newFrm = new Frmgrmxbspxxcx();
                    break;
                case "异地就医急诊住院申报信息查询":
                    newFrm = new Frmydjyjzzysbxxcx();
                    break;
                case "病种可用三目范围下载":
                    newFrm = new Frmbzkysmfwxz();
                    break;
                case "结算信息下载":
                    newFrm = new FrmSettlementInfo();
                    break;
                case "三目申报":
                    newFrm = new Frmrelationship();
                    break;
                case "三目对照关系下载":
                    newFrm = new FrmDownloadContrast();
                    break;
                case "批量预结算":
                    newFrm = new FrmCostTransfer();
                    break;
                case "工伤项目对照":
                    newFrm = new FrmGsxmdz();
                    break;
                case "批量获取工伤信息":
                    newFrm = new Frmgsplhq();
                    break;
                case "医保管理":
                    //newFrm = new FrmInsurManage();
                    break;
                case "武邑签到":
                    newFrm = new FrmSign();
                    break;
                case "住院查询":
                    newFrm = new FrmIhspQtyInhsp(accmemus);
                    break;
                case "交预付款":
                    newFrm = new FrmIhspInhsp(true);
                    break;
                case "关于":
                    newFrm = new FrmAbout();
                    break;
                case "帮助文档":
                    Process.Start(Application.StartupPath + "\\帮助文档\\收费接口操作文档.CHM");
                    break;
                case "打印配置":
                    newFrm = new FrmFpdysz(); //FrmPrint();
                    break;
                case "系统设置":
                    newFrm = new Frmxtsz(); //FrmPrint();
                    break;
                case "腕带配置":
                    newFrm = new FrmPrintSetting(); //FrmPrint();
                    break;
                case "系统初始化":
                    newFrm = new FrmSysInit();
                    break;
                case "数据源配置":
                    newFrm = new FrmDBConnectionConfiguration();
                    break;
                //case "医保病人查询":
                //    newFrm = new FrmYbBrcx();
                //    break;

                case "市医保报补单打印":
                    newFrm = new FrmSybbbddcx();
                    break;

                case "省报补单打印":
                    newFrm = new Frm_JSD();
                    break;

                case "市医保特殊结算查询":
                    newFrm = new FrmSybTsMzJsCx();
                    break;

                case "市医保普通结算查询":
                    newFrm = new FrmSybMzJxCx();
                    break;

                case "农合报补单打印":
                    newFrm = new frmnhjsddy();
                    break;

                case "省医保清算申请":
                    newFrm = new Frm_Sybqssq();
                    break;

                case "省医保清算查询":
                    newFrm = new Frm_Qssqcx();
                    break;

                case "省医保结算查询":
                    newFrm = new Frm_ydjscxall();
                    break;

                case "农合目录下载":
                    newFrm = new Frmxzyp();
                    break;

                case "医保目录更新":
                    newFrm = new Frmxzybml();
                    break;

                case "完善医保诊断":
                    newFrm = new FrmMain2();
                    break;

                case "医保错误处理":
                    newFrm = new FrmCxcwTscl();
                    break;
                case "支付管理":
                    newFrm = new FrmNetPayManage();
                    break;

                case "注销登录":
                    if (!qiantui())//程序退出时用户签退
                    {
                        break;
                    }
                    this.frmLogin.Show();
                    this.Dispose();
                    this.Close();
                    break;
                case "修改密码":
                    newFrm = new FrmChangePwd();
                    break;
                case "退出":
                    //if (chuliyb())//程序退出时用户签退
                    //{
                    //    break;
                    //}
                    this.Dispose();
                    this.Close();
                    Application.Exit();
                    break;
            }
            if (newFrm == null)
                return;
            if (!itemName.Equals("退出") && !itemName.Equals("注销登录"))
            {
                List<string> menus = getmenuNormalName();
                //单例模式
                if (!isOpen(newFrm))
                {
                    newFrm.MdiParent = this;
                    newFrm.Text = itemName;
                    newFrm.WindowState = FormWindowState.Normal;

                    for (int i = 0; i < menus.Count; i++)
                    {
                        if (newFrm.Text == menus[i].ToString())
                        {

                            newFrm.StartPosition = FormStartPosition.Manual;
                            if (newFrm.Text == "住院日结")
                            {
                                newFrm.WindowState = FormWindowState.Maximized;
                            }
                            
                            else
                            {
                                newFrm.WindowState = FormWindowState.Normal;
                                newFrm.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
                            }
                            newFrm.Show();
                            return;
                        }
                    }

                    newFrm.Show();
                }
                else
                {
                    for (int i = 0; i < menus.Count; i++)
                    {
                        if (newFrm.Text == menus[i].ToString())
                        {
                            newFrm.WindowState = FormWindowState.Normal;
                            newFrm.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
                            break;
                        }
                    }

                }

            }

        }


        /// <summary>
        /// 用户退出系统时都要签退
        /// </summary>
        /// <returns></returns>
        public bool qiantui()
        {
            Sjzsyb sjzsyb = new Sjzsyb();
            Sjzsyb_IN in1 = new Sjzsyb_IN();
            in1.Yw = "1503";
            in1.Rc = in1.Request_head()
                            + "<AAE140>0</AAE140>"//险种类型 0-医保
                            + "<AAC001></AAC001>"//患者识别信息 个人编号/卡号/身份证号，有卡此值传 0，无卡传值
                            + "<AKB020>H001</AKB020>"//定点医疗机构编码 
                            + "<MSGNO>1501</MSGNO>"// 交易代码 
                            + "<MSGID>130100H00120151013121501</MSGID>"// 发送方交易流水号 
                            + "<GRANTID>H0017LPX79T56U</GRANTID>"// 授权码 
                            + "<OPERID>" + ProgramGlobal.User_id + "</OPERID>"// 操作员编号 
                            + "<OPERNAME>" + ProgramGlobal.Nickname + "</OPERNAME>"// 操作员姓名
                            + "<OPTTIME>20151013120000</OPTTIME>"// 系统时间(转时间戳) 
                            + in1.Request_foot();

            int opstat = sjzsyb.ybcjhs(in1);
            DataSet ds = new DataSet();
            StringReader sr = new StringReader(in1.Cc);
            ds.ReadXml(sr);
            DataTable dt = ds.Tables["RESPONSEDATA"];//所有返回参数
            int returnnum = Convert.ToInt32(dt.Rows[0]["RETURNNUM"].ToString());

            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                string ReturnMsg = dt.Rows[0]["ERRORMSG"].ToString();
                MessageBox.Show("医保签退失败！" + ReturnMsg);
                return false;
            }
            return true;
        }


        /// <summary>
        /// //打开该菜单时定义大小
        /// </summary>
        /// <returns></returns>
        ///
        public List<string> getmenuNormalName()
        {
            List<string> menus = new List<string>();
            menus.Add("处方收费");
            menus.Add("门诊挂号");//打开该菜单时定义大小
            menus.Add("门诊充值挂号");
            menus.Add("住院管理");
            menus.Add("出院管理");
            menus.Add("回退审批");
            menus.Add("省医保撤销");
            menus.Add("市医保撤销");
            menus.Add("支付管理");
            menus.Add("挂号管理");
            menus.Add("会员卡管理");
            menus.Add("会员卡结算");
            menus.Add("住院日结");
            menus.Add("住院班结");
            menus.Add("住院日结管理");
            menus.Add("住院班结管理");
            menus.Add("住院结算后情况");
            menus.Add("住院科室核算");
            menus.Add("交预付款");
            menus.Add("住院医生核算");
            menus.Add("退费确定");
            menus.Add("手工收费");
            menus.Add("收费管理");
            menus.Add("退费管理");
            //menus.Add("退费解锁");
            menus.Add("发票解锁");
            menus.Add("发票解锁");
            menus.Add("门诊日结");
            menus.Add("门诊班结");
            menus.Add("门诊日结管理");
            menus.Add("门诊班结管理");
            menus.Add("门诊科室核算");
            menus.Add("门诊医生核算");
            menus.Add("门诊结算后情况");
            menus.Add("打印配置");
            menus.Add("数据源配置");
            menus.Add("住院查询");
            menus.Add("修改密码");
            menus.Add("词典对照");
            menus.Add("批量预结算");
            menus.Add("医保管理");
            menus.Add("医保签到");


            menus.Add("医保病人查询");
            menus.Add("市医保报补单打印");
            menus.Add("省报补单打印");
            menus.Add("市医保特殊结算查询");
            menus.Add("市医保普通结算查询");
            menus.Add("农合报补单打印");
            menus.Add("省医保清算申请");
            menus.Add("省医保清算查询");
            menus.Add("省医保结算查询");
            menus.Add("农合目录下载");
            menus.Add("医保目录更新");
            menus.Add("完善医保诊断");

            //井陉
            //menus.Add("三目对照关系下载");


            menus.Add("关于");
            return menus;
        }

        /// <summary>
        /// 初始化菜单栏 Write by wzw 2016/7/15 10:49
        /// </summary>
        private void initMenu()
        {
            //系统主菜单数据
            DataSet ds = BllMain.getMenuByUser(null, ProgramGlobal.Account_id);

            // Create a MenuStrip control with a new window.
            // MenuStrip ms = new MenuStrip();

            string mname = "";
            if (accmemus == null)
            {
                accmemus = new List<AccMenu>();
            }
            accmemus.Clear();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                mname = (string)row["name"];
                ToolStripMenuItem windowMenu = new ToolStripMenuItem((string)row["name"]);
                //子菜单数据
                DataSet dssub = BllMain.getMenuByUser(row["id"].ToString(), ProgramGlobal.Account_id);  //子菜单数据
                ToolStripMenuItem windowNewMenu = null; //子菜单
                foreach (DataRow rowsub in dssub.Tables[0].Rows)
                {
                    AccMenu accMenu = new AccMenu();
                    accMenu.Id = rowsub["id"].ToString();
                    accMenu.Name = rowsub["name"].ToString();
                    accMenu.Url = rowsub["url"].ToString();
                    accmemus.Add(accMenu);
                    windowNewMenu = new ToolStripMenuItem((string)rowsub["name"], null, new EventHandler(windowNewMenu_Click));
                    windowMenu.DropDownItems.Add(windowNewMenu);
                }
                // Assign the ToolStripMenuItem that displays 
                // the list of child forms.
                ms.MdiWindowListItem = windowMenu;

                // Add the window ToolStripMenuItem to the MenuStrip.
                ms.Items.Add(windowMenu);
            }

            // Dock the MenuStrip to the top of the form.
            // ms.Dock = DockStyle.Top;

            // The Form.MainMenuStrip property determines the merge target.
            //  this.MainMenuStrip = ms;

            // Add the MenuStrip last.
            // This is important for correct placement in the z-order.
            //  this.Controls.Add(ms);
        }
        /// <summary>
        /// 初始化工具栏 writeBy wzw 2016/7/14 19:17
        /// </summary>
        private void inittool()
        {
            // this.toolStrip = new System.Windows.Forms.ToolStrip();
            //this.toolStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Name = "toolStrip1";
            //  this.toolStrip.Size = new System.Drawing.Size(1210, 40);
            this.toolStrip.Text = "toolStrip1";

            //系统菜单数据
            DataSet ds = BllMain.getToolBarByUser(null, ProgramGlobal.Account_id);
            string mname = "";
            string icon = "";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                mname = row["name"].ToString();
                icon = row["icon"].ToString();
                ToolStripButton button = new ToolStripButton();
                if (!string.IsNullOrEmpty(icon))
                {
                    button.Image = imgUtils.getImage(icon.ToString());
                }
                button.ImageTransparentColor = System.Drawing.Color.Magenta;
                button.Name = mname.ToString();
                button.Size = new System.Drawing.Size(46, 32);
                button.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                button.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
                button.Text = mname.ToString();
                button.Click += new System.EventHandler(windowTools_Click);
                button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                ToolStripSeparator separator = new ToolStripSeparator();
                toolStrip.Items.Add(button);
                toolStrip.Items.Add(separator);
            }

            //  this.Controls.Add(this.toolStrip);            
        }
        /// <summary>
        /// 医保签到
        /// </summary>
        public void Signin()
        {
            SJZYB_IN<DBNull> yb_in_qd = new SJZYB_IN<DBNull>();
            Signin_Out yb_out_qd = new Signin_Out();
            SjzybInterface yb_qd = new SjzybInterface();
            yb_in_qd.OPERID = ProgramGlobal.User_id;
            yb_in_qd.OPERNAME = ProgramGlobal.Nickname;
            yb_in_qd.MSGNO = "1501";
            int opstat = yb_qd.Signin(yb_in_qd, ref yb_out_qd);
            if (opstat == 1)
            {

                ProgramGlobal.batno = yb_out_qd.BATNO;
                ProgramGlobal.logintime = DateTime.Now;
                MessageBox.Show("签到成功！");
            }
            else
            {
                MessageBox.Show("签到失败！");
            }
        }
        /// <summary>
        /// 医保签到
        /// </summary>
        public void Signback()
        {
            SJZYB_IN<DBNull> yb_in_qd = new SJZYB_IN<DBNull>();
            SJZYB_OUT yb_out_qd = new SJZYB_OUT();
            SjzybInterface yb_qd = new SjzybInterface();
            yb_in_qd.OPERID = ProgramGlobal.User_id;
            yb_in_qd.OPERNAME = ProgramGlobal.Nickname;
            yb_in_qd.MSGNO = "1503";
            int opstat = yb_qd.Signback(yb_in_qd, ref yb_out_qd);
            if (opstat == 1)
            {
                ProgramGlobal.logintime = DateTime.Now;
                MessageBox.Show("签退成功！");
            }
            else
            {
                MessageBox.Show("签退失败！");
            }
        }
        //程序退出
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string sfmzyb = IniUtils.IniReadValue(IniUtils.syspath, "MZPZ", "MZYB");
            if (sfmzyb == "1")
            {
                Signback();
            }
            this.Dispose();
            Application.Exit();
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statUserInfo.Items[6].Text = DateTime.Now.ToString();
            if (Convert.ToDateTime(statUserInfo.Items[6].Text).Minute % 10 == 0)
            {
                upVersionChk();
                if (ProgramGlobal.VersionChk == "N")
                {
                    statUserInfo.Items[8].Text = "版本已经在" + ProgramGlobal.Limitdate + "过期!";
                }
                else if (ProgramGlobal.VersionChk == "Y")
                {
                    DateTime startDate = DateTime.Now;
                    DateTime endDate = Convert.ToDateTime(ProgramGlobal.Limitdate);
                    if (endDate.Year * 12 + endDate.Month - startDate.Year * 12 - startDate.Month < 2)
                    {
                        statUserInfo.Items[8].Text = "版本将在" + ProgramGlobal.Limitdate + "过期!请及时联系工作人员进行维护!";
                    }
                    else
                    {
                        statUserInfo.Items[8].Text = "";
                    }
                }
            }

        }
        /// <summary>
        /// 更新版本校验状态
        /// </summary>
        private void upVersionChk()
        {
            DataTable dt_version = BllMain.getVersionChk();
            if (dt_version != null)
            {
                ProgramGlobal.VersionChk = dt_version.Rows[0]["ischk"].ToString();
                ProgramGlobal.Limitdate = dt_version.Rows[0]["limitdate"].ToString();
            }
        }

        //连接服务器
        public void InitConsumer()
        {
            //配置文件中取服务器的url
            String serurl = Ini.IniReadValue(Ini.syspath, "netinfo", "serurl");
            //区别那一台服务器的ip地址，从配置文件中取出来
            String calladdr = Ini.IniReadValue(Ini.syspath, "netinfo", "calladdr");
            //创建连接工厂
            IConnectionFactory factory = new ConnectionFactory(serurl);
            //通过工厂构建连接
            IConnection connection = factory.CreateConnection();
            //这个是连接的客户端名称标识
            connection.ClientId = "firstQueueListener";
            //启动连接，监听的话要主动启动连接
            connection.Start();
            //通过连接创建一个会话
            ISession session = connection.CreateSession();
            //通过会话创建一个消费者，这里就是Queue这种会话类型的监听参数设置
            IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"), "filter='self'");
            //注册监听事件

            consumer.Listener += new MessageListener(consumer_Listener);
            //connection.Stop();
            //connection.Close();  

            ////测试java通信
            //IMessageConsumer java = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"));//, "filter='demo'"
            //java.Listener += new MessageListener(java_Listener);

        }
        //设置监听
        void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            //异步调用下，否则无法回归主线程
            //this.dataGridView.Invoke(new DelegateRevMessage(RevMessage), msg);
        }
        //改变界面内容
        public void RevMessage(IMessage message)
        {
            var decode = new Decode();
            string jeson = message.Properties.GetString("message").ToString();
            decode.ProductDetails = jeson;
            string cmd = decode.ProductDetailList["cmd"];
            if (cmd == "PRE_ACCOUNT")
            {
                decode.ProductDetailList["ihsp_id"].ToString();
            }
        }

        private void ms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            if (mainArgs != null && mainArgs[0] == "1")
            {
                menuSelected("门诊挂号");
            }
            else if (mainArgs != null && mainArgs[0] == "2")
            {
                menuSelected("处方收费");
            }
        }
    }
}