using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ClinicInvoiceDet
    {
        private string payfee;
        private string bas_paytype_id;
        private string cheque;
        private string bas_paysumby_id;
        private string clinic_invoice_id;

        /// <summary>
        /// 发票外键id
        /// </summary>
        public string Clinic_invoice_id
        {
            get { return clinic_invoice_id; }
            set { clinic_invoice_id = value; }
        }
      
        /// <summary>
        /// 汇总累呗
        /// </summary>
        public string Bas_paysumby_id
        {
            get { return bas_paysumby_id; }
            set { bas_paysumby_id = value; }
        }
        /// <summary>
        /// 应付金额
        /// </summary>
        public string Payfee
        {
            get { return payfee; }
            set { payfee = value; }
        }
        
        /// <summary>
        /// 收款类型
        /// </summary>
        public string Bas_paytype_id
        {
            get { return bas_paytype_id; }
            set { bas_paytype_id = value; }
        }
        
        /// <summary>
        /// 支票号
        /// </summary>
        public string Cheque
        {
            get { return cheque; }
            set { cheque = value; }
        }

    }
}
