using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb
{
	public class frmnhzy
	{
        private string bcjg;//补偿机构

        public string Bcjg
        {
            get { return bcjg; }
            set { bcjg = value; }
        }
        private string hzname;//患者姓名

        public string Hzname
        {
            get { return hzname; }
            set { hzname = value; }
        }
        private string sex;//性别

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string age;//年龄

        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        private string grsx;//个人属性

        public string Grsx
        {
            get { return grsx; }
            set { grsx = value; }
        }
        private string tel;//联系电话

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string jyjg;//就医机构

        public string Jyjg
        {
            get { return jyjg; }
            set { jyjg = value; }
        }
        private string fph;//发票号

        public string Fph
        {
            get { return fph; }
            set { fph = value; }
        }
        private string zyh;//住院号

        public string Zyh
        {
            get { return zyh; }
            set { zyh = value; }
        }
        private string hzxm; //户主姓名

        public string Hzxm
        {
            get { return hzxm; }
            set { hzxm = value; }
        }
        private string address;//家庭住址

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string ylzh;//医疗证号

        public string Ylzh
        {
            get { return ylzh; }
            set { ylzh = value; }
        }
        private string ryrq;//入院日期

        public string Ryrq
        {
            get { return ryrq; }
            set { ryrq = value; }
        }
        private string zdjb;//是否重大疾病

        public string Zdjb
        {
            get { return zdjb; }
            set { zdjb = value; }
        }
        private string bclx;//补偿类型

        public string Bclx
        {
            get { return bclx; }
            set { bclx = value; }
        }
        private string cyrq;//出院日期

        public string Cyrq
        {
            get { return cyrq; }
            set { cyrq = value; }
        }
        private string bzfyde;//病种费用定额

        public string Bzfyde
        {
            get { return bzfyde; }
            set { bzfyde = value; }
        }
        private string tbtgbce;//特别提高补偿额

        public string Tbtgbce
        {
            get { return tbtgbce; }
            set { tbtgbce = value; }
        }
        private string qfx;//起付线

        public string Qfx
        {
            get { return qfx; }
            set { qfx = value; }
        }
        private string yycdje; //医院承担金额

        public string Yycdje
        {
            get { return yycdje; }
            set { yycdje = value; }
        }
        private string sfzz;//是否转诊

        public string Sfzz
        {
            get { return sfzz; }
            set { sfzz = value; }
        }
        private string zfy;//总费用

        public string Zfy
        {
            get { return zfy; }
            set { zfy = value; }
        }
        private string grzfje;//个人自付金额

        public string Grzfje
        {
            get { return grzfje; }
            set { grzfje = value; }
        }
        private string zlfs;//治疗方式

        public string Zlfs
        {
            get { return zlfs; }
            set { zlfs = value; }
        }
        private string kbfy;//可报费用

        public string Kbfy
        {
            get { return kbfy; }
            set { kbfy = value; }
        }
        private string clcxzf;//材料超限自付

        public string Clcxzf
        {
            get { return clcxzf; }
            set { clcxzf = value; }
        }
        private string zycs;//住院次数

        public string Zycs
        {
            get { return zycs; }
            set { zycs = value; }
        }
        private string bkbfy;//不可报费用

        public string Bkbfy
        {
            get { return bkbfy; }
            set { bkbfy = value; }
        }
        private string mzjxje;//民政救助金额

        public string Mzjxje
        {
            get { return mzjxje; }
            set { mzjxje = value; }
        }
        private string yyfy; //医药费用

        public string Yyfy
        {
            get { return yyfy; }
            set { yyfy = value; }
        }
        private string cyzd;//出院诊断

        public string Cyzd
        {
            get { return cyzd; }
            set { cyzd = value; }
        }
        private string dbybpf;//大病医保赔付

        public string Dbybpf
        {
            get { return dbybpf; }
            set { dbybpf = value; }
        }
        private string bcje;//补偿金额

        public string Bcje
        {
            get { return bcje; }
            set { bcje = value; }
        }
        private string jjsjbcje;//基金实际补偿额

        public string Jjsjbcje
        {
            get { return jjsjbcje; }
            set { jjsjbcje = value; }
        }
        private string bcjedx;//大写

        public string Bcjedx
        {
            get { return bcjedx; }
            set { bcjedx = value; }
        }
        private string bcrq; //补偿日期
        public string Bcrq
        {
            get { return bcrq; }
            set { bcrq = value; }
        }
        private string jsgs; //计算公式
        public string Jsgs
        {
            get { return jsgs; }
            set { jsgs = value; }
        }
        private string dbbxhgfy; //大病保险合规费用
        public string Dbbxhgfy
        {
            get { return dbbxhgfy; }
            set { dbbxhgfy = value; }
        }
        private string dbqfx; //大病起伏线
        public string Dbqfx
        {
            get { return dbqfx; }
            set { dbqfx = value; }
        }
        private string jsbc; //计生补偿
        public string Jsbc
        {
            get { return jsbc; }
            set { jsbc = value; }
        }
        private string csbc; //慈善补偿
        public string Csbc
        {
            get { return csbc; }
            set { csbc = value; }
        }
        private string fpbc; //扶贫补偿
        public string Fpbc
        {
            get { return fpbc; }
            set { fpbc = value; }
        }
        private string jzfpsx; //精准扶贫属性
        public string Jzfpsx
        {
            get { return jzfpsx; }
            set { jzfpsx = value; }
        }
        private string mzyfbz; //民政优抚补助
        public string Mzyfbz
        {
            get { return mzyfbz; }
            set { mzyfbz = value; }
        }
        private string cxyfbz; //城乡优抚补助
        public string Cxyfbz
        {
            get { return cxyfbz; }
            set { cxyfbz = value; }
        }
        private string bcbchj;//本次补偿合计
        public string Bcbchj
        {
            get { return bcbchj; }
            set { bcbchj = value; }
        }

        private string ypf;//药品费
        public string Ypf
        {
            get { return ypf; }
            set { ypf = value; }
        }

        private string clf;//材料费
        public string Clf
        {
            get { return clf; }
            set { clf = value; }
        }

        private string jcf;//检查费
        public string Jcf
        {
            get { return jcf; }
            set { jcf = value; }
        }

        private string zlf;//治疗费
        public string Zlf
        {
            get { return zlf; }
            set { zlf = value; }
        }

        private string cwf;//床位费
        public string Cwf
        {
            get { return cwf; }
            set { cwf = value; }
        }

        private string hlf;//护理费
        public string Hlf
        {
            get { return hlf; }
            set { hlf = value; }
        }

        private string hyf;//化验费
        public string Hyf
        {
            get { return hyf; }
            set { hyf = value; }
        }

        private string zhenlf;//诊疗费
        public string Zhenlf
        {
            get { return zhenlf; }
            set { zhenlf = value; }
        }

        private string ssf;//手术费
        public string Ssf
        {
            get { return ssf; }
            set { ssf = value; }
        }

        private string qtf;//其他费
        public string Qtf
        {
            get { return qtf; }
            set { qtf = value; }
        }
    }
}
