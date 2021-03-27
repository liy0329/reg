using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.clinic.bo;
using MTREG.common;
//using MTREG.medinsur.hdyb.bo;
//using MTREG.medinsur.hdyb.bll;
//using MTREG.medinsur.hdyb.clinic.bo;

namespace MTREG.medinsur.sjzsyb.clinic.bll
{
    class BllClinicMedinsr
    {
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
        /// 获取门诊疾病
        /// </summary>
        /// <returns></returns>
        public DataTable getClinicDisease(string pincode)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select illcode as id,name as name from insur_illness where 1=1 and illcode like '%" + pincode + "%' or name like '%" + pincode + "%' or pincode like '%" + pincode + "%' ";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
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
        /// 获取医保类型关键字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getInsurtypeKeyname(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select cost_insurtype.keyname as keyname "
                              + " from bas_patienttype "
                              + " left join cost_insurtype on cost_insurtype.id=bas_patienttype.cost_insurtype_id"
                              + " where bas_patienttype.id= " + DataTool.addFieldBraces(id);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string keyname = datatable.Rows[0]["keyname"].ToString();
                return keyname;
            }
            else
            {
                return "";
            }
        }
         ///<summary>
         ///传输病人就诊信息
         ///</summary>
         ///<returns></returns>
        //public bool insurReg(InsurInfo insurinfo,string reg_id)
        //{
        //    string search_sql = "select count(*) from KC21 where AKC190=" + DataTool.addFieldBraces(reg_id);
        //    string sql_slt = "select "
        //                + " billcode"
        //                + ",regdate"
        //                + ",doctor_id"
        //                + ",depart_id"
        //                + " from register"
        //                + " where id = " + DataTool.addFieldBraces(reg_id);
        //    DataTable dt = BllMain.Db.Select(sql_slt).Tables[0];
        //    string sql_ist = "insert into KC21 ("
        //               + " AKC190"
        //               + ",CKC502"
        //               + ",AAC003"
        //               + ",AAC001"
        //               + ",AAB001"
        //               + ",AAE073"
        //               + ",AKA130"
        //               + ",AKC192"
        //               + ",AKC193"
        //               + ",AAE011"
        //               + ",AAE036"
        //               + ",zkc271"
        //               + ",zkc272 ) values ("
        //               + DataTool.addFieldBraces(dt.Rows[0]["billcode"].ToString())
        //               + "," + DataTool.addFieldBraces(insurinfo.Iccardid)
        //               + "," + DataTool.addFieldBraces(insurinfo.Name)
        //               + "," + DataTool.addFieldBraces(insurinfo.PersonalNum)
        //               + "," + DataTool.addFieldBraces(insurinfo.Companynum)
        //               + "," + DataTool.addFieldBraces(insurinfo.Approvenum)
        //               + "," + DataTool.addFieldBraces(insurinfo.Ihsptype)
        //               + "," + DataTool.addFieldBraces(dt.Rows[0]["regdate"].ToString())
        //               + "," + DataTool.addFieldBraces(insurinfo.Clinicicd)
        //               + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
        //               + "," + DataTool.addFieldBraces(BillSysBase.currDate())
        //               + "," + DataTool.addFieldBraces(dt.Rows[0]["doctor_id"].ToString())
        //               + "," + DataTool.addFieldBraces(dt.Rows[0]["depart_id"].ToString())
        //               + " );";
        //    DataSet ds = BllMain.InsurDb.Select(search_sql);
        //    int result = -1;
        //    if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 0)
        //    {
        //        result = BllMain.InsurDb.Update(sql_ist);
        //    }
        //    upsjcs(dt.Rows[0]["billcode"].ToString());
        //    if (result == 0)
        //        return true;
        //    else
        //        return false;
        //}
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
        //public int costdetTransfer(string cliniCode, string costdetIds,string insurtypeKeyname)
        //{
        //    Ybjk ybjk = new Ybjk();
        //    string sql = "select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(insurtypeKeyname);
        //    DataTable dt_insurtype = BllMain.Db.Select(sql).Tables[0];
        //    string insurtypeid = dt_insurtype.Rows[0]["id"].ToString();
        //    DataTable dt = new DataTable();
        //    string sql_slt = "select "
        //                   + " clinic_costdet.id"
        //                   + ",clinic_cost.billcode"
        //                   + ",clinic_cost.rcpdate"
        //                   + ",clinic_costdet.item_id"
        //                   + ",clinic_costdet.standcode"
        //                   + ",clinic_costdet.name"
        //                   + ",insur_itemfrom.insurcode"
        //                   + ",clinic_costdet.prc"
        //                   + ",clinic_costdet.num"
        //                   + ",clinic_costdet.fee"
        //                   + ",clinic_costdet.spec"
        //                   + ",clinic_costdet.unit"
        //                   + ",case insur_itemfrom.insurcode when '1' then '1' when '2' then '3' end as ckc048"
        //                   + " from clinic_costdet"
        //                   + " left join clinic_cost on clinic_cost.id = clinic_costdet.clinic_cost_id"
        //                   + " left join insur_itemfrom on insur_itemfrom.itemtype_id = clinic_costdet.itemtype_id"
        //                   + " and insur_itemfrom.cost_insurtype_id = (select id from cost_insurtype where keyname = "
        //                   + DataTool.addFieldBraces(CostInsurtypeKeyname.HDSYB.ToString())+ ")"
        //                   + " where clinic_costdet.id in (" + costdetIds
        //                   + " )";
        //    dt = BllMain.Db.Select(sql_slt).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        string merge_sql = "";
        //        string upsql = "";
        //        string insurclass = "";
        //        string selffee = "";
        //        string currDate = BillSysBase.currDate().Substring(0,9);
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string itemid = dt.Rows[i]["item_id"].ToString();
        //            string insuritemid = BillSysBase.nextId("cost_insuritem");
        //            string insurcrossid = BillSysBase.nextId("cost_insurcross");
        //            string selectsql = "select cost_insuritem.insurclass"
        //                             + " from cost_insurcross"
        //                             + " left join cost_insuritem on cost_insuritem.id = cost_insurcross.cost_insuritem_id"
        //                             + " where cost_insurcross.cost_insurtype_id = " + DataTool.addFieldBraces(insurtypeid)
        //                             + " and cost_insurcross.item_id = " + DataTool.addFieldBraces(itemid);
        //            DataTable dtselect = BllMain.Db.Select(selectsql).Tables[0];
        //            if (dtselect.Rows.Count > 0)
        //            {
        //                insurclass = dtselect.Rows[0]["insurclass"].ToString();
        //            }
        //            else
        //            {
        //                //读取药品信息
        //                if (dt.Rows[0]["insurcode"].ToString() == Convert.ToString((int)InsurEnum.Yzc.YP))
        //                {
        //                    Dqypxx_out dqypxx_out = new Dqypxx_out();
        //                    string drugcode = Convert.ToString((int)InsurEnum.Yzc.YP);
        //                    int flag = ybjk.dqypxx(dqypxx_out, drugcode, 0);
        //                    if (flag < 0)
        //                    {
        //                        //读取药品信息失败
        //                        return -1;
        //                    }
        //                    insurclass = dqypxx_out.Fydj;
        //                    selffee = dqypxx_out.Mzzfbl;
        //                }
        //                //读取诊疗信息
        //                if (dt.Rows[0]["insurcode"].ToString() == Convert.ToString((int)InsurEnum.Yzc.ZL))
        //                {
        //                    Dqzlxx_out dqzlxx_out = new Dqzlxx_out();
        //                    string zlcode = Convert.ToString((int)InsurEnum.Yzc.ZL);
        //                    int flag = ybjk.dqzlxx(zlcode, dqzlxx_out, 0);
        //                    if (flag < 0)
        //                    {
        //                        //读取诊疗信息失败
        //                        return -2;
        //                    }
        //                    insurclass = dqzlxx_out.Fydj;
        //                    selffee = dqzlxx_out.Mzzfbl;
        //                }
        //                string sqlin = "insert into cost_insuritem( id"
        //                                  + ",cost_insurtype_id"
        //                                  + ",name"
        //                                  + ",pincode"
        //                                  + ",insurcode"
        //                                  + ",itemfrom"
        //                                  + ",insurclass) values (" + DataTool.addFieldBraces(insuritemid)
        //                                  + "," + DataTool.addFieldBraces(insurtypeid)
        //                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["name"].ToString())
        //                                  + "," + DataTool.addFieldBraces(GetData.GetChineseSpell(dt.Rows[i]["name"].ToString()))
        //                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["insurcode"].ToString())
        //                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["ckc048"].ToString())
        //                                  + "," + DataTool.addFieldBraces(insurclass)
        //                                  + ");";
        //                if (BllMain.Db.Update(sqlin) < 0)
        //                {
        //                    //添加目录表失败！
        //                    return -5;
        //                }
        //                string sqlin1 = "insert into cost_insurcross( id "
        //                              + ",cost_insurtype_id"
        //                              + ",item_id"
        //                              + ",cost_insuritem_id) values (" + DataTool.addFieldBraces(insurcrossid)
        //                              + "," + DataTool.addFieldBraces(insurtypeid)
        //                              + "," + DataTool.addFieldBraces(itemid)
        //                              + "," + DataTool.addFieldBraces(insuritemid)
        //                              + ");";
        //                if (BllMain.Db.Update(sqlin1) < 0)
        //                {
        //                    //添加对照表失败！
        //                    return -6;
        //                }
        //            }
        //            merge_sql += "insert into KC22 ("
        //                + " AKC190"
        //                + ",AKC220"
        //                + ",AAE072"
        //                + ",AKC221"
        //                + ",AKC515"
        //                + ",AKC223"
        //                + ",AKC224"
        //                + ",AKC225"
        //                + ",AKC226"
        //                + ",AKC227"
        //                + ",AAE040"
        //                + ",ZKA100"
        //                + ",ZKA101"
        //                + ",AAE073"
        //                + ",CKC048"
        //                + ",CKC126"
        //                + ",CKC125) values ("
        //                + DataTool.addFieldBraces(cliniCode)
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["billcode"].ToString())
        //                + "," + DataTool.addFieldBraces(cliniCode)
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["rcpdate"].ToString())
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["standcode"].ToString())
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["name"].ToString())
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["insurcode"].ToString())
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["prc"].ToString())
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["num"].ToString())
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["fee"].ToString())
        //                + "," + DataTool.addFieldBraces(currDate)
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["spec"].ToString())
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["unit"].ToString())
        //                + "," + DataTool.addFieldBraces("")
        //                + "," + DataTool.addFieldBraces(dt.Rows[i]["ckc048"].ToString())
        //                + "," + "0"
        //                + "," + "0"
        //                + " );";
        //         //   double selfScale = double.Parse(selffee);
        //        //    upsql += "update clinic_costdet set insursync='Y' , insurclass=" + DataTool.addFieldBraces(insurclass)
        //        //          + ",selffee = (realfee *" + selffee + "),insurefee = (realfee-selffee) where id=" + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString());
        //            upsql = "update clinic_costdet set insursync='Y' , insurclass=" + DataTool.addFieldBraces(insurclass)
        //                  + " where id = " + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString());
        //        }
        //        int info=BllMain.InsurDb.Update(merge_sql);
        //        if (info >= 0)
        //        {
        //            BllMain.InsurDb.Update(upsql);
        //        }
        //        else
        //        {
        //            //传入中间表失败
        //            return -3;
        //        }
        //        return 0;
        //    }
        //    //无可传输项
        //    return -4;
        //}
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

    }
}
