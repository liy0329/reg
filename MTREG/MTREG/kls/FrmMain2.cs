using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.listitem;
using MTREG.medinsur.gzsyb.Entity;
using MTREG.medinsur.gzsyb.gysyb.Entity;
using MTREG.medinsur.gzsyb.Util;
using MTREG.medinsur.gzsyb;
using MTHIS.main.bll;
namespace MTREG.medinsur.gzsyb
{
    public partial class FrmMain2 : Form
    {
        public FrmMain2()
        {
            InitializeComponent();
            btnWsryinfo.Enabled = false;
            btnWscyinfo.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            //Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {           

        }


 
        private void button1_Click_2(object sender, EventArgs e)
        {
            DataTable ds = SelectSickRy();
            int cnt = ds.Rows.Count;
            dgvdjrs.AutoGenerateColumns = false;
            dgvdjrs.DataSource = ds.DefaultView;
            btnWscyinfo.Enabled = false;
            btnWsryinfo.Enabled = true;
            btnSybsczd.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataTable ds = SelectSickCy();
            dgvdjrs.AutoGenerateColumns = false;
            dgvdjrs.DataSource = ds;
            btnWscyinfo.Enabled = true;
            btnWsryinfo.Enabled = false;
            btnSybsczd.Enabled = false;
        }

        private void btnWsryinfo_Click(object sender, EventArgs e)
        {
            int rowIdx = dgvdjrs.CurrentRow.Index;
            string ylfkfs = dgvdjrs.Rows[rowIdx].Cells["dgvtxtylfkfs"].Value.ToString();
            if (ylfkfs != "市医保")
            {
                MessageBox.Show("选中的不是市医保病人");
            }
            Frm_wsryinfo main = new Frm_wsryinfo();
            main.Mtzyjliid = dgvdjrs.Rows[rowIdx].Cells["mtzyjl_iid"].Value.ToString(); //住院记录表iid
            main.StartPosition = FormStartPosition.CenterScreen;
            main.ShowDialog(this);
            DataTable ds = SelectSickRy();
            dgvdjrs.AutoGenerateColumns = false;
            dgvdjrs.DataSource = ds.DefaultView;
            btnWscyinfo.Enabled = false;
            btnWsryinfo.Enabled = true;
        }

        private void btnWscyinfo_Click(object sender, EventArgs e)
        {
            int rowIdx = dgvdjrs.CurrentRow.Index;
            string ylfkfs = dgvdjrs.Rows[rowIdx].Cells["dgvtxtylfkfs"].Value.ToString();
            if (ylfkfs != "市医保")
            {
                MessageBox.Show("选中的不是市医保病人");
            }
            Frm_wscyinfo main = new Frm_wscyinfo();
            main.Mtzyjliid = dgvdjrs.Rows[rowIdx].Cells["mtzyjl_iid"].Value.ToString();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.ShowDialog(this);
            DataTable ds = SelectSickCy();
            dgvdjrs.AutoGenerateColumns = false;
            dgvdjrs.DataSource = ds;
            btnWscyinfo.Enabled = true;
            btnWsryinfo.Enabled = false;
            

        }

        private void btnSyb_Click(object sender, EventArgs e)
        {

            DataTable ds = SelectSickSybCy();
            int cnt = ds.Rows.Count;
            dgvdjrs.AutoGenerateColumns = false;
            dgvdjrs.DataSource = ds.DefaultView;
            btnWscyinfo.Enabled = false;
            btnWsryinfo.Enabled = false;
            btnSybsczd.Enabled = true;
        }

        private void btnSybsczd_Click(object sender, EventArgs e)
        {
            int rowIdx = dgvdjrs.CurrentRow.Index;
            Frm_sybwscyinfo main = new Frm_sybwscyinfo();
            main.Mtzyjliid = dgvdjrs.Rows[rowIdx].Cells["mtzyjl_iid"].Value.ToString();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.ShowDialog(this);
            DataTable ds = SelectSickSybCy();
            dgvdjrs.AutoGenerateColumns = false;
            dgvdjrs.DataSource = ds;
            btnWscyinfo.Enabled = false;
            btnWsryinfo.Enabled = false;
            btnSybsczd.Enabled = true;
        }
        public DataTable SelectSickRy()
        {

            string sql = "select "
                      + "inhospital.member_id as ctctiid,"
                      + "inhospital.name as fullname,"
                      + "(case when inhospital.sex='M' then '男' when inhospital.sex='W' then '女' end)  as gender,"
                      + "bas_depart.name as orgname,"
                      + "bas_sickroom.name as bs,"
                      + "bas_sickbed.name as bc,"
                      + "inhospital.ihspcode as zyh,"
                      + "inhospital.casecode as bah,"
                      + "inhospital.indate as rysj,"
                      + " inhospital.bas_patienttype_id as ylfkfs, "
                      + " bas_patienttype.name as ylfkfsname, "
                      + " inhospital.id as mtzyjl_iid, "
                      + " bas_doctor.name as ownerName "
                      + " from inhospital, bas_sickroom,bas_sickroom,bas_sickbed,bas_patienttype,bas_doctor,bas_depart"
                      + " where inhospital.indate>'2015-10-01 00:00:00' and inhospital.bas_patienttype_id=15 and inhospital.sickroom_id=bas_sickroom.id "
                      + " and inhospital.sickbed_id=bas_sickbed.id and inhospital.bas_patienttype_id=bas_patienttype.id and inhospital.registby=bas_doctor.id "
                      + " and  inhospital.insurstat='SETT' and inhospital.depart_id=bas_depart.id"
                      +"  "//未上传入院诊断
                      + "  order by inhospital.iid";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            int cnt = dt.Rows.Count;

            return dt;
        }
        public DataTable SelectSickSybCy()
        {


            string sql = "select "
                      + "inhospital.member_id as ctctiid,"
                      + "inhospital.name as fullname,"
                      + "(case when inhospital.sex='M' then '男' when inhospital.sex='W' then '女' end)  as gender,"
                      + "bas_depart.name as orgname,"
                      + "bas_sickroom.name as bs,"
                      + "bas_sickbed.name as bc,"
                      + "inhospital.ihspcode as zyh,"
                      + "inhospital.casecode as bah,"
                      + "inhospital.indate as rysj,"
                      + " inhospital.bas_patienttype_id as ylfkfs, "
                      + " bas_patienttype.name as ylfkfsname, "
                      + " inhospital.id as mtzyjl_iid, "
                      + " bas_doctor.name as ownerName "
                      + " from inhospital, bas_sickroom,bas_sickroom,bas_sickbed,bas_patienttype,bas_doctor,bas_depart"
                      + " where inhospital.indate>'2015-10-01 00:00:00' and inhospital.bas_patienttype_id=16 and inhospital.sickroom_id=bas_sickroom.id "
                      + " and inhospital.sickbed_id=bas_sickbed.id and inhospital.bas_patienttype_id=bas_patienttype.id and inhospital.registby=bas_doctor.id "
                      + " and  inhospital.insurstat='SETT' and inhospital.depart_id=bas_depart.id"
                      + "  "//未上传入院诊断
                      + "  order by inhospital.iid";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
           
            int cnt = dt.Rows.Count;

            return dt;
        }

        public DataTable SelectSickCy()
        {

            string sql = "select "
                        + "inhospital.member_id as ctctiid,"
                        + "inhospital.name as fullname,"
                        + "(case when inhospital.sex='M' then '男' when inhospital.sex='W' then '女' end)  as gender,"
                        + "bas_depart.name as orgname,"
                        + "bas_sickroom.name as bs,"
                        + "bas_sickbed.name as bc,"
                        + "inhospital.ihspcode as zyh,"
                        + "inhospital.casecode as bah,"
                        + "inhospital.indate as rysj,"
                        + " inhospital.bas_patienttype_id as ylfkfs, "
                        + " bas_patienttype.name as ylfkfsname, "
                        + " inhospital.id as mtzyjl_iid, "
                        + " bas_doctor.name as ownerName "
                        + " from inhospital, bas_sickroom,bas_sickroom,bas_sickbed,bas_patienttype,bas_doctor,bas_depart"
                        + " where inhospital.indate>'2015-10-01 00:00:00' and inhospital.bas_patienttype_id=15 and inhospital.sickroom_id=bas_sickroom.id "
                        + " and inhospital.sickbed_id=bas_sickbed.id and inhospital.bas_patienttype_id=bas_patienttype.id and inhospital.registby=bas_doctor.id "
                        + " and  inhospital.insurstat='SETT' and inhospital.depart_id=bas_depart.id"
                        + "  "//未上传出院院诊断
                        + "  order by inhospital.iid";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
    }
}
