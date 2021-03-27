using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.common;
using MTREG.medinsur.sjzsyb.bll;
using k = System.Object;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class SJZYB_IN<k>
    {
        /// <summary>
        /// 险种类型
        /// 0-医保 已默认
        /// </summary>
        public string AAE140 { get; set; }
        /// <summary>
        /// 患者识别信息
        /// 个人编号/卡号/身份证号，有卡此值传 0，无卡传值
        /// </summary>
        public string AAC001 { get; set; }
        /// <summary>
        /// 定点医疗机构编码
        /// 必录 已默认
        /// </summary>
        public string AKB020 { get; set; }
        /// <summary>
        /// 门诊/住院流水号
        /// 必录，同一家医院的流水号唯一
        /// </summary>
        public string AKC190 { get; set; }
        /// <summary>
        /// 社保卡号（医保卡号）
        /// 必录(1501、1503、1800、1401可以为空)
        /// </summary>
        public string AKC020 { get; set; }
        /// <summary>
        /// 医疗类别
        /// 必录
        /// </summary>
        public string AKA130 { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        public string MSGNO { get; set; }
        /// <summary>
        /// 发送方交易流水号 已默认
        /// </summary>
        public string MSGID { get; set; }
        /// <summary>
        /// 授权码
        /// </summary>
        public string GRANTID { get; set; }
        /// <summary>
        /// 原交易代码
        /// </summary>
        public string ORGMSGNO { get; set; }
        /// <summary>
        /// 原发送方交易流水号
        /// </summary>
        public string ORGMSGID { get; set; }
        /// <summary>
        /// 操作员 ID 已默认
        /// </summary>
        public string OPERID { get; set; }
        /// <summary>
        /// 操作员 姓名 已默认
        /// </summary>
        public string OPERNAME { get; set; }
        /// <summary>
        /// 业务周期号 已默认
        /// </summary>
        public string BATNO { get; set; }
        /// <summary>
        /// 系统时间 已默认
        /// </summary>
        public string OPTTIME { get; set; }
        /// <summary>
        /// 特定输入参数 
        /// 
        /// </summary>
        public List<k> INPUT;
        /// <summary>
        /// 就诊信息
        /// </summary>
        public KC21 KC21XML;
        /// <summary>
        /// 费用明细 
        /// </summary>
        public List<KC22> KC22XML;
        /// <summary>
        /// AAE140
        /// AKB020
        /// OPERID
        /// OPERNAME
        /// BATNO
        /// OPTTIME
        /// MSGID
        /// </summary>
        public SJZYB_IN()
        {
            AAE140 = "0";
            AKB020 = ProgramGlobal.AKB020;
            GRANTID = ProgramGlobal.GRANTID;
            OPERID = ProgramGlobal.User_id;
            OPERNAME = ProgramGlobal.Nickname;
            BATNO = ProgramGlobal.batno;
            OPTTIME = DateTime.Now.ToString("yyyyMMddHHmmss") ;
            string msgid = BllItemcrossSJZ.getTradingStream(); //交易流水号
            MSGID = msgid;

            
        }
    }
}
