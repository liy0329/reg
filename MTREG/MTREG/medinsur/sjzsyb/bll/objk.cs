using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MTREG.medinsur.sjzsyb.bean;
using k = System.Object;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace MTREG.medinsur.sjzsyb.bll
{
    public class objk<k>
    {
        /// <summary>
        /// 对SJZYB_IN<K>进行序列化
        /// </summary>
        /// <param name="sjzyb_in"></param>
        /// <param name="Tap"></param>
        /// <returns></returns>
        public static string getXML(SJZYB_IN<k> sjzyb_in, string Tap)
        {
            
            //获得 T 模型类型
            Type T_type1 = typeof(SJZYB_IN<k>);
            //获得 T 模型类型公共属性
            PropertyInfo[] Proper1 = T_type1.GetProperties();

            string xml_body = "";

            xml_body = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "";
            xml_body += "" + "<HOSDATA>" + "";
            xml_body += "" + "<REQUESTDATA>" + "";
            foreach (PropertyInfo P in Proper1)
            {

                xml_body += "" + "<" + P.Name + ">" + Convert.ToString(P.GetValue(sjzyb_in, null)) + "</" + P.Name + ">" + "";
                
            }

            if (sjzyb_in.INPUT != null)
            {
                xml_body += "" + "<INPUT>" + "";
                foreach (k info in sjzyb_in.INPUT)
                {
                    Type T_type = typeof(k);
                    PropertyInfo[] proper = T_type.GetProperties();
                    if (Tap.Equals(""))
                    {
                        foreach (PropertyInfo P1 in proper)
                        {
                            xml_body += "" + "<" + P1.Name + ">" + Convert.ToString(P1.GetValue(info, null)) + "</" + P1.Name + ">" + "";
                        }
                    }
                    else
                    {
                        xml_body += "" + "<" + Tap + ">" + "";
                        foreach (PropertyInfo P1 in proper)
                        {
                            xml_body += "" + "<" + P1.Name + ">" + Convert.ToString(P1.GetValue(info, null)) + "</" + P1.Name + ">" + "";
                        }
                        xml_body += "" + "</" + Tap + ">" + "";
                    }
                   
                }
                xml_body += "" + "</INPUT>" + "";

            }
            else
            {
                xml_body += "" + "<INPUT>";
                xml_body += "</INPUT>" + "";
            }
            if (sjzyb_in.KC21XML != null)
            {
                xml_body += "" + "<KC21XML>" + "";
                Type T_type = typeof(KC21);
                PropertyInfo[] proper = T_type.GetProperties();

                foreach (PropertyInfo P1 in proper)
                {
                    xml_body += "" + "<" + P1.Name + ">" + Convert.ToString(P1.GetValue(sjzyb_in.KC21XML, null)) + "</" + P1.Name + ">" + "";
                }

                xml_body += "" + "</KC21XML>" + "";

            }
            else
            {
                xml_body += "" + "<KC21XML>";
                xml_body +=  "</KC21XML>" + "";
            }

            if (sjzyb_in.KC22XML != null)
            {
                xml_body += "" + "<KC22XML>" + "";
                foreach (KC22 info in sjzyb_in.KC22XML)
                {
                    Type T_type = typeof(KC22);
                    PropertyInfo[] proper = T_type.GetProperties();
                    xml_body += "" + "<KC22ROW>" + "";
                    foreach (PropertyInfo P1 in proper)
                    {

                        xml_body += "" + "<" + P1.Name + ">" + Convert.ToString(P1.GetValue(info, null)) + "</" + P1.Name + ">" + "";
                    }
                    xml_body += "" + "</KC22ROW>" + "";
                }
                xml_body += "" + "</KC22XML>" + "";

            }
            else
            {
                xml_body += "" + "<KC22XML>";
                xml_body += "</KC22XML>" + "";
            }

            xml_body += "" + "</REQUESTDATA>" + "";
            xml_body += "" + "</HOSDATA>" + "";
            
            
            return xml_body;
        }
        
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(object obj)
        {
            //获得 T 模型类型
            Type T_type1 = obj.GetType();
            //获得 T 模型类型公共属性
            PropertyInfo[] Proper1 = T_type1.GetProperties();

            string xml_body = "";

            
            foreach (PropertyInfo P in Proper1)
            {

                xml_body += "" + "<" + P.Name + ">" + Convert.ToString(P.GetValue(obj, null)) + "</" + P.Name + ">" + "";

            }

            return xml_body;
        }
        /// <summary>
        /// sjz_yb_jsxx的sql
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public static string getsqls(object obj)
        {
            //获得 T 模型类型
            Type T_type1 = obj.GetType();
            //获得 T 模型类型公共属性
            PropertyInfo[] Proper1 = T_type1.GetProperties();

            string xml_body = "";
            string field = "INSERT INTO sjz_yb_jsxx(";
            string value = ")VALUES(";

            foreach (PropertyInfo P1 in Proper1)
            {
                field += P1.Name + ",";
                value += "'" + Convert.ToString(P1.GetValue(obj, null)) + "',";
            }

            field = field.Substring(0, field.Length - 1);
            value = value.Substring(0, value.Length - 1) + ");";
            return field + value;
        }
        /// <summary>
        /// 用DataTable填充实体类
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<k> FillModel(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<k> modelList = new List<k>();
            foreach (DataRow dr in dt.Rows)
            {
                k model = (k)Activator.CreateInstance(typeof(k));  
                //k model = new k();
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    PropertyInfo propertyInfo = model.GetType().GetProperty(dr.Table.Columns[i].ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo != null && dr[i] != DBNull.Value)
                    {
                        string value = dr[i] == null ? "" : dr[i].ToString();
                        //string typestr = dr[i].GetType().Name;
                        //if(typestr.Equals("DateTime"))
                        //value = dr[i].ToString();

                        Type type = propertyInfo.PropertyType;
                        if (type == typeof(Int32))
                        {
                            var convertType = Convert.ToInt32(value);
                            propertyInfo.SetValue(model, convertType, null);
                        }
                        else if (type == typeof(decimal))
                        {
                            propertyInfo.SetValue(model, Convert.ToDecimal(value), null);
                        }
                        else if (type == typeof(DateTime))
                        {
                            propertyInfo.SetValue(model, Convert.ToDateTime(value), null);
                        }
                        else if (type == typeof(string))
                        {
                            propertyInfo.SetValue(model, value, null);
                        }

                    }

                }

                modelList.Add(model);
            }
            return modelList;

        }

        /// <summary>
        /// sjz_yb_jsxx的sql
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public static string getsql(js_sql in1)
        {
            string field = "INSERT INTO sjz_yb_jsxx(";
            string value = ")VALUES(";
            Type T_type = typeof(js_sql);
            PropertyInfo[] proper = T_type.GetProperties();
            foreach (PropertyInfo P1 in proper)
            {
                field += P1.Name + ",";
                value += "'" + Convert.ToString(P1.GetValue(in1, null)) + "',";
            }
            if (in1.js != null)
            {
                Type T_type1 = typeof(zyjs_OUT);
                PropertyInfo[] proper1 = T_type1.GetProperties();
                foreach (PropertyInfo P1 in proper1)
                {
                    if (!(P1.Name.Equals("RETURNNUM") || P1.Name.Equals("ERRORMSG") || P1.Name.Equals("REFMSGID")))
                    {
                        field += P1.Name + ",";
                        value += "'" + Convert.ToString(P1.GetValue(in1.js, null)) + "',";
                    }
                        
                }
            }
            field = field.Substring(0, field.Length - 1);
            value = value.Substring(0, value.Length - 1) + ");";
            return field + value;
        }
        /// <summary>
        /// XML转化DataSet
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        
    }
}