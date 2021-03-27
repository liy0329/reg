using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    public class MZZF_ZLYY
    {
        private string _yymc;//医院名称
        private string _xm;//姓名
        private string _kb;//科别
        private string _fph;//发票号
        private string _xy;//西药
        private string _jc;//检查
        private string _ss;//手术
        private string _sy;//输氧
        private string _zc;//中成
        private string _zl;//治疗
        private string _hy;//化验
        private string _qt;//其他
        private string _zcy;//中草药
        private string _xg;//X光
        private string _sx;//输血
        private string _hjsz;//合计-数字
        private string _hjdx;//合计-大写

       //医院名称 |姓名//科别//发票号
        public string Yymc
        {
            set { _yymc = value; }
            get { return _yymc; }
        }
        public string Xm
        {
            set { _xm = value; }
            get { return _xm; }
        }
        public string Kb
        {
            set { _kb = value; }
            get { return _kb; }
        }
        public string Fph
        {
            set { _fph = value; }
            get { return _fph; }
        }
        //西药
        public string Xy
        {
            set { _xy = value; }
            get { return _xy ; }
        }
        //检查
        public string Jc
        {
            set { _jc = value; }
            get { return _jc;  }
        }
        //手术
        public string Ss
        {
            set { _ss = value; }
            get { return _ss; }
        }
        //输氧
        public string Sy
        {
            set { _sy = value; }
            get { return _sy; }
        }
        //中成
        public string Zc
        {
            set { _zc = value; }
            get { return _zc; }
        }
        //治疗
        public string Zl
        {
            set { _zl = value; }
            get { return _zl; }
        }
        //化验
        public string Hy
        {
            set { _hy = value; }
            get { return _hy; }
        }
        //其他
        public string Qt
        {
            set { _qt = value; }
            get { return _qt ; }
        }
        //中草药
        public string Zcy
        {
            set { _zcy = value; }
            get { return _zcy ; }
        }
        //X光
        public string Xg
        {
            set { _xg = value; }
            get { return _xg ; }
        }
        //输血
        public string Sx
        {
            set { _sx = value; }
            get { return _sx ; }
        }
        //合计-数字
        public string Hjsz
        {
            set { _hjsz = value; }
            get { return _hjsz ; }
        }
        //合计-大写
        public string Hjdx
        {
            set { _hjdx = value; }
            get { return _hjdx ; }
        }

    }

}
