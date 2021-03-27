using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clintab.bo
{
    class ClinicTabCostGather
    {
        private string clinictab_id;
        private string bas_patienttype_id;
        private string itemtype_id;
        private string itemtype1_id;
        private string diagndep_id;
        private string diagndoctor_id;
        private string exedep_id;
        private string exedoctor_id;
        private string fee;
        private string realfee;
        /// <summary>
        /// 日结主表外键
        /// </summary>
        public string Clinictab_id
        {
            get { return clinictab_id; }
            set { clinictab_id = value; }
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
        /// 项目
        /// </summary>
        public string Itemtype_id
        {
            get { return itemtype_id; }
            set { itemtype_id = value; }
        }
        /// <summary>
        /// 外键
        /// </summary>
        public string Itemtype1_id
        {
            get { return itemtype1_id; }
            set { itemtype1_id = value; }
        }
        /// <summary>
        /// 项目类型外键
        /// </summary>
        public string Diagndep_id
        {
            get { return diagndep_id; }
            set { diagndep_id = value; }
        }
        /// <summary>
        /// 核算类型
        /// </summary>
        public string Diagndoctor_id
        {
            get { return diagndoctor_id; }
            set { diagndoctor_id = value; }
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
       /// 执行人
       /// </summary>
        public string Exedoctor_id
        {
            get { return exedoctor_id; }
            set { exedoctor_id = value; }
        }
        /// <summary>
        /// 应收金额
        /// </summary>
        public string Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        /// <summary>
        /// 实收金额
        /// </summary>
        public string Realfee
        {
            get { return realfee; }
            set { realfee = value; }
        }

    }
}
