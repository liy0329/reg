using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ClinicAccount
    {        


        private string billcode;
        private string regist_id;
        private string recivefee;
        private string realfee;
        private string retfee;
        private string insurefee;
        private string insuraccountfee;
        private string settledby;
        private string settledate;
        private string settledep_id;
        private string bas_paytype_id;
        private string cheque;
        private string payfee;

        private string hisOrderNo;
        /// <summary>
        /// 支付订单号
        /// </summary>
        public string HisOrderNo
        {
            get { return hisOrderNo; }
            set { hisOrderNo = value; }
        }
        /// <summary>
        /// 支付金额
        /// </summary>
        public string Payfee
        {
            get { return payfee; }
            set { payfee = value; }
        }
       
        /// <summary>
       /// 交易单号
       /// </summary>
       public string Cheque
       {
           get { return cheque; }
           set { cheque = value; }
       }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string Bas_paytype_id
        {
          get { return bas_paytype_id; }
          set { bas_paytype_id = value; }
        }

        /// <summary>
        /// 结算科室
        /// </summary>
        public string Settledep_id
        {
          get { return settledep_id; }
          set { settledep_id = value; }
        }

        private string id;
        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 挂号记录外键
        /// </summary>
        public string Regist_id
        {
            get { return regist_id; }
            set { regist_id = value; }
        }
        /// <summary>
        /// 结算单
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// 实收金额
        /// </summary>
        public string Recivefee
        {
            get { return recivefee; }
            set { recivefee = value; }
        }
        /// <summary>
        /// 总金额
        /// </summary>
        public string Realfee
        {
            get { return realfee; }
            set { realfee = value; }
        }
        /// <summary>
        /// 找零金额
        /// </summary>
        public string Retfee
        {
            get { return retfee; }
            set { retfee = value; }
        }
        /// <summary>
        /// 统筹金额
        /// </summary>
        public string Insurefee
        {
            get { return insurefee; }
            set { insurefee = value; }
        }
        /// <summary>
        /// 个人自付
        /// </summary>
        public string Insuraccountfee
        {
            get { return insuraccountfee; }
            set { insuraccountfee = value; }
        }
        /// <summary>
        /// 结算人
        /// </summary>
        public string Settledby
        {
            get { return settledby; }
            set { settledby = value; }
        }
        /// <summary>
        /// 结算时间
        /// </summary>
        public string Settledate
        {
            get { return settledate; }
            set { settledate = value; }
        }
    }
}
