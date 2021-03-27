using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.ihsp.bll;
using MTREG.clinic.bo;
using MTREG.common;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur;
using MTREG.medinsur.hdsch;
using MTREG.medinsur.hsdryb;
using MTREG.medinsur.gysyb.clinic;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.medinsur.gysyb.bo;
using MTREG.medinsur.hdyb.clinic.bll;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdsch.clinic.bll;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hsdryb.bll;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.sjzsyb.bll;

namespace MTREG.clinic
{
    public partial class FrmMemberSett : Form
    {
        BllMemberSett bllMemberSett = new BllMemberSett();
        InsurInfo insurInfo = new InsurInfo();//衡水武邑县医保
        Sybdk_Entity sybdk_entity = new Sybdk_Entity();//贵阳市医保
        PersonInfo personInfo = new PersonInfo();//贵州省医保
        //结算单信息
        ClinicAccount clinicAccount = new ClinicAccount();//结算表
        List<ClinicInvoice> clinicInvoices = new List<ClinicInvoice>();
        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        BllClinicReg bllClinicReg = new BllClinicReg();
        string registInfo = "";
        string member_id = "-1";
        string register_id = "-1";
        string clinic_costdet_ids = "";
        string ybkbalance = "";
        public FrmMemberSett()
        {
            InitializeComponent();
        }

        private void FrmMemberSett_Load(object sender, EventArgs e)
        {
            btnvisable();
            comboxSource();
        }
        /// <summary>
        /// 下拉框数据
        /// </summary>
        public void comboxSource()
        {
            BillCmbList billCmbList = new BillCmbList();
            DataTable dtunit = new DataTable();
            dtunit.Columns.Add("name");
            dtunit.Columns.Add("value");
            DataRow dr1 = dtunit.NewRow();
            dr1[0] = "天";
            dr1[1] = "1";
            dtunit.Rows.Add(dr1);
            DataRow dr2 = dtunit.NewRow();
            dr2[0] = "周";
            dr2[1] = "2";
            dtunit.Rows.Add(dr2);
            DataRow dr3 = dtunit.NewRow();
            dr3[0] = "月";
            dr3[1] = "3";
            dtunit.Rows.Add(dr3);
            DataRow dr4 = dtunit.NewRow();
            dr4[0] = "岁";
            dr4[1] = "4";
            dtunit.Rows.Add(dr4);
            this.cmbAgeunit.DisplayMember = "name";
            this.cmbAgeunit.ValueMember = "value";
            this.cmbAgeunit.DataSource = dtunit;
            this.cmbAgeunit.SelectedValue = 4;

            DataTable dtsex = new DataTable();
            dtsex.Columns.Add("name");
            dtsex.Columns.Add("value");
            DataRow drsex1 = dtsex.NewRow();
            drsex1[0] = "男";
            drsex1[1] = "M";
            dtsex.Rows.Add(drsex1);
            DataRow drsex2 = dtsex.NewRow();
            drsex2[0] = "女";
            drsex2[1] = "W";
            dtsex.Rows.Add(drsex2);
            DataRow drsex3 = dtsex.NewRow();
            drsex3[0] = "未说明性别";
            drsex3[1] = "U";
            dtsex.Rows.Add(drsex3);
            DataRow drsex4 = dtsex.NewRow();
            drsex4[0] = "未知性别";
            drsex4[1] = "";
            dtsex.Rows.Add(drsex4);
            this.cmbSex.DisplayMember = "name";
            this.cmbSex.ValueMember = "value";
            this.cmbSex.DataSource = dtsex;

            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatienttype.ValueMember = "id";
                this.cmbPatienttype.DisplayMember = "name";
                this.cmbPatienttype.DataSource = dtp;
            }


            DataTable dtde = bllMemberSett.getDepartInfo();
            this.cmbDepart.ValueMember = "Id";
            this.cmbDepart.DisplayMember = "Name";
            var drde = dtde.NewRow();
            drde["Id"] = 0;
            drde["Name"] = "";
            dtde.Rows.InsertAt(drde, 0);
            this.cmbDepart.DataSource = dtde;

            DataTable dtdo = bllMemberSett.getDoctorInfo();
            this.cmbDoctor.ValueMember = "Id";
            this.cmbDoctor.DisplayMember = "Name";
            var drdo = dtdo.NewRow();
            drdo["Id"] = 0;
            drdo["Name"] = "";
            dtdo.Rows.InsertAt(drdo, 0);
            this.cmbDoctor.DataSource = dtdo;
        }

        /// <summary>
        /// 按卡号查询信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxHspcard_KeyDown(object sender, KeyEventArgs e)
        {
            //    member_id = "-1";
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        string hspcode = tbxHspcard.Text;
            //        DataTable dt= bllMemberSett.getMemberInfo(hspcode);
            //        if (dt.Rows.Count > 0)
            //        {
            //            member_id = dt.Rows[0]["id"].ToString();
            //            tbxAge.Text = dt.Rows[0]["age"].ToString();
            //            tbxName.Text = dt.Rows[0]["name"].ToString();
            //            tbxClinicCode.Text = dt.Rows[0]["billcode"].ToString();
            //            cmbSex.SelectedValue = dt.Rows[0]["sex"].ToString();
            //            cmbAgeunit.SelectedValue = dt.Rows[0]["ageunit"].ToString();
            //            cmbDepart.SelectedValue = dt.Rows[0]["depart_id"].ToString();
            //            cmbDoctor.SelectedValue = dt.Rows[0]["doctor_id"].ToString();
            //            register_id = dt.Rows[0]["register_id"].ToString();
            //            dgvUnsettInvoiceSource();
            //            dgvSettInvoiceSource();
            //            if (dgvUnsettInvoice.DataSource == null && dgvSettInvoice.DataSource!=null)
            //            {
            //                dgvSettInvoice.Focus();
            //                dgvSettInvoice.Select();
            //            }
            //            dgvCostdetSource();
            //        }
            //        else 
            //        {
            //            MessageBox.Show("未找到相关人员信息,请先进行充值挂号!");
            //            clearInfo();    
            //            return;
            //        }
            //    }
            //    btnvisable();
        }

        /// <summary>
        /// 已计费未结算的单号 数据
        /// </summary>
        public void dgvUnsettInvoiceSource(string starttime, string endtime)
        {
            DataTable dt = bllMemberSett.getNoSett(member_id, starttime, endtime);
            dgvUnsettInvoice.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                
                dgvUnsettInvoice.Columns["id"].Visible = false;
            }
            for (int i = 0; i < this.dgvUnsettInvoice.RowCount; i++)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvUnsettInvoice.Rows[i].Cells["check"];
                checkBox.Value = 1;
            }
        }

        /// <summary>
        /// 获取已打发票号
        /// </summary>
        public void dgvSettInvoiceSource()
        {
            DataTable dt = bllMemberSett.getInvoiceInfo(member_id);
            dgvSettInvoice.DataSource = dt;
            dgvSettInvoice.Columns["invoice"].HeaderText = "发票号";
            dgvSettInvoice.Columns["invoice"].Width = 190;
            dgvSettInvoice.Columns["id"].HeaderText = "id";
            dgvSettInvoice.Columns["id"].Visible = false;

        }

        /// <summary>
        /// 明细信息
        /// </summary>
        public void dgvCostdetSource()
        {
            string id = "";
            if (dgvUnsettInvoice.DataSource != null)
            {
                for (int i = 0; i < this.dgvUnsettInvoice.RowCount; i++)
                {
                    DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvUnsettInvoice.Rows[i].Cells["check"];
                    if (checkBox.Value.ToString() == "1")
                    {
                        id += dgvUnsettInvoice.Rows[i].Cells["id"].Value.ToString() + ",";
                    }
                }
                if (id.Length >= 2)
                {
                    id = id.Substring(0, id.Length - 1);
                }
                DataTable dt = bllMemberSett.getNoSettCostdet(id);
                dgvCostdet.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clinic_costdet_ids += dt.Rows[i]["id"].ToString() + ",";
                }
                if (!String.IsNullOrEmpty(clinic_costdet_ids))
                {
                    clinic_costdet_ids = clinic_costdet_ids.Substring(0, clinic_costdet_ids.Length - 1);
                }
            }
            else if (dgvUnsettInvoice.DataSource == null && dgvSettInvoice.DataSource != null)
            {
                if (dgvSettInvoice.CurrentRow != null)
                {
                    id = dgvSettInvoice.CurrentRow.Cells["id"].Value.ToString();
                    DataTable dt = bllMemberSett.getSettCostdet(id);
                    dgvCostdet.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        clinic_costdet_ids += dt.Rows[i]["id"].ToString() + ",";
                    }
                    if (!String.IsNullOrEmpty(clinic_costdet_ids))
                    {
                        clinic_costdet_ids = clinic_costdet_ids.Substring(0, clinic_costdet_ids.Length - 1);
                    }
                }
            }
        }
        /// <summary>
        /// 发票 对应费用明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSettInvoice_SelectionChanged(object sender, EventArgs e)
        {
            string id = "";
            if (dgvSettInvoice.CurrentRow != null)
            {
                id = dgvSettInvoice.CurrentRow.Cells["id"].Value.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    DataTable dt = bllMemberSett.getSettCostdet(id);
                    dgvCostdet.DataSource = dt;
                }
            }
        }
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSett_Click(object sender, EventArgs e)
        {

            //门诊结算                   
            clinicAccount.Id = BillSysBase.nextId("clinic_account");
            clinicAccount.Billcode = BillSysBase.newBillcode("clinic_account_billcode");//结算单
            clinicAccount.Regist_id = register_id;

            clinicAccount.Settledep_id = ProgramGlobal.Depart_id;
            clinicAccount.Settledby = ProgramGlobal.User_id;
            clinicAccount.Settledate = BillSysBase.currDate();
            clinicAccount.Bas_paytype_id = "11";//门诊卡
            clinicInvoices.Clear();//多张发票

            string id = "";
            for (int i = 0; i < this.dgvUnsettInvoice.RowCount; i++)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvUnsettInvoice.Rows[i].Cells["check"];
                if ((bool)checkBox.EditedFormattedValue == true)
                {
                    id += dgvUnsettInvoice.Rows[i].Cells["id"].Value.ToString() + ",";
                }
            }
            if (id.Length >= 2)
            {
                id = id.Substring(0, id.Length - 1);
            }
            string invoiceCostdetIds = "";
            DataTable dt = bllMemberSett.getNoSettCostdet(id);
            for (int i = 0;  i < dt.Rows.Count; i++ )
            {
                invoiceCostdetIds += dt.Rows[i]["id"].ToString() + ",";
            }
            if (invoiceCostdetIds.Length >= 2)
            {
                invoiceCostdetIds = invoiceCostdetIds.Substring(0, invoiceCostdetIds.Length - 1);
            }
            
            ClinicInvoice clinicInvoice = new ClinicInvoice();
            clinicInvoice.Id = BillSysBase.nextId("clinic_invoice");
            clinicInvoice.Account_id = clinicAccount.Id;
            clinicInvoice.Regist_id = register_id;
            clinicInvoice.Sickname = tbxName.Text;
            clinicInvoice.Rcpdep_id = cmbDepart.SelectedValue.ToString();
            clinicInvoice.Rcpdoctor_id = cmbDoctor.SelectedValue.ToString();
            clinicInvoice.Exedep_id = cmbDepart.SelectedValue.ToString();
            clinicInvoice.Fee = lblFeeamt.Text.ToString();
            clinicInvoice.Discnt = "1";
            clinicInvoice.Realfee = (double.Parse(clinicInvoice.Fee) * double.Parse(clinicInvoice.Discnt)).ToString();
            clinicInvoice.Bas_patienttype_id = cmbPatienttype.SelectedValue.ToString();
            clinicInvoice.Bas_patienttype1_id = cmbPatienttype.SelectedValue.ToString();
            clinicInvoice.Depart_id = ProgramGlobal.Depart_id;
            clinicInvoice.Chargedate = clinicAccount.Settledate;
            clinicInvoice.Chargeby = ProgramGlobal.User_id;//收费人
            clinicInvoice.Charged = CostCharged.CHAR.ToString();
            clinicInvoice.Clinic_cost_ids = id;
            clinicInvoice.Clinic_costdet_ids = invoiceCostdetIds;
            clinicInvoice.Payfee = lblFeeamt.Text.Trim();
            clinicInvoice.Bas_paytype_id = "11";

            clinicInvoice.Isregist = "0";

            clinicInvoices.Add(clinicInvoice);


            string invoicekind = bllClinicReg.getInvoiceKind(); //初始化发票类型
            //3.生成发票序列号。
            if (BillSysBase.currInvoiceB(ProgramGlobal.User_id, invoicekind, clinicInvoices) <= 0)
            {
                MessageBox.Show("发票已不足本次收费使用，请领取发票后，收费");
                return;
            }

            string invoices_sql = "";
            List<ClinicInvoiceDet> clinicInvoiceDetList = new List<ClinicInvoiceDet>();
            ClinicInvoiceDet clinicInvoiceDet3 = new ClinicInvoiceDet();//其他
            clinicInvoiceDet3.Clinic_invoice_id = clinicInvoice.Id;
            clinicInvoiceDet3.Payfee = clinicInvoice.Realfee;
            clinicInvoiceDet3.Bas_paytype_id = "11";
            clinicInvoiceDet3.Bas_paysumby_id = bllClinicReg.getPaysumbyFor("11");
            clinicInvoiceDet3.Cheque = "";
            clinicInvoiceDetList.Add(clinicInvoiceDet3);

            clinicInvoice.Bas_patienttype1_id = clinicInvoice.Bas_patienttype_id;
            clinicInvoice.Insurefee = "0.00";
            clinicInvoice.Insurotherfee = "0.00";
            clinicInvoice.Insuraccountfee = "0.00";
            clinicInvoice.Bas_paytype_id = "11";
            clinicInvoice.Payfee = clinicInvoice.Realfee;
            invoices_sql += bllRecipelCharge.doClinicInvoice_zf(clinicInvoice, clinicInvoiceDetList);//收费发票

            //3.生成结账信息单sql
            clinicAccount.Recivefee = lblFeeamt.Text;
            clinicAccount.Realfee = lblFeeamt.Text;
            clinicAccount.Payfee = lblFeeamt.Text;
            clinicAccount.Retfee = "0";
            clinicAccount.Insurefee = "";
            clinicAccount.Insuraccountfee = "";
            clinicAccount.Bas_paytype_id = "11";
            clinicAccount.HisOrderNo = "";
            invoices_sql += bllRecipelCharge.doClinicAccount(clinicAccount);

            //7 执行sql
            if (bllRecipelCharge.doExeSql(invoices_sql) < 0)
            {
                MessageBox.Show("收费信息生成失败！,医保病人请及时撤销医保票据,用网络支付时，请及时撤销网络支付");
                //bllRecipelCharge.doCancleInsurInvoice(clinicInvoices);//失败后处理医保信息
                return ;
            }
            if (MessageBox.Show("收费成功！是否打印明细？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                FrxPrintView frxPrintView = new FrxPrintView();
                if (cmbPatienttype.Text == "自费")
                {
                    frxPrintView.ZFprintInvoice(id, clinicInvoice.Id);
                    string sql1 = " UPDATE clinic_invoice SET print = '1' WHERE id = " + DataTool.addFieldBraces(clinicInvoice.Id);
                    BllMain.Db.Update(sql1);
                }
            }
            btnvisable();
            string startDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            dgvUnsettInvoiceSource(startDate, endDate);
            dgvSettInvoiceSource();
           
            #region
            //string S = clinic_costdet_ids;
            //string[] insurInvoice = new string[8];
            ////string id = "";
            //string invoiceCode = "";
            //string clinic_invoice_id = "";
            //for (int i = 0; i < this.dgvUnsettInvoice.RowCount; i++)
            //{
            //    DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvUnsettInvoice.Rows[i].Cells["check"];
            //    if ((bool)checkBox.EditedFormattedValue == true)
            //    {
            //        id += dgvUnsettInvoice.Rows[i].Cells["id"].Value.ToString() + ",";
            //    }
            //}
            //if (id.Length >= 2)
            //{
            //    id = id.Substring(0, id.Length - 1);
            //}
            ////ClinicInvoice clinicInvoice = new ClinicInvoice();
            ////BllClinicReg bllRegister = new BllClinicReg();
            ////clinicInvoice.Regist_id = register_id;
            ////DataTable dt = bllMemberSett.getMemberInfo(tbxHspcard.Text);
            ////clinicInvoice.Id = BillSysBase.nextId("clinic_invoice");
            ////clinic_invoice_id = clinicInvoice.Id;
            ////clinicInvoice.Sickname = dt.Rows[0]["name"].ToString();
            ////clinicInvoice.Fee = lblFeeamt.Text;
            ////clinicInvoice.Bas_patienttype_id = cmbPatienttype.SelectedValue.ToString();
            ////clinicInvoice.Insurcode = dt.Rows[0]["insurcode"].ToString();
            ////clinicInvoice.Healthcard = dt.Rows[0]["healthcard"].ToString();
            ////string invoiceKind = bllRegister.getInvoiceKind(cmbPatienttype.SelectedValue.ToString());
            ////string ip = ProgramGlobal.Ip;

            ////if (BillSysBase.nextInvoice(ProgramGlobal.User_id.Trim().ToString(), ip, invoiceKind, "1") == null)
            ////{
            ////    MessageBox.Show("发票类型不存在!");
            ////    return;
            ////}
            ////clinicInvoice.Billcode = BillSysBase.nextInvoice(ProgramGlobal.User_id.Trim().ToString(), ip, invoiceKind, "1")[0];//发票号
            ////invoiceCode = clinicInvoice.Billcode;
            ////clinicInvoice.Depart_id = ProgramGlobal.Depart_id;
            ////clinicInvoice.Chargeby = ProgramGlobal.User_id;
            ////clinicInvoice.Chargedate = BillSysBase.currDate();
            ////clinicInvoice.Charged = CostCharged.CHAR.ToString();

            //BllInsur bllInsur = new BllInsur();
            //string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            //#region 医保结算
            //if (keyname.ToUpper().Equals(CostInsurtypeKeyname.HDSYB.ToString().ToUpper().Trim()))
            //{
            //    //调用医保接口    邯郸市医保传输
            //    BllClinicMedinsr bllClinicMedinsr = new BllClinicMedinsr();
            //    bllClinicMedinsr.insurReg(insurInfo, register_id);
            //    int flag = bllClinicMedinsr.costdetTransfer(tbxClinicCode.Text, clinic_costdet_ids, keyname.ToUpper().Trim());
            //    switch (flag)
            //    {
            //        case 0: MessageBox.Show("传输成功！");
            //            break;
            //        case -1: MessageBox.Show("读取药品信息失败！");
            //            return;
            //        case -2: MessageBox.Show("读取诊疗信息失败！");
            //            return;
            //        case -3: MessageBox.Show("传入中间表失败！");
            //            return;
            //        case -4: MessageBox.Show("无可传输项！");
            //            return;
            //        case -5: MessageBox.Show("添加目录表失败！");
            //            return;
            //        case -6: MessageBox.Show("添加对照表失败！");
            //            return;
            //    }
            //    //邯郸市医保门诊结算
            //    Mzjs_in mzjs_in = new Mzjs_in();
            //    mzjs_in.Djh = invoiceCode;//单据号
            //    mzjs_in.Grbh = insurInfo.PersonalNum;
            //    mzjs_in.Jbr = ProgramGlobal.User_id;
            //    mzjs_in.Mzzyh = tbxClinicCode.Text.Trim();
            //    mzjs_in.Yllb = insurInfo.Ihsptype;//医疗类别
            //    mzjs_in.Zffs = "";//支付方式
            //    Mzjs_out mzjs_out = new Mzjs_out();
            //    Ybjk ybjk = new Ybjk();
            //    int opt = ybjk.mzjs(mzjs_in, mzjs_out);
            //    if (opt != 0)
            //    {
            //        MessageBox.Show(mzjs_out.Message + "，门诊结算失败！", "提示信息");
            //        return;
            //    }
            //    lblInsurefee.Text = mzjs_out.Bctczfje;
            //    //insurefee = mzjs_out.Bctczfje;
            //    lblInsurefee.Text = mzjs_out.Bctczfje;
            //    //dgvCharge.Rows[i].Cells["fee"].Value = mzjs_out.Bcxjzfje;
            //    //reallfee = mzjs_out.Bcxjzfje;
            //    lblInsuraccountfee.Text = mzjs_out.Bcgrzhzfje;
            //    //Insuraccountfee = mzjs_out.Bcgrzhzfje;
            //    lblInsuraccountfee.Text = mzjs_out.Bcgrzhzfje;
            //}
            //else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDSCH.ToString().ToUpper().Trim())
            //{
            //    //调用城合接口    邯郸市城合传输
            //    BllHdschClinic bllHdschClinic = new BllHdschClinic();
            //    bllHdschClinic.insurReg(insurInfo, register_id);
            //    int flag = bllHdschClinic.costdetTransfer(tbxClinicCode.Text, clinic_costdet_ids, insurInfo.PersonalNum);
            //    switch (flag)
            //    {
            //        case 0: MessageBox.Show("传输成功！");
            //            break;
            //        case -1: MessageBox.Show("读取药品信息失败！");
            //            return;
            //        case -2: MessageBox.Show("读取诊疗信息失败！");
            //            return;
            //        case -3: MessageBox.Show("传入中间表失败！");
            //            return;
            //        case -4: MessageBox.Show("无可传输项！");
            //            return;
            //    }
            //    //邯郸市城合门诊结算
            //    Hdsch hdsch = new Hdsch();
            //    Mzjs_in mzjs_in = new Mzjs_in();
            //    mzjs_in.Djh = invoiceCode;//单据号
            //    mzjs_in.Grbh = insurInfo.PersonalNum;
            //    mzjs_in.Jbr = ProgramGlobal.User_id;
            //    mzjs_in.Mzzyh = tbxClinicCode.Text.Trim();
            //    mzjs_in.Yllb = insurInfo.Ihsptype;//医疗类别
            //    mzjs_in.Zffs = "";//支付方式
            //    Mzjs_out mzjs_out = new Mzjs_out();
            //    int opt = hdsch.mzjs(mzjs_in, mzjs_out, insurInfo.PersonalNum);
            //    if (opt != 0)
            //    {
            //        MessageBox.Show(mzjs_out.Message + "，门诊结算失败！", "提示信息");
            //        return;
            //    }
            //    lblInsurefee.Text = mzjs_out.Bctczfje;//统筹金额
            //    //insurefee = mzjs_out.Bctczfje;
            //    lblInsurefee.Text = mzjs_out.Bctczfje;
            //    //dgvCharge.Rows[i].Cells["fee"].Value = mzjs_out.Bcxjzfje;//实收金额
            //    //reallfee = mzjs_out.Bcxjzfje;
            //    lblInsuraccountfee.Text = mzjs_out.Bcgrzhzfje;//账户支付
            //    //Insuraccountfee = mzjs_out.Bcgrzhzfje;
            //    lblInsuraccountfee.Text = mzjs_out.Bcgrzhzfje;
            //}
            //else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDBHNH.ToString().ToUpper().Trim())
            //{

            //}
            //else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDXBHNH.ToString().ToUpper().Trim())
            //{

            //}
            //else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDXZRNH.ToString().ToUpper().Trim())
            //{

            //}
            //else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDZRNH.ToString().ToUpper().Trim())
            //{

            //}
            //else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HSDRYB.ToString().ToUpper().Trim())
            //{
            //    //衡水数据传输
            //    BllClinMedinsrHSDR bllMedinsrHSDR = new BllClinMedinsrHSDR();
            //    bllMedinsrHSDR.insurReg(insurInfo, register_id);
            //    int flag = bllMedinsrHSDR.costdetTransfer(tbxClinicCode.Text.Trim(), clinic_costdet_ids, insurInfo.PersonalNum);
            //    if (flag == 0)
            //    {
            //    }
            //    else if (flag == -1)
            //    {
            //        return;
            //    }
            //    //门诊结算
            //    TopParameter common = new TopParameter();
            //    common.AKC190 = tbxClinicCode.Text.Trim();
            //    common.AKC020 = insurInfo.Iccardid;
            //    common.AKA130 = insurInfo.Ihsptype;
            //    common.AKB020 = ProgramGlobal.Othvar_2;
            //    common.MSGNO = "1108";
            //    common.MSGID = WYJK.getLsh();
            //    common.GRANTID = ProgramGlobal.Othvar_3;
            //    common.OPERID = ProgramGlobal.User_id;
            //    common.OPERNAME = ProgramGlobal.Username;
            //    common.BATNO = ProgramGlobal.Othvar_1;
            //    common.OPTTIME = BillSysBase.currDate();

            //    MTREG.medinsur.hsdryb.bo.KC21 kc21 = new MTREG.medinsur.hsdryb.bo.KC21();
            //    DataTable dt_r = bllMedinsrHSDR.getRegInfo(common.AKC190);
            //    kc21.AKC190 = common.AKC190;
            //    kc21.AKA130 = common.AKA130;
            //    kc21.AKC192 = dt_r.Rows[0]["AKC192"].ToString();
            //    kc21.AAE011 = ProgramGlobal.User_id;
            //    kc21.AAE036 = dt_r.Rows[0]["AAE036"].ToString();
            //    kc21.AKC008 = dt_r.Rows[0]["AKC008"].ToString();
            //    kc21.AKC025 = dt_r.Rows[0]["AKC025"].ToString();
            //    kc21.AKC031 = dt_r.Rows[0]["AKC031"].ToString();
            //    kc21.BKF050 = dt_r.Rows[0]["BKF050"].ToString();
            //    if (common.AKA130 == "13")//慢性病添加此项
            //    {
            //        kc21.AKC193 = dt_r.Rows[0]["AKC193"].ToString(); ;
            //    }
            //    WYJK wyjk = new WYJK();
            //    var par = wyjk.mzfyjs(common, kc21, insurInfo.PersonalNum, this.lblFeeamt.Text.Trim(), invoiceCode);
            //    if (par.ReturnNum == "-1")
            //    {
            //        MessageBox.Show("门诊结算失败:" + par.ErrorMsg);
            //        return;
            //    }
            //    lblInsurefee.Text = par.AKC260;
            //    //insurefee = par.AKC260;
            //    lblInsurefee.Text = par.AKC260;
            //    //dgvCharge.Rows[i].Cells["fee"].Value = par.AKC261;
            //    //reallfee = par.AKC261;
            //    lblInsuraccountfee.Text = par.AKC255;
            //    //Insuraccountfee = par.AKC255;
            //    lblInsuraccountfee.Text = par.AKC255;
            //    //tbxRealFee.Text = par.AKC264;
            //    //tbxAmount.Text = par.AKC264;
            //}
            //else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.GYSYB.ToString().ToUpper().Trim())
            //{
            //    Gysybservice gysyb = new Gysybservice();
            //    StringBuilder message = new StringBuilder(50);
            //    string[] yb = new string[5];
            //    //string once_zhzf = "";
            //    //if (!gysyb.mzzsjs_kls(sybdk_entity, clinic_costdet_ids, clinic_invoice_id,  invoiceCode, ref once_zhzf, yb, message))
            //    //{
            //    //    return;
            //    //}
            //    //string cash = (double.Parse(tbxAmount.Text.Trim()) - yb[0] - yb[1]).ToString();
            //    lblInsurefee.Text = yb[1].ToString();
            //    //insurefee = yb[1].ToString();
            //    lblInsurefee.Text = yb[1].ToString();
            //    lblInsuraccountfee.Text = yb[0].ToString();
            //    //Insuraccountfee = yb[0].ToString();
            //    lblInsuraccountfee.Text = yb[0].ToString();
            //    //dgvCharge.Rows[i].Cells["fee"].Value = cash;
            //    //reallfee = cash;
            //}//贵州省医保结算
            //else if (keyname.ToUpper().Trim().ToUpper().Equals(CostInsurtypeKeyname.GZSYB.ToString().ToUpper().Trim()))
            //{
            //    Gzsybservice gzsybservice = new Gzsybservice();
            //    string info = "";
            //    string[] ybzf = new string[2];

            //    //if (gzsybservice.mzjs_kls(personInfo, ref info,  clinic_costdet_ids, clinic_invoice_id, ybzf, register_id, insurInvoice))
            //    //{
            //    //            lblInsurefee.Text = ybzf[1];//统筹
            //    //            lblInsuraccountfee.Text = ybzf[0];//账户
            //    //            //reallfee = (DataTool.stringToDouble(amount) - DataTool.stringToDouble(insurefee) - DataTool.stringToDouble(Insuraccountfee)).ToString();
            //    //            //dgvCharge.Rows[i].Cells["fee"].Value = reallfee;//现金
            //    //}
            //}
            //#endregion
            ////his读卡收费，接口不再收费
            ////MemRechargedet memRechargedet = new MemRechargedet();
            ////memRechargedet.Id = BillSysBase.nextId("member_rechargedet");
            ////memRechargedet.Bas_member_id = member_id;
            ////memRechargedet.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
            ////memRechargedet.Opertype = "RE";
            ////memRechargedet.Amount = (DataTool.stringToDouble(lblInsuraccountfee.Text.Trim())+DataTool.stringToDouble(lblInsurefee.Text.Trim())).ToString();
            ////memRechargedet.Balance = (DataTool.stringToDouble(tbxBalance.Text.Trim())+DataTool.stringToDouble(memRechargedet.Amount)).ToString();
            ////memRechargedet.Operatorid = ProgramGlobal.User_id;
            ////memRechargedet.Operatdate = BillSysBase.currDate();
            ////更改会员卡
            ////string sql_yb = bllMemberSett.inMember_rechargedet(memRechargedet);
            ////sql_yb += bllMemberSett.modifyMember_balance(memRechargedet.Balance,member_id);
            //string sql = "";// bllMemberSett.inClinic_invoice(clinicInvoice);
            ////sql += bllMemberSett.upClinic_costdet(id);
            ////sql += bllMemberSett.upRechargedet(id);
            ////sql += sql_yb;
            //bool flg = settMethod(sql);
            //if (flg)
            //{

            //    if (keyname.ToUpper().Equals(CostInsurtypeKeyname.HDSYB.ToString().ToUpper().Trim()))
            //    {
            //        string reginfo = insurInfo.PersonalNum + "|" + insurInfo.Iccardid + "|" + insurInfo.ApproveType + "|" + insurInfo.Approvenum + "|" + insurInfo.Ihsptype + "|" + insurInfo.Ihspdiagn + "|" + insurInfo.Isblock + "|" + insurInfo.Selffee + "|" + insurInfo.Insurfee + "|"
            //                       + insurInfo.Balance + "|" + insurInfo.Clinicdiagn + "|" + insurInfo.Clinicicd + "|" + insurInfo.Cliniciname + "|" + insurInfo.Companyname + "|" + insurInfo.Companynum;
            //        BllClinicMedinsr bllClinicMedinsr = new BllClinicMedinsr();
            //        bllClinicMedinsr.clinicInsurInfo(reginfo, clinic_invoice_id);
            //    }
            //    else if (keyname.ToUpper().Equals(CostInsurtypeKeyname.HDSCH.ToString().ToUpper().Trim()))
            //    {
            //        //个人编号|ic卡号|门诊诊断名称|门诊诊断编码|医疗类别|账户余额|单位编号|封锁状态
            //        string reginfo = insurInfo.PersonalNum + "|" + insurInfo.Iccardid + "|" + insurInfo.Clinicdiagn + "|" + insurInfo.Clinicicd + "|" + insurInfo.Ihsptype + "|" + insurInfo.Balance + "|" + insurInfo.Companynum + "|" + insurInfo.Isblock;
            //        BllHdschClinic bllHdschClinic = new BllHdschClinic();
            //        bllHdschClinic.clinicInsurInfo(reginfo, clinic_invoice_id);
            //    }
            //    else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDBHNH.ToString().ToUpper().Trim())
            //    {

            //    }
            //    else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDXBHNH.ToString().ToUpper().Trim())
            //    {

            //    }
            //    else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDXZRNH.ToString().ToUpper().Trim())
            //    {

            //    }
            //    else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDZRNH.ToString().ToUpper().Trim())
            //    {

            //    }
            //    else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HSDRYB.ToString().ToUpper().Trim())
            //    {

            //    }

            //}
            //else
            //{
            //    //bllRecipelCharge.deleteSql(getCliniCostIds(), clinic_costdet_ids);
            //    MessageBox.Show("结算失败！");
            //    return;
            //}
            #endregion
        }
        /// <summary>
        /// 结算方法
        /// </summary>
        public bool settMethod(string sql)
        {
            if (BllMain.Db.Update(sql) < 0)
            {
                MessageBox.Show("结算失败!");
                return false;
            }
            MessageBox.Show("结算成功!");
            btnvisable();
            string startDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            dgvUnsettInvoiceSource(startDate, endDate);
            dgvSettInvoiceSource();
            return true;
        }
        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetcard_Click(object sender, EventArgs e)
        {
            if (member_id == "-1")
            {
                MessageBox.Show("请先填写正确的卡号并回车!");
                return;
            }
            FrmNocard frmNocard = new FrmNocard();
            frmNocard.getSource(member_id);
            frmNocard.ShowDialog();
            if (frmNocard.DialogResult == DialogResult.OK)
            {
                clearInfo();
            }
        }

        /// <summary>
        /// 数据变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCostdet_DataSourceChanged(object sender, EventArgs e)
        {
            lblFeeamt.ForeColor = Color.Red;
            lblInsuraccountfee.ForeColor = Color.Red;
            lblInsurefee.ForeColor = Color.Red;
            double feeamt = 0.00;
            double insuraccountfee = 0.00;
            double insurefee = 0.00;
            for (int i = 0; i < dgvCostdet.Rows.Count; i++)
            {
                feeamt += double.Parse(dgvCostdet.Rows[i].Cells["fee"].Value.ToString());
                //insuraccountfee += double.Parse(dgvCostdet.Rows[i].Cells["selffee"].Value.ToString());
                //insurefee += double.Parse(dgvCostdet.Rows[i].Cells["insurefee"].Value.ToString());
            }
            lblFeeamt.Text = DataTool.FormatData(feeamt.ToString(), "2");
            lblInsuraccountfee.Text = DataTool.FormatData(insuraccountfee.ToString(), "2");
            lblInsurefee.Text = DataTool.FormatData(insurefee.ToString(), "2");
        }
        /// <summary>
        /// 清空信息    
        /// </summary>
        public void clearInfo()
        {
            member_id = "-1";
            tbxAge.Text = "";
            //tbxBalance.Text = "";
            tbxClinicCode.Text = "";
            tbxHspcard.Text = "";
            tbxName.Text = "";
            string startDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string hspcode = tbxHspcard.Text;
            DataTable dt = bllMemberSett.getMemberInfo(hspcode);
            if (dt.Rows.Count > 0)
            {
                member_id = dt.Rows[0]["id"].ToString();
                tbxAge.Text = dt.Rows[0]["age"].ToString();
                tbxName.Text = dt.Rows[0]["name"].ToString();
                tbxClinicCode.Text = dt.Rows[0]["billcode"].ToString();
                //tbxBalance.Text = dt.Rows[0]["balance"].ToString();
                cmbSex.SelectedValue = dt.Rows[0]["sex"].ToString();
                cmbAgeunit.SelectedValue = dt.Rows[0]["ageunit"].ToString();
                cmbDepart.SelectedValue = dt.Rows[0]["depart_id"].ToString();
                cmbDoctor.SelectedValue = dt.Rows[0]["doctor_id"].ToString();
                register_id = dt.Rows[0]["register_id"].ToString();
                dgvUnsettInvoiceSource(startDate, endDate);
                dgvSettInvoiceSource();
                if (dgvUnsettInvoice.DataSource == null && dgvSettInvoice.DataSource != null)
                {
                    dgvSettInvoice.Focus();
                    dgvSettInvoice.Select();
                }
                dgvCostdetSource();
            }
            else
            {
                MessageBox.Show("未找到相关人员信息,请先进行充值挂号!");
                clearInfo();
                return;
            }
            btnvisable();
        }

        /// <summary>
        /// 取发票号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static int currInvoiceB(string chargeBy, string invoicekindId, List<ClinicInvoice> clinicinvoices)
        {
            //int num = clinicinvoices.Count;//1
            int num = 1;
            int invoiceNum = 0;
            DataTable dt1 = new DataTable();
            string sql1 = "select COALESCE(sum(endnum-currnum+1),0) as num from sys_invoice where charger = " + DataTool.addFieldBraces(chargeBy)
                + " and sys_invoicekind_id = " + DataTool.addFieldBraces(invoicekindId)
                + " and  started in ('OO', 'ST')";
            dt1 = BllMain.Db.Select(sql1).Tables[0];
            try
            {

                invoiceNum = int.Parse(dt1.Rows[0]["num"].ToString()) - num;
            }
            catch (Exception ex)
            {

                invoiceNum = 0;
                return invoiceNum;
            }
            if (invoiceNum <= 0)
            {
                return invoiceNum = 0;
            }

            List<string> invoices = new List<string>();
            string sql = "SELECT currnum,endnum,id,postfix, prefix,started  from sys_invoice "
            + "WHERE "
            + " sys_invoicekind_id=" + DataTool.addFieldBraces(invoicekindId)
            + " and charger =" + DataTool.addFieldBraces(chargeBy)
            + " and started in ('OO','ST') order by issuedate";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];

            int i_num = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string currnum = dt.Rows[i]["currnum"].ToString();
                string endnum = dt.Rows[i]["endnum"].ToString();
                string id = dt.Rows[i]["id"].ToString();
                string postfix = dt.Rows[i]["postfix"].ToString();
                string prefix = dt.Rows[i]["prefix"].ToString();
                string started = dt.Rows[i]["started"].ToString();
                int int_currnum = DataTool.stringToInt(currnum);
                int int_endnum = DataTool.stringToInt(endnum);
                string nextinvoicesql = "";
                string invoicecode = "";
                while (i_num < clinicinvoices.Count)
                {
                    if (int_currnum < int_endnum)
                    {

                        invoicecode = prefix + int_currnum + postfix;
                        if (!started.Trim().Equals("OO"))
                            nextinvoicesql = "update sys_invoice set currnum=" + int_currnum + "+1 where id=" + DataTool.addFieldBraces(id) + ";";
                        else
                            nextinvoicesql = "update sys_invoice set currnum=" + int_currnum + "+1,started = 'ST' where id=" + DataTool.addFieldBraces(id) + ";";

                        clinicinvoices[i_num].Invoice = invoicecode;
                        clinicinvoices[i_num].Nextinvoicesql = nextinvoicesql;
                        i_num++;
                        int_currnum++;
                    }
                    else if (int_currnum == int_endnum)
                    {
                        invoicecode = prefix + currnum + postfix;
                        nextinvoicesql = "update sys_invoice set currnum=" + int_currnum + "+1,started = 'EN' where id=" + DataTool.addFieldBraces(id) + ";";
                        clinicinvoices[i_num].Invoice = invoicecode;
                        clinicinvoices[i_num].Nextinvoicesql = nextinvoicesql;
                        i_num++;
                        break;
                    }
                }
                if (i_num == clinicinvoices.Count)
                    break;

            }
            return invoiceNum;
        }
        private void dgvUnsettInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getCostdet();
        }

        /// <summary>
        /// 充值记录获取明细
        /// </summary>
        public void getCostdet()
        {
            string id = "";
            if (dgvUnsettInvoice.DataSource != null)
            {
                for (int i = 0; i < this.dgvUnsettInvoice.RowCount; i++)
                {
                    DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvUnsettInvoice.Rows[i].Cells["check"];
                    if ((bool)checkBox.EditedFormattedValue == true)
                    {
                        id += dgvUnsettInvoice.Rows[i].Cells["id"].Value.ToString() + ",";
                    }
                }
                if (id.Length >= 2)
                {
                    id = id.Substring(0, id.Length - 1);
                }
                DataTable dt = bllMemberSett.getNoSettCostdet(id);
                dgvCostdet.DataSource = dt;
            }
        }

        /// <summary>
        /// 按钮显示
        /// </summary>
        public void btnvisable()
        {
            if (dgvUnsettInvoice.DataSource != null)
            {
                btnSett.Enabled = true;
                btnSett.Visible = true;
                btnRePrint.Visible = false;
                dgvSettInvoice.Enabled = false;
            }
            else if (dgvUnsettInvoice.DataSource == null && dgvSettInvoice.DataSource != null)
            {
                btnRePrint.Visible = true;
                btnSett.Visible = false;
                dgvSettInvoice.Enabled = true;
            }
            else if (dgvUnsettInvoice.DataSource == null && dgvSettInvoice.DataSource == null)
            {
                btnRePrint.Visible = false;
                btnSett.Visible = true;
                btnSett.Enabled = false;
            }

        }

        private void btnReadHealthcard_Click(object sender, EventArgs e)
        {
            reaInsurCardButtonClick();
        }
        /// <summary>
        /// 门诊卡读取信息
        /// </summary>
        private void reaInsurCardButtonClick()
        {
            Mifare dk = new Mifare();
            Member member = new Member();
            dk.OpenPoint();
            string fareuid = dk.FindCard();
            dk.ClosePoint();
            member.Mzfare = fareuid;
            member.Cardstat = "YES";
            BillMember billMember = new BillMember();
            string startDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            DataTable dthspcard = billMember.memberSearch(member, "", "");
            if (dthspcard.Rows.Count <= 0)
            {
                MessageBox.Show("没有此卡信息！");
                return;
            }
            string hspcard = dthspcard.Rows[0]["hspcard"].ToString();
            DataTable dt = bllMemberSett.getMemberInfo(hspcard);
            if (dt.Rows.Count > 0)
            {
                member_id = dt.Rows[0]["id"].ToString();
                tbxAge.Text = dt.Rows[0]["age"].ToString();
                tbxName.Text = dt.Rows[0]["name"].ToString();
                tbxHspcard.Text = hspcard;
                tbxClinicCode.Text = dt.Rows[0]["billcode"].ToString();
                //tbxBalance.Text = dt.Rows[0]["balance"].ToString();
                cmbSex.SelectedValue = dt.Rows[0]["sex"].ToString();
                cmbAgeunit.SelectedValue = dt.Rows[0]["ageunit"].ToString();
                cmbDepart.SelectedValue = dt.Rows[0]["depart_id"].ToString();
                cmbDoctor.SelectedValue = dt.Rows[0]["doctor_id"].ToString();
                register_id = dt.Rows[0]["register_id"].ToString();
                dgvUnsettInvoiceSource(startDate, endDate);
                dgvSettInvoiceSource();
                if (dgvUnsettInvoice.DataSource == null && dgvSettInvoice.DataSource != null)
                {
                    dgvSettInvoice.Focus();
                    dgvSettInvoice.Select();
                }
                dgvCostdetSource();
            }
            btnvisable();
        }
        /// <summary>
        /// 预结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void budgetBalance()
        {
            if (ProgramGlobal.VersionChk == "N")
            {
                MessageBox.Show("版本已过期,请联系相关工作人员进行升级!");
                this.Close();
            }
            if (tbxName.Text == "" || cmbDoctor.SelectedIndex == -1 || cmbDoctor.SelectedIndex == 0 || cmbDepart.SelectedValue.Equals(0) || tbxAge.Text == "" || tbxClinicCode.Text == "")
            {
                MessageBox.Show("请录入信息");
                return;
            }
            //for (int i = 0; i < dgvClinic_costdet.Rows.Count; i++)
            //{
            //    if (this.dgvClinic_costdet.Rows[i].Cells["itemfrom"].Value.ToString().Equals(BasItemFrom.DRUG.ToString()) && double.Parse(dgvClinic_costdet.Rows[i].Cells["activeqty"].Value.ToString()) - double.Parse(dgvClinic_costdet.Rows[i].Cells["num"].Value.ToString()) < 0)
            //    {
            //        MessageBox.Show("缺药，不能收费！");
            //        return;
            //    }
            //}

            string itemname = "";

            string id = "";
            for (int i = 0; i < this.dgvUnsettInvoice.RowCount; i++)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvUnsettInvoice.Rows[i].Cells["check"];
                if ((bool)checkBox.EditedFormattedValue == true)
                {
                    id += dgvUnsettInvoice.Rows[i].Cells["id"].Value.ToString() + ",";
                }
            }
            if (id.Length >= 2)
            {
                id = id.Substring(0, id.Length - 1);
            }
            // int drug = bllRecipelCharge.doPayAppDrugIo(getCliniCostIds(), clinic_costdet_ids, ref itemname);
            //if (drug == -1)
            //{
            //    itemname = itemname.Substring(0, itemname.Length - 1);
            //    MessageBox.Show("itemname" + "药品库存不够！");
            //}
            BllClinicReg bllRegister = new BllClinicReg();
            string invoiceKind = bllRegister.getInvoiceKind(cmbPatienttype.SelectedValue.ToString());
            string ip = ProgramGlobal.Ip;

            if (BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), ip, invoiceKind, "1").Count == 0)
            {
                MessageBox.Show("发票类型不存在!");
                return;
            }
            string invoiceCode = BillSysBase.nextInvoice(ProgramGlobal.User_id.Trim().ToString(), ip, invoiceKind, "1")[0];//

            BllInsur bllInsur = new BllInsur();
            string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDSYB.ToString().ToUpper().Trim())
            {
                //调用医保接口    邯郸市医保传输
                BllClinicMedinsr bllClinicMedinsr = new BllClinicMedinsr();
                bllClinicMedinsr.insurReg(insurInfo, register_id);
                int flag = bllClinicMedinsr.costdetTransfer(tbxClinicCode.Text, clinic_costdet_ids, keyname.ToUpper().Trim());
                switch (flag)
                {
                    case 0: MessageBox.Show("传输成功！");
                        break;
                    case -1: MessageBox.Show("读取药品信息失败！");
                        return;
                    case -2: MessageBox.Show("读取诊疗信息失败！");
                        return;
                    case -3: MessageBox.Show("传入中间表失败！");
                        return;
                    case -4: MessageBox.Show("无可传输项！");
                        return;
                    case -5: MessageBox.Show("添加目录表失败！");
                        return;
                    case -6: MessageBox.Show("添加对照表失败！");
                        return;
                }
                //门诊预结算
                Mzjs_in mzjs_in = new Mzjs_in();
                mzjs_in.Djh = invoiceCode;//单据号
                mzjs_in.Grbh = insurInfo.PersonalNum;
                mzjs_in.Jbr = ProgramGlobal.User_id;
                mzjs_in.Mzzyh = tbxClinicCode.Text.Trim();
                mzjs_in.Yllb = insurInfo.Ihsptype;//医疗类别
                mzjs_in.Zffs = "";//支付方式
                Mzjs_out mzjs_out = new Mzjs_out();
                Ybjk ybjk = new Ybjk();
                int opt = ybjk.mzjs_yjs(mzjs_in, mzjs_out);
                if (opt != 0)
                {
                    MessageBox.Show(mzjs_out.Message + "，门诊预结算失败！", "提示信息");
                    return;
                }
                lblInsurefee.Text = mzjs_out.Bctczfje;
                //insurefee = mzjs_out.Bctczfje;
                lblInsurefee.Text = mzjs_out.Bctczfje;
                //dgvCharge.Rows[i].Cells["fee"].Value = mzjs_out.Bcxjzfje;
                //reallfee = mzjs_out.Bcxjzfje;
                lblInsuraccountfee.Text = mzjs_out.Bcgrzhzfje;
                //Insuraccountfee = mzjs_out.Bcgrzhzfje;
                lblInsuraccountfee.Text = mzjs_out.Bcgrzhzfje;
            }
            else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDSCH.ToString().ToUpper().Trim())
            {
                //调用城合接口    邯郸市城合传输
                BllHdschClinic bllHdschClinic = new BllHdschClinic();
                bllHdschClinic.insurReg(insurInfo, register_id);
                int flag = bllHdschClinic.costdetTransfer(tbxClinicCode.Text, clinic_costdet_ids, insurInfo.PersonalNum);
                switch (flag)
                {
                    case 0: MessageBox.Show("传输成功！");
                        break;
                    case -1: MessageBox.Show("读取药品信息失败！");
                        return;
                    case -2: MessageBox.Show("读取诊疗信息失败！");
                        return;
                    case -3: MessageBox.Show("传入中间表失败！");
                        return;
                    case -4: MessageBox.Show("无可传输项！");
                        return;
                }
                //门诊预结算
                Mzjs_in mzjs_in = new Mzjs_in();
                mzjs_in.Djh = invoiceCode;//单据号
                mzjs_in.Grbh = insurInfo.PersonalNum;
                mzjs_in.Jbr = ProgramGlobal.User_id;
                mzjs_in.Mzzyh = tbxClinicCode.Text.Trim();
                mzjs_in.Yllb = insurInfo.Ihsptype;//医疗类别
                mzjs_in.Zffs = "";//支付方式
                Mzjs_out mzjs_out = new Mzjs_out();
                Hdsch hdsch = new Hdsch();
                int opt = hdsch.mzjs_yjs(mzjs_in, mzjs_out, insurInfo.PersonalNum);
                if (opt != 0)
                {
                    MessageBox.Show(mzjs_out.Message + "，门诊预结算失败！", "提示信息");
                    return;
                }
                lblInsurefee.Text = mzjs_out.Bctczfje;//统筹金额
                //insurefee = mzjs_out.Bctczfje;
                lblInsurefee.Text = mzjs_out.Bctczfje;
                //dgvCharge.Rows[i].Cells["fee"].Value = mzjs_out.Bcxjzfje;//实收金额
                //reallfee = mzjs_out.Bcxjzfje;
                lblInsuraccountfee.Text = mzjs_out.Bcgrzhzfje;//账户支付
                //Insuraccountfee = mzjs_out.Bcgrzhzfje;
                lblInsuraccountfee.Text = mzjs_out.Bcgrzhzfje;
            }
            else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDBHNH.ToString().ToUpper().Trim())
            {

            }
            else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDXBHNH.ToString().ToUpper().Trim())
            {

            }
            else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDXZRNH.ToString().ToUpper().Trim())
            {

            }
            else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HDZRNH.ToString().ToUpper().Trim())
            {

            }
            else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.HSDRYB.ToString().ToUpper().Trim())
            {
                //衡水数据传输
                BllClinMedinsrHSDR bllMedinsrHSDR = new BllClinMedinsrHSDR();
                bllMedinsrHSDR.insurReg(insurInfo, register_id);
                int flag = bllMedinsrHSDR.costdetTransfer(tbxClinicCode.Text.Trim(), clinic_costdet_ids, insurInfo.PersonalNum);
                if (flag == 0)
                {

                }
                else if (flag == -1)
                {
                    return;
                }
                //门诊预结算
                TopParameter common = new TopParameter();
                common.AKC190 = tbxClinicCode.Text.Trim();
                common.AKC020 = insurInfo.Iccardid;
                common.AKA130 = insurInfo.Ihsptype;
                common.AKB020 = ProgramGlobal.Othvar_2;
                common.MSGNO = "1107";
                common.MSGID = WYJK.getLsh();
                common.GRANTID = ProgramGlobal.Othvar_3;
                common.OPERID = ProgramGlobal.User_id;
                common.OPERNAME = ProgramGlobal.Username;
                common.BATNO = ProgramGlobal.Othvar_1;
                common.OPTTIME = BillSysBase.currDate();

                MTREG.medinsur.hsdryb.bo.KC21 kc21 = new MTREG.medinsur.hsdryb.bo.KC21();
                DataTable dt_r = bllMedinsrHSDR.getRegInfo(common.AKC190);
                kc21.AKC190 = common.AKC190;
                kc21.AKA130 = common.AKA130;
                kc21.AKC192 = dt_r.Rows[0]["AKC192"].ToString();
                kc21.AAE011 = ProgramGlobal.User_id;
                kc21.AAE036 = dt_r.Rows[0]["AAE036"].ToString();
                kc21.AKC008 = dt_r.Rows[0]["AKC008"].ToString();
                kc21.AKC025 = dt_r.Rows[0]["AKC025"].ToString();
                kc21.AKC031 = dt_r.Rows[0]["AKC031"].ToString();
                kc21.BKF050 = dt_r.Rows[0]["BKF050"].ToString();
                if (common.AKA130 == "13")//慢性病添加此项
                {
                    kc21.AKC193 = dt_r.Rows[0]["AKC193"].ToString(); ;
                }
                WYJK wyjk = new WYJK();
                var par = wyjk.mzfyyjs(common, kc21);
                if (par.ReturnNum != "-1")
                {
                    lblInsurefee.Text = par.AKC260;
                    //insurefee = par.AKC260;
                    lblInsurefee.Text = par.AKC260;
                    //dgvCharge.Rows[i].Cells["fee"].Value = par.AKC261;
                    //reallfee = par.AKC261;
                    lblInsuraccountfee.Text = par.AKC255;
                    //Insuraccountfee = par.AKC255;
                    lblInsuraccountfee.Text = par.AKC255;
                    //tbxRealFee.Text = par.AKC264;
                    //tbxAmount.Text = par.AKC264;
                }
                else
                {
                    MessageBox.Show("调用门诊医保预结算函数失败：" + par.ErrorMsg);
                }
            }
            else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.GYSYB.ToString().ToUpper().Trim())
            {
                Gysybservice gysyb = new Gysybservice();
                StringBuilder message = new StringBuilder(50);
                if (!gysyb.mzgh_kls(sybdk_entity, message))
                {
                    return;
                }


                double[] yb = new double[4];
                //医保模拟结算
                if (!gysyb.mzmnjs_kls2(sybdk_entity, clinic_costdet_ids, invoiceCode, message, yb))
                {
                    return;
                }
                //string cash = (double.Parse(tbxAmount.Text.Trim()) - yb[0] - yb[1]).ToString();
                lblInsurefee.Text = yb[1].ToString();
                //insurefee = yb[1].ToString();
                lblInsurefee.Text = yb[1].ToString();
                lblInsuraccountfee.Text = yb[0].ToString();
                //Insuraccountfee = yb[0].ToString();
                lblInsuraccountfee.Text = yb[0].ToString();
                //dgvCharge.Rows[i].Cells["fee"].Value = cash;
                //reallfee = cash;
            }
            else if (keyname.ToUpper().Trim() == CostInsurtypeKeyname.GZSYB.ToString().ToUpper().Trim())
            {

            }
            btnSett.Visible = true;
        }
        /// <summary>
        /// 患者类型改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPatienttype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            patientTypeChange();
        }
        private void patientTypeChange()
        {
            string patientType_id = cmbPatienttype.SelectedValue.ToString();
            BllInsur bllInsur = new BllInsur();
            string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())
            {

            }
            else if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
            {

            }
            else if (keyname == CostInsurtypeKeyname.HDSCH.ToString())
            {

            }
            else if (keyname == CostInsurtypeKeyname.HDBHNH.ToString())
            {
                MessageBox.Show("暂不支持该患者类型！");
                return;
            }
            else if (keyname == CostInsurtypeKeyname.HDSSY.ToString())
            {
                MessageBox.Show("暂不支持该患者类型！");
                return;
            }
            else if (keyname == CostInsurtypeKeyname.HDXBHNH.ToString())
            {
                MessageBox.Show("暂不支持该患者类型！");
                return;
            }
            else if (keyname == CostInsurtypeKeyname.HDXZRNH.ToString())
            {
                MessageBox.Show("暂不支持该患者类型！");
                return;
            }
            else if (keyname == CostInsurtypeKeyname.HDZRNH.ToString())
            {
                MessageBox.Show("暂不支持该患者类型！");
                return;
            }
            else if (keyname == CostInsurtypeKeyname.HSDRYB.ToString())
            {

            }
            else if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            {

            }
        }


    }
}
