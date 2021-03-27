using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ClinicRcpdetail
    {
        private string itemfrom;
        private string exedep_id;
        private string item_id;
        private string name;
        private string spec;
        private string itemtype_id;
        private string packsole;
        private string drug_packsole_id;
        private string unit;
        private string num;
        private string prc;
        private string fee;

        private string clinic_rcp_id;
        /// <summary>
        /// 处方
        /// </summary>
        public string Clinic_rcp_id
        {
            get { return clinic_rcp_id; }
            set { clinic_rcp_id = value; }
        }

        private string id;
        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 项目定义类型
        /// </summary>
        public string Itemfrom
        {
            get { return itemfrom; }
            set { itemfrom = value; }
        }
        /// <summary>
        /// 执行科室
        /// </summary>
        public string Exedep_id
        {
            get { return exedep_id; }
            set { exedep_id = value; }
        }
        /// <summary>
        /// 项目编码
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
        /// 项目规格
        /// </summary>
        public string Spec
        {
            get { return spec; }
            set { spec = value; }
        }
        /// <summary>
        /// 费用类别
        /// </summary>
        public string Itemtype_id
        {
            get { return itemtype_id; }
            set { itemtype_id = value; }
        }
        /// <summary>
        /// 大包装销售
        /// </summary>
        public string Packsole
        {
            get { return packsole; }
            set { packsole = value; }
        }
        /// <summary>
        /// 大包装定义
        /// </summary>
        public string Drug_packsole_id
        {
            get { return drug_packsole_id; }
            set { drug_packsole_id = value; }
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
    }     
}
