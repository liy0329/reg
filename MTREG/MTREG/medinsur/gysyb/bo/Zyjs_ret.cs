using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    public class Zyjs_ret
    {
        private string centercode;//分中心编码    
        private string billno;//就诊顺序号
        private string balanceid;//结算编号
        private string hospfeeall;//医院总费用
        private string feeall;//医保总费用
        private string calfeeall;//结算总费用
        private string feeout;//全自费
        private string feeself;//挂钩自付
        private string allowfund;//允许报销
        private string startfee;//本次起付线
        private string enterstartfee;//进入起付线
        private string fund1pay;//基本统筹支付
        private string fund1self;//基本统筹自付
        private string fund2pay;//大额统筹支付
        private string fund2self;//大额统筹自付
        private string feeouer;//超限额自付
        private string acctpay;//个人账户支付
        private string fund3pay;//医疗补助支付
        private string acctbalance;//个人账户余额
        private string handledte;//系统处理时间
        private string speccalflag;//特殊结算标志
        private string reckoningtype;//清算方式
        private string singleillnesscode;//清算病种编码
        private string singleillnessname;//病种名称
        private string sbstartfee;//商保起付线
        private string sbpay;//商保支付
        private string mtzyjl_iid;//住院记录iid

        public string Sbpay
        {
            get { return sbpay; }
            set { sbpay = value; }
        }

        public string Sbstartfee
        {
            get { return sbstartfee; }
            set { sbstartfee = value; }
        }

        public string Mtzyjl_iid
        {
            get { return mtzyjl_iid; }
            set { mtzyjl_iid = value; }
        }
        /// <summary>
        /// 超限额自付
        /// </summary>
        public string Feeouer
        {
            get { return feeouer; }
            set { feeouer = value; }
        }
        /// <summary>
        /// 分中心编码  
        /// </summary>
        public string Centercode
        {
            get { return centercode; }
            set { centercode = value; }
        }
        /// <summary>
        /// 就诊顺序号
        /// </summary>
        public string Billno
        {
            get { return billno; }
            set { billno = value; }
        }
        /// <summary>
        /// 结算编号
        /// </summary>
        public string Balanceid
        {
            get { return balanceid; }
            set { balanceid = value; }
        }
        /// <summary>
        /// 医院总费用
        /// </summary>
        public string Hospfeeall
        {
            get { return hospfeeall; }
            set { hospfeeall = value; }
        }
        /// <summary>
        /// 医保总费用
        /// </summary>
        public string Feeall
        {
            get { return feeall; }
            set { feeall = value; }
        }
        /// <summary>
        /// 结算总费用
        /// </summary>
        public string Calfeeall
        {
            get { return calfeeall; }
            set { calfeeall = value; }
        }
        /// <summary>
        /// 全自费
        /// </summary>
        public string Feeout
        {
            get { return feeout; }
            set { feeout = value; }
        }
        /// <summary>
        /// 挂钩自付
        /// </summary>
        public string Feeself
        {
            get { return feeself; }
            set { feeself = value; }
        }
        /// <summary>
        /// 允许报销
        /// </summary>
        public string Allowfund
        {
            get { return allowfund; }
            set { allowfund = value; }
        }
        /// <summary>
        /// 本次起付线
        /// </summary>
        public string Startfee
        {
            get { return startfee; }
            set { startfee = value; }
        }
        /// <summary>
        /// 进入起付线
        /// </summary>
        public string Enterstartfee
        {
            get { return enterstartfee; }
            set { enterstartfee = value; }
        }
        /// <summary>
        /// 基本统筹支付
        /// </summary>
        public string Fund1pay
        {
            get { return fund1pay; }
            set { fund1pay = value; }
        }
        /// <summary>
        /// 基本统筹自付
        /// </summary>
        public string Fund1self
        {
            get { return fund1self; }
            set { fund1self = value; }
        }
        /// <summary>
        /// 大额统筹支付
        /// </summary>
        public string Fund2pay
        {
            get { return fund2pay; }
            set { fund2pay = value; }
        }
        /// <summary>
        /// 大额统筹自付
        /// </summary>
        public string Fund2self
        {
            get { return fund2self; }
            set { fund2self = value; }
        }
        /// <summary>
        /// 个人账户支付
        /// </summary>
        public string Acctpay
        {
            get { return acctpay; }
            set { acctpay = value; }
        }
        /// <summary>
        /// 医疗补助支付
        /// </summary>
        public string Fund3pay
        {
            get { return fund3pay; }
            set { fund3pay = value; }
        }
        /// <summary>
        /// 个人账户余额
        /// </summary>
        public string Acctbalance
        {
            get { return acctbalance; }
            set { acctbalance = value; }
        }
        /// <summary>
        /// 系统处理时间
        /// </summary>
        public string Handledte
        {
            get { return handledte; }
            set { handledte = value; }
        }
        /// <summary>
        /// 特殊结算标志
        /// </summary>
        public string Speccalflag
        {
            get { return speccalflag; }
            set { speccalflag = value; }
        }
        /// <summary>
        /// 清算方式
        /// </summary>
        public string Reckoningtype
        {
            get { return reckoningtype; }
            set { reckoningtype = value; }
        }
        /// <summary>
        /// 清算病种编码
        /// </summary>
        public string Singleillnesscode
        {
            get { return singleillnesscode; }
            set { singleillnesscode = value; }
        }
        /// <summary>
        /// 病种名称
        /// </summary>
        public string Singleillnessname
        {
            get { return singleillnessname; }
            set { singleillnessname = value; }
        }
    }
}
