using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ChargeManage
    {
        private string regBillcode;
        private string patientName;
        private string hspCard;
        private string depart_id;
        private string doctor_id;
        private String startDate;
        private String endDate;
        private string islock;
        private string isret;
        private string chargeby;
        private string fph;
        /// <summary>
        /// 电话
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 是否退费
        /// </summary>
        public string Fph
        {
            get { return fph; }
            set { fph = value; }
        }
        /// <summary>
        /// 是否退费
        /// </summary>
        public string Isret
        {
            get { return isret; }
            set { isret = value; }
        }
        /// <summary>
        /// 门诊编号    挂号编号
        /// </summary>
        public string RegBillcode
        {
            get { return regBillcode; }
            set { regBillcode = value; }
        }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }
        /// <summary>
        /// 卡号
        /// </summary>
        public string HspCard
        {
            get { return hspCard; }
            set { hspCard = value; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        /// <summary>
        /// 医生
        /// </summary>
        public string Doctor_id
        {
            get { return doctor_id; }
            set { doctor_id = value; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public String StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public String EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        /// <summary>
        /// 是否解锁
        /// </summary>
        public string Islock
        {
            get { return islock; }
            set { islock = value; }
        }
        /// <summary>
        /// 收费员
        /// </summary>
        public string Chargeby
        {
            get { return chargeby; }
            set { chargeby = value; }
        } 
    }
}
