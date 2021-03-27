/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       DBSQLServer
     * 机器名称：       AARON-PC
     * 命名空间：       MTLIS.db
     * 文 件 名：       DBSQLServer
     * 创建时间：       2013/5/16 14:43:37
     * 作    者：       田非
     * 说   明：        QLSERVER数据库连接
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
using System.Data.OleDb;

namespace MTHIS.db
{
    //数据连接的工厂模式SQLSERVER连接类
    internal class DBAccess : DBbase
    {
        private OdbcConnection conn = null;
        private OdbcCommand cmd = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="constring">连接字符串</param>
        public DBAccess(string constring)
        {
            //OleDbConnection Connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;DataSource=D:\\vs\\Interface.mdb;Persist Security Info=True;"); 
            this.conn = new OdbcConnection(constring);
        }
       #region MTNHYB


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
                SqlParameter[] SQLparmas = (SqlParameter[])parmas;
                this.cmd = new OdbcCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandType = CommandType.StoredProcedure;
                this.cmd.CommandText = procname;
                if (this.cmd.Parameters.Count > 0)
                {
                    this.cmd.Parameters.Clear();
                }
                if (SQLparmas != null && SQLparmas.Length > 0)
                {
                    foreach (SqlParameter p in SQLparmas)
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
                    SqlParameter[] SQLparmas = (SqlParameter[])parmas;
                    this.Open();
                    this.PublicClass(procname, SQLparmas);
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
                    SqlParameter[] SQLparmas = new SqlParameter[1]; // (SqlParameter[])parmas;
                    this.PublicClass(procname, SQLparmas);
                    DataSet ds = new DataSet();
                    using (OdbcDataAdapter da = new OdbcDataAdapter())
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
        /// <param name="pricName">存储过程名称</param>
        /// <param name="parmas">参数</param>
        /// <returns>消息集合(DataSet)</returns>
        public override DataSet ExecSqlPricDataSet(string pricName, object[] parmas)
        {
            lock (this)
            {
                try
                {
                    cmd = new OdbcCommand();
                    cmd.Parameters.Add("@in_id", parmas[0].ToString());
                    cmd.Parameters.Add("@in_devId", parmas[1].ToString());
                    cmd.Parameters.Add("@in_opdate", parmas[2].ToString());
                    cmd.Parameters.Add("@in_appsn", parmas[3].ToString());
                    cmd.Parameters.Add("@in_userId", parmas[4].ToString());

                    cmd.Connection = conn;
                    cmd.CommandText = pricName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    OdbcDataAdapter da = new OdbcDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return new DataSet();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public override DataSet Select(string sql, String tableName)
        {
            lock (this)
            {
                try
                {
                    OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    DataSet ds = new DataSet();
                    odbcDataAdapter.Fill(ds, tableName);
                    return ds;
                }
                catch (Exception)
                {
                    throw;
                }
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
                DataSet ds = new DataSet();
                try
                {
                    this.conn.Open();
                    OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    odbcDataAdapter.Fill(ds);
                }
                catch (Exception e)
                {

                }
                finally
                {
                    this.conn.Close();
                }
                return ds;
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
                try
                {
                    OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    odbcDataAdapter.Fill(ds, tableName);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
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
			//lock (this)
			//{
                try
                {
                    OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    OdbcCommandBuilder odbcCommandBuilder = new OdbcCommandBuilder(odbcDataAdapter);
                    odbcDataAdapter.Update(dt);
                }
                catch (Exception e)
                {
                    return -1;
                }

                return 0;
           // }
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
                int r = 0;
                try
                {
                    this.conn.Open();
                    OdbcCommand objOdbcCommand = new OdbcCommand();
                    objOdbcCommand.Connection = this.conn;
                    objOdbcCommand.CommandText = sql;
                    objOdbcCommand.Transaction = conn.BeginTransaction();
                    string[] SQLStringList = sql.Split(';');
                    for (int n = 0; n < SQLStringList.Length; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {

                            objOdbcCommand.CommandText = strsql;

                            objOdbcCommand.ExecuteNonQuery();

                        }

                    }

                    objOdbcCommand.Transaction.Commit();  //提交事务
                }
                catch (Exception e)
                {

                    r = -1;
                }
                finally
                {
                    this.conn.Close();
                }

                return r;
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
                try
                {
                    OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    OdbcCommandBuilder odbcCommandBuilder = new OdbcCommandBuilder(odbcDataAdapter);
                    odbcDataAdapter.Update(ds, tableName);
                    odbcDataAdapter.UpdateCommand = odbcCommandBuilder.GetUpdateCommand();
                    String sss = odbcDataAdapter.UpdateCommand.ToString();
                    ds.AcceptChanges();
                }
                catch (Exception)
                {
                    return -1;
                }

                return 0;
            }
        }
        public override String ExecSqlPricDataSet1(string pricName, OdbcParameter[] parmas)
        {
            return null;
        }
        #endregion
    }
}
