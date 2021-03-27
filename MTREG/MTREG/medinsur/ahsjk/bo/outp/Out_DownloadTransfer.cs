using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.outp
{
    class Out_DownloadTransfer
    {
        private string truncode;//转诊单编号
        private string memberno;//成员编码
        private string idcardno;//身份证号
        private string name;//姓名
        private string sex;//性别
        private string birthday;//出生日期
        private string bookno;//医疗证（卡）号
        private string telephone;//联系电话
        private string turntype;//本次转诊类型编码
        private string icdcode;//转诊诊断编码
        private string icdname;//转诊诊断名称
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
        private string sObligate1;//预留字段1
        private string sObligate2;//预留字段2
        private string sObligate3;//预留字段3
        private string sObligate4;//预留字段4
        private string sObligate5;//预留字段5

        public string Truncode
        {
            get { return truncode; }
            set { truncode = value; }
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

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
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

        public string SObligate1
        {
            get { return sObligate1; }
            set { sObligate1 = value; }
        }

        public string SObligate2
        {
            get { return sObligate2; }
            set { sObligate2 = value; }
        }

        public string SObligate3
        {
            get { return sObligate3; }
            set { sObligate3 = value; }
        }

        public string SObligate4
        {
            get { return sObligate4; }
            set { sObligate4 = value; }
        }

        public string SObligate5
        {
            get { return sObligate5; }
            set { sObligate5 = value; }
        }
    }
}
