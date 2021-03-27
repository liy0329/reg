using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.main.bo
{
    public class AccMenu
    {
        private string id;
        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string url;
        /// <summary>
        /// 地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private string name;
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
