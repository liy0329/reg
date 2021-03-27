using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    class SybMzjs_Entity
    {
        string sbstartfee;
        /// <summary>
        /// //商保起付线
        /// </summary>
        public string Sbstartfee
        {
            get { return sbstartfee; }
            set { sbstartfee = value; }
        }
        string sbpay;
        /// <summary>
        /// //商保支付
        /// </summary>
        public string Sbpay
        {
            get { return sbpay; }
            set { sbpay = value; }
        }

        string fzxbm;
        /// <summary>
        /// //分中心编码
        /// </summary>
        public string Fzxbm
        {
            get { return fzxbm; }
            set { fzxbm = value; }
        }

        string jzsxh;
        /// <summary>
        /// //就诊顺序号
        /// </summary>
        public string Jzsxh
        {
            get { return jzsxh; }
            set { jzsxh = value; }
        }

        string jsbm;
        /// <summary>
        /// //结算编号
        /// </summary>
        public string Jsbm
        {
            get { return jsbm; }
            set { jsbm = value; }
        }

        double yyzfy;
        /// <summary>
        /// //医院总费用
        /// </summary>
        public double Yyzfy
        {
            get { return yyzfy; }
            set { yyzfy = value; }
        }
        double jszfy;
        /// <summary>
        /// //结算总费用
        /// </summary>
        public double Jszfy
        {
            get { return jszfy; }
            set { jszfy = value; }
        }

        double ybzfy;
        /// <summary>
        /// //医保总费用
        /// </summary>
        public double Ybzfy
        {
            get { return ybzfy; }
            set { ybzfy = value; }
        }
        double qzf;
        /// <summary>
        /// //全自费
        /// </summary>
        public double Qzf
        {
            get { return qzf; }
            set { qzf = value; }
        }

        double ggzf;
        /// <summary>
        /// //挂钩自付
        /// </summary>
        public double Ggzf
        {
            get { return ggzf; }
            set { ggzf = value; }
        }

        double yxbx;
        /// <summary>
        /// //允许报销
        /// </summary>
        public double Yxbx
        {
            get { return yxbx; }
            set { yxbx = value; }
        }


        double grzhzf;
        /// <summary>
        /// //个人账户支付
        /// </summary>
        public double Grzhzf
        {
            get { return grzhzf; }
            set { grzhzf = value; }
        }
        string bndptmzylbzqfx;
        /// <summary>
        /// //本年度普通门诊医疗补助起付标准
        /// </summary>
        public string Bndptmzylbzqfx
        {
            get { return bndptmzylbzqfx; }
            set { bndptmzylbzqfx = value; }
        }

        string ptmzylbzqfx;
        /// <summary>
        /// //普通门诊医疗补助起付线
        /// </summary>
        public string Ptmzylbzqfx
        {
            get { return ptmzylbzqfx; }
            set { ptmzylbzqfx = value; }
        }

        string ptmzylbzlj;
        /// <summary>
        /// //普通门诊医疗补助累计
        /// </summary>
        public string Ptmzylbzlj
        {
            get { return ptmzylbzlj; }
            set { ptmzylbzlj = value; }
        }

        private double ylbzzf;
        /// <summary>
        /// //医疗补助支付
        /// </summary>
        public double Ylbzzf
        {
            get { return ylbzzf; }
            set { ylbzzf = value; }
        }
        public double jjtczf;
        /// <summary>
        /// //基本统筹支付
        /// </summary>
        public double Jjtczf
        {
            get { return jjtczf; }
            set { jjtczf = value; }
        }

        double debzzf;
        /// <summary>
        /// //大额补助支付
        /// </summary>
        public double Debzzf
        {
            get { return debzzf; }
            set { debzzf = value; }
        }

        public double cxezf;
        /// <summary>
        /// //超限额自付
        /// </summary>
        public double Cxezf
        {
            get { return cxezf; }
            set { cxezf = value; }
        }

        public double grzhye;
        /// <summary>
        /// //个人账户余额
        /// </summary>
        public double Grzhye
        {
            get { return grzhye; }
            set { grzhye = value; }
        }


        public string xtclsj;
        /// <summary>
        /// //系统处理时间
        /// </summary>
        public string Xtclsj
        {
            get { return xtclsj; }
            set { xtclsj = value; }
        }

        public string tsjsbz;
        /// <summary>
        /// //特殊结算标志
        /// </summary>
        public string Tsjsbz
        {
            get { return tsjsbz; }
            set { tsjsbz = value; }
        }

        public string tsjssm;
        /// <summary>
        /// //特殊结算说明
        /// </summary>
        public string Tsjssm
        {
            get { return tsjssm; }
            set { tsjssm = value; }
        }
        private string fph;
        /// <summary>
        /// 发票号
        /// </summary>
        public string Fph
        {
            get { return fph; }
            set { fph = value; }
        }
        private string gysyb_mtmzblstuff_iid;

        public string Gysyb_mtmzblstuff_iid
        {
            get { return gysyb_mtmzblstuff_iid; }
            set { gysyb_mtmzblstuff_iid = value; }
        }
        private string jrqfx;
        /// <summary>
        /// //进入起付线
        /// </summary>
        public string Jrqfx
        {
            get { return jrqfx; }
            set { jrqfx = value; }
        }

        private string fUND1SELF;
        /// <summary>
        /// //基本统筹自付
        /// </summary>
        public string FUND1SELF
        {
            get { return fUND1SELF; }
            set { fUND1SELF = value; }
        }
        private string fUND2SELF;
        /// <summary>
        /// //大额统筹自付
        /// </summary>
        public string FUND2SELF
        {
            get { return fUND2SELF; }
            set { fUND2SELF = value; }
        }
    }
}
