using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdsbhnh.bo
{
    class HdsbhRegInfo
    {

        private string inpatientSn;
        /// <summary>
        /// 住院流水号
        /// </summary>
        public string InpatientSn
        {
            get { return inpatientSn; }
            set { inpatientSn = value; }
        }
        private string doctor;
        /// <summary>
        /// 经办人
        /// </summary>
        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }
        private string personNum;
        /// <summary>
        /// 个人编号
        /// </summary>
        public string PersonNum
        {
            get { return personNum; }
            set { personNum = value; }
        }
        private string djsx;
        /// <summary>
        /// 登记属性
        /// </summary>
        public string Djsx
        {
            get { return djsx; }
            set { djsx = value; }
        }
        private string hspcode;
        /// <summary>
        /// 就医机构代码
        /// </summary>
        public string Hspcode
        {
            get { return hspcode; }
            set { hspcode = value; }
        }
        private string zwlx;
        /// <summary>
        /// 转外类型
        /// </summary>
        public string Zwlx
        {
            get { return zwlx; }
            set { zwlx = value; }
        }
        private string weburl;
        /// <summary>
        /// webservice地址
        /// </summary>
        public string Weburl
        {
            get { return weburl; }
            set { weburl = value; }
        }
        private string targetOrg;
        /// <summary>
        /// 目标机构代码
        /// </summary>
        public string TargetOrg
        {
            get { return targetOrg; }
            set { targetOrg = value; }
        }
        private string trustpointcode;
        /// <summary>
        /// 3位信任码/医疗单位身份id
        /// </summary>
        public string Trustpointcode
        {
            get { return trustpointcode; }
            set { trustpointcode = value; }
        }
        private string password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
