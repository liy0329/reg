using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.hsdryb.bll;
using MTHIS.common;

namespace MTREG.medinsur.hsdryb
{
    public partial class FrmDownloadInsurItem : Form
    {
        public FrmDownloadInsurItem()
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
        BllItemCrossHSDR bllItemCrossHSDR = new BllItemCrossHSDR();
        private void FrmDownloadInsurItem_Load(object sender, EventArgs e)
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
            string standcode = "";

            TopParameter common = new TopParameter();
            common.AKC190 = cmbItemfrom.SelectedValue.ToString();
            common.AKA130 = "21";//普通住院
            common.MSGNO = "1708";
            common.MSGID = WYJK.getLsh();
            common.OPERID = ProgramGlobal.User_id;
            common.OPERNAME = ProgramGlobal.Username;
            common.BATNO = ProgramGlobal.Othvar_1;
            common.INPUT = string.Format("<AKC224>{0}</AKC224><AKC515>{1}</AKC515><AKC021>{2}</AKC021>",cmbItemfrom.SelectedValue.ToString(),standcode, "63");//普通居民
            WYJK wyjk = new WYJK();
            DataTable dt = new DataTable();
            var opt = wyjk.smdzjbxxqkcx(common,out dt);
            if (opt.ReturnNum != "-1")
            {
                bllItemCrossHSDR.insertInsurItem(Insurtype_id,standcode, dt);
            }
        }
    }
}
