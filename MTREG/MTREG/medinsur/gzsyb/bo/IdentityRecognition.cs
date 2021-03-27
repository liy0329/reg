using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// §3.7.2.	身份识别（03）
    /// </summary>
    class IdentityRecognition
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string xmlCode_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>";
            return data;
        }
        public string xmlCode_in()
        {
            string data = "<input><proxy>1</proxy></input>";
            return data;
        }
    }
}
