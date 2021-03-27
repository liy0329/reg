using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.dor
{
    class RetMsg
    {
        private string mesg;

        public string Mesg
        {
            get { return mesg; }
            set { mesg = value; }
        }

        private bool retint;

        public bool Retint
        {
            get { return retint; }
            set { retint = value; }
        }
    }
}
