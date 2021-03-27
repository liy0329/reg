using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdsbhnh.bo
{
    class Header
    {
        private string weburl;
        /// <summary>
        /// webservice地址
        /// </summary>
        public string Weburl
        {
            get { return weburl; }
            set { weburl = value; }
        }
        private int identity;
        /// <summary>
        /// 区域id
        /// </summary>
        public int Identity
        {
            get { return identity; }
            set { identity = value; }
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
        private string password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string name;
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
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
        private string orgid;
        /// <summary>
        /// 医疗机构id
        /// </summary>
        public string Orgid
        {
            get { return orgid; }
            set { orgid = value; }
        }
    }
}
