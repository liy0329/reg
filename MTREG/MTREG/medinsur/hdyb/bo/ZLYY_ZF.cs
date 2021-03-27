using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    public class ZLYY
    {
        //医院名称|科室| 流水号 //住院号 | 住院时间 | 住院天数  //  姓名| 性别 //左列。。。床位费 | 诊查费|检查费|化验费|治疗费|手术费 //右列。。。护理费|卫生材料费|药品费|药事服务费|一般诊疗费|其他住院费用|输血费  //合计(大写) | (数字) //预交金额 | 退费金额//收款人 | 收款日期
        private string _yymc;//医院名称
        private string _ks;//科室
        private string _lsh;//流水号
        private string _zyh;//住院号
        private string _zykssj;//住院开始时间
        private string _zyjssj;//住院结束时间
        private string _zyts;//住院天数
        private string _hzxm;//患者姓名
        private string _hzxb;//患者性别
        private string _cwf;//床位费
        private string _zcf;//诊查费
        private string _jcf;//检查费
        private string _hyf;//化验费
        private string _zlf;//治疗费
        private string _ssf;//手术费
        private string _hlf;//护理费
        private string _wsclf;//卫生材料费
        private string _ypf;//药品费
        private string _ysfwf;//药事服务费
        private string _ybzlf;//一般诊疗费
        private string _qtzyfy;//其他住院费用
        private string _sxf;//输血费
        private string _hjdx;//合计(大写)
        private string _hjsz;//合计(数字)
        private string _yjje;//预交金额 
        private string _tfje;//退费金额
        private string _skr;//收款人 
        private string _skrq;// 收款日期

        //医院名称|科室| 流水号|住院号  4
        public string Yymc
        {
            set { _yymc = value; }
            get { return _yymc;  }
        }
        public string Ks
        {
            set { _ks = value; }
            get { return _ks;  }
        }
        public string Lsh
        {
            set { _lsh = value; }
            get { return _lsh;  }
        }
        public string Zyh
        {
            set { _zyh = value; }
            get { return _zyh;  }
        }
        // 住院开始时间 |住院结束时间| 住院天数 | 姓名| 性别 5
        public string Zykssj
        {
            set { _zykssj = value; }
            get { return _zykssj;  }
        }
        public string Zyjssj
        {
            set { _zyjssj = value; }
            get { return _zyjssj;  }
        }
        public string Zyts 
        {
            set { _zyts = value; }
            get { return _zyts;  }
        }
        public string Hzxm
        {
            set { _hzxm = value; }
            get { return _hzxm; }
        }
        public string Hzxb
        {
            set { _hzxb = value; }
            get { return _hzxb; }
        }
        //床位费 | 诊查费|检查费|化验费|治疗费|手术费 6
        public string Cwf
        {
            set { _cwf = value; }
            get { return _cwf; }
        }
        public string Zcf
        {
            set { _zcf = value; }
            get { return _zcf; }
        }
        public string Jcf
        {
            set { _jcf = value; }
            get { return _jcf; }
        }
        public string Hyf
        {
            set { _hyf = value; }
            get { return _hyf; }
        }
        public string Zlf
        {
            set { _zlf = value; }
            get { return _zlf; }
        }
        public string Ssf
        {
            set { _ssf = value; }
            get { return _ssf; }
        }
        //护理费|卫生材料费|药品费|药事服务费|一般诊疗费|其他住院费用|输血费 7
        public string Hlf
        {
            set { _hlf = value; }
            get { return _hlf; }
        }
        public string Wsclf
        {
            set { _wsclf = value; }
            get { return _wsclf; }
        }
        public string Ypf
        {
            set { _ypf = value; }
            get { return _ypf; }
        }
        public string Ysfwf
        {
            set { _ysfwf = value; }
            get { return _ysfwf; }
        }
        public string Ybzlf
        {
            set { _ybzlf = value; }
            get { return _ybzlf; }
        }
        public string Qtzyfy
        {
            set { _qtzyfy = value; }
            get { return _qtzyfy; }
        }
        public string Sxf
        {
            set { _sxf = value; }
            get { return _sxf; }
        }
        //合计(大写) | (数字)|预交金额 | 退费金额|收款人 | 收款日期 6
        public string Hjdx
        {
            set { _hjdx = value; }
            get { return _hjdx; }
        }
        public string Hjsz
        {
            set { _hjsz = value; }
            get { return _hjsz; }
        }
        public string Yjje
        {
            set { _yjje = value; }
            get { return _yjje; }
        }
        public string Tfje
        {
            set { _tfje = value; }
            get { return _tfje; }
        }
        public string Skr
        {
            set { _skr = value; }
            get { return _skr; }
        }
        public string Skrq
        {
            set { _skrq  = value; }
            get { return _skrq ; }
        }
    }
}
