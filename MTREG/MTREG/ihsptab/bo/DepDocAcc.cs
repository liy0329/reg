using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsptab.bo
{
    class DepDocAcc
    {
        private string startTime;
        /// <summary>
        /// 起始时间
        /// </summary>
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private string endTime;
        /// <summary>
        /// 截止时间
        /// </summary>
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private string depart;
        /// <summary>
        /// 科室名称
        /// </summary>
        public string Depart
        {
            get { return depart; }
            set { depart = value; }
        }
        private string departid;
        /// <summary>
        /// 科室id
        /// </summary>
        public string Departid
        {
            get { return departid; }
            set { departid = value; }
        }
        private string itemtype1;
        /// <summary>
        /// 核算类别名称
        /// </summary>
        public string Itemtype1
        {
            get { return itemtype1; }
            set { itemtype1 = value; }
        }
        private string itemtype1id;
        /// <summary>
        /// 核算类别id
        /// </summary>
        public string Itemtype1id
        {
            get { return itemtype1id; }
            set { itemtype1id = value; }
        }
        private string patienttype;
        /// <summary>
        /// 患者类型名称
        /// </summary>
        public string Patienttype
        {
            get { return patienttype; }
            set { patienttype = value; }
        }
        private string patienttypeid;
        /// <summary>
        /// 患者类型id
        /// </summary>
        public string Patienttypeid
        {
            get { return patienttypeid; }
            set { patienttypeid = value; }
        }
        private string tablename;
        /// <summary>
        /// 表名
        /// </summary>
        public string Tablename
        {
            get { return tablename; }
            set { tablename = value; }
        }
    }
}
