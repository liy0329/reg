using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.ihsp.bll;
using System.Web.UI.WebControls;

namespace MTREG.medinsur.gzsyb.ihsp
{
    public partial class FrmIhspOutRetGZS : Form
    {
        public FrmIhspOutRetGZS()
        {
            InitializeComponent();
        }
        BllInsurIhspGZS bllInsurIhsp = new BllInsurIhspGZS();
        private string ihspid;

        public string Ihspid
        {
            get { return ihspid; }
            set { ihspid = value; }
        }
        private bool flag;
        /// <summary>
        /// 成功标志
        /// </summary>
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        } 
        /// <summary>
        /// 界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspOutRetGZS_Load(object sender, EventArgs e)
        {
            DataTable dt = bllInsurIhsp.getOutIhspRetInfo(ihspid);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("未查询到该患者的医保信息！");
                return;
            }
            string personinfos = dt.Rows[0]["registedinfo"].ToString();
            //就诊编号|分中心编号|支付类别|个人编号|姓名|性别|身份证号|单位编码|单位名称|人员状态|实足年龄|社会保险办法
            string[] personinfo = personinfos.Split('|');
            string billcode = personinfo[0];//就诊编号
            string personCode = personinfo[1];//个人编号
            string payType = personinfo[0];//支付类别
            string centerCode = personinfo[9];//分中心编号
            string socialInsurWay = personinfo[5];//社会保险办法
            tbxBillCode.Text = billcode;
            tbxPersonCode.Text = personCode;
            tbxCenterCode.Text = centerCode;
            tbxSocietyInsurWay.Text = socialInsurWay;
            cmbPayType.SelectedValue = payType;
            initPayType();
        }
        /// <summary>
        /// 初始化支付类别
        /// </summary>
        public void initPayType()
        {
            List<ListItem> items = new List<ListItem>();
            //items.Add(new ListItem("11", "普通门诊"));
            //items.Add(new ListItem("18", "特殊门诊"));
            //items.Add(new ListItem("G11", "(工伤)普通门诊"));
            //items.Add(new ListItem("M11", "门诊产前检查"));
            //items.Add(new ListItem("M12", "门诊流产费用支付"));
            //items.Add(new ListItem("M13", "门诊计划生育手术支付"));
            items.Add(new ListItem("31", "普通住院"));
            items.Add(new ListItem("G31", "(工伤)普通住院"));
            items.Add(new ListItem("M31", "分娩住院"));
            items.Add(new ListItem("31", "计划生育手术住院"));
            items.Add(new ListItem("31", "生育终止妊娠计划生育手术并发症住院"));
            cmbPayType.DisplayMember = "Text";
            cmbPayType.ValueMember = "Value";
            cmbPayType.DataSource = items;
        }
        /// <summary>
        /// 点击确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbxSocietyInsurWay.Text == "")
            {
                MessageBox.Show("社会保险办法不能为空！");
                return;
            }
            if (tbxCenterCode.Text == "")
            {
                MessageBox.Show("分中心编码不能为空！");
                return;
            }
            flag = bllInsurIhsp.retIhspOut(ihspid) == true;
            if (flag)
            {
                MessageBox.Show("出院医保办理成功！");
                this.Dispose();
                return;
            }
            else
            {
                MessageBox.Show("出院医保办理失败！");
                this.Dispose();
                return;
            }
        }
        /// <summary>
        /// 点击取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Dispose();
            return;
        }
    }
}
