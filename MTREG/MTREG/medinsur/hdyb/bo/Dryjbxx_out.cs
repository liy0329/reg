using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dryjbxx_out
    {
        private string _grbh; //个人编号|身份证号|单位编号 |IC卡号|姓名|性别|出生日期|人员类别|参保日期|人员状态|变更日期|定点医院1|定点医院2|定点医院3|定点医院4|定点医院5|
        private string _sfzh;
        private string _dwbh;
        private string _ickh;
        private string _xm;
        private string _xb;
        private string _csrq;
        private string _rylb;
        private string _cbrq;
        private string _ryzt;
        private string _bgrq;
        private string _ddyy1;
        private string _ddyy2;
        private string _ddyy3;
        private string _ddyy4;
        private string _ddyy5;
        private string _cyrq;//出院日期|
        private string _zyzt;//住院状态|
        private string _ylzd1;
        private string _ylzd2;
        private string _ylzd3;
        private string _qh;//区号|
        private string _ylzd4;
        private string _dwlx;//单位类型|预留字段|
        private string _gwy;//公务员|//
        private string _jfys;//缴费月数|
        private string _zwjb;//职务级别|
        private string _ddyym1;
        private string _ddyym2;
        private string _ddyym3;
        private string _mxbyy1;
        private string _mxbyy2;
        private string _mxbyy3;
        private string _mxbyy4;
        private string _mxbyy5;
        private string _ddyym4;
        private string _ddyym5;//定点医院名1|定点医院名2|定点医院名3|慢性病医院1|慢性病医院2|慢性病医院3|慢性病医院4|慢性病医院5|定点医院名4|定点医院名5|
        private string _lybbh;
        private string _ylzd5;
        private string _dwmc;
        private string _xzjb;
        private string _ylzd6;
        private string _ylzd7;
        private string _lhjybz;
        private string _ljkh;
        private string _ylzd8;
        private string _sfjcry;
        private string _grid;
        private string _dwid;
        private string _cjgzrq;//老医保编号|单位名称|行政级别|预留字段|预留字段|灵活就业标志|逻辑卡号|预留字段|是否基残人员|个人ID|单位ID|参加工作日期
        private string _message;
        /// <summary>
        /// 个人编号
        /// </summary>
        public string Grbh
        {
            set { _grbh = value; }
            get { return _grbh; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Sfzh
        {
            set { _sfzh = value; }
            get { return _sfzh; }
        }
        public string Dwbh
        {
            set { _dwbh = value; }
            get { return _dwbh; }
        }
        public string Ickh
        {
            set { _ickh = value; }
            get { return _ickh; }
        }
        public string Xm
        {
            set { _xm = value; }
            get { return _xm; }
        }
        public string Xb
        {
            set { _xb = value; }
            get { return _xb; }
        }
        public string Csrq
        {
            set { _csrq = value; }
            get { return _csrq; }
        }
        public string Rylb
        {
            set { _rylb = value; }
            get { return _rylb; }
        }
        public string Cbrq
        {
            set { _cbrq = value; }
            get { return _cbrq; }
        }
        public string Ryzt
        {
            set { _ryzt = value; }
            get { return _ryzt; }
        }
        public string Bgrq
        {
            set { _bgrq = value; }
            get { return _bgrq; }
        }
        public string Ddyy1
        {
            set { _ddyy1 = value; }
            get { return _ddyy1; }
        }
        public string Ddyy2
        {
            set { _ddyy2 = value; }
            get { return _ddyy2; }
        }
        public string Ddyy3
        {
            set { _ddyy3 = value; }
            get { return _ddyy3; }
        }
        public string Ddyy4
        {
            set { _ddyy4 = value; }
            get { return _ddyy4; }
        }
        public string Ddyy5
        {
            set { _ddyy5 = value; }
            get { return _ddyy5; }
        }
        public string Cyrq
        {
            set { _cyrq = value; }
            get { return _cyrq; }
        }
        public string Zyzt
        {
            set { _zyzt = value; }
            get { return _zyzt; }
        }
        public string Ylzd1
        {
            set { _ylzd1 = value; }
            get { return _ylzd1; }
        }
        public string Ylzd2
        {
            set { _ylzd2 = value; }
            get { return _ylzd2; }
        }
        public string Ylzd3
        {
            set { _ylzd3 = value; }
            get { return _ylzd3; }
        }
        public string Qh
        {
            set { _qh = value; }
            get { return _qh; }
        }
        public string Ylzd4
        {
            set { _ylzd4 = value; }
            get { return _ylzd4; }
        }
        public string Dwlx
        {
            set { _dwlx = value; }
            get { return _dwlx; }
        }
        public string Gwy
        {
            set { _gwy = value; }
            get { return _gwy; }
        }
        public string Jfys
        {
            set { _jfys = value; }
            get { return _jfys; }
        }
        public string Zwjb
        {
            set { _zwjb = value; }
            get { return _zwjb; }
        }
        public string Ddyym1
        {
            set { _ddyym1 = value; }
            get { return _ddyym1; }
        }
        public string Ddyym2
        {
            set { _ddyym2 = value; }
            get { return _ddyym2; }
        }
        public string Ddyym3
        {
            set { _ddyym3 = value; }
            get { return _ddyym3; }
        }
        public string Mxbyy1
        {
            set { _mxbyy1 = value; }
            get { return _mxbyy1; }
        }
        public string Mxbyy2
        {
            set { _mxbyy2 = value; }
            get { return _mxbyy2; }
        }
        public string Mxbyy3
        {
            set { _mxbyy3 = value; }
            get { return _mxbyy3; }
        }
        public string Mxbyy4
        {
            set { _mxbyy4 = value; }
            get { return _mxbyy4; }
        }
        public string Mxbyy5
        {
            set { _mxbyy5 = value; }
            get { return _mxbyy5; }
        }
        public string Ddyym4
        {
            set { _ddyym4 = value; }
            get { return _ddyym4; }
        }
        public string Ddyym5
        {
            set { _ddyym5 = value; }
            get { return _ddyym5; }
        }
        public string Lybbh
        {
            set { _lybbh = value; }
            get { return _lybbh; }
        }
        //老医保编号|单位名称|行政级别|预留字段|预留字段|灵活就业标志|逻辑卡号|预留字段|是否基残人员|个人ID|单位ID|参加工作日期

        public string Dwmc
        {
            set { _dwmc = value; }
            get { return _dwmc; }
        }
        public string Xzjb
        {
            set { _xzjb = value; }
            get { return _xzjb; }
        }
        public string Ylzd5
        {
            set { _ylzd5 = value; }
            get { return _ylzd5; }
        }
        public string Ylzd6
        {
            set { _ylzd6 = value; }
            get { return _ylzd6; }
        }
        public string Lhjybz
        {
            set { _lhjybz = value; }
            get { return _lhjybz; }
        }
        public string Ljkh
        {
            set { _ljkh = value; }
            get { return _ljkh; }
        }
        public string Ylzd7
        {
            set { _ylzd7 = value; }
            get { return _ylzd7; }
        }
        public string Sfjcry
        {
            set { _sfjcry = value; }
            get { return _sfjcry; }
        }
        public string Grid
        {
            set { _grid = value; }
            get { return _grid; }
        }
        public string Dwid
        {
            set { _dwid = value; }
            get { return _dwid; }
        }
        public string Cjgzrq
        {
            set { _cjgzrq = value; }
            get { return _cjgzrq; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
        public string Ylzd8
        {
            set { _ylzd8 = value; }
            get { return _ylzd8; }
        }
    }
}
