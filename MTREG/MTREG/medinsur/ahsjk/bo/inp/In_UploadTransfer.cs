using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_UploadTransfer : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sUserCode;//用户名
        [Valid(Required = true, Description = "不能为空")]
        private string sUserPass;//密码
        [Valid(Required = true, Description = "不能为空")]
        private string truncode;//转诊单编号
        [Valid(Required = true, Description = "不能为空")]
        private string stype;//操作类型编码
        [Valid(Required = true, Description = "不能为空")]
        private string memberno;//成员编码
        private string idcardno;//身份证号
        [Valid(Required = true, Description = "不能为空")]
        private string name;//姓名
        [Valid(Required = true, Description = "不能为空")]
        private string sex;//性别
        [Valid(Required = true, Description = "不能为空")]
        private string birthday;//出生日期
        [Valid(Required = true, Description = "不能为空")]
        private string bookno;//医疗证（卡）号
        private string telphone;//联系电话
        [Valid(Required = true, Description = "不能为空")]
        private string turntype;//本次转诊类型编码
        [Valid(Required = true, Description = "不能为空")]
        private string icdcode;//转诊诊断编码
        [Valid(Required = true, Description = "不能为空")]
        private string icdname;//转诊诊断名称
        [Valid(Required = true, Description = "不能为空")]
        private string turndate;//转诊日期
        private string fromhospitalcode;//转出医院代码
        private string fromhospitalname;//转出医院名称
        private string tohospitalcode;//转入医院代码
        private string tohospitalname;//转入医院名称
        private string tohospitallevel;//转入医院行政级别编码
        private string tohospitalteclevel;//转入医院技术级别编码
        private string leavedateoflasttime;//本次住院出院日期
        private string outofficeoflasttime;//本次住院出院科室
        private string icdcodeoflasttime;//本次住院出院诊断编码
        private string icdnameoflasttime;//本次住院出院诊断名称
        private string doctorname;//本次住院责任医生
        private string remark;//转诊说明
        private string sAreaCode;
        /// <summary>
        /// 地区代码
        /// </summary>
        public string SAreaCode
        {
            get { return sAreaCode; }
            set { sAreaCode = value; }
        }

        public string SUserCode
        {
            get { return sUserCode; }
            set { sUserCode = value; }
        }

        public string SUserPass
        {
            get { return sUserPass; }
            set { sUserPass = value; }
        }

        public string Truncode
        {
            get { return truncode; }
            set { truncode = value; }
        }

        public string Stype
        {
            get { return stype; }
            set { stype = value; }
        }

        public string Memberno
        {
            get { return memberno; }
            set { memberno = value; }
        }

        public string Idcardno
        {
            get { return idcardno; }
            set { idcardno = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Bookno
        {
            get { return bookno; }
            set { bookno = value; }
        }

        public string Telphone
        {
            get { return telphone; }
            set { telphone = value; }
        }

        public string Turntype
        {
            get { return turntype; }
            set { turntype = value; }
        }

        public string Icdcode
        {
            get { return icdcode; }
            set { icdcode = value; }
        }

        public string Icdname
        {
            get { return icdname; }
            set { icdname = value; }
        }

        public string Turndate
        {
            get { return turndate; }
            set { turndate = value; }
        }

        public string Fromhospitalcode
        {
            get { return fromhospitalcode; }
            set { fromhospitalcode = value; }
        }

        public string Fromhospitalname
        {
            get { return fromhospitalname; }
            set { fromhospitalname = value; }
        }

        public string Tohospitalcode
        {
            get { return tohospitalcode; }
            set { tohospitalcode = value; }
        }

        public string Tohospitalname
        {
            get { return tohospitalname; }
            set { tohospitalname = value; }
        }

        public string Tohospitallevel
        {
            get { return tohospitallevel; }
            set { tohospitallevel = value; }
        }

        public string Tohospitalteclevel
        {
            get { return tohospitalteclevel; }
            set { tohospitalteclevel = value; }
        }

        public string Leavedateoflasttime
        {
            get { return leavedateoflasttime; }
            set { leavedateoflasttime = value; }
        }

        public string Outofficeoflasttime
        {
            get { return outofficeoflasttime; }
            set { outofficeoflasttime = value; }
        }

        public string Icdcodeoflasttime
        {
            get { return icdcodeoflasttime; }
            set { icdcodeoflasttime = value; }
        }

        public string Icdnameoflasttime
        {
            get { return icdnameoflasttime; }
            set { icdnameoflasttime = value; }
        }

        public string Doctorname
        {
            get { return doctorname; }
            set { doctorname = value; }
        }

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
