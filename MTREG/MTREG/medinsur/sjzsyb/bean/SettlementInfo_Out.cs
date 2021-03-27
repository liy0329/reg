using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class SettlementInfo_Out : SJZYB_OUT
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
        public List<SettlementInfo_Out_OUTROW> OUTROW { get; set; }
    }
    public class SettlementInfo_Out_OUTROW
	{ 
		/// <summary>
		/// 定 点 医 疗机构编号
		/// </summary>
		public string AKB020 { get; set; }
		/// <summary>
		/// 门 诊 住 院流水号
		/// </summary>
		public string AKC190 { get; set; }
		/// <summary>
		/// 单据号
		/// </summary>
		public string AAE072 { get; set; }
		/// <summary>
		/// 结算日期
		/// </summary>
		public string AAE040 { get; set; }
		/// <summary>
		/// 个人编号
		/// </summary>
		public string AAC001 { get; set; }
		/// <summary>
		/// 社保卡号
		/// </summary>
		public string AKC020 { get; set; }
		/// <summary>
		/// 发 送 方 交易流水号
		/// </summary>
		public string AKC275 { get; set; }
		/// <summary>
		/// 接 收 方 交易流水号
		/// </summary>
		public string AKC276 { get; set; }
		/// <summary>
		/// 撤销（或被撤销）的发送 方 交 易流水号
		/// </summary>
		public string AKC281 { get; set; }
		/// <summary>
		/// 撤销（或被撤销）的接收 方 交 易流水号
		/// </summary>
		public string AKC282 { get; set; }
		/// <summary>
		/// 冲正（或被冲正）的发送 方 交 易流水号
		/// </summary>
		public string AKC283 { get; set; }
		/// <summary>
		/// 被冲正（或被冲正）的接 收 方 交易流水号
		/// </summary>
		public string AKC284 { get; set; }
		/// <summary>
		/// 业 务 周 期号
		/// </summary>
		public string AKC332 { get; set; }
		/// <summary>
		/// 医 疗 费 总额
		/// </summary>
		public string AKC264 { get; set; }
		/// <summary>
		/// 帐户支付
		/// </summary>
		public string AKC255 { get; set; }
		/// <summary>
		/// 统 筹 基 金支付
		/// </summary>
		public string AKC260 { get; set; }
		/// <summary>
		/// 现金支付
		/// </summary>
		public string AKC261 { get; set; }
		/// <summary>
		/// 大 病 救 助基金支付
		/// </summary>
		public string AKC706 { get; set; }
		/// <summary>
		/// 公 务 员 补助支付
		/// </summary>
		public string AKC707 { get; set; }
		/// <summary>
		/// 其 他 基 金支出
		/// </summary>
		public string AKC708 { get; set; }
		/// <summary>
		/// 交易代码
		/// </summary>
		public string MSGNO { get; set; }
		/// <summary>
		/// 对账状态
		/// </summary>
		public string CKAA08 { get; set; }
		/// <summary>
		/// 对账时间
		/// </summary>
		public string CKAA09 { get; set; }
		/// <summary>
		/// 基 本 提 高支 付 （ 发票）
		/// </summary>
		public string CKAA20 { get; set; }
		/// <summary>
		/// 大 病 提 高支 付 （ 发票）
		/// </summary>
		public string CKAA27 { get; set; }
		/// <summary>
		/// 医 疗 救 助支 付 （ 发票）
		/// </summary>
		public string BKE151 { get; set; }
		/// <summary>
		/// 医 疗 救 助补 充 支 付（发票）
		/// </summary>
		public string CKAA40 { get; set; }
		/// <summary>
		/// 贫 困 人 口标志
		/// </summary>
		public string BAC081 { get; set; }
	} 
}
