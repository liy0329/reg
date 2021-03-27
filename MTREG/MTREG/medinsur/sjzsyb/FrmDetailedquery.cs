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
    public partial class FrmDetailedquery : Form
    {
        public FrmDetailedquery()
        {
            InitializeComponent();
        }

        private void FrmDetailedquery_Load(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
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
            if (ret == -1)
            {
                MessageBox.Show(yb_out_dk.ERRORMSG, "提示信息");
                return;
            }
            query(yb_out_dk.AAC001);
        }
        public void query( string grbh)
         {
            SJZYB_IN<Detailedquery_In> yb_in_dk = new SJZYB_IN<Detailedquery_In>();
            SjzybInterface sjzybInterface = new SjzybInterface();
            yb_in_dk.INPUT = new List<Detailedquery_In>();
            Detailedquery_In dom = new Detailedquery_In();
            dom.AAC001 = grbh;
            List<Detailedquery_Out> yb_out_dk = new List<Detailedquery_Out>();
            yb_in_dk.INPUT.Add(dom);
            yb_in_dk.MSGNO = "1730";
            yb_in_dk.AAC001 = "0";
            //dk_out.sfcf = "0";
            int ret = sjzybInterface.Detailedquery(yb_in_dk, ref yb_out_dk);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_dk[0].ERRORMSG, "提示信息");
                return;
            }
            DataTable dt = yb_out_dk.ToDataTable<Detailedquery_Out>();
            dataGridView(dt);
        }
        public void dataGridView( DataTable dt)
        {
            this.dataGridView1.DataSource = dt;

            dataGridView1.Columns["AKB020"].HeaderText = "定点医疗机构编码";
            dataGridView1.Columns["AKB020"].Width = 100;
            dataGridView1.Columns["AKB020"].DisplayIndex = 0;

            dataGridView1.Columns["AKC192"].HeaderText = "就诊日期";
            dataGridView1.Columns["AKC192"].DisplayIndex = 1;
            dataGridView1.Columns["AKC192"].Width = 200;

            dataGridView1.Columns["AKC222"].HeaderText = "中心收费项目编码";
            dataGridView1.Columns["AKC222"].Width = 150;
            dataGridView1.Columns["AKC222"].DisplayIndex = 2;

            dataGridView1.Columns["AKC223"].HeaderText = "中心收费项目名称";
            dataGridView1.Columns["AKC223"].DisplayIndex = 3;
            dataGridView1.Columns["AKC223"].Width = 200;

            dataGridView1.Columns["AKA070"].HeaderText = "剂型";
            dataGridView1.Columns["AKA070"].Width = 150;
            dataGridView1.Columns["AKA070"].DisplayIndex = 4;

            dataGridView1.Columns["AKA077"].HeaderText = "规格";
            dataGridView1.Columns["AKA077"].Width = 100;
            dataGridView1.Columns["AKA077"].DisplayIndex = 5;

            dataGridView1.Columns["BKA076"].HeaderText = "销售单位";
            dataGridView1.Columns["BKA076"].Width = 100;
            dataGridView1.Columns["BKA076"].DisplayIndex = 6;

            dataGridView1.Columns["AKC226"].HeaderText = "数量";
            dataGridView1.Columns["AKC226"].Width = 100;
            dataGridView1.Columns["AKC226"].DisplayIndex = 7;
            dataGridView1.Columns["RETURNNUM"].Visible = false;
            dataGridView1.Columns["ERRORMSG"].Visible = false;
            dataGridView1.Columns["REFMSGID"].Visible = false;

            
        }
    }
}
