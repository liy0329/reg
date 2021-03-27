using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.clinic.bo;
using MTHIS.db;
using System.Data.SqlClient;
using System.Data.Odbc;
using MTHIS.tools;
using MTREG.common.bll;
using MTREG.common;

namespace MTREG.clinic.bll
{
    class BillClinicRcpCost
    {

        ///<summary>
        ///更新职工医保报销状态
        ///</summary>
        ///<param name="clinicInvoice">
        ///</param>
        ///<returns>
        ///</returns>
        public string updateClinicInvoiceZgmzFlag(string clinicInvoiceId)
        {
            string merge_sql = "";
            if (!string.IsNullOrEmpty(clinicInvoiceId))
            {
                merge_sql = "update clinic_invoice set ybsfsc=301 where id=" + DataTool.addFieldBraces(clinicInvoiceId);
            }
            return merge_sql;
        }












        /// <summary>
        /// 修改支付类别
        /// </summary>
        /// <param name="account_id"></param>
        /// <param name="paytype"></param>
        /// <returns></returns>
        public int upPaytype(string account_id, string paytype)
        {
            string invoice_id = "";
            string sql = "select id from clinic_invoice where account_id=" + DataTool.addIntBraces(account_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                invoice_id += dt.Rows[i]["id"].ToString() + ",";
            }
            if (invoice_id != "")
            {
                invoice_id = invoice_id.Substring(0, invoice_id.Length - 1);
            }
            sql = "update clinic_invoicedet"
                    + " set bas_paytype_id=" + DataTool.addIntBraces(paytype)
                    + " where clinic_invoice_id in (" + invoice_id + ")";
            return BllMain.Db.Update(sql);
        }
        public string getnullnum(string register_id)
        {
            try
            {
                string sql_nullnum = @"select name,(select billcode from clinic_rcp where id = (select clinic_rcp_id from clinic_rcpdetail where id = clinic_costdet.clinic_rcpdetail_id LIMIT 1) LIMIT 1) as billcode from clinic_costdet
                        where (item_id is null or spec is null or unit is null or itemtype1_id is NULL or itemtype_id is null or fee is null or prc is null) 
                        and regist_id = " + register_id + " and charged = 'OO' and itemfrom = 'DRUG'";
                DataSet dataset = BllMain.Db.Select(sql_nullnum);
                if (Convert.ToInt32(dataset.Tables[0].Rows.Count) > 0)
                {
                    string tsxx = "处方有误！！！";
                    for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                    {
                        tsxx += "   项目名称：" + dataset.Tables[0].Rows[i]["name"] + "     处方号：" + dataset.Tables[0].Rows[i]["billcode"];
                    }
                    return tsxx;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取支付类型id
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public string getPaytypeId(string keyname)
        {
            string sql = "select sn,name"
                        + " from sys_dict"
                        + " where dicttype='bas_paytype'"
                        + " and father_id<>0 "
                        + " and keyname =" + DataTool.addFieldBraces(keyname);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string id = dt.Rows[0]["sn"].ToString();
            return id;
        }
        /// <summary>
        /// 获取查询处方挂号信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getRecipelInfo(String patientName, String startDate, String endDate, string hspcard, String depart_id, String regBillcode)
        {

            DataTable dt = null;
            try
            {
                String sql = "select "
                  + " register.id "
                  + ",register.billcode "
                  + ",register.bas_patienttype_id"
                  + ",register.name as regname"
                  + ",(CASE WHEN register.sex='M' THEN '男' WHEN register.sex='W' THEN '女'end) as sex"
                  + ",bas_depart.name as dptname"
                  + ",bas_doctor.name as dctname"
                  + ",bas_doctor.id as doctor_id"
                  + ",bas_depart.id as depart_id"
                  + " from register ,bas_depart,bas_doctor"
                  + " where  "
                  + " register.depart_id = bas_depart.id "
                  + " and register.doctor_id = bas_doctor.id "
                  + " and register.id in ( select clinic_costdet.regist_id  from clinic_costdet,clinic_cost  where clinic_costdet.charged = 'OO' "
                        + " and clinic_costdet.rcpdate>= " + DataTool.addFieldBraces(startDate) + " and clinic_costdet.rcpdate<= " + DataTool.addFieldBraces(endDate)
                        + " and clinic_cost.executed<>'X' and clinic_cost.id = clinic_costdet.clinic_cost_id"
                        + ")"
                  + " and status = 'REG' ";
                 //  + " and prepaid = 'N' ";
                if (!String.IsNullOrEmpty(patientName))
                    sql += " and register.name like '%" + patientName.Trim() + "%' ";
                if (!String.IsNullOrEmpty(hspcard))
                    sql += "  and register.hspcard = " + DataTool.addFieldBraces(hspcard);
                if (depart_id != "0")
                    sql += "  and register.depart_id = " + DataTool.addFieldBraces(depart_id);
                if (!String.IsNullOrEmpty(regBillcode))
                    sql += "  and register.billcode = " + DataTool.addFieldBraces(regBillcode);
                sql += " order by register.regdate desc;";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
            return dt;
        }


        /// <summary>
        /// 收费主表信息
        /// </summary>
        /// <param name="register_id"></param>
        /// <returns></returns>
        public DataTable getClinicCost(String register_id, String startDate, String endDate)
        {
            DataSet dataset = null;
            string type = IniUtils.IniReadValue(IniUtils.syspath, "FEETYPE", "TYPE");

            String sql = "";
            if (String.IsNullOrEmpty(register_id))
            {
                sql = "select "
                + " id"
                + ", billcode"
                + ", rcptype"

                + " from clinic_cost "
                + " where 1!=1";
            }
            else
            {
                sql = "select "
                   + " clinic_cost.id"
                   + ",clinic_cost.billcode"
                   + ",clinic_cost.rcptype"
                   + " from clinic_cost "
                   + " left join clinic_costdet on clinic_cost.id=clinic_costdet.clinic_cost_id"
                   + " RIGHT JOIN register ON register.ID = clinic_cost.regist_id AND register.clininicpay = 'A'"
                   + " where (clinic_cost.ischarged = 'N' or clinic_costdet.charged='OO')";
                if (type == "YAOFANG")
                    sql += " AND clinic_costdet.exedep_id  IN (SELECT depart_id FROM bas_depart_departtype WHERE departtype_id = '90')";
                if (type == "YISHENG")
                    sql += " AND clinic_costdet.exedep_id  IN (SELECT depart_id FROM bas_depart_departtype WHERE departtype_id = '91')";
                if (type == "KESHI")
                    sql += " AND clinic_costdet.exedep_id  IN (SELECT depart_id FROM bas_depart_departtype WHERE departtype_id IN ('93','94'))";

                sql += " and  clinic_cost.regist_id = " + DataTool.addFieldBraces(register_id)
                    + " and clinic_costdet.rcpdate>= " + DataTool.addFieldBraces(startDate) + " and clinic_costdet.rcpdate<= " + DataTool.addFieldBraces(endDate)
                    + " and clinic_cost.executed <> 'X' "
                    + " group by clinic_cost.id"
                    + " order by clinic_cost.rcpdate desc";
            }
            dataset = BllMain.Db.Select(sql);
            DataTable dt = dataset.Tables[0];
            int allcheck = 1;
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Boolean"); //该列的数据类型  
            dc.ColumnName = "checkrcp";//该列得名称  
            dc.DefaultValue = allcheck;//该列得默认值 
            dt.Columns.Add(dc);
            return dt;
        }

        /// <summary>
        /// 获取收费清单信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getClinicCostDet(String clinic_cost_ids)
        {
            DataSet ds = null;
            DataTable dt = null;
            String sql = "";
            if (String.IsNullOrEmpty(clinic_cost_ids))
            {
                sql = " select "
                   + " clinic_costdet.item_id"
                   + ", cost_itemtype.name as itemtype"
                   + ", bas_depart.name as depart"
                   + ", clinic_costdet.name"
                   + ", clinic_costdet.spec"
                   + ", clinic_costdet.unit"
                   + ", clinic_costdet.prc"
                   + ", clinic_costdet.num"
                   + ", ROUND(clinic_costdet.realfee,2) as realfee"
                   + ", clinic_costdet.discnt"
                   + " from clinic_costdet "
                   + " left join cost_itemtype"
                   + " on clinic_costdet.itemtype_id = cost_itemtype.id"
                   + " left join bas_depart "
                   + " on clinic_costdet.exedep_id = bas_depart.id"
                   + " where 1!=1";

                ds = BllMain.Db.Select(sql);
            }
            else
            {
                sql = " select "
                   + " clinic_costdet.item_id"
                   + ", cost_itemtype.name as itemtype"
                   + ", bas_depart.name as depart"
                   + ", clinic_costdet.name"
                   + ", clinic_costdet.spec"
                   + ", clinic_costdet.unit"
                   + ", clinic_costdet.prc"
                   + ", clinic_costdet.num"
                   + ", ROUND(clinic_costdet.realfee,2) as realfee"
                   + ", clinic_costdet.discnt"
                   + " from clinic_costdet "
                   + " left join cost_itemtype"
                   + " on clinic_costdet.itemtype_id = cost_itemtype.id"
                   + " left join bas_depart "
                   + " on clinic_costdet.exedep_id = bas_depart.id"
                   + " where clinic_costdet.clinic_cost_id in ("
                    + clinic_cost_ids + ")"
                   + " and clinic_costdet.charged=" + DataTool.addFieldBraces(CostCharged.OO.ToString())
                   + " order by depart,clinic_costdet.id";
                ds = BllMain.Db.Select(sql);
            }
            try
            {
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception e)
            {

            }
            return null;
        }
        /// <summary>
        /// 加载GroupBox控件的只读信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getSickInfo(string register_id)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(register_id))
                return dt;
            try
            {
                String sql = "SELECT "
                   + " register.id"
                   + ",register.name"
                   + ",register.sex"
                   + ",register.age"
                   + ",register.billcode"
                   + ",bas_depart.name as dptname"
                   + ",bas_doctor.name as dctname"
                   + ",register.bas_patienttype_id "
                   + ",cost_insurtype.keyname"
                   + ",register.hspcard"
                   + ",ihsp_info.idcard"
                   + ",ihsp_info.homephone"
                   + ",ihsp_info.homeaddress"
                   + " from register left join bas_depart on register.depart_id = bas_depart.id"
                   + " left join bas_doctor on register.doctor_id = bas_doctor.id "
                   + " left join ihsp_info on ihsp_info.ihsp_id = register.id  and registkind='CLIN'"
                   + " left join cost_insurtype on cost_insurtype.id ="
                   + " (select cost_insurtype_id from bas_patienttype where id = register.bas_patienttype_id)";
                if (!String.IsNullOrEmpty(register_id))
                    sql += " where register.id = " + DataTool.addFieldBraces(register_id);
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 获取挂号部门信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getRegDepartInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                String sqlDepart = "select id,name from bas_depart where id in (select depart_id from bas_depart_departtype where departtype_id in(select id from bas_departtype where typecode in('CLIN','IHSP')))";
                dt = BllMain.Db.Select(sqlDepart).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// 加载医生下拉框信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getDoctorInfo(string depart_id)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select "
                + " bas_doctor.id"
                + ",bas_doctor.name"
                + " from "
                + " bas_doctor "
                + " where "
                + " bas_doctor.isstop = 'N'"
                + " and bas_doctor.id in (select doctor_id from bas_doctor_doctype where doctype='DOCTOR') ";
                if (!(String.IsNullOrEmpty(depart_id) || depart_id == "") && depart_id != "0")
                    sql += " and depart_id = "
                             + DataTool.addFieldBraces(depart_id);
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// 加载医生信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getDoctor_View(string bas_doctor_name)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select "
                + " bas_doctor.id as doc_id"
                + ",bas_doctor.name as doc_name"
                + ",bas_depart.id as dep_id"
                + ",bas_depart.`name` as dep_name"
                + " from "
                + " bas_doctor "
                + " LEFT JOIN bas_depart ON bas_depart.id =bas_doctor.depart_id"
                + " where "
                + " bas_doctor.isstop = 'N'"
                + " and bas_doctor.id in (select doctor_id from bas_doctor_doctype where doctype='DOCTOR') ";
                if (!(String.IsNullOrEmpty(bas_doctor_name) || bas_doctor_name == "") && bas_doctor_name != "0")
                    sql += " and (bas_doctor. NAME LIKE '%" + bas_doctor_name + "%'  OR bas_doctor.pincode LIKE '%" + bas_doctor_name + "%')";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 下拉框信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getChargebyInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select "
                + " bas_doctor.id"
                + ",bas_doctor.name"
                + " from "
                + " bas_doctor "
                + " where "
                + " bas_doctor.isstop = 'N'"
                + " and bas_doctor.id in (select doctor_id from bas_doctor_doctype where doctype='CLICCHARGR') ";

                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// 加载就诊类别下拉框信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getPatientType()
        {
            DataTable dt = new DataTable();
            try
            {
                //井陉仅显示医保
                String sqlRegtype = "select id,name,keyname from bas_patienttype where isclinic='Y' ";
                dt = BllMain.Db.Select(sqlRegtype).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 插入一条门诊结算记录
        /// </summary>
        /// <param name="clinicAccount">门诊结算参数类</param>
        /// <returns></returns>
        public int addClinicAccount(ClinicAccount clinicAccount, ref string merge_sql)
        {
            String sql = "insert into clinic_account ( "
                            + "id"
                            + ", billcode"
                            + ", regist_id"
                            + ", recivefee"
                            + ", realfee"
                            + ", retfee"
                            + ", Insurefee"
                            + ", insuraccountfee"
                            + ", settledep_id"
                            + ", settledby"
                            + ", bas_paytype_id"
                            + ", cheque"
                            + ", payfee"
                            + ", hisOrderNo"
                            + ", settledate) values("
                            + DataTool.addFieldBraces(clinicAccount.Id)
                            + "," + DataTool.addFieldBraces(clinicAccount.Billcode)
                            + "," + DataTool.addFieldBraces(clinicAccount.Regist_id)
                            + "," + DataTool.addFieldBraces(clinicAccount.Recivefee)
                            + "," + DataTool.addFieldBraces(clinicAccount.Realfee)
                            + "," + DataTool.addFieldBraces(clinicAccount.Retfee)
                            + "," + DataTool.addFieldBraces(clinicAccount.Insurefee)
                            + "," + DataTool.addFieldBraces(clinicAccount.Insuraccountfee)
                            + "," + DataTool.addFieldBraces(clinicAccount.Settledep_id)
                            + "," + DataTool.addFieldBraces(clinicAccount.Settledby)
                            + "," + DataTool.addFieldBraces(clinicAccount.Bas_paytype_id)
                            + "," + DataTool.addFieldBraces(clinicAccount.Cheque)
                            + "," + DataTool.addFieldBraces(clinicAccount.Payfee)
                            + "," + DataTool.addFieldBraces(clinicAccount.HisOrderNo)
                            + "," + DataTool.addFieldBraces(clinicAccount.Settledate)
                            + " );";
            merge_sql += sql;

            return 0;
        }
        /// <summary>
        /// 插入一条门诊发票记录
        /// </summary>
        /// <param name="clinicInvoice">门诊发票参数类</param>
        /// <param name="clinic_invoice_id">主键值</param>
        /// <param name="clinic_account_id">门诊结算外键</param>
        /// <returns></returns>
        public int addClinicInvoice(ClinicInvoice clinicInvoice, ref string merge_sql)
        {
            String sql = "insert into clinic_invoice ( "
                + "id"
                + ", account_id"
                + ", regist_id"
                + ", isregist"
                + ", sickname"
                + ", rcpdep_id"
                + ", rcpdoctor_id"
                + ", fee"
                + ", discnt"
                + ", realfee"
                + ", bas_patienttype_id"
                + ", billcode"
                + ", invoice"
                + ", depart_id"
                + ", chargedate"
                + ", chargeby"
                + ", charged"
                + ", insurstat"
                + ", Insurefee"
                + ", insuraccountfee"
                + ", insurotherfee"
                + ",exedep_id"
                + ",bas_patienttype1_id"
                + ",bas_paytype_id"
                + ",payfee"
                + ",hisOrderNo"
                + ", clinic_tab_id,ybsfsc ) values("
                + DataTool.addFieldBraces(clinicInvoice.Id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Account_id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Regist_id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Isregist)
                + "," + DataTool.addFieldBraces(clinicInvoice.Sickname)
                + "," + DataTool.addFieldBraces(clinicInvoice.Rcpdep_id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Rcpdoctor_id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Fee)
                + "," + DataTool.addFieldBraces(clinicInvoice.Discnt)
                + "," + DataTool.addFieldBraces(clinicInvoice.Realfee)
                + "," + DataTool.addFieldBraces(clinicInvoice.Bas_patienttype_id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Billcode)
                + "," + DataTool.addFieldBraces(clinicInvoice.Invoice)
                + "," + DataTool.addFieldBraces(clinicInvoice.Depart_id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Chargedate)
                + "," + DataTool.addFieldBraces(clinicInvoice.Chargeby)
                + "," + DataTool.addFieldBraces(clinicInvoice.Charged)
                + "," + DataTool.addFieldBraces(clinicInvoice.Insurstat)
                + "," + DataTool.addFieldBraces(clinicInvoice.Insurefee)
                + "," + DataTool.addFieldBraces(clinicInvoice.Insuraccountfee)
                + "," + DataTool.addFieldBraces(clinicInvoice.Insurotherfee)
                + "," + DataTool.addFieldBraces(clinicInvoice.Exedep_id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Bas_patienttype1_id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Bas_paytype_id)
                + "," + DataTool.addFieldBraces(clinicInvoice.Payfee)
                + "," + DataTool.addFieldBraces(clinicInvoice.HisOrderNo)
                + "," + DataTool.addFieldBraces(clinicInvoice.Clinic_tab_id)
                + ",0 "
                + " );";
            if (!string.IsNullOrEmpty(clinicInvoice.HisOrderNo))
            {
                sql += "update netpaydata set hisstat = 1 where outerOrderNo=" + DataTool.addFieldBraces(clinicInvoice.HisOrderNo) + ";";
            }
            merge_sql += sql;
            merge_sql += clinicInvoice.Nextinvoicesql;
            return 0;
        }
        /// <summary>
        /// 插入一条发票支付记录
        /// </summary>
        /// <param name="clinic_invoicedet_id">主键值</param>
        /// <param name="clinic_invoice_id">发票外键</param>
        /// <param name="payfee">应付金额</param>
        /// <param name="bas_paytype_id">收款类型</param>
        /// <param name="cheque">支票号</param>
        /// <returns></returns>
        public int addClinicInvoicedet(ClinicInvoiceDet clinicInvoiceDet, ref string merge_sql)
        {
            string clinic_invoicedet_id = BillSysBase.nextId("clinic_invoicedet");
            String sql = "insert into clinic_invoicedet ( "
                + " id"
                + ", clinic_invoice_id"
                + ", payfee"
                + ", bas_paytype_id"
                + ", bas_paysumby_id"
                + ", cheque ) values("
                + DataTool.addFieldBraces(clinic_invoicedet_id)
                + "," + DataTool.addFieldBraces(clinicInvoiceDet.Clinic_invoice_id)
                + "," + DataTool.addFieldBraces(clinicInvoiceDet.Payfee)
                + "," + DataTool.addFieldBraces(clinicInvoiceDet.Bas_paytype_id)
                + "," + DataTool.addFieldBraces(clinicInvoiceDet.Bas_paysumby_id)
                + "," + DataTool.addFieldBraces(clinicInvoiceDet.Cheque)
                 + " );";
            merge_sql += sql;
            return 0;
        }

        /// <summary>
        ///修改收费主表
        /// </summary>
        /// <returns></returns>
        ///
        public int upClinicCost(ClinicInvoice clinicInvoice, ref string merge_sql)
        {

            String sql = "update clinic_cost  set "
                + " clinicInvoice = " + DataTool.addFieldBraces(clinicInvoice.Invoice)
                + ",clinic_invoice_id=" + DataTool.addFieldBraces(clinicInvoice.Id)
                + ",ischarged = 'Y' "
                + " ,chargedate = " + DataTool.addFieldBraces(clinicInvoice.Chargedate)
                + ",chargeby = " + DataTool.addFieldBraces(clinicInvoice.Chargeby)
                + " where id in ("
                + clinicInvoice.Clinic_cost_ids
                + ");";
            merge_sql += sql;
            return 0;
        }
        /// <summary>
        ///修改收费主表_自费会员卡结算不更新明细收费状态
        /// </summary>
        /// <returns></returns>
        ///
        public int upClinicCost_zf(ClinicInvoice clinicInvoice, ref string merge_sql)
        {

            String sql = "update clinic_cost  set "
                + " clinicInvoice = " + DataTool.addFieldBraces(clinicInvoice.Invoice)
                + ",clinic_invoice_id=" + DataTool.addFieldBraces(clinicInvoice.Id)
                //+ ",ischarged = 'Y' "
                //+ " ,chargedate = " + DataTool.addFieldBraces(clinicInvoice.Chargedate)
                //+ ",chargeby = " + DataTool.addFieldBraces(clinicInvoice.Chargeby)
                + " where id in ("
                + clinicInvoice.Clinic_cost_ids
                + ");";
            merge_sql += sql;
            return 0;
        }

        /// <summary>
        ///修改收费明细
        /// </summary>
        /// <returns></returns>
        ///
        public int upClinicCostdet(ClinicInvoice clinicInvoice, ref string merge_sql)
        {
            if (string.IsNullOrEmpty(clinicInvoice.Clinic_costdet_ids))
                return -1;
            String sql = "update clinic_costdet set "
                + " clinic_Invoice_id = " + DataTool.addFieldBraces(clinicInvoice.Id)
                + ",bas_patienttype_id = " + DataTool.addFieldBraces(clinicInvoice.Bas_patienttype_id)
                // + ",unlocked = " + DataTool.addFieldBraces("Y")
                + ",retappstat = " + DataTool.addFieldBraces("Y")
                + ",charged = " + DataTool.addFieldBraces(clinicInvoice.Charged)
                + ", chargedate = " + DataTool.addFieldBraces(clinicInvoice.Chargedate)
                + ", chargeby = " + DataTool.addFieldBraces(clinicInvoice.Chargeby)
                + " where id in (" + clinicInvoice.Clinic_costdet_ids + ");";
            merge_sql += sql;
            return 0;
        }/// <summary>
        ///修改收费明细_自费会员卡结算不更新明细收费状态
        /// </summary>
        /// <returns></returns>
        ///
        public int upClinicCostdet_zf(ClinicInvoice clinicInvoice, ref string merge_sql)
        {
            if (string.IsNullOrEmpty(clinicInvoice.Clinic_costdet_ids))
                return -1;
            String sql = "update clinic_costdet set "
                + " clinic_Invoice_id = " + DataTool.addFieldBraces(clinicInvoice.Id)
                //+ ",bas_patienttype_id = " + DataTool.addFieldBraces(clinicInvoice.Bas_patienttype_id)
                //// + ",unlocked = " + DataTool.addFieldBraces("Y")
                //+ ",retappstat = " + DataTool.addFieldBraces("Y")
                //+ ",charged = " + DataTool.addFieldBraces(clinicInvoice.Charged)
                //+ ", chargedate = " + DataTool.addFieldBraces(clinicInvoice.Chargedate)
                //+ ", chargeby = " + DataTool.addFieldBraces(clinicInvoice.Chargeby)
                + " where id in (" + clinicInvoice.Clinic_costdet_ids + ");";
            merge_sql += sql;
            return 0;
        }
        //public int modifyClinicCost(string id,string fee,string realfee,ref string merge_sql)
        //{ 
        //    string sql = "update clinic_cost set "
        //        + " recipelfee = " + DataTool.addFieldBraces(fee.ToString())
        //        + ",realfee = " + DataTool.addFieldBraces(realfee.ToString())
        //        + " where id = " + DataTool.addFieldBraces(id)
        //        + ";";

        //       merge_sql += sql;
        //    return 0;
        //}
        //public int modifyClinicCostdet(string id ,string prc,string fee,string discnt,string realfee,ref string merge_sql)
        //{
        //    string sql = "update clinic_costdet set "
        //        + " prc = " + DataTool.addFieldBraces(prc)
        //        + ",fee = " + DataTool.addFieldBraces(fee)
        //        + ",discnt = " + DataTool.addFieldBraces(discnt)
        //        + ",realfee = " + DataTool.addFieldBraces(realfee)
        //        + " where id = " + DataTool.addFieldBraces(id)
        //        + ";";

        //       merge_sql += sql;
        //    return 0;
        //}
        public int addDrugIoItem(DrugIo drugIo, ref string merge_sql)
        {

            String sql = "insert into drug_io ("
                    + " id"
                    + ",iokind"
                    + ",billcode"
                    + ",drug_app_id"
                    + ",actdept_id"
                    + ",objdept_id"
                    + ",opstat"
                    + ",amount"
                    + ",createdby"
                    + ",createdate ) values ("
                    + DataTool.addFieldBraces(drugIo.Id)
                    + "," + DataTool.addFieldBraces(DrugIoKind.OUT04.ToString())
                    + "," + DataTool.addFieldBraces(BillSysBase.newBillcode("drug_io_billcode"))
                    + "," + DataTool.addFieldBraces(drugIo.Clinic_cost_id)
                    + "," + DataTool.addFieldBraces(drugIo.Actdept_id)
                    + "," + DataTool.addFieldBraces(drugIo.Objdept_id)
                    + "," + DataTool.addFieldBraces(DrugOpStat.APP.ToString())
                    + "," + DataTool.addFieldBraces(drugIo.Amount)
                    + "," + "-1"
                    + "," + DataTool.addFieldBraces(drugIo.Createdate)
                 + " );";
            merge_sql += sql;
            return 0;
        }
        public int addDrugIo(string id, string objdpt, ref string merge_sql)
        {
            string sql = "update drug_io "
                       + " set objdept_id = "
                       + DataTool.addFieldBraces(objdpt)
                       + " where id = "
                       + DataTool.addFieldBraces(id)
                       + ";";
            merge_sql += sql;
            return 0;
        }
        public int modifyDrugIoState(string clinic_cost_ids)
        {
            string sql = "update drug_io "
                       + " set opstat = " + DataTool.addFieldBraces(DrugOpStat.APP.ToString())
                       + " where drug_app_id in ( " + clinic_cost_ids + ");";
            return doExeSql(sql);
        }
        public int modifyDrugIoDetState(string clinic_costdet_ids)
        {
            string sql = "update drug_iodetail "
                       + " set opstat = " + DataTool.addFieldBraces(DrugOpStat.APP.ToString())
                       + " where costdet_id in ( " + clinic_costdet_ids + ");";
            return doExeSql(sql);
        }
        public DataTable getDrugIoDetId(string clinic_costdet_ids)
        {
            string sql = "select drug_iodetail.id"
                         + ",bas_drugstock.qty - bas_drugstock.useqty as qty"
                         + ",bas_drugstock.itemname"
                         + " from  drug_iodetail"
                         + " left join bas_drugstock"
                         + " on drug_iodetail.item_id = bas_drugstock.item_id "
                         + " and abs(drug_iodetail.realprc - bas_drugstock.realprc)<0.00001 "
                         + " and drug_iodetail.drug_packsole_id = bas_drugstock.drug_packsole_id"
                         + " and drug_iodetail.packsole = bas_drugstock.packsole"
                         + " and drug_iodetail.objdept_id = bas_drugstock.execdept_id"
                         + " where costdet_id in ( " + clinic_costdet_ids
                         + " );";
            return BllMain.Db.Select(sql).Tables[0];
        }
        public int addDrugIoDetailItem(DrugIodetail drugIodetail, ref string merge_sql)
        {

            string packsole = drugIodetail.Packsole;
            string drug_packsole_id = "";
            string packsoleprc = "";
            string packsoleqty = "";
            if (packsole == "Y")
            {
                drug_packsole_id = drugIodetail.Drug_packsole_id;
                packsoleprc = drugIodetail.Packsoleprc;
                packsoleqty = drugIodetail.Packsoleqty;
            }
            else if (packsole == "N")
            {
                drug_packsole_id = "0";
                packsoleprc = drugIodetail.Realprc;
                packsoleqty = drugIodetail.Qty;
            }
            //string selectsql = "select qty "
            //                    + " from bas_drugstock"
            //                    + " where item_id=" + DataTool.addIntBraces(drugIodetail.Item_id)
            //                    + " and realprc=" + DataTool.addFieldBraces(drugIodetail.Realprc);
            //DataSet ds = BllMain.Db.Select(selectsql);
            //if (ds.Tables.Count == 0)
            //{
            //    return -1;
            //}
            //else
            //{
            //    DataTable dtqty = BllMain.Db.Select(selectsql).Tables[0];
            //    if (string.IsNullOrEmpty(dtqty.Rows[0]["qty"].ToString()))
            //    {
            //        return -1;
            //    }
            //    else if (double.Parse(drugIodetail.Qty) > double.Parse(dtqty.Rows[0]["qty"].ToString()))
            //    {
            //        return -1;
            //    }
            //}            
            String sql = "insert into drug_iodetail ("
                + "id"
                + ",drugio_id"
                + ",iokind"
                + ",costdet_id"
                + ",opstat"
                + ",objdept_id"
                + ",item_id"
                + ",name"
                + ",spec"
                + ",unit"
                + ",qty"
                + ",realprc"
                + ",packsole"
                + ",packsoleunit"
                + ",packsoleqty"
                + ",packsoleprc"
                + ",drug_packsole_id"
                + ",iotype) values ("
                 + DataTool.addFieldBraces(drugIodetail.Id)
                + "," + DataTool.addFieldBraces(drugIodetail.Drugio_id)
                + "," + DataTool.addFieldBraces(DrugIoKind.OUT04.ToString())
                + "," + DataTool.addFieldBraces(drugIodetail.Costdet_id)
                + "," + DataTool.addFieldBraces(DrugOpStat.APP.ToString())
                + "," + DataTool.addFieldBraces(drugIodetail.Objdept_id)
                + "," + DataTool.addFieldBraces(drugIodetail.Item_id)
                + "," + DataTool.addFieldBraces(drugIodetail.Name)
                + "," + DataTool.addFieldBraces(drugIodetail.Spec)
                + "," + DataTool.addFieldBraces(drugIodetail.Unit)
                + "," + DataTool.addFieldBraces(drugIodetail.Qty)
                + "," + DataTool.addFieldBraces(drugIodetail.Realprc)
                + "," + DataTool.addFieldBraces(drugIodetail.Packsole)
                + "," + DataTool.addFieldBraces(drugIodetail.Packsoleunit)
                + "," + DataTool.addFieldBraces(packsoleqty)
                + "," + DataTool.addFieldBraces(packsoleprc)
                + "," + DataTool.addFieldBraces(drug_packsole_id)
                + "," + DataTool.addFieldBraces("-1")
                 + " );";
            merge_sql += sql;
            return 0;
        }
        //查询药品io表所需要的数据
        public DataTable getDrugIo(string ids)
        {
            DataTable dt = new DataTable();
            String sql = "select "
                + " clinic_cost.id as cost_id"
                + ",clinic_cost.depart_id "
                + ",clinic_costdet.exedep_id"
                + ",sum(clinic_costdet.realfee) as amount"
                + " from clinic_cost left join clinic_costdet"
                + " on clinic_cost.id = clinic_costdet.clinic_cost_id"
                + " where clinic_cost.id in ( "
                + " select clinic_cost_id from clinic_costdet where itemfrom = "
                + DataTool.addFieldBraces(BasItemFrom.DRUG.ToString())
                + " and clinic_cost_id in ("
                + ids
                + " )) and clinic_costdet.itemfrom = "
                + DataTool.addFieldBraces(BasItemFrom.DRUG.ToString())
                + "group by cost_id";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        public DataTable getDrugIoDet(string cost_id)
        {
            DataTable dt = new DataTable();
            string sql = "select "
                       + " id"
                       + ",item_id"
                       + ",name"
                       + ",spec"
                       + ",unit"
                       + ",num"
                       + ",prc"
                       + ",packsole"
                       + ",drug_packsole_id"
                       + ",realfee"
                       + ",exedep_id"
                       + " from clinic_costdet"
                       + " where clinic_cost_id = "
                       + DataTool.addFieldBraces(cost_id)
                       + " and itemfrom = "
                       + DataTool.addFieldBraces(BasItemFrom.DRUG.ToString());
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        //执行sql语句
        public int doExeSql(string sql)
        {
            int result = -1;
            try
            {
                result = BllMain.Db.Update(sql);
            }
            catch (Exception e)
            {
                SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + e.ToString());
            }

            return result;
        }

        ///根据患者类型id或者外键， 获取信息
        /// </summary>
        /// <returns></returns>
        public DataTable getPayItemsById(String patienttype)
        {
            DataTable dt = new DataTable();
            String sql = "select "
                          + " sys_dict.name"
                          + ",sys_dict.sn as id"
                          + ",clinic_paytype.readonly "
                          + ",sys_dict.keyname"
                          + ",'' as fee"
                          + ",'' as cheque"
                          + " from clinic_paytype left join sys_dict "
                          + " on clinic_paytype.bas_paytype_id = sys_dict.sn"
                          + " where sys_dict.father_id<>0 and sys_dict.dicttype = 'bas_paytype' "
                          + " and sys_dict.isstop = 'N' and clinic_paytype.bas_patienttype_id = "
                          + DataTool.stringToInt(patienttype) + " order by sys_dict.id";
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
        /// 由患者类型id得到患者类型keyname
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getPatienttypeKeyname(string id)
        {
            DataTable dt = new DataTable();
            string ret = "";
            string sql = "select "
                  + " keyname"
                  + " from cost_insurtype where id = (select cost_insurtype_id from bas_patienttype"
                  + " where id = "
                  + DataTool.addFieldBraces(id)
                  + " and isstop = 'N'"
                  + ")";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
                ret = dt.Rows[0]["keyname"].ToString();
            }
            catch (Exception e)
            {

            }
            return ret;
        }
        /// <summary>
        /// 由患者类型得到发票类型
        /// </summary>
        /// <param name="patienttype_id"></param>
        /// <returns></returns>
        public string getInvoiceKind(string patienttype_id)
        {
            DataTable dt = new DataTable();
            string sql = "select sys_clinicinvoicekind_id from bas_patienttype where id = " + DataTool.addFieldBraces(patienttype_id);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0][0].ToString();

        }
        /// <summary>
        /// 查询剩余发票号
        /// </summary>
        /// <param name="patienttype_id"></param>
        /// <param name="chargeer"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public DataTable getInvoiceNum(string patienttype_id, string chargeer, string ip)
        {
            DataTable dt = new DataTable();
            string sql = "select endnum,currnum from sys_invoice where charger = " + DataTool.addFieldBraces(chargeer)
                + "and workstate = " + DataTool.addFieldBraces(ip) + "and sys_invoicekind_id = (select sys_clinicinvoicekind_id from bas_patienttype where id = "
                + DataTool.addFieldBraces(patienttype_id) + ")";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }



        public int doPayAppDrugIo(string clinic_cost_ids, string clinic_costdet_ids, ref string itemname)
        {
            if (clinic_costdet_ids == "")
            {
                return 0;
            }
            DataTable dt = getDrugIoDetId(clinic_costdet_ids);
            int j = 0;
            if (j > 0)
            {
                return 0;
            }
            else if (j == 0)
            {
                modifyDrugIoState(clinic_cost_ids);
                return 1;
            }
            return 1;
        }
        /// <summary>
        /// 判断处方是否存在
        /// </summary>
        /// <param name="billcodes"></param>
        /// <param name="clinic_cost_ids"></param>
        /// <param name="rcpbills"></param>
        /// <returns></returns>
        public int isRcpExist(string billcodes, string clinic_cost_ids, ref string rcpbills)
        {
            string[] clinic_cost_id = clinic_cost_ids.Split(',');
            string[] billcode = billcodes.Split(',');
            string sql = "select count(*) from clinic_cost where id in (" + clinic_cost_ids + ")";
            int num = clinic_cost_id.Length - int.Parse(BllMain.Db.Select(sql).Tables[0].Rows[0][0].ToString());
            if (num != 0)
            {
                sql = "select id,billcode from clinic_cost where id in (" + clinic_cost_ids + ")";
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                for (int i = 0; i < clinic_cost_id.Length; i++)
                {
                    int j = 0;
                    for (; j < dt.Rows.Count; j++)
                    {
                        if (clinic_cost_id[i] == dt.Rows[j]["id"].ToString())
                        {
                            break;
                        }
                    }
                    if (j == dt.Rows.Count)
                    {
                        rcpbills += billcode[i] + ",";
                    }
                }
                rcpbills = rcpbills.Substring(0, rcpbills.Length - 1);
            }
            return num;
        }
        /// <summary>
        /// 结算单Id 是否存在
        /// </summary>
        /// <returns></returns>
        public bool accountIdIshave(string id)
        {
            string sql = "select id from clinic_account where id=" + DataTool.addIntBraces(id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 追加支付信息
        /// </summary>
        /// <param name="clinicInvoice"></param>
        /// <returns></returns>
        public string addClinicInvoice(ClinicInvoice clinicInvoice)
        {
            string merge_sql = "";

            if (!string.IsNullOrEmpty(clinicInvoice.HisOrderNo))
            {
                merge_sql = "update clinic_invoice set hisOrderNo=" + DataTool.addFieldBraces(clinicInvoice.HisOrderNo) + " where id=" + DataTool.addFieldBraces(clinicInvoice.Id) + ";"
                          + " update netpaydata set hisstat = 1 where outerOrderNo=" + DataTool.addFieldBraces(clinicInvoice.HisOrderNo) + ";";
            }
            return merge_sql;
        }
        /// <summary>
        /// 门诊发票合并信息
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <param name="clinic_cost_ids"></param>
        /// <param name="clinic_costdet_ids"></param>
        /// <param name="clinicAccount"></param>
        /// <param name="clinicInvoice"></param>
        /// <param name="clinicInvoiceDetList"></param>
        /// <param name="account_id"></param>
        /// <returns></returns>
        public string doClinicInvoice(ClinicInvoice clinicInvoice, List<ClinicInvoiceDet> clinicInvoiceDetList)
        {
            string merge_sql = "";


            addClinicInvoice(clinicInvoice, ref merge_sql);//发票表

            //发票支付明细
            for (int i = 0; i < clinicInvoiceDetList.Count; i++)
            {
                if (DataTool.stringToDouble(clinicInvoiceDetList[i].Payfee) >= 0.00)
                {
                    addClinicInvoicedet(clinicInvoiceDetList[i], ref merge_sql);
                }
            }
            //发票支付明细_END
            //更新收费
            upClinicCost(clinicInvoice, ref merge_sql);
            upClinicCostdet(clinicInvoice, ref merge_sql);
            //更新收费_END

            doRcpCharge(clinicInvoice, ref merge_sql);//更新处方
            return merge_sql;
        }
        /// <summary>
        /// 门诊发票合并信息_自费会员卡结算不更新明细收费状态
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <param name="clinic_cost_ids"></param>
        /// <param name="clinic_costdet_ids"></param>
        /// <param name="clinicAccount"></param>
        /// <param name="clinicInvoice"></param>
        /// <param name="clinicInvoiceDetList"></param>
        /// <param name="account_id"></param>
        /// <returns></returns>
        public string doClinicInvoice_zf(ClinicInvoice clinicInvoice, List<ClinicInvoiceDet> clinicInvoiceDetList)
        {
            string merge_sql = "";


            addClinicInvoice(clinicInvoice, ref merge_sql);//发票表

            //发票支付明细
            for (int i = 0; i < clinicInvoiceDetList.Count; i++)
            {
                if (DataTool.stringToDouble(clinicInvoiceDetList[i].Payfee) >= 0.00)
                {
                    addClinicInvoicedet(clinicInvoiceDetList[i], ref merge_sql);
                }
            }
            //发票支付明细_END
            //更新收费
            upClinicCost_zf(clinicInvoice, ref merge_sql);
            upClinicCostdet_zf(clinicInvoice, ref merge_sql);
            //更新收费_END

            //doRcpCharge(clinicInvoice, ref merge_sql);//更新处方
            return merge_sql;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string doClinicAccount(ClinicAccount clinicAccount)
        {
            string merge_sql = "";
            addClinicAccount(clinicAccount, ref merge_sql);//结算表_移走
            return merge_sql;
        }

        /// <summary>
        /// 撤销医保结成功， HIS未成功信息，
        /// </summary>
        /// <param name="clinicAccounts"></param>
        /// <returns></returns>
        public int doCancleInsurInvoice(List<ClinicInvoice> clinicInvoices)
        {
            string clinic_invoice_ids = "";
            for (int i = 0; i < clinicInvoices.Count; i++)
            {
                ClinicInvoice clinicInvoice = clinicInvoices[i];
                clinic_invoice_ids += DataTool.addFieldBraces(clinicInvoice.Id) + ",";
            }
            if (string.IsNullOrEmpty(clinic_invoice_ids))
            {
                return 0;
            }
            clinic_invoice_ids = clinic_invoice_ids.Remove(clinic_invoice_ids.Length - 1);
            string sql = "update gysyb_mz set hisaccount='1' where gysyb_mtmzblstuff_iid in (" + clinic_invoice_ids + ");"
                        + "update gzsyb_mzfyb set hisaccount='1' where mtmzblstuffiid in (" + clinic_invoice_ids + ");";

            return BllMain.Db.Update(sql);


        }
        /// <summary>
        /// 更新处方为收费状态
        /// </summary>
        /// <param name="clinic_cost_ids"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int doRcpCharge(ClinicInvoice clinicInvoice, ref string merge_sql)
        {

            merge_sql += "update clinic_rcp "
                         + " set syncost = " + DataTool.addFieldBraces("Y")
                         + " where id in (select clinic_rcp_id from clinic_cost where id in (" + clinicInvoice.Clinic_cost_ids + ")  and rcptype='RCP');";
            merge_sql += "update chk_app "
                        + " set syncost = " + DataTool.addFieldBraces("Y")
                        + ",execdate=" + DataTool.addFieldBraces(clinicInvoice.Chargedate)
                        + " where id in (select clinic_rcp_id from clinic_cost where id in ( " + clinicInvoice.Clinic_cost_ids + ") and rcptype='CHK') ;";
            merge_sql += "update chk_appcost "
                        + " set syncost='Y'"
                        + " where chk_app_id in (select clinic_rcp_id from clinic_cost where id in ( " + clinicInvoice.Clinic_cost_ids + ") and rcptype='CHK');";
            return 0;
        }

        /// <summary>
        /// 获取执行科室
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public DataTable getExedep(string ids)
        {
            string sql = "select exedep_id "
                        + " ,sum( realfee) as realfee"
                        + " from clinic_costdet"
                        + " where id in (" + ids + ")"
                        + " group by exedep_id";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }


        /// <summary>
        /// 获取执行科室的费用明细
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="exedep_id"></param>
        /// <returns></returns>
        public string getCostdetIds(string ids, string exedep_id)
        {
            string costIds = "";
            string sql = "select id"
                            + " from clinic_costdet"
                            + " where id in (" + ids + ")"
                            + " and exedep_id = " + DataTool.addFieldBraces(exedep_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                costIds += dt.Rows[i]["id"].ToString() + ",";
            }
            if (costIds != "")
            {
                costIds = costIds.Substring(0, costIds.Length - 1);
            }
            return costIds;
        }
        /// <summary>
        /// 根据费用明细获取主表Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public DataTable getCostInfo(string ids)
        {
            string sql = "select DISTINCT clinic_cost.id"
                            + ",clinic_cost.billcode"
                            + ",clinic_cost.depart_id"
                            + ",clinic_cost.doctor_id"
                            + " from clinic_costdet"
                            + " left join clinic_cost on clinic_costdet.clinic_cost_id=clinic_cost.id"
                            + " where clinic_costdet.id in (" + ids + ")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 根据费用明细获取主表Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public DataTable getHandCostInfo(string ids)
        {
            string sql = "select DISTINCT clinic_cost.id"
                + ",clinic_costdet.name"
                + ",clinic_costdet.prc"
                + ",clinic_costdet.num"
                + ",clinic_costdet.fee"
                            + ",clinic_cost.billcode"
                            + ",clinic_cost.depart_id"
                            + ",clinic_cost.doctor_id"
                            + " from clinic_costdet"
                            + " left join clinic_cost on clinic_costdet.clinic_cost_id=clinic_cost.id"
                            + " where clinic_costdet.id in (" + ids + ")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 处方id明细id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string getCostdetId_RealFee(string ids, ref string realfee)
        {
            string costdetIds = "";
            if (string.IsNullOrEmpty(ids))
                return costdetIds;
            string sql = "select id "
                        + ", realfee"
                        + " from clinic_costdet"
                        + " where clinic_cost_id in (" + ids + ")"
                        + " and clinic_costdet.charged=" + DataTool.addFieldBraces(CostCharged.OO.ToString())
                        + ";";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            double d_realfee = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                costdetIds += dt.Rows[i]["id"].ToString() + ",";
                d_realfee += DataTool.stringToDouble(dt.Rows[i]["realfee"].ToString());
            }
            if (costdetIds != "")
            {
                realfee = DataTool.FormatData(d_realfee.ToString(), "2");
                costdetIds = costdetIds.Substring(0, costdetIds.Length - 1);
            }
            return costdetIds;
        }

        /// <summary>
        /// 处方id明细id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string getCostdet(string ids)
        {
            string costdetIds = "";
            if (string.IsNullOrEmpty(ids))
                return costdetIds;
            string sql = "select id "
                        + " from clinic_costdet"
                        + " where clinic_cost_id in (" + ids + ")"
                        + " and clinic_costdet.charged=" + DataTool.addFieldBraces(CostCharged.OO.ToString())
                        + ";";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                costdetIds += dt.Rows[i]["id"].ToString() + ",";
            }
            if (costdetIds != "")
            {
                costdetIds = costdetIds.Substring(0, costdetIds.Length - 1);
            }
            return costdetIds;
        }
        /// <summary>
        /// 获取处方信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getRcpCostInfo(string id)
        {
            string sql = "select realfee "
                        + ",depart_id"
                        + ",doctor_id"
                        + ",billcode"
                        + " from clinic_cost"
                        + " where id =" + id;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取处方信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getRcpClinicCosts(string clinic_cost_ids)
        {

            if (string.IsNullOrEmpty(clinic_cost_ids))
            {
                DataTable dt = new DataTable();
                return dt;
            }

            string sql = "select id "
                        + ",depart_id"
                        + ",doctor_id"
                        + ",billcode"
                        + ",(select exedep_id from clinic_costdet where clinic_cost_id= clinic_cost.id limit 1) as exedep_id"
                        + " from clinic_cost"
                        + " where id in( " + clinic_cost_ids + ")";
            DataTable dt1 = BllMain.Db.Select(sql).Tables[0];
            return dt1;
        }



        public string updateClinic_costdet_unlocked(string clinic_costdet_ids)
        {

            String sql = "update clinic_costdet set "
                + " unlocked = " + DataTool.addFieldBraces("Y")
                + " ,retappstat = 'Y'"
                + " where id in (" + clinic_costdet_ids + ");";
            return sql;

        }

        public string getChkCostIds(string clinic_cost_ids)
        {
            string ret = "";
            if (string.IsNullOrEmpty(clinic_cost_ids))
            {
                return ret;
            }

            string sql = "select id "
                        + " from clinic_cost"
                        + " where id in( " + clinic_cost_ids + ")";// and rcptype='CHK'";
            DataTable dt1 = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                ret += dt1.Rows[i]["id"].ToString() + ",";
            }
            if (!string.IsNullOrEmpty(ret))
            {
                ret = ret.Remove(ret.Length - 1);
            }
            return ret;
        }
        public string getRcpCostIds(string clinic_cost_ids)
        {
            string ret = "";
            if (string.IsNullOrEmpty(clinic_cost_ids))
            {
                return ret;
            }

            string sql = "select id "
                        + " from clinic_cost"
                        + " where id in( " + clinic_cost_ids + ") and rcptype='RCP'";
            DataTable dt1 = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                ret += dt1.Rows[i]["id"].ToString() + ",";
            }
            if (!string.IsNullOrEmpty(ret))
            {
                ret = ret.Remove(ret.Length - 1);
            }
            return ret;
        }

        /// <summary>
        /// 查询门诊市医保医保结算列表
        /// </summary>
        /// <param name="insurInfoParam"></param>
        /// <returns></returns>
        public DataTable getGysybClinicAccountList(InsurInfoParam insurInfoParam)
        {
            string sql = "select "
                        + "gysyb_mtmzblstuff_iid as invoice_id,"
                        + "xm as patientname,"
                        + "grbh as insurcode,"
                        + "sfsj as chargedate,"
                        + "hisaccount,"
                        + "case when hisaccount='1' then '未撤销' when hisaccount='2' then '已撤销' end as stat"
                        + " from gysyb_mz "
                        + " where hisaccount in('1','2') ";
            if (!String.IsNullOrEmpty(insurInfoParam.PatientName))
                sql += "  and xm = " + DataTool.addFieldBraces(insurInfoParam.PatientName);
            if (!String.IsNullOrEmpty(insurInfoParam.StartDate))
                sql += "  and sfsj >= " + DataTool.addFieldBraces(insurInfoParam.StartDate);
            if (!String.IsNullOrEmpty(insurInfoParam.EndDate))
                sql += "  and sfsj <= " + DataTool.addFieldBraces(insurInfoParam.EndDate);
            DataTable dt = new DataTable();
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
        /// 
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="hisaccount"></param>
        /// <returns></returns>
        public int upGysybHisaccount(string invoiceId, string hisaccount)
        {
            string sql = " update gysyb_mz set hisaccount=" + DataTool.addFieldBraces(hisaccount) + " where gysyb_mtmzblstuff_iid=" + DataTool.addFieldBraces(invoiceId);
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 查询门诊省医保医保结算列表
        /// </summary>
        /// <param name="insurInfoParam"></param>
        /// <returns></returns>
        public DataTable getGzsybClinicAccountList(InsurInfoParam insurInfoParam)
        {
            string sql = "select "
                        + " mtmzblstuffiid as invoice_id,"
                        + " aac003 as patientname,"
                        + " aac001 as insurcode,"
                        + " mzjssj as chargedate,"
                        + " hisaccount,"
                        + " ybflag,"
                        + " ybretflag,"
                        + " astrjylsh,"
                        + " retastrjylsh,"
                        + " case when ybflag='0' then '取消' when ybflag='2' then '确认' when ybflag='1' then '确认失败' end as ybflaginfo,"
                        + " case when ybretflag='0' then '取消' when ybretflag='2' then '确认' when ybretflag='1' then '确认失败' end as ybretflaginfo,"
                        + " case when hisaccount='1' then '未退费' when hisaccount='2' then '已退费' end as stat"
                        + " from gzsyb_mzfyb "
                        + " where 1=1";
            if (!String.IsNullOrEmpty(insurInfoParam.PatientName))
                sql += "  and aac003 = " + DataTool.addFieldBraces(insurInfoParam.PatientName);
            if (!String.IsNullOrEmpty(insurInfoParam.StartDate))
                sql += "  and mzjssj >= " + DataTool.addFieldBraces(insurInfoParam.StartDate);
            if (!String.IsNullOrEmpty(insurInfoParam.EndDate))
                sql += "  and mzjssj <= " + DataTool.addFieldBraces(insurInfoParam.EndDate);
            DataTable dt = new DataTable();
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
        /// 
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="hisaccount"></param>
        /// <returns></returns>
        public int upGzsybHisaccount(string invoiceId, string hisaccount)
        {
            string sql = " update gzsyb_mzfyb set hisaccount=" + DataTool.addFieldBraces(hisaccount) + " where mtmzblstuffiid=" + DataTool.addFieldBraces(invoiceId);
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="hisaccount"></param>
        /// <returns></returns>
        public int getInVoiceCount(string invoiceId)
        {
            int ret = 0;
            string sql = " SELECT count(*) as invoiceCount from clinic_invoice where id =" + DataTool.addFieldBraces(invoiceId);
            try
            {
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                string invoiceCount = dt.Rows[0]["invoiceCount"].ToString();
                ret = DataTool.stringToInt(invoiceCount);
            }
            catch (Exception ex)
            { }
            return ret;
        }
        /// <summary>
        /// //检查科室下拉框
        /// </summary>
        public DataTable getinitjcks()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT chk_opkind.id,chk_opkind.`name`,chk_opkind.chkkind FROM chk_opkind WHERE 1=1";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
    }
}
