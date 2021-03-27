using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.gsbx.bll
{
    class GSBX_IN
    {
        private string log_iid;//
        public string Log_iid
        {
            get { return log_iid; }
            set { log_iid = value; }
        }

        private string log_name;//
        public string Log_name
        {
            get { return log_name; }
            set { log_name = value; }
        }
        public string head()
        {
            string head = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            return head;
        }
        private string ywName;//
        public string YwName
        {
            get { return ywName; }
            set { ywName = value; }
        }
        private string ywData;//
        public string YwData
        {
            get { return ywData; }
            set { ywData = value; }
        }
    }
}
