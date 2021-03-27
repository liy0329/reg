using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hsdryb.bo
{
    class InOutParameter
    {
        #region 输出参数
        private string returnNum;
        private string errorMsg;
        private string refMsgId;
        private string output;
        /// <summary>
        /// 返回值
        /// </summary>
        public string ReturnNum
        {
            get { return returnNum; }
            set { returnNum = value; }
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg
        {
            get { return errorMsg; }
            set { errorMsg = value; }
        }
        /// <summary>
        /// 接收方交易流水号
        /// </summary>
        public string RefMsgId
        {
            get { return refMsgId; }
            set { refMsgId = value; }
        }   
        /// <summary>
        /// 特定输出参数
        /// </summary>
        public string Output
        {
            get { return output; }
            set { output = value; }
        }
        #endregion

        private string batno;
        private string aae036;
        private string aab001;
        private string aab004;
        private string akc020;
        private string aac002;
        private string aac004;
        private string aac005;
        private string aac006;
        private string aac030;
        private string aac008;
        private string zkc031;
        private string aac021;
        private string bac136;
        private string aac007;
        private string akc086;
        private string zkc026;
        private string akc099;
        private string akc803;
        private string akc804;
        private string baz061;

        /// <summary>
        /// 业务周期号
        /// </summary>
        public string BATNO
        {
            get { return batno; }
            set { batno = value; }
        }
        /// <summary>
        /// 中心端时间
        /// </summary>
        public string AAE036
        {
            get { return aae036; }
            set { aae036 = value; }
        }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string AAB001
        {
            get { return aab001; }
            set { aab001 = value; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string AAB004
        {
            get { return aab004; }
            set { aab004 = value; }
        }
        /// <summary>
        /// 卡号
        /// </summary>
        public string AKC020
        {
            get { return akc020; }
            set { akc020 = value; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string AAC002
        {
            get { return aac002; }
            set { aac002 = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string AAC004
        {
            get { return aac004; }
            set { aac004 = value; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string AAC005
        {
            get { return aac005; }
            set { aac005 = value; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string AAC006
        {
            get { return aac006; }
            set { aac006 = value; }
        }
        /// <summary>
        /// 参保日期
        /// </summary>
        public string AAC030
        {
            get { return aac030; }
            set { aac030 = value; }
        }
        /// <summary>
        /// 人员状态
        /// </summary>
        public string AAC008
        {
            get { return aac008; }
            set { aac008 = value; }
        }
        /// <summary>
        /// 住院状态
        /// </summary>
        public string ZKC031
        {
            get { return zkc031; }
            set { zkc031 = value; }
        }
        /// <summary>
        /// 公务员
        /// </summary>
        public string AAC021
        {
            get { return aac021; }
            set { aac021 = value; }
        }
        /// <summary>
        /// 灵活就业标志
        /// </summary>
        public string BAC136
        {
            get { return bac136; }
            set { bac136 = value; }
        }
        /// <summary>
        /// 参加工作日期
        /// </summary>
        public string AAC007
        {
            get { return aac007; }
            set { aac007 = value; }
        }
        /// <summary>
        /// 帐户支出累计
        /// </summary>
        public string AKC086
        {
            get { return akc086; }
            set { akc086 = value; }
        }
        /// <summary>
        /// 公务员统筹累计
        /// </summary>
        public string ZKC026
        {
            get { return zkc026; }
            set { zkc026 = value; }
        }
        /// <summary>
        /// 门诊特殊病符合基本医疗
        /// </summary>
        public string AKC099
        {
            get { return akc099; }
            set { akc099 = value; }
        }
        /// <summary>
        /// 参保地行政区划代码
        /// </summary>
        public string AKC803
        {
            get { return akc803; }
            set { akc803 = value; }
        }
        /// <summary>
        /// 参保地社保机构名称
        /// </summary>
        public string AKC804
        {
            get { return akc804; }
            set { akc804 = value; }
        }
        /// <summary>
        /// 社保卡SID
        /// </summary>
        public string BAZ061
        {
            get { return baz061; }
            set { baz061 = value; }
        }

        private string aae002;
        /// <summary>
        /// 最大实缴月份
        /// </summary>
        public string AAE002
        {
            get { return aae002; }
            set { aae002 = value; }
        }

        private string zka102;
        /// <summary>
        /// 已审批的门诊慢性病病种
        /// </summary>
        public string ZKA102
        {
            get { return zka102; }
            set { zka102 = value; }
        }

        private string zka103;
        /// <summary>
        /// 已审批的门诊特殊疾病（门诊大病）病种
        /// </summary>
        public string ZKA103
        {
            get { return zka103; }
            set { zka103 = value; }
        }



        private string akc194;
        /// <summary>
        /// 出院日期
        /// </summary>
        public string AKC194
        {
            get { return akc194; }
            set { akc194 = value; }
        }

        private string akc195;
        /// <summary>
        /// 出院原因
        /// </summary>
        public string AKC195
        {
            get { return akc195; }
            set { akc195 = value; }
        }

        private string akc196;
        /// <summary>
        /// 出院诊断编码
        /// </summary>
        public string AKC196
        {
            get { return akc196; }
            set { akc196 = value; }
        }

        private string akc141;
        /// <summary>
        /// 出院诊断名称
        /// </summary>
        public string AKC141
        {
            get { return akc141; }
            set { akc141 = value; }
        }

        private string bkc317;
        /// <summary>
        /// 在院状态
        /// </summary>
        public string BKC317
        {
            get { return bkc317; }
            set { bkc317 = value; }
        }

        private string zkc759;
        /// <summary>
        /// 结算方式
        /// </summary>
        public string ZKC759
        {
            get { return zkc759; }
            set { zkc759 = value; }
        }

        private string bkc111;
        /// <summary>
        /// 是否使用账户
        /// </summary>
        public string BKC111
        {
            get { return bkc111; }
            set { bkc111 = value; }
        }


        private string akc255;
        /// <summary>
        /// 本次帐户支付金额
        /// </summary>
        public string AKC255
        {
            get { return akc255; }
            set { akc255 = value; }
        }

        private string akc260;
        /// <summary>
        /// 本次统筹支付金额
        /// </summary>
        public string AKC260
        {
            get { return akc260; }
            set { akc260 = value; }
        }



        private string akc706;
        /// <summary>
        /// 大病救助基金支付
        /// </summary>
        public string AKC706
        {
            get { return akc706; }
            set { akc706 = value; }
        }

        private string akc707;
        /// <summary>
        /// 公务员补助支付
        /// </summary>
        public string AKC707
        {
            get { return akc707; }
            set { akc707 = value; }
        }

        private string akc708;
        /// <summary>
        /// 其他基金支出
        /// </summary>
        public string AKC708
        {
            get { return akc708; }
            set { akc708 = value; }
        }

        private string akc263;
        /// <summary>
        /// 符合基本医疗保险费用
        /// </summary>
        public string AKC263
        {
            get { return akc263; }
            set { akc263 = value; }
        }

        private string akc089;
        /// <summary>
        /// 本年符合基本医疗累计
        /// </summary>
        public string AKC089
        {
            get { return akc089; }
            set { akc089 = value; }
        }

        private string akc088;
        /// <summary>
        /// 本年统筹支出累计
        /// </summary>
        public string AKC088
        {
            get { return akc088; }
            set { akc088 = value; }
        }

        private string akc121;
        /// <summary>
        /// 本年大病支出累计
        /// </summary>
        public string AKC121
        {
            get { return akc121; }
            set { akc121 = value; }
        }

        private string akc256;
        /// <summary>
        /// 本次起付标准自付
        /// </summary>
        public string AKC256
        {
            get { return akc256; }
            set { akc256 = value; }
        }

        private string cka050;
        /// <summary>
        /// 本次起付标准
        /// </summary>
        public string CKA050
        {
            get { return cka050; }
            set { cka050 = value; }
        }

        private string akc090;
        /// <summary>
        /// 本年住院次数
        /// </summary>
        public string AKC090
        {
            get { return akc090; }
            set { akc090 = value; }
        }


        private string akc278;
        /// <summary>
        /// 本次进入公务员费用
        /// </summary>
        public string AKC278
        {
            get { return akc278; }
            set { akc278 = value; }
        }

        private string akc279;
        /// <summary>
        /// 本次进入大病部分
        /// </summary>
        public string AKC279
        {
            get { return akc279; }
            set { akc279 = value; }
        }

        private string akc718;
        /// <summary>
        /// 进入其他基金费用
        /// </summary>
        public string AKC718
        {
            get { return akc718; }
            set { akc718 = value; }
        }

        private string zkc036;
        /// <summary>
        /// 超过大病补充封顶线部分
        /// </summary>
        public string ZKC036
        {
            get { return zkc036; }
            set { zkc036 = value; }
        }

        private string akc262;
        /// <summary>
        /// 本次个人帐户应支付金额
        /// </summary>
        public string AKC262
        {
            get { return akc262; }
            set { akc262 = value; }
        }

        private string akc252;
        /// <summary>
        /// 卡结算前余额
        /// </summary>
        public string AKC252
        {
            get { return akc252; }
            set { akc252 = value; }
        }



        private string akc253;
        /// <summary>
        /// 自费费用
        /// </summary>
        public string AKC253
        {
            get { return akc253; }
            set { akc253 = value; }
        }

        private string akc254;
        /// <summary>
        /// 乙类自付
        /// </summary>
        public string AKC254
        {
            get { return akc254; }
            set { akc254 = value; }
        }

        private string akc380;
        /// <summary>
        /// 乙类药自付
        /// </summary>
        public string AKC380
        {
            get { return akc380; }
            set { akc380 = value; }
        }

        private string zkc032;
        /// <summary>
        /// 特检自付
        /// </summary>
        public string ZKC032
        {
            get { return zkc032; }
            set { zkc032 = value; }
        }

        private string zkc034;
        /// <summary>
        /// 特治自付
        /// </summary>
        public string ZKC034
        {
            get { return zkc034; }
            set { zkc034 = value; }
        }

        private string akc740;
        /// <summary>
        /// 统筹分段自付（第1段）
        /// </summary>
        public string AKC740
        {
            get { return akc740; }
            set { akc740 = value; }
        }

        private string akc741;
        /// <summary>
        /// 统筹分段自付（第2段）
        /// </summary>
        public string AKC741
        {
            get { return akc741; }
            set { akc741 = value; }
        }

        private string akc742;
        /// <summary>
        /// 统筹分段自付（第3段）
        /// </summary>
        public string AKC742
        {
            get { return akc742; }
            set { akc742 = value; }
        }

        private string akc743;
        /// <summary>
        /// 统筹分段自付（第4段）
        /// </summary>
        public string AKC743
        {
            get { return akc743; }
            set { akc743 = value; }
        }

        private string akc744;
        /// <summary>
        /// 统筹分段自付（第5段）
        /// </summary>
        public string AKC744
        {
            get { return akc744; }
            set { akc744 = value; }
        }

        private string akc745;
        /// <summary>
        /// 统筹分段自付（第6段）
        /// </summary>
        public string AKC745
        {
            get { return akc745; }
            set { akc745 = value; }
        }

        private string akc746;
        /// <summary>
        /// 统筹支出（第1段）
        /// </summary>
        public string AKC746
        {
            get { return akc746; }
            set { akc746 = value; }
        }

        private string akc747;
        /// <summary>
        /// 统筹支出（第2段）
        /// </summary>
        public string AKC747
        {
            get { return akc747; }
            set { akc747 = value; }
        }

        private string akc748;
        /// <summary>
        /// 统筹支出（第3段）
        /// </summary>
        public string AKC748
        {
            get { return akc748; }
            set { akc748 = value; }
        }

        private string akc749;
        /// <summary>
        /// 统筹支出（第4段）
        /// </summary>
        public string AKC749
        {
            get { return akc749; }
            set { akc749 = value; }
        }

        private string akc750;
        /// <summary>
        /// 统筹支出（第5段）
        /// </summary>
        public string AKC750
        {
            get { return akc750; }
            set { akc750 = value; }
        }

        private string akc751;
        /// <summary>
        /// 统筹支出（第6段）
        /// </summary>
        public string AKC751
        {
            get { return akc751; }
            set { akc751 = value; }
        }

        private string akc752;
        /// <summary>
        /// 公务员自付
        /// </summary>
        public string AKC752
        {
            get { return akc752; }
            set { akc752 = value; }
        }

        private string akc753;
        /// <summary>
        /// 其他基金自付
        /// </summary>
        public string AKC753
        {
            get { return akc753; }
            set { akc753 = value; }
        }

        private string akc258;
        /// <summary>
        /// 超过封顶线个人自付
        /// </summary>
        public string AKC258
        {
            get { return akc258; }
            set { akc258 = value; }
        }

        private string bka067;
        /// <summary>
        /// 甲类药总费用
        /// </summary>
        public string BKA067
        {
            get { return bka067; }
            set { bka067 = value; }
        }

        private string bka068;
        /// <summary>
        /// 乙类药总费用
        /// </summary>
        public string BKA068
        {
            get { return bka068; }
            set { bka068 = value; }
        }

        private string bka069;
        /// <summary>
        /// 丙类药总费用
        /// </summary>
        public string BKA069
        {
            get { return bka069; }
            set { bka069 = value; }
        }

        private string akc368;
        /// <summary>
        /// 普通检查费用
        /// </summary>
        public string AKC368
        {
            get { return akc368; }
            set { akc368 = value; }
        }

        private string akc369;
        /// <summary>
        /// 特殊检查费用
        /// </summary>
        public string AKC369
        {
            get { return akc369; }
            set { akc369 = value; }
        }

        private string akc370;
        /// <summary>
        /// 自费检查费用
        /// </summary>
        public string AKC370
        {
            get { return akc370; }
            set { akc370 = value; }
        }

        private string akc374;
        /// <summary>
        /// 普通治疗费用
        /// </summary>
        public string AKC374
        {
            get { return akc374; }
            set { akc374 = value; }
        }

        private string akc375;
        /// <summary>
        /// 特殊治疗费用
        /// </summary>
        public string AKC375
        {
            get { return akc375; }
            set { akc375 = value; }
        }

        private string akc376;
        /// <summary>
        /// 自费治疗费用
        /// </summary>
        public string AKC376
        {
            get { return akc376; }
            set { akc376 = value; }
        }

        private string akc754;
        /// <summary>
        /// 总的个人自付金额
        /// </summary>
        public string AKC754
        {
            get { return akc754; }
            set { akc754 = value; }
        }

        private string akc755;
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string AKC755
        {
            get { return akc755; }
            set { akc755 = value; }
        }

        private string akc756;
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string AKC756
        {
            get { return akc756; }
            set { akc756 = value; }
        }

        private string akc757;
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string AKC757
        {
            get { return akc757; }
            set { akc757 = value; }
        }

        private string akc758;
        /// <summary>
        /// 预留字段5
        /// </summary>
        public string AKC758
        {
            get { return akc758; }
            set { akc758 = value; }
        }


        private string akc759;
        /// <summary>
        /// 基本账户
        /// </summary>
        public string AKC759
        {
            get { return akc759; }
            set { akc759 = value; }
        }

        private string akc760;
        /// <summary>
        /// 4%补充账户
        /// </summary>
        public string AKC760
        {
            get { return akc760; }
            set { akc760 = value; }
        }

        private string akc761;
        /// <summary>
        /// 10%补充账户
        /// </summary>
        public string AKC761
        {
            get { return akc761; }
            set { akc761 = value; }
        }

        private string akc762;
        /// <summary>
        /// 10%补助账户
        /// </summary>
        public string AKC762
        {
            get { return akc762; }
            set { akc762 = value; }
        }

        private string akc763;
        /// <summary>
        /// 补充账户
        /// </summary>
        public string AKC763
        {
            get { return akc763; }
            set { akc763 = value; }
        }

        private string akc764;
        /// <summary>
        /// 补助账户
        /// </summary>
        public string AKC764
        {
            get { return akc764; }
            set { akc764 = value; }
        }

        private string akc765;
        /// <summary>
        /// 其他账户
        /// </summary>
        public string AKC765
        {
            get { return akc765; }
            set { akc765 = value; }
        }

        private string akc766;
        /// <summary>
        /// 基本统筹
        /// </summary>
        public string AKC766
        {
            get { return akc766; }
            set { akc766 = value; }
        }

        private string akc767;
        /// <summary>
        /// 4%补充统筹
        /// </summary>
        public string AKC767
        {
            get { return akc767; }
            set { akc767 = value; }
        }

        private string akc768;
        /// <summary>
        /// 10%补充统筹
        /// </summary>
        public string AKC768
        {
            get { return akc768; }
            set { akc768 = value; }
        }

        private string akc769;
        /// <summary>
        /// 10%补助统筹
        /// </summary>
        public string AKC769
        {
            get { return akc769; }
            set { akc769 = value; }
        }

        private string akc770;
        /// <summary>
        /// 补充统筹
        /// </summary>
        public string AKC770
        {
            get { return akc770; }
            set { akc770 = value; }
        }

        private string akc771;
        /// <summary>
        /// 补助统筹
        /// </summary>
        public string AKC771
        {
            get { return akc771; }
            set { akc771 = value; }
        }

        private string akc772;
        /// <summary>
        /// 其他统筹
        /// </summary>
        public string AKC772
        {
            get { return akc772; }
            set { akc772 = value; }
        }

        private string akc773;
        /// <summary>
        /// 定点医疗机构支付
        /// </summary>
        public string AKC773
        {
            get { return akc773; }
            set { akc773 = value; }
        }

        private string akc774;
        /// <summary>
        /// 一次性材料费用
        /// </summary>
        public string AKC774
        {
            get { return akc774; }
            set { akc774 = value; }
        }

        private string akc775;
        /// <summary>
        /// 诊疗项目费用
        /// </summary>
        public string AKC775
        {
            get { return akc775; }
            set { akc775 = value; }
        }

        private string akc776;
        /// <summary>
        /// 药品费用
        /// </summary>
        public string AKC776
        {
            get { return akc776; }
            set { akc776 = value; }
        }

        private string akc777;
        /// <summary>
        /// 服务设施费用
        /// </summary>
        public string AKC777
        {
            get { return akc777; }
            set { akc777 = value; }
        }

        private string akc778;
        /// <summary>
        /// 类型（发票）
        /// </summary>
        public string AKC778
        {
            get { return akc778; }
            set { akc778 = value; }
        }

        private string akc779;
        /// <summary>
        /// 医保类型（发票）
        /// </summary>
        public string AKC779
        {
            get { return akc779; }
            set { akc779 = value; }
        }

        private string akc780;
        /// <summary>
        /// 医保统筹支付（发票）
        /// </summary>
        public string AKC780
        {
            get { return akc780; }
            set { akc780 = value; }
        }

        private string akc781;
        /// <summary>
        /// 起付标准累计（发票）
        /// </summary>
        public string AKC781
        {
            get { return akc781; }
            set { akc781 = value; }
        }

        private string akc782;
        /// <summary>
        /// 统筹累计支付（发票）
        /// </summary>
        public string AKC782
        {
            get { return akc782; }
            set { akc782 = value; }
        }

        private string akc785;
        /// <summary>
        /// 医院垫支（发票）
        /// </summary>
        public string AKC785
        {
            get { return akc785; }
            set { akc785 = value; }
        }

        private string akc786;
        /// <summary>
        /// 大病起付标准自付（发票）
        /// </summary>
        public string AKC786
        {
            get { return akc786; }
            set { akc786 = value; }
        }

        private string akc787;
        /// <summary>
        /// 大病起付标准累计（发票）
        /// </summary>
        public string AKC787
        {
            get { return akc787; }
            set { akc787 = value; }
        }

        private string akc788;
        /// <summary>
        /// 超限价（发票）
        /// </summary>
        public string AKC788
        {
            get { return akc788; }
            set { akc788 = value; }
        }

        private string akc789;
        /// <summary>
        /// 是否异地
        /// </summary>
        public string AKC789
        {
            get { return akc789; }
            set { akc789 = value; }
        }



        private string akc190;
        /// <summary>
        /// 门诊住院流水号
        /// </summary>
        public string AKC190
        {
            get { return akc190; }
            set { akc190 = value; }
        }




        private string akc264;
        /// <summary>
        /// 总费用
        /// </summary>
        public string AKC264
        {
            get { return akc264; }
            set { akc264 = value; }
        }


        private string aae072;
        /// <summary>
        /// 单据号
        /// </summary>
        public string AAE072
        {
            get { return aae072; }
            set { aae072 = value; }
        }

        private string akc261;
        /// <summary>
        /// 本次现金支付金额
        /// </summary>
        public string AKC261
        {
            get { return akc261; }
            set { akc261 = value; }
        }

        private string akc087;
        /// <summary>
        /// 结算后卡余额
        /// </summary>
        public string AKC087
        {
            get { return akc087; }
            set { akc087 = value; }
        }

        private string aae040;
        /// <summary>
        /// 结算回退时间
        /// </summary>
        public string AAE040
        {
            get { return aae040; }
            set { aae040 = value; }
        }



        private string bkc462;
        /// <summary>
        /// 病种代码
        /// </summary>
        public string BKC462
        {
            get { return bkc462; }
            set { bkc462 = value; }
        }

        private string aka127;
        /// <summary>
        /// 慢性病种类
        /// </summary>
        public string AKA127
        {
            get { return aka127; }
            set { aka127 = value; }
        }


        private string aae030;
        /// <summary>
        /// 开始日期
        /// </summary>
        public string AAE030
        {
            get { return aae030; }
            set { aae030 = value; }
        }

        private string aae031;
        /// <summary>
        /// 终止日期
        /// </summary>
        public string AAE031
        {
            get { return aae031; }
            set { aae031 = value; }
        }

        private string akb020;
        /// <summary>
        /// 定点医疗机构编码（西药定点）
        /// </summary>
        public string AKB020
        {
            get { return akb020; }
            set { akb020 = value; }
        }

        private string bkb020;
        /// <summary>
        /// 草药定点医疗机构编码
        /// </summary>
        public string BKB020
        {
            get { return bkb020; }
            set { bkb020 = value; }
        }

        private string bae073;
        /// <summary>
        /// 审批编号
        /// </summary>
        public string BAE073
        {
            get { return bae073; }
            set { bae073 = value; }
        }

        private string aka060;
        /// <summary>
        /// 药品编码
        /// </summary>
        public string AKA060
        {
            get { return aka060; }
            set { aka060 = value; }
        }

        private string aka061;
        /// <summary>
        /// 中文名称
        /// </summary>
        public string AKA061
        {
            get { return aka061; }
            set { aka061 = value; }
        }




        private string aka071;
        /// <summary>
        /// 每次用量
        /// </summary>
        public string AKA071
        {
            get { return aka071; }
            set { aka071 = value; }
        }

        private string aka107;
        /// <summary>
        /// 用法
        /// </summary>
        public string AKA107
        {
            get { return aka107; }
            set { aka107 = value; }
        }



        private string akc378;
        /// <summary>
        /// 发送方交易流水号
        /// </summary>
        public string AKC378
        {
            get { return akc378; }
            set { akc378 = value; }
        }

        private string pagecnt;
        /// <summary>
        /// 页码
        /// </summary>
        public string PAGECNT
        {
            get { return pagecnt; }
            set { pagecnt = value; }
        }

        private string akc220;
        /// <summary>
        /// 处方号
        /// </summary>
        public string AKC220
        {
            get { return akc220; }
            set { akc220 = value; }
        }

        private string akc221;
        /// <summary>
        /// 处方日期
        /// </summary>
        public string AKC221
        {
            get { return akc221; }
            set { akc221 = value; }
        }





        private string akc516;
        /// <summary>
        /// 医院收费项目名称
        /// </summary>
        public string AKC516
        {
            get { return akc516; }
            set { akc516 = value; }
        }

        private string akc225;
        /// <summary>
        /// 单价
        /// </summary>
        public string AKC225
        {
            get { return akc225; }
            set { akc225 = value; }
        }

        private string akc226;
        /// <summary>
        /// 数量
        /// </summary>
        public string AKC226
        {
            get { return akc226; }
            set { akc226 = value; }
        }

        private string akc227;
        /// <summary>
        /// 总额
        /// </summary>
        public string AKC227
        {
            get { return akc227; }
            set { akc227 = value; }
        }




        private string akc268;
        /// <summary>
        /// 超限价金额
        /// </summary>
        public string AKC268
        {
            get { return akc268; }
            set { akc268 = value; }
        }




        private string akc604;
        /// <summary>
        /// 规格
        /// </summary>
        public string AKC604
        {
            get { return akc604; }
            set { akc604 = value; }
        }

        private string akc281;
        /// <summary>
        /// 发送方交易流水号
        /// </summary>
        public string AKC281
        {
            get { return akc281; }
            set { akc281 = value; }
        }

        private string pagesize;
        /// <summary>
        /// 总页数
        /// </summary>
        public string PAGESIZE
        {
            get { return pagesize; }
            set { pagesize = value; }
        }

        private string akc224;
        /// <summary>
        /// 收费项目类别
        /// </summary>
        public string AKC224
        {
            get { return akc224; }
            set { akc224 = value; }
        }

        private string akc515;
        /// <summary>
        /// 医院收费项目编码
        /// </summary>
        public string AKC515
        {
            get { return akc515; }
            set { akc515 = value; }
        }



        private string ake001;
        /// <summary>
        /// 医保目录编码
        /// </summary>
        public string AKE001
        {
            get { return ake001; }
            set { ake001 = value; }
        }

        private string ake002;
        /// <summary>
        /// 医保目录名称
        /// </summary>
        public string AKE002
        {
            get { return ake002; }
            set { ake002 = value; }
        }

        private string aka065;
        /// <summary>
        /// 收费项目等级
        /// </summary>
        public string AKA065
        {
            get { return aka065; }
            set { aka065 = value; }
        }

        private string aka068;
        /// <summary>
        /// 最高限价
        /// </summary>
        public string AKA068
        {
            get { return aka068; }
            set { aka068 = value; }
        }

        private string aka069;
        /// <summary>
        /// 自付比例
        /// </summary>
        public string AKA069
        {
            get { return aka069; }
            set { aka069 = value; }
        }

        private string aka063;
        /// <summary>
        /// 收费类别
        /// </summary>
        public string AKA063
        {
            get { return aka063; }
            set { aka063 = value; }
        }

        private string aae013;
        /// <summary>
        /// 限制使用信息
        /// </summary>
        public string AAE013
        {
            get { return aae013; }
            set { aae013 = value; }
        }

        private string bkc002;
        /// <summary>
        /// 对照关系审批状态
        /// </summary>
        public string BKC002
        {
            get { return bkc002; }
            set { bkc002 = value; }
        }

        private string aka120;
        /// <summary>
        /// 病种代码
        /// </summary>
        public string AKA120
        {
            get { return aka120; }
            set { aka120 = value; }
        }

        private string aka121;
        /// <summary>
        /// 病种名称
        /// </summary>
        public string AKA121
        {
            get { return aka121; }
            set { aka121 = value; }
        }

        private string aka123;
        /// <summary>
        /// 疾病类别
        /// </summary>
        public string AKA123
        {
            get { return aka123; }
            set { aka123 = value; }
        }

        private string bkc192start;
        /// <summary>
        /// 入院开始日期
        /// </summary>
        public string BKC192START
        {
            get { return bkc192start; }
            set { bkc192start = value; }
        }

        private string bkc192end;
        /// <summary>
        /// 入院终止日期
        /// </summary>
        public string BKC192END
        {
            get { return bkc192end; }
            set { bkc192end = value; }
        }

        private string aac003;
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string AAC003
        {
            get { return aac003; }
            set { aac003 = value; }
        }

        private string aaz500;
        /// <summary>
        /// 社保卡号
        /// </summary>
        public string AAZ500
        {
            get { return aaz500; }
            set { aaz500 = value; }
        }

        private string aac001;
        /// <summary>
        /// 个人流水号
        /// </summary>
        public string AAC001
        {
            get { return aac001; }
            set { aac001 = value; }
        }

        private string akc021;
        /// <summary>
        /// 医疗人员类别
        /// </summary>
        public string AKC021
        {
            get { return akc021; }
            set { akc021 = value; }
        }

        private string bkc378;
        /// <summary>
        /// 发送方交易流水号
        /// </summary>
        public string BKC378
        {
            get { return bkc378; }
            set { bkc378 = value; }
        }

        private string aka130;
        /// <summary>
        /// 医疗类别
        /// </summary>
        public string AKA130
        {
            get { return aka130; }
            set { aka130 = value; }
        }

        private string aae100;
        /// <summary>
        /// 是否有效
        /// </summary>
        public string AAE100
        {
            get { return aae100; }
            set { aae100 = value; }
        }
    }
}
