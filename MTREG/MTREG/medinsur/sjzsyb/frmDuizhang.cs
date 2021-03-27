using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using MTREG.Util;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.common;
using MTHIS.main.bll;
using System.Web.UI.WebControls;
using MTREG.medinsur.hdyb;

namespace MTREG.medinsur.sjzsyb
{
    public partial class frmDuizhang : Form
    {
        public frmDuizhang()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private double zfy = 0.0;

        public double Zfy
        {
            get { return zfy; }
            set { zfy = value; }
        }
        private double zhzf1 = 0.0;

        public double Zhzf1
        {
            get { return zhzf1; }
            set { zhzf1 = value; }
        }
        private double xjzf1 = 0.0;

        public double Xjzf1
        {
            get { return xjzf1; }
            set { xjzf1 = value; }
        }
        private double jjzf1 = 0.0;

        public double Jjzf1
        {
            get { return jjzf1; }
            set { jjzf1 = value; }
        }
        private void frmDuizhang_Load(object sender, EventArgs e)
        {
            inittype();
            yyzfy();
            this.groupBox4.Visible = false;
        }
        

        


        private double gwybzje1 = 0.0;

        public double Gwybzje1
        {
            get { return gwybzje1; }
            set { gwybzje1 = value; }
        }
        
        public void yyzfy()
        {
            this.groupBox4.Visible = false;
            DateTime starttime = (Convert.ToDateTime(this.dateTimePicker1.Text));
            DateTime endtime = (Convert.ToDateTime(this.dateTimePicker2.Text));
            string type = comboType.SelectedValue.ToString();
            BllItemcrossSJZ BllItemcrossSJZ = new BllItemcrossSJZ();
            DataTable dt = BllItemcrossSJZ.getjsxx(starttime.ToString("yyyy-MM-dd 00:00:00"), endtime.ToString("yyyy-MM-dd 23:59:59"), type);
            if (type == "1")
            {
                double difference = double.Parse(dt.Rows[0]["clin"].ToString());
                if (difference > 1)
                {
                    MessageBox.Show("his费用与医保费用相差1元以上！无法进行对账");
                    return;
                }
            }
            else{
                double difference = double.Parse(dt.Rows[0]["ihsp"].ToString());
                if (difference > 1)
                {
                    MessageBox.Show("his费用与医保费用相差1元以上！无法进行对账");
                    return;
                }
            }
            this.textBox1.Text = comboType.Text.ToString();
            this.textBox2.Text = dt.Rows[0]["BKB001"].ToString();
            this.textBox3.Text = dt.Rows[0]["BKB002"].ToString();
            this.tbx_yyzfy.Text = dt.Rows[0]["AKC264"].ToString();
            this.tbx_yyzhzf.Text = dt.Rows[0]["AKC255"].ToString();
            this.tbx_yyxjzf.Text = dt.Rows[0]["AKC261"].ToString();
            this.tbx_yyjjzf.Text = dt.Rows[0]["AKC260"].ToString();
            this.tbx_yyjzj.Text = dt.Rows[0]["AKC706"].ToString();
            this.tbx_yygwy.Text = dt.Rows[0]["AKC707"].ToString();
            this.tbx_qtzfhj.Text = dt.Rows[0]["AKC708"].ToString();

        }
        public void inittype()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("门诊", "1"));
            items.Add(new ListItem("住院", "2"));
            this.comboType.DisplayMember = "Text";
            this.comboType.ValueMember = "Value";
            this.comboType.DataSource = items;
            comboType.SelectedValue = "1";
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            yyzfy();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            yyzfy();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            yyzfy();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime starttime = (Convert.ToDateTime(this.dateTimePicker1.Text));
            DateTime endtime = (Convert.ToDateTime(this.dateTimePicker2.Text));
            string type = comboType.SelectedValue.ToString();
            BllItemcrossSJZ BllItemcrossSJZ = new BllItemcrossSJZ();
            DataTable dt = BllItemcrossSJZ.getjsxx(starttime.ToString("yyyy-MM-dd 00:00:00"), endtime.ToString("yyyy-MM-dd 23:59:59"), type);
            
            SJZYB_IN<Reconciliation_In> yb_in_dz = new SJZYB_IN<Reconciliation_In>();
            Reconciliation_Out yb_out_dz = new Reconciliation_Out();
            yb_in_dz.INPUT = new List<Reconciliation_In>();
            Reconciliation_In dom = new Reconciliation_In();
            dom = objk<Reconciliation_In>.FillModel(dt)[0];
            dom.AAE030 = starttime.ToString("yyyy-MM-dd");
            dom.AAE031 = endtime.ToString("yyyy-MM-dd");
            dom.CKA130 = type;
            yb_in_dz.MSGNO = "1120";
            yb_in_dz.INPUT.Add(dom);
            SjzybInterface sjzybInterface = new SjzybInterface();

            int ret = sjzybInterface.ylxxdz(yb_in_dz, ref yb_out_dz);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_dz.ERRORMSG, "提示信息");
                return;
            }
            this.groupBox4.Visible = true;
            this.tbx_dzjg.Text = yb_out_dz.AKE150 == "0"?"不平":"账平";
            this.stime.Text = yb_out_dz.AAE030;
            this.etime.Text = yb_out_dz.AAE031;
            this.tbx_ywlb.Text = yb_out_dz.CKA130 == "1"?"门诊":"住院";
            this.tbx_zjys.Text = yb_out_dz.BKB001;
            this.tbx_fjys.Text = yb_out_dz.BKB002;
            this.tbx_ybzfy.Text = yb_out_dz.AKC264;
            this.tbx_ybxjzf.Text = yb_out_dz.AKC261;
            this.tbx_ybjjzf.Text = yb_out_dz.AKC260;
            this.tbx_ybzhzf.Text = yb_out_dz.AKC255;
            this.tbx_ybjzj.Text = yb_out_dz.AKC706;
            this.tbx_ybgwy.Text = yb_out_dz.AKC707;
            this.tbx_ybqtzfhj.Text = yb_out_dz.AKC708;
            //统筹基金合计
            this.tbx_tcjjhj.Text = (Double.Parse(yb_out_dz.AKC260) + Double.Parse(yb_out_dz.AKC706) + Double.Parse(yb_out_dz.AKC707) + Double.Parse(yb_out_dz.AKC708)).ToString();
            //医保支付合计
            this.tbx_ybjhj.Text = (Double.Parse(tbx_ybzhzf.Text) + Double.Parse(tbx_tcjjhj.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dyxx();
        }
        public void dyxx()
        {
            string in_zfc1 = "|";
            in_zfc1 += stime.Text + "|";
            in_zfc1 += etime.Text + "|";

            in_zfc1 += tbx_dzjg.Text + "|";
            in_zfc1 += tbx_ywlb.Text + "|";
            in_zfc1 += tbx_zjys.Text + "|";
            in_zfc1 += tbx_fjys.Text + "|";

            in_zfc1 += tbx_ybzfy.Text + "|";

            in_zfc1 += tbx_ybxjzf.Text + "|";
            in_zfc1 += tbx_ybjhj.Text + "|";

            in_zfc1 += tbx_ybzhzf.Text + "|";
            in_zfc1 += tbx_tcjjhj.Text + "|";

            in_zfc1 += tbx_ybjzj.Text + "|";
            in_zfc1 += tbx_ybjjzf.Text + "|";

            in_zfc1 += tbx_ybgwy.Text + "|";
            in_zfc1 += tbx_ybqtzfhj.Text + "|";

            in_zfc1 += DateTime.Now.ToString("yyyy-MM-dd") + "|";
            in_zfc1 += ProgramGlobal.Nickname + "|";
            FrmDy cxjsddy = new FrmDy();
            cxjsddy.in_zfc = in_zfc1;
            cxjsddy.dy("ybdz");
        }

        

       

        

    }
}
