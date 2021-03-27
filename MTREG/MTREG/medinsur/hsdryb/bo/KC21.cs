using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hsdryb.bo
{
    /// <summary>
    /// 就诊信息
    /// </summary>
    class KC21
    {
        /// <summary>
        /// 门诊（住院）流水号
        /// </summary>
        public string AKC190 { get; set; }

        /// <summary>
        /// 医疗类别
        /// </summary>
        public string AKA130 { get; set; }


        /// <summary>
        /// 入院(门诊)日期yyyyMMddHHmmss
        /// </summary>
        public string AKC192 { get; set; }

        /// <summary>
        /// 入院诊断疾病编码
        /// </summary>
        public string AKC193 { get; set; }

        /// <summary>
        /// 出院日期yyyyMMddHHmmss
        /// </summary>
        public string AKC194 { get; set; }

        /// <summary>
        /// 出院原因
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
        /// 经办日期yyyyMMddHHmmss
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
        public int AMC100 { get; set; }

        /// <summary>
        /// 准生证号
        /// </summary>
        public string AMC001 { get; set; }

        /// <summary>
        /// 胎儿数
        /// </summary>
        public int AMC013 { get; set; }

        /// <summary>
        /// 出生证编号
        /// </summary>
        public string AMC008 { get; set; }

        /// <summary>
        /// 意外伤害标志
        /// </summary>
        public string AKC120 { get; set; }

        /// <summary>
        /// 科室编码
        /// </summary>
        public string BKF040 { get; set; }

        /// <summary>
        /// 医师编码
        /// </summary>
        public string BKF050 { get; set; }

        /// <summary>
        /// 手术日期
        /// </summary>
        public string AMC020 { get; set; }

        ////非接口文档字段
        /// <summary>
        /// 姓名
        /// </summary>
        public string AAC003 { get; set; }
        /// <summary>
        /// 个人编号
        /// </summary>
        public string AAC001 { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string AKC020 { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string AAB001 { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string AAB004 { get; set; }
        /// <summary>
        /// 人员类别
        /// </summary>
        public string AKC021 { get; set; }

        public string KC21_inXml(KC21 entity)
        {
            StringBuilder sb = new StringBuilder(200);
            sb.AppendFormat("<AKC190>{0}</AKC190>", entity.AKC190);
            sb.AppendFormat("<AKA130>{0}</AKA130>", entity.AKA130);
            sb.AppendFormat("<AKC192>{0}</AKC192>", entity.AKC192 == DateTime.MinValue.ToString("yyyyMMddHHmmss") ? "" : entity.AKC192);
            sb.AppendFormat("<AKC193>{0}</AKC193>", entity.AKC193);
            sb.AppendFormat("<AKC194>{0}</AKC194>", entity.AKC194 == DateTime.MinValue.ToString("yyyyMMddHHmmss") ? "" : entity.AKC194);
            sb.AppendFormat("<AKC195>{0}</AKC195>", entity.AKC195);
            sb.AppendFormat("<AKC196>{0}</AKC196>", entity.AKC196);
            sb.AppendFormat("<AAE011>{0}</AAE011>", entity.AAE011);
            sb.AppendFormat("<AAE036>{0}</AAE036>", entity.AAE036 == DateTime.MinValue.ToString("yyyyMMddHHmmss") ? "" : entity.AAE036);
            sb.AppendFormat("<AKC008>{0}</AKC008>", entity.AKC008);
            sb.AppendFormat("<AKC025>{0}</AKC025>", entity.AKC025);
            sb.AppendFormat("<AKC140>{0}</AKC140>", entity.AKC140);
            sb.AppendFormat("<AKC600>{0}</AKC600>", entity.AKC600);
            sb.AppendFormat("<AKC141>{0}</AKC141>", entity.AKC141);
            sb.AppendFormat("<AKC701>{0}</AKC701>", entity.AKC701);
            sb.AppendFormat("<AKC030>{0}</AKC030>", entity.AKC030);
            sb.AppendFormat("<AKE020>{0}</AKE020>", entity.AKE020);
            sb.AppendFormat("<AKC032>{0}</AKC032>", entity.AKC032);
            sb.AppendFormat("<AKC033>{0}</AKC033>", entity.AKC033);
            sb.AppendFormat("<AKC034>{0}</AKC034>", entity.AKC034);
            sb.AppendFormat("<AKC031>{0}</AKC031>", entity.AKC031);
            sb.AppendFormat("<AMC026>{0}</AMC026>", entity.AMC026);
            sb.AppendFormat("<AMC100>{0}</AMC100>", entity.AMC100);
            sb.AppendFormat("<AMC001>{0}</AMC001>", entity.AMC001);
            sb.AppendFormat("<AMC013>{0}</AMC013>", entity.AMC013);
            sb.AppendFormat("<AMC008>{0}</AMC008>", entity.AMC008);
            sb.AppendFormat("<AKC120>{0}</AKC120>", entity.AKC120);
            sb.AppendFormat("<BKF040>{0}</BKF040>", entity.BKF040);
            sb.AppendFormat("<BKF050>{0}</BKF050>", entity.BKF050);
            sb.AppendFormat("<AMC020>{0}</AMC020>", entity.AMC020);

            return sb.ToString();
        
        }
    }
}
