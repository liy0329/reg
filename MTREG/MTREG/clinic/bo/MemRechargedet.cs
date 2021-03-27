using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class MemRechargedet
    {
        private string id;
        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string bas_member_id;
        /// <summary>
        /// 卡号
        /// </summary>
        public string Bas_member_id
        {
            get { return bas_member_id; }
            set { bas_member_id = value; }
        }
        private string billcode;
        /// <summary>
        /// 交易号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        private string opertype;
        /// <summary>
        /// 操作类型
        /// </summary>
        public string Opertype
        {
            get { return opertype; }
            set { opertype = value; }
        }
        private string amount;
        /// <summary>
        /// 操作金额
        /// </summary>
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        /// <summary>
        /// 执行科室
        /// </summary>
        public string depart_id { get; set; }
        private string operatorid;
        /// <summary>
        /// 操作者外键
        /// </summary>
        public string Operatorid
        {
            get { return operatorid; }
            set { operatorid = value; }
        }
        private string operatdate;
        /// <summary>
        /// 操作时间
        /// </summary>
        public string Operatdate
        {
            get { return operatdate; }
            set { operatdate = value; }
        }
        private string balance;
        /// <summary>
        /// 操作后余额
        /// </summary>
        public string Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        private string paytype_id;
        /// <summary>
        /// 支付类型
        /// </summary>
        public string Paytype_id
        {
            get { return paytype_id; }
            set { paytype_id = value; }
        }
    }
}
