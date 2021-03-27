using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.clintab.bll;
using MTREG.clintab.bo;
using MTREG.common;
using MTHIS.main.bll;
using MTREG.clinic.bll;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTREG.medinsur.sjzsyb.clinic
{
    public partial class FrmClicDaily : Form
    {
        public FrmClicDaily()
        {
            InitializeComponent();
        }
        BllClicTab bllClicTab = new BllClicTab();
        private void FrmClicDaily_Load(object sender, EventArgs e)
        {
            string sql0 = "SELECT id,name FROM bas_doctor WHERE depart_id = '55' AND isstop = 'N'";
            DataTable dtdoc = BllMain.Db.Select(sql0).Tables[0];
            DataRow dr1 = dtdoc.NewRow();
            dr1["id"] = 0;
            dr1["name"] = "--全部--";
            dtdoc.Rows.InsertAt(dr1, 0);
            if (dtdoc.Rows.Count > 0)
            {
                this.comboBox1.ValueMember = "id";
                this.comboBox1.DisplayMember = "name";
                this.comboBox1.DataSource = dtdoc;
                this.comboBox1.SelectedValue = 0;
            }

            //cmbPayType

            BllMemberReg bllMemberReg = new BllMemberReg();
            DataTable dtPayType = bllMemberReg.payPaytypeList();
            //重新绑定
            DataRow dr = dtPayType.NewRow();
            dr["id"] = 0;
            dr["name"] = "--全部--";
            dtPayType.Rows.InsertAt(dr, 0);
            if (dtPayType.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtPayType;
                this.cmbPayType.SelectedValue = 0;
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            clinicSearchMethod();
        }
        /// <summary>
        /// 门诊查找方法
        /// </summary>
        private void clinicSearchMethod()
        {

            string sett = cmbPayType.SelectedValue.ToString();
            string startDate = this.dtpStime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpEtime.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            string sql = "SELECT member.`name` AS '姓名',member.hspcard AS '卡号',member_rechargedet.opertype AS '操作类型',member_rechargedet.amount AS '操作金额',member_rechargedet.balance AS '余额', sys_dict.`name` AS '支付类型',member_rechargedet.operatdate  AS '时间'"
                       + " FROM member_rechargedet"
                       + " LEFT JOIN member ON member.id = member_rechargedet.bas_member_id"
                       + " LEFT JOIN sys_dict ON father_id <> 0 AND dicttype = 'bas_paytype' AND member_rechargedet.bas_paytype_id = sys_dict.sn"
                       + " WHERE member_rechargedet.operatdate >" + DataTool.addFieldBraces(startDate)
                       + " AND member_rechargedet.operatdate <"+ DataTool.addFieldBraces(endDate)
                       + " AND member_rechargedet.operator = " + DataTool.addFieldBraces(comboBox1.SelectedValue.ToString())
                       + " AND member_rechargedet.bas_paytype_id <> '20'";
            if(sett != "0")
            {
                sql += " AND member_rechargedet.bas_paytype_id = " + DataTool.addFieldBraces(sett);
            }
            double amount = 0;
            DataTable dataTable = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                amount += Double.Parse(dataTable.Rows[i]["操作金额"].ToString());
                string opertype = dataTable.Rows[i]["操作类型"].ToString();
                switch (opertype)
                {
                    case "EN": dataTable.Rows[i]["操作类型"] = "取现"; break;
                    case "RE": dataTable.Rows[i]["操作类型"] = "充值"; break;
                    case "CO": dataTable.Rows[i]["操作类型"] = "消费"; break;
                }
            }
            DataRow dr = dataTable.NewRow();
            dr["操作类型"] = "合计：";
            dr["操作金额"] = amount.ToString();
            dataTable.Rows.Add(dr);
            dgvRechargedet.DataSource = dataTable;
        }
    }
}
