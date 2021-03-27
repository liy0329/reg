using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using MTREG.medinsur.gysyb.bo;
using MTREG.medinsur.gysyb.bll;
using System.IO;
using MTREG.common;
using MTREG.common.bll;

namespace MTREG.medinsur.gysyb.clinic
{
    public partial class FrmClinicMedinsrGYSYB : Form
    {
        Gysybservice gysybservice = new Gysybservice();
        public FrmClinicMedinsrGYSYB()
        {
            InitializeComponent();
        }

        private Sybdk_Entity sybdk_entity;

        internal Sybdk_Entity Sybdk_entity
        {
            get { return sybdk_entity; }
            set { sybdk_entity = value; }
        }

        public bool flag;
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private Gysybdk gyyb;

        internal Gysybdk Gyyb
        {
            get { return gyyb; }
            set { gyyb = value; }
        }

        private void FrmClinicMedinsur_Load(object sender, EventArgs e)
        {
            initInsurType();//保险类别
            initPayType();//支付类别
            //initqsfs();//清算方式
            rbick.Checked = true;
            initSettleType();//结算方式初始化
            sybdk_entity = new Sybdk_Entity();
            //this.cmbgysyb_bxlb.Text = "企业基本医疗保险";

            //this.cmbgysyb_bxlb.DroppedDown = true;
        }
        /// <summary>
        /// 保险类别初始化
        /// </summary>
        public void initInsurType()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("企业基本医疗保险","1"));
            items.Add(new ListItem("企业离休医疗保险","2"));
            items.Add(new ListItem("机关事业单位基本医疗保险","3"));
            items.Add(new ListItem("企业生育保险","4"));
            items.Add(new ListItem( "机关事业单位生育保险","5"));
            items.Add(new ListItem("居民医保","6"));
            items.Add(new ListItem("工伤保险","7"));

            //items.Add(new ListItem("1", "企业基本医疗保险"));
            //items.Add(new ListItem("2", "企业离休医疗保险"));
            //items.Add(new ListItem("3", "机关事业单位基本医疗保险"));
            //items.Add(new ListItem("4", "机关事业单位生育保险"));
            //items.Add(new ListItem("5", "居民医保"));
            //items.Add(new ListItem("6", "省级收费标准"));
            //items.Add(new ListItem("7", "工伤保险"));
            cmbInsurType.DisplayMember = "Text";
            cmbInsurType.ValueMember = "Value";
            cmbInsurType.DataSource = items;
        }
        /// <summary>
        /// 初始化结算那方式
        /// </summary>
        public void initSettleType()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("按项目结算","0"));
            items.Add(new ListItem("单病种包干结算","1"));
            cbxSettleType.DisplayMember = "Text";
            cbxSettleType.ValueMember = "Value";
            cbxSettleType.DataSource = items;
        }
        /// <summary>
        /// 清算方式
        /// </summary>
        //public void initqsfs()
        //{ 
        //    List<ListItem> items = new List<ListItem>();
        //    items.Add(new ListItem("1", "控制线清算方式（生育保险中为非包干方式）"));
        //    items.Add(new ListItem("3", "单病种按人次定额包干清算方式"));
        //    items.Add(new ListItem("4", "单病种按日定额包干清算方式"));
        //    items.Add(new ListItem("2", "重症病种清算"));
        //    items.Add(new ListItem("5", "生育保险包干清算"));
        //    items.Add(new ListItem("6", "单病种包干清算"));
        //    zdbm.DisplayMember = "Text";
        //    zdbm.ValueMember = "Value";
        //    zdbm.DataSource = items; 
        //}
        /// <summary>
        /// 初始化支付类别
        /// </summary>
        public void initPayType()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("普通门诊","11"));
            items.Add(new ListItem("特殊门诊","18"));
            cmbPayType.DisplayMember = "Text";
            cmbPayType.ValueMember = "Value";
            cmbPayType.DataSource = items;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbxPersonalNum.Text.Equals(""))
            {
                this.flag = false;
                this.Dispose();
            }
            else
            {
                this.flag = true;
                this.Dispose();
            }
        }
        /// <summary>
        /// 获得个人信息
        /// </summary>
        public bool GetPersonalInformation()
        {

            Hqgrxx hqgrxx = new Hqgrxx();
            string instr = "";
            string ksxsdysj = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");//待遇开始享受时间
            ReadYbCard_entity readybcard = new ReadYbCard_entity();

            string[] parm = new string[11];
            instr += hqgrxx.Hqgrxx_head();
            if (cmbInsurType.SelectedValue.ToString() == "7" && !string.IsNullOrEmpty(tbxIndrsInjuryCode.Text.Trim()))//工商保险
            {
                parm[0] = sybdk_entity.Klb;  //卡类别
                parm[1] = sybdk_entity.Ctsj; //磁条数据
                parm[2] = sybdk_entity.Sfzhm;////社保卡卡号
                parm[3] = "192.168.0.52";// readybcard.ZdIp;//终端机IP地址(可选)
                parm[4] = sybdk_entity.Pasmkh;//PASM卡号  
                parm[5] = sybdk_entity.Mm;//密码
                parm[6] = cmbPayType.SelectedValue.ToString();//支付类别

            }
            else
            {
                if (rbck.Checked == true)
                {

                    readybcard.CarType = "1";
                    readybcard.cardId = tbxCardno.Text;
                    readybcard.SzPasswd = tbxCardPwd.Text;
                    if (!Dqybk(readybcard))
                    {
                        MessageBox.Show(readybcard.IERRInfo);
                        return false;
                    }
                }
                else if (rbick.Checked == true)
                {
                    if (!Dqybk(readybcard))
                    {
                        MessageBox.Show(readybcard.IERRInfo);
                        return false;
                    }
                }
                else if (rbidk.Checked == true)
                {
                    if (tbxIDNo.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("请输入身份证");
                        return false;
                    }
                    readybcard.CarType = "3";
                    readybcard.cardId = tbxCardno.Text;
                    readybcard.SzPasswd = tbxCardPwd.Text;
                    readybcard.icd_Id = tbxIDNo.Text;
                }
                parm[0] = readybcard.CarType;  //卡类别
                parm[1] = readybcard.cardId; //磁条数据
                parm[2] = readybcard.icd_Id;////社保卡卡号
                parm[3] = "192.168.0.52";// readybcard.ZdIp;//终端机IP地址(可选)
                parm[4] = readybcard.PSAMkh;//PASM卡号  
                parm[5] = readybcard.SzPasswd;//密码
                parm[6] = cmbPayType.SelectedValue.ToString();//支付类别
            }
            parm[7] = cmbInsurType.SelectedValue.ToString();//保险类别
            parm[8] = tbxSpcDiseCode.Text;//特种病编码(不确定)
            parm[9] = tbxIndrsInjuryCode.Text;//工伤认定编号
            parm[10] = ksxsdysj;//待遇开始享受时间






            instr += hqgrxx.Hqgrxx_in(parm);
            instr += hqgrxx.Hqgrxx_tail();
            SysWriteLogs.writeLogs1("贵阳市医保个人信息获取", Convert.ToDateTime(BillSysBase.currDate()), gysybservice.getInfo(instr));
            string outxml = gysybservice.getInfo(instr);


            StringReader sd = new StringReader(outxml);
            DataSet ds = new DataSet();
            ds.ReadXml(sd);
            string ztm = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            if (ztm.Equals("-1"))
            {
                MessageBox.Show(ds.Tables["DATA"].Rows[0]["INFO"].ToString()); //错误信息
                return false;
            }
            string PERSONCODE = ds.Tables["DATA"].Rows[0]["PERSONCODE"].ToString();//个人编码  
            string CENTERCODE = ds.Tables["DATA"].Rows[0]["CENTERCODE"].ToString();//分中心编码
            string PERSONNAME = ds.Tables["DATA"].Rows[0]["PERSONNAME"].ToString();//姓名
            string SEX = "";
            if (ds.Tables["DATA"].Rows[0]["SEX"].ToString().Equals("1"))  //性别
            {
                SEX = "男";

            }
            else if (ds.Tables["DATA"].Rows[0]["SEX"].ToString().Equals("2"))
            {
                SEX = "女";
            }
            else if (ds.Tables["DATA"].Rows[0]["SEX"].ToString().Equals("9"))
            {
                SEX = "未说明性别";
            }


            string PID = ds.Tables["DATA"].Rows[0]["PID"].ToString();//身份证号码
            string BIRTHDAY = ds.Tables["DATA"].Rows[0]["BIRTHDAY"].ToString();//出生日期
            string PERSONTYPE = ds.Tables["DATA"].Rows[0]["PERSONTYPE"].ToString();//人员类别
            string INSURETYPE = ds.Tables["DATA"].Rows[0]["INSURETYPE"].ToString();//保险类别
            string CAREPSNFLAG = ds.Tables["DATA"].Rows[0]["CAREPSNFLAG"].ToString();//医疗照顾人员标志
            string DEPTCODE = ds.Tables["DATA"].Rows[0]["DEPTCODE"].ToString();//单位编码
            string DEPTNAME = ds.Tables["DATA"].Rows[0]["DEPTNAME"].ToString();//单位名称
            string ACCTBALANCE = ds.Tables["DATA"].Rows[0]["ACCTBALANCE"].ToString();//账户余额
            string HOSPTIMES = ds.Tables["DATA"].Rows[0]["HOSPTIMES"].ToString();//本年住院次数
            string STARTFEE = ds.Tables["DATA"].Rows[0]["STARTFEE"].ToString();//本次起付线
            string STARTFEEPAID = ds.Tables["DATA"].Rows[0]["STARTFEEPAID"].ToString();//本年已支付起付线
            string FUND1LMT = ds.Tables["DATA"].Rows[0]["FUND1LMT"].ToString();//基本统筹限额
            string FUND1PAID = ds.Tables["DATA"].Rows[0]["FUND1PAID"].ToString();//本年已支付基本统筹
            string FUND2LMT = ds.Tables["DATA"].Rows[0]["FUND2LMT"].ToString();//大额统筹限额
            string FUND2PAID = ds.Tables["DATA"].Rows[0]["FUND2PAID"].ToString();//本年已支付大额统筹
            string FUND3LMT = ds.Tables["DATA"].Rows[0]["FUND3LMT"].ToString();//本年普通门诊医疗补助限额
            string FUND3PAID = ds.Tables["DATA"].Rows[0]["FUND3PAID"].ToString();//本年普通门诊医疗补助累计
            string STARTFEE2STD = ds.Tables["DATA"].Rows[0]["STARTFEE2STD"].ToString();//普通门诊医疗补助起付标准
            string FUND75BALANCE = ds.Tables["DATA"].Rows[0]["FUND75BALANCE"].ToString();//普通门诊医疗补助结转可使用金额
            string LOCKINFO = ds.Tables["DATA"].Rows[0]["LOCKINFO"].ToString();//封锁信息
            string NOTE = ds.Tables["DATA"].Rows[0]["NOTE"].ToString();//备注

            tbxPersonalNum.Text = PERSONCODE;//个人编码
            tbCenterCode.Text = CENTERCODE;//分中心编码
            tbxPersonalType.Text = PERSONTYPE;//人员类别
            tbxCarePeople.Text = CAREPSNFLAG;//医疗照顾人员标志
            tbxName.Text = PERSONNAME;//姓名
            tbxSex.Text = SEX;//性别
            tbxIDNo.Text = PID;//身份证号码
            dtpBirth.Text = BIRTHDAY;//出生日期
            tbxCompanyNum.Text = DEPTCODE;//单位编码
            tbxCompanyName.Text = DEPTNAME;//单位名称
            tbxBalance.Text = ACCTBALANCE;//账户余额
            tbxPayYear.Text = "";//缴费年度
            tbxgysyb_zycs.Text = HOSPTIMES;//本年住院次数
            tbxgysyb_qfx.Text = STARTFEE;//本次起付线
            tbxgysyb_yzfqfx.Text = STARTFEEPAID;//本年已支付起付线
            tbxgysyb_jbtcxe.Text = FUND1LMT;//基本统筹限额
            tbxgysyb_tczflj.Text = FUND1PAID;//本年已支付基本统筹(统筹支付累计)
            tbxgysyb_detcxe.Text = FUND2LMT;//大额统筹限额
            tbxgysyb_dezflj.Text = FUND2PAID;//本年已支付大额统筹(大额支付累计)
            tbxgysyb_ptmzylbzxe.Text = FUND3LMT;//本年普通门诊医疗补助限额
            tbxgysyb_ptmzylbzlj.Text = FUND3PAID;//本年普通门诊医疗补助累计
            tbxgysyb_ptmzylbzqfbz.Text = STARTFEE2STD;//普通门诊医疗补助起付标准
            tbxgysyb_ptmzylbzqfx.Text = STARTFEE2STD;//普通门诊医疗补助起付线
            tbxgysyb_ptmzylbzjzksy.Text = FUND75BALANCE;//普通门诊医疗补助结转可使用金额
            tbxIsBlock.Text = LOCKINFO;//封锁信息

            tbxgysyb_bz.Text = NOTE;//备注

            //this.gyyb.Klb = readybcard.CarType;//卡类别
            //this.gyyb.Ctsj = readybcard.cardId;//磁条数据
            //this.gyyb.Shbxh = readybcard.cardId;//社会保障号
            //this.gyyb.ZdjIPdz = readybcard.ZdIp;//终端机IP地址(可选)
            //this.gyyb.PASMkh1 = readybcard.PSAMkh;//PASM卡号
            //this.gyyb.Mm = readybcard.SzPasswd;//密码
            //this.gyyb.Zflb = cmbgysyb_zflb.SelectedValue.ToString();//支付类别
            //this.gyyb.Bxlb = cmbgysyb_bxlb.SelectedValue.ToString();//保险类别

            this.sybdk_entity.Xtclsj = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
            this.sybdk_entity.Grbh = PERSONCODE;//个人编码
            this.sybdk_entity.Fzxbm = CENTERCODE;//分中心编码
            this.sybdk_entity.Xm = PERSONNAME;//PERSONNAME
            this.sybdk_entity.Xb = SEX;//性别
            this.sybdk_entity.Sfzhm = PID;//身份证号码
            this.sybdk_entity.Csrq = BIRTHDAY;//出生日期
            this.sybdk_entity.Rylb = PERSONTYPE;//人员类别
            this.sybdk_entity.Bxlb = INSURETYPE;//保险类别
            this.sybdk_entity.Ylzgrybz = CAREPSNFLAG;//医疗照顾人员标志
            this.sybdk_entity.Dwbm = DEPTCODE;//单位编码
            this.sybdk_entity.Dwmc = DEPTNAME;//单位名称
            this.sybdk_entity.Zhye = ACCTBALANCE;//账户余额
            this.sybdk_entity.Bnzycs = HOSPTIMES;//本年住院次数
            this.sybdk_entity.Bcqfx = STARTFEE;//本次起付线
            this.sybdk_entity.Bnyzfdetc = STARTFEEPAID;//本年已支付起付线
            this.sybdk_entity.Jbtcxe = FUND1LMT;//基本统筹限额
            this.sybdk_entity.Bnyzfdetc = FUND1PAID;//本年已支付基本统筹
            this.sybdk_entity.Detcxe = FUND2LMT;//大额统筹限额
            this.sybdk_entity.Bnyzfdetc = FUND2PAID;//本年已支付大额统筹
            this.sybdk_entity.Bnptmzylbzye = FUND3LMT;//本年普通门诊医疗补助限额
            this.sybdk_entity.Bnptmzylbzlj = FUND3PAID;//本年普通门诊医疗补助累计
            this.sybdk_entity.Ptmzylbzqfbz = STARTFEE2STD;//普通门诊医疗补助起付标准
            this.sybdk_entity.Ptmzylbzjzksyje = FUND75BALANCE;//普通门诊医疗补助结转可使用金额
            this.sybdk_entity.Fsxx = LOCKINFO;//封锁信息
            this.sybdk_entity.Bz = NOTE;//备注
            //this.sybdk_entity.Qsfs = zdbm.SelectedValue.ToString();//清算方式

            this.sybdk_entity.Klb = parm[0];//卡类别
            this.sybdk_entity.Ctsj = parm[1];//磁条数据
            this.sybdk_entity.Mm = parm[5];//密码
            this.sybdk_entity.Zdjipdz = parm[3];//终端机IP地址
            this.sybdk_entity.Pasmkh = parm[4];//pasm卡号
            this.sybdk_entity.Zflb = parm[6];//支付类别
            this.sybdk_entity.Gsrd = tbxIndrsInjuryCode.Text;//工伤认定编号
            this.sybdk_entity.Gsrdbh = tbxIndrsInjuryCode.Text;//工伤认定编号
            this.sybdk_entity.Tbzbm = tbxSpcDiseCode.Text;//特病种编码
            this.sybdk_entity.Dbzbm = tbxSingleDiseaCode.Text;//单病种编码
            this.sybdk_entity.Jsfs = cbxSettleType.SelectedValue.ToString();//结算方式
            this.sybdk_entity.Cfbh = tbxRcpCode.Text;//处方编号
            //this.sybdk_entity.Sfzhm = readybcard.icd_Id;//社会保障号


            return true;

        }
        /// <summary>
        /// 读取医保卡号
        /// </summary>
        public bool Dqybk(ReadYbCard_entity readybcard)
        {
            int iCardType = 0;//卡类型
            if (rbck.Checked == true)
            {
                iCardType = 1;
            }
            else if (rbick.Checked == true)
            {
                iCardType = 2;
            }
            else if (rbidk.Checked == true)
            {
                iCardType = 3;
            }
            readybcard.CarType = iCardType.ToString();
            if (!ReadCardYb.ReadCard(readybcard, iCardType))
            {
                return false;
            }
            tbxCardno.Text = readybcard.cardId;//卡号
            tbxCardPwd.Text = readybcard.SzPasswd;//密码
            return true;
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.flag = false;
            this.Dispose();
        }
        /// <summary>
        /// 提取个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            
            if(!GetPersonalInformation())
            {
                return;
            }
        }

        private void rbck_CheckedChanged(object sender, EventArgs e)
        {
            tbxCardno.ReadOnly = false;
            tbxCardPwd.ReadOnly = false;
            tbxCardno.Focus();
        }

        private void rbick_CheckedChanged(object sender, EventArgs e)
        {
            tbxCardno.ReadOnly = false;
            tbxCardPwd.ReadOnly = false;
        }

        private void rbidk_CheckedChanged(object sender, EventArgs e)
        {
            tbxIDNo.ReadOnly = false;
            tbxCardno.ReadOnly = false;
            tbxCardPwd.ReadOnly = false;
        }

        private void btnIndrsInjuryInfo_Click(object sender, EventArgs e)
        {
            if (cmbInsurType.SelectedValue.ToString() == "7")//保险类别==工商保险
            {
                StringBuilder message = new StringBuilder();

                //读卡                               

                ReadYbCard_entity readybcard = new ReadYbCard_entity();

                if (rbck.Checked == true)//磁卡
                {

                    readybcard.CarType = "1";
                    readybcard.cardId = tbxCardno.Text;
                    readybcard.SzPasswd = tbxCardPwd.Text;
                }
                else if (rbidk.Checked == true)//身份证
                {
                    if (tbxIDNo.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("请输入身份证");
                        return;
                    }
                    readybcard.CarType = "3";
                    readybcard.cardId = tbxCardno.Text;
                    readybcard.SzPasswd = tbxCardPwd.Text;
                    readybcard.icd_Id = tbxIDNo.Text;
                }

                if (!Dqybk(readybcard))
                {
                    MessageBox.Show(readybcard.IERRInfo);
                    return;
                }
                string[] param = new string[7];

                param[0] = readybcard.CarType;  //卡类别
                param[1] = readybcard.cardId; //磁条数据
                param[2] = readybcard.icd_Id;////社保卡卡号
                param[3] = "192.168.0.52";// readybcard.ZdIp;//终端机IP地址(可选)
                param[4] = readybcard.PSAMkh;//PASM卡号  
                param[5] = readybcard.SzPasswd;//密码
                param[6] = cmbPayType.SelectedValue.ToString();//支付类别

                List<Gsrdxx> gsrdxxs = gysybservice.Hqgrxx(param,message);
                if (gsrdxxs.Count == 0)
                {
                    MessageBox.Show(message.ToString());
                    return;
                }
                else
                {
                    dgvIndrsInjury.DataSource = gsrdxxs;
                    dgvIndrsInjury.Visible = true;
                }
                return;
            }
        }
        /// <summary>
        /// 工伤险种选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbInsurType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInsurType.SelectedValue == "7")
                btnIndrsInjuryInfo.Visible = true;
            else
                btnIndrsInjuryInfo.Visible = false;
        }

        private void tbxRcpCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnGetInfo.Focus();//提取信息
            }
        }

        private void tbxSpcDiseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.tbxRcpCode.Focus();
            }
        }

        private void cmbPayType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string value = cmbPayType.SelectedValue.ToString();
                if (value == "11")
                {
                    this.btnGetInfo.Focus();
                }
                else if (value == "18")
                {
                    this.tbxSpcDiseName.Focus();
                }
            }
        }

        private void cmbInsurType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbPayType.Focus();
                this.cmbPayType.DroppedDown = true;
            }
        }

        private void dgvIndrsInjury_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvIndrsInjury.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvIndrsInjury.CurrentRow != null)
                {
                    tbxIndrsInjuryCode.Text = dgvIndrsInjury.SelectedRows[0].Cells["code"].Value.ToString();
                    dgvIndrsInjury.Visible = false;
                    dgvIndrsInjury.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvIndrsInjury.CurrentRow != null && dgvIndrsInjury.CurrentRow.Index > 0)
                {
                    dgvIndrsInjury.Rows[dgvIndrsInjury.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvIndrsInjury.CurrentRow != null && dgvIndrsInjury.CurrentRow.Index < dgvIndrsInjury.Rows.Count - 1)
                {
                    dgvIndrsInjury.Rows[dgvIndrsInjury.CurrentRow.Index + 1].Selected = true;
                }
            }
        }

        private void dgvIndrsInjury_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvIndrsInjury.Focus();
                tbxIndrsInjuryCode.Text = dgvIndrsInjury.Rows[e.RowIndex].Cells["code"].Value.ToString();
                dgvIndrsInjury.Visible = false;
            }
        }

        private void tbxPersonalNum_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
