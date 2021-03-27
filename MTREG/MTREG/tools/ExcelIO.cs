using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace MTREG.Util
{
    class ExcelIO
    {
        /// <summary>
        /// 导入EXCEL到DataTable
        /// </summary>
        /// <param name="fileName">Excel全路径文件名</param>
        /// <returns>导入成功的DataSet</returns>
        public DataTable ImportExcel(string fileName)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + "Extended Properties=Excel 8.0;";
            //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + "Extended Properties=Excel 12.0;";
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            DataTable table;
            try
            {
                OleDbConnection conn = new OleDbConnection(strConn);//连接excel
                conn.Open();//打开excel
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string tableName = schemaTable.Rows[0][2].ToString().Trim();//获取 Excel 的表名，默认值是sheet1
                strExcel = "select * from [" + tableName + "]";//当作数据库查询
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");//将结果放入table1中
                table = ds.Tables["table1"];
                conn.Close();
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("该Excel文件的工作表的名字不正确," + ex.Message);
                return null;
            }
        }
    }
}
