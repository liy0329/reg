using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsp.bo
{
    class IhspRetapp
    {

        private string billcode;
        /// <summary>
        /// 单号
        /// </summary>
        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }

        private string ihsp_id;
        /// <summary>
        /// 住院号外键
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string appdep_id;
        /// <summary>
        /// 申请科室外键
        /// </summary>
        public string Appdep_id
        {
            get { return appdep_id; }
            set { appdep_id = value; }
        }
        private string apper_id;
        /// <summary>
        /// 申请员
        /// </summary>
        public string Apper_id
        {
            get { return apper_id; }
            set { apper_id = value; }
        }
        private string bedname;
        /// <summary>
        /// 床号
        /// </summary>
        public string Bedname
        {
            get { return bedname; }
            set { bedname = value; }
        }
        private string sickname;
        /// <summary>
        /// 病号姓名
        /// </summary>
        public string Sickname
        {
            get { return sickname; }
            set { sickname = value; }
        }
        private string appdate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public string Appdate
        {
            get { return appdate; }
            set { appdate = value; }
        }
        private string status;
        /// <summary>
        /// 申请状态
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string amount;
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private string approver_id;
        /// <summary>
        /// 审批人
        /// </summary>
        public string Approver_id
        {
            get { return approver_id; }
            set { approver_id = value; }
        }
        private string approvedate;
        /// <summary>
        /// 审批时间
        /// </summary>
        public string Approvedate
        {
            get { return approvedate; }
            set { approvedate = value; }
        }
        private string chker;
        /// <summary>
        /// 审核者
        /// </summary>
        public string Chker
        {
            get { return chker; }
            set { chker = value; }
        }
        private string chkdate;
        /// <summary>
        /// 审核时间
        /// </summary>
        public string Chkdate
        {
            get { return chkdate; }
            set { chkdate = value; }
        }
    }
}
