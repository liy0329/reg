using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
   public  class NetPayCancelIn
    {
        private String appCode="40";//	应用编码
       /// <summary>
        /// 应用编码
       /// </summary>
        public String AppCode
        {
            get { return appCode; }
            set { appCode = value; }
        }
        private String orgCode="";//	机构编码
       /// <summary>
        /// 机构编码
       /// </summary>
        public String OrgCode
        {
            get { return orgCode; }
            set { orgCode = value; }
        }
        private String merId="";//	医院商户编码
       /// <summary>
        /// 医院商户编码
       /// </summary>
        public String MerId
        {
            get { return merId; }
            set { merId = value; }
        }
        private String innerOrderNo="";//	系统标识
       /// <summary>
        /// 系统标识
       /// </summary>
        public String InnerOrderNo
        {
            get { return innerOrderNo; }
            set { innerOrderNo = value; }
        }
        private String nonce_str="";//	随机字符串
       /// <summary>
        /// 随机字符串
       /// </summary>
        public String Nonce_str
        {
            get { return nonce_str; }
            set { nonce_str = value; }
        }
        private String paytype="";//	支付方式
       /// <summary>
        /// 支付方式
       /// </summary>
        public String Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        private String outerOrderNo="";//	原收据号
       /// <summary>
        /// 原收据号
       /// </summary>
        public String OuterOrderNo
        {
            get { return outerOrderNo; }
            set { outerOrderNo = value; }
        }
        private String czyh="";//	操作员编号
       /// <summary>
        /// 操作员编号
       /// </summary>
        public String Czyh
        {
            get { return czyh; }
            set { czyh = value; }
        }
        private String cdly="";//	撤单来源
       /// <summary>
        /// 撤单来源
       /// </summary>
        public String Cdly
        {
            get { return cdly; }
            set { cdly = value; }
        }
        private String wkdz="";//	网卡地址
       /// <summary>
        /// 网卡地址
       /// </summary>
        public String Wkdz
        {
            get { return wkdz; }
            set { wkdz = value; }
        }
        private String merchantId="";//	客户端编码
       /// <summary>
        /// 客户端编码
       /// </summary>
        public String MerchantId
        {
            get { return merchantId; }
            set { merchantId = value; }
        }
        private String sign="";//	MD5签名
       /// <summary>
        /// MD5签名
       /// </summary>
        public String Sign
        {
            get { return sign; }
            set { sign = value; }
        }

    }
}
