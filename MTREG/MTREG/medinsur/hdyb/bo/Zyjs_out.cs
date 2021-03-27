using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Zyjs_out
    {
        //医疗费总额|本次医保外自费金额（自费类费用） |本次乙类自费金额|本次特检自付金额|本次特检统筹支付金额|本次特治自付金额|本次特治统筹支付金额|
        private string _ylfze;
        private string _ybwzfje;
        private string _ylzfje;
        private string _tjzfje;
        private string _tjtczfje;
        private string _tzzfje;
        private string _tztczfje;
        //本次起付标准自付金额（本次起付线以内支付）|本次分段自付金额|本次超过统筹封顶线个人自付金额|历次符合基本医疗保险累计金额|本次符合基本医疗保险费用金额|
        private string _qfbzzfje;
        private string _fdzfje;
        private string _cgtcfdxzfje;
        private string _lsljje;
        private string _bcfyje;
        //预留字段|本次进入统筹费用金额|本次帐户支付金额|本次统筹支付金额|本次现金支付金额|本次公务员补助支出金额|结算后IC卡余额|本次起付线标准|本次帐户应支付|
        private string _ylzd;
        private string _bctcfyje;
        private string _bczhzfje;
        private string _bctczfje;
        private string _bcxjzfje;
        private string _bcgwybzzcje;
        private string _jshickye;
        private string _bcqfxbz;
        private string _bczhyzf;
        //本年住院次数|本次进入大病部分|本次大病支付金额|本次超过大病封顶线|本年历次大病支付累计|XX
        private string _bnzycs;
        private string _bcjrdbbf;
        private string _bcdbzfje;
        private string _bccgdbfdx;
        private string _bnlcdbzflj;
        private string _message;

        public string Ylfze
        {
            set { _ylfze = value; }
            get { return _ylfze; }
        }
        public string Ybwzfje
        {
            set { _ybwzfje = value; }
            get { return _ybwzfje; }
        }
        public string Ylzfje
        {
            set { _ylzfje = value; }
            get { return _ylzfje; }
        }
        public string Tjzfje
        {
            set { _tjzfje = value; }
            get { return _tjzfje; }
        }
        public string Tjtczfje
        {
            set { _tjtczfje = value; }
            get { return _tjtczfje; }
        }
        public string Tzzfje
        {
            set { _tzzfje = value; }
            get { return _tzzfje; }
        }
        public string Tztczfje
        {
            set { _tztczfje = value; }
            get { return _tztczfje; }
        }
        public string Qfbzzfje
        {
            set { _qfbzzfje = value; }
            get { return _qfbzzfje; }
        }
        public string Fdzfje
        {
            set { _fdzfje = value; }
            get { return _fdzfje; }
        }
        public string Cgtcfdxzfje
        {
            set { _cgtcfdxzfje = value; }
            get { return _cgtcfdxzfje; }
        }
        public string Lcljje
        {
            set { _lsljje = value; }
            get { return _lsljje; }
        }
        public string Bcfyje
        {
            set { _bcfyje = value; }
            get { return _bcfyje; }
        }
        public string Ylzd
        {
            set { _ylzd = value; }
            get { return _ylzd; }
        }
        public string Bctcfyje
        {
            set { _bctcfyje = value; }
            get { return _bctcfyje; }
        }
        public string Bczhzfje
        {
            set { _bczhzfje = value; }
            get { return _bczhzfje; }
        }
        public string Bctczfje
        {
            set { _bctczfje = value; }
            get { return _bctczfje; }
        }
        public string Bcxjzfje
        {
            set { _bcxjzfje = value; }
            get { return _bcxjzfje; }
        }
        public string Bcgwybzzcje
        {
            set { _bcgwybzzcje = value; }
            get { return _bcgwybzzcje; }
        }
        public string Jshickye
        {
            set { _jshickye = value; }
            get { return _jshickye; }
        }
        public string Bcqfxbz
        {
            set { _bcqfxbz = value; }
            get { return _bcqfxbz; }
        }
        public string Bczhyzf
        {
            set { _bczhyzf = value; }
            get { return _bczhyzf; }
        }
        public string Bnzycs
        {
            set { _bnzycs = value; }
            get { return _bnzycs; }
        }
        public string Bcjrdbbf
        {
            set { _bcjrdbbf = value; }
            get { return _bcjrdbbf; }
        }
        public string Bcdbzfje
        {
            set { _bcdbzfje = value; }
            get { return _bcdbzfje; }
        }
        public string Bccgdbfdx
        {
            set { _bccgdbfdx = value; }
            get { return _bccgdbfdx; }
        }
        public string Bnlcdbzflj
        {
            set { _bnlcdbzflj = value; }
            get { return _bnlcdbzflj; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
