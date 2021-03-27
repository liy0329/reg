using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class DrugIodetail
    {
        private String drugio_id;
        private string costdet_id;
        private String objdept_id;
        private String item_id;
        private String name;
        private string spec;
        private string unit;
        private string qty;
        private string realprc;
        private string packsoleunit;
        private string packsole;
        private string drug_packsole_id;
        private string packsoleprc;
        private string packsoleqty;
        private string id;
      
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 药品io外键
        /// </summary>
        public String Drugio_id
        {
            get { return drugio_id; }
            set { drugio_id = value; }
        }
        /// <summary>
        /// 收费主表明细外键
        /// </summary>
        public string Costdet_id
        {
            get { return costdet_id; }
            set { costdet_id = value; }
        }
        /// <summary>
        /// 执行科室
        /// </summary>
        public String Objdept_id
        {
            get { return objdept_id; }
            set { objdept_id = value; }
        }
        /// <summary>
        /// 项目定义外键
        /// </summary>
        public String Item_id
        {
            get { return item_id; }
            set { item_id = value; }
        }
        /// <summary>
        /// 通用名称
        /// </summary>
        public String Name
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
        /// 基本单位
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        /// <summary>
        /// 基本数量
        /// </summary>
        public string Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// 零售价
        /// </summary>
        public string Realprc
        {
            get { return realprc; }
            set { realprc = value; }
        }
        /// <summary>
        /// 大包装单位
        /// </summary>
        public string Packsoleunit
        {
            get { return packsoleunit; }
            set { packsoleunit = value; }
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
        /// 大包装定义外键
        /// </summary>
        public string Drug_packsole_id
        {
            get { return drug_packsole_id; }
            set { drug_packsole_id = value; }
        }
        /// <summary>
        /// 大包装价
        /// </summary>
        public string Packsoleprc
        {
            get { return packsoleprc; }
            set { packsoleprc = value; }
        }
        /// <summary>
        /// 大包装数量
        /// </summary>
        public string Packsoleqty
        {
            get { return packsoleqty; }
            set { packsoleqty = value; }
        }

    }
}
