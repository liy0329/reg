using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class Directory_Out_zl : SJZYB_OUT
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
        public List<Directory_Out_zl_OUTROW> OUTROW { get; set; }
    }
    public class Directory_Out_zl_OUTROW
	{ 
		/// <summary>
		/// 项目编码
		/// </summary>
		public string AKA090 { get; set; }
		/// <summary>
		/// 项目名称
		/// </summary>
		public string AKA091 { get; set; }
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
		/// 单位
		/// </summary>
		public string AKA076 { get; set; }
		/// <summary>
		/// 生产厂家
		/// </summary>
		public string CKAA00 { get; set; }
		/// <summary>
		/// 县级限价
		/// </summary>
		public string AKA068I { get; set; }
		/// <summary>
		/// 市级限价
		/// </summary>
		public string AKA068II { get; set; }
		/// <summary>
		/// 省级限价
		/// </summary>
		public string AKA068III { get; set; }
		/// <summary>
		/// 公立医院县级限价
		/// </summary>
		public string PUB_AKA068I { get; set; }
		/// <summary>
		/// 公立医院市级限价
		/// </summary>
		public string PUB_AKA068II { get; set; }
		/// <summary>
		/// 公立医院省级限价
		/// </summary>
		public string PUB_AKA068III { get; set; }
		/// <summary>
		/// 目录适用类型标志
		/// </summary>
		public string CKAA07 { get; set; }
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
		/// 物价编码
		/// </summary>
		public string BKA643 { get; set; }
		/// <summary>
		/// 限价标志
		/// </summary>
		public string CKAA10 { get; set; }
	} 
}
