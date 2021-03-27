using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MTREG.medinsur.gysyb.bll
{
    class Bjq
    {
        [DllImport("CKY32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int dsbdll(int ComPort, StringBuilder outputData);

        /// <summary>
        /// 调用报价器方法静态调用
        /// </summary>
        /// <param name="outputdata"></param>
        public static void bjqts(String out_Str)
        {
            StringBuilder outputdata = new StringBuilder(out_Str);
            try
            {
                dsbdll(1, outputdata);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
