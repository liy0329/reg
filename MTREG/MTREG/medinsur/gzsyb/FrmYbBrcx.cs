using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.listitem;
using MTHIS.main.bll;


namespace MTREG.medinsur.gzsyb
{
    public partial class FrmYbBrcx : Form
    {
        public FrmYbBrcx()
        {
            InitializeComponent();
        }
        private void FrmYbBrcx_Load(object sender, EventArgs e)
        {
            inityblx();//初始化医保类型
        }
        /// <summary>
        /// 初始化医保类型
        /// </summary>
        public void inityblx()
        {
            List<ListItem> yblbItem = new List<ListItem>();
            yblbItem.Add(new ListItem("171", "市医保"));
            yblbItem.Add(new ListItem("168", "省医保"));
            yblbItem.Add(new ListItem("173", "异地医保"));
            cbxyblx.DisplayMember = "Text";
            cbxyblx.ValueMember = "Value";
            cbxyblx.DataSource = yblbItem;
        }
        public void Search()
        {
            //dgvybbr
            String yblb = cbxyblx.SelectedValue.ToString();//医保类别
            string ksrq = this.dateTimePickerKsrq.Value.ToString("yyyy-MM-dd");
            string jsrq = this.dateTimePickerJsrq.Value.ToString("yyyy-MM-dd");
           dgvybbr.DataSource=GetYbbr(yblb,ksrq,jsrq);//查询
        }

        private void btncx_Click(object sender, EventArgs e)
        {
            Search();
        }
        public DataTable GetYbbr(String yblb, string ksrq, string jsrq)
        {
            StringBuilder sql = new StringBuilder();
            if (yblb.Equals("171"))
            {
                sql.Append(" select inhospital.name  as hzxm, insur_gysyb_zy.PERSONCODE as grbh, (case when inhospital.Sex='M' then '男' when inhospital.Sex='W' then '女' else '' end ) as xb,inhospital.Birthday as csrq,");
                sql.Append("  insur_gysyb_zy.SNO  as sfzh,insur_gysyb_zy.FUND1PAID as tczf,insur_gysyb_zy.fund2pay as dectzf,insur_gysyb_zy.fund3pay as gwybx,insur_gysyb_zy.carddata as kxx  ");
                sql.Append(" from insur_gysyb_zy,inhospital where insur_gysyb_zy.mtzyjliid=inhospital.id and insur_gysyb_zy.handledte>'" + ksrq + " 00:00:00' and insur_gysyb_zy.handledte<'" + jsrq + " 23:59:59'");
            }
            /*else if (yblb.Equals("168"))
            {
                sql.Append(" select aac003 as hzxm ,aac004 as grbh,aac001 as xb,aac006 as csrq, '' as sfzh ,'' as kxx,tczhifbf as tczf,dbzhifbf as dectzf ,gwytczhif as  gwybx, '' as kxx from gzyblocal_rybl where jsrq>'" + ksrq + " 00:00:00' and jsrq<'" + jsrq + " 23:59:59'");
            }*/
            else if (yblb.Equals("173"))
            {

                sql.Append(" select aac003 as hzxm,aac001 as grbh,(case when aac004=1 then '男' when aac004=2 then '女' end) as xb ,akc023 as csrq, aac002 as sfzh,yka248 as tczf,yka062 as dectzf,yke030 as gwybx,'' as kxx from insur_gzsyb_ryinfo where ykc014>'" + ksrq + " 00:00:00' and ykc014<'" + jsrq + " 23:59:59' ");
            }
            return BllMain.Db.Select(sql.ToString()).Tables[0];
            
        }
    }
}
