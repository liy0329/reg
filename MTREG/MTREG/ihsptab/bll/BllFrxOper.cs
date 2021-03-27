using System;
using System.Data;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.ihsptab.bo;

namespace MTREG.ihsptab.bll
{
    class BllFrxOper
    {
        /// <summary>
        /// 打印联合查询
        /// </summary>
        /// <returns></returns>
        public DataTable unPayCost(string id, string flag)
        {
            string sql = "SELECT '预付款' as itemkind"
                                   + " ,bas_doctor.name as chargedby"
                                   + " ,inhospital.name"
                                   + " ,bas_depart.name as departname"
                                   + " ,inhospital.ihspcode"
                                   + " ,ihsp_payinadv.payfee as fee"
                                   + " ,sys_dict.name as paytype"
                                   + " ,ihsp_payinadv.chargedate "
                                   + " from ihsp_payinadv"
                                   + " LEFT JOIN inhospital on inhospital.id=ihsp_payinadv.ihsp_id"
                                   + " LEFT JOIN bas_doctor on ihsp_payinadv.chargedby=bas_doctor.id"
                                   + " LEFT JOIN bas_depart on ihsp_payinadv.depart_id=bas_depart.id"
                                   + " LEFT JOIN sys_dict on ihsp_payinadv.bas_paytype_id=sys_dict.sn and sys_dict.dicttype='bas_paytype' and sys_dict.father_id<>0";
            if (flag == "duty")
            {
                sql += " where ihsp_payinadv.ihsptab_id=" + DataTool.addFieldBraces(id);
            }
            else if (flag == "tab")
            {
                sql += " left join ihsptab_duty on ihsptab_duty.id=ihsp_payinadv.ihsptab_id"
                     + " where ihsptab_duty.Ihsptab_day_id=" + DataTool.addFieldBraces(id);
            }
            sql += " UNION SELECT '出院结算' as itemkind"
            + " ,bas_doctor.name as chargedby"
            + " ,inhospital.name"
            + " ,bas_depart.name as departname"
            + " ,inhospital.ihspcode"
            + " ,ihsp_account.feeamt as fee"
            + " ,sys_dict.name as paytype"
            + " ,ihsp_account.chargedate "
            + " from ihsp_account"
            + " LEFT JOIN inhospital on inhospital.id=ihsp_account.ihsp_id"
            + " LEFT JOIN bas_doctor on ihsp_account.chargedby_id=bas_doctor.id"
            + " LEFT JOIN bas_depart on ihsp_account.depart_id=bas_depart.id"
            + " LEFT JOIN sys_dict on ihsp_account.bas_paytype_id=sys_dict.sn and sys_dict.dicttype='bas_paytype' and sys_dict.father_id<>0";
            if (flag == "duty")
            {
                sql += " where ihsp_account.ihsptab_id=" + DataTool.addFieldBraces(id);
            }
            else if (flag == "tab")
            {
                sql += " left join ihsptab_duty on ihsptab_duty.id=ihsp_account.ihsptab_id"
                     + " where ihsptab_duty.Ihsptab_day_id=" + DataTool.addFieldBraces(id);
            }

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 打印出院查询
        /// </summary>
        /// <returns></returns>
        public DataTable outIhsp(string id)
        {
            string sql = "SELECT cost_itemtype1.name"
                                + " ,sum(realfee) as realfee"
                                + " from ihsptab_outcostgather"
                                + " left join ihsptab on ihsptab.id=ihsptab_outcostgather.ihsptab_id"
                                + " left join cost_itemtype1 on cost_itemtype1.id=ihsptab_outcostgather.itemtype1_id"
                                + " where ihsptab_outcostgather.ihsptab_day_id=" + DataTool.addFieldBraces(id)
                                + " GROUP BY itemtype1_id";
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
        /// 付款类型查询
        /// </summary>
        /// <returns></returns>
        public DataTable tabPay(string id, string pay)
        {
            string sql = "SELECT sys_dict.name as bas_paytype_id"
                                + " ,sum(fee) as fee"
                                + " from ihsptab_payinadv"
                                + " left join sys_dict on ihsptab_payinadv.bas_paytype_id=sys_dict.sn and sys_dict.dicttype='bas_paytype' and sys_dict.father_id<>0 ";
            if (pay == "tab")
            {
                sql += " left join ihsptab_duty on ihsptab_duty.id=ihsptab_payinadv.ihsptab_id"
                + " where ihsptab_duty.Ihsptab_day_id=" + DataTool.addFieldBraces(id);
            }
            else if (pay == "duty")
            {
                sql += " where ihsptab_payinadv.ihsptab_id=" + DataTool.addFieldBraces(id);
            }
            sql += " GROUP BY bas_paytype_id";
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
        /// 获取收费员
        /// </summary>
        /// <returns></returns>
        public DataTable getCharger(string ihsptab_id,string flag)
        {
            string sql = "select bas_doctor.name "
            + ",ihsptab_duty.settleby"
            + " from ihsptab_payinadv"
            + " left join ihsptab_duty on ihsptab_duty.id=ihsptab_payinadv.ihsptab_duty_id"
            + " left join bas_doctor on ihsptab_duty.settleby=bas_doctor.id";
            if(flag=="duty")
            {
                sql += " where ihsptab_duty_id=" + DataTool.addFieldBraces(ihsptab_id);
            }
            else if (flag == "tab")
            {
                sql += " where ihsptab_duty.Ihsptab_day_id=" + DataTool.addFieldBraces(ihsptab_id);
            }
            sql += " group by ihsptab_duty.settleby";
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
        /// 获取收费员的预交款情况
        /// </summary>
        /// <returns></returns>
        public string getChargerPay(string ihsptab_id, string charger, string auditetype, string flag)
        {
            string sql = "select sum(fee) as fee "
            + " from ihsptab_payinadv"
            + " left join ihsptab_duty on ihsptab_duty.id=ihsptab_payinadv.ihsptab_duty_id";
            if (flag == "duty")
            {
                sql += " where ihsptab_duty_id=" + DataTool.addFieldBraces(ihsptab_id);
            }
            else if (flag == "tab")
            {
                sql += " where ihsptab_duty.ihsptab_day_id=" + DataTool.addFieldBraces(ihsptab_id);
            }
            sql += " and ihsptab_duty.settleby=" + DataTool.addFieldBraces(charger)
            + " and auditetype=" + DataTool.addFieldBraces(charger);

            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string fee = datatable.Rows[0]["fee"].ToString();
                return fee;
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
        /// 获取收费员结退金额情况
        /// </summary>
        /// <param name="ihsptab_id"></param>
        /// <param name="charger"></param>
        /// <param name="auditetype"></param>
        /// <returns></returns>
        public string getChargerAcc(string ihsptab_id, string charger, string flag)
        {
            string sql = "select sum(balanceamt) as balanceamt"
            + " from ihsptab_account"
            + " left join ihsptab_duty on ihsptab_duty.id=ihsptab_account.ihsptab_duty_id";
            if (flag == "duty")
            {
                sql += " where ihsptab_duty_id=" + DataTool.addFieldBraces(ihsptab_id);
            }
            else if (flag == "tab")
            {
                sql += " where ihsptab_duty.ihsptab_day_id=" + DataTool.addFieldBraces(ihsptab_id);
            }
            sql+= " and ihsptab_duty.settleby=" + DataTool.addFieldBraces(charger);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string balanceamt = datatable.Rows[0]["balanceamt"].ToString();
                return balanceamt;
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 科室核算
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable departAccounting(DepDocAcc departAcc)
        {
            string starttime = departAcc.StartTime;
            string endtime = departAcc.EndTime;
            string sql = "select bas_depart.name as depart"
                + ", cost_itemtype1.name as itemtype1"
                + ", sum(realfee) as realfee"
                + " from " + departAcc.Tablename
                + " left join sys_daysettle on ihsptab_day_id=sys_daysettle.id"
                + " left join bas_depart on bas_depart.id=exedep_id"
                + " right join cost_itemtype1 on cost_itemtype1.id=itemtype1_id"
                + (!string.IsNullOrEmpty(departAcc.Departid) && departAcc.Departid != "0" ? (" and bas_depart.id= " + DataTool.addFieldBraces(departAcc.Departid)) : "")
                + (!string.IsNullOrEmpty(departAcc.Patienttypeid) && departAcc.Patienttypeid != "0" ? (" and bas_patienttype_id= " + DataTool.addFieldBraces(departAcc.Patienttypeid)) : "")
                + (!string.IsNullOrEmpty(departAcc.Itemtype1id) && departAcc.Itemtype1id != "0" ? (" and cost_itemtype1.id= " + DataTool.addFieldBraces(departAcc.Itemtype1id)) : "");
            if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
            {
                sql += " and sys_daysettle.startdate >= " + DataTool.addFieldBraces(starttime) + " and sys_daysettle.enddate<=" + DataTool.addFieldBraces(endtime);
            }
            sql+= " group by exedep_id,cost_itemtype1.name";

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 医生核算
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable doctorAccounting(DepDocAcc departAcc)
        {
            string starttime = departAcc.StartTime;
            string endtime = departAcc.EndTime;
            string sql = "select bas_depart.name as depart"
                + ",bas_doctor.name as doctor"
                + ", cost_itemtype1.name as itemtype"
                + ", sum(realfee) as realfee"
                + " from " + departAcc.Tablename
                + " LEFT JOIN bas_doctor on bas_doctor.id=exedoctor_id"
                + " LEFT JOIN sys_daysettle on ihsptab_day_id=sys_daysettle.id"
                + " left join bas_depart on bas_depart.id=exedep_id"
                + " RIGHT JOIN cost_itemtype1 on cost_itemtype1.id=itemtype1_id"
                + (!string.IsNullOrEmpty(departAcc.Departid) && departAcc.Departid != "0" ? (" and bas_depart.id= " + DataTool.addFieldBraces(departAcc.Departid)) : "")
                + (!string.IsNullOrEmpty(departAcc.Itemtype1id) && departAcc.Itemtype1id != "0" ? (" and cost_itemtype1.id= " + DataTool.addFieldBraces(departAcc.Itemtype1id)) : "");
            if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
            {
                sql += " and sys_daysettle.startdate >= " + DataTool.addFieldBraces(starttime) + " and sys_daysettle.enddate<=" + DataTool.addFieldBraces(endtime);
            }
                sql+= " group by exedep_id,cost_itemtype1.name";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 预付款发票
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable ihspPayInadv(string id)
        {
            string sql = "SELECT ihsp_payinadv.billcode"//预交款单号
                           + " ,sys_dict.name as paytype"//付款方式
                           + " ,ihsp_payinadv.payfee"//本次收受
                           + " ,bas_depart.name as depart"//科室
                           + " ,bas_doctor.name as charger"//操作员
                           + " ,ihsp_payinadv.chargedate"//发生时间
                           + " ,inhospital.indate"
                           + " ,inhospital.name"//姓名
                           + " ,ihsp_payinadv.feeamt"//消费总额
                           + " ,ihsp_payinadv.prepamt"//总预交款
                           + ",sexList.name as sex"
                           + " ,NOW() as now"
                           + " ,inhospital.ihspcode"//住院号
                           + " ,bas_patienttype.name as patienttype"
                           + " FROM ihsp_payinadv "
                           + " LEFT JOIN inhospital ON ihsp_payinadv.ihsp_id = inhospital.id "
                           + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                           + " left join bas_doctor on ihsp_payinadv.chargedby=bas_doctor.id "
                           + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                           + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                           + " left join sys_dict on ihsp_payinadv.bas_paytype_id=sys_dict.sn and sys_dict.dicttype='bas_paytype' and sys_dict.father_id<>0 "
                           + " where ihsp_payinadv.id=" + DataTool.addFieldBraces(id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 住院id获取住院结算信息
        /// </summary>
        public DataTable getIhspAccInfo(string ihsp_id)
        {
            string sql="SELECT"
	                    +" inhospital.ihspcode"
	                    +" ,inhospital.casecode"
	                    +" ,bas_patienttype.name as patienttype"
	                    +" ,inhospital.healthcard"
	                    +" ,inhospital.name as ihspname"
                        + ",sexList.name as sex"
	                    +" ,inhospital.indate"
	                    +" ,inhospital.outdate"
	                    +" ,inhospital.feeamt"
	                    +" ,inhospital.prepamt"
	                    +" ,inhospital.balanceamt"
                        + " ,ihsp_account.billcode"
                        +" ,ihsp_account.invoice"
	                    +" ,ihsp_account.insurefee"
                        + " ,ihsp_account.insuraccountfee"
                        + " ,bas_doctor.name as chargedby"
                        + ",ihsp_account.chargedate"
                        + " FROM ihsp_account"
                        + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                        + " LEFT JOIN inhospital ON ihsp_account.ihsp_id = inhospital.id"
                        +" LEFT JOIN bas_doctor ON bas_doctor.id=ihsp_account.chargedby_id"
                        +" LEFT JOIN bas_patienttype ON bas_patienttype.id=inhospital.bas_patienttype_id"
                        +" where inhospital.id="+DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 结算单号获取住院结算信息
        /// </summary>
        public DataTable getAccInfo(string invoice)
        {
            //string sql = "SELECT"
            //            + " inhospital.ihspcode"//住院号
            //            + " ,inhospital.casecode"//病案号
            //            + " ,bas_patienttype.name as patienttype"//医保类型
            //            + " ,inhospital.bas_patienttype_id as patienttype_id"//医保类型id
            //            + " ,inhospital.insurcode"//社会保障号
            //            + " ,inhospital.name as ihspname"//姓名
            //            + " ,sexList.name as sex"//性别
            //            + " ,inhospital.age "//年龄 
            //            + ",inhospital.healthcard,"//医保卡号
            //            + " ,inhospital.indate"//入院时间
            //            + " ,inhospital.outdate"//出院时间
            //            + " ,ihsp_account.feeamt"//总费用
            //            + " ,ihsp_account.prepamt"//总预交款
            //            + " ,ihsp_account.balanceamt"
            //            + " ,ihsp_account.billcode"//结算单号
            //            + " ,ihsp_account.invoice"//发票号
            //            + " ,ihsp_account.insurefee"//医保统筹支付
            //            + " ,ihsp_account.insuraccountfee"//账户支付
            //            + " ,bas_doctor.name as chargedby"//结算人
            //            + " ,ihsp_account.chargedate"//结算时间
            //            + " ,bas_paytype.name as paytypename "//支付名称
            //            + " ,ihsp_account.ihsp_id"
            //            + " ,member.idcard"//身份证号
            //            + " ,bas_depart.`name` as ks"//科室
            //            + " ,(SELECT GROUP_CONCAT(diagnname)  FROM ihsp_diagnmes WHERE ihsp_diagnmes.ihsp_id = inhospital.id ) as cyzd"
            //            + " FROM ihsp_account"
            //            + " LEFT JOIN inhospital ON ihsp_account.ihsp_id = inhospital.id"
            //            + " LEFT JOIN bas_doctor ON bas_doctor.id=ihsp_account.chargedby_id"
            //            + " LEFT JOIN bas_patienttype ON bas_patienttype.id=inhospital.bas_patienttype_id"
            //            + " left join sys_dict as bas_paytype on ihsp_account.bas_paytype_id=bas_paytype.sn and bas_paytype.dicttype='bas_paytype' and bas_paytype.father_id<>0"
            //            + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
            //            + " LEFT JOIN member ON member.id = inhospital.member_id"
            //            + " LEFT JOIN bas_depart ON bas_depart.id = inhospital.depart_id"
            //            + " where ihsp_account.invoice=" + DataTool.addFieldBraces(invoice);
            string sql = @"SELECT
	inhospital.ihspcode,
	inhospital.casecode,
	bas_patienttype. NAME AS patienttype,
	inhospital.bas_patienttype_id AS patienttype_id,
	inhospital.insurcode,
	inhospital. NAME AS ihspname,
	sexList. NAME AS sex,
	inhospital.indate,
	inhospital.outdate,
inhospital.age,
inhospital.healthcard,
	ihsp_account.feeamt,
	ihsp_account.prepamt,
	ihsp_account.balanceamt,
	ihsp_account.billcode,
	ihsp_account.invoice,
	ihsp_account.insurefee,
	ihsp_account.insuraccountfee,
	bas_doctor. NAME AS chargedby,
	ihsp_account.chargedate,
	bas_paytype. NAME AS paytypename,
	ihsp_account.ihsp_id,
bas_depart.`name` as ks,
member.idcard,
(SELECT GROUP_CONCAT(diagnname)  FROM ihsp_diagnmes WHERE ihsp_diagnmes.ihsp_id = inhospital.id ) as cyzd
FROM
	ihsp_account
LEFT JOIN inhospital ON ihsp_account.ihsp_id = inhospital.id
LEFT JOIN bas_doctor ON bas_doctor.id = ihsp_account.chargedby_id
LEFT JOIN bas_patienttype ON bas_patienttype.id = inhospital.bas_patienttype_id
LEFT JOIN sys_dict AS bas_paytype ON ihsp_account.bas_paytype_id = bas_paytype.sn
AND bas_paytype.dicttype = 'bas_paytype'
AND bas_paytype.father_id <> 0
LEFT JOIN sys_dict AS sexList ON inhospital.sex = sexList.keyname
AND sexList.dicttype = 'bas_sex'
AND sexList.father_id <> 0
LEFT JOIN member ON member.id = inhospital.member_id
LEFT JOIN bas_depart ON bas_depart.id = inhospital.depart_id
WHERE
	ihsp_account.invoice = " + DataTool.addFieldBraces(invoice);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 住院id获取市医保住院结算信息
        /// </summary>
        public DataTable getGYSYBZyjsInfo(string mtzyjl_iid)
        {
            string sql = "select"
                        + " fund1pay"//基本统筹支付
                        + " ,fund2pay"//大额统筹支付
                        + " ,fund3pay"//医疗补助支付
                        + " ,acctpay"//个人帐户支付
                        + " ,sbpay"//商保支付
                        + " ,personcode"//个人编号
                        + " FROM insur_gysyb_zy"
                        + " where mtzyjliid=" + DataTool.addFieldBraces(mtzyjl_iid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 住院id获取异地医保住院结算信息
        /// </summary>
        public DataTable getGZSYBZyjsInfo(string mtzyjl_iid)
        {
            string sql = "select"
                        + " yab003"//
                        + " ,yka248"//基本统筹支付
                        + " ,yka062"//大病统筹支付
                        + " ,yke030"//公务员统筹支付
                        + " ,yka065"//个人帐户支付
                        + " ,aac001"//个人编号
                        + " FROM insur_gzsyb_ryinfo"
                        + " where mtzyjliid=" + DataTool.addFieldBraces(mtzyjl_iid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 住院id获取农合住院结算信息
        /// </summary>
        public DataTable getGZSNHZyjsInfo(string mtzyjl_iid)
        {
            string sql = "select"
                        + " calculateMoney"//基金支付金额
                        + " ,yfmedicalaid"//民政优抚医疗补助
                        + " ,cxmedicalaid"//民政城乡医疗救助
                        + " ,CIICalculateMoney"//本次大病保险补偿金额
                        + " ,ChinaCharityPay"//慈善总会支付金额
                        + " ,FamilyPlanningWaiver"//计生两户减免费用金额
                        + " ,memberno"//个人编号
                        + " FROM insur_gzsnhzyinfo"
                        + " where ihsp_id=" + DataTool.addFieldBraces(mtzyjl_iid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 获取项目类别信息
        /// </summary>
        public DataTable getItemTypeName()
        {
            string sql = "select name from cost_itemtype where isstop='N';";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 获取住院费用信息
        /// </summary>
        public DataTable getIhspCostInfo(string id)
        {
            string sql = "SELECT cost_itemtype.name as name"
                        + " ,sum(ihsp_costdet.realfee) as realfee"
                        + " FROM ihsp_costdet"
                        + " left join cost_itemtype on cost_itemtype.id=ihsp_costdet.itemtype_id"
                        + " where ihsp_costdet.settled='Y'"
                        + " and ihsp_costdet.ihsp_account_id =" + DataTool.addFieldBraces(id)
                        + " GROUP BY cost_itemtype.id";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// name获取模板名称
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public DataTable getPrintTemplate(string txt)
        {
            string sql = "SELECT frmurl FROM sys_print WHERE isstop = 'N' and name=" + DataTool.addFieldBraces(txt);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// codeid获取模板名称
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public DataTable getPrintFrmurl(string code)
        {
            string sql = "SELECT frmurl FROM sys_print WHERE isstop = 'N' and codeid=" + DataTool.addFieldBraces(code);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 根据患者类型获取模板地址
        /// </summary>
        /// <param name="patienttype_id"></param>
        /// <returns></returns>
        public string  getFrmurl(string patienttype_id)
        {
            string sql = "select frmurl from sys_print where id=(select sys_insurprint_if from cost_insurtype where id=(select cost_insurtype_id from bas_patienttype where id=" + patienttype_id + "))";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["frmurl"].ToString();
            }
            return "";
        }
        /// <summary>
        /// 是否可以进行预览
        /// </summary>
        /// <returns></returns>
        public string getView(string txt)
        {
            string sql = "SELECT ispreview FROM sys_print WHERE isstop = 'Y' and name=" + DataTool.addFieldBraces(txt);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string ispreview = dt.Rows[0]["ispreview"].ToString();
                return ispreview;
            }
            else
            {
                return "空";
            }
        }

        /// <summary>
        /// 不同医保获取项目类别
        /// </summary>
        /// <param name="id"></param>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public DataTable insurInfo(string id ,string keyname)
        {
            string sql = "SELECT insur_itemtype.name as name"
                        + ",sum(ihsp_costdet.realfee) as realfee"
                        + " FROM ihsp_costdet"
                        + " left JOIN insur_itemtype on insur_itemtype.itemtype_id=ihsp_costdet.itemtype_id"
                        + " where insur_itemtype.cost_insurtype_id=(select id from cost_insurtype where keyname="+ DataTool.addFieldBraces(keyname)+")"
                        + " and ihsp_costdet.ihsp_id =" + DataTool.addFieldBraces(id)
                        + " GROUP BY insur_itemtype.itemtype_id";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
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
        /// 邯郸市第二医院病人费用清单
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable getIhspInfo(string ihsp_id)
        {
            DataTable dt = null;
            string sql = "select "
                       + " inhospital.casecode"//病人ID
                       + ",inhospital.ihspcode"//住院号
                       + ",inhospital.name as patientname"//姓名
                       + ",case inhospital.sex when 'M' then '男' when 'W' then '女' end as sex"//性别
                       + ", inhospital.age "
                       + ",inhospital.healthcard"
                       + ", sjz_yb_jsxx.AAE072"
                       + ", sjz_yb_jsxx.AAE040"
                       + ",inhospital.indate"//入院日期
                       + ",inhospital.outdate"//出院日期
                       + ",bas_depart.name as dptname"//入院科室
                       + ",bas_patienttype.name as patienttypename"//费别
                       + ",inhospital.prepamt"//预交金余额
                       + ",inhospital.feeamt"//住院费用
                       + ", member.companyname"
                       + ",(SELECT `name` FROM sys_dict WHERE dicttype = 'bas_ihspoutstat' AND sn = inhospital.bas_ihspoutstat_id) as cybq"
                       + ",( SELECT GROUP_CONCAT(diagnname) FROM ihsp_diagnmes WHERE ihsp_diagnmes.ihsp_id = inhospital.id AND opkind = 'MAIN') AS cyzd"
                       + " from inhospital left join bas_patienttype"
                       + " on inhospital.bas_patienttype_id = bas_patienttype.id"
                       + " left join member on inhospital.member_id = member.id"
                       + " left join bas_depart on bas_depart.id = inhospital.depart_id"
                       + " LEFT JOIN sjz_yb_jsxx ON sjz_yb_jsxx.AKC190 = inhospital.ihspcode"
                       + " where inhospital.id = " + DataTool.addFieldBraces(ihsp_id);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 邯郸市第二医院病人费用清单
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable getIhspCostdetInfo(string ihsp_id)
        {
            DataTable dt = null;
            //string sql = "select "
            //           + " t.itemtype_id"
            //           + ",t.costname"
            //           + ",t.itemname"
            //           + ",t.spec"
            //           + ",t.unit"
            //           + ",t.num"
            //           + ",t.prc"
            //           + ",t.realfee"
            //           + ",t.insurclass"
            //           + ",t.selffee"
            //           + " from "
            //           + "(select "
            //           + " ihsp_costdet.itemtype_id*10 as itemtype_id"
            //           + ",cost_itemtype.name as costname"
            //           + ",bas_item.name as itemname"
            //           + ",ihsp_costdet.spec"
            //           + ",ihsp_costdet.unit"
            //           + ",ihsp_costdet.num"
            //           + ",ihsp_costdet.prc*ihsp_costdet.discnt as prc"
            //           + ",ihsp_costdet.realfee"
            //           + ",ihsp_costdet.insurclass"
            //           + ",ihsp_costdet.selffee"
            //           + " from ihsp_costdet left join bas_item on ihsp_costdet.item_id = bas_item.id"
            //           + " left join cost_itemtype on cost_itemtype.id = ihsp_costdet.itemtype_id"
            //           + " where ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
            //            + "  and ihsp_costdet.charged in('RREC','RET','CHAR')"//charged为RREC：红冲、RET：退费、CHAR: 计费
            //           + " union all select "
            //           + " ihsp_costdet.itemtype_id * 10+1 as itemtype_id"
            //           + ", '小计金额'as costname"
            //           + ",'' as itemname"
            //           + ",'' as spec"
            //           + ",'' as unit"
            //           + ",'' as num"
            //           + ",'' as prc"
            //           + ",sum(ihsp_costdet.realfee) as realfee "
            //           + ",'' as insurclass"
            //           + ",'' as selffee"
            //           + " from ihsp_costdet "
            //           + " where ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
            //           + "  and ihsp_costdet.charged in('RREC','RET','CHAR')"//charged为RREC：红冲、RET：退费、CHAR: 计费
            //           + " group by ihsp_costdet.itemtype_id) t "
            //           + "order by itemtype_id"
                  //     ;

            string sql = " SELECT"
                                + " 	t.itemtype_id,"
                                + " 	t.costname,"
                                + " 	t.itemname,"
                                + " 	t.spec,"
                                + " 	t.unit,"
                                + " 	t.num,"
                                + " 	t.prc,"
                                + " 	t.realfee,"
                                + " 	t.insurclass,"
                                + " 	t.selffee"
                                + " FROM"
                                + " 	("
                                + " 		SELECT"
                                + " 			ihsp_costdet.itemtype_id * 100 AS itemtype_id,"
                                + " 			cost_itemtype. NAME AS costname,"
                                + " 			bas_item. NAME AS itemname,"
                                + " 			ihsp_costdet.spec,"
                                + " 			ihsp_costdet.unit,"
                                + " 			CONVERT (sum(ihsp_costdet.num),DECIMAL (10, 0)) AS num,"
                                + " 			CONVERT (sum(ihsp_costdet.prc * ihsp_costdet.discnt) ,DECIMAL (10, 2)) AS prc,"
                                + " 			CONVERT ("
                                + " 				sum(ihsp_costdet.realfee),"
                                + " 				DECIMAL (10, 2)"
                                + " 			) AS realfee,"
                                + " 			ihsp_costdet.insurclass  AS insurclass,"
                                + " 			CONVERT (sum(ihsp_costdet.selffee),DECIMAL (10, 2)) AS selffee"
                                + " 		FROM"
                                + " 			ihsp_costdet"
                                + " 		LEFT JOIN bas_item ON ihsp_costdet.item_id = bas_item.id"
                                + " 		LEFT JOIN cost_itemtype ON cost_itemtype.id = ihsp_costdet.itemtype_id"
                                + " 		WHERE"
                                + " 			 ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
                                + " 			AND ihsp_costdet.settled='N'"
                                + " 		AND ihsp_costdet.charged IN ('RREC', 'RET', 'CHAR')"
                                + " 		GROUP BY"
                                + " 			bas_item.id,"
                                + " 			prc"
                                + " 		UNION ALL"
                                + " 			SELECT"
                                + " 				ihsp_costdet.itemtype_id * 100 + 1 AS itemtype_id,"
                                + " 				'小计金额' AS costname,"
                                + " 				null AS itemname,"
                                + " 				null AS spec,"
                                + " 				null AS unit,"
                                + " 				' ' AS num,"
                                + " 				' ' AS prc,"
                                + " 			  convert (	sum(ihsp_costdet.realfee),decimal(10,2) ) AS realfee,"
                                + " 				null AS insurclass,"
                                + " 				null AS selffee"
                                + " 			FROM"
                                + " 				ihsp_costdet"
                                + " 			WHERE"
                                + " 				ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
                                + " 			AND ihsp_costdet.settled='N'"
                                + " 			AND ihsp_costdet.charged IN ('RREC', 'RET', 'CHAR')"
                                + " 			GROUP BY"
                                + " 				ihsp_costdet.itemtype_id"
                                + " 	) t"
                                + " WHERE"
                                + " 	t.realfee > 0"
                                + " ORDER BY"
                                + " 	itemtype_id";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 邯郸市第二医院病人费用清单
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable getIhspCostdetInfoBySettle(string ihsp_account_id)
        {
            DataTable dt = null;
            //string sql = "select "
            //           + " t.itemtype_id"
            //           + ",t.costname"
            //           + ",t.itemname"
            //           + ",t.spec"
            //           + ",t.unit"
            //           + ",t.num"
            //           + ",t.prc"
            //           + ",t.realfee"
            //           + ",t.insurclass"
            //           + ",t.selffee"
            //           + " from "
            //           + "(select "
            //           + " ihsp_costdet.itemtype_id*10 as itemtype_id"
            //           + ",cost_itemtype.name as costname"
            //           + ",bas_item.name as itemname"
            //           + ",ihsp_costdet.spec"
            //           + ",ihsp_costdet.unit"
            //           + ",	sum(ihsp_costdet.num) as num"
            //           + ",sum(ihsp_costdet.prc*ihsp_costdet.discnt) as prc"
            //           + ",convert(sum(ihsp_costdet.realfee),decimal(10,2)) as realfee"
            //           + ",sum(ihsp_costdet.insurclass) as insurclass"
            //           + ",sum(ihsp_costdet.selffee) as selffee"
            //           + " from ihsp_costdet left join bas_item on ihsp_costdet.item_id = bas_item.id"
            //           + " left join cost_itemtype on cost_itemtype.id = ihsp_costdet.itemtype_id"
            //           + " where ihsp_costdet.ihsp_account_id = " + DataTool.addFieldBraces(ihsp_account_id)
            //           + "  and ihsp_costdet.charged in('RREC','RET','CHAR')"//charged为RREC：红冲、RET：退费、CHAR: 计费
            //           + " group by bas_item.id, prc"
            //           + " union all select "
            //           + " ihsp_costdet.itemtype_id * 10+1 as itemtype_id"
            //           + ", '小计金额'as costname"
            //           + ",'' as itemname"
            //           + ",'' as spec"
            //           + ",'' as unit"
            //           + ",'' as num"
            //           + ",'' as prc"
            //           + ",sum(ihsp_costdet.realfee) as realfee "
            //           + ",'' as insurclass"
            //           + ",'' as selffee"
            //           + " from ihsp_costdet "
            //           + " where ihsp_costdet.ihsp_account_id = " + DataTool.addFieldBraces(ihsp_account_id)
            //           + "  and ihsp_costdet.charged in('RREC','RET','CHAR')"//charged为RREC：红冲、RET：退费、CHAR: 计费
            //           + " group by ihsp_costdet.itemtype_id) t "
            //           + " where t.realfee >0"
            //           + " order by itemtype_id"
            //           ;
            //string sql = " SELECT"
            //                    + " 	t.itemtype_id,"
            //                    + " 	t.costname,"
            //                    + " 	t.itemname,"
            //                    + " 	t.spec,"
            //                    + " 	t.unit,"
            //                    + " 	t.num,"
            //                    + " 	t.prc,"
            //                    + " 	t.realfee,"
            //                    + " 	t.insurclass,"
            //                    + " 	t.selffee"
            //                    + " FROM"
            //                    + " 	("
            //                    + " 		SELECT"
            //                    + " 			ihsp_costdet.itemtype_id * 10 AS itemtype_id,"
            //                    + " 			cost_itemtype. NAME AS costname,"
            //                    + " 			bas_item. NAME AS itemname,"
            //                    + " 			ihsp_costdet.spec,"
            //                    + " 			ihsp_costdet.unit,"
            //                    + " 			CONVERT (sum(ihsp_costdet.num),DECIMAL (10, 0)) AS num,"
            //                    + " 			CONVERT (ihsp_costdet.prc * ihsp_costdet.discnt,DECIMAL (10, 2) ) AS prc,"
            //                    + " 			CONVERT ("
            //                    + " 				sum(ihsp_costdet.realfee),"
            //                    + " 				DECIMAL (10, 2)"
            //                    + " 			) AS realfee,"
            //                    + " 			ihsp_costdet.insurclass  AS insurclass,"
            //                    + " 			CONVERT (sum(ihsp_costdet.selffee),DECIMAL (10, 2)) AS selffee"
            //                    + " 		FROM"
            //                    + " 			ihsp_costdet"
            //                    + " 		LEFT JOIN bas_item ON ihsp_costdet.item_id = bas_item.id"
            //                    + " 		LEFT JOIN cost_itemtype ON cost_itemtype.id = ihsp_costdet.itemtype_id"
            //                    + " 		WHERE"
            //                    + " 			ihsp_costdet.ihsp_account_id =" + DataTool.addFieldBraces(ihsp_account_id)
            //                    + " 		AND ihsp_costdet.charged IN ('RREC', 'RET', 'CHAR')"
            //                    + " 		GROUP BY"
            //                    + " 			bas_item.id,"
            //                    + " 			prc"
            //                    + " 		UNION ALL"
            //                    + " 			SELECT"
            //                    + " 				ihsp_costdet.itemtype_id * 10 + 1 AS itemtype_id,"
            //                    + " 				'小计金额' AS costname,"
            //                    + " 				null AS itemname,"
            //                    + " 				null AS spec,"
            //                    + " 				null AS unit,"
            //                    + " 				' ' AS num,"
            //                    + " 				' ' AS prc,"
            //                    + " 			  convert (	sum(ihsp_costdet.realfee),decimal(10,2) ) AS realfee,"
            //                    + " 				null AS insurclass,"
            //                    + " 				null AS selffee"
            //                    + " 			FROM"
            //                    + " 				ihsp_costdet"
            //                    + " 			WHERE"
            //                    + " 				ihsp_costdet.ihsp_account_id = "+ DataTool.addFieldBraces(ihsp_account_id)
            //                    + " 			AND ihsp_costdet.charged IN ('RREC', 'RET', 'CHAR')"
            //                    + " 			GROUP BY"
            //                    + " 				ihsp_costdet.itemtype_id"
            //                    + " 	) t"
            //                    + " WHERE"
            //                    + " 	t.realfee > 0"
            //                    + " ORDER BY"
            //                    + " 	itemtype_id";
            string sql = " SELECT"
                            + " 	t.itemtype_id,"
                            + " 	t.costname,"
                            + " 	t.itemname,"
                            + " 	t.spec,"
                            + " 	t.unit,"
                            + " 	t.num,"
                            + " 	t.prc,"
                            + " 	t.realfee,"
                            + " 	t.insurclass,"
                            + " 	t.selffee"
                            + " FROM"
                            + " 	("
                            + " 		SELECT"
                            + " 			ihsp_costdet.itemtype_id * 10 AS itemtype_id,"
                            + " 			cost_itemtype. NAME AS costname,"
                            + " 			bas_item. NAME AS itemname,"
                            + " 			ihsp_costdet.spec,"
                            + " 			ihsp_costdet.unit,"
                            + " 			CONVERT (sum(ihsp_costdet.num),DECIMAL (10, 0)) AS num,"
                            + " 			CONVERT (sum(ihsp_costdet.prc * ihsp_costdet.discnt),DECIMAL (10, 2) ) AS prc,"
                            + " 			CONVERT ("
                            + " 				sum(ihsp_costdet.realfee),"
                            + " 				DECIMAL (10, 2)"
                            + " 			) AS realfee,"
                            + " 			ihsp_costdet.insurclass  AS insurclass,"
                            + " 			CONVERT (sum(ihsp_costdet.selffee),DECIMAL (10, 2)) AS selffee"
                            + " 		FROM"
                            + " 			ihsp_costdet"
                            + " 		LEFT JOIN bas_item ON ihsp_costdet.item_id = bas_item.id"
                            + " 		LEFT JOIN cost_itemtype ON cost_itemtype.id = ihsp_costdet.itemtype_id"
                            + " 		WHERE"
                            + " 			ihsp_costdet.ihsp_account_id =" + DataTool.addFieldBraces(ihsp_account_id)
                            + " 		AND ihsp_costdet.charged IN ('RREC', 'RET', 'CHAR')"
                            + " 		GROUP BY"
                            + " 			bas_item.id,"
                            + " 			prc"
                            + " 		UNION ALL"
                            + " 			SELECT"
                            + " 				ihsp_costdet.itemtype_id * 10 + 1 AS itemtype_id,"
                            + " 				'小计金额' AS costname,"
                            + " 				null AS itemname,"
                            + " 				null AS spec,"
                            + " 				null AS unit,"
                            + " 				' ' AS num,"
                            + " 				' ' AS prc,"
                            + " 			  convert (	sum(ihsp_costdet.realfee),decimal(10,2) ) AS realfee,"
                            + " 				null AS insurclass,"
                            + " 				null AS selffee"
                            + " 			FROM"
                            + " 				ihsp_costdet"
                            + " 			WHERE"
                            + " 				ihsp_costdet.ihsp_account_id = " + DataTool.addFieldBraces(ihsp_account_id)
                            + " 			AND ihsp_costdet.charged IN ('RREC', 'RET', 'CHAR')"
                            + " 			GROUP BY"
                            + " 				ihsp_costdet.itemtype_id"
                            + " 	) t"
                            + " WHERE"
                            + " 	t.realfee > 0"
                            + " ORDER BY"
                            + " 	itemtype_id";


            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 云南异地医保打印数据
        /// </summary>
        /// <returns></returns>
        public DataTable ynydybInfo(string ihsp_id)
        {
            string sql = "select"
                + ",bas_depart.name as depart"
                + ",ihspdoc.name as ihspdoc"
                + ",settdoc.name as settdoc"
                + ",inhospital.casecode"
                + ",inhospital.ihspcode"
                + ",bas_sickbed.name as bedcode"
                + ",inhospital.outcondition"
                + ",inhospital.indate"
                + ",inhospital.outdate"
                + ",inhospital.ihspdiagn"
                + ",inhospital.outdiagn"
                + ",ihsp_account.billcode"
                + ",ihsp_account.chargedate"
                + " from inhospital"
                + " left join ihsp_account on ihsp_account.ihsp_id=inhospital.id"
                + " left join bas_doctor as ihspdoc on inhospital.doctor_id=ihspdoc.id"
                + " left join bas_doctor as settdoc on ihsp_account.chargedby_id=settdoc.id"
                + " left join bas_depart on inhospital.depart_id=bas_depart.id"
                + " left join bas_sickbed on inhospital.sickbed_id=bas_sickbed.id"
                + " where inhospital.id=" + DataTool.addFieldBraces(ihsp_id)
                + ";";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
    }
}
