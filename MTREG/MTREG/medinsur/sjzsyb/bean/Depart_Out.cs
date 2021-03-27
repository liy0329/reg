using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class Depart_Out : SJZYB_OUT
	{ 
		/// <summary>
		/// 科室编码
		/// </summary>
		public string AKF001 { get; set; }
		/// <summary>
		/// 科室代码
		/// </summary>
		public string AKF003 { get; set; }
		/// <summary>
		/// 科室名称
		/// </summary>
		public string AKF002 { get; set; }
		/// <summary>
		/// 医疗机构编号
		/// </summary>
		public string AKB020 { get; set; }
		/// <summary>
		/// 科室分类
		/// </summary>
		public string BKF075 { get; set; }
		/// <summary>
		/// 床位数
		/// </summary>
		public string AKF015 { get; set; }
		/// <summary>
		/// 职工数量
		/// </summary>
		public string AKF008 { get; set; }
		/// <summary>
		/// 负责人
		/// </summary>
		public string BKF005 { get; set; }
		/// <summary>
		/// 联系电话
		/// </summary>
		public string BKF006 { get; set; }
		/// <summary>
		/// 业务范围
		/// </summary>
		public string BKF061 { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string AAE013 { get; set; }
	} 
}
