using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsp.bo
{
    class Ihsppayinadv
    {
        private string id;
        /// <summary>
        /// 预付款表id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string billcode;
        /// <summary>
        /// 收据号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        private string ihsp_id;
        /// <summary>
        /// 住院编号外键
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string paytype;
        /// <summary>
        /// 收款类型
        /// </summary>
        public string Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }

        private string bas_paysumby_id;
        
        /// <summary>
        /// 汇总类别
        /// </summary>
        public string Bas_paysumby_id
        {
            get { return bas_paysumby_id; }
            set { bas_paysumby_id = value; }
        }

        private string cheque;
        /// <summary>
        /// 支票号
        /// </summary>
        public string Cheque
        {
            get { return cheque; }
            set { cheque = value; }
        }
        private string num;
        /// <summary>
        /// 票据数量
        /// </summary>
        public string Num
        {
            get { return num; }
            set { num = value; }
        }
        private string payman;
        /// <summary>
        /// 付款人
        /// </summary>
        public string Payman
        {
            get { return payman; }
            set { payman = value; }
        }
        private string payfee;
        /// <summary>
        /// 付款金额
        /// </summary>
        public string Payfee
        {
            get { return payfee; }
            set { payfee = value; }
        }
        private string status;
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string depart;
        /// <summary>
        /// 科室
        /// </summary>
        public string Depart
        {
            get { return depart; }
            set { depart = value; }
        }
        private string chargedby;
        /// <summary>
        /// 收费员外键
        /// </summary>
        public string Chargedby
        {
            get { return chargedby; }
            set { chargedby = value; }
        }
        private string chargedate;
        /// <summary>
        /// 收费时间
        /// </summary>
        public string Chargedate
        {
            get { return chargedate; }
            set { chargedate = value; }
        }
        private string ihsp_payinadv_id;
        /// <summary>
        /// 红冲编号
        /// </summary>
        public string Ihsp_payinadv_id
        {
            get { return ihsp_payinadv_id; }
            set { ihsp_payinadv_id = value; }
        }

        private string feeamt;
        /// <summary>
        /// 总费用
        /// </summary>
        public string Feeamt
        {
            get { return feeamt; }
            set { feeamt = value; }
        }

        private string prepamt;
        /// <summary>
        /// 余额
        /// </summary>
        public string Prepamt
        {
            get { return prepamt; }
            set { prepamt = value; }
        }
        private string hisOrderNo;
        /// <summary>
        ///  支付订单号
        /// </summary>
        public string HisOrderNo
        {
            get { return hisOrderNo; }
            set { hisOrderNo = value; }
        }
        private string sourceHisOrderNo;

        public string SourceHisOrderNo
        {
            get { return sourceHisOrderNo; }
            set { sourceHisOrderNo = value; }
        }
        private string netpay_store_id="1";
        /// <summary>
        /// 窗口
        /// </summary>
        public string Netpay_store_id
        {
            get { return netpay_store_id; }
            set { netpay_store_id = value; }
        }
    }
}
