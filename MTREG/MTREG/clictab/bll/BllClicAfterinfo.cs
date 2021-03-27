using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTREG.common;
using MTHIS.common;

namespace MTREG.clintab.bll
{
    class BllClicAfterinfo
    {
        public DataTable getItemGather(string startTime,string endTime)
        {
            DataTable dt = null;
            DataTable dt_refund = null;
            string sql_charge = "select "
                       + " clinic_costdet.item_id"
                       + ",bas_item.name AS itemname"
                       + ",sum(clinic_costdet.realfee) as receive"
                       + ",'0.00' as refund"
                       + ",'0.00' as realfee"
                       + " from clinic_costdet "
                       + " left join bas_item"
                       + " on clinic_costdet.item_id = bas_item.id"
                       + " where clinic_costdet.charged in ("
                       + DataTool.addFieldBraces(CostCharged.CHAR.ToString()) + "," + DataTool.addFieldBraces(CostCharged.RET.ToString())
                       + ") and clinic_costdet.chargedate>= " + DataTool.addFieldBraces(startTime)
                       + " and clinic_costdet.chargedate<= " + DataTool.addFieldBraces(endTime)
                       + " group by clinic_costdet.item_id,bas_item.name";

            string sql_refund = "select "
                       + " clinic_costdet.item_id"
                       + ",bas_item.name as itemname"
                       + ",sum(clinic_costdet.realfee) as refund"
                       + " from clinic_costdet"
                       + " left join bas_item"
                       + " on clinic_costdet.item_id = bas_item.id"
                       + " where clinic_costdet.charged in ("
                       + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                       + ")  and clinic_costdet.chargedate>= " + DataTool.addFieldBraces(startTime)
                       + " and clinic_costdet.chargedate<= " + DataTool.addFieldBraces(endTime)
                       + " group by clinic_costdet.item_id,bas_item.name";

            dt_refund = BllMain.Db.Select(sql_refund).Tables[0];
            dt = BllMain.Db.Select(sql_charge).Tables[0];
            double sumReci = 0, sumRefund = 0, sumReal = 0;
            for (int i = 0; i < dt_refund.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt_refund.Rows[i]["item_id"] == dt.Rows[j]["item_id"])
                    {
                        dt.Rows[i]["refund"] = dt_refund.Rows[i]["refund"];
                    }
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["realfee"] = (double.Parse(dt.Rows[i]["receive"].ToString()) - double.Parse(dt.Rows[i]["refund"].ToString())).ToString();
                sumReci += double.Parse(dt.Rows[i]["receive"].ToString());
                sumRefund += double.Parse(dt.Rows[i]["refund"].ToString());
                sumReal += double.Parse(dt.Rows[i]["realfee"].ToString());
            }
            dt.Rows.Add(null, "总金额", sumReci.ToString(), sumRefund.ToString(), sumReal.ToString());
            dt.Columns.Remove("item_id");

            return dt;
        }

        public DataTable getPaytypeGather(string startTime,string endTime)
        { 
            DataTable dt = null;
            DataTable dt_refund = null;
            string sql_charge = "select "
                              + " sys_dict.sn as id"
                              + ",sys_dict.name as paytypename"
                              + ",sum(clinic_invoicedet.payfee) as receive"
                              + ",'0.00' as refund"
                              + ",'0.00' as realfee"
                              + " from clinic_invoicedet left join sys_dict"
                              + " on clinic_invoicedet.bas_paytype_id = sys_dict.sn"
                              + " and father_id <>0 and dicttype = 'bas_paytype'"
                              + " where clinic_invoice_id in (select id from clinic_invoice where chargedate>= " + DataTool.addFieldBraces(startTime)
                              + " and chargedate<= " + DataTool.addFieldBraces(endTime)
                              + " and charged in (" + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                              + "," + DataTool.addFieldBraces(CostCharged.RET.ToString())
                              + " )) group by sys_dict.sn,sys_dict.name ";
            string sql_refund = "select "
                              + " sys_dict.sn as id"
                              + ",sys_dict.name as paytypename"
                              + ",sum(clinic_invoicedet.payfee) as refund"
                              + " from clinic_invoicedet left join sys_dict"
                              + " on clinic_invoicedet.bas_paytype_id = sys_dict.sn"
                              + " and father_id <>0 and dicttype = 'bas_paytype'"
                              + " where clinic_invoice_id in (select id from clinic_invoice where chargedate>= " + DataTool.addFieldBraces(startTime)
                              + " and chargedate<= " + DataTool.addFieldBraces(endTime)
                              + " and charged in (" + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                              + " )) group by sys_dict.sn,sys_dict.name ";

            dt = BllMain.Db.Select(sql_charge).Tables[0];
            dt_refund = BllMain.Db.Select(sql_refund).Tables[0];
            double sumReci = 0, sumRefund = 0, sumReal = 0;
            for (int i = 0; i < dt_refund.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt_refund.Rows[i]["id"] == dt.Rows[j]["id"])
                    {
                        dt.Rows[i]["refund"] = dt_refund.Rows[i]["refund"];
                    }
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["realfee"] = (double.Parse(dt.Rows[i]["receive"].ToString()) - double.Parse(dt.Rows[i]["refund"].ToString())).ToString();
                sumReci += double.Parse(dt.Rows[i]["receive"].ToString());
                sumRefund += double.Parse(dt.Rows[i]["refund"].ToString());
                sumReal += double.Parse(dt.Rows[i]["realfee"].ToString());
            }
            dt.Rows.Add(null, "总金额", sumReci.ToString(), sumRefund.ToString(), sumReal.ToString());
            dt.Columns.Remove("id");
            return dt;

        }
    }
}
