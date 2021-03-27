using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.tools;

namespace MTREG.netpay.bo
{
    class NetPayIniParam
    {
        
        public static String MerId
        {
            get { return IniUtils.IniReadValue(IniUtils.inidir + "\\netPay.ini", "netpay", "merId"); }
        }

        public static String MerchantId
        {
            get { return IniUtils.IniReadValue(IniUtils.inidir + "\\netPay.ini", "netpay", "merchantId");  }
        
        }

        public static String OrgCode
        {
            get { return IniUtils.IniReadValue(IniUtils.inidir + "\\netPay.ini", "netpay", "orgCode"); }
        
        }

        public static String Key
        {
            get { return IniUtils.IniReadValue(IniUtils.inidir + "\\netPay.ini", "netpay", "key"); }
        }

        public static String Basurl
        {
            get { return IniUtils.IniReadValue(IniUtils.inidir + "\\netPay.ini", "netpay", "basurl"); }
 
        }

    }
}
