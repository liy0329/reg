/*************************************************************************************
     * CLR版本：       2.0.50727.3649
     * 类 名 称：       DBPostgreSQL
     * 机器名称：       TIANCI
     * 命名空间：       MTLIS.db
     * 文 件 名：       DBPostgreSQL
     * 创建时间：       2013-7-16 11:05:22
     * 作    者：          xxx
     * 说   明：。。。。。
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;
using MTREG.common.bll;
using MTREG.common;
namespace MTHIS.db
{
    public class DBMySQLODBC :DBbase
    {
        private OdbcConnection conn = null;  //数据连接
        private OdbcCommand cmd = null;      //连接命令
        public DBMySQLODBC(string constring)
        {
            lock (this)
            {
                try
                {
                    this.conn = new OdbcConnection(constring);
                }
                catch (Exception ex)
                { 
                    
                }
            }
        }

        public DBMySQLODBC()
        {
            // TODO: Complete member initialization
        }

        public override bool ConnectionTest(string constring)
        {
             bool IsCanConnectioned = false;
            try {

                this.conn = new OdbcConnection(constring);
                //打开数据库
                this.Open();
                IsCanConnectioned = true;
            }
            catch 
            {
                //Can not Open DataBase
                //打开不成功 则连接不成功
                IsCanConnectioned = false;
            }
            finally
            {
                //Close DataBase
                //关闭数据库连接
                this.Close();
            }
            //mySqlConnection   is   a   SqlConnection   object 
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                //Connection   is   not   available  
                return IsCanConnectioned;
            }
            else
            {
                //Connection   is   available  
                return IsCanConnectioned;
            }

          
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
               
                OdbcParameter[] SQLparmas = (OdbcParameter[])parmas;
                this.cmd = new OdbcCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandType = CommandType.StoredProcedure;
                this.cmd.CommandText = "call "+procname+"(?,?,?,?,?);";
                if (this.cmd.Parameters.Count > 0)
                {
                    this.cmd.Parameters.Clear();
                }
                if (SQLparmas != null && SQLparmas.Length > 0)
                {
                    foreach (OdbcParameter p in SQLparmas)
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
                    OdbcParameter[] SQLparmas = (OdbcParameter[])parmas;
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
                    OdbcParameter[] SQLparmas = new OdbcParameter[parmas.Length];
                    for (int i = 0; i < parmas.Length; i++)
                    {
                        SQLparmas[i] = new OdbcParameter();
                        OdbcParameter sqlParma = SQLparmas[i];
                        if (parmas[i].Paramtype == 1)
                        {
                            sqlParma.OdbcType = OdbcType.Int;
                        }
                        else if (parmas[i].Paramtype == 2)
                        {
                            sqlParma.OdbcType = OdbcType.VarChar;
                        }
                        
                        sqlParma.ParameterName = parmas[i].ParamName;
                        sqlParma.Size = parmas[i].Lenth;
                        sqlParma.Value = parmas[i].ParamVal;
                    }
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
        /// <param name="pricName"></param>
        /// <param name="parmas"></param>
        /// <returns></returns>
        public override DataSet ExecSqlPricDataSet(string pricName, object[] parmas)
        {
            lock (this)
            {

                return new DataSet();
            }
        }

        /// <summary>
        /// 调用存储过程返回id
        /// </summary>
        /// <param name="pricName"></param>
        /// <param name="parmas"></param>
        /// <returns></returns>
        public override String ExecSqlPricDataSet1(string pricName, OdbcParameter[] parmas)
        {
            lock (this)
            {
                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = sqlconn;
                this.cmd = new OdbcCommand();
                this.cmd.Connection = this.conn;
                cmd.CommandText = pricName;
                cmd.CommandType = CommandType.StoredProcedure;
                parmas[1].Direction = ParameterDirection.ReturnValue;  // 设置为返回值  
                // 添加参数  
                cmd.Parameters.Add(parmas[0]);
                cmd.Parameters.Add(parmas[1]);
                this.conn.Open();
                cmd.ExecuteNonQuery();
                this.conn.Close();
                // 显示影响的行数，输出参数和返回值  
                return parmas[1].Value.ToString();
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
                    OdbcDataAdapter objOdbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    DataSet ds = new DataSet();
                    objOdbcDataAdapter.Fill(ds, tableName);
                    return ds;
                }
                catch (Exception e)
                {
                    SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + e.ToString());
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
                    OdbcDataAdapter objOdbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    objOdbcDataAdapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + ex.ToString());
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
                    OdbcDataAdapter objOdbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    objOdbcDataAdapter.Fill(ds, tableName);
                    return true;
                }
                catch (Exception ex)
                {
                    SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + ex.ToString());
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
            lock (this)
            {
                string strtmp = "";
                try
                {
                    OdbcDataAdapter objOdbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    OdbcCommandBuilder objOdbcCommand = new OdbcCommandBuilder(objOdbcDataAdapter);
                    objOdbcDataAdapter.Update(dt);
                }
                catch (Exception ex)
                {
                   strtmp = ex.ToString();
                   SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + ex.ToString());
                    return -1;
                }

                return 0;
            }
        }
        #region
        ///// <summary>
        ///// 更新
        ///// </summary>
        ///// <param name="sql">sql</param>
        ///// <returns>0: 正确  ; -1: 失败</returns>
        //public override int Update(string sql)
        //{
        //   lock (this)
        //    {
        //        int r = 0;
        //        OdbcTransaction odbcTransaction = null;
        //        try
        //        {
        //            this.conn.Open();
        //            //开启事务
        //            odbcTransaction = conn.BeginTransaction();
        //            OdbcCommand objOdbcCommand = new OdbcCommand();
        //            objOdbcCommand.Connection = this.conn;
        //            //连接事务
        //            objOdbcCommand.Transaction = odbcTransaction;
        //            objOdbcCommand.CommandText = sql;
        //            objOdbcCommand.ExecuteNonQuery();
        //            //提交
        //            odbcTransaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            r = -1;
        //            SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + e.ToString());
        //            try
        //            {
        //                // 回滚
        //                odbcTransaction.Rollback();
        //            }
        //            catch
        //            {
        //                // Do nothing here; transaction is not active.
        //            }
        //        }
        //        finally
        //        {
        //            this.conn.Close();
        //        }

        //        return r;
        //    }
        //}
#endregion
        /// <summary>
        /// 更新(循环)
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns>0: 正确  ; -1: 失败</returns>
        public override int Update(string sql)
        {
            lock (this)
            {
                int r = 0;
                int ljcs = 0;//连接次数
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    OdbcTransaction odbcTransaction = null;
                    try
                    {
                        this.conn.Open();
                        //开启事务
                        odbcTransaction = conn.BeginTransaction();
                        OdbcCommand objOdbcCommand = new OdbcCommand();
                        objOdbcCommand.Connection = this.conn;
                        //连接事务
                        objOdbcCommand.Transaction = odbcTransaction;
                        objOdbcCommand.CommandText = sql;
                        objOdbcCommand.ExecuteNonQuery();
                        //提交
                        odbcTransaction.Commit();

                    }
                    catch (Exception e)
                    {
                        flag = true;
                        r = -1;
                        SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + e.ToString());
                        try
                        {
                            // 回滚
                            odbcTransaction.Rollback();
                        }
                        catch
                        {
                            // Do nothing here; transaction is not active.
                        }
                    }
                    finally
                    {
                        this.conn.Close();
                    }

                    if (++ljcs >= 5)
                    {
                        flag = false;
                    }
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
                    OdbcDataAdapter objOdbcDataAdapter = new OdbcDataAdapter(sql, this.conn);
                    OdbcCommandBuilder objOdbcCommand = new OdbcCommandBuilder(objOdbcDataAdapter);
                    objOdbcDataAdapter.Update(ds, tableName);
                    objOdbcDataAdapter.UpdateCommand = objOdbcCommand.GetUpdateCommand();
                    String sss = objOdbcDataAdapter.UpdateCommand.ToString();
                    ds.AcceptChanges();
                }
                catch (Exception e)
                {
                    SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + e.ToString());
                    return -1;
                }

                return 0;
            }
        }
    }
}
