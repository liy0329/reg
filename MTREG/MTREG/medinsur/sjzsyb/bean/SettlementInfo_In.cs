using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
	public class SettlementInfo_In
	{ 
		/// <summary>
		/// 开始时间
		/// </summary>
		public string AAE030 { get; set; }
		/// <summary>
		/// 终止时间
		/// </summary>
		public string AAE031 { get; set; }
		/// <summary>
		/// 业务类型
		/// </summary>
		public string CKA130 { get; set; }
		/// <summary>
		/// 对账状态
		/// </summary>
		public string CKAA08 { get; set; }
		/// <summary>
		/// 页码
		/// </summary>
		public string CURRENTPAGE { get; set; }
	} 
}
