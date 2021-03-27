/*************************************************************************************
    * CLR版本：       2.0.50727.4984
    * 类 名 称：       BllDict
    * 机器名称：       DELL-PC
    * 命名空间：       MTLIS.sys.bll
    * 文 件 名：       BllDict
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
    /// 数据字典
    /// </summary>
    class BllDict
    {
        string sql;

        /// <summary>
        /// 获取数据字典下拉框
        /// </summary>
        /// <returns></returns>
        public DataTable getCmbx()
        {
            sql = "select id, name  from lis_dict where father_id=0 and isshow='1'";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 根据下拉框的值更新DataTable
        /// </summary>
        /// <param name="father_id"></param>
        /// <returns></returns>
        public DataTable getDgv(int father_id)
        {
            sql = "select id, name, dicttype, pincode, isshow, memo, sn,ordersn from lis_dict where father_id=" + father_id;
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="father_id"></param>
        /// <returns></returns>
        public int save(DataTable dt, int father_id)
        {
            
            foreach (DataRow row in dt.Rows)
            {
                int count = this.findById(int.Parse(row[0].ToString()), father_id).Rows.Count;

                string name = row["name"].ToString();
                string dicttype = row["dicttype"].ToString();
                string pincode = row["pincode"].ToString();
                string isshow = row["isshow"].ToString();
                string memo = row["memo"].ToString();
                string sn = row["sn"].ToString();
                string ordersn = row["ordersn"].ToString();
                string id = row["id"].ToString();
                switch (count)
                {
                    case 0:
                        sql = "insert into lis_dict"
                            + "(father_id"
                            + ", name"
                            + ", dicttype"
                            + ", pincode"
                            + ", isshow"
                            + ", memo"
                            + ", sn"
                            + ", ordersn"
                            + ")"
                            + " values("
                            + father_id
                            + "," + DataTool.addFieldBraces(name)
                            + "," + DataTool.addFieldBraces(dicttype)
                            + "," + DataTool.addFieldBraces(pincode)
                            + "," + DataTool.BoolStrValue(isshow)
                            + "," + DataTool.addFieldBraces(memo)
                            + "," + DataTool.addFieldBraces(sn)
                            + "," + DataTool.addFieldBraces(ordersn)
                            + ")";
                        BllMain.Db.Update(sql);
                        break;
                    case 1:
                        sql = "update lis_dict "
                            + "set "
                            + "  father_id=" + father_id
                            + ", name=" + DataTool.addFieldBraces(name)
                            + ", dicttype=" + DataTool.addFieldBraces(dicttype)
                            + ", pincode=" + DataTool.addFieldBraces(pincode)
                            + ", isshow=" + DataTool.BoolStrValue(isshow)
                            + ", memo=" + DataTool.addFieldBraces(memo)
                            + ", sn=" + DataTool.addFieldBraces(sn)
                            + ", ordersn=" + DataTool.addFieldBraces(ordersn)
                            + "  where id=" + DataTool.addFieldBraces(id);
                        BllMain.Db.Update(sql);
                        break;
                }
            }
            return 0;
        }

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="father_id"></param>
        /// <returns></returns>
        public DataTable findById(int id, int father_id)
        {
            if(father_id==0)
            {
                sql = "select * from lis_dict where id=" + id + "  and father_id =0";
            }
            else
            {
                sql = "select * from lis_dict where id=" + id + "  and father_id=" + father_id;
            }
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 根据字典类型查询
        /// </summary>
        /// <param name="dicttype"></param>
        /// <returns></returns>
        public DataTable findByDicttype(string dicttype)
        {
            sql = "select * from lis_dict where dicttype='"+dicttype+"' and father_id =0 ";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        ///  删除数据字典的一行记录  add ytc
        /// </summary>
        /// <param name="dict_id"></param>
        public void deleteDict(string dict_id)
        {
            sql = string.Format("delete from lis_dict where id={0}", dict_id);
            BllMain.Db.Update(sql);
            
        }
    }
}
