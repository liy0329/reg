/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       DBbase
     * 机器名称：       AARON-PC
     * 命名空间：       MTLIS.db
     * 文 件 名：       DBbase
     * 创建时间：       2013/5/16 14:43:37
     * 作    者：       田非
     * 说   明：        数据库连接基类
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Odbc;

namespace MTHIS.db
{
    //数据连接的工厂模式抽象类
    public abstract class DBbase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DBbase()
        {
        }
     
        #region 链接MTLIS数据库

        public abstract bool ConnectionTest(string constring);
        
        /// <summary>
        /// 打开一个连接
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// 关闭一个连接
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// 数据读取的公共数
        /// </summary>
        /// <param name="procname"></param>
        /// <param name="parmas"></param>
        public abstract void PublicClass(string procname, object[] parmas);

        /// <summary>
        /// 执行无返回DataSet的函数
        /// </summary>
        /// <param name="procname"></param>
        /// <param name="parmas"></param>
        /// <returns></returns>
        public abstract string Execsql(string procname, object[] parmas);

        /// <summary>
        /// 执行有返回DataSet的函数
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="procname"></param>
        /// <param name="parmas"></param>
        /// <returns></returns>
        public abstract DataSet ExecSqlReturnDataSet(string tablename, string procname, ProcParma[] parmas);

        /// <summary>
        ///  执行存储过程返回DataSet不是公共方法
        /// </summary>
        /// <param name="pricName"></param>
        /// <param name="parmas"></param>
        /// <returns></returns>
        public abstract DataSet ExecSqlPricDataSet(string pricName, object[] parmas);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public abstract bool Select(string sql, String tableName, DataSet ds);
        public abstract DataSet Select(string sql, string tableName);
        public abstract DataSet Select(string sql);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public abstract int Update(DataSet ds, String sql, String tableName);
        public abstract int Update(DataTable dt, String sql);
        public abstract int Update(String sql);
        public abstract String ExecSqlPricDataSet1(string pricName, OdbcParameter[] parmas);
        #endregion

    }
}
