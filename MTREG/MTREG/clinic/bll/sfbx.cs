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
    public class Sfbx
    {
        public DataTable gethism(string id)
        {
//            string sql_xmbm = @"SELECT
//                                clinic_costdet.id,
//	                            clinic_costdet.clinic_cost_id AS costid,
//	                            clinic_costdet.id AS stuffiid,
//	                            clinic_costdet.standcode AS sfxmdm,
//	                            clinic_costdet. NAME AS xmmc,
//	                            insur_itemfrom.insurcode AS itemfromcode,
//	                            clinic_costdet.Prc,
//	                            clinic_costdet.Num AS qty,
//	                            clinic_costdet.Fee AS amt,
//	                            clinic_costdet.Spec,
//	                            clinic_costdet.Unit AS uom
//                            FROM
//	                            clinic_costdet
//                            LEFT JOIN insur_itemfrom ON insur_itemfrom.itemtype_id = clinic_costdet.itemtype_id and insur_itemfrom.cost_insurtype_id = 6
//                            WHERE

            string sql_xmbm = @"SELECT
clinic_costdet.id, clinic_costdet.clinic_cost_id AS costid,	                        clinic_costdet.spbz AS ypspbz,
	                        -- 审批标志
	                        clinic_costdet.yptsxx AS yptsxx,
	                        -- 药品提示信息
	                        clinic_costdet.itemfrom AS projecttype,
	                        -- 项目类型
	                        clinic_costdet.id AS stuffiid,
	                        -- 
	                        '' AS mzh,
	                        clinic_costdet.id AS cfh,
	                        -- 处方号
	                        clinic_costdet.rcpdate AS cfrq,
	                        -- 处方日期
	                        bas_item.standcode AS sfxmdm,
	                        clinic_costdet. NAME AS xmmc,
							(select insurcode from insur_itemfrom where insur_itemfrom.itemtype_id = clinic_costdet.itemtype_id and insur_itemfrom.cost_insurtype_id = 6) AS itemfromcode,
	                        clinic_costdet.Prc,
	                        clinic_costdet.Num AS qty,
	                        clinic_costdet.Fee AS amt,
							clinic_costdet.Spec,
	                        clinic_costdet.chargedate AS jsrq,
	                        clinic_costdet.Spec AS prodguige,
	                        '' AS jixing,
	                         clinic_costdet.Unit AS uom -- 收费单位
                        FROM
	                        clinic_costdet
                        LEFT JOIN bas_item on clinic_costdet.item_id = bas_item.id
                        WHERE
                            clinic_costdet.charged in ('RREC','RET','CHAR')  and
	                            clinic_costdet.clinic_Invoice_id  = " + id;
            
            DataTable dt = BllMain.Db.Select(sql_xmbm).Tables[0];
            return dt;
        }

        
    }
}
