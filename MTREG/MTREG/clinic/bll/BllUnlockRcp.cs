using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;

namespace MTREG.clinic.bll
{
    class BllUnlockRcp
    {
        public DataTable getChargeData(string invoiceId)
        {
            DataSet dataset = null;
            string sql = "";
            if (string.IsNullOrEmpty(invoiceId))
            {
                sql = "select "
                           + " clinic_cost.id"
                           + ",clinic_cost.billcode"
                           + ",clinic_cost.chargedate"
                           + ",bas_depart.name as dptname"
                           + ",bas_doctor.name as dctname"
                           + ",clinic_cost.Realfee"
                           + " from clinic_cost"
                           + " left join bas_depart on clinic_cost.depart_id = bas_depart.id"
                           + " left join bas_doctor on clinic_cost.doctor_id = bas_doctor.id"
                           + " where 1!=1";
            }
            else
            {
                sql = "select "
                           + " clinic_cost.id"
                           + ",clinic_cost.billcode"
                           + ",clinic_cost.chargedate"
                           + ",bas_depart.name as dptname"
                           + ",bas_doctor.name as dctname"
                           + ",clinic_cost.Realfee"
                           + " from clinic_cost"
                           + " left join bas_depart on clinic_cost.depart_id = bas_depart.id"
                           + " left join bas_doctor on clinic_cost.doctor_id = bas_doctor.id"
                           + " where clinic_cost.id in (select clinic_cost_id from clinic_costdet "
                           + " where retappstat = 'Y' and unlocked = 'N' and clinic_invoice_id = " + DataTool.addFieldBraces(invoiceId)
                           + ");";
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
        /// 查询明细数据
        /// </summary>
        /// <param name="cliniCostId"></param>
        /// <returns></returns>
        public DataTable getClinicRcp(string cliniCostId)
        {
            DataSet dataset = null;
            string sql = "select "
                       + " clinic_costdet.id"
                       + ",clinic_costdet.name"
                       + ",clinic_costdet.unit"
                       + ",clinic_costdet.num"
                       + ",clinic_costdet.prc"
                       + ",clinic_costdet.retappstat"
                       + ",clinic_invoice.billcode"
                       + " from clinic_costdet "
                       + " left join clinic_invoice on clinic_costdet.clinic_Invoice_id=clinic_invoice.id"
                       + " where clinic_costdet.clinic_cost_id = "
                       + DataTool.addFieldBraces(cliniCostId);
            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }
        /// <summary>
        /// 修改收费明细表为已解锁
        /// </summary>
        /// <param name="recipelIds"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int modifyCliniCostdet(string recipelIds, ref string merge_sql)
        {
            String sql = "update clinic_costdet  set "
                       + " unlocked = 'Y'"
                       + " where id in ("
                       + recipelIds;
            sql += ");";
            merge_sql += sql;
            return 0;
        }
        /// <summary>
        /// 修改收费主表为已解锁
        /// </summary>
        /// <param name="recipelIds"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int modifyCliniCost(string recipelIds, ref string merge_sql)
        {
            String sql = "update clinic_cost  set "
                       + " unlocked = 'Y'"
                       + " where id in ("
                       + recipelIds;
            sql += ");";
            merge_sql += sql;
            return 0;
        }

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


        public DataTable  getCliniCostIds(string cliniCostdetIds)
        {
            DataSet dataset = null;
            string sql = "select "
                       + " clinic_cost_id as id"
                       + " from clinic_costdet "
                       + " where id in ( "
                       + cliniCostdetIds
                       + ")";
            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }
    }
}
