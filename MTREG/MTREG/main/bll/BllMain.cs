/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       BllMain
     * 机器名称：       AARON-PC
     * 命名空间：       MTLIS.main.bll
     * 文 件 名：       BllMain
     * 创建时间：       2013/5/13 14:43:37
     * 作    者：       田非
     * 说   明：        主窗体_业务
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Data;
using MTHIS.db;
using MTHIS.common;

namespace MTHIS.main.bll
{
    class BllMain
    {
        static DBbase db;
        static DBbase hisdb;
        static DBbase insurdb;
        static DBbase accessdb;
        static DBbase hdxbhnhdb;
        static DBbase hsdrdb;
        static DBbase ynthxybdb;
        static DBbase ynsybdb;
        /// <summary>
        /// 云南省医保db
        /// </summary>
        public static DBbase Ynsybdb
        {
            get { return BllMain.ynsybdb; }
            set { BllMain.ynsybdb = value; }
        }
        /// <summary>
        /// 云南通海县医保
        /// </summary>
        public static DBbase Ynthxybdb
        {
            get { return BllMain.ynthxybdb; }
            set { BllMain.ynthxybdb = value; }
        }
        /// <summary>
        /// 衡水武邑县医保
        /// </summary>
        public static DBbase Hsdrdb
        {
            get { return BllMain.hsdrdb; }
            set { BllMain.hsdrdb = value; }
        }
        /// <summary>
        /// 邯郸县北航农合
        /// </summary>
        public static DBbase Hdxbhnhdb
        {
            get { return BllMain.hdxbhnhdb; }
            set { BllMain.hdxbhnhdb = value; }
        }
        /// <summary>
        /// 农合中间库
        /// </summary>
        public static DBbase AccessDb
        {
            get { return BllMain.accessdb; }
            set { BllMain.accessdb = value; }
        }
        /// <summary>
        /// 医保中间库
        /// </summary>
        public static DBbase InsurDb
        {
            get { return BllMain.insurdb; }
            set { BllMain.insurdb = value; }
        }
        /// <summary>
        /// LIS数据库
        /// </summary>
        public static MTHIS.db.DBbase Db
        {
            get { return db; }
            set { db = value; }
        }
        /// <summary>
        /// His数据库
        /// </summary>
        public static MTHIS.db.DBbase HisDb
        {
            get { return hisdb; }
            set { hisdb = value; }
        }


        /// <summary>
        /// 初始化系统数据连接对象
        /// </summary>
        /// <returns>true:成功; false:失败</returns>
        public bool initDB()
        {
            DBProvider provider = new DBProvider();
            provider.initDBInfo();
            db = DBProvider.getDB("MTHIS");
            if (db == null)
            {
                return false;
            }
            hisdb = DBProvider.getDB("MTMCHK");
            if (hisdb == null)
            {
                return false;
            }
            insurdb = DBProvider.getDB("MTYBJK");
            if (insurdb == null)
            {
                return false;
            }
            hdxbhnhdb = DBProvider.getDB("HDXBHNH");
            if (hdxbhnhdb == null)
            {
                return false;
            }
            accessdb = DBProvider.getDB("MTNHJK");
            if (accessdb == null)
            {
                return false;
            }
            hsdrdb = DBProvider.getDB("MT_HSDRYB");
            if (hsdrdb == null)
            {
                return false;
            }
            ynthxybdb = DBProvider.getDB("MT_HSDRYB");
            if (ynthxybdb == null)
            {
                return false;
            }
            ynsybdb = DBProvider.getDB("MTYNSJK");
            if (ynsybdb == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据用户角色获取菜单
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>菜单数据集</returns>
        public static DataSet getMenuByUser(String fatherid, String account_id)
        {
            String sql = "select * from acc_menu where "
                      + " father_id in (select id from acc_menu where keyname = 'cost:SYSCOST')"
                      + " and  platform='CAPP'"
                      + " and isstop = 'N'"
                      + " and  id in " + "(select menu_id from acc_account_menu where account_id =" + DataTool.addFieldBraces(account_id) + ") order by ordersn";

            if (fatherid != null)
            {
                sql = "select * from acc_menu where "
                     + " father_id = " + DataTool.addFieldBraces(fatherid)
                     + " and  platform='CAPP'"
                     + " and isstop = 'N'"
                     + " and  id in " + "(select menu_id from acc_account_menu where account_id =" + DataTool.addFieldBraces(account_id) + ") order by ordersn";
            }

            return db.Select(sql);
        }

        /// <summary>
        /// 根据用户角色获取菜单
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>菜单数据集</returns>
        public static DataSet getToolBarByUser(String fatherid, String account_id)
        {
            String sql = "select acc_menu.id, acc_menu.name,acc_menu.icon, acc_icon.ordersn from acc_menu  right join  acc_icon on  acc_menu.id = menu_id  where "
                        + " father_id in (select id from acc_menu where father_id in (select id from acc_menu where keyname = 'cost:SYSCOST'))"
                        + " and  platform='CAPP'"
                        + " AND isstop = 'N' "
                        + " and acc_icon.account_id =" + DataTool.addFieldBraces(account_id)
                        + " and acc_icon.sys_id in (select id from acc_menu where keyname = 'cost:SYSCOST')"
                        + " order by ordersn";
            return db.Select(sql);
        }
        /// <summary>
        /// 获取服务器当前时间字符串【"yyyy-MM-dd HH:mm:ss"】
        /// </summary>
        /// <returns></returns>
        public static string getServieDateTimeString()
        {
            string sql = "select NOW() as nowdat;";
            string ret = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                ret = DateTime.Parse(db.Select(sql).Tables[0].Rows[0][0].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception)
            {

            }
            return ret;
        }
        
        /// <summary>
        /// 获取版本过期信息
        /// </summary>
        /// <returns></returns>
        public static DataTable getVersionChk()
        {
            string sql_version = "select ischk,limitdate from sys_version";
            DataTable dt = BllMain.db.Select(sql_version).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
    }
}
