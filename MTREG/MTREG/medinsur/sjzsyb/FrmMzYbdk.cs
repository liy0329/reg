using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.Util;
using MTHIS.common;
using MTREG.common;
using MTREG.clinic;
using MTHIS.main.bll;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.clinic.bo;
using System.IO;
using MTREG.medinsur.sjzsyb.bean;
using System.Web.UI.WebControls;
using MTREG.ihsp.bll;
using MTREG.medinsur.sjzsyb;

namespace MTREG
{
    public partial class FrmMzYbdk : Form
    {
        public FrmMzYbdk()
        {
            InitializeComponent();
        }
        BillCmbList BillCmbList = new BillCmbList();
        SjzybInterface sjzybInterface = new SjzybInterface();
        private void btn_Wk_Click(object sender, EventArgs e)
        {
            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "30";//出院预结算
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            yb_in_ryjbxxhzh.MSGNO = "1401";
            yb_in_ryjbxxhzh.AAC001 = tbxsfzh.Text.ToString();
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret != 0)
            {
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }
            fz(yb_out_ryjbxxhzh);
        }

        private void btn_Yk_Click(object sender, EventArgs e)
        {
            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "30";//30读卡查询
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            yb_in_ryjbxxhzh.MSGNO = "1401";
            //yb_in_ryjbxxhzh.MSGNO = "5013";
            //yb_in_ryjbxxhzh.AAC001 = "130427199707290710";
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }
            fz(yb_out_ryjbxxhzh);
            label23.Visible = true;
            label23.Text = "最后访问时间:" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            label24.Visible = true;
            label24.Text = "操作员:" + yb_in_ryjbxxhzh.OPERNAME;
        }
        public void fz(DK_OUT yb_out_ryjbxxhzh)
        {
            ipt_xm.Text = yb_out_ryjbxxhzh.AAC003;
            tb_Birthdays.Text = yb_out_ryjbxxhzh.AAC006;
            tbx_xb.Text = yb_out_ryjbxxhzh.AAC004 == "1" ? "男" : "女";
            DataTable dt = BillCmbList.getRaceInfo_code(yb_out_ryjbxxhzh.AAC005);
            if (dt.Rows.Count >= 1)
            {
                tb_Nation.Text = dt.Rows[0]["name"].ToString();
            }
            else
            {
                tb_Nation.Text = "无";
            }
            ipt_ickh.Text = yb_out_ryjbxxhzh.AKC020;
            tbxsfzh.Text = yb_out_ryjbxxhzh.AAC002;
            tb_fsj.Text = yb_out_ryjbxxhzh.CKAA12 == "0" ? "否" : "是";
            tb_Poverty.Text = yb_out_ryjbxxhzh.CKAA35 == "0" ? "否" : "是";
            tb_Account.Text = yb_out_ryjbxxhzh.AKC086;
            tb_tczc.Text = yb_out_ryjbxxhzh.AKC088;
            tb_fhjbyl.Text = yb_out_ryjbxxhzh.AKC089;
            tb_gwytcjl.Text = yb_out_ryjbxxhzh.ZKC026;
            tb_tsbjb.Text = yb_out_ryjbxxhzh.AKC099;
            tbx_grzhye.Text = yb_out_ryjbxxhzh.AKC087;
            tb_cbcode.Text = yb_out_ryjbxxhzh.AKC803;
            tb_cbname.Text = yb_out_ryjbxxhzh.AKC804;
            tb_mx.Text = yb_out_ryjbxxhzh.ZKA102.ToString().Replace("|", ",");
            tb_ts.Text = yb_out_ryjbxxhzh.ZKA103.ToString().Replace("|", ",");
            #region 医疗人员类别
            string rylb = "";
            if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("11"))
            {
                rylb = "在职";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("21"))
            {
                rylb = "退休";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("31"))
            {
                rylb = "机关离休";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("32"))
            {
                rylb = "企事业离休";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("33"))
            {
                rylb = "医疗费实报实销六级及以上伤残军人";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("41"))
            {
                rylb = "城乡居民";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("99"))
            {
                rylb = "其他";
            }
            tbx_ryxz.Text = rylb;
            #endregion
            #region 公务员类别
            string gwy = "";
            if (yb_out_ryjbxxhzh.AAC021.ToString().Equals("0"))
            {
                gwy = "非公务员";
            }
            else if (yb_out_ryjbxxhzh.AAC021.ToString().Equals("1"))
            {
                gwy = "公务员";
            }
            else if (yb_out_ryjbxxhzh.AAC021.ToString().Equals("2"))
            {
                gwy = "享受公务员待遇";
            }
            else if (yb_out_ryjbxxhzh.AAC021.ToString().Equals("3"))
            {
                gwy = "劳模";
            }
            tbx_gwylx.Text = gwy;

            #endregion
            #region 在院状态
            string iszy = "";
            if (yb_out_ryjbxxhzh.ZKC031.ToString().Equals("0"))
            {
                iszy = "不在院";
            }
            else if (yb_out_ryjbxxhzh.ZKC031.ToString().Equals("1"))
            {
                iszy = "在院";
            }
            else if (yb_out_ryjbxxhzh.ZKC031.ToString().Equals("2"))
            {
                iszy = "出院未结算";
            }
            tbx_zyzt.Text = iszy;

            #endregion
            #region 定点
            string ckaa34 = "";
            if (yb_out_ryjbxxhzh.CKAA34.ToString().Equals("0"))
            {
                ckaa34 = "未设普通门诊统筹定点";
            }
            else if (yb_out_ryjbxxhzh.CKAA34.ToString().Equals("1"))
            {
                ckaa34 = "当前定点是本人普通门诊统筹定点";
            }
            else if (yb_out_ryjbxxhzh.CKAA34.ToString().Equals("2"))
            {
                ckaa34 = "当前定点非本人普通门诊统筹定点";
            }
            tb_Fixed.Text = ckaa34;
            #endregion
            #region 人员状态
            string aac008 = "";
            if (yb_out_ryjbxxhzh.AAC008.ToString().Equals("0"))
            {
                aac008 = "正常";
            }
            else if (yb_out_ryjbxxhzh.AAC008.ToString().Equals("1"))
            {
                aac008 = "死亡";
            }
            else if (yb_out_ryjbxxhzh.AAC008.ToString().Equals("2"))
            {
                aac008 = "调离";
            }
            else if (yb_out_ryjbxxhzh.AAC008.ToString().Equals("3"))
            {
                aac008 = "注销";
            }
            else if (yb_out_ryjbxxhzh.AAC008.ToString().Equals("5"))
            {
                aac008 = "停止待遇";
            }
            tb_ryzt.Text = aac008;
            #endregion



        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmclinicPoint FrmclinicPoint = new FrmclinicPoint();
            FrmclinicPoint.ShowDialog();
        }
    }
}
