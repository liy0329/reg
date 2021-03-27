using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTHIS.common;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.bo;
using MTREG.common;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdxbhnh.bll;
using MTREG.medinsur.hdssy.bll;
using MTREG.medinsur.hdsbhnh.bll;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.gzsnh.bll;
//using MTREG.medinsur.gzsyb.ihsp.bll;
using MTREG.medinsur.ynsyb.ihsp.bll;
using MTREG.medinsur.ynydyb.bll;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.sjzsyb.bll;
using System.IO;
using MTHIS.main.bll;
using MTREG.medinsur.sjzsyb.bean;
using System.Collections.Generic;


namespace MTREG.ihsp
{
    public partial class FrmRetIhsp : Form
    {
        int flag;
        string ihsp_id;
        string thisPatienttype;
        string enterdep;
        FrmIhspInhsp frmIhspMan = new FrmIhspInhsp();
        BillIhspcost billIhspcost = new BillIhspcost();
        Ybjk ybjk = new Ybjk();
        Rydj_in ryxx = new Rydj_in();
        public FrmRetIhsp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从FrmIhspMan中获取信息
        /// </summary>
        /// <param name="source"></param>
        public void getOutSource(string id)
        {
            this.ihsp_id = id;
            DataTable dt = billIhspcost.ihspIdSearch(id);
            this.lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
            this.lblName.Text = dt.Rows[0]["ihspname"].ToString();
            this.lblSex.Text = dt.Rows[0]["sex"].ToString();
            this.thisPatienttype = dt.Rows[0]["bas_patienttype_id"].ToString();
            this.enterdep = dt.Rows[0]["enterdep"].ToString();
            if (enterdep==IhspEnterDep.OO.ToString())
            {
                lblEnterdep.Text = "未入科";
            }
            else if (enterdep == IhspEnterDep.OUT.ToString())
            {
                lblEnterdep.Text = "已出科";
            }
            if (enterdep == IhspEnterDep.RECV.ToString())
            {
                lblEnterdep.Text = "已入科";
            }
            BillIhspAct bllIhspAct = new BillIhspAct();
            this.lblFeeamt.Text = DataTool.FormatData(bllIhspAct.getHisCostDetSum(this.ihsp_id),"2");
            this.lblPrepamt.Text = DataTool.FormatData(bllIhspAct.getHisPayinadvSum(this.ihsp_id),"2");
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            
            
            BillIhspMan billIhspMan = new BillIhspMan();
            BllInsur bllInsur = new BllInsur();            
                      
            string keyname = bllInsur.getInsurtype(thisPatienttype);
            
            if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            {
                BllGzsnhMethod bllGzsnhMethod=new BllGzsnhMethod();
                StringBuilder smessage = new StringBuilder();
                if (!bllGzsnhMethod.cancelIhspReg(ihsp_id, smessage))
                {
                    MessageBox.Show(smessage.ToString());
                    return;
                }
            }
            if (keyname == CostInsurtypeKeyname.SJZSYB.ToString())
            {
                string sql_ihsp = "SELECT MSGID,ihspcode,insurcode ,healthcard from inhospital where id = " + DataTool.addFieldBraces(ihsp_id);
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
                SjzybInterface sjzybInterface = new SjzybInterface();
                sjzybInterface.zyht(yb_in_ht, ref yb_out_ht);


                string ReturnMsg = "";
                int returnnum = Convert.ToInt32(yb_out_ht.RETURNNUM);
                if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                {
                    ReturnMsg = yb_out_ht.ERRORMSG;
                    MessageBox.Show(ReturnMsg, "提示信息");
                    return ;
                }

                string sql = "update inhospital set insurstat='OO', bas_patienttype_id= '1', bas_patienttype1_id= '1',Insuritemtype='1'  where id=" + DataTool.addFieldBraces(ihsp_id) + ";";
                sql += "delete from Sybzyjl where AKC190 =" + DataTool.addFieldBraces(ihspcode) + ";";
                flag = BllMain.Db.Update(sql);
                if (flag < 0)
                {
                    MessageBox.Show("入院取消成功,医保状态修改失败!", "提示信息");
                    return ;
                }

            }
            
            flag = billIhspMan.upOutStatus(ihsp_id);
            if (flag == -1)
            {
                MessageBox.Show("住院回退失败!");
                return;
            }

            MessageBox.Show("入院回退成功!", "提示信息");
            this.Close();   
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOuthospital_Load(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            if (lblPrepamt.Text == "" )
            {
                lblPrepamt.Text = "0.00";
            }
            if(lblFeeamt.Text == "")
            {
                lblFeeamt.Text = "0.00";
            }
            if (enterdep == IhspEnterDep.OO.ToString() || enterdep == IhspEnterDep.OUT.ToString())
            {
                if (lblPrepamt.Text == "0.00" && lblFeeamt.Text == "0.00")
                {
                    btnOk.Enabled = true;
                }                
            }                  
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
