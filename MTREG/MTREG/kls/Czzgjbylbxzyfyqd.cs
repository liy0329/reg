using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.gysyb.Entity
{
    /// <summary>
    /// 城镇职工基本医疗保险住院费用结算清单-----打印类
    /// </summary>
   public class Czzgjbylbxzyfyqd
    {
        private string jzsxh;//就诊顺序号

        public string Jzsxh
        {
            get { return jzsxh; }
            set { jzsxh = value; }
        }
        private string kssj;//开始时间

        public string Kssj
        {
            get { return kssj; }
            set { kssj = value; }
        }
        private string jssj;//结束时间

        public string Jssj
        {
            get { return jssj; }
            set { jssj = value; }
        }
        private string grbh;//个人编号
        private string xm;// 姓名
        private string xb;//性别
        private string nl;//年龄
        private string rylb;//人员类别
        private string dwmc;//单位名称
        private string bcqfx;//本次起付线
        private string ryzd;//入院诊断
        private string rysj;//入院时间
        private string fyqssj;//费用起始时间
        private string fyjzsj;//费用截止时间
        private string yfj;//预付金
        private string cyzd;//出院诊断
        private string cysj;//出院时间
        private string zyts;//住院天数
        private string xyf;//西药费
        private string zcy;//中成药
        private string zcyf;//中草药
        private string jcf;//检查费
        private string zlf;//治疗费
        private string zfc;//诊查费           
        private string hyf;//化验费
        private string ssf;//手术费
        private string cwf;//床位费
        private string hlf;//护理费
        private string qt;//其他
        private string fyhjxm;//费用合计--医疗项目


        public string Fyqssj
        {
            set { fyqssj=value; }
            get { return fyqssj; }
        }
        public string Fyjzsj
        {
            set { fyjzsj = value; }
            get { return fyjzsj; }
        }
        public string Grbh
        {
            get { return grbh; }
            set { grbh = value; }
        }
        public string Xm
        {
            get { return xm; }
            set { xm = value; }
        }
        public string Xb
        {
            get { return xb; }
            set { xb = value; }
        }
        public string Nl
        {
            get { return nl; }
            set { nl = value; }
        }
        public string Rylb
        {
            get { return rylb; }
            set { rylb = value; }
        }
        public string Dwmc
        {
            get { return dwmc; }
            set { dwmc = value; }
        }
        public string Bcqfx
        {
            get { return bcqfx; }
            set { bcqfx = value; }
        }
        public string Ryzd
        {
            get { return ryzd; }
            set { ryzd = value; }
        }
        public string Rysj
        {
            get { return rysj; }
            set { rysj = value; }
        }
        public string Yfj
        {
            get { return yfj; }
            set { yfj = value; }
        }
        public string Cyzd
        {
            get { return cyzd; }
            set { cyzd = value; }
        }
        public string Cysj
        {
            get { return cysj; }
            set { cysj = value; }
        }
        public string Zyts
        {
            get { return zyts; }
            set { zyts = value; }
        }
        public string Xyf
        {
            get { return xyf; }
            set { xyf = value; }
        }
        public string Zcy
        {
            get { return zcy; }
            set { zcy = value; }
        }
        public string Zcyf
        {
            get { return zcyf; }
            set { zcyf = value; }
        }
        public string Jcf
        {
            get { return jcf; }
            set { jcf = value; }
        }
        public string Zlf
        {
            get { return zlf; }
            set { zlf = value; }
        }
        public string Zfc
        {
            get { return zfc; }
            set { zfc = value; }
        }
        public string Hyf
        {
            get { return hyf; }
            set { hyf = value; }
        }
        public string Ssf
        {
            get { return ssf; }
            set { ssf = value; }
        }
        public string Cwf
        {
            get { return cwf; }
            set { cwf = value; }
        }
        public string Hlf
        {
            get { return hlf; }
            set { hlf = value; }
        }
        public string Qt
        {
            get { return qt; }
            set { qt = value; }
        }
        public string Fyhjxm
        {
            get { return fyhjxm; }
            set { fyhjxm = value; }
        }



        private string qfx;//起付线
        private string stzfbf;//三特自付部分
        private string qzfbf;//全自费部分
        private string jbtczif;//基本统筹自付
        private string jbtczhif;//基本统筹支付
        private string detczif;//大额统筹自付
        private string detczhif;//大额统筹支付
        private string cgxezf;//超过限额自付
        public string Cgxezf
        {
            get { return cgxezf; }
            set { cgxezf = value; }
        }
        private string fyhj;//费用合计--医疗总费用支付分类
        private string qzgrzhzf;//
        private string gwyylbzzf;//公务员医疗补助支付
        private string cdegwybz;//超大额公务员补偿
        private string txgwybz;//特项公务员补偿

        public string Qfx
        {
            get { return qfx; }
            set { qfx = value; }
        }
        public string Stzfbf
        {
            get { return stzfbf; }
            set { stzfbf = value; }
        }
        public string Qzfbf
        {
            get { return qzfbf; }
            set { qzfbf = value; }
        }
        public string Jbtczif
        {
            get { return jbtczif; }
            set { jbtczif = value; }
        }
        public string Jbtczhif
        {
            get { return jbtczhif; }
            set { jbtczhif = value; }
        }
        public string Detczif
        {
            get { return detczif; }
            set { detczif = value; }
        }
        public string Detczhif
        {
            get { return detczhif; }
            set { detczhif = value; }
        }
   
        public string Fyhj
        {
            get { return fyhj; }
            set { fyhj = value; }
        }
        public string Qzgrzhzf
        {
            get { return qzgrzhzf; }
            set { qzgrzhzf = value; }
        }
        public string Gwyylbzzf
        {
            get { return gwyylbzzf; }
            set { gwyylbzzf = value; }
        }
        public string Cdegwybz
        {
            get { return cdegwybz; }
            set { cdegwybz = value; }
        }
        public string Txgwybz
        {
            get { return txgwybz; }
            set { txgwybz = value; }
        }

    }
}
