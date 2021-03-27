using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhongluyiyuan.gsbx
{
    public class Reportgsjsd
    {
        private string _zyh;//住院号
        private string _yymc;//医院名称
        private string _hzxm;//患者姓名
        private string _sfzh;//身份证号码
        private string _hzxb;//患者性别
        private string _gsbw;//工伤部位
        private string _cbd;//参保地
        private string _shbzh;//社会保障号
        private string _gssj;//工伤时间
        private string _jylx;//就医类型
        private string _zllb;//治疗类别
        private string _jssj;//结算时间
        private string _rysj;//入院时间
        private string _ryzd;//入院诊断
        private string _cysj;//出院时间
        private string _cyzd;//出院诊断

        public string Zyh
        {
            get { return _zyh; }
            set { _zyh = value; }
        }
        public string Yymc
        {
            get { return _yymc; }
            set { _yymc = value; }
        }
        public string Hzxm
        {
            get { return _hzxm; }
            set { _hzxm = value; }
        }
        public string Sfzh
        {
            get { return _sfzh; }
            set { _sfzh = value; }
        }
        public string Hzxb
        {
            get { return _hzxb; }
            set { _hzxb = value; }
        }
        public string Gsbw
        {
            get { return _gsbw; }
            set { _gsbw = value; }
        }
        public string Cbd
        {
            get { return _cbd; }
            set { _cbd = value; }
        }
        public string Shbzh
        {
            get { return _shbzh; }
            set { _shbzh = value; }
        }
        public string Gssj
        {
            get { return _gssj; }
            set { _gssj = value; }
        }
        public string Jylx
        {
            get { return _jylx; }
            set { _jylx = value; }
        }
        public string Zllb
        {
            get { return _zllb; }
            set { _zllb = value; }
        }
        public string Jssj
        {
            get { return _jssj; }
            set { _jssj = value; }
        }
        public string Rysj
        {
            get { return _rysj; }
            set { _rysj = value; }
        }
        public string Cysj
        {
            get { return _cysj; }
            set { _cysj = value; }
        }
        public string Ryzd
        {
            get { return _ryzd; }
            set { _ryzd = value; }
        }
        public string Cyzd
        {
            get { return _cyzd; }
            set { _cyzd = value; }
        }
        private string _ylzf;//总费用
        public string Ylzf
        {
            get { return _ylzf; }
            set { _ylzf = value; }
        }
        private string _gszf;//工伤费用
        public string Gszf
        {
            get { return _gszf; }
            set { _gszf = value; }
        }
        private string _zfje;//自付金额
        public string Zfje
        {
            get { return _zfje; }
            set { _zfje = value; }
        }

        private string xh;

        public string Xh
        {
            get { return xh; }
            set { xh = value; }
        }
        private string xmmc;//项目
        public string Xmmc
        {
            get { return xmmc; }
            set { xmmc = value; }
        }
        private string sl;//数量
        public string Sl
        {
            get { return sl; }
            set { sl = value; }
        }
        private string dj;//单价
        public string Dj
        {
            get { return dj; }
            set { dj = value; }
        }
        private string je;//金额
        public string Je
        {
            get { return je; }
            set { je = value; }
        }
        private string jzfje;//自付金额
        public string Jzfje
        {
            get { return jzfje; }
            set { jzfje = value; }
        }
        private string zfyy;//自付原因
        public string Zfyy
        {
            get { return zfyy; }
            set { zfyy = value; }
        }
        private string jbr;

        public string Jbr
        {
            get { return jbr; }
            set { jbr = value; }
        }
        private string dysj;

        public string Dysj
        {
            get { return dysj; }
            set { dysj = value; }
        }
    }
}
