using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public  class js_sql
    {
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 住院发票(ihspaccount)外键
        /// </summary>
        public string ihspaccount_id { get; set; }

        
        /// <summary>
        /// 门诊住院流水号
        /// </summary>
        public string AKC190 { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        public string AAE072 { get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        public string ZKC759 { get; set; }
        /// <summary>
        /// 是否使用账户
        /// </summary>
        public string BKC111 { get; set; }
        /// <summary>
        /// 发送交易流水号
        /// </summary>
        public string MSGID { get; set; }
        /// <summary>
        /// 接收交易流水号
        /// </summary>
        public string REFMSGID { get; set; }
        /// <summary>
        /// 医疗类别
        /// </summary>
        public string AKA130 { get; set; }
        /// <summary>
        /// 疾病
        /// </summary>
        public string AKC193 { get; set; }
        /// <summary>
        /// 住院 ou 门诊
        /// </summary>
        public string registkind { get; set; }
        /// <summary>
        /// 结算返回
        /// </summary>
        public zyjs_OUT js;
    }
}
