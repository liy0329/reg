using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class GetEmpInfo_out
    {
        //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
        //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
        //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
        private string xm;
        /// <summary>
        /// //姓名
        /// </summary>
        public string Xm
        {
            get { return xm; }
            set { xm = value; }
        }
        private string xb;
        /// <summary>
        /// //性别
        /// </summary>
        public string Xb
        {
            get { return xb; }
            set { xb = value; }
        }
        private string sfzh;
        /// <summary>
        /// //身份证号
        /// </summary>
        public string Sfzh
        {
            get { return sfzh; }
            set { sfzh = value; }
        }
        private string csrq;
        /// <summary>
        /// //出身日期
        /// </summary>
        public string Csrq
        {
            get { return csrq; }
            set { csrq = value; }
        }
        private string rylbbm;
        /// <summary>
        /// //人员类别编码
        /// </summary>
        public string Rylbbm
        {
            get { return rylbbm; }
            set { rylbbm = value; }
        }
        private string rylbmc;
        /// <summary>
        /// //人员类别名称
        /// </summary>
        public string Rylbmc
        {
            get { return rylbmc; }
            set { rylbmc = value; }
        }
        private string dwmc;
        /// <summary>
        /// //单位名称
        /// </summary>
        public string Dwmc
        {
            get { return dwmc; }
            set { dwmc = value; }
        }
        private string dwbh;
        /// <summary>
        /// //单位编号
        /// </summary>
        public string Dwbh
        {
            get { return dwbh; }
            set { dwbh = value; }
        }
        private string tcqh;
        /// <summary>
        /// //统筹区号
        /// </summary>
        public string Tcqh
        {
            get { return tcqh; }
            set { tcqh = value; }
        }
        private string qybh;
        /// <summary>
        /// //区域编号
        /// </summary>
        public string Qybh
        {
            get { return qybh; }
            set { qybh = value; }
        }
        private string zgjmbz;
        /// <summary>
        /// //职工居民标志
        /// </summary>
        public string Zgjmbz
        {
            get { return zgjmbz; }
            set { zgjmbz = value; }
        }
        private string ybcsmc1;
        /// <summary>
        /// //医保参数1名称
        /// </summary>
        public string Ybcsmc1
        {
            get { return ybcsmc1; }
            set { ybcsmc1 = value; }
        }
        private string ybcsz1;
        /// <summary>
        /// //医保参数1值
        /// </summary>
        public string Ybcsz1
        {
            get { return ybcsz1; }
            set { ybcsz1 = value; }
        }
        private string ybcsmc2;
        /// <summary>
        /// //医保参数2名称
        /// </summary>
        public string Ybcsmc2
        {
            get { return ybcsmc2; }
            set { ybcsmc2 = value; }
        }
        private string ybcsz2;
        /// <summary>
        /// //医保参数2值
        /// </summary>
        public string Ybcsz2
        {
            get { return ybcsz2; }
            set { ybcsz2 = value; }
        }
        private string ybcsmc3;
        /// <summary>
        /// //医保参数3名称
        /// </summary>
        public string Ybcsmc3
        {
            get { return ybcsmc3; }
            set { ybcsmc3 = value; }
        }
        private string ybcsz3;
        /// <summary>
        /// //医保参数3值
        /// </summary>
        public string Ybcsz3
        {
            get { return ybcsz3; }
            set { ybcsz3 = value; }
        }
        private string ybcsmc4;
        /// <summary>
        /// //医保参数4名称
        /// </summary>
        public string Ybcsmc4
        {
            get { return ybcsmc4; }
            set { ybcsmc4 = value; }
        }
        private string ybcsz4;
        /// <summary>
        /// //医保参数4值
        /// </summary>
        public string Ybcsz4
        {
            get { return ybcsz4; }
            set { ybcsz4 = value; }
        }
        private string ybcsmc5;
        /// <summary>
        /// //医保参数5名称
        /// </summary>
        public string Ybcsmc5
        {
            get { return ybcsmc5; }
            set { ybcsmc5 = value; }
        }
        private string ybcsz5;
        /// <summary>
        /// //医保参数5值
        /// </summary>
        public string Ybcsz5
        {
            get { return ybcsz5; }
            set { ybcsz5 = value; }
        }
        private string ybcsmc6;
        /// <summary>
        /// //医保参数6名称
        /// </summary>
        public string Ybcsmc6
        {
            get { return ybcsmc6; }
            set { ybcsmc6 = value; }
        }
        private string ybcsz6;
        /// <summary>
        /// //医保参数6值
        /// </summary>
        public string Ybcsz6
        {
            get { return ybcsz6; }
            set { ybcsz6 = value; }
        }
        private string grbh;
        /// <summary>
        /// //个人编号
        /// </summary>
        public string Grbh
        {
            get { return grbh; }
            set { grbh = value; }
        }
        private string kh;
        /// <summary>
        /// //卡号（无卡人员为空）
        /// </summary>
        public string Kh
        {
            get { return kh; }
            set { kh = value; }
        }
        private string zhye;
        /// <summary>
        /// //账户余额
        /// </summary>
        public string Zhye
        {
            get { return zhye; }
            set { zhye = value; }
        }
        private string fsbz;
        /// <summary>
        /// //封锁标志
        /// </summary>
        public string Fsbz
        {
            get { return fsbz; }
            set { fsbz = value; }
        }
        private string fslx;
        /// <summary>
        /// //封锁类型
        /// </summary>
        public string Fslx
        {
            get { return fslx; }
            set { fslx = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
        private string mediType;
        /// <summary>
        /// 医疗类别
        /// </summary>
        public string MediType
        {
            get { return mediType; }
            set { mediType = value; }
        }
        private string approType;
        /// <summary>
        /// 审批类别
        /// </summary>
        public string ApproType
        {
            get { return approType; }
            set { approType = value; }
        }
        private string approCode;
        /// <summary>
        /// 审批编号
        /// </summary>
        public string ApproCode
        {
            get { return approCode; }
            set { approCode = value; }
        }
        private string diseaseCode;
        /// <summary>
        /// 疾病编码
        /// </summary>
        public string DiseaseCode
        {
            get { return diseaseCode; }
            set { diseaseCode = value; }
        }
        private string diseaseName;
        /// <summary>
        /// 疾病名称
        /// </summary>
        public string DiseaseName
        {
            get { return diseaseName; }
            set { diseaseName = value; }
        }
        private string apItemCode;
        /// <summary>
        /// 项目编码
        /// </summary>
        public string ApItemCode
        {
            get { return apItemCode; }
            set { apItemCode = value; }
        }
        private string apItemName;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ApItemName
        {
            get { return apItemName; }
            set { apItemName = value; }
        }

        private string jylsh;
        /// <summary>
        /// 交易流水号(医保登记函数返回)
        /// </summary>
        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string zycs;
        /// <summary>
        /// 住院次数
        /// </summary>
        public string Zycs
        {
            get { return zycs; }
            set { zycs = value; }
        }
        private string qfx;
        /// <summary>
        /// 起付线
        /// </summary>
        public string Qfx
        {
            get { return qfx; }
            set { qfx = value; }
        }


        //预结算使用
        private string zfy;
        /// <summary>
        /// 总费用
        /// </summary>
        public string Zfy
        {
            get { return zfy; }
            set { zfy = value; }
        }
        private string xj;
        /// <summary>
        /// //现金
        /// </summary>
        public string Xj
        {
            get { return xj; }
            set { xj = value; }
        }
        private string zhzf;
        /// <summary>
        /// 账户支付
        /// </summary>
        public string Zhzf
        {
            get { return zhzf; }
            set { zhzf = value; }
        }
        private string tczf;
        /// <summary>
        /// 统筹支付
        /// </summary>
        public string Tczf
        {
            get { return tczf; }
            set { tczf = value; }
        }
    }
}
