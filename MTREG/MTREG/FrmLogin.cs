using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.db;
using MTHIS.main.bll;
using MTHIS.common;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;
using MTHIS.tools;
using MTREG.ihsp.bll;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.gzsyb.bo;
using MTREG.medinsur.gzsnh.bo;
using MTREG.netpay.bo;
using Newtonsoft.Json;
using MTREG.tools;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.ihsp;
using MTHIS.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.clinic.bo;
using MTREG.medinsur.hdyb.dor;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.bean;


namespace MTHIS
{
    public partial class FrmLogin : Form
    {
        string[] mainArgs = null;
        Sjzsyb sjzsyb = new Sjzsyb();
        System.Timers.Timer restult = new System.Timers.Timer();
        Thread thTmp;
        private string thisusername = "";
        public string ThisUserName
        {
            get { return this.thisusername; }
            set { this.thisusername = value; }
        }
        BllMain bllMain = new BllMain();
        public FrmLogin(string[] Args)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            mainArgs = Args;
        }

        //登录
        private void login()
        {
            this.cmenuRight.Items.Add(new ToolStripMenuItem("数据库配置", null, new EventHandler(menuItem_Click)));
            this.cmenuRight.Items.Add(new ToolStripMenuItem("参数配置", null, new EventHandler(menuItem_Click)));
            this.cmenuRight.Items.Add(new ToolStripMenuItem("退出", null, new EventHandler(menuItem_Click)));
            if (tbxAccount.Text == "" || tbxPwd.Text == "")
            {
                tbxAccount.Focus();
                MessageBox.Show("用户名或密码不能为空");
                return;
            }

            DataTable dt = new DataTable();
            try
            {
                dt = BllMain.Db.Select("SELECT id FROM acc_account where isstop='N' and account='" + tbxAccount.Text.Trim() + "'").Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("该用户没有权限!", "提示");
                    tbxAccount.Clear();
                    tbxPwd.Clear();
                    tbxAccount.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接账户或密码不对，请配置HIS数据库连接，重新登录！", "提示信息");
                FrmDBConnectionConfiguration connection = new FrmDBConnectionConfiguration();
                connection.StartPosition = FormStartPosition.CenterParent;
                connection.ShowDialog(this);
                return;
            }

            string sql_user = "SELECT"
                            + " acc_account.id as account_id"
                            + " ,bas_doctor.id as doctor_id"
                            + " ,acc_account.nickname as name"
                            + " ,bas_doctor.name as doctorname"
                            + " ,bas_doctor.workno"
                            + " from acc_account"
                            + " LEFT JOIN bas_doctor on acc_account.doctor_id = bas_doctor.id"
                            + " where "
                            + " acc_account.account = " + DataTool.addFieldBraces(tbxAccount.Text.Trim())
                            + " and acc_account.passwd = " + DataTool.addFieldBraces(this.tbxPwd.Text.Trim())
                            + " and bas_doctor.isstop = 'N'";
            try
            {
                dt = BllMain.Db.Select(sql_user).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("用户名或密码错误!", "提示");
                    tbxPwd.Clear();
                    tbxAccount.Focus();
                    tbxAccount.SelectAll();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("用户名或密码错误!", "提示");
                return;
            }
            string doctor_id = dt.Rows[0]["doctor_id"].ToString();
            string sql_depart = "SELECT"
                             + " bas_depart.id"
                             + ",bas_depart.name"
                             + " from bas_doctor_depart LEFT JOIN bas_depart on bas_doctor_depart.depart_id=bas_depart.id "
                             + " where "
                             + " bas_doctor_depart.isfirst='Y'"
                             + " and bas_doctor_depart.doctor_id = " + DataTool.addFieldBraces(doctor_id);
            DataTable dt_depart = BllMain.Db.Select(sql_depart).Tables[0];

            string sql_hsp = "select hspName"
                             + ",started"
                             + ",startdate"
                             + ",costclass"
                             + ",website"
                             + ",sys_dict.name as hspkind"
                             + " from sys_info"
                             + " left join sys_dict on sys_info.hspkind=sys_dict.keyname and sys_dict.dicttype='sys_hspkind'"
                             ;
            DataTable dt_hsp = BllMain.Db.Select(sql_hsp).Tables[0];

            string sql_config = "select settletype,clininicpay,invoicetype"
                             + " from sys_config";
            DataTable dt_config = BllMain.Db.Select(sql_config).Tables[0];

            DataTable dt_version = BllMain.getVersionChk();
            if (dt_version != null)
            {
                ProgramGlobal.VersionChk = dt_version.Rows[0]["ischk"].ToString();
            }
            thisusername = tbxAccount.Text;
            FrmMain fm = new FrmMain(tbxAccount.Text, mainArgs);
            fm.ybsyqx();

            //string sfmzyb = IniUtils.IniReadValue(IniUtils.syspath, "MZPZ", "MZYB");
            //if (sfmzyb == "1")
            //{
            //    if (!qiandao())
            //    {
            //        MessageBox.Show("医保签到失败", "提示信息");
            //        //return false;
            //    }
            //}

            ProgramGlobal.Ip = IniUtils.IniReadValue(IniUtils.syspath, "netinfo", "ip");
            ProgramGlobal.Calling = IniUtils.IniReadValue(IniUtils.syspath, "syscalling", "calling");
            ProgramGlobal.Calladdr = IniUtils.IniReadValue(IniUtils.syspath, "syscalling", "calladdr");
            ProgramGlobal.Callserverurl = IniUtils.IniReadValue(IniUtils.syspath, "syscalling", "callserverurl");
            ProgramGlobal.User = this.tbxAccount.Text.Trim();
            IniUtils.IniWriteValue(IniUtils.syspath, "account", "user", this.tbxAccount.Text.Trim());
            ProgramGlobal.Account_id = dt.Rows[0]["account_id"].ToString();
            ProgramGlobal.Username = dt.Rows[0]["doctorname"].ToString();
            ProgramGlobal.Password = tbxPwd.Text;
            ProgramGlobal.User_id = dt.Rows[0]["doctor_id"].ToString();
            ProgramGlobal.Nickname = dt.Rows[0]["name"].ToString();
            ProgramGlobal.Workno = dt.Rows[0]["workno"].ToString();
            ProgramGlobal.Depart_id = dt_depart.Rows[0]["id"].ToString();
            ProgramGlobal.DepartName = dt_depart.Rows[0]["name"].ToString();
            ProgramGlobal.HspName = dt_hsp.Rows[0]["hspName"].ToString();
            ProgramGlobal.HspKind = dt_hsp.Rows[0]["hspKind"].ToString();
            ProgramGlobal.Website = dt_hsp.Rows[0]["website"].ToString();
            ProgramGlobal.Startdate = dt_hsp.Rows[0]["startdate"].ToString();
            ProgramGlobal.Started = dt_hsp.Rows[0]["started"].ToString();
            ProgramGlobal.CostClass = dt_hsp.Rows[0]["costclass"].ToString();
            ProgramGlobal.Settletype = dt_config.Rows[0]["settletype"].ToString();
            ProgramGlobal.Clininicpay = dt_config.Rows[0]["clininicpay"].ToString();
            ProgramGlobal.Invoicetype = dt_config.Rows[0]["invoicetype"].ToString();

            GzsnhGlobal.UserName = Ini.IniReadValue2("GZSNH", "userName");
            GzsnhGlobal.UserPwd = Ini.IniReadValue2("GZSNH", "userPwd");
            GzsnhGlobal.CenterNo = Ini.IniReadValue2("GZSNH", "centerNo");
            GzsnhGlobal.HospCode = Ini.IniReadValue2("GZSNH", "hospCode");
            GzsnhGlobal.Url = Ini.IniReadValue2("GZSNH", "url");
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            float wScale = (float)SW / SW;//新旧窗体之间的比例，与最早的旧窗体  
            float hScale = (float)SH / SH;//.Height;
            ProgramGlobal.WidthScale = wScale;
            ProgramGlobal.HeightScale = hScale;
            BillCmbList billCmbList = new BillCmbList();
            ProgramGlobal.Depart = billCmbList.departList();
            fm.FrmLogin = this;
            fm.WindowState = FormWindowState.Maximized;
            fm.Show();
            Hide();
            //贵州省医保初始化
            //GzsybInterface szybinterface = new GzsybInterface();
            //GzsGlobal.Gzsyb = szybinterface;
            //if (false)
            //{
            //    Init_out initout = szybinterface.Init();
            //}
        }

        /// <summary>
        /// 进行所有的业务之前都先签到，获得业务周期号
        /// </summary>
        /// <returns></returns>
        public bool qiandao()
        {
            Sjzsyb_IN in1 = new Sjzsyb_IN();
            in1.Yw = "1501";
            //in1.Rc = in1.Request_head()
            //                + "<AAE140>0</AAE140>"//险种类型 0-医保
            //                + "<AAC001></AAC001>"//患者识别信息 个人编号/卡号/身份证号，有卡此值传 0，无卡传值
            //                + "<AKB020>HW02</AKB020>"//定点医疗机构编码 
            //                + "<MSGNO>1501</MSGNO>"// 交易代码 
            //                + "<MSGID>130100H00120151013121501</MSGID>"// 发送方交易流水号 
            //                + "<GRANTID>" + ProgramGlobal.GRANTID + "</GRANTID>"// 授权码 
            //                + "<OPERID>" + ProgramGlobal.User_id + "</OPERID>"// 操作员编号 
            //                + "<OPERNAME>" + ProgramGlobal.Nickname + "</OPERNAME>"// 操作员姓名
            //                + "<OPTTIME>" + DateTime.Now + "</OPTTIME>"// 系统时间(转时间戳) 
            //                 + "<INPUT></INPUT><KC21XML></KC21XML><KC22XML></KC22XML>"
            //                + in1.Request_foot();
            string ReturnMsg = "";
            SJZYB_IN<DBNull> in11 = new SJZYB_IN<DBNull>();
            in11.MSGNO = "1501";

            //int opstat = sjzsyb.ybcjhs(in1);
            SjzybInterface his = new SjzybInterface();
            //int opstat = his.ad(in11);

            DataSet ds = new DataSet();
            StringReader sr = new StringReader(in1.Cc);
            ds.ReadXml(sr);
            DataTable dt1 = ds.Tables["OUTPUT"];//特定输出参数
            DataTable dt2 = ds.Tables["RESPONSEDATA"];//所有返回参数
            int returnnum = Convert.ToInt32(dt2.Rows[0]["RETURNNUM"].ToString());

            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = dt2.Rows[0]["ERRORMSG"].ToString();
                ProgramGlobal.batno = ReturnMsg;
                return false;
            }
            else//==1成功   ==2成功,带有提示信息
            {
                ReturnMsg = dt1.Rows[0]["BATNO"].ToString();
                ProgramGlobal.batno = ReturnMsg;
                ProgramGlobal.logintime = DateTime.Now;
            }
            return true;
        }


        #region 开启线程方法

        /// <summary>
        /// 开启线程方法 读身份信息
        /// ReWriter:qinYangYang 2014-4-6
        /// </summary>
        /// <param name="param"></param>
        public static void PreLoadRpt(object param)
        {


        }

        #endregion

        //登录事件
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string param = "{\"err\" : \"\",\"errcode\" : \"200\",\"msg\" : {\"amount\" : \"0.01\",\"innerOrderNo\" :\"WN201605091749333844124981\",\"outerOrderNo\" : \"20160504000012\",\"tradeNo\" : \"20160504000012\",\"paytype\" : 4,\"tradeStatus\" : \"SUCCESS\"},\"success\" : true,\"token\" : \"\",\"userid\" : \"\",\"nonce_str\":\"3116\",\"sign\":\"FD3A37F3662C13A07E41DB31A8523D1C\"}";

            //JsonSuccess json_su = JsonConvert.DeserializeObject<JsonSuccess>(param);

            //string tradeStatus = json_su.msg.tradeStatus;

            login();
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //加载
        private void FrmLogin_Load(object sender, EventArgs e)
        {

            this.BackgroundImage = imgUtils.getImage("LoginImg.jpg");

            FrmDBConnectionConfiguration connection = new FrmDBConnectionConfiguration();
            if (!connection.test())
            {
                MessageBox.Show("ip地址不通，请配置HIS数据库连接，重新登录！", "提示信息");
                connection.StartPosition = FormStartPosition.CenterParent;
                connection.ShowDialog(this);
                return;

            }


            if (!bllMain.initDB())
            {
                MessageBox.Show("数据连接对象加载失败,请检查数据库连接配置文件dbconfig.ini", "提示");
                connection.StartPosition = FormStartPosition.CenterParent;
                connection.ShowDialog(this);
                return;
            }
            try
            {
                DataTable dt = BllMain.Db.Select("SELECT * FROM sys_info where id='1'").Tables[0];
                string started = dt.Rows[0]["started"].ToString().ToUpper();
                if (dt.Rows.Count > 0)
                {
                    ProgramGlobal.User = IniUtils.IniReadValue(IniUtils.syspath, "account", "user");
                    ProgramGlobal.Isffp = Convert.ToInt32(IniUtils.IniReadValue(IniUtils.syspath, "PZ", "ISFFP"));
                    ProgramGlobal.Zyyblx = IniUtils.IniReadValue(IniUtils.syspath, "MZPZ", "Zyyblx");
                    this.tbxAccount.Text = ProgramGlobal.User.Trim();
                    tbxPwd.Text = "";
                    tbxPwd.Focus();
                }
                string sql_hsp = "select hspname from sys_info left join sys_dict on sys_info.hspkind=sys_dict.keyname and sys_dict.dicttype='sys_hspkind'";
                DataTable dt_hsp = BllMain.Db.Select(sql_hsp).Tables[0];
                label1.Text = dt_hsp.Rows[0]["hspname"].ToString().Trim();
            }
            catch (Exception)
            {
                MessageBox.Show("数据连接不上,请检查数据库连接配置", "提示");
                connection.StartPosition = FormStartPosition.CenterParent;
                connection.ShowDialog(this);
                return;
            }
            //try
            //{
            //    zjkip();
            //}
            //catch { }
            //定时器
            string MM = IniUtils.IniReadValue(IniUtils.syspath, "DATE", "JGDATE");//线程间隔运行时间 单位分钟
            int mm = int.Parse(MM);
            restult.Interval = mm * 60 * 1000;
            restult.Elapsed += new ElapsedEventHandler(ybfysc);
            restult.AutoReset = true;
            restult.Enabled = true;
        }
        //上传费用与修改kc21信息
        private void ybfysc(object source, System.Timers.ElapsedEventArgs e)
        {
            lock (this)
            {
                if (IniUtils.IniReadValue(IniUtils.syspath, "DATE", "YBCHZDGXSJ").Equals("1"))//启用医保城乡自动更新数据
                {
                    thTmp = new Thread(scfy);
                    thTmp.Start();
                }
            }
        }
        //上传费用与修改kc21信息
        private void scfy()
        {
            lock (this)
            {

                int iIid = 0;
                string strGrbh = "", strZyh = "";

                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//当前时间
                DateTime date5 = Convert.ToDateTime(date);

                string date1 = DateTime.Now.ToString("yyyy-MM-dd") + " " + IniUtils.IniReadValue(IniUtils.syspath, "DATE", "YCKSDATE");//第一次开始时间
                string date2 = DateTime.Now.ToString("yyyy-MM-dd") + " " + IniUtils.IniReadValue(IniUtils.syspath, "DATE", "YCJSDATE");//第一次结束时间
                DateTime date3 = Convert.ToDateTime(date1);
                DateTime date4 = Convert.ToDateTime(date2);
                string dateks = DateTime.Now.ToString("yyyy-MM-dd") + " " + IniUtils.IniReadValue(IniUtils.syspath, "DATE", "ECKSDATE");//第二次开始时间
                string datejs = DateTime.Now.ToString("yyyy-MM-dd") + " " + IniUtils.IniReadValue(IniUtils.syspath, "DATE", "ECJSDATE");//第二次结束时间
                DateTime dateks7 = Convert.ToDateTime(dateks);
                DateTime datejs8 = Convert.ToDateTime(datejs);
                if ((date5 > date3 && date5 < date4) || (date5 > dateks7 && date5 < datejs8))
                {
                    try
                    {
                        // restult.Enabled = false;//停止定时器
                        ProgramGlobal.IsUpload = true;

                        //医保
                        if (IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "ybState").Equals("1") || IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "qybState").Equals("1"))
                        {
                            //医保
                            string sql = "select id,ihspcode,insurcode from inhospital where nhflag = 301 ";
                            DataTable dtYb = BllMain.Db.Select(sql).Tables[0];
                            if (dtYb.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtYb.Rows.Count; i++)
                                {
                                    iIid = int.Parse(dtYb.Rows[i]["id"].ToString());
                                    strGrbh = dtYb.Rows[i]["insurcode"].ToString().Trim();
                                    strZyh = dtYb.Rows[i]["ihspcode"].ToString().Trim();
                                    Zyybfysc_zdcs ybfysc = new Zyybfysc_zdcs();
                                    RetMsg ret = ybfysc.ybscfymx(iIid, strGrbh, strZyh);
                                    if (ret.Retint == false)
                                    {
                                        ProgramGlobal.IsUpload = false;
                                        ProgramGlobal.SysWriteLogs.writeLogs("上传费用错误", DateTime.Now, "住院号：" + strZyh + " 自动上传费用出错信息" + ret.Mesg);
                                    }
                                    string msg = "";
                                    ybfysc.xfdhje(iIid, strZyh, out msg);
                                }

                            }
                            //生育
                            string sql2 = "select iid,ihspcode,insurcode mtzyjl where nhflag = 1501 ";
                            DataTable dtYb2 = BllMain.Db.Select(sql2).Tables[0];
                            if (dtYb2.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtYb2.Rows.Count; i++)
                                {
                                    iIid = int.Parse(dtYb2.Rows[i]["id"].ToString());
                                    strGrbh = dtYb2.Rows[i]["insurcode"].ToString().Trim();
                                    strZyh = dtYb2.Rows[i]["ihspcode"].ToString().Trim();

                                    ZySyybfysc_zd syybfysc = new ZySyybfysc_zd();
                                    RetMsg ret = syybfysc.ybscfymx(iIid, strGrbh, strZyh);
                                    if (ret.Retint == false)
                                    {
                                        ProgramGlobal.IsUpload = false;
                                        ProgramGlobal.SysWriteLogs.writeLogs("上传费用错误", DateTime.Now, "住院号：" + strZyh + " 自动上传费用出错信息" + ret.Mesg);
                                    }
                                }
                            }
                        }
                        //城乡
                        if (IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "chState").Equals("1") || IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "qchState").Equals("1"))
                        {
                            JKDB jkdb = new JKDB();
                            string sqlTmp = "select iid,ihspcode,insurcode from mtzyjl where nhflag = 1101";
                            DataTable dtCh = BllMain.Db.Select(sqlTmp).Tables[0];
                            if (dtCh.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtCh.Rows.Count; i++)
                                {
                                    iIid = int.Parse(dtCh.Rows[i]["id"].ToString());
                                    strGrbh = dtCh.Rows[i]["insurcode"].ToString().Trim();
                                    strZyh = dtCh.Rows[i]["ihspcode"].ToString().Trim();
                                    string sql2 = "select AAC001 from KC21 where AKC190='" + strZyh + "'";
                                    DataSet ds2 = jkdb.Select(sql2);
                                    if (ds2.Tables[0].Rows.Count == 0)
                                    {
                                        continue;
                                    }
                                    Zycjfysc_zd cjfysc = new Zycjfysc_zd();
                                    RetMsg ret = cjfysc.ybscfymx(iIid, strGrbh, strZyh);
                                    string msg = "";
                                    cjfysc.xfdhjejyb_pl(strGrbh, iIid, strZyh, out msg);
                                    if (ret.Retint == false)
                                    {
                                        ret.Mesg += msg;
                                        ProgramGlobal.IsUpload = false;
                                        ProgramGlobal.SysWriteLogs.writeLogs("上传费用错误", DateTime.Now, "住院号：" + strZyh + " 自动上传费用出错信息" + ret.Mesg);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        ProgramGlobal.IsUpload = false;
                    }
                    finally
                    {
                        ProgramGlobal.IsUpload = false;
                        thTmp.Abort();
                    }
                    ProgramGlobal.IsUpload = false;
                }
                ProgramGlobal.IsUpload = false;
                if (thTmp != null)
                {
                    thTmp.Abort();
                }
            }

        }
        private void zjkip()
        {
            try
            {
                string sql = "select * from hdzjkip where iid = 1";//查询中间库ip
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                string[] retdata = dt.Rows[0]["ljfs"].ToString().Trim().Split('|');
                ProgramGlobal.Zjk = retdata[0] + dt.Rows[0]["dz"].ToString().Trim() + retdata[1];
            }
            catch
            { }
        }
        //输完用户名按enter键直接跳转到密码框
        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxPwd.Focus();
            }
        }

        //输完密码按enter键直接登录
        private void tbxPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            #region web登录
            if (mainArgs != null && mainArgs.Length == 2)
            {
                DataTable dt = BllMain.Db.Select("SELECT account,passwd FROM acc_account where isstop='N' and account='" + mainArgs[1].Trim() + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    tbxAccount.Text = dt.Rows[0]["account"].ToString();
                    tbxPwd.Text = dt.Rows[0]["passwd"].ToString();
                    btnLogin_Click(sender, e);
                }
            }
            #endregion

            #region 冗余
            //try
            //{
            //    #region 启动自动更新程序
            //    string version_MTLIS = Ini.IniReadValue("version", "version_MTLIS");//配置文件的版本号

            //    string sql_version = "select * from lis_version order by id desc limit 1";
            //    DataTable dt_version = BllMain.Db.Select(sql_version).Tables[0];
            //    string version_DB = "";
            //    if (dt_version.Rows.Count > 0)
            //    {
            //        if (dt_version.Rows[0]["MTLIS_version"] != null)
            //        {
            //            version_DB = dt_version.Rows[0]["MTLIS_version"].ToString();
            //        }

            //        if (version_DB != version_MTLIS)
            //        {
            //            //this.Hide();

            //            ProcessStartInfo obj = new ProcessStartInfo(@"D:\MTAPP1\SaveFileFromSeverMTLIS\SaveFileFromSeverMTLIS\bin\Debug\SaveFileFromSeverMTLIS.exe"); //new ProcessStartInfo(Current + "/opentest.exe");
            //            //obj.UseShellExecute = false;
            //            //obj.RedirectStandardOutput = true;
            //            //obj.RedirectStandardInput = true;
            //            //obj.CreateNoWindow = true;
            //            Process.Start(obj);//有需要时，可以强制退出 

            //            this.Close();

            //        }
            //    }
            //    #endregion
            //}
            //catch
            //{ } 
            #endregion
        }
        private void notiyIconPort_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.cmenuRight.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void cmenuRight_MouseLeave(object sender, EventArgs e)
        {
            this.cmenuRight.Visible = false;
        }
        private void menuItem_Click(object sender, EventArgs e)
        {
            string itemName = ((ToolStripMenuItem)sender).Text;
            switch (itemName)
            {

                case "退出":
                    this.Dispose(true);
                    Application.Exit();//
                    Environment.Exit(0);
                    break;
                case "数据库配置":
                    FrmDBConnectionConfiguration hisodbc = new FrmDBConnectionConfiguration();
                    hisodbc.StartPosition = FormStartPosition.CenterScreen;
                    hisodbc.ShowDialog(this);
                    break;
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
