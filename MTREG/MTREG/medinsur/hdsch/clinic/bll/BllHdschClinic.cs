using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdyb.clinic.bo;
using MTHIS.common;
using System.Data;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdsch.bll;

namespace MTREG.medinsur.hdsch.clinic.bll
{
    class BllHdschClinic
    {
        /// <summary>
        /// 插入邯郸市医保信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int clinicInsurInfo(string reginfo, string clinic_Invoice_id)
        {
            string opstat = "OO";//医保信息OO
            string id = BillSysBase.nextId("clinic_insurinfo");
            string sql = "insert into clinic_insurinfo (id,clinic_Invoice_id"
                + ",registinfo"
                + ",opstat)values(" + DataTool.addFieldBraces(id)
                                     + "," + DataTool.addFieldBraces(clinic_Invoice_id)
                                     + "," + DataTool.addFieldBraces(reginfo)
                                     + "," + DataTool.addFieldBraces(opstat)
                                     + ")";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 查询邯郸医保信息
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable hdschinfo(string clinic_Invoice_id)
        {
            DataTable dt = new DataTable();
            string sql = "select registinfo,settinfo from clinic_insurinfo where clinic_Invoice_id=" + DataTool.addFieldBraces(clinic_Invoice_id);
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
        /// 插入/更改中软农合出院结账信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int accountInfo(string settinfo, string midsettinfo, string clinic_Invoice_id)
        {
            string sql = "update clinic_insurinfo set settinfo=" + DataTool.addFieldBraces(settinfo)
                                    + ",midsettinfo=" + DataTool.addFieldBraces(midsettinfo)
                                    + " where clinic_Invoice_id=" + DataTool.addFieldBraces(clinic_Invoice_id)
                                     + ")";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 修改医保信息状态
        /// </summary>
        /// <param name="accountinfo"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int upopstat(string opstat, string ihsp_id)
        {
            string sql = "update clinic_insurinfo set opstat=" + DataTool.addFieldBraces(opstat)
                                    + " where clinic_Invoice_id=" + DataTool.addFieldBraces(ihsp_id)
                                     + ")";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 传输病人就诊信息
        /// </summary>
        /// <returns></returns>
        public bool insurReg(InsurInfo insurinfo, string reg_id)
        {
            string search_sql = "select count(*) from KC21 where AKC190=" + DataTool.addFieldBraces(reg_id);
            string sql_slt = "select "
                        + " billcode"
                        + ",regdate"
                        + ",doctor_id"
                        + ",depart_id"
                        + " from register"
                        + " where id = " + DataTool.addFieldBraces(reg_id);
            DataTable dt = BllMain.Db.Select(sql_slt).Tables[0];
            string sql_ist = "insert into KC21 ("
                       + " AKC190"
                       + ",CKC502"
                       + ",AAC003"
                       + ",AAC001"
                       + ",AAB001"
                       + ",AAE073"
                       + ",AKA130"
                       + ",AKC192"
                       + ",AKC193"
                       + ",AAE011"
                       + ",AAE036"
                       + ",zkc271"
                       + ",zkc272 ) values ("
                       + DataTool.addFieldBraces(dt.Rows[0]["billcode"].ToString())
                       + "," + DataTool.addFieldBraces(insurinfo.Iccardid)
                       + "," + DataTool.addFieldBraces(insurinfo.Name)
                       + "," + DataTool.addFieldBraces(insurinfo.PersonalNum)
                       + "," + DataTool.addFieldBraces(insurinfo.Companynum)
                       + "," + DataTool.addFieldBraces(insurinfo.Approvenum)
                       + "," + DataTool.addFieldBraces(insurinfo.Ihsptype)
                       + "," + DataTool.addFieldBraces(dt.Rows[0]["regdate"].ToString())
                       + "," + DataTool.addFieldBraces(insurinfo.Clinicicd)
                       + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
                       + "," + DataTool.addFieldBraces(BillSysBase.currDate())
                       + "," + DataTool.addFieldBraces(dt.Rows[0]["doctor_id"].ToString())
                       + "," + DataTool.addFieldBraces(dt.Rows[0]["depart_id"].ToString())
                       + " );";
            DataSet ds = BllMain.InsurDb.Select(search_sql);
            int result = -1;
            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 0)
            {
                result = BllMain.InsurDb.Update(sql_ist);
            }         
            upsjcs(dt.Rows[0]["billcode"].ToString());
            if (result == 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 修改kc21传输标志，置为1
        /// </summary>
        /// <param name="zyh"></param>
        private void upsjcs(string zyh)
        {
            String sql = "UPDATE KC21 SET CKC126 =1 WHERE AKC190='" + zyh + "';";
            BllMain.InsurDb.Update(sql);
        }

        /// <summary>
        /// 费用信息传送到KC22
        /// </summary>
        /// <returns></returns>
        public int costdetTransfer(string cliniCode, string costdetIds,string grbm)
        {
            Hdsch hdsch = new Hdsch();
            DataTable dt = new DataTable();
            string sql_slt = "select "
                           + " clinic_costdet.id"
                           + ",clinic_cost.billcode"
                           + ",clinic_cost.rcpdate"
                           + ",clinic_costdet.standcode"
                           + ",clinic_costdet.name"
                           + ",insur_itemfrom.insurcode"
                           + ",clinic_costdet.prc"
                           + ",clinic_costdet.num"
                           + ",clinic_costdet.fee"
                           + ",clinic_costdet.spec"
                           + ",clinic_costdet.unit"
                           + ",case insur_itemfrom.insurcode when '1' then '1' when '2' then '3' end as ckc048"
                           + " from clinic_costdet"
                           + " left join clinic_cost on clinic_cost.id = clinic_costdet.clinic_cost_id"
                           + " left join insur_itemfrom on insur_itemfrom.itemtype_id = clinic_costdet.itemtype_id"
                           + " and insur_itemfrom.cost_insurtype_id = (select id from cost_insurtype where keyname = "
                           + DataTool.addFieldBraces(CostInsurtypeKeyname.HDSYB.ToString()) + ")"
                           + " where clinic_costdet.id in (" + costdetIds
                           + " )";
            dt = BllMain.Db.Select(sql_slt).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string merge_sql = "";
                string upsql = "";
                string insurclass = "";
                string selffee = "";
                string currDate = BillSysBase.currDate().Substring(0, 9);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //读取药品信息
                    if (dt.Rows[0]["insurcode"].ToString() == Convert.ToString((int)InsurEnum.Yzc.YP))
                    {
                        Dqypxx_out dqypxx_out = new Dqypxx_out();
                        string drugcode = Convert.ToString((int)InsurEnum.Yzc.YP);
                        int flag = hdsch.dqypxx(dqypxx_out, drugcode, 0, grbm);
                        if (flag < 0)
                        {
                            //读取药品信息失败
                            return -1;
                        }
                        insurclass = dqypxx_out.Fydj;
                        selffee = dqypxx_out.Mzzfbl;
                    }
                    //读取诊疗信息
                    if (dt.Rows[0]["insurcode"].ToString() == Convert.ToString((int)InsurEnum.Yzc.ZL))
                    {
                        Dqzlxx_out dqzlxx_out = new Dqzlxx_out();
                        string zlcode = Convert.ToString((int)InsurEnum.Yzc.ZL);
                        int flag = hdsch.dqzlxx(zlcode, dqzlxx_out, 0,grbm);
                        if (flag < 0)
                        {
                            //读取诊疗信息失败
                            return -2;
                        }
                        insurclass = dqzlxx_out.Fydj;
                        selffee = dqzlxx_out.Mzzfbl;
                    }
                    merge_sql += "insert into KC22 ("
                        + " AKC190"
                        + ",AKC220"
                        + ",AAE072"
                        + ",AKC221"
                        + ",AKC515"
                        + ",AKC223"
                        + ",AKC224"
                        + ",AKC225"
                        + ",AKC226"
                        + ",AKC227"
                        + ",AAE040"
                        + ",ZKA100"
                        + ",ZKA101"
                        + ",AAE073"
                        + ",CKC048"
                        + ",CKC126"
                        + ",CKC125) values ("
                        + DataTool.addFieldBraces(cliniCode)
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["billcode"].ToString())
                        + "," + DataTool.addFieldBraces(cliniCode)
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["rcpdate"].ToString())
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["standcode"].ToString())
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["name"].ToString())
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["insurcode"].ToString())
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["prc"].ToString())
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["num"].ToString())
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["fee"].ToString())
                        + "," + DataTool.addFieldBraces(currDate)
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["spec"].ToString())
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["unit"].ToString())
                        + "," + DataTool.addFieldBraces("")
                        + "," + DataTool.addFieldBraces(dt.Rows[i]["ckc048"].ToString())
                        + "," + "0"
                        + "," + "0"
                        + " );";
                    double selfScale = double.Parse(selffee);
                    upsql += "update clinic_costdet set insursync='Y' , insurclass=" + DataTool.addFieldBraces(insurclass)
                          + ",selffee = (realfee *" + selffee + "),insurefee = (realfee-selffee) where id=" + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString());
                }
                int info = BllMain.InsurDb.Update(merge_sql);
                if (info >= 0)
                {
                    BllMain.InsurDb.Update(upsql);
                }
                else
                {
                    //传入中间表失败
                    return -3;
                }
                Ybsjcs_in ryxx = new Ybsjcs_in();
            ryxx.Mzzyh = cliniCode;
            ryxx.Grbh = grbm;
            if (hdsch.ybsjcs(ryxx, grbm) < 0)
            {
                //医保传输失败
                return -7;
            }
                return 0;
            }
            //无可传输项
            return -4;
        }

        /// <summary>
        /// 医疗类别
        /// </summary>
        /// <returns></returns>
        public DataTable getMediTypeInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select insurcode as id,name from insur_hdsyb_aka130 where registkind = 'CLIN' and isstop = 'N'";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// 审批类别
        /// </summary>
        /// <returns></returns>
        public DataTable getApproTypeInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select insurcode as id,name from insur_hdsyb_akc170 where isstop = 'N'";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            { }
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
        /// 获取门诊疾病
        /// </summary>
        /// <returns></returns>
        public DataTable getClinicDisease(string pincode)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select id,name,illcode  from cost_insurillness where pincode like '%" + pincode.Trim() + "%' ";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
    }
}
