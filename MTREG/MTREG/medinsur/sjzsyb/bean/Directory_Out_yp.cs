using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class Directory_Out_yp : SJZYB_OUT
    {
        /// <summary>
        ///  当前页
        /// </summary>
        public string CURRENTPAGE { get; set; }
        /// <summary>
        ///  总页数
        /// </summary>
        public string TOTALPAGE { get; set; }
        /// <summary>
        ///  总记录数
        /// </summary>
        public string TOTALRECORD { get; set; }
        /// <summary>
        ///  每页条数
        /// </summary>
        public string PAGESIZE { get; set; }
        /// <summary>
        /// 特定
        /// </summary>
        public List<Directory_Out_yp_OUTROW> OUTROW { get; set; }
    }
    public class Directory_Out_yp_OUTROW
	{ 
		/// <summary>
		/// 药品编码
		/// </summary>
		public string AKA060 { get; set; }
		/// <summary>
		/// 通用名称
		/// </summary>
		public string AKA061 { get; set; }
		/// <summary>
		/// 英文名称
		/// </summary>
		public string AKA062 { get; set; }
		/// <summary>
		/// 收费类别
		/// </summary>
		public string AKA063 { get; set; }
		/// <summary>
		/// 甲乙类标志
		/// </summary>
		public string AKA065 { get; set; }
		/// <summary>
		/// 拼音助记码
		/// </summary>
		public string AKA066 { get; set; }
		/// <summary>
		/// 剂型
		/// </summary>
		public string AKA070 { get; set; }
		/// <summary>
		/// 规格
		/// </summary>
		public string AKA077 { get; set; }
		/// <summary>
		/// 药品商品名
		/// </summary>
		public string AKA079 { get; set; }
		/// <summary>
		/// 商品名拼音码
		/// </summary>
		public string AKA081 { get; set; }
		/// <summary>
		/// 生产厂家
		/// </summary>
		public string CKAA00 { get; set; }
		/// <summary>
		/// 自付比例
		/// </summary>
		public string AKA069 { get; set; }
		/// <summary>
		/// 居民自付比例
		/// </summary>
		public string AKA069_JM { get; set; }
		/// <summary>
		/// 是否离休可用
		/// </summary>
		public string CKAA01 { get; set; }
		/// <summary>
		/// 限用标志
		/// </summary>
		public string CKAA02 { get; set; }
		/// <summary>
		/// 限价
		/// </summary>
		public string AKA068 { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string AAE013 { get; set; }
		/// <summary>
		/// 变更日期
		/// </summary>
		public string AAE035 { get; set; }
		/// <summary>
		/// 开始时间
		/// </summary>
		public string AAE030 { get; set; }
		/// <summary>
		/// 结束时间
		/// </summary>
		public string AAE031 { get; set; }
		/// <summary>
		/// 是否有效
		/// </summary>
		public string AAE100 { get; set; }
		/// <summary>
		/// 限价标志
		/// </summary>
		public string CKAA10 { get; set; }
        /// <summary>
        /// 单位
		/// </summary>
        public string AKA076 { get; set; }
        
	} 
}
