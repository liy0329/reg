using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.gzswyb.common;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.gzsyb.bo;

namespace MTREG.medinsur.gzsyb
{
    public partial class Frm_Qssqcx : Form
    {
        public Frm_Qssqcx()
        {
            InitializeComponent();
        }
        GzsybInterface gzsybInterface = new GzsybInterface();
 
        private void Frm_Qssqcx_Load(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            ClearApplySearch ihh = new ClearApplySearch();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "74";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + "<input><prm_yae366>"+tbxqsqh.Text.ToString()+"</prm_yae366><proxy>1</proxy></input>";
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "清算申请查询错误信息");
                return;
            }
            string xml = callOut.Astrjyscxml;
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            dataGridView1.DataSource = ds.Tables["row"].DefaultView; 
            
                
        }

        private void btn_hzdy_Click(object sender, EventArgs e)
        {

        }

        private void btn_mxdy_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.CurrentRow.Index;
            if (idx == -1)
                return;
            string qslsh = dataGridView1.Rows[idx].Cells["ykb053"].Value.ToString();
            string fzx = dataGridView1.Rows[idx].Cells["ykb037_bm"].Value.ToString();
            string bxff = dataGridView1.Rows[idx].Cells["ykb065_bm"].Value.ToString();
            ClearApply ihh = new ClearApply();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "73";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + "<input><prm_ykb053>" + qslsh + "</prm_ykb053><prm_ykb037>" + fzx + "</prm_ykb037><prm_ykc179>" + MTHIS.common.ProgramGlobal.Username + "</prm_ykc179><prm_yke150>" + DateTime.Now.ToString() + "</prm_yke150><prm_ykb065>" + bxff + "</prm_ykb065><proxy>1</proxy></input>";
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "清算申请撤消错误信息");
                return;
            }
            Confirm_in confirmin = new Confirm_in();
            confirmin.Astrjylsh = callOut.Astrjylsh;
            confirmin.Astrjyyzm = callOut.Astrjyyzm;
            Confirm_out confirmout = gzsybInterface.Confirm(confirmin);
            if (confirmout.AintAppcode < 0)
            {
                MessageBox.Show(confirmout.AstrAppmsg, "清算申请撤消确认错误信息");
                //message.Append(confirmout.AstrAppmsg);
                return;
            }
            MessageBox.Show("清算申请撤消成功");
        }
    }
}
