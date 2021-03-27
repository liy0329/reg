using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.outp
{
    class retMesage
    {
        string ret_mesg;
        //成功失败信息
        public string Ret_mesg
        {
            get { return ret_mesg; }
            set { ret_mesg = value; }
        }
        List<object> ret_data;
        //成功后数据
        public List<object> Ret_data
        {
            get { return ret_data; }
            set { ret_data = value; }
        }
        bool ret_flag;
        //返回成功标志
        public bool Ret_flag
        {
            get { return ret_flag; }
            set { ret_flag = value; }
        }
    }
}
