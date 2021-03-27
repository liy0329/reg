/*************************************************************************************
    * CLR版本：       2.0.50727.4984
    * 类 名 称：       BllDepart
    * 机器名称：       DELL-PC
    * 命名空间：       MTLIS.sys.bll
    * 文 件 名：       BllDepart
    * 创建时间：       2013/5/18 16:41:45
    * 作    者：          郑月
    * 说   明：。。。。。
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.db;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;


namespace MTHIS.sys.bll
{
    /// <summary>
    /// 送检科室
    /// </summary>
    class BllDepart
    {
        string sql;
        static DBbase db;
        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int save(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                string name = row["name"].ToString();
                string pincode = row["pincode"].ToString();
                string hiscode = row["hiscode"].ToString();
                string isshow = row["isshow"].ToString();
                string platform_id = row["platform_id"].ToString();

                if (row.RowState == DataRowState.Added)
                {
                    sql = "insert into lis_depart"
                         + "(name"
                         + ",pincode"
                         + ",hiscode"
                         + ",isshow"
                         + ",platform_id"
                         + ") values("
                         + DataTool.addFieldBraces(name)
                         + ", " + DataTool.addFieldBraces(pincode)
                         + ", " + DataTool.addFieldBraces(hiscode)
                         + ", " + DataTool.BoolStrValue(isshow)
                         + "," + DataTool.addFieldBraces(platform_id)
                         + ")";

                    if (BllMain.Db.Update(sql) != 0)
                    {
                        return -1;
                    }

                }

                if (row.RowState == DataRowState.Modified)
                {

                    sql = "update lis_depart set "
                          + " name=" + DataTool.addFieldBraces(name)
                          + ", pincode=" + DataTool.addFieldBraces(pincode)
                          + ", hiscode=" + DataTool.addFieldBraces(hiscode)
                          + ", isshow=" + DataTool.BoolStrValue(isshow)
                          + ", platform_id=" + DataTool.addFieldBraces(platform_id)
                          + "  where id=" + row[0].ToString();
                    if (BllMain.Db.Update(sql) != 0)
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 保存科室
        /// </summary>
        /// <returns></returns>
        public bool saveDepart(DataTable dt)
        {
            try
            {
                String sql = "select * from lis_depart";
                if (BllMain.Db.Update(dt, sql) == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 导入科室
        /// </summary>
        /// <returns></returns>
        public bool importDepart()
        {
            BllMain.Db.Update("delete from lis_depart");  //清空原有科室
            DataTable dt = DBProvider.getDB("MTLIS").Select("select * from lis_view_department").Tables[0];
            string sql = ""; 
            foreach(DataRow row in dt.Rows)
            {
                sql = string.Format("insert into lis_depart (name, pincode, hiscode, isshow, platform_id) values ('{0}', '{1}', '{2}', '{3}', '{4}')",
                    row["name"].ToString(), GetData.GetChineseSpell(row["name"].ToString()), row["code"].ToString(), true, "1");

                if (BllMain.Db.Update(sql) != 0)
                    return false;                
            }
            return true;
        }
      
        /// <summary>
        /// 根据id查询科室信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable findById(int id)
        {
            sql = "select * from lis_depart where id="+id;
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 导入科室信息
        /// </summary>
        /// <returns></returns>
        public int readIn(string platformid)
        {
            if (platformid.Equals("1"))
            {
                db = DBProvider.getDB("MTHIS");
            }
            else {
                db = DBProvider.getDB("MTMCHK");
            }
            
            if(db!=null)
            {
                sql = "select * from LIS_VIEW_DEPARTMENT ";
                DataTable dt = db.Select(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        sql = "select * from lis_depart where hiscode='" + row["Code"].ToString() + "'";
                        int count = BllMain.Db.Select(sql).Tables[0].Rows.Count;
                        switch (count)
                        {
                            case 0:
                                sql = "insert into lis_depart(name, pincode, hiscode, isshow, platform_id) values('" + row["Name"].ToString() 
                                    + "', '" + GetData.GetChineseSpell(row["Name"].ToString()) + "', '" + row["Code"].ToString() + "', 1, "+platformid+")";
                                BllMain.Db.Update(sql);
                                break;
                            case 1:
                                sql = "update lis_depart set name='" + row["Name"].ToString() + "', pincode='"
                                    + GetData.GetChineseSpell(row["Name"].ToString()) + "', isshow=1, platform_id=" + platformid + " where id=" 
                                    + BllMain.Db.Select(sql).Tables[0].Rows[0]["id"].ToString();
                                BllMain.Db.Update(sql);
                                break;
                            default:
                                return -1;
                        }
                    }
                }
                return dt.Rows.Count;
            }
            return -2;
        }
    }
}
