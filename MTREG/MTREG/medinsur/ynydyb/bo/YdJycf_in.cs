using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class YdJycf_in
    {
        private string fsfjylsh;
        /// <summary>
        /// 发送方交易流水号
        /// </summary>
        public string Fsfjylsh
        {
            get { return fsfjylsh; }
            set { fsfjylsh = value; }
        }
        private string hzgrbh;
        /// <summary>
        /// 患者个人编号
        /// </summary>
        public string Hzgrbh
        {
            get { return hzgrbh; }
            set { hzgrbh = value; }
        }
        private string hzybkh;
        /// <summary>
        /// 患者医保卡号
        /// </summary>
        public string Hzybkh
        {
            get { return hzybkh; }
            set { hzybkh = value; }
        }
        private string hzcbdtcqbh;
        /// <summary>
        /// 患者参保地统筹区编号
        /// </summary>
        public string Hzcbdtcqbh
        {
            get { return hzcbdtcqbh; }
            set { hzcbdtcqbh = value; }
        }
        private string yjym;
        /// <summary>
        /// 原交易码(冲正交易时使用)
        /// </summary>
        public string Yjym
        {
            get { return yjym; }
            set { yjym = value; }
        }
        private string yfsfjylsh;
        /// <summary>
        /// //原发送方交易流水号(冲正交易时使用)[撤销交易不要传入此参数！]
        /// </summary>
        public string Yfsfjylsh
        {
            get { return yfsfjylsh; }
            set { yfsfjylsh = value; }
        }
        private string czybh;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string Czybh
        {
            get { return czybh; }
            set { czybh = value; }
        }
        private string ywzqh;
        /// <summary>
        /// 业务周期号
        /// </summary>
        public string Ywzqh
        {
            get { return ywzqh; }
            set { ywzqh = value; }
        }
        private string zyh;
        /// <summary>
        /// 住院号
        /// </summary>
        public string Zyh
        {
            get { return zyh; }
            set { zyh = value; }
        }
    }
}
