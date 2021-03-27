using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clintab.bo
{
    class Clinictab
    {
        private string id;

        private string billcode;
        private string startdate;
        private string enddate;
        private string charger_id;
        private string depart_id;
        private string settledate;
        private string settleby;
        private string daytab;


        public string Daytab
        {
            get { return daytab; }
            set { daytab = value; }
        }


        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 日结单号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string Startdate
        {
            get { return startdate; }
            set { startdate = value; }
        }
        /// <summary>
        /// 截止时间
        /// </summary>
        public string Enddate
        {
            get { return enddate; }
            set { enddate = value; }
        }
        /// <summary>
        /// 收费员
        /// </summary>
        public string Charger_id
        {
            get { return charger_id; }
            set { charger_id = value; }
        }
        /// <summary>
        /// 结算科室
        /// </summary>
        public string Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        /// <summary>
        /// 日结时间
        /// </summary>
        public string Settledate
        {
            get { return settledate; }
            set { settledate = value; }
        }
        /// <summary>
        /// 日结人
        /// </summary>
        public string Settleby
        {
            get { return settleby; }
            set { settleby = value; }
        }
        

    }
}
