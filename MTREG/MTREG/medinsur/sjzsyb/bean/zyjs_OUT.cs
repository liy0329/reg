using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class zyjs_OUT : SJZYB_OUT
    {
        /// <summary>
        /// 医疗费总额 
        /// </summary>
        public string AKC264 { get; set; }
        /// <summary>
        /// 本次帐户支付金额 
        /// </summary>
        public string AKC255 { get; set; }
        /// <summary>
        /// 本次统筹支付金额 
        /// </summary>
        public string AKC260 { get; set; }
        /// <summary>
        /// 本次现金支付金额 
        /// </summary>
        public string AKC261 { get; set; }
        /// <summary>
        /// 大病救助基金支付 
        /// </summary>
        public string AKC706 { get; set; }
        /// <summary>
        /// 公务员补助支付 
        /// </summary>
        public string AKC707 { get; set; }
        /// <summary>
        /// 其他基金支出 
        /// </summary>
        public string AKC708 { get; set; }
        /// <summary>
        /// 符合基本医疗保险费用
        /// </summary>
        public string AKC263 { get; set; }
        /// <summary>
        /// 本年符合基本医疗累计
        /// </summary>
        public string AKC089 { get; set; }
        /// <summary>
        /// 本年统筹支出累计 
        /// </summary>
        public string AKC088 { get; set; }
        /// <summary>
        /// 本年大病支出累计 
        /// </summary>
        public string AKC121 { get; set; }
        /// <summary>
        /// 本次起付标准自付 
        /// </summary>
        public string AKC256 { get; set; }
        /// <summary>
        /// 本次起付标准 
        /// </summary>
        public string CKA050 { get; set; }
        /// <summary>
        /// 本年住院次数 
        /// </summary>
        public string AKC090 { get; set; }
        /// <summary>
        /// 进入统筹费用 
        /// </summary>
        public string AKC268 { get; set; }
        /// <summary>
        /// 本次进入公务员费用 
        /// </summary>
        public string AKC278 { get; set; }
        /// <summary>
        /// 本次进入大病部分 
        /// </summary>
        public string AKC279 { get; set; }
        /// <summary>
        /// 进入其他基金费用 
        /// </summary>
        public string AKC718 { get; set; }
        /// <summary>
        /// 超过大病补充封顶线部分
        /// </summary>
        public string ZKC036 { get; set; }
        /// <summary>
        /// 本次个人帐户应支付金额
        /// </summary>
        public string AKC262 { get; set; }
        /// <summary>
        /// 卡结算前余额 
        /// </summary>
        public string AKC252 { get; set; }
        /// <summary>
        /// 卡结算后余额 
        /// </summary>
        public string AKC087 { get; set; }
        /// <summary>
        /// 自费费用 
        /// </summary>
        public string AKC253 { get; set; }
        /// <summary>
        /// 乙类自付 
        /// </summary>
        public string AKC254 { get; set; }
        /// <summary>
        /// 乙类药自付 
        /// </summary>
        public string AKC380 { get; set; }
        /// <summary>
        /// 特检自付 
        /// </summary>
        public string ZKC032 { get; set; }
        /// <summary>
        /// 特治自付 
        /// </summary>
        public string ZKC034 { get; set; }
        /// <summary>
        /// 统筹分段自付（第1段） 
        /// </summary>
        public string AKC740 { get; set; }
        /// <summary>
        /// 统筹分段自付（第2段） 
        /// </summary>
        public string AKC741 { get; set; }
        /// <summary>
        /// 统筹分段自付（第3段） 
        /// </summary>
        public string AKC742 { get; set; }
        /// <summary>
        /// 统筹分段自付（第4段） 
        /// </summary>
        public string AKC743 { get; set; }
        /// <summary>
        /// 统筹分段自付（第5段） 
        /// </summary>
        public string AKC744 { get; set; }
        /// <summary>
        /// 统筹分段自付（第6段） 
        /// </summary>
        public string AKC745 { get; set; }
        /// <summary>
        /// 统筹支出（第 1 段） 
        /// </summary>
        public string AKC746 { get; set; }
        /// <summary>
        /// 统筹支出（第 2 段） 
        /// </summary>
        public string AKC747 { get; set; }
        /// <summary>
        /// 统筹支出（第 3 段） 
        /// </summary>
        public string AKC748 { get; set; }
        /// <summary>
        /// 统筹支出（第 4 段） 
        /// </summary>
        public string AKC749 { get; set; }
        /// <summary>
        /// 统筹支出（第 5 段） 
        /// </summary>
        public string AKC750 { get; set; }
        /// <summary>
        /// 统筹支出（第 6 段） 
        /// </summary>
        public string AKC751 { get; set; }
        /// <summary>
        /// 公务员自付 
        /// </summary>
        public string AKC752 { get; set; }
        /// <summary>
        /// 其他基金自付 
        /// </summary>
        public string AKC753 { get; set; }
        /// <summary>
        /// 超过封顶线个人自付 
        /// </summary>
        public string AKC258 { get; set; }
        /// <summary>
        /// 甲类药总费用 
        /// </summary>
        public string BKA067 { get; set; }
        /// <summary>
        /// 乙类药总费用 
        /// </summary>
        public string BKA068 { get; set; }
        /// <summary>
        /// 丙类药总费用 
        /// </summary>
        public string BKA069 { get; set; }
        /// <summary>
        /// 普通检查费用 
        /// </summary>
        public string AKC368 { get; set; }
        /// <summary>
        /// 特殊检查费用 
        /// </summary>
        public string AKC369 { get; set; }
        /// <summary>
        /// 自费检查费用 
        /// </summary>
        public string AKC370 { get; set; }
        /// <summary>
        /// 普通治疗费用 
        /// </summary>
        public string AKC374 { get; set; }
        /// <summary>
        /// 特殊治疗费用 
        /// </summary>
        public string AKC375 { get; set; }
        /// <summary>
        /// 自费治疗费用 
        /// </summary>
        public string AKC376 { get; set; }
        /// <summary>
        /// 总的个人自付金额 
        /// </summary>
        public string AKC754 { get; set; }
        /// <summary>
        /// 预留字段 2 
        /// </summary>
        public string AKC755 { get; set; }
        /// <summary>
        /// 预留字段 
        /// </summary>
        public string AKC756 { get; set; }
        /// <summary>
        /// 预留字段 4 
        /// </summary>
        public string AKC757 { get; set; }
        /// <summary>
        /// 预留字段 5 
        /// </summary>
        public string AKC758 { get; set; }
        /// <summary>
        /// 结算日期 
        /// </summary>
        public string AAE040 { get; set; }
        /// <summary>
        /// 基本账户 
        /// </summary>
        public string AKC759 { get; set; }
        /// <summary>
        /// 4%补充账户 
        /// </summary>
        public string AKC760 { get; set; }
        /// <summary>
        /// 10%补充账户 
        /// </summary>
        public string AKC761 { get; set; }
        /// <summary>
        /// 10%补助账户 
        /// </summary>
        public string AKC762 { get; set; }
        /// <summary>
        /// 补充账户 
        /// </summary>
        public string AKC763 { get; set; }
        /// <summary>
        /// 补助账户 
        /// </summary>
        public string AKC764 { get; set; }
        /// <summary>
        /// 其他账户 
        /// </summary>
        public string AKC765 { get; set; }
        /// <summary>
        /// 基本统筹 
        /// </summary>
        public string AKC766 { get; set; }
        /// <summary>
        /// 4%补充统筹 
        /// </summary>
        public string AKC767 { get; set; }
        /// <summary>
        /// 10%补充统筹 
        /// </summary>
        public string AKC768 { get; set; }
        /// <summary>
        /// 10%补助统筹 
        /// </summary>
        public string AKC769 { get; set; }
        /// <summary>
        /// 补充统筹 
        /// </summary>
        public string AKC770 { get; set; }
        /// <summary>
        /// 补助统筹 
        /// </summary>
        public string AKC771 { get; set; }
        /// <summary>
        /// 其他统筹 
        /// </summary>
        public string AKC772 { get; set; }
        /// <summary>
        /// 定点医疗机构支付 
        /// </summary>
        public string AKC773 { get; set; }
        /// <summary>
        /// 一次性材料费用 
        /// </summary>
        public string AKC774 { get; set; }
        /// <summary>
        /// 诊疗项目费用 
        /// </summary>
        public string AKC775 { get; set; }
        /// <summary>
        /// 药品费用 
        /// </summary>
        public string AKC776 { get; set; }
        /// <summary>
        /// 服务设施费用 
        /// </summary>
        public string AKC777 { get; set; }
        /// <summary>
        /// 类型（发票） 
        /// </summary>
        public string AKC778 { get; set; }
        /// <summary>
        /// 医保类型（发票） 
        /// </summary>
        public string AKC779 { get; set; }
        /// <summary>
        /// 医保统筹支付（发票） 
        /// </summary>
        public string AKC780 { get; set; }
        /// <summary>
        /// 起付标准累计（发票） 
        /// </summary>
        public string AKC781 { get; set; }
        /// <summary>
        /// 统筹累计支付（发票） 
        /// </summary>
        public string AKC782 { get; set; }
        /// <summary>
        /// 免收（发票） 
        /// </summary>
        public string AKC783 { get; set; }
        /// <summary>
        /// 是否七方面人（发票） 
        /// </summary>
        public string AKC784 { get; set; }
        /// <summary>
        /// 医院垫支（发票） 
        /// </summary>
        public string AKC785 { get; set; }
        /// <summary>
        /// 大病起付标准自付（发票）
        /// </summary>
        public string AKC786 { get; set; }
        /// <summary>
        /// 大病起付标准累计（发票）
        /// </summary>
        public string AKC787 { get; set; }
        /// <summary>
        /// 结算状态（发票） 
        /// </summary>
        public string AKC788 { get; set; }
        /// <summary>
        /// 门诊超限额自付（发票）
        /// </summary>
        public string AKC789 { get; set; }
        /// <summary>
        /// 大病自付（发票） 
        /// </summary>
        public string AKC790 { get; set; }
        /// <summary>
        /// 其他自付（发票） 
        /// </summary>
        public string AKC791 { get; set; }
        /// <summary>
        /// 票据类型（发票） 
        /// </summary>
        public string AKC792 { get; set; }
        /// <summary>
        /// 补助统筹累计（发票） 
        /// </summary>
        public string AKC793 { get; set; }
        /// <summary>
        /// 基金分项
        /// </summary>
        public string AKE182 { get; set; }
        /// <summary>
        /// 定点机构名称（发票） 
        /// </summary>
        public string AKB021 { get; set; }
        /// <summary>
        /// 基本提高支付（发票）
        /// </summary>
        public string CKAA20 { get; set; }
        /// <summary>
        /// 大病提高支付（发票）
        /// </summary>
        public string CKAA27 { get; set; }
        /// <summary>
        /// 医疗救助支付（发票）
        /// </summary>
        public string BKE151 { get; set; }
        /// <summary>
        /// 医疗救助补充支付（发票）
        /// </summary>
        public string CKAA40 { get; set; }
        /// <summary>
        /// 贫困人口标志 
        /// </summary>
        public string BAC081 { get; set; }


    }
}
