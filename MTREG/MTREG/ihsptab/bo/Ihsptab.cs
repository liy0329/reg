using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsptab.bo
{
    class Ihsptab
    {
        /// <summary>
        /// 日结生成班结 标示
        /// </summary>
        private string daytab;

        public string Daytab
        {
            get { return daytab; }
            set { daytab = value; }
        }

        private string paytype;
        /// <summary>
        /// 付款方式
        /// </summary>
        public string Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        private string id;
        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string billcode;
        /// <summary>
        /// 日结号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        private string startdate;
        /// <summary>
        /// 开始时间
        /// </summary>
        public string Startdate
        {
            get { return startdate; }
            set { startdate = value; }
        }
        private string enddate;
        /// <summary>
        /// 截止时间
        /// </summary>
        public string Enddate
        {
            get { return enddate; }
            set { enddate = value; }
        }
        private string depart_id;
        /// <summary>
        /// 收费员科室
        /// </summary>
        public string Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        private string charger_id;
        /// <summary>
        /// 收费员
        /// </summary>
        public string Charger_id
        {
            get { return charger_id; }
            set { charger_id = value; }
        }
        private string settleby;
        /// <summary>
        /// 日结人
        /// </summary>
        public string Settleby
        {
            get { return settleby; }
            set { settleby = value; }
        }
        private string settledate;

        public string Settledate
        {
            get { return settledate; }
            set { settledate = value; }
        }
    }
}
