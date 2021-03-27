using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.main.bll;
using System.Data;

namespace MTREG.clinic.bll
{
    class BllBasDepart
    {
        /// <summary>
        /// 获取拼音简码
        /// </summary>
        /// <param name="depart_id"></param>
        /// <returns></returns>
        public DataTable queryForPincode(String depart_id)
        {
            String sql="select pincode from bas_depart where id="
                        +depart_id;
            DataTable dt = null;
            try {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch(Exception e){
                
            }
            return dt;
        }
    }
}
