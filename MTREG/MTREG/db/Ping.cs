using System;
using System.Collections.Generic;
using System.Text;

namespace MTLIS.db
{
    class ping_ip
    {
        /// <summary>
        ///  判断是否ping通
        /// </summary>
        /// <param name="strCommandline"></param>
        /// <returns></returns>
        public  static bool ping(string strCommandline)
        {
            System.Net.NetworkInformation.Ping p=new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "test data!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;
            System.Net.NetworkInformation.PingReply reply = p.Send(strCommandline, timeout, buffer, options);
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                return true;
            else
                return false;
        }
    }
}
