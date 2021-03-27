using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.db;
using System.Data;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTHIS.sys.bll
{
    class BllPrint
    {
        public DataTable SelectData()
        {
            string sql = "select id"
                        + " ,codeid"
                        + " ,name"
                        + " ,point_x"
                        + " ,point_y"
                        + " ,frmurl"
                        + " ,case isstop"
                        + " when 'N' then '否'"
                        + " when 'Y' then '是'"
                        + " end as isstop,"
                        + " case ispreview "
                        + " when 'N' then '否'"
                        + " when 'Y' then '是'"
                        + " end as ispreview"                   
                        + " from sys_print"
                        + " where sysm_id in (select id from acc_menu where keyname = 'cost:SYSCOST')"
                        + " and orgid in (select orgid from sys_info);";
            return BllMain.Db.Select(sql).Tables[0];
        }

        public int insertItemData(string codeid, string name, string point_x, string point_y, string isstop, string ispreview, string frmurl, string sysm_id)
        {
            string sql = "insert into sys_print("
                            + " codeid"
                            + " ,name"
                            + " ,point_x"
                            + " ,point_y"
                            + " ,isstop"
                            + " ,ispreview"
                            + " ,frmurl"
                            + " ,sysm_id"
                            + ")"
                            + " values("
                            + DataTool.addFieldBraces(codeid)
                            + "," + DataTool.addFieldBraces(name)
                            + "," + DataTool.addFieldBraces(point_x)
                            + "," + DataTool.addFieldBraces(point_y)
                            + "," +  DataTool.addFieldBraces(isstop)
                            + "," + DataTool.addFieldBraces(ispreview)
                            + "," + DataTool.addFieldBraces(frmurl)
                            + "," + DataTool.addFieldBraces(sysm_id)
                            + ")";
            return BllMain.Db.Update(sql);  
        }

        public int updateItemData(string id, string codeid, string name, string point_x, string point_y, string isstop, string ispreview, string frmurl, string sysm_id)
        {
            string sql = "update sys_print set "
                               + "codeid=" + DataTool.addFieldBraces(codeid)
                               + ",name=" + DataTool.addFieldBraces(name)
                               + ",point_x=" + DataTool.addFieldBraces(point_x)
                               + ",point_y=" + DataTool.addFieldBraces(point_y)
                               + ",isstop=" + DataTool.addFieldBraces(isstop)
                               + ",ispreview=" + DataTool.addFieldBraces(ispreview)
                               + ",frmurl=" + DataTool.addFieldBraces(frmurl)
                               + ",sysm_id=" + DataTool.addFieldBraces(sysm_id)
                               + " where id=" + DataTool.addFieldBraces(id);
            return BllMain.Db.Update(sql);
        }


        public int deleteItemData(string printId)
        {
            string sql = "delete from sys_print where id=" + DataTool.addFieldBraces(printId);
            return BllMain.Db.Update(sql);
        }

        public string getSysm_id()
        {
            string sql="select id from acc_menu where keyname = 'cost:SYSCOST'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["id"].ToString();
        }

    }
}
