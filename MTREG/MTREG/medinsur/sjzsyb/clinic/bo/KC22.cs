using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.clinic.bo
{
    class KC22
    {
        /// <summary>
        /// 门诊（住院）号，
        /// </summary>
        public string AKC190 { get; set; }
        /// <summary>
        /// 处方号
        /// </summary>
        public string AKC220 { get; set; }
        /// <summary>
        /// 处方日期 YYYYMMDDHH24MISS
        /// </summary>
        public string AKC221 { get; set; }
        /// <summary>
        /// 医院收费项目编码
        /// </summary>
        public string AKC515 { get; set; }
        /// <summary>
        /// 医院收费项目名称
        /// </summary>
        public string AKC516 { get; set; }
        /// <summary>
        /// 中心收费项目编码
        /// </summary>
        public string AKC222 { get; set; }
        /// <summary>
        /// 中心收费项目名称
        /// </summary>
        public string AKC223 { get; set; }
        /// <summary>
        /// 药品/诊疗/床位费详见
        /// </summary>
        public string AKC224 { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public string AKC225 { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string AKC226 { get; set; }
        /// <summary>
        /// 金额（单价*数量=金额）
        /// </summary>
        public string AKC227 { get; set; }
        /// <summary>
        /// 剂型
        /// </summary>
        public string AKA070 { get; set; }
        /// <summary>
        /// 每次用量
        /// </summary>
        public string AKA071 { get; set; }
        /// <summary>
        /// 每次用量单位
        /// </summary>
        public string AKC602 { get; set; }
        /// <summary>
        /// 使用频次
        /// </summary>
        public string AKA072 { get; set; }
        /// <summary>
        /// 用法
        /// </summary>
        public string AKA073 { get; set; }
        /// <summary>
        /// 执行天数（工伤必录项）
        /// </summary>
        public string AKC603 { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string AKC604 { get; set; }
        /// <summary>
        /// 医院处方流水号（
        /// </summary>
        public string AKC378 { get; set; }
        /// <summary>
        /// 每日最大用量
        /// </summary>
        public string AKA075 { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string BKA970 { get; set; }
        /// <summary>
        /// 中心医师编码
        /// </summary>
        public string BKF050 { get; set; }
        /// <summary>
        /// 中心医师名称
        /// </summary>
        public string AKC008 { get; set; }
        /// <summary>
        /// 中心科室编码
        /// </summary>
        public string BKF040 { get; set; }
        /// <summary>
        /// 中心科室名称
        /// </summary>
        public string AKC025 { get; set; }
        /// <summary>
        /// 销售单位，例如“盒”
        /// </summary>
        public string BKA076 { get; set; }
        /// <summary>
        /// 基本单位（小单位），例如“片”
        /// </summary>
        public string AKA067 { get; set; }
        /// <summary>
        /// 包装单位（大单位），例如“盒”
        /// </summary>
        public string CKAA08 { get; set; }
        /// <summary>
        /// 包装单位基本单位换算比例
        /// </summary>
        public string CKAA09 { get; set; }
    }
}
