using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ChargeManagePatientInfo
    {
        private string patientName;
        private string hspcard;
        private string sex;
        private string depart;
        private string doctor;
        private string idcard;
        private string regbillcode;
        private string age;
        private string amount;
        private string regist_id;
        private string invoice_id;
        private string bas_patienttype_id;
        private string invoicecode;
        private string patienttypeKeyname;


        /// <summary>
        /// 门诊号
        /// </summary>
        public string Regbillcode
        {
            get { return regbillcode; }
            set { regbillcode = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        /// <summary>
        /// 金额
        /// </summary>
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }
        /// <summary>
        /// 卡号
        /// </summary>
        public string Hspcard
        {
            get { return hspcard; }
            set { hspcard = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string Depart
        {
            get { return depart; }
            set { depart = value; }
        }
        /// <summary>
        /// 医生
        /// </summary>
        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idcard
        {
            get { return idcard; }
            set { idcard = value; }
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
        /// 发票ID
        /// </summary>
        public string Invoice_id
        {
            get { return invoice_id; }
            set { invoice_id = value; }
        }
        /// <summary>
        /// 患者类型外键
        /// </summary>
        public string Bas_patienttype_id
        {
            get { return bas_patienttype_id; }
            set { bas_patienttype_id = value; }
        }
        /// <summary>
        /// 单据号
        /// </summary>
        public string Invoicecode
        {
            get { return invoicecode; }
            set { invoicecode = value; }
        }
        /// <summary>
        /// 患者类型keyname
        /// </summary>
        public string PatienttypeKeyname
        {
            get { return patienttypeKeyname; }
            set { patienttypeKeyname = value; }
        }
    }
}
