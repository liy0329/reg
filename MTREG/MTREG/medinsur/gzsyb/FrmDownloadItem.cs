using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.gzsyb.bo;
using System.IO;
using MTREG.common.bll;
using MTREG.common;

namespace MTREG.medinsur.gzsyb
{
    public partial class FrmDownloadItem : Form
    {
        BllItemcrossGZS bllItemcrossGZS = new BllItemcrossGZS();
        public FrmDownloadItem()
        {
            InitializeComponent();
        }
        private string insurtype_id;
        /// <summary>
        /// 患者类型
        /// </summary>
        public string Insurtype_id
        {
            get { return insurtype_id; }
            set { insurtype_id = value; }
        }
        BllItemcrossGZS bllItemCrossGZS = new BllItemcrossGZS();
        private void FrmDownloadItem_Load(object sender, EventArgs e)
        {
            //收费类别
            DataTable dtItemfrom = new DataTable();
            dtItemfrom.Columns.Add("name");
            dtItemfrom.Columns.Add("value");
            DataRow dr11 = dtItemfrom.NewRow();
            dr11[0] = "药品";
            dr11[1] = "DRUG";
            dtItemfrom.Rows.Add(dr11);
            DataRow dr12 = dtItemfrom.NewRow();
            dr12[0] = "材料";
            dr12[1] = "STUFF";
            dtItemfrom.Rows.Add(dr12);
            DataRow dr13 = dtItemfrom.NewRow();
            dr13[0] = "诊疗费用";
            dr13[1] = "COST";
            dtItemfrom.Rows.Add(dr13);
            this.cmbItemfrom.DisplayMember = "name";
            this.cmbItemfrom.ValueMember = "value";
            this.cmbItemfrom.DataSource = dtItemfrom;
            this.cmbItemfrom.SelectedValue = "DRUG";
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            GzsybInterface gzsyb = new GzsybInterface();
            GetServiceItem ihh = new GetServiceItem();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "91";
            String[] param = new string[2];
            param[0] = "2016-09-18";
            param[1] = "d:\\szydybfwml.txt";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
            Call_out callOut = gzsyb.Call(callIn);
            if(callOut.Aintappcode<0)
            {
                MessageBox.Show(callOut.Astrappms,"下载服务目录错误信息");
                return ;
            }
            SysWriteLogs.writeLogs1("贵州省医保获取收费类别", Convert.ToDateTime(BillSysBase.currDate()), callOut.Astrjyscxml);
            string xml = callOut.Astrjyscxml;
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            DataTable dt = ds.Tables["output"];
            bllItemcrossGZS.insertInsurItem(insurtype_id,dt);
        }
    }
}
