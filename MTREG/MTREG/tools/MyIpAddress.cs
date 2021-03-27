using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace MTREG.tools
{
    class MyIpAddress
    {
        public static string ip()
        {
            IPAddress ipAddr = Dns.Resolve(Dns.GetHostName()).AddressList[0];//获得当前IP地址
            string ip = ipAddr.ToString();
            return ip;
        }
    }
}
