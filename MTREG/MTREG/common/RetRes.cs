using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTHIS.common
{
    /// <summary>
    /// 输入参数存储类
    /// </summary>
    public class RetRes
    {
        public RetRes(bool ret_flag)
        {
            this.ret_flag = ret_flag;
        }
        string ret_mesg;
        //成功失败信息
        public string Ret_mesg
        {
            get { return ret_mesg; }
            set { ret_mesg = value; }
        }
        bool ret_flag = true;
        //返回成功标志
        public bool Ret_flag
        {
            get { return ret_flag; }
            set { ret_flag = value; }
        }
        int ret_value;

        public int Ret_value
        {
            get { return ret_value; }
            set { ret_value = value; }
        }

        int barcode_stat;
        /// <summary>
        /// 扫码时状态
        /// </summary>
        public int Barcode_stat
        {
            get { return barcode_stat; }
            set { barcode_stat = value; }
        }

    }
}
