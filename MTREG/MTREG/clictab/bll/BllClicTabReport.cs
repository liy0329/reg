using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.main.bll;
using MTHIS.common;
using System.Data;
using MTREG.common;

namespace MTREG.clintab.bll
{
    class BllClicTabReport
    {
        /// <summary>
        /// 日结信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable getCharger(string id,string flag)
        {
            string sql="";
            if(flag=="duty")
            {
                sql = "select * from clinictab_duty where id=" + DataTool.addIntBraces(id);
            }
            else if (flag == "tab")
            {
                sql = "select * from clinictab_day where id=" + DataTool.addIntBraces(id);
            }
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 支付汇总类型
        /// </summary>
        /// <returns></returns>
        public DataTable getPaysumby()
        {
            string sql = "select id from bas_paysumby where isclinic='Y'";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 收费员日结信息
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="chargeby"></param>
        /// <param name="depart_id"></param>
        /// <returns></returns>
        public DataTable getChargeFee(string startdate, string enddate, string chargeby, string depart_id)
        {
            string sql = "select (select name from bas_doctor where id = mainclinic_invoice.chargeby)name"
                       + ",sum(mainclinic_invoicedet.payfee) allfee"
                       + ",(select sum(clinic_invoicedet.payfee) "
                       + " from clinic_invoicedet"
                       + " left join clinic_invoice on clinic_invoicedet.clinic_invoice_id = clinic_invoice.id"
                       + " where clinic_invoice.charged = 'RET'"
                       + " and clinic_invoice.chargeby = mainclinic_invoice.chargeby"
                       + " and clinic_invoice.chargedate >= " + DataTool.addFieldBraces(startdate)
                       + " and clinic_invoice.chargedate <= " + DataTool.addFieldBraces(enddate);
            if (chargeby == "")
            {
                sql += " and clinic_invoice.depart_id =" + DataTool.addFieldBraces(depart_id);
            }
            else
            {
                sql += " and clinic_invoice.chargeby =" + DataTool.addFieldBraces(chargeby);
            }
            sql += ")retfee"
            + ",(select sum(clinic_invoicedet.payfee) from clinic_invoicedet"
            + " left join clinic_invoice on clinic_invoicedet.clinic_invoice_id = clinic_invoice.id"
            + " where clinic_invoice.charged = 'CHAR'"
            + " and clinic_invoice.chargeby = mainclinic_invoice.chargeby"
            + " and clinic_invoice.chargedate >= " + DataTool.addFieldBraces(startdate)
            + " and clinic_invoice.chargedate <= " + DataTool.addFieldBraces(enddate);
            if (chargeby == "")
            {
                sql += " and clinic_invoice.depart_id =" + DataTool.addFieldBraces(depart_id);
            }
            else
            {
                sql += " and clinic_invoice.chargeby =" + DataTool.addFieldBraces(chargeby);
            }
            sql += ")charfee";
            DataTable dt = getPaysumby();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql += ",(select sum(clinic_invoicedet.payfee) from clinic_invoicedet"
                + " left join clinic_invoice on clinic_invoicedet.clinic_invoice_id = clinic_invoice.id"
                + " where clinic_invoice.charged = 'CHAR'"
                + " and clinic_invoice.chargeby = mainclinic_invoice.chargeby"
                + " and clinic_invoice.chargedate >= " + DataTool.addFieldBraces(startdate)
                + " and clinic_invoice.chargedate <= " + DataTool.addFieldBraces(enddate);
                if (chargeby == "")
                {
                    sql += " and clinic_invoice.depart_id =" + DataTool.addFieldBraces(depart_id);
                }
                else
                {
                    sql += " and clinic_invoice.chargeby =" + DataTool.addFieldBraces(chargeby);
                }
                sql += " and clinic_invoicedet.bas_paysumby_id=" + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                + ") pTypeFee" + i;
            }
            sql += ",count(DISTINCT (mainclinic_invoice.id) )allinvoice"
            + ",(select count(DISTINCT (clinic_invoice.id))"
            + " from clinic_invoicedet"
            + " left join clinic_invoice ON clinic_invoicedet.clinic_invoice_id = clinic_invoice.id"
            + " where clinic_invoice.charged = 'RET'"
            + " and clinic_invoice.chargeby = mainclinic_invoice.chargeby"
            + " and clinic_invoice.chargedate >= " + DataTool.addFieldBraces(startdate)
            + " and clinic_invoice.chargedate <= " + DataTool.addFieldBraces(enddate);
            if (chargeby == "")
            {
                sql += " and clinic_invoice.depart_id =" + DataTool.addFieldBraces(depart_id);
            }
            else
            {
                sql += " and clinic_invoice.chargeby =" + DataTool.addFieldBraces(chargeby);
            }
            sql += ")retinvoice"
            + ",(select count(DISTINCT (clinic_invoice.id))"
            + " from clinic_invoicedet"
            + " left join clinic_invoice ON clinic_invoicedet.clinic_invoice_id = clinic_invoice.id"
            + " where clinic_invoice.charged = 'CHAR'"
            + " and clinic_invoice.chargeby = mainclinic_invoice.chargeby"
            + " and clinic_invoice.chargedate >= " + DataTool.addFieldBraces(startdate)
            + " and clinic_invoice.chargedate <= " + DataTool.addFieldBraces(enddate);
            if (chargeby == "")
            {
                sql += " and clinic_invoice.depart_id =" + DataTool.addFieldBraces(depart_id);
            }
            else
            {
                sql += " and clinic_invoice.chargeby =" + DataTool.addFieldBraces(chargeby);
            }
            sql += ")charinvoice"
            + " from clinic_invoicedet mainclinic_invoicedet"
            + " left join clinic_invoice mainclinic_invoice on mainclinic_invoicedet.clinic_invoice_id = mainclinic_invoice.id"
            + " where (mainclinic_invoice.charged = 'CHAR' or mainclinic_invoice.charged = 'RET')"
            + " and mainclinic_invoice.chargedate >= " + DataTool.addFieldBraces(startdate)
            + " and mainclinic_invoice.chargedate <= " + DataTool.addFieldBraces(enddate);
            if (chargeby == "")
            {
                sql += " and mainclinic_invoice.depart_id =" + DataTool.addFieldBraces(depart_id);
            }
            else
            {
                sql += " and mainclinic_invoice.chargeby =" + DataTool.addFieldBraces(chargeby);
            }
            sql += " group by mainclinic_invoice.chargeby";
            DataTable dtInfo = BllMain.Db.Select(sql).Tables[0];
            return dtInfo;
        }

        public DataTable getPayType(string ids, string starTime, string endTime, string flag)
        {
            string sql = "select "
                       + " bas_patienttype.name as patienttypename"
                       + ",sys_dict.name as paytypename"
                       + ",clinictab_detail.realfee"
                       + " from clinictab_detail"
                       + " left join bas_patienttype on clinictab_detail.bas_patienttype_id = bas_patienttype.id"
                       + " left join sys_dict on clinictab_detail.bas_paytype_id = sys_dict.sn"
                       + " and sys_dict.father_id <> 0 and sys_dict.dicttype = 'bas_paytype'";
            if (flag == "tab")
            {
                sql += " left join clinictab_duty on clinictab_detail.clinictab_duty_id = clinictab_duty.id"
                   + " where clinictab_duty.clinictab_day_id in ( " + ids + ")";
            }
            else if (flag == "duty")
            {
                sql += " where clinictab_detail.clinictab_duty_id in ( " + ids + ")";
            }
            DataSet ds = BllMain.Db.Select(sql);
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            else
            {
                return BllMain.Db.Select(sql).Tables[0];
            }
        }
        public DataTable  getCostAmt(string ids,string starTime, string endTime)
        {
            DataTable dt = null;
            DataTable dt_refund = null;
            string sql = " select cost_itemtype1.name,sum(clinictab_costgather.realfee) as receive,'0.00' as refund,'0.00' as realfee "
                       + " from cost_itemtype1 left join clinictab_costgather on cost_itemtype1.id = clinictab_costgather.itemtype_id AND clinictab_costgather.gathertype = 1 "
                       + " and clinictab_costgather.clinictab_day_id in (" + ids + ")"
                       + " where cost_itemtype1.isclinic='Y'"
                       + " group by cost_itemtype1.name";
            string sql_refund = " select cost_itemtype1.name,sum(clinictab_costgather.realfee) as refund "
                       + " from cost_itemtype1 left join clinictab_costgather on cost_itemtype1.id = clinictab_costgather.itemtype1_id AND clinictab_costgather.gathertype = -1 "
                       + " and clinictab_costgather.clinictab_day_id in (" + ids + ")"
                       + " where cost_itemtype1.isclinic='Y'"
                       + " group by cost_itemtype1.name";
            dt = BllMain.Db.Select(sql).Tables[0];
            dt_refund = BllMain.Db.Select(sql_refund).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].IsNull("receive"))
                {
                    dt.Rows[i]["receive"] = "0";
                }
                for (int j = 0; j < dt_refund.Rows.Count; j++)
                {
                    if (dt_refund.Rows[j].IsNull("refund"))
                    {
                        dt_refund.Rows[j]["refund"] = "0";
                    }
                    if (dt.Rows[i]["name"].ToString() == dt_refund.Rows[j]["name"].ToString())
                    {
                        dt.Rows[i]["refund"] = dt_refund.Rows[j]["refund"];
                        break;
                    }
                }
                dt.Rows[i]["realfee"] = (double.Parse(dt.Rows[i]["receive"].ToString()) - double.Parse(dt.Rows[i]["refund"].ToString())).ToString();
            }
             return dt;
        }
        public DataTable getCostAmtPaytype(string ids, string starTime, string endTime, string flag)
        {
            DataTable dt = null;
            string sql = " select bas_doctor.name as dctname,cost_itemtype.name as paytypename,clinictab_detail.realfee "
                       + " from clinictab_detail"
                       + " left join clinictab_duty on clinictab_detail.clinictab_duty_id = clinictab_duty.id"
                       + " left join bas_doctor on clinictab_duty.users_id = bas_doctor.id "
                       + " left join cost_itemtype on clinictab_detail.bas_paytype_id = cost_itemtype.id ";
            if (flag == "tab")
            {
                    sql+= " where clinictab_duty.clinictab_day_id in ( " + ids + ")";
            }
            else if (flag == "duty")
            {
                sql += " where clinictab_detail.clinictab_duty_id in ( " + ids + ")";
            }
            sql += "group by dctname,paytypename";

            DataSet ds = BllMain.Db.Select(sql);
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            else
            {
                return BllMain.Db.Select(sql).Tables[0];
            }
        }
        public DataTable getInvoice(string starttime,string endtime,string docname)
        {
            string sql = "select clinic_invoice.billcode"
                        + " from clinic_costdet"
                        + " left join clinic_invoice on clinic_invoice.id=clinic_costdet.clinic_invoice_id"
                        + " left join bas_doctor on clinic_costdet.chargeby = bas_doctor.id "
                        + " where chargedate>=" + DataTool.addFieldBraces(starttime)
                        + " and chargedate<" + DataTool.addFieldBraces(endtime)
                        + " and bas_doctor.name=" + DataTool.addFieldBraces(docname)
                        +" order by chargedate";
            DataTable dt=BllMain.Db.Select(sql).Tables[0];
            string invoices = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                invoices += dt.Rows[0]["billcode"].ToString();
                string sqlInvoice="select prefix,postfix,started "
                                    + " from sys_invice "
                                    + " left join bas_doctor on bas_doctor.id=sys_invice.charger "
                                    + " where bas_doctor.name=" + DataTool.addFieldBraces(docname);
                DataTable dtInvoice=BllMain.Db.Select(sqlInvoice).Tables[0];
                if(dtInvoice.Rows.Count==1)
                {
                
                }
                
            }

            return dt;
        }
        /// <summary>
        /// 获取日结/班结信息
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable getInfo(string ids, string flag)
        {
            string sql = "";
            if (flag == "duty")
            {
                sql = "select "
                        + " billcode"
                        + ",bas_doctor.name as settleby"
                        + ",bas_depart.name as depname"
                        + " from clinictab_duty "
                        + " left join bas_depart on bas_depart.id = clinictab_duty.depart_id"
                        + " left join bas_doctor on bas_doctor.id = clinictab_duty.settleby"
                        + " where clinictab_duty.id in (" + ids + ")";
            }
            else if (flag == "tab")
            {
                sql = "select "
                        + " billcode"
                        + ",settleby"
                        + ",bas_depart.name as depname"
                        + " from clinictab_day "
                        + " left join bas_depart on bas_depart.id = clinictab_day.depart_id"
                        + " where clinictab_day.id in (" + ids + ")";
            }
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 获取储值卡发票信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="startime"></param>
        /// <param name="endtime"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable memberInfo(string info,string startime,string endtime,string flag)
        {
            string sql = "select count(member_rechargedet.id) as num"
                            + " ,CASE"
                            + " WHEN opertype='RE' THEN '充值'"
                            + " WHEN opertype='EN' THEN '取现'"
                            + " END as opertype"
                            + ",bas_doctor.name as doctor"
                            + ",bas_depart.name as depart"
                            + ",SUM(amount) as amount"
                            + ",sys_dict.name as paytype"
                            + " from member_rechargedet "
                            + " left join bas_doctor on bas_doctor.id=member_rechargedet.operator"
                            + " left join bas_depart on bas_depart.id=member_rechargedet.depart_id"
                            + " left join sys_dict on member_rechargedet.bas_paytype_id=sys_dict.sn and sys_dict.dicttype='bas_paytype'"
                            + " where operatdate>" + DataTool.addFieldBraces(startime)
                            + " and operatdate<=" + DataTool.addFieldBraces(endtime)
                            + " and opertype in ('RE','EN')";
                            
            if(flag=="tab")
            {
                sql += " and member_rechargedet.depart_id=" + DataTool.addFieldBraces(info)
                      + " group by bas_paytype_id,opertype";
            }
            else if (flag == "duty")
            {
                sql += " and member_rechargedet.operator=" + DataTool.addFieldBraces(info)
                    + " group by bas_paytype_id,opertype";
            }
            DataTable dt=BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
    }
}
