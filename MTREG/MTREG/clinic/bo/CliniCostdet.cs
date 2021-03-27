using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class CliniCostdet
    {
        private string id;
        private string clinic_cost_id;
        private string bas_patienttype_id;
        private String regist_id; //挂号编号外键
        private String item_id;                 //外键项目  隐式外键
        private String standcode;               //统一编码
        private String itemfrom; 
        private String depart_id;               // 处方科室
        private String doctor_id;               // 处方医生
        private String exedep_id;               //执行科室
        private String name;                    //项目名称
        private String spec;                    //规格  单位 数量 单价
        private String packsole;                //大包装销售
        private String drug_packsole_id;        //大包装定义
        private String unit;
        private String num;
        private String prc;
        private String fee;                //金额 打折 实收金额
        private String discnt;
        private String realfee;
        private String itemtype_id;     //费用类别
        private String itemtype1_id;     //核算类别
                       //项目定义类型
        private String clinic_rcpdetail_id;     //处方明细
        private string chargedate;
        private string chargeby;
        private string rcptype;
        /// <summary>
        /// 处方类型
        /// </summary>
        public string Rcptype
        {
            get { return rcptype; }
            set { rcptype = value; }
        }

        
        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
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
        /// 患者类型外键
        /// </summary>
        public string Bas_patienttype_id
        {
            get { return bas_patienttype_id; }
            set { bas_patienttype_id = value; }
        }
        /// <summary>
        /// 统一编码
        /// </summary>
        public String Standcode
        {
            get { return standcode; }
            set { standcode = value; }
        }

        /// <summary>
        /// 外键项目  隐式外键
        /// </summary>
        public String Item_id
        {
            get { return item_id; }
            set { item_id = value; }
        }

        /// <summary>
        /// 项目定义类型
        /// </summary>
        public String Itemfrom
        {
            get { return itemfrom; }
            set { itemfrom = value; }
        }

        /// <summary>
        /// 处方明细
        /// </summary>
        public String Clinic_rcpdetail_id
        {
            get { return clinic_rcpdetail_id; }
            set { clinic_rcpdetail_id = value; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public String Spec
        {
            get { return spec; }
            set { spec = value; }
        }

        /// <summary>
        /// 大包装销售
        /// </summary>
        public String Packsole
        {
            get { return packsole; }
            set { packsole = value; }
        }
        /// <summary>
        /// 大包装定义
        /// </summary>
        public String Drug_packsole_id
        {
            get { return drug_packsole_id; }
            set { drug_packsole_id = value; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public String Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public String Num
        {
            get { return num; }
            set { num = value; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public String Prc
        {
            get { return prc; }
            set { prc = value; }
        }

        /// <summary>
        /// 金额
        /// </summary>
        public String Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        /// <summary>
        /// 打折
        /// </summary>
        public String Discnt
        {
            get { return discnt; }
            set { discnt = value; }
        }
        /// <summary>
        /// 实收金额
        /// </summary>
        public String Realfee
        {
            get { return realfee; }
            set { realfee = value; }
        }

        /// <summary>
        /// 费用类别
        /// </summary>
        public String Itemtype_id
        {
            get { return itemtype_id; }
            set { itemtype_id = value; }
        }

        /// <summary>
        /// 核算类别
        /// </summary>
        public String Itemtype1_id
        {
            get { return itemtype1_id; }
            set { itemtype1_id = value; }
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
        /// 收费日期
        /// </summary>
        public string Chargedate
        {
            get { return chargedate; }
            set { chargedate = value; }
        }
        /// <summary>
        /// 收费人
        /// </summary>
        public string Chargeby
        {
            get { return chargeby; }
            set { chargeby = value; }
        }

        private string member_rechargedet_id;
        /// <summary>
        /// 会员充值记录表id
        /// </summary>
        public string Member_rechargedet_id
        {
            get { return member_rechargedet_id; }
            set { member_rechargedet_id = value; }
        }
    }
}
