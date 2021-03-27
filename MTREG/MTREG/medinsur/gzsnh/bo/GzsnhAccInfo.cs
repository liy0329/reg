using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsnh.bo
{
    class GzsnhAccInfo
    {
        private string redeemNo;
        /// <summary>
        /// 补偿类型编码
        /// </summary>
        public string RedeemNo
        {
            get { return redeemNo; }
            set { redeemNo = value; }
        }
        private string outDate;
        /// <summary>
        /// 出院时间
        /// </summary>
        public string OutDate
        {
            get { return outDate; }
            set { outDate = value; }
        }
        private string isMaterials;
        /// <summary>
        /// 身份材料属性证明
        /// </summary>
        public string IsMaterials
        {
            get { return isMaterials; }
            set { isMaterials = value; }
        }
    }
}
