using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
    class NetPayData
    {
        String outerOrderNo;	//	HIS订单号
        /// <summary>
        /// HIS订单号
        /// </summary>
        public String OuterOrderNo
        {
            get { return outerOrderNo; }
            set { outerOrderNo = value; }
        }
        String merchantId;	//	客户端编码
        /// <summary>
        /// 客户端编码
        /// </summary>
        public String MerchantId
        {
            get { return merchantId; }
            set { merchantId = value; }
        }
        String orgCode;	//	机构编码
        /// <summary>
        /// 机构编码
        /// </summary>
        public String OrgCode
        {
            get { return orgCode; }
            set { orgCode = value; }
        }
        String merId;	//	医院商户编码
        /// <summary>
        /// 医院商户编码
        /// </summary>
        public String MerId
        {
            get { return merId; }
            set { merId = value; }
        }
        String ysje;	//	收费金额
        /// <summary>
        /// 收费金额
        /// </summary>
        public String Ysje
        {
            get { return ysje; }
            set { ysje = value; }
        }
        String innerOrderNo;	//	系统号码
        /// <summary>
        /// 系统号码
        /// </summary>
        public String InnerOrderNo
        {
            get { return innerOrderNo; }
            set { innerOrderNo = value; }
        }
        String tfje;	//	退费金额
        /// <summary>
        /// 退费金额
        /// </summary>
        public String Tfje
        {
            get { return tfje; }
            set { tfje = value; }
        }
        String tradeNo;	//	支付宝流水号
        /// <summary>
        /// 支付宝流水号
        /// </summary>
        public String TradeNo
        {
            get { return tradeNo; }
            set { tradeNo = value; }
        }
        String jyrq;	//	交易时间
        /// <summary>
        /// 交易时间
        /// </summary>
        public String Jyrq
        {
            get { return jyrq; }
            set { jyrq = value; }
        }
        String paytype;	//	支付方式
        /// <summary>
        /// 支付方式
        /// </summary>
        public String Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        String czyh;	//	操作员号
        /// <summary>
        /// 操作员号
        /// </summary>
        public String Czyh
        {
            get { return czyh; }
            set { czyh = value; }
        }
        String storeId;	//	商户编号
        /// <summary>
        /// 商户编号
        /// </summary>
        public String StoreId
        {
            get { return storeId; }
            set { storeId = value; }
        }
        String sourceOuterOrderNo;	//	HIS原订单号
        /// <summary>
        /// HIS原订单号
        /// </summary>
        public String SourceOuterOrderNo
        {
            get { return sourceOuterOrderNo; }
            set { sourceOuterOrderNo = value; }
        }
        String jylx;	//	交易类型
        /// <summary>
        /// 交易类型
        /// </summary>
        public String Jylx
        {
            get { return jylx; }
            set { jylx = value; }
        }
        String ddlx;	//	订单类型
        /// <summary>
        /// 订单类型
        /// </summary>
        public String Ddlx
        {
            get { return ddlx; }
            set { ddlx = value; }
        }
        private string ihsp_id;

        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }

        String ddly;	//	订单来源 1:门诊 2：来源
        /// <summary>
        /// 订单来源
        /// </summary>
        public String Ddly
        {
            get { return ddly; }
            set { ddly = value; }
        }
        String yymc;	//	院区名称
        /// <summary>
        /// 院区名称
        /// </summary>
        public String Yymc
        {
            get { return yymc; }
            set { yymc = value; }
        }
        String ksmc;	//	挂号科室
        /// <summary>
        /// 挂号科室
        /// </summary>
        public String Ksmc
        {
            get { return ksmc; }
            set { ksmc = value; }
        }
        String appCode;	//	应用编码
        /// <summary>
        /// 应用编码
        /// </summary>
        public String AppCode
        {
            get { return appCode; }
            set { appCode = value; }
        }
        String zfzt;	//	支付状态
        /// <summary>
        /// 支付状态
        /// </summary>
        public String Zfzt
        {
            get { return zfzt; }
            set { zfzt = value; }
        }
        private String hzxm = "";//	患者姓名
        /// <summary>
        /// 患者姓名
        /// </summary>
        public String Hzxm
        {
            get { return hzxm; }
            set { hzxm = value; }
        }
        private String sfzh = "";//	身份证号
        /// <summary>
        /// 身份证号
        /// </summary>
        public String Sfzh
        {
            get { return sfzh; }
            set { sfzh = value; }
        }
        private String lxdh = "";//	联系电话
        /// <summary>
        /// 联系电话
        /// </summary>
        public String Lxdh
        {
            get { return lxdh; }
            set { lxdh = value; }
        }
        private string blh;
        /// <summary>
        /// 病历号
        /// </summary>
        public string Blh
        {
            get { return blh; }
            set { blh = value; }
        }

        private string lxdz;
        /// <summary>
        /// 联系地址
        /// </summary>
        public string Lxdz
        {
            get { return lxdz; }
            set { lxdz = value; }
        }

        
    }
}
