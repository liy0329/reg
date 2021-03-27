using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using MTREG.medinsur.gzsnh.bll;
using System.Web.UI.WebControls;
using MTREG.ihsp;
using MTREG.medinsur.gzsnh.bo;
using MTREG.medinsur.bll;

namespace MTREG.medinsur.gzsnh
{
    public partial class FrmGzsnhAcc : Form
    {
        FrmGzsnhAccount frmGzsnhAccount;

        public FrmGzsnhAccount FrmGzsnhAccount
        {
            get { return frmGzsnhAccount; }
            set { frmGzsnhAccount = value; }
        }

        public void getSource(string id)
        {
            this.ihsp_id = id;
          //  DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
         
        }
        string type = "1";
        private string ihsp_id;
        /// <summary>
        /// 住院记录Id
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        /// <summary>
        /// 预交款
        /// </summary>
        private string payfee;

        public string Payfee
        {
            get { return payfee; }
            set { payfee = value; }
        }
        private string costfee;
        /// <summary>
        /// 费用
        /// </summary>
        public string Costfee
        {
            get { return costfee; }
            set { costfee = value; }
        }



        public FrmGzsnhAcc()
        {
            InitializeComponent();
        }

       

      

        private void doAccount( string redeemNo)
        {
            WebClient webClient = new WebClient();
            BllInsurMethod bllInsurMethod = new BllInsurMethod();
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
           
            string isMaterials = cmbIsMaterials.SelectedValue.ToString();
            Dictionary<string, string> result = new Dictionary<string, string>();
            Dictionary<int, string> gradeList = new Dictionary<int, string>();
            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = bllGzsnhMethod.readRegInfo(ihsp_id);
            string url = GzsnhGlobal.Url + "inpatientCalculate?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "&redeemNo=" + Base64.encodebase64(redeemNo) + "&outDate=" + Base64.encodebase64(dtpOhspTime.Value.ToString()) + "&type=" + Base64.encodebase64(type) + "&isMaterials=" + Base64.encodebase64(cmbIsMaterials.SelectedValue.ToString()) + "&operationName=" + Base64.encodebase64("") + "";
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                try
                {
                    string[] info = param.Replace("\"", "").Replace(",gradeList:", "@").Split('@');
                    string[] firstp = info[0].Replace("{", "").Replace("}", "").Split(',');
                    for (int i = 0; i < firstp.Length; i++)
                    {
                        string[] item = firstp[i].Split(':');
                        result.Add(item[0], Base64.decodebase64(item[1]));
                    }

                    this.tbxAccountInfo.Text = "成员编码:" + result["memberNo"] + "\t成员姓名:" + result["name"] + "\t医疗证、卡号:" + result["bookNo"] + "\t性别:" + result["sexName"] + "\r\n出生年月日:" + result["birthday"] + "\t户主姓名:" + result["masterName"] + "";
                    this.tbxAccountInfo.Text += "\t与户主关系名称:" + result["relationName"] + "\t个人身份属性名称:" + result["identityName"] + "\r\n身份证号码:" + result["idCard"] + "\r\n当前年度成员住院已补偿次数:" + result["currYearRedeemCount"] + "\t当前年度成员住院已补偿总医疗费用:" + result["currYearTotal"] + "\r\n当前年度成员住院已补偿总保内费用:" + result["currYearEnableMoney"] + "";
                    this.tbxAccountInfo.Text += "当前年度成员住院已补偿金额:" + result["currYearReddemMoney"] + "\r\n家庭编码:" + result["familyNo"] + "\t家庭住址:" + result["address"] + "\t参合属性:" + result["joinPropName"] + "\r\n当前年度家庭住院已补偿次数:" + result["currFamilyRedeemCount"] + "\t当前年度家庭住院已补偿总医疗费用:" + result["currFamilyTotal"] + "\r\n";
                    this.tbxAccountInfo.Text += "当前年度家庭住院已补偿保内费用:" + result["currFamilyEnableMoney"] + "\t当前年度家庭住院已补偿金额:" + result["currFamilyReddemMoney"] + "\r\n本次住院总医疗费用:" + result["totalCosts"] + "\t本次住院保内费用:" + result["enableMoney"] + "\r\n本次住院费用中国定基本药品费用:" + result["essentialMedicineMoney"] + "\t本次住院费用中省补基本药品费用:" + result["provinceMedicineMoney"] + "\r\n";
                    this.tbxAccountInfo.Text += "本次住院补偿扣除起付线金额:" + result["startMoney"] + "\t本次住院补偿金额:" + result["calculateMoney"] + "\t补偿类型名称:" + result["redeemTypeName"] + "\r\n是否为单病种补偿:" + result["isSpecial"] + "\t是否实行保底补偿:" + result["isPaul"] + "\r\n追补金额，中药和国定基本药品提高补偿额部分:" + result["anlagernMoney"] + "\r\n";
                    this.tbxAccountInfo.Text += "单病种费用定额:" + result["fundPayMoney"] + "\t医疗机构承担费用:" + result["hospAssumeMoney"] + "\t重大疾病个人自付费用:" + result["personalPayMoney"] + "\r\n民政优抚医疗补助:" + result["YFmedicalAid"] + "\t民政城乡医疗救助:" + result["CXmedicalAid"] + "\t高额材料限价超额费用:" + result["materialMoney"] + "\r\n";
                    this.tbxAccountInfo.Text += "本次结算计算方法：" + result["calculationMethod"] + "\t慈善总会支付金额:" + result["ChinaCharityPay"] + "\t是否长周期定额付费:" + result["isLongPeriod"] + "\t是否进入大病保险:" + result["isCII"] + "\t大病保险合规费用:" + result["CIIEligibleCosts"] + "\t本次大病保险起付线:" + result["CIIStartMoney"] + "\r\n";
                    this.tbxAccountInfo.Text += "本次大病保险补偿金额:" + result["CIICalculateMoney"] + "\t累计大病保险补偿额:" + result["CIICumulativePay"] + "\t累计大病保险扣除起付线金额:" + result["CIICumulativeStart"] + "\t累计进入大病保险合规费用:" + result["CIICumulativeEligible"] + "\t计生两户减免费用金额:" + result["FamilyPlanningWaiver"];
                    double nhbx = Convert.ToDouble(result["calculateMoney"]);
                    //民政优抚医疗补助
                    double mzbz = 0;
                    if (result["YFmedicalAid"] != "")
                        mzbz = Convert.ToDouble(result["YFmedicalAid"]);
                    //民政城乡医疗救护
                    double cxbz = 0;
                    if (result["CXmedicalAid"] != "")
                        cxbz = Convert.ToDouble(result["CXmedicalAid"]);
                    //本次大病保险补偿金额
                    double dbbx = 0;
                    if (result["CIICalculateMoney"] != "")
                        dbbx = Convert.ToDouble(result["CIICalculateMoney"]);
                    //慈善总会支付金额
                    double csbz = 0;
                    if (result["ChinaCharityPay"] != "")
                        csbz = Convert.ToDouble(result["ChinaCharityPay"]);
                    //计生两户减免费用金额
                    double jsbz = 0;
                    if (result["FamilyPlanningWaiver"] != "")
                        jsbz = Convert.ToDouble(result["FamilyPlanningWaiver"]);

                    double zbx = nhbx + mzbz + cxbz + dbbx + csbz + jsbz;
                    this.tbxNhbx.Text = zbx.ToString("0.00");
                    this.tbxNhCost.Text = result["totalCosts"];
                    this.tbxFee.Text = (Convert.ToDouble(this.tbxHspCost.Text) - Convert.ToDouble(this.tbxPayinadv.Text) - Convert.ToDouble(this.tbxNhbx.Text)).ToString();
                    string[] secondp = info[1].Replace("[", "").Replace("]", "").Replace("},{", "@").Replace("{", "").Replace("}", "").Split('@');
                    dgvGradeResult.Rows.Clear();
                    for (int j = 0; j < secondp.Length; j++)
                    {
                        if (secondp[j] == "")
                        {
                            continue;
                        }
                        string[] item1 = secondp[j].Split(',');
                        for (int k = 0; k < item1.Length; k++)
                        {
                            string[] item2 = item1[k].Split(':');
                            gradeList.Add(k, Base64.decodebase64(item2[1]));
                        }
                        dgvGradeResult.Rows.Add();
                        for (int l = 0; l < gradeList.Count; l++)
                        {
                            dgvGradeResult.Rows[j].Cells[l].Value = gradeList[l];
                        }
                        gradeList.Clear();
                    }
                    if (redeemNo.Equals("2"))
                    {
                        int flag = bllInsurMethod.upInsurinfoFee(ihsp_id, result["calculateMoney"], (double.Parse(result["totalcosts"]) - double.Parse(result["startmoney"])).ToString());
                        if (flag < 0)
                        {
                            MessageBox.Show("费用更新失败!");
                            return;
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("下载失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
        }

        private void FrmGzsnhAcc_Load(object sender, EventArgs e)
        {
            init();
        }
        public void init()
        {
            List<ListItem> sfcl = new List<ListItem>();
            ListItem sfcl1 = new ListItem("0", "未提供");
            ListItem sfcl2 = new ListItem("1", "已提供");
            //ListItem sfcl3 = new ListItem("-1", "");
            sfcl.Add(sfcl1);
            sfcl.Add(sfcl2);
            //sfcl.Add(sfcl3);
            cmbIsMaterials.DisplayMember = "Text";
            cmbIsMaterials.ValueMember = "Value";
            cmbIsMaterials.DataSource = sfcl;
            cmbIsMaterials.SelectedIndex = 1;

            List<ListItem> jsskfs = new List<ListItem>();
            ListItem jsskfs1 = new ListItem("144", "现金");
            ListItem jsskfs2 = new ListItem("146", "银行卡");
            ListItem jsskfs3 = new ListItem("166", "支票");
            jsskfs.Add(jsskfs1);
            jsskfs.Add(jsskfs2);
            jsskfs.Add(jsskfs3);
            cmbPayType.DisplayMember = "Text";
            cmbPayType.ValueMember = "Value";
            cmbPayType.DataSource = jsskfs;
            cmbPayType.SelectedIndex = 0;

            List<ListItem> bclx = new List<ListItem>();
            ListItem bclx1 = new ListItem("21", "普通住院");
            ListItem bclx2 = new ListItem("22", "正常分娩住院(定额补偿)");
            ListItem bclx3 = new ListItem("13", "体格检查");
            ListItem bclx4 = new ListItem("99", "其他");
            jsskfs.Add(bclx1);
            jsskfs.Add(bclx2);
            jsskfs.Add(bclx3);
            jsskfs.Add(bclx4);
            cmbPayType.DisplayMember = "Text";
            cmbPayType.ValueMember = "Value";
            cmbPayType.DataSource = bclx;
            //cmbPayType.SelectedIndex = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxNhbx.Text))
            {
                MessageBox.Show("请先预结算后，再点击确定");
                this.btnPreAccount.Enabled = false;
                return;
            }
            if (this.tbxHspCost.Text.ToString() != this.tbxNhCost.Text.ToString())
            {
                MessageBox.Show("医院费用与农合费用不一致，不能进行结算");
                this.btnPreAccount.Enabled = false;
                return;
            }
            cmbRedeemNo.SelectedValue = "2";
            doAccount(cmbRedeemNo.SelectedValue.ToString());
        }

        private void btnPreAccount_Click(object sender, EventArgs e)
        {
            //cmbRedeemNo.SelectedValue = "1";
            //doAccount(cmbRedeemNo.SelectedValue.ToString());
            this.Close();
            this.frmGzsnhAccount.Close();
            
        }
    }
}
