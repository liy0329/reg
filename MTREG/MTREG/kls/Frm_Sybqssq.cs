using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.gzswyb.common;
using MTREG.medinsur.gzsyb.Util;
using MTREG.medinsur.gzsyb.bo;
using MTREG.medinsur.gzsyb.listitem;
using MTREG.medinsur.gzsyb.bll;

namespace MTREG.medinsur.gzsyb
{
    public partial class Frm_Sybqssq : Form
    {
        GzsybInterface gzsybInterface = new GzsybInterface();
        public Frm_Sybqssq()
        {
            InitializeComponent();
        }

        private void Frm_Sybqssq_Load(object sender, EventArgs e)
        {
            List<ListItem> zjlx = new List<ListItem>();
            ListItem yblb1 = new ListItem("1", "企业");
            ListItem yblb2 = new ListItem("2", "机关");
            ListItem yblb3 = new ListItem("3", "居民");
            ListItem yblb4 = new ListItem("4", "离休");
            zjlx.Add(yblb1);
            zjlx.Add(yblb2);
            zjlx.Add(yblb3);
            zjlx.Add(yblb4);
            cbx_bxlb.DisplayMember = "Text";
            cbx_bxlb.ValueMember = "Value";
            cbx_bxlb.DataSource = zjlx;
            cbx_bxlb.SelectedValue = "1";

            List<ListItem> qslb = new List<ListItem>();
            ListItem qslb1 = new ListItem("01", "医疗清算");
            ListItem qslb2 = new ListItem("02", "生育清算");
            ListItem qslb3 = new ListItem("03", "工伤清算");
            ListItem qslb4 = new ListItem("YD01", "异地医疗清算");
            qslb.Add(qslb1);
            qslb.Add(qslb2);
            qslb.Add(qslb3);
            qslb.Add(qslb4);
            cbx_qslb.DisplayMember = "Text";
            cbx_qslb.ValueMember = "Value";
            cbx_qslb.DataSource = qslb;
            cbx_qslb.SelectedValue = "01";

        }

        private void btn_qssq_Click(object sender, EventArgs e)
        {
            string[] param = new string[12];
            param[0] = tbx_qsqh.Text.ToString();
            param[1] = cbx_bxlb.SelectedValue.ToString();
            param[2] = cbx_qslb.SelectedValue.ToString();
            param[3] = "9900";
            param[4] = "0";
            param[5] = "0";
            param[6] = "0";
            param[7] = "0";
            param[8] = "0";
            param[9] = MTHIS.common.ProgramGlobal.Username;
            param[10] = DateTime.Now.ToString();
            param[11] = "1";
            ClearApply ihh = new ClearApply();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "71";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "清算申请错误信息");
                return;
            }
            Confirm_in confirmin = new Confirm_in();
            confirmin.Astrjylsh = callOut.Astrjylsh;
            confirmin.Astrjyyzm = callOut.Astrjyyzm;
            Confirm_out confirmout = gzsybInterface.Confirm(confirmin);
            if (confirmout.AintAppcode < 0)
            {
                MessageBox.Show(confirmout.AstrAppmsg, "清算申请确认错误信息");
                //message.Append(confirmout.AstrAppmsg);
                return;
            }
            MessageBox.Show("清算申请成功");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            string[] param = new string[7];
            Dictionary<string,string> d = new Dictionary<string,string>();
            d.Add("01","31");
            d.Add("02","M31");
            d.Add("03","G31");
            d.Add("YD01","YD31");
            param[0] = "";
            param[1] = cbx_bxlb.SelectedValue.ToString();
            param[2] = "2";
            param[3] = d[cbx_qslb.SelectedValue.ToString()];
            param[4] = "020023";
            param[5] = "QB";
            param[6] = tbx_qsqh.Text.ToString();
            if (cbx_bxlb.SelectedValue.ToString()!="4")
            {
                ClearApplySearchPrint ihh = new ClearApplySearchPrint();
                Call_in callIn = new Call_in();
                callIn.AstrJybh = "75";
                callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
                Call_out callOut = gzsybInterface.Call(callIn);
                if (callOut.Aintappcode < 0)
                {
                    MessageBox.Show(callOut.Astrappms, "清算打印错误信息");
                    return;
                }
            }
            else
            {
                Call_in callIn = new Call_in();
                callIn.AstrJybh = "Q99G";
                callIn.Astr_jysr_xml = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?><input><prm_yae366>" + tbx_qsqh.Text.ToString() + "</prm_yae366><prm_yab003>9908</prm_yab003><prm_outputfile>c:\\离休清算" + tbx_qsqh.Text.ToString() + ".txt </prm_outputfile><proxy>1</proxy></input>";
                Call_out callOut = gzsybInterface.Call(callIn);
                if (callOut.Aintappcode < 0)
                {
                    MessageBox.Show(callOut.Astrappms, "清算打印错误信息");
                    return;
                }
            }
        }

    }
}
