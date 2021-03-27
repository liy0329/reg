using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.bo;
using MTREG.medinsur.gysyb.bo;
using MTREG.common;
using MTHIS.common;
using MTREG.medinsur.gzsyb.clinic.bo;
using MTHIS.main.bll;
using MTREG.common.bll;
using MTHIS.tools;
using MTREG.clinic.bo;

namespace MTREG.medinsur.gzsyb.bll
{
    class Gzsybservice
    {
        GzsybInterface gzsybInterface = new GzsybInterface();
        /// <summary>
        /// 读卡（身份识别）
        /// </summary>
        /// <param name="e"></param>
        public PersonInfo Zydk()
        {
            IdentityRecognition ihh = new IdentityRecognition();
            PersonInfo personInfo = new PersonInfo();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "03";//交易编号
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in();//交易输入
            Call_out callOut = gzsybInterface.Call(callIn);
            
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                personInfo.Flag = "-1";
                return personInfo;
            }            
            //交易成功
            string xml = callOut.Astrjyscxml;
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string aac001 = ds.Tables["output"].Rows[0]["prm_aac001"].ToString();//个人编号0
            string akc021 = ds.Tables["output"].Rows[0]["prm_akc021"].ToString();//医疗人员类别
            string ykc120 = ds.Tables["output"].Rows[0]["prm_ykc120"].ToString();//医疗照顾人员类别
            string yab139 = ds.Tables["output"].Rows[0]["prm_yab139"].ToString();//所属社保机构编码
            string ykb065 = ds.Tables["output"].Rows[0]["prm_ykb065"].ToString();//执行社会保险办法
            string ykc150 = ds.Tables["output"].Rows[0]["prm_ykc150"].ToString();//驻外标志
            string aac003 = ds.Tables["output"].Rows[0]["prm_aac003"].ToString();//姓名0
            string aac004 = ds.Tables["output"].Rows[0]["prm_aac004"].ToString();//性别0
            string aac002 = ds.Tables["output"].Rows[0]["prm_aac002"].ToString();//身份号码
            string aac006 = ds.Tables["output"].Rows[0]["prm_aac006"].ToString();//出生日期
            string akc023 = ds.Tables["output"].Rows[0]["prm_akc023"].ToString();//实足年龄
            string aab001 = ds.Tables["output"].Rows[0]["prm_aab001"].ToString();//单位编码
            string aab004 = ds.Tables["output"].Rows[0]["prm_aab004"].ToString();//单位名称
            string aac031 = ds.Tables["output"].Rows[0]["prm_aac031"].ToString();//参保状态
            string akc087 = ds.Tables["output"].Rows[0]["prm_akc087"].ToString();//个人账户余额
            string yab003 = ds.Tables["output"].Rows[0]["prm_yab003"].ToString();//分中心编号
            string ykc280 = ds.Tables["output"].Rows[0]["prm_ykc280"].ToString();//居民医疗人员类别
            string ykc281 = ds.Tables["output"].Rows[0]["prm_ykc281"].ToString();//居民医疗人员身份
            string ykc023 = ds.Tables["output"].Rows[0]["prm_ykc023"].ToString();//当前住院状态
            personInfo.Swgrbh = aac001;
            personInfo.Swxm = aac003;
            personInfo.Swxb = aac004;
            personInfo.Swylzgrylb = ykc120;
            personInfo.Swzxshbxbf = ykb065;
            personInfo.Swcsrq = aac006;
            personInfo.Swdwbm = aab001;
            personInfo.Swjmlrylb = ykc280;
            personInfo.Swfzxbm = yab003;
            personInfo.Swzbzt = aac031;
            personInfo.Swylrylb = akc021;
            personInfo.Swsfzh = aac002;
            personInfo.Sssbjgbm = yab139;
            personInfo.Swzwbz = ykc150;
            personInfo.Swsznl = akc023;
            personInfo.Swdwmc = aab004;
            personInfo.Swjmylrysf = ykc281;
            personInfo.Swgrzhye = akc087;
            personInfo.Swdqzyzt = ykc023;
            personInfo.Swdwmc = aab004;
            return personInfo;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        public void updatePassword()
        { 
            UpdatePassword up = new UpdatePassword();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "02";
            callIn.Astr_jysr_xml = up.xmlCode_head() + up.xmlCode_in();
            Call_out callOut = gzsybInterface.Call(callIn);
            if(callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms,"错误信息");
                return;
            }
        }
        /// <summary>
        /// 读委托人信息
        /// </summary>
        /// <param name="grbh"></param>个人编号
        /// <param name="fzxbm"></param>分中心编码
        /// <returns></returns>
        public PersonInfo readBailor(string grbh, string fzxbm)
        {
            IdentityRecognition ihh = new IdentityRecognition();
            PersonInfo personInfo = new PersonInfo();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "Q99E";//交易编号
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + "<input><prm_aac001>" + grbh + "</prm_aac001><prm_yab003>" + fzxbm + "</prm_yab003><prm_outputfile>c:\\dswtrxx.txt</prm_outputfile><proxy>1</proxy></input>";//交易输入
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                personInfo.Flag = "-1";
                return personInfo;
            }
            
            //交易成功
            string xml = callOut.Astrjyscxml;
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            StreamReader objReader = new StreamReader("c:\\dswtrxx.txt", System.Text.Encoding.Default);
            String sLine = "";
            List<String> lineList = new List<String>();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine != null)
                    lineList.Add(sLine);
            }
            objReader.Close();
            //string aac003 = ds.Tables["output"].Rows[0]["prm_aac003"].ToString();//个人编号0
            //string aae013 = ds.Tables["output"].Rows[0]["prm_Aae013"].ToString();//医疗人员类别
            //string aac002 = ds.Tables["output"].Rows[0]["prm_Aac002"].ToString();//医疗照顾人员类别
            //string aac004 = ds.Tables["output"].Rows[0]["prm_Aac004"].ToString();//所属社保机构编码

            if (lineList.Count > 0)
            {
                string _data = lineList[0];
                string[] _d2 = _data.Split('\t');
                personInfo.Swtrxm = _d2[0];
                personInfo.Swtrgx = _d2[1];
                personInfo.Swtrsfzh = _d2[2];
                personInfo.Swtrxb = _d2[3];
            }
            return personInfo;
        }

       


        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <param name="message"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool mzjs_kls(PersonInfo personInfo, ref string message, ClinicInvoice clinicInvoice,  string[] yb)
        {
            BllClinicMedinsrGZS bllClinicMedinsrGzs = new BllClinicMedinsrGZS();
            string jzbh="";
            string fph = clinicInvoice.Invoice;//发票号
            string grbh = personInfo.Swgrbh;//个人编号
            string jbzd = "";//疾病诊断
            string jbrbm = ProgramGlobal.User_id;//经办人编码
            string jbrmc = ProgramGlobal.Username;//经办人姓名
            string zflb = personInfo.Zflb;//支付类别
            string zxshbxbf = personInfo.Swzxshbxbf;//执行社会保险办法
            string[] param = new string[10];
             
            param[0] = jzbh;//就诊编号
            param[1] = grbh;//个人编号
            param[2] = jbzd;//门诊诊断信息(可空)
            param[3] = upLoadClinicAmount(clinicInvoice.Clinic_costdet_ids);//HIS总费用
            param[4] = zflb;//支付类别
            param[5] = fph;//发票号(可空)
            param[6] = "";//备注(可空)
            param[7] = jbrbm;//经办人编码(可空)
            param[8] = jbrmc;//经办人姓名
            param[9] = zxshbxbf;//执行社会保险办法
            ClinicSettle cs = new ClinicSettle();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "48";
            string insuritemsage = "";
            string xmlBody = uploadClinCostdet(cs, clinicInvoice, ref insuritemsage);
            if (!string.IsNullOrEmpty(insuritemsage))
            {
                message = "收费项目医保未对照：" + insuritemsage;
                return false;
            }
            callIn.Astr_jysr_xml = cs.xmlCode_head() + cs.xmlCode_in(param) + xmlBody + cs.xmlCodeIn_end();
            Call_out callOut = gzsybInterface.Call(callIn);
          
            if(callOut.Aintappcode < 0)
            {
                message = "收费交易函数失败：" + callOut.Astrappms;
                return false;
            }
           

            string jylsh = callOut.Astrjylsh;
            string jyyzm = callOut.Astrjyyzm;//交易验证码            
            string xml = callOut.Astrjyscxml;
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string akc190 = ds.Tables["output"].Rows[0]["prm_akc190"].ToString();//就诊编号
            string yab003 = ds.Tables["output"].Rows[0]["prm_yab003"].ToString();//分中心编号
            string yka103 = ds.Tables["output"].Rows[0]["prm_yka103"].ToString();//结算编号
            string aac001 = ds.Tables["output"].Rows[0]["prm_aac001"].ToString();//个人编号
            string yka065 = ds.Tables["output"].Rows[0]["prm_yka065"].ToString();//个人账户支付部分#-----------
            string aae036 = ds.Tables["output"].Rows[0]["prm_aae036"].ToString();//经办时间
            string yka055 = ds.Tables["output"].Rows[0]["prm_yka055"].ToString();//费用总额-----------------
            string yka056 = ds.Tables["output"].Rows[0]["prm_yka056"].ToString();//全自费部分------------
            string yka057 = ds.Tables["output"].Rows[0]["prm_yka057"].ToString();//先行自付
            string yka111 = ds.Tables["output"].Rows[0]["prm_yka111"].ToString();//符合范围
            string yka058 = ds.Tables["output"].Rows[0]["prm_yka058"].ToString();//本次起付线
            string yka248 = ds.Tables["output"].Rows[0]["prm_yka248"].ToString();//本次基本医疗报销金额+------
            string yka062 = ds.Tables["output"].Rows[0]["prm_yka062"].ToString();//本次大病医疗报销金额+------
            string yke030 = ds.Tables["output"].Rows[0]["prm_yke030"].ToString();//公务员报销金额+-------
            string akc087 = ds.Tables["output"].Rows[0]["prm_akc087"].ToString();//本次个人账户支付后帐户余额
            string ykb037 = ds.Tables["output"].Rows[0]["prm_ykb037"].ToString();//清算分中心
            string yka316 = ds.Tables["output"].Rows[0]["prm_yka316"].ToString();//清算类别
            string akc021 = ds.Tables["output"].Rows[0]["prm_akc021"].ToString();//医疗人员类别
            string ykc120 = ds.Tables["output"].Rows[0]["prm_ykc120"].ToString();//医疗照顾人员类别
            string yab139 = ds.Tables["output"].Rows[0]["prm_yab139"].ToString();//所属社保机构编码
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
            string akc090 = ds.Tables["output"].Rows[0]["prm_akc090"].ToString();//本年真实住院次数
            string yka120 = ds.Tables["output"].Rows[0]["prm_yka120"].ToString();//基本统筹累计金额
            string yka122 = "";// ds.Tables["output"].Rows[0]["prm_yka122"].ToString();//大病统筹累计金额
            string yka368 = ds.Tables["output"].Rows[0]["prm_yka368"].ToString();//门诊补助起付线
            string yke025 = ds.Tables["output"].Rows[0]["prm_yke025"].ToString();//门诊补助累计
            string aae001 = ds.Tables["output"].Rows[0]["prm_aae001"].ToString();//年度
            string yka900 = ds.Tables["output"].Rows[0]["prm_yka900"].ToString();//规定病种起付线累计
            //aka130 :支付类别
            //ykb065://执行社会保险办法
            personInfo.Jzbh = akc190;
            yb[2] = yab003;
            yb[0] = yka065;//账户支付
            yb[1] = (DataTool.stringToDouble(yka248) + DataTool.stringToDouble(yka062) + DataTool.stringToDouble(yke030)).ToString();//统筹支付

            String sql2 = " insert into gzsyb_mzfyb(mtstuffitemfph, mtmzblstuffiid, akc190, yab003, yka103, aac001, yka065,aae036,yka055,yka056,yka057,yka111,yka058,yka248,yka062,yke030,akc087,ykb037,yka316,akc021,ykc120,yab139,aac003,aac004,aac002,aac006,akc023,aab001,aab004,ykc280,ykc281,yka054,yae366,aka130,ykb065,mzjsr,mzjssj, akc090, yka120, yka122, yka368, yke025, aae001, yka900, astrjylsh, astrjyyzm, sickname, createdate,ybflag) values('" + fph + "','"
                    + clinicInvoice.Id + "','" + akc190 + "','" + yab003 + "','" + yka103 + "','" + aac001 + "','" + DataTool.stringToDouble(yka065) + "','" + aae036 + "','" + DataTool.stringToDouble(yka055) + "','" + yka056 + "','" + yka057 + "','" + yka111 + "','" + yka058 + "','" + DataTool.stringToDouble(yka248) + "','" + DataTool.stringToDouble(yka062) + "','" + DataTool.stringToDouble(yke030)
                    + "','" + akc087 + "','" + ykb037 + "','" + yka316 + "','" + akc021 + "','" + ykc120 + "','" + yab139 + "','" + aac003 + "','" + aac004 + "','" + aac002 + "','" + aac006 + "','" + akc023 + "','" + aab001 + "','" + aab004 + "','" + ykc280 + "','" + ykc281 + "','" + yka054 + "','" + yae366 + "','" + zflb + "','" + zxshbxbf + "','" + ProgramGlobal.Username + "','" + BillSysBase.currDate() + "','" + akc090 + "','" + yka120 + "','" + yka122 + "','" + yka368 + "','" + yke025 + "','" + aae001 + "','" + yka900 + "','" + jylsh + "','" + jyyzm + "','" + personInfo.Swxm + "', NOW(),'1') ;";


            string sql_bak = " insert into gzsyb_mzfyb_bak(mtstuffitemfph, mtmzblstuffiid, akc190, yab003, yka103, aac001, yka065,aae036,yka055,yka056,yka057,yka111,yka058,yka248,yka062,yke030,akc087,ykb037,yka316,akc021,ykc120,yab139,aac003,aac004,aac002,aac006,akc023,aab001,aab004,ykc280,ykc281,yka054,yae366,aka130,ykb065,mzjsr,mzjssj, akc090, yka120, yka122, yka368, yke025, aae001, yka900, astrjylsh, astrjyyzm, sickname, createdate,ybflag ) values('" + fph + "','"
                  + clinicInvoice.Id + "','" + akc190 + "','" + yab003 + "','" + yka103 + "','" + aac001 + "','" + DataTool.stringToDouble(yka065) + "','" + aae036 + "','" + DataTool.stringToDouble(yka055) + "','" + yka056 + "','" + yka057 + "','" + yka111 + "','" + yka058 + "','" + DataTool.stringToDouble(yka248) + "','" + DataTool.stringToDouble(yka062) + "','" + DataTool.stringToDouble(yke030)
                  + "','" + akc087 + "','" + ykb037 + "','" + yka316 + "','" + akc021 + "','" + ykc120 + "','" + yab139 + "','" + aac003 + "','" + aac004 + "','" + aac002 + "','" + aac006 + "','" + akc023 + "','" + aab001 + "','" + aab004 + "','" + ykc280 + "','" + ykc281 + "','" + yka054 + "','" + yae366 + "','" + zflb + "','" + zxshbxbf + "','" + ProgramGlobal.Username + "','" + BillSysBase.currDate() + "','" + akc090 + "','" + yka120 + "','" + yka122 + "','" + yka368 + "','" + yke025 + "','" + aae001 + "','" + yka900 + "','" + jylsh + "','" + jyyzm + "','" + personInfo.Swxm + "', NOW(),'1');";

            BllMain.Db.Update(sql_bak);
            string sql_ybflag = "";

            if (BllMain.Db.Update(sql2) == 0)
            {  //提交确认交易
                Confirm_in confirmIn = new Confirm_in();
                confirmIn.Astrjylsh = jylsh;//交易流水号
                confirmIn.Astrjyyzm = jyyzm;//交易验证码
                Confirm_out confirmOut = gzsybInterface.Confirm(confirmIn);
                if (confirmOut.AintAppcode < 0)
                {
                    sql_ybflag = "update gzsyb_mzfyb_bak set ybflag=1 where mtmzblstuffiid='" + clinicInvoice.Id + "'; "
                             + "update gzsyb_mzfyb set ybflag=1 where mtmzblstuffiid='" + clinicInvoice.Id + "' ";
                    BllMain.Db.Update(sql_ybflag);
                    message = "收费交易确定失败：" + confirmOut.AstrAppmsg;
                    return false;
                }
                sql_ybflag = "update gzsyb_mzfyb_bak set ybflag=2 where mtmzblstuffiid='" + clinicInvoice.Id + "'; "
                +"update gzsyb_mzfyb set ybflag=2 where mtmzblstuffiid='" + clinicInvoice.Id + "'; ";
                BllMain.Db.Update(sql_ybflag);
            }
            else
            { 
                //取消交易
                message += "数据库错误";
                Cancel_in cancelIn = new Cancel_in();
                cancelIn.Astrjylsh = jylsh;//交易流水号
                Cancel_out cancelOut = gzsybInterface.Cancel(cancelIn);
                if(cancelOut.AintAppcode < 0)
                {
                    sql_ybflag = "update gzsyb_mzfyb_bak set ybflag=1 where mtmzblstuffiid='" + clinicInvoice.Id + "' ;"
                         + "update gzsyb_mzfyb set ybflag=1 where mtmzblstuffiid='" + clinicInvoice.Id + "'; ";
                    BllMain.Db.Update(sql_ybflag);
                  
                    message += "收费交易取消失败：" + cancelOut.AstrAppmsg;
                    return false;
                }
                sql_ybflag = "update gzsyb_mzfyb_bak set ybflag=0 where mtmzblstuffiid='" + clinicInvoice.Id + "'; "
                        + "update gzsyb_mzfyb set ybflag=0 where mtmzblstuffiid='" + clinicInvoice.Id + "'; ";
                BllMain.Db.Update(sql_ybflag);
                  
                return false;
            }
            return true;
        }

        public bool doConfirm( Confirm_in confirmIn,ref string message)
        {
            //提交确认交易
            Confirm_out confirmOut = gzsybInterface.Confirm(confirmIn);
            if (confirmOut.AintAppcode < 0)
            {

                message = "收费交易确定失败：" + confirmOut.AstrAppmsg;
                return false;
            }
            string sql = "update insur_gzsybjylsh set stat =1 where astrjylsh=" + DataTool.addFieldBraces(confirmIn.Astrjylsh) + ";";
            BllMain.Db.Update(sql);
            return true;
        }
        public bool doCancel(Cancel_in cancelIn, ref string message)
        {
            //提交确认交易
            Cancel_out cancelOut = gzsybInterface.Cancel(cancelIn);
            if (cancelOut.AintAppcode < 0)
            {
                message = "收费交易取消失败：" + cancelOut.AstrAppmsg;
                return false;
            }
            string sql = "update insur_gzsybjylsh set stat =2 where astrjylsh" + DataTool.addFieldBraces(cancelIn.Astrjylsh) + ";";
            BllMain.Db.Update(sql);
            return true;
        }
         /// <summary>
        ///  结算费用明细
        /// </summary>
        /// <returns></returns>
        private string upLoadClinicAmount(string costdetIds)
        {
            string ret ="";
            string sql = "SELECT  COALESCE(sum(realfee),0) as amount from clinic_costdet where id in (" + costdetIds + ")";
            try
            {
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                ret = dt.Rows[0]["amount"].ToString();
            }
            catch (Exception e)
            {
                ret = "0";
            }
            return ret;
        }
        /// <summary>
        ///  结算费用明细
        /// </summary>
        /// <returns></returns>
        private string uploadClinCostdet(ClinicSettle cs, ClinicInvoice clinicInvoice, ref string retmesg)
        {
            retmesg = "";
            string jbr = ProgramGlobal.User_id;
            string jbrmc = ProgramGlobal.Username;
            string xmlBody = "";
            string sql = "select"
                       + " clinic_costdet.id "//记账流水号
                       + ",clinic_costdet.standcode"//
                       + ",clinic_costdet.item_id"//医院项目流水号
                       + ",clinic_costdet.itemfrom"
                       + ",clinic_costdet.name"//医院项目名称
                       + ",clinic_costdet.Spec"//规格
                       + ",clinic_costdet.unit"//最小计价单位
                       + ",clinic_costdet.Num"//数量
                       + ",clinic_costdet.prc"//实际价格
                       + ",clinic_costdet.realfee"//明细项目费用总额
                       + ",clinic_costdet.depart_id"//开单科室编码
                       + ",bas_depart.name as dptname"//开单科室名称
                       + ",bas_doctor.name as dctname"//开单医生姓名
                       + ",bas_doctor.practicecode"//开单医生医师资格证号
                       + ",clinic_costdet.exedep_id"//受单科室编码
                       + ",clinic_costdet.exedoctor_id"//受单医生编码
                       + ",clinic_costdet.chargedate"//明细发生时间
                       + ",cost_insurcross.insurcode"//医保目录id modify by wzw_ 20170627
                       + ",cost_insurcross.insurname"//医保目录id modify by wzw_ 20170627
                       +" from clinic_costdet "
                       +" left join bas_depart on clinic_costdet.depart_id = bas_depart.id"
                       +" left join bas_doctor on clinic_costdet.doctor_id = bas_doctor.id"
                       + " left join cost_insurcross on cost_insurcross.item_id= clinic_costdet.item_id and cost_insurcross.insuritemtype='3' and cost_insurcross.drug_factyitem_id=clinic_costdet.drug_factyitem_id"//医保目录id modify by wzw_ 20170627
                       + " where clinic_costdet.id in ( " + clinicInvoice.Clinic_costdet_ids + ")";
           
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            
            for(int i=0;i< dt.Rows.Count;i++)
            {
                string item_id = dt.Rows[i]["item_id"].ToString();
                String[] param = new String[27];
                param[0] = dt.Rows[i]["id"].ToString();
                param[1] = item_id;
                param[2] = dt.Rows[i]["name"].ToString();
                param[3] = dt.Rows[i]["insurcode"].ToString();//医保通用项目编码
                param[4] = dt.Rows[i]["insurname"].ToString();//医保通用项目名称
                if (string.IsNullOrEmpty(param[3]) || string.IsNullOrWhiteSpace(param[3]))
                {
                    retmesg += dt.Rows[i]["name"].ToString() + ",";
                }
                param[5] = dt.Rows[i]["Num"].ToString();
                param[6] = dt.Rows[i]["prc"].ToString();
                param[7] = dt.Rows[i]["realfee"].ToString();
                param[8] = dt.Rows[i]["depart_id"].ToString();
                param[9] = dt.Rows[i]["dptname"].ToString();
                param[10] = dt.Rows[i]["practicecode"].ToString();
                param[11] = dt.Rows[i]["dctname"].ToString();
                param[12] = dt.Rows[i]["exedep_id"].ToString();//受单科室编码
                //param[13] = dt_rcpdet.Rows[0]["dptname"].ToString();//受单科室名称
                param[14] = dt.Rows[i]["exedoctor_id"].ToString();//受单医生编码
                //param[15] = dt_rcpdet.Rows[0]["dctname"].ToString();//受单医生姓名
                param[16] = clinicInvoice.Chargedate; //时间
                param[17] = ProgramGlobal.Username;
                param[18] = clinicInvoice.Chargedate;
                param[19] = "";
                param[20] = "";
                param[21] = dt.Rows[i]["unit"].ToString();
                param[22] = dt.Rows[i]["Spec"].ToString();
                param[23] = "";   
                param[24] = "";
                param[25] = "";
                param[26] = "1";
                xmlBody += cs.xmlBody(param);
            }
            return xmlBody;
        }




        /// <summary>
        /// 下载服务项目目录
        /// </summary>
        /// <param name="Mtmzblstuff_iid"></param>
        /// <param name="zfy"></param>
        /// <returns></returns>
        /// 
        public bool xzfwxmml_new(string riqi)
        {
            GetServiceItem ihh = new GetServiceItem();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "91";
            String[] param = new String[2];
            param[0] = riqi;
            param[1] = "d:\\szydybfwml.txt";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                return false;
            }
            string xml = callOut.Astrjyscxml;
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            DataTable dt = ds.Tables["output"];

            StreamReader objReader = new StreamReader("d:\\szydybfwml.txt", System.Text.Encoding.Default);
            String sLine = "";
            List<String> lineList = new List<String>();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine != null)
                    lineList.Add(sLine);
            }
            objReader.Close();
            string s = "";
            for (int i = 0; i < lineList.Count; i++)
            {
                string _data = lineList[i];
                string[] _d2 = _data.Split('\t');

                string sql2 = "select yka002 from gzydyb_ypzlml where yka002='" + _d2[0] + "'";
                DataTable dt2 = BllMain.Db.Select(sql2).Tables[0]; 
                if (dt2.Rows.Count == 0)
                {
                    s += "INSERT INTO gzydyb_ypzlml(";
                    s += "yka002, yka003, yae036, yka001, ykd110, yka389, yka401, yka295, ";
                    s += "aka074, aka070, yaa027, yka007, yke100, yke054, yke103, aae013, ";
                    s += "yka096, yae375, yka284, yka233, yka601, yka603, yka604, yka606, ";
                    s += "yka609, yka459, yka096_lx, yka096_jm, yka459_jm, yka459_lx, yka096_tj, ";
                    s += "yka459_tj,aka101)     VALUES (";
                    s += "'" + _d2[0].Replace('\'', '’') + "',";
                    s += "'" + _d2[1].Replace('\'', '’') + "',";
                    s += "'" + _d2[2].Replace('\'', '’') + "',";
                    s += "'" + _d2[3].Replace('\'', '’') + "',";
                    s += "'" + _d2[4].Replace('\'', '’') + "',";
                    s += "'" + _d2[5].Replace('\'', '’') + "',";
                    s += "'" + _d2[6].Replace('\'', '’') + "',";
                    s += "'" + _d2[7].Replace('\'', '’') + "',";
                    s += "'" + _d2[8].Replace('\'', '’') + "',";
                    s += "'" + _d2[9].Replace('\'', '’') + "',";
                    s += "'" + _d2[10].Replace('\'', '’') + "',";
                    s += "'" + _d2[11].Replace('\'', '’') + "',";
                    s += "'" + _d2[12].Replace('\'', '’') + "',";
                    s += "'" + _d2[13].Replace('\'', '’') + "',";
                    s += "'" + _d2[14].Replace('\'', '’') + "',";
                    s += "'" + _d2[15].Replace('\'', '’') + "',";
                    s += "'" + _d2[16].Replace('\'', '’') + "',";
                    s += "'" + _d2[17].Replace('\'', '’') + "',";
                    s += "'" + _d2[18].Replace('\'', '’') + "',";
                    s += "'" + _d2[19].Replace('\'', '’') + "',";
                    s += "'" + _d2[20].Replace('\'', '’') + "',";
                    s += "'" + _d2[21].Replace('\'', '’') + "',";
                    s += "'" + _d2[22].Replace('\'', '’') + "',";
                    s += "'" + _d2[23].Replace('\'', '’') + "',";
                    s += "'" + _d2[24].Replace('\'', '’') + "',";
                    s += "'" + _d2[25].Replace('\'', '’') + "',";
                    s += "'" + _d2[26].Replace('\'', '’') + "',";
                    s += "'" + _d2[27].Replace('\'', '’') + "',";
                    s += "'" + _d2[28].Replace('\'', '’') + "',";
                    s += "'" + _d2[29].Replace('\'', '’') + "',";
                    s += "'" + _d2[30].Replace('\'', '’') + "',";
                    s += "'" + _d2[31].Replace('\'', '’') + "',";
                    s += "'" + _d2[32].Replace('\'', '’') + "');";
                }
                else
                {
                    s += "update gzydyb_ypzlml set ";
                    s += "yka003='" + _d2[1].Replace('\'', '’') + "',";
                    s += "yae036='" + _d2[2].Replace('\'', '’') + "',";
                    s += "yka001='" + _d2[3].Replace('\'', '’') + "',";
                    s += "ykd110='" + _d2[4].Replace('\'', '’') + "',";
                    s += "yka389='" + _d2[5].Replace('\'', '’') + "',";
                    s += "yka401='" + _d2[6].Replace('\'', '’') + "',";
                    s += "yka295='" + _d2[7].Replace('\'', '’') + "',";
                    s += "aka074='" + _d2[8].Replace('\'', '’') + "',";
                    s += "aka070='" + _d2[9].Replace('\'', '’') + "',";
                    s += "yaa027='" + _d2[10].Replace('\'', '’') + "',";
                    s += "yka007='" + _d2[11].Replace('\'', '’') + "',";
                    s += "yke100='" + _d2[12].Replace('\'', '’') + "',";
                    s += "yke054='" + _d2[13].Replace('\'', '’') + "',";
                    s += "yke103='" + _d2[14].Replace('\'', '’') + "',";
                    s += "aae013='" + _d2[15].Replace('\'', '’') + "',";
                    s += "yka096='" + _d2[16].Replace('\'', '’') + "',";
                    s += "yae375='" + _d2[17].Replace('\'', '’') + "',";
                    s += "yka284='" + _d2[18].Replace('\'', '’') + "',";
                    s += "yka233='" + _d2[19].Replace('\'', '’') + "',";
                    s += "yka601='" + _d2[20].Replace('\'', '’') + "',";
                    s += "yka603='" + _d2[21].Replace('\'', '’') + "',";
                    s += "yka604='" + _d2[22].Replace('\'', '’') + "',";
                    s += "yka606='" + _d2[23].Replace('\'', '’') + "',";
                    s += "yka609='" + _d2[24].Replace('\'', '’') + "',";
                    s += "yka459='" + _d2[25].Replace('\'', '’') + "',";
                    s += "yka096_lx='" + _d2[26].Replace('\'', '’') + "',";
                    s += "yka096_jm='" + _d2[27].Replace('\'', '’') + "',";
                    s += "yka459_jm='" + _d2[28].Replace('\'', '’') + "',";
                    s += "yka459_lx='" + _d2[29].Replace('\'', '’') + "',";
                    s += "yka096_tj='" + _d2[30].Replace('\'', '’') + "',";
                    s += "yka459_tj='" + _d2[31].Replace('\'', '’') + "',";
                    s += "aka101='" + _d2[32].Replace('\'', '’') + "'";
                    s += " where yka002='" + _d2[0] + "';";
                }
                if (!s.Equals(""))
                {
                    int n = BllMain.Db.Update(s);
                    s = "";
                    if (n == -1)
                    {
                     
                        return false;
                    }
                }
              }         
            return true;
        }



        /// <summary>
        /// 下载服务项目目录
        /// </summary>
        /// <param name="Mtmzblstuff_iid"></param>
        /// <param name="zfy"></param>
        /// <returns></returns>
        /// 
        public bool xzfwxmml(string riqi)
        {
            GetServiceItem ihh = new GetServiceItem();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "91";
            String[] param = new String[2];
            param[0] = riqi;
            param[1] = "d:\\szydybfwml.txt";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
            Call_out callOut = null;
            try
            {
                 callOut = gzsybInterface.Call(callIn);
            }
            catch (Exception ex)
            {
                return false;
            }
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "下载服务目录错误信息");
                return false;
            }
            string xml = callOut.Astrjyscxml;
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            DataTable dt = ds.Tables["output"];
            //string sql = "delete from gzydyb_ypzlml";
            //hisdb.Update(sql);
            StreamReader objReader = new StreamReader("d:\\szydybfwml.txt", System.Text.Encoding.Default);
            String sLine = "";
            List<String> lineList = new List<String>();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine != null)
                    lineList.Add(sLine);
            }
            objReader.Close();
            string s = "";
            for (int i = 0; i < lineList.Count; i++)
            {
                string _data = lineList[i];
                string[] _d2 = _data.Split('\t');

                string sql2 = "select insurcode from cost_insuritem where insurcode='" + _d2[0] + "' and Insuritemtype='3'";
                DataTable dt2 = BllMain.Db.Select(sql2).Tables[0];
                string ykd110 = _d2[4].Replace('\'', '’').Trim();
                string insurclass = "";
                if (ykd110.Equals("01"))
                {
                    insurclass = "甲";
                }
                else if (ykd110.Equals("02"))
                {
                    insurclass = "乙";
                }
                else if (ykd110.Equals("03"))
                {
                    insurclass = "丙";
                }
                if (dt2.Rows.Count == 0)
                {
                   
                   s += "INSERT INTO cost_insuritem("
                      + "insurcode"                   //yka002医保通用码
                      + ",name"                  //yka003医 保 通 用项目名称
                      + ",updateat"                  //yae036变更时间
                      + ",insurclass"                  //ykd110, 01:甲 , 02:乙, 03:丙
                      + ",pincode"                  //yka389, 拼音助记码
                      + ",unit"                  //yka295
                      + ",spec"                  //aka074 规 格
                      + ",dosageform"                  //aka070剂型名称
                      + ",standcode"                  //yaa027物价编码
                      + ",statenum"                  //yke100项目内涵 国药准字
                      +",limituse"                  //yke054除外内容
                      + ",memo"                  //yke103项目说明 
                      +",ratioclin"                  //yka096门诊报销比例
                       //  +"siglecharge"                  // yka233,
                      +",drugfactory"                  //yka601生产厂家
                      +",insuritemtype )     VALUES ("
                    + "'" + _d2[0].Replace('\'', '’') + "',"//yka002医保通用码
                    + "'" + _d2[1].Replace('\'', '’') + "',"//yka003医 保 通 用项目名称
                    + "'" + _d2[2].Replace('\'', '’') + "',"//yae036变更时间
                    //+ "'" + _d2[3].Replace('\'', '’') + "',"
                    + "'" + insurclass + "',"
                    + "'" + _d2[5].Replace('\'', '’') + "',"//yka389拼 音 助 记码
                    //+ "'" + _d2[6].Replace('\'', '’') + "',"
                    + "'" + _d2[7].Replace('\'', '’') + "',"//yka295最 小 计 价单位
                    + "'" + _d2[8].Replace('\'', '’') + "',"//aka074 规 格
                    + "'" + _d2[9].Replace('\'', '’') + "',"//aka070剂型名称
                    + "'" + _d2[10].Replace('\'', '’') + "',"//yaa027物价编码
                    //+ "'" + _d2[11].Replace('\'', '’') + "',"
                    + "'" + _d2[12].Replace('\'', '’') + "',"//yke100项目内涵 国药准字
                    //+ "'" + _d2[13].Replace('\'', '’') + "',"
                    + "'" + _d2[14].Replace('\'', '’') + "',"//yke054除外内容
                    + "'" + _d2[15].Replace('\'', '’') + "',"//yke103项目说明
                    //+ "'" + _d2[16].Replace('\'', '’') + "',"
                    + "'" + _d2[17].Replace('\'', '’') + "',"//yka096门诊报销比例
                    //+ "'" + _d2[18].Replace('\'', '’') + "',"
                    //+ "'" + _d2[19].Replace('\'', '’') + "',"
                   // + "'" + _d2[20].Replace('\'', '’') + "',"
                    + "'" + _d2[21].Replace('\'', '’') + "',"//yka601生产厂家
                    //+ "'" + _d2[22].Replace('\'', '’') + "',"
                    //+ "'" + _d2[23].Replace('\'', '’') + "',"
                    //+ "'" + _d2[24].Replace('\'', '’') + "',"
                    //+ "'" + _d2[25].Replace('\'', '’') + "',"
                    //+ "'" + _d2[26].Replace('\'', '’') + "',"
                    //+ "'" + _d2[27].Replace('\'', '’') + "',"
                    //+ "'" + _d2[28].Replace('\'', '’') + "',"
                    //+ "'" + _d2[29].Replace('\'', '’') + "',"
                    //+ "'" + _d2[30].Replace('\'', '’') + "',"
                    //+ "'" + _d2[31].Replace('\'', '’') + "',"
                    //+ "'" + _d2[32].Replace('\'', '’') + "')"
                    + "'3')";
                }
                else
                {
                    s += "update cost_insuritem set "
                     + " insurcode="+ "'" + _d2[0].Replace('\'', '’') + "'"//yka002医保通用码
                     + ",name="    + "'" + _d2[1].Replace('\'', '’') + "'"//yka003医 保 通 用项目名称
                     + ",updateat="+ "'" + _d2[2].Replace('\'', '’') + "'"//yae036变更时间
                        //+ "'" + _d2[3].Replace('\'', '’') + "',"
                     + ",insurclass="+ "'" + insurclass + "'"
                     + ",pincode=" + "'" + _d2[5].Replace('\'', '’') + "'"//yka389拼 音 助 记码
                        //+ "'" + _d2[6].Replace('\'', '’') + "',"
                     + ",unit="      + "'" + _d2[7].Replace('\'', '’') + "'"//yka295最 小 计 价单位
                     + ",spec="      + "'" + _d2[8].Replace('\'', '’') + "'"//aka074 规 格
                     + ",dosageform="+ "'" + _d2[9].Replace('\'', '’') + "'"//aka070剂型名称
                     + ",standcode=" + "'" + _d2[10].Replace('\'', '’') + "'"//yaa027物价编码
                        //+ "'" + _d2[11].Replace('\'', '’') + "',"
                     + ",statenum="+ "'" + _d2[12].Replace('\'', '’') + "'"//yke100项目内涵 国药准字
                        //+ "'" + _d2[13].Replace('\'', '’') + "',"
                     +",limituse="  + "'" + _d2[14].Replace('\'', '’') + "'"//yke054除外内容
                     + ",memo="   + "'" + _d2[15].Replace('\'', '’') + "'"//yke103项目说明
                        //+ "'" + _d2[16].Replace('\'', '’') + "',"
                     +",ratioclin="   + "'" + _d2[17].Replace('\'', '’') + "'"//yka096门诊报销比例
                        //+ "'" + _d2[18].Replace('\'', '’') + "',"
                        //+ "'" + _d2[19].Replace('\'', '’') + "',"
                        // + "'" + _d2[20].Replace('\'', '’') + "',"
                     +",drugfactory=" + "'" + _d2[21].Replace('\'', '’') + "'"//yka601生产厂家
                    //+ "yka604='" + _d2[22].Replace('\'', '’') + "',"
                    //+ "yka606='" + _d2[23].Replace('\'', '’') + "',"
                    //+ "yka609='" + _d2[24].Replace('\'', '’') + "',"
                    //+ "yka459='" + _d2[25].Replace('\'', '’') + "',"
                    //+ "yka096_lx='" + _d2[26].Replace('\'', '’') + "',"
                    //+ "yka096_jm='" + _d2[27].Replace('\'', '’') + "',"
                    //+ "yka459_jm='" + _d2[28].Replace('\'', '’') + "',"
                    //+ "yka459_lx='" + _d2[29].Replace('\'', '’') + "',"
                    //+ "yka096_tj='" + _d2[30].Replace('\'', '’') + "',"
                    //+ "yka459_tj='" + _d2[31].Replace('\'', '’') + "',"
                    //+ "aka101='" + _d2[32].Replace('\'', '’') + "'"
                     + " where insurcode='" + _d2[0] + "' and Insuritemtype='3'";
                }
                if (!s.Equals(""))
                {
                    int n = BllMain.Db.Update(s);
                    s = "";
                    if (n == -1)
                    {
                        MessageBox.Show("数据库错误", "错误信息");
                        return false;
                    }
                }

            }
            if (!s.Equals(""))
            {
                int n = BllMain.Db.Update(s);
                if (n == -1)
                {
                    MessageBox.Show("数据库错误", "错误信息");
                    return false;
                }
            }
            MessageBox.Show("更新成功", "信息");
            return true;
        }
        /// <summary>
        /// //住院结算打单
        /// </summary>
        /// <param name="mtzyjliid"></param>
        /// <returns></returns>
        public bool Zyjsddy(string mtzyjliid)
        {
            string sqljsdd = "select akc190,yab003,aka130,yka103,ykb065 from insur_gzsyb_ryinfo where mtzyjliid=" + mtzyjliid;
            DataTable sqldd = BllMain.Db.Select(sqljsdd).Tables[0];
            String[] param = new String[6];
            param[0] = sqldd.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = sqldd.Rows[0]["yab003"].ToString();//分中心编号
            param[2] = sqldd.Rows[0]["aka130"].ToString();//支付类别
            param[3] = "";//医疗人员类别
            param[4] = sqldd.Rows[0]["yka103"].ToString();//结算编号
            param[5] = sqldd.Rows[0]["ykb065"].ToString();//社会保险办法
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
      
    }
}
