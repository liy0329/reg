using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTREG.clinic.bll
{
    class BllUnlockRcpdetail
    {
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
                       + ",bas_item.name"
                       + ",clinic_costdet.retappstat"
                       + " from clinic_costdet left join bas_item"
                       + " on bas_item.id = clinic_costdet.item_id"
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
        public int modifyCliniCostdet(string recipelIds,ref string merge_sql)
        {
            String sql = "update clinic_costdet  set "
                       + " unlocked = 'Y'"
                       + " where id in ("
                       + DataTool.addFieldBraces(recipelIds);
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
                       + DataTool.addFieldBraces(recipelIds);
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

        public DataTable getCliniCostIds(string cliniCostdetIds)
        {
            DataSet dataset = null;
            string sql = "select "
                       + " clinic_cost.id"
                       + " from clinic_costdet "
                       + " where id in ( "
                       + DataTool.addFieldBraces(cliniCostdetIds)
                       + ")";
            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }
    }
}
