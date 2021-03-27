using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
    public class NetPayIn
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
        private String attach="";//	自定义参数
        /// <summary>
        /// 自定义参数
        /// </summary>
        public String Attach
        {
            get { return attach; }
            set { attach = value; }
        }
        private String authCode="";//	支付宝或微信授权码
        /// <summary>
        /// 支付宝或微信授权码
        /// </summary>
        public String AuthCode
        {
            get { return authCode; }
            set { authCode = value; }
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
        private String ddlx="";//	订单类型
        /// <summary>
        /// 订单类型
        /// </summary>
        public String Ddlx
        {
            get { return ddlx; }
            set { ddlx = value; }
        }
        private String ddly="";//	订单来源
        /// <summary>
        /// 订单来源
        /// </summary>
        public String Ddly
        {
            get { return ddly; }
            set { ddly = value; }
        }
        private String ksmc="";//	挂号科室
        /// <summary>
        /// 挂号科室
        /// </summary>
        public String Ksmc
        {
            get { return ksmc; }
            set { ksmc = value; }
        }
        private String hzxm="";//	患者姓名
        /// <summary>
        /// 患者姓名
        /// </summary>
        public String Hzxm
        {
            get { return hzxm; }
            set { hzxm = value; }
        }
        private String sfzh="";//	身份证号
        /// <summary>
        /// 身份证号
        /// </summary>
        public String Sfzh
        {
            get { return sfzh; }
            set { sfzh = value; }
        }
        private String lxdh="";//	联系电话
        /// <summary>
        /// 联系电话
        /// </summary>
        public String Lxdh
        {
            get { return lxdh; }
            set { lxdh = value; }
        }
        private String descriptive="";//	描述
        /// <summary>
        /// 描述
        /// </summary>
        public String Descriptive
        {
            get { return descriptive; }
            set { descriptive = value; }
        }
        private String discountableAmount="0";//	可打折金额
        /// <summary>
        /// 可打折金额
        /// </summary>
        public String DiscountableAmount
        {
            get { return discountableAmount; }
            set { discountableAmount = value; }
        }
        private String goodsTag="";//	商品标识
        /// <summary>
        /// 商品标识
        /// </summary>
        public String GoodsTag
        {
            get { return goodsTag; }
            set { goodsTag = value; }
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
        private String outerOrderNo="";//	收据号
        /// <summary>
        /// 收据号
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
        private String subject="";//	标题
        /// <summary>
        /// 标题
        /// </summary>
        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private String tradeDetail="";//	订单明细
        /// <summary>
        /// 订单明细
        /// </summary>
        public String TradeDetail
        {
            get { return tradeDetail; }
            set { tradeDetail = value; }
        }
        private String undiscountableAmount="";//	不可打折金额
        /// <summary>
        /// 不可打折金额
        /// </summary>
        public String UndiscountableAmount
        {
            get { return undiscountableAmount; }
            set { undiscountableAmount = value; }
        }
        private String ysje="";//	总金额
        /// <summary>
        /// 总金额
        /// </summary>
        public String Ysje
        {
            get { return ysje; }
            set { ysje = value; }
        }
        private String yydm="";//	医院代码
        /// <summary>
        /// 医院代码
        /// </summary>
        public String Yydm
        {
            get { return yydm; }
            set { yydm = value; }
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
        /// 
        /// </summary>
        public String Sign
        {
            get { return sign; }
            set { sign = value; }
        }
       
       
    }
}
