using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    class ValidAttribute:Attribute
    {
        private bool required = false;

        public bool Required
        {
            get { return required; }
            set { required = value; }
        }

        private string defaultValue;

        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        private string description = "必需字段不能为空！";

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
