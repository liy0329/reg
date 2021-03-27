using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ClinicRcp
    {
        private string regist_id;
        private string billcode;
        private string dep_id;
        private string doctor_id;
        private string rcpdate;
        private string fee;
        private string clinic_record_id;
        private string opstat;
        private string syncost;
        private string id;

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
        /// 处方编号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// 处方科室
        /// </summary>
        public string Dep_id
        {
            get { return dep_id; }
            set { dep_id = value; }
        }
        /// <summary>
        /// 处方医生
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
        /// 金额
        /// </summary>
        public string Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        /// <summary>
        /// 病历外键id
        /// </summary>
        public string Clinic_record_id
        {
            get { return clinic_record_id; }
            set { clinic_record_id = value; }
        }
        /// <summary>
        /// 处方状态
        /// </summary>
        public string Opstat
        {
            get { return opstat; }
            set { opstat = value; }
        }
        
        /// <summary>
        /// 同步费用表
        /// </summary>
        public string Syncost
        {
            get { return syncost; }
            set { syncost = value; }
        }
    }
}
