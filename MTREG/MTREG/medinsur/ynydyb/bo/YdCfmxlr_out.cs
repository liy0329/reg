using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class YdCfmxlr_out 
    {
        private string sjdj;
        /// <summary>
        /// 实际单价
        /// </summary>
        public string Sjdj
        {
            get { return sjdj; }
            set { sjdj = value; }
        }
        private string xmsfdj;
        /// <summary>
        /// 项目收费等级
        /// </summary>
        public string Xmsfdj
        {
            get { return xmsfdj; }
            set { xmsfdj = value; }
        }

        private string spbh;
        /// <summary>
        /// 审批编号
        /// </summary>
        public string Spbh
        {
            get { return spbh; }
            set { spbh = value; }
        }

        private string zfbl;
        /// <summary>
        /// 自付比例
        /// </summary>
        public string Zfbl
        {
            get { return zfbl; }
            set { zfbl = value; }
        }
        private string fyze;
        /// <summary>
        /// 费用总额
        /// </summary>
        public string Fyze
        {
            get { return fyze; }
            set { fyze = value; }
        }
        private string qzfbf;
        /// <summary>
        /// 全自费部分
        /// </summary>
        public string Qzfbf
        {
            get { return qzfbf; }
            set { qzfbf = value; }
        }
        private string xzfbf;
        /// <summary>
        /// 先自付部分
        /// </summary>
        public string Xzfbf
        {
            get { return xzfbf; }
            set { xzfbf = value; }
        }
        private string yxbxbf;
        /// <summary>
        /// 允许报销部分
        /// </summary>
        public string Yxbxbf
        {
            get { return yxbxbf; }
            set { yxbxbf = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
