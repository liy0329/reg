using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsp.bo
{
    class IhspPayinadvFrm
    {
        private string ihspcode;
        /// <summary>
        /// 住院号
        /// </summary>
        public string Ihspcode
        {
            get { return ihspcode; }
            set { ihspcode = value; }
        }
        private string name;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
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
        private string paytype;
        /// <summary>
        /// 支付方式
        /// </summary>
        public string Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        private string retchrg;
        /// <summary>
        /// 撤销金额
        /// </summary>
        public string Retchrg
        {
            get { return retchrg; }
            set { retchrg = value; }
        }
        private string billcode;
        /// <summary>
        /// 单据号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        private string age;
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        private string sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string hspcard;
        /// <summary>
        /// 卡号
        /// </summary>
        public string Hspcard
        {
            get { return hspcard; }
            set { hspcard = value; }
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
        private string doctor;
        /// <summary>
        /// 医生
        /// </summary>
        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }
        private string prepamt;
        /// <summary>
        /// 金额
        /// </summary>
        public string Prepamt
        {
            get { return prepamt; }
            set { prepamt = value; }
        }

    }
}
