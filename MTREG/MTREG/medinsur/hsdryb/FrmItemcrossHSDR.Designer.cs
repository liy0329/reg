namespace MTREG.medinsur.hsdryb
{
    partial class FrmItemcrossHSDR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tcItemCross = new System.Windows.Forms.TabControl();
            this.tpHisItem = new System.Windows.Forms.TabPage();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.dgvHisItem = new System.Windows.Forms.DataGridView();
            this.cbxStuff = new System.Windows.Forms.CheckBox();
            this.cbxDiagnoCost = new System.Windows.Forms.CheckBox();
            this.cbxDrug = new System.Windows.Forms.CheckBox();
            this.tpInsurItem = new System.Windows.Forms.TabPage();
            this.tbxName0 = new System.Windows.Forms.TextBox();
            this.dgvInsurItem = new System.Windows.Forms.DataGridView();
            this.cbxStuff0 = new System.Windows.Forms.CheckBox();
            this.cbxDiagnoCost0 = new System.Windows.Forms.CheckBox();
            this.cbxDrug0 = new System.Windows.Forms.CheckBox();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.tcItemCross.SuspendLayout();
            this.tpHisItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHisItem)).BeginInit();
            this.tpInsurItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurItem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(221, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 22);
            this.label1.TabIndex = 90;
            this.label1.Text = "HIS编码信息（三目录）";
            // 
            // tcItemCross
            // 
            this.tcItemCross.Controls.Add(this.tpHisItem);
            this.tcItemCross.Controls.Add(this.tpInsurItem);
            this.tcItemCross.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcItemCross.Location = new System.Drawing.Point(4, 39);
            this.tcItemCross.Name = "tcItemCross";
            this.tcItemCross.SelectedIndex = 0;
            this.tcItemCross.Size = new System.Drawing.Size(702, 355);
            this.tcItemCross.TabIndex = 91;
            this.tcItemCross.SelectedIndexChanged += new System.EventHandler(this.tcItemCross_SelectedIndexChanged);
            // 
            // tpHisItem
            // 
            this.tpHisItem.Controls.Add(this.tbxName);
            this.tpHisItem.Controls.Add(this.dgvHisItem);
            this.tpHisItem.Controls.Add(this.cbxStuff);
            this.tpHisItem.Controls.Add(this.cbxDiagnoCost);
            this.tpHisItem.Controls.Add(this.cbxDrug);
            this.tpHisItem.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpHisItem.Location = new System.Drawing.Point(4, 26);
            this.tpHisItem.Name = "tpHisItem";
            this.tpHisItem.Padding = new System.Windows.Forms.Padding(3);
            this.tpHisItem.Size = new System.Drawing.Size(694, 325);
            this.tpHisItem.TabIndex = 0;
            this.tpHisItem.Text = "院内目录信息";
            this.tpHisItem.UseVisualStyleBackColor = true;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(82, 41);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(230, 26);
            this.tbxName.TabIndex = 60;
            this.tbxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName_KeyDown);
            // 
            // dgvHisItem
            // 
            this.dgvHisItem.AllowDrop = true;
            this.dgvHisItem.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHisItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHisItem.ColumnHeadersHeight = 32;
            this.dgvHisItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvHisItem.Location = new System.Drawing.Point(6, 73);
            this.dgvHisItem.Name = "dgvHisItem";
            this.dgvHisItem.ReadOnly = true;
            this.dgvHisItem.RowHeadersVisible = false;
            this.dgvHisItem.RowHeadersWidth = 200;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvHisItem.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHisItem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvHisItem.RowTemplate.Height = 38;
            this.dgvHisItem.RowTemplate.ReadOnly = true;
            this.dgvHisItem.Size = new System.Drawing.Size(682, 246);
            this.dgvHisItem.TabIndex = 59;
            // 
            // cbxStuff
            // 
            this.cbxStuff.AutoSize = true;
            this.cbxStuff.Location = new System.Drawing.Point(252, 13);
            this.cbxStuff.Name = "cbxStuff";
            this.cbxStuff.Size = new System.Drawing.Size(61, 20);
            this.cbxStuff.TabIndex = 2;
            this.cbxStuff.Text = "材料";
            this.cbxStuff.UseVisualStyleBackColor = true;
            this.cbxStuff.CheckedChanged += new System.EventHandler(this.cbxStuff_CheckedChanged);
            // 
            // cbxDiagnoCost
            // 
            this.cbxDiagnoCost.AutoSize = true;
            this.cbxDiagnoCost.Location = new System.Drawing.Point(126, 13);
            this.cbxDiagnoCost.Name = "cbxDiagnoCost";
            this.cbxDiagnoCost.Size = new System.Drawing.Size(95, 20);
            this.cbxDiagnoCost.TabIndex = 1;
            this.cbxDiagnoCost.Text = "诊疗费用";
            this.cbxDiagnoCost.UseVisualStyleBackColor = true;
            this.cbxDiagnoCost.CheckedChanged += new System.EventHandler(this.cbxDiagnoCost_CheckedChanged);
            // 
            // cbxDrug
            // 
            this.cbxDrug.AutoSize = true;
            this.cbxDrug.Location = new System.Drawing.Point(33, 13);
            this.cbxDrug.Name = "cbxDrug";
            this.cbxDrug.Size = new System.Drawing.Size(61, 20);
            this.cbxDrug.TabIndex = 0;
            this.cbxDrug.Text = "药品";
            this.cbxDrug.UseVisualStyleBackColor = true;
            this.cbxDrug.CheckedChanged += new System.EventHandler(this.cbxDrug_CheckedChanged);
            // 
            // tpInsurItem
            // 
            this.tpInsurItem.Controls.Add(this.tbxName0);
            this.tpInsurItem.Controls.Add(this.dgvInsurItem);
            this.tpInsurItem.Controls.Add(this.cbxStuff0);
            this.tpInsurItem.Controls.Add(this.cbxDiagnoCost0);
            this.tpInsurItem.Controls.Add(this.cbxDrug0);
            this.tpInsurItem.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpInsurItem.Location = new System.Drawing.Point(4, 26);
            this.tpInsurItem.Name = "tpInsurItem";
            this.tpInsurItem.Padding = new System.Windows.Forms.Padding(3);
            this.tpInsurItem.Size = new System.Drawing.Size(694, 325);
            this.tpInsurItem.TabIndex = 1;
            this.tpInsurItem.Text = "医保目录信息";
            this.tpInsurItem.UseVisualStyleBackColor = true;
            // 
            // tbxName0
            // 
            this.tbxName0.Location = new System.Drawing.Point(82, 37);
            this.tbxName0.Name = "tbxName0";
            this.tbxName0.Size = new System.Drawing.Size(230, 26);
            this.tbxName0.TabIndex = 65;
            this.tbxName0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName0_KeyDown);
            // 
            // dgvInsurItem
            // 
            this.dgvInsurItem.AllowDrop = true;
            this.dgvInsurItem.AllowUserToAddRows = false;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsurItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInsurItem.ColumnHeadersHeight = 32;
            this.dgvInsurItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvInsurItem.Location = new System.Drawing.Point(6, 69);
            this.dgvInsurItem.Name = "dgvInsurItem";
            this.dgvInsurItem.ReadOnly = true;
            this.dgvInsurItem.RowHeadersVisible = false;
            this.dgvInsurItem.RowHeadersWidth = 200;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvInsurItem.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInsurItem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvInsurItem.RowTemplate.Height = 38;
            this.dgvInsurItem.RowTemplate.ReadOnly = true;
            this.dgvInsurItem.Size = new System.Drawing.Size(682, 246);
            this.dgvInsurItem.TabIndex = 64;
            // 
            // cbxStuff0
            // 
            this.cbxStuff0.AutoSize = true;
            this.cbxStuff0.Location = new System.Drawing.Point(252, 9);
            this.cbxStuff0.Name = "cbxStuff0";
            this.cbxStuff0.Size = new System.Drawing.Size(61, 20);
            this.cbxStuff0.TabIndex = 63;
            this.cbxStuff0.Text = "材料";
            this.cbxStuff0.UseVisualStyleBackColor = true;
            this.cbxStuff0.CheckedChanged += new System.EventHandler(this.cbxStuff0_CheckedChanged);
            // 
            // cbxDiagnoCost0
            // 
            this.cbxDiagnoCost0.AutoSize = true;
            this.cbxDiagnoCost0.Location = new System.Drawing.Point(126, 9);
            this.cbxDiagnoCost0.Name = "cbxDiagnoCost0";
            this.cbxDiagnoCost0.Size = new System.Drawing.Size(95, 20);
            this.cbxDiagnoCost0.TabIndex = 62;
            this.cbxDiagnoCost0.Text = "诊疗费用";
            this.cbxDiagnoCost0.UseVisualStyleBackColor = true;
            this.cbxDiagnoCost0.CheckedChanged += new System.EventHandler(this.cbxDiagnoCost0_CheckedChanged);
            // 
            // cbxDrug0
            // 
            this.cbxDrug0.AutoSize = true;
            this.cbxDrug0.Location = new System.Drawing.Point(33, 9);
            this.cbxDrug0.Name = "cbxDrug0";
            this.cbxDrug0.Size = new System.Drawing.Size(61, 20);
            this.cbxDrug0.TabIndex = 61;
            this.cbxDrug0.Text = "药品";
            this.cbxDrug0.UseVisualStyleBackColor = true;
            this.cbxDrug0.CheckedChanged += new System.EventHandler(this.cbxDrug0_CheckedChanged);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(540, 33);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(129, 21);
            this.btnDownLoad.TabIndex = 92;
            this.btnDownLoad.Text = "下载医保目录";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // FrmItemcrossHSDR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 399);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.tcItemCross);
            this.Controls.Add(this.label1);
            this.Name = "FrmItemcrossHSDR";
            this.Text = "武邑县医保编码对照";
            this.Load += new System.EventHandler(this.FrmItemcrossHSDR_Load);
            this.tcItemCross.ResumeLayout(false);
            this.tpHisItem.ResumeLayout(false);
            this.tpHisItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHisItem)).EndInit();
            this.tpInsurItem.ResumeLayout(false);
            this.tpInsurItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcItemCross;
        private System.Windows.Forms.TabPage tpHisItem;
        private System.Windows.Forms.CheckBox cbxStuff;
        private System.Windows.Forms.CheckBox cbxDiagnoCost;
        private System.Windows.Forms.CheckBox cbxDrug;
        private System.Windows.Forms.TabPage tpInsurItem;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.DataGridView dgvHisItem;
        private System.Windows.Forms.TextBox tbxName0;
        private System.Windows.Forms.DataGridView dgvInsurItem;
        private System.Windows.Forms.CheckBox cbxStuff0;
        private System.Windows.Forms.CheckBox cbxDiagnoCost0;
        private System.Windows.Forms.CheckBox cbxDrug0;
    }
}