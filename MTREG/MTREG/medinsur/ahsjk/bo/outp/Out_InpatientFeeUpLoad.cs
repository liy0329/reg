using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.outp
{
  public class Out_InpatientFeeUpLoad
    {
                       
       // private string sCenterKey;//中心明细关键字

        public string sCenterKey
        {
            get;
            set;
        }
       // private string sApply;//可报销总金额

        public string sApply
        {
            get;
            set;
        }
        //private string sOwn;//自付金额/先付金额

        public string sOwn
        {
            get;
            set;
        }
       // private string sSelf;//自费金额

        public string sSelf
        {
            get;
            set;
        }
       // private string sMaxPrice;//最高限价

        public string sMaxPrice
        {
            get;
            set;
        }
        //private string sApplyBL;//进统筹比例

        public string sApplyBL
        {
            get;
            set;
        }
       // private string sLimitPrice;//限段金额

        public string sLimitPrice
        {
            get;
            set;
        }
        //private string sLowBL;//低于限段进统筹比例

        public string sLowBL
        {
            get;
            set;
        }
       // private string sHighBL;//高于限段进统筹比例

        public string sHighBL
        {
            get;
            set;
        }
        //private string sIfCMed;//是否中医诊疗项目

        public string sIfCMed
        {
            get;
            set;
        }
    }
}
