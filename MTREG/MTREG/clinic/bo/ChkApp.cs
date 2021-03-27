using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ChkApp
    {
        private string billcode;
        private string regist_id;
        private string registkind;
        private string dep_id;
        private string doctor_id;
        private string rcpdate;
        private string exedep_id;
        private string clinic_record_id;
        private string fee;
        private string name;
        private string diagnset_id;
        private string instuction;

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Instuction
        {
            get { return instuction; }
            set { instuction = value; }
        }
        private string chk_sampletype_id;

        public string Chk_sampletype_id
        {
            get { return chk_sampletype_id; }
            set { chk_sampletype_id = value; }
        }
        private string chk_type_id;

        public string Chk_type_id
        {
            get { return chk_type_id; }
            set { chk_type_id = value; }
        }
        private string chk_opkind_id;

        public string Chk_opkind_id
        {
            get { return chk_opkind_id; }
            set { chk_opkind_id = value; }
        }
        private string num;

        public string Num
        {
            get { return num; }
            set { num = value; }
        }
        private string sendstat;

        public string Sendstat
        {
            get { return sendstat; }
            set { sendstat = value; }
        }
        public string Diagnset_id
        {
            get { return diagnset_id; }
            set { diagnset_id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string syncost;
        private string opstat;
        /// <summary>
        /// 检查单号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// 外键就诊记录表
        /// </summary>
        public string Regist_id
        {
            get { return regist_id; }
            set { regist_id = value; }
        }
        /// <summary>
        /// 就诊类型
        /// </summary>
        public string Registkind
        {
            get { return registkind; }
            set { registkind = value; }
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
        /// 执行科室
        /// </summary>
        public string Exedep_id
        {
            get { return exedep_id; }
            set { exedep_id = value; }
        }
        /// <summary>
        /// 病历id
        /// </summary>
        public string Clinic_record_id
        {
            get { return clinic_record_id; }
            set { clinic_record_id = value; }
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
        /// 同步费用表
        /// </summary>
        public string Syncost
        {
            get { return syncost; }
            set { syncost = value; }
        }

        /// <summary>
        /// 处方状态
        /// </summary>
        public string Opstat
        {
            get { return opstat; }
            set { opstat = value; }
        }
    }
}
