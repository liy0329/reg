using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    class PersonInfo
    {
      
        private string invoice_id;

        public string Invoice_id
        {
            get { return invoice_id; }
            set { invoice_id = value; }
        }

        private string zflb;
        /// <summary>
        /// 支付类别
        /// </summary>
        public string Zflb
        {
            get { return zflb; }
            set { zflb = value; }
        }
        private string jzbh;
        /// <summary>
        /// 就诊编号
        /// </summary>
        public string Jzbh
        {
            get { return jzbh; }
            set { jzbh = value; }
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

        private string qjgrbh;
        private string qjryzd;
        private string qjicd;
        private string qjdyspxx;
        private string qjsjbzyxbrbs;
        private string qjzxshbxbf;
        /// <summary>
        /// 个人编号
        /// </summary>
        public string Qjgrbh
        {
            get { return qjgrbh; }
            set { qjgrbh = value; }
        }
        /// <summary>
        /// 疾病诊断
        /// </summary>
        public string Qjryzd
        {
            get { return qjryzd; }
            set { qjryzd = value; }
        }
        /// <summary>
        /// 疾病ICD编码
        /// </summary>
        public string Qjicd
        {
            get { return qjicd; }
            set { qjicd = value; }
        }
        
        public string Qjdyspxx
        {
            get { return qjdyspxx; }
            set { qjdyspxx = value; }
        }
        /// <summary>
        /// 精神疾病住院新病人标示
        /// </summary>
        public string Qjsjbzyxbrbs
        {
            get { return qjsjbzyxbrbs; }
            set { qjsjbzyxbrbs = value; }
        }
       /// <summary>
       /// 执行社会保险办法
       /// </summary>
        public string Qjzxshbxbf
        {
            get { return qjzxshbxbf; }
            set { qjzxshbxbf = value; }
        }
        /////////////////////////////////////////////////////////////////////////
        private string swgrbh;//个人编号
        private string swxm;//姓名
        private string swxb;//性别
        private string swylzgrylb;// 医疗照顾人员类别
        private string swzxshbxbf;// 执行社会保险办法
        private string swcsrq;//出生日期
        private string swdwbm;//单位编码
        private string swjmlrylb;// 居民医疗人员类别
        private string swfzxbm;//分中心编码
        private string swzbzt;//参保状态
        private string swylrylb;// 医疗人员类别
        private string swylrylbmc;//医疗人员类别名称
        private string swsfzh;// 身份证号
        private string sssbjgbm;// 所属社保机构编码(使用分中心编码代码)
        private string swzwbz;//驻外标志
        private string swsznl;//实足年龄
        private string swdwmc;//单位名称
        private string swjmylrysf;// 居民医疗人员身份
        private string swgrzhye;// 个人账户余额
        private string swdqzyzt;// 当前住院状态
        private string flag;//读卡成功标志
       
        /// <summary>
        /// 个人编号
        /// </summary>
        public string Swgrbh
        {
            get { return swgrbh; }
            set { swgrbh = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Swxm
        {
            get { return swxm; }
            set { swxm = value; }
        }
        
        /// <summary>
        /// 性别
        /// </summary>
        public string Swxb
        {
            get { return swxb; }
            set { swxb = value; }
        }
        
        /// <summary>
        /// 医疗照顾人员类别
        /// </summary>
        public string Swylzgrylb
        {
            get { return swylzgrylb; }
            set { swylzgrylb = value; }
        }
        
        /// <summary>
        /// 执行社会保险办法
        /// </summary>
        public string Swzxshbxbf
        {
            get { return swzxshbxbf; }
            set { swzxshbxbf = value; }
        }
        
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Swcsrq
        {
            get { return swcsrq; }
            set { swcsrq = value; }
        }
        
        /// <summary>
        /// 单位编码
        /// </summary>
        public string Swdwbm
        {
            get { return swdwbm; }
            set { swdwbm = value; }
        }
        
        /// <summary>
        /// 居民医疗人员类别
        /// </summary>
        public string Swjmlrylb
        {
            get { return swjmlrylb; }
            set { swjmlrylb = value; }
        }
        
        /// <summary>
        /// 分中心编码
        /// </summary>
        public string Swfzxbm
        {
            get { return swfzxbm; }
            set { swfzxbm = value; }
        }
        
        /// <summary>
        /// 参保状态
        /// </summary>
        public string Swzbzt
        {
            get { return swzbzt; }
            set { swzbzt = value; }
        }
        
        /// <summary>
        /// 医疗人员类别
        /// </summary>
        public string Swylrylb
        {
            get { return swylrylb; }
            set { swylrylb = value; }
        }

        /// <summary>
        /// 医疗人员类别名称
        /// </summary>
        public string Swylrylbmc
        {
            get { return swylrylbmc; }
            set { swylrylbmc = value; }
        }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Swsfzh
        {
            get { return swsfzh; }
            set { swsfzh = value; }
        }
        
        /// <summary>
        /// 所属社保机构编码(使用分中心编码代码)
        /// </summary>
        public string Sssbjgbm
        {
            get { return sssbjgbm; }
            set { sssbjgbm = value; }
        }
        
        /// <summary>
        /// 驻外标志
        /// </summary>
        public string Swzwbz
        {
            get { return swzwbz; }
            set { swzwbz = value; }
        }
        /// <summary>
        /// 实足年龄
        /// </summary>
        public string Swsznl
        {
            get { return swsznl; }
            set { swsznl = value; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Swdwmc
        {
            get { return swdwmc; }
            set { swdwmc = value; }
        }
        /// <summary>
        /// 居民医疗人员身份
        /// </summary>
        public string Swjmylrysf
        {
            get { return swjmylrysf; }
            set { swjmylrysf = value; }
        }
        /// <summary>
        /// 个人账户余额
        /// </summary>
        public string Swgrzhye
        {
            get { return swgrzhye; }
            set { swgrzhye = value; }
        }
        
        /// <summary>
        /// 当前住院状态
        /// </summary>
        public string Swdqzyzt
        {
            get { return swdqzyzt; }
            set { swdqzyzt = value; }
        }
        /// <summary>
        /// 成功标志0成功-1失败
        /// </summary>
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private string swtrxm;
        private string swtrgx;
        private string swtrsfzh;
        private string swtrxb;
        /// <summary>
        /// 受委托人姓名
        /// </summary>
        public string Swtrxm
        {
            get { return swtrxm; }
            set { swtrxm = value; }
        }
        /// <summary>
        /// 与受委托人关系
        /// </summary>
        public string Swtrgx
        {
            get { return swtrgx; }
            set { swtrgx = value; }
        }
        /// <summary>
        /// 受委托人身份证号
        /// </summary>
        public string Swtrsfzh
        {
            get { return swtrsfzh; }
            set { swtrsfzh = value; }
        }
        /// <summary>
        /// 受委托人性别
        /// </summary>
        public string Swtrxb
        {
            get { return swtrxb; }
            set { swtrxb = value; }
        }
    }
}
