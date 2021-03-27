using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class DownloadContrast_Out_zl : SJZYB_OUT
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
        public List<DownloadContrast_Out_zl_OUTROW> OUTROW { get; set; }
    }
    public class DownloadContrast_Out_zl_OUTROW
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
		/// 医院收费项目编码
		/// </summary>
		public string AKC515 { get; set; }
		/// <summary>
		/// 医院收费项目名称
		/// </summary>
		public string AKC516 { get; set; }
		/// <summary>
		/// 审核人
		/// </summary>
		public string AAE014 { get; set; }
		/// <summary>
		/// 审核时间
		/// </summary>
		public string AAE015 { get; set; }
		/// <summary>
		/// 审核标志
		/// </summary>
		public string AAE016 { get; set; }
		/// <summary>
		/// 审核说明
		/// </summary>
		public string BAE001 { get; set; }
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
	} 
}
