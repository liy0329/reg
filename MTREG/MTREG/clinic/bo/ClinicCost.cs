using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ClinicCost
    {
        private string id;
        private string regist_id;
        private string clinicInvoice;
        private string billcode;
        private string clinic_rcp_id;
        private string executed;
        private string depart_id;
        private string doctor_id;
        private string rcpdate;
        private string ischarged;
        private string chargedate;
        private string chargeby;
        private string recipelfee;
        private string realfee;
        private string unlocked;
        private string retappstat;
        private string rcptype;

        /// <summary>
        /// 处方类型
        /// </summary>
        public string Rcptype
        {
            get { return rcptype; }
            set { rcptype = value; }
        }
        
        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 挂号外键
        /// </summary>
        public string Regist_id
        {
            get { return regist_id; }
            set { regist_id = value; }
        }
        /// <summary>
        /// 发票号
        /// </summary>
        public string ClinicInvoice
        {
            get { return clinicInvoice; }
            set { clinicInvoice = value; }
        }
        /// <summary>
        /// 挂号编号/处方编号/检验单号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// 挂号.id
        /// </summary>
        public string Clinic_rcp_id
        {
            get { return clinic_rcp_id; }
            set { clinic_rcp_id = value; }
        }
        /// <summary>
        /// 已执行
        /// </summary>
        public string Executed
        {
            get { return executed; }
            set { executed = value; }
        }
        /// <summary>
        /// 处方科室外键
        /// </summary>
        public string Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        /// <summary>
        /// 处方医生外键
        /// </summary>
        public string Doctor_id
        {
            get { return doctor_id; }
            set { doctor_id = value; }
        }
        /// <summary>
        /// 处方时间
        /// </summary>
        public string Rcpdate
        {
            get { return rcpdate; }
            set { rcpdate = value; }
        }
        /// <summary>
        /// 是否收费
        /// </summary>
        public string Ischarged
        {
            get { return ischarged; }
            set { ischarged = value; }
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
        /// 应收金额
        /// </summary>
        public string Recipelfee
        {
            get { return recipelfee; }
            set { recipelfee = value; }
        }
        /// <summary>
        /// 实收金额
        /// </summary>
        public string Realfee
        {
            get { return realfee; }
            set { realfee = value; }
        }
        /// <summary>
        /// 退方解锁
        /// </summary>
        public string Unlocked
        {
            get { return unlocked; }
            set { unlocked = value; }
        }

        /// <summary>
        /// 医生申请
        /// </summary>
        public string Retappstat
        {
            get { return retappstat; }
            set { retappstat = value; }
        }

    }
}
