using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
     public class mz_dk : SJZYB_OUT
    {
        /// <summary>
        /// 是否持卡
        /// </summary>
        public string sfcf { get; set; }
        /// <summary>
        /// 医疗类别
        /// </summary>
        public string AKA130 { get; set; }
        /// <summary>
        /// 入院诊断疾病编码
        /// </summary>
        public string AKC193 { get; set; }
        /// <summary>
        /// 入院诊断疾病名称
        /// </summary>
        public string AKC140 { get; set; }
        /// <summary>
        /// 读卡
        /// </summary>
        public DK_OUT DK_OUT { get; set; }
    }
}
