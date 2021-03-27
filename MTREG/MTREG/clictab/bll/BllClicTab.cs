using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.common;
using MTREG.common;
using MTHIS.main.bll;
using MTREG.clintab.bo;


namespace MTREG.clintab.bll
{
    class BllClicTab
    {
        /// <summary>
        /// 获取医生姓名
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public string getDoctorName(string doctor)
        {
            string doc = "select name from bas_doctor where id = " + DataTool.addFieldBraces(doctor);
            DataTable datatable = BllMain.Db.Select(doc).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string doct = datatable.Rows[0]["name"].ToString();
                return doct;
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 门诊班结记录是否存在
        /// </summary>
        /// <returns></returns>
        public bool clinicDutyIshave(string settleby)
        {
            string sql = "select * from clinictab_duty"
             + " where settleby=" + DataTool.addFieldBraces(settleby)
             +" order by settledate desc limit 1";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 门诊日结记录是否存在
        /// </summary>
        /// <returns></returns>
        public bool clinicTabIshave()
        {
            string sql = "select * from clinictab_day";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 门诊日结初始化
        /// </summary>
        /// <param name="datatime"></param>
        /// <returns></returns>
        public int clinicTabinit(string datatime)
        {
            string id=BillSysBase.nextId("clinictab_day");
            string sql = "insert into clinictab_day(id"
            + ",startdate"
            + ",enddate"
            + ",settledate"
            + ",settleby"
            + ",depart_id)values(" + DataTool.addIntBraces(id)
            + "," + DataTool.addFieldBraces(datatime)
            + "," + DataTool.addFieldBraces(datatime)
            + "," + DataTool.addFieldBraces(BillSysBase.currDate())
            + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
            + "," + DataTool.addFieldBraces(ProgramGlobal.Depart_id)
            + ");";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 门诊班结初始化
        /// </summary>
        /// <param name="datatime"></param>
        /// <returns></returns>
        public int clinicDutyinit(string datatime)
        {
            string id = BillSysBase.nextId("clinictab_duty");
            string billcode = BillSysBase.newBillcode("clinictab_duty_billcode");
            string sql = "insert into clinictab_duty(id"
            + ",billcode"
            + ",startdate"
            + ",enddate"
            + ",charger_id"
            + ",settledate"
            + ",settleby"
            + ",depart_id) values(" + DataTool.addIntBraces(id)
            + "," + DataTool.addFieldBraces(billcode)
            + "," + DataTool.addFieldBraces(datatime)
            + "," + DataTool.addFieldBraces(datatime)


            + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
            + "," + DataTool.addFieldBraces(BillSysBase.currDate())
            + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
            + "," + DataTool.addFieldBraces(ProgramGlobal.Depart_id)
            + ");";
            return BllMain.Db.Update(sql);
        }
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 门诊班结记录是否存在
        /// </summary>
        /// <returns></returns>
        public bool ihspDutyIshave()
        {
            string sql = "select * from ihsptab_duty where charger_id ="+DataTool.addFieldBraces(ProgramGlobal.User_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 门诊日结记录是否存在
        /// </summary>
        /// <returns></returns>
        public bool ihspTabIshave()
        {
            string sql = "select * from Ihsptab_day";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 住院日结初始化
        /// </summary>
        /// <param name="datatime"></param>
        /// <returns></returns>
        public int ihspTabinit(string datatime)
        {
            string id = BillSysBase.nextId("ihsptab_day");
            string sql = "insert into ihsptab_day(id"
            + ",startdate"
            + ",enddate"
            + ",depart_id)values(" + DataTool.addIntBraces(id)
            + "," + DataTool.addFieldBraces(datatime)
            + "," + DataTool.addFieldBraces(datatime)
            + "," + DataTool.addFieldBraces(ProgramGlobal.Depart_id)
            + ");";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 住院班结初始化
        /// </summary>
        /// <param name="datatime"></param>
        /// <returns></returns>
        public int ihspDutyinit(string datatime)
        {
            string id = BillSysBase.nextId("ihsptab_duty");
            string sql = "insert into ihsptab_duty(id"
            + ",startdate"
            + ",enddate"
            + ",depart_id)values(" + DataTool.addIntBraces(id)
            + "," + DataTool.addFieldBraces(datatime)
            + "," + DataTool.addFieldBraces(datatime)
            + "," + DataTool.addFieldBraces(ProgramGlobal.Depart_id)
            + ");";
            return BllMain.Db.Update(sql);
        }

         /// <summary>
         /// 加载grid数据
         /// </summary>
         /// <param name="dtpStime"></param>
         /// <param name="dtpEtime"></param>
         /// <returns></returns>
         public DataTable  getClinicInvoice(string dtpStime,string dtpEtime )
        {
            DataSet dataset = null;
            string sql = "select "
                       + "clinic_invoice.id"
                       + ",clinic_invoice.billcode"
                       + ",clinic_invoice.sickname"
                       + ",bas_depart.name as rcpdptname"
                       + ",bas_patienttype.name as patienttype"
                       + ",clinic_invoice.realfee"
                       + ",clinic_invoice.insurefee"
                       + ",clinic_invoice.insuraccountfee"
                       + ",clinic_invoice.chargedate"
                       + ",bas_depart.name as dptname"
                       + ",clinic_invoice.chargeby"
                       + " from clinic_invoice "
                       + " left join bas_depart "
                       + " on bas_depart.id = clinic_invoice.depart_id "
                       + " left join bas_patienttype "
                       + " on clinic_invoice.bas_patienttype_id = bas_patienttype.id"
                       + " where chargedate > " + DataTool.addFieldBraces(dtpStime)
                       + " and  chargedate <= " + DataTool.addFieldBraces(dtpEtime)
                       + " and charged in ( " + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                       + "," + DataTool.addFieldBraces(CostCharged.RET.ToString())
                       + "," + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                       + ") ";
            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }
        /// <summary>
        /// 加载部门下拉框
        /// </summary>
        /// <param name="registerID"></param>
        /// <returns></returns>
        public DataTable getTabDptInfo()
        {
            DataTable dt = new DataTable();
            string sql = " select id"
                       + ",name"
                       + " from bas_depart where id in (select depart_id from bas_depart_departtype where departtype_id in(select id from bas_departtype where typecode ='CHRG'))";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
         }
        public string getDepartName(string depart_id)
        {
            string sql = " select name from bas_depart where id = " + DataTool.addFieldBraces(depart_id);
            return BllMain.Db.Select(sql).Tables[0].Rows[0][0].ToString();
        }
        /// <summary>
        /// 加载个人下拉框
        /// </summary>
        /// <returns></returns>
        public DataTable getTabDoctor()
        {
            DataTable dt = new DataTable();
            string sql = "select id ,name "
                + " from bas_doctor where depart_id = "
                + DataTool.addFieldBraces(ProgramGlobal.Depart_id);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getClinictabUserId(string depart_id)
        { 
            DataTable dt = new DataTable();
            string sql = " select "
                       + " chargeby"
                       + " from clinic_invoice where depart_id = " + DataTool.addFieldBraces(depart_id)
                       + " and charged in (" + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                        + "," + DataTool.addFieldBraces(CostCharged.RET.ToString())
                        + "," + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                        + ") group by chargeby";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        #region 原始方法
        public int settle(Clinictab clinictab,ref string clinictab_id ,string dtpStime,string dtpEtime)
        {
            string sql = " insert into clinictab_duty ( "
                    + " id"
                    + ",clinictab_day_id"
                    + ",billcode"
                    + ",startdate"
                    + ",enddate"
                    + ",users_id"
                    + ",depart_id"
                    + ",settledate"
                    + ",settleby ) values ("
                    + DataTool.addFieldBraces(clinictab_id)
                    + "," + DataTool.addIntBraces("0")
                    + "," + DataTool.addFieldBraces(clinictab.Billcode)
                    + "," + DataTool.addFieldBraces(clinictab.Startdate)
                    + "," + DataTool.addFieldBraces(clinictab.Enddate)
                    + "," + DataTool.addFieldBraces(clinictab.Charger_id)
                    + "," + DataTool.addFieldBraces(clinictab.Depart_id)
                    + "," + DataTool.addFieldBraces(clinictab.Settledate)
                    + "," + DataTool.addFieldBraces(clinictab.Settleby)
                    + ");";
            string sql_insert_clinictab_detail = "";
            string sql_insert_costgather = "";

            DataTable dt = null;
            string sql_charge = "select "
                        + " clinic_invoicedet.bas_paytype_id"
                        + ",clinic_invoice.bas_patienttype_id"
                        + ",count(clinic_invoice.id) as receiveNum"
                        + ",sum(clinic_invoice.realfee) as receive"
                        + ",CAST('0' as decimal(10,2)) AS  refundNum"
                        + ",CAST('0.00' as decimal(10,2)) AS refund"
                        + ",'0' as realNum"
                        + ",'0.00' as realfee"
                        + " from clinic_invoice "
                        + " left join clinic_invoicedet"
                        + " on clinic_invoice.id = clinic_invoicedet.clinic_invoice_id"
                        + " where clinic_invoice.chargedate > " + DataTool.addFieldBraces(dtpStime)
                        + " and  clinic_invoice.chargedate <= " + DataTool.addFieldBraces(dtpEtime)
                        + " and clinic_invoice.charged in ( " + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                        + "," + DataTool.addFieldBraces(CostCharged.RET.ToString())
                        +  ") and clinic_invoice.chargeby = " + DataTool.addFieldBraces(clinictab.Charger_id)
                        + " and clinic_invoice.depart_id = " + DataTool.addFieldBraces(ProgramGlobal.Depart_id)
                        + " group by clinic_invoicedet.bas_paytype_id,clinic_invoice.bas_patienttype_id,clinic_invoice.depart_id,clinic_invoice.chargeby";

             sql_charge += " union all select "
                + " clinic_invoicedet.bas_paytype_id"
                + ",clinic_invoice.bas_patienttype_id"
                + ",CAST('0' as decimal(10,2)) AS receiveNum"
                + ",CAST('0.00' as decimal(10,2)) AS receive"
                + ",count(clinic_invoice.id) as refundNum"
                + ",sum(clinic_invoice.realfee) as refund"
                + ",'0' as realNum"
                + ",'0.00' as realfee"
                + " from clinic_invoice "
                + " left join clinic_invoicedet"
                + " on clinic_invoice.id = clinic_invoicedet.clinic_invoice_id"
                + " where clinic_invoice.chargedate > " + DataTool.addFieldBraces(dtpStime)
                + " and  clinic_invoice.chargedate <= " + DataTool.addFieldBraces(dtpEtime)
                + " and clinic_invoice.charged in ( "
                + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                + ") and clinic_invoice.chargeby = " + DataTool.addFieldBraces(clinictab.Charger_id)
                + " and clinic_invoice.depart_id = " + DataTool.addFieldBraces(ProgramGlobal.Depart_id)
                + " group by clinic_invoicedet.bas_paytype_id,clinic_invoice.bas_patienttype_id,clinic_invoice.depart_id,clinic_invoice.chargeby";
              
            dt = BllMain.Db.Select(sql_charge).Tables[0]; 
            var query = from t in dt.AsEnumerable() group t by new{t1 = t.Field<int>("bas_paytype_id"),t2=t.Field<int>("bas_patienttype_id")} into m 
                        select new {
                                      bas_paytype_id = m.Key.t1,
                                      bas_patienttype_id =m.Key.t2,
                                      receiveNum = m.Sum(n =>n.Field<decimal>("receiveNum")),
                                      receive = m.Sum(n=>n.Field<decimal>("receive")),
                                      refundNum = m.Sum(n=>n.Field<decimal>("receive")),
                                      refund = m.Sum(n=>n.Field<decimal>("refund"))
                                   }; 
            dt = LINQTool.CopyToDataTable0(query);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["realNum"] = (double.Parse(dt.Rows[i]["receiveNum"].ToString())-double.Parse(dt.Rows[i]["refundNum"].ToString())).ToString();
                dt.Rows[i]["realfee"] = (double.Parse(dt.Rows[i]["receive"].ToString()) - double.Parse(dt.Rows[i]["refund"].ToString())).ToString();
                string clinictab_detail_id = BillSysBase.nextId("clinictab_detail");
                sql_insert_clinictab_detail = "insert i nto clinictab_detail ("
                                            + ",realnum"
                                            + ",realfee ) values ("
                                            +  DataTool.addFieldBraces(clinictab_detail_id)
                                            + "," + DataTool.addFieldBraces(clinictab_id)
                                            + "," + DataTool.addFieldBraces(dt.Rows[i]["bas_paytype_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt.Rows[i]["bas_patienttype_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt.Rows[i]["receiveNum"].ToString())
                                            + "," + DataTool.addFieldBraces(dt.Rows[i]["receive"].ToString())
                                            + "," + DataTool.addFieldBraces(dt.Rows[i]["refundNum"].ToString())
                                            + "," + DataTool.addFieldBraces(dt.Rows[i]["refund"].ToString())
                                            + "," + DataTool.addFieldBraces(dt.Rows[i]["realNum"].ToString())
                                            + "," + DataTool.addFieldBraces(dt.Rows[i]["realfee"].ToString())
                                            + ");";
                sql += sql_insert_clinictab_detail;
            }
            
            DataTable dt_costgather_receive = null;
            DataTable dt_costgather_refund = null;
            string sql_costdet_receive = "select "
                               + " bas_patienttype_id"
                               + ",itemtype_id"
                               + ",itemtype1_id"
                               + ",depart_id"
                               + ",doctor_id"
                               + ",exedep_id"
                               + ",exedoctor_id"
                               + ",sum(fee) as fee"
                               + ",sum(realfee) as realfee"
                               + "  from clinic_costdet where chargedate >= " + DataTool.addFieldBraces(dtpStime)
                               + " and  chargedate <= " + DataTool.addFieldBraces(dtpEtime)
                               + " and charged in ( " 
                               + DataTool.addFieldBraces(CostCharged.RET.ToString())
                               + "," + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                               + " and chargeby = " + DataTool.addFieldBraces(clinictab.Charger_id)
                               + ") group by bas_patienttype_id,itemtype_id,itemtype1_id,depart_id,doctor_id,exedep_id,exedoctor_id";
            dt_costgather_receive = BllMain.Db.Select(sql_costdet_receive).Tables[0];
            string sql_costdet_refund = "select "
                               + " bas_patienttype_id"
                               + ",itemtype_id"
                               + ",itemtype1_id"
                               + ",depart_id"
                               + ",doctor_id"
                               + ",exedep_id"
                               + ",exedoctor_id"
                               + ",sum(fee) as fee"
                               + ",sum(realfee) as realfee"
                               + "  from clinic_costdet where chargedate >= " + DataTool.addFieldBraces(dtpStime)
                               + " and  chargedate <= " + DataTool.addFieldBraces(dtpEtime)
                               + " and charged in ( "
                               + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                               + " and chargeby = " + DataTool.addFieldBraces(clinictab.Charger_id)
                               + ") group by bas_patienttype_id,itemtype_id,itemtype1_id,depart_id,doctor_id,exedep_id,exedoctor_id";


            dt_costgather_refund = BllMain.Db.Select(sql_costdet_refund).Tables[0];
            for (int i = 0; i < dt_costgather_receive.Rows.Count; i++)
            {
                string clinictab_costgather_id = BillSysBase.nextId("clinictab_costgather");

                sql_insert_costgather = "insert into clinictab_costgather ("
                                 + " id "
                                 + ",clinictab_duty_id"
                                 + ",bas_patienttype_id"
                                 + ",itemtype_id"
                                 + ",itemtype1_id"
                                 + ",gathertype"
                                 + ",diagndep_id"
                                 + ",diagndoctor_id"
                                 + ",exedep_id"
                                 + ",exedoctor_id"
                                 + ",fee"
                                 + ",realfee ) values ("
                                 + DataTool.addFieldBraces(clinictab_costgather_id)
                                 + "," + DataTool.addFieldBraces(clinictab_id)
                                 + "," + DataTool.addFieldBraces(dt_costgather_receive.Rows[i]["bas_patienttype_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_receive.Rows[i]["itemtype_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_receive.Rows[i]["itemtype1_id"].ToString())
                                 + "," + DataTool.addFieldBraces("1")
                                 + "," + DataTool.addFieldBraces(dt_costgather_receive.Rows[i]["depart_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_receive.Rows[i]["doctor_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_receive.Rows[i]["exedep_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_receive.Rows[i]["exedoctor_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_receive.Rows[i]["fee"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_receive.Rows[i]["realfee"].ToString())
                                 + ");";
                sql += sql_insert_costgather;
            }
            for (int i = 0; i < dt_costgather_refund.Rows.Count; i++)
            {
                string clinictab_costgather_id = BillSysBase.nextId("clinictab_costgather");

                sql_insert_costgather = "insert into clinictab_costgather ("
                                 + " id "
                                 + ",clinictab_duty_id"
                                 + ",bas_patienttype_id"
                                 + ",itemtype_id"
                                 + ",itemtype1_id"
                                 + ",gathertype"
                                 + ",diagndep_id"
                                 + ",diagndoctor_id"
                                 + ",exedep_id"
                                 + ",exedoctor_id"
                                 + ",fee"
                                 + ",realfee ) values ("
                                 + DataTool.addFieldBraces(clinictab_costgather_id)
                                 + "," + DataTool.addFieldBraces(clinictab_id)
                                 + "," + DataTool.addFieldBraces(dt_costgather_refund.Rows[i]["bas_patienttype_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_refund.Rows[i]["itemtype_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_refund.Rows[i]["itemtype1_id"].ToString())
                                 + "," + DataTool.addFieldBraces("-1")
                                 + "," + DataTool.addFieldBraces(dt_costgather_refund.Rows[i]["depart_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_refund.Rows[i]["doctor_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_refund.Rows[i]["exedep_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_refund.Rows[i]["exedoctor_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_refund.Rows[i]["fee"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_costgather_refund.Rows[i]["realfee"].ToString())
                                 + ");";
                sql += sql_insert_costgather;
            }
            DataTable dt_invoice = null;
            string sql_invoice = "select "
                               + " id"
                               + " from clinic_invoice"
                               + " where chargedate > " + DataTool.addFieldBraces(dtpStime)
                               + " and  chargedate <= " + DataTool.addFieldBraces(dtpEtime)
                               + " and charged in ( " + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                               + "," + DataTool.addFieldBraces(CostCharged.RET.ToString())
                               + "," + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                               + ");";
            dt_invoice = BllMain.Db.Select(sql_invoice).Tables[0];
            string clinic_invoice_ids = "";
            for (int i = 0; i < dt_invoice.Rows.Count; i++)
            {
                clinic_invoice_ids += dt_invoice.Rows[i]["id"].ToString() + ",";
            }
            if (clinic_invoice_ids != "")
            {
                clinic_invoice_ids = clinic_invoice_ids.Substring(0, clinic_invoice_ids.Length - 1);
                string sql_update_invoice = "update clinic_invoice "
                   + " set clinic_tab_id = "
                   + DataTool.addFieldBraces(clinictab_id)
                   + " where id in ( "
                   + clinic_invoice_ids + ");";
                sql += sql_update_invoice;
            }

                return doExeSql(sql);
                //string clinictab_detail_id = ""
                //string sql_int_det = "insert into clinictab_detail ( "
                //            + " id"
                //            + ",clinictab_id"
                //            + ",bas_paytype_id"
                //            + ",bas_patienttype_id"
                //            + ",num"
                //            + ",fee"
                //            + ",retnum"
                //            + ",retfee"
                //            + ",realnum"
                //            + ",Realfee ) values ("
                //            + DataTool.addFieldBraces(clinictab_detail_id)
                //            + ","  + DataTool.addFieldBraces(clinicTabDetail.Clinictab_id)
                //            + ","  + DataTool.addFieldBraces(clinicTabDetail.Bas_paytype_id)
                //            + ","  + DataTool.addFieldBraces(clinicTabDetail.Bas_patienttype_id)
                //            + ","  + DataTool.addFieldBraces(clinicTabDetail.Num)
                //            + ","  + DataTool.addFieldBraces(clinicTabDetail.Fee)
                //            + ","  + DataTool.addFieldBraces(clinicTabDetail.Retnum)
                //            + ","  + DataTool.addFieldBraces(clinicTabDetail.Retfee)
                //            + ","  + DataTool.addFieldBraces(clinicTabDetail.Realnum)
                //            + ","  + DataTool.addFieldBraces(clinicTabDetail.Realfee)
                //            + ");";

                //string clinictab_costgather = "";
                //string sql_int_gather = "insert into clinictab_costgather ( "
                //            + " id"
                //            + ",clinictab_id"
                //            + ",bas_patienttype_id"
                //            + ",itemtype_id"
                //            + ",itemtype1_id"
                //            + ",diagndep_id"
                //            + ",diagndoctor_id"
                //            + ",exedep_id"
                //            + ",exedoctor_id"
                //            + ",fee"
                //            + ",realfee ) values ("
                //            + "," + DataTool.addFieldBraces(clinictab_costgather)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Clinictab_id)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Bas_patienttype_id)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Itemtype_id)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Itemtype1_id)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Diagndep_id)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Diagndoctor_id)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Exedep_id)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Exedoctor_id)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Fee)
                //            + "," + DataTool.addFieldBraces(clinicTabCostGather.Realfee)
                //            +");";
        }
        #endregion 
        //执行sql语句
        public int doExeSql(string sql)
        {
            int result = -1;
            try
            {
                result = BllMain.Db.Update(sql);
            }
            catch (Exception e) { }

            return result;
        }


        /// <summary>
        /// 日结后更新日结号外键
        /// </summary>
        /// <param name="ihsptab_day_id"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public string upClinicTabDuty(Clinictab clinictab)
        {
            string sql = "update clinictab_duty set clinictab_day_id=" + DataTool.addIntBraces(clinictab.Id)
                    + " where enddate > " + DataTool.addFieldBraces(clinictab.Startdate) 
                    + " and enddate<=" + DataTool.addFieldBraces(clinictab.Enddate)
                    + " and depart_id=" + DataTool.addFieldBraces(clinictab.Depart_id) + ";";
            return sql;
        }
        /// <summary>
        ///  强制班结数据
        /// </summary>
        /// <param name="departid"></param>
        /// <param name="ihsptab_day_id"></param>
        /// <returns></returns>
        public string inChargertabDay(Clinictab clinictab)
        {
            String sql_chargers = " SELECT DISTINCT"
                  + " 	bas_doctor_doctype.doctor_id"
                  + " FROM"
                  + " 	bas_doctor_doctype"
                  + " LEFT JOIN sys_dict bas_doctype ON bas_doctor_doctype.bas_doctype_id = bas_doctype.sn"
                  + " LEFT JOIN bas_doctor_depart  on bas_doctor_depart.doctor_id = bas_doctor_doctype.doctor_id"
                  + " AND father_id <> 0"
                  + " AND bas_doctype.dicttype = 'bas_doctype'"
                  + " "
                  + " WHERE"
                  + " 	bas_doctype.keyname = 'CLICCHARGR'"
                  + " and bas_doctor_depart.depart_id ="+ DataTool.addFieldBraces(clinictab.Depart_id)
                  + " ORDER BY doctor_id";
            DataTable dt_chargers = BllMain.Db.Select(sql_chargers).Tables[0];
            string sql_chargertabday = "";
            for (int i = 0; i < dt_chargers.Rows.Count; i++)
            {
                string doctor_id = dt_chargers.Rows[i]["doctor_id"].ToString();
                string startdate = clinictab.Startdate;
                string sql = "SELECT max(enddate) as enddate FROM clinictab_duty where charger_id = " + DataTool.addFieldBraces(doctor_id) + ";";
                DataTable datatable = BllMain.Db.Select(sql).Tables[0];
                if (datatable.Rows.Count > 0)
                {
                     startdate = datatable.Rows[0]["enddate"].ToString();
                     if (string.IsNullOrEmpty(startdate))
                     {
                         startdate = clinictab.Startdate;
                     }
                     Clinictab clinictab_duty = new Clinictab(); 
                     clinictab_duty.Startdate = startdate;
                     clinictab_duty.Enddate = clinictab.Enddate;
                     clinictab_duty.Charger_id = doctor_id;
                     clinictab_duty.Settleby = clinictab.Settleby;
                     clinictab_duty.Settledate = clinictab.Settledate;
                     clinictab_duty.Daytab = "Y";
                     sql_chargertabday += getClinictabDuty(clinictab_duty);
                }
            }
            return sql_chargertabday;
        }
        /// <summary>
        /// 获取最后一次日结时间
        /// </summary>
        /// <returns></returns>
        public string getTabEndtime(string depart)
        {
            string sql = "select max(enddate) as enddate from clinictab_day where depart_id="+DataTool.addIntBraces(depart);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string enddate = datatable.Rows[0]["enddate"].ToString();
                return enddate;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取最后一次班结时间
        /// </summary>
        /// <returns></returns>
        public string getDutyEndtime(string settleby)
        {
            string sql = "select max(enddate) as enddate from clinictab_duty where settleby=" + DataTool.addIntBraces(settleby);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string enddate = datatable.Rows[0]["enddate"].ToString();
                return enddate;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 查询结算主表中日期是否存在
        /// </summary>
        /// <returns></returns>
        public DataTable daysettle(string date)
        {
            DataTable dt = new DataTable();
            string sql = "select * from sys_daysettle where startdate=" + DataTool.addFieldBraces(date);
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
        /// 获取系统配置中的结算信息
        /// </summary>
        /// <returns></returns>
        public DataTable getSettleType()
        {
            DataTable dt = new DataTable();
            string sql = "select settletype,settledate,monthday from sys_config";
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
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
        /// 查询发票表
        /// </summary>
        /// <param name="dtpStime"></param>
        /// <param name="dtpEtime"></param>
        /// <param name="type"></param>
        /// <param name="charer_id"></param>
        /// <returns></returns>
        public DataTable dutyClinicInvoice(string dtpStime, string dtpEtime,string charer_id)
        {
            DataSet dataset = null;
            string sql = "select "
                       + "clinic_invoice.id"
                       + ",clinic_invoice.invoice"
                       + ",clinic_invoice.sickname"
                       + ",rcpdepart.name as rcpdptname"
                       + ",bas_patienttype.name as patienttype"
                       + ",clinic_invoice.realfee"
                       + ",clinic_invoice.insurefee"
                       + ",clinic_invoice.insuraccountfee"
                       + ",clinic_invoice.chargedate"
                       + ",bas_depart.name as dptname"
                       + " from clinic_invoice "
                       + " left join bas_depart "
                       + " on bas_depart.id = clinic_invoice.depart_id "
                       + " left join bas_depart rcpdepart"
                       + " on rcpdepart.id = clinic_invoice.rcpdep_id "
                       + " left join bas_patienttype "
                       + " on clinic_invoice.bas_patienttype_id = bas_patienttype.id"
                       + " left join register "
                       + " on clinic_invoice.regist_id = register.id"
                       + " where 1=1"
                       + " and register.prepaid<>'Y'"
                       + " and clinic_invoice.chargedate > " + DataTool.addFieldBraces(dtpStime)
                       + " and  clinic_invoice.chargedate <= " + DataTool.addFieldBraces(dtpEtime)
                       +" and charged in ( " + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                       + "," + DataTool.addFieldBraces(CostCharged.RET.ToString())
                       + "," + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                       + ")"
                       + " and clinic_invoice.chargeby=" + DataTool.addFieldBraces(charer_id);
                    
            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }
        /// <summary>
        /// 查询发票表
        /// </summary>
        /// <param name="dtpStime"></param>
        /// <param name="dtpEtime"></param>
        /// <param name="type"></param>
        /// <param name="charer_id"></param>
        /// <returns></returns>
        public DataTable dayClinicInvoice(string dtpStime, string dtpEtime, string depart_id)
        {
            DataSet dataset = null;
            string sql = "select "
                       + "clinic_invoice.id"
                       + ",clinic_invoice.invoice"
                       + ",clinic_invoice.sickname"
                       + ",rcpdepart.name as rcpdptname"
                       + ",bas_patienttype.name as patienttype"
                       + ",clinic_invoice.realfee"
                       + ",clinic_invoice.insurefee"
                       + ",clinic_invoice.insuraccountfee"
                       + ",clinic_invoice.chargedate"
                       + ",bas_depart.name as dptname"
                       + " from clinic_invoice "
                       + " left join bas_depart "
                       + " on bas_depart.id = clinic_invoice.depart_id "
                       + " left join bas_depart rcpdepart"
                       + " on rcpdepart.id = clinic_invoice.rcpdep_id "
                       + " left join bas_patienttype "
                       + " on clinic_invoice.bas_patienttype_id = bas_patienttype.id"
                       + " left join register "
                       + " on clinic_invoice.regist_id = register.id"
                       + " where 1=1"
                       + " and register.prepaid<>'Y'"
                       + " and clinic_invoice.chargedate > " + DataTool.addFieldBraces(dtpStime)
                       + " and  clinic_invoice.chargedate <= " + DataTool.addFieldBraces(dtpEtime)
                       + " and charged in ( " + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                       + "," + DataTool.addFieldBraces(CostCharged.RET.ToString())
                       + "," + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                       + ")"
                       + " and clinic_invoice.depart_id=" + DataTool.addFieldBraces(depart_id);

            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }
        /// <summary>
        /// 向日结主表中插入数据
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="chargeby"></param>
        /// <returns></returns>
        public string inDaysettle(Clinictab clinictab, string id, string billcode)
        {
            string sql = "insert into sys_daysettle("
                                            + "id"
                                            + ",billcode"
                                            + ",startdate"
                                            + ",enddate"
                                            + ",createdby"
                                            + ")values("
                                            + DataTool.addIntBraces(id)
                                            + "," + DataTool.addFieldBraces(billcode)
                                            + "," + DataTool.addFieldBraces(clinictab.Startdate)
                                            + "," + DataTool.addFieldBraces(clinictab.Enddate)
                                            + "," + DataTool.addIntBraces(clinictab.Settleby)
                                            + ");";
            return sql;
        }

        public bool doClinictabDuty(Clinictab clinictab)
        {
            bool ret = true; ;
            string sql= getClinictabDuty(clinictab);
            if (BllMain.Db.Update(sql) < 0)
            {
                ret = false;
            }
            return ret;
        }

        private string getClinictabDuty(Clinictab clinictab )
        {
            string sql = "";
          
            clinictab.Billcode = BillSysBase.newBillcode("clinictab_duty_billcode");
            clinictab.Id = BillSysBase.nextId("clinictab_duty");

            ///插入班结表 并修改发票表日结外键
            sql = inClinictab_duty(clinictab);
            ///插入门诊班结收款明细汇总
            sql += inClinictab_detail(clinictab);
            ///插入门诊班发票汇总
            sql += inClinictab_invoiceamt(clinictab);
            return sql;
        }

        /// <summary>
        /// 插入门诊班结表
        /// </summary>
        /// <returns></returns>
        public string inClinictab_duty(Clinictab clinictab)
        {           
            string sql = " insert into clinictab_duty ( "
                 + " id"
                 + ",clinictab_day_id"
                  + ",daytab"
                 + ",billcode"
                 + ",startdate"
                 + ",enddate"
                 + ",charger_id"
                 + ",depart_id"
                 + ",settledate"
                 + ",settleby ) values ("
                 + DataTool.addFieldBraces(clinictab.Id)
                 + "," + DataTool.addIntBraces("0")
                 + "," + DataTool.addFieldBraces(clinictab.Daytab)
                 + "," + DataTool.addFieldBraces(clinictab.Billcode)
                 + "," + DataTool.addFieldBraces(clinictab.Startdate)
                 + "," + DataTool.addFieldBraces(clinictab.Enddate)
                 + "," + DataTool.addFieldBraces(clinictab.Charger_id)
                 + "," + DataTool.addFieldBraces(clinictab.Depart_id)
                 + "," + DataTool.addFieldBraces(clinictab.Settledate)
                 + "," + DataTool.addFieldBraces(clinictab.Settleby)
                 + ");";                
            return sql;
        }
        /// <summary>
        /// 插入门诊日结表
        /// </summary>
        /// <returns></returns>
        public string inClinictabDay(Clinictab clinictab)
        {
            //"update  clinictab_day set clinictab_day.islock = 'Y' order by id  desc  limit  1;"
            string sql = ""
                 +" insert into clinictab_day ( "
                 + " id"
                 + ",billcode"
                 + ",startdate"
                 + ",enddate"
                 + ",depart_id"
                 + ",settledate"
                 + ",islock"
                 + ",settleby ) values ("
                 + DataTool.addFieldBraces(clinictab.Id)
                 + "," + DataTool.addFieldBraces(clinictab.Billcode)
                 + "," + DataTool.addFieldBraces(clinictab.Startdate)
                 + "," + DataTool.addFieldBraces(clinictab.Enddate)
                 + "," + DataTool.addFieldBraces(clinictab.Depart_id)
                 + "," + DataTool.addFieldBraces(clinictab.Settledate)
                 + "," + DataTool.addFieldBraces("N")
                 + "," + DataTool.addFieldBraces(clinictab.Settleby)
                 + ");";
            return sql;
        }


        /// <summary>
        /// 插入班结明细
        /// </summary>
        /// <returns></returns>
        public string inClinictab_detail(Clinictab clinictab)
        {
            string sql_fee = "SELECT  sum(clinic_Invoicedet.payfee) as fee,"
                     + "  Cast('0' AS decimal) as retfee,"
                     + "  Cast('0' AS decimal) as realfee,"
                     + "  clinic_Invoicedet.bas_paysumby_id,"
                     + "  clinic_Invoicedet.bas_paytype_id,"
                     + "  clinic_invoice.bas_patienttype_id"
                     + "  FROM clinic_Invoicedet,clinic_invoice"
                     + "  WHERE"
                     + "  clinic_Invoicedet.clinic_invoice_id=clinic_invoice.id"
                     + "  and clinic_invoice.chargedate >" + DataTool.addFieldBraces(clinictab.Startdate) 
                     + " and clinic_invoice.chargedate<=" + DataTool.addFieldBraces(clinictab.Enddate)
                     + "  and clinic_invoice.chargeby =" + DataTool.addFieldBraces(clinictab.Charger_id)
                     + "  and clinic_invoice.charged in ('RET','CHAR')"
                     + "  GROUP BY "
                     + "  bas_paysumby_id,"
                     + "  bas_paytype_id,"
                     + "  bas_patienttype_id";
           DataTable dt_fee = BllMain.Db.Select(sql_fee).Tables[0];
           doSummaryRetFee(clinictab, dt_fee);
           string sql_insert = "";
           for (int i = 0; i < dt_fee.Rows.Count; i++)
           {
                string clinictab_detail_id = BillSysBase.nextId("clinictab_detail");
                double fee = DataTool.stringToDouble(dt_fee.Rows[i]["fee"].ToString());
                double retfee = DataTool.stringToDouble(dt_fee.Rows[i]["retfee"].ToString()); 
                dt_fee.Rows[i]["realfee"] = DataTool.FormatData(fee + retfee, "2");
                sql_insert += "insert into clinictab_detail ("
                                + " id "
                                + ",clinictab_duty_id"
                                + ",bas_paysumby_id"
                                + ",bas_paytype_id"
                                + ",bas_patienttype_id"
                                + ",fee"
                                + ",retfee"
                                + ",realfee ) values ("
                                + DataTool.addFieldBraces(clinictab_detail_id)
                                + "," + DataTool.addFieldBraces(clinictab.Id)
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["bas_paysumby_id"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["bas_paytype_id"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["bas_patienttype_id"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["fee"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["retfee"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["realfee"].ToString())
                                + ");";
             }
             return sql_insert;
          }
        /// <summary>
        /// 汇总退费
        /// </summary>
        /// <param name="clinictab"></param>
        /// <param name="dt_fee"></param>
        private  void doSummaryRetFee(Clinictab clinictab, DataTable dt_fee)
        {
            string sql_retfee = "SELECT  sum(clinic_Invoicedet.payfee) as retfee,"
                  + "  clinic_Invoicedet.bas_paysumby_id,"
                  + "  clinic_Invoicedet.bas_paytype_id,"
                  + "  clinic_invoice.bas_patienttype_id"
                  + "  FROM clinic_Invoicedet,clinic_invoice"
                  + "  WHERE"
                  + "  clinic_Invoicedet.clinic_invoice_id=clinic_invoice.id"
                  + "  and clinic_invoice.chargedate >" + DataTool.addFieldBraces(clinictab.Startdate) + " and clinic_invoice.chargedate<=" + DataTool.addFieldBraces(clinictab.Enddate)
                  + "  and clinic_invoice.chargeby =" + DataTool.addFieldBraces(clinictab.Charger_id)
                  + "  and clinic_invoice.charged in ('RREC')"
                  + "  GROUP BY "
                  + "  bas_paysumby_id,"
                  + "  bas_paytype_id,"
                  + "  bas_patienttype_id";
            DataTable dt_retfee = BllMain.Db.Select(sql_retfee).Tables[0];

            for (int i = 0; i < dt_retfee.Rows.Count; i++)
            {
                string bas_paysumby_id = dt_retfee.Rows[i]["bas_paysumby_id"].ToString();
                string bas_paytype_id = dt_retfee.Rows[i]["bas_paytype_id"].ToString();
                string bas_patienttype_id = dt_retfee.Rows[i]["bas_patienttype_id"].ToString();
                int findFlag = 0;
                int dt_fee_idx = 0;
                for (int j = 0; j < dt_fee.Rows.Count; j++)
                {
                    string bas_paysumby_id_1 = dt_fee.Rows[j]["bas_paysumby_id"].ToString();
                    string bas_paytype_id_1 = dt_fee.Rows[j]["bas_paytype_id"].ToString();
                    string bas_patienttype_id_1 = dt_fee.Rows[j]["bas_patienttype_id"].ToString();
                    if (bas_paysumby_id == bas_paysumby_id_1 && bas_paytype_id == bas_paytype_id_1 && bas_patienttype_id == bas_patienttype_id_1)
                    {

                        dt_fee_idx = j;
                        findFlag = 1;
                        break;

                    }

                }
                double retfee = DataTool.stringToDouble(dt_retfee.Rows[i]["retfee"].ToString());
                if (findFlag == 1)
                {

                    dt_fee.Rows[dt_fee_idx]["retfee"] = retfee.ToString("0.00");
                   

                }
                else
                {
                    dt_fee.Rows.Add();
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_paysumby_id"] = bas_paysumby_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_paytype_id"] = bas_paytype_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_patienttype_id"] = bas_patienttype_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["fee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["retfee"] = retfee.ToString("0.00");
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["realfee"] = "0";
                }
            }
        }
        /// <summary>
        /// 插入班结发票汇总
        /// </summary>
        /// <returns></returns>
        public string inClinictab_invoiceamt(Clinictab clinictab)
        {
            string sql_insert="";
            string sql_fee = "SELECT count(clinic_invoice.id) as num,"

                     + "  Cast('0' AS int) as retnum,"
                     + "  Cast('0' AS int) as realnum,"
                     + "  clinic_invoice.bas_patienttype_id"
                     + "  FROM clinic_invoice"
                     + "  WHERE 1=1"                  
                     + "  and clinic_invoice.chargedate >" + DataTool.addFieldBraces(clinictab.Startdate) + " and clinic_invoice.chargedate<=" + DataTool.addFieldBraces(clinictab.Enddate)
                     + "  and clinic_invoice.chargeby =" + DataTool.addFieldBraces(clinictab.Charger_id)
                     + "  and clinic_invoice.charged in ('RET','CHAR')"
                     + "  GROUP BY "
                     + "  bas_patienttype_id";
             string sql_retfee = "SELECT count(clinic_invoice.id) as retnum,"
                     + "  clinic_invoice.bas_patienttype_id"
                     + "  FROM clinic_invoice"
                     + "  WHERE 1=1"                  
                     + "  and clinic_invoice.chargedate >" + DataTool.addFieldBraces(clinictab.Startdate) + " and clinic_invoice.chargedate<=" + DataTool.addFieldBraces(clinictab.Enddate)
                     + "  and clinic_invoice.chargeby =" + DataTool.addFieldBraces(clinictab.Charger_id)
                     + "  and clinic_invoice.charged in ('RREC')"
                     + "  GROUP BY "
                     + "  bas_patienttype_id";

             DataTable dt_fee = BllMain.Db.Select(sql_fee).Tables[0];
             DataTable dt_retfee = BllMain.Db.Select(sql_retfee).Tables[0];
             for (int i = 0; i < dt_retfee.Rows.Count; i++)
             {
               
                 string bas_patienttype_id = dt_retfee.Rows[i]["bas_patienttype_id"].ToString();
                 int findFlag = 0;
                 int dt_fee_idx = 0;
                 for (int j = 0; j < dt_fee.Rows.Count; j++)
                 {
               
                     string bas_patienttype_id_1 = dt_fee.Rows[j]["bas_patienttype_id"].ToString();
                     if ( bas_patienttype_id == bas_patienttype_id_1)
                     {

                         dt_fee_idx = j;
                         findFlag = 1;
                         break;
                     }

                 }
                 int retnum = DataTool.stringToInt(dt_retfee.Rows[i]["retnum"].ToString());
                 if (findFlag == 1)
                 {
                     double num = DataTool.stringToInt(dt_fee.Rows[dt_fee_idx]["num"].ToString());
                     dt_fee.Rows[dt_fee_idx]["retnum"] = dt_retfee.Rows[i]["retnum"].ToString();
                     dt_fee.Rows[dt_fee_idx]["realnum"] = DataTool.FormatData(num - retnum, "0");

                 }
                 else
                 {
                     dt_fee.Rows.Add();
                
                     dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_patienttype_id"] = bas_patienttype_id;
                     dt_fee.Rows[dt_fee.Rows.Count - 1]["num"] = "0";
                     dt_fee.Rows[dt_fee.Rows.Count - 1]["retnum"] = retnum;
                     dt_fee.Rows[dt_fee.Rows.Count - 1]["realnum"] = -retnum;
                 }
             }
        
             for (int i = 0; i < dt_fee.Rows.Count; i++)
             {
                 string clinictab_invoiceamt_id = BillSysBase.nextId("clinictab_invoiceamt");
                 sql_insert += "insert into clinictab_invoiceamt ("
                                 + " id "
                                 + ",clinictab_duty_id"
                                 + ",bas_patienttype_id"
                                 + ",num"
                                 + ",retnum"
                                 + ",realnum ) values ("
                                 + DataTool.addFieldBraces(clinictab_invoiceamt_id)
                                 + "," + DataTool.addFieldBraces(clinictab.Id)
                                 + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["bas_patienttype_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["num"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["retnum"].ToString())
                                 + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["realnum"].ToString())
                                 + ");";
             }
             return sql_insert;
        }
        /// <summary>
        /// 插入门诊核算汇总
        /// </summary>
        /// <returns></returns>
        public string inClinictab_costgather(Clinictab clinictab)
        {
            string sql1 = "select "
                        + " clinic_costdet.bas_patienttype_id"
                        + ",clinic_costdet.itemtype_id"
                        + ",clinic_costdet.itemtype1_id"
                        + ",clinic_costdet.depart_id"
                        + ",clinic_costdet.doctor_id"
                        + ",clinic_costdet.exedep_id"
                //+ ",clinic_costdet.exedoctor_id"
                        + ",sum(clinic_costdet.fee) as fee"
                        + ",sum(clinic_costdet.realfee) as realfee"
                        + " from clinic_costdet "
                        + " where 1=1"
                        + "  and clinic_costdet.chargedate >= " + DataTool.addFieldBraces(clinictab.Startdate)
                        + " and  clinic_costdet.chargedate <= " + DataTool.addFieldBraces(clinictab.Enddate)
                        + " and clinic_costdet.charged in ( "
                        + DataTool.addFieldBraces(CostCharged.RET.ToString())
                        + "," + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                        + "," + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                        + ")"
                        + " group by clinic_costdet.bas_patienttype_id"
                        + ",clinic_costdet.itemtype_id"
                        + ", clinic_costdet.itemtype1_id"
                        + ",clinic_costdet.depart_id"
                        + ",clinic_costdet.doctor_id"
                        + ",clinic_costdet.exedep_id"
                         //+ ",clinic_costdet.exedoctor_id";
                        ;
            DataTable dt1 = BllMain.Db.Select(sql1).Tables[0];
            string insql="";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string clinictab_costgather_id = BillSysBase.nextId("clinictab_costgather");

                insql += "insert into clinictab_costgather ("
                                 + " id "
                                 + ",clinictab_day_id"
                                 + ",bas_patienttype_id"
                                 + ",itemtype_id"
                                 + ",itemtype1_id"
                                 + ",diagndep_id"
                                 + ",diagndoctor_id"
                                 + ",exedep_id"
                                // + ",exedoctor_id"
                                 + ",costfee"
                                 + ",realfee ) values ("
                                 + DataTool.addFieldBraces(clinictab_costgather_id)
                                 + "," + DataTool.addFieldBraces(clinictab.Id)
                                 + "," + DataTool.addFieldBraces(dt1.Rows[i]["bas_patienttype_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt1.Rows[i]["itemtype_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt1.Rows[i]["itemtype1_id"].ToString())
                           
                                 + "," + DataTool.addFieldBraces(dt1.Rows[i]["depart_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt1.Rows[i]["doctor_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt1.Rows[i]["exedep_id"].ToString())
                                // + "," + DataTool.addFieldBraces(dt1.Rows[i]["exedoctor_id"].ToString())
                                 + "," + DataTool.addFieldBraces(dt1.Rows[i]["fee"].ToString())
                                 + "," + DataTool.addFieldBraces(dt1.Rows[i]["realfee"].ToString())
                                 + ");";               
            }
            return insql;
        }


    }

}