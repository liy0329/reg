using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsp.bo
{
    class Ihspguaranfee
    {
        private string id;
        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string ihspid;
        /// <summary>
        /// 住院记录外键
        /// </summary>
        public string Ihspid
        {
            get { return ihspid; }
            set { ihspid = value; }
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
        /// 担保人
        /// </summary>
        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }
        private string enddate;
        /// <summary>
        /// 担保期限
        /// </summary>
        public string Enddate
        {
            get { return enddate; }
            set { enddate = value; }
        }
        private string amt;
        /// <summary>
        /// 担保金额
        /// </summary>
        public string Amt
        {
            get { return amt; }
            set { amt = value; }
        }
        private string createdate;
        /// <summary>
        /// 记录时间
        /// </summary>
        public string Createdate
        {
            get { return createdate; }
            set { createdate = value; }
        }
        private string memo;
        /// <summary>
        /// 担保说明
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
        private string createdby;
        /// <summary>
        /// 记录人
        /// </summary>
        public string Createdby
        {
            get { return createdby; }
            set { createdby = value; }
        }
    }
}
