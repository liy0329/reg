using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace MTHIS.db
{
    public class ProcParma
    {
        string paramName;

        public string ParamName
        {
            get { return paramName; }
            set { paramName = value; }
        }
        int paramtype;
        /// <summary>
        /// paramtype: 1:int, 2:string, 3:bool, 4:datetime
        /// </summary>
        public int Paramtype
        {
            get { return paramtype; }
            set { paramtype = value; }
        }
        int lenth;

        public int Lenth
        {
            get { return lenth; }
            set { lenth = value; }
        }
        object paramVal;

        public object ParamVal
        {
            get { return paramVal; }
            set { paramVal = value; }
        }
    }
}
