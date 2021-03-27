using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Mzjsddy_out
    {
        //医保中心名称|收据号|定点医疗机构名称|科室|姓名|人员类别|个人编号|处方号|IC卡号|西药|中成药|草药|化验|检查|放射|治疗|手术|床费|其他|应收金额|
        //实收金额|自付金额|个人账户支付|本次支付后账户余额|公务员支出|本年支付累计|收费员|打印日期|医疗类别|本次统筹支付|本年统筹支付累计|本年门诊统筹支付累计
        private string _ybzxmc;
        private string _sjh;
        private string _ddyljgmc;
        private string _ks;
        private string _xm;
        private string _grlb;
        private string _grbh;
        private string _cfh;
        private string _ickh;
        private string _xy;
        private string _zcy;
        private string _cy;
        private string _hy;
        private string _jc;
        private string _fs;
        private string _zl;
        private string _ss;
        private string _cf;
        private string _qt;
        private string _ysje;
        private string _ssje;
        private string _zfje;
        private string _grzhzf;
        private string _zhye;
        private string _gwyzc;
        private string _bnzflj;
        private string _sfy;
        private string _dyrq;
        private string yllb;
        private string bctczf;
        private string bntczflj;
        private string bnmztczflj;

        
        
        private string _message;
       // private string fyhj;
        //private string tczf;
        //private string fhjbyl;
        
        
        //private string bntclj;
        private string ssrmb;
        private string fymc;

        public string Fymc
        {
            get { return fymc; }
            set { fymc = value; }
        }
        private string guige;

        public string Guige
        {
            get { return guige; }
            set { guige = value; }
        }
        private string sl;

        public string Sl
        {
            get { return sl; }
            set { sl = value; }
        }
        private string sx;

        public string Sx
        {
            get { return sx; }
            set { sx = value; }
        }
        private string je;

        public string Je
        {
            get { return je; }
            set { je = value; }
        }


       
       

        public string Ssrmb
        {
            get { return ssrmb; }
            set { ssrmb = value; }
        }

        //public string Bntclj
        //{
        //    get { return bntclj; }
        //    set { bntclj = value; }
        //}

        //public string Bcdbzf
        //{
        //    get { return bcdbzf; }
        //    set { bcdbzf = value; }
        //}

        //public string Qfx
        //{
        //    get { return qfx; }
        //    set { qfx = value; }
        //}

        //public string Fhjbyl
        //{
        //    get { return fhjbyl; }
        //    set { fhjbyl = value; }
        //}

        //public string Tczf
        //{
        //    get { return tczf; }
        //    set { tczf = value; }
        //}

        //public string Fyhj
        //{
        //    get { return fyhj; }
        //    set { fyhj = value; }
        //}

        public string Ybzxmc
        {
            set { _ybzxmc = value; }
            get { return _ybzxmc; }
        }
        public string Sjh
        {
            set { _sjh = value; }
            get { return _sjh; }
        }
        public string Ddyljgmc
        {
            set { _ddyljgmc = value; }
            get { return _ddyljgmc; }
        }
        public string Ks
        {
            set { _ks = value; }
            get { return _ks; }
        }
        public string Xm
        {
            set { _xm = value; }
            get { return _xm; }
        }
        public string Grlb
        {
            set { _grlb = value; }
            get { return _grlb; }
        }
        public string Grbh
        {
            set { _grbh = value; }
            get { return _grbh; }
        }
        public string Cfh
        {
            set { _cfh = value; }
            get { return _cfh; }
        }
        public string Ickh
        {
            set { _ickh = value; }
            get { return _ickh; }
        }
        public string Xy
        {
            set { _xy = value; }
            get { return _xy; }
        }
        public string Zcy
        {
            set { _zcy = value; }
            get { return _zcy; }
        }
        public string Cy
        {
            set { _cy = value; }
            get { return _cy; }
        }
        public string Hy
        {
            set { _hy = value; }
            get { return _hy; }
        }
        public string Jc
        {
            set { _jc = value; }
            get { return _jc; }
        }
        public string Fs
        {
            set { _fs = value; }
            get { return _fs; }
        }
        public string Zl
        {
            set { _zl = value; }
            get { return _zl; }
        }
        public string Ss
        {
            set { _ss = value; }
            get { return _ss; }
        }
        public string Cf
        {
            set { _cf = value; }
            get { return _cf; }
        }
        public string Qt
        {
            set { _qt = value; }
            get { return _qt; }
        }
        public string Ysje
        {
            set { _ysje = value; }
            get { return _ysje; }
        }
        public string Ssje
        {
            set { _ssje = value; }
            get { return _ssje; }
        }
        public string Zfje
        {
            set { _zfje = value; }
            get { return _zfje; }
        }
        public string Grzhzf
        {
            set { _grzhzf = value; }
            get { return _grzhzf; }
        }
        public string Zhye
        {
            set { _zhye = value; }
            get { return _zhye; }
        }
        public string Gwyzc
        {
            set { _gwyzc = value; }
            get { return _gwyzc; }
        }
        public string Bnzflj
        {
            set { _bnzflj = value; }
            get { return _bnzflj; }
        }
        public string Sfy
        {
            set { _sfy = value; }
            get { return _sfy; }
        }
        public string Dyrq
        {
            set { _dyrq = value; }
            get { return _dyrq; }
        }

        public string Bnmztczflj   //|本年门诊统筹支付累计
        {
            get { return bnmztczflj; }
            set { bnmztczflj = value; }
        }
        public string Bntczflj  //本年统筹支付累计
        {
            get { return bntczflj; }
            set { bntczflj = value; }
        }
        public string Bctczf   //本次统筹支付
        {
            get { return bctczf; }
            set { bctczf = value; }
        }
        public string Yllb    //   医疗类别
        {
            get { return yllb; }
            set { yllb = value; }
        }
        private string bnmzdbzflj;//本年门诊大病支付累计

        public string Bnmzdbzflj
        {
          get { return bnmzdbzflj; }
          set { bnmzdbzflj = value; }
        }

        private string bcfhjbyl;//本次符合基本医疗

        public string Bcfhjbyl
        {
          get { return bcfhjbyl; }
          set { bcfhjbyl = value; }
        }

        private string qfx;//起付线

        public string Qfx
        {
          get { return qfx; }
          set { qfx = value; }
        }

        private string bcdbzf;//本次大病支付

        public string Bcdbzf
        {
          get { return bcdbzf; }
          set { bcdbzf = value; }
        }

        private string ndzjzlx;//尿毒症就诊类型|

        public string Ndzjzlx
        {
          get { return ndzjzlx; }
          set { ndzjzlx = value; }
        }

        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }

        private string bnmxbtczflj;//本年慢性病统筹支付累计

        public string Bnmxbtczflj
        {
            get { return bnmxbtczflj; }
            set { bnmxbtczflj = value; }
        }

        private string bcjsqbntclj;//本次结算前本年统筹累计

        public string Bcjsqbntclj
        {
            get { return bcjsqbntclj; }
            set { bcjsqbntclj = value; }
        }

        private string bcjsqdbzflj;//本次结算前大病支付累计

        public string Bcjsqdbzflj
        {
            get { return bcjsqdbzflj; }
            set { bcjsqdbzflj = value; }
        }

        private string bccdbzf;//本次超大病支付

        public string Bccdbzf
        {
            get { return bccdbzf; }
            set { bccdbzf = value; }
        }

        private string zifujine;//自付金额

        public string Zifujine
        {
            get { return zifujine; }
            set { zifujine = value; }
        }

        private string zifeijine;//自费金额

        public string Zifeijine
        {
            get { return zifeijine; }
            set { zifeijine = value; }
        }

       

        private string bcbxze;//本次报销总额

        public string Bcbxze
        {
            get { return bcbxze; }
            set { bcbxze = value; }
        }
    }
    
    
}
