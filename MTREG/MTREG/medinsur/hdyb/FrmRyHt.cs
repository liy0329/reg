using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.dor;
using MTREG.common.bll;
using MTHIS.main.bll;
using System.Data.Odbc;
using MTHIS.main.bll;
using MTREG.medinsur.sjzsyb.bean;
using System.Collections.Generic;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.main.bll;
using MTREG.ihsp.bll;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmRyHt : Form
    {
        int flag;
        public FrmRyHt()
        {
            InitializeComponent();
        }
        YBCJ yw1 = new YBCJ();
        private string iQfybch;
        /// <summary>
        /// 医疗付款方式id
        /// </summary>
        public string IQfybch
        {
            get { return iQfybch; }
            set { iQfybch = value; }
        }
        private string ylfkfs_id;
        /// <summary>
        /// 医疗付款方式id
        /// </summary>
        public string Ylfkfs_id
        {
            get { return ylfkfs_id; }
            set { ylfkfs_id = value; }

        }
        private int sfck;
        /// <summary>
        /// 医疗付款方式id
        /// </summary>
        public int Sfck
        {
            get { return sfck; }
            set { sfck = value; }
        }
        private string zyjlh;//
        /// <summary>
        /// 住院记录号
        /// </summary>
        public string Zyjlh
        {
            get { return zyjlh; }
            set { zyjlh = value; }
        }
        private string zyh;//
        /// <summary>
        /// 住院记录号
        /// </summary>
        public string Zyh
        {
            get { return zyh; }
            set { zyh = value; }
        }
        private string xm;//
        /// <summary>
        /// 住院记录号
        /// </summary>
        public string Xm
        {
            get { return xm; }
            set { xm = value; }
        }
        private string grbh;//
        /// <summary>
        /// 住院记录号
        /// </summary>
        public string Grbh
        {
            get { return grbh; }
            set { grbh = value; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmRyHt_Load(object sender, EventArgs e)
        {
            textBox1.Text = xm;
            textBox2.Text = grbh;
            textBox4.Text = zyh;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SJZYB_IN<DK_IN> yb_in_dk = new SJZYB_IN<DK_IN>();
            SjzybInterface sjzybInterface = new SjzybInterface();
            yb_in_dk.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_dk = new DK_OUT();
            dk.BKA130 = "27";//出院预结算
            yb_in_dk.INPUT.Add(dk);
            yb_in_dk.MSGNO = "1401";
            yb_in_dk.AAC001 = "0";
            //dk_out.sfcf = "0";
            int ret = sjzybInterface.DK(yb_in_dk, ref yb_out_dk);
            if (ret == -1)
            {
                //Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
                MessageBox.Show(yb_out_dk.ERRORMSG, "提示信息");
                return;
            }
            if (yb_out_dk.ZKC031.ToString() == "0")
            {
                MessageBox.Show("该患者为不在院状态！", "提示信息");
                return;
            }
            BillIhspMan billIhspMan = new BillIhspMan();

            string sql_ihsp = "SELECT MSGID,ihspcode,insurcode ,healthcard from inhospital where id = " + DataTool.addFieldBraces(zyjlh);
            DataTable dt_ihsp = BllMain.Db.Select(sql_ihsp).Tables[0];
            string ihspcode = dt_ihsp.Rows[0]["ihspcode"].ToString().Trim();
            string oldmsgid = dt_ihsp.Rows[0]["MSGID"].ToString().Trim();
            string insurcode = dt_ihsp.Rows[0]["insurcode"].ToString().Trim();
            string healthcard = dt_ihsp.Rows[0]["healthcard"].ToString().Trim();

            SJZYB_IN<ReHospital_In> yb_in_ht = new SJZYB_IN<ReHospital_In>();
            yb_in_ht.INPUT = new List<ReHospital_In>();
            ReHospital_In dom = new ReHospital_In();
            SJZYB_OUT yb_out_ht = new SJZYB_OUT();
            dom.AKC190 = ihspcode;
            dom.AKC281 = oldmsgid;
            yb_in_ht.INPUT.Add(dom);
            yb_in_ht.AKC190 = ihspcode;
            yb_in_ht.AAC001 = "0";
            yb_in_ht.AKA130 = "21";
            yb_in_ht.MSGNO = "1201";
            yb_in_ht.AKC020 = healthcard;
            
            sjzybInterface.zyht(yb_in_ht, ref yb_out_ht);


            string ReturnMsg = "";
            int returnnum = Convert.ToInt32(yb_out_ht.RETURNNUM);
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = yb_out_ht.ERRORMSG;
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }

            string sql = "update inhospital set insurstat='OO', bas_patienttype_id= '1', bas_patienttype1_id= '1',Insuritemtype='1'  where id=" + DataTool.addFieldBraces(zyjlh) + ";";
            sql += "delete from Sybzyjl where AKC190 =" + DataTool.addFieldBraces(ihspcode) + ";";
            flag = BllMain.Db.Update(sql);
            if (flag < 0)
            {
                MessageBox.Show("入院取消成功,医保状态修改失败!", "提示信息");
                return;
            }

            MessageBox.Show("医保入院回退成功!", "提示信息");
            this.Close();

        }
    }
}
