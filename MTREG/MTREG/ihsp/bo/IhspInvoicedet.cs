using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsp.bo
{
    class IhspInvoicedet
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string ihspAccountId;//发票外键

        public string IhspAccountId
        {
            get { return ihspAccountId; }
            set { ihspAccountId = value; }
        }
        private string payfee;//金额

        public string Payfee
        {
            get { return payfee; }
            set { payfee = value; }
        }
        private string paysumbyId;//支付汇总

        public string PaysumbyId
        {
            get { return paysumbyId; }
            set { paysumbyId = value; }
        }
        private string paytypeId;//收款类型

        public string PaytypeId
        {
            get { return paytypeId; }
            set { paytypeId = value; }
        }
        private string billcode;//单据号

        public string Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        private string cheque;//支票号

        public string Cheque
        {
            get { return cheque; }
            set { cheque = value; }
        }
        private string isfirst;//是否首选

        public string Isfirst
        {
            get { return isfirst; }
            set { isfirst = value; }
        }
    }
}
