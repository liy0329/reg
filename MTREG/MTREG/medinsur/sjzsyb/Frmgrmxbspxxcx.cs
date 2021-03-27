using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.common;
using System.IO;
using MTHIS.main.bll;
using MTREG.common;
using System.Web.UI.WebControls;
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.medinsur.sjzsyb
{
    public partial class Frmgrmxbspxxcx : Form
    {
        Sjzsyb syb = new Sjzsyb();
        public Frmgrmxbspxxcx()
        {
            InitializeComponent();
        }

        public void inyb_type()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("12", "门诊慢性病"));
            items.Add(new ListItem("15", "门诊特殊病"));
            this.yb_type.DisplayMember = "Value";
            this.yb_type.ValueMember = "Test";
            this.yb_type.SelectedValue = "12";
            this.yb_type.DataSource = items;
        }

        private void Frmgrmxbspxxcx_Load(object sender, EventArgs e)
        {
            inyb_type();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AKA130_in = yb_type.SelectedValue.ToString().Trim();

            SJZYB_IN<DK_IN> yb_in_dk = new SJZYB_IN<DK_IN>();
            SjzybInterface sjzybInterface = new SjzybInterface();
            yb_in_dk.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_dk = new DK_OUT();
            dk.BKA130 = "30";//出院预结算
            yb_in_dk.INPUT.Add(dk);
            yb_in_dk.MSGNO = "1401";
            yb_in_dk.AAC001 = "0";
            //dk_out.sfcf = "0";
            int ret = sjzybInterface.DK(yb_in_dk, ref yb_out_dk);
            string ReturnMsg = "";
            //int opstat = Convert.ToInt32(yb_out_grmx[0].RETURNNUM);
            if (ret == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = yb_out_dk.ERRORMSG;
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }

            SJZYB_IN<grmxbspxxcx_In> yb_in_grmx = new SJZYB_IN<grmxbspxxcx_In>();
            yb_in_grmx.INPUT = new List<grmxbspxxcx_In>();
            grmxbspxxcx_In doc = new grmxbspxxcx_In();
            List<grmxbspxxcx_Out> yb_out_grmx = new List<grmxbspxxcx_Out>();
            doc.AAC001 = yb_out_dk.AAC001;
            doc.AKA130 = AKA130_in;
            yb_in_grmx.MSGNO = "1910";
            yb_in_grmx.INPUT.Add(doc);

            int opstat = sjzybInterface.grmxbspxxcx(yb_in_grmx, ref yb_out_grmx);

            //int opstat = Convert.ToInt32(yb_out_grmx[0].RETURNNUM);
            if (opstat == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = yb_out_grmx[0].ERRORMSG;
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }
            dataGridView1.DataSource = yb_out_grmx.ToDataTable<grmxbspxxcx_Out>();

        }

        

        
    }
}
