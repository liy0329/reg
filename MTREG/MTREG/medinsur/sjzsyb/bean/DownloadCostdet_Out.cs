using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
	public class DownloadCostdet_Out : SJZYB_OUT
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
        public List<DownloadCostdet_Out_OUTROW> OUTROW { get; set; }
    }
    public class DownloadCostdet_Out_OUTROW
    { 
		/// <summary>
		/// 发送方交易流水号
		/// </summary>
		public string AKC275 { get; set; }
		/// <summary>
		/// 接收方交易流水号
		/// </summary>
		public string AKC276 { get; set; }
		/// <summary>
		/// 定点医疗机构编码
		/// </summary>
		public string AKB020 { get; set; }
		/// <summary>
		/// 门诊住院流水号
		/// </summary>
		public string AKC190 { get; set; }
		/// <summary>
		/// 医院收费项目编码
		/// </summary>
		public string AKC515 { get; set; }
		/// <summary>
		/// 医院收费项目名称
		/// </summary>
		public string AKC516 { get; set; }
		/// <summary>
		/// 项目等级
		/// </summary>
		public string AKA065 { get; set; }
		/// <summary>
		/// 收费类别
		/// </summary>
		public string AKA063 { get; set; }
		/// <summary>
		/// 单价
		/// </summary>
		public string AKC225 { get; set; }
		/// <summary>
		/// 数量
		/// </summary>
		public string AKC226 { get; set; }
		/// <summary>
		/// 金额
		/// </summary>
		public string AKC227 { get; set; }
		/// <summary>
		/// 中心收费项目编码
		/// </summary>
		public string AKC222 { get; set; }
		/// <summary>
		/// 中心收费项目名称
		/// </summary>
		public string AKC223 { get; set; }
		/// <summary>
		/// 自付比例
		/// </summary>
		public string AKA069 { get; set; }
		/// <summary>
		/// 限额内金额
		/// </summary>
		public string CKAA06 { get; set; }
		/// <summary>
		/// 超限自费金额
		/// </summary>
		public string AKC253 { get; set; }
		/// <summary>
		/// 免收金额
		/// </summary>
		public string AKC783 { get; set; }
		/// <summary>
		/// 剂型
		/// </summary>
		public string AKA070 { get; set; }
		/// <summary>
		/// 规格
		/// </summary>
		public string AKC604 { get; set; }
		/// <summary>
		/// 处方日期
		/// </summary>
		public string AKC221 { get; set; }
		/// <summary>
		/// 医院处方流水号
		/// </summary>
		public string AKC378 { get; set; }
	} 
}
