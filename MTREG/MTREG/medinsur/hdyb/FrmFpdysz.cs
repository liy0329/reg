using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.dor;
using MTREG.medinsur.hdyb.clinic;
using MTHIS.tools;
using MTHIS.sys;
using MTHIS.common;
using System.Drawing.Printing;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmFpdysz : Form
    {
        public FrmFpdysz()
        {
            InitializeComponent();
        }
        List<string> dyjs = new List<string>();
        private void FrmFpdysz_Load(object sender, EventArgs e)
        {
            init_dyjm();
            init_fpxz();
        }
        public void init_fpxz()
        {
            List<ListItem> items = new List<ListItem>();

            //items.Add(new ListItem("zycxjsdnew", "城乡结算单新版"));
            items.Add(new ListItem("mzzf", "门诊自费发票"));
            items.Add(new ListItem("mzzfyjj", "门诊预交金发票"));
            items.Add(new ListItem("mzyb", "门诊医保发票"));
            //items.Add(new ListItem("mzcx", "门诊城乡发票"));
            //items.Add(new ListItem("mzcxjsd", "门诊结算单"));
            items.Add(new ListItem("ybdz", "医疗信息对账单"));
            items.Add(new ListItem("zyzf", "住院自费发票"));
            items.Add(new ListItem("zyyb", "住院医保发票"));
            //items.Add(new ListItem("zysyyb", "住院生育医保发票"));
            //items.Add(new ListItem("zycx", "住院城乡发票"));
            //items.Add(new ListItem("zycxjsd", "住院结算单"));


            cbx_fpxz.DisplayMember = "Text";
            cbx_fpxz.ValueMember = "Value";
            cbx_fpxz.DataSource = items;
            cbx_fpxz.SelectedValue = "mzzf";
        }
        public void init_dyjm()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                this.dyjs.Add(item.ToString());
            }
            tbx_dyjm.DataSource = dyjs;
        }

        private void cbx_fpxz_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string tmp = cbx_fpxz.Text.Trim();
                if (tmp == "" || tmp == "System.Data.DataRowView")
                {
                    return;
                }
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", cbx_fpxz.SelectedValue.ToString().Trim());//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                tbx_dyjm.Text = str[1];
                tbx_ymkd.Text = str[2];
                tbx_ymgd.Text = str[3];
                tbx_X.Text = str[4];
                tbx_Y.Text = str[5];
                if (str[6] == "1")
                {
                    this.cbx_isdyyl.Checked = true;
                }
                else
                {
                    this.cbx_isdyyl.Checked = false;
                }
                if (str[7] == "true")
                {
                    this.cbx_ishx.Checked = true;
                }
                else
                {
                    this.cbx_ishx.Checked = false;
                }
            }
            catch
            { }
        }

        private void btn_bc_Click(object sender, EventArgs e)
        {
            if (bcsj())
                MessageBox.Show("设置成功！"); 
        }
        private bool bcsj()
        {
            if (pd_num(tbx_ymkd.Text.Trim(), "页面宽度"))
                return false;
            if (pd_num(tbx_ymgd.Text.Trim(), "页面高度"))
                return false;
            if (pd_num(tbx_X.Text.Trim(), "左右移"))
                return false;
            if (pd_num(tbx_Y.Text.Trim(), "上下移"))
                return false;

            string con = "Dy_mc=" + cbx_fpxz.SelectedValue.ToString().Trim() + ";Dyjmc=" + tbx_dyjm.Text.Trim() + ";Page_width=" + tbx_ymkd.Text.Trim() + ";Page_height=" + tbx_ymgd.Text.Trim() + ";Start_x=" + tbx_X.Text.Trim() + ";Start_y=" + tbx_Y.Text.Trim() + ";Is_dyyl=" + ((this.cbx_isdyyl.Checked == true) ? ("1") : ("0")).ToString() + ";Page_fx=" + ((this.cbx_ishx.Checked == true) ? ("true") : ("false")).ToString() + ";";
            IniUtils.IniWriteValue(IniUtils.syspath, "FPDYSZ1", cbx_fpxz.SelectedValue.ToString().Trim(), con);
            if (!IniUtils.ExistINIFile())
            {
                MessageBox.Show("设置失败！");
                return false;
            }
            return true;
        }
        private bool pd_num(string in_txt, string in_lb)
        {
            if (string.IsNullOrEmpty(in_txt))
            {
                MessageBox.Show("【" + in_lb + "】不可为空！");
                return true;
            }
            try
            {
                double xx = double.Parse(in_txt);
                return false;
            }
            catch
            {
                MessageBox.Show("【" + in_lb + "】请填写数字！");
                return true;
            }
        }

        private void btn_cs_Click(object sender, EventArgs e)
        {
            FrmDy dyj = new FrmDy();
            dyj.flag_cs = true;
            dyj.dy(cbx_fpxz.SelectedValue.ToString().Trim());
        }

        private void label13_Click(object sender, EventArgs e)
        {
            FrmPrintSetting print = new FrmPrintSetting();
            print.Show();
        }

    }
}
