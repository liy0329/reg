using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.clinic;
using MTREG.medinsur.sjzsyb.dor;
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmclinicPoint : Form
    {
        public FrmclinicPoint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SJZYB_IN<clinicPoint_In> yb_in_dk = new SJZYB_IN<clinicPoint_In>();
            yb_in_dk.INPUT = new List<clinicPoint_In>();
            SjzybInterface sjzybInterface = new SjzybInterface();
            clinicPoint_In dom = new clinicPoint_In();
            dom.CKAA13 = this.comboYllb.SelectedValue.ToString();
            yb_in_dk.INPUT.Add(dom);
            SJZYB_OUT yb_out_dk = new SJZYB_OUT();
            yb_in_dk.MSGNO = "2130";
            yb_in_dk.AAC001 = "0";
            //dk_out.sfcf = "0";
            int ret = sjzybInterface.clinicPoint(yb_in_dk, ref yb_out_dk);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_dk.ERRORMSG, "提示信息");
                return;
            }
            MessageBox.Show("设定定点成功！", "提示信息");
        }

        private void Frmactivation_Load(object sender, EventArgs e)
        {
            initYllb();
        }
        private void initYllb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("1", "普通病门诊定点"));
            items.Add(new ListItem("2", "慢性病门诊定点"));
            this.comboYllb.DisplayMember = "Text";
            this.comboYllb.ValueMember = "Value";
            this.comboYllb.DataSource = items;
        }
    }
}
