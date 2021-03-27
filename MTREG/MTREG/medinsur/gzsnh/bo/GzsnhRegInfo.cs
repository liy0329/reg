using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsnh.bo
{
    class GzsnhRegInfo
    {

        private string centerno;
        /// <summary>
        /// 农合中心编码
        /// </summary>
        public string Centerno
        {
            get { return centerno; }
            set { centerno = value; }
        }
        private string type;
        /// <summary>
        /// 类型:登记/修改
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string familysysno;
        /// <summary>
        /// 家庭编号
        /// </summary>
        public string Familysysno
        {
            get { return familysysno; }
            set { familysysno = value; }
        }

        private  string membersysno;
        /// <summary>
        /// 个人编码
        /// </summary>
        public  string Membersysno
        {
            get { return membersysno; }
            set { membersysno = value; }
        }
        private  string stature;
        /// <summary>
        /// 身高
        /// </summary>
        public  string Stature
        {
            get { return stature; }
            set { stature = value; }
        }
        private  string weight;
        /// <summary>
        /// 体重
        /// </summary>
        public  string Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private string inhosid;
        /// <summary>
        /// 入院状态
        /// </summary>
        public string Inhosid
        {
            get { return inhosid; }
            set { inhosid = value; }
        }


        private string icdallno;
        /// <summary>
        /// 疾病诊断
        /// </summary>
        public string Icdallno
        {
            get { return icdallno; }
            set { icdallno = value; }
        }

        private  string secondicdno;
        /// <summary>
        /// 第二疾病诊断
        /// </summary>
        public  string Secondicdno
        {
            get { return secondicdno; }
            set { secondicdno = value; }
        }
        private  string threeicdno;
        /// <summary>
        /// 第三疾病诊断
        /// </summary>
        public  string Threeicdno
        {
            get { return threeicdno; }
            set { threeicdno = value; }
        }
        private  string opsid;
        /// <summary>
        /// 手术编号
        /// </summary>
        public  string Opsid
        {
            get { return opsid; }
            set { opsid = value; }
        }
        private  string treatcode;
        /// <summary>
        /// 治疗方式编码
        /// </summary>
        public  string Treatcode
        {
            get { return treatcode; }
            set { treatcode = value; }
        }
        private  string cureid;
        /// <summary>
        /// 就诊类型
        /// </summary>
        public  string Cureid
        {
            get { return cureid; }
            set { cureid = value; }
        }
        private  string complication;
        /// <summary>
        /// 并发症
        /// </summary>
        public  string Complication
        {
            get { return complication; }
            set { complication = value; }
        }
        private  string curedoctor;
        /// <summary>
        /// 经治医生
        /// </summary>
        public  string Curedoctor
        {
            get { return curedoctor; }
            set { curedoctor = value; }
        }
        private  string bedno;
        /// <summary>
        /// 床位号码
        /// </summary>
        public  string Bedno
        {
            get { return bedno; }
            set { bedno = value; }
        }
        private string inofficeid;
        /// <summary>
        /// 入院科室编码
        /// </summary>
        public string Inofficeid
        {
            get { return inofficeid; }
            set { inofficeid = value; }
        }
      
        private string officedate;
        /// <summary>
        /// 入院时间
        /// </summary>
        public string Officedate
        {
            get { return officedate; }
            set { officedate = value; }
        }
        private  string sectionno;
        /// <summary>
        /// 入院病区
        /// </summary>
        public  string Sectionno
        {
            get { return sectionno; }
            set { sectionno = value; }
        }
        private  string turnmode;
        /// <summary>
        /// 转诊类型
        /// </summary>
        public  string Turnmode
        {
            get { return turnmode; }
            set { turnmode = value; }
        }
        private  string turncode;
        /// <summary>
        /// 转诊转院编码
        /// </summary>
        public  string Turncode
        {
            get { return turncode; }
            set { turncode = value; }
        }
        private  string turndate;
        /// <summary>
        /// 转院日期
        /// </summary>
        public  string Turndate
        {
            get { return turndate; }
            set { turndate = value; }
        }
        private  string ticketno;
        /// <summary>
        /// 医院住院收费收据号
        /// </summary>
        public  string Ticketno
        {
            get { return ticketno; }
            set { ticketno = value; }
        }
        private  string ministernotice;
        /// <summary>
        /// 民政通知书号
        /// </summary>
        public  string Ministernotice
        {
            get { return ministernotice; }
            set { ministernotice = value; }
        }
        private  string procreatenotice;
        /// <summary>
        /// 生育证号
        /// </summary>
        public  string Procreatenotice
        {
            get { return procreatenotice; }
            set { procreatenotice = value; }
        }
        private  string tel;
        /// <summary>
        /// 电话号码
        /// </summary>
        public  string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string bookNo;
        /// <summary>
        /// 医疗证号
        /// </summary>
        public string BookNo
        {
            get { return bookNo; }
            set { bookNo = value; }
        }
        private  string isnewborn;
        /// <summary>
        /// 是否新生儿入院
        /// </summary>
        public  string Isnewborn
        {
            get { return isnewborn; }
            set { isnewborn = value; }
        }
        private  string newbornbirthday;
        /// <summary>
        /// 新生儿出生时间
        /// </summary>
        public  string Newbornbirthday
        {
            get { return newbornbirthday; }
            set { newbornbirthday = value; }
        }
        private  string newbornname;
        /// <summary>
        /// 新生儿姓名
        /// </summary>
        public  string Newbornname
        {
            get { return newbornname; }
            set { newbornname = value; }
        }
        private  string newbornsex;
        /// <summary>
        /// 新生儿性别
        /// </summary>
        public  string Newbornsex
        {
            get { return newbornsex; }
            set { newbornsex = value; }
        }
        private string inpatientsn;
        /// <summary>
        /// 农合住院登记流水号
        /// </summary>
        public string Inpatientsn
        {
            get { return inpatientsn; }
            set { inpatientsn = value; }
        }

      

    }
}
