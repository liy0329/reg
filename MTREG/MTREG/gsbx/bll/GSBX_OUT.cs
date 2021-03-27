using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace zhongluyiyuan.gsbx.bll
{
    class GSBX_OUT
    {
        private string state;//
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string outData;//
        public string OutData
        {
            get { return outData; }
            set { outData = value; }
        }

        private string message;//
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        private DataSet ds;//

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }
    }
}
