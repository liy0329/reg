using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
	public class DownloadCostdet_In
	{ 
		/// <summary>
		/// 门诊住院流水号
		/// </summary>
		public string AKC190 { get; set; }
		/// <summary>
		/// 发送方交易流水号
		/// </summary>
		public string AKC275 { get; set; }
		/// <summary>
		/// 医院处方流水号
		/// </summary>
		public string AKC378 { get; set; }
		/// <summary>
		/// 页码
		/// </summary>
		public string CURRENTPAGE { get; set; }
	} 
}
