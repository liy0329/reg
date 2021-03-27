using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MTHIS.common
{
    class DataTool
    {
        public static DateTime stringToDate(string dateString, string dateFormat)
        {

            DateTime val = DateTime.ParseExact(dateString, dateFormat, System.Globalization.CultureInfo.CurrentCulture);
            return val;
        }


        public static string dateToString(DateTime dat, string dateFormat)
        {

            string val = dat.ToString(dateFormat);
            return val;
        }
        /// <summary>
        /// 检查字符串是否是空或者是不符合double类型的强转的都弄成“0”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string checkDouble(string str)
        {        
            Regex obj = new Regex(@"^(\d+(\.\d+)?)?$");

            if (!obj.IsMatch(str)||string.IsNullOrEmpty(str))
            {
                return "0";
            } 
          return str;
        }
        
        //转换为int
        public static int toInt(bool val)
        {
            if (val)
                return 1;
            else
                return 0;
        }
        
        public static string addBoolBraces(bool val)
        {
            string ret = ""+toInt(val).ToString()+"";
            return ret;

        }
        /// <summary>
        /// toBool
        /// </summary>
        /// <param name="val">整形 </param>
        /// <returns></returns>
        public static bool toBool(int val)
        {
            if (val == 0)
                return false;
            else
                return true;
        }
        public static string BoolStrValue(string val)
        {
            string retvalue = "0";
            if (val.Trim().ToUpper().Equals("TRUE"))
                retvalue = "1";
            return retvalue;
        }
        public static string addFieldBraces(string fieldvalue)
        {
            if (fieldvalue == null || fieldvalue.Trim().Equals(""))
                return "null";
            fieldvalue =  fieldvalue.Replace(';', '.');
            fieldvalue =  fieldvalue.Replace("'", "\'");
            fieldvalue = fieldvalue.Replace("\\", "\\\\");

            if (fieldvalue.IndexOf("'") != -1) //判断字符串是否含有单引号
            {
                fieldvalue = "\"" + fieldvalue + "\"";
            }
            else
            {
                fieldvalue = "'" + fieldvalue + "'";
            }
            
            
            return fieldvalue;
        }
        public static string addIntBraces(string fieldvalue)
        {
            if (fieldvalue == null || fieldvalue.Trim().Equals(""))
                return "null";
            fieldvalue = "" + fieldvalue + "";
            fieldvalue.Replace(';', '.');
       
            return fieldvalue;

        }

        public static Sickages DateDiff(DateTime dateTime1, DateTime dateTime2)
        {
            Sickages sickage = new Sickages();

            if (dateTime2.Year == 1900)
            {
                sickage.Ageunit = "岁";
                return sickage;
            }

            sickage.Years = dateTime1.Year - dateTime2.Year;
            if(sickage.Years <= 0)
            {
                TimeSpan tp = dateTime1 - dateTime2;  // 相隔天数
                sickage.Days = tp.Days;
                if (sickage.Days >= 61)
                {
                    sickage.Months = sickage.Days / 30;
                    sickage.Cur_values = sickage.Months;
                    sickage.Ageunit = "月";
                    
                   

                }
                else
                {
                    sickage.Cur_values = sickage.Days;
                    sickage.Ageunit = "天";
                }
            }
            else
            {
               sickage.Cur_values = sickage.Years;
               sickage.Ageunit = "岁";
            }
            return sickage;
            
        }
        public static int DateCompare(string strdate1, string strdate2)
        {
            int ret = 0;

            try
            {
                DateTime dateTime1 = DateTime.Parse(strdate1);
                DateTime dateTime2 = DateTime.Parse(strdate2);
                return DateTime.Compare(dateTime1, dateTime2);
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public static string FormatData(String val, String decimals)
        {
            try
            {
                double curval = Convert.ToDouble(val);
                if (decimals.Equals("1"))
                {
                    return curval.ToString("0.0");
                }
                else if (decimals.Equals("2"))
                {
                    return curval.ToString("0.00");
                }
                else if (decimals.Equals("0"))
                {
                    return Convert.ToInt32(curval).ToString();
                }
                else if (decimals.Equals("3"))
                {
                    return curval.ToString("0.000");
                }
                else if (decimals.Equals("4"))
                {
                    return curval.ToString("0.0000");
                }
            }
            catch (Exception)
            {
                return val;
            }
            return val;
        }


        public static string FormatData(double val1, String decimals)
        {
            string val = val1.ToString();
            try
            {
                double curval = val1;
                if (decimals.Equals("1"))
                {
                    return curval.ToString("0.0");
                }
                else if (decimals.Equals("2"))
                {
                    return curval.ToString("0.00");
                }
                else if (decimals.Equals("0"))
                {
                    return Convert.ToInt32(curval).ToString();
                }
                else if (decimals.Equals("3"))
                {
                    return curval.ToString("0.000");
                }
                else if (decimals.Equals("4"))
                {
                    return curval.ToString("0.0000");
                }
            }
            catch (Exception)
            {
                return "";
            }
            return val;
        }
        /// <summary>
        /// 根据传过来的字符串返回double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double Getdouble(String str)
        {
            double ret = 0;
            try
            {
                ret = Convert.ToDouble(str.Trim());

            }
            catch
            {
                ret = 0;
            }
            return Math.Round(ret, 3);
        }

        public static string ChangeNull(string str) 
        {
            if(string.IsNullOrEmpty(str)||str == "")
            return "0";
            return str;
        }
        public static bool IsNumberDouble(string val)
        {
            try
            {
                double i = Convert.ToDouble(val);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsDoubleNum(string val)
        {
            try
            {
                if (val != null && val != "")
                {
                    double i = Convert.ToDouble(val);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool IsNumberInt(string val)
        {
            try
            {
                if (val != null && val != "")
                {
                    int i = Convert.ToInt32(val);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public static bool isNumeric(string str)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(str);
            foreach (byte c in bytestr)
            {
                if ((c >= 48 && c <= 57) || c==46 || c==45)
                {
                    return true;
                } 
            }
            return false;
        
        }

        public static string getNumericByString(string str)
        {
            string tmp="";
            for (int i = 0; i < str.Length; i++)
            {
                if (isNumeric(str[i].ToString()))
                {
                    tmp = tmp + str[i].ToString();
                }
            }
            return tmp;
        } 


        /// <summary>
        /// 字符转整数
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int stringToInt(string val)
        {
            if (string.IsNullOrEmpty(val))
                return 0;
            try
            {
                    int i = Convert.ToInt32(val);
                    return i;
            }
            catch
            {
               
            }
            return 0;
        }
        /// <summary>
        /// 字符转实数
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double stringToDouble(string val)
        {
            if (string.IsNullOrEmpty(val))
                return 0;
            try
            {
                double i = Convert.ToDouble(val);
                return i;
            }
            catch
            {

            }
            return 0;
        }

        public static float stringToFloat(string val)
        {
            if (string.IsNullOrEmpty(val))
                return 0;
            try
            {
                float i = float.Parse(val);
                return i;
            }
            catch
            { }
            return 0;
        }

        public static string GenUniqueText()
        {
            string readyStr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] rtn = new char[8];
            Guid gid = Guid.NewGuid();
            var ba = gid.ToByteArray();
            for (var i = 0; i < 8; i++)
            {
                rtn[i] = readyStr[((ba[i] + ba[8 + i]) % 35)];
            }
            return "" + rtn[0] + rtn[1] + rtn[2] + rtn[3] + rtn[4] + rtn[5] + rtn[6] + rtn[7];
        }
        
        
    }
    public static class LINQTool
    {
    //LINQ to DataTable
        public static DataTable CopyToDataTable0<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source,null,null);
        }
    };
    //LINQ to DataTable
    public class ObjectShredder<T>
    {
        private FieldInfo[] _fi;
        private PropertyInfo[] _pi;
        private Dictionary<string,int> _ordinalMap;
        private Type _type;
        public ObjectShredder()
        { 
            _type = typeof(T);
            _fi = _type.GetFields();
            _pi = _type.GetProperties();
            _ordinalMap = new Dictionary<string, int>();
        }
        
        public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            if (typeof(T).IsPrimitive)
            {
                return ShredPrimitive(source, table, options);
            }


            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            // now see if need to extend datatable base on the type T + build ordinal map
            table = ExtendTable(table, typeof(T));

            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (options != null)
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), true);
                    }
                }
            }
            table.EndLoadData();
            return table;
        }
        public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            if (!table.Columns.Contains("Value"))
            {
                table.Columns.Add("Value", typeof(T));
            }

            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                Object[] values = new object[table.Columns.Count];
                while (e.MoveNext())
                {
                    values[table.Columns["Value"].Ordinal] = e.Current;

                    if (options != null)
                    {
                        table.LoadDataRow(values, (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(values, true);
                    }
                }
            }
            table.EndLoadData();
            return table;
        }
        public DataTable ExtendTable(DataTable table, Type type)
        {
            // value is type derived from T, may need to extend table.
            foreach (FieldInfo f in type.GetFields())
            {
                if (!_ordinalMap.ContainsKey(f.Name))
                {
                    DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
                        : table.Columns.Add(f.Name, f.FieldType);
                    _ordinalMap.Add(f.Name, dc.Ordinal);
                }
            }
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (!_ordinalMap.ContainsKey(p.Name))
                {
                    DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                        : table.Columns.Add(p.Name, p.PropertyType);
                    _ordinalMap.Add(p.Name, dc.Ordinal);
                }
            }
            return table;
        }
        public object[] ShredObject(DataTable table, T instance)
        {

            FieldInfo[] fi = _fi;
            PropertyInfo[] pi = _pi;

            if (instance.GetType() != typeof(T))
            {
                ExtendTable(table, instance.GetType());
                fi = instance.GetType().GetFields();
                pi = instance.GetType().GetProperties();
            }

            Object[] values = new object[table.Columns.Count];
            foreach (FieldInfo f in fi)
            {
                values[_ordinalMap[f.Name]] = f.GetValue(instance);
            }

            foreach (PropertyInfo p in pi)
            {
                values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
            }
            return values;
        }

    }
    public class Tools<T> where T : new()
    {
        /// <summary>
        /// 利用反射和泛型
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertToList(DataTable dt)
        {
            //定义集合
            List<T> ts = new List<T>();
            //获得此模型的类型
            Type type = typeof(T);
            //定义一个临时变量
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                //获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量
                    //检查DataTable是否包含此列（列名==对象的属性名）
                    if (dt.Columns.Contains(tempName))
                    { 
                        //判断此属性是否有Setter
                        if(!pi.CanWrite) continue;//该属性不可写，直接跳出
                        //取值
                        object tmpvalue = dr[tempName];
                        string value = tmpvalue.ToString();
                        //如果非空，则赋给对象的属性
                        if (tmpvalue != DBNull.Value)
                            pi.SetValue(t,value,null);
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }
            return ts;
        }

      
 
     }

}
