using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhongluyiyuan.Entity
{
   public  class ZfRydj
    {
        private string hyid;//会员ID
        private string yjkjkfs;//预交款交款方式
        private string je;//金额
        private string sfbz;//收费标准
        private string ylfkfs;//医疗付款方式
        private string ylfkfsname;//医疗付款方式名称
        private string brxm;//病人姓名
        private string brxb;//病人性别
        private string brcsrq;//病人出生日期
        private string brnl;//病人年龄
        private string brdz;//病人地址
        private string mm;//密码
        private string zdxe;//最低限额
        private string kdr;//开单人
        private string jsr;//结算人
        private string ryks;//入院科室
        private string ysname;//医生姓名
        private string rycs;//入院次数
        private string brcity;//患者所在城市代码=0
        private string yspth;//医生所在org表中的pth字段
        private string bfh;//病房号
        private string yscimsuseriid;//医生cimsuseriid
        private string brsfzh;//病人身份证号
        private string brcimsuseriid;//病人cimsuseriid
        private string ghlbmc;//挂号类别名称
        private string ghlbbm;//挂号类别编码
        private string ghlsh2;//挂号流水号
        private string ghbs;//挂号判断表示
        private string mzh;//门诊号
        private String orgname;
        private string ctctprof;//职业
        private string mTel;//电话
        private string introducer;//介绍人
        private string zyryzd;
        private string zyh;//住院号
        public string Zyryzd
        {
            get { return zyryzd; }
            set { zyryzd = value; }
        }
        public string Zyh
        {
            get { return zyh; }
            set { zyh = value; }
        }

        public string Introducer
        {
            get { return introducer; }
            set { introducer = value; }
        }
        public String Orgname
        {
            get { return orgname; }
            set { orgname = value; }
        }
        public string Mzh
        {
            get { return mzh; }
            set { mzh = value; }
        }

        public string Ghbs
        {
            get { return ghbs; }
            set { ghbs = value; }
        }

        public string Ghlsh2
        {
            get { return ghlsh2; }
            set { ghlsh2 = value; }
        }


        public string Ghlbmc
        {
            get { return ghlbmc; }
            set { ghlbmc = value; }
        }
        

        public string Ghlbbm
        {
            get { return ghlbbm; }
            set { ghlbbm = value; }
        }

        public string Brcimsuseriid
        {
            get { return brcimsuseriid; }
            set { brcimsuseriid = value; }
        }
        public string Brsfzh
        {
            get { return brsfzh; }
            set { brsfzh = value; }
        }
        public string Yscimsuseriid
        {
            get { return yscimsuseriid; }
            set { yscimsuseriid = value; }
        }
        public string Bfh
        {
            get { return bfh; }
            set { bfh = value; }
        }
        private string bch;//病床号
        public string Bch
        {
            get { return bch; }
            set { bch = value; }
        }
        public string Yspth
        {
            get { return yspth; }
            set { yspth = value; }
        }
        public string Brcity
        {
            get { return brcity; }
            set { brcity = value; }
        }
        public string Rycs
        {
            get { return rycs; }
            set { rycs = value; }
        }
        private string pym;//患者姓名简拼
        public string Pym
        {
            get { return pym; }
            set { pym = value; }
        }
        public string Ysname
        {
            get { return ysname; }
            set { ysname = value; }
        }
        private string yscode;//医生代码
        public string Yscode
        {
            get { return yscode; }
            set { yscode = value; }
        }
        private string rysj;//入院时间

        public string Hyid
        {
            get { return hyid; }
            set { hyid = value; }
        }
        public string Yjkjkfs
        {
            get { return yjkjkfs; }
            set { yjkjkfs = value; }
        }
        public string Je
        {
            get { return je; }
            set { je = value; }
        }
        public string Sfbz
        {
            get { return sfbz; }
            set { sfbz = value; }
        }
        public string Ylfkfs
        {
            get { return ylfkfs; }
            set { ylfkfs = value; }
        }
        public string Ylfkfsname
        {
            get { return ylfkfsname; }
            set { ylfkfsname = value; }
        }
        public string Brxm
        {
            get { return brxm; }
            set { brxm = value; }
        }
        public string Brxb
        {
            get { return brxb; }
            set { brxb = value; }
        }
        public string Brcsrq
        {
            get { return brcsrq; }
            set { brcsrq = value; }
        }
        public string Brnl
        {
            get { return brnl; }
            set { brnl = value; }
        }
        public string Brdz
        {
            get { return brdz; }
            set { brdz = value; }
        }
        public string Mm
        {
            get { return mm; }
            set { mm = value; }
        }
        public string Zdxe
        {
            get { return zdxe; }
            set { zdxe = value; }
        }
        public string Kdr
        {
            get { return kdr; }
            set { kdr = value; }
        }
        public string Jsr
        {
            get { return jsr; }
            set { jsr = value; }
        }
        public string Ryks
        {
            get { return ryks; }
            set { ryks = value; }
        }
        public string Rysj
        {
            get { return rysj; }
            set { rysj = value; }
        }
        
       /// <summary>
       /// 电话
       /// </summary>
        public string MTel
        {
            get { return mTel; }
            set { mTel = value; }
        }

       /// <summary>
       /// 职业
       /// </summary>
        public string Ctctprof
        {
            get { return ctctprof; }
            set { ctctprof = value; }
        }

        private string departname;//科室名称

        public string Departname
        {
            get { return departname; }
            set { departname = value; }
        }
        private string doctorname2;//医生名称

        public string Doctorname2
        {
            get { return doctorname2; }
            set { doctorname2 = value; }
        }

      

    }
}
