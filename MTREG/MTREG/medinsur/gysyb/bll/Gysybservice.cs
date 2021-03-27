using System;
using System.Collections.Generic;
using System.Text;
using MTREG.medinsur.gysyb.bo;
using MTHIS.common;
using MTREG.common;
using System.IO;
using System.Data;
using MTHIS.main.bll;
using System.Windows.Forms;
using MTREG.common.bll;
using MTREG.medinsur.gzsyb.Report_form;
using MTREG.medinsur.gzsyb.gysyb.Entity;
using MTREG.clinic.bo;

namespace MTREG.medinsur.gysyb.bll
{
    class Gysybservice
    {
        private Gysybdk gyyb;
        BllInsurGYSYB bllInsur = new BllInsurGYSYB();
        private Sybdk_Entity sybdk_entity;

        public Sybdk_Entity Sybdk_entity
        {
            get { return sybdk_entity; }
            set { sybdk_entity = value; }
        }
        public Gysybdk Gyyb
        {
            get { return gyyb; }
            set { gyyb = value; }
        }
        GysybInterface gysybface = new GysybInterface();
       // SzybDb szybdb = new SzybDb();
    //    Common_Util util = new Common_Util();
        


        /// <summary>
        /// 查询五定特殊项目目录
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public String Cxwdtsxmml(string itemcode, string isvalid)
        {
            string inXml = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?><DATA>";
            inXml += "<ITEMCODE>" + itemcode + "</ITEMCODE>";
            inXml += "<ISVALID>" + isvalid + "</ISVALID>";
            inXml += "</DATA>";
            string outXml = gysybface.QUERYSPECITEM(inXml);
            return outXml;
        }

        /// <summary>
        ///五定资格认定
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public String Wdzgrd(string grbh, string itemcode, string itemname, string drid, string drname, string operatorname)
        {
            string inXml = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?><DATA>";
            inXml += "<PERSONCODE>" + grbh + "</PERSONCODE>";
            inXml += "<ITEMCODE>" + itemcode + "</ITEMCODE>";
            inXml += "<ITEMNAME>" + itemname + "</ITEMNAME>";
            inXml += "<DRID>" + drid + "</DRID>";
            inXml += "<DRNAME>" + drname + "</DRNAME>";
            inXml += "<OPERATOR>" + operatorname + "</OPERATOR>";
            inXml += "</DATA>";
            string outXml = gysybface.REGSPECQFY(inXml);
            return outXml;
        }

        /// <summary>
        ///五定资格认定
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public String Wdzgcx(string grbh, string itemcode, string operatorname)
        {
            string inXml = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?><DATA>";
            inXml += "<PERSONCODE>" + grbh + "</PERSONCODE>";
            inXml += "<ITEMCODE>" + itemcode + "</ITEMCODE>";
            inXml += "<OPERATOR>" + operatorname + "</OPERATOR>";
            inXml += "</DATA>";
            string outXml = gysybface.DELSPECQFY(inXml);
            return outXml;
        }


        /// <summary>
        ///查询五定资格
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public String CxWdzg(string grbh, string itemcode, string drid)
        {
            string inXml = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?><DATA>";
            inXml += "<PERSONCODE>" + grbh + "</PERSONCODE>";
            inXml += "<ITEMCODE>" + itemcode + "</ITEMCODE>";
            inXml += "<DRID>" + drid + "</DRID>";
            inXml += "</DATA>";
            string outXml = gysybface.DELSPECQFY(inXml);
            return outXml;
        }


        /// <summary>
        ///查询特殊项目用量
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public String CxTsxmyl(string grbh, string itemcode, string nd)
        {
            string inXml = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?><DATA>";
            inXml += "<ND>" + nd + "</ND>";
            inXml += "<ITEMCODE>" + itemcode + "</ITEMCODE>";
            inXml += "<PERSONCODE>" + grbh + "</PERSONCODE>";
            inXml += "</DATA>";
            string outXml = gysybface.DELSPECQFY(inXml);
            return outXml;
        }
        /// <summary>
        /// 获取医保信息
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public String getInfo(String inXML)
        {
            return gysybface.GETCLINNO(inXML);
        }

        /// <summary>
        /// 入院登记
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        //public bool Gysybry(int mtzyjl_zyh, int mtzyjl_iid, StringBuilder message)
        //{

        //    String[] param = new String[19];
        //    param[0] = sybdk_entity.Klb;//卡类别
        //    param[1] = sybdk_entity.Ctsj;//磁条数据
        //    param[2] = sybdk_entity.Sfzhm;//社会保障号
        //    param[3] = sybdk_entity.Grbh;//个人编码
        //    param[4] = sybdk_entity.Zdjipdz;//终端机IP地址
        //    param[5] = sybdk_entity.Pasmkh;//PASM卡号
        //    param[6] = sybdk_entity.Mm;//密码
        //    param[7] = sybdk_entity.Bxlb;//保险类别
        //    param[8] = sybdk_entity.Zflb;//支付类别
        //    param[9] = mtzyjl_zyh.ToString();//住院号
        //    param[10] = "";//参保前已在院
        //    param[11] = sybdk_entity.Zdicd;//诊断
        //    if (param[11] == "")
        //    {
        //        param[11] = "J12.200";
        //    }
        //    param[12] = sybdk_entity.Ys;//诊断医生
        //    param[13] = sybdk_entity.Ks;//科室
        //    param[14] = sybdk_entity.Ryrq;//入院时间
        //    param[15] = ProgramGlobal.User_id;//操作员
        //    param[16] = BillSysBase.currDate();//办理时间
        //    param[17] = sybdk_entity.Gsrd;//工伤认定编号
        //    param[18] = sybdk_entity.Gskfzybz;//工伤康复住院标志
        //    Rydj_Syb rydj = new Rydj_Syb();
        //    string inXml = rydj.Rydj_head() + rydj.Rydj_in(param) + rydj.Rydj_tail();
        //    //调用业务类
        //    string outXml = gysybface.Syb_Rydj(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (flag == "0")
        //    {
        //        string centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码
        //        string billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
        //        string hosptimes = ds.Tables["DATA"].Rows[0]["HOSPTIMES"].ToString();//本年住院次数
        //        string startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //        string startfeepaid = ds.Tables["DATA"].Rows[0]["STARTFEEPAID"].ToString();//本年已支付起付线
        //        string fund1lmt = ds.Tables["DATA"].Rows[0]["FUND1LMT"].ToString();//基本统筹限额
        //        string fund1paid = ds.Tables["DATA"].Rows[0]["FUND1PAID"].ToString();//本年已支付基本统筹
        //        string fund2lmt = ds.Tables["DATA"].Rows[0]["FUND2LMT"].ToString();//大额统筹限额
        //        string fund2paid = ds.Tables["DATA"].Rows[0]["FUND2PAID"].ToString();//本年已支付大额统筹
        //        string lockinfo = ds.Tables["DATA"].Rows[0]["LOCKINFO"].ToString();//封锁信息
        //        string note = ds.Tables["DATA"].Rows[0]["NOTE"].ToString();//备注
        //        string soeccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
        //        string speccalflagtxt = ds.Tables["DATA"].Rows[0]["SPECCALFLAGTXT"].ToString();//特殊结算说明
        //        string reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
        //        string singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
        //        string singlellnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
        //        string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间

        //        GysYbRydj_Entity Rydj_Entity = new GysYbRydj_Entity();
        //        Rydj_Entity.Centercode = centercode;//分中心编码
        //        Rydj_Entity.Billno = billno;//就诊顺序号
        //        Rydj_Entity.Hosptimes = hosptimes;//本年住院次数
        //        Rydj_Entity.Startfee = startfee;//本次起付线
        //        Rydj_Entity.Startfeepaid = startfeepaid;//本年已支付起付线
        //        Rydj_Entity.Fund1lmt = fund1lmt;//基本统筹限额
        //        Rydj_Entity.Fund1paid = fund1paid;//本年已支付基本统筹
        //        Rydj_Entity.Fund2lmt = fund2lmt;//大额统筹限额
        //        Rydj_Entity.Fund2paid = fund1paid;//本年已支付大额统筹
        //        Rydj_Entity.Lockinfo = lockinfo;//封锁信息
        //        Rydj_Entity.Note = note;//备注
        //        Rydj_Entity.Soeccalflag = soeccalflag;//特殊结算标志
        //        Rydj_Entity.Speccalflagtxt = speccalflagtxt;//特殊结算说明
        //        Rydj_Entity.Reckoningtype = reckoningtype;//清算方式
        //        Rydj_Entity.Singleillnesscode = singleillnesscode;//清算病种编码
        //        Rydj_Entity.Singlellnessname = singlellnessname;//病种名称
        //        Rydj_Entity.Handledate = handledate;//系统处理时间
        //        Rydj_Entity.Cardtype = sybdk_entity.Klb;//卡类别
        //        Rydj_Entity.Sno = sybdk_entity.Sfzhm;//社会保障号
        //        Rydj_Entity.Carddata = sybdk_entity.Ctsj;//磁条数据
        //        Rydj_Entity.Personcode = sybdk_entity.Grbh;//个人编码
        //        Rydj_Entity.Ipaddr = sybdk_entity.Zdjipdz;//终端机IP地址
        //        Rydj_Entity.Psamno = sybdk_entity.Pasmkh;//PASM卡号
        //        Rydj_Entity.Pwd = sybdk_entity.Mm;//密码
        //        Rydj_Entity.Insuretype = sybdk_entity.Bxlb;//保险类别
        //        Rydj_Entity.Paytype = sybdk_entity.Zflb;//支付类别
        //        Rydj_Entity.Mtzyjl_iid = mtzyjl_iid.ToString();//Mtzyjl_iid
        //        Rydj_Entity.Deptname = sybdk_entity.Dwmc;
        //        Rydj_Entity.RylbName = sybdk_entity.RylbName;

        //        if (!gyybdb.SybRydj_his_New(Rydj_Entity, 1))
        //        {
        //            message.Append("数据库错误");
        //            return false;
        //        }
        //    }
        //    else if (flag != "0")
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 撤销入院登记
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <returns></returns>
        //public bool Cxzy(String Mtzyjl_iid, StringBuilder message)
        //{
        //    DataTable dt = gyybdb.GetRydjxx(Mtzyjl_iid);
        //    String[] param = new String[4];
        //    param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
        //    param[1] = dt.Rows[0]["aac001"].ToString();//个人编号
        //    param[2] = dt.Rows[0]["yab003"].ToString();//分中心编号
        //    param[3] = dt.Rows[0]["ykb065"].ToString();//社会保险办法
        //    Cydjsjht cydjsjht = new Cydjsjht();
        //    String inXml = cydjsjht.Cydjsjht_head() + cydjsjht.Cydjsjht_in(param) + cydjsjht.Cydjsjht_tail();
        //    //调用业务类
        //    string outXml = gysybface.Cxrydj(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    if (!gyybdb.CxRydj(Mtzyjl_iid))
        //    {
        //        message.Append("数据库错误");
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 设置结算方式
        ///// ReWriter:qinYangYang 2014/4/29 
        ///// 结算方式 为1时，单病种编码不能为空
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <param name="PERSONCODE">个人编码</param>
        ///// <param name="CALTYPE">结算方式</param>
        ///// <param name="SINGLEILLNESSCODE">单病种编码</param>
        ///// <param name="currDateTime">服务器时间</param>
        ///// <returns></returns>
        //public bool SETCALTYPE(string Mtzyjl_iid, StringBuilder message, int CALTYPE, string SINGLEILLNESSCODE, string PERSONCODE, string currDateTime)
        //{
        //    string[] param = new string[5];
        //    param[0] = PERSONCODE;
        //    param[1] = CALTYPE.ToString();
        //    param[2] = SINGLEILLNESSCODE;
        //    param[3] = ProgramGlobal.User_id;//操作员
        //    param[4] = currDateTime;
        //    Szjsfs szjsfs = new Szjsfs();
        //    String inXml = szjsfs.Szjsfs_head() + szjsfs.Szjsfs_in(param) + szjsfs.Szjsfs_tail();
        //    //调用业务类
        //    string outXml = gysybface.Szjsfs(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 设置清算方式
        ///// ReWriter:qinYangYang 2014/4/29 
        ///// 清算方式 为1时，单病种编码不能为空
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <param name="PERSONCODE">个人编码</param>
        ///// <param name="RECKONINGTYPE">清算方式</param>
        ///// <param name="SINGLEILLNESSCODE">单病种编码</param>
        ///// <param name="currDateTime">服务器时间</param>
        ///// <returns></returns>
        //public bool SETRECKONINGTYPE(string Mtzyjl_iid, StringBuilder message, int RECKONINGTYPE, string SINGLEILLNESSCODE, string PERSONCODE, string currDateTime)
        //{
        //    String[] param = new String[5];
        //    param[0] = PERSONCODE;
        //    param[1] = RECKONINGTYPE.ToString();
        //    param[2] = SINGLEILLNESSCODE;
        //    param[3] = ProgramGlobal.User_id;//操作员
        //    param[4] = currDateTime;//办理时间
        //    Szqsfs szqsfs = new Szqsfs();
        //    String inXml = szqsfs.Szqsfs_head() + szqsfs.Szqsfs_in(param) + szqsfs.Szqsfs_tail();
        //    //调用业务类
        //    string outXml = gysybface.Szqsfs(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 模拟住院结算
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <returns></returns>
        //public Dictionary<String, Zyjs_ret> CALHOSP(String Mtzyjl_iid, StringBuilder message, String qsfs, String dbzbm, string currDateTime, out string errInfo)
        //{//住院记录iid-错误消息-清算方式-病种编码-时间-“”
        //    errInfo = "";
        //    Dictionary<String, Zyjs_ret> dic = new Dictionary<string, Zyjs_ret>();
        //    DataTable dt = gyybdb.GetRydjxx(Mtzyjl_iid);
        //    String[] param = new String[15];
        //    param[0] = dt.Rows[0]["CARDTYPE"].ToString();//卡类别
        //    param[1] = dt.Rows[0]["CARDDATA"].ToString();//磁条数据
        //    param[2] = dt.Rows[0]["SNO"].ToString();//社会保障号
        //    param[3] = dt.Rows[0]["IPADDR"].ToString();//终端机IP地址
        //    param[4] = dt.Rows[0]["PSAMNO"].ToString();//PASM卡号
        //    param[5] = dt.Rows[0]["PERSONCODE"].ToString();//个人编码
        //    param[6] = dt.Rows[0]["pwd"].ToString();//密码 
        //    param[7] = "0";//是否结算
        //    param[8] = "0";//账户支付额
        //    param[10] = qsfs;//清算方式
        //    param[11] = dbzbm;//单病种编码
        //    param[12] = ProgramGlobal.User_id;//操作员
        //    param[13] = currDateTime;//办理日期

        //    String fph = gyybdb.Getfph(Mtzyjl_iid);
        //    param[9] = fph;//发票号
        //    Zyjs zyjs = new Zyjs();
        //    String inXml = zyjs.Zyjs_head() + zyjs.Zyjs_in(param);
        //    String fy = "";
        //    DataTable SybRydjdt = gyybdb.RyjlFycx(Mtzyjl_iid);
        //    String[] param2 = new String[26];
        //    if (dt.Rows[0]["sfcx"].ToString().Equals("0"))
        //    {
        //        for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //        {
        //            param2[0] = SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //            param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //            param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //            string hisXmmc = SybRydjdt.Rows[i]["xmmc"].ToString();//项目名称(his)
        //            if (string.IsNullOrEmpty(param2[1]))
        //            {
        //                errInfo += "医保编码为空：项目名称:【" + hisXmmc + "】======";
        //            }
        //            param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //            param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //            param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //            param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //            param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //            param2[8] = SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //            param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //            param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //            param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //            param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //            param2[13] = DateTime.Parse(SybRydjdt.Rows[i]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
        //            param2[14] = "";//备注
        //            double qty = DataTool.stringToDouble(SybRydjdt.Rows[i]["QUANTITY"].ToString());
        //            if (qty < 0)
        //            {
        //                param2[15] = "1";//冲销标志
        //            }
        //            else
        //            {
        //                param2[15] = "0";//冲销标志
        //            }
        //            param2[16] = SybRydjdt.Rows[i]["WAY"].ToString();//用药途径
        //            param2[17] = SybRydjdt.Rows[i]["FREQ"].ToString();//用药频次
        //            param2[18] = SybRydjdt.Rows[i]["DOSAGE"].ToString();//单次用量
        //            param2[19] = SybRydjdt.Rows[i]["USEDAYS"].ToString();//用药天数
        //            param2[20] = SybRydjdt.Rows[i]["DRID"].ToString();//开药医师身份证号码
        //            param2[21] = SybRydjdt.Rows[i]["HOSPITEMCODE"].ToString();// 院内收费项目编码
        //            param2[22] = SybRydjdt.Rows[i]["TOTAL"].ToString();//取药总量
        //            param2[23] = SybRydjdt.Rows[i]["TOTALUNIT"].ToString();//取药总量单位
        //            param2[24] = SybRydjdt.Rows[i]["GETDAYS"].ToString();//药量天数
        //            param2[25] = SybRydjdt.Rows[i]["USEDATE"].ToString();//执行时间
        //            fy += zyjs.Zyjs_in2(param2);
        //        }
        //    }
        //    else
        //    {
        //        String cxstr = dt.Rows[0]["cxstr"].ToString();
        //        for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //        {
        //            param2[0] = cxstr + SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //            param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //            param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //            string hisXmmc = SybRydjdt.Rows[i]["xmmc"].ToString();//项目名称(his)
        //            if (string.IsNullOrEmpty(param2[1]))
        //            {
        //                errInfo += "医保编码为空：项目名称:【" + hisXmmc + "】======";
        //            }
        //            param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //            param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //            param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //            param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //            param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //            param2[8] = SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //            param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //            param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //            param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //            param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //            param2[13] = DateTime.Parse(SybRydjdt.Rows[i]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
        //            param2[14] = "";//备注
        //            param2[15] = "0";//冲销标志
        //            param2[16] = SybRydjdt.Rows[i]["WAY"].ToString();//用药途径
        //            param2[17] = SybRydjdt.Rows[i]["FREQ"].ToString();//用药频次
        //            param2[18] = SybRydjdt.Rows[i]["DOSAGE"].ToString();//单次用量
        //            param2[19] = SybRydjdt.Rows[i]["USEDAYS"].ToString();//用药天数
        //            param2[20] = SybRydjdt.Rows[i]["DRID"].ToString();//开药医师身份证号码
        //            param2[21] = SybRydjdt.Rows[i]["HOSPITEMCODE"].ToString();// 院内收费项目编码
        //            param2[22] = SybRydjdt.Rows[i]["TOTAL"].ToString();//取药总量
        //            param2[23] = SybRydjdt.Rows[i]["TOTALUNIT"].ToString();//取药总量单位
        //            param2[24] = SybRydjdt.Rows[i]["GETDAYS"].ToString();//药量天数
        //            param2[25] = SybRydjdt.Rows[i]["USEDATE"].ToString();//执行时间
        //            fy += zyjs.Zyjs_in2(param2);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(errInfo))
        //    {
        //        return dic;
        //    }

        //    inXml += fy;

        //    inXml += zyjs.Zyjs_tail();

        //    String outXml = gysybface.mnZyjs(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();

        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        errInfo = "医保中心返回错误信息:【" + info + "】，状态码:【" + flag + "】";
        //        dic.Add("zyjs_ret", zyjs_ret_Entity);
        //        return dic;
        //    }
        //    else
        //    {
        //        errInfo = "";
        //        string sql = "";
        //        for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //        {
        //            sql += "update mtzyjlstuff set ybsc=1 where iid=" + SybRydjdt.Rows[i]["ITEMSERIAL"].ToString() + ";";
        //        }
        //        if (!string.IsNullOrEmpty(sql))
        //        {
        //            int flg = BllMain.Db.Update(sql);
        //            if (flg.Equals(-1))
        //            {
        //                errInfo = "更新费用上传标志失败";
        //            }
        //        }
        //    }

        //    //Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
        //    zyjs_ret_Entity.Centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码    
        //    zyjs_ret_Entity.Billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    zyjs_ret_Entity.Balanceid = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
        //    zyjs_ret_Entity.Hospfeeall = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
        //    zyjs_ret_Entity.Feeall = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
        //    zyjs_ret_Entity.Calfeeall = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
        //    zyjs_ret_Entity.Feeout = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
        //    zyjs_ret_Entity.Feeself = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
        //    zyjs_ret_Entity.Allowfund = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
        //    zyjs_ret_Entity.Startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //    zyjs_ret_Entity.Enterstartfee = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
        //    zyjs_ret_Entity.Fund1pay = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
        //    zyjs_ret_Entity.Fund1self = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
        //    zyjs_ret_Entity.Fund2pay = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额统筹支付
        //    zyjs_ret_Entity.Fund2self = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
        //    zyjs_ret_Entity.Feeouer = ds.Tables["DATA"].Rows[0]["FEEOVER"].ToString();//超限额自付
        //    zyjs_ret_Entity.Acctpay = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
        //    zyjs_ret_Entity.Fund3pay = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
        //    zyjs_ret_Entity.Acctbalance = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
        //    zyjs_ret_Entity.Handledte = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    zyjs_ret_Entity.Speccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
        //    zyjs_ret_Entity.Reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
        //    zyjs_ret_Entity.Singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
        //    zyjs_ret_Entity.Singleillnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
        //    //更新his数据
        //    dic.Add("zyjs_ret", zyjs_ret_Entity);
        //    return dic;
        //}
        ///// <summary>
        ///// 撤销费用
        ///// </summary>
        ///// <param name="mtzyjl_iid"></param>
        ///// <returns></returns>
        //public bool CXFY(string mtzyjl_iid)
        //{
        //    string sql = " update mtzyjlstuff set ybsc=1  where mtzyjl=" + DataTool.addFieldBraces(mtzyjl_iid);
        //    if (BllMain.Db.Update(sql) < 0)
        //        return false;
        //    else
        //        return true;
        //}
        /// <summary>
        /// 费用冲销
        /// </summary>
        /// <param name="Mtzyjl_iid"></param>
        /// <param name="message"></param>
        /// <param name="qsfs"></param>
        /// <returns></returns>
        //public bool FYCX(String Mtzyjl_iid, StringBuilder message)
        //{
        //    DataTable dt = gyybdb.GetRydjxx(Mtzyjl_iid);
        //    String[] param = new String[15];
        //    param[0] = dt.Rows[0]["CARDTYPE"].ToString();//卡类别
        //    param[1] = dt.Rows[0]["CARDDATA"].ToString();//磁条数据
        //    param[2] = dt.Rows[0]["SNO"].ToString();//社会保障号
        //    param[3] = dt.Rows[0]["IPADDR"].ToString();//终端机IP地址
        //    param[4] = dt.Rows[0]["PSAMNO"].ToString();//PASM卡号
        //    param[5] = dt.Rows[0]["PERSONCODE"].ToString();//个人编码
        //    param[6] = dt.Rows[0]["pwd"].ToString();//密码 
        //    param[7] = "0";//是否结算
        //    param[8] = "0";//账户支付额
        //    param[10] = "";//清算方式
        //    param[11] = dt.Rows[0]["SINGLEILLNESSCODE"].ToString();//单病种编码
        //    param[12] = ProgramGlobal.User_id;//操作员
        //    param[13] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");//办理日期

        //    String fph = gyybdb.Getfph(Mtzyjl_iid);
        //    param[9] = fph;//发票号
        //    Zyjs zyjs = new Zyjs();
        //    String inXml = zyjs.Zyjs_head() + zyjs.Zyjs_in(param);
        //    String fy = "";
        //    DataTable SybRydjdt = gyybdb.RyjlFycx(Mtzyjl_iid);
        //    if (dt.Rows[0]["sfcx"].ToString().Equals("0"))//卡类别
        //    {
        //        for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //        {
        //            String[] param2 = new String[16];
        //            param2[0] = SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //            param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //            param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //            param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //            param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //            param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //            param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //            param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //            param2[8] = "-" + SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //            param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //            param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //            param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //            param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //            param2[13] = DateTime.Parse(SybRydjdt.Rows[i]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
        //            param2[14] = "";//备注
        //            param2[15] = "1";//冲销标志
        //            fy += zyjs.Zyjs_in2(param2);
        //        }
        //    }
        //    else
        //    {
        //        String cxstr = dt.Rows[0]["cxstr"].ToString();//已经冲销过 查询冲销标志唯一码
        //        for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //        {
        //            String[] param2 = new String[16];
        //            param2[0] = cxstr + SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //            param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //            param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //            param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //            param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //            param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //            param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //            param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //            param2[8] = "-" + SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //            param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //            param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //            param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //            param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //            param2[13] = DateTime.Parse(SybRydjdt.Rows[i]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
        //            param2[14] = "";//备注
        //            param2[15] = "1";//冲销标志
        //            fy += zyjs.Zyjs_in2(param2);
        //        }
        //    }
        //    inXml += fy;
        //    inXml += zyjs.Zyjs_tail();
        //    String outXml = gysybface.mnZyjs(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
        //    Dictionary<String, Zyjs_ret> dic = new Dictionary<string, Zyjs_ret>();
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        //dic.Add("zyjs_ret", zyjs_ret_Entity);
        //        return false;
        //    }
        //    //Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
        //    //zyjs_ret_Entity.Centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码    
        //    //zyjs_ret_Entity.Billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    //zyjs_ret_Entity.Balanceid = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
        //    //zyjs_ret_Entity.Hospfeeall = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
        //    //zyjs_ret_Entity.Feeall = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
        //    //zyjs_ret_Entity.Calfeeall = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
        //    //zyjs_ret_Entity.Feeout = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
        //    //zyjs_ret_Entity.Feeself = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
        //    //zyjs_ret_Entity.Allowfund = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
        //    //zyjs_ret_Entity.Startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //    //zyjs_ret_Entity.Enterstartfee = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
        //    //zyjs_ret_Entity.Fund1pay = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
        //    //zyjs_ret_Entity.Fund1self = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
        //    //zyjs_ret_Entity.Fund2pay = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额统筹支付
        //    //zyjs_ret_Entity.Fund2self = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
        //    //zyjs_ret_Entity.Feeouer = ds.Tables["DATA"].Rows[0]["FEEOVER"].ToString();//超限额自付
        //    //zyjs_ret_Entity.Acctpay = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
        //    //zyjs_ret_Entity.Fund3pay = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
        //    //zyjs_ret_Entity.Acctbalance = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
        //    //zyjs_ret_Entity.Handledte = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    //zyjs_ret_Entity.Speccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
        //    //zyjs_ret_Entity.Reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
        //    //zyjs_ret_Entity.Singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
        //    //zyjs_ret_Entity.Singleillnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
        //    //List<Zyjs_rets> zyjs_ret_list = new List<Zyjs_rets>();
        //    //for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
        //    //{
        //    //    Zyjs_rets zyjs_Entity = new Zyjs_rets();
        //    //    zyjs_Entity.Itemserial = ds.Tables["ROW"].Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //    //    zyjs_Entity.Itemcode = ds.Tables["ROW"].Rows[i]["ITEMCODE"].ToString();//医保编码
        //    //    zyjs_Entity.Itemname = ds.Tables["ROW"].Rows[i]["ITEMNAME"].ToString();//项目名称
        //    //    zyjs_Entity.Hospprice = ds.Tables["ROW"].Rows[i]["HOSPPRICE"].ToString();//医院单价
        //    //    zyjs_Entity.Price = ds.Tables["ROW"].Rows[i]["PRICE"].ToString();//医保单价
        //    //    zyjs_Entity.Quantity = ds.Tables["ROW"].Rows[i]["QUANTITY"].ToString();//数量
        //    //    zyjs_Entity.Selfrate = ds.Tables["ROW"].Rows[i]["SELFRATE"].ToString();//自付比例
        //    //    zyjs_Entity.Specpayflag = ds.Tables["ROW"].Rows[i]["SPECPAYFLAG"].ToString();//特殊报销项目标志
        //    //    zyjs_Entity.Bgitemtype = ds.Tables["ROW"].Rows[i]["BGITEMTYPE"].ToString();//包干结算项目类别
        //    //    zyjs_Entity.Returnfalg = ds.Tables["ROW"].Rows[i]["RETURNFLAG"].ToString();//冲销标志
        //    //    zyjs_ret_list.Add(zyjs_Entity);
        //    //}
        //    //更新his数据
        //    message.Append(ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString());

        //    if (gyybdb.cxupdate(Mtzyjl_iid, DataTool.GenUniqueText()))
        //    {
        //        return false;
        //    }
        //    //dic.Add("zyjs_ret", zyjs_ret_Entity);
        //    return true;
        //}

        ///// <summary>
        ///// 正式结算 
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <returns></returns>
        //public bool CALHOSPzs(String Mtzyjl_iid, StringBuilder message, String zhzfe, String qsfs, String Cyyy, String dbz, String jsskfkfs, string currDateTime, Sybdk_Entity sybdk_entity)
        //{

        //    String[] getfph = new String[1];
        //    Gyd gyd = Gyd.getGyd();
        //    string errInfo;
        //    if (!gyd.Getfphs_New(1, "1", int.Parse(ProgramGlobal.User_id), getfph, out errInfo))
        //    {
        //        message.Append("发票不足，请领回发票再进行操作");
        //        return false;
        //    }
        //    DataTable dt = gyybdb.GetRydjxx(Mtzyjl_iid);
        //    String[] param = new String[15];
        //    //新验证结算_wzw
        //    param[0] = sybdk_entity.Klb;    //dt.Rows[0]["CARDTYPE"].ToString();//卡类别 
        //    param[1] = sybdk_entity.Ctsj;  //dt.Rows[0]["CARDDATA"].ToString();//磁条数据
        //    param[2] = sybdk_entity.Sfzhm;  //dt.Rows[0]["SNO"].ToString();//社会保障号
        //    param[3] = sybdk_entity.Zdjipdz;//dt.Rows[0]["IPADDR"].ToString();//终端机IP地址
        //    param[4] = sybdk_entity.Pasmkh; // dt.Rows[0]["PSAMNO"].ToString();//PASM卡号
        //    param[5] = sybdk_entity.Grbh;   //dt.Rows[0]["PERSONCODE"].ToString();//个人编码
        //    param[6] = sybdk_entity.Mm;     // dt.Rows[0]["pwd"].ToString();//密码 


        //    //新验证结算_end_wzw


        //    //就验证_bak_wzw
        //    //param[0] = dt.Rows[0]["CARDTYPE"].ToString();//卡类别 
        //    //param[1] = dt.Rows[0]["CARDDATA"].ToString();//磁条数据
        //    //param[2] = dt.Rows[0]["SNO"].ToString();//社会保障号
        //    //param[3] = dt.Rows[0]["IPADDR"].ToString();//终端机IP地址
        //    //param[4] = dt.Rows[0]["PSAMNO"].ToString();//PASM卡号
        //    //param[5] = dt.Rows[0]["PERSONCODE"].ToString();//个人编码
        //    //param[6] = dt.Rows[0]["pwd"].ToString();//密码 
        //    //就验证_bak_end_wzw

        //    param[7] = "1";//dt.Rows[0]["PASSWORD"].ToString();//是否结算
        //    param[8] = zhzfe;//账户支付额
        //    if (string.IsNullOrEmpty(zhzfe))
        //    {
        //        param[8] = "0";
        //    }

        //    param[10] = qsfs;//清算方式
        //    param[11] = dbz;//单病种编码
        //    param[12] = ProgramGlobal.User_id;//操作员
        //    param[13] = currDateTime;//办理日期

        //    String fph = gyybdb.Getfph(Mtzyjl_iid);
        //    // getfph[0] = fph;
        //    param[9] = getfph[0];//发票号
        //    Zyjs zyjs = new Zyjs();
        //    String inXml = zyjs.Zyjs_head() + zyjs.Zyjs_in(param);
        //    String fy = "";
        //    DataTable SybRydjdt = gyybdb.RyjlFycx(Mtzyjl_iid);
        //    if (dt.Rows[0]["sfcx"].ToString().Equals("0"))
        //    {
        //        for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //        {
        //            String[] param2 = new String[26];
        //            param2[0] = SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //            param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //            param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //            param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //            param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //            param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //            param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //            param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //            param2[8] = SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //            param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //            param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //            param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //            param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //            param2[13] = DateTime.Parse(SybRydjdt.Rows[i]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
        //            param2[14] = "";//备注”
        //            param2[15] = "0";//冲销标志
        //            param2[16] = SybRydjdt.Rows[i]["WAY"].ToString();//用药途径
        //            param2[17] = SybRydjdt.Rows[i]["FREQ"].ToString();//用药频次
        //            param2[18] = SybRydjdt.Rows[i]["DOSAGE"].ToString();//单次用量
        //            param2[19] = SybRydjdt.Rows[i]["USEDAYS"].ToString();//用药天数
        //            param2[20] = SybRydjdt.Rows[i]["DRID"].ToString();//开药医师身份证号码
        //            param2[21] = SybRydjdt.Rows[i]["HOSPITEMCODE"].ToString();// 院内收费项目编码
        //            param2[22] = SybRydjdt.Rows[i]["TOTAL"].ToString();//取药总量
        //            param2[23] = SybRydjdt.Rows[i]["TOTALUNIT"].ToString();//取药总量单位
        //            param2[24] = SybRydjdt.Rows[i]["GETDAYS"].ToString();//药量天数
        //            param2[25] = SybRydjdt.Rows[i]["USEDATE"].ToString();//执行时间
        //            fy += zyjs.Zyjs_in2(param2);
        //        }
        //    }
        //    else
        //    {
        //        String cxstr = dt.Rows[0]["cxstr"].ToString();
        //        for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //        {
        //            String[] param2 = new String[26];
        //            param2[0] = cxstr + SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //            param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //            param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //            param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //            param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //            param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //            param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //            param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //            param2[8] = SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //            param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //            param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //            param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //            param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //            param2[13] = DateTime.Parse(SybRydjdt.Rows[i]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
        //            param2[14] = "";//备注”
        //            param2[15] = "0";//冲销标志
        //            param2[16] = SybRydjdt.Rows[i]["WAY"].ToString();//用药途径
        //            param2[17] = SybRydjdt.Rows[i]["FREQ"].ToString();//用药频次
        //            param2[18] = SybRydjdt.Rows[i]["DOSAGE"].ToString();//单次用量
        //            param2[19] = SybRydjdt.Rows[i]["USEDAYS"].ToString();//用药天数
        //            param2[20] = SybRydjdt.Rows[i]["DRID"].ToString();//开药医师身份证号码
        //            param2[21] = SybRydjdt.Rows[i]["HOSPITEMCODE"].ToString();// 院内收费项目编码
        //            param2[22] = SybRydjdt.Rows[i]["TOTAL"].ToString();//取药总量
        //            param2[23] = SybRydjdt.Rows[i]["TOTALUNIT"].ToString();//取药总量单位
        //            param2[24] = SybRydjdt.Rows[i]["GETDAYS"].ToString();//药量天数
        //            param2[25] = SybRydjdt.Rows[i]["USEDATE"].ToString();//执行时间
        //            fy += zyjs.Zyjs_in2(param2);
        //        }
        //    }

        //    inXml += fy;
        //    inXml += zyjs.Zyjs_tail();
        //    String outXml = gysybface.mnZyjs(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
        //    zyjs_ret_Entity.Centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码    
        //    zyjs_ret_Entity.Billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    zyjs_ret_Entity.Balanceid = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
        //    zyjs_ret_Entity.Hospfeeall = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
        //    zyjs_ret_Entity.Feeall = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
        //    zyjs_ret_Entity.Calfeeall = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
        //    zyjs_ret_Entity.Feeout = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
        //    zyjs_ret_Entity.Feeself = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
        //    zyjs_ret_Entity.Allowfund = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
        //    zyjs_ret_Entity.Startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //    zyjs_ret_Entity.Enterstartfee = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线

        //    zyjs_ret_Entity.Fund1pay = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
        //    //sybdk_entity.Bxlb = "3";
        //    if (sybdk_entity.Bxlb.Equals("2"))
        //    {
        //        zyjs_ret_Entity.Fund1pay = zyjs_ret_Entity.Allowfund;
        //    }
        //    zyjs_ret_Entity.Fund1self = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
        //    zyjs_ret_Entity.Fund2pay = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额统筹支付
        //    zyjs_ret_Entity.Fund2self = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
        //    zyjs_ret_Entity.Acctpay = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
        //    zyjs_ret_Entity.Feeouer = ds.Tables["DATA"].Rows[0]["FEEOVER"].ToString();//超限额自付
        //    zyjs_ret_Entity.Fund3pay = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
        //    zyjs_ret_Entity.Acctbalance = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
        //    zyjs_ret_Entity.Handledte = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    zyjs_ret_Entity.Speccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
        //    zyjs_ret_Entity.Reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
        //    zyjs_ret_Entity.Singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
        //    zyjs_ret_Entity.Singleillnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
        //    zyjs_ret_Entity.Mtzyjl_iid = Mtzyjl_iid;


        //    List<Zyjs_rets> zyjs_ret_list = new List<Zyjs_rets>();

        //    String grzh = zyjs_ret_Entity.Acctpay;//个人账户支付

        //    String yjje = gyybdb.GetYjje(Mtzyjl_iid);//预交金额


        //    String gwytczf = zyjs_ret_Entity.Fund3pay;//医疗补助支付
        //    String dbzf = zyjs_ret_Entity.Fund2pay;//大额统筹支付
        //    String jbtczf = zyjs_ret_Entity.Fund1pay;//基本统筹支付

        //    float float_grzh = DataTool.stringToFloat(grzh); //个人账户支付
        //    float float_gwytczf = DataTool.stringToFloat(gwytczf);//医疗补助支付
        //    float float_dbzf = DataTool.stringToFloat(dbzf);       //大病统筹支付
        //    float float_jbtczf = DataTool.stringToFloat(jbtczf);//基本统筹支付

        //    float ybfy = float_grzh + float_gwytczf + float_dbzf + float_jbtczf;//医保费用

        //    float float_xj = DataTool.stringToFloat(zyjs_ret_Entity.Hospfeeall) - ybfy - DataTool.stringToFloat(yjje);//现金支付（最后多退少补）的钱数

        //    Dictionary<String, String> dic2 = new Dictionary<String, String>();
        //    dic2.Add("mtzyjl_iid", Mtzyjl_iid);
        //    dic2.Add("ysjefkfs", jsskfkfs);
        //    dic2.Add("mtylfkfs", "171");
        //    dic2.Add("jkr", ProgramGlobal.User_id);
        //    dic2.Add("fph", getfph[0]);//发票号
        //    Dictionary<String, float> dic = new Dictionary<string, float>();
        //    dic.Add("ybfy", ybfy);
        //    dic.Add("xj", float_xj);
        //    //更新his数据
        //    String sql = gyybdb.updateZyjs(zyjs_ret_Entity);
        //    sql += gyd.ybJs_Add_paragraph(dic2, message, dic, currDateTime);
        //    BllMain.Db.Update(sql);






        //    //trans.Commit();
        //    //connection.Close();
        //    return true;
        //}

        /// <summary>
        /// 正式结算 
        /// </summary>
        /// <param name="Mtzyjl_iid"></param>
        /// <returns></returns>
        //public bool CALHOSPzs(String Mtzyjl_iid, StringBuilder message, String zhzfe, String qsfs, String Cyyy, String dbz, String jsskfkfs, string currDateTime)
        //{

        //    String[] getfph = new String[1];
        //    Gyd gyd = Gyd.getGyd();
        //    string errInfo;
        //    if (!gyd.Getfphs_New(1, "1", int.Parse(ProgramGlobal.User_id), getfph, out errInfo))
        //    {
        //        message.Append("发票不足，请领回发票再进行操作");
        //        return false;
        //    }
        //    DataTable dt = gyybdb.GetRydjxx(Mtzyjl_iid);
        //    String[] param = new String[15];
        //    param[0] = dt.Rows[0]["CARDTYPE"].ToString();//卡类别
        //    param[1] = dt.Rows[0]["CARDDATA"].ToString();//磁条数据
        //    param[2] = dt.Rows[0]["SNO"].ToString();//社会保障号
        //    param[3] = dt.Rows[0]["IPADDR"].ToString();//终端机IP地址
        //    param[4] = dt.Rows[0]["PSAMNO"].ToString();//PASM卡号
        //    param[5] = dt.Rows[0]["PERSONCODE"].ToString();//个人编码
        //    param[6] = dt.Rows[0]["pwd"].ToString();//密码 
        //    param[7] = "1";//dt.Rows[0]["PASSWORD"].ToString();//是否结算
        //    param[8] = zhzfe;//账户支付额
        //    if (string.IsNullOrEmpty(zhzfe))
        //    {
        //        param[8] = "0";
        //    }

        //    param[10] = qsfs;//清算方式
        //    param[11] = dbz;//单病种编码
        //    param[12] = ProgramGlobal.Username;//操作员
        //    param[13] = currDateTime;//办理日期

        //    String fph = gyybdb.Getfph(Mtzyjl_iid);
        //    // getfph[0] = fph;
        //    param[9] = getfph[0];//发票号
        //    Zyjs zyjs = new Zyjs();
        //    String inXml = zyjs.Zyjs_head() + zyjs.Zyjs_in(param);
        //    String fy = "";
        //    DataTable SybRydjdt = gyybdb.RyjlFycx(Mtzyjl_iid);
        //    if (dt.Rows[0]["sfcx"].ToString().Equals("0"))
        //    {
        //        for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //        {
        //            String[] param2 = new String[16];
        //            param2[0] = SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //            param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //            param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //            param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //            param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //            param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //            param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //            param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //            param2[8] = SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //            param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //            param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //            param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //            param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //            param2[13] = DateTime.Parse(SybRydjdt.Rows[i]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
        //            param2[14] = "";//备注”
        //            param2[15] = "0";//冲销标志
        //            fy += zyjs.Zyjs_in2(param2);
        //        }
        //    }
        //    else
        //    {
        //        String cxstr = dt.Rows[0]["cxstr"].ToString();
        //        for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //        {
        //            String[] param2 = new String[16];
        //            param2[0] = cxstr + SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //            param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //            param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //            param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //            param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //            param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //            param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //            param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //            param2[8] = SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //            param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //            param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //            param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //            param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //            param2[13] = DateTime.Parse(SybRydjdt.Rows[i]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
        //            param2[14] = "";//备注”
        //            param2[15] = "0";//冲销标志
        //            fy += zyjs.Zyjs_in2(param2);
        //        }
        //    }

        //    inXml += fy;
        //    inXml += zyjs.Zyjs_tail();
        //    String outXml = gysybface.mnZyjs(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
        //    zyjs_ret_Entity.Centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码    
        //    zyjs_ret_Entity.Billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    zyjs_ret_Entity.Balanceid = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
        //    zyjs_ret_Entity.Hospfeeall = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
        //    zyjs_ret_Entity.Feeall = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
        //    zyjs_ret_Entity.Calfeeall = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
        //    zyjs_ret_Entity.Feeout = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
        //    zyjs_ret_Entity.Feeself = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
        //    zyjs_ret_Entity.Allowfund = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
        //    zyjs_ret_Entity.Startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //    zyjs_ret_Entity.Enterstartfee = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
        //    zyjs_ret_Entity.Fund1pay = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
        //    zyjs_ret_Entity.Fund1self = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
        //    zyjs_ret_Entity.Fund2pay = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额统筹支付
        //    zyjs_ret_Entity.Fund2self = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
        //    zyjs_ret_Entity.Acctpay = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
        //    zyjs_ret_Entity.Feeouer = ds.Tables["DATA"].Rows[0]["FEEOVER"].ToString();//超限额自付
        //    zyjs_ret_Entity.Fund3pay = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
        //    zyjs_ret_Entity.Acctbalance = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
        //    zyjs_ret_Entity.Handledte = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    zyjs_ret_Entity.Speccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
        //    zyjs_ret_Entity.Reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
        //    zyjs_ret_Entity.Singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
        //    zyjs_ret_Entity.Singleillnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
        //    zyjs_ret_Entity.Mtzyjl_iid = Mtzyjl_iid;


        //    List<Zyjs_rets> zyjs_ret_list = new List<Zyjs_rets>();

        //    String grzh = zyjs_ret_Entity.Acctpay;//个人账户支付

        //    String yjje = gyybdb.GetYjje(Mtzyjl_iid);//预交金额


        //    String gwytczf = zyjs_ret_Entity.Fund3pay;//医疗补助支付
        //    String dbzf = zyjs_ret_Entity.Fund2pay;//大额统筹支付
        //    String jbtczf = zyjs_ret_Entity.Fund1pay;//基本统筹支付

        //    float float_grzh = DataTool.stringToFloat(grzh); //个人账户支付
        //    float float_gwytczf = DataTool.stringToFloat(gwytczf);//医疗补助支付
        //    float float_dbzf = DataTool.stringToFloat(dbzf);       //大病统筹支付
        //    float float_jbtczf = DataTool.stringToFloat(jbtczf);//基本统筹支付

        //    float ybfy = float_grzh + float_gwytczf + float_dbzf + float_jbtczf;//医保费用

        //    float float_xj = DataTool.stringToFloat(zyjs_ret_Entity.Hospfeeall) - ybfy - DataTool.stringToFloat(yjje);//现金支付（最后多退少补）的钱数

        //    Dictionary<String, String> dic2 = new Dictionary<String, String>();
        //    dic2.Add("mtzyjl_iid", Mtzyjl_iid);
        //    dic2.Add("ysjefkfs", jsskfkfs);
        //    dic2.Add("mtylfkfs", "171");
        //    dic2.Add("jkr", ProgramGlobal.User_id);
        //    dic2.Add("fph", getfph[0]);//发票号
        //    Dictionary<String, float> dic = new Dictionary<string, float>();
        //    dic.Add("ybfy", ybfy);
        //    dic.Add("xj", float_xj);
        //    //更新his数据
        //    String sql = gyybdb.updateZyjs(zyjs_ret_Entity);
        //    sql += gyd.ybJs_Add_paragraph(dic2, message, dic, currDateTime);
        //    BllMain.Db.Update(sql);






        //    //trans.Commit();
        //    //connection.Close();
        //    return true;
        //}
        /// <summary>
        /// 出院登记
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        //public bool Cydj(String[] param1, StringBuilder message, string currDateTime)
        //{
        //    String Mtzyjl_iid = param1[0];
        //    DataTable cydjdt = gyybdb.GetCydj(Mtzyjl_iid);
        //    String[] param = new String[11];
        //    param[0] = cydjdt.Rows[0]["PERSONCODE"].ToString();//个人编码
        //    param[1] = cydjdt.Rows[0]["zyjlzyh"].ToString();//病案号 修改为住院号
        //    param[2] = param1[1];//icdname
        //    param[3] = "";//其他诊断
        //    param[4] = param1[2];//转归类别
        //    param[5] = cydjdt.Rows[0]["zyjlzyys"].ToString();//诊断医生
        //    param[6] = cydjdt.Rows[0]["orgname"].ToString();//科室
        //    param[7] = param1[3];//icd编码
        //    param[8] = cydjdt.Rows[0]["zyjlcysj"].ToString();//出院时间
        //    param[8] = Convert.ToDateTime(currDateTime).AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss");

        //    param[9] = ProgramGlobal.User_id;//操作员
        //    param[10] = currDateTime;//办理时间
        //    Cydj cydj = new Cydj();
        //    String InXml = cydj.Cydj_head() + cydj.Cydj_in(param) + cydj.Cydj_tail();

        //    String outXml = gysybface.cydj(InXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        MessageBox.Show(info);
        //        return false;
        //    }
        //    //String fph = gyybdb.Getfph(Mtzyjl_iid);
        //    //DataTable Sybxxdt = gyybdb.Getxx(Mtzyjl_iid);
        //    return true;
        //}
        ///// <summary>
        ///// 住院退票
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <param name="fph"></param>
        ///// <returns></returns>
        //public bool ZyTp(String Mtzyjl_iid, StringBuilder message)
        //{
        //    DataTable TpDt = gyybdb.Getxx(Mtzyjl_iid);

        //    String[] param = new String[5];
        //    param[0] = TpDt.Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    param[1] = TpDt.Rows[0]["balanceid"].ToString();//结算编号
        //    param[2] = TpDt.Rows[0]["PAYTYPE"].ToString();//支付类别
        //    param[3] = ProgramGlobal.User_id;//操作员
        //    param[4] = BillSysBase.currDate();//办理时间
        //    Tp tp = new Tp();
        //    String InXml = tp.Tp_head() + tp.Tp_in(param) + tp.Tp_tail();
        //    String outXml = gysybface.ZyTp(InXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 离休退票
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool LxTp(String Mtzyjl_iid, StringBuilder message)
        //{
        //    DataTable TpDt = gyybdb.Getxx(Mtzyjl_iid);
        //    String[] param = new String[5];
        //    param[0] = TpDt.Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    param[1] = TpDt.Rows[0]["BALANCEID"].ToString();//结算编号
        //    param[2] = TpDt.Rows[0]["PAYTYPE"].ToString();//支付类别
        //    param[3] = ProgramGlobal.User_id;//操作员
        //    param[4] = BillSysBase.currDate();//办理时间

        //    Lxtp tp = new Lxtp();
        //    String InXml = tp.Lxtp_head() + tp.Lxtp_in(param) + tp.Lxtp_tail();
        //    String outXml = gysybface.ZyLxTp(InXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 出院登记数据回退
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <param name="?"></param>
        ///// <returns></returns>
        //public bool Cydjsjht(String Mtzyjl_iid, StringBuilder message)
        //{
        //    DataTable TpDt = gyybdb.Getxx(Mtzyjl_iid);
        //    String[] parpam = new String[3];
        //    parpam[0] = TpDt.Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    parpam[1] = ProgramGlobal.User_id;//操作员
        //    parpam[2] = BillSysBase.currDate();//办理时间
        //    Cydjsjht cydjsjht = new Cydjsjht();
        //    String InXml = cydjsjht.Cydjsjht_head() + cydjsjht.Cydjsjht_in(parpam) + cydjsjht.Cydjsjht_tail();
        //    String outXml = gysybface.Cydjht(InXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 上传普通门诊数据
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool Sctpmzsj(StringBuilder message)
        //{
        //    String InXml = "";
        //    String outXml = gysybface.SctpMzsj(InXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 上传特殊门诊数据
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool Sctsmzsj(StringBuilder message)
        //{
        //    String InXml = "";
        //    String outXml = gysybface.SctpMzsj(InXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 上传住院数据
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <returns></returns>
        //public bool ScZysj(StringBuilder message)
        //{
        //    String InXml = "";
        //    String outXml = gysybface.Sczysj(InXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string info = ds.Tables["row"].Rows[0]["INFO"].ToString();//错误信息

        //    //if (!flag.Equals("0"))
        //    //{
        //    //    message.Append(info);
        //    //    return false;
        //    //}
        //    return true;
        //}
        ///// <summary>
        ///// 住院特殊结算
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool Zytsjs(String Mtzyjl_iid, StringBuilder message, String zhzfe, String qsfs, String Cyyy, String dbz)
        //{
        //    string currDateTime = BillSysBase.currDate();
        //    String[] getfph = new String[1];
        //    Gyd gyd = Gyd.getGyd();
        //    string errInfo = "";
        //    if (!gyd.Getfphs_New(1, "1", int.Parse(ProgramGlobal.User_id), getfph, out errInfo))
        //    {
        //        message.Append("发票不足，请领回发票再进行操作");
        //        return false;
        //    }
        //    DataTable dt = gyybdb.GetRydjxx(Mtzyjl_iid);
        //    String[] param = new String[8];
        //    param[0] = dt.Rows[0]["CARDTYPE"].ToString();//个人编码
        //    param[1] = "1";//是否结算
        //    param[2] = zhzfe;//账户支付额
        //    param[3] = getfph[0]; ;//发票号
        //    param[4] = qsfs;//清算方式
        //    param[5] = dbz;//单病种编码
        //    param[6] = ProgramGlobal.Username;//操作员
        //    param[7] = currDateTime;//办理日期

        //    Zytsjs zyjs = new Zytsjs();
        //    String inXml = zyjs.Zytsjs_head() + zyjs.Zytsjs_in(param);
        //    String fy = "";
        //    DataTable SybRydjdt = gyybdb.RyjlFycx(Mtzyjl_iid);
        //    for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //    {
        //        String[] param2 = new String[26];
        //        param2[0] = SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //        param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //        param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //        param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //        param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //        param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //        param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //        param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //        param2[8] = SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //        param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //        param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //        param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //        param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //        param2[13] = SybRydjdt.Rows[i]["DODATE"].ToString();//开单时间
        //        param2[14] = "";//备注
        //        param2[15] = "0";//冲销标志
        //        param2[16] = SybRydjdt.Rows[i]["WAY"].ToString();//用药途径
        //        param2[17] = SybRydjdt.Rows[i]["FREQ"].ToString();//用药频次
        //        param2[18] = SybRydjdt.Rows[i]["DOSAGE"].ToString();//单次用量
        //        param2[19] = SybRydjdt.Rows[i]["USEDAYS"].ToString();//用药天数
        //        param2[20] = SybRydjdt.Rows[i]["DRID"].ToString();//开药医师身份证号码
        //        param2[21] = SybRydjdt.Rows[i]["HOSPITEMCODE"].ToString();// 院内收费项目编码
        //        param2[22] = SybRydjdt.Rows[i]["TOTAL"].ToString();//取药总量
        //        param2[23] = SybRydjdt.Rows[i]["TOTALUNIT"].ToString();//取药总量单位
        //        param2[24] = SybRydjdt.Rows[i]["GETDAYS"].ToString();//药量天数
        //        param2[25] = SybRydjdt.Rows[i]["USEDATE"].ToString();//执行时间
        //        fy += zyjs.Zytsjs_in2(param2);
        //    }

        //    inXml += fy;
        //    inXml += zyjs.Zytsjs_tail();
        //    String outXml = gysybface.Zytsjs(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
        //    zyjs_ret_Entity.Centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码    
        //    zyjs_ret_Entity.Billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    zyjs_ret_Entity.Balanceid = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
        //    zyjs_ret_Entity.Hospfeeall = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
        //    zyjs_ret_Entity.Feeall = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
        //    zyjs_ret_Entity.Calfeeall = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
        //    zyjs_ret_Entity.Feeout = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
        //    zyjs_ret_Entity.Feeself = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
        //    zyjs_ret_Entity.Allowfund = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
        //    zyjs_ret_Entity.Startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //    zyjs_ret_Entity.Enterstartfee = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
        //    zyjs_ret_Entity.Fund1pay = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
        //    zyjs_ret_Entity.Fund1self = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
        //    zyjs_ret_Entity.Fund2pay = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额统筹支付
        //    zyjs_ret_Entity.Fund2self = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
        //    zyjs_ret_Entity.Acctpay = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
        //    zyjs_ret_Entity.Fund3pay = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
        //    zyjs_ret_Entity.Acctbalance = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
        //    zyjs_ret_Entity.Handledte = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    zyjs_ret_Entity.Speccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
        //    zyjs_ret_Entity.Reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
        //    zyjs_ret_Entity.Singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
        //    zyjs_ret_Entity.Singleillnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
        //    zyjs_ret_Entity.Mtzyjl_iid = Mtzyjl_iid;

        //    String sql = gyybdb.updateZyjs(zyjs_ret_Entity);
        //    List<Zyjs_rets> zyjs_ret_list = new List<Zyjs_rets>();

        //    //DataTable yjkdata = szybdb.GetJsxx(mtzyjl_iid);///查询预交款所需信息
        //    String grzh = zyjs_ret_Entity.Acctpay;//个人账户支付

        //    String yjje = gyybdb.GetYjje(Mtzyjl_iid);//预交金额


        //    String gwytczf = zyjs_ret_Entity.Fund3pay;//医疗补助支付
        //    String dbzf = zyjs_ret_Entity.Fund2pay;//大额统筹支付
        //    String jbtczf = zyjs_ret_Entity.Fund1pay;//基本统筹支付

        //    float float_grzh = DataTool.stringToFloat(grzh); //个人账户支付
        //    //float float_xj = util.Getfloat(xj);   //现金支付
        //    float float_gwytczf = DataTool.stringToFloat(gwytczf);//医疗补助支付
        //    float float_dbzf = DataTool.stringToFloat(dbzf);       //大病统筹支付
        //    float float_jbtczf = DataTool.stringToFloat(jbtczf);//基本统筹支付

        //    float ybfy = float_grzh + float_gwytczf + float_dbzf + float_jbtczf;//医保费用

        //    float float_xj = DataTool.stringToFloat(zyjs_ret_Entity.Hospfeeall) - ybfy - DataTool.stringToFloat(yjje);//现金支付（最后多退少补）的钱数

        //    Dictionary<String, String> dic2 = new Dictionary<String, String>();
        //    dic2.Add("mtzyjl_iid", Mtzyjl_iid);
        //    dic2.Add("mtylfkfs", "171");
        //    dic2.Add("jkr", ProgramGlobal.User_id);
        //    dic2.Add("fph", getfph[0]);//发票号
        //    Dictionary<String, float> dic = new Dictionary<string, float>();
        //    dic.Add("ybfy", ybfy);
        //    dic.Add("xj", float_xj);
        //    //出院办理
        //    DataTable cysrxx = szybdb.Getcybzxx(Mtzyjl_iid);
        //    String[] param3 = new String[4];
        //    param3[0] = Mtzyjl_iid;
        //    param3[1] = cysrxx.Rows[0]["ssmc"].ToString();
        //    param3[2] = Cyyy;
        //    param3[3] = cysrxx.Rows[0]["ssbm"].ToString();
        //    if (!Cydj(param3, message, currDateTime))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    //更新his数据
        //    sql += gyybdb.InsertintoZyjsfy(zyjs_ret_list);
        //    sql += gyd.ybJs_Add_paragraph(dic2, message, dic, currDateTime);

        //    if (BllMain.Db.Update(sql) == -1)
        //    {
        //        message.Append("医保结算成功，更新his失败！");
        //        return false;
        //    }


        //    //trans.Commit();
        //    //connection.Close();
        //    return true;
        //}
        ///// <summary>
        ///// 模拟住院特殊结算
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <param name="message"></param>
        ///// <param name="zhzfe"></param>
        ///// <param name="qsfs"></param>
        ///// <returns></returns>
        //public Dictionary<String, Zyjs_ret> Mnzytsjs(String Mtzyjl_iid, StringBuilder message, String qsfs)
        //{
        //    DataTable dt = gyybdb.GetRydjxx(Mtzyjl_iid);
        //    String[] param = new String[8];
        //    param[0] = dt.Rows[0]["CARDTYPE"].ToString();//个人编码
        //    param[1] = "0";//是否结算
        //    param[2] = "0.00";//账户支付额
        //    param[3] = "";//发票号
        //    param[4] = qsfs;//清算方式
        //    param[5] = dt.Rows[0]["SINGLEILLNESSCODE"].ToString();//单病种编码
        //    param[6] = ProgramGlobal.Username;//操作员
        //    param[7] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");//办理日期
        //    Zytsjs zyjs = new Zytsjs();
        //    String inXml = zyjs.Zytsjs_head() + zyjs.Zytsjs_in(param);
        //    String fy = "";
        //    DataTable SybRydjdt = gyybdb.RyjlFycx(Mtzyjl_iid);
        //    for (int i = 0; i < SybRydjdt.Rows.Count; i++)
        //    {
        //        String[] param2 = new String[26];
        //        param2[0] = SybRydjdt.Rows[i]["ITEMSERIAL"].ToString();//数据批号
        //        param2[1] = SybRydjdt.Rows[i]["ITEMCODE"].ToString();//医保编码
        //        param2[2] = SybRydjdt.Rows[i]["ITEMNAME"].ToString();//项目名称
        //        param2[3] = SybRydjdt.Rows[i]["SUBJECT"].ToString();//发票归属科目编码
        //        param2[4] = SybRydjdt.Rows[i]["SPECIFICATION"].ToString();//规格
        //        param2[5] = SybRydjdt.Rows[i]["AGENTTYPE"].ToString();// 剂型
        //        param2[6] = SybRydjdt.Rows[i]["UNIT"].ToString();//单位
        //        param2[7] = SybRydjdt.Rows[i]["PRICE"].ToString();//单价
        //        param2[8] = SybRydjdt.Rows[i]["QUANTITY"].ToString();//数量
        //        param2[9] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//开单科室
        //        param2[10] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//开单医生
        //        param2[11] = SybRydjdt.Rows[i]["FROMOFFICE"].ToString();//受单科室
        //        param2[12] = SybRydjdt.Rows[i]["FROMDOCT"].ToString();//受单医生
        //        param2[13] = SybRydjdt.Rows[i]["DODATE"].ToString();//开单时间
        //        param2[14] = "";//备注
        //        param2[15] = "0";//冲销标志
        //        param2[16] = SybRydjdt.Rows[i]["WAY"].ToString();//用药途径
        //        param2[17] = SybRydjdt.Rows[i]["FREQ"].ToString();//用药频次
        //        param2[18] = SybRydjdt.Rows[i]["DOSAGE"].ToString();//单次用量
        //        param2[19] = SybRydjdt.Rows[i]["USEDAYS"].ToString();//用药天数
        //        param2[20] = SybRydjdt.Rows[i]["DRID"].ToString();//开药医师身份证号码
        //        param2[21] = SybRydjdt.Rows[i]["HOSPITEMCODE"].ToString();// 院内收费项目编码
        //        param2[22] = SybRydjdt.Rows[i]["TOTAL"].ToString();//取药总量
        //        param2[23] = SybRydjdt.Rows[i]["TOTALUNIT"].ToString();//取药总量单位
        //        param2[24] = SybRydjdt.Rows[i]["GETDAYS"].ToString();//药量天数
        //        param2[25] = SybRydjdt.Rows[i]["USEDATE"].ToString();//执行时间
        //        fy += zyjs.Zytsjs_in2(param2);
        //    }

        //    inXml += fy;
        //    inXml += zyjs.Zytsjs_tail();
        //    String outXml = gysybface.Zytsjs(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
        //    Dictionary<String, Zyjs_ret> dic = new Dictionary<string, Zyjs_ret>();
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        dic.Add("zyjs_ret", zyjs_ret_Entity);
        //        return dic;
        //    }
        //    //Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
        //    zyjs_ret_Entity.Centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码    
        //    zyjs_ret_Entity.Billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    zyjs_ret_Entity.Balanceid = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
        //    zyjs_ret_Entity.Hospfeeall = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
        //    zyjs_ret_Entity.Feeall = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
        //    zyjs_ret_Entity.Calfeeall = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
        //    zyjs_ret_Entity.Feeout = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
        //    zyjs_ret_Entity.Feeself = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
        //    zyjs_ret_Entity.Allowfund = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
        //    zyjs_ret_Entity.Startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //    zyjs_ret_Entity.Enterstartfee = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
        //    zyjs_ret_Entity.Fund1pay = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
        //    zyjs_ret_Entity.Fund1self = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
        //    zyjs_ret_Entity.Fund2pay = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额统筹支付
        //    zyjs_ret_Entity.Fund2self = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
        //    zyjs_ret_Entity.Feeouer = ds.Tables["DATA"].Rows[0]["FEEOVER"].ToString();//超限额自付
        //    zyjs_ret_Entity.Acctpay = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
        //    zyjs_ret_Entity.Fund3pay = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
        //    zyjs_ret_Entity.Acctbalance = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
        //    zyjs_ret_Entity.Handledte = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    zyjs_ret_Entity.Speccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
        //    zyjs_ret_Entity.Reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
        //    zyjs_ret_Entity.Singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
        //    zyjs_ret_Entity.Singleillnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称

        //    //更新his数据
        //    dic.Add("zyjs_ret", zyjs_ret_Entity);
        //    return dic;
        //}


        //public bool tranToRealData(double card_zhzf, Dictionary<String, double> sou_dic, Dictionary<String, double> des_dic)
        //{
        //    des_dic.Clear();
        //    double sumtotal = card_zhzf;

        //    foreach (KeyValuePair<String, double> cur in sou_dic)
        //    {
        //        double cur_value = cur.Value;
        //        if (sumtotal == 0)
        //        {
        //            des_dic.Add(cur.Key, 0);
        //            continue;
        //        }
        //        if (sumtotal >= cur_value)
        //        {
        //            des_dic.Add(cur.Key, cur_value);
        //            sumtotal -= cur_value;
        //            continue;
        //        }
        //        if (sumtotal < cur_value)
        //        {
        //            des_dic.Add(cur.Key, sumtotal);
        //            sumtotal = 0;
        //        }
        //    }
        //    return true;

        //}
        ////////////////////////门诊//////////////////////
        //////////////////////////////////////////////////


        /// <summary>
        /// 门诊结算流程
        /// </summary>
        /// <returns></returns>
        //public bool mzjslc_kls(String Mtmzblstuff_iid, Sybdk_Entity sybdk_entity, StringBuilder message, double[] yb)
        //{
        //    //医保门诊挂号
        //    if (!mzgh_kls(sybdk_entity, message))
        //        return false;


        //    SybMzjs_Entity sybmzjs_entity = null;  //new SybMzjs_Entity();


        //    //DataTable Mzfyxxdt = gyybdb.GetSybMzjsxx1_kls(Mtmzblstuff_iid);
        //    //for (int i = 0; i < Mzfyxxdt.Rows.Count; i++) //根据发票号循环结算
        //    //{
        //    //    String fph = Mzfyxxdt.Rows[i]["fph"].ToString();
        //    String once_zhzf = "";
        //    //医保模拟结算
        //    if (!mzmnjs_kls(sybdk_entity, Mtmzblstuff_iid, fph, sybmzjs_entity, out once_zhzf, message))
        //        return false;
        //    //医保正式结算
        //    if (!mzzsjs_kls(sybdk_entity, Mtmzblstuff_iid, fph, ref once_zhzf, yb, message))
        //        return false;
        //    //}

        //    return true;
        //}

        ///// <summary>
        ///// 门诊结算流程
        ///// </summary>
        ///// <returns></returns>
        //public bool mzjslc_kls2(String Mtmzblstuff_iid, Sybdk_Entity sybdk_entity, StringBuilder message, double[] yb)
        //{
        //    //医保门诊挂号
        //    if (!mzgh_kls(sybdk_entity, message))
        //        return false;


        //    SybMzjs_Entity sybmzjs_entity = null;// new SybMzjs_Entity();


        //    //DataTable Mzfyxxdt = gyybdb.GetSybMzjsxx1_kls2(Mtmzblstuff_iid);
        //    //for (int i = 0; i < Mzfyxxdt.Rows.Count; i++) //根据发票号循环结算
        //    //{
        //    //    String fph = Mzfyxxdt.Rows[i]["fph"].ToString();
        //    String once_zhzf = "";
        //    //医保模拟结算
        //    if (!mzmnjs_kls2(sybdk_entity, Mtmzblstuff_iid, fph, sybmzjs_entity, out once_zhzf, message, yb))
        //        return false;
        //    //}

        //    return true;
        //}

       
        ///// <summary>
        ///// 门诊挂号
        ///// </summary>
        ///// <returns></returns>
        public bool mzgh_kls(Sybdk_Entity sybdk_entity, StringBuilder message)
        {
            string currtime = BillSysBase.currDate();
            String[] parpam = new String[3];
            parpam[0] = sybdk_entity.Grbh;//个人编码
            parpam[1] = ProgramGlobal.User_id;//操作员
            parpam[2] = currtime;//办理时间

            Ptmzgh ptmzgh = new Ptmzgh();
            String InXml = ptmzgh.Ptmzgh_head() + ptmzgh.Ptmzgh_in(parpam) + ptmzgh.Ptmzgh_tail();

            String outXml = gysybface.Ptmzgh(InXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            string bllNo = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间

            String sql = " INSERT INTO insur_gysyb_mtmzblstuff("
                     + " iid, klb, ctsj, shbzh, grbm, zdjipdz, pasmkh, bxlb, mm, sickname,"
                     + " qfx, dyksxssj, gsrdbh, billno, handledate,oprname,jsfs,qsfs,zflb)"
                     + " VALUES ("
                     + sybdk_entity.Mzmzblstuff_iid + ",'" + sybdk_entity.Klb + "','" + sybdk_entity.Ctsj + "','" + sybdk_entity.Sfzhm + "','"
                     + sybdk_entity.Grbh + "','" + sybdk_entity.Zdjipdz + "','" + sybdk_entity.Pasmkh + "','" + sybdk_entity.Bxlb + "','" + sybdk_entity.Mm + "','"
                     + sybdk_entity.Xm + "','" + sybdk_entity.Bcqfx + "','" + sybdk_entity.Dyksxssj + "','" + sybdk_entity.Gsrdbh + "','" + bllNo + "','" + handledate + "','" + parpam[1] + "','0','" + sybdk_entity.Qsfs + "','" + sybdk_entity.Zflb + "');";

            if (BllMain.Db.Update(sql) == -1)
            {
                message.Append("市医保门诊挂号his更新数据错误");
                return false;
            }
            return true;
        }


        /// <summary>
        /// 门诊正式结算
        /// </summary>
        /// <returns></returns>
        public bool mzzsjs_kls(Sybdk_Entity sybdk_entity, ClinicInvoice clinicInvoice, ref  String strzhzf, string[] yb, StringBuilder message)
        {

         
            if (strzhzf.Trim() == "")
            {
                strzhzf = "0";
            }
            String InXml = "";
            Ptmzjs ptmzjs = new Ptmzjs();
            Tsmzjs mzjs = new Tsmzjs();
            if (sybdk_entity.Zflb.Equals("18"))
            {
                String[] parpam = new String[16];
                parpam[0] = sybdk_entity.Klb;//卡类别
                parpam[1] = sybdk_entity.Ctsj;//磁条数据
                parpam[2] = sybdk_entity.Sfzhm;//社会保障号
                parpam[3] = sybdk_entity.Grbh;//个人编码
                parpam[4] = sybdk_entity.Zdjipdz;//终端机IP地址
                parpam[5] = sybdk_entity.Pasmkh;//PASM卡号
                parpam[6] = sybdk_entity.Mm;//密码
                parpam[7] = sybdk_entity.Bxlb;//保险类别
                parpam[8] = sybdk_entity.Tbzbm;//特种病编码
                parpam[9] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");
                parpam[10] = "1";//是否结算                

                parpam[11] = "0";//是否严控特殊项目     0：不严控；1：严控  
                parpam[12] = strzhzf;//zhzf.ToString();//发票号//strzhzf;//账户支付额                
                parpam[13] = clinicInvoice.Invoice;//fph_zyfs.Rows[i]["fph"].ToString();//发票号
                parpam[14] = sybdk_entity.Cfbh;//处方本编号
                parpam[15] = ProgramGlobal.User_id;//操作员
                parpam[16] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");

                InXml = mzjs.Tsmzjs_head() + mzjs.Tsmzjs_in(parpam);
            }
            else
            {
                String[] parpam = new String[17];
                parpam[0] = sybdk_entity.Klb;//卡类别
                parpam[1] = sybdk_entity.Ctsj;//磁条数据
                parpam[2] = sybdk_entity.Sfzhm;//社会保障号
                parpam[3] = sybdk_entity.Grbh;//个人编码
                parpam[4] = sybdk_entity.Zdjipdz;//终端机IP地址
                parpam[5] = sybdk_entity.Pasmkh;//PASM卡号
                parpam[6] = sybdk_entity.Mm;//密码
                parpam[7] = sybdk_entity.Bxlb;//保险类别
                parpam[8] = "1";//是否结算
                parpam[9] = sybdk_entity.Jsfs;//结算方式
                parpam[10] = ""; //gyyb.Dbzbm;//单病种编码

                parpam[11] = "0";//是否严控特殊项目     0：不严控；1：严控  
                parpam[12] = strzhzf;//zhzf.ToString();//strzhzf;//账户支付额
                parpam[13] = clinicInvoice.Invoice;//fph_zyfs.Rows[i]["fph"].ToString();//发票号
                parpam[14] = ProgramGlobal.User_id;//操作员
                parpam[15] = Convert.ToDateTime(clinicInvoice.Chargedate).ToString("yyyy-MM-dd HH:mm:ss");
                parpam[16] = Convert.ToDateTime(clinicInvoice.Chargedate).ToString("yyyy-MM-dd HH:mm:ss"); ;///Mzfyxxdt.Rows[0]["dyksxssj"].ToString();//待遇开始享受时间
                parpam[17] = sybdk_entity.Gsrdbh; //Mzfyxxdt.Rows[0]["gsrdbh"].ToString();//工伤认定编号
                InXml = ptmzjs.Ptmzjs_head() + ptmzjs.Ptmzjs_in(parpam);
            }
            
            InXml += ptmzjs.Ptmzjs_top();
            DataTable costdetItem = bllInsur.getClinCostdet(clinicInvoice.Clinic_costdet_ids, "Y");
            if (costdetItem == null) 
            {
                return false;
            }
            for (int b = 0; b < costdetItem.Rows.Count; b++)
            {
                String[] parpam2 = new String[14];
                parpam2[0] = costdetItem.Rows[b]["ITEMCODE"].ToString();//医保编码
                if (parpam2[0].Equals(""))
                {
                    parpam2[0] = "34999999";
                }
                parpam2[1] = costdetItem.Rows[b]["ITEMNAME"].ToString();//项目名称
                if (parpam2[1].Equals(""))
                {
                    parpam2[1] = "全自费";
                }
                parpam2[2] = costdetItem.Rows[b]["SUBJECT"].ToString();//发票归属科目编码
                parpam2[3] = costdetItem.Rows[b]["SPECIFICATION"].ToString();//规格
                parpam2[4] = costdetItem.Rows[b]["AGENTTYPE"].ToString();//剂型
                parpam2[5] = costdetItem.Rows[b]["UNIT"].ToString();//单位
                parpam2[6] = costdetItem.Rows[b]["PRICE"].ToString();//单价
                parpam2[7] = costdetItem.Rows[b]["QUANTITY"].ToString();//数量
                parpam2[8] = costdetItem.Rows[b]["FROMOFFICE"].ToString();//开单科室
                parpam2[9] = costdetItem.Rows[b]["FROMDOCT"].ToString();//开单医生
                parpam2[10] = costdetItem.Rows[b]["FROMOFFICE"].ToString();//受单科室
                parpam2[11] = costdetItem.Rows[b]["FROMDOCT"].ToString();//受单医生
                parpam2[12] = DateTime.Parse(costdetItem.Rows[b]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
                parpam2[13] = "";//备注

                parpam2[14] = "";//用药途径
                parpam2[15] = "";//用药频次
                parpam2[16] = "";//单次用量
                parpam2[17] = "";//用药天数   
                parpam2[18] = costdetItem.Rows[b]["cardid"].ToString();//身份证号
                parpam2[19] = costdetItem.Rows[b]["item_id"].ToString();// 院内收费项目编码
                parpam2[20] = "";//取药总量
                parpam2[21] = "";//取药总量单位
                parpam2[22] = "";//药量天数
                parpam2[23] = DateTime.Parse(costdetItem.Rows[b]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//执行时间
                InXml += ptmzjs.Ptmzjs_in2(parpam2);
            }
            InXml += ptmzjs.Ptmzjs_tail2();
            InXml += ptmzjs.Ptmzjs_tail();

            //////////////////////////////////////////
            //string sql_k = "insert into gzyb_mzblstuff_bak (mtmzblstuff,inxml1) values (" + Mtmzblstuff_iid + ",'" + InXml + "');";
            //HISDB hisdb = new HISDB();
            //hisdb.Update(sql_k);
            /////////////////////////////////////////////
            String outXml = "";
            if (sybdk_entity.Zflb.Equals("18"))
            {
                outXml = gysybface.Tsmzjs(InXml);
            }
            else
            {
                outXml = gysybface.Ptmzjs(InXml);
            }
            StringReader sr = new StringReader(outXml);

            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (!flag.Equals("0"))
            {
                if (sybdk_entity.Zflb.Equals("18"))
                {
                    outXml = gysybface.Tsmzjs(InXml);
                }
                else
                {
                    outXml = gysybface.Ptmzjs(InXml);
                }
                StringReader sr2 = new StringReader(outXml);
                //DataSet ds2 = new DataSet();
                ds.ReadXml(sr2);
                string flag2 = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
                string info2 = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
                if (!flag2.Equals("0"))
                {
                    if (sybdk_entity.Zflb.Equals("18"))
                    {
                        outXml = gysybface.Tsmzjs(InXml);
                    }
                    else
                    {
                        outXml = gysybface.Ptmzjs(InXml);
                    }
                    StringReader sr3 = new StringReader(outXml);
                    //DataSet ds3 = new DataSet();
                    ds.ReadXml(sr3);
                    string flag3 = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
                    string info3 = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
                    if (!flag3.Equals("0"))
                    {
                        message.Append(info);
                        return false;
                    }
                }
            }
            double pt_ybbx = 0;
            double lx_ybbx = 0;
            double zhzf = 0;
            double ybbx = 0;
            SybMzjs_Entity sybmzjs_entity = new SybMzjs_Entity();
            // sybmzjs_entity.Gysyb_mtmzblstuff_iid = Mtmzblstuff_iid;
            string sbqfx = ds.Tables["DATA"].Rows[0]["SBSTARTFEE"].ToString();//商保起付线
            sybmzjs_entity.Sbstartfee = sbqfx;

            string sbzf = ds.Tables["DATA"].Rows[0]["SBPAY"].ToString();//商保支付

            sybmzjs_entity.Sbpay = sbzf;
            string fzxbm = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码
            sybmzjs_entity.Fzxbm = fzxbm;

            string jzsxh = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
            sybmzjs_entity.Jzsxh = jzsxh;
            string jsbm = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
            sybmzjs_entity.Jsbm = jsbm;
            string yyzfy = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
            sybmzjs_entity.Yyzfy = DataTool.stringToDouble(yyzfy);
            string jszfy = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
            sybmzjs_entity.Jszfy = DataTool.stringToDouble(jszfy);
            string ybzfy = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
            sybmzjs_entity.Ybzfy = DataTool.stringToDouble(ybzfy);
            string qzf = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
            sybmzjs_entity.Qzf = DataTool.stringToDouble(qzf);
            string ggzf = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
            sybmzjs_entity.Ggzf = DataTool.stringToDouble(ggzf);
            string yxbx = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
            sybmzjs_entity.Yxbx = DataTool.stringToDouble(yxbx);
            lx_ybbx += DataTool.stringToDouble(yxbx);

            string grzhzf = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
            zhzf += DataTool.stringToDouble(grzhzf);
            sybmzjs_entity.Grzhzf = DataTool.stringToDouble(grzhzf);

            string ptmzylbzqfx = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//普通门诊医疗补助起付线
            sybmzjs_entity.Ptmzylbzqfx = ptmzylbzqfx;

            string ylbzzf = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
            sybmzjs_entity.Ylbzzf = DataTool.stringToDouble(ylbzzf);
            pt_ybbx += DataTool.stringToDouble(ylbzzf);
            string jjtczf = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
            sybmzjs_entity.Jjtczf = DataTool.stringToDouble(jjtczf);
            pt_ybbx += DataTool.stringToDouble(jjtczf);
            string debzzf = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额补助支付
            sybmzjs_entity.Debzzf = DataTool.stringToDouble(debzzf);
            pt_ybbx += DataTool.stringToDouble(debzzf);
            if (sybdk_entity.Bxlb == "2")
            {
                sybmzjs_entity.Debzzf = DataTool.stringToDouble(yxbx);
            }

            string cxezf = ds.Tables["DATA"].Rows[0]["FEEOVER"].ToString();//超限额自付
            sybmzjs_entity.Cxezf = DataTool.stringToDouble(cxezf);
            string grzhye = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
            sybmzjs_entity.Grzhye = DataTool.stringToDouble(grzhye);
            string xtclsj = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            sybmzjs_entity.Xtclsj = xtclsj;
            string tsjsbz = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
            sybmzjs_entity.Tsjsbz = tsjsbz;
            string tsjssm = ds.Tables["DATA"].Rows[0]["SPECCALFLAGTXT"].ToString();//特殊结算说明
            sybmzjs_entity.Tsjssm = tsjssm;
            sybmzjs_entity.Fph = clinicInvoice.Invoice;
            if (sybdk_entity.Zflb.Equals("18"))
            {
                string jrqfx = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
                sybmzjs_entity.Jrqfx = jrqfx;
                string FUND1SELF = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
                sybmzjs_entity.FUND1SELF = FUND1SELF;
                string FUND2SELF = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
                sybmzjs_entity.FUND2SELF = FUND2SELF;
            }
            else
            {
                string bndptmzylbzqfx = ds.Tables["DATA"].Rows[0]["STARTFEE2STD"].ToString();//本年度普通门诊医疗补助起付标准
                sybmzjs_entity.Bndptmzylbzqfx = bndptmzylbzqfx;
                string ptmzylbzlj = ds.Tables["DATA"].Rows[0]["ENTERLMT3"].ToString();//普通门诊医疗补助累计
                sybmzjs_entity.Ptmzylbzlj = ptmzylbzlj;
            }

            String sql2 = "";
            if (!sybdk_entity.Zflb.Equals("18"))
            {


                sql2 += "delete from gysyb_mz where gysyb_mtmzblstuff_iid='" + clinicInvoice.Id + "'; INSERT INTO gysyb_mz("
                    + "  gysyb_mtmzblstuff_iid, fzxbm, jzsxh, jsbm, yyzfy, jszfy, ybzfy,"
                    + " qzf, ggzf, yxbx, grzhzf, bndptmzylbzqfx, ptmzylbzqfx, ptmzylbzlj, "
                    + " ylbzzf, jjtczf, detczf, cxezf, grzhye, xtclsj, tsjsbz, tsjssm, "
                    + " fph,sfy,sfsj,sbstartfee,sbpay,zflb,bxlb,grbh,xm)"



                    + " VALUES ('"
                    + clinicInvoice.Id + "','" + sybmzjs_entity.Fzxbm + "','" + sybmzjs_entity.Jzsxh + "','" + sybmzjs_entity.Jsbm + "','"
                    + sybmzjs_entity.Yyzfy + "','" + sybmzjs_entity.Jszfy + "','" + sybmzjs_entity.Ybzfy + "','" + sybmzjs_entity.Qzf + "','" + sybmzjs_entity.Ggzf + "','"
                    + sybmzjs_entity.Yxbx + "','" + sybmzjs_entity.Grzhzf + "','" + sybmzjs_entity.Bndptmzylbzqfx + "','" + sybmzjs_entity.Ptmzylbzqfx + "','"
                    + sybmzjs_entity.Ptmzylbzlj + "','" + sybmzjs_entity.Ylbzzf + "','" + sybmzjs_entity.Jjtczf + "','" + sybmzjs_entity.Debzzf + "','"
                    + sybmzjs_entity.Cxezf + "','" + sybmzjs_entity.Grzhye + "','" + sybmzjs_entity.Xtclsj + "','" + sybmzjs_entity.Tsjsbz + "','" + sybmzjs_entity.Tsjssm + "','"
                    + sybmzjs_entity.Fph + "','" + ProgramGlobal.Username + "','" + BillSysBase.currDate() + "','" + sybmzjs_entity.Sbstartfee + "','" + sybmzjs_entity.Sbpay + "'"
                    + "," + DataTool.addFieldBraces(sybdk_entity.Zflb) + "," + DataTool.addFieldBraces(sybdk_entity.Bxlb) + "," + DataTool.addFieldBraces(sybdk_entity.Grbh) + "," + DataTool.addFieldBraces(sybdk_entity.Xm) + ");";
                BllMain.Db.Update(sql2);
            }
            else
            {
                sql2 += "delete from gysyb_mz where gysyb_mtmzblstuff_iid='" + clinicInvoice.Id + "'; INSERT INTO gysyb_mz("
                + "  gysyb_mtmzblstuff_iid, fzxbm, jzsxh, jsbm, yyzfy, jszfy, ybzfy,"
                + " qzf, ggzf, yxbx, grzhzf, bndptmzylbzqfx, ptmzylbzqfx, ptmzylbzlj, "
                + " ylbzzf, jjtczf, detczf, cxezf, grzhye, xtclsj, tsjsbz, tsjssm, "
                + " fph,sfy,sfsj,jrqfx,fund1self,fund2self,sbstartfee,sbpay,zflb,bxlb,grbh,xm)"
                + " VALUES ('"
                + clinicInvoice.Id + "','" + sybmzjs_entity.Fzxbm + "','" + sybmzjs_entity.Jzsxh + "','" + sybmzjs_entity.Jsbm + "','"
                + sybmzjs_entity.Yyzfy + "','" + sybmzjs_entity.Jszfy + "','" + sybmzjs_entity.Ybzfy + "','" + sybmzjs_entity.Qzf + "','" + sybmzjs_entity.Ggzf + "','"
                + sybmzjs_entity.Yxbx + "','" + sybmzjs_entity.Grzhzf + "','" + sybmzjs_entity.Bndptmzylbzqfx + "','" + sybmzjs_entity.Ptmzylbzqfx + "','"
                + sybmzjs_entity.Ptmzylbzlj + "','" + sybmzjs_entity.Ylbzzf + "','" + sybmzjs_entity.Jjtczf + "','" + sybmzjs_entity.Debzzf + "','"
                + sybmzjs_entity.Cxezf + "','" + sybmzjs_entity.Grzhye + "','" + sybmzjs_entity.Xtclsj + "','" + sybmzjs_entity.Tsjsbz + "','" + sybmzjs_entity.Tsjssm + "','"
                + sybmzjs_entity.Fph + "','" + ProgramGlobal.Username + "','" + BillSysBase.currDate() + "','" + sybmzjs_entity.Jrqfx + "','" + sybmzjs_entity.FUND1SELF + "','" + sybmzjs_entity.FUND2SELF
                + "','" + sybmzjs_entity.Sbstartfee + "','" + sybmzjs_entity.Sbpay + "'"
                    + "," + DataTool.addFieldBraces(sybdk_entity.Zflb) + "," + DataTool.addFieldBraces(sybdk_entity.Bxlb) + "," + DataTool.addFieldBraces(sybdk_entity.Grbh) + "," + DataTool.addFieldBraces(sybdk_entity.Xm) + ");";
                BllMain.Db.Update(sql2);
            }
         
          
            List<SybMzjs_ret_fy_Entity> sybmzjs_ret_entitys = new List<SybMzjs_ret_fy_Entity>();
            for (int b = 0; b < ds.Tables["ROW"].Rows.Count; b++)
            {
                SybMzjs_ret_fy_Entity sybmzjs_ret_entity = new SybMzjs_ret_fy_Entity();
                string ybbm = ds.Tables["ROW"].Rows[b]["ITEMCODE"].ToString();//医保编码
                sybmzjs_ret_entity.Ybbm = ybbm;
                string xmmc = ds.Tables["ROW"].Rows[b]["ITEMNAME"].ToString();//项目名称
                sybmzjs_ret_entity.Xmmc = xmmc;
                string yydj = ds.Tables["ROW"].Rows[b]["HOSPPRICE"].ToString();//医院单价
                sybmzjs_ret_entity.Yydj = yydj;
                string ybdj = ds.Tables["ROW"].Rows[b]["PRICE"].ToString();//医保单价
                sybmzjs_ret_entity.Ybdj = ybdj;
                string sl = ds.Tables["ROW"].Rows[b]["QUANTITY"].ToString();//数量
                sybmzjs_ret_entity.Sl = sl;
                string zfbl = ds.Tables["ROW"].Rows[b]["SELFRATE"].ToString();//自付比例
                sybmzjs_ret_entity.Zfbl = zfbl;
                string tsbxxmbz = ds.Tables["ROW"].Rows[b]["SPECPAYFLAG"].ToString();//特殊报销项目标志
                sybmzjs_ret_entity.Tsbxxmbz = tsbxxmbz;
                string bgjsxmlb = ds.Tables["ROW"].Rows[b]["BGITEMTYPE"].ToString();//包干结算项目类别
                sybmzjs_ret_entity.Bgjsxmlb = bgjsxmlb;
                sybmzjs_ret_entitys.Add(sybmzjs_ret_entity);
                sybmzjs_ret_entity.Fph = sybmzjs_entity.Fph;//发票号
                ////sql += gyybdb.GetMzjsfymx(sybmzjs_ret_entity);
                ////sql_bak += gyybdb.GetMzjsfymx_bak(sybmzjs_ret_entity);
            }

            if (sybdk_entity.Bxlb == "2")
            {
                ybbx = lx_ybbx;

            }
            else
                ybbx = pt_ybbx;

            yb[0] = zhzf.ToString();
            yb[1] = ybbx.ToString();
            yb[2] = sbqfx;
            yb[3] = sbzf;
            yb[4] = fzxbm;
       
            return true;
        }
       

        // <summary>
        /// 门诊模拟结算
        /// </summary>
        /// <returns></returns>
        public bool mzmnjs_kls2(Sybdk_Entity sybdk_entity, String costdetIds, String fph,  StringBuilder message, double[] yb)
        {
            String InXml = "";
            Tsmzjs mzjs = new Tsmzjs();
            Ptmzjs ptmzjs = new Ptmzjs();
            if (sybdk_entity.Zflb.Equals("18"))
            {
                String[] parpam = new String[16];
                parpam[0] = sybdk_entity.Klb;//卡类别
                parpam[1] = sybdk_entity.Ctsj;//磁条数据
                parpam[2] = sybdk_entity.Sfzhm;//社会保障号
                parpam[3] = sybdk_entity.Grbh;//个人编码
                parpam[4] = sybdk_entity.Zdjipdz;//终端机IP地址
                parpam[5] = sybdk_entity.Pasmkh;//PASM卡号
                parpam[6] = sybdk_entity.Mm;//密码
                parpam[7] = sybdk_entity.Bxlb;//保险类别
                parpam[8] = sybdk_entity.Tbzbm;//特种病编码
                parpam[9] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");//待遇开始享受时间
                parpam[10] = "0";//是否结算
                parpam[11] = "0";////账户支付额
                parpam[12] = fph;//Mzfyxxdt.Rows[i]["fph"].ToString();//发票号
                parpam[13] = sybdk_entity.Cfbh;//处方本编号
                parpam[14] = ProgramGlobal.User_id;//操作员
                parpam[15] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");//办理日期
                InXml = mzjs.Tsmzjs_head() + mzjs.Tsmzjs_in(parpam) + mzjs.Ptmzjs_top();
            }
            else
            {
                String[] parpam = new String[17];
                parpam[0] = sybdk_entity.Klb;//卡类别
                parpam[1] = sybdk_entity.Ctsj;//磁条数据
                parpam[2] = sybdk_entity.Sfzhm;//社会保障号
                parpam[3] = sybdk_entity.Grbh;//个人编码
                parpam[4] = sybdk_entity.Zdjipdz;//终端机IP地址
                parpam[5] = sybdk_entity.Pasmkh;//PASM卡号
                parpam[6] = sybdk_entity.Mm;//密码
                parpam[7] = sybdk_entity.Bxlb;//保险类别
                parpam[8] = "0";//是否结算
                parpam[9] = "0";// sybdk_entity.Jsfs;//结算方式------ 按项目结算
                parpam[10] = "";//gyyb.Dbzbm;//单病种编码------icd编码
                parpam[11] = "0";// Mzfyxxdt.Rows[i]["amt"].ToString();//账户支付额
                parpam[12] = fph;//Mzfyxxdt.Rows[i]["fph"].ToString();//发票号
                parpam[13] = ProgramGlobal.Username;//操作员
                parpam[14] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");//办理日期
                parpam[15] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");//Mzfyxxdt.Rows[0]["dyksxssj"].ToString();//待遇开始享受时间
                parpam[16] = sybdk_entity.Gsrdbh;// Mzfyxxdt.Rows[0]["gsrdbh"].ToString();//工伤认定编号
                InXml = ptmzjs.Ptmzjs_head() + ptmzjs.Ptmzjs_in(parpam) + ptmzjs.Ptmzjs_top();
            }
            if (costdetIds.Trim() == "")
            {
                return false;
            }
            DataTable costdetItem = bllInsur.getClinCostdet(costdetIds, "N");
            if (costdetItem == null) 
            {
                message.Append("预结算失败！");
                return false;
            }
            for (int b = 0; b < costdetItem.Rows.Count; b++)
            {
                String[] parpam2 = new String[14];
                parpam2[0] = costdetItem.Rows[b]["ITEMCODE"].ToString();//医保编码
                if (parpam2[0].Equals(""))
                {
                    parpam2[0] = "34999999";
                }
                parpam2[1] = costdetItem.Rows[b]["ITEMNAME"].ToString();//项目名称
                if (parpam2[1].Equals(""))
                {
                    parpam2[1] = "全自费";
                }
                parpam2[2] = costdetItem.Rows[b]["SUBJECT"].ToString();//发票归属科目编码
                parpam2[3] = costdetItem.Rows[b]["SPECIFICATION"].ToString();//规格
                parpam2[4] = costdetItem.Rows[b]["AGENTTYPE"].ToString();//剂型
                parpam2[5] = costdetItem.Rows[b]["UNIT"].ToString();//单位
                parpam2[6] = costdetItem.Rows[b]["PRICE"].ToString();//单价
                parpam2[7] = costdetItem.Rows[b]["QUANTITY"].ToString();//数量
                parpam2[8] = costdetItem.Rows[b]["FROMOFFICE"].ToString();//开单科室
                parpam2[9] = costdetItem.Rows[b]["FROMDOCT"].ToString();//开单医生
                parpam2[10] = costdetItem.Rows[b]["FROMOFFICE"].ToString();//受单科室
                parpam2[11] = costdetItem.Rows[b]["FROMDOCT"].ToString();//受单医生
                parpam2[12] = DateTime.Parse(costdetItem.Rows[b]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
                parpam2[13] = "";//备注

                parpam2[14] = "";//用药途径
                parpam2[15] = "";//用药频次
                parpam2[16] = "";//单次用量
                parpam2[17] = "";//用药天数   
                parpam2[18] = costdetItem.Rows[b]["cardid"].ToString();//身份证号
                parpam2[19] = costdetItem.Rows[b]["item_id"].ToString();// 院内收费项目编码
                parpam2[20] = "";//取药总量
                parpam2[21] = "";//取药总量单位
                parpam2[22] = "";//药量天数
                parpam2[23] = DateTime.Parse(costdetItem.Rows[b]["DODATE"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//执行时间
                InXml += ptmzjs.Ptmzjs_in2(parpam2);
            }
            InXml += ptmzjs.Ptmzjs_tail2() + ptmzjs.Ptmzjs_tail();
            String outXml = "";
            if (sybdk_entity.Zflb.Equals("18"))
            {
                outXml = gysybface.Tsmzjs(InXml);//特殊门诊结算
            }
            else
            {
                SysWriteLogs sysWriteLog123 = new SysWriteLogs();
                var date123 = Convert.ToDateTime(BillSysBase.currDate()).ToFileTime();
                outXml = gysybface.Ptmzjs(InXml);//普通门诊结算
                sysWriteLog123.writeLogs("去跟前置机要数据-首次", Convert.ToDateTime(BillSysBase.currDate()), (Convert.ToDateTime(BillSysBase.currDate()).ToFileTime() - date123).ToString());
            }
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (!flag.Equals("0"))
            {
                message.Append("市医保:" + info);
                return false;
            }
            string sql_upd = "update clinic_costdet set insursync = 'Y' where id in (" + costdetIds + ")";
            int res = BllMain.Db.Update(sql_upd);

            if (res != 0)
            {
                message.Append("市医保:" + "修改医保传输标志失败！");
            }
            string yxbx = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
            string grzhzf = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
           
            string ylbzzf = "";
            string jjtczf = "";
            string debzzf = "";
            double sbstartfee = 0;//商保起付线
            double sbpay = 0;//商保支付
            sbstartfee = DataTool.stringToDouble(ds.Tables["DATA"].Rows[0]["SBSTARTFEE"].ToString());//商保起付线
            sbpay = DataTool.stringToDouble(ds.Tables["DATA"].Rows[0]["SBPAY"].ToString());//商保支付
            if (sybdk_entity.Zflb.Equals("18"))  //特殊门诊
            { 
                ylbzzf = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
                jjtczf = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
                debzzf = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额补助支付
            }
            else
            {
                ylbzzf = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
                jjtczf = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
                debzzf = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额补助支付
            }
            double ybbx = 0;
            double lx_ybbx = DataTool.stringToDouble(yxbx);//允许报销
            double pt_ybbx = DataTool.stringToDouble(ylbzzf) + DataTool.stringToDouble(jjtczf) + DataTool.stringToDouble(debzzf);
            if (sybdk_entity.Bxlb == "2")
            {
                ybbx = lx_ybbx;
            }
            else
            {
                ybbx = pt_ybbx;
            }
            yb[0] = DataTool.stringToDouble(grzhzf);//个人账户支付 医保报销 商保起付线 商保支付
            yb[1] = ybbx;//医保报销
            yb[2] = sbstartfee;//商保起付线
            yb[3] = sbpay;//商保支付            
            return true;
        }

        ///// <summary>
        ///// 普通门诊退票
        ///// </summary>
        ///// <param name="parpam"></param>
        ///// <returns></returns>
        //public bool Ptmztp(String Mtmzblstuff_iid, StringBuilder message, String Fph)
        //{
        //    string currtime = BillSysBase.currDate();
        //    DataTable dt = gyybdb.GetTPcx(Mtmzblstuff_iid, Fph);
        //    String[] parpam = new String[5];

        //    parpam[0] = dt.Rows[0]["billno"].ToString(); ;//就诊顺序号
        //    parpam[1] = dt.Rows[0]["jsbm"].ToString(); ;//结算编号
        //    parpam[2] = dt.Rows[0]["zflb"].ToString();//支付类别
        //    parpam[3] = ProgramGlobal.User_id;//操作员
        //    parpam[4] = currtime;//办理时间
        //    Tp tp = new Tp();
        //    String InXml = tp.Tp_head() + tp.Tp_in(parpam) + tp.Tp_tail();
        //    String outXml = "";
        //    if (dt.Rows[0]["bxlb"].ToString().Equals("2"))
        //    {
        //        outXml = gysybface.Lxmztp(InXml); //离休退票
        //    }
        //    else
        //    {
        //        outXml = gysybface.Ptmztp(InXml);// 普通退票
        //    }
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    string ACCTBALANCE = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
        //    string HANDLEDATE = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
        //    if (!gyybdb.Updatesql(Mtmzblstuff_iid, Fph, currtime))/////更改his数据
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 获取工伤认定信息
        /// </summary>
        /// <returns></returns>
        public List<Gsrdxx> Hqgrxx(string[] param, StringBuilder message)
        {
            Hqgsqrxx gsrd = new Hqgsqrxx();
            string inXml = gsrd.Hqgsqrxx_head() + gsrd.Hqgsqrxx_in(param) + gsrd.Hqgrxx_tail();
            //调用业务类
            string outXml = gysybface.Hqgsrdxx(inXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            List<Gsrdxx> gsrdxxs = new List<Gsrdxx>();
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return gsrdxxs;
            }

            for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
            {
                Gsrdxx gsrdxx = new Gsrdxx();
                gsrdxx.Gsrdbh = ds.Tables["ROW"].Rows[i]["GSRDBH"].ToString();//工伤认定编号
                gsrdxx.Sgsj = ds.Tables["ROW"].Rows[i]["SGSJ"].ToString();//事故时间
                gsrdxx.Gsrylb = ds.Tables["ROW"].Rows[i]["GSRYLB"].ToString();//工伤人员类别
                gsrdxx.Zyblb = ds.Tables["ROW"].Rows[i]["ZYBLB"].ToString();//职业病类别
                gsrdxx.Shbw = ds.Tables["ROW"].Rows[i]["SHBW"].ToString();//伤害部位
                gsrdxx.Rdjl = ds.Tables["ROW"].Rows[i]["RDJL"].ToString();//认定结论
                gsrdxx.Scdj = ds.Tables["ROW"].Rows[i]["SCDJ"].ToString();//伤残等级
                gsrdxx.Dwbm = ds.Tables["ROW"].Rows[i]["DWBH"].ToString();//单位编码
                gsrdxx.Dwmc = ds.Tables["ROW"].Rows[i]["DWMC"].ToString();//单位名称
                gsrdxxs.Add(gsrdxx);
            }
            return gsrdxxs;
        }
        ///// <summary>
        ///// 中心下载医保药品诊疗服务目录
        ///// </summary>
        ///// <returns></returns>
        //public bool GETSERVICE(StringBuilder message)
        //{
        //    string outXml = gysybface.GETSERVICE();
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 中心下载特殊病种目录
        ///// </summary>
        ///// <returns></returns>
        //public bool ZXXZTSBZML(StringBuilder message)
        //{
        //    string outXml = gysybface.GETSPECILLNESS();
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 中心下载医院单病种清算数据
        ///// </summary>
        ///// <returns></returns>
        //public bool ZXXZYYDBZ(StringBuilder message)
        //{
        //    string outXml = gysybface.GETHOSPSINGLEILLNESS_BG();
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 查询医保药品诊疗服务目录
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool CXYBYPZLFWML(StringBuilder message)
        //{
        //    String[] param = new String[5];
        //    param[0] = "";//医保编码
        //    param[1] = "12";//项目支付类别
        //    param[2] = "";
        //    param[3] = "";
        //    param[4] = "";
        //    Cxybypzlfwml gsrd = new Cxybypzlfwml();
        //    string inXml = gsrd.Cxybypzlfwml_head() + gsrd.Cxybypzlfwml_in(param) + gsrd.Cxybypzlfwml_tail();
        //    string outXml = gysybface.QUERYSERVICE(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    int b = 0;
        //    String sql = " delete from syb_tzbml;";
        //    for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
        //    {

        //        //if (ds.Tables["ROW"].Rows[i]["ENDDATE"].ToString()<"2014-01-01 00:00:00")
        //        //    continue;
        //        sql += " INSERT INTO syb_tzbml( ";
        //        sql += " ITEMCODE, ITEMNAME, ITEMNOTE,LICNO,LICNOTE,UNIT,SPECIFICATION,AGENTTYPE,MANUFACTURER,COMMONCODE,COMMONNAME,NODECODE,MODIFYDATE,MODIFYNOTE,DIRTAG,LMTTAG,JMXMBZ,XMNH,CLLY,SFMZY,SFDDSF,PRICELMT, SELFRATE, BEARINGITEMFLAG, ";
        //        sql += " GSITEMFLAG, STATTYPE, SPECPAYFLAG,BGITEMTYPE,SPECRATE,STARTDATE, ";
        //        sql += " ENDDATE)VALUES ('";
        //        sql += ds.Tables["ROW"].Rows[i]["ITEMCODE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["ITEMNAME"].ToString().Replace('\'', '’') + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["ITEMNOTE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["LICNO"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["LICNOTE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["UNIT"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["SPECIFICATION"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["AGENTTYPE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["MANUFACTURER"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["COMMONCODE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["COMMONNAME"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["NODECODE"].ToString() + "');";
        //        sql += ds.Tables["ROW"].Rows[i]["MODIFYDATE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["MODIFYNOTE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["DIRTAG"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["LMTTAG"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["JMXMBZ"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["XMNH"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["CLLY"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["SFMZY"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["SFDDSF"].ToString() + "');";
        //        sql += ds.Tables["ROW"].Rows[i]["PRICELMT"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["SELFRATE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["BEARINGITEMFLAG"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["GSITEMFLAG"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["STATTYPE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["SPECPAYFLAG"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["BGITEMTYPE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["SPECRATE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["STARTDATE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["ENDDATE"].ToString() + "');";
        //        if (b == 100)
        //        {
        //            if (BllMain.Db.Update(sql)<0)
        //            {
        //                Tool.SysWriteLogs.writeLogs("插入市医保医保编码错误", Convert.ToDateTime(BillSysBase.currDate()), sql);//------------------------------------------------------------------------------------------------------------------------
        //                return false;
        //            }
        //            b = 0;
        //            sql = "";
        //        }
        //        if (b < 5000 && i == ds.Tables["ROW"].Rows.Count - 1)
        //        {
        //            if (!gyybdb.insert(sql))
        //            {
        //                Tool.SysWriteLogs.writeLogs("插入市医保医保编码错误", Convert.ToDateTime(BillSysBase.currDate()), sql);
        //                return false;
        //            }
        //        }
        //        b++;
        //    }

        //    return true;
        //}


        ///// <summary>
        ///// 查询特殊病种目录
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool CXTSBZML(StringBuilder message)
        //{
        //    String[] param = new String[2];
        //    param[0] = "";//特种病编码
        //    Cxybypzlfwml gsrd = new Cxybypzlfwml();
        //    string inXml = gsrd.Cxybypzlfwml_head() + gsrd.Cxybypzlfwml_in(param) + gsrd.Cxybypzlfwml_tail();
        //    string outXml = gysybface.QUERYSPECILLNESS(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    String sql = "";
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
        //    {
        //        sql += " INSERT INTO syb_tsbzml(";
        //        sql += " specillnesscode,specillnessname)VALUES ('";
        //        sql += ds.Tables["ROW"].Rows[i]["SPECILLNESSCODE"].ToString() + "','";
        //        sql += ds.Tables["ROW"].Rows[i]["SPECILLNESSNAME"].ToString() + "');";
        //    }
        //    if (!gyybdb.insert(sql))
        //    {
        //        Tool.SysWriteLogs.writeLogs("插入市医保医保特种兵编码错误", Convert.ToDateTime(BillSysBase.currDate()), sql);
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 查询医院单病种包干结算目录
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool CXYYDBZBGJSML(String bxlb, StringBuilder message)
        //{
        //    String[] param = new String[2];
        //    param[0] = bxlb;//保险类别
        //    param[1] = "";//特种病编码
        //    Cxyydbzbgjsml cxyydbzbgml = new Cxyydbzbgjsml();
        //    string inXml = cxyydbzbgml.Cxyydbzbgjsml_head() + cxyydbzbgml.Cxyydbzbgjsml_in(param) + cxyydbzbgml.Cxyydbzbgjsml_tail();
        //    string outXml = gysybface.QUERYHOSPSINGLEILLNESS_BG(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    String sql = "delete from syb_dbzml;";
        //    for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
        //    {
        //        sql += "  INSERT INTO syb_dbzml("
        //                + " enddate,startdate, psnstd, fundstd, paylmt, singleillnessname,singleillnesscode, mitype)VALUES ('"
        //                + ds.Tables["ROW"].Rows[i]["ENDDATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["STARTDATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PSNSTD"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["FUNDSTD"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAYLMT"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["SINGLEILLNESSNAME"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["SINGLEILLNESSCODE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["MITYPE"].ToString() + "');";
        //    }
        //    if (!gyybdb.insert(sql))//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //    {
        //        Tool.SysWriteLogs.writeLogs("插入市医保医保单病种编码错误", Convert.ToDateTime(BillSysBase.currDate()), sql);//---------------------------------------------------------------------------------------------------------------------------------------
        //        return false;
        //    }
        //    return true;
        //}
        //// <summary>
        ///// 查询医院住院单病种包干结算目录
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool CXYYZYDBZBGJSML(String bxlb, StringBuilder message)
        //{
        //    String[] param = new String[2];
        //    param[0] = bxlb;//保险类别
        //    param[1] = "";//特种病编码
        //    Cxyydbzbgjsml cxyydbzbgml = new Cxyydbzbgjsml();
        //    string inXml = cxyydbzbgml.Cxyydbzbgjsml_head() + cxyydbzbgml.Cxyydbzbgjsml_in(param) + cxyydbzbgml.Cxyydbzbgjsml_tail();
        //    string outXml = gysybface.QUERYHOSPSINGLEILLNESS(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    String sql = "delete from syb_zydbzml;";
        //    for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
        //    {
        //        sql += "  INSERT INTO syb_zydbzml("
        //                + " iid,enddate,startdate, singleillnessname,singleillnesscode, reckoningtype,paystd,payrate,pay2std,pay2rate,mitype)VALUES ("
        //                + (i + 1).ToString() + ",'"
        //                + ds.Tables["ROW"].Rows[i]["ENDDATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["STARTDATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["SINGLEILLNESSNAME"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["SINGLEILLNESSCODE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["RECKONINGTYPE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAYSTD"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAYRATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAY2STD"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAY2RATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["MITYPE"].ToString() + "');";
        //    }
        //    if (!gyybdb.insert(sql))
        //    {
        //        Tool.SysWriteLogs.writeLogs("插入市医保住院医保单病种编码错误", Convert.ToDateTime(BillSysBase.currDate()), sql);//------------------------------------------------------------------------------------------------------------------------------------------------------
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 查询接口住院结算数据
        ///// </summary>
        ///// <param name="Mtzyjl_iid"></param>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool QUERYINFHOSPBILL(String zyjlzyh, StringBuilder message, Czzgjbylbxzyfyqd sybbbd_Entity)
        //{
        //    DataTable dt = gyybdb.Get_QUERYINFHOSPBILL(zyjlzyh);

        //    if (dt.Rows.Count <= 0)
        //    {
        //        message.Append("没有查找到该住院号的报补信息");
        //        return false;
        //    }
        //    String[] parprm = new String[10];
        //    parprm[0] = "2013-01-01 00:00:00";//开始时间
        //    parprm[1] = "2030-01-01 00:00:00";//结束时间

        //    parprm[2] = "";// dt.Rows[0]["PAYTYPE"].ToString();//支付类别
        //    parprm[3] = "";//dt.Rows[0]["PERSONCODE"].ToString();//个人编码
        //    parprm[4] = dt.Rows[0]["BALANCEID"].ToString();//结算编号
        //    parprm[5] = dt.Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    parprm[6] = "";//dt.Rows[0]["fph"].ToString();//发票号
        //    parprm[7] = "0";//退票标志
        //    parprm[8] = "";//dt.Rows[0]["INSURETYPE"].ToString();//保险类别
        //    parprm[9] = "";//dt.Rows[0]["CALTYPE"].ToString();//结算方式
        //    Cxjkzyjssj cxjkzyjssj = new Cxjkzyjssj();
        //    String inXml = "";
        //    inXml = cxjkzyjssj.Cxjkzyjssj_head() + cxjkzyjssj.Cxjkzyjssj_in(parprm) + cxjkzyjssj.Cxjkzyjssj_tail();
        //    string outXml = gysybface.GetQUERYINFHOSPBILL(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    sybbbd_Entity.Jzsxh = ds.Tables["ROW"].Rows[0]["BILLNO"].ToString();//就诊顺序号
        //    ds.Tables["ROW"].Rows[0]["BALANCEID"].ToString();//结算编号
        //    ds.Tables["ROW"].Rows[0]["RETURNID"].ToString();//退票标志
        //    ds.Tables["ROW"].Rows[0]["CENTERCODE"].ToString();//分中心编码
        //    sybbbd_Entity.Grbh = ds.Tables["ROW"].Rows[0]["PERSONCODE"].ToString();//个人编码
        //    ds.Tables["ROW"].Rows[0]["DEPTCODE"].ToString();//单位编码
        //    sybbbd_Entity.Dwmc = ds.Tables["ROW"].Rows[0]["DEPTNAME"].ToString() + "(" + ds.Tables["ROW"].Rows[0]["DEPTCODE"].ToString() + ")";
        //    //sybbbd_Entity.Dwmc = ds.Tables["ROW"].Rows[0]["PERSONNAME"].ToString();//单位名称
        //    sybbbd_Entity.Xm = ds.Tables["ROW"].Rows[0]["PERSONNAME"].ToString();//姓名

        //    sybbbd_Entity.Rylb = this.getRylb(ds.Tables["ROW"].Rows[0]["PERSONTYPE"].ToString());//人员类别
        //    ds.Tables["ROW"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
        //    sybbbd_Entity.Fyhj = ds.Tables["ROW"].Rows[0]["FEEALL"].ToString();//医保总费用
        //    ds.Tables["ROW"].Rows[0]["CALFEEALL"].ToString();//结算总费用
        //    sybbbd_Entity.Qzfbf = ds.Tables["ROW"].Rows[0]["FEEOUT"].ToString();//全自费部分
        //    sybbbd_Entity.Stzfbf = ds.Tables["ROW"].Rows[0]["FEESELF"].ToString();//三特自付部分
        //    ds.Tables["ROW"].Rows[0]["ALLOWFUND"].ToString();//允许报销部分
        //    sybbbd_Entity.Bcqfx = ds.Tables["ROW"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //    sybbbd_Entity.Qfx = ds.Tables["ROW"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //    ds.Tables["ROW"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
        //    sybbbd_Entity.Jbtczhif = ds.Tables["ROW"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
        //    sybbbd_Entity.Jbtczif = ds.Tables["ROW"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
        //    sybbbd_Entity.Detczhif = ds.Tables["ROW"].Rows[0]["FUND2PAY"].ToString();//大额支付
        //    sybbbd_Entity.Detczif = ds.Tables["ROW"].Rows[0]["FUND2SELF"].ToString();//大额自付
        //    ds.Tables["ROW"].Rows[0]["FUND2SELF"].ToString();//大额自付
        //    sybbbd_Entity.Cgxezf = ds.Tables["ROW"].Rows[0]["FEEOVER"].ToString();//超限额自付
        //    sybbbd_Entity.Qzgrzhzf = ds.Tables["ROW"].Rows[0]["ACCTPAY"].ToString();//个人帐户支付
        //    ds.Tables["ROW"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
        //    ds.Tables["ROW"].Rows[0]["PAYTYPE"].ToString();//支付类别
        //    ds.Tables["ROW"].Rows[0]["SPECILLNESSCODE"].ToString();//特种病编码
        //    ds.Tables["ROW"].Rows[0]["SINGLEILLNESSCODE"].ToString();//单病种编码
        //    ds.Tables["ROW"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
        //    ds.Tables["ROW"].Rows[0]["INVOICENO"].ToString();//发票号
        //    ds.Tables["ROW"].Rows[0]["OPERATOR"].ToString();//操作员
        //    ds.Tables["ROW"].Rows[0]["DODATE"].ToString();//结算时间
        //    sybbbd_Entity.Jssj = ds.Tables["ROW"].Rows[0]["HANDLEDATE"].ToString();//处理时间
        //    ds.Tables["ROW"].Rows[0]["INSURETYPE"].ToString();//保险类别
        //    ds.Tables["ROW"].Rows[0]["CAREPSNFLAG"].ToString();//医疗照顾人员标志
        //    ds.Tables["ROW"].Rows[0]["CALTYPE"].ToString();//结算方式
        //    ds.Tables["ROW"].Rows[0]["ISSENDED"].ToString();//上传标志
        //    ds.Tables["ROW"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
        //    ds.Tables["ROW"].Rows[0]["SINGLEILLNESSCODE"].ToString();//病种名称
        //    ds.Tables["ROW"].Rows[0]["BGFS"].ToString();//包干计算方式
        //    ds.Tables["ROW"].Rows[0]["FEEOUT_3J"].ToString();//三级医院允许加收全自费
        //    ds.Tables["ROW"].Rows[0]["FUNDITEMPAY"].ToString();//基金直接支付项目费用
        //    ds.Tables["ROW"].Rows[0]["ADDITEMPAY"].ToString();//允许加收全自付费用

        //    Cxjkzyjsfymx cxjkzyjsfymx = new Cxjkzyjsfymx();
        //    String[] parprm2 = new String[5];
        //    parprm2[0] = dt.Rows[0]["BILLNO"].ToString();
        //    parprm2[1] = dt.Rows[0]["BALANCEID"].ToString();
        //    parprm2[2] = "";
        //    parprm2[3] = "";
        //    parprm2[4] = "";
        //    inXml = cxjkzyjsfymx.Cxjkzyjsfymx_head() + cxjkzyjsfymx.Cxjkzyjsfymx_in(parprm2) + cxjkzyjsfymx.Cxjkzyjsfymx_tail();
        //    outXml = gysybface.GetQUERYINFHOSPFEELIST(inXml);
        //    sr = new StringReader(outXml);
        //    ds = new DataSet();
        //    ds.ReadXml(sr);
        //    flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    double xyf = 0;
        //    double cyf = 0;
        //    double zcyf = 0;
        //    double jcf = 0;
        //    double zlf = 0;
        //    double zcf = 0;
        //    double hyf = 0;
        //    double ssf = 0;
        //    double cwf = 0;
        //    double hlf = 0;
        //    double qt = 0;
        //    double qzf = 0;
        //    double stzf = 0;
        //    double fyhj = 0;

        //    for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
        //    {
        //        stzf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["FEESELF"].ToString());
        //        qzf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["FEEOUT"].ToString()) + Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString()) - Convert.ToDouble(ds.Tables["ROW"].Rows[i]["FEEALL"].ToString());
        //        fyhj += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "01")
        //            xyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "02")
        //            cyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "03")
        //            zcyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "04")
        //            cwf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "05")
        //            zcf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "06")
        //            jcf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "07")
        //            zlf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "08")
        //            hlf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "09")
        //            ssf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "10")
        //            hyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //        else
        //            qt += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
        //    }
        //    sybbbd_Entity.Xyf = xyf.ToString();
        //    sybbbd_Entity.Zcy = cyf.ToString();
        //    sybbbd_Entity.Zcyf = zcyf.ToString();
        //    sybbbd_Entity.Jcf = jcf.ToString();
        //    sybbbd_Entity.Zlf = zlf.ToString();
        //    sybbbd_Entity.Zfc = zcf.ToString();
        //    sybbbd_Entity.Hyf = hyf.ToString();
        //    sybbbd_Entity.Ssf = ssf.ToString();
        //    sybbbd_Entity.Cwf = cwf.ToString();
        //    sybbbd_Entity.Hlf = hlf.ToString();
        //    sybbbd_Entity.Qt = String.Format("{0:F}", qt);
        //    sybbbd_Entity.Fyhjxm = fyhj.ToString();
        //    sybbbd_Entity.Stzfbf = stzf.ToString();
        //    sybbbd_Entity.Qzfbf = qzf.ToString();
        //    sybbbd_Entity.Fyhj = fyhj.ToString();
        //    return true;
        //}

        ///// <summary>
        ///// 查询接口入院数据
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public String CXryjksj(string inXml)
        //{

        //    String outXml = gysybface.Cxrydj(inXml);

        //    return outXml;
        //}

        //public string getRylb(string rylb)
        //{
        //    string ret = "";
        //    if (rylb == "11")
        //    {
        //        ret = "在职";
        //    }
        //    else if (rylb == "21")
        //    {
        //        ret = "退休";
        //    }
        //    else if (rylb == "32")
        //    {
        //        ret = "省属离休";
        //    }
        //    else if (rylb == "34")
        //    {
        //        ret = "市属离休";
        //    }
        //    else if (rylb == "41")
        //    {
        //        ret = "普通居民";
        //    }
        //    else if (rylb == "42")
        //    {
        //        ret = "低保对象";
        //    }
        //    else if (rylb == "43")
        //    {
        //        ret = "三无人员";
        //    }
        //    else if (rylb == "44")
        //    {
        //        ret = "低收入家庭";
        //    }
        //    else if (rylb == "45")
        //    {
        //        ret = "重度残疾";
        //    }
        //    return ret;

        //}

        //#region  贵阳市医保入院登记

        ///// <summary>
        ///// 贵阳市医保入院登记
        ///// Writer:qinYangYang 2014/4/17
        ///// </summary>
        ///// <param name="mtzyjl_zyh">住院号</param>
        ///// <param name="mtzyjl_iid">mtzyjl表IID</param>
        ///// <param name="servicesNowDateTime">服务器当前时间</param>
        ///// <returns></returns>
        //public bool Gysybry(int mtzyjl_zyh, int mtzyjl_iid, string servicesNowDateTime, StringBuilder message)
        //{

        //    String[] param = new String[19];
        //    param[0] = sybdk_entity.Klb;//卡类别
        //    param[1] = sybdk_entity.Ctsj;//磁条数据
        //    param[2] = sybdk_entity.Sfzhm;//社会保障号
        //    param[3] = sybdk_entity.Grbh;//个人编码
        //    param[4] = sybdk_entity.Zdjipdz;//终端机IP地址
        //    param[5] = sybdk_entity.Pasmkh;//PASM卡号
        //    param[6] = sybdk_entity.Mm;//密码
        //    param[7] = sybdk_entity.Bxlb;//保险类别
        //    param[8] = sybdk_entity.Zflb;//支付类别
        //    param[9] = mtzyjl_zyh.ToString();//住院号
        //    param[10] = "";//参保前已在院
        //    param[11] = sybdk_entity.Zdicd;//诊断
        //    if (param[11] == "")
        //    {
        //        param[11] = "J12.200";
        //    }
        //    param[12] = sybdk_entity.Ys;//诊断医生
        //    param[13] = sybdk_entity.Ks;//科室
        //    param[14] = sybdk_entity.Ryrq;//入院时间
        //    param[15] = ProgramGlobal.User_id;//操作员
        //    param[16] = servicesNowDateTime;//办理时间
        //    param[17] = sybdk_entity.Gsrd;//工伤认定编号
        //    param[18] = sybdk_entity.Gskfzybz;//工伤康复住院标志
        //    Rydj_Syb rydj = new Rydj_Syb();
        //    string inXml = rydj.Rydj_head() + rydj.Rydj_in(param) + rydj.Rydj_tail();
        //    //调用业务类
        //    string outXml = gysybface.Syb_Rydj(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (flag == "0")
        //    {
        //        string centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码
        //        string billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
        //        string hosptimes = ds.Tables["DATA"].Rows[0]["HOSPTIMES"].ToString();//本年住院次数
        //        string startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
        //        string startfeepaid = ds.Tables["DATA"].Rows[0]["STARTFEEPAID"].ToString();//本年已支付起付线
        //        string fund1lmt = ds.Tables["DATA"].Rows[0]["FUND1LMT"].ToString();//基本统筹限额
        //        string fund1paid = ds.Tables["DATA"].Rows[0]["FUND1PAID"].ToString();//本年已支付基本统筹
        //        string fund2lmt = ds.Tables["DATA"].Rows[0]["FUND2LMT"].ToString();//大额统筹限额
        //        string fund2paid = ds.Tables["DATA"].Rows[0]["FUND2PAID"].ToString();//本年已支付大额统筹
        //        string lockinfo = ds.Tables["DATA"].Rows[0]["LOCKINFO"].ToString();//封锁信息
        //        string note = ds.Tables["DATA"].Rows[0]["NOTE"].ToString();//备注
        //        string soeccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
        //        string speccalflagtxt = ds.Tables["DATA"].Rows[0]["SPECCALFLAGTXT"].ToString();//特殊结算说明
        //        string reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
        //        string singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
        //        string singlellnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
        //        string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间

        //        GysYbRydj_Entity Rydj_Entity = new GysYbRydj_Entity();
        //        Rydj_Entity.Centercode = centercode;//分中心编码
        //        Rydj_Entity.Billno = billno;//就诊顺序号
        //        Rydj_Entity.Hosptimes = hosptimes;//本年住院次数
        //        Rydj_Entity.Startfee = startfee;//本次起付线
        //        Rydj_Entity.Startfeepaid = startfeepaid;//本年已支付起付线
        //        Rydj_Entity.Fund1lmt = fund1lmt;//基本统筹限额
        //        Rydj_Entity.Fund1paid = fund1paid;//本年已支付基本统筹
        //        Rydj_Entity.Fund2lmt = fund2lmt;//大额统筹限额
        //        Rydj_Entity.Fund2paid = fund1paid;//本年已支付大额统筹
        //        Rydj_Entity.Lockinfo = lockinfo;//封锁信息
        //        Rydj_Entity.Note = note;//备注
        //        Rydj_Entity.Soeccalflag = soeccalflag;//特殊结算标志
        //        Rydj_Entity.Speccalflagtxt = speccalflagtxt;//特殊结算说明
        //        Rydj_Entity.Reckoningtype = reckoningtype;//清算方式
        //        Rydj_Entity.Singleillnesscode = singleillnesscode;//清算病种编码
        //        Rydj_Entity.Singlellnessname = singlellnessname;//病种名称
        //        Rydj_Entity.Handledate = handledate;//系统处理时间
        //        Rydj_Entity.Cardtype = sybdk_entity.Klb;//卡类别
        //        Rydj_Entity.Sno = sybdk_entity.Sfzhm;//社会保障号
        //        Rydj_Entity.Carddata = sybdk_entity.Ctsj;//磁条数据
        //        Rydj_Entity.Personcode = sybdk_entity.Grbh;//个人编码
        //        Rydj_Entity.Ipaddr = sybdk_entity.Zdjipdz;//终端机IP地址
        //        Rydj_Entity.Psamno = sybdk_entity.Pasmkh;//PASM卡号
        //        Rydj_Entity.Pwd = sybdk_entity.Mm;//密码
        //        Rydj_Entity.Insuretype = sybdk_entity.Bxlb;//保险类别
        //        Rydj_Entity.Paytype = sybdk_entity.Zflb;//支付类别
        //        Rydj_Entity.Mtzyjl_iid = mtzyjl_iid.ToString();//Mtzyjl_iid
        //        Rydj_Entity.RylbName = sybdk_entity.RylbName;//人员类别名称
        //        Rydj_Entity.Dwmc = sybdk_entity.Dwmc;//单位名称
        //        Rydj_Entity.Zhye = sybdk_entity.Zhye;//账户余额
        //        if (!gyybdb.SybRydj_his_New(Rydj_Entity, 0))
        //        {
        //            message.Append("GyybDb.SybRydj_his_New()方法执行失败【his库】,请重试,如再次医保办理入院时,提示已经医保已入院,请联系市医保在中心解除此患者入院状态,或联系【民腾】管理员!");
        //            return false;
        //        }
        //    }
        //    else if (flag != "0")
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    return true;
        //}

        //#endregion

        //#region  查询贵阳市医保接口入院数据

        ///// <summary>
        ///// 查询贵阳市医保接口入院数据
        ///// Writer:qinYangYang 2014/4/25
        ///// </summary>
        ///// <param name="startTimer">开始时间</param>
        ///// <param name="endTimer">结束时间</param>
        ///// <param name="rlt">结果集</param>
        ///// <param name="errInfo">错误信息</param>
        ///// <returns></returns>
        //public bool QueryInHospReg(string startTimer, string endTimer, out DataTable rlt, out string errInfo)
        //{
        //    rlt = new DataTable();
        //    errInfo = "";

        //    String[] param = new String[7];
        //    param[0] = startTimer;//开始时间
        //    param[1] = endTimer;//结束时间
        //    param[2] = "";//个人编码
        //    param[3] = "";//支付类别
        //    param[4] = "";//就诊顺序号
        //    param[5] = "";//出院标志
        //    param[6] = "";//保险类别

        //    Cxjkrysj rydj = new Cxjkrysj();
        //    string inXml = rydj.Cxjkrysj_head() + rydj.Cxjkrysj_in(param) + rydj.Cxjkrysj_tail();

        //    //调用业务类
        //    string outXml = gysybface.QUERYINFHOSPREG(inXml);//---------------------------------------------------------------------------------------------------------------------------------------------------------
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);

        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (flag == "0")
        //    {
        //        rlt = ds.Tables["ROW"];
        //        return true;
        //    }
        //    else
        //    {
        //        errInfo = info;
        //        return false;
        //    }
        //}

        //#endregion

        //#region 查询医院单病种清算数据(即大病 非包干)

        //// <summary>
        ///// 查询医院单病种清算数据(即大病 非包干)
        ///// ReWriter：qinYangYang 2014/4/29
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool CXYYZYDBZBGJSML_New(String bxlb, StringBuilder message)
        //{
        //    String[] param = new String[2];
        //    param[0] = bxlb;//保险类别
        //    param[1] = "";//特种病编码
        //    Cxyydbzbgjsml cxyydbzbgml = new Cxyydbzbgjsml();
        //    string inXml = cxyydbzbgml.Cxyydbzbgjsml_head() + cxyydbzbgml.Cxyydbzbgjsml_in(param) + cxyydbzbgml.Cxyydbzbgjsml_tail();
        //    string outXml = gysybface.QUERYHOSPSINGLEILLNESS(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    //String sql = "delete from syb_zydbzml;";
        //    String sql = "";
        //    for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
        //    {
        //        sql += "  INSERT INTO syb_zydbzml("
        //                + " iid,enddate,startdate, singleillnessname,singleillnesscode, reckoningtype,paystd,payrate,pay2std,pay2rate,tp, pym,mitype)VALUES ("
        //                + "nextval('syb_zydbzml_iid_seq '),'"
        //                + ds.Tables["ROW"].Rows[i]["ENDDATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["STARTDATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["SINGLEILLNESSNAME"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["SINGLEILLNESSCODE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["RECKONINGTYPE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAYSTD"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAYRATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAY2STD"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAY2RATE"].ToString() + "','"
        //                + "0','"
        //                + GetData.GetChineseSpell(ds.Tables["ROW"].Rows[i]["SINGLEILLNESSNAME"].ToString()) + "','"
        //                + ds.Tables["ROW"].Rows[i]["MITYPE"].ToString() + "');";
        //    }
        //    if (!gyybdb.insert(sql))//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //    {
        //        Tool.SysWriteLogs.writeLogs("插入市医保住院医保单病种编码错误", Convert.ToDateTime(BillSysBase.currDate()), sql);//-----------------------------------------------------------------------------------------------------------------------
        //        return false;
        //    }
        //    return true;
        //}

        //#endregion

        //#region 查询医院单病种包干结算目录(包干)

        ///// <summary>
        ///// 查询医院单病种包干结算目录 (包干)
        ///// ReWriter:qinYangYang 2014/4/29
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public bool CXYYDBZBGJSML_New(String bxlb, StringBuilder message)
        //{
        //    String[] param = new String[2];
        //    param[0] = bxlb;//保险类别
        //    param[1] = "";//特种病编码
        //    Cxyydbzbgjsml cxyydbzbgml = new Cxyydbzbgjsml();
        //    string inXml = cxyydbzbgml.Cxyydbzbgjsml_head() + cxyydbzbgml.Cxyydbzbgjsml_in(param) + cxyydbzbgml.Cxyydbzbgjsml_tail();
        //    string outXml = gysybface.QUERYHOSPSINGLEILLNESS_BG(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (!flag.Equals("0"))
        //    {
        //        message.Append(info);
        //        return false;
        //    }
        //    String sql = "";
        //    for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
        //    {
        //        sql += "  INSERT INTO syb_zydbzml("
        //                + " iid,enddate,startdate, singleillnessname,singleillnesscode,psnstd, fundstd, paylmt,tp, pym,mitype)VALUES ("
        //                + "nextval('syb_zydbzml_iid_seq '),'"
        //                + ds.Tables["ROW"].Rows[i]["ENDDATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["STARTDATE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["SINGLEILLNESSNAME"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["SINGLEILLNESSCODE"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PSNSTD"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["FUNDSTD"].ToString() + "','"
        //                + ds.Tables["ROW"].Rows[i]["PAYLMT"].ToString() + "','"
        //                + "1','"
        //                + GetData.GetChineseSpell(ds.Tables["ROW"].Rows[i]["SINGLEILLNESSNAME"].ToString()) + "','"
        //                + ds.Tables["ROW"].Rows[i]["MITYPE"].ToString() + "');";
        //    }
        //    if (!gyybdb.insert(sql))//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //    {
        //        Tool.SysWriteLogs.writeLogs("查询医院单病种包干结算目录 (包干)", Convert.ToDateTime(BillSysBase.currDate()), sql);
        //        return false;
        //    }
        //    return true;
        //}

        //#endregion

        //#region  查询接口住院结算费用明细

        ///// <summary>
        ///// 查询接口住院结算费用明细
        ///// Writer:qinYangYang 2014/5/3
        ///// </summary>
        ///// <param name="jzxlh">就诊顺序号</param>
        ///// <param name="jsbh">结算编号</param>
        ///// <param name="tpbz">退票标志</param>
        ///// <param name="errInfo">错误信息</param>
        ///// <returns></returns>
        //public bool QUERYINFHOSPFEELIST(string jzxlh, string jsbh, string tpbz, out DataTable rlt, out string errInfo)
        //{
        //    rlt = new DataTable();
        //    errInfo = "";

        //    String[] param = new String[5];
        //    param[0] = jzxlh;//就诊顺序号
        //    param[1] = jsbh;//结算编号
        //    param[2] = tpbz;//退票标志
        //    param[3] = "";//开始时间
        //    param[4] = "";//结束时间

        //    Cxjkzyjsfymx cxjkzyjsfymx = new Cxjkzyjsfymx();

        //    string inXml = cxjkzyjsfymx.Cxjkzyjsfymx_head() + cxjkzyjsfymx.Cxjkzyjsfymx_in(param) + cxjkzyjsfymx.Cxjkzyjsfymx_tail();
        //    string outXml = gysybface.GetQUERYINFHOSPFEELIST(inXml);
        //    StringReader sr = new StringReader(outXml);
        //    var ds = new DataSet();

        //    ds.ReadXml(sr);

        //    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
        //    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
        //    if (flag == "0")
        //    {
        //        rlt = ds.Tables["ROW"];
        //        return true;
        //    }
        //    else
        //    {
        //        errInfo = info;
        //        return false;
        //    }
        //}

        //#endregion


        /// <summary>
        /// 查询接口住院结算数据
        /// </summary>
        /// <param name="Mtzyjl_iid"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool QUERYINFHOSPBILL(String zyjlzyh, StringBuilder message, Czzgjbylbxzyfyqd sybbbd_Entity)
        {
            DataTable dt = Get_QUERYINFHOSPBILL(zyjlzyh);

            if (dt.Rows.Count <= 0)
            {
                message.Append("没有查找到该住院号的报补信息");
                return false;
            }
            String[] parprm = new String[10];
            parprm[0] = "2013-01-01 00:00:00";//开始时间
            parprm[1] = "2030-01-01 00:00:00";//结束时间

            parprm[2] = "";// dt.Rows[0]["PAYTYPE"].ToString();//支付类别
            parprm[3] = "";//dt.Rows[0]["PERSONCODE"].ToString();//个人编码
            parprm[4] = dt.Rows[0]["BALANCEID"].ToString();//结算编号
            parprm[5] = dt.Rows[0]["BILLNO"].ToString();//就诊顺序号
            parprm[6] = "";//dt.Rows[0]["fph"].ToString();//发票号
            parprm[7] = "0";//退票标志
            parprm[8] = "";//dt.Rows[0]["INSURETYPE"].ToString();//保险类别
            parprm[9] = "";//dt.Rows[0]["CALTYPE"].ToString();//结算方式
            Cxjkzyjssj cxjkzyjssj = new Cxjkzyjssj();
            String inXml = "";
            inXml = cxjkzyjssj.Cxjkzyjssj_head() + cxjkzyjssj.Cxjkzyjssj_in(parprm) + cxjkzyjssj.Cxjkzyjssj_tail();
            string outXml = gysybface.GetQUERYINFHOSPBILL(inXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            sybbbd_Entity.Jzsxh = ds.Tables["ROW"].Rows[0]["BILLNO"].ToString();//就诊顺序号
            ds.Tables["ROW"].Rows[0]["BALANCEID"].ToString();//结算编号
            ds.Tables["ROW"].Rows[0]["RETURNID"].ToString();//退票标志
            ds.Tables["ROW"].Rows[0]["CENTERCODE"].ToString();//分中心编码
            sybbbd_Entity.Grbh = ds.Tables["ROW"].Rows[0]["PERSONCODE"].ToString();//个人编码
            ds.Tables["ROW"].Rows[0]["DEPTCODE"].ToString();//单位编码
            sybbbd_Entity.Dwmc = ds.Tables["ROW"].Rows[0]["DEPTNAME"].ToString() + "(" + ds.Tables["ROW"].Rows[0]["DEPTCODE"].ToString() + ")";
            //sybbbd_Entity.Dwmc = ds.Tables["ROW"].Rows[0]["PERSONNAME"].ToString();//单位名称
            sybbbd_Entity.Xm = ds.Tables["ROW"].Rows[0]["PERSONNAME"].ToString();//姓名

            sybbbd_Entity.Rylb = this.getRylb(ds.Tables["ROW"].Rows[0]["PERSONTYPE"].ToString());//人员类别
            ds.Tables["ROW"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
            sybbbd_Entity.Fyhj = ds.Tables["ROW"].Rows[0]["FEEALL"].ToString();//医保总费用
            ds.Tables["ROW"].Rows[0]["CALFEEALL"].ToString();//结算总费用
            sybbbd_Entity.Qzfbf = ds.Tables["ROW"].Rows[0]["FEEOUT"].ToString();//全自费部分
            sybbbd_Entity.Stzfbf = ds.Tables["ROW"].Rows[0]["FEESELF"].ToString();//三特自付部分
            ds.Tables["ROW"].Rows[0]["ALLOWFUND"].ToString();//允许报销部分
            sybbbd_Entity.Bcqfx = ds.Tables["ROW"].Rows[0]["STARTFEE"].ToString();//本次起付线
            sybbbd_Entity.Qfx = ds.Tables["ROW"].Rows[0]["STARTFEE"].ToString();//本次起付线
            ds.Tables["ROW"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
            sybbbd_Entity.Jbtczhif = ds.Tables["ROW"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
            sybbbd_Entity.Jbtczif = ds.Tables["ROW"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
            sybbbd_Entity.Detczhif = ds.Tables["ROW"].Rows[0]["FUND2PAY"].ToString();//大额支付
            sybbbd_Entity.Detczif = ds.Tables["ROW"].Rows[0]["FUND2SELF"].ToString();//大额自付
            ds.Tables["ROW"].Rows[0]["FUND2SELF"].ToString();//大额自付
            sybbbd_Entity.Cgxezf = ds.Tables["ROW"].Rows[0]["FEEOVER"].ToString();//超限额自付
            sybbbd_Entity.Qzgrzhzf = ds.Tables["ROW"].Rows[0]["ACCTPAY"].ToString();//个人帐户支付
            sybbbd_Entity.Gwyylbzzf = ds.Tables["ROW"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
            ds.Tables["ROW"].Rows[0]["PAYTYPE"].ToString();//支付类别
            ds.Tables["ROW"].Rows[0]["SPECILLNESSCODE"].ToString();//特种病编码
            ds.Tables["ROW"].Rows[0]["SINGLEILLNESSCODE"].ToString();//单病种编码
            ds.Tables["ROW"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
            ds.Tables["ROW"].Rows[0]["INVOICENO"].ToString();//发票号
            ds.Tables["ROW"].Rows[0]["OPERATOR"].ToString();//操作员
            ds.Tables["ROW"].Rows[0]["DODATE"].ToString();//结算时间
            sybbbd_Entity.Jssj = ds.Tables["ROW"].Rows[0]["HANDLEDATE"].ToString();//处理时间
            ds.Tables["ROW"].Rows[0]["INSURETYPE"].ToString();//保险类别
            ds.Tables["ROW"].Rows[0]["CAREPSNFLAG"].ToString();//医疗照顾人员标志
            ds.Tables["ROW"].Rows[0]["CALTYPE"].ToString();//结算方式
            ds.Tables["ROW"].Rows[0]["ISSENDED"].ToString();//上传标志
            ds.Tables["ROW"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
            ds.Tables["ROW"].Rows[0]["SINGLEILLNESSCODE"].ToString();//病种名称
            ds.Tables["ROW"].Rows[0]["BGFS"].ToString();//包干计算方式
            ds.Tables["ROW"].Rows[0]["FEEOUT_3J"].ToString();//三级医院允许加收全自费
            ds.Tables["ROW"].Rows[0]["FUNDITEMPAY"].ToString();//基金直接支付项目费用
            ds.Tables["ROW"].Rows[0]["ADDITEMPAY"].ToString();//允许加收全自付费用

            Cxjkzyjsfymx cxjkzyjsfymx = new Cxjkzyjsfymx();
            String[] parprm2 = new String[5];
            parprm2[0] = dt.Rows[0]["BILLNO"].ToString();
            parprm2[1] = dt.Rows[0]["BALANCEID"].ToString();
            parprm2[2] = "";
            parprm2[3] = "";
            parprm2[4] = "";
            inXml = cxjkzyjsfymx.Cxjkzyjsfymx_head() + cxjkzyjsfymx.Cxjkzyjsfymx_in(parprm2) + cxjkzyjsfymx.Cxjkzyjsfymx_tail();
            outXml = gysybface.GetQUERYINFHOSPFEELIST(inXml);
            sr = new StringReader(outXml);
            ds = new DataSet();
            ds.ReadXml(sr);
            flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            double xyf = 0;
            double cyf = 0;
            double zcyf = 0;
            double jcf = 0;
            double zlf = 0;
            double zcf = 0;
            double hyf = 0;
            double ssf = 0;
            double cwf = 0;
            double hlf = 0;
            double qt = 0;
            double qzf = 0;
            double stzf = 0;
            double fyhj = 0;

            for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
            {
                stzf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["FEESELF"].ToString());
                qzf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["FEEOUT"].ToString()) + Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString()) - Convert.ToDouble(ds.Tables["ROW"].Rows[i]["FEEALL"].ToString());
                fyhj += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "01")
                    xyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "02")
                    cyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "03")
                    zcyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "04")
                    cwf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "05")
                    zcf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "06")
                    jcf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "07")
                    zlf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "08")
                    hlf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "09")
                    ssf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "10")
                    hyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else
                    qt += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
            }
            sybbbd_Entity.Xyf = xyf.ToString("0.00");
            sybbbd_Entity.Zcy = cyf.ToString("0.00");
            sybbbd_Entity.Zcyf = zcyf.ToString("0.00");
            sybbbd_Entity.Jcf = jcf.ToString("0.00");
            sybbbd_Entity.Zlf = zlf.ToString("0.00");
            sybbbd_Entity.Zfc = zcf.ToString("0.00");
            sybbbd_Entity.Hyf = hyf.ToString("0.00");
            sybbbd_Entity.Ssf = ssf.ToString("0.00");
            sybbbd_Entity.Cwf = cwf.ToString("0.00");
            sybbbd_Entity.Hlf = hlf.ToString("0.00");
            sybbbd_Entity.Qt = String.Format("{0:F}", qt);
            sybbbd_Entity.Fyhjxm = fyhj.ToString("0.00");
            sybbbd_Entity.Stzfbf = stzf.ToString("0.00");
            sybbbd_Entity.Qzfbf = qzf.ToString("0.00");
            sybbbd_Entity.Fyhj = fyhj.ToString("0.00");
            return true;
        }


        /// <summary>
        /// 查询接口住院结算数据-附件
        /// </summary>
        /// <param name="Mtzyjl_iid"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool QUERYINFHOSPBILL_fj(String zyjlzyh, StringBuilder message, frmnhzy_fj sybbbd_Entity)
        {
            DataTable dt = Get_QUERYINFHOSPBILL(zyjlzyh);

            if (dt.Rows.Count <= 0)
            {
                message.Append("没有查找到该住院号的报补信息");
                return false;
            }
            String[] parprm = new String[10];
            parprm[0] = "2013-01-01 00:00:00";//开始时间
            parprm[1] = "2030-01-01 00:00:00";//结束时间

            parprm[2] = "";// dt.Rows[0]["PAYTYPE"].ToString();//支付类别
            parprm[3] = "";//dt.Rows[0]["PERSONCODE"].ToString();//个人编码
            parprm[4] = dt.Rows[0]["BALANCEID"].ToString();//结算编号
            parprm[5] = dt.Rows[0]["BILLNO"].ToString();//就诊顺序号
            parprm[6] = "";//dt.Rows[0]["fph"].ToString();//发票号
            parprm[7] = "0";//退票标志
            parprm[8] = "";//dt.Rows[0]["INSURETYPE"].ToString();//保险类别
            parprm[9] = "";//dt.Rows[0]["CALTYPE"].ToString();//结算方式
            Cxjkzyjssj cxjkzyjssj = new Cxjkzyjssj();
            String inXml = "";
            inXml = cxjkzyjssj.Cxjkzyjssj_head() + cxjkzyjssj.Cxjkzyjssj_in(parprm) + cxjkzyjssj.Cxjkzyjssj_tail();
            string outXml = gysybface.GetQUERYINFHOSPBILL(inXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            sybbbd_Entity.Jzxlh = ds.Tables["ROW"].Rows[0]["BILLNO"].ToString();//就诊顺序号
            sybbbd_Entity.Jsbh = ds.Tables["ROW"].Rows[0]["BALANCEID"].ToString();//结算编号
            ds.Tables["ROW"].Rows[0]["RETURNID"].ToString();//退票标志
            ds.Tables["ROW"].Rows[0]["CENTERCODE"].ToString();//分中心编码
            sybbbd_Entity.Grbh = ds.Tables["ROW"].Rows[0]["PERSONCODE"].ToString();//个人编码
            ds.Tables["ROW"].Rows[0]["DEPTCODE"].ToString();//单位编码
            //sybbbd_Entity.Dwmc = ds.Tables["ROW"].Rows[0]["DEPTNAME"].ToString() + "(" + ds.Tables["ROW"].Rows[0]["DEPTCODE"].ToString() + ")";
            //sybbbd_Entity.Dwmc = ds.Tables["ROW"].Rows[0]["PERSONNAME"].ToString();//单位名称
            sybbbd_Entity.Hzname = ds.Tables["ROW"].Rows[0]["PERSONNAME"].ToString();//姓名

            sybbbd_Entity.Rylb = this.getRylb(ds.Tables["ROW"].Rows[0]["PERSONTYPE"].ToString());//人员类别
            sybbbd_Entity.Yyzfy = ds.Tables["ROW"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
            //sybbbd_Entity.Fyhj = ds.Tables["ROW"].Rows[0]["FEEALL"].ToString();//医保总费用
            sybbbd_Entity.Bcjsfy = ds.Tables["ROW"].Rows[0]["CALFEEALL"].ToString();//结算总费用
            //sybbbd_Entity.Qzfbf = ds.Tables["ROW"].Rows[0]["FEEOUT"].ToString();//全自费部分
            //sybbbd_Entity.Stzfbf = ds.Tables["ROW"].Rows[0]["FEESELF"].ToString();//三特自付部分
            sybbbd_Entity.Bcjzhgfy = ds.Tables["ROW"].Rows[0]["ALLOWFUND"].ToString();//允许报销部分
            sybbbd_Entity.Bcqfx = ds.Tables["ROW"].Rows[0]["STARTFEE"].ToString();//本次起付线
            //sybbbd_Entity.Qfx = ds.Tables["ROW"].Rows[0]["STARTFEE"].ToString();//本次起付线
            // ds.Tables["ROW"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
            sybbbd_Entity.Tczfzf = ds.Tables["ROW"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
            //sybbbd_Entity.Jbtczif = ds.Tables["ROW"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
            //sybbbd_Entity.Detczhif = ds.Tables["ROW"].Rows[0]["FUND2PAY"].ToString();//大额支付
            //sybbbd_Entity.Detczif = ds.Tables["ROW"].Rows[0]["FUND2SELF"].ToString();//大额自付
            // ds.Tables["ROW"].Rows[0]["FUND2SELF"].ToString();//大额自付
            // sybbbd_Entity.Cgxezf = ds.Tables["ROW"].Rows[0]["FEEOVER"].ToString();//超限额自付
            // sybbbd_Entity.Qzgrzhzf = ds.Tables["ROW"].Rows[0]["ACCTPAY"].ToString();//个人帐户支付
            ds.Tables["ROW"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
            ds.Tables["ROW"].Rows[0]["PAYTYPE"].ToString();//支付类别
            ds.Tables["ROW"].Rows[0]["SPECILLNESSCODE"].ToString();//特种病编码
            ds.Tables["ROW"].Rows[0]["SINGLEILLNESSCODE"].ToString();//单病种编码
            ds.Tables["ROW"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
            ds.Tables["ROW"].Rows[0]["INVOICENO"].ToString();//发票号
            ds.Tables["ROW"].Rows[0]["OPERATOR"].ToString();//操作员
            ds.Tables["ROW"].Rows[0]["DODATE"].ToString();//结算时间
            // sybbbd_Entity.Jssj = ds.Tables["ROW"].Rows[0]["HANDLEDATE"].ToString();//处理时间
            switch (ds.Tables["ROW"].Rows[0]["INSURETYPE"].ToString())
            {
                case "1":
                    sybbbd_Entity.Bxlb = "企业基本医疗保险";
                    break;

                case "2":
                    sybbbd_Entity.Bxlb = "企业离休医疗保险";
                    break;

                case "3":
                    sybbbd_Entity.Bxlb = "机关事业单位基本医疗保险";
                    break;

                case "4":
                    sybbbd_Entity.Bxlb = "企业生育保险";
                    break;

                case "5":
                    sybbbd_Entity.Bxlb = "机关事业单位生育保险";
                    break;

                case "6":
                    sybbbd_Entity.Bxlb = "居民医保";
                    break;

                case "7":
                    sybbbd_Entity.Bxlb = "工伤保险";
                    break;

            }
            // sybbbd_Entity.Bxlb= ds.Tables["ROW"].Rows[0]["INSURETYPE"].ToString();//保险类别
            ds.Tables["ROW"].Rows[0]["CAREPSNFLAG"].ToString();//医疗照顾人员标志
            ds.Tables["ROW"].Rows[0]["CALTYPE"].ToString();//结算方式
            ds.Tables["ROW"].Rows[0]["ISSENDED"].ToString();//上传标志
            ds.Tables["ROW"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
            ds.Tables["ROW"].Rows[0]["SINGLEILLNESSCODE"].ToString();//病种名称
            ds.Tables["ROW"].Rows[0]["BGFS"].ToString();//包干计算方式
            ds.Tables["ROW"].Rows[0]["FEEOUT_3J"].ToString();//三级医院允许加收全自费
            ds.Tables["ROW"].Rows[0]["FUNDITEMPAY"].ToString();//基金直接支付项目费用
            ds.Tables["ROW"].Rows[0]["ADDITEMPAY"].ToString();//允许加收全自付费用
            sybbbd_Entity.Dbbxpf = ds.Tables["ROW"].Rows[0]["sbpay"].ToString();//商保支付
            sybbbd_Entity.Bcjzgryzff = (double.Parse(sybbbd_Entity.Bcjsfy) - double.Parse(sybbbd_Entity.Tczfzf)).ToString();
            sybbbd_Entity.Bcgrsjzffy = (double.Parse(sybbbd_Entity.Bcjzgryzff) - double.Parse(sybbbd_Entity.Dbbxpf)).ToString();

            Cxjkzyjsfymx cxjkzyjsfymx = new Cxjkzyjsfymx();
            String[] parprm2 = new String[5];
            parprm2[0] = dt.Rows[0]["BILLNO"].ToString();
            parprm2[1] = dt.Rows[0]["BALANCEID"].ToString();
            parprm2[2] = "";
            parprm2[3] = "";
            parprm2[4] = "";
            inXml = cxjkzyjsfymx.Cxjkzyjsfymx_head() + cxjkzyjsfymx.Cxjkzyjsfymx_in(parprm2) + cxjkzyjsfymx.Cxjkzyjsfymx_tail();
            outXml = gysybface.GetQUERYINFHOSPFEELIST(inXml);
            sr = new StringReader(outXml);
            ds = new DataSet();
            ds.ReadXml(sr);
            flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            double xyf = 0;
            double cyf = 0;
            double zcyf = 0;
            double jcf = 0;
            double zlf = 0;
            double zcf = 0;
            double hyf = 0;
            double ssf = 0;
            double cwf = 0;
            double hlf = 0;
            double qt = 0;
            double qzf = 0;
            double stzf = 0;
            double fyhj = 0;

            for (int i = 0; i < ds.Tables["ROW"].Rows.Count; i++)
            {
                stzf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["FEESELF"].ToString());
                qzf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["FEEOUT"].ToString()) + Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString()) - Convert.ToDouble(ds.Tables["ROW"].Rows[i]["FEEALL"].ToString());
                fyhj += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "01")
                    xyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "02")
                    cyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "03")
                    zcyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "04")
                    cwf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "05")
                    zcf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "06")
                    jcf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "07")
                    zlf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "08")
                    hlf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "09")
                    ssf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else if (ds.Tables["ROW"].Rows[i]["SUBJECT"].ToString() == "10")
                    hyf += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
                else
                    qt += Convert.ToDouble(ds.Tables["ROW"].Rows[i]["HOSPFEEALL"].ToString());
            }
            sybbbd_Entity.Cwf = cwf.ToString("0.00");
            sybbbd_Entity.Zcf = zcf.ToString("0.00");
            sybbbd_Entity.Zlf = zlf.ToString("0.00");
            sybbbd_Entity.Hlf = hlf.ToString("0.00");
            sybbbd_Entity.Ssf = ssf.ToString("0.00");
            sybbbd_Entity.Hyf = hyf.ToString("0.00");
            sybbbd_Entity.Xy = xyf.ToString("0.00");
            sybbbd_Entity.Cy = cyf.ToString("0.00");
            sybbbd_Entity.Zcy = zcyf.ToString("0.00");
            sybbbd_Entity.Jcf = jcf.ToString("0.00");
            sybbbd_Entity.Qt = String.Format("{0:F}", qt);
            //sybbbd_Entity.Fyhjxm = fyhj.ToString("0.00");
            //sybbbd_Entity.Stzfbf = stzf.ToString("0.00");
            //sybbbd_Entity.Qzfbf = qzf.ToString("0.00");
            //sybbbd_Entity.Fyhj = fyhj.ToString("0.00");
            return true;
        }
        /// <summary>
        /// 查询接口住院结算费用明细
        /// Writer:qinYangYang 2014/5/3
        /// </summary>
        /// <param name="jzxlh">就诊顺序号</param>
        /// <param name="jsbh">结算编号</param>
        /// <param name="tpbz">退票标志</param>
        /// <param name="errInfo">错误信息</param>
        /// <returns></returns>
        public bool QUERYINFHOSPFEELIST(string jzxlh, string jsbh, string tpbz, out DataTable rlt, out string errInfo)
        {
            rlt = new DataTable();
            errInfo = "";

            String[] param = new String[5];
            param[0] = jzxlh;//就诊顺序号
            param[1] = jsbh;//结算编号
            param[2] = tpbz;//退票标志
            param[3] = "";//开始时间
            param[4] = "";//结束时间

            Cxjkzyjsfymx cxjkzyjsfymx = new Cxjkzyjsfymx();

            string inXml = cxjkzyjsfymx.Cxjkzyjsfymx_head() + cxjkzyjsfymx.Cxjkzyjsfymx_in(param) + cxjkzyjsfymx.Cxjkzyjsfymx_tail();
            string outXml = gysybface.GetQUERYINFHOSPFEELIST(inXml);
            StringReader sr = new StringReader(outXml);
            var ds = new DataSet();

            ds.ReadXml(sr);

            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (flag == "0")
            {
                rlt = ds.Tables["ROW"];
                return true;
            }
            else
            {
                errInfo = info;
                return false;
            }
        }

        public string getRylb(string rylb)
        {
            string ret = "";
            if (rylb == "11")
            {
                ret = "在职";
            }
            else if (rylb == "21")
            {
                ret = "退休";
            }
            else if (rylb == "32")
            {
                ret = "省属离休";
            }
            else if (rylb == "34")
            {
                ret = "市属离休";
            }
            else if (rylb == "41")
            {
                ret = "普通居民";
            }
            else if (rylb == "42")
            {
                ret = "低保对象";
            }
            else if (rylb == "43")
            {
                ret = "三无人员";
            }
            else if (rylb == "44")
            {
                ret = "低收入家庭";
            }
            else if (rylb == "45")
            {
                ret = "重度残疾";
            }
            return ret;

        }
        /// <summary>
        /// 查询---查询接口住院结算数据--的数据
        /// </summary>
        /// <param name="Mtzyjl_iid"></param>
        /// <returns></returns>
        public DataTable Get_QUERYINFHOSPBILL(String zyjlzyh)
        {
            String sql = " select  PAYTYPE,PERSONCODE,BILLNO,BALANCEID,INSURETYPE,ihsp_account.invoice as fph,insur_gysyb_zy.paytype AS CALTYPE "
                     + " from insur_gysyb_zy,inhospital, ihsp_account where insur_gysyb_zy.mtzyjliid=inhospital.id "
                        + " and ihsp_account.ihsp_id = inhospital.id and inhospital.ihspcode='" + zyjlzyh + "' and ihsp_account.status='SETT'";
            return BllMain.Db.Select(sql).Tables[0];
        }
    }
}
