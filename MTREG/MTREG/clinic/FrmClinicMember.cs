using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.clinic.bo;
using MTREG.common;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.dor;

namespace MTREG.clinic
{
    public partial class FrmClinicMember : Form
    {
        public FrmClinicMember()
        {
            InitializeComponent();
        }
   
        /// <summary>
        /// 查找方法
        /// </summary>
        public void searchMethod( string uid )
        {
            Member member = new Member();
            member.Mzfare = uid;
            member.Idcard = tbxIdcard.Text;
            member.Mobile = tbxMobile.Text;
            member.Name = tbxName.Text;
            string cardstat=cmbCardstat.Text;
            switch (cardstat)
            {
                case "--全部--": cardstat = ""; break;
                case "作废": cardstat = MemberCardStat.XX.ToString(); break;
                case "未使用": cardstat = MemberCardStat.NO.ToString(); break;
                case "激活": cardstat = MemberCardStat.YES.ToString(); break;
                case "挂失": cardstat = MemberCardStat.LOSS.ToString(); break;
                case "冻结": cardstat = MemberCardStat.LOCK.ToString(); break;
            }
            member.Cardstat = cardstat;
            BillMember billMember = new BillMember();
            DataTable dt = new DataTable();
            if (!String.IsNullOrEmpty(member.Mzfare))
            {
                dt = billMember.memberSearch(member, "", "");
            }
            else
            {
                //DateTime.Now.ToString()).AddMonths(-3)
                dt = billMember.memberSearch(member, this.dtp_begin.Value.ToString("yyyy-MM-dd 00:00:00"), this.dtp_end.Value.ToString("yyyy-MM-dd 23:59:59"));
            }
                for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["cardstat"].ToString())
                {
                    case "XX": dt.Rows[i]["cardstat"] = "作废 "; break;
                    case "NO": dt.Rows[i]["cardstat"] = "未使用"; break;
                    case "YES": dt.Rows[i]["cardstat"] = "激活"; break;
                    case "LOSS": dt.Rows[i]["cardstat"] = "挂失"; break;
                    case "LOCK": dt.Rows[i]["cardstat"] = "冻结"; break;
                }
            }
            dgvMember.DataSource = dt;
            #region  dgvMember单元格标题设置
            dgvMember.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvMember.Columns["hspcard"].HeaderText = "会员卡号";
            this.dgvMember.Columns["hspcard"].Width = 130;
            this.dgvMember.Columns["name"].HeaderText = "姓名";
            this.dgvMember.Columns["name"].Width = 90;
            this.dgvMember.Columns["sex"].HeaderText = "性别";
            this.dgvMember.Columns["sex"].Width = 50;
            this.dgvMember.Columns["birthday"].HeaderText = "出生年月";
            this.dgvMember.Columns["birthday"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvMember.Columns["birthday"].Width = 130;
            this.dgvMember.Columns["idcard"].HeaderText = "身份证号";
            this.dgvMember.Columns["idcard"].Width = 170;
            this.dgvMember.Columns["cardstat"].HeaderText = "状态";
            this.dgvMember.Columns["cardstat"].Width = 90;
            this.dgvMember.Columns["mobile"].HeaderText = "电话";
            this.dgvMember.Columns["mobile"].Width = 150;
            this.dgvMember.Columns["balance"].HeaderText = "余额";
            this.dgvMember.Columns["balance"].Width = 110;
            this.dgvMember.Columns["createdate"].HeaderText = "办卡日期";
            this.dgvMember.Columns["createdate"].Width = 130;
            this.dgvMember.Columns["createdate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvMember.Columns["id"].HeaderText = "id";
            this.dgvMember.Columns["id"].Visible = false;
            #endregion
        }

        /// <summary>
        /// 查找按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchMethod("");
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMember_Load(object sender, EventArgs e)
        {
            #region  cmbCardstart设置
            cmbCardstat.Items.Add("作废");
            cmbCardstat.Items.Add("未使用");
            cmbCardstat.Items.Add("激活");
            cmbCardstat.Items.Add("挂失");
            cmbCardstat.Items.Add("冻结");
            cmbCardstat.Items.Add("--全部--");
            cmbCardstat.Text = "激活";
            #endregion

            Member member =new Member();
            BillMember billMember=new BillMember();
            searchMethod("");            
            this.dgvMember.ReadOnly = true;
            this.dgvMember.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 制卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeCard_Click(object sender, EventArgs e)
        {
            FrmMakeCard frmMakeCard = new FrmMakeCard();
            frmMakeCard.getSource("","false");
            frmMakeCard.ShowDialog();
            if (frmMakeCard.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
        }

        /// <summary>
        /// 补卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemakeCard_Click(object sender, EventArgs e)
        {
            if (dgvMember.SelectedRows.Count == 0 && dgvMember.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmMakeCard frmMakeCard = new FrmMakeCard();
            string id = dgvMember.SelectedRows[0].Cells["id"].Value.ToString();
            frmMakeCard.getSource(id, "true");
            frmMakeCard.ShowDialog();
            if (frmMakeCard.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
        }

        /// <summary>
        /// 充值按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemRe_Click(object sender, EventArgs e)
        {
            getmzfare();
            if (dgvMember.SelectedRows.Count == 0 && dgvMember.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmMemRe frmMemRe = new FrmMemRe();
            string id = dgvMember.SelectedRows[0].Cells["id"].Value.ToString();
            frmMemRe.getSource(id);
            frmMemRe.ShowDialog();
            if (frmMemRe.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
            //会员充值打印
            
        }
        /// <summary>
        /// 打印
        /// </summary>
        //private void MemberPrint()
        //{
        //    YBCJ_IN hy_yjj_cz = new YBCJ_IN();
           
        //    BillMember ss = new BillMember();
        //    string[] hyyjjcz = hy_yjj_cz.Cc.Split('|');
        //    string in_zfc1="";
        //    in_zfc1 += hyyjjcz[1]+ "|";//姓名
        //    in_zfc1 += hyyjjcz[2] + "|";//性别
        //    in_zfc1 += hyyjjcz[3] + "|";//ID号
        //    in_zfc1 += hyyjjcz[4] + "|";//卡号
        //    in_zfc1 += hyyjjcz[5] + "|";//支付方式
        //    in_zfc1 += hyyjjcz[6] + "|";//费别  默认为自费
        //    in_zfc1 += hyyjjcz[7]+ "|";//交款金额
        //    in_zfc1 += hyyjjcz[8];//卡内余额
        //    in_zfc1 += hyyjjcz[9];//收款人
        //    in_zfc1 += hyyjjcz[10];//交款日期
        //    FrmDy hyddy = new FrmDy();
        //    hyddy.in_zfc = in_zfc1;
        //    hyddy.dy("mzzfyjj");
        //    MessageBox.Show("打印金额成功！");
        //}
        /// <summary>
        /// 取现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemEn_Click(object sender, EventArgs e)
        {
            getmzfare();
            if (dgvMember.SelectedRows.Count == 0 && dgvMember.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmMemEn frmMemEn = new FrmMemEn();
            string id = dgvMember.SelectedRows[0].Cells["id"].Value.ToString();
            frmMemEn.getSource(id);
            frmMemEn.ShowDialog();
            if (frmMemEn.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
        }

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemLock_Click(object sender, EventArgs e)
        {
            if (dgvMember.SelectedRows.Count == 0 && dgvMember.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmMemCardstatLock frmMemCardstatLock = new FrmMemCardstatLock();
            string id = dgvMember.SelectedRows[0].Cells["id"].Value.ToString();
            frmMemCardstatLock.getSource(id);
            frmMemCardstatLock.ShowDialog();
            if (frmMemCardstatLock.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
        }

        /// <summary>
        /// 退卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoCard_Click(object sender, EventArgs e)
        {
            getmzfare();
            if (dgvMember.SelectedRows.Count == 0 && dgvMember.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmNocard frmNocard = new FrmNocard();
            string id = dgvMember.SelectedRows[0].Cells["id"].Value.ToString();
            frmNocard.getSource(id);
            frmNocard.userfare = true;
            frmNocard.ShowDialog();
            if (frmNocard.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
        }

        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemYes_Click(object sender, EventArgs e)
        {
            if (dgvMember.SelectedRows.Count == 0 && dgvMember.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmMemCardstatYes FrmMemCardstatYes = new FrmMemCardstatYes();   
            string id = dgvMember.SelectedRows[0].Cells["id"].Value.ToString();
            FrmMemCardstatYes.getSource(id);
            FrmMemCardstatYes.ShowDialog();
            if (FrmMemCardstatYes.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
        }

        /// <summary>
        /// 账单查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRechargedet_Click(object sender, EventArgs e)
        {
            if (dgvMember.SelectedRows.Count == 0 && dgvMember.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmRechargedet frmRechargedet = new FrmRechargedet();
            string id = dgvMember.SelectedRows[0].Cells["id"].Value.ToString();
            frmRechargedet.member_id = id;
            //frmRechargedet.getSource(id);
            frmRechargedet.ShowDialog();
            if (frmRechargedet.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
        }

        private void dgvMember_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvMember.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvMember.RowHeadersDefaultCellStyle.Font, rectangle, dgvMember.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            
            tbxIdcard.Text = "";
            tbxMobile.Text = "";
            tbxName.Text = "";
            cmbCardstat.Text = "激活";
            searchMethod("");
        }

        private void tbxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchMethod("");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getmzfare();
        }
        /// <summary>
        /// 读卡查询
        /// </summary>
        public void getmzfare()
        {
            Mifare dk = new Mifare();
            dk.OpenPoint();
            string fareuid = dk.FindCard();
            dk.ClosePoint();

            searchMethod(fareuid);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvMember.SelectedRows.Count == 0 && dgvMember.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmViewCard FrmViewCard = new FrmViewCard();
            string id = dgvMember.SelectedRows[0].Cells["id"].Value.ToString();
            FrmViewCard.member_id = id;
            FrmViewCard.ShowDialog();
            if (FrmViewCard.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
        }

        private void btnNoCard_w_Click(object sender, EventArgs e)
        {
            if (dgvMember.SelectedRows.Count == 0 && dgvMember.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmNocard frmNocard = new FrmNocard();
            string id = dgvMember.SelectedRows[0].Cells["id"].Value.ToString();
            frmNocard.getSource(id);
            frmNocard.userfare = false;
            frmNocard.ShowDialog();
            if (frmNocard.DialogResult == DialogResult.OK)
            {
                searchMethod("");
            }
        }

    }
}
