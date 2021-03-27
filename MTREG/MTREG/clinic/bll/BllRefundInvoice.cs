using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTREG.clinic.bll
{
    class BllRefundInvoice
    {
        public DataTable getClinicRcp(string cliniCostId)
        {
            DataSet dataset = null;
            string sql = "select "
                       + " clinic_costdet.id"
                       + ",bas_item.name"
                       + ",charged"
                       + ",unlocked"
                       + " from clinic_costdet left join bas_item"
                       + " on bas_item.id = clinic_costdet.item_id"
                       + " where clinic_costdet.clinic_cost_id = "
                       + DataTool.addFieldBraces(cliniCostId);
            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }


    }
}
