using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.gysyb.Entity;
using MTREG.medinsur.gzsyb.Report_form;
using MTREG.medinsur.bll;
using MTREG.medinsur.gysyb.bll;
using MTHIS.main.bll;

namespace MTREG.medinsur.gzsyb
{
    public partial class FrmSybbbddcx : Form
    {
        CrystalReport_sybbbd CReportSybbbd = new CrystalReport_sybbbd();
        
        CrystalReport_Fpdy_ybfj report2 = new CrystalReport_Fpdy_ybfj();
        public FrmSybbbddcx()
        {
            InitializeComponent();
        }
        Gysybservice gysybservice = new Gysybservice();
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Preview();
            Preview_fj();

        }
        /// <summary>
        /// 打印方法
        /// </summary>
        public void Print()
        {
            CrystalReport_sybbbd CReportSybbbd = new CrystalReport_sybbbd();
            if (GetSybbbd().Count > 0)
            {
                CReportSybbbd.SetDataSource(GetSybbbd());
                crystalReportViewer1.ReportSource = CReportSybbbd;
            }
        }
        /// <summary>
        /// 预览方法
        /// </summary>
        public void Preview()
        {
            
            if(GetSybbbd().Count > 0)
            {
                CReportSybbbd.SetDataSource(GetSybbbd());
                crystalReportViewer1.ReportSource = CReportSybbbd;
            }
        }
        /// <summary>
        /// 预览方法--附件
        /// </summary>
        public void Preview_fj()
        {
            List<frmnhzy_fj> list = GetSybbbd_fj();

            if (list.Count > 0)
            {
                report2.SetDataSource(list);
                crystalReportViewer2.ReportSource = report2;
            }
        }
        /// <summary>
        /// 得到list--附件
        /// </summary>
        /// <returns></returns>
        public List<frmnhzy_fj> GetSybbbd_fj()
        {
            StringBuilder message = new StringBuilder();
            frmnhzy_fj sybbbd_entity = new frmnhzy_fj();
            List<frmnhzy_fj> sybbbd_entitys = new List<frmnhzy_fj>();
            if (!gysybservice.QUERYINFHOSPBILL_fj(tbxzyh.Text, message, sybbbd_entity))
            {
                MessageBox.Show(message.ToString());
                return sybbbd_entitys;
            }


            sybbbd_entitys.Add(sybbbd_entity);

            Dictionary<string, string> ryxx = getZyryxx(this.tbxzyh.Text);
            sybbbd_entity.Sex = ryxx["性别"];
            sybbbd_entity.Yljg = "贵州省骨科医院";
            sybbbd_entity.Ryzd = ryxx["入院诊断"];
            sybbbd_entity.Cyzd = ryxx["出院诊断"];
            sybbbd_entity.Rysj =DateTime.Parse(ryxx["入院时间"]).ToString("yyyy年MM月dd日");
            sybbbd_entity.Cysj = DateTime.Parse(ryxx["出院时间"]).ToString("yyyy年MM月dd日");
            sybbbd_entity.Ts = ryxx["住院天数"];
            sybbbd_entity.Yfje = ryxx["预交款"];
            sybbbd_entity.Jb ="三级甲等";
            sybbbd_entity.Zyh = tbxzyh.Text;
            return sybbbd_entitys;
        }
        /// <summary>
        /// 得到list
        /// </summary>
        /// <returns></returns>
        public List<Czzgjbylbxzyfyqd> GetSybbbd()
        {
            StringBuilder message=new StringBuilder();
            Czzgjbylbxzyfyqd sybbbd_entity=new Czzgjbylbxzyfyqd();
            List<Czzgjbylbxzyfyqd> sybbbd_entitys = new List<Czzgjbylbxzyfyqd>();
            if (!gysybservice.QUERYINFHOSPBILL(tbxzyh.Text, message, sybbbd_entity))
            {
                MessageBox.Show(message.ToString());
                return sybbbd_entitys;
            }
            
            //Dictionary<string, float> hisdata = gyybdb.getHisData(tbxzyh.Text);
            //float xyf =0;
            //hisdata.TryGetValue("西药",out xyf);
            //sybbbd_entity.Xyf=  Convert.ToString(xyf);//西药费
            //float zcy =0;
            //hisdata.TryGetValue("中成药",out zcy);
            //sybbbd_entity.Zcy=  Convert.ToString(zcy);//中成药
            //float zcyf =0;
            //hisdata.TryGetValue("中草药",out zcyf);
            //sybbbd_entity.Zcyf= Convert.ToString(zcyf);//中草药
            //float jcf = 0;
            //hisdata.TryGetValue("检查费",out jcf);
            //sybbbd_entity.Jcf =jcf.ToString();
            //float zlf = 0;
            //hisdata.TryGetValue("治疗费",out zlf);
            //sybbbd_entity.Zlf =zlf.ToString();
            //float zcf = 0;
            //hisdata.TryGetValue("诊查费",out zcf);
            //sybbbd_entity.Zfc =zcf.ToString();
            //float hyf = 0;
            //hisdata.TryGetValue("化验费",out hyf);
            //sybbbd_entity.Hyf =hyf.ToString();
            //float ssf = 0;
            //hisdata.TryGetValue("手术费",out ssf);
            //sybbbd_entity.Ssf =ssf.ToString();
            //float cwf = 0;
            //hisdata.TryGetValue("床位费",out cwf);
            //sybbbd_entity.Cwf =cwf.ToString();
            //float hlf = 0;
            //hisdata.TryGetValue("护理费",out hlf);
            //sybbbd_entity.Hlf =hlf.ToString();
            //float qt = 0;
            //hisdata.TryGetValue("其它",out qt);
            //sybbbd_entity.Qt =qt.ToString();
            //float fyhj = xyf + zcy + zcyf + jcf + zlf + zcf + hyf + ssf + cwf + hlf + qt;
            //sybbbd_entity.Fyhj = fyhj.ToString();//费用合计
            //sybbbd_entity.Fyhjxm = fyhj.ToString();
            
            sybbbd_entitys.Add(sybbbd_entity);
             


            Dictionary<string, string> ryxx = getZyryxx(this.tbxzyh.Text);
            sybbbd_entity.Xb = ryxx["性别"];
            sybbbd_entity.Nl = ryxx["年龄"];
            sybbbd_entity.Ryzd = ryxx["入院诊断"];
            sybbbd_entity.Cyzd = ryxx["出院诊断"];
            sybbbd_entity.Rysj = ryxx["入院时间"];
            sybbbd_entity.Cysj = ryxx["出院时间"];
            sybbbd_entity.Zyts = ryxx["住院天数"];
            sybbbd_entity.Yfj = ryxx["预交款"];
            sybbbd_entity.Kssj = sybbbd_entity.Rysj;
            sybbbd_entity.Jssj = sybbbd_entity.Cysj;
            return sybbbd_entitys;
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            report2.PrintToPrinter(1, false, 0, 0);
        }
        public Dictionary<string, string> getZyryxx(string zyjlzyh)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql3 = "select bas_sex.name as xb,inhospital.birthday as dob, inhospital.Ihspdiagn as zyjlryzd,inhospital.Outdiagn as zyjljbmc,"
            +"inhospital.Indate as zyjlrysj, inhospital.outdate as  zyjlcysj from sys_dict as bas_sex,inhospital where inhospital.Sex=bas_sex.keyname "
            + "and bas_sex.father_id <>0 and bas_sex.dicttype='bas_sex' and  inhospital.ihspcode='" + zyjlzyh + "'";
            DataTable tb1 = BllMain.Db.Select(sql3).Tables[0];
            if (tb1.Rows.Count == 0)
                return ret;
            ret.Add("性别", tb1.Rows[0]["xb"].ToString());
            ret.Add("入院诊断", tb1.Rows[0]["zyjlryzd"].ToString());
            ret.Add("出院诊断", tb1.Rows[0]["zyjljbmc"].ToString());
            ret.Add("入院时间", tb1.Rows[0]["zyjlrysj"].ToString().Split(' ')[0]);
            ret.Add("出院时间", tb1.Rows[0]["zyjlcysj"].ToString().Split(' ')[0]);
            string dob = tb1.Rows[0]["dob"].ToString();
            string rysj = tb1.Rows[0]["zyjlrysj"].ToString();
            string dobn = dob.Split(' ')[0].Split('-')[0];
            string rysjn = rysj.Split(' ')[0].Split('-')[0];
            string nl = (Convert.ToInt32(rysjn) - Convert.ToInt32(dobn)).ToString();
            ret.Add("年龄", nl);
            DateTime d_cysj = Convert.ToDateTime(tb1.Rows[0]["zyjlcysj"].ToString());
            DateTime d_rysj = Convert.ToDateTime(rysj);
            int zyts = d_cysj.Subtract(d_rysj).Days;
            if (zyts <= 0)
            {
                zyts = 1;
            }
            ret.Add("住院天数", zyts.ToString());
            string sql4 = "select sum(payfee) AS yjk from ihsp_payinadv,inhospital where ihsp_payinadv.ihsp_id=inhospital.id and inhospital.ihspcode='" + zyjlzyh + "'";
            DataTable tb2 = BllMain.Db.Select(sql4).Tables[0];
            ret.Add("预交款", tb2.Rows[0]["yjk"].ToString());
            return ret;

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
