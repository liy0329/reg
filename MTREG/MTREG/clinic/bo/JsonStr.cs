using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class InCall
    {
        /// <summary>
        /// 候诊编码
        /// </summary>
        string seqnum;

        public string Seqnum
        {
            get { return seqnum; }
            set { seqnum = value; }
        }

       
        string register_id;
        /// <summary>
        /// 挂号记录Id
        /// </summary>
        public string Register_id
        {
            get { return register_id; }
            set { register_id = value; }
        }

        string depart_id;
        /// <summary>
        /// 科室Id
        /// </summary>
        public string Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        string clinicroom_id;
        /// <summary>
        /// 诊室Id
        /// </summary>
        public string Clinicroom_id
        {
            get { return clinicroom_id; }
            set { clinicroom_id = value; }
        }
        string doctor;
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }
        string sickname;
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Sickname
        {
            get { return sickname; }
            set { sickname = value; }
        }
        string depart;
        /// <summary>
        /// 科室
        /// </summary>
        public string Depart
        {
            get { return depart; }
            set { depart = value; }
        }
        string clinicroom;
        /// <summary>
        /// 诊治室名称
        /// </summary>
        public string Clinicroom
        {
            get { return clinicroom; }
            set { clinicroom = value; }
        }
        string calladdr;

        public string Calladdr
        {
            get { return calladdr; }
            set { calladdr = value; }
        }
        string callserverurl;

        public string Callserverurl
        {
            get { return callserverurl; }
            set { callserverurl = value; }
        }
    }
}
