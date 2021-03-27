using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
	public class declare_zl_In
    {
        /// <summary>
        /// 收费项目类别
        /// </summary>
        public string AKC224 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INROW { get; set; }
    }
    public class declare_zl_In_INROW
	{ 
		/// <summary>
		/// 操作类型
		/// </summary>
		public string OPERTYPE { get; set; }
		/// <summary>
		/// 项目编码
		/// </summary>
		public string AKA090 { get; set; }
		/// <summary>
		/// 项目名称
		/// </summary>
		public string AKA091 { get; set; }
		/// <summary>
		/// 医院收费项目编码
		/// </summary>
		public string AKC515 { get; set; }
		/// <summary>
		/// 医院收费项目名称
		/// </summary>
		public string AKC516 { get; set; }
		/// <summary>
		/// HIS 名称拼音助记码
		/// </summary>
		public string HISAKA066 { get; set; }
		/// <summary>
		/// 价格
		/// </summary>
		public string AKC225 { get; set; }
	} 
}
