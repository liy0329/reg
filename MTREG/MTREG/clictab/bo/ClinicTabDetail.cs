using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clintab.bo
{
    class ClinicTabDetail
    {
        private string clinictab_id;
        private string bas_paytype_id;
        private string bas_patienttype_id;
        private string num;
        private string fee;
        private string retnum;
        private string retfee;
        private string realnum;
        private string realfee;
        /// <summary>
        /// 主表外键
        /// </summary>
        public string Clinictab_id
        {
            get { return clinictab_id; }
            set { clinictab_id = value; }
        }
        /// <summary>
        /// 支付类型外键
        /// </summary>
        public string Bas_paytype_id
        {
            get { return bas_paytype_id; }
            set { bas_paytype_id = value; }
        }
        /// <summary>
        /// 患者类型
        /// </summary>
        public string Bas_patienttype_id
        {
            get { return bas_patienttype_id; }
            set { bas_patienttype_id = value; }
        }
        /// <summary>
        /// 收款发票数
        /// </summary>
        public string Num
        {
            get { return num; }
            set { num = value; }
        }
        /// <summary>
        /// 收款金额
        /// </summary>
        public string Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        /// <summary>
        /// 退费发票数
        /// </summary>
        public string Retnum
        {
            get { return retnum; }
            set { retnum = value; }
        }
        /// <summary>
        /// 退费金额
        /// </summary>
        public string Retfee
        {
            get { return retfee; }
            set { retfee = value; }
        }
        /// <summary>
        /// 实收发票数
        /// </summary>
        public string Realnum
        {
            get { return realnum; }
            set { realnum = value; }
        }
        /// <summary>
        /// 实收金额
        /// </summary>
        public string Realfee
        {
            get { return realfee; }
            set { realfee = value; }
        }

    }
}
