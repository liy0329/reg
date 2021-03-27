using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.medinsur.gysyb.bo;
using System.IO;
using System.Windows.Forms;
using MTREG.common.bll;
using MTHIS.tools;

namespace MTREG.medinsur.gysyb.bll
{
    class BllInsurGYSYB
    {
        /// <summary>
        /// 获取贵阳市医保挂号信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable gysybIhspInfo(string ihsp_id)
        {
            string sql = "select personcode as insurcode"//个人编码
                        + ",cardtype"//卡类别
                        + ",carddata"//磁条数据
                        + ",sno"//社保卡卡号
                        + ",ipaddr"//终端机IP地址
                        + ",psamno"//PASM卡号
                        + ",pwd"//密码
                        + ",insuretype" //保险类别
                        + ",singleillnesscode"//单病种编码
                        + ",caltype" //结算方式
                        + ",reckoningtype"//清算方式
                        + " from insur_gysyb_zy "
                        + " where mtzyjliid=" + DataTool.addIntBraces(ihsp_id);
            return BllMain.Db.Select(sql).Tables[0];
        }
        GysybInterface gysybface = new GysybInterface();
        /// <summary>
        /// 患者类型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable patientTypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select id,name from bas_patienttype where isstop='N'";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        public DataTable getClinCostdet(string costdetIds, string isTranst)
        {
            string sql = "select clinic_costdet.id"
                       + ",clinic_costdet.item_id"//院内收费项目编码
                       + ",cost_insurcross.insurname AS ITEMNAME"
                       + ",cost_insurcross.insurcode as ITEMCODE"//医保编码
                       + ",clinic_costdet.spec as SPECIFICATION"
                       + ",clinic_costdet.unit as UNIT"
                       + ",clinic_costdet.prc as PRICE"
                        + ",clinic_costdet.createdate as DODATE"
                       + ",dosageform.name as  AGENTTYPE"
                       + ",clinic_costdet.num as QUANTITY"
                       + ",bas_depart.name as FROMOFFICE"
                       + ",bas_doctor.name as FROMDOCT"
                       + ",bas_doctor.cardid "//身份证号
                       + ",insur_itemtype.insurcode as SUBJECT"
                       + " from clinic_costdet"
                       + " left join bas_depart on clinic_costdet.depart_id = bas_depart.id"
                       + " left join bas_doctor on clinic_costdet.doctor_id = bas_doctor.id"
                       + " left join  sys_dict as dosageform  on clinic_costdet.dosageform_id = dosageform.sn and dosageform.dicttype='drug_dosageform' and dosageform.father_id <> 0"
                       + " left join insur_itemtype on insur_itemtype.itemtype_id = clinic_costdet.itemtype_id and insur_itemtype.cost_insurtype_id='15'"
                       + " LEFT JOIN cost_insurcross ON clinic_costdet.item_id = cost_insurcross.item_id and clinic_costdet.drug_factyitem_id=cost_insurcross.drug_factyitem_id"
                       + " where clinic_costdet.id in ( " + costdetIds + ")"
                       + " and cost_insurcross.insuritemtype='3'";
                       
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
       
        /// <summary>
        /// 查询icd疾病编码
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable getIcdInfo(string pincode)
        {
            string sql = "select id,case_icd10_6 as illcode,case_name as name,pincode from bas_caseicd where isstop='N'"
                + " and (case_name like '%" + pincode + "%' or case_icd10_6 like '%" + pincode + "%' or pincode like '%" + pincode + "%');";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getDiseaseInfo(string pincode)
        {
            string sql = "select id,name,illcode,pincode from cost_insurillness where cost_insurtype_id = (select id from cost_insurtype where keyname = "
            + DataTool.addFieldBraces(CostInsurtypeKeyname.GYSYB.ToString()) + ") and illcode = " + DataTool.addFieldBraces(pincode);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        public DataTable queryYdbzml(string jm,string szjsfs)
        {
            string sql = " select singleillnessname, singleillnesscode, pym as pincode from insur_gysyb_zydbzml where pym like '%" + jm + "%' and tp='" + szjsfs + "' ;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

      
     
        /// <summary>
        /// 贵阳市医保入院登记
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool insurRegist(string ihsp_id, string ihspcode, StringBuilder message, Sybdk_Entity sybdk_entity)
        {
            String[] param = new String[19];
            param[0] = sybdk_entity.Klb;    //卡类别
            param[1] = sybdk_entity.Ctsj;   //磁条数据
            param[2] = sybdk_entity.Sfzhm;   //社保卡卡号
            param[3] = sybdk_entity.Grbh;    //个人编码
            param[4] = sybdk_entity.Zdjipdz; //终端机IP地址
            param[5] = sybdk_entity.Pasmkh;  //PASM卡号
            param[6] = sybdk_entity.Mm;   //密码
            param[7] = sybdk_entity.Bxlb; //保险类别
            param[8] = sybdk_entity.Zflb; //支付类别
            param[9] = ihspcode;//住院号
            param[10] = "";//参保前已住院
            param[11] = sybdk_entity.Zdicd; //dtInsur.Rows[0]["insurdata9"].ToString();//诊断
            if (param[11] == "")
            {
                param[11] = "J12.200";
            }
            param[12] = sybdk_entity.Ys;//诊断医生
            param[13] = sybdk_entity.Ks;//科室
            param[14] = Convert.ToDateTime(sybdk_entity.Ryrq).ToString("yyyy-MM-dd HH:mm:ss");//入院时间
            param[15] = ProgramGlobal.User_id;
            param[16] = BillSysBase.currDate();
            param[17] = sybdk_entity.Gsrd;//工伤认定编号
            param[18] = sybdk_entity.Gskfzybz;//工伤康复住院标志
            if (!sybdk_entity.Gsrd.Equals(""))
            {
                param[7] = "7";
                sybdk_entity.Bxlb = "7";
            }
            Rydj_Syb rydj = new Rydj_Syb();
            string inXml = rydj.Rydj_head() + rydj.Rydj_in(param) + rydj.Rydj_tail();
            //调用业务类
            StringReader srin = new StringReader(inXml);
            DataSet dsin = new DataSet();
            dsin.ReadXml(srin);
            string outXml = gysybface.Syb_Rydj(inXml);
           
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            SysWriteLogs.writeLogs1("贵阳市医保入院登记", DateTime.Now, outXml + info);
            if (flag != "0")
            {
                message.Append(info);
                return false;
            }
            else
            {
                string centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码
                string billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
                string hosptimes = ds.Tables["DATA"].Rows[0]["HOSPTIMES"].ToString();//本年住院次数
                string startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
                string startfeepaid = ds.Tables["DATA"].Rows[0]["STARTFEEPAID"].ToString();//本年已支付起付线
                string fund1lmt = ds.Tables["DATA"].Rows[0]["FUND1LMT"].ToString();//基本统筹限额
                string fund1paid = ds.Tables["DATA"].Rows[0]["FUND1PAID"].ToString();//本年已支付基本统筹
                string fund2lmt = ds.Tables["DATA"].Rows[0]["FUND2LMT"].ToString();//大额统筹限额
                string fund2paid = ds.Tables["DATA"].Rows[0]["FUND2PAID"].ToString();//本年已支付大额统筹
                string lockinfo = ds.Tables["DATA"].Rows[0]["LOCKINFO"].ToString();//封锁信息
                string note = ds.Tables["DATA"].Rows[0]["NOTE"].ToString();//备注
                string soeccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
                string speccalflagtxt = ds.Tables["DATA"].Rows[0]["SPECCALFLAGTXT"].ToString();//特殊结算说明
                string reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
                string singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
                string singlellnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
                string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间

                GysYbRydj_Entity Rydj_Entity = new GysYbRydj_Entity();
                Rydj_Entity.Centercode = centercode;//分中心编码
                Rydj_Entity.Billno = billno;//就诊顺序号
                Rydj_Entity.Hosptimes = hosptimes;//本年住院次数
                Rydj_Entity.Startfee = startfee;//本次起付线
                Rydj_Entity.Startfeepaid = startfeepaid;//本年已支付起付线
                Rydj_Entity.Fund1lmt = fund1lmt;//基本统筹限额
                Rydj_Entity.Fund1paid = fund1paid;//本年已支付基本统筹
                Rydj_Entity.Fund2lmt = fund2lmt;//大额统筹限额
                Rydj_Entity.Fund2paid = fund2paid;//本年已支付大额统筹
                Rydj_Entity.Lockinfo = lockinfo;//封锁信息
                Rydj_Entity.Note = note;//备注
                Rydj_Entity.Soeccalflag = soeccalflag;//特殊结算标志
                Rydj_Entity.Speccalflagtxt = speccalflagtxt;//特殊结算说明
                Rydj_Entity.Reckoningtype = reckoningtype;//清算方式
                Rydj_Entity.Singleillnesscode = singleillnesscode;//清算病种编码
                Rydj_Entity.Singlellnessname = singlellnessname;//病种名称
                Rydj_Entity.Handledate = handledate;//系统处理时间
                Rydj_Entity.Cardtype = sybdk_entity.Klb;//卡类别
                Rydj_Entity.Sno = sybdk_entity.Sfzhm;//社会保障号
                Rydj_Entity.Carddata = sybdk_entity.Ctsj;//磁条数据
                Rydj_Entity.Personcode = sybdk_entity.Grbh;//个人编码
                Rydj_Entity.Ipaddr = sybdk_entity.Zdjipdz;//终端机IP地址
                Rydj_Entity.Psamno = sybdk_entity.Pasmkh;//PASM卡号
                Rydj_Entity.Pwd = sybdk_entity.Mm;//密码
                Rydj_Entity.Insuretype = sybdk_entity.Bxlb;//保险类别
                Rydj_Entity.Paytype = sybdk_entity.Zflb;//支付类别
                Rydj_Entity.Mtzyjl_iid = ihsp_id;//Mtzyjl_iid
                Rydj_Entity.Deptname = sybdk_entity.Dwmc;
                Rydj_Entity.RylbName = sybdk_entity.RylbName;

                if (!SybRydj_his_New(Rydj_Entity))
                {
                    message.Append("数据库错误");
                    return false;
                }
            }
            return true;
        }
        public bool afterReginsur(string ihsp_id, string registedinfo)
        {
            string[] message = registedinfo.Split('|');
            string strXml = "<info>";
            strXml += "<centercode>" + message[0] + "</centercode>";
            strXml += "<billno>" + message[1] + "</billno>";
            strXml += "<hosptimes>" + message[2] + "</hosptimes>";
            strXml += "<startfee>" + message[3] + "</startfee>";
            strXml += "<startfeepaid>" + message[4] + "</startfeepaid>";
            strXml += "<fund1lmt>" + message[5] + "</fund1lmt>";
            strXml += "<fund1paid>" + message[6] + "</fund1paid>";
            strXml += "<fund2lmt>" + message[7] + "</fund2lmt>";
            strXml += "<fund2paid>" + message[8] + "</fund2paid>";
            strXml += "<lockinfo>" + message[9] + "</lockinfo>";
            strXml += "<note>" + message[10] + "</note>";
            strXml += "<soeccalflag>" + message[11] + "</soeccalflag>";
            strXml += "<speccalflagtxt>" + message[12] + "</speccalflagtxt>";
            strXml += "<reckoningtype>" + message[13] + "</reckoningtype>";
            strXml += "<singleillnesscode>" + message[14] + "</singleillnesscode>";
            strXml += "<singlellnessname>" + message[15] + "</singlellnessname>";
            strXml += "<handledate>" + message[16] + "</handledate>";
            strXml += "<info>";
            string sql = "update ihsp_insurinfo set registinfo = " + registedinfo
                + "where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            int res = BllMain.Db.Update(sql);
            if (res < 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 查询医保信息
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable getReginsur(string ihsp_id)
        {
            DataTable dt = new DataTable();
            string sql = "select registinfo,settinfo from ihsp_insurinfo where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 读取医保信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable readInsurInfo(string ihsp_id)
        {
            DataTable dt = getReginsur(ihsp_id);
            string reginfo = dt.Rows[0]["registinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            DataTable dtNew = ds.Tables["info"];
            return dtNew;
        }

        public DataTable getIhspInfo(string ihsp_id)
        {
            string sql = "select inhospital.ihspcode,bas_depart.name as depart,bas_doctor.name as doctor,inhospital.indate "
                       + " from inhospital left join bas_depart on inhospital.depart_id = bas_depart.id"
                       + " left join bas_doctor on inhospital.doctor_id = bas_doctor.id "
                       + " where inhospital.id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public bool gysyb_zy(string ihsp_id, DataSet ds,DataSet dsin)
        {
            /*<CENTERCODE>分中心编码</CENTERCODE>
            <BILLNO>就诊顺序号</BILLNO>
            <HOSPTIMES>本年住院次数</HOSPTIMES>
            <STARTFEE>本次起付线</STARTFEE>
            <STARTFEEPAID>本年已支付起付线</STARTFEEPAID>
            <FUND1LMT>基本统筹限额</FUND1LMT>
            <FUND1PAID>本年已支付基本统筹</FUND1PAID>
            <FUND2LMT>大额统筹限额</FUND2LMT>
            <FUND2PAID>本年已支付大额统筹</FUND2PAID>
            <LOCKINFO>封锁信息</LOCKINFO>
            <NOTE>备注</NOTE>
            <SPECCALFLAG>特殊结算标志</SPECCALFLAG>
            <SPECCALFLAGTXT>特殊结算说明</SPECCALFLAGTXT>
            <RECKONINGTYPE>清算方式</RECKONINGTYPE>
            <SINGLEILLNESSCODE>清算病种编码</SINGLEILLNESSCODE>
            <SINGLEILLNESSNAME>病种名称</SINGLEILLNESSNAME>
            <HANDLEDATE>系统处理时间</HANDLEDATE>*/
            /*
            string data = "<CARDTYPE>" + parm[0] + "</CARDTYPE>";//卡类别        使用IC卡及身份证时，通过GETPSNINFO获得的个人编码。
            data += "<CARDDATA>" + parm[1] + "</CARDDATA>";//磁条数据            客户端IP地址
            data += "<SNO>" + parm[2] + "</SNO>";//社会保障号                    PSAM卡芯片号
            data += "<PERSONCODE>" + parm[3] + "</PERSONCODE>";//个人编码        六位数字
            data += "<IPADDR>" + parm[4] + "</IPADDR>";//终端机IP地址            参见参数表
            data += "<PSAMNO>" + parm[5] + "</PSAMNO>";//PASM卡号                参见参数表
            data += "<PASSWORD>" + parm[6] + "</PASSWORD>";//密码
            data += "<INSURETYPE>" + parm[7] + "</INSURETYPE>";//保险类别
            data += "<PAYTYPE>" + parm[8] + "</PAYTYPE>";//支付类别
            data += "<HOSPNO>" + parm[9] + "</HOSPNO>";//住院号
            data += "<ISINHOSP>" + parm[10] + "</ISINHOSP>";//参保前已在院
            data += "<DIAGNOSES>" + parm[11] + "</DIAGNOSES>";//诊断
            data += "<DOCTOR>" + parm[12] + "</DOCTOR>";//诊断医生
            data += "<OFFICE>" + parm[13] + "</OFFICE>";//科室
            data += "<REGDATE>" + parm[14] + "</REGDATE>";//入院时间
            data += "<OPERATOR>" + parm[15] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[16] + "</DODATE>";//办理时间
            data += "<GSRDBH>" + parm[17] + "</GSRDBH>";//工伤认定编号
            data += "<KFZYBZ>" + parm[18] + "</KFZYBZ>";//工伤康复住院标志         0：否；1：是
             */

            string sql = "insert insur_gysyb_zy "
                + " set mtzyjliid = " + DataTool.addFieldBraces(ihsp_id)
                + " , centercode = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString())
                + " , billno = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["BILLNO"].ToString())
                + " , hosptimes = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["HOSPTIMES"].ToString())
                + " , startfee = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString())
                + " , startfeepaid = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["STARTFEEPAID"].ToString())
                + " , fund1lmt = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["FUND1LMT"].ToString())
                + " , fund1paid = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["FUND1PAID"].ToString())
                + " , fund2lmt = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["FUND2LMT"].ToString())
                + " , fund2paid = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["FUND2PAID"].ToString())
                + " , lockinfo = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["LOCKINFO"].ToString())
                + " , note = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["NOTE"].ToString())
                + " , speccalflag = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString())
                + " , speccalflagtxt = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["SPECCALFLAGTXT"].ToString())
                + " , reckoningtype = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString())
                + " , singleillnesscode = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString())
                + " , singleillnessname = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString())
                + " , handledate = " + DataTool.addFieldBraces(ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString())

                + " , cardtype = " + DataTool.addFieldBraces(dsin.Tables["DATA"].Rows[0]["CARDTYPE"].ToString())
                + " , carddata = " + DataTool.addFieldBraces(dsin.Tables["DATA"].Rows[0]["CARDDATA"].ToString())
                + " , sno = " + DataTool.addFieldBraces(dsin.Tables["DATA"].Rows[0]["SNO"].ToString())
                + " , personcode = " + DataTool.addFieldBraces(dsin.Tables["DATA"].Rows[0]["PERSONCODE"].ToString())
                + " , ipaddr = " + DataTool.addFieldBraces(dsin.Tables["DATA"].Rows[0]["IPADDR"].ToString())
                + " , psamno = " + DataTool.addFieldBraces(dsin.Tables["DATA"].Rows[0]["PSAMNO"].ToString())
                + " , pwd = " + DataTool.addFieldBraces(dsin.Tables["DATA"].Rows[0]["PASSWORD"].ToString())
                + " , insuretype = " + DataTool.addFieldBraces(dsin.Tables["DATA"].Rows[0]["INSURETYPE"].ToString())
                + " , paytype = " + DataTool.addFieldBraces(dsin.Tables["DATA"].Rows[0]["PAYTYPE"].ToString());
             
            int res = BllMain.Db.Update(sql);
            if (res < 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 市医保入院登记成功后执行此方法 【 参考方法SybRydj_his（）】
        /// ReWriter:qinYangYang 2014/4/18
        /// </summary>
        /// <param name="Rydj_Entity"></param>
        /// <returns></returns>
        public bool SybRydj_his_New(GysYbRydj_Entity Rydj_Entity)
        {

            // 修改his系统nhflag标志，置为7
            string sql = "delete from insur_gysyb_zy where mtzyjliid='" + Rydj_Entity.Mtzyjl_iid + "'; INSERT INTO insur_gysyb_zy("
                          + "  mtzyjliid, centercode, billno, hosptimes, startfee, startfeepaid, "
                          + "  fund1lmt, fund1paid, fund2lmt, fund2paid, lockinfo, note, speccalflag,"
                          + "  speccalflagtxt, reckoningtype, singleillnesscode, singleillnessname, "
                          + " handledate, cardtype, carddata, sno, personcode, ipaddr, psamno, "
                          + "  pwd, insuretype, paytype, dwmc,acctbalance, rylbname)"
                          + "VALUES ('"
                          + Rydj_Entity.Mtzyjl_iid + "','" + Rydj_Entity.Centercode + "','" + Rydj_Entity.Billno + "','" + Rydj_Entity.Hosptimes + "','"
                          + Rydj_Entity.Startfee + "','" + Rydj_Entity.Startfeepaid + "','" + Rydj_Entity.Fund1lmt + "','" + Rydj_Entity.Fund1paid + "','"
                          + Rydj_Entity.Fund2lmt + "','" + Rydj_Entity.Fund2paid + "','" + Rydj_Entity.Lockinfo + "','" + Rydj_Entity.Note + "','"
                          + Rydj_Entity.Soeccalflag + "','" + Rydj_Entity.Speccalflagtxt + "','" + Rydj_Entity.Reckoningtype + "','" + Rydj_Entity.Singleillnesscode + "','"
                          + Rydj_Entity.Singlellnessname + "','" + Rydj_Entity.Handledate + "','" + Rydj_Entity.Cardtype + "','" + Rydj_Entity.Carddata + "','"
                          + Rydj_Entity.Sno + "','" + Rydj_Entity.Personcode + "','" + Rydj_Entity.Ipaddr + "','" + Rydj_Entity.Psamno + "','" + Rydj_Entity.Pwd + "','"
                          + Rydj_Entity.Insuretype + "','" + Rydj_Entity.Paytype + "','" + Rydj_Entity.Dwmc + "','" + Rydj_Entity.Zhye + "','" + Rydj_Entity.RylbName + "'); ";


            if (BllMain.Db.Update(sql) == -1)
            {
                LogUtils.writeFileLog("gysyb.log","GyybDb.SybRydj_his_New()方法执行失败，市医保更新his错误信息"+ DateTime.Now+ "sql=" + sql);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 医保结算后返回数据更新his数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int updateZyjs(Zyjs_ret zyjs_ret_Entity)
        {

            String sql = " UPDATE insur_gysyb_zy "
                   + " SET  centercode='" + zyjs_ret_Entity.Centercode + "', billno='" + zyjs_ret_Entity.Billno + "',balanceid='" + zyjs_ret_Entity.Balanceid + "',hospfeeall='" + zyjs_ret_Entity.Hospfeeall + "',calfeeall='" + zyjs_ret_Entity.Calfeeall + "',"
                   + " feeout='" + zyjs_ret_Entity.Feeout + "',feeself='" + zyjs_ret_Entity.Feeself + "',allowfund='" + zyjs_ret_Entity.Allowfund + "',startfee='" + zyjs_ret_Entity.Startfee + "',enterstartfee='" + zyjs_ret_Entity.Enterstartfee + "',"
                   + " fund1pay='" + zyjs_ret_Entity.Fund1pay + "', fund1self='" + zyjs_ret_Entity.Fund1self + "', fund2pay='" + zyjs_ret_Entity.Fund2pay + "', fund2self='" + zyjs_ret_Entity.Fund2self + "', "
                   + " acctpay='" + zyjs_ret_Entity.Acctpay + "', fund3pay='" + zyjs_ret_Entity.Fund3pay + "', acctbalance='" + zyjs_ret_Entity.Acctbalance + "', handledte='" + zyjs_ret_Entity.Handledte + "', speccalflag='" + zyjs_ret_Entity.Speccalflag + "', "
                   + " reckoningtype='" + zyjs_ret_Entity.Reckoningtype + "', singleillnesscode='" + zyjs_ret_Entity.Singleillnesscode + "', singleillnessname='" + zyjs_ret_Entity.Singleillnessname + "',feeover='" + zyjs_ret_Entity.Feeouer + "', "
                    + " sbstartfee='" + zyjs_ret_Entity.Sbstartfee + "', sbpay='" + zyjs_ret_Entity.Sbpay + "' "
                   + "  WHERE mtzyjliid=" + zyjs_ret_Entity.Mtzyjl_iid + ";";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 转医保时更新市医保入院信息
        /// </summary>
        /// <param name="ihsp_id">住院记录id</param>
        /// <param name="patienttype"></param>
        /// <param name="csrq">生日</param>
        /// <param name="sfzhm">身份证</param>
        /// <param name="dwmc">单位名称</param>
        /// <param name="insurcode">个人编号</param>
        /// <returns></returns>
       
        public int upSybRyInfo(string ihsp_id, string patienttype, Sybdk_Entity sybdk_entity)
        {
            string sql = "update inhospital set bas_patienttype_id=" + DataTool.addFieldBraces(patienttype)
                + ",insurstat='REG',insuritemtype='3'"
                + ",insurcode=" + DataTool.addFieldBraces(sybdk_entity.Grbh)
                + ",bas_patienttype1_id=" + DataTool.addFieldBraces(patienttype)
                + ",birthday=" + DataTool.addFieldBraces(sybdk_entity.Csrq)
                + " where id=" + DataTool.addFieldBraces(ihsp_id) + ";";
            sql += "update ihsp_info set companyname=" + DataTool.addFieldBraces(sybdk_entity.Dwmc)
                + ",idcard=" + DataTool.addFieldBraces(sybdk_entity.Sfzhm)
                + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id)
                + ";";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 数据传输
        /// </summary>
        /// <returns></returns>
        public DataTable getCostdet(string ihsp_id, string insursync)
        {
            string sql = "select ihsp_costdet.id"
                        + ",ihsp_costdet.id as costdet_id"
                        + ",ihsp_costdet.item_id"
                        + ",ihsp_costdet.standcode"//院内收费项目编码
                        + ",ihsp_costdet.name"
                        + ",ihsp_costdet.spec"
                        + ",ihsp_costdet.unit"
                        + ",ihsp_costdet.prc"
                        + ",ihsp_costdet.num"
                        + ",ihsp_costdet.diagndep_id"
                        + ",ihsp_costdet.diagndoctor_id"
                        + ",bas_depart.name as exedpt"
                        + ",bas_doctor.name as exedct"
                        + ",diagndepart.name as diagndpt"
                        + ",diagndoctor.name as diagndct"
                        + ",diagndoctor.cardid"
                        + ",ihsp_costdet.chargedate"
                        + ",ihsp_costdet.ihsp_costdet_id"
                        + ",ihsp_costdet.charged"
                        + ",insur_itemtype.insurcode as subject"//发票科目编码
                        + ",cost_insurcross.insurcode as insurcode"//医保编码
                        + " from ihsp_costdet "
                        + " left join bas_depart on ihsp_costdet.exedep_id = bas_depart.id"
                        + " left join bas_doctor on ihsp_costdet.exedoctor_id = bas_doctor.id"
                        + " left join bas_depart as diagndepart on ihsp_costdet.diagndep_id = diagndepart.id"
                        + " left join bas_doctor as diagndoctor on ihsp_costdet.diagndoctor_id = diagndoctor.id"
                        + " left join insur_itemtype on ihsp_costdet.itemtype_id = insur_itemtype.itemtype_id and cost_insurtype_id ="
                        + " (select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.GYSYB.ToString()) + ")"
                        + " left join cost_insurcross on ihsp_costdet.item_id = cost_insurcross.item_id and cost_insurcross.insuritemtype = '3' and cost_insurcross.drug_factyitem_id=ihsp_costdet.drug_factyitem_id"
                        + " where ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
                        + " and ihsp_costdet.neonate_id = 0"//非新生儿
                        + " and ihsp_costdet.insursync =" + DataTool.addFieldBraces(insursync)
                        + " and ihsp_costdet.charged in ('RET','CHAR')";
            sql += " union select ihsp_costdet.ihsp_costdet_id as id"
                        + ",ihsp_costdet.id as costdet_id"
                       + ",ihsp_costdet.item_id"
                       + ",ihsp_costdet.standcode"//院内收费项目编码
                       + ",ihsp_costdet.name"
                       + ",ihsp_costdet.spec"
                       + ",ihsp_costdet.unit"
                       + ",ihsp_costdet.prc"
                       + ",ihsp_costdet.num"
                       + ",ihsp_costdet.diagndep_id"
                       + ",ihsp_costdet.diagndoctor_id"
                       + ",bas_depart.name as exedpt"
                       + ",bas_doctor.name as exedct"
                       + ",diagndepart.name as diagndpt"
                       + ",diagndoctor.name as diagndct"
                       + ",diagndoctor.cardid"
                       + ",ihsp_costdet.chargedate"
                       + ",ihsp_costdet.ihsp_costdet_id"
                       + ",ihsp_costdet.charged"
                       + ",insur_itemtype.insurcode as subject"//发票科目编码
                       + ",cost_insurcross.insurcode as insurcode"//医保编码
                       + " from ihsp_costdet "
                       + " left join bas_depart on ihsp_costdet.exedep_id = bas_depart.id"
                       + " left join bas_doctor on ihsp_costdet.exedoctor_id = bas_doctor.id"
                       + " left join bas_depart as diagndepart on ihsp_costdet.diagndep_id = diagndepart.id"
                       + " left join bas_doctor as diagndoctor on ihsp_costdet.diagndoctor_id = diagndoctor.id"
                       + " left join insur_itemtype on ihsp_costdet.itemtype_id = insur_itemtype.itemtype_id and cost_insurtype_id ="
                       + " (select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.GYSYB.ToString()) + ")"
                       + " left join cost_insurcross on ihsp_costdet.item_id = cost_insurcross.item_id and   cost_insurcross.insuritemtype = '3' and cost_insurcross.drug_factyitem_id=ihsp_costdet.drug_factyitem_id "
                       + " where ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
                       + " and ihsp_costdet.neonate_id = 0"//非新生儿
                       + " and ihsp_costdet.insursync =" + DataTool.addFieldBraces(insursync)
                       + " and ihsp_costdet.charged in ('RREC')";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 查询医生信息
        /// </summary>
        /// <returns></returns>
        public DataTable getDoctorInfo(string dct_id, string dpt_id)
        {
            string sql = "select bas_depart.name as dptname,bas_doctor.name as dctname,bas_doctor.cardid from bas_depart,bas_doctor "
                       + " where bas_depart.id = " + DataTool.addFieldBraces(dpt_id)
                       + " and bas_doctor.id = " + DataTool.addFieldBraces(dct_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getInsurstat(string ihsp)
        {
            string sql = "select insurstat from inhospital where id = " + DataTool.addFieldBraces(ihsp);
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 保存结算返回数据
        /// </summary>
        /// <param name="thisid"></param>
        /// <param name="settledInfo"></param>
        /// <returns></returns>
        public int updateSettledInfo(string thisid, string settledInfo)
        {
            string sql = "update ihsp_insurinfo set settinfo = " + DataTool.addFieldBraces(settledInfo)
                       + " where ihsp_id =  " + DataTool.addFieldBraces(thisid);
            int res = BllMain.Db.Update(sql);
            return res;
        }
        public DataTable getSettledInfo(string thisid)
        {
            string sql = "select   billno,balanceid,paytype,insuretype from  insur_gysyb_zy where mtzyjliid= " + DataTool.addFieldBraces(thisid);
            //string sql = "select settinfo,presettleinfo from ihsp_insurinfo where ihsp_id =  " + DataTool.addFieldBraces(thisid);
            return BllMain.Db.Select(sql).Tables[0];
        }
        public int updateInsurInfo(string thisid, string settledInfo)
        {
            string sql = "update ihsp_insurinfo set presettleinfo = " + DataTool.addFieldBraces(settledInfo)
                        + " where ihsp_id = " + DataTool.addFieldBraces(thisid);
            int res = BllMain.Db.Update(sql);
            return res;
        }

        /// <summary>
        /// 查询出院登记信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable getCydjInfo(string ihsp_id)
        {
            /*string sql = "select ihsp_insurinfo.registinfo"
                        + ",inhospital.ihspcode"
                        + ",inhospital.ihspdiagn"
                        + ",inhospital.doctor_id"
                        + ",inhospital.depart_id"
                        + ",inhospital.bas_ihspoutstat_id"
                        + " from ihsp_insurinfo,inhospital "
                        + " where ihsp_insurinfo.ihsp_id = "
                + DataTool.addFieldBraces(ihsp_id) + "and inhospital.id = " + DataTool.addFieldBraces(ihsp_id);*/
            string sql = "select inhospital.insurcode"
                    + ",inhospital.ihspcode"
                    + ",inhospital.ihspdiagn"
                    + ",ihsp_diagnmes.diagnICD"
                    + ",ihsp_diagnmes.diagnname"
                    + ",inhospital.doctor_id"
                    + ",bas_depart.name as departname"
                    + ",inhospital.bas_ihspoutstat_id"
                    + " from inhospital "
                    + " left join ihsp_diagnmes on ihsp_diagnmes.ihsp_id=inhospital.id and ihsp_diagnmes.diagnkind='OUT' "
                    + " left join bas_depart on bas_depart.id=inhospital.depart_id and bas_depart.isstop='N' "
                    + " where  inhospital.id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 出院登记
        /// </summary>
        /// <returns></returns>
        public bool Cydj(string ihsp_id,string outtype, StringBuilder message)
        {
            DataTable dt = getCydjInfo(ihsp_id);
            string insurcode = dt.Rows[0]["insurcode"].ToString();
            string ihsp_code = dt.Rows[0]["ihspcode"].ToString();
            string ihsp_diag = dt.Rows[0]["diagnname"].ToString();
            string ihsp_diagicd = dt.Rows[0]["diagnICD"].ToString();
            string doctor_id = dt.Rows[0]["doctor_id"].ToString();
            string depart_name = dt.Rows[0]["departname"].ToString();

            string[] param = new string[11];
            param[0] = insurcode;//个人编码
            param[1] = ihsp_code;//住院号
            param[2] = ihsp_diag;//主诊断icdname
            param[3] = "";//其他诊断 
            param[4] = outtype; //转归类别
            param[5] = doctor_id;//诊断医生
            param[6] = depart_name;//科室名称
            param[7] = ihsp_diagicd;//ICD编码
            param[8] = BillSysBase.currDate();//出院时间
            param[9] = ProgramGlobal.User_id;//操作员
            param[10] = BillSysBase.currDate();//办理时间
            Cydj cydj = new Cydj();
            String InXml = cydj.Cydj_head() + cydj.Cydj_in(param) + cydj.Cydj_tail();
            String outXml = gysybface.cydj(InXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();
            SysWriteLogs.writeLogs1("贵阳市医保出院登记", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            string udp_sql = "update inhospital set insurouthsp = '1' where id = " + DataTool.addFieldBraces(ihsp_id);
            BllMain.Db.Update(udp_sql);
            return true;
        }
        /// <summary>
        /// 贵阳市预结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool NursYjs(string ihsp_id)
        {
           DataTable dt = gysybIhspInfo( ihsp_id);
           string bxlb = dt.Rows[0]["insuretype"].ToString();
           string jsfs = dt.Rows[0]["caltype"].ToString();
           string qsfs = dt.Rows[0]["reckoningtype"].ToString();
           string ybBzbm = dt.Rows[0]["singleillnesscode"].ToString();
           string insurcode = dt.Rows[0]["insurcode"].ToString();
           StringBuilder message = new StringBuilder();
           if (bxlb != "2" && bxlb != "5" && bxlb != "4" && bxlb!="7")
                {
                    if (jsfs != "0")
                    {
                        if (!setCalType(message, jsfs, ybBzbm, insurcode))
                        {
                            return false;
                        }
                    }
                }
                message.Length = 0;
                string _qsfs = "1";//清算方式
                if (bxlb != "2" && bxlb != "7")
                {
                    if (qsfs != "9")
                    {
                        _qsfs = qsfs;//清算方式
                    }
                    if (!setReckoningType(message, _qsfs, ybBzbm, insurcode))
                    {
                      
                        return false;
                    }
                }

                message.Length = 0;
                string errInfo = "";
                Dictionary<String, Zyjs_ret> dic = preSettle(ihsp_id, "111111", "0", message, out errInfo, jsfs, ybBzbm);
                if (!string.IsNullOrEmpty(errInfo))
                {
                   
                    return false;
                }
                Zyjs_ret zyjs_ret_entity = new Zyjs_ret();
                dic.TryGetValue("zyjs_ret", out zyjs_ret_entity);
                return true;
        }
        
        
        /// <summary>
        ///  模拟住院结算
        /// </summary>
        /// <param name="insurInfo"></param>
        /// <param name="ihsp_id"></param>住院登记id
        /// <param name="invoiceCode"></param>发票号
        /// <param name="cardPay"></param>账户支付额
        /// <param name="message"></param>
        /// <param name="errInfo"></param>
        /// <returns></returns>
        public Dictionary<String, Zyjs_ret> preSettle(string ihsp_id, string invoiceCode, string cardPay, StringBuilder message, out string errInfo, string settletype, string icdcode)
        {//住院记录iid-错误消息-清算方式-病种编码-时间-“”
            errInfo = "";
            Dictionary<String, Zyjs_ret> dic = new Dictionary<string, Zyjs_ret>();
            GysybInterface gysybface = new GysybInterface();
            //卡类别|磁条数据|社保卡卡号|个人编码|终端机IP地址|PASM卡号|密码|保险类别|支付类别|诊断|工伤认定编号|工伤康复住院标志
            //人员类别名称|单位名称|账户余额
            DataTable dtInsur = gysybIhspInfo(ihsp_id);
            string[] param = new string[14];
            param[0] = dtInsur.Rows[0]["cardtype"].ToString();  //卡类别
            param[1] = dtInsur.Rows[0]["carddata"].ToString(); //磁条数据
            param[2] = dtInsur.Rows[0]["sno"].ToString();////社保卡卡号
            param[3] = dtInsur.Rows[0]["ipaddr"].ToString();// readybcard.ZdIp;//终端机IP地址(可选)
            param[4] = dtInsur.Rows[0]["psamno"].ToString();//PASM卡号  
            param[5] = dtInsur.Rows[0]["insurcode"].ToString();//个人编码
            param[6] = dtInsur.Rows[0]["pwd"].ToString();//密码
            param[7] = "0";//是否结算  0模拟结算1正式结算
            param[8] = "0";//是否严控特殊项目     0：不严控；1：严控      
            param[9] = cardPay;//账户支付额
            string insuretype = dtInsur.Rows[0]["insuretype"].ToString();//保险类别
            if (string.IsNullOrEmpty(cardPay))
            {
                param[9] = "0";
            }
            param[10] = invoiceCode;//发票号
            param[11] = settletype;//清算方式
            param[12] = icdcode;//单病种编码
            param[13] = ProgramGlobal.User_id;//操作员
            param[14] = BillSysBase.currDate();//办理日期
            Zyjs zyjs = new Zyjs();
            String inXml = zyjs.Zyjs_head() + zyjs.Zyjs_in(param);
            String fy = "";
            DataTable items = getCostdet(ihsp_id, "N");
            String[] param2 = new String[26];
            //  if(items.Rows[0][)
            for (int i = 0; i < items.Rows.Count; i++)
            {
                param2[0] = items.Rows[i]["id"].ToString();//数据批号
                param2[1] = items.Rows[i]["insurcode"].ToString();//医保编码
                param2[2] = items.Rows[i]["name"].ToString();//项目名称
                if (string.IsNullOrEmpty(param2[1]))
                {
                    errInfo += "医保编码为空：项目名称：【" + param2[2] + "】=====";
                }
                param2[3] = items.Rows[i]["subject"].ToString();//发票归属科目编码
                param2[4] = items.Rows[i]["spec"].ToString();//规格
                param2[5] = "";// 剂型
                param2[6] = items.Rows[i]["unit"].ToString();//单位
                param2[7] = items.Rows[i]["prc"].ToString();//单价
                param2[8] = items.Rows[i]["num"].ToString();//数量
                param2[11] = items.Rows[i]["exedpt"].ToString();//受单科室
                param2[12] = items.Rows[i]["exedct"].ToString();//受单医生
                param2[13] = Convert.ToDateTime(items.Rows[i]["chargedate"]).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
                param2[14] = "";//备注
                string charged = items.Rows[i]["charged"].ToString();
                if (charged == CostCharged.CHAR.ToString() || charged == CostCharged.RET.ToString())
                {
                    param2[15] = "0";//items.Rows[i]["0"].ToString();//冲销标志0正常1冲销
                }
                else if (charged == CostCharged.RREC.ToString())//冲销
                {
                    param2[15] = "1";//items.Rows[i]["1"].ToString();//冲销标志0正常1冲销
                }

                param2[16] = "";//用药途径
                param2[17] = "";//用药频次
                param2[18] = "";//单次用量
                param2[19] = "";//用药天数    
                param2[21] = items.Rows[i]["standcode"].ToString();// 院内收费项目编码
                param2[22] = "";//取药总量
                param2[23] = "";//取药总量单位
                param2[24] = "";//药量天数
                param2[25] = Convert.ToDateTime(items.Rows[i]["chargedate"]).ToString("yyyy-MM-dd HH:mm:ss");//执行时间
                //string dpt_id = items.Rows[i]["diagndep_id"].ToString();
                //string dct_id = items.Rows[i]["diagndoctor_id"].ToString();
                //DataTable dt = getDoctorInfo(dct_id, dpt_id);
                param2[9] = items.Rows[i]["diagndpt"].ToString();//开单科室
                param2[10] = items.Rows[i]["diagndct"].ToString();//开单医生

                param2[20] = items.Rows[i]["cardid"].ToString();//开药医师身份证号码
                fy += zyjs.Zyjs_in2(param2);
            }
            if (!string.IsNullOrEmpty(errInfo))
            {
                return dic;
            }
            inXml += fy;
            inXml += zyjs.Zyjs_tail();
            String outXml = gysybface.mnZyjs(inXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
            SysWriteLogs.writeLogs1("贵阳市医保模拟住院结算", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
                message.Append(info);
                errInfo = "医保中心返回错误信息:【" + info + "】，状态码:【" + flag + "】";
                dic.Add("zyjs_ret", zyjs_ret_Entity);
                return dic;
            }
            else
            {
                errInfo = "";
                string sql = "";
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    sql += "update ihsp_costdet set insursync = 'Y' where id = " + DataTool.addFieldBraces(items.Rows[i]["costdet_id"].ToString())+";";
                }
                if (!string.IsNullOrEmpty(sql))
                {
                    int flg = BllMain.Db.Update(sql);
                    if (flg.Equals(-1))
                    {
                        errInfo = "更新费用上传标志失败";
                    }
                }
            }
            zyjs_ret_Entity.Centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码
            zyjs_ret_Entity.Billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
            zyjs_ret_Entity.Balanceid = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
            zyjs_ret_Entity.Hospfeeall = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
            zyjs_ret_Entity.Feeall = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
            zyjs_ret_Entity.Calfeeall = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
            zyjs_ret_Entity.Feeout = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
            zyjs_ret_Entity.Feeself = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
            zyjs_ret_Entity.Allowfund = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
            zyjs_ret_Entity.Startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
            zyjs_ret_Entity.Enterstartfee = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
            zyjs_ret_Entity.Fund1pay = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
            zyjs_ret_Entity.Fund1self = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
            zyjs_ret_Entity.Fund2pay = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额统筹支付
            zyjs_ret_Entity.Fund2self = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
            zyjs_ret_Entity.Feeouer = ds.Tables["DATA"].Rows[0]["FEEOVER"].ToString();//超限额自付
            zyjs_ret_Entity.Acctpay = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
            zyjs_ret_Entity.Fund3pay = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
            zyjs_ret_Entity.Acctbalance = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
            zyjs_ret_Entity.Handledte = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            zyjs_ret_Entity.Speccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
            zyjs_ret_Entity.Reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
            zyjs_ret_Entity.Singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
            zyjs_ret_Entity.Singleillnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
            zyjs_ret_Entity.Sbstartfee = ds.Tables["DATA"].Rows[0]["SBSTARTFEE"].ToString();//商保起付线
            zyjs_ret_Entity.Sbpay = ds.Tables["DATA"].Rows[0]["SBPAY"].ToString();//商保支付
            zyjs_ret_Entity.Mtzyjl_iid = ihsp_id;
            string jbtcbx = zyjs_ret_Entity.Fund1pay;//基本统筹支付
            if (insuretype.Equals("2"))
            {
                jbtcbx = zyjs_ret_Entity.Allowfund;
            }
            string ybbx = (DataTool.Getdouble(jbtcbx) + DataTool.Getdouble(zyjs_ret_Entity.Fund2pay) + DataTool.Getdouble(zyjs_ret_Entity.Fund3pay) + DataTool.Getdouble(zyjs_ret_Entity.Sbpay)).ToString();
            string preact_sql = "update inhospital set insurefee=" + DataTool.addFieldBraces(ybbx)
               + ", insuraccountfee ='0' "
                + ", nustmpamt = balanceamt+ insuraccountfee+insurefee "
               + " where id =" + DataTool.addFieldBraces(ihsp_id) + ";";
            BllMain.Db.Update(preact_sql);
            dic.Add("zyjs_ret", zyjs_ret_Entity);
            return dic;
        }

        /// <summary>
        ///  住院结算
        /// </summary>
        /// <param name="ihsp_id"></param>住院登记id
        /// <param name="invoiceCode"></param>发票号
        /// <param name="cardPay"></param>账户支付额
        /// <param name="message"></param>
        /// <param name="errInfo"></param>
        /// <param name="settletype"></param>
        /// <param name="icdcode">疾病编码</param>
        /// <param name="sybdk_entity">读卡信息</param>
        /// <returns></returns>
        public Dictionary<String, Zyjs_ret> settle(string ihsp_id, string invoiceCode, string cardPay, StringBuilder message, out string errInfo, string settletype, string icdcode, Sybdk_Entity sybdk_entity)
        {//住院记录iid-错误消息-清算方式-病种编码-时间-“”
            errInfo = "";
            Dictionary<String, Zyjs_ret> dic = new Dictionary<string, Zyjs_ret>();
            GysybInterface gysybface = new GysybInterface();
            //卡类别|磁条数据|社保卡卡号|个人编码|终端机IP地址|PASM卡号|密码|保险类别|支付类别|诊断|工伤认定编号|工伤康复住院标志
            //人员类别名称|单位名称|账户余额
            //DataTable dtInsur = gysybIhspInfo(ihsp_id);
            string[] param = new string[14];
            param[0] = sybdk_entity.Klb; //卡类别 
            param[1] = sybdk_entity.Ctsj;//磁条数据
            param[2] = sybdk_entity.Sfzhm;//社会保障号
            param[3] = sybdk_entity.Zdjipdz;//终端机IP地址(可选)
            param[4] = sybdk_entity.Pasmkh;//PASM卡号  
            param[5] = sybdk_entity.Grbh;//个人编码
            param[6] = sybdk_entity.Mm;//密码
            param[7] = "1";// settled;//是否结算 0模拟结算1正式结算
            param[8] = "0";//是否严控特殊项目     0：不严控；1：严控  
            param[9] = cardPay;//账户支付额
            if (string.IsNullOrEmpty(cardPay))
            {
                param[9] = "0";
            }
            param[10] = invoiceCode;//发票号
            param[11] = settletype;//清算方式
            param[12] = icdcode;//单病种编码
            param[13] = ProgramGlobal.User_id;//操作员
            param[14] = BillSysBase.currDate();//办理日期
            Zyjs zyjs = new Zyjs();
            String inXml = zyjs.Zyjs_head() + zyjs.Zyjs_in(param);
            String fy = "";
            DataTable items = getCostdet(ihsp_id, "N");
            String[] param2 = new String[26];
            //  if(items.Rows[0][)
            for (int i = 0; i < items.Rows.Count; i++)
            {
                param2[0] = items.Rows[i]["id"].ToString();//数据批号
                param2[1] = items.Rows[i]["insurcode"].ToString();//医保编码
                param2[2] = items.Rows[i]["name"].ToString();//项目名称
                if (string.IsNullOrEmpty(param2[1]))
                {
                    errInfo += "医保编码为空：项目名称：【" + param2[2] + "】=====";
                }
                param2[3] = items.Rows[i]["subject"].ToString();//发票归属科目编码
                param2[4] = items.Rows[i]["spec"].ToString();//规格
                param2[5] = "";// 剂型
                param2[6] = items.Rows[i]["unit"].ToString();//单位
                param2[7] = items.Rows[i]["prc"].ToString();//单价
                param2[8] = items.Rows[i]["num"].ToString();//数量
                param2[11] = items.Rows[i]["exedpt"].ToString();//受单科室
                param2[12] = items.Rows[i]["exedct"].ToString();//受单医生
                param2[13] = Convert.ToDateTime(items.Rows[i]["chargedate"]).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
                param2[14] = "";//备注
                string charged = items.Rows[i]["charged"].ToString();
                if (charged == CostCharged.CHAR.ToString() || charged == CostCharged.RET.ToString())
                {
                    param2[15] = "0";//items.Rows[i]["0"].ToString();//冲销标志0正常1冲销
                }
                else if (charged == CostCharged.RREC.ToString())//冲销
                {
                    param2[15] = "1";//items.Rows[i]["1"].ToString();//冲销标志0正常1冲销
                }

                param2[16] = "";//用药途径
                param2[17] = "";//用药频次
                param2[18] = "";//单次用量
                param2[19] = "";//用药天数    
                param2[21] = items.Rows[i]["standcode"].ToString();// 院内收费项目编码
                param2[22] = "";//取药总量
                param2[23] = "";//取药总量单位
                param2[24] = "";//药量天数
                param2[25] = Convert.ToDateTime(items.Rows[i]["chargedate"]).ToString("yyyy-MM-dd HH:mm:ss");//执行时间
                //string dpt_id = items.Rows[i]["diagndep_id"].ToString();
                //string dct_id = items.Rows[i]["diagndoctor_id"].ToString();
                //DataTable dt = getDoctorInfo(dct_id, dpt_id);
                param2[9] = items.Rows[i]["diagndpt"].ToString();//开单科室
                param2[10] = items.Rows[i]["diagndct"].ToString();//开单医生

                param2[20] = items.Rows[i]["cardid"].ToString();//开药医师身份证号码
                fy += zyjs.Zyjs_in2(param2);
            }
            if (!string.IsNullOrEmpty(errInfo))
            {
                return dic;
            }
            inXml += fy;
            inXml += zyjs.Zyjs_tail();
            String outXml = gysybface.mnZyjs(inXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
            SysWriteLogs.writeLogs1("贵阳市医保模拟住院结算", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
             
                errInfo = "医保中心返回错误信息:【" + info + "】，状态码:【" + flag + "】";
                dic.Add("zyjs_ret", zyjs_ret_Entity);
                return dic;
            }
            else
            {
                errInfo = "";
                string sql = "";
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    sql += "update ihsp_costdet set insursync = 'Y' where id = " + DataTool.addFieldBraces(items.Rows[i]["costdet_id"].ToString())+";";
                }
                if (!string.IsNullOrEmpty(sql))
                {
                    int flg = BllMain.Db.Update(sql);
                    if (flg.Equals(-1))
                    {
                        errInfo = "更新费用上传标志失败";
                    }
                }
            }
            zyjs_ret_Entity.Centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码
            zyjs_ret_Entity.Billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
            zyjs_ret_Entity.Balanceid = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
            zyjs_ret_Entity.Hospfeeall = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
            zyjs_ret_Entity.Feeall = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
            zyjs_ret_Entity.Calfeeall = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
            zyjs_ret_Entity.Feeout = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
            zyjs_ret_Entity.Feeself = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
            zyjs_ret_Entity.Allowfund = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
            zyjs_ret_Entity.Startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
            zyjs_ret_Entity.Enterstartfee = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
            zyjs_ret_Entity.Fund1pay = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
            if (sybdk_entity.Bxlb.Equals("2"))
            {
                zyjs_ret_Entity.Fund1pay = zyjs_ret_Entity.Allowfund;
            }

            zyjs_ret_Entity.Fund1self = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
            zyjs_ret_Entity.Fund2pay = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额统筹支付
            zyjs_ret_Entity.Fund2self = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
            zyjs_ret_Entity.Feeouer = ds.Tables["DATA"].Rows[0]["FEEOVER"].ToString();//超限额自付
            zyjs_ret_Entity.Acctpay = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
            zyjs_ret_Entity.Fund3pay = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
            zyjs_ret_Entity.Acctbalance = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
            zyjs_ret_Entity.Handledte = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            zyjs_ret_Entity.Speccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
            zyjs_ret_Entity.Reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
            zyjs_ret_Entity.Singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
            zyjs_ret_Entity.Singleillnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
            zyjs_ret_Entity.Sbstartfee = ds.Tables["DATA"].Rows[0]["SBSTARTFEE"].ToString();//商保起付线
            zyjs_ret_Entity.Sbpay = ds.Tables["DATA"].Rows[0]["SBPAY"].ToString();//商保支付
            zyjs_ret_Entity.Mtzyjl_iid = ihsp_id;
            //更新his数据
            dic.Add("zyjs_ret", zyjs_ret_Entity);
            return dic;
        }

        public DataTable getPersonInfo(string ihsp_id)
        {
            string sql = "select registinfo from ihsp_insurinfo where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 设置结算方式
        /// </summary>
        /// <param name="message"></param>
        /// <param name="jsfs">结算方式</param>
        /// <param name="singleIllnessCode">单病种编码</param>
        /// <param name="personCode">个人编号</param>
        /// <returns></returns>
        public bool setCalType(StringBuilder message, string jsfs, string singleIllnessCode, string personCode)
        {
            GysybInterface gysybface = new GysybInterface();
            string[] param = new string[5];
            param[0] = personCode;//个人编码
            param[1] = jsfs;//结算方式
            param[2] = singleIllnessCode;
            param[3] = ProgramGlobal.Username;
            param[4] = BillSysBase.currDate();
            Szjsfs szjsfs = new Szjsfs();
            String inXml = szjsfs.Szjsfs_head() + szjsfs.Szjsfs_in(param) + szjsfs.Szjsfs_tail();
            //调用业务类

            string outXml = gysybface.Szjsfs(inXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            SysWriteLogs.writeLogs1("贵阳市医保模拟住院结算", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 设置清算方式
        /// </summary>清算方式为1时，单病种编码不能为空
        /// <returns></returns>
        public bool setReckoningType(StringBuilder message, string qsfs, string singleIllnessCode, string personCode)
        {
            GysybInterface gysybface = new GysybInterface();
            String[] param = new String[5];
            param[0] = personCode;
            param[1] = qsfs.ToString();
            param[2] = singleIllnessCode;
            param[3] = ProgramGlobal.Username;
            param[4] = BillSysBase.currDate();
            Szqsfs szqsfs = new Szqsfs();
            String inXml = szqsfs.Szqsfs_head() + szqsfs.Szqsfs_in(param) + szqsfs.Szqsfs_tail();
            //调用业务类
            string outXml = gysybface.Szqsfs(inXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            SysWriteLogs.writeLogs1("贵阳市医保模拟住院结算", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 特殊结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="insurInfo"></param>
        /// <param name="settled"></param>
        /// <param name="invoiceCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Dictionary<String, Zyjs_ret> settleSp(string ihsp_id, string settled, string invoiceCode, StringBuilder message, string qsfs, string dbzbm)
        {
            DataTable dtInsur = gysybIhspInfo(ihsp_id);
            string personCode = dtInsur.Rows[0]["insurcode"].ToString();
            string[] param = new string[8];
            param[0] = personCode;//个人编码
            param[1] = settled;//是否结算
            param[2] = "0.00";//账户支付额
            param[3] = invoiceCode;//发票号
            param[4] = qsfs;//清算方式
            param[5] = dbzbm;//单病种编码
            param[6] = ProgramGlobal.Username;//操作员
            param[7] = BillSysBase.currDate();//办理日期
            Zytsjs zyjs = new Zytsjs();
            string inXml = zyjs.Zytsjs_head() + zyjs.Zytsjs_in(param);
            string fy = "";
            DataTable items = getCostdet(ihsp_id, "Y");
            String[] param2 = new String[26];
            for (int i = 0; i < items.Rows.Count; i++)
            {
                param2[0] = items.Rows[i]["id"].ToString();//数据批号
                param2[1] = items.Rows[i]["insurcode"].ToString();//医保编码
                param2[2] = items.Rows[i]["name"].ToString();//项目名称
                param2[3] = items.Rows[i]["subject"].ToString();//发票归属科目编码
                param2[4] = items.Rows[i]["spec"].ToString();//规格
                param2[5] = "";// 剂型
                param2[6] = items.Rows[i]["unit"].ToString();//单位
                param2[7] = items.Rows[i]["prc"].ToString();//单价
                param2[8] = items.Rows[i]["num"].ToString();//数量
                param2[11] = items.Rows[i]["exedpt"].ToString();//受单科室
                param2[12] = items.Rows[i]["exedct"].ToString();//受单医生
                param2[13] = Convert.ToDateTime(items.Rows[i]["chargedate"]).ToString("yyyy-MM-dd HH:mm:ss");//开单时间
                param2[14] = "";//备注
                string charged = items.Rows[i]["charged"].ToString();
                if (charged == CostCharged.CHAR.ToString() || charged == CostCharged.RET.ToString())
                {
                    param2[15] = "0";// items.Rows[i]["0"].ToString();//冲销标志0正常1冲销
                }
                else if (charged == CostCharged.RREC.ToString())//冲销
                {
                    param2[15] = "1";// items.Rows[i]["1"].ToString();//冲销标志0正常1冲销
                }
                param2[16] = "";//用药途径
                param2[17] = "";//用药频次
                param2[18] = "";//单次用量
                param2[19] = "";//用药天数    
                param2[21] = items.Rows[i]["standcode"].ToString();// 院内收费项目编码
                param2[22] = "";//取药总量
                param2[23] = "";//取药总量单位
                param2[24] = "";//药量天数
                param2[25] = Convert.ToDateTime(items.Rows[i]["chargedate"]).ToString("yyyy-MM-dd HH:mm:ss");//执行时间
                //string dpt_id = items.Rows[i]["diagndep_id"].ToString();
                //string dct_id = items.Rows[i]["diagndoctor_id"].ToString();
                //DataTable dt = getDoctorInfo(dct_id, dpt_id);
                param2[9] = items.Rows[i]["diagndpt"].ToString();//开单科室
                param2[10] = items.Rows[i]["diagndct"].ToString();//开单医生

                param2[20] = items.Rows[i]["cardid"].ToString();//开药医师身份证号码
                fy += zyjs.Zytsjs_in2(param2);
            }
            inXml += fy;
            inXml += zyjs.Zytsjs_tail();
            String outXml = gysybface.Zytsjs(inXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            Zyjs_ret zyjs_ret_Entity = new Zyjs_ret();
            Dictionary<String, Zyjs_ret> dic = new Dictionary<string, Zyjs_ret>();
            SysWriteLogs.writeLogs1("贵阳市医保特殊结算", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
                message.Append(info);
                dic.Add("zyjs_ret", zyjs_ret_Entity);
                return dic;
            }
            zyjs_ret_Entity.Centercode = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码    
            zyjs_ret_Entity.Billno = ds.Tables["DATA"].Rows[0]["BILLNO"].ToString();//就诊顺序号
            zyjs_ret_Entity.Balanceid = ds.Tables["DATA"].Rows[0]["BALANCEID"].ToString();//结算编号
            zyjs_ret_Entity.Hospfeeall = ds.Tables["DATA"].Rows[0]["HOSPFEEALL"].ToString();//医院总费用
            zyjs_ret_Entity.Feeall = ds.Tables["DATA"].Rows[0]["FEEALL"].ToString();//医保总费用
            zyjs_ret_Entity.Calfeeall = ds.Tables["DATA"].Rows[0]["CALFEEALL"].ToString();//结算总费用
            zyjs_ret_Entity.Feeout = ds.Tables["DATA"].Rows[0]["FEEOUT"].ToString();//全自费
            zyjs_ret_Entity.Feeself = ds.Tables["DATA"].Rows[0]["FEESELF"].ToString();//挂钩自付
            zyjs_ret_Entity.Allowfund = ds.Tables["DATA"].Rows[0]["ALLOWFUND"].ToString();//允许报销
            zyjs_ret_Entity.Startfee = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
            zyjs_ret_Entity.Enterstartfee = ds.Tables["DATA"].Rows[0]["ENTERSTARTFEE"].ToString();//进入起付线
            zyjs_ret_Entity.Fund1pay = ds.Tables["DATA"].Rows[0]["FUND1PAY"].ToString();//基本统筹支付
            zyjs_ret_Entity.Fund1self = ds.Tables["DATA"].Rows[0]["FUND1SELF"].ToString();//基本统筹自付
            zyjs_ret_Entity.Fund2pay = ds.Tables["DATA"].Rows[0]["FUND2PAY"].ToString();//大额统筹支付
            zyjs_ret_Entity.Fund2self = ds.Tables["DATA"].Rows[0]["FUND2SELF"].ToString();//大额统筹自付
            zyjs_ret_Entity.Feeouer = ds.Tables["DATA"].Rows[0]["FEEOVER"].ToString();//超限额自付
            zyjs_ret_Entity.Acctpay = ds.Tables["DATA"].Rows[0]["ACCTPAY"].ToString();//个人账户支付
            zyjs_ret_Entity.Fund3pay = ds.Tables["DATA"].Rows[0]["FUND3PAY"].ToString();//医疗补助支付
            zyjs_ret_Entity.Acctbalance = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//个人账户余额
            zyjs_ret_Entity.Handledte = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            zyjs_ret_Entity.Speccalflag = ds.Tables["DATA"].Rows[0]["SPECCALFLAG"].ToString();//特殊结算标志
            zyjs_ret_Entity.Reckoningtype = ds.Tables["DATA"].Rows[0]["RECKONINGTYPE"].ToString();//清算方式
            zyjs_ret_Entity.Singleillnesscode = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSCODE"].ToString();//清算病种编码
            zyjs_ret_Entity.Singleillnessname = ds.Tables["DATA"].Rows[0]["SINGLEILLNESSNAME"].ToString();//病种名称
            //更新his数据
            dic.Add("zyjs_ret", zyjs_ret_Entity);
            return dic;
        }
        /// <summary>
        /// 出院登记数据回退
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="bllNo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Cydjsjht(string ihsp_id, string bllNo, StringBuilder message)
        {
            string[] param = new string[3];
            param[0] = bllNo;//就诊顺序号
            param[1] = ProgramGlobal.Username;//操作员
            param[2] = BillSysBase.currDate();//办理时间
            Cydjsjht cydjsjht = new Cydjsjht();
            String InXml = cydjsjht.Cydjsjht_head() + cydjsjht.Cydjsjht_in(param) + cydjsjht.Cydjsjht_tail();
            string outXml = gysybface.Cydjht(InXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            SysWriteLogs.writeLogs1("贵阳市医保出院登记数据回退", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            //更新医保出院状态为0
            string udp_sql = "update inhospital set insurouthsp = '0' where id = " + DataTool.addFieldBraces(ihsp_id);
            BllMain.Db.Update(udp_sql);
            return true;
        }
        /// <summary>
        /// 住院退票
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool zyTp(string ihsp_id, string bllNo, string settleNo, string payType, StringBuilder message)
        {
            string sql = "select insurouthsp,indate from inhospital where id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows[0]["insurouthsp"].ToString() == "1")
            {
                message.Append("该患者已出院，不能进行住院退票！");
                return false;
            }
            if (Convert.ToDateTime(dt.Rows[0]["indate"].ToString()).Month != Convert.ToDateTime(BillSysBase.currDate()).Month)
            {
                message.Append("不是当月数据，不能进行住院退票！");
            }
            string[] param = new string[5];
            param[0] = bllNo;//就诊顺序号
            param[1] = settleNo;//结算编号
            param[2] = payType;//支付类别
            param[3] = ProgramGlobal.Username;//操作员
            param[4] = BillSysBase.currDate();//办理时间
            Tp tp = new Tp();
            String InXml = tp.Tp_head() + tp.Tp_in(param) + tp.Tp_tail();
            String outXml = gysybface.ZyTp(InXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            SysWriteLogs.writeLogs1("贵阳市医保住院退票", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 离休退票
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool lxTp(string ihsp_id, string bllNo, string settleNo, string payType, StringBuilder message)
        {
            string sql = "select insurouthsp,indate from inhospital where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows[0]["insurouthsp"].ToString() == "1")
            {
                message.Append("该患者已出院，不能进行住院退票！");
                return false;
            }
            if (Convert.ToDateTime(dt.Rows[0]["indate"].ToString()).Month != Convert.ToDateTime(BillSysBase.currDate()).Month)
            {
                message.Append("不是当月数据，不能进行住院退票！");
            }
            String[] param = new String[5];
            param[0] = bllNo;//就诊顺序号
            param[1] = settleNo;//结算编号
            param[2] = payType;//支付类别
            param[3] = ProgramGlobal.Username;//操作员
            param[4] = BillSysBase.currDate();//办理时间
            Lxtp tp = new Lxtp();
            String InXml = tp.Lxtp_head() + tp.Lxtp_in(param) + tp.Lxtp_tail();
            String outXml = gysybface.ZyLxTp(InXml);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            SysWriteLogs.writeLogs1("贵阳市医保离休退票", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
                message.Append(info);
                return false;
            }
            return true;
        }
      

        /// <summary>
        /// 获取医保结算信息
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public DataTable getRefund(string invoice_id)
        {


            string sql = "select jzsxh"
                            + ",jsbm"
                            + ",zflb"
                            + ",bxlb"
                            + ",grbh"
                            + " from gysyb_mz"
                            + " where gysyb_mtmzblstuff_iid=" + DataTool.addIntBraces(invoice_id);
            return BllMain.Db.Select(sql).Tables[0];
        }


        /// <summary>
        /// 门诊退费
        /// </summary>
        /// <returns></returns>
        public bool refund(string clinic_invoice_id)
        {
            DataTable dt = getRefund(clinic_invoice_id);
            string jzsxh = dt.Rows[0]["jzsxh"].ToString();
            string jsbm = dt.Rows[0]["jsbm"].ToString();
            string zflb = dt.Rows[0]["zflb"].ToString();
            string bxlb = dt.Rows[0]["bxlb"].ToString();
            string grbh = dt.Rows[0]["grbh"].ToString();
            String[] param = new String[5];
            param[0] = jzsxh;//就诊顺序号
            param[1] = jsbm;//结算编号
            param[2] = zflb;//支付类别
            param[3] = ProgramGlobal.Username;//操作员
            param[4] = BillSysBase.currDate();//办理时间
            Tp tp = new Tp();
            String InXml = tp.Tp_head() + tp.Tp_in(param) + tp.Tp_tail();
            String outXml = "";
            if (bxlb.Equals("2"))//离休退票
            {
                outXml = gysybface.Lxmztp(InXml);
            }
            else//普通退票
            {
                outXml = gysybface.Ptmztp(InXml);
            }
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            SysWriteLogs.writeLogs1("贵阳市医保门诊退费", Convert.ToDateTime(BillSysBase.currDate()), outXml + info);
            if (!flag.Equals("0"))
            {
                MessageBox.Show("撤销失败，请稍后重试");
                return false;
            }
            string sql = "update gysyb_mz set tfr='" + ProgramGlobal.Username + "',tfsj='" + BillSysBase.currDate() + "' where gysyb_mtmzblstuff_iid='" + clinic_invoice_id + "'";
            BllMain.Db.Update(sql);
            MessageBox.Show("费用撤销成功");
            return true;
        }
        

        /// <summary>
        /// 更新医保状态为已结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public string accountInsurStat(string ihsp_id)
        {
            string sql = " update inhospital set insurstat= 'SETT' where id=" + DataTool.addFieldBraces(ihsp_id);
            return sql;

        }
        /// <summary>
        /// 撤销医保结算状态
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int cancelAccountInsurStat(string ihsp_id)
        {
            string sql = " update inhospital set insurstat= 'REG' where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);

        }


        public DataTable getAccIhspInfo(string id)
        {
            string sql = "select inhospital.ihspcode"
                            + ",inhospital.name as ihspname"
                            + ",bas_depart.name as deparname"
                            + ",inhospital.indate"
                            + ",inhospital.outdate"
                            + ",inhospital.member_id"
                            + ",inhospital.bas_patienttype_id"
                            + ",inhospital.status"
                            + ",insur_gysyb_zy.insuretype"
                            + ",ihsp_info.idcard"
                            + ",ihsp_info.homephone"

                            + " from inhospital "
                            + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                            + " left join insur_gysyb_zy on insur_gysyb_zy.mtzyjliid=inhospital.id "
                            + " left join ihsp_info on ihsp_info.ihsp_id=inhospital.id and registkind='IHSP'"
                            + " where inhospital.id = " + DataTool.addFieldBraces(id)
                            ;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// dgvIhspcost查询
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <returns></returns>
        public DataTable costSearch(string ihsp_id)
        {
            DataTable dt = new DataTable();
            string sql = "select cost_itemtype.name as itemtypename "
                      + ",ihsp_costdet.name"
                      + ",ihsp_costdet.spec"
                      + ",ihsp_costdet.realfee"
                      + ",ihsp_costdet.num"
                      + ",ihsp_costdet.prc"
                      + ",ihsp_costdet.id"
                      + " from ihsp_costdet "
                      + " left join cost_itemtype on cost_itemtype.id=ihsp_costdet.itemtype_id "
                      + " where 1=1 and settled='N' and charged in ('RREC','RET','CHAR')"
                      + " and  ihsp_costdet.neonate_id =0  "
                      + " and  ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
    }
}
