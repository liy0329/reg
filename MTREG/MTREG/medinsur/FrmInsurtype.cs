using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdyb.bll;
using MTREG.common;
using MTHIS.common;
using MTHIS.main.bll;

using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdxbhnh;
using MTREG.medinsur.hsdryb;
using MTREG.medinsur.hdsbhnh;
using MTREG.medinsur.ahsjk;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.ynsyb;


namespace MTREG.medinsur
{
    public partial class FrmInsurtype : Form
    {
        public FrmInsurtype()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInsurtype_Load(object sender, EventArgs e)
        {
            BllInsurCross bllInsurCross=new BllInsurCross();
            DataTable dt = bllInsurCross.insurtypeSelect();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int index = this.dgvInsurtype.Rows.Add();
                dgvInsurtype.Rows[index].Cells["name"].Value = dt.Rows[i]["name"].ToString();
                dgvInsurtype.Rows[index].Cells["iffactory"].Value = dt.Rows[i]["iffactory"].ToString();
                dgvInsurtype.Rows[index].Cells["iftechiq"].Value = dt.Rows[i]["iftechiq"].ToString();
                dgvInsurtype.Rows[index].Cells["keyname"].Value = dt.Rows[i]["keyname"].ToString();
                if (dt.Rows[i]["updateat"].ToString() == null || dt.Rows[i]["updateat"].ToString() == "")
                {
                    dgvInsurtype.Rows[index].Cells["updateat"].Value = "";
                }
                else
                 dgvInsurtype.Rows[index].Cells["updateat"].Value = Convert.ToDateTime(dt.Rows[i]["updateat"]).ToString("yyyy-MM-dd");
            }
        }

        private void dgvInsurtype_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvInsurtype.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                                                          (e.RowIndex + 1).ToString(),
                                                          dgvInsurtype.RowHeadersDefaultCellStyle.Font,
                                                          rectangle,
                                                          dgvInsurtype.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        /// <summary>
        /// 选择内容时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInsurtype_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dgvInsurtype.SelectedCells[0].OwningRow.Cells["name"].Value.ToString();
            string sql = "select keyname,id from cost_insurtype where name=" + DataTool.addFieldBraces(name);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string id = dt.Rows[0]["id"].ToString();
            string keyname = dt.Rows[0]["keyname"].ToString();         
            if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
            {
                FrmSelectCross frmSelectCross = new FrmSelectCross();
                frmSelectCross.Insurtype_id = id;
                frmSelectCross.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.HDSCH.ToString())
            {
                FrmSelectCross frmSelectCross = new FrmSelectCross();
                frmSelectCross.Insurtype_id = id;
                frmSelectCross.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.HDSSY.ToString())
            {
                FrmSelectCross frmSelectCross = new FrmSelectCross();
                frmSelectCross.Insurtype_id = id;
                frmSelectCross.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.AHSJNH.ToString())
            {
                FrmItemcrossAhsjnh frmItemcrossAhsjnh = new FrmItemcrossAhsjnh();
                frmItemcrossAhsjnh.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.HDZRNH.ToString())
            {
               
            }
            else if (keyname == CostInsurtypeKeyname.HDXBHNH.ToString())
            {
                FrmSelectCrossXBH frmSelectCrossXBH = new FrmSelectCrossXBH();
                frmSelectCrossXBH.Insurtype_id = id;
                frmSelectCrossXBH.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.HSDRYB.ToString())
            {
                FrmSelectCrossHSDR frmSelectCrossHSDR = new FrmSelectCrossHSDR();
                frmSelectCrossHSDR.Insurtype_id = id;
                frmSelectCrossHSDR.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.HDBHNH.ToString())
            {
                FrmSelctcrossHDSBH frmSelctcrossHDSBH = new FrmSelctcrossHDSBH();
                frmSelctcrossHDSBH.Insurtype_id = id;
                frmSelctcrossHDSBH.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.GYSYB.ToString())
            {
                FrmSelectCrossGZS FrmSelectCrossGZS = new FrmSelectCrossGZS();
                FrmSelectCrossGZS.Insurtype_id = id;
                FrmSelectCrossGZS.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            {
                FrmSelectCrossGZS FrmSelectCrossGZS = new FrmSelectCrossGZS();
                FrmSelectCrossGZS.Insurtype_id = id;
                FrmSelectCrossGZS.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            {
                FrmGzsnhSelectCross frmGzsnhSelectCross = new FrmGzsnhSelectCross();
                frmGzsnhSelectCross.ShowDialog();
            }
            else if(keyname == CostInsurtypeKeyname.YNSYB.ToString())
            {
                FrmSelectCrossYNSYB frmSelectCrossYNSYB = new FrmSelectCrossYNSYB();
                frmSelectCrossYNSYB.ShowDialog();
            }
        }


    }
}
