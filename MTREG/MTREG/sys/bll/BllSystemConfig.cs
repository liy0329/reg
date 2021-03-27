using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.main.bll;
using System.Data;

namespace MTHIS.sys.bll
{
    class BllSystemConfig
    {
        /// <summary>
        /// 获取系统配置信息
        /// </summary>
        /// <returns></returns>
        public DataTable getConfigInfo()
        {
            string sql = "select * from lis_sysconfig";
            return BllMain.Db.Select(sql).Tables[0];
        }
    }
}
