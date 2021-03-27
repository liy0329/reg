using System;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.ihsp.bo;
using MTREG.common;
using MTREG.ihsptab.bo;


namespace MTREG.ihsptab.bll
{
    class BllIhsptab
    {
        /// <summary>
        /// 日结上次结束时间
        /// </summary>
        /// <returns></returns>
        public string tabEndDate(string depart)
        {
            string sql = "select max(enddate) as enddate from ihsptab_day where depart_id="+DataTool.addFieldBraces(depart);
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
        /// 班结上次结束时间
        /// </summary>
        /// <returns></returns>
        public string dutyEndDate(string doctor)
        {
            string sql = "select max(enddate) as enddate from ihsptab_duty where settleby=" + DataTool.addFieldBraces(doctor);
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
        /// 日结主表上次结束时间
        /// </summary>
        /// <returns></returns>
        public string dayEndDate()
        {
            string sql = "select max(enddate) as enddate from sys_daysettle";
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
        /// 查询结账方式
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
        /// 日结后更新日结号外键
        /// </summary>
        /// <param name="ihsptab_day_id"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public string upIhsptabDuty(Ihsptab ihsptab)
        {
            string sql = "update ihsptab_duty set ihsptab_day_id=" + DataTool.addIntBraces(ihsptab.Id)
                        +" where 1=1"
                       // +" and depart_id=" + DataTool.addFieldBraces(ihsptab.Depart_id)
                        +" and enddate>" + DataTool.addFieldBraces(ihsptab.Startdate)
                        + " and enddate=" + DataTool.addFieldBraces(ihsptab.Enddate) + ";";
           return sql;
        }

        /// <summary>
        /// 未进行日结的插0
        /// </summary>
        /// <param name="departid"></param>
        /// <param name="ihsptab_day_id"></param>
        /// <returns></returns>
        public string inChargertabDay(Ihsptab ihsptab)
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
                  + " 	bas_doctype.keyname = 'IHPSCHARGR'"
                  + " and bas_doctor_depart.depart_id =" + DataTool.addFieldBraces(ihsptab.Depart_id)
                  + " ORDER BY doctor_id";
            DataTable dt_chargers = BllMain.Db.Select(sql_chargers).Tables[0];
            string sql_chargertabday = "";
            for (int i = 0; i < dt_chargers.Rows.Count; i++)
            {
                string doctor_id = dt_chargers.Rows[i]["doctor_id"].ToString();
                string startdate = ihsptab.Startdate;
                string sql = "SELECT max(enddate) as enddate FROM ihsptab_duty where charger_id = " + DataTool.addFieldBraces(doctor_id) + ";";
                DataTable datatable = BllMain.Db.Select(sql).Tables[0];
                if (datatable.Rows.Count > 0)
                {
                    startdate = datatable.Rows[0]["enddate"].ToString();
                    if(string.IsNullOrEmpty(startdate))
                    {
                        startdate = ihsptab.Startdate;
                    }
                    Ihsptab ihsptab_duty = new Ihsptab();
                    ihsptab_duty.Id = BillSysBase.nextId("ihsptab_duty");
                         
                    ihsptab_duty.Startdate = startdate;
                    ihsptab_duty.Enddate = ihsptab.Enddate;
                    ihsptab_duty.Charger_id = doctor_id;
                    ihsptab_duty.Settleby = ihsptab.Settleby;
                    ihsptab_duty.Settledate = ihsptab.Settledate;
                    ihsptab_duty.Daytab = "Y";
                    sql_chargertabday += getIhsptabDuty(ihsptab_duty); 
                }
            }
            return sql_chargertabday;
        }
        /// <summary>
        /// 向日结主表中插入数据
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="chargeby"></param>
        /// <returns></returns>
        public string inDaysettle(string starttime,string endtime,string chargeby,string id,string billcode)
        {            
            string sql = "insert into sys_daysettle("
                                            + "id"
                                            + ",billcode"
                                            + ",startdate"
                                            + ",enddate"
                                            + ",createdby"
                                            + ")values("
                                            +  DataTool.addIntBraces(id)
                                            + "," + DataTool.addFieldBraces(billcode)
                                            + "," + DataTool.addFieldBraces(starttime)
                                            + "," + DataTool.addFieldBraces(endtime)
                                            + "," + DataTool.addIntBraces(chargeby)
                                            +");";
            return sql;
        }
        /// <summary>
        /// 住院日结查询按钮
        /// </summary>
        /// <returns></returns>
        public DataTable ihsptabSearch(string startTime, string endTime, string depart)
        {
            DataTable dt = new DataTable();
            string sql = "select bas_depart.name as departname"
                      + ",ihsptab_day.startdate"
                      + ",ihsptab_day.enddate"
                      + ",ihsptab_day.billcode "
                      + ",ihsptab_day.id "
                      + ",ihsptab_day.depart_id "
                      + ",ihsptab_day.settleby "
                      + " from ihsptab_day "
                      + " left join bas_depart on ihsptab_day.depart_id=bas_depart.id "
                      + " where 1=1 "
                    //  +" and ihsptab_day.depart_id = " + DataTool.addFieldBraces(depart)
                      + " and ihsptab_day.enddate > " + DataTool.addFieldBraces(startTime) + " and ihsptab_day.enddate<=" + DataTool.addFieldBraces(endTime);
                dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 住院班结查询按钮
        /// </summary
        /// <returns></returns>
        public DataTable ihspdutySearch(string startTime, string endTime, string charger)
        {
            DataTable dt = new DataTable();
            string sql = "select bas_doctor.name as charger"
                      + ",ihsptab_duty.startdate"
                      + ",ihsptab_duty.enddate"
                      + ",ihsptab_duty.billcode "
                      + ",ihsptab_duty.id "
                      + ",bas_depart.name as departname "
                      + ",ihsptab_duty.depart_id "
                      + " from ihsptab_duty "
                      + " left join bas_depart on ihsptab_duty.depart_id=bas_depart.id "
                      + " left join bas_doctor on ihsptab_duty.charger_id=bas_doctor.id "
                      + " where 1=1 "
                      + " and charger_id = "+DataTool.addFieldBraces(charger)
                      + " and ihsptab_duty.enddate > " + DataTool.addFieldBraces(startTime) + " and ihsptab_duty.enddate<=" + DataTool.addFieldBraces(endTime);
                dt = BllMain.Db.Select(sql).Tables[0];
          
            return dt;
        }

        /// <summary>
        /// 预交款查询
        /// </summary>
        /// <returns></returns>
        public DataTable paySearch(string name, Ihsptab ihsptab)
        {
            DataTable dt = new DataTable();

            string sql = "select bas_doctor.name as charger"
                      + ",inhospital.name as ihspname"
                      + ",bas_depart.name as departname"
                      + ",inhospital.ihspcode"
                      + ",ihsp_payinadv.payfee"
                      + ",sys_dict.name as paytypename"
                      + ",ihsp_payinadv.chargedate"
                      + ",ihsp_payinadv.ihsptab_id"
                      + " from ihsp_payinadv "
                      + " left join inhospital on inhospital.id=ihsp_payinadv.ihsp_id "
                      + " left join bas_doctor on ihsp_payinadv.chargedby=bas_doctor.id "
                      + " left join bas_depart on ihsp_payinadv.depart_id=bas_depart.id "
                      + " left join sys_dict on ihsp_payinadv.bas_paytype_id=sys_dict.sn and sys_dict.dicttype='bas_paytype' and  sys_dict.father_id<>0 "
                      + " where 1=1 "
                      + " and ihsp_payinadv.chargedate >" + DataTool.addFieldBraces(ihsptab.Startdate) 
                      + " and ihsp_payinadv.chargedate<=" + DataTool.addFieldBraces(ihsptab.Enddate)
                      + (!string.IsNullOrEmpty(name) ? (" and inhospital.name = " + DataTool.addFieldBraces(name)) : "")
                      +";";
                      dt = BllMain.Db.Select(sql).Tables[0];
         
            return dt;
        }

        /// <summary>
        /// 住院班结函数
        /// </summary>
        /// <param name="ihsptab">班结输入参数类</param>
        /// <returns></returns>
      public  bool doIhsptabDuty(Ihsptab ihsptab)
    {
        bool ret = true;
        ///添加住院班结表
        string sql = getIhsptabDuty(ihsptab);

        if (BllMain.Db.Update(sql) < 0)
        {
            ret = false;
        }
        return ret;
    }

      private string getIhsptabDuty(Ihsptab ihsptab)
      {
          string sql = inIhsptabDuty(ihsptab);

          ///添加住院班结收款汇总
          sql += inIhsptabDetail(ihsptab);

          ///添加住院班结结算汇总
          sql += inIhsptabInvoiceamt(ihsptab);
          return sql;
      }

        /// <summary>
        /// 插入住院班结表
        /// </summary>
        /// <param name="ihsptab"></param>
        /// <returns></returns>
        public string inIhsptabDuty(Ihsptab ihsptab)
        {    
            
               string sql="insert into ihsptab_duty(id"
                                        + ",ihsptab_day_id"
                                        + ",daytab"
                                        + ",billcode"
                                        + ",startdate"
                                        + ",enddate"
                                        + ",depart_id"
                                        + ",charger_id"
                                        + ",settledate"
                                        + ",settleby)values(" + DataTool.addFieldBraces(ihsptab.Id)
                                        + ", " + DataTool.addFieldBraces("0")
                                        + "," + DataTool.addFieldBraces(ihsptab.Daytab)
                                        + "," + DataTool.addFieldBraces(ihsptab.Billcode)
                                        + "," + DataTool.addFieldBraces(ihsptab.Startdate)
                                        + "," + DataTool.addFieldBraces(ihsptab.Enddate)
                                        + "," + DataTool.addFieldBraces(ihsptab.Depart_id)
                                        + "," + DataTool.addFieldBraces(ihsptab.Charger_id)
                                        + "," + DataTool.addFieldBraces(BillSysBase.currDate())
                                        + "," + DataTool.addFieldBraces(ihsptab.Settleby)
                                        + ");";
            return sql;
        }
        /// <summary>
        /// 插入住院日结表
        /// </summary>
        /// <param name="ihsptab"></param>
        /// <returns></returns>
        public string inIhsptabDay(Ihsptab ihsptab)
        {
            string sql = "update  ihsptab_day set ihsptab_day.islock = 'Y' order by id  desc  limit  1;";
                   sql += "insert into ihsptab_day(id"
                                        + ",billcode"
                                        + ",startdate"
                                        + ",enddate"
                                        + ",depart_id"
                                        + ",islock"
                                        + ",settleby"
                                        + ",settledate)values(" + DataTool.addFieldBraces(ihsptab.Id)
                                        + "," + DataTool.addFieldBraces(ihsptab.Billcode)
                                        + "," + DataTool.addFieldBraces(ihsptab.Startdate)
                                        + "," + DataTool.addFieldBraces(ihsptab.Enddate)
                                        + "," + DataTool.addFieldBraces(ihsptab.Depart_id)
                                        + "," + DataTool.addFieldBraces("N")
                                        + "," + DataTool.addFieldBraces(ihsptab.Settleby)
                                        + "," + DataTool.addFieldBraces(ihsptab.Settledate)
                                        + ");";
            return sql;
        }
        /// <summary>
        /// 插入住院班结收款汇总
        /// </summary>
        /// <param name="ihsptab"></param>
        /// <returns></returns>
        public string inIhsptabDetail(Ihsptab ihsptab)
        {

            String sql_inadvfee = " SELECT"
                        + " 	ihsp_payinadv.bas_paysumby_id,"
                        + " 	ihsp_payinadv.bas_paytype_id,"
                        + " 	inhospital.bas_patienttype_id,"
                        + " 	sum(ihsp_payinadv.payfee) AS inadvfee,"
                        + " 	Cast('0' AS DECIMAL) AS retinadvfee,"
                        + " 	Cast('0' AS DECIMAL) AS revcefee,"
                        + " 	Cast('0' AS DECIMAL) AS retfee,"
                        + " 	Cast('0' AS DECIMAL) AS realfee"
                        + " FROM"
                        + " 	ihsp_payinadv, inhospital"
                        + " WHERE"
                        + " 	ihsp_payinadv.STATUS IN ('RET', 'CHRG')"
                        + " AND ihsp_payinadv.ihsp_id = inhospital.id"
                        + " AND ihsp_payinadv.chargedate > " + DataTool.addFieldBraces(ihsptab.Startdate)
                        + " AND ihsp_payinadv.chargedate <= " + DataTool.addFieldBraces(ihsptab.Enddate)
                        + " AND ihsp_payinadv.chargedby = " + DataTool.addFieldBraces(ihsptab.Charger_id)
                        + " GROUP BY"
                        + " 	ihsp_payinadv.bas_paysumby_id,"
                        + " 	ihsp_payinadv.bas_paytype_id,"
                        + " 	inhospital.bas_patienttype_id"
                        + " ORDER BY"
                        + " 	ihsp_payinadv.bas_paysumby_id;";

            DataTable dt_fee = BllMain.Db.Select(sql_inadvfee).Tables[0];
            doSummaryByRetInadvfee(ihsptab,  dt_fee);
            doSummaryByRevcefee(ihsptab, dt_fee);
            doSummaryByRetfee(ihsptab, dt_fee);
            string sql_insert = "";
            for (int i = 0; i < dt_fee.Rows.Count; i++)
            {
                string ihsptab_detail_id = BillSysBase.nextId("ihsptab_detail");
                double inadvfee = DataTool.stringToDouble(dt_fee.Rows[i]["inadvfee"].ToString());
                double retinadvfee = DataTool.stringToDouble(dt_fee.Rows[i]["retinadvfee"].ToString());
                double revcefee = DataTool.stringToDouble(dt_fee.Rows[i]["revcefee"].ToString());
                double retfee = DataTool.stringToDouble(dt_fee.Rows[i]["retfee"].ToString());
                dt_fee.Rows[i]["realfee"] =DataTool.FormatData( (inadvfee + retinadvfee + revcefee + revcefee),"2");
                
                sql_insert += "insert into ihsptab_detail ("
                                + " id "
                                + ",ihsptab_duty_id"
                                + ",bas_paysumby_id"
                                + ",bas_paytype_id"
                                + ",bas_patienttype_id"
                                + ",inadvfee"
                                + ",retinadvfee"
                                + ",revcefee"
                                + ",retfee"
                                + ",realfee"
                                +" ) values ("
                                + DataTool.addFieldBraces(ihsptab_detail_id)
                                + "," + DataTool.addFieldBraces(ihsptab.Id)
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["bas_paysumby_id"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["bas_paytype_id"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["bas_patienttype_id"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["inadvfee"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["retinadvfee"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["revcefee"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["retfee"].ToString())
                                + "," + DataTool.addFieldBraces(dt_fee.Rows[i]["realfee"].ToString())
                                + ");";
            }
            return sql_insert;
        }
        /// <summary>
        /// 汇总预交款
        /// </summary>
        /// <param name="clinictab"></param>
        /// <param name="dt_fee"></param>
        private void doSummaryByRetInadvfee(Ihsptab ihsptab, DataTable dt_fee)
        {
            String sql_retinadvfee = " SELECT"
                        + " 	ihsp_payinadv.bas_paysumby_id,"
                        + " 	ihsp_payinadv.bas_paytype_id,"
                        + " 	inhospital.bas_patienttype_id,"
                        + " 	Cast('0' AS DECIMAL) AS inadvfee,"
                        + " 	sum(ihsp_payinadv.payfee) AS retinadvfee,"
                        + " 	Cast('0' AS DECIMAL) AS revcefee,"
                        + " 	Cast('0' AS DECIMAL) AS retfee,"
                        + " 	Cast('0' AS DECIMAL) AS realfee"
                        + " FROM"
                        + " 	ihsp_payinadv, inhospital"
                        + " WHERE"
                        + " 	ihsp_payinadv.STATUS IN ('RREC')"
                        + " AND ihsp_payinadv.ihsp_id = inhospital.id"
                        + " AND ihsp_payinadv.chargedate > " + DataTool.addFieldBraces(ihsptab.Startdate)
                        + " AND ihsp_payinadv.chargedate <= " + DataTool.addFieldBraces(ihsptab.Enddate)
                        + " AND ihsp_payinadv.chargedby = " + DataTool.addFieldBraces(ihsptab.Charger_id)
                        + " GROUP BY"
                        + " 	ihsp_payinadv.bas_paysumby_id,"
                        + " 	ihsp_payinadv.bas_paytype_id,"
                        + " 	inhospital.bas_patienttype_id"
                        + " ORDER BY"
                        + " 	ihsp_payinadv.bas_paysumby_id;";
            DataTable dt_retfee = BllMain.Db.Select(sql_retinadvfee).Tables[0];

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
                string retinadvfee = dt_retfee.Rows[i]["retinadvfee"].ToString();
                if (findFlag == 1)
                {
                    dt_fee.Rows[dt_fee_idx]["retinadvfee"] = retinadvfee;
                }
                else
                {
                    dt_fee.Rows.Add();
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_paysumby_id"] = bas_paysumby_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_paytype_id"] = bas_paytype_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_patienttype_id"] = bas_patienttype_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["inadvfee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["retinadvfee"] = retinadvfee;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["revcefee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["retfee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["realfee"] = "0";
                }
            }
        }

        /// <summary>
        /// 汇总预交款
        /// </summary>
        /// <param name="clinictab"></param>
        /// <param name="dt_fee"></param>
        private void doSummaryByRevcefee(Ihsptab ihsptab, DataTable dt_fee)
        {
            String sql_revcefee = " SELECT"
                            + " 	ihsp_invoicedet.bas_paysumby_id,"
                            + " 	ihsp_invoicedet.bas_paytype_id,"
                            +"      ihsp_account.bas_patienttype_id,"
                            + " 	Cast('0' AS DECIMAL) AS inadvfee,"
                            + " 	Cast('0' AS DECIMAL) AS retinadvfee,"
                            + " 	sum(ihsp_invoicedet.payfee) AS revcefee,"
                            + " 	Cast('0' AS DECIMAL) AS retfee,"
                            + " 	Cast('0' AS DECIMAL) AS realfee"
                            + " FROM"
                            + " 	ihsp_invoicedet,"
                            + " 	ihsp_account"
                            + " WHERE"
                            + " 	ihsp_invoicedet.ihsp_account_id = ihsp_account.id"
                            //+ " AND ihsp_account. STATUS IN ('RET', 'CHRG')"
                            + " and ihsp_invoicedet.payfee >0"
                            + " AND ihsp_account.chargedate > " + DataTool.addFieldBraces(ihsptab.Startdate)
                            + " AND ihsp_account.chargedate <= " + DataTool.addFieldBraces(ihsptab.Enddate)
                            + " AND ihsp_account.chargedby_id = " + DataTool.addFieldBraces(ihsptab.Charger_id)
                            + " GROUP BY"
                            + " 	ihsp_invoicedet.bas_paysumby_id,"
                            + " 	ihsp_invoicedet.bas_paytype_id,"
                            + "     ihsp_account.bas_patienttype_id"
                            + " ORDER BY"
                            + " 	bas_paysumby_id;";
            DataTable dt_retfee = BllMain.Db.Select(sql_revcefee).Tables[0];

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
                string revcefee = dt_retfee.Rows[i]["revcefee"].ToString();
                if (findFlag == 1)
                {
                    dt_fee.Rows[dt_fee_idx]["revcefee"] = revcefee;
                }
                else
                {
                    dt_fee.Rows.Add();
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_paysumby_id"] = bas_paysumby_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_paytype_id"] = bas_paytype_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_patienttype_id"] = bas_patienttype_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["inadvfee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["retinadvfee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["revcefee"] = revcefee;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["retfee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["realfee"] = "0";
                }
            }
        }


        /// <summary>
        /// 汇总预交款
        /// </summary>
        /// <param name="clinictab"></param>
        /// <param name="dt_fee"></param>
        private void doSummaryByRetfee(Ihsptab ihsptab, DataTable dt_fee)
        {
            String sql_revcefee = " SELECT"
                            + " 	ihsp_invoicedet.bas_paysumby_id,"
                            + " 	ihsp_invoicedet.bas_paytype_id,"
                            + "      ihsp_account.bas_patienttype_id,"
                            + " 	Cast('0' AS DECIMAL) AS inadvfee,"
                            + " 	Cast('0' AS DECIMAL) AS retinadvfee,"
                            + " 	Cast('0' AS DECIMAL) AS revcefee,"
                            + " 	sum(ihsp_invoicedet.payfee) AS retfee,"
                            + " 	Cast('0' AS DECIMAL) AS realfee"
                            + " FROM"
                            + " 	ihsp_invoicedet,"
                            + " 	ihsp_account"
                            + " WHERE"
                            + " 	ihsp_invoicedet.ihsp_account_id = ihsp_account.id"
                            //+ " AND ihsp_account. STATUS IN ('RREC')"
                            + " and ihsp_invoicedet.payfee <0"
                            + " AND ihsp_account.chargedate > " + DataTool.addFieldBraces(ihsptab.Startdate)
                            + " AND ihsp_account.chargedate <= " + DataTool.addFieldBraces(ihsptab.Enddate)
                            + " AND ihsp_account.chargedby_id = " + DataTool.addFieldBraces(ihsptab.Charger_id)
                            + " GROUP BY"
                            + " 	ihsp_invoicedet.bas_paysumby_id,"
                            + " 	ihsp_invoicedet.bas_paytype_id,"
                            + "     ihsp_account.bas_patienttype_id"
                            + " ORDER BY"
                            + " 	bas_paysumby_id;";
            DataTable dt_retfee = BllMain.Db.Select(sql_revcefee).Tables[0];

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
                string retfee = dt_retfee.Rows[i]["retfee"].ToString();
                if (findFlag == 1)
                {
                    dt_fee.Rows[dt_fee_idx]["retfee"] = retfee;
                }
                else
                {
                    dt_fee.Rows.Add();
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_paysumby_id"] = bas_paysumby_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_paytype_id"] = bas_paytype_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["bas_patienttype_id"] = bas_patienttype_id;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["inadvfee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["retinadvfee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["revcefee"] = "0";
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["retfee"] = retfee;
                    dt_fee.Rows[dt_fee.Rows.Count - 1]["realfee"] = "0";
                }
            }
        }

        /// <summary>
        /// 插入住院班结结算汇总
        /// </summary>
        /// <param name="ihsptab_id"></param>
        /// <returns></returns>
        public string inIhsptabInvoiceamt(Ihsptab ihsptab)
        {
            String sql_num = " SELECT"
                    + " 	bas_patienttype_id,"
                    + " 	sum(num* prepamt) AS inadvfeeamt,"
                    + " 	sum(num* feeamt) AS feeamt,"
                    + " 	sum(num) AS num,"
                    + " 	Cast('0' AS INT) AS retnum,"
                    + " 	Cast('0' AS INT) AS realnum"
                    + " FROM"
                    + "     ihsp_account"
                    + " WHERE"
                    + " chargedby_id = "+ DataTool.addFieldBraces(ihsptab.Charger_id)
                    + " AND chargedate > "+ DataTool.addFieldBraces(ihsptab.Startdate)
                    + " AND chargedate <= "+ DataTool.addFieldBraces(ihsptab.Enddate)
                    + " AND STATUS IN ('SETT', 'RET')"
                    + " GROUP BY bas_patienttype_id";
            DataTable dt_num = BllMain.Db.Select(sql_num).Tables[0];
            doSummaryByRetNum(ihsptab, dt_num);
            string sql_insert = "";
            for (int i = 0; i < dt_num.Rows.Count; i++)
            {
                string ihsptab_invoiceamt_id = BillSysBase.nextId("ihsptab_invoiceamt_id");
                double inadvfeeamt = DataTool.stringToDouble(dt_num.Rows[i]["inadvfeeamt"].ToString());
                double feeamt = DataTool.stringToDouble(dt_num.Rows[i]["feeamt"].ToString());
                int num = DataTool.stringToInt(dt_num.Rows[i]["num"].ToString());
                int retnum = DataTool.stringToInt(dt_num.Rows[i]["retnum"].ToString());
                dt_num.Rows[i]["realnum"] = (num + retnum).ToString();

                sql_insert += "insert into ihsptab_invoiceamt ("
                                + " id "
                                + ",ihsptab_duty_id"
                                + ",bas_patienttype_id"
                                + ",inadvfeeamt"
                                + ",feeamt"
                                + ",num"
                                + ",retnum"
                                + ",realnum"
                                + " ) values ("
                                + DataTool.addFieldBraces(ihsptab_invoiceamt_id)
                                + "," + DataTool.addFieldBraces(ihsptab.Id)
                                + "," + DataTool.addFieldBraces(dt_num.Rows[i]["bas_patienttype_id"].ToString())
                                + "," + DataTool.addFieldBraces(dt_num.Rows[i]["inadvfeeamt"].ToString())
                                + "," + DataTool.addFieldBraces(dt_num.Rows[i]["feeamt"].ToString())
                                + "," + DataTool.addFieldBraces(dt_num.Rows[i]["num"].ToString())
                                + "," + DataTool.addFieldBraces(dt_num.Rows[i]["retnum"].ToString())
                                + "," + DataTool.addFieldBraces(dt_num.Rows[i]["realnum"].ToString())
                                + ");";
            }
            return sql_insert;
           
        }
        private void doSummaryByRetNum(Ihsptab ihsptab, DataTable dt_num)
        {
            String sql_retnum = " SELECT"
                   + " 	bas_patienttype_id,"
                   + " 	sum(num* prepamt) AS inadvfeeamt,"
                   + " 	sum(num* feeamt) AS feeamt,"
                   + " 	Cast('0' AS INT) AS num,"
                   + "  sum(num) AS retnum,"
                   + " 	Cast('0' AS INT) AS realnum"
                   + " FROM"
                   + "     ihsp_account"
                   + " WHERE"
                   + " chargedby_id = " + DataTool.addFieldBraces(ihsptab.Charger_id)
                   + " AND chargedate > " + DataTool.addFieldBraces(ihsptab.Startdate)
                   + " AND chargedate <= " + DataTool.addFieldBraces(ihsptab.Enddate)
                   + " AND STATUS IN ('RREC')"
                   + " GROUP BY bas_patienttype_id";
             DataTable dt_retnum = BllMain.Db.Select(sql_retnum).Tables[0];

              for (int i = 0; i < dt_retnum.Rows.Count; i++)
             {
                string bas_patienttype_id = dt_retnum.Rows[i]["bas_patienttype_id"].ToString();
                int findFlag = 0;
                int dt_fee_idx = 0;
                for (int j = 0; j < dt_num.Rows.Count; j++)
                {
                    string bas_patienttype_id_1 = dt_num.Rows[j]["bas_patienttype_id"].ToString();
                    if ( bas_patienttype_id == bas_patienttype_id_1)
                    {

                        dt_fee_idx = j;
                        findFlag = 1;
                        break;
                    }

              }
              string inadvfeeamt = dt_retnum.Rows[i]["inadvfeeamt"].ToString();
              string feeamt = dt_retnum.Rows[i]["feeamt"].ToString();
              string retnum = dt_retnum.Rows[i]["retnum"].ToString(); 
              if (findFlag == 1)
              {
                    double d_inadvfeeamt = DataTool.stringToDouble(dt_num.Rows[dt_fee_idx]["inadvfeeamt"].ToString()) + DataTool.stringToDouble(inadvfeeamt);
                    double d_feeamt = DataTool.stringToDouble(dt_num.Rows[dt_fee_idx]["feeamt"].ToString()) + DataTool.stringToDouble(feeamt);
                    dt_num.Rows[dt_fee_idx]["inadvfeeamt"] = DataTool.FormatData(d_inadvfeeamt, "2") ;
                    dt_num.Rows[dt_fee_idx]["feeamt"] = DataTool.FormatData(d_feeamt, "2");
                    dt_num.Rows[dt_fee_idx]["retnum"] = retnum;
              }
              else
              {
                    dt_num.Rows.Add();
                    dt_num.Rows[dt_num.Rows.Count - 1]["bas_patienttype_id"] = bas_patienttype_id;
                    dt_num.Rows[dt_num.Rows.Count - 1]["inadvfeeamt"] = inadvfeeamt;
                    dt_num.Rows[dt_num.Rows.Count - 1]["feeamt"] = feeamt;
                    dt_num.Rows[dt_num.Rows.Count - 1]["retnum"] = retnum;
                    dt_num.Rows[dt_num.Rows.Count - 1]["realfee"] = "0";
              }
            }
        }

        /// <summary>
        /// 插入住院日结结算费用汇总
        /// </summary>
        /// <param name="ihsptab"></param>
        /// <returns></returns>
        public string inIhsptabcostset(Ihsptab ihsptab)
        {

            string sql1 = (!string.IsNullOrEmpty(ihsptab.Charger_id) ? (" and ihsp_account.chargedby_id= " + DataTool.addFieldBraces(ihsptab.Charger_id)) : "")
                        + " GROUP BY itemtype ,chargedby_id";

            string sql = "SELECT itemtype"
                                      + " ,SUM(costfee) as costfee"
                                      + " ,SUM(realfee) as realfee"
                                      + " from ihsp_accountdet"
                                      + " left join ihsp_account on ihsp_account.id=ihsp_accountdet.ihsp_account_id"
                                      + " where 1=1 ";
            if (!string.IsNullOrEmpty(ihsptab.Startdate) && !string.IsNullOrEmpty(ihsptab.Enddate) && ihsptab.Startdate != ihsptab.Enddate)
            {
                sql += " and ihsp_account.chargedate >= " + DataTool.addFieldBraces(ihsptab.Startdate) + " and ihsp_account.chargedate<=" + DataTool.addFieldBraces(ihsptab.Enddate);
            }
            sql+= sql1;

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string insql = "";
            if (dt.Rows.Count == 0)
            {
                string id = BillSysBase.nextId("ihsptab_costsettle");
                insql += "insert into ihsptab_costsettle (id,ihsptab_duty_id,costfee,realfee)values(" + id + "," + ihsptab.Id + ",0,0);";
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = BillSysBase.nextId("ihsptab_costsettle");
                insql += "insert into ihsptab_costsettle(id"
                                               + ",ihsptab_duty_id"
                                               + ",itemtype_id"
                                               + ",costfee"
                                               + ",realfee)values(" + DataTool.addFieldBraces(id)
                                               + "," + DataTool.addFieldBraces(ihsptab.Id)
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["costfee"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["realfee"].ToString())
                                               + ");";
            }
            return insql;
        }

      

        /// <summary>
        /// 插入在院核算汇总
        /// </summary>
        /// <param name="ihsptab_id"></param>
        /// <returns></returns>
        public string inIhsptap_costgather(Ihsptab ihsptab)
        {
            string sql = "SELECT ihsp_id"
                        + ",bas_patienttype_id"
                        + ",itemtype1_id"
                        + ",diagndep_id"
                        + ",diagndoctor_id"
                        + ",exedep_id"
                        //+ ",exedoctor_id"
                        + ",SUM(fee) AS costfee"
                        + ",SUM(realfee) AS realfee"
                        + " FROM ihsp_costdet"
                        + " LEFT JOIN inhospital on ihsp_costdet.ihsp_id=inhospital.id"
                        + " where 1=1 and charged<>'OO'"
                        + " and ihsp_costdet.chargedate>" + DataTool.addFieldBraces(ihsptab.Startdate)
                        + " and ihsp_costdet.chargedate<=" + DataTool.addFieldBraces(ihsptab.Enddate)
                        +"  GROUP BY"
                        + " ihsp_id"
                        + " ,charger_id"
                        + " ,exedep_id"
                        + " ,bas_patienttype_id"
                        + " , itemtype1_id"
                        + " , diagndep_id"
                        + " , diagndoctor_id"
                        + " , exedep_id"
                        //+ " , exedoctor_id"
                        ;

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string insql = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = BillSysBase.nextId("ihsptap_costgather");
                insql += "insert into ihsptab_costgather(id"
                                               + ",ihsptab_day_id"
                                               + ",bas_patienttype_id"
                                               + ",itemtype1_id"
                                               + ",diagndep_id"
                                               + ",diagndoctor_id"
                                               + ",exedep_id"
                                              // + ",exedoctor_id"
                                               + ",costfee"
                                               + ",realfee)values(" + DataTool.addFieldBraces(id)
                                               + "," + DataTool.addFieldBraces(ihsptab.Id)
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["bas_patienttype_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype1_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["diagndep_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["diagndoctor_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["exedep_id"].ToString())
                                              // + "," + DataTool.addFieldBraces(dt.Rows[i]["exedoctor_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["costfee"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["realfee"].ToString())
                                               + ");";
            }
            return insql;
        }

        /// <summary>
        /// 插入出院核算汇总
        /// </summary>
        /// <param name="ihsptab_id"></param>
        /// <returns></returns>
        public string inIhsptab_outcostgather(Ihsptab ihsptab)
        {
            string sql = "SELECT ihsp_costdet.ihsp_id"
                         + ",ihsp_account.bas_patienttype_id"
                          + ",ihsp_costdet.itemtype_id"
                         + ",ihsp_costdet.itemtype1_id"
                         + ",ihsp_costdet.diagndep_id"
                         + ",ihsp_costdet.diagndoctor_id"
                         + ",ihsp_costdet.exedep_id"
                //+ ",exedoctor_id"
                         + ",SUM(ihsp_costdetsettle.num* ihsp_costdet.fee) AS costfee"
                         + ",SUM(ihsp_costdetsettle.num* ihsp_costdet.realfee) AS realfee"
                         + " FROM ihsp_costdet"
                         + " INNER JOIN ihsp_costdetsettle on ihsp_costdetsettle.ihsp_costdet_id=ihsp_costdet.id"
                         + " INNER JOIN ihsp_account on ihsp_costdetsettle.ihsp_account_id=ihsp_account.id"
                         + " where ihsp_costdet.charged<>'OO'"
                         + " and ihsp_account.chargedate >" + DataTool.addFieldBraces(ihsptab.Startdate)
                         + " and ihsp_account.chargedate<=" + DataTool.addFieldBraces(ihsptab.Enddate)
                         + " GROUP BY"
                         + " ihsp_id"
                         + " , bas_patienttype_id"
                          + " , itemtype_id"
                         + " , itemtype1_id"
                         + " , diagndep_id"
                         + " , diagndoctor_id"
                         + " , exedep_id"
                         //+ " , exedoctor_id";
                         ;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string insql = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = BillSysBase.nextId("ihsptab_outcostgather");
                insql += "insert into ihsptab_outcostgather(id"
                                               + ",ihsptab_day_id"
                                               + ",bas_patienttype_id"
                                               + ",itemtype1_id"
                                               + ",diagndep_id"
                                               + ",diagndoctor_id"
                                               + ",exedep_id"
                                              // + ",exedoctor_id"
                                               + ",costfee"
                                               + ",realfee)values(" + DataTool.addFieldBraces(id)
                                               + "," + DataTool.addFieldBraces(ihsptab.Id)
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["bas_patienttype_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype1_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["diagndep_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["diagndoctor_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["exedep_id"].ToString())
                                             //  + "," + DataTool.addFieldBraces(dt.Rows[i]["exedoctor_id"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["costfee"].ToString())
                                               + "," + DataTool.addFieldBraces(dt.Rows[i]["realfee"].ToString())
                                               + ");";
            }
            return insql;
        }

       

        

      

        /// <summary>
        /// 获取日结可退结算id
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public DataTable getTabMaxId(string depart)
        {
            string sql = "select max(id) as id from ihsptab_day where depart_id=" + DataTool.addIntBraces(depart) + " and  islock='N'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
       

        /// <summary>
        /// 获取日结可退结算id
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public DataTable getDutyMaxId(string settleby)
        {
            string sql = "select max(id) as id from ihsptab_duty where settleby=" + DataTool.addFieldBraces(settleby) + " and ihsptab_day_id=0";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 班结退结算
        /// </summary>
        /// <param name="dutyid"></param>
        /// <returns></returns>
        public bool deleteIhspTabDuty(string settleby)
        {
            string delsql = "";
            DataTable dt = getDutyMaxId(settleby);
            string id = dt.Rows[0]["id"].ToString();
            delsql += "delete from ihsptab_detail where ihsptab_duty_id=" + DataTool.addIntBraces(id) + ";";
            delsql += "delete from ihsptab_invoiceamt where ihsptab_duty_id=" + DataTool.addIntBraces(id) + ";";
          
            delsql += "delete from ihsptab_duty where id=" + DataTool.addIntBraces(id) + ";";

         

            bool ret = true;
            ///添加住院班结表
            
            if (BllMain.Db.Update(delsql) < 0)
            {
                ret = false;
            }
            return ret;
        }
        /// <summary>
        /// 结算表查询
        /// </summary>
        /// <returns></returns>
        public DataTable accountSearch(string name, Ihsptab ihsptab)
        {
            DataTable dt = new DataTable();
            string sql1 = "";
        
            string sql = "select bas_doctor.name as charger"
                      + ",inhospital.name as ihspname"
                      + ",bas_depart.name as departname"
                      + ",inhospital.ihspcode"
                      + ",inhospital.indate"
                      + ",inhospital.outdate"
                      + ",ihsp_account.prepamt"
                      + ",ihsp_account.feeamt"
                      + ",ihsp_account.retfee"
                      + ",sys_dict.name as paytypename"
                      + ",ihsp_account.ihsptab_id"
                      + " from ihsp_account "
                      + " left join inhospital on inhospital.id=ihsp_account.ihsp_id "
                      + " left join bas_doctor on ihsp_account.chargedby_id=bas_doctor.id "
                      + " left join bas_depart on ihsp_account.depart_id=bas_depart.id "
                      + " left join sys_dict on ihsp_account.bas_paytype_id=sys_dict.sn and sys_dict.dicttype='bas_paytype' and sys_dict.father_id<>0 "
                      + " where 1=1 "
                      + (!string.IsNullOrEmpty(name) ? (" and inhospital.name= " + DataTool.addFieldBraces(name)) : "")
                      +sql1                      
                      ;
           
                dt = BllMain.Db.Select(sql).Tables[0];
         
            return dt;
        }


        /// <summary>
        /// 为住院记录表和科室表的外键服务
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public string getDepartId(string depart)
        {
            string depar = "select id from bas_depart where name = " + DataTool.addFieldBraces(depart);
            DataTable datatable = BllMain.Db.Select(depar).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string dep = datatable.Rows[0]["id"].ToString();
                return dep;
            }
            else
            {
                return "0";
            }
        }

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
            + ",charger_id"
            + ",settledate"
            + ",settleby"
            + ",depart_id)values(" + DataTool.addIntBraces(id)
            + "," + DataTool.addFieldBraces(datatime)
            + "," + DataTool.addFieldBraces(datatime)
            + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
            + "," + DataTool.addFieldBraces(BillSysBase.currDate())
            + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
            + "," + DataTool.addFieldBraces(ProgramGlobal.Depart_id)
            + ");";
            return BllMain.Db.Update(sql);
        }

        public bool getLastIhspTabDuty(Ihsptab ihsptab)
        {
            bool ret = false;
            string sql = "select * from ihsptab_duty where charger_id= " + DataTool.addFieldBraces(ihsptab.Charger_id)
                                  + " and ihsptab_day_id='0' order by id desc limit 1";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ihsptab.Startdate = dt.Rows[0]["startdate"].ToString();
                ihsptab.Enddate = dt.Rows[0]["enddate"].ToString();
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ihsptab"></param>
        /// <returns></returns>
        public bool getLastIhspTab(Ihsptab ihsptab)
        {
            bool ret = false;
            string sql = "select * from ihsptab_day where depart_id= " + DataTool.addFieldBraces(ihsptab.Depart_id)
                                  + " and  islock = 'N' order by id desc limit 1";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ihsptab.Startdate = dt.Rows[0]["startdate"].ToString();
                ihsptab.Enddate = dt.Rows[0]["enddate"].ToString();
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 日退结算
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public string retIhspTab(string depart_id)
        {
            DataTable dt = getTabMaxId(depart_id);
            string ihsptab_id = dt.Rows[0]["id"].ToString();

            //删除强制班结信息    
            string upsql = " delete from ihsptab_detail where ihsptab_duty_id in (select id from ihsptab_duty"
                          + " where ihsptab_day_id = " + DataTool.addFieldBraces(ihsptab_id)
                          + " and daytab='Y');"
                          + " delete from ihsptab_invoiceamt where ihsptab_duty_id in (select id from ihsptab_duty"
                          + " where ihsptab_day_id = " + DataTool.addFieldBraces(ihsptab_id)
                          + " and daytab='Y');"
                          + " delete from ihsptab_duty"
                          + " where ihsptab_day_id = " + DataTool.addFieldBraces(ihsptab_id)
                          + " and daytab='Y';";
            //还原班结信息
            upsql += "update ihsptab_duty set ihsptab_day_id='0'"
                    + " where ihsptab_day_id=" + DataTool.addFieldBraces(ihsptab_id)
                    + ";";
            //删除日结信息
            upsql += "delete from ihsptab_costgather"
                    + " where ihsptab_day_id = " + DataTool.addFieldBraces(ihsptab_id)
                    + ";"
                    + "delete from ihsptab_outcostgather"
                    + " where ihsptab_day_id = " + DataTool.addFieldBraces(ihsptab_id)
                    + ";"
                    + " delete from ihsptab_day"
                    + " where id = " + DataTool.addFieldBraces(ihsptab_id)
                    + ";";
            return upsql;
        }

        

    }
}
