using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace MTREG.medinsur.sjzsyb.bean
{
    public class SJZYB_OUT
    {
        /// <summary>
        /// 返回值 -1：失败，1：成功
        /// </summary>
        public int RETURNNUM { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ERRORMSG { get; set; }
        /// <summary>
        /// 接收方交易流水号
        /// </summary>
        public string REFMSGID { get; set; }
        
        
    }
    
}
