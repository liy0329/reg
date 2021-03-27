using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTREG.common;
using MTHIS.common;
using MTREG.medinsur.gysyb.bo;
using MTREG.medinsur.gzsyb.bo;
using MTREG.medinsur.gzsyb.bll;
using System.IO;
using System.Windows.Forms;
using MTREG.common.bll;
using MTREG.ihsp.bll;
using MTHIS.tools;

using MTREG.ihsp.bo;
using MTREG.netpay.bo;

namespace MTREG.medinsur.gzsyb.ihsp.bll
{
    class BllInsurIhspGZS
    {
        GzsybInterface gzsybInterface = new GzsybInterface();
        BillIhspAct bllIhspAct = new BillIhspAct();
        BillIhspMan billIhspMan = new BillIhspMan();
        /// <summary>
        /// 获取门诊疾病
        /// </summary>
        /// <returns></returns>
        public DataTable getDisease(string pincode)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select id,name,illcode  from cost_insurillness where pincode like '%" + pincode.Trim() + "%' and cost_insurtype_id = (SELECT id from cost_insurtype where keyname = "
                    + DataTool.addFieldBraces(CostInsurtypeKeyname.GZSYB.ToString()) + ")";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
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

        /// <summary>
        /// 获取患者类型
        /// </summary>
        /// <returns></returns>
        public DataTable getPatientType()
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select id,name from bas_patienttype";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// 插入住院医保信息表
        /// </summary>
        /// <param name="registinfo"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int ihspInsurInfo(string registinfo, string ihsp_id)
        {
            //支付类别|个人编号|姓名|性别|医疗照顾人员类别|执行社会保险办法|出生日期|单位编码|居民医疗人员类别|分中心编码
            //参保状态|医疗人员类别|身份证号|所属社保机构编码(使用分中心编码代码)|驻外标志|实足年龄|单位名称|居民医疗人员身份|个人账户余额|当前住院状态|读卡成功标志
            //受委托人姓名|与受委托人关系|受委托人身份证号|受委托人性别|疾病诊断|疾病ICD编码|精神病人住院标识
            //string[] message = registinfo.Split('|');
            //string strXml="<info>"
            //            + "<Zflb>" + message[0] + "</Zflb>"
            //            + "<Swgrbh>" + message[1] + "</Swgrbh>"
            //            + "<Swxm>" + message[2] + "</Swxm>"
            //            + "<Swxb>" + message[3] + "</Swxb>"
            //            + "<Swylzgrylb>" + message[4] + "</Swylzgrylb>"
            //            + "<Swzxshbxbf>" + message[5] + "</Swzxshbxbf>"
            //            + "<Swcsrq>" + message[6] + "</Swcsrq>"
            //            + "<Swdwbm>" + message[7] + "</Swdwbm>"
            //            + "<Swjmlrylb>" + message[8] + "</Swjmlrylb>"
            //            + "<Swfzxbm>" + message[9] + "</Swfzxbm>"
            //            + "<Swzbzt>" + message[10] + "</Swzbzt>"
            //            + "<Swylrylb>" + message[11] + "</Swylrylb>"
            //            + "<Swsfzh>" + message[12] + "</Swsfzh>"
            //            + "<Sssbjgbm>" + message[13] + "</Sssbjgbm>"
            //            + "<Swzwbz>" + message[14] + "</Swzwbz>"
            //            + "<Swsznl>" + message[15] + "</Swsznl>"
            //            + "<Swdwmc>" + message[16] + "</Swdwmc>"
            //            + "<Swjmylrysf>" + message[17] + "</Swjmylrysf>"
            //            + "<Swgrzhye>" + message[18] + "</Swgrzhye>"
            //            + "<Swdqzyzt>" + message[19] + "</Swdqzyzt>"
            //            + "<Flag>" + message[20] + "</Flag>"
            //            + "<Swtrxm>" + message[21] + "</Swtrxm>"
            //            + "<Swtrgx>" + message[22] + "</Swtrgx>"
            //            + "<Swtrsfzh>" + message[23] + "</Swtrsfzh>"
            //            + "<Swtrxb>" + message[24] + "</Swtrxb>"
            //            + "<Qjryzd>" + message[25] + "</Qjryzd>"
            //            + "<Qjicd>" + message[26] + "</Qjicd>"
            //            + "<Qjsjbzyxbrbs>" + message[27] + "</Qjsjbzyxbrbs>"
            //            +"</info>";
            string ihsp_insurinfo_id = BillSysBase.nextId("ihsp_insurinfo");
            string sql = "insert into ihsp_insurinfo (id,ihsp_id,registinfo,opstat)values(" 
                + DataTool.addFieldBraces(ihsp_insurinfo_id)
                + "," + DataTool.addFieldBraces(ihsp_id)
                + "," + DataTool.addFieldBraces(registinfo)
                + "," + DataTool.addFieldBraces(Insurinfostate.OO.ToString())
                +")";           
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 异地医保入院登记成功时记录返回信息
        /// </summary>
        /// <param name="mtzyjl_iid">住院记录id</param>
        /// <param name="wdrydj"></param>
        /// <returns></returns>
        public bool Rydj_New(string mtzyjl_iid, WdybRydj wdrydj)
        {
            string sql = "";
            sql = "select mtzyjliid from insur_gzsyb_ryinfo where mtzyjliid=" + mtzyjl_iid;
            DataSet ds = BllMain.Db.Select(sql);
            if (ds.Tables.Count <= 0)
            {
                return false;
            }
            string sqlUpdate = "";
            if (ds.Tables[0].Rows.Count > 0)
            {

                sqlUpdate = "update insur_gzsyb_ryinfo set akc190 ='" + wdrydj.Akc190 + "',"
                     + " yab003='" + wdrydj.Yab003 + "',aka130='" + wdrydj.Aka130 + "',"
                     + " aac001='" + wdrydj.Aac001 + "',aac003='" + wdrydj.Aac003 + "',"
                     + " aac004='" + wdrydj.Aac004 + "',"
                     + " aac002='" + wdrydj.Aac002 + "',"
                     + " aab001='" + wdrydj.Aab001 + "',"
                     + " aab004='" + wdrydj.Aab004 + "',"
                     + " akc021='" + wdrydj.Akc021 + "',"
                     + " akc023='" + wdrydj.Akc023 + "',"
                     + "akc087='" + wdrydj.Ack087 + "',"
                     + " ykb065='" + wdrydj.Ykb065 + "',"
                     + " yke120='" + wdrydj.Ryzdcode + "',"
                     + " ykc014='" + wdrydj.Ryjbsj + "',"
                     + " rylbname='" + wdrydj.RylbName + "',"
                     + " aae013='" + wdrydj.Bz
                     + "' where mtzyjliid='" + mtzyjl_iid + "'";

            }
            else
            {
                sqlUpdate = " insert into insur_gzsyb_ryinfo(mtzyjliid, akc190, yab003, aka130,"
                       + " aac001, aac003, aac004, aac002,"
                       + "  aab001, aab004, akc021,"
                       + " akc023,akc087, ykb065,yke120,ykc014,rylbname,aae013) values('"
                       + mtzyjl_iid + "','" + wdrydj.Akc190 + "','" + wdrydj.Yab003 + "','" + wdrydj.Aka130 + "','"
                       + wdrydj.Aac001 + "','" + wdrydj.Aac003 + "','" + wdrydj.Aac004 + "','" + wdrydj.Aac002 + "','"
                       + wdrydj.Aab001 + "','" + wdrydj.Aab004 + "','" + wdrydj.Akc021 + "','"
                       + wdrydj.Akc023 + "','" + wdrydj.Ack087 + "','" + wdrydj.Ykb065 + "','" + wdrydj.Ryzdcode + "','" + wdrydj.Ryjbsj + "','" + wdrydj.RylbName + "','" + wdrydj.Bz + "')";
            }
            if (BllMain.Db.Update(sqlUpdate) == -1)
            {
                SysWriteLogs sysWriteLog = new SysWriteLogs();
                sysWriteLog.writeLogs("入院办理 错误信息", DateTime.Now, sqlUpdate);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 转医保时更新省医保入院信息
        /// </summary>
        /// <param name="ihsp_id">住院记录id</param>
        /// <param name="patienttype"></param>
        /// <param name="csrq">生日</param>
        /// <param name="sfzhm">身份证</param>
        /// <param name="dwmc">单位名称</param>
        /// <param name="insurcode">个人编号</param>
        /// <returns></returns>
        /// 

      
        public int upGzsybRyInfo(string ihsp_id, string patienttype, PersonInfo personInfo)
        {

            string insurtype = personInfo.Swfzxbm;
           string bas_patienttype1_id = "16";
            if (insurtype == "9900" || insurtype == "9907")
            {

                bas_patienttype1_id = "29";
            }
            else if (insurtype == "9908")
            {

                bas_patienttype1_id = "30";
            }

            string sql = "update inhospital set bas_patienttype_id=" + DataTool.addFieldBraces(patienttype)
                + ",insurstat='REG',insuritemtype='3'"
                + ",insurcode=" + DataTool.addFieldBraces(personInfo.Swgrbh)
                 + ",bas_patienttype1_id=" + DataTool.addFieldBraces(bas_patienttype1_id)
                + ",birthday=" + DataTool.addFieldBraces( personInfo.Swcsrq)
                + " where id=" + DataTool.addFieldBraces(ihsp_id) + ";";
            sql += "update ihsp_info set companyname=" + DataTool.addFieldBraces(personInfo.Swdwmc)
                + ",idcard=" + DataTool.addFieldBraces(personInfo.Swsfzh)
                + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id)
                + ";";

            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 贵州省医保入院登记
        /// </summary>
        /// <param name="personInfo"></param>
        /// <param name="ihspcode"></param>
        /// <param name="indate"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool rydj(PersonInfo personInfo, string ihspcode, string indate, string ihsp_id, out string errInfo)
        {
            errInfo = "";
            String[] param = new String[15];
            param[0] = ihspcode;//住院号
            param[1] = personInfo.Swgrbh;//个人编号
            param[2] = indate;//入院日期
            param[3] = personInfo.Qjryzd;//入院诊断(可空)
            param[4] = personInfo.Qjicd;//ICD10代码
            param[5] = "";//入院床位(可空)
            param[6] = "";//入院科室 科室为中文，不能为编码(可空)
            param[7] = ProgramGlobal.User_id;//入院经办人编码(可空)
            param[8] = ProgramGlobal.Username;//入院经办人姓名(可空)
            param[9] = BillSysBase.currDate();//入院经办时间(可空)
            param[10] ="" ;//病历号(可空)
            param[11] = "";//备注(可空)
            param[12] = "MTHIS";//HIS厂商编号  由银海公司提供
            param[13] = personInfo.Qjsjbzyxbrbs;//精神病住院新人标识
            param[14] = personInfo.Swzxshbxbf;//执行社会保险办法
            InHospitalHandle ihh = new InHospitalHandle();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "21";//交易编号
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);//交易输入
            Call_out callOut = gzsybInterface.Call(callIn);       
            if (callOut.Aintappcode < 0)
            {
                errInfo = callOut.Astrappms;
                return false;
            }
            //交易成功
            string xml = callOut.Astrjyscxml;
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string akc190 = ds.Tables["output"].Rows[0]["prm_akc190"].ToString();
            string yab003 = ds.Tables["output"].Rows[0]["prm_yab003"].ToString();
            string aka130 = ds.Tables["output"].Rows[0]["prm_aka130"].ToString();
            string aac001 = ds.Tables["output"].Rows[0]["prm_aac001"].ToString();
            string aac003 = ds.Tables["output"].Rows[0]["prm_aac003"].ToString();
            string aac004 = ds.Tables["output"].Rows[0]["prm_aac004"].ToString();
            string aac002 = ds.Tables["output"].Rows[0]["prm_aac002"].ToString();
            string aab001 = ds.Tables["output"].Rows[0]["prm_aab001"].ToString();
            string aab004 = ds.Tables["output"].Rows[0]["prm_aab004"].ToString();
            string akc021 = ds.Tables["output"].Rows[0]["prm_akc021"].ToString();
            string akc023 = ds.Tables["output"].Rows[0]["prm_akc023"].ToString();
            string ykb065 = ds.Tables["output"].Rows[0]["prm_ykb065"].ToString();
            

            WdybRydj wdrydj = new WdybRydj();
            wdrydj.Akc190 = akc190;
            wdrydj.Yab003 = yab003;
            wdrydj.Aka130 = aka130;
            wdrydj.Aac001 = aac001;
            wdrydj.Aac003 = aac003;
            wdrydj.Aac004 = aac004;
            wdrydj.Aac002 = aac002;
            wdrydj.Aab001 = aab001;
            wdrydj.Aab004 = aab004;
            wdrydj.Akc021 = akc021;
            wdrydj.Akc023 = akc023;
            wdrydj.Ykb065 = ykb065;
            wdrydj.Ryzdcode = personInfo.Qjicd;
            wdrydj.Ryjbsj = indate;
            wdrydj.RylbName = personInfo.Swylrylbmc;
            wdrydj.Ack087 = personInfo.Swgrzhye;
            //判断更改入院状态是否成功
            if (!Rydj_New(ihsp_id, wdrydj))
            {
                Cancel_in cancelIn = new Cancel_in();
                cancelIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
                Cancel_out cancelOut = gzsybInterface.Cancel(cancelIn);

                if (cancelOut.AintAppcode < 0)
                {
                    errInfo = cancelOut.AstrAppmsg;
                }
                errInfo = "异地医保入院办理失败！";
                return false;
            }
            else
            {
                Confirm_in confirmIn = new Confirm_in();
                confirmIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
                confirmIn.Astrjyyzm = callOut.Astrjyyzm;//交易验证码
                Confirm_out confirmOut = gzsybInterface.Confirm(confirmIn);
                if (confirmOut.AintAppcode < 0)
                {
                    errInfo = confirmOut.AstrAppmsg;
                    return false;
                }
            }
            
            return true;
        }
        /// <summary>
        /// 入院回退
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool retIhspReg(string ihsp_id)
        {
            string insurouthsp = getInsurouthsp(ihsp_id);
            if (insurouthsp == "1")
            {
                MessageBox.Show("已经出院办理，不能进行入院办理回退！", "提示消息");
                return false;
            }

            string sql1 = "select akc190,aac001,yab003,ykb065,aka130 from insur_gzsyb_ryinfo where  mtzyjliid=" + ihsp_id;
            DataTable dt = BllMain.Db.Select(sql1).Tables[0];

            if (dt.Rows.Count <= 0)
            {
                return false;
            }
            String[] param = new String[5];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号"GZ131127100025638646";//
            param[1] = dt.Rows[0]["aac001"].ToString();//个人编号"1000228902";//
            param[2] = dt.Rows[0]["aka130"].ToString();//支付类别"31";// 
            param[3] = dt.Rows[0]["yab003"].ToString();//分中心编号"2702";//
            param[4] = dt.Rows[0]["ykb065"].ToString();//社会保险办法"2";//
           InHospitalHandleBack ihhk = new InHospitalHandleBack();
            //调用交易函数
           Call_in callIn = new Call_in();
           callIn.AstrJybh = "22";//交易编号
           callIn.Astr_jysr_xml = ihhk.xmlCode_head() + ihhk.xmlCode_in(param);//交易输入
           Call_out callOut = gzsybInterface.Call(callIn);
           if (callOut.Aintappcode < 0)
           {
               MessageBox.Show(callOut.Astrappms,"错误信息");
               return false;
           }

           string sql_upd = "update inhospital set insurstat='OO', bas_patienttype_id= '1', bas_patienttype1_id= '1',Insuritemtype='1'  where id=" + DataTool.addFieldBraces(ihsp_id);
           int ops = BllMain.Db.Update(sql_upd);
           if (ops == 0)
           {
               Confirm_in confirmIn = new Confirm_in();
               confirmIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
               confirmIn.Astrjyyzm = callOut.Astrjyyzm;//交易验证码
               Confirm_out confirmOut = gzsybInterface.Confirm(confirmIn);
               if (confirmOut.AintAppcode < 0)
               {
                   MessageBox.Show(confirmOut.AstrAppmsg,"错误信息");
                   return false; ;
               }
           }
           else
           {
               MessageBox.Show("数据库错误","错误信息");
               Cancel_in cancelIn = new Cancel_in();
               cancelIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
               Cancel_out cancelOut = gzsybInterface.Cancel(cancelIn);
               if (cancelOut.AintAppcode < 0)
               {
                   MessageBox.Show(cancelOut.AstrAppmsg,"错误信息");
               }
               MessageBox.Show("入院办理回退失败！","提示消息");
               return false;
           }
           return true;
        }
        /// <summary>
        /// 入院登记修改(23)
        /// </summary>
        public bool alterIhspRegInfo(string ihsp_id)
        {
            return true;
        }
       
        /// <summary>
        /// 住院费用明细导入
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool costdetTransferSub(string ihsp_id, ref string returnMsg)
        {
            returnMsg = "";
            string noCross = "";
            string sql1 = "select akc190,aka130,yab003,aac001,ykb065,aac001 from insur_gzsyb_ryinfo where  mtzyjliid=" + ihsp_id;
            DataTable dt = BllMain.Db.Select(sql1).Tables[0];
         
            //就诊编号|分中心编号|支付类别|个人编号|姓名|性别|身份证号|单位编码|单位名称|人员状态|实足年龄|社会保险办法
            String[] param = new String[6];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["aac001"].ToString();//个人编号
            param[2] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[3] = dt.Rows[0]["aka130"].ToString();//支付类别
            param[4] = dt.Rows[0]["ykb065"].ToString();//执行的社保办法
       
            FeeWriteIn fwi = new FeeWriteIn();
            while (true)
            {
                string currDateTime = BillSysBase.currDate();
                string code_body = "";

                string sql_costs = " select "
                                 + "  ihsp_costdet.id"
                                 + " ,ihsp_costdet.standcode"
                                 + " ,ihsp_costdet.item_id"
                                 + " ,ihsp_costdet.itemfrom"
                                 + " ,ihsp_costdet.name"
                                 + " ,ihsp_costdet.spec"
                                 + ", sys_dict.name as dosageform"
                                 + " ,ihsp_costdet.unit"
                                 + " ,ihsp_costdet.num"
                                 + " ,ihsp_costdet.prc"
                                 + " ,ihsp_costdet.realfee"
                                 + " ,ihsp_costdet.diagndep_id"
                                 + " ,bas_depart.name as dptname"
                                 + " ,bas_doctor.name as dctname"
                                 + " ,bas_doctor.practicecode"
                                 + " ,exedep.name as exedepname"
                                 + " ,exedoctor.name  as exedoctorname"
                                 + " ,charger.name as chargername"
                                 + " ,cost_insurcross.insurcode"
                                 + " ,cost_insurcross.insurname"
                                 + " from ihsp_costdet "
                                 + "  left join bas_depart on ihsp_costdet.diagndep_id = bas_depart.id "
                                 + "  left join bas_doctor on ihsp_costdet.diagndoctor_id = bas_doctor.id"
                                 + "  left join bas_depart  exedep on ihsp_costdet.exedep_id = exedep.id "
                                 + "  left join bas_doctor  exedoctor on ihsp_costdet.exedoctor_id = exedoctor.id"
                                 + "  left join bas_doctor  charger  on ihsp_costdet.charger_id = charger.id"
                                  + " left join sys_dict on bas_item.dosageform_id=sys_dict.sn and sys_dict.dicttype='drug_dosageform' and father<>0"
                                 + "  left join bas_doctor  charger  on ihsp_costdet.charger_id = charger.id"
                                 + " left join cost_insurcross on cost_insurcross.insuritemtype ='3' and cost_insurcross.item_id = ihsp_costdet.item_id"
                                 + "  where ihsp_costdet.ihsp_id =  " + DataTool.addFieldBraces(ihsp_id)
                                 + "  and ihsp_costdet.insursync = 'N' and ihsp_costdet.charged in ('RET','CHAR') limit 20";
                 DataTable dt_xmcx;
                try
                {
                    dt_xmcx = BllMain.Db.Select(sql_costs).Tables[0];
                }
                catch (Exception e)
                {
                    return false; 
                }
                if (dt_xmcx.Rows.Count == 0)
                {
                    return true;
                }
                DataTable dt_insur = new DataTable();
                DataTable dt_rcpexedet = new DataTable();
                string costdetids = "";
                for (int j = 0; j < dt_xmcx.Rows.Count; j++)
                {
                    String[] fee_param = new String[27];
                    fee_param[0] = dt_xmcx.Rows[j]["id"].ToString();//yka105>";//记账流水号
                    fee_param[1] = dt_xmcx.Rows[j]["item_id"].ToString();// ykd125 医院项目流水号(可空)
                    //<商品名代码>商品名代码</商品名代码>/*考虑增加*/
                    fee_param[2] = dt_xmcx.Rows[j]["name"].ToString();//ykd126 医院项目名称(可空)
                    fee_param[3] = dt_xmcx.Rows[j]["insurcode"].ToString();//yka002 医保通用项目编码
                    if (fee_param[2].Equals(""))
                    {
                        noCross = "[编码:" + dt_xmcx.Rows[j]["item_id"].ToString() + ",名称:" + dt_xmcx.Rows[j]["name"].ToString() + "]";
                        fee_param[2] = "NCL99999999";  //自费
                    }
                    fee_param[4] = dt_xmcx.Rows[j]["insurname"].ToString();//yka003 医保通用项目名称(可空)
                    fee_param[5] = dt_xmcx.Rows[j]["num"].ToString();//akc226 数量
                    fee_param[6] = dt_xmcx.Rows[j]["prc"].ToString();//akc225 实际价格
                    fee_param[7] = dt_xmcx.Rows[j]["realfee"].ToString();//yka315 明细项目费用总额
                    fee_param[8] = "";//yka097 开单科室编码(可空)
                    fee_param[9] = dt_xmcx.Rows[j]["dptname"].ToString();//yka098 开单科室名称(可空)
                    fee_param[10] = "";//ykd102 开单医生医师资格证号(可空)
                    fee_param[11] = dt_xmcx.Rows[j]["dctname"].ToString();//yka099 开单医生姓名(可空)
                    fee_param[12] = "";//yka100 受单科室编码(可空)
                    fee_param[13] = dt_xmcx.Rows[j]["exedepname"].ToString();//yka101 受单科室名称(可空)
                    fee_param[14] = "";//ykd106 受单医生编码(可空)
                    fee_param[15] = dt_xmcx.Rows[j]["dptname"].ToString();//yka102 受单医生姓名(可空)
                    fee_param[16] = dt_xmcx.Rows[j]["chargedate"].ToString();//yke123 明细发生时间
                    fee_param[17] = dt_xmcx.Rows[j]["chargername"].ToString();//ykc141 经办人姓名
                    fee_param[18] = BillSysBase.currDate();//aae036 经办时间(可空)
                    fee_param[19] = "";// dt.Rows[0]["aae013"].ToString();//aae013 备注(可空)
                    fee_param[20] = "";//yke201 中药使用方式(可空)
                    fee_param[21] = dt_xmcx.Rows[j]["unit"].ToString();//yka295 最小计价单位(可空)
                    fee_param[22] = dt_xmcx.Rows[j]["spec"].ToString();//aka074 规格(可空)
                    fee_param[23] = "";// t_xmcx.Rows[j]["jx"].ToString();//aka070 剂型(可空)
                    fee_param[24] = dt_xmcx.Rows[j]["dosageform"].ToString();//yae374 剂型名称(可空)
                    fee_param[25] = "";// yke009 是否医院制剂(可空)
                    fee_param[26] = "1";// yke186 医院审批标志(可空)暂未使用,默认传入值：1            
                    code_body += fwi.xml_code_body(fee_param);
                    costdetids += dt_xmcx.Rows[j]["id"].ToString() + ",";
                }
                costdetids = costdetids.Substring(0, costdetids.Length - 1);
                //调用交易函数
                Call_in callIn = new Call_in();
                callIn.AstrJybh = "31";
                callIn.Astr_jysr_xml = fwi.xmlCode_head() + fwi.xmlCode_in(param) + code_body + fwi.xml_Code_end();//交易输入xml
                Call_out callOut = gzsybInterface.Call(callIn);
                if (callOut.Aintappcode < 0)
                {
                    returnMsg += callOut.Astrappms;
                    return false;
                }
                else
                {
                    string sql_upd = "update ihsp_costdet set insursync = 'Y' where id in (" + costdetids + ")";
                    int flg = BllMain.Db.Update(sql_upd);
                    if (flg.Equals(-1))
                    {
                        returnMsg += "更新状态失败:(" + costdetids + ")";
                        return false;
                    }
                }

                //交易成功
                string xml = callOut.Astrjyscxml;
                StringReader sr = new StringReader(xml);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                for (int i = 0; i < ds.Tables["Row"].Rows.Count; i++)
                {
                    string akc190 = ds.Tables["row"].Rows[i]["akc190"].ToString();//就诊编码
                    string yka105 = ds.Tables["row"].Rows[i]["yka105"].ToString();//记账流水号
                    string yka317 = ds.Tables["row"].Rows[i]["yka317"].ToString();//明细项目全自费金额_YKA317
                    string yka318 = ds.Tables["row"].Rows[i]["yka318"].ToString();//明细项目挂钩自付金额_YKA318
                    string yka319 = ds.Tables["row"].Rows[i]["yka319"].ToString();//明细项目符合范围金额_YKA319
                    int pdbs = int.Parse(ds.Tables["row"].Rows[i]["code"].ToString());
                    string astrappms = ds.Tables["row"].Rows[i]["message"].ToString();
                    if (pdbs < 0)
                    {
                        returnMsg += astrappms;
                        return false;
                    }
                    string sql_updd = "update ihsp_costdet set insurefee = " + DataTool.addFieldBraces(yka319) + ", selffee=" + DataTool.addFieldBraces(yka318) + ",insursync = 'Y' where id = " + DataTool.addFieldBraces(yka105);
                    if (BllMain.Db.Update(sql_updd) == -1)
                    {
                        return false;
                    }
                }
                if (noCross.Length > 0)
                    returnMsg += noCross;
            }
           
        }
        /// <summary>
        /// 费用批量删除(删除所有未结算明细)
        /// </summary>
        /// <returns></returns>
        public bool deleteIhspcostItem(string ihsp_id)
        {
            string sql = "select registinfo from ihsp_insurinfo where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("读取医保信息失败！");
                return false;
            }
            string sql_stat = "select insurstat from inhospital where id = " + DataTool.addFieldBraces(ihsp_id);
            if (BllMain.Db.Select(sql_stat).Tables[0].Rows[0]["insurstat"].ToString() == Insurstat.SETT.ToString())
            {
                MessageBox.Show("该记录已结算需先退结算！");
                return false;
            }
            //就诊编号|分中心编号|支付类别|个人编号|姓名|性别|身份证号|单位编码|单位名称|人员状态|实足年龄|社会保险办法
            string[] info = dt.Rows[0]["registinfo"].ToString().Split('|');
            //string sql_reg = "";
            String[] param = new String[5];
            param[0] = info[0];//就诊编号
            param[1] = info[2];//支付类别
            param[2] = info[1];//分中心编号
            param[4] = info[11];//社会保险办法
            BatchFeeDel ohhk = new BatchFeeDel();//批量删除明细
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "33";//交易编号
            callIn.Astr_jysr_xml = ohhk.xmlCode_head() + ohhk.xmlCode_in(param);//交易输入xml
            Call_out callOut = gzsybInterface.Call(callIn);
            if(callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms,"错误信息");
                return false;
            }
            string sql_upd = "update ihsp_costdet set insursync = 'N' where ihsp_id = " + DataTool.addFieldBraces(ihsp_id) +" and insursync = 'Y'";
            BllMain.Db.Update(sql_upd);
            return true;
        }
        /// <summary>
        /// 预结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        /*public bool preSettle(string ihsp_id, string total, string registedInfo, out  string midsettInfo)
        {
            

            string sql1 = "select akc190,aka130,yab003,aac001,ykb065,aac001 from gzsyb_ryinfo where  mtzyjliid=" + ihsp_id;
            DataTable dt = BllMain.Db.Select(sql1).Tables[0];

            total = bllIhspAct.getHisCostDetSum(ihsp_id); ;
            //就诊编号|分中心编号|支付类别|个人编号|姓名|性别|身份证号|单位编码|单位名称|人员状态|实足年龄|社会保险办法
            String[] param = new String[6];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["aac001"].ToString();//个人编号
            param[2] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[3] = dt.Rows[0]["aka130"].ToString();//支付类别
            param[4] = dt.Rows[0]["ykb065"].ToString();//执行的社保办法
            param[5] = Math.Round(Convert.ToDouble(total),2).ToString();//HIS费用总额
            HisSimulateSettle ihh = new HisSimulateSettle();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "43";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms,"错误信息");
                return false;
            }         
            //交易成功
            string xml = callOut.Astrjyscxml;
            //写xml日志到文件_wzw
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string aac001 = ds.Tables["output"].Rows[0]["prm_aac001"].ToString();//个人编号
            string aae036 = ds.Tables["output"].Rows[0]["prm_aae036"].ToString();//经办时间
            string yka055 = ds.Tables["output"].Rows[0]["prm_yka055"].ToString();//总费用
            string yka056 = ds.Tables["output"].Rows[0]["prm_yka056"].ToString();//全自费部分
            string yka057 = ds.Tables["output"].Rows[0]["prm_yka057"].ToString();//先行自付
            string yka111 = ds.Tables["output"].Rows[0]["prm_yka111"].ToString();//符合范围
            string yka058 = ds.Tables["output"].Rows[0]["prm_yka058"].ToString();//本次起伏线
            string yka248 = ds.Tables["output"].Rows[0]["prm_yka248"].ToString();//基本医疗统筹支付金额
            string yka062 = ds.Tables["output"].Rows[0]["prm_yka062"].ToString();//大额医疗支付金额
            string yke030 = ds.Tables["output"].Rows[0]["prm_yke030"].ToString();//公务员补助报销金额
            string ykb037 = ds.Tables["output"].Rows[0]["prm_ykb037"].ToString();//清算分中心
            string yka316 = ds.Tables["output"].Rows[0]["prm_yka316"].ToString();//清算类别
            string yka054 = ds.Tables["output"].Rows[0]["prm_yka054"].ToString();//清算方式
            string yae366 = ds.Tables["output"].Rows[0]["prm_yae366"].ToString();//清算期号
            //string zhyjj = ds.Tables["output"].Rows[0]["prm_zhyjj"].ToString();//
            string zhkzf = ds.Tables["output"].Rows[0]["prm_zhkzf"].ToString();//账户可支付金额
            //个人编号|经办时间|总费用|全自费部分|先行自付|符合范围|本次起伏线|基本医疗统筹支付金额|大额医疗支付金额|公务员补助报销金额|清算分中心|清算类别|清算方式|清算期号
            preSettled = aac001 + "|" + aae036 + "|" + yka055 + "|" + yka056 + "|" + yka057 + "|" + yka111 + "|" + yka058 + "|" + yka248 + "|" + yka062 + "|" + yke030
                + "|" + ykb037 + "|" + yka316 + "|" + yka054 + "|" + yae366;
            string sql_upds = "update ihsp_insurinfo set presettleinfo = " + DataTool.addFieldBraces(personInfo)
                + ",midsettinfo = " + DataTool.addFieldBraces(preSettled) + " where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            BllMain.Db.Update(sql_upds);
            return true;
        } */                                             
        /// <summary>
        /// 住院结算
        /// </summary>
        /// <param name="ihsp_id"></param>住院id
        /// <param name="personInfo"></param>个人医保信息
        /// <param name="total"></param>总费用
        /// <param name="invoiceCode"></param>发票号
        /// <param name="prepamt"></param>总预交款
        /// <param name="message"></param>返回错误信息
        /// <returns></returns>
        public bool settle(string ihsp_id,string personInfo,string total,string invoiceCode,string prepamt, StringBuilder message)
        {
            DataTable dtInfo = getBillCode(ihsp_id);
            string[] info = dtInfo.Rows[0]["registInfo"].ToString().Split('|');
            //支付类别|个人编号|姓名|性别|医疗照顾人员类别|执行社会保险办法|出生日期|单位编码|居民医疗人员类别|分中心编码
            //参保状态|医疗人员类别|身份证号|所属社保机构编码(使用分中心编码代码)|驻外标志|实足年龄|单位名称|居民医疗人员身份|个人账户余额|当前住院状态|读卡成功标志
            //受委托人姓名|与受委托人关系|受委托人身份证号|受委托人性别|疾病诊断|疾病ICD编码|精神病人住院标识
            string[] personInfos = personInfo.Split('|');
            String[] param = new String[10];
            param[0] = info[0];//就诊编号
            param[1] = personInfos[9];//分中心编号
            param[2] = info[2];//支付类别
            param[3] = personInfos[5];//社会保险办法
            param[4] = Math.Round(Convert.ToDouble(total),2).ToString();//HIS费用总额
            param[5] = invoiceCode;//发票号
            param[6] = "";//备注
            param[7] = ProgramGlobal.User_id;//经办人
            param[8] = ProgramGlobal.Username;//经办人姓名
            param[9] = personInfos[1];//个人编号
            FeeSettle ihh = new FeeSettle();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "41";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
            Call_out callOut = gzsybInterface.Call(callIn) ;
            if(callOut.Aintappcode < 0)
            {
                message.Append(callOut.Astrappms);
                return false;
            }
         
            //交易成功
            string xml = callOut.Astrjyscxml;
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string yka103 = ds.Tables["output"].Rows[0]["prm_yka103"].ToString();//结算编号
            string aac001 = ds.Tables["output"].Rows[0]["prm_aac001"].ToString();//个人编号
            string yka065 = ds.Tables["output"].Rows[0]["prm_yka065"].ToString();//个人账户支付部分
            string aae036 = ds.Tables["output"].Rows[0]["prm_aae036"].ToString();//经办时间
            string yka055 = ds.Tables["output"].Rows[0]["prm_yka055"].ToString();//费用总额
            string yka056 = ds.Tables["output"].Rows[0]["prm_yka056"].ToString();//全自费部分
            string yka057 = ds.Tables["output"].Rows[0]["prm_yka057"].ToString();//先行自付
            string yka111 = ds.Tables["output"].Rows[0]["prm_yka111"].ToString();//符合范围
            string yka058 = ds.Tables["output"].Rows[0]["prm_yka058"].ToString();//本次起付线
            string yka248 = ds.Tables["output"].Rows[0]["prm_yka248"].ToString();//本次基本医疗报销金额
            string yka062 = ds.Tables["output"].Rows[0]["prm_yka062"].ToString();//本次大病医疗报销金额
            string yke030 = ds.Tables["output"].Rows[0]["prm_yke030"].ToString();//本次公务员报销金额
            string akc087 = ds.Tables["output"].Rows[0]["prm_akc087"].ToString();//本次个人账户支付后帐户余额
            string ykb037 = ds.Tables["output"].Rows[0]["prm_ykb037"].ToString();//清算分中心
            string yka316 = ds.Tables["output"].Rows[0]["prm_yka316"].ToString();//清算类别
            string akc021 = ds.Tables["output"].Rows[0]["prm_akc021"].ToString();//医疗人员类别
            string ykc120 = ds.Tables["output"].Rows[0]["prm_ykc120"].ToString();//医疗照顾人员类别
            string yab139 = ds.Tables["output"].Rows[0]["prm_yab139"].ToString();//所属社保机构编码（使用分中心编码代码）
            string aac003 = ds.Tables["output"].Rows[0]["prm_aac003"].ToString();//姓名
            string aac004 = ds.Tables["output"].Rows[0]["prm_aac004"].ToString();//性别
            string aac002 = ds.Tables["output"].Rows[0]["prm_aac002"].ToString();//身份号码
            string aac006 = ds.Tables["output"].Rows[0]["prm_aac006"].ToString();//出生日期
            string akc023 = ds.Tables["output"].Rows[0]["prm_akc023"].ToString();//实足年龄
            string aab001 = ds.Tables["output"].Rows[0]["prm_aab001"].ToString();//单位编码
            string aab004 = ds.Tables["output"].Rows[0]["prm_aab004"].ToString();//单位名称
            string ykc280 = ds.Tables["output"].Rows[0]["prm_ykc280"].ToString();//居民医疗人员类别
            string ykc281 = ds.Tables["output"].Rows[0]["prm_ykc281"].ToString();//居民医疗人员身份
            string yka054 = ds.Tables["output"].Rows[0]["prm_yka054"].ToString();//清算方式
            string yae366 = ds.Tables["output"].Rows[0]["prm_yae366"].ToString();//清算期号
            string ykd523 = ds.Tables["output"].Rows[0]["prm_ykd523"].ToString();//单病种清算金额
            string ykd524 = ds.Tables["output"].Rows[0]["prm_ykd524"].ToString();//精神病按日拨付金额
            //结算编号|个人编号|个人账户支付部分|经办时间|费用总额|全自费部分|先行自付|符合范围|本次起付线|本次基本医疗报销金额|
            //本次大病医疗报销金额|本次公务员报销金额|本次个人账户支付后帐户余额|清算分中心|清算类别|医疗人员类别|医疗照顾人员类别|所属社保机构编码（使用分中心编码代码）|姓名|性别|
            //身份号码|出生日期|实足年龄|单位编码|单位名称|居民医疗人员类别|居民医疗人员身份|清算方式|清算期号|单病种清算金额
            //精神病按日拨付金额
            string settled = yka103 + "|" + aac001 + "|" + yka065 + "|" + aae036 + "|" + yka055 + "|" + yka056 + "|" + yka057 + "|" + yka111 + "|" + yka058 + "|" + yka248 + "|"
                            + yka062 + "|" + yke030 + "|" + akc087 + "|" + ykb037 + "|" + yka316 + "|" + akc021 + "|" + ykc120 + "|" + yab139 + "|" + aac003 + "|" + aac004 + "|"
                            + aac002 + "|" + aac006 + "|" + akc023 + "|" + aab001 + "|" + aab004 + "|" + ykc280 + "|" + ykc281 + "|" + yka054 + "|" + yae366 + "|" + ykd523 + "|" 
                            + ykd524;
            string sql_upd = "update ihsp_insurinfo set settinfo = " + DataTool.addFieldBraces(settled) + ",opstat = " + DataTool.addFieldBraces(Insurinfostate.SETT.ToString()) +"where ihsp_id = " + DataTool.addFieldBraces(ihsp_id)+";";
            int res = BllMain.Db.Update(sql_upd);
            if (res != -1)
            {
                Confirm_in confirmin = new Confirm_in();
                confirmin.Astrjylsh = callOut.Astrjylsh;
                confirmin.Astrjyyzm = callOut.Astrjyyzm;
                Confirm_out confirmout = gzsybInterface.Confirm(confirmin);
                if(confirmout.AintAppcode<0)
                {
                    message.Append(confirmout.AstrAppmsg);
                    return false;
                }
                String grzh = yka065;//个人账户支付
                String zfy = yka055;//总费用
                String gwytczf = yke030;//公务员统筹支付
                String dbzf = yka062;//大病统筹支付
                String jbtczf = yka248;//基本统筹支付
                float float_grzh = DataTool.stringToFloat(grzh); //个人账户支付
                float float_zfy = DataTool.stringToFloat(zfy);   //总费用
                float float_gwytczf = DataTool.stringToFloat(gwytczf);//公务员统筹支付
                float float_dbzf = DataTool.stringToFloat(dbzf);       //大病统筹支付
                float float_jbtczf = DataTool.stringToFloat(jbtczf);//基本统筹支付
                float ybfy = float_grzh + float_gwytczf + float_dbzf + float_jbtczf;//医保费用
                //本次现金支付=费用总额-个人账户支付-基本医疗报销-大病医疗报销-公务员报销-总预交款
                float float_xj = float_zfy - float_grzh - float_gwytczf - float_dbzf - float_jbtczf - DataTool.stringToFloat(prepamt);//现金支付
                //统筹支付=基本医疗报销+大病医疗报销+公务员报销
                string ctzf = (double.Parse(jbtczf) + double.Parse(dbzf) + double.Parse(gwytczf)).ToString();
                sql_upd = ""; sql_upd += "update ihsp_insurinfo set insurefee = " + DataTool.addFieldBraces(ctzf) + ",insuraccountfee =" + DataTool.addFieldBraces(grzh) + ",insurbalance = " + DataTool.addFieldBraces(akc087) + "where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
                if (BllMain.Db.Update(sql_upd) >= 0)
                {
                    return true;
                }
                else
                {
                    message.Append("医保结算后插入数据执行失败！");
                    return false;
                }
            }
            else
            {
                message.Append("住院结算失败！");
                return false;
            }
        }
        /// <summary>
        /// 获取就诊编号
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable getBillCode(string ihsp_id)
        {
            string sql = "select registinfo from ihsp_insurinfo where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            //就诊编号|分中心编号|支付类别|个人编号|姓名|性别|身份证号|单位编码|单位名称|人员状态|实足年龄|社会保险办法
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 住院退结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool settleBack(string ihsp_id)
        {
            DataTable dtInfo = getBillCode(ihsp_id);
            string[] info = dtInfo.Rows[0]["registInfo"].ToString().Split('|');
            string currtime = BillSysBase.currDate();
            string sql = "select registinfo,settinfo from ihsp_insurinfo where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string personInfos = "";
            string settledInfos = "";
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("未查到该患者的医保信息！");
                return false;
            }
            personInfos = dt.Rows[0]["registinfo"].ToString();
            settledInfos = dt.Rows[0]["settinfo"].ToString();
            //支付类别|个人编号|姓名|性别|医疗照顾人员类别|执行社会保险办法|出生日期|单位编码|居民医疗人员类别|分中心编码
            //参保状态|医疗人员类别|身份证号|所属社保机构编码(使用分中心编码代码)|驻外标志|实足年龄|单位名称|居民医疗人员身份|个人账户余额|当前住院状态|读卡成功标志
            //受委托人姓名|与受委托人关系|受委托人身份证号|受委托人性别|疾病诊断|疾病ICD编码|精神病人住院标识
            string[] personInfo = personInfos.Split('|');
            //结算编号|个人编号|个人账户支付部分|经办时间|费用总额|全自费部分|先行自付|符合范围|本次起付线|本次基本医疗报销金额|
            //本次大病医疗报销金额|本次公务员报销金额|本次个人账户支付后帐户余额|清算分中心|清算类别|医疗人员类别|医疗照顾人员类别|所属社保机构编码（使用分中心编码代码）|姓名|性别|
            //身份号码|出生日期|实足年龄|单位编码|单位名称|居民医疗人员类别|居民医疗人员身份|清算方式|清算期号|单病种清算金额
            //精神病按日拨付金额
            string[] settledInfo = settledInfos.Split('|');
            String[] param = new String[10];
            param[0] = info[0];//就诊编号
            param[1] = personInfo[9];//分中心编号
            param[2] = info[2];//支付类别
            param[3] = settledInfo[0];//结算编号(原始结算编号)
            param[4] = ProgramGlobal.User_id;//经办人员编码
            param[5] = ProgramGlobal.Username;//经人人姓名
            param[6] = currtime;//经办时间
            param[7] = "不详";//退费原因
            param[8] = personInfo[5];//社会保险办法
            param[9] = settledInfo[1];//个人编号
            SettleBack ihhk = new SettleBack();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "42";//交易编号
            callIn.Astr_jysr_xml = ihhk.xmlCode_head() + ihhk.xmlCode_in(param);//交易输入
            Call_out callOut = gzsybInterface.Call(callIn);
            
            if(callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms,"错误信息");
                return false;
            }
            //交易成功
            string sql_upd = "update ihsp_insurinfo set opstat = "+DataTool.addFieldBraces(Insurinfostate.XX.ToString())+" where ihsp_id = " +DataTool.addFieldBraces(ihsp_id)+";";
            //sql_upd += "update inhospital set insurstat = " ;
            if(BllMain.Db.Update(sql) == -1)
            {
                 MessageBox.Show("数据库错误","错误信息");
                Cancel_in cancelIn = new Cancel_in();
                cancelIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
                Cancel_out cancelOut = gzsybInterface.Cancel(cancelIn);
                if(cancelOut.AintAppcode < 0)
                {
                    MessageBox.Show(cancelOut.AstrAppmsg,"错误信息");
                }
                MessageBox.Show("结算回退失败！","提示信息");
                return false;
            }
            else
            {
                Confirm_in confirmIn = new Confirm_in();
                confirmIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
                confirmIn.Astrjyyzm = callOut.Astrjyyzm;//交易验证码
                Confirm_out confirmOut = gzsybInterface.Confirm(confirmIn);
                if(confirmOut.AintAppcode < 0)
                {
                    MessageBox.Show(confirmOut.AstrAppmsg,"错误信息");
                    return false;
                }
                MessageBox.Show("结算回退成功！","提示消息");
            }
            return true;
        }
        /// <summary>
        /// 住院结算单打印
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool printIhspSettle(string ihsp_id)
        {
            DataTable dtInfo = getBillCode(ihsp_id);
            string[] info = dtInfo.Rows[0]["registInfo"].ToString().Split('|');
            string sql = "select registinfo,settinfo from ihsp_insurinfo where ihsp_id = " +DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if(dt.Rows.Count==0)
            {
                MessageBox.Show("未查询到该患者的医保信息！");
                return false;
            }
            string personinfos = dt.Rows[0]["registinfo"].ToString();
            //支付类别|个人编号|姓名|性别|医疗照顾人员类别|执行社会保险办法|出生日期|单位编码|居民医疗人员类别|分中心编码
            //参保状态|医疗人员类别|身份证号|所属社保机构编码(使用分中心编码代码)|驻外标志|实足年龄|单位名称|居民医疗人员身份|个人账户余额|当前住院状态|读卡成功标志
            //受委托人姓名|与受委托人关系|受委托人身份证号|受委托人性别|疾病诊断|疾病ICD编码|精神病人住院标识
            string[] personinfo = personinfos.Split('|');
            string settinfos = dt.Rows[0]["settinfo"].ToString();
            //结算编号|个人编号|个人账户支付部分|经办时间|费用总额|全自费部分|先行自付|符合范围|本次起付线|本次基本医疗报销金额|
            //本次大病医疗报销金额|本次公务员报销金额|本次个人账户支付后帐户余额|清算分中心|清算类别|医疗人员类别|医疗照顾人员类别|所属社保机构编码（使用分中心编码代码）|姓名|性别|
            //身份号码|出生日期|实足年龄|单位编码|单位名称|居民医疗人员类别|居民医疗人员身份|清算方式|清算期号|单病种清算金额
            //精神病按日拨付金额
            string[] settinfo = settinfos.Split('|');
            String[] param = new String[6];
            param[0] = info[0];//就诊编号
            param[1] = personinfo[9];//分中心编号
            param[2] = info[2];//支付类别
            param[3] = personinfo[11];//医疗人员类别
            param[4] = settinfo[0];//结算编号
            param[5] = personinfo[5];//社会保险办法
            SettlePrint ihhk = new SettlePrint();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "44";//交易编号
            callIn.Astr_jysr_xml = ihhk.xmlCode_head() + ihhk.xmlCode_in(param);//交易输入
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                return false;
            }
            return true;
        }
        public DataTable getInsurInfo(string ihsp_id)
        {
            string sql = "select registinfo,settinfo from ihsp_insurinfo where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 出院办理
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool outHosp(string ihsp_id,string reason)
        {
            DataTable dt=getInsurInfo(ihsp_id);
            string[] info = dt.Rows[0]["registinfo"].ToString().Split('|');
            String[] param = new String[21];
            param[0] = info[0];//就诊编号
            param[1] = info[3];//个人编号
            param[2] = info[2];//支付类别
            param[3] = reason;//出院原因(可空) (1、治愈；2、好转；3、死亡；4转院;5精神病中途结算(只有精神病按日包干的中途结算使用);9 其他)
            param[4] = BillSysBase.currDate();//出院日期(可空)
            param[5] = "";//"面肌痉挛";//出院诊断(可空)
            param[6] = "";//出院科室(可空)科室为中文,不能为编码
            param[7] = "";//cyjsBfh.Text;//出院床位(可空)
            param[8] = ProgramGlobal.Username;//经办人姓名(可空)
            param[9] = BillSysBase.currDate();//出院经办时间(可空)
            param[10] = info[1];//分中心编号
            param[11] = "";//"351.801";//出院附属诊断代码
            param[12] = "";//第一出院疾病诊断代码(可空)
            param[13] = "";//第二出院疾病诊断代码(可空)
            param[14] = "";//第三出院疾病诊断代码(可空)
            param[15] = "";//第四出院疾病诊断代码(可空)
            param[16] = "";//第五出院疾病诊断代码(可空)
            param[17] = "";//第六出院疾病诊断代码(可空)
            param[18] ="" ;//第七出院疾病诊断代码(可空)
            param[19] = "";//第八出院疾病诊断代码(可空)
            param[20] = info[11];//社会保险办法
            OutHospitalHandle ohhk = new OutHospitalHandle();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "25";//交易编号
            callIn.Astr_jysr_xml = ohhk.xmlCode_head() + ohhk.xmlCode_in(param);//交易输入xml
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 出院回退办理信息查询
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable getOutIhspRetInfo(string ihsp_id)
        {
            string sql = "select registinfo from ihsp_insurinfo where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 出院办理回退
        /// </summary>
        /// <param name="thisid"></param>
        /// <returns></returns>
        public bool retIhspOut(string ihsp_id)
        {
            DataTable dt = getInsurInfo(ihsp_id);
            string[] info = dt.Rows[0]["registinfo"].ToString().Split('|');
            String[] param = new String[7];
            param[0] = info[0];//就诊编号
            param[1] = info[2];//支付类别
            param[2] = ProgramGlobal.Username;
            param[3] = "";
            param[4] = info[1];//分中心编号
            param[5] = info[3];//个人编号
            param[6] = info[11];//社会保险办法
            OutHospitalHandleBack ohhk = new OutHospitalHandleBack();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "26";//交易编号
            callIn.Astr_jysr_xml = ohhk.xmlCode_head() + ohhk.xmlCode_in(param);
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 更新医保状态为已结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int accountHisStat(string ihsp_id)
        {
            string sql = " update inhospital set insurstat= 'SETT' where id" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);

        }
          /// <summary>
        /// 出院办理
        /// </summary>
        public bool Cybl(string mtzyjliid, string cyyy, string currDateTime)
        {
            string Jbr = ProgramGlobal.User_id;
            string xgxxJbr = ProgramGlobal.Username;
            string cyks = "select bas_depart.`name` as cyks from inhospital,bas_depart where inhospital.depart_id = bas_depart.id and inhospital.id =" + mtzyjliid;
            DataTable chksb =BllMain.Db.Select(cyks).Tables[0];
            string sql1 = "select akc190,aac001,aka130,yab003,ykb065 from insur_gzsyb_ryinfo where  mtzyjliid=" + mtzyjliid;
            DataTable dt =BllMain.Db.Select(sql1).Tables[0];
            string sql2 = "select diagnname as ssmc,diagnICD as ssbm from ihsp_diagnmes where diagnKind ='OUT' and opkind = 'MAIN' and ihsp_id =" + mtzyjliid + " limit 1";
            DataTable cysrxx = BllMain.Db.Select(sql2).Tables[0];
            string cyzd = "";
            string ssbm = "";
            if (cysrxx.Rows.Count > 0)
            {
                cyzd = cysrxx.Rows[0]["ssmc"].ToString();
                ssbm = cysrxx.Rows[0]["ssbm"].ToString();
            }
               

            String[] param = new String[21];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["aac001"].ToString();//个人编号
            param[2] = dt.Rows[0]["aka130"].ToString();//支付类别
            param[3] = cyyy;//swcyyy.SelectedValue.ToString();//出院原因(可空) (1、治愈；2、好转；3、死亡；4转院;5精神病中途结算(只有精神病按日包干的中途结算使用);9 其他)
            param[4] = currDateTime;//出院日期(可空)
            param[5] = cyzd;//"面肌痉挛";//出院诊断(可空)
            param[6] = chksb.Rows[0]["cyks"].ToString();//出院科室(可空)科室为中文,不能为编码
            param[7] = "";//cyjsBfh.Text;//出院床位(可空)
            param[8] = xgxxJbr;//经办人姓名(可空)
            param[9] = currDateTime;//出院经办时间(可空)
            param[10] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[11] = ssbm;//"351.801";//出院附属诊断代码
            param[12] = "";//dt.Rows[0]["ykd018"].ToString();//第一出院疾病诊断代码(可空)
            param[13] = "";//dt.Rows[0]["ykd019"].ToString();//第二出院疾病诊断代码(可空)
            param[14] = "";//dt.Rows[0]["ykd020"].ToString();//第三出院疾病诊断代码(可空)
            param[15] = "";//dt.Rows[0]["ykd021"].ToString();//第四出院疾病诊断代码(可空)
            param[16] = "";//dt.Rows[0]["ykd022"].ToString();//第五出院疾病诊断代码(可空)
            param[17] = "";//dt.Rows[0]["ykd023"].ToString();//第六出院疾病诊断代码(可空)
            param[18] = "";//dt.Rows[0]["ykd024"].ToString();//第七出院疾病诊断代码(可空)
            param[19] = "";//dt.Rows[0]["ykd025"].ToString();//第八出院疾病诊断代码(可空)
            param[20] = dt.Rows[0]["ykb065"].ToString();//社会保险办法
            OutHospitalHandle ohhk = new OutHospitalHandle();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "25";//交易编号
            callIn.Astr_jysr_xml = ohhk.xmlCode_head() + ohhk.xmlCode_in(param);//交易输入xml
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                return false;
            }
            //更新医保出院状态
            updateHisGzsybcyinfo(mtzyjliid);
            return true;
        }
        /// <summary>
        /// 出院回退
        /// </summary>
        public bool CyblHt(string mtzyjliid)
        {
            string Jbr = ProgramGlobal.User_id;
            string xgxxJbr = ProgramGlobal.Username;
            string currDateTime = BillSysBase.currDate();
            string sql1 = "select akc190,aka130,yab003,aac001,ykb065,aae036 from insur_gzsyb_ryinfo where  mtzyjliid=" + mtzyjliid;
            DataTable dt = BllMain.Db.Select(sql1).Tables[0];
            String[] param = new String[7];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["aka130"].ToString();//支付类别
            param[2] = xgxxJbr;//经办人姓名
            param[3] = currDateTime;//经办时间(可空)
            param[4] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[5] = dt.Rows[0]["aac001"].ToString();//个人编号
            param[6] = dt.Rows[0]["ykb065"].ToString();//社会保险办法
            OutHospitalHandleBack ohhk = new OutHospitalHandleBack();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "26";//交易编号
            callIn.Astr_jysr_xml = ohhk.xmlCode_head() + ohhk.xmlCode_in(param);//交易输入xml
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                return false;
            }
            //更新医保出院状态
            cancleHisGzsybcyinfo(mtzyjliid);
            return true;
        }

        public int updateHisGzsybcyinfo(string ihsp_id)
        {
            string sql = "update inhospital set insurouthsp=1  where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }

        public int cancleHisGzsybcyinfo(string ihsp_id)
        {
            string sql = "update inhospital set insurouthsp=0  where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 获取医保出院状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getInsurouthsp(string id)
        {
            string sql = "select insurouthsp from inhospital where id =" + DataTool.addFieldBraces(id);
            try
            {
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["insurouthsp"].ToString();
                }
            }
            catch (Exception)
            { }
            return "";

        }

        /// <summary>
        /// 费用上传
        /// </summary>
        /// <param name="mtzyjliid"></param>
        /// <returns></returns>
        public bool Fymxdr(String mtzyjliid,ref string returnMsg)
        {
            returnMsg = "";
            string noCross = "";
            string Jbr = ProgramGlobal.User_id;
            string xgxxJbr = ProgramGlobal.Username;
            string sql1 = "select akc190,aka130,yab003,aac001,ykb065,aae013,inhospital.insuritemtype from insur_gzsyb_ryinfo,inhospital where inhospital.id=insur_gzsyb_ryinfo.mtzyjliid and  mtzyjliid=" + mtzyjliid;
            DataTable dt = BllMain.Db.Select(sql1).Tables[0];
            String[] param = new String[5];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["aka130"].ToString();//支付类别
            param[2] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[3] = dt.Rows[0]["aac001"].ToString();//个人编码
            param[4] = dt.Rows[0]["ykb065"].ToString();//社会保险办法
            FeeWriteIn fwi = new FeeWriteIn();
            string insuritemtype = dt.Rows[0]["insuritemtype"].ToString(); ;//医保目录编码
            string currDateTime = BillSysBase.currDate();
            while (true)
            {
                string code_body = "";
                string sql_costs = " select "
                                 + "  ihsp_costdet.id"
                                 + " ,ihsp_costdet.standcode"
                                 + " ,ihsp_costdet.item_id"
                                 + " ,ihsp_costdet.itemfrom"
                                 + " ,ihsp_costdet.name"
                                 + " ,ihsp_costdet.spec"
                                 + ", dosageform.name as dosageform"
                                 + " ,ihsp_costdet.unit"
                                 + " ,ihsp_costdet.num"
                                 + " ,ihsp_costdet.prc"
                                 + " ,ihsp_costdet.realfee"
                                 + " ,ihsp_costdet.diagndep_id"
                                 + " ,ihsp_costdet.chargedate"
                                 + " ,bas_depart.name as dptname"
                                 + " ,bas_doctor.name as dctname"
                                 + " ,bas_doctor.practicecode"
                                 + " ,exedep.name as exedepname"
                                 + " ,exedoctor.name  as exedoctorname"
                                 + " ,cost_insurcross.insurcode"
                                 + " ,cost_insurcross.insurname"
                                 + " from ihsp_costdet "
                                 + "  left join bas_depart on ihsp_costdet.diagndep_id = bas_depart.id "
                                 + "  left join bas_doctor on ihsp_costdet.diagndoctor_id = bas_doctor.id"
                                 + "  left join bas_depart  exedep on ihsp_costdet.exedep_id = exedep.id "
                                 + "  left join bas_doctor  exedoctor on ihsp_costdet.exedoctor_id = exedoctor.id"
                                  + " left join sys_dict as dosageform on ihsp_costdet.dosageform_id=dosageform.sn and dosageform.dicttype='drug_dosageform' "
                                 + "  left join bas_doctor  charger  on ihsp_costdet.charger_id = charger.id"
                                 + " left join cost_insurcross on cost_insurcross.item_id = ihsp_costdet.item_id and cost_insurcross.drug_factyitem_id=ihsp_costdet.drug_factyitem_id"
                                 + "  where ihsp_costdet.ihsp_id =  " + DataTool.addFieldBraces(mtzyjliid)
                                  + " and ihsp_costdet.neonate_id = 0" //非新生儿
                                 + " and cost_insurcross.insuritemtype=" + DataTool.addFieldBraces(insuritemtype)
                                 + "  and ihsp_costdet.insursync = 'N' and ihsp_costdet.settled='N' and ihsp_costdet.charged in ('RET','CHAR','RREC') limit 20";
                DataTable dt_xmcx;
                try
                {
                    dt_xmcx = BllMain.Db.Select(sql_costs).Tables[0];
                }
                catch (Exception e)
                {
                    return false;
                }
                if (dt_xmcx.Rows.Count == 0)
                {
                    break;
                }
                
                for (int j = 0; j < dt_xmcx.Rows.Count; j++)
                {
                    String[] fee_param = new String[27];
                    fee_param[0] = dt_xmcx.Rows[j]["id"].ToString();//yka105>";//记账流水号
                    fee_param[1] = dt_xmcx.Rows[j]["item_id"].ToString();// ykd125 医院项目流水号(可空)
                    //<商品名代码>商品名代码</商品名代码>/*考虑增加*/
                    fee_param[2] = dt_xmcx.Rows[j]["name"].ToString();//ykd126 医院项目名称(可空)
                    fee_param[3] = dt_xmcx.Rows[j]["insurcode"].ToString();//yka002 医保通用项目编码
                    if (fee_param[3].Equals(""))
                    {
                        noCross = "[编码:" + dt_xmcx.Rows[j]["item_id"].ToString() + ",名称:" + dt_xmcx.Rows[j]["name"].ToString() + "]";
                        fee_param[3] = "NCL99999999";  //自费
                    }
                    fee_param[4] = dt_xmcx.Rows[j]["insurname"].ToString();//yka003 医保通用项目名称(可空)
                    fee_param[5] = dt_xmcx.Rows[j]["num"].ToString();//akc226 数量
                    fee_param[6] = dt_xmcx.Rows[j]["prc"].ToString();//akc225 实际价格
                    fee_param[7] = dt_xmcx.Rows[j]["realfee"].ToString();//yka315 明细项目费用总额
                    fee_param[8] = "";//yka097 开单科室编码(可空)
                    fee_param[9] = dt_xmcx.Rows[j]["dptname"].ToString();//yka098 开单科室名称(可空)
                    fee_param[10] = "";//ykd102 开单医生医师资格证号(可空)
                    fee_param[11] = dt_xmcx.Rows[j]["dctname"].ToString();//yka099 开单医生姓名(可空)
                    fee_param[12] = "";//yka100 受单科室编码(可空)
                    fee_param[13] = dt_xmcx.Rows[j]["exedepname"].ToString();//yka101 受单科室名称(可空)
                    fee_param[14] = "";//ykd106 受单医生编码(可空)
                    fee_param[15] = dt_xmcx.Rows[j]["dptname"].ToString();//yka102 受单医生姓名(可空)
                    fee_param[16] = dt_xmcx.Rows[j]["chargedate"].ToString();//yke123 明细发生时间
                    fee_param[17] = xgxxJbr;//ykc141 经办人姓名
                    fee_param[18] = BillSysBase.currDate();//aae036 经办时间(可空)
                    fee_param[19] = "";// dt.Rows[0]["aae013"].ToString();//aae013 备注(可空)
                    fee_param[20] = "";//yke201 中药使用方式(可空)
                    fee_param[21] = dt_xmcx.Rows[j]["unit"].ToString();//yka295 最小计价单位(可空)
                    fee_param[22] = dt_xmcx.Rows[j]["spec"].ToString();//aka074 规格(可空)
                    fee_param[23] = "";// t_xmcx.Rows[j]["jx"].ToString();//aka070 剂型(可空)
                    fee_param[24] = dt_xmcx.Rows[j]["dosageform"].ToString();//yae374 剂型名称(可空)
                    fee_param[25] = "";// yke009 是否医院制剂(可空)
                    fee_param[26] = "1";// yke186 医院审批标志(可空)暂未使用,默认传入值：1            
                    code_body += fwi.xml_code_body(fee_param);
                    
                }
                

                //调用交易函数
                Call_in callIn = new Call_in();
                callIn.AstrJybh = "31";
                callIn.Astr_jysr_xml = fwi.xmlCode_head() + fwi.xmlCode_in(param) + code_body + fwi.xml_Code_end();//交易输入xml
                Call_out callOut = gzsybInterface.Call(callIn);
                if (callOut.Aintappcode < 0)
                {
                    returnMsg += callOut.Astrappms;
                    return false;
                }
               

                //交易成功
                string xml = callOut.Astrjyscxml;
                StringReader sr = new StringReader(xml);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                for (int i = 0; i < ds.Tables["Row"].Rows.Count; i++)
                {
                    string akc190 = ds.Tables["row"].Rows[i]["akc190"].ToString();//就诊编码
                    string yka105 = ds.Tables["row"].Rows[i]["yka105"].ToString();//记账流水号
                    string yka317 = ds.Tables["row"].Rows[i]["yka317"].ToString();//明细项目全自费金额_YKA317
                    string yka318 = ds.Tables["row"].Rows[i]["yka318"].ToString();//明细项目挂钩自付金额_YKA318
                    string yka319 = ds.Tables["row"].Rows[i]["yka319"].ToString();//明细项目符合范围金额_YKA319
                    int pdbs = int.Parse(ds.Tables["row"].Rows[i]["code"].ToString());
                    string astrappms = ds.Tables["row"].Rows[i]["message"].ToString();
                    if (pdbs < 0)
                    {
                        returnMsg += astrappms;
                        return false;
                    }
                    string sql_updd = "update ihsp_costdet set insurefee = " + DataTool.addFieldBraces(yka319) + ", selffee=" + DataTool.addFieldBraces(yka318) + ",insursync = 'Y' where id = " + DataTool.addFieldBraces(yka105);
                    if (BllMain.Db.Update(sql_updd) == -1)
                    {
                        return false;
                    }
                }
            }
            returnMsg += noCross;
            return true;
        }
        public bool NursYjs(string ihsp_id)
        {
            string returnMsg = "";
            if(!Fymxdr(ihsp_id, ref returnMsg)) 
                return false;
            Yjs_retdata retdata = new Yjs_retdata();
           return Yjsan(ihsp_id, ref  retdata);
        }
        /// <summary>
        /// 预结算
        /// </summary>
        /// <param name="blh"></param>
        /// <returns></returns>
        public bool Yjsan(string mtzyjliid,ref Yjs_retdata retdata)
        {
            string zfy = bllIhspAct.getHisCostDetSum(mtzyjliid);
            string sql1 = "select akc190,aka130,yab003,aac001,ykb065,aac001 from insur_gzsyb_ryinfo where  mtzyjliid=" + mtzyjliid;
            DataTable dt =BllMain.Db.Select(sql1).Tables[0];
            String[] param = new String[6];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["aac001"].ToString();//个人编号
            param[2] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[3] = dt.Rows[0]["aka130"].ToString();//支付类别
            param[4] = dt.Rows[0]["ykb065"].ToString();//执行的社保办法
            param[5] = zfy;//HIS费用总额

            HisSimulateSettle ihh = new HisSimulateSettle();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "43";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
            Call_out callOut =gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {

                MessageBox.Show(callOut.Astrappms, "错误信息");
                return false;
            }


            //交易成功
            string xml = callOut.Astrjyscxml;
            //写xml日志到文件_wzw
            LogUtils.writeFileLog("gzsyb.log" ,"预结算:" + xml);
            //写xml日志到文件_wzw
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            retdata.Aac001 = ds.Tables["output"].Rows[0]["prm_aac001"].ToString();
            retdata.Aae036 = ds.Tables["output"].Rows[0]["prm_aae036"].ToString();
            retdata.Yka055 = ds.Tables["output"].Rows[0]["prm_yka055"].ToString();//总费用
            retdata.Yka056 = ds.Tables["output"].Rows[0]["prm_yka056"].ToString();//全自费
            retdata.Yka057 = ds.Tables["output"].Rows[0]["prm_yka057"].ToString();
            retdata.Yka111 = ds.Tables["output"].Rows[0]["prm_yka111"].ToString();
            retdata.Yka058 = ds.Tables["output"].Rows[0]["prm_yka058"].ToString();
            retdata.Yka248 = ds.Tables["output"].Rows[0]["prm_yka248"].ToString();//基本医疗统筹支付金额
            retdata.Yka062 = ds.Tables["output"].Rows[0]["prm_yka062"].ToString();//大额医疗支付金额
            retdata.Yke030 = ds.Tables["output"].Rows[0]["prm_yke030"].ToString();//公务员补助报销金额
            retdata.Ykb037 = ds.Tables["output"].Rows[0]["prm_ykb037"].ToString();
            retdata.Yka316 = ds.Tables["output"].Rows[0]["prm_yka316"].ToString();
            retdata.Yka054 = ds.Tables["output"].Rows[0]["prm_yka054"].ToString();
            retdata.Yae366 = ds.Tables["output"].Rows[0]["prm_yae366"].ToString();
            retdata.Zhyjj = ds.Tables["output"].Rows[0]["prm_zhyjj"].ToString();
            retdata.Zhkzf = ds.Tables["output"].Rows[0]["prm_zhkzf"].ToString();

          
            //医保报销  = 基本医疗统筹支付金额 + 大额医疗支付金

            double d_ybbx = DataTool.stringToDouble(retdata.Yka248) + DataTool.stringToDouble(retdata.Yka062) + DataTool.stringToDouble(retdata.Yke030);
            //个人账户余额
            double d_grzhye =DataTool.stringToDouble( getGrzhye(mtzyjliid));
            double d_zfy = DataTool.stringToDouble(zfy);
            //个人应付 = 总费用 - 医保报销
            double d_gryfje = d_zfy - d_ybbx;
            double d_grzhzf = 0;
            //个人账户最大支付= 个人应付- 全自费
            double d_zhmax_zf = d_gryfje - DataTool.stringToDouble(retdata.Yka056);
            //个人账户最大支付 < 个人账户余额
            if (d_zhmax_zf < d_grzhye)
            {
                d_grzhzf = d_zhmax_zf;
            }
            //个人账户最大支付 >=个人账户余额
            else
            {
                d_grzhzf = d_grzhye;
            }
             string sql = "update inhospital set insurefee=" + DataTool.addFieldBraces(d_ybbx.ToString())
                + ", insuraccountfee = " + DataTool.addFieldBraces(d_grzhzf.ToString())
                + ", nustmpamt = balanceamt+ insuraccountfee+insurefee "
                + " where id =" + DataTool.addFieldBraces(mtzyjliid) + ";";
           if( BllMain.Db.Update(sql)<0)
                    return false;
            return true;
        }
       public string getGrzhye(string mtzyjliid)
        {
            string sql = "select akc087 from insur_gzsyb_ryinfo where mtzyjliid =" + DataTool.addFieldBraces(mtzyjliid);
            try
            {
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string gezhye = dt.Rows[0][0].ToString();
                    return DataTool.stringToDouble(gezhye).ToString("0.00");
                }
            }
            catch (Exception)
            { }
            return "0.00";
            
        }
       public DataTable  getAccIhspInfo(string ihsp_id)
       {
           string sql = "select inhospital.ihspcode"
                           + ",inhospital.name as ihspname"
                           + ",inhospital.status"
                           + ",inhospital.bas_patienttype_id"
                           + ",inhospital.member_id"
                           + ",sexList.name as sex"
                           + ",ihsp_info.idcard"
                           + ",ihsp_info.homephone"
                           + ",bas_depart.name as departname"

                           + " from inhospital "
                           + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                           + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                           + " left join ihsp_info on ihsp_info.ihsp_id=inhospital.id and registkind='IHSP'"
                            + " where inhospital.id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
             return dt;
       }
      
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="bas_paytype_id">预交款付款方式(144 现金 ，146 银行卡，166 支票，)</param>
        /// <returns></returns>
        public bool Jsan( Ihspaccount ihspaccount, StringBuilder message)
        {
           string  ihsp_id = ihspaccount.Ihsp_id;
           string yjk = ihspaccount.Prepamt;
           string bas_paytype_id = ihspaccount.Bas_paytype_id;
           string currDateTime = ihspaccount.Chargedate;

            DataTable infoDt = getAccIhspInfo(ihsp_id);
            if (infoDt.Rows.Count <= 0)
            {
                message.Append("未找到想关病人信息!");
                return false;
            }
            string invoiceKind = bllIhspAct.getInvoiceKind(infoDt.Rows[0]["bas_patienttype_id"].ToString());
            
            string invoicecode = "";
            string nextinvoicesql = "";
            if (!BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), invoiceKind, ref invoicecode, ref nextinvoicesql))
            {
                message.Append("发票已用完，不能进行收费！");
                return false;
            }
            string member_id = infoDt.Rows[0]["member_id"].ToString();
            string patienttype_id = infoDt.Rows[0]["bas_patienttype_id"].ToString();

            string Jbr = ProgramGlobal.User_id;
            string xgxxJbr = ProgramGlobal.Username;

            string sql1 = "select akc190,aka130,yab003,aac001,ykb065,aac001,aae013,aac003 from insur_gzsyb_ryinfo where  mtzyjliid=" + ihsp_id;
            DataTable dt =BllMain.Db.Select(sql1).Tables[0];
            string sumtotal =  bllIhspAct.getHisCostDetSum(ihsp_id);;//HIS费用总额
            String[] param = new String[10];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[2] = dt.Rows[0]["aka130"].ToString(); //支付类别
            param[3] = dt.Rows[0]["ykb065"].ToString(); ;//社会保险办法
            param[4] = Math.Round(Convert.ToDouble(sumtotal), 2).ToString();//HIS费用总额
            param[5] = invoicecode;
            param[6] = "";// dt.Rows[0]["aae013"].ToString();//备注
            param[7] = Jbr;//经办人(可空)
            param[8] = xgxxJbr;//经办人姓名
            param[9] = dt.Rows[0]["aac001"].ToString();//个人编号

            FeeSettle ihh = new FeeSettle();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "41";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                message.Append(callOut.Astrappms);
                return false;
            }

            //交易成功
            string xml = callOut.Astrjyscxml;
            //写xml日志到文件_wzw
             LogUtils.writeFileLog("gzsyb.log" ,"结算:" + xml);
            
            //写xml日志到文件_wzw
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string yka103 = ds.Tables["output"].Rows[0]["prm_yka103"].ToString();//结算编号
            string aac001 = ds.Tables["output"].Rows[0]["prm_aac001"].ToString();//个人编号
            string yka065 = ds.Tables["output"].Rows[0]["prm_yka065"].ToString();//个人账户支付部分
            string aae036 = ds.Tables["output"].Rows[0]["prm_aae036"].ToString();//经办时间
            string yka055 = ds.Tables["output"].Rows[0]["prm_yka055"].ToString();//费用总额
            string yka056 = ds.Tables["output"].Rows[0]["prm_yka056"].ToString();//全自费部分
            string yka057 = ds.Tables["output"].Rows[0]["prm_yka057"].ToString();//先行自付
            string yka111 = ds.Tables["output"].Rows[0]["prm_yka111"].ToString();//符合范围
            string yka058 = ds.Tables["output"].Rows[0]["prm_yka058"].ToString();//本次起付线
            string yka248 = ds.Tables["output"].Rows[0]["prm_yka248"].ToString();//本次基本医疗报销金额
            string yka062 = ds.Tables["output"].Rows[0]["prm_yka062"].ToString();//本次大病医疗报销金额
            string yke030 = ds.Tables["output"].Rows[0]["prm_yke030"].ToString();//本次公务员报销金额
            string akc087 = ds.Tables["output"].Rows[0]["prm_akc087"].ToString();//本次个人账户支付后帐户余额
            string ykb037 = ds.Tables["output"].Rows[0]["prm_ykb037"].ToString();//清算分中心
            string yka316 = ds.Tables["output"].Rows[0]["prm_yka316"].ToString();//清算类别
            string akc021 = ds.Tables["output"].Rows[0]["prm_akc021"].ToString();//医疗人员类别
            string ykc120 = ds.Tables["output"].Rows[0]["prm_ykc120"].ToString();//医疗照顾人员类别
            string yab139 = ds.Tables["output"].Rows[0]["prm_yab139"].ToString();//所属社保机构编码（使用分中心编码代码）
            string aac003 = ds.Tables["output"].Rows[0]["prm_aac003"].ToString();//姓名
            string aac004 = ds.Tables["output"].Rows[0]["prm_aac004"].ToString();//性别
            string aac002 = ds.Tables["output"].Rows[0]["prm_aac002"].ToString();//身份号码
            string aac006 = ds.Tables["output"].Rows[0]["prm_aac006"].ToString();//出生日期
            string akc023 = ds.Tables["output"].Rows[0]["prm_akc023"].ToString();//实足年龄
            string aab001 = ds.Tables["output"].Rows[0]["prm_aab001"].ToString();//单位编码
            string aab004 = ds.Tables["output"].Rows[0]["prm_aab004"].ToString();//单位名称
            string ykc280 = ds.Tables["output"].Rows[0]["prm_ykc280"].ToString();//居民医疗人员类别
            string ykc281 = ds.Tables["output"].Rows[0]["prm_ykc281"].ToString();//居民医疗人员身份
            string yka054 = ds.Tables["output"].Rows[0]["prm_yka054"].ToString();//清算方式
            string yae366 = ds.Tables["output"].Rows[0]["prm_yae366"].ToString();//清算期号
            string ykd523 = ds.Tables["output"].Rows[0]["prm_ykd523"].ToString();//单病种清算金额
            string ykd524 = ds.Tables["output"].Rows[0]["prm_ykd524"].ToString();//精神病按日拨付金额
            string selectSql = "select * from insur_gzsyb_ryinfo where mtzyjliid=" + ihsp_id;
            DataTable ynnhinfoDT = BllMain.Db.Select(selectSql).Tables[0];

            string sql2 = "";

            if (ynnhinfoDT.Rows.Count > 0)//有更新没有插入
            {
                sql2 += "update insur_gzsyb_ryinfo set yka103 ='" + yka103 + "',"
               + " aac001='" + aac001 + "',yka065='" + yka065 + "',"
               + " aae036='" + aae036 + "',yka055='" + yka055 + "',"
               + " yka056='" + yka056 + "',"
               + " yka057='" + yka057 + "',"
               + " yka111='" + yka111 + "',"
               + " yka058='" + yka058 + "',"
               + " yka248='" + yka248 + "',"
               + " yka062='" + yka062 + "',"
               + " yke030='" + yke030 + "',"
               + " akc087='" + akc087 + "',"
               + " ykb037='" + ykb037 + "',"
               + " yka316='" + yka316 + "',"
               + " akc021='" + akc021 + "',"
               + " ykc120='" + ykc120 + "',"
               + " yab139='" + yab139 + "',"
               + " aac003='" + aac003 + "',"
               + " aac004='" + aac004 + "',"
               + " aac002='" + aac002 + "',"
               + " aac006='" + aac006 + "',"
               + " akc023='" + akc023 + "',"
               + " aab001='" + aab001 + "',"
               + " aab004='" + aab004 + "',"
               + " ykc280='" + ykc280 + "',"
               + " ykc281='" + ykc281 + "',"
               + " yka054='" + yka054 + "',"
               + " yae366='" + yae366 + "',"
               + " ykd523='" + ykd523 + "',"
               + " ykd524='" + ykd524 
               + "' where mtzyjliid='" + ihsp_id + "';";
            }
            else
            {
                sql2 += " insert into insur_gzsyb_ryinfo(mtzyjliid, yka103, aac001, yka065,aae036,yka055,yka056,yka057,yka111,yka058,yka248,yka062,yke030,akc087,ykb037,yka316,akc021,ykc120,yab139,aac003,aac004,aac002,aac006,akc023,aab001,aab004,ykc280,ykc281,yka054,yae366,ykd523,ykd524) values('"
                    + ihsp_id + "','" + yka103 + "','" + aac001 + "','" + yka065 + "','" + aae036 + "','" + yka055 + "','" + yka056 + "','" + yka057 + "','" + yka111 + "','" + yka058 + "','" + yka248 + "','" + yka062 + "','" + yke030
                    + "','" + akc087 + "','" + ykb037 + "','" + yka316 + "','" + akc021 + "','" + ykc120 + "','" + yab139 + "','" + aac003 + "','" + aac004 + "','" + aac002 + "','" + aac006 + "','" + akc023 + "','" + aab001 + "','" + aab004 + "','" + ykc280 + "','" + ykc281 + "','" + yka054 + "','" + yae366 + "','" + ykd523 + "','" + ykd524 + "');";//修改his系统nhflag标志，置为7
            }
            sql2 += "update inhospital set insurstat='SETT' where id='" + ihsp_id + "';";

            int n =  BllMain.Db.Update(sql2);
            if (n == -1)
            {
                message.Append("住院结算,更新医保结算信息失败！，结算时用网络支付请及时退网络支付费用");
                return false;
            }
            Confirm_in confirmin = new Confirm_in();
            confirmin.Astrjylsh = callOut.Astrjylsh;
            confirmin.Astrjyyzm = callOut.Astrjyyzm;
            Confirm_out confirmout = gzsybInterface.Confirm(confirmin);
            if (confirmout.AintAppcode < 0)
            {
                //MessageBox.Show(confirmout.AstrAppmsg, "错误信息");
                LogUtils.writeFileLog("gzsyb.log", "结算交易确认失败:Astrjylsh=" + confirmin.Astrjylsh + ",Astrjyyzm=" + confirmin.Astrjyyzm);
                message.Append(confirmout.AstrAppmsg);
                return false;
            }
          //  Common_Util util = new Common_Util();
            String jsrxm = dt.Rows[0]["yab003"].ToString();
            String grzh = yka065;//个人账户支付
            String zfy = yka055;//总费用
            String gwytczf = yke030;//公务员统筹支付
            String dbzf = yka062;//大病统筹支付
            String jbtczf = yka248;//基本统筹支付

            double float_grzh = Convert.ToDouble(grzh); //个人账户支付
            double float_zfy = Convert.ToDouble(zfy);   //总费用
            double float_gwytczf = Convert.ToDouble(gwytczf);//公务员统筹支付
            double float_dbzf = Convert.ToDouble(dbzf);       //大病统筹支付
            double float_jbtczf = Convert.ToDouble(jbtczf);//基本统筹支付
            double ybfy =  float_gwytczf + float_dbzf + float_jbtczf;//医保报销
            double float_xj = float_zfy - float_grzh - float_gwytczf - float_dbzf - float_jbtczf - DataTool.stringToDouble(yjk);//结算收款
           
            
            List<IhspInvoicedet> invoicedets = new List<IhspInvoicedet>();

            ihspaccount.Id = BillSysBase.nextId("ihsp_account");
            ihspaccount.Ihsp_id = ihsp_id;
            ihspaccount.Billcode = BillSysBase.newBillcode("ihsp_account_billcode");
            ihspaccount.Member_id = member_id;
            ihspaccount.Bas_paytype_id = bas_paytype_id;
            ihspaccount.Cheque = "";
            ihspaccount.Bas_patienttype_id = patienttype_id;
            ihspaccount.Num = "1";
            //发票号
            ihspaccount.Invoice = invoicecode;
            ihspaccount.Nextinvoicesql = nextinvoicesql;
            //费用
            ihspaccount.Feeamt = DataTool.FormatData(zfy, "2");
            //总预交款
            ihspaccount.Prepamt = DataTool.FormatData(yjk, "2");
            ihspaccount.Balanceamt = DataTool.FormatData(float_xj.ToString(), "2");
            //医保报销
            ihspaccount.Insurefee = ybfy.ToString("0.00");
            //账户支付
            ihspaccount.Selffee = DataTool.FormatData(grzh, "2");
            ihspaccount.Depart_id = ProgramGlobal.Depart_id;
            ihspaccount.Chargedby_id = ProgramGlobal.User_id;
            ihspaccount.Chargedate = currDateTime;
            ihspaccount.Cancleby = "0";
            ihspaccount.Ihsp_account_id = "0";
            ihspaccount.Status = IhspAccountStatus.SETT.ToString();
           
            IhspInvoicedet invoicedet = new IhspInvoicedet();
            invoicedet.Id = BillSysBase.nextId("ihsp_invoicedet");
            invoicedet.IhspAccountId = ihspaccount.Id;
            invoicedet.PaytypeId = ihspaccount.Bas_paytype_id;
            invoicedet.PaysumbyId = bllIhspAct.getPaysumby(invoicedet.PaytypeId);
            invoicedet.Payfee = DataTool.FormatData(float_xj.ToString(), "2");
            invoicedet.Billcode = ihspaccount.Cheque;
            invoicedets.Add(invoicedet);
            IhspInvoicedet invoicedet1 = new IhspInvoicedet();
            invoicedet1.Id = BillSysBase.nextId("ihsp_invoicedet");
            invoicedet1.IhspAccountId = ihspaccount.Id;
            invoicedet1.PaytypeId = bllIhspAct.getInsurFeePaytypeId();
            invoicedet1.PaysumbyId = bllIhspAct.getPaysumbyKeyname("GZSYDYB"); //医保报销
            invoicedet1.Payfee = DataTool.FormatData(ybfy.ToString(), "2");
            invoicedet1.Billcode = "";
            invoicedets.Add(invoicedet1);
            IhspInvoicedet invoicedet2 = new IhspInvoicedet();
            invoicedet2.Id = BillSysBase.nextId("ihsp_invoicedet");
            invoicedet2.IhspAccountId = ihspaccount.Id;
            invoicedet2.PaytypeId = bllIhspAct.getSELFFEEPaytypeId();
            invoicedet2.PaysumbyId = bllIhspAct.getPaysumbyKeyname("GZSYDYB"); //账户支付
            invoicedet2.Payfee = DataTool.FormatData(grzh, "2");
            invoicedet2.Billcode = "";
            invoicedets.Add(invoicedet2);
            string account_sql = bllIhspAct.accountInsurStat(ihsp_id);//医保状态信息
            account_sql += bllIhspAct.doAccount(ihspaccount, invoicedets, "insur");

            if (billIhspMan.doExeSql(account_sql) < 0)
            {
                message.Append("HIS结算失败, 请及时处理医保已结算信息, 结算时用网络支付请及时退网络支付费用");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 结算回退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public bool cyjsJsht(string mtzyjliid, string paytypeId)
        {
         

            string Jbr = ProgramGlobal.User_id;
            string xgxxJbr = ProgramGlobal.Username;

            string sql1 = "select akc190,yab003,aka130,ykb065,aac001,yka103,aae036 from insur_gzsyb_ryinfo where mtzyjliid=" + mtzyjliid;
            String[] param = new String[10];
            DataTable dt = BllMain.Db.Select(sql1).Tables[0];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[2] = dt.Rows[0]["aka130"].ToString();//支付类别
            param[3] = dt.Rows[0]["yka103"].ToString();//结算编号(原始结算编号)
            param[4] = Jbr;//经办人员编码
            param[5] = xgxxJbr;//经人人姓名
            param[6] = dt.Rows[0]["aae036"].ToString();//经办时间
            param[7] = "不详";//退费原因
            param[8] = dt.Rows[0]["ykb065"].ToString();//社会保险办法
            param[9] = dt.Rows[0]["aac001"].ToString();//个人编号
            SettleBack ihhk = new SettleBack();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "42";//交易编号
            callIn.Astr_jysr_xml = ihhk.xmlCode_head() + ihhk.xmlCode_in(param);//交易输入
            Call_out callOut = gzsybInterface.Call(callIn);
          
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                return false;
            }
            Confirm_in confirmIn = new Confirm_in();
            confirmIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
            confirmIn.Astrjyyzm = callOut.Astrjyyzm;//交易验证码
            Confirm_out confirmOut = gzsybInterface.Confirm(confirmIn);
            if (confirmOut.AintAppcode < 0)
            {
                LogUtils.writeFileLog("gzsyb.log", "结算回退交易确认失败:Astrjylsh=" + confirmIn.Astrjylsh + ",Astrjyyzm=" + confirmIn.Astrjyyzm);
                MessageBox.Show(confirmOut.AstrAppmsg, "错误信息");
                return false;
            }
            return true;
           
           
        }
       
        public bool doCancel(string Astrjylsh, StringBuilder message)
        {
            Cancel_in cancelIn = new Cancel_in();
            cancelIn.Astrjylsh = Astrjylsh;//交易流水号
            Cancel_out cancelOut = gzsybInterface.Cancel(cancelIn);

            if (cancelOut.AintAppcode < 0)
            {
                LogUtils.writeFileLog("gzsyb.log", "结算回退交易取消失败:Astrjylsh=" + Astrjylsh );
                message.Append(cancelOut.AstrAppmsg);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 费用批量删除
        /// </summary>
        /// <param name="mtzyjl_iid"></param>
        /// <returns></returns>
        public bool fysc(String mtzyjliid)
        {
            string sql1 = "select akc190,aka130,yab003,ykb065 from insur_gzsyb_ryinfo where  mtzyjliid=" + mtzyjliid;
            DataTable dt = BllMain.Db.Select(sql1).Tables[0];
            String[] param = new String[4];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["aka130"].ToString();//支付类别
            param[2] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[3] = dt.Rows[0]["ykb065"].ToString();//社会保险办法
            BatchFeeDel ohhk = new BatchFeeDel();//批量删除明细
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "33";//交易编号
            callIn.Astr_jysr_xml = ohhk.xmlCode_head() + ohhk.xmlCode_in(param);//交易输入xml
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                return false;
            }

            string sql = "update ihsp_costdet set insursync='N' where settled='N' and ihsp_id=" + mtzyjliid;
            BllMain.Db.Update(sql);
            return true;
        }
         /// <summary>
        /// 查询icd10疾病编码
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataTable GetIcd(String where)
        {
            String sql = "  select case_icd10_6 as flbm,case_name as jbmc,pincode as pybm from bas_caseicd where case_icd10_6 like '%" + where + "%' or case_name like '%" + where + "%' or pincode like '%" + where + "%';";
            return BllMain.Db.Select(sql).Tables[0];
        }
         /// <summary>
        /// 查询所有icd10疾病编码
        /// </summary>
        /// <returns></returns>
        public DataTable GetIcd()
        {
            String sql = " select case_icd10_6 as flbm,case_name as jbmc,pincode as pybm from bas_caseicd";
            return BllMain.Db.Select(sql).Tables[0];
        }
        
    }    
}        