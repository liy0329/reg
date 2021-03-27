using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class InsurInfoParam
    {
        private string patientName;

        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }
        private string startDate;

        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private string endDate;

        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
    }
}
