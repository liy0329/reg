using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.netpay.bo;
using MTHIS.main.bll;
using MTHIS.common;
using System.Data;

namespace MTREG.netpay
{
    class NetpayBll
    {
       public   int saveToDb(NetPayData netPayData)
        {
            string sql = "INSERT INTO `netpay_data`("
                + " outerOrderNo , "
                + " merchantId , "
                + " orgCode  , "
                + " merId , "
                + " ysje , "
                + " innerOrderNo , "
                + " tfje , "
                + " tradeNo , "
                + " jyrq , "
                + " paytype , "
                + " czyh , "
                + " storeId , "
                + " SourceOuterOrderNo , "
                + " jylx , "
                + " ddlx , "
                + " ihsp_id , "
                + " ddly , "
                + " yymc , "
                + " ksmc , "
                + " appCode , "
                + " hzxm , "
                + " lxdh , "
                + " sfzh , "
              
                + " zfzt   ) VALUES ( "
                +DataTool.addFieldBraces(netPayData.OuterOrderNo )+ " , " // HIS订单号
                +DataTool.addFieldBraces(netPayData.MerchantId )+ " , " // 客户端编码
                +DataTool.addFieldBraces(netPayData.OrgCode )+ " , " // 机构编码
                +DataTool.addFieldBraces(netPayData.MerId )+ " , " // 医院商户编码
                +DataTool.addFieldBraces(netPayData.Ysje )+ " , " // 收费金额
                +DataTool.addFieldBraces(netPayData.InnerOrderNo )+ " , " // 系统号码
                +DataTool.addFieldBraces("0" )+ " , " // 退费金额
                +DataTool.addFieldBraces(netPayData.TradeNo )+ " , " // 支付宝流水号
                +DataTool.addFieldBraces(netPayData.Jyrq )+ " , " // 交易时间
                +DataTool.addFieldBraces(netPayData.Paytype )+ " , " // 支付方式
                +DataTool.addFieldBraces(netPayData.Czyh )+ " , " // 操作员号
                +DataTool.addFieldBraces(netPayData.StoreId )+ " , " // 商户编号
                +DataTool.addFieldBraces(netPayData.SourceOuterOrderNo )+ " , " // HIS原订单号
                +DataTool.addFieldBraces(netPayData.Jylx )+ " , " // 交易类型
                +DataTool.addFieldBraces(netPayData.Ddlx )+ " , " // 订单类型
                +DataTool.addFieldBraces(netPayData.Ihsp_id) + " , " // 订单类型
                +DataTool.addFieldBraces(netPayData.Ddly )+ " , " // 订单来源
                +DataTool.addFieldBraces(netPayData.Yymc )+ " , " // 院区名称
                +DataTool.addFieldBraces(netPayData.Ksmc )+ " , " // 挂号科室
                +DataTool.addFieldBraces(netPayData.AppCode )+ " , " // 应用编码
                +DataTool.addFieldBraces(netPayData.Hzxm) + " , " // 应用编码
                +DataTool.addFieldBraces(netPayData.Lxdh) + " , " // 应用编码
                +DataTool.addFieldBraces(netPayData.Sfzh) + " , " // 应用编码
                +DataTool.addFieldBraces(netPayData.Zfzt) + " ); "; // 支付状态
               return BllMain.Db.Update(sql); 
        }

       public int refundNetPay(string sourceHisOrderNo,string currdate,string zfzt, NetPayTradeRefundOut netPayTradeRefundOut)
       {

           string sql = "select * from netpay_data where outerOrderNo=" + DataTool.addFieldBraces(sourceHisOrderNo) + ";";
           DataTable dt = BllMain.Db.Select(sql).Tables[0];
           if(dt.Rows.Count<=0)
               return -1;
          
           string refoundsql =
               "INSERT INTO `netpay_data`("
                + " outerOrderNo , "
                + " merchantId , "
                + " orgCode  , "
                + " merId , "
                + " ysje , "
                + " innerOrderNo , "
                + " tfje , "
                + " tradeNo , "
                + " jyrq , "
                + " paytype , "
                + " czyh , "
                + " storeId , "
                + " SourceOuterOrderNo , "
                + " jylx , "
                + " ddlx , "
                + " ihsp_id , "
                + " ddly , "
                + " yymc , "
                + " ksmc , "
                + " appCode , "
                + " hzxm , "
                + " lxdh , "
                + " sfzh , "
                + " zfzt   )"
           + "VALUES ( "
                    + DataTool.addFieldBraces(netPayTradeRefundOut.OutRefundNo) + " , " // HIS订单号
                    + DataTool.addFieldBraces(dt.Rows[0]["MerchantId"].ToString()) + " , " // 客户端编码
                    + DataTool.addFieldBraces(dt.Rows[0]["OrgCode"].ToString()) + " , " // 机构编码
                    + DataTool.addFieldBraces(dt.Rows[0]["MerId"].ToString()) + " , " // 医院商户编码
                    + DataTool.addFieldBraces("0") + " , " // 收费金额
                    + DataTool.addFieldBraces(netPayTradeRefundOut.InnerOrderNo) + " , " // 系统号码
                    + DataTool.addFieldBraces(netPayTradeRefundOut.Amount) + " , " // 退费金额
                    + DataTool.addFieldBraces(netPayTradeRefundOut.TradeNo) + " , " // 支付宝流水号
                    + DataTool.addFieldBraces(currdate) + " , " // 交易时间
                    + DataTool.addFieldBraces(dt.Rows[0]["Paytype"].ToString()) + " , " // 支付方式
                    + DataTool.addFieldBraces(dt.Rows[0]["Czyh"].ToString()) + " , " // 操作员号
                    + DataTool.addFieldBraces(dt.Rows[0]["StoreId"].ToString()) + " , " // 商户编号
                    + DataTool.addFieldBraces(dt.Rows[0]["OuterOrderNo"].ToString()) + " , " // HIS原订单号
                    + DataTool.addFieldBraces("2") + " , " // 交易类型
                    + DataTool.addFieldBraces(dt.Rows[0]["Ddlx"].ToString()) + " , " // 订单类型
                    + DataTool.addFieldBraces(dt.Rows[0]["ihsp_id"].ToString()) + " , " // 订单来源
                    + DataTool.addFieldBraces(dt.Rows[0]["Ddly"].ToString()) + " , " // 订单来源
                    + DataTool.addFieldBraces(dt.Rows[0]["Yymc"].ToString()) + " , " // 院区名称
                    + DataTool.addFieldBraces(dt.Rows[0]["Ksmc"].ToString()) + " , " // 挂号科室
                    + DataTool.addFieldBraces(dt.Rows[0]["AppCode"].ToString()) + " , " // 应用编码
                    + DataTool.addFieldBraces(dt.Rows[0]["Hzxm"].ToString()) + " , " // 姓名
                    + DataTool.addFieldBraces(dt.Rows[0]["Lxdh"].ToString()) + " , " // 联系电话
                    + DataTool.addFieldBraces(dt.Rows[0]["Sfzh"].ToString()) + " , " // 身份证号
                    + DataTool.addFieldBraces(zfzt) + " ); "; // 支付状态;  
           return BllMain.Db.Update(refoundsql);
       }

        public string getNetPaytype(string bas_paytype_id)
        {
            string ret = "-1";
            string sql = "select hiscode as netpaytype_id from sys_dict where dicttype='bas_paytype' and keyname in ( 'ALIPAY', 'WECHAT') and sn =" + DataTool.addFieldBraces(bas_paytype_id) + ";";
            try
            {
                
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ret = dt.Rows[0]["netpaytype_id"].ToString();
                }
            }
            catch (Exception ex)
            {
                ret = "-1";
            }
            return ret;
        }
        public string netpayOrderStat(string outerOrderNo, string nonce_str, string merchantId, string orgCode, string merId)
        {
            bool flag = true;
            string sql_clinic = "select "
                    + "outerOrderNo as sjh"
                    + ",date_format(jyrq,  '%Y%m%d%H:%i:%s') as sfrq"
                    + ",case paytype when 4 then  '支付宝' when 5 then '微信'  else '' end as payname"
                    + ",jylx"
                    + ",ysje"
                    + ",tfje"
                    + ",register.member_id as patid"
                    + ",register.billcode as blh"
                   + ",register.name as hzxm"
                    + ",case register.sex when 'M' then  '男' when 'W' then '女'  else '' end as sex"
                    + ",ihsp_info.idcard as sfzh"
                    + ",ihsp_info.homephone as lxdh"
                    + ",ihsp_info.homeaddress as lxdz"
                    + ",tradeNo as zflsh"
                    + ",innerOrderNo"
                    + ",zfzt"
                    + " from netpay_data "
                    + " left join register on netpay_data.ihsp_id = register.id "
                    + " left join ihsp_info on netpay_data.ihsp_id = ihsp_info.ihsp_id and ihsp_info.registkind='CLIN' "
                    +" where ddly=1 ";
                    if(!string.IsNullOrEmpty(outerOrderNo))
                    {
                        sql_clinic+= " and outerOrderNo= " + DataTool.addFieldBraces(outerOrderNo);
                    }
                    if (!string.IsNullOrEmpty(merchantId))
                    {
                        sql_clinic += " and merchantId= " + DataTool.addFieldBraces(merchantId);
                    }
                    else flag = false;
                    if (!string.IsNullOrEmpty(orgCode))
                    {
                        sql_clinic += " and orgCode= " + DataTool.addFieldBraces(orgCode);
                    }
                    else flag = false;
                    if (!string.IsNullOrEmpty(merId))
                    {
                        sql_clinic += " and merId= " + DataTool.addFieldBraces(merId);
                    }
                    else flag = false;
                    string sql_ihsp = "select "
                        + "outerOrderNo as sjh"
                        + ",date_format(jyrq,  '%Y%m%d%H:%i:%s') as sfrq"
                        + ",case paytype when 4 then  '支付宝' when 5 then '微信'  else '' end as payname"
                        + ",jylx"
                        + ",ysje"
                        + ",tfje"
                        + ",register.member_id as patid"
                        + ",register.ihspcode as blh"
                        + ",register.name as hzxm"
                        + ",case register.sex when 'M' then  '男' when 'W' then '女'  else '' end as sex"
                        + ",ihsp_info.idcard as sfzh"
                        + ",ihsp_info.homephone as lxdh"
                        + ",ihsp_info.homeaddress as lxdz"
                        + ",tradeNo as zflsh"
                        + ",innerOrderNo"
                        + ",zfzt"
                        + " from netpay_data "
                        + " left join inhospital register on netpay_data.ihsp_id = register.id "
                        + " left join ihsp_info on netpay_data.ihsp_id = ihsp_info.ihsp_id and ihsp_info.registkind='IHSP' "
                        + " where ddly=2 ";
                   if (!string.IsNullOrEmpty(outerOrderNo))
                   {
                       sql_ihsp += " and outerOrderNo= " + DataTool.addFieldBraces(outerOrderNo);
                   }
                   if (!string.IsNullOrEmpty(merchantId))
                   {
                       sql_ihsp += " and merchantId= " + DataTool.addFieldBraces(merchantId);
                   }
                   if (!string.IsNullOrEmpty(orgCode))
                   {
                       sql_ihsp += " and orgCode= " + DataTool.addFieldBraces(orgCode);
                   }
                   if (!string.IsNullOrEmpty(merId))
                   {
                       sql_ihsp += " and merId= " + DataTool.addFieldBraces(merId);
                   }
                   string sql = sql_clinic + "union all " + sql_ihsp;

                   string xml_resitem = "";
                   if (flag)
                   {
                       DataTable dt = BllMain.Db.Select(sql).Tables[0];
                       for (int i = 0; i < dt.Rows.Count; i++)
                       {
                           xml_resitem += "<item>"
                                  + "<sjh>" + dt.Rows[i]["sjh"].ToString() + "</sjh>"
                                  + "<sfrq>" + dt.Rows[i]["sfrq"].ToString() + "</sfrq>"
                                  + "<payname>" + dt.Rows[i]["payname"] + "</payname>"
                                  + "<jylx>" + dt.Rows[i]["jylx"].ToString() + "</jylx>";
                           if (dt.Rows[i]["jylx"].ToString().Equals("1"))
                           {
                               xml_resitem += "<jyje>" + dt.Rows[i]["ysje"].ToString() + "</jyje>";
                           }
                           if (dt.Rows[i]["jylx"].ToString().Equals("2"))
                           {
                               xml_resitem += "<jyje>" + dt.Rows[i]["tfje"].ToString() + "</jyje>";
                           }
                           xml_resitem += "<patid>" + dt.Rows[i]["patid"].ToString() + "</patid>"
                           + "<blh>" + dt.Rows[i]["blh"].ToString() + "</blh>"
                           + "<hzxm>" + dt.Rows[i]["hzxm"].ToString() + "</hzxm>"
                           + "<sex>" + dt.Rows[i]["sex"].ToString() + "</sex>"
                           + "<sfzh>" + dt.Rows[i]["sfzh"].ToString() + "</sfzh>"
                           + "<lxdh>" + dt.Rows[i]["lxdh"].ToString() + "</lxdh>"
                           + "<lxdz>" + dt.Rows[i]["lxdz"].ToString() + "</lxdz>"
                           + "<zflsh>" + dt.Rows[i]["zflsh"].ToString() + "</zflsh>"
                           + "<innerOrderNo>" + dt.Rows[i]["innerOrderNo"].ToString() + "</innerOrderNo>"
                           + "<zfzt>" + dt.Rows[i]["zfzt"].ToString() + "</zfzt>"
                           + "</item>";
                       }
                   }
                   string xml_resstart =
                        "<response>"
                        + "<resultCode>0</resultCode>"
                        + "<resultMessage></resultMessage>"
                        + "<result>";
                   string xml_resend =
                       "</result>"
                       + "</response>";
                   string xml_data=xml_resstart + xml_resitem + xml_resend;
                   return xml_data;
        }
        public string netpayOrderList(string startDate, string endDate, string nonce_str, string merchantId, string orgCode, string merId)
        {

           DateTime  d_startDate = DataTool.stringToDate(startDate, "yyyyMMdd");
           DateTime d_endDate = DataTool.stringToDate(startDate, "yyyyMMdd");
            d_endDate= d_endDate.AddDays(1);
            startDate = DataTool.dateToString(d_startDate, "yyyy-MM-dd HH:mm:ss");
            endDate = DataTool.dateToString(d_endDate, "yyyy-MM-dd HH:mm:ss");
            
            bool flag = true;
            string sql = "select "
                   + "outerOrderNo as goodsTag"
                   + ",ysje"
                   + ",'' as memo"
                   + ",innerOrderNo"
                   + ",tfje"
                   + ",tradeNo"
                   + ",date_format(jyrq,  '%Y%m%d%H:%i:%s') as jyrq"
                   + ",paytype"
                   + ",czyh"
                   + ",storeId"
                   + ",outerOrderNo"
                   + ",SourceOuterOrderNo"
                   + ",jylx"
                   + ",ddlx"
                   + ",ddly"
                   + ",yymc"
                   + ",ksmc"
                   + ",appCode from netpay_data where 1=1 and zfzt=1 and isCancel>=0";

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                sql += " and jyrq> " + DataTool.addFieldBraces(startDate) + "and jyrq < " + DataTool.addFieldBraces(endDate);
            }
            if (!string.IsNullOrEmpty(merchantId))
            {
                sql += " and merchantId= " + DataTool.addFieldBraces(merchantId);
            }
            else flag = false;
            if (!string.IsNullOrEmpty(orgCode))
            {
                sql += " and orgCode= " + DataTool.addFieldBraces(orgCode);
            }
            else flag = false;
            if (!string.IsNullOrEmpty(merId))
            {
                sql += " and merId= " + DataTool.addFieldBraces(merId);
            }
            else flag = false;
            string xml_resitem = "";
            if (flag)
            {
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    xml_resitem +=
                         "<item>"
                         + "<goodsTag>" + dt.Rows[i]["goodsTag"].ToString() + "</goodsTag>"
                         + "<ysje>" + dt.Rows[i]["ysje"].ToString() + "</ysje>"
                         + "<memo></memo>"
                         + "<innerOrderNo>" + dt.Rows[i]["innerOrderNo"].ToString() + "</innerOrderNo>"
                         + "<tfje>" + dt.Rows[i]["tfje"].ToString() + "</tfje>"
                         + "<tradeNo>" + dt.Rows[i]["tradeNo"].ToString() + "</tradeNo>"
                         + "<jyrq>" + dt.Rows[i]["jyrq"].ToString() + "</jyrq>"
                         + "<paytype>" + dt.Rows[i]["paytype"].ToString() + "</paytype>"
                         + "<czyh>" + dt.Rows[i]["czyh"].ToString() + "</czyh>"
                         + "<storeId>" + dt.Rows[i]["storeId"].ToString() + "</storeId>"
                         + "<outerOrderNo>" + dt.Rows[i]["outerOrderNo"].ToString() + "</outerOrderNo>"
                         + "<SourceOuterOrderNo>" + dt.Rows[i]["SourceOuterOrderNo"].ToString() + "</SourceOuterOrderNo>"
                         + "<zfzt>" + dt.Rows[i]["jylx"].ToString() + "</zfzt>"
                         + "<yymc>" + dt.Rows[i]["yymc"].ToString() + "</yymc>"
                         + "<appCode>" + dt.Rows[i]["appCode"].ToString() + "</appCode>"
                         + "</item>";
                }
            }
            string xml_resstart =
                           "<response>"
                           + "<resultCode>0</resultCode>"
                           + "<resultMessage></resultMessage>"
                           + "<result>";
                string xml_resend =
                    "</result>"
                    + "</response>";
                string xml_data = xml_resstart + xml_resitem + xml_resend;
                return xml_data;
        }
    }
}
