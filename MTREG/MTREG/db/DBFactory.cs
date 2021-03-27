/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       FactoryClass
     * 机器名称：       AARON-PC
     * 命名空间：       MTLIS.db
     * 文 件 名：       FactoryClass
     * 创建时间：       2013/5/16 14:43:37
     * 作    者：       田非
     * 说   明：        数据库连接工厂类
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MTHIS.db
{
    public class FactoryClass
    {
        /// <summary>
        /// 根据数据库类型获得数据库操作对象
        /// </summary>
        /// <param name="constring">数据库连接字符串</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>数据库操作对象</returns>
        public DBbase GetDB(string constring, string dbType)
        {
            lock (this)
            {
                if (dbType == "Oracle")
                {
                    return new DBOracle(constring);
                }
                else if (dbType == "SQLSERVER")
                {
                    return new DBSQLServer(constring);
                }
                else if (dbType == "PostgreSQL")
                {
                    return new DBPostgreSQL(constring);
                }
                else if(dbType == "MySQL")
                {
                    return new DBMySQLODBC(constring); // DBMySQL(constring);
                }
                else if (dbType == "Access")
                {
                    return new DBAccess(constring); 
                }   
                else
                {
                    return null;
                }
            }
        }
    }
}