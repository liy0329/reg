using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    public class ClinicInvoice
    {
        private string id;
        private string regist_id;
        private string account_id;
        private string sickname;
        private string rcpdep_id;
        private string rcpdoctor_id;
        private string fee;
        private string discnt;
        private string realfee;
        private string bas_patienttype_id;
        private string billcode;
        private string chargedate;
        private string chargeby;
        private string charged;
        private string insurstat;
        private string insurefee;
        private string insuraccountfee;
        private string insurotherfee;
        private string clinic_tab_id;
        private string healthcard;
        private string insurcode;
        private string nextinvoicesql;
        private string clinic_cost_ids;
        private string clinic_costdet_ids;
        private string invoice;
        private string isregist;
        private string invoice_sql;
        private string exedep_id;
        private string bas_patienttype1_id;
        private string bas_paytype_id;//个人支付类型
        private string payfee;//支付金额
        private string hisOrderNo;//订单单据号
        private string netpay_store_id;
        /// <summary>
        /// 窗口类型
        /// </summary>
        public string Netpay_store_id
        {
            get { return netpay_store_id; }
            set { netpay_store_id = value; }
        }
        /// <summary>
        /// 订单单据号
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
        /// 个人支付类型
        /// </summary>
        public string Bas_paytype_id
        {
            get { return bas_paytype_id; }
            set { bas_paytype_id = value; }
        }
        /// <summary>
        /// 患者子类型统计
        /// </summary>
        public string Bas_patienttype1_id
        {
            get { return bas_patienttype1_id; }
            set { bas_patienttype1_id = value; }
        }
        /// <summary>
        /// 执行科室
        /// </summary>
        public string Exedep_id
        {
            get { return exedep_id; }
            set { exedep_id = value; }
        }

        //发票sql
        public string Invoice_sql
        {
            get { return invoice_sql; }
            set { invoice_sql = value; }
        }

        /// <summary>
        /// 是挂号票
        /// </summary>
        public string Isregist
        {
            get { return isregist; }
            set { isregist = value; }
        }
        
        /// <summary>
        /// 发票号
        /// </summary>
        public string Invoice
        {
            get { return invoice; }
            set { invoice = value; }
        }
        
        
       
        /// <summary>
        /// 收费明细_id
        /// </summary>
        public string Clinic_costdet_ids
        {
            get { return clinic_costdet_ids; }
            set { clinic_costdet_ids = value; }
        }
        /// <summary>
        /// 收费主表id
        /// </summary>
        public string Clinic_cost_ids
        {
            get { return clinic_cost_ids; }
            set { clinic_cost_ids = value; }
        }
        //结算单号
        public string Account_id
        {
            get { return account_id; }
            set { account_id = value; }
        }
        //走发票号sql
        public string Nextinvoicesql
        {
            get { return nextinvoicesql; }
            set { nextinvoicesql = value; }
        }
        /// <summary>
        /// 其它医保支付
        /// </summary>
        public string Insurotherfee
        {
            get { return insurotherfee; }
            set { insurotherfee = value; }
        }
        /// <summary>
        /// 医保卡号
        /// </summary>
        public string Healthcard
        {
            get { return healthcard; }
            set { healthcard = value; }
        }        
        /// <summary>
        /// 参保证号
        /// </summary>
        public string Insurcode
        {
            get { return insurcode; }
            set { insurcode = value; }
        }
        
        private string depart_id;
        /// <summary>
        /// 收费员科室
        /// </summary>
        public string Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }


        /// <summary>
        /// 发票主键
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
        /// 姓名
        /// </summary>
        public string Sickname
        {
            get { return sickname; }
            set { sickname = value; }
        }
        /// <summary>
        /// 处方科室
        /// </summary>
        public string Rcpdep_id
        {
            get { return rcpdep_id; }
            set { rcpdep_id = value; }
        }
        /// <summary>
        /// 处方医生
        /// </summary>
        public string Rcpdoctor_id
        {
            get { return rcpdoctor_id; }
            set { rcpdoctor_id = value; }
        }
        /// <summary>
        /// 处方金额
        /// </summary>
        public string Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        /// <summary>
        /// 折扣率
        /// </summary>
        public string Discnt
        {
            get { return discnt; }
            set { discnt = value; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public string Realfee
        {
            get { return realfee; }
            set { realfee = value; }
        }
        /// <summary>
        /// 患者类型/就诊类别 外键
        /// </summary>
        public string Bas_patienttype_id
        {
            get { return bas_patienttype_id; }
            set { bas_patienttype_id = value; }
        }
        /// <summary>
        /// 单据号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// 收费时间
        /// </summary>
        public string Chargedate
        {
            get { return chargedate; }
            set { chargedate = value; }
        }
        /// <summary>
        /// 收费人
        /// </summary>
        public string Chargeby
        {
            get { return chargeby; }
            set { chargeby = value; }
        }
        /// <summary>
        /// 计费状态
        /// </summary>
        public string Charged
        {
            get { return charged; }
            set { charged = value; }
        }
        /// <summary>
        /// 医保接口状态
        /// </summary>
        public string Insurstat
        {
            get { return insurstat; }
            set { insurstat = value; }
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
        /// 日结单号
        /// </summary>
        public string Clinic_tab_id
        {
            get { return clinic_tab_id; }
            set { clinic_tab_id = value; }
        }
        
       
    }
}
