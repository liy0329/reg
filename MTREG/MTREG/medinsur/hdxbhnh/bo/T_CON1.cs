using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdxbhnh.bo
{
    class T_CON1
    {
        private string zyh;// 标示住院号
        private string zyh1;// 真实住院号
        private string ylzbh;// 个人参合号
        private string hzxm;// 患者姓名
        private string xb;// 性别
        private string djrq;// 登记日期
        private string yj;// 押金总额
        private string z_date1;// 入院日期
        private string nhzt;// 农合结算状态
        private string qhdm;// 区划代码
        /// <summary>
        /// 标示住院号
        /// </summary>
        public string Zyh
        {
            get { return zyh; }
            set { zyh = value; }
        }
        
        /// <summary>
        /// 真实住院号
        /// </summary>
        public string Zyh1
        {
            get { return zyh1; }
            set { zyh1 = value; }
        }
        
        /// <summary>
        /// 个人参合号
        /// </summary>
        public string Ylzbh
        {
            get { return ylzbh; }
            set { ylzbh = value; }
        }
        
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Hzxm
        {
            get { return hzxm; }
            set { hzxm = value; }
        }
        
        /// <summary>
        /// 性别
        /// </summary>
        public string Xb
        {
            get { return xb; }
            set { xb = value; }
        }
        
        /// <summary>
        /// 登记日期
        /// </summary>
        public string Djrq
        {
            get { return djrq; }
            set { djrq = value; }
        }
        
        /// <summary>
        /// 押金总额
        /// </summary>
        public string Yj
        {
            get { return yj; }
            set { yj = value; }
        }
        
        /// <summary>
        /// 入院日期
        /// </summary>
        public string Z_date1
        {
            get { return z_date1; }
            set { z_date1 = value; }
        }
        
        /// <summary>
        /// 农合结算状态
        /// </summary>
        public string Nhzt
        {
            get { return nhzt; }
            set { nhzt = value; }
        }
        
        /// <summary>
        /// 区划代码
        /// </summary>
        public string Qhdm
        {
            get { return qhdm; }
            set { qhdm = value; }
        }
    }
}
