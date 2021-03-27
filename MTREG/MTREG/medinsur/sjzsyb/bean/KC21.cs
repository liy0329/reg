using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class KC21
    {
        /// <summary>
        /// 门诊（住院）流水号，
        /// </summary>
        public string AKC190 { get; set; }
        /// <summary>
        /// 医疗类别详见代码表
        /// </summary>
        public string AKA130 { get; set; }
        /// <summary>
        /// 入院日期 YYYYMMDDHH24MISS
        /// </summary>
        public string AKC192 { get; set; }
        /// <summary>
        /// 入院诊断疾病编码
        /// </summary>
        public string AKC193 { get; set; }
        /// <summary>
        /// 出院日期 YYYYMMDDHH24MISS
        /// </summary>
        public string AKC194 { get; set; }
        /// <summary>
        /// 出院原因（住院费用结算时必录）
        /// </summary>
        public string AKC195 { get; set; }
        /// <summary>
        /// 出院疾病诊断编码
        /// </summary>
        public string AKC196 { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        public string AAE011 { get; set; }
        /// <summary>
        /// 经办日期 YYYYMMDDHH24MISS
        /// </summary>
        public string AAE036 { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string AKC008 { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string AKC025 { get; set; }
        /// <summary>
        /// 入院诊断疾病名称
        /// </summary>
        public string AKC140 { get; set; }
        /// <summary>
        /// 入院描述
        /// </summary>
        public string AKC600 { get; set; }
        /// <summary>
        /// 出院疾病诊断名称
        /// </summary>
        public string AKC141 { get; set; }
        /// <summary>
        /// 出院描述
        /// </summary>
        public string AKC701 { get; set; }
        /// <summary>
        /// 病房号
        /// </summary>
        public string AKC030 { get; set; }
        /// <summary>
        /// 病床号
        /// </summary>
        public string AKE020 { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string AKC032 { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string AKC033 { get; set; }
        /// <summary>
        /// 患者联系电话
        /// </summary>
        public string AKC034 { get; set; }
        /// <summary>
        /// 病历号
        /// </summary>
        public string AKC031 { get; set; }
        /// <summary>
        /// 生育类别
        /// </summary>
        public string AMC026 { get; set; }
        /// <summary>
        /// 孕周
        /// </summary>
        public string AMC100 { get; set; }
        /// <summary>
        /// 准生证号
        /// </summary>
        public string AMC001 { get; set; }
        /// <summary>
        /// 胎儿数
        /// </summary>
        public string AMC013 { get; set; }
        /// <summary>
        /// 出生证编号
        /// </summary>
        public string AMC008 { get; set; }
        /// <summary>
        /// 意外伤害标志
        /// </summary>
        public string AKC120 { get; set; }
        /// <summary>
        /// 中心科室编码
        /// </summary>
        public string BKF040 { get; set; }
        /// <summary>
        /// 中心医师编码
        /// </summary>
        public string BKF050 { get; set; }
        /// <summary>
        /// 手术日期，分娩日期或流产日期
        /// </summary>
        public string AMC020 { get; set; }
        /// <summary>
        /// 急诊标志，用于记录急诊就医
        /// </summary>
        public string AKC069 { get; set; }
        /// <summary>
        /// 是否双侧输卵管结扎（0 否 1 是）
        /// </summary>
        public string CKAA59 { get; set; }
        /// <summary>
        /// 就诊诊断信息
        /// </summary>
        public string KC33XML { get; set; }
        
    }
    public class KC33ROW
    {
        /// <summary>
        /// 门诊（住院）号，医院用于区分每次就诊或住院的唯一标识
        /// </summary>
        public string AKC190 { get; set; }
        /// <summary>
        /// 诊断顺序
        /// </summary>
        public string BKE150 { get; set; }
        /// <summary>
        /// 确诊日期 YYYYMMDDHH24MISS
        /// </summary>
        public string AKC221 { get; set; }
        /// <summary>
        /// 诊断编码
        /// </summary>
        public string AKA120 { get; set; }
        /// <summary>
        /// 诊断名称
        /// </summary>
        public string AKA121 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string AAE013 { get; set; }
    }
}
