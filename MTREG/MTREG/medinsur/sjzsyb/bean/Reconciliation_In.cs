using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
	public class Reconciliation_In
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
		/// 正交易笔数
		/// </summary>
		public string BKB001 { get; set; }
		/// <summary>
		/// 反交易笔数
		/// </summary>
		public string BKB002 { get; set; }
		/// <summary>
		/// 发送方医疗费总额
		/// </summary>
		public string AKC264 { get; set; }
		/// <summary>
		/// 发送方帐户支付合计
		/// </summary>
		public string AKC255 { get; set; }
		/// <summary>
		/// 发送方统筹基金支付合计
		/// </summary>
		public string AKC260 { get; set; }
		/// <summary>
		/// 发送方现金支付合计
		/// </summary>
		public string AKC261 { get; set; }
		/// <summary>
		/// 发送方大病救助基金支付
		/// </summary>
		public string AKC706 { get; set; }
		/// <summary>
		/// 发送方公务员补
		/// </summary>
		public string AKC707 { get; set; }
		/// <summary>
		/// 发送方其他基金支付合计
		/// </summary>
		public string AKC708 { get; set; }
	} 
}
