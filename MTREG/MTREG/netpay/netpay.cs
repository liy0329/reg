using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.netpay.bo;
using MTHIS.tools;
using System.Net;
using Newtonsoft.Json;

namespace MTREG.netpay
{
    public class Netpay
    {
       static   WebClient webClient = new WebClient();
        /// <summary>
        /// 4.3.1提交条码支付
        /// </summary>
        /// <param name="netPayIn"></param>
        /// <param name="netPayOut"></param>
        /// <returns></returns>
        public static NetpayRetRes execNetPay(NetPayIn netPayIn, NetPayOut netPayOut)
        {
            string random = DataUtils.getRandom(30);
            netPayIn.Nonce_str = random;
            NetpayRetRes ret = new NetpayRetRes();

            ///
            netPayIn.MerchantId = NetPayIniParam.MerchantId;
            netPayIn.MerId = NetPayIniParam.MerId;
            netPayIn.OrgCode = NetPayIniParam.OrgCode;
            ///
            ret.Ret_flag = true;
           // return ret;

            String stringA =
                        "appCode=" + netPayIn.AppCode + "&"
                        + "authCode=" + netPayIn.AuthCode + "&";
            if (!string.IsNullOrEmpty(netPayIn.Attach))
            {
                stringA += "attach=" + netPayIn.Attach + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Czyh))
            {
                stringA += "czyh=" + netPayIn.Czyh + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Ddlx))
            {
                stringA += "ddlx=" + netPayIn.Ddlx + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Ddly))
            {
                stringA += "ddly=" + netPayIn.Ddly + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Descriptive))
            {
                stringA += "descriptive=" + netPayIn.Descriptive + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.DiscountableAmount))
            {
                stringA += "discountableAmount=" + netPayIn.DiscountableAmount + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.GoodsTag))
            {
                stringA += "goodsTag=" + netPayIn.GoodsTag + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Hzxm))
            {
                stringA += "hzxm=" + netPayIn.Hzxm + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Ksmc))
            {
                stringA += "ksmc=" + netPayIn.Ksmc + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Lxdh))
            {
                stringA += "lxdh=" + netPayIn.Lxdh + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerId))
            {
                stringA += "merId=" + NetPayIniParam.MerId + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerchantId))
            {
                stringA += "merchantId=" + NetPayIniParam.MerchantId + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Nonce_str))
            {
                stringA += "nonce_str=" + netPayIn.Nonce_str + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
            {
                stringA += "orgCode=" + NetPayIniParam.OrgCode + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.OuterOrderNo))
            {
                stringA += "outerOrderNo=" + netPayIn.OuterOrderNo + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Paytype))
            {
                stringA += "paytype=" + netPayIn.Paytype + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Sfzh))
            {
                stringA += "sfzh=" + netPayIn.Sfzh + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.StoreId))
            {
                stringA += "storeId=" + netPayIn.StoreId + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Subject))
            {
                stringA += "subject=" + netPayIn.Subject + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.TradeDetail))
            {
                stringA += "tradeDetail=" + netPayIn.TradeDetail + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.UndiscountableAmount))
            {
                stringA += "undiscountableAmount=" + netPayIn.UndiscountableAmount + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Wkdz))
            {
                stringA += "wkdz=" + netPayIn.Wkdz + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Ysje))
            {
                stringA += "ysje=" + netPayIn.Ysje + "&";
            }
            if (!string.IsNullOrEmpty(netPayIn.Yydm))
            {
                stringA += "yydm=" + netPayIn.Yydm+"&";

            }
            stringA = stringA.Remove(stringA.Length - 1);
           String stringC =
               "appCode=" + netPayIn.AppCode + "&"
                + "authCode=" + netPayIn.AuthCode + "&"
                + "attach=" + netPayIn.Attach + "&"
                + "czyh=" + netPayIn.Czyh + "&"
                + "ddlx=" + netPayIn.Ddlx + "&"
                + "ddly=" + netPayIn.Ddly + "&"
                + "descriptive=" + netPayIn.Descriptive + "&"
                + "discountableAmount=" + netPayIn.DiscountableAmount + "&"
                + "goodsTag=" + netPayIn.GoodsTag + "&"
                + "hzxm=" + netPayIn.Hzxm + "&"
                + "ksmc=" + netPayIn.Ksmc + "&"
                + "lxdh=" + netPayIn.Lxdh + "&"
                + "merId=" + NetPayIniParam.MerId + "&"
                + "merchantId=" + NetPayIniParam.MerchantId + "&"
                + "nonce_str=" + netPayIn.Nonce_str + "&"
                + "orgCode=" + NetPayIniParam.OrgCode + "&"
                + "outerOrderNo=" + netPayIn.OuterOrderNo + "&"
                + "paytype=" + netPayIn.Paytype + "&"
                + "sfzh=" + netPayIn.Sfzh + "&"
                + "storeId=" + netPayIn.StoreId + "&"
                + "subject=" + netPayIn.Subject + "&"
                + "tradeDetail=" + netPayIn.TradeDetail + "&"
                + "undiscountableAmount=" + netPayIn.UndiscountableAmount + "&"
                + "wkdz=" + netPayIn.Wkdz + "&"
                + "ysje=" + netPayIn.Ysje + "&"
                + "yydm=" + netPayIn.Yydm;
          
            string stringSignTemp = stringA + "&key=" + NetPayIniParam.Key;
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringSignTemp, "MD5").ToUpper();
            string stringB = stringC + "&sign=" + sign;
            try
            {
                string url = NetPayIniParam.Basurl + "!execNetPay.do?" + stringB;
                webClient.Encoding = Encoding.UTF8;
                string param = webClient.DownloadString(url);
                if (param == "")
                {
                    ret.Err_mesg = "微信(支付宝) 失败！:返回字符串为空";
                    ret.Errcode = -1;
                    return ret;
                }
                JsonTop topInfo = JsonConvert.DeserializeObject<JsonTop>(param);
                if (topInfo.success.ToUpper() == "TRUE")
                {
                    JsonSuccess json_su = JsonConvert.DeserializeObject<JsonSuccess>(param);
                    netPayOut.OuterOrderNo = json_su.msg.outerOrderNo;
                    netPayOut.TradeNo = json_su.msg.tradeNo;
                    netPayOut.Paytype = json_su.msg.paytype;
                    netPayOut.Amount = json_su.msg.amount;
                    netPayOut.InnerOrderNo = json_su.msg.innerOrderNo;
                    netPayOut.Nonce_str = json_su.nonce_str;
                    netPayOut.Sign = json_su.sign;
                    ret.Ret_flag = true;
                    ret.Errcode = 0;
                    return ret;
                }
                else
                {
                    JsonFail failInfo = JsonConvert.DeserializeObject<JsonFail>(param);
                    if (failInfo.err.Contains("order success pay inprocess"))
                    {
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err + ",errcode:" + failInfo.errcode + "账户余额不足（未开启小额免密）。";

                    }
                    else
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err;
                    LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayIn.OuterOrderNo);
                    ret.Errcode = 1;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                ret.Err_mesg = "-2|微信(支付宝) 失败！:" + ex.ToString();
                ret.Errcode =-2;
                LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayIn.OuterOrderNo);

            }
            return ret;
        }
        /// <summary>
        /// 4.3.2统一下单交易预创建（扫码支付--自助机）
        /// </summary>
        /// <param name="netPayTradePayPrecreateIn"></param>
        /// <param name="netPayTradePayPrecreateOut"></param>
        /// <returns></returns>
        public static NetpayRetRes execNetPayTradePayPrecreate(NetPayTradePayPrecreateIn netPayTradePayPrecreateIn, NetPayTradePayPrecreateOut netPayTradePayPrecreateOut)
        {
              string random = DataUtils.getRandom(30);
            NetpayRetRes ret = new NetpayRetRes();
            String stringA =
                         "appCode=" + netPayTradePayPrecreateIn.AppCode + "&";
                      
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Attach))
            {
                stringA += "attach=" + netPayTradePayPrecreateIn.Attach + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Czyh))
            {
                stringA += "czyh=" + netPayTradePayPrecreateIn.Czyh + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Ddlx))
            {
                stringA += "ddlx=" + netPayTradePayPrecreateIn.Ddlx + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Ddly))
            {
                stringA += "ddly=" + netPayTradePayPrecreateIn.Ddly + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Descriptive))
            {
                stringA += "descriptive=" + netPayTradePayPrecreateIn.Descriptive + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.DiscountableAmount))
            {
                stringA += "discountableAmount=" + netPayTradePayPrecreateIn.DiscountableAmount + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.GoodsTag))
            {
                stringA += "goodsTag=" + netPayTradePayPrecreateIn.GoodsTag + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Hzxm))
            {
                stringA += "hzxm=" + netPayTradePayPrecreateIn.Hzxm + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Ksmc))
            {
                stringA += "ksmc=" + netPayTradePayPrecreateIn.Ksmc + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Lxdh))
            {
                stringA += "lxdh=" + netPayTradePayPrecreateIn.Lxdh + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerId))
            {
                stringA += "merId=" + NetPayIniParam.MerId + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerchantId))
            {
                stringA += "merchantId=" + NetPayIniParam.MerchantId + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Nonce_str))
            {
                stringA += "nonce_str=" + netPayTradePayPrecreateIn.Nonce_str + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
            {
                stringA += "orgCode=" + NetPayIniParam.OrgCode + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.OuterOrderNo))
            {
                stringA += "outerOrderNo=" + netPayTradePayPrecreateIn.OuterOrderNo + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Paytype))
            {
                stringA += "paytype=" + netPayTradePayPrecreateIn.Paytype + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Sfzh))
            {
                stringA += "sfzh=" + netPayTradePayPrecreateIn.Sfzh + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.StoreId))
            {
                stringA += "storeId=" + netPayTradePayPrecreateIn.StoreId + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Subject))
            {
                stringA += "subject=" + netPayTradePayPrecreateIn.Subject + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Timeout_express))
            {
                stringA += "timeout_express=" + netPayTradePayPrecreateIn.Timeout_express + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.TradeDetail))
            {
                stringA += "tradeDetail=" + netPayTradePayPrecreateIn.TradeDetail + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.UndiscountableAmount))
            {
                stringA += "undiscountableAmount=" + netPayTradePayPrecreateIn.UndiscountableAmount + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Wkdz))
            {
                stringA += "wkdz=" + netPayTradePayPrecreateIn.Wkdz + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Ysje))
            {
                stringA += "ysje=" + netPayTradePayPrecreateIn.Ysje + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradePayPrecreateIn.Yydm))
            {
                stringA += "yydm=" + netPayTradePayPrecreateIn.Yydm + "&";

            }
            stringA = stringA.Remove(stringA.Length - 1);
            String stringC =
                "appCode=" + netPayTradePayPrecreateIn.AppCode + "&"
                 + "attach=" + netPayTradePayPrecreateIn.Attach + "&"
                 + "czyh=" + netPayTradePayPrecreateIn.Czyh + "&"
                 + "ddlx=" + netPayTradePayPrecreateIn.Ddlx + "&"
                 + "ddly=" + netPayTradePayPrecreateIn.Ddly + "&"
                 + "descriptive=" + netPayTradePayPrecreateIn.Descriptive + "&"
                 + "discountableAmount=" + netPayTradePayPrecreateIn.DiscountableAmount + "&"
                 + "goodsTag=" + netPayTradePayPrecreateIn.GoodsTag + "&"
                 + "hzxm=" + netPayTradePayPrecreateIn.Hzxm + "&"
                 + "ksmc=" + netPayTradePayPrecreateIn.Ksmc + "&"
                 + "lxdh=" + netPayTradePayPrecreateIn.Lxdh + "&"
                 + "merId=" + NetPayIniParam.MerId + "&"
                 + "merchantId=" + NetPayIniParam.MerchantId + "&"
                 + "nonce_str=" + netPayTradePayPrecreateIn.Nonce_str + "&"
                 + "orgCode=" + NetPayIniParam.OrgCode + "&"
                 + "outerOrderNo=" + netPayTradePayPrecreateIn.OuterOrderNo + "&"
                 + "paytype=" + netPayTradePayPrecreateIn.Paytype + "&"
                 + "sfzh=" + netPayTradePayPrecreateIn.Sfzh + "&"
                 + "storeId=" + netPayTradePayPrecreateIn.StoreId + "&"
                 + "subject=" + netPayTradePayPrecreateIn.Subject + "&"
                 + "timeout_express=" + netPayTradePayPrecreateIn.Timeout_express + "&"
                 + "tradeDetail=" + netPayTradePayPrecreateIn.TradeDetail + "&"
                 + "undiscountableAmount=" + netPayTradePayPrecreateIn.UndiscountableAmount + "&"
                 + "wkdz=" + netPayTradePayPrecreateIn.Wkdz + "&"
                 + "ysje=" + netPayTradePayPrecreateIn.Ysje + "&"
                 + "yydm=" + netPayTradePayPrecreateIn.Yydm;

            string stringSignTemp = stringA + "&key=" + NetPayIniParam.Key;
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringSignTemp, "MD5").ToUpper();
            string stringB = stringC + "&sign=" + sign;

            try
            {
                string url = NetPayIniParam.Basurl + "!execNetPayTradePayPrecreate.do?" + stringB;
                webClient.Encoding = Encoding.UTF8;
                string param = webClient.DownloadString(url);
                if (param == "")
                {
                    ret.Err_mesg = "微信(支付宝) 失败！:返回字符串为空";
                    ret.Errcode = -1;
                    return ret;
                }
                JsonTop topInfo = JsonConvert.DeserializeObject<JsonTop>(param);
                if (topInfo.success.ToUpper() == "TRUE")
                {
                    JsonSuccess json_su = JsonConvert.DeserializeObject<JsonSuccess>(param);
                    netPayTradePayPrecreateOut.OuterOrderNo = json_su.msg.outerOrderNo;
                    netPayTradePayPrecreateOut.QrCode = json_su.msg.qrCode;
                    netPayTradePayPrecreateOut.Amount = json_su.msg.amount;
                    netPayTradePayPrecreateOut.InnerOrderNo = json_su.msg.innerOrderNo;
                    netPayTradePayPrecreateOut.Nonce_str = json_su.nonce_str;
                    netPayTradePayPrecreateOut.Sign = json_su.sign;
              
                    ret.Ret_flag = true;
                    ret.Errcode = 0;
                    return ret;

                }
                else
                {
                    JsonFail failInfo = JsonConvert.DeserializeObject<JsonFail>(param);
                    if (failInfo.err.Contains("order success pay inprocess"))
                    {
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err + ",errcode:" + failInfo.errcode + "账户余额不足（未开启小额免密）。";

                    }
                    else
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err;
                    LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayTradePayPrecreateIn.OuterOrderNo);
                    ret.Errcode = 1;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                ret.Err_mesg = "-2|微信(支付宝) 失败！:" + ex.ToString();
                ret.Errcode = -2;
                LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayTradePayPrecreateIn.OuterOrderNo);

            }
            return ret;
        }
        /// <summary>
        /// 4.3.3*******查询订单（自助机）
        /// </summary>
        /// <param name="netPayTradeQueryIn"></param>
        /// <param name="netPayTradeQueryOut"></param>
        /// <returns></returns>
        public static NetpayRetRes execNetPayTradeQuery(NetPayTradeQueryIn netPayTradeQueryIn, NetPayTradeQueryOut netPayTradeQueryOut)
        {


               string random = DataUtils.getRandom(30);
            NetpayRetRes ret = new NetpayRetRes();
            netPayTradeQueryIn.Nonce_str = random;
            String stringA =
                 "appCode=" + netPayTradeQueryIn.AppCode + "&";
            if (!string.IsNullOrEmpty(netPayTradeQueryIn.Czyh))
           {
                stringA += "czyh=" + netPayTradeQueryIn.Czyh + "&";
           }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerId))
            {
                stringA += "merId=" + NetPayIniParam.MerId + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerchantId))
            {
                stringA += "merchantId=" + NetPayIniParam.MerchantId + "&";
            }
            stringA += "nonce_str=" + netPayTradeQueryIn.Nonce_str + "&";
            if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
            {
                stringA += "orgCode=" + NetPayIniParam.OrgCode + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
            {
                stringA += "outerOrderNo=" + netPayTradeQueryIn.OuterOrderNo + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
            {
                stringA += "paytype=" + netPayTradeQueryIn.Paytype + "&";
            }
             if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
            {
                stringA += "wkdz=" + netPayTradeQueryIn.Wkdz + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
            {
                 stringA += "zflsh=" + netPayTradeQueryIn.Zflsh + "&";
            }
            stringA = stringA.Substring(0, stringA.Length - 1);
            string stringC =
                 "appCode=" + netPayTradeQueryIn.AppCode + "&"
                + "czyh=" + netPayTradeQueryIn.Czyh + "&"
                + "merId=" + NetPayIniParam.MerId + "&"
                + "merchantId=" + NetPayIniParam.MerchantId + "&"
                + "nonce_str=" + netPayTradeQueryIn.Nonce_str + "&"
                + "orgCode=" + NetPayIniParam.OrgCode + "&"
                + "outerOrderNo=" + netPayTradeQueryIn.OuterOrderNo + "&"
                + "paytype=" + netPayTradeQueryIn.Paytype + "&"
                + "wkdz=" + netPayTradeQueryIn.Wkdz + "&"
                + "zflsh=" + netPayTradeQueryIn.Zflsh ;


            string stringSignTemp = stringA + "&key=" + NetPayIniParam.Key;
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringSignTemp, "MD5").ToUpper();
            string stringB = stringC + "&sign=" + sign;

            try
            {
                string url = NetPayIniParam.Basurl + "!execNetPayTradeQuery.do?" + stringB;
                webClient.Encoding = Encoding.UTF8;
                string param = webClient.DownloadString(url);
                if (param == "")
                {
                    ret.Err_mesg = "微信(支付宝) 失败！:返回字符串为空";
                    ret.Errcode = -1;
                    return ret;
                }
                JsonTop topInfo = JsonConvert.DeserializeObject<JsonTop>(param);
                if (topInfo.success.ToUpper() == "TRUE")
                {
                    JsonSuccess json_su = JsonConvert.DeserializeObject<JsonSuccess>(param);
                    netPayTradeQueryOut.OuterOrderNo = json_su.msg.outerOrderNo;
                    netPayTradeQueryOut.TradeNo = json_su.msg.tradeNo;
                    netPayTradeQueryOut.TradeStatus = json_su.msg.tradeStatus;
                    netPayTradeQueryOut.Amount = json_su.msg.amount;
                    netPayTradeQueryOut.InnerOrderNo = json_su.msg.innerOrderNo;
                    netPayTradeQueryOut.Nonce_str = json_su.nonce_str;
                    netPayTradeQueryOut.Sign = json_su.sign;
                    ret.Ret_flag = true;
                    ret.Errcode = 0;
                    return ret;

                }
                else
                {
                    JsonFail failInfo = JsonConvert.DeserializeObject<JsonFail>(param);
                    if (failInfo.err.Contains("order success pay inprocess"))
                    {
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err + ",errcode:" + failInfo.errcode + "账户余额不足（未开启小额免密）。";

                    }
                    else
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err;
                    LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayTradeQueryIn.OuterOrderNo);
                    ret.Errcode = 1;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                ret.Err_mesg = "2|微信(支付宝) 失败！:" + ex.ToString();
                ret.Errcode = 2;
                LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayTradeQueryIn.OuterOrderNo);

            }
            return ret;
        }
        /// <summary>
        /// 4.3.4**********撤销订单
        /// </summary>
        /// <param name="netPayCancelIn"></param>
        /// <param name="netPayCancelOut"></param>
        /// <returns></returns>
        public static NetpayRetRes execNetPayCancel(NetPayCancelIn netPayCancelIn, NetPayCancelOut netPayCancelOut)
        {
           string random = DataUtils.getRandom(30);
           netPayCancelIn.Nonce_str = random;
            NetpayRetRes ret = new NetpayRetRes();
            String stringA =
                "appCode=" + netPayCancelIn.AppCode + "&";
            if (!string.IsNullOrEmpty(netPayCancelIn.Cdly))
            {
                stringA += "cdly=" + netPayCancelIn.Cdly + "&";
            }
            if (!string.IsNullOrEmpty(netPayCancelIn.Czyh))
            {
                stringA += "czyh=" + netPayCancelIn.Czyh + "&";
            }
            if (!string.IsNullOrEmpty(netPayCancelIn.InnerOrderNo))
            {
                stringA += "innerOrderNo=" + netPayCancelIn.InnerOrderNo + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerId))
            {
                stringA += "merId=" + NetPayIniParam.MerId + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerchantId))
            {
                stringA += "merchantId=" + NetPayIniParam.MerchantId + "&";
            }
            if (!string.IsNullOrEmpty(netPayCancelIn.Nonce_str))
            {
                stringA += "nonce_str=" + netPayCancelIn.Nonce_str + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
            {
                stringA += "orgCode=" + NetPayIniParam.OrgCode + "&";
            }
            if (!string.IsNullOrEmpty(netPayCancelIn.OuterOrderNo))
            {
                stringA += "outerOrderNo=" + netPayCancelIn.OuterOrderNo + "&";
            }
            if (!string.IsNullOrEmpty(netPayCancelIn.Paytype))
            {
                stringA += "paytype=" + netPayCancelIn.Paytype + "&"; 
            }
            if (!string.IsNullOrEmpty(netPayCancelIn.Wkdz))
            {
                stringA += "wkdz=" + netPayCancelIn.Wkdz + "&"; 
            }
            stringA = stringA.Remove(stringA.Length - 1);
            String stringC =
               "appCode=" + netPayCancelIn.AppCode + "&"
               + "cdly=" + netPayCancelIn.Cdly + "&"
               + "czyh=" + netPayCancelIn.Czyh + "&"
               + "innerOrderNo=" + netPayCancelIn.InnerOrderNo + "&"
               + "merId=" + NetPayIniParam.MerId + "&"
               + "merchantId=" + NetPayIniParam.MerchantId + "&"
               + "nonce_str=" + netPayCancelIn.Nonce_str + "&"
               + "orgCode=" + NetPayIniParam.OrgCode + "&"
               + "outerOrderNo=" + netPayCancelIn.OuterOrderNo + "&"
               + "paytype=" + netPayCancelIn.Paytype+"&"
               + "wkdz=" + netPayCancelIn.Wkdz;

            string stringSignTemp = stringA + "&key=" + NetPayIniParam.Key.Trim();
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringSignTemp, "MD5").ToUpper();
            string stringB = stringC + "&sign=" + sign;

            try
            {
                string url = NetPayIniParam.Basurl + "!execNetPayCancel.do?" + stringB;
                webClient.Encoding = Encoding.UTF8;
                string param = webClient.DownloadString(url);
                if (param == "")
                {
                    ret.Err_mesg = "微信(支付宝) 失败！:返回字符串为空";
                    ret.Errcode = -1;
                    return ret;
                }
                JsonTop topInfo = JsonConvert.DeserializeObject<JsonTop>(param);
                if (topInfo.success.ToUpper() == "TRUE")
                {
                    JsonSuccess json_su = JsonConvert.DeserializeObject<JsonSuccess>(param);
                    netPayCancelOut.OuterOrderNo = json_su.msg.outerOrderNo;
                    netPayCancelOut.Paytype = json_su.msg.paytype;
                    netPayCancelOut.Amount = json_su.msg.amount;
                    netPayCancelOut.InnerOrderNo = json_su.msg.innerOrderNo;
                    netPayCancelOut.Nonce_str = json_su.nonce_str;
                    netPayCancelOut.Sign = json_su.sign;
                    ret.Ret_flag = true;
                    ret.Errcode = 0;
                    return ret;

                }
                else
                {
                    JsonFail failInfo = JsonConvert.DeserializeObject<JsonFail>(param);
                    if (failInfo.err.Contains("order success pay inprocess"))
                    {
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err + ",errcode:" + failInfo.errcode + "账户余额不足（未开启小额免密）。";

                    }
                    else
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err;
                    LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayCancelIn.OuterOrderNo);
                    ret.Errcode = 1;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                ret.Err_mesg = "-2|微信(支付宝) 失败！:" + ex.ToString();
                ret.Errcode = -2;
                LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayCancelIn.OuterOrderNo);

            }
            return ret;
        }
        /// <summary>
        /// 4.3.5********申请退款(支持部分退)
        /// </summary>
        /// <param name="netPayTradeRefundIn"></param>
        /// <param name="netPayTradeRefundOut"></param>
        /// <returns></returns>
        public static NetpayRetRes execNetPayTradeRefund(NetPayTradeRefundIn netPayTradeRefundIn, NetPayTradeRefundOut netPayTradeRefundOut)
        {
          
            string random = DataUtils.getRandom(30);
            NetpayRetRes ret = new NetpayRetRes();
            netPayTradeRefundIn.Nonce_str = random;
            String stringA =
                    "appCode=" + netPayTradeRefundIn.AppCode + "&";
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.Czyh))
            {
                stringA += "czyh=" + netPayTradeRefundIn.Czyh + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerId))
            {
                stringA += "merId=" + NetPayIniParam.MerId + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.MerchantId))
            {
                stringA += "merchantId=" + NetPayIniParam.MerchantId + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.Nonce_str))
            {
                stringA += "nonce_str=" + netPayTradeRefundIn.Nonce_str + "&";
            }
            if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
            {
                stringA += "orgCode=" + NetPayIniParam.OrgCode + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.OutRefundNo))
            {
                stringA += "outRefundNo=" + netPayTradeRefundIn.OutRefundNo + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.OuterOrderNo))
            {
                stringA += "outerOrderNo=" + netPayTradeRefundIn.OuterOrderNo + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.Paytype))
            {
                stringA += "paytype=" + netPayTradeRefundIn.Paytype + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.StoreId))
            {
                stringA += "storeId=" + netPayTradeRefundIn.StoreId + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.Subject))
            {
                stringA += "subject=" + netPayTradeRefundIn.Subject + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.Tfje))
            {
                stringA += "tfje=" + netPayTradeRefundIn.Tfje + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.Wkdz))
            {
                stringA += "wkdz=" + netPayTradeRefundIn.Wkdz + "&";
            }
            if (!string.IsNullOrEmpty(netPayTradeRefundIn.Zflsh))
            {
                stringA += "zflsh=" + netPayTradeRefundIn.Zflsh+"&";
            }
            stringA = stringA.Remove(stringA.Length - 1);
            String stringC =
                    "appCode=" + netPayTradeRefundIn.AppCode + "&"
                    + "czyh=" + netPayTradeRefundIn.Czyh + "&"   //
                    + "merId=" + NetPayIniParam.MerId + "&"
                    + "merchantId=" + NetPayIniParam.MerchantId + "&"
                    + "nonce_str=" + netPayTradeRefundIn.Nonce_str + "&"
                    + "orgCode=" + NetPayIniParam.OrgCode + "&"
                    + "outRefundNo=" + netPayTradeRefundIn.OutRefundNo + "&"
                    + "outerOrderNo=" + netPayTradeRefundIn.OuterOrderNo + "&"
                    + "paytype=" + netPayTradeRefundIn.Paytype + "&"
                    + "storeId=" + netPayTradeRefundIn.StoreId + "&"
                    + "subject=" + netPayTradeRefundIn.Subject + "&"
                    + "tfje=" + netPayTradeRefundIn.Tfje + "&"
                    + "wkdz=" + netPayTradeRefundIn.Wkdz + "&"
                    + "zflsh=" + netPayTradeRefundIn.Zflsh ;
            string stringSignTemp = stringA + "&key=" + NetPayIniParam.Key;
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringSignTemp, "MD5").ToUpper();
            string stringB = stringC + "&sign=" + sign;

            try
            {
                string url = NetPayIniParam.Basurl + "!execNetPayTradeRefund.do?" + stringB;
                webClient.Encoding = Encoding.UTF8;
                string param = webClient.DownloadString(url);
                if (param == "")
                {
                    ret.Err_mesg = "微信(支付宝) 失败！:返回字符串为空";
                    ret.Errcode = -1;
                    return ret;
                }
                JsonTop topInfo = JsonConvert.DeserializeObject<JsonTop>(param);
                if (topInfo.success.ToUpper() == "TRUE")
                {
                    JsonSuccess json_su = JsonConvert.DeserializeObject<JsonSuccess>(param);
                    netPayTradeRefundOut.OuterOrderNo = json_su.msg.outerOrderNo;
                    netPayTradeRefundOut.Paytype = json_su.msg.paytype;
                    netPayTradeRefundOut.TradeNo = json_su.msg.tradeNo;
                    netPayTradeRefundOut.Amount = json_su.msg.amount;
                    netPayTradeRefundOut.InnerOrderNo = json_su.msg.innerOrderNo;
                    netPayTradeRefundOut.Nonce_str = json_su.nonce_str;
                    ret.Ret_flag = true;
                    ret.Errcode = 0;
                    return ret;

                }
                else
                {
                    JsonFail failInfo = JsonConvert.DeserializeObject<JsonFail>(param);
                    if (failInfo.err.Contains("order success pay inprocess"))
                    {
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err + ",errcode:" + failInfo.errcode + "账户余额不足（未开启小额免密）。";

                    }
                    else
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err;
                    LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayTradeRefundIn.OuterOrderNo);
                    ret.Errcode = 1;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                ret.Err_mesg = "2|微信(支付宝) 失败！:" + ex.ToString();
                ret.Errcode = 2;
                LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayTradeRefundIn.OuterOrderNo);

            }
            return ret;

        }
        /// <summary>
        /// 4.3.6查询退款
        /// </summary>
        /// <param name="netPayTradeRefundQueryIn"></param>
        /// <param name="netPayTradeRefundQueryOut"></param>
        /// <returns></returns>
        public static NetpayRetRes execNetPayTradeRefundQuery(NetPayTradeRefundQueryIn netPayTradeRefundQueryIn, NetPayTradeRefundQueryOut netPayTradeRefundQueryOut)
        {
            string random = DataUtils.getRandom(30);
            netPayTradeRefundQueryIn.Nonce_str = random;
            NetpayRetRes ret = new NetpayRetRes();
            String stringA = "";
                 if(!string.IsNullOrEmpty(netPayTradeRefundQueryIn.AppCode))
                 {
                     stringA +="appCode=" + netPayTradeRefundQueryIn.AppCode + "&";
                 }
                 if (!string.IsNullOrEmpty(netPayTradeRefundQueryIn.Czyh))
                 {
                     stringA += "czyh=" + netPayTradeRefundQueryIn.Czyh + "&";
                 }
                 if (!string.IsNullOrEmpty(NetPayIniParam.MerId))
                 {
                     stringA += "merId=" + NetPayIniParam.MerId + "&";
                 }
                 if (!string.IsNullOrEmpty(NetPayIniParam.MerchantId))
                 {
                     stringA += "merchantId=" + NetPayIniParam.MerchantId + "&";
                 }
                 if (!string.IsNullOrEmpty(netPayTradeRefundQueryIn.Nonce_str))
                 {
                     stringA += "nonce_str=" + netPayTradeRefundQueryIn.Nonce_str + "&";
                 }
                 if (!string.IsNullOrEmpty(NetPayIniParam.OrgCode))
                 {
                     stringA += "orgCode=" + NetPayIniParam.OrgCode + "&";
                 }
                 if (!string.IsNullOrEmpty(netPayTradeRefundQueryIn.OutRefundNo))
                 {
                     stringA += "outRefundNo=" + netPayTradeRefundQueryIn.OutRefundNo + "&";
                 }
                 if (!string.IsNullOrEmpty(netPayTradeRefundQueryIn.OuterOrderNo))
                 {
                     stringA += "outerOrderNo=" + netPayTradeRefundQueryIn.OuterOrderNo + "&";
                 }
                 if (!string.IsNullOrEmpty(netPayTradeRefundQueryIn.Paytype))
                 {
                     stringA += "paytype=" + netPayTradeRefundQueryIn.Paytype + "&";
                 }
                 if (!string.IsNullOrEmpty(netPayTradeRefundQueryIn.Wkdz))
                 {
                     stringA += "wkdz=" + netPayTradeRefundQueryIn.Wkdz + "&";
                 }
                 if (!string.IsNullOrEmpty(netPayTradeRefundQueryIn.Zflsh))
                 {
                     stringA += "zflsh=" + netPayTradeRefundQueryIn.Zflsh + "&";
                 }
                 stringA = stringA.Substring(0, stringA.Length - 1);
         
            string  stringC =

                    "appCode=" + netPayTradeRefundQueryIn.AppCode + "&"
                    + "czyh=" + netPayTradeRefundQueryIn.Czyh + "&"
                    + "merId=" + NetPayIniParam.MerId + "&"
                    + "merchantId=" + NetPayIniParam.MerchantId + "&"
                    + "nonce_str =" + netPayTradeRefundQueryIn.Nonce_str + "&"
                    + "orgCode=" + NetPayIniParam.OrgCode + "&"
                    + "outRefundNo=" + netPayTradeRefundQueryIn.OutRefundNo + "&"
                    + "outerOrderNo=" + netPayTradeRefundQueryIn.OuterOrderNo + "&"
                    + "paytype=" + netPayTradeRefundQueryIn.Paytype + "&"
                    + "wkdz=" + netPayTradeRefundQueryIn.Wkdz + "&"
                    + "zflsh=" + netPayTradeRefundQueryIn.Zflsh;


            string stringSignTemp = stringA + "&key=" + NetPayIniParam.Key;
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringSignTemp, "MD5").ToUpper();
            string stringB = stringC + "&sign=" + sign;
            
            try
            {
                string url = NetPayIniParam.Basurl + "!execNetPayTradeRefundQuery.do?" + stringB;
                webClient.Encoding = Encoding.UTF8;
                string param = webClient.DownloadString(url);
                if (param == "")
                {
                    ret.Err_mesg = "微信(支付宝) 失败！:返回字符串为空";
                    ret.Errcode = -1;
                    return ret;
                }
                JsonTop topInfo = JsonConvert.DeserializeObject<JsonTop>(param);
                if (topInfo.success.ToUpper() == "TRUE")
                {
                    JsonSuccess json_su = JsonConvert.DeserializeObject<JsonSuccess>(param);
                    netPayTradeRefundQueryOut.OuterOrderNo = json_su.msg.outerOrderNo;
                    netPayTradeRefundQueryOut.Gmt_refund_pay = json_su.msg.gmt_refund_pay;
                    netPayTradeRefundQueryOut.RefundFee = json_su.msg.refundFee;
                    netPayTradeRefundQueryOut.TradeNo = json_su.msg.tradeNo;
                    netPayTradeRefundQueryOut.Nonce_str = json_su.nonce_str;
                    ret.Ret_flag = true;
                    ret.Errcode = 0;
                    return ret;

                }
                else
                {
                    JsonFail failInfo = JsonConvert.DeserializeObject<JsonFail>(param);
                    if (failInfo.err.Contains("order success pay inprocess"))
                    {
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err + ",errcode:" + failInfo.errcode + "账户余额不足（未开启小额免密）。";
                       
                    }
                    else
                        ret.Err_mesg = "1|微信(支付宝) 失败！err:" + failInfo.err;
                    LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayTradeRefundQueryIn.OuterOrderNo);
                    ret.Errcode = 1;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                ret.Err_mesg = "2|微信(支付宝) 失败！:" + ex.ToString();
                ret.Errcode = 2;
                LogUtils.writeFileLog("省支付平台.log", ret.Err_mesg + ",OuterOrderNo:" + netPayTradeRefundQueryIn.OuterOrderNo);

            }
            return ret;
        }
        public static string get_uft8(string unicodeString)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            String decodedString = utf8.GetString(encodedBytes);
            return decodedString;
        }
    }
}
