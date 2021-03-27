using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.ihsp.bll;
using System.Data;
using MTREG.common.bll;

namespace MTHIS.common
{
    public static class ProgramGlobal
    {
        private static string hspName;
        /// <summary>
        /// 医院名称
        /// </summary>
        public static string HspName
        {
            get { return ProgramGlobal.hspName; }
            set { ProgramGlobal.hspName = value; }
        }

        private static SysWriteLogs sysWriteLogs;
        /// <summary>
        /// 日志
        /// </summary>
        internal static SysWriteLogs SysWriteLogs
        {
            get { return ProgramGlobal.sysWriteLogs; }
            set { ProgramGlobal.sysWriteLogs = value; }
        }


        private static string sessionid;
        /// <summary>
        /// 工伤id
        /// </summary>
        public static string Sessionid
        {
            get { return ProgramGlobal.sessionid; }
            set { ProgramGlobal.sessionid = value; }
        }
        private static string url;
        /// <summary>
        /// 工伤url
        /// </summary>
        public static string Url
        {
            get { return ProgramGlobal.url; }
            set { ProgramGlobal.url = value; }
        }
        private static string hspKind;
        /// <summary>
        /// 医院类型
        /// </summary>
        public static string HspKind
        {
            get { return ProgramGlobal.hspKind; }
            set { ProgramGlobal.hspKind = value; }
        }
        private static string insurHspCode;
        /// <summary>
        /// 定点编号(医保定点机构编码)
        /// </summary>
        public static string InsurHspCode
        {
            get { return ProgramGlobal.insurHspCode; }
            set { ProgramGlobal.insurHspCode = value; }
        }
        private static string departName;
        /// <summary>
        /// 科室名称
        /// </summary>
        public static string DepartName
        {
            get { return ProgramGlobal.departName; }
            set { ProgramGlobal.departName = value; }
        }
        private static string user;
        /// <summary>
        /// 账号
        /// </summary>
        public static string User
        {
            get { return ProgramGlobal.user; }
            set { ProgramGlobal.user = value; }
        }

        private static string depart_id;
        /// <summary>
        /// 科室ID
        /// </summary>
        public static string Depart_id
        {
            get { return ProgramGlobal.depart_id; }
            set { ProgramGlobal.depart_id = value; }
        }

        private static string ybcjbz;
        /// <summary>
        /// 邯郸医保城居标志
        /// </summary>
        public static string Ybcjbz
        {
            get { return ProgramGlobal.ybcjbz; }
            set { ProgramGlobal.ybcjbz = value; }
        }

        private static string username;
        /// <summary>
        /// 本系统登陆人的Doctor.NAME
        /// </summary>
        public static string Username
        {
            get { return ProgramGlobal.username; }
            set { ProgramGlobal.username = value; }
        }
        private static string user_id;
        /// <summary>
        /// Doctor.id
        /// </summary>
        public static string User_id
        {
            get { return ProgramGlobal.user_id; }
            set { ProgramGlobal.user_id = value; }
        }
        private static string nickname;
        /// <summary>
        /// 用户表acc_account名字
        /// </summary>
        public static string Nickname
        {
            get { return ProgramGlobal.nickname; }
            set { ProgramGlobal.nickname = value; }
        }

        private static string startdate;
        /// <summary>
        /// 开始时间
        /// </summary>
        public static string Startdate
        {
            get { return ProgramGlobal.startdate; }
            set { ProgramGlobal.startdate = value; }
        }


        private static string started;
        /// <summary>
        /// 使用状态
        /// </summary>
        public static string Started
        {
            get { return ProgramGlobal.started; }
            set { ProgramGlobal.started = value; }
        }
        private static string zjk;
        /// <summary>
        /// 邯郸医保中间库
        /// </summary>
        public static string Zjk
        {
            get { return ProgramGlobal.zjk; }
            set { ProgramGlobal.zjk = value; }
        }
        private static string workno;
        /// <summary>
        /// 登陆人工号
        /// </summary>
        public static string Workno
        {
            get { return ProgramGlobal.workno; }
            set { ProgramGlobal.workno = value; }
        }
        private static string account_id;
        /// <summary>
        /// 用户表id
        /// </summary>
        public static string Account_id
        {
            get { return ProgramGlobal.account_id; }
            set { ProgramGlobal.account_id = value; }
        }
        private static string costClass;
        /// <summary>
        /// 默认用费级别
        /// </summary>
        public static string CostClass
        {
            get { return ProgramGlobal.costClass; }
            set { ProgramGlobal.costClass = value; }
        }
        private static string settletype;
        /// <summary>
        /// 默认结账方式
        /// </summary>
        public static string Settletype
        {
            get { return ProgramGlobal.settletype; }
            set { ProgramGlobal.settletype = value; }
        }


        private static string website;
        /// <summary>
        /// 网站地址
        /// </summary>
        public static string Website
        {
            get { return ProgramGlobal.website; }
            set { ProgramGlobal.website = value; }
        }

        private static string password;
        /// <summary>
        /// 登录密码
        /// </summary>
        public static string Password
        {
            get { return ProgramGlobal.password; }
            set { ProgramGlobal.password = value; }
        }

        private static string clininicpay;
        /// <summary>
        /// 门诊缴费方式
        /// </summary>
        public static string Clininicpay
        {
            get { return ProgramGlobal.clininicpay; }
            set { ProgramGlobal.clininicpay = value; }
        }

        private static DataTable depart;
        /// <summary>
        /// 科室下拉框
        /// </summary>
        public static DataTable Depart
        {
            get { return ProgramGlobal.depart; }
            set { ProgramGlobal.depart = value; }
        }

        private static String othvar_1;
        /// <summary>
        /// 业务周期号BATNO 武邑县签到输出参数
        /// </summary>
        public static String Othvar_1
        {
            get { return ProgramGlobal.othvar_1; }
            set { ProgramGlobal.othvar_1 = value; }
        }
        private static String othvar_2;
        /// <summary>
        /// 医疗机构编码AKB020 武邑县医保参数
        /// </summary>
        public static String Othvar_2
        {
            get { return ProgramGlobal.othvar_2; }
            set { ProgramGlobal.othvar_2 = value; }
        }
        private static String othvar_3;
        /// <summary>
        /// 授权码GRANTID 武邑县
        /// </summary>
        public static String Othvar_3
        {
            get { return ProgramGlobal.othvar_3; }
            set { ProgramGlobal.othvar_3 = value; }
        }
        private static String othvar_4;
        /// <summary>
        /// 
        /// </summary>
        public static String Othvar_4
        {
            get { return ProgramGlobal.othvar_4; }
            set { ProgramGlobal.othvar_4 = value; }
        }
        private static string versionChk;
        /// <summary>
        /// 版本过期标志
        /// </summary>
        public static string VersionChk
        {
            get { return ProgramGlobal.versionChk; }
            set { ProgramGlobal.versionChk = value; }
        }

        private static string ip;
        /// <summary>
        /// 获取配置文件IP地址
        /// </summary>
        public static string Ip
        {
            get { return ProgramGlobal.ip; }
            set { ProgramGlobal.ip = value; }
        }
        private static string limitdate;
        /// <summary>
        /// 版本过期时间
        /// </summary>
        public static string Limitdate
        {
            get { return ProgramGlobal.limitdate; }
            set { ProgramGlobal.limitdate = value; }
        }
        private static float widthScale;
        /// <summary>
        /// 分辨率宽度比例
        /// </summary>
        public static float WidthScale
        {
            get { return ProgramGlobal.widthScale; }
            set { ProgramGlobal.widthScale = value; }
        }
        private static float heightScale;
        /// <summary>
        /// 分辨率高度比例
        /// </summary>
        public static float HeightScale
        {
            get { return ProgramGlobal.heightScale; }
            set { ProgramGlobal.heightScale = value; }
        }
        private static string invoicetype;
        /// <summary>
        /// 门诊出票方式
        /// </summary>
        public static string Invoicetype
        {
            get { return ProgramGlobal.invoicetype; }
            set { ProgramGlobal.invoicetype = value; }
        }

        private static string calling;
        /// <summary>
        /// 是否叫号
        /// </summary>
        public static string Calling
        {
            get { return ProgramGlobal.calling; }
            set { ProgramGlobal.calling = value; }
        }

        private static string calladdr;
        /// <summary>
        /// 叫号标示地址
        /// </summary>
        public static string Calladdr
        {
            get { return ProgramGlobal.calladdr; }
            set { ProgramGlobal.calladdr = value; }
        }

        private static string callserverurl;
        /// <summary>
        /// 服务器地址 
        /// </summary>
        public static string Callserverurl
        {
            get { return ProgramGlobal.callserverurl; }
            set { ProgramGlobal.callserverurl = value; }
        }

        private static string syb_yljgbh = "200012";//省医保医疗机构编号
        public static string Syb_yljgbh
        {
            get { return ProgramGlobal.syb_yljgbh; }
            set { ProgramGlobal.syb_yljgbh = value; }
        }
        private static string yhhiscs = "tr0001";//HIS厂商编号 由银海公司提供

        public static string Yhhiscs
        {
            get { return ProgramGlobal.yhhiscs; }
            set { ProgramGlobal.yhhiscs = value; }
        }
        /// <summary>
        /// 是否分发票
        /// </summary>
        public static int isffp = 0;
        public static int Isffp
        {
            get { return ProgramGlobal.isffp; }
            set { ProgramGlobal.isffp = value; }
        }
        private static string zyyblx;
        /// <summary>
        /// 医院名称
        /// </summary>
        public static string Zyyblx
        {
            get { return ProgramGlobal.zyyblx; }
            set { ProgramGlobal.zyyblx = value; }
        }
        private static bool isUpload;//是否正在上传费用

        public static bool IsUpload
        {
            get { return ProgramGlobal.isUpload; }
            set { ProgramGlobal.isUpload = value; }
        }
        /// <summary>
        /// 医保登录时间
        /// </summary>
        public static DateTime logintime { get; set; }

        /// <summary>
        /// 石家庄_业务周期号
        /// </summary>
        public static string batno;
        public static string Batno
        {
            get { return ProgramGlobal.batno; }
            set { ProgramGlobal.batno = value; }
        }

        
        /// <summary>
        /// 石家庄_定点医疗机构编码
        /// </summary>
        public static string AKB020 = "HW02";
        public static string aKB020
        {
            get { return ProgramGlobal.AKB020; }
            set { ProgramGlobal.AKB020 = value; }
        }

        /// <summary>
        /// 石家庄_授权码
        /// </summary>
        //public static string GRANTID = "HW02R8HJ36test";//测试
        public static string GRANTID = "HW02R8HJ36G269";//正式
        public static string gRANTID
        {
            get { return ProgramGlobal.GRANTID; }
            set { ProgramGlobal.GRANTID = value; }
        }
        /// <summary>
        /// 自动下载医保三目
        /// </summary>
        public static bool ybDownload { get; set; }
    }
}
