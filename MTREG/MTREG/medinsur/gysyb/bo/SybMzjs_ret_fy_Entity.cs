using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    class SybMzjs_ret_fy_Entity
    {
        string ybbm;//医保编码

        public string Ybbm
        {
            get { return ybbm; }
            set { ybbm = value; }
        }
        string xmmc;//项目名称

        public string Xmmc
        {
            get { return xmmc; }
            set { xmmc = value; }
        }
        string yydj;//医院单价

        public string Yydj
        {
            get { return yydj; }
            set { yydj = value; }
        }
        string ybdj;//医保单价

        public string Ybdj
        {
            get { return ybdj; }
            set { ybdj = value; }
        }
        string sl;//数量

        public string Sl
        {
            get { return sl; }
            set { sl = value; }
        }
        string zfbl;//自付比例
        public string Zfbl
        {
            get { return zfbl; }
            set { zfbl = value; }
        }

        string tsbxxmbz;//特殊报销项目标志

        public string Tsbxxmbz
        {
            get { return tsbxxmbz; }
            set { tsbxxmbz = value; }
        }

        string bgjsxmlb;//包干结算项目类别

        public string Bgjsxmlb
        {
            get { return bgjsxmlb; }
            set { bgjsxmlb = value; }
        }
        private string fph;


        public string Fph
        {
            get { return fph; }
            set { fph = value; }
        }
    }
}
