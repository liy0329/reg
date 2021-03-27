using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dryzhxx_out
    {
        private string _nd;
        private string _lnjz;
        private string _bnzr;
        private string _sxsj;
        private string _fyhj;
        private string _zycs;
        private string _zhzc;
        private string _tczc;
        private string _grzf;
        private string _zf;
        private string _jzjlj;
        private string _zytc;
        private string _mzdbtc;
        private string _mztstclj;
        private string _mztsjbqfbzlj;
        private string _jtbclj;
        private string _fhjbyllj;
        private string _jrtclj;
        private string _ylzd;
        private string _gwytclj;
        private string _ylzd2;
        private string _mzmxbtczflj;
        private string _ylzd3;
        private string _zyfhjbyl;
        private string _mxbqfbz;
        private string _mxbfhjbyl;
        private string _dxjctclj;
        private string _dxjcfhjbyl;
        private string _mztsbfhjbyl;
        private string _zwmztclj;
        private string _zwmzfhjbyl;
        private string _message;

        //年度|历年结转|本年注入|刷新时间|费用合计|住院次数|帐户支出|统筹支出|个人支付|自费（用做符合基本医疗累计）|结转金累计|
            //住院统筹|门诊大病统筹|门诊特殊统筹累计|门诊特殊疾病起付标准累计|家庭病床累计|符合基本医疗累计|进入统筹累计|预留字段|公务员统筹累计
            //|预留字段|门诊慢性病统筹支付累计|预留字段|住院符合基本医疗|慢性病起付标准|慢性病符合基本医疗|大型检查统筹累计|大型检查符合基本医疗|
            //门诊特殊病符合基本医疗|转外门诊统筹累计|转外门诊符合基本医疗
        public string Nd
        {
            set { _nd = value; }
            get { return _nd; }
        }
        public string Lnjz
        {
            set { _lnjz = value; }
            get { return _lnjz; }
        }
        public string Bnzr
        {
            set { _bnzr = value; }
            get { return _bnzr; }
        }
        public string Sxsj
        {
            set { _sxsj = value; }
            get { return _sxsj; }
        }
        public string Fyhj
        {
            set { _fyhj = value; }
            get { return _fyhj; }
        }
        public string Zycs
        {
            set { _zycs = value; }
            get { return _zycs; }
        }
        public string Zhzc
        {
            set { _zhzc = value; }
            get { return _zhzc; }
        }
        public string Tczc
        {
            set { _tczc = value; }
            get { return _tczc; }
        }
        public string Grzf
        {
            set { _grzf = value; }
            get { return _grzf; }
        }
        public string Zf
        {
            set { _zf = value; }
            get { return _zf; }
        }
        public string Jzjlj
        {
            set { _jzjlj = value; }
            get { return _jzjlj; }
        }
        //住院统筹|门诊大病统筹|门诊特殊统筹累计|门诊特殊疾病起付标准累计|家庭病床累计|符合基本医疗累计|进入统筹累计|预留字段|公务员统筹累计
        public string Zytc
        {
            set { _zytc = value; }
            get { return _zytc; }
        }
        public string Mzdbtc
        {
            set { _mzdbtc = value; }
            get { return _mzdbtc; }
        }
        public string Mztstclj
        {
            set { _mztstclj = value; }
            get { return _mztstclj; }
        }
        public string Mztsjbqfbzlj
        {
            set { _mztsjbqfbzlj = value; }
            get { return _mztsjbqfbzlj; }
        }
        public string Jtbclj
        {
            set { _jtbclj = value; }
            get { return _jtbclj; }
        }
        public string Fhjbyllj
        {
            set { _fhjbyllj = value; }
            get { return _fhjbyllj; }
        }
        public string Jrtclj
        {
            set { _jrtclj = value; }
            get { return _jrtclj; }
        }
        public string Ylzd
        {
            set { _ylzd = value; }
            get { return _ylzd; }
        }
        public string Gwytclj
        {
            set { _gwytclj = value; }
            get { return _gwytclj; }
        }
        //|预留字段|门诊慢性病统筹支付累计|预留字段|住院符合基本医疗|慢性病起付标准|慢性病符合基本医疗|大型检查统筹累计|大型检查符合基本医疗|
        public string Ylzd2
        {
            set { _ylzd2 = value; }
            get { return _ylzd2; }
        }
        public string Mzmxbtczflj
        {
            set { _mzmxbtczflj = value; }
            get { return _mzmxbtczflj; }
        }
        public string Ylzd3
        {
            set { _ylzd3 = value; }
            get { return _ylzd3; }
        }
        public string Zyfhjbyl
        {
            set { _zyfhjbyl = value; }
            get { return _zyfhjbyl; }
        }
        public string Mxbqfbz
        {
            set { _mxbqfbz = value; }
            get { return _mxbqfbz; }
        }
        public string Mxbfhjbyl
        {
            set { _mxbfhjbyl = value; }
            get { return _mxbfhjbyl; }
        }
        public string Dxjctclj
        {
            set { _dxjctclj = value; }
            get { return _dxjctclj; }
        }
        public string Dxjcfhjbyl
        {
            set { _dxjcfhjbyl = value; }
            get { return _dxjcfhjbyl; }
        }
        //门诊特殊病符合基本医疗|转外门诊统筹累计|转外门诊符合基本医疗
        public string Mztsbfhjbyl
        {
            set { _mztsbfhjbyl = value; }
            get { return _mztsbfhjbyl; }
        }
        public string Zwmztclj
        {
            set { _zwmztclj = value; }
            get { return _zwmztclj; }
        }
        public string Zwmzfhjbyl
        {
            set { _zwmzfhjbyl = value; }
            get { return _zwmzfhjbyl; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
