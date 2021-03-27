using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb
{
     public class Mzybdk
    {
         private string _grbh; //个人编号|身份证号|单位编号 |IC卡号|姓名|性别|出生日期

        public string Grbh
        {
            get { return _grbh; }
            set { _grbh = value; }
        }

        private string _sfck;

        public string Sfck
        {
            get { return _sfck; }
            set { _sfck = value; }
        }
        private string _qh;

        public string Qh
        {
            get { return _qh; }
            set { _qh = value; }
        }
        private string _sfzh;

        public string Sfzh
        {
            get { return _sfzh; }
            set { _sfzh = value; }
        }
        private string _dwbh;

        public string Dwbh
        {
            get { return _dwbh; }
            set { _dwbh = value; }
        }
        private string _ickh;

        public string Ickh
        {
            get { return _ickh; }
            set { _ickh = value; }
        }
        private string _xm;

        public string Xm
        {
            get { return _xm; }
            set { _xm = value; }
        }
        private string _xb;

        public string Xb
        {
            get { return _xb; }
            set { _xb = value; }
        }
        private string _csrq;

        public string Csrq
        {
            get { return _csrq; }
            set { _csrq = value; }
        }
        private string dwmc;//单位名称

        public string Dwmc
        {
            get { return dwmc; }
            set { dwmc = value; }
        }
        private string zhye;//余额

        public string Zhye
        {
            get { return zhye; }
            set { zhye = value; }
        }

        private string yllb;//医疗类别

        public string Yllb
        {
            get { return yllb; }
            set { yllb = value; }
        }
        private string jbbm;//疾病编码

        public string Jbbm
        {
            get { return jbbm; }
            set { jbbm = value; }
        }

        private string jbmc;//疾病名称

        public string Jbmc
        {
            get { return jbmc; }
            set { jbmc = value; }
        }

        private string sfsk;//是否封锁

        public string  Sfsk
        {
            get { return sfsk; }
            set { sfsk = value; }
        }
    }
}
