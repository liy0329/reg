/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       DBOracle
     * 机器名称：       AARON-PC
     * 命名空间：       MTLIS.db
     * 文 件 名：       DBOracle
     * 创建时间：       2013/5/16 14:43:37
     * 作    者：       田非
     * 说   明：        ORACLE数据库连接
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Data.Odbc;

namespace MTHIS.db
{
    //数据连接的工厂模式ORACLE连接类
    internal class DBOracle : DBbase
    {

        private OracleConnection conn = null;  //数据连接
        private OracleCommand cmd = null;      //连接命令
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="constring">连接字符串</param>
        public DBOracle(string constring)
        {
            lock (this)
            {
                this.conn = new OracleConnection(constring);
            }
        }

        public override bool ConnectionTest(string constring)
        {
            return true;
        }

        /// <summary>
        /// 打开一个连接
        /// </summary>
        public override void Open()
        {
            lock (this)
            {
                if (this.conn != null && this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
            }
        }

        /// <summary>
        /// 关闭一个连接
        /// </summary>
        public override void Close()
        {
            lock (this)
            {
                if (this.conn != null && this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }

        /// <summary>
        /// 数据读取的公共数
        /// </summary>
        /// <param name="procname">sql执行语句</param>
        /// <param name="parmas">sql控制语句参数</param>
        public override void PublicClass(string procname, object[] parmas)
        {
            lock (this)
            {
                OracleParameter[] Oracleparmas = (OracleParameter[])parmas;
                this.cmd = new OracleCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandType = CommandType.StoredProcedure;
                this.cmd.CommandText = procname;
                if (this.cmd.Parameters.Count > 0)
                {
                    this.cmd.Parameters.Clear();
                }
                if (Oracleparmas != null && Oracleparmas.Length > 0)
                {
                    foreach (OracleParameter p in Oracleparmas)
                    {
                        this.cmd.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// 执行无返回DataSet的函数
        /// </summary>
        /// <param name="procname">存储过程名</param>
        /// <param name="parmas">参数数组</param>
        /// <returns></returns>
        public override string Execsql(string procname, object[] parmas)
        {
            lock (this)
            {
                try
                {
                    OracleParameter[] Oracleparmas = (OracleParameter[])parmas;
                    this.Open();
                    this.PublicClass(procname, Oracleparmas);
                    int var = this.cmd.ExecuteNonQuery();
                    this.cmd.Parameters.Clear();
                    this.Close();
                    return Convert.ToString(var);
                }
                catch (Exception ex)
                {
                    string e = ex.Message;
                    this.Close();
                    throw;
                }
            }
        }

        /// <summary>
        /// 执行有返回DataSet的函数
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="procname">存储过程名</param>
        /// <param name="parmas">参数数组</param>
        /// <returns>数据集</returns>
        public override DataSet ExecSqlReturnDataSet(string tablename, string procname, ProcParma[] parmas)
        {
            lock (this)
            {
                try
                {
                    OracleParameter[] Oracleparmas = new OracleParameter[1];//(OracleParameter[])parmas;
                    this.PublicClass(procname, Oracleparmas);
                    DataSet ds = new DataSet();
                    using (OracleDataAdapter da = new OracleDataAdapter())
                    {
                        da.SelectCommand = this.cmd;
                        da.Fill(ds, tablename);
                    }
                    return ds;

                }
                catch (Exception ex)
                {
                    string e = ex.Message;
                    throw;
                }
            }
        }

        /// <summary>
        /// 调用存储过程新
        /// </summary>
        /// <param name="pricName"></param>
        /// <param name="parmas"></param>
        /// <returns></returns>
        public override DataSet ExecSqlPricDataSet(string pricName, object[] parmas)
        {
            try
            {
                return new DataSet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns>数据集</returns>
        public override DataSet Select(string sql)
        {
            lock (this)
            {
                return null;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="tableName">表名</param>
        /// <returns>数据集</returns>
        public override DataSet Select(string sql, String tableName)
        {
            lock (this)
            {
                return new DataSet();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="tableName">表名</param>
        /// <param name="ds">数据集</param>
        /// <returns>true:成功;false:失败</returns>
        public override bool Select(string sql, String tableName, DataSet ds)
        {
            lock (this)
            {
                return true;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="sql">sql</param>
        /// <param name="tableName">表名</param>
        /// <returns>0: 正确  ; -1: 失败</returns>
        public override int Update(DataSet ds, String sql, String tableName)
        {
            lock (this)
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dt">数据库表关联的table</param>
        /// <param name="sql">基础sql</param>
        /// <returns>0: 正确  ; -1: 失败</returns>
        public override int Update(DataTable dt, String sql)
        {
            lock (this)
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns>0: 正确  ; -1: 失败</returns>
        public override int Update(string sql)
        {
            lock (this)
            {
                return 0;
            }
        }
        public override String ExecSqlPricDataSet1(string pricName, OdbcParameter[] parmas)
        {
            return null;
        }
    }
}
