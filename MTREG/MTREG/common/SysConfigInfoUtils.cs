using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.main.bll;

namespace MTHIS.common
{
    class SysConfigInfoUtils
    {

        /// <summary>
        /// 获得是否启用
        /// </summary>
        public static int getStarted()
        {
            string sql = "select started from lis_sysconfig";
            return int.Parse(BllMain.Db.Select(sql).Tables[0].Rows[0][0].ToString());

        }
    }
}
