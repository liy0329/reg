using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.common;

namespace MTREG.medinsur.hsdryb.bo
{
    class TopParameter
    {
        /// <summary>
        /// 险种类型
        /// </summary>
        public string AAE140 { get; set; }

        /// <summary>
        /// 患者识别信息
        /// </summary>
        public string AAC001 { get; set; }

        /// <summary>
        /// 定点医疗机构编码
        /// </summary>
        public string AKB020 { get; set; }

        /// <summary>
        /// 门诊/住院流水号
        /// </summary>
        public string AKC190 { get; set; }

        /// <summary>
        /// 社保卡号（医保卡号）
        /// </summary>
        public string AKC020 { get; set; }

        /// <summary>
        /// 医疗类别
        /// </summary>
        public string AKA130 { get; set; }

        /// <summary>
        /// 交易代码
        /// </summary>
        public string MSGNO { get; set; }

        /// <summary>
        /// 发送方交易流水号
        /// </summary>
        public string MSGID { get; set; }

        /// <summary>
        /// 授权码
        /// </summary>
        public string GRANTID { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        public string OPERID { get; set; }

        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string OPERNAME { get; set; }

        /// <summary>
        /// 业务周期号
        /// </summary>
        public string BATNO { get; set; }

        /// <summary>
        /// 系统时间
        /// </summary>
        public string OPTTIME { get; set; }

        /// <summary>
        /// 特定输入参数XML
        /// </summary>
        public string INPUT { get; set; }

        /// <summary>
        /// 就诊信息XML
        /// </summary>
        public string KC21XML { get; set; }

        /// <summary>
        /// 费用明细XML
        /// </summary>
        public string KC22XML { get; set; }

        public string InXml(TopParameter  entity)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<HOSDATA>");
            sb.Append("<REQUESTDATA>");
            sb.AppendFormat("<AAE140>{0}</AAE140>", 0);
            sb.AppendFormat("<AAC001>{0}</AAC001>", 0);
            sb.AppendFormat("<AKB020>{0}</AKB020>", entity.AKB020);
            sb.AppendFormat("<AKC190>{0}</AKC190>", entity.AKC190);
            sb.AppendFormat("<AKC020>{0}</AKC020>", entity.AKC020);
            sb.AppendFormat("<AKA130>{0}</AKA130>", entity.AKA130);
            sb.AppendFormat("<MSGNO>{0}</MSGNO>", entity.MSGNO);
            sb.AppendFormat("<MSGID>{0}</MSGID>", entity.MSGID);
            sb.AppendFormat("<GRANTID>{0}</GRANTID>", entity.GRANTID);//授权码，值要修改
            sb.AppendFormat("<OPERID>{0}</OPERID>", entity.OPERID);
            sb.AppendFormat("<OPERNAME>{0}</OPERNAME>", entity.OPERNAME);
            sb.AppendFormat("<BATNO>{0}</BATNO>", entity.BATNO);
            sb.AppendFormat("<OPTTIME>{0}</OPTTIME>", Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
            sb.AppendFormat("<INPUT>{0}</INPUT>", entity.INPUT);
            sb.AppendFormat("<KC21XML>{0}</KC21XML>", entity.KC21XML);
            sb.AppendFormat("<KC22XML>{0}</KC22XML>", entity.KC22XML == "" ? "<KC22ROW></KC22ROW>" : entity.KC22XML);
            sb.Append("</REQUESTDATA>");
            sb.Append("</HOSDATA>");

            return sb.ToString();
        }
    }
}
