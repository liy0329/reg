using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Yjs_out
    {
        //0| 总费用|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起伏线|住院次数|起付线剩余|结算时间|包干标准|包干结余
        private string jylsh;
        /// <summary>
        /// 交易流水号（预结算ID）
        /// </summary>
        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string zfy;
        /// <summary>
        /// //总费用
        /// </summary>
        public string Zfy
        {
            get { return zfy; }
            set { zfy = value; }
        }
        private string tc;
        /// <summary>
        /// //统筹
        /// </summary>
        public string Tc
        {
            get { return tc; }
            set { tc = value; }
        }
        private string zh;
        /// <summary>
        /// //账户
        /// </summary>
        public string Zh
        {
            get { return zh; }
            set { zh = value; }
        }
        private string xj;
        /// <summary>
        /// //现金
        /// </summary>
        public string Xj
        {
            get { return xj; }
            set { xj = value; }
        }
        private string dblp;
        /// <summary>
        /// //大病理赔
        /// </summary>
        public string Dblp
        {
            get { return dblp; }
            set { dblp = value; }
        }
        private string zgrybz;
        /// <summary>
        /// //照顾人员补助
        /// </summary>
        public string Zgrybz
        {
            get { return zgrybz; }
            set { zgrybz = value; }
        }
        private string gwybz;
        /// <summary>
        /// //公务员补助
        /// </summary>
        public string Gwybz
        {
            get { return gwybz; }
            set { gwybz = value; }
        }
        private string jfqgzrybz;
        /// <summary>
        /// //解放前工作人员补助
        /// </summary>
        public string Jfqgzrybz
        {
            get { return jfqgzrybz; }
            set { jfqgzrybz = value; }
        }
        private string qfx;
        /// <summary>
        /// //起付线
        /// </summary>
        public string Qfx
        {
            get { return qfx; }
            set { qfx = value; }
        }
        private string zycs;
        /// <summary>
        /// //住院次数
        /// </summary>
        public string Zycs
        {
            get { return zycs; }
            set { zycs = value; }
        }
        private string qfxsy;
        /// <summary>
        /// //起付线剩余
        /// </summary>
        public string Qfxsy
        {
            get { return qfxsy; }
            set { qfxsy = value; }
        }
        private string jssj;
        /// <summary>
        /// //结算时间
        /// </summary>
        public string Jssj
        {
            get { return jssj; }
            set { jssj = value; }
        }
        private string bgbz;
        /// <summary>
        /// //包干标准
        /// </summary>
        public string Bgbz
        {
            get { return bgbz; }
            set { bgbz = value; }
        }
        private string bgjy;
        /// <summary>
        /// //包干结余
        /// </summary>
        public string Bgjy
        {
            get { return bgjy; }
            set { bgjy = value; }
        }
        private string qzfje;
        /// <summary>
        /// //全自费金额
        /// </summary>
        public string Qzfje
        {
            get { return qzfje; }
            set { qzfje = value; }
        }
        private string znshydxx;
        /// <summary>
        /// //智能审核疑点信息
        /// </summary>
        public string Znshydxx
        {
            get { return znshydxx; }
            set { znshydxx = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
