using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MTHIS.tools
{
    class DataUtils
    {
        /// <summary>
        /// 转为数据库用的格式的字符串
        /// </summary>
        /// <param name="fieldvalue"></param>
        /// <returns></returns>
        public static string toStrDbField(string fieldvalue)
        {
            if (fieldvalue == null || fieldvalue.Trim().Equals(""))
                return "null";
            fieldvalue = "'" + fieldvalue + "'";
            fieldvalue.Replace(';', '.');
            return fieldvalue;
        }

        /// <summary>
        /// 取得字符串中的数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string getNumByStr(string str)
        {
            string tmp = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (isNumer(str[i]))
                {
                    tmp = tmp + str[i];
                }
            }
            return tmp;
        }

        /// <summary>
        /// 判断字符是否数字或小数或负号
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool isNumer(char c)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(c.ToString());
            foreach (byte b in bytestr)
            {
                if ((b >= 48 && b <= 57) || b == 46 || b == 45)
                {
                    return true;
                }
            }
            return false;
        }

        #region bool
        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="fieldvalue"></param>
        /// <returns></returns>
        public static Boolean toBoolValue(string fieldvalue)
        {
            fieldvalue = fieldvalue.Trim().ToUpper();
            if ("TRUE".Equals(fieldvalue))
                return true;
            int tmp = 0;
            if (int.TryParse(fieldvalue, out tmp) && tmp != 0)
                return true;
            return false;
        }
        /// <summary>
        /// 数字转bool
        /// </summary>
        /// <param name="fieldvalue"></param>
        /// <returns></returns>
        public static Boolean toBoolValue(int fieldvalue)
        {
            if (fieldvalue == 0)
                return false;
            else
                return true;
        }
        #endregion

        /// <summary>
        /// 将byte数组转为字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
                returnStr = byteToHexStr(bytes, bytes.Length);
            return returnStr;
        }
        /// <summary>
        /// 将byte数组转为字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes, int num)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < num; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 项datatable添加一列复选框
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnName"></param>
        /// <param name="defultValue"></param>
        public static void DataTableAddSelectColumn(DataTable dt, string columnName, bool defultValue)
        {
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Boolean"); //该列的数据类型  
            dc.ColumnName = columnName;//该列得名称  
            dc.DefaultValue = defultValue;//该列得默认值 
            dt.Columns.Add(dc);
        }
        /// <summary>
        /// 向datatable添加一列复选框,state:false
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnName"></param>
        /// <param name="defultValue"></param>
        public static void DataTableAddSelectColumn(DataTable dt)
        {
            DataTableAddSelectColumn(dt, "state", false);
        }

        /// <summary>
        /// 取得datatable的列名集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<string> getDataTableColumnNames(DataTable dt)
        {
            List<string> columnNames = new List<string>();
            foreach (DataColumn dc in dt.Columns)
            {
                columnNames.Add(dc.ColumnName);
            }
            return columnNames;
        }
        private static char[] constant =   
       {   
        '0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
       };
        public static string getRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }
    }
}
