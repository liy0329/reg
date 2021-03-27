using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.common;
using System.Data.Odbc;
using System.Data;

namespace MTREG.medinsur.hdyb.bll
{
    class JKDB
    {
        static string sql = ((ProgramGlobal.Zjk == null || ProgramGlobal.Zjk == "") ? ("Driver={SQL Server};Server=127.0.0.1;Port=1433;Database=MT_YB_JK;Uid=HIS_DLL;Pwd=HIS_DLL;") : (ProgramGlobal.Zjk));

        private OdbcConnection objSqlConnection = new OdbcConnection(sql);

        public DataSet Select(string sql)
        {

            objSqlConnection.Open();
            DataSet ds = new DataSet();
            OdbcDataAdapter objSqlDataAdapter = new OdbcDataAdapter(sql, objSqlConnection);
            objSqlDataAdapter.Fill(ds);
            objSqlConnection.Close();
            return ds;
        }

        public int Update(string sql)
        {
            int r = 0;
            try
            {
                objSqlConnection.Open();
                OdbcCommand objSqlCommand = new OdbcCommand();
                objSqlCommand.Connection = objSqlConnection;
                objSqlCommand.CommandText = sql;

                r = objSqlCommand.ExecuteNonQuery();
                objSqlConnection.Close();
                return r;
            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    r = -1;
                }
                objSqlConnection.Close();
                return -1;
            }

        }
        public int Update2(string sql)
        {
            int r = 0;
            try
            {
                objSqlConnection.Open();
                OdbcCommand objSqlCommand = new OdbcCommand();
                objSqlCommand.Connection = objSqlConnection;
                objSqlCommand.CommandText = sql;

                r = objSqlCommand.ExecuteNonQuery();
                objSqlConnection.Close();
                return r;
            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    r = -1;
                }
                objSqlConnection.Close();
                return -1;
            }
        }
    }
}
