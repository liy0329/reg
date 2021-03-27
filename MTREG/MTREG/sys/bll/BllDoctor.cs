/*************************************************************************************
    * CLR版本：       2.0.50727.4984
    * 类 名 称：       BllDoctor
    * 机器名称：       DELL-PC
    * 命名空间：       MTLIS.sys.bll
    * 文 件 名：       BllDoctor
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
using System.Data;
using MTHIS.db;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTHIS.sys.bll
{
    /// <summary>
    /// 送检医生
    /// </summary>
    class BllDoctor
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


                string depart_id = row["depart_id"].ToString();
                string name = row["name"].ToString();
                string pincode = row["pincode"].ToString();
                string hiscode = row["hiscode"].ToString();
                string isshow = row["isshow"].ToString();

                if (row.RowState == DataRowState.Added)
                {
                    sql = "insert into lis_doctor"
                           + "(depart_id"
                           + ", name"
                           + ", pincode"
                           + ", hiscode"
                           + ", isshow)"
                           + "values (" + DataTool.addFieldBraces(depart_id)
                           + ", " + DataTool.addFieldBraces(name)
                           + ", " + DataTool.addFieldBraces(pincode)
                           + ", " + DataTool.addFieldBraces(hiscode)
                           + ", " + DataTool.BoolStrValue(isshow)
                           + ")";
                    if (BllMain.Db.Update(sql) != 0)
                    {
                        return -1;
                    }
                }
                if (row.RowState == DataRowState.Modified)
                {
                    sql = "update lis_doctor set"
                         + " depart_id=" + DataTool.addFieldBraces(depart_id)
                         + ",name=" + DataTool.addFieldBraces(name)
                         + ",pincode=" + DataTool.addFieldBraces(pincode)
                         + ",hiscode=" + DataTool.addFieldBraces(hiscode)
                         + ",isshow=" + DataTool.BoolStrValue(isshow)
                         + " where id=" + row[0].ToString();
                    if (BllMain.Db.Update(sql) != 0)
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 保存医生
        /// </summary>
        /// <returns></returns>
        public bool saveDoctor(DataTable dt)
        {
            try
            {
                String sql = "select * from lis_doctor";
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
        /// 根据id查询医生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable findById(int id)
        {
            sql = "select * from lis_doctor where id=" + id;
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 获取科室下拉框
        /// </summary>
        /// <returns></returns>
        public DataTable getCmbxDept()
        {
            sql = "select * from lis_depart where isshow='1'";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 导入
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
                sql = "select * from LIS_VIEW_DOCTOR";
                DataTable dt = db.Select(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int depart_id = findDeptIdByCode(row["DEPCODE"].ToString());
                        if (depart_id == -1)
                        {
                            return -2;
                        }
                        sql = "select * from lis_doctor where hiscode='" + row["Code"].ToString() + "'";
                        int count = BllMain.Db.Select(sql).Tables[0].Rows.Count;
                        switch (count)
                        {
                            case 0:
                                sql = "insert into lis_doctor(depart_id, name, pincode, hiscode, isshow, platform_id) values(" 
                                    + depart_id + ", '" + row["Name"].ToString() + "', '" + GetData.GetChineseSpell(row["Name"].ToString())
                                    + "', '" + row["Code"].ToString() + "', 1," + platformid + " )";
                                BllMain.Db.Update(sql);
                                break;
                            case 1:
                                sql = "update lis_doctor set depart_id=" + depart_id + ", name='" + row["Name"].ToString() 
                                    + "', pincode='" + GetData.GetChineseSpell(row["Name"].ToString()) + "' , isshow=1, platform_id="+platformid+"  where id="
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
            return -3;
        }

        /// <summary>
        /// 根据his代码查询科室id
        /// </summary>
        /// <param name="hiscode"></param>
        /// <returns></returns>
        public int findDeptIdByCode(string hiscode)
        {
            sql = "select id from lis_depart where hiscode='" + hiscode + "'";
            DataTable dt=BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["id"].ToString());
            }
            else
            {
                return -1;
            }
        }
    }
}
