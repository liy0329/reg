/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       DBProvider
     * 机器名称：       AARON-PC
     * 命名空间：       MTLIS.db
     * 文 件 名：       DBProvider
     * 创建时间：       2013/5/16 14:43:37
     * 作    者：       田非
     * 说   明：        数据库连接提供类
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Policy;
using System.Collections;

namespace MTHIS.db
{
    class DBProvider
    {

        private FactoryClass fac = new FactoryClass();   //数据库工厂类
        private static Dictionary<String, DBbase> dbpool = new Dictionary<String, DBbase>();   //存储各系统数据库连接配置

        public static Dictionary<String, DBbase> Dbpool
        {
            get { return dbpool; }
        }
        
        /// <summary>
        /// 创建数据库对象
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>数据库连接对象</returns>
        public DBbase provide(string dbType, string section)
        {
            lock (this)
            {
                if (dbType == "Oracle")
                {
                    return fac.GetDB(readOracleIni(), "Oracle");
                }
                else if (dbType == "SQLSERVER")
                {
                    return fac.GetDB(readSqlServerIni(section), "SQLSERVER");
                }
                else if (dbType == "PostgreSQL")
                {
                    return fac.GetDB(readPostgreSQLIni(section), "PostgreSQL");
                }
                else if (dbType == "MySQL")
                {
                    return fac.GetDB(this.readMySQLODBCIni(section), "MySQL"); //readMySQLIni(section)
                }
                else if (dbType == "Access")
                {
                    return fac.GetDB(readAccessIni(section), "Access"); //readAccessIni(section)
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 读取配置文件中数据库配置信息
        /// </summary>
        public void initDBInfo()
        {
            lock (this)
            {
                ArrayList list = Ini.readSections();
                foreach (String str in list)
                {
                    DBbase db = provide(Ini.IniReadValue(str, "DBType"), str);
                    if (db != null)
                    {
                        if (dbpool.ContainsKey(str))
                        {
                            dbpool.Remove(str);
                        }
                        dbpool.Add(str, db);
                    }
                }
            }
        }

        /// <summary>
        /// 读取配置文件中数据库配置信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns>true:成功; false:失败</returns>
        public bool initDBInfo(String path)
        {
            lock (this)
            {
                try
                {
                    Ini.INIClass(path);
                    ArrayList list = Ini.readSections();
                    foreach (String str in list)
                    {
                        DBbase db = provide(Ini.IniReadValue(str, "DBType"), str);
                        if (db != null)
                        {
                            dbpool.Add(str, db);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// 读取sqlserver配置信息
        /// </summary>
        /// <returns>sql server 数据库连接字符串</returns>
        private String readAccessIni(string section)
        {
            lock (this)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("DSN=");
                sb.Append(Ini.IniReadValue(section, "DSN"));
                //sb.Append("Provider=");
                //sb.Append(Ini.IniReadValue(section, "Provider"));
                //sb.Append(";");
                //sb.Append("Data Source=");
                //sb.Append(Ini.IniReadValue(section, "Data Source"));
                sb.Append(";");
                return sb.ToString();
            }
        }

        /// <summary>
        /// 读取sqlserver配置信息
        /// </summary>
        /// <returns>sql server 数据库连接字符串</returns>
        private String readSqlServerIni(string section)
        {
            lock (this)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Data Source=");
                sb.Append(Ini.IniReadValue(section, "Data Source"));
                sb.Append(";");
                sb.Append("Initial Catalog=");
                sb.Append(Ini.IniReadValue(section, "Initial Catalog"));
                sb.Append(";");
                sb.Append("User ID=");
                sb.Append(Ini.IniReadValue(section, "User ID"));
                sb.Append(";");
                sb.Append("Pwd=");
                sb.Append(Ini.IniReadValue(section, "Pwd"));
                sb.Append(";");
                return sb.ToString();
            }
        }

        /// <summary>
        /// 读取oracle配置信息
        /// </summary>
        /// <returns>oracle 数据库连接字符串</returns>
        private String readOracleIni()
        {
            lock (this)
            {
                return "";
            }
        }

        // //static string sql = "Driver={PostgreSQL ANSI};Server=192.168.1.105;Port=9999;Database=cims007db;Uid=bop007;Pwd=123456;";
        /// <summary>
        /// 读取sqlserver配置信息
        /// </summary>
        /// <returns>sql server 数据库连接字符串</returns>
        private String readPostgreSQLIni(string section)
        {
            lock (this)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Driver=");
                sb.Append(Ini.IniReadValue(section, "Driver"));
                sb.Append(";");
                sb.Append("Server=");
                sb.Append(Ini.IniReadValue(section, "Server"));
                sb.Append(";");
                sb.Append("Port=");
                sb.Append(Ini.IniReadValue(section, "Port"));
                sb.Append(";");
                sb.Append("Database=");
                sb.Append(Ini.IniReadValue(section, "Database"));
                sb.Append(";");
                sb.Append("Uid=");
                sb.Append(Ini.IniReadValue(section, "Uid"));
                sb.Append(";");
                sb.Append("Pwd=");
                sb.Append(Ini.IniReadValue(section, "Pwd"));
                sb.Append(";");
                return sb.ToString();
            }
        }
        
        /// <summary>
        /// 读取MySQL配置信息
        /// </summary>
        /// <returns>MySQL 数据库连接字符串</returns>
        private String readMySQLIni(string section)
        {//"database=dbname;Password=;User ID=root;server=192.168.1.168";
            lock (this)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SERVER=");
                sb.Append(Ini.IniReadValue(section, "Server"));
                sb.Append(";");
                sb.Append("database=");
                sb.Append(Ini.IniReadValue(section, "Database"));
                sb.Append(";");
                sb.Append("User ID=");
                sb.Append(Ini.IniReadValue(section, "Uid"));
                sb.Append(";");
                sb.Append("Password=");
                sb.Append(Ini.IniReadValue(section, "Pwd"));
                sb.Append(";");
                return sb.ToString();
            }
        }

        /// <summary>
        /// 读取MySQLODBC配置信息
        /// DRIVER={MySQL ODBC 5.3 Unicode Driver};SERVER=localhost;PORT=3306;DATABASE=test;UID=root;PASSWORD=123456;OPTION=3;MULTI_STATEMENTS=1;
        /// </summary>
        /// <returns>sql server 数据库连接字符串</returns>
        private String readMySQLODBCIni(string section)
        {
            lock (this)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("DRIVER=");
                sb.Append(Ini.IniReadValue(section, "Driver"));
                sb.Append(";");
                sb.Append("SERVER=");
                sb.Append(Ini.IniReadValue(section, "Server"));
                sb.Append(";");
                sb.Append("PORT=");
                sb.Append(Ini.IniReadValue(section, "Port"));
                sb.Append(";");
                sb.Append("DATABASE=");
                sb.Append(Ini.IniReadValue(section, "Database"));
                sb.Append(";");
                sb.Append("UID=");
                sb.Append(Ini.IniReadValue(section, "Uid"));
                sb.Append(";");
                sb.Append("PASSWORD=");
                sb.Append(Ini.IniReadValue(section, "Pwd"));
                sb.Append(";");
                sb.Append("OPTION=3;MULTI_STATEMENTS=1;");
                return sb.ToString();
            }
        }

        /// <summary>
        /// 读取MySQLODBC配置信息_连接数据源ODBC
        /// DSN=MTLIS;UID=MTLIS;PASSWORD=MTLIS;
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        private String readMySQLDSNODBCIni(string section)
        {
            lock (this)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("DSN=");
                sb.Append(Ini.IniReadValue(section, "DSN"));
                sb.Append(";");
                sb.Append("UID=");
                sb.Append(Ini.IniReadValue(section, "UID"));
                sb.Append(";");
                sb.Append("PASSWORD=");
                sb.Append(Ini.IniReadValue(section, "PWD"));
                sb.Append(";");
                return sb.ToString();
            }
        }





        /// <summary>
        /// 根据系统类型取得对应的数据库对象
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>数据库连接对象</returns>
        public static DBbase getDB(String sysType)
        {

            if (DBProvider.Dbpool.ContainsKey(sysType))
            {
                return DBProvider.Dbpool[sysType];
            }
            return null;
        }
    }
}
