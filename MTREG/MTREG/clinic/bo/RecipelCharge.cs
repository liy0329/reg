using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class RecipelCharge
    {
        private String patientName;
        private String dtpRecipelDateFrom;
        private String dtpRecipelDateTo;
        private String tbxID;
        private String cmbDepart;
        private String tbxClinicID;
        public String PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }
        public String DtpRecipelDateFrom
        {
            get { return dtpRecipelDateFrom; }
            set { dtpRecipelDateFrom = value; }
        }
        public String DtpRecipelDateTo
        {
            get { return dtpRecipelDateTo; }
            set { dtpRecipelDateTo = value; }
        }
        public String TbxID
        {
            get { return tbxID; }
            set { tbxID = value; }
        }
        public String CmbDepart
        {
            get { return cmbDepart; }
            set { cmbDepart = value; }
        }
        public String TbxClinicID
        {
            get { return tbxClinicID; }
            set { tbxClinicID = value; }
        }

    }
}
