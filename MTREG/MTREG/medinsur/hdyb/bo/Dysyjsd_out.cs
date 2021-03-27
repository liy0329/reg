using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dysyjsd_out
    {
        //医保中心名称|医院住院号|单据号|定点医院名称|科室|住院次数|患者姓名|住院号|入院日期|出院日期|住院天数|个人编号|IC卡号|人员类别|是否公务员|实收金额|
        //生育医疗费定额补贴金额|个人支付现金|经办人|结算日期
        private string _ybzxmc;
        private string _yyzyh;
        private string _djh;
        private string _ddyymc;
        private string _ks;
        private string _zycs;
        private string _hzxm;
        private string _zyh;
        private string _ryrq;
        private string _cyrq;
        private string _zyts;
        private string _grbh;
        private string _ickh;
        private string _rylb;
        private string _sfgwy;
        private string _ssje;
        private string _syylfdebtje;
        private string _grzfxj;
        private string _jbr;
        private string _jsrq;
        private string _message;
        private string rmb;
        private string yj;
        private string tbxj;

        public string Tbxj
        {
            get { return tbxj; }
            set { tbxj = value; }
        }

        public string Yj
        {
            get { return yj; }
            set { yj = value; }
        }

        public string Rmb
        {
            get { return rmb; }
            set { rmb = value; }
        }

        public string Ybzxmc
        {
            set { _ybzxmc = value; }
            get { return _ybzxmc; }
        }
        public string Yyzyh
        {
            set { _yyzyh = value; }
            get { return _yyzyh; }
        }
        public string Djh
        {
            set { _djh = value; }
            get { return _djh; }
        }
        public string Ddyymc
        {
            set { _ddyymc = value; }
            get { return _ddyymc; }
        }
        public string Ks
        {
            set { _ks = value; }
            get { return _ks; }
        }
        public string Zycs
        {
            set { _zycs = value; }
            get { return _zycs; }
        }
        //患者姓名|住院号|入院日期|出院日期|住院天数|个人编号|IC卡号|人员类别|是否公务员|实收金额|
        public string Hzxm
        {
            set { _hzxm = value; }
            get { return _hzxm; }
        }
        public string Zyh
        {
            set { _zyh = value; }
            get { return _zyh; }
        }
        public string Ryrq
        {
            set { _ryrq = value; }
            get { return _ryrq; }
        }
        public string Cyrq
        {
            set { _cyrq = value; }
            get { return _cyrq; }
        }
        public string Zyts
        {
            set { _zyts = value; }
            get { return _zyts; }
        }
        public string Grbh
        {
            set { _grbh = value; }
            get { return _grbh; }
        }
        public string Ickh
        {
            set { _ickh = value; }
            get { return _ickh; }
        }
        public string Rylb
        {
            set { _rylb = value; }
            get { return _rylb; }
        }
        public string Sfgwy
        {
            set { _sfgwy = value; }
            get { return _sfgwy; }
        }
        public string Ssje
        {
            set { _ssje = value; }
            get { return _ssje; }
        }
        //生育医疗费定额补贴金额|个人支付现金|经办人|结算日期
        public string Syylfdebtje
        {
            set { _syylfdebtje = value; }
            get { return _syylfdebtje; }
        }
        public string Grzfxj
        {
            set { _grzfxj = value; }
            get { return _grzfxj; }
        }
        public string Jbr
        {
            set { _jbr = value; }
            get { return _jbr; }
        }
        public string Jsrq
        {
            set { _jsrq = value; }
            get { return _jsrq; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
