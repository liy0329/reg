using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class ClinicCostdet
    {
        private string id;
        private string clinic_Invoice_id;
        private string clinic_cost_id;
        private String regist_id;
        private String depart_id;
        private String doctor_id;
        private String exedep_id;
        private String exedoctor_id;
        
        /// <summary>
        /// 主键id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        
        /// <summary>
        /// 门诊发票外键
        /// </summary>
        public string Clinic_Invoice_id
        {
            get { return clinic_Invoice_id; }
            set { clinic_Invoice_id = value; }
        }
        private string standcode;
        /// <summary>
        /// 统一编码
        /// </summary>
        public string Standcode
        {
            get { return standcode; }
            set { standcode = value; }
        }
        private string item_id;
        /// <summary>
        /// 外键项目
        /// </summary>
        public string Item_id
        {
            get { return item_id; }
            set { item_id = value; }
        }
        private string itemfrom;
        /// <summary>
        /// 项目定义类型
        /// </summary>
        public string Itemfrom
        {
            get { return itemfrom; }
            set { itemfrom = value; }
        }
        private string clinic_rcpdetail_id;
        /// <summary>
        /// 处方明细
        /// </summary>
        public string Clinic_rcpdetail_id
        {
            get { return clinic_rcpdetail_id; }
            set { clinic_rcpdetail_id = value; }
        }
        private string drug_packsole_id;
        /// <summary>
        /// 包装定义
        /// </summary>
        public string Drug_packsole_id
        {
            get { return drug_packsole_id; }
            set { drug_packsole_id = value; }
        }
        private string name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string spec;
        /// <summary>
        /// 规格
        /// </summary>
        public string Spec
        {
            get { return spec; }
            set { spec = value; }
        }
        private string unit;
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private string num;
        /// <summary>
        /// 数量
        /// </summary>
        public string Num
        {
            get { return num; }
            set { num = value; }
        }
        private string prc;
        /// <summary>
        /// 单价
        /// </summary>
        public string Prc
        {
            get { return prc; }
            set { prc = value; }
        }
        private string fee;
        /// <summary>
        /// 金额
        /// </summary>
        public string Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        private string realfee;
        /// <summary>
        /// 实收金额
        /// </summary>
        public string Realfee
        {
            get { return realfee; }
            set { realfee = value; }
        }
        private string itemtype_id;
        /// <summary>
        /// 费用类别
        /// </summary>
        public string Itemtype_id
        {
            get { return itemtype_id; }
            set { itemtype_id = value; }
        }
        private string itemtype1_id;
        /// <summary>
        /// 核算类别
        /// </summary>
        public string Itemtype1_id
        {
            get { return itemtype1_id; }
            set { itemtype1_id = value; }
        }
        private string charged;
        /// <summary>
        /// 计费状态
        /// </summary>
        public string Charged
        {
            get { return charged; }
            set { charged = value; }
        }
        private string chargedate;
        /// <summary>
        /// 收费时间
        /// </summary>
        public string Chargedate
        {
            get { return chargedate; }
            set { chargedate = value; }
        }
        private string chargeby;
        /// <summary>
        /// 收费人
        /// </summary>
        public string Chargeby
        {
            get { return chargeby; }
            set { chargeby = value; }
        }
        private string drug_iodet_id;

        public string Drug_iodet_id
        {
            get { return drug_iodet_id; }
            set { drug_iodet_id = value; }
        }
        private string retcost_id;

        public string Retcost_id
        {
            get { return retcost_id; }
            set { retcost_id = value; }
        }

        /// <summary>
        /// 收费主表外键
        /// </summary>
        public string Clinic_cost_id
        {
            get { return clinic_cost_id; }
            set { clinic_cost_id = value; }
        }
        /// <summary>
        /// 挂号外键
        /// </summary>
        public String Regist_id
        {
            get { return regist_id; }
            set { regist_id = value; }
        }
        /// <summary>
        /// 处方科室
        /// </summary>
        public String Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        /// <summary>
        /// 处方医生
        /// </summary>
        public String Doctor_id
        {
            get { return doctor_id; }
            set { doctor_id = value; }
        }
        /// <summary>
        /// 执行科室
        /// </summary>
        public String Exedep_id
        {
            get { return exedep_id; }
            set { exedep_id = value; }
        }
         /// <summary>
         /// 执行医生
         /// </summary>
        public String Exedoctor_id
        {
            get { return exedoctor_id; }
            set { exedoctor_id = value; }
        }
    }
}
