using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.common;
using MTREG.clinic.bo;
using MTHIS.common;

namespace MTREG.clinic
{
    public partial class FrmRegBack : Form
    {
        string thisid;
        string patienttype;
        int flag;
        public FrmRegBack()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="id"></param>
        public void getSource(string id)
        {
            BillRegSearch billRegSearch = new BillRegSearch();
            this.thisid = id;
            DataTable dt = billRegSearch.regIdSearch(thisid);
            if (dt.Rows.Count > 0)
            {
                this.lblName.Text = dt.Rows[0]["regname"].ToString();
                this.lblBillcode.Text = dt.Rows[0]["billcode"].ToString();
                this.lblHspcard.Text = dt.Rows[0]["hspcard"].ToString();
                this.lblSex.Text = dt.Rows[0]["sex"].ToString();
                this.lblAge.Text = dt.Rows[0]["age"].ToString();
                this.lblDepart.Text = dt.Rows[0]["departname"].ToString();
                this.lblDoctor.Text = dt.Rows[0]["doctorname"].ToString();
                this.lblAmount.Text = dt.Rows[0]["amount"].ToString();
                this.lblPatienttype.Text = dt.Rows[0]["patienttype"].ToString();
                patienttype = dt.Rows[0]["patienttypeid"].ToString(); 
                this.lblRegdate.Text = Convert.ToDateTime(dt.Rows[0]["regdate"]).ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            BillRegSearch billRegSearch = new BillRegSearch();
            string keyname = billRegSearch.getInsurtype(patienttype);
            if(keyname== CostInsurtypeKeyname.HDSYB.ToString())
            {

            }
            ClinicCost clinicCost = new ClinicCost();
            ClinicCostdet clinicCostdet = new ClinicCostdet();
            string upsql = billRegSearch.upRegSta(thisid);
            //upsql += billRegSearch.upClinicCost(thisid);
            //DataTable dt = billRegSearch.costSearch(thisid);
            //string insql = "";
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        clinicCostdet.Id = BillSysBase.nextId("clinic_costdet");
            //        clinicCostdet.Clinic_cost_id = dt.Rows[i]["clinic_cost_id"].ToString();
            //        clinicCostdet.Regist_id = dt.Rows[i]["regist_id"].ToString();
            //        clinicCostdet.Standcode = dt.Rows[i]["standcode"].ToString();
            //        clinicCostdet.Clinic_Invoice_id = dt.Rows[i]["clinic_Invoice_id"].ToString();
            //        clinicCostdet.Item_id = dt.Rows[i]["item_id"].ToString();
            //        clinicCostdet.Itemfrom = dt.Rows[i]["itemfrom"].ToString();
            //        clinicCostdet.Clinic_rcpdetail_id = dt.Rows[i]["clinic_rcpdetail_id"].ToString();
            //        clinicCostdet.Depart_id = dt.Rows[i]["depart_id"].ToString();
            //        clinicCostdet.Doctor_id = dt.Rows[i]["doctor_id"].ToString();
            //        clinicCostdet.Exedep_id = dt.Rows[i]["exedep_id"].ToString();
            //        clinicCostdet.Exedoctor_id = dt.Rows[i]["exedoctor_id"].ToString();
            //        clinicCostdet.Drug_packsole_id = dt.Rows[i]["drug_packsole_id"].ToString();
            //        clinicCostdet.Name = dt.Rows[i]["name"].ToString();
            //        clinicCostdet.Spec = dt.Rows[i]["spec"].ToString();
            //        clinicCostdet.Unit = dt.Rows[i]["unit"].ToString();
            //        clinicCostdet.Num = "-"+dt.Rows[i]["num"].ToString();
            //        clinicCostdet.Prc = dt.Rows[i]["prc"].ToString();
            //        clinicCostdet.Fee = "-"+dt.Rows[i]["fee"].ToString();                    
            //        clinicCostdet.Realfee = "-" + dt.Rows[i]["realfee"].ToString();
            //        clinicCostdet.Itemtype_id = dt.Rows[i]["itemtype_id"].ToString();
            //        clinicCostdet.Itemtype1_id = dt.Rows[i]["itemtype1_id"].ToString();
            //        clinicCostdet.Charged = CostCharged.RREC.ToString();
            //        clinicCostdet.Chargedate = BillSysBase.currDate();
            //        clinicCostdet.Chargeby = ProgramGlobal.User_id;
            //        clinicCostdet.Retcost_id = dt.Rows[i]["id"].ToString();
            //        insql += billRegSearch.inCostdet(clinicCostdet);
            //    }
            //}
            //string sql = upsql + insql;
            string sql = upsql;
            flag = billRegSearch.sql(sql);
            if (flag<0)
            {
                MessageBox.Show("退号失败!");
                return;
            }
            this.Close();

        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
