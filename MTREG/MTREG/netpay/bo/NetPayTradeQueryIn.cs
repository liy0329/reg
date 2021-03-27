using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
    public class NetPayTradeQueryIn
    {
        private String appCode="40";//	应用编码

        public String AppCode
        {
            get { return appCode; }
            set { appCode = value; }
        }
        private String orgCode="";//	机构编码

        public String OrgCode
        {
            get { return orgCode; }
            set { orgCode = value; }
        }
        private String merId="";//	医院商户编码

        public String MerId
        {
            get { return merId; }
            set { merId = value; }
        }
        private String nonce_str="";//	随机字符串

        public String Nonce_str
        {
            get { return nonce_str; }
            set { nonce_str = value; }
        }
        private String paytype="";//	支付方式

        public String Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        private String outerOrderNo="";//	收据号

        public String OuterOrderNo
        {
            get { return outerOrderNo; }
            set { outerOrderNo = value; }
        }
        private String czyh="";//	操作员编号

        public String Czyh
        {
            get { return czyh; }
            set { czyh = value; }
        }
        private String wkdz="";//	网卡地址

        public String Wkdz
        {
            get { return wkdz; }
            set { wkdz = value; }
        }
        private String zflsh="";//	支付流水号

        public String Zflsh
        {
            get { return zflsh; }
            set { zflsh = value; }
        }
        private String merchantId="";//	客户端编码

        public String MerchantId
        {
            get { return merchantId; }
            set { merchantId = value; }
        }
        private String sign="";//	MD5签名

        public String Sign
        {
            get { return sign; }
            set { sign = value; }
        }

    }
}
