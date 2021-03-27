using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsp.bo
{
    class Ihspaccount
    {
        private string nextinvoicesql;

        //走发票号sql
        public string Nextinvoicesql
        {
            get { return nextinvoicesql; }
            set { nextinvoicesql = value; }
        }

        private string id;
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string billcode;
        /// <summary>
        /// 结算单号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        private string ihsp_id;
        /// <summary>
        /// 住院记录
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string member_id;
        /// <summary>
        /// 会员卡
        /// </summary>
        public string Member_id
        {
            get { return member_id; }
            set { member_id = value; }
        }
        private string bas_paytype_id;
        /// <summary>
        /// 收款类型
        /// </summary>
        public string Bas_paytype_id
        {
            get { return bas_paytype_id; }
            set { bas_paytype_id = value; }
        }
        private string cost_insurtype_id;
        /// <summary>
        /// 接口类型
        /// </summary>
        public string Cost_insurtype_id
        {
            get { return cost_insurtype_id; }
            set { cost_insurtype_id = value; }
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
        private string bas_patienttype_id;
        /// <summary>
        /// 患者类型
        /// </summary>
        public string Bas_patienttype_id
        {
            get { return bas_patienttype_id; }
            set { bas_patienttype_id = value; }
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
        private string invoice;
        /// <summary>
        /// 发票号
        /// </summary>
        public string Invoice
        {
            get { return invoice; }
            set { invoice = value; }
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
        /// 总预交款
        /// </summary>
        public string Prepamt
        {
            get { return prepamt; }
            set { prepamt = value; }
        }
        private string balanceamt;
        /// <summary>
        /// 结算收款
        /// </summary>
        public string Balanceamt
        {
            get { return balanceamt; }
            set { balanceamt = value; }
        }
        private string recivefee;
        /// <summary>
        /// 实收金额
        /// </summary>
        public string Recivefee
        {
            get { return recivefee; }
            set { recivefee = value; }
        }
        private string retfee;
        /// <summary>
        /// 找零金额
        /// </summary>
        public string Retfee
        {
            get { return retfee; }
            set { retfee = value; }
        }
        private string depart_id;
        /// <summary>
        /// 结算科室
        /// </summary>
        public string Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        private string chargedby_id;
        /// <summary>
        /// 结算人
        /// </summary>
        public string Chargedby_id
        {
            get { return chargedby_id; }
            set { chargedby_id = value; }
        }
        private string chargedate;
        /// <summary>
        /// 结算时间
        /// </summary>
        public string Chargedate
        {
            get { return chargedate; }
            set { chargedate = value; }
        }
        private string cancleby;
        /// <summary>
        /// 结算回退人
        /// </summary>
        public string Cancleby
        {
            get { return cancleby; }
            set { cancleby = value; }
        }
        private string ihsp_account_id;
        /// <summary>
        /// 红冲ID
        /// </summary>
        public string Ihsp_account_id
        {
            get { return ihsp_account_id; }
            set { ihsp_account_id = value; }
        }
        private string status;
        /// <summary>
        /// 结算单状态
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string cost_end_id;
        /// <summary>
        /// 收费结束号
        /// </summary>
        public string Cost_end_id
        {
            get { return cost_end_id; }
            set { cost_end_id = value; }
        }
        private string cost_begin_id;
        /// <summary>
        /// 收费开始号
        /// </summary>
        public string Cost_begin_id
        {
            get { return cost_begin_id; }
            set { cost_begin_id = value; }
        }
        private string insurefee;
        /// <summary>
        /// 统筹支付
        /// </summary>
        public string Insurefee
        {
            get { return insurefee; }
            set { insurefee = value; }
        }
        private string selffee;
        /// <summary>
        /// 账户支付
        /// </summary>
        public string Selffee
        {
            get { return selffee; }
            set { selffee = value; }
        }

        private string hisOrderNo;
        /// <summary>
        /// 移动支付: 订单号
        /// </summary>
        public string HisOrderNo
        {
            get { return hisOrderNo; }
            set { hisOrderNo = value; }
        }

    }
}
