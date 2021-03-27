using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class Doctor_Out : SJZYB_OUT
    {
        /// <summary>
        ///  当前页
        /// </summary>
        public string CURRENTPAGE { get; set; }
        /// <summary>
        ///  总页数
        /// </summary>
        public string TOTALPAGE { get; set; }
        /// <summary>
        ///  总记录数
        /// </summary>
        public string TOTALRECORD { get; set; }
        /// <summary>
        ///  每页条数
        /// </summary>
        public string PAGESIZE { get; set; }
        /// <summary>
        /// 特定
        /// </summary>
        public List< Doctor_Out_OUTROW> OUTROW { get; set; }
    }
    public class Doctor_Out_OUTROW
	{ 
		/// <summary>
		/// 中心医师编码
		/// </summary>
		public string BKF050 { get; set; }
		/// <summary>
		/// 定点医师编码
		/// </summary>
		public string BKF051 { get; set; }
		/// <summary>
		/// 医师姓名
		/// </summary>
		public string AKC273 { get; set; }
		/// <summary>
		/// 证件号码
		/// </summary>
		public string AAC002 { get; set; }
		/// <summary>
		/// 性别
		/// </summary>
		public string AAC004 { get; set; }
		/// <summary>
		/// 出生日期
		/// </summary>
		public string AAC006 { get; set; }
		/// <summary>
		/// 学历
		/// </summary>
		public string AAC011 { get; set; }
		/// <summary>
		/// 学位
		/// </summary>
		public string BKC113 { get; set; }
		/// <summary>
		/// 民族
		/// </summary>
		public string AAC005 { get; set; }
		/// <summary>
		/// 行政区划
		/// </summary>
		public string AAB301 { get; set; }
		/// <summary>
		/// 医师类别
		/// </summary>
		public string BKF063 { get; set; }
		/// <summary>
		/// 所学专业
		/// </summary>
		public string BKC114 { get; set; }
		/// <summary>
		/// 执 范围
		/// </summary>
		public string BKF066 { get; set; }
		/// <summary>
		/// 卫生技术人员专业技术职务
		/// </summary>
		public string AAF009 { get; set; }
		/// <summary>
		/// 资格证书编码
		/// </summary>
		public string BKF573 { get; set; }
		/// <summary>
		/// 注册证书编号
		/// </summary>
		public string BKF574 { get; set; }
		/// <summary>
		/// 发证日期
		/// </summary>
		public string BKC115 { get; set; }
		/// <summary>
		/// 执业类别
		/// </summary>
		public string BKF065 { get; set; }
		/// <summary>
		/// 执业地点
		/// </summary>
		public string BKF569 { get; set; }
		/// <summary>
		/// 手机
		/// </summary>
		public string AAE005 { get; set; }
		/// <summary>
		/// 医疗机构编码
		/// </summary>
		public string AKB020 { get; set; }
		/// <summary>
		/// 科室编码
		/// </summary>
		public string AKF001 { get; set; }
		/// <summary>
		/// 行政职务
		/// </summary>
		public string AAC020 { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string AAE013 { get; set; }
	} 
}
