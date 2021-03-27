﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
   public class NetPayTradeRefundIn
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
        private String czyh="";//	操作员号
       /// <summary>
        /// 操作员号
       /// </summary>
        public String Czyh
        {
            get { return czyh; }
            set { czyh = value; }
        }
        private String nonce_str="";//	随机字符串
       /// <summary>
       /// 
       /// </summary>
        public String Nonce_str
        {
            get { return nonce_str; }
            set { nonce_str = value; }
        }
        private String outRefundNo="";//	退费收据号
       /// <summary>
        /// 退费收据号
       /// </summary>
        public String OutRefundNo
        {
            get { return outRefundNo; }
            set { outRefundNo = value; }
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
        private String storeId="";//	商户编号
       /// <summary>
        /// 商户编号
       /// </summary>
        public String StoreId
        {
            get { return storeId; }
            set { storeId = value; }
        }
        private String subject="";//	退费说明
       /// <summary>
        /// 退费说明
       /// </summary>
        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private String tfje="";//	总金额
       /// <summary>
        /// 总金额
       /// </summary>
        public String Tfje
        {
            get { return tfje; }
            set { tfje = value; }
        }
        private String zflsh="";//	支付流水号
       /// <summary>
        /// 支付流水号
       /// </summary>
        public String Zflsh
        {
            get { return zflsh; }
            set { zflsh = value; }
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
