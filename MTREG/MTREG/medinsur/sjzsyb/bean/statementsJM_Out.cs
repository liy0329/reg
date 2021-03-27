using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
	public class statementsJM_Out : SJZYB_OUT
	{ 
		/// <summary>
		/// 报销类别
		/// </summary>
		public string CKAA52 { get; set; }
		/// <summary>
		/// 医疗机构名称
		/// </summary>
		public string AKB021 { get; set; }
		/// <summary>
		/// 医疗机构等级
		/// </summary>
		public string CKAA53 { get; set; }
		/// <summary>
		/// 住院号
		/// </summary>
		public string AKC190 { get; set; }
		/// <summary>
		/// 姓名
		/// </summary>
		public string AAC003 { get; set; }
		/// <summary>
		/// 性别
		/// </summary>
		public string AAC004 { get; set; }
		/// <summary>
		/// 身份证号
		/// </summary>
		public string AAC002 { get; set; }
		/// <summary>
		/// 参保地
		/// </summary>
		public string CKAA54 { get; set; }
		/// <summary>
		/// 人员类别
		/// </summary>
		public string CKAA55 { get; set; }
		/// <summary>
		/// 诊断名称
		/// </summary>
		public string AKC141 { get; set; }
		/// <summary>
		/// 入院日期
		/// </summary>
		public string AKC192 { get; set; }
		/// <summary>
		/// 出院日期
		/// </summary>
		public string AKC194 { get; set; }
		/// <summary>
		/// 费用总额
		/// </summary>
		public string AKC264 { get; set; }
		/// <summary>
		/// 政策内费用
		/// </summary>
		public string CKAA56 { get; set; }
		/// <summary>
		/// 基本医保统筹支付
		/// </summary>
		public string AKC260 { get; set; }
		/// <summary>
		/// 基本医保提高待遇
		/// </summary>
		public string CKAA20 { get; set; }
		/// <summary>
		/// 大病保险统筹支付
		/// </summary>
		public string AKC706 { get; set; }
		/// <summary>
		/// 大病保险提高待遇
		/// </summary>
		public string CKAA27 { get; set; }
		/// <summary>
		/// 医疗救助
		/// </summary>
		public string BKE151 { get; set; }
		/// <summary>
		/// 其他保障或补助
		/// </summary>
		public string AKC708 { get; set; }
		/// <summary>
		/// 票据号
		/// </summary>
		public string AAE072 { get; set; }
		/// <summary>
		/// 报销流水号
		/// </summary>
		public string CKAA57 { get; set; }
		/// <summary>
		/// 本次报销合计
		/// </summary>
		public string AKC780 { get; set; }
		/// <summary>
		/// 本次个人负担小计
		/// </summary>
		public string CKAA58 { get; set; }
		/// <summary>
		/// 政策内自付
		/// </summary>
		public string AKC754 { get; set; }
		/// <summary>
		/// 政策外自费
		/// </summary>
		public string AKC253 { get; set; }
		/// <summary>
		/// 是否享受三重保障
		/// </summary>
		public string CKAA59 { get; set; }
		/// <summary>
		/// 结算日期
		/// </summary>
		public string AAE040 { get; set; }
	} 
}
