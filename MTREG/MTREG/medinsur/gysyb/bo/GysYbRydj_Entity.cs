using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    class GysYbRydj_Entity
    {
        private string mtzyjl_iid;
        string centercode;//分中心编码
        string billno;//就诊顺序号
        string hosptimes;//本年住院次数
        string startfee;//本次起付线
        string startfeepaid;//本年已支付起付线
        string fund1lmt;//基本统筹限额
        string fund1paid;//本年已支付基本统筹
        string fund2lmt;//大额统筹限额
        string fund2paid;//本年已支付大额统筹
        string lockinfo;//封锁信息
        string note;//备注
        string soeccalflag;//特殊结算标志
        string speccalflagtxt;//特殊结算说明
        string reckoningtype;//清算方式 
        string singleillnesscode;//清算病种编码 
        string singlellnessname;//病种名称
        string handledate;//系统处理时间
        private string cardtype;//卡类别
        private string carddata;//磁条数据
        private string sno;//社会保障号
        private string personcode;//个人编号
        private string ipaddr;// 终端机IP地址
        private string psamno;//PASM卡号
        private string pwd;//密码
        private string insuretype;//保险类别
        private string paytype;//支付类别
        private string deptname;//单位名称
        private string rylb;//人员类别
        private string rylbName;//人员名称
        private string dwmc;//单位名称
        private string zhye;//账户余额
        private string deptcode;//单位编码
        private string caltype; //结算方式

        public string Caltype
        {
            get { return caltype; }
            set { caltype = value; }
        }
        /// <summary>
        /// //分中心编码
        /// </summary>
        public string Centercode
        {
            get { return centercode; }
            set { centercode = value; }
        }
        
        /// <summary>
        /// //就诊顺序号
        /// </summary>
        public string Billno
        {
            get { return billno; }
            set { billno = value; }
        }
        
        /// <summary>
        /// //本年住院次数
        /// </summary>
        public string Hosptimes
        {
            get { return hosptimes; }
            set { hosptimes = value; }
        }
        
        /// <summary>
        /// //本次起付线
        /// </summary>
        public string Startfee
        {
            get { return startfee; }
            set { startfee = value; }
        }
        
        /// <summary>
        /// //本年已支付起付线
        /// </summary>
        public string Startfeepaid
        {
            get { return startfeepaid; }
            set { startfeepaid = value; }
        }
        
        /// <summary>
        /// //基本统筹限额
        /// </summary>
        public string Fund1lmt
        {
            get { return fund1lmt; }
            set { fund1lmt = value; }
        }
        
        /// <summary>
        /// //本年已支付基本统筹
        /// </summary>
        public string Fund1paid
        {
            get { return fund1paid; }
            set { fund1paid = value; }
        }
        
        /// <summary>
        /// //大额统筹限额
        /// </summary>
        public string Fund2lmt
        {
            get { return fund2lmt; }
            set { fund2lmt = value; }
        }
        
        /// <summary>
        /// //本年已支付大额统筹
        /// </summary>
        public string Fund2paid
        {
            get { return fund2paid; }
            set { fund2paid = value; }
        }
       
        
        /// <summary>
        /// //封锁信息
        /// </summary>
        public string Lockinfo
        {
            get { return lockinfo; }
            set { lockinfo = value; }
        }
        
        /// <summary>
        /// //备注
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        
        /// <summary>
        /// //特殊结算标志
        /// </summary>
        public string Soeccalflag
        {
            get { return soeccalflag; }
            set { soeccalflag = value; }
        }
        
        /// <summary>
        /// //特殊结算说明
        /// </summary>
        public string Speccalflagtxt
        {
            get { return speccalflagtxt; }
            set { speccalflagtxt = value; }
        }
        
        /// <summary>
        /// //清算方式
        /// </summary>
        public string Reckoningtype
        {
            get { return reckoningtype; }
            set { reckoningtype = value; }
        }
        
        /// <summary>
        /// //清算病种编码
        /// </summary>
        public string Singleillnesscode
        {
            get { return singleillnesscode; }
            set { singleillnesscode = value; }
        }
        
        /// <summary>
        /// //病种名称
        /// </summary>
        public string Singlellnessname
        {
            get { return singlellnessname; }
            set { singlellnessname = value; }
        }
        
        /// <summary>
        /// //系统处理时间
        /// </summary>
        public string Handledate
        {
            get { return handledate; }
            set { handledate = value; }
        }

        
        /// <summary>
        /// 卡类别
        /// </summary>
        public string Cardtype
        {
            get { return cardtype; }
            set { cardtype = value; }
        }
        
        /// <summary>
        /// 磁条数据
        /// </summary>
        public string Carddata
        {
            get { return carddata; }
            set { carddata = value; }
        }
        
        /// <summary>
        /// 社会保障号
        /// </summary>
        public string Sno
        {
            get { return sno; }
            set { sno = value; }
        }
        
        /// <summary>
        /// 个人编号
        /// </summary>
        public string Personcode
        {
            get { return personcode; }
            set { personcode = value; }
        }
        
        /// <summary>
        /// 终端机IP地址
        /// </summary>
        public string Ipaddr
        {
            get { return ipaddr; }
            set { ipaddr = value; }

        }
        
        /// <summary>
        /// PASM卡号
        /// </summary>
        public string Psamno
        {
            get { return psamno; }
            set { psamno = value; }
        }
        
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
        
        /// <summary>
        /// 保险类别
        /// </summary>
        public string Insuretype
        {
            get { return insuretype; }
            set { insuretype = value; }
        }
        
        /// <summary>
        /// 支付类别
        /// </summary>
        public string Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        
        /// <summary>
        /// Mtzyjl_iid
        /// </summary>
        public string Mtzyjl_iid
        {
            get { return mtzyjl_iid; }
            set { mtzyjl_iid = value; }
        }
        
        /// <summary>
        /// 单位编码
        /// </summary>
        public string Deptcode
        {
            get { return deptcode; }
            set { deptcode = value; }
        }
        
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Deptname
        {
            get { return deptname; }
            set { deptname = value; }
        }
        
        /// <summary>
        /// 人员类别
        /// </summary>
        public string Rylb
        {
            get { return rylb; }
            set { rylb = value; }
        }

        
        /// <summary>
        /// 人员名称
        /// </summary>
        public string RylbName
        {
            get { return rylbName; }
            set { rylbName = value; }
        }

        
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Dwmc
        {
            get { return dwmc; }
            set { dwmc = value; }
        }
        
        /// <summary>
        /// 账户余额
        /// </summary>
        public string Zhye
        {
            get { return zhye; }
            set { zhye = value; }
        }
    }
}
