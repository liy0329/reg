using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ChkAppcost
    {
        private string item_id;
        private string name;
        private string spec;
        private string unit;
        private string num;
        private string prc;
        private string fee;
        private string syncost;
        private string chk_app_id;
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Chk_app_id
        {
            get { return chk_app_id; }
            set { chk_app_id = value; }
        }
        /// <summary>
        /// 收费定义外键
        /// </summary>
        public string Item_id
        {
            get { return item_id; }
            set { item_id = value; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string Spec
        {
            get { return spec; }
            set { spec = value; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public string Num
        {
            get { return num; }
            set { num = value; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public string Prc
        {
            get { return prc; }
            set { prc = value; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public string Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        /// <summary>
        /// 同步
        /// </summary>
        public string Syncost
        {
            get { return syncost; }
            set { syncost = value; }
        }
    }
}
