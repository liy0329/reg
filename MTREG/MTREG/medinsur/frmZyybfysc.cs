using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.tools;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.ihsp;
using MTHIS.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.clinic.bo;
using MTREG.medinsur.hdyb.dor;
using MTHIS.db;
using MTHIS.main.bll;
using MTHIS.tools;

namespace MTREG.medinsur
{
    public partial class frmZyybfysc : Form
    {
        JKDB jkdb = new JKDB();
        public frmZyybfysc()
        {
            InitializeComponent();
        }

        private void frmZyybfysc_Load(object sender, EventArgs e)
        {
            this.SelectZyjlByQyid();
        }
        private void SelectZyjlByQyid()
        {
            string sql2 = "select inhospital.id as iid, inhospital.ihspcode as zyh"
                      + ",inhospital.name as xm"
                      + ",bas_depart.name as ks"
                      + ",bas_doctor.name as ys"
                      + ",inhospital.indate as ryrq"
                      + " from inhospital "
                      + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                      + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                      + " where 1=1 and inhospital.nhflag = 301 and inhospital.insurstat != 'SETT' order by inhospital.id ";
            DataTable dt = BllMain.Db.Select(sql2).Tables[0];
            this.dataGridView1.DataSource = dt.DefaultView;
        }

        private void buttonTc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ypqb_Click(object sender, EventArgs e)
        {
            string sql_ypqbgx = "update ihsp_costdet set ypspbz=1 where ybsc=0 and yptsxx!='' and ypspbz not in (1,2) and ihsp_id in(select iid from mtzyjl where nhflag=301)";
            if (BllMain.Db.Update(sql_ypqbgx) == -1)
            {
                MessageBox.Show("审批失败！");
            }
            else
            {
                MessageBox.Show("审批成功！");
            }
        }

        private void btn_ypqbb_Click(object sender, EventArgs e)
        {
            string sql_ypqbgx = "update ihsp_costdet set ypspbz=2 where ybsc=0 and yptsxx!='' and ypspbz not in (1,2) and ihsp_id in(select iid from mtzyjl where nhflag=301)";
            if (BllMain.Db.Update(sql_ypqbgx) == -1)
            {
                MessageBox.Show("审批失败！");
            }
            else
            {
                MessageBox.Show("审批成功！");
            }
        }

        private void buttonKssc_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            //费用上传
            this.drsj();
        }
        //费用上传
        private void drsj()
        {
            //医保
            string sql = "select id, ihspcode from inhospital where bas_patienttype_id in ('35','34') and inhospital.insurstat != 'SETT' order by id";
            DataSet ds = BllMain.Db.Select(sql);
            Zyybfysc_button zyybfysc = new Zyybfysc_button();
            string mesg = "";
            int rs = ds.Tables[0].Rows.Count;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lblFeeUpLoad.Text = "正在医保上传费用：" + (i + 1).ToString() + "/" + rs.ToString() + "人数";
                lblFeeUpLoad.Update();
                string zyh = ds.Tables[0].Rows[i]["ihspcode"].ToString().Trim();
                int iid = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                string sql2 = "select AAC001 from KC21 where AKC190='" + zyh + "'";
                DataSet ds2 = jkdb.Select(sql2);
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    continue;
                }
                string grbh = ds2.Tables[0].Rows[0]["AAC001"].ToString().Trim();
                RetMsg ret = zyybfysc.ybscfymx(iid, "", zyh, label1);
                mesg += ret.Mesg + "\r\n";
                string msg = "";
                //zyybfysc.xfdhje(iid, zyh, out msg);
                mesg += msg + "\r\n";
            }
            //mesg += "\r\n";
            ////生育
            //string sqlsy = "select id, ihspcode from inhospital where nhflag=1501 inhospital.insurstat != 'SETT' order by id";
            //DataSet dssy = BllMain.Db.Select(sqlsy);
            //ZySyybfysc zysyybfysc = new ZySyybfysc();
            //rs = dssy.Tables[0].Rows.Count;
            //for (int j = 0; j < dssy.Tables[0].Rows.Count; j++)
            //{
            //    lblFeeUpLoad.Text = "正在职工生育上传费用：" + (j + 1).ToString() + "/" + rs.ToString() + "人数";
            //    lblFeeUpLoad.Update();
            //    string zyh = dssy.Tables[0].Rows[j]["ihspcode"].ToString().Trim();
            //    int iid = Convert.ToInt32(dssy.Tables[0].Rows[j]["id"].ToString().Trim());
            //    string sql2 = "select AAC001 from KC21 where AKC190='" + zyh + "'";
            //    DataSet ds2 = jkdb.Select(sql2);
            //    if (ds2.Tables[0].Rows.Count == 0)
            //    {
            //        continue;
            //    }
            //    string grbh = ds2.Tables[0].Rows[0]["AAC001"].ToString().Trim();
            //    RetMsg ret = zysyybfysc.ybscfymx(iid, grbh, zyh, label1);
            //    if (ret.Retint == false)
            //    {
            //        mesg += ret.Mesg + "\r\n";
            //    }
            //}
            this.Tbx_tsxx.Text = mesg;
            if (!string.IsNullOrEmpty(mesg))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = mesg;
                frmmesg.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("费用上传完成！");
            }
        }
    }
}
