using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTLIS.common
{
    public class SysRuning
    {
        string chkissend;//true:单击“审核”自动发布
        string send_check;//true:单击“发布”自动审核
        string print_check ;//true:单击“打印”自动审核
        string send_check_s ;//true:单击“批量发布”自动审核
        string print_check_s ;//true:单击“批量打印”自动审核

        public string Chkissend
        {
            get { return chkissend; }
            set { chkissend = value; }
        }
        public string Send_Check
        {
            get { return send_check; }
            set { send_check = value; }
        }
        public string Print_Check
        {
            get { return print_check; }
            set { print_check = value; }
        }
        public string Send_Check_s
        {
            get { return send_check_s; }
            set { send_check_s = value; }
        }
        public string Print_Check_s
        {
            get { return print_check_s; }
            set { print_check_s = value; }
        }
        

    }
}
