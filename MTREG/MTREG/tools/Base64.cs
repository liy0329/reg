using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTHIS.tools
{
    class Base64
    {
        /// <summary>
        /// 将字符串通过默认编码进行Base64转码
        /// </summary>
        /// <param name="code">要转码的字符</param>
        /// <returns></returns> 
        public static string encodebase64(string code)
        {
            if (code == null) return "";
            string encode = "";
            byte[] bytes = Encoding.UTF8.GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }
         public static string decodebase64(string code)
        {
            if (code == null) return "";
            string decode = "";
            try
            {
                if (code != "null")
                {
                    byte[] bytes = Convert.FromBase64String(code.Replace("服务器无法处理请求。 ---> ", "").Replace("\\n", ""));
                    decode = Encoding.UTF8.GetString(bytes);
                }
                else
                {
                    decode = "0";
                }
            }
            catch(Exception e)
            {
                decode = "1000-01-01 00:00:00";
            }
            return decode;
        }
         public static string decodebase644(string code)
         {
             if (code == null) return "";
             string decode = "";
             try
             {
                 if (code != "null")
                 {
                     byte[] bytes = Convert.FromBase64String(code.Replace("服务器无法处理请求。 ---> ", "").Replace("\\n", ""));
                     decode = Encoding.GetEncoding(0).GetString(bytes);
                 }
                 else
                 {
                     decode = "0";
                 }
             }
             catch (Exception e)
             {
                 decode = "0";
             }
             return decode;
         }
    }
}
