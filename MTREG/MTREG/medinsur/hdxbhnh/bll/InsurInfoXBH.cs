using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdxbhnh.bll
{
    class InsurInfoXBH
    {
        private string personJoinNum;
        /// <summary>
        /// 参合证号
        /// </summary>
        public string PersonJoinNum
        {
            get { return personJoinNum; }
            set { personJoinNum = value; }
        }
        private string zoneCode;
        /// <summary>
        /// 区域编码
        /// </summary>
        public string ZoneCode
        {
            get { return zoneCode; }
            set { zoneCode = value; }
        }

    }
}
