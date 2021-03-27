/*************************************************************************************
    * CLR版本：       2.0.50727.4984
    * 类 名 称：       BllRole
    * 机器名称：       DELL-PC
    * 命名空间：       MTLIS.sys.bll
    * 文 件 名：       BllRole
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
using MTHIS.common;
using MTHIS.main.bll;

namespace MTHIS.sys.bll
{
    /// <summary>
    /// 角色管理
    /// </summary>
    class BllRole
    {
        string sql;

        /// <summary>
        /// 获取所有的主菜单
        /// </summary>
        /// <returns></returns>
        public DataTable getMainMenu()
        {
            sql = "select * from lis_menu where father_id is null order by ordersn ";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 根据主菜单查询子菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getSubMenuByMain(int id)
        {
            sql = "select * from lis_menu where father_id=" + id + " order by ordersn";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 根据角色查询菜单
        /// </summary>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public DataTable getMenuByRole(int role_id)
        {
            sql = "select name from lis_menu where id in (select menu_id from lis_role_menu where role_id=" + role_id + " ) order by ordersn";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 根据角色查询仪器
        /// </summary>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public DataTable getDevByRole(int role_id)
        {
            sql = "select devname from lis_dev where id in (select dev_id from lis_role_dev where role_id=" + role_id + ")";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int addRole(string name)
        {
            sql = "insert into lis_role(name, pincode) values('" + name + "', '"+GetData.GetChineseSpell(name)+"')";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 保存lis_role_menu
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name"></param>
        public void addRole_Menu(DataTable dt, string name)
        {
            int role_id = getIdByRoleName(name);
            foreach (DataRow row in dt.Rows)
            {
                int menu_id = getIdByMenuName(row["name"].ToString());
                sql = "insert into lis_role_menu(role_id, menu_id) values("+role_id+", "+menu_id+")";
                BllMain.Db.Update(sql);
            }
        }

        /// <summary>
        /// 保存lis_role_dev
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name"></param>
        public void addRole_Dev(DataTable dt, string name)
        {
            int role_id = getIdByRoleName(name);
            foreach (DataRow row in dt.Rows)
            {
                int dev_id = getIdByDevName(row["devname"].ToString());
                sql = "insert into lis_role_dev(role_id, dev_id) values(" + role_id + ", " + dev_id + ")";
                BllMain.Db.Update(sql);
            }
        }
        
        /// <summary>
        /// 根据角色名称查询role_id
        /// </summary>
        /// <param name="role_name"></param>
        /// <returns></returns>
        public int getIdByRoleName(string role_name)
        {
            sql = "select id from lis_role where name='" + role_name+"'";
            return int.Parse(BllMain.Db.Select(sql).Tables[0].Rows[0]["id"].ToString());
        }

        /// <summary>
        /// 根据菜单名称查询menu_id
        /// </summary>
        /// <param name="menu_name"></param>
        /// <returns></returns>
        public int getIdByMenuName(string menu_name)
        {
            sql = "select id from lis_menu where name='" + menu_name + "'";
            return int.Parse(BllMain.Db.Select(sql).Tables[0].Rows[0]["id"].ToString());
        }

        /// <summary>
        /// 根据仪器名称查询dev_id
        /// </summary>
        /// <param name="dev_name"></param>
        /// <returns></returns>
        public int getIdByDevName(string dev_name)
        {
            sql = "select id from lis_dev where devname='" + dev_name + "'";
            return int.Parse(BllMain.Db.Select(sql).Tables[0].Rows[0]["id"].ToString());
        }

        /// <summary>
        /// 修改保存
        /// </summary>
        /// <param name="role_id"></param>
        /// <param name="menuList"></param>
        /// <param name="devList"></param>
        /// <returns></returns>
        public int save(int role_id, List<string> menuList, List<string> devList)
        {
            int r = 0;
            removeMenuByRoleId(role_id);
            removeDevByRoleId(role_id);
            if (menuList.Count >= 0)
            {
                foreach (String menu in menuList)
                {
                    int menu_id = getIdByMenuName(menu);
                    sql = "insert into lis_role_menu(role_id, menu_id) values(" + role_id + ", " + menu_id + ")";
                    r = BllMain.Db.Update(sql);
                    if (r == -1)
                    {
                        break;
                    }
                }
            }
            if (devList.Count >= 0)
            {
                foreach (String dev in devList)
                {
                    int dev_id = getIdByDevName(dev);
                    sql = "insert into lis_role_dev(role_id, dev_id) values(" + role_id + ", " + dev_id + ")";
                    r = BllMain.Db.Update(sql);
                    if (r == -1)
                    {
                        break;
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// 根据角色id删除相关菜单记录
        /// </summary>
        /// <param name="id"></param>
        public void removeMenuByRoleId(int id)
        {
            if (getMenuByRole(id).Rows.Count != 0)
            {
                sql = "delete from lis_role_menu where role_id=" + id;
                BllMain.Db.Update(sql);
            }
        }

        /// <summary>
        /// 根据角色id删除相关仪器记录
        /// </summary>
        /// <param name="id"></param>
        public void removeDevByRoleId(int id)
        {
            if (getDevByRole(id).Rows.Count != 0)
            {
                sql = "delete from lis_role_dev where role_id=" + id;
                BllMain.Db.Update(sql);
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public int removeRoleById(int role_id)
        {
            sql = "delete from lis_role where id=" + role_id;
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 根据角色id删除相关用户
        /// </summary>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public int removeAccountByRoleId(int role_id)
        {
            int r = 0;
            sql = "select * from lis_account where role_id="+role_id+" and isused ='1'";
            if (BllMain.Db.Select(sql).Tables[0].Rows.Count != 0)
            {
                r = 1; //某用户正在使用这个角色，不能删除！
                return r;
            }
            sql = "select * from lis_account where role_id=" + role_id;
            if (BllMain.Db.Select(sql).Tables[0].Rows.Count != 0)
            {
                sql = "delete from lis_account where role_id=" + role_id;
                BllMain.Db.Update(sql);
            }
            return r;
        }



    }
}
