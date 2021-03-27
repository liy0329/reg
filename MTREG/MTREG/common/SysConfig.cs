using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.tools;

namespace MTHIS.common
{
    class SysConfig
    {
        private SysConfig() { }

        public bool chkissend;
        public bool send_check;
        public bool print_check;
        public bool send_check_s;
        public bool print_check_s;

        public string bloodRoom;
        public bool printBarcode;

        public bool autoUpResutStat; // 自动更新结果列表

        private string checkImgDir;
        public string CheckImgDir
        {
            get { return converPath(checkImgDir); }
            set { checkImgDir = value; }
        }
        private string esignImgDir;
        public string EsignImgDir
        {
            get { return converPath(esignImgDir); }
            set { esignImgDir = value; }
        }

        public static SysConfig getSysConfig()
        {
            SysConfig sysConfig = new SysConfig();

            sysConfig.chkissend = DataUtils.toBoolValue(IniUtils.IniReadValue(IniUtils.syspath, "sysruning", "chkissend").Trim());
            sysConfig.send_check = DataUtils.toBoolValue(IniUtils.IniReadValue(IniUtils.syspath, "sysruning", "send_check").Trim());
            sysConfig.print_check = DataUtils.toBoolValue(IniUtils.IniReadValue(IniUtils.syspath, "sysruning", "print_check").Trim());
            sysConfig.send_check_s = DataUtils.toBoolValue(IniUtils.IniReadValue(IniUtils.syspath, "sysruning", "send_check_s").Trim());
            sysConfig.print_check_s = DataUtils.toBoolValue(IniUtils.IniReadValue(IniUtils.syspath, "sysruning", "print_check_s").Trim());

            sysConfig.bloodRoom = IniUtils.IniReadValue(IniUtils.syspath, "SYSTEM", "bloodRoom").Trim();
            sysConfig.printBarcode = DataUtils.toBoolValue(IniUtils.IniReadValue(IniUtils.syspath, "SYSTEM", "printBarcode").Trim());
            sysConfig.autoUpResutStat = DataUtils.toBoolValue(IniUtils.IniReadValue(IniUtils.syspath, "SYSTEM", "autoUpResutStat").Trim());

            sysConfig.checkImgDir = IniUtils.IniReadValue(IniUtils.syspath, "IMAGE", "checkImgDir").Trim().Trim('\\');
            sysConfig.esignImgDir = IniUtils.IniReadValue(IniUtils.syspath, "IMAGE", "esignImgDir").Trim().Trim('\\');

            return sysConfig;



        }

        private static string converPath(string dirPath)
        {
            string strTag = "[startpath]";
            if (dirPath.Contains(strTag))
            {
                int start = dirPath.IndexOf(strTag) + strTag.Length;
                dirPath = dirPath.Substring(start, dirPath.Length - start);
                dirPath = System.Windows.Forms.Application.StartupPath + dirPath;
            }
            return dirPath;
        }

        public void writeSysConfig()
        {
            IniUtils.IniWriteValue(IniUtils.syspath, "sysruning", "chkissend", chkissend.ToString());
            IniUtils.IniWriteValue(IniUtils.syspath, "sysruning", "send_check", send_check.ToString());
            IniUtils.IniWriteValue(IniUtils.syspath, "sysruning", "print_check", print_check.ToString());
            IniUtils.IniWriteValue(IniUtils.syspath, "sysruning", "send_check_s", send_check_s.ToString());
            IniUtils.IniWriteValue(IniUtils.syspath, "sysruning", "print_check_s", print_check_s.ToString());

            IniUtils.IniWriteValue(IniUtils.syspath, "SYSTEM", "bloodRoom", bloodRoom.ToString());
            IniUtils.IniWriteValue(IniUtils.syspath, "SYSTEM", "printBarcode", printBarcode.ToString());
            IniUtils.IniWriteValue(IniUtils.syspath, "SYSTEM", "autoUpResutStat", autoUpResutStat.ToString());

            IniUtils.IniWriteValue(IniUtils.syspath, "IMAGE", "checkImgDir", checkImgDir);
            IniUtils.IniWriteValue(IniUtils.syspath, "IMAGE", "esignImgDir", esignImgDir);
        }
        public static string readHttpServerPort()
        {
          string port =  IniUtils.IniReadValue(IniUtils.syspath, "httpserver", "port").Trim();
          return port;
        }
    }
}
