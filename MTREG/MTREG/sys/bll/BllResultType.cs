using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MTHIS.db;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTHIS.sys.bll
{
    class BllResultType
    {
        /// <summary>
        /// 查询结果类型表
        /// </summary>
        /// <returns></returns>
        public DataTable SelectResultType()
        {
            
            string sql = "select name,id from lis_dict where dicttype = 'resulttype' and father_id not in (0) order by sn ";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
            
        }
        /// <summary>
        /// 通过结果类型查询结果表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable SelectResult(string restype_id)
        {
            string sql = "select id, name,itemsn,pincode from lis_devitemstrrange where restype_id = '" + restype_id + "' order by itemsn";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 通过结果表中的ID，删除对应的结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteResult(string id)
        {
            try
            {
                string sql = "delete from lis_devitemstrrange where id = '" + id + "'";
                BllMain.Db.Update(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertIntoReuslt(string restype_id, string name, string itemsn, string id)
        {
            try
            {
                string sql_select = "select * from lis_devitemstrrange where id = '" + id + "'";
                DataTable dt = BllMain.Db.Select(sql_select).Tables[0];
                if (dt.Rows.Count <= 0)
                {

                    if (restype_id == null || restype_id == "")
                    {
                        return false;
                    }
                    else
                    {
                        restype_id = "'" + restype_id + "'";
                    }
                    if (name == null || name == "")
                    {
                        return false;
                    }
                    else
                    {
                        name = "'" + name + "'";
                    }
                    if (itemsn == null || itemsn == "")
                    {
                        return false;
                    }
                    else
                    {
                        itemsn = "'" + itemsn + "'";
                    }

                    string sql = "insert into lis_devitemstrrange (restype_id,name,itemsn) values (" + restype_id + "," + name + "," + itemsn + ")";
                    BllMain.Db.Update(sql);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateReuslt(string restype_id, string name, string itemsn, string id)
        {
            try
            {
                string sql_select = "select * from lis_devitemstrrange where id = '" + id + "'";
                DataTable dt = BllMain.Db.Select(sql_select).Tables[0];
                if (dt.Rows.Count > 0)
                {

                    if (restype_id == null || restype_id == "")
                    {
                        return false;
                    }
                    else
                    {
                        restype_id = "'" + restype_id + "'";
                    }
                    if (name == null || name == "")
                    {
                        return false;
                    }
                    else
                    {
                        name = "'" + name + "'";
                    }
                    if (itemsn == null || itemsn == "")
                    {
                        return false;
                    }
                    else
                    {
                        itemsn = "'" + itemsn + "'";
                    }

                    string sql = "update lis_devitemstrrange set restype_id = " + restype_id + ",name = " + name + ",itemsn = " + itemsn + " where id = '" + id + "'";
                    BllMain.Db.Update(sql);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public string selectmeno(string id)
        {
            string sql = "select memo from lis_dict where id="+id;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["memo"].ToString();
        }
        public bool updatedict(string id,string meno)
        {
            try
            {
                string sql = "update lis_dict set memo='" + meno + "' where id=" + id;
                BllMain.Db.Update(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
