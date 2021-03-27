using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class ybSettRpt_Out : SJZYB_OUT
	{ 
		/// <summary>
		/// 医保类型
		/// </summary>
		public string CKAA14 { get; set; }
		/// <summary>
		/// 基本医保支付限额
		/// </summary>
		public string CKAA15 { get; set; }
		/// <summary>
		/// 大病保险支付限额
		/// </summary>
		public string CKAA16 { get; set; }
		/// <summary>
		/// 贫困人口大病保险
		/// </summary>
		public string CKAA17 { get; set; }
		/// <summary>
		/// 医疗补助支付限额
		/// </summary>
		public string CKAA18 { get; set; }
		/// <summary>
		/// 有效住院累计次数
		/// </summary>
		public string AKC090 { get; set; }
		/// <summary>
		/// 基本统筹累计支付
		/// </summary>
		public string AKC088 { get; set; }
		/// <summary>
		/// 补助起付线累计支付
		/// </summary>
		public string CKAA19 { get; set; }
		/// <summary>
		/// 补助累计支付
		/// </summary>
		public string ZKC026 { get; set; }
		/// <summary>
		/// 个人账户余额
		/// </summary>
		public string AKC252 { get; set; }
		/// <summary>
		/// 累计进入大病费用
		/// </summary>
		public string BKE106 { get; set; }
		/// <summary>
		/// 大病起付线累计支付
		/// </summary>
		public string AKC787 { get; set; }
		/// <summary>
		/// 大病保险累计支付
		/// </summary>
		public string AKC121 { get; set; }
		/// <summary>
		/// 医疗救助累计支付
		/// </summary>
		public string BKE152 { get; set; }
		/// <summary>
		/// 费用总额
		/// </summary>
		public string AKC264 { get; set; }
		/// <summary>
		/// 医保医疗费
		/// </summary>
		public string AKC263 { get; set; }
		/// <summary>
		/// 乙类首先自付
		/// </summary>
		public string AKC254 { get; set; }
		/// <summary>
		/// 起付线标准
		/// </summary>
		public string CKA050 { get; set; }
		/// <summary>
		/// 超限额自费
		/// </summary>
		public string BKE033 { get; set; }
		/// <summary>
		/// 基本统筹支付
		/// </summary>
		public string AKC260 { get; set; }
		/// <summary>
		/// 基本统筹自付
		/// </summary>
		public string AKC740 { get; set; }
		/// <summary>
		/// 起付标准自付
		/// </summary>
		public string AKC256 { get; set; }
		/// <summary>
		/// 提高待遇合计 2A
		/// </summary>
		public string CKAA20 { get; set; }
		/// <summary>
		/// 起付线降低提高待遇
		/// </summary>
		public string BKE155 { get; set; }
		/// <summary>
		/// 提高报销比例提高待遇
		/// </summary>
		public string BKE148 { get; set; }
		/// <summary>
		/// 大病支付合计
		/// </summary>
		public string AKC706 { get; set; }
		/// <summary>
		/// 本次进入大病费用
		/// </summary>
		public string AKC279 { get; set; }
		/// <summary>
		/// 大病起付标准(医疗补助起付标准)
		/// </summary>
		public string CKAA21 { get; set; }
		/// <summary>
		/// 起付标准自付(补助起付线自付)
		/// </summary>
		public string AKC786 { get; set; }
		/// <summary>
		/// 大病一段支付(补助一段支付)
		/// </summary>
		public string CKAA22 { get; set; }
		/// <summary>
		/// 大病二段支付(补助二段支付)
		/// </summary>
		public string CKAA23 { get; set; }
		/// <summary>
		/// 大病三段支付(补助三段支付)
		/// </summary>
		public string CKAA24 { get; set; }
		/// <summary>
		/// 大病四段支付(补助四段支付)
		/// </summary>
		public string CKAA25 { get; set; }
		/// <summary>
		/// 大病五段支付(补助五段支付)
		/// </summary>
		public string CKAA26 { get; set; }
		/// <summary>
		/// 大病段内自付(补助段内自付)
		/// </summary>
		public string AKC790 { get; set; }
		/// <summary>
		/// 大病超限额自付(补助超限额自付)
		/// </summary>
		public string ZKC036 { get; set; }
		/// <summary>
		/// 提高待遇合计 3A
		/// </summary>
		public string CKAA27 { get; set; }
		/// <summary>
		/// 取消起付线提高待遇
		/// </summary>
		public string BKE149 { get; set; }
		/// <summary>
		/// 提高封顶线
		/// </summary>
		public string BKE150 { get; set; }
		/// <summary>
		/// 医疗救助合计
		/// </summary>
		public string BKE151 { get; set; }
		/// <summary>
		/// 本次进入医疗救助费用
		/// </summary>
		public string CKAA28 { get; set; }
		/// <summary>
		/// 医疗救助自付
		/// </summary>
		public string CKAA49 { get; set; }
		/// <summary>
		/// 补助支付合计
		/// </summary>
		public string AKC707 { get; set; }
		/// <summary>
		/// 医疗补助起付标准
		/// </summary>
		public string CKAA29 { get; set; }
		/// <summary>
		/// 补助自付
		/// </summary>
		public string AKC752 { get; set; }
		/// <summary>
		/// 医疗补助支付基本起付线
		/// </summary>
		public string CKAA30 { get; set; }
		/// <summary>
		/// 千元以上一次性材料补助
		/// </summary>
		public string CKAA31 { get; set; }
		/// <summary>
		/// 医疗补助支付基本段内自付
		/// </summary>
		public string CKAA32 { get; set; }
		/// <summary>
		/// 医保统筹支付
		/// </summary>
		public string AKC780 { get; set; }
		/// <summary>
		/// 个人账户支付
		/// </summary>
		public string AKC255 { get; set; }
		/// <summary>
		/// 个人自付
		/// </summary>
		public string AKC754 { get; set; }
		/// <summary>
		/// 个人自费
		/// </summary>
		public string AKC253 { get; set; }
		/// <summary>
		/// 其他自费
		/// </summary>
		public string CKAA33 { get; set; }
		/// <summary>
		/// 大类列表
		/// </summary>
		public string AKC063LIST { get; set; }
		/// <summary>
		/// 累计进入补充保险费用
		/// </summary>
		public string CKAA37 { get; set; }
		/// <summary>
		/// 补充保险起付线累计支付
		/// </summary>
		public string CKAA38 { get; set; }
		/// <summary>
		/// 补充保险累计支付
		/// </summary>
		public string CKAA39 { get; set; }
		/// <summary>
		/// 支付合计
		/// </summary>
		public string CKAA40 { get; set; }
		/// <summary>
		/// 本次进入补充保险费用
		/// </summary>
		public string CKAA41 { get; set; }
		/// <summary>
		/// 补充保险起付标准
		/// </summary>
		public string CKAA42 { get; set; }
		/// <summary>
		/// 补充保险起付标准自付
		/// </summary>
		public string CKAA43 { get; set; }
		/// <summary>
		/// 补充一段支付
		/// </summary>
		public string CKAA44 { get; set; }
		/// <summary>
		/// 补充二段支付
		/// </summary>
		public string CKAA45 { get; set; }
		/// <summary>
		/// 补充三段支付
		/// </summary>
		public string CKAA46 { get; set; }
		/// <summary>
		/// 补充四段支付
		/// </summary>
		public string CKAA47 { get; set; }
		/// <summary>
		/// 补充超限额
		/// </summary>
		public string CKAA48 { get; set; }
		/// <summary>
		/// 补充保险段内自付
		/// </summary>
		public string CKAA50 { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string CKAA51 { get; set; }
		/// <summary>
		/// 贫困人口标志
		/// </summary>
		public string BAC081 { get; set; }
	} 
}
