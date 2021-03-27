using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class DrugIo
    {
        private String actdept_id;
        private String objdept_id;
        private String amount;
        private String createdate;
        private string clinic_cost_id;
        private string id;
        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 处方科室
        /// </summary>
        public String Actdept_id
        {
            get { return actdept_id; }
            set { actdept_id = value; }
        }
        /// <summary>
        /// 执行科室
        /// </summary>
        public String Objdept_id
        {
            get { return objdept_id; }
            set { objdept_id = value; }
        }
        /// <summary>
        /// 单据金额
        /// </summary>
        public String Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public String Createdate
        {
            get { return createdate; }
            set { createdate = value; }
        }
        /// <summary>
        /// 收费主表外键
        /// </summary>
        public string Clinic_cost_id
        {
            get { return clinic_cost_id; }
            set { clinic_cost_id = value; }
        }
    }
}
