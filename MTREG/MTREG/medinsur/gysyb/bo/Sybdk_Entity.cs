using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    class Sybdk_Entity
    {
        private string mzmzblstuff_iid;
        private string xtclsj;//系统处理时间
        private string ttm;//状态码
        private string message;//错误信息
        private string fzxbm;//分中心编码
        private string grbh;//个人编码
        private string xm;//姓名
        private string xb;//性别
        private string sfzhm;//身份证号码
        private string csrq;//出生日期
        private string rylb;//人员类别
        private string rylbName;//人员名称
        private string bxlb;//保险类别
        private string ylzgrybz;//医疗照顾人员标志
        private string dwbm;//单位编码
        private string dwmc;//单位名称
        private string zhye;//账户余额
        private string bnzycs;//本年住院次数
        private string bcqfx;//本次起付线
        private string bnyzfqfx;//本年已支付起付线
        private string jbtcxe;//基本统筹限额
        private string bnyzfjbtc;//本年已支付基本统筹
        private string detcxe;//大额统筹限额
        private string bnyzfdetc;//本年已支付大额统筹
        private string bnptmzylbzye;//本年普通门诊医疗补助限额
        private string bnptmzylbzlj;//本年普通门诊医疗补助累计
        private string ptmzylbzqfbz;//普通门诊医疗补助起付标准
        private string ptmzylbzjzksyje;//普通门诊医疗补助结转可使用金额 
        private string fsxx;//封锁信息
        private string bz;//备注
        private string klb;//卡类别
        private string ctsj;//磁条数据
        private string zdjipdz;//终端机IP地址
        private string pasmkh;//PASM卡号
        private string mm;//密码
        private string dyksxssj;//待遇享受时间
        private string gsrdbh;//工伤认定编号
        private string jsfs;//结算方式
        private string qsfs;//清算方式
        private string zflb;//支付类别
        private string ryrq;//入院登记
        private string ks;//科室
        private string ys;//医生
        private string zdmc;//诊断名称
        private string zdicd;//诊断编码
        private string gsrd;//工伤认定编号
        private string gskfzybz;//工伤康复住院标志
        private string dbzbm;//单病种编码
        private string cfbh;//处方编号
        private string tbzbm;//特种病编码
        private string fph;//发票号
        private string invoice_id;//发票id
        private string zhzf;//账户支付金额

        /// <summary>
        /// 账户支付输入
        /// </summary>
        public string Zhzf
        {
            get { return zhzf; }
            set { zhzf = value; }
        }

        /// <summary>
        /// 发票表id
        /// </summary>
        public string Invoice_id
        {
            get { return invoice_id; }
            set { invoice_id = value; }
        }
        /// <summary>
        /// 发票号
        /// </summary>
        public string Fph
        {
            get { return fph; }
            set { fph = value; }
        }
        /// <summary>
        /// 单病种编码
        /// </summary>
        public string Dbzbm
        {
            get { return dbzbm; }
            set { dbzbm = value; }
        }
        /// <summary>
        /// 处方编号
        /// </summary>
        public string Cfbh
        {
            get { return cfbh; }
            set { cfbh = value; }
        }
        /// <summary>
        /// 特种病编码
        /// </summary>
        public string Tbzbm
        {
            get { return tbzbm; }
            set { tbzbm = value; }
        }
        /// <summary>
        /// 工伤康复住院标志
        /// </summary>
        public string Gskfzybz
        {
            get { return gskfzybz; }
            set { gskfzybz = value; }
        }
        /// <summary>
        /// 工伤认定编号
        /// </summary>
        public string Gsrd
        {
            get { return gsrd; }
            set { gsrd = value; }
        }
        /// <summary>
        /// 诊断编码
        /// </summary>
        public string Zdicd
        {
            get { return zdicd; }
            set { zdicd = value; }
        }
        /// <summary>
        /// 诊断名称
        /// </summary>
        public string Zdmc
        {
            get { return zdmc; }
            set { zdmc = value; }
        }
        /// <summary>
        /// 医生
        /// </summary>
        public string Ys
        {
            get { return ys; }
            set { ys = value; }
        }
        /// <summary>
        /// 科室
        /// </summary>
        public string Ks
        {
            get { return ks; }
            set { ks = value; }
        }
        /// <summary>
        /// 入院登记
        /// </summary>
        public string Ryrq
        {
            get { return ryrq; }
            set { ryrq = value; }
        }
        /// <summary>
        /// 支付类别
        /// </summary>
        public string Zflb
        {
            get { return zflb; }
            set { zflb = value; }
        }
        /// <summary>
        /// 清算方式
        /// </summary>
        public string Qsfs
        {
            get { return qsfs; }
            set { qsfs = value; }
        }
        /// <summary>
        /// 结算方式
        /// </summary>
        public string Jsfs
        {
            get { return jsfs; }
            set { jsfs = value; }
        }
        /// <summary>
        /// 工伤认定编号
        /// </summary>
        public string Gsrdbh
        {
            get { return gsrdbh; }
            set { gsrdbh = value; }
        }
        /// <summary>
        /// 待遇享受时间
        /// </summary>
        public string Dyksxssj
        {
            get { return dyksxssj; }
            set { dyksxssj = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Mm
        {
            get { return mm; }
            set { mm = value; }
        }
        /// <summary>
        /// PASM卡号
        /// </summary>
        public string Pasmkh
        {
            get { return pasmkh; }
            set { pasmkh = value; }
        }
        /// <summary>
        /// 终端机IP地址
        /// </summary>
        public string Zdjipdz
        {
            get { return zdjipdz; }
            set { zdjipdz = value; }
        }
        /// <summary>
        /// 磁条数据
        /// </summary>
        public string Ctsj
        {
            get { return ctsj; }
            set { ctsj = value; }
        }
        /// <summary>
        /// 卡类别
        /// </summary>
        public string Klb
        {
            get { return klb; }
            set { klb = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mzmzblstuff_iid
        {
            get { return mzmzblstuff_iid; }
            set { mzmzblstuff_iid = value; }
        }
        /// <summary>
        /// 系统处理时间
        /// </summary>
        public string Xtclsj
        {
            get { return xtclsj; }
            set { xtclsj = value; }
        }
        /// <summary>
        /// 状态码
        /// </summary>
        public string Ttm
        {
            get { return ttm; }
            set { ttm = value; }
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        /// <summary>
        /// 个人编号
        /// </summary>
        public string Grbh
        {
            get { return grbh; }
            set { grbh = value; }
        }
        /// <summary>
        /// 分中心编码
        /// </summary>
        public string Fzxbm
        {
            get { return fzxbm; }
            set { fzxbm = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Xm
        {
            get { return xm; }
            set { xm = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Xb
        {
            get { return xb; }
            set { xb = value; }
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string Sfzhm
        {
            get { return sfzhm; }
            set { sfzhm = value; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Csrq
        {
            get { return csrq; }
            set { csrq = value; }
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
        /// 保险类别
        /// </summary>
        public string Bxlb
        {
            get { return bxlb; }
            set { bxlb = value; }
        }
        /// <summary>
        /// 医疗照顾人员标志
        /// </summary>
        public string Ylzgrybz
        {
            get { return ylzgrybz; }
            set { ylzgrybz = value; }
        }
        /// <summary>
        /// 单位编码
        /// </summary>
        public string Dwbm
        {
            get { return dwbm; }
            set { dwbm = value; }
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
        /// <summary>
        /// 本年住院次数
        /// </summary>
        public string Bnzycs
        {
            get { return bnzycs; }
            set { bnzycs = value; }
        }
        /// <summary>
        /// 本次起付线
        /// </summary>
        public string Bcqfx
        {
            get { return bcqfx; }
            set { bcqfx = value; }
        }
        /// <summary>
        /// 本年已支付起付线
        /// </summary>
        public string Bnyzfqfx
        {
            get { return bnyzfqfx; }
            set { bnyzfqfx = value; }
        }
        /// <summary>
        /// 基本统筹限额
        /// </summary>
        public string Jbtcxe
        {
            get { return jbtcxe; }
            set { jbtcxe = value; }
        }
        /// <summary>
        /// 本年已支付基本统筹
        /// </summary>
        public string Bnyzfjbtc
        {
            get { return bnyzfjbtc; }
            set { bnyzfjbtc = value; }
        }
        /// <summary>
        /// 大额统筹限额
        /// </summary>
        public string Detcxe
        {
            get { return detcxe; }
            set { detcxe = value; }
        }
        /// <summary>
        /// 本年已支付大额统筹
        /// </summary>
        public string Bnyzfdetc
        {
            get { return bnyzfdetc; }
            set { bnyzfdetc = value; }
        }
        /// <summary>
        /// 本年普通门诊医疗补助限额
        /// </summary>
        public string Bnptmzylbzye
        {
            get { return bnptmzylbzye; }
            set { bnptmzylbzye = value; }
        }
        /// <summary>
        /// 本年普通门诊医疗补助累计
        /// </summary>
        public string Bnptmzylbzlj
        {
            get { return bnptmzylbzlj; }
            set { bnptmzylbzlj = value; }
        }
        /// <summary>
        /// 普通门诊医疗补助起付标准
        /// </summary>
        public string Ptmzylbzqfbz
        {
            get { return ptmzylbzqfbz; }
            set { ptmzylbzqfbz = value; }
        }
        /// <summary>
        /// 普通门诊医疗补助结转可使用金额 
        /// </summary>
        public string Ptmzylbzjzksyje
        {
            get { return ptmzylbzjzksyje; }
            set { ptmzylbzjzksyje = value; }
        }
        /// <summary>
        /// 封锁消息
        /// </summary>
        public string Fsxx
        {
            get { return fsxx; }
            set { fsxx = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Bz
        {
            get { return bz; }
            set { bz = value; }
        }
    }
}
