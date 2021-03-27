using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Mzjs_out
    {
        //医疗费用总额|本次符合基本医疗保险费用金额|本次符合基本医疗保险外自费金额|本次特检自付金额|本次特检统筹支付金额|本次特治自付金额|本次特治统筹支付金额|
        //本次个人帐户支付金额|本次统筹支付金额|本次现金支付金额|本次公务员补助支出金额|结算后IC卡余额|本次帐户应支付|本次进入大病部分|本次大病支付金额|本次超过大病封顶线|
        //本年历次大病支付累计|本次起付线支付金额|尿毒症就诊类型|XX
        private string _ylfyze;
        private string _bcfhje;
        private string _bczfje;
        private string _bctjzfje;
        private string _bctjtcje;
        private string _bctzzfje;
        private string _bctztcje;
        private string _bcgrzhzfje;
        private string _bctczfje;
        private string _bcxjzfje;
        private string _bcgwybzzcje;
        private string _jshickye;
        private string _bczhyzf;
        private string _bcjrdbbf;
        private string _bcdbzfje;
        private string _bccgdbfdx;
        private string _bnlcdbzflj;
        private string _bcqfxzfje;

       
        private string _ndzjzlx;

       
        private string _message;
       

        public string Ylfyze
        {
            set { _ylfyze = value; }
            get { return _ylfyze; }
        }
        public string Bcfhje
        {
            set { _bcfhje = value; }
            get { return _bcfhje; }
        }
        public string Bczfje
        {
            set { _bczfje = value; }
            get { return _bczfje; }
        }
        public string Bctjzfje
        {
            set { _bctjzfje = value; }
            get { return _bctjzfje; }
        }
        public string Bctjtcje
        {
            set { _bctjtcje = value; }
            get { return _bctjtcje; }
        }
        public string Bctzzfje
        {
            set { _bctzzfje = value; }
            get { return _bctzzfje; }
        }
        public string Bctztcje
        {
            set { _bctztcje = value; }
            get { return _bctztcje; }
        }
        public string Bcgrzhzfje
        {
            set { _bcgrzhzfje = value; }
            get { return _bcgrzhzfje; }
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
        public string Bczhyzf
        {
            set { _bczhyzf = value; }
            get { return _bczhyzf; }
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

        public string Bcqfxzfje
        {
            get { return _bcqfxzfje; }
            set { _bcqfxzfje = value; }
        }

        public string Ndzjzlx
        {
            get { return _ndzjzlx; }
            set { _ndzjzlx = value; }
        }

        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
