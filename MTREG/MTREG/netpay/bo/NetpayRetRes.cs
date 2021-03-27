using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
    /// <summary>
    /// 输入参数存储类
    /// </summary>
    public class NetpayRetRes
    {
        
        string ret_mesg;
        //失败信息:
        public string  Err_mesg
        {
            get { return ret_mesg; }
            set { ret_mesg = value; }
        }
        bool ret_flag = false;
        //返回成功标志
        public bool Ret_flag
        {
            get { return ret_flag; }
            set { ret_flag = value; }
        }
        int errcode;
        /// <summary>
        /// 错误码: 0:成功, 1:失败，确定交易不成功 , 负数 : 失败, 交易不确定
        /// </summary>
        public int Errcode
        {
            get { return errcode; }
            set { errcode = value; }
        }



    }
}
