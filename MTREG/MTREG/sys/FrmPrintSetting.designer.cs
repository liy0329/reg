namespace MTHIS.sys
{
    partial class FrmPrintSetting
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
            this.lblOpstat = new System.Windows.Forms.Label();
            this.lblPrintId = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDesign = new System.Windows.Forms.Button();
            this.tbxTmpName = new System.Windows.Forms.TextBox();
            this.lblTmpName = new System.Windows.Forms.Label();
            this.cbxIsused = new System.Windows.Forms.ComboBox();
            this.cbxIsprintview = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbliSprintview = new System.Windows.Forms.Label();
            this.lblIsused = new System.Windows.Forms.Label();
            this.tbxY_val = new System.Windows.Forms.TextBox();
            this.lblY_val = new System.Windows.Forms.Label();
            this.tbxX_val = new System.Windows.Forms.TextBox();
            this.lblX_val = new System.Windows.Forms.Label();
            this.tbxPrintname = new System.Windows.Forms.TextBox();
            this.lblPrintname = new System.Windows.Forms.Label();
            this.tbxPrintcode = new System.Windows.Forms.TextBox();
            this.lblPrintcode = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_stateshow = new System.Windows.Forms.Label();
            this.btnChanagePrinter = new System.Windows.Forms.Button();
            this.lblSysm_id = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOpstat
            // 
            this.lblOpstat.AutoSize = true;
            this.lblOpstat.Location = new System.Drawing.Point(904, 28);
            this.lblOpstat.Name = "lblOpstat";
            this.lblOpstat.Size = new System.Drawing.Size(41, 12);
            this.lblOpstat.TabIndex = 23;
            this.lblOpstat.Text = "Opstat";
            this.lblOpstat.Visible = false;
            // 
            // lblPrintId
            // 
            this.lblPrintId.AutoSize = true;
            this.lblPrintId.Location = new System.Drawing.Point(833, 28);
            this.lblPrintId.Name = "lblPrintId";
            this.lblPrintId.Size = new System.Drawing.Size(53, 12);
            this.lblPrintId.TabIndex = 22;
            this.lblPrintId.Text = "ptint_id";
            this.lblPrintId.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(156, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(56, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDesign);
            this.panel3.Controls.Add(this.tbxTmpName);
            this.panel3.Controls.Add(this.lblTmpName);
            this.panel3.Controls.Add(this.cbxIsused);
            this.panel3.Controls.Add(this.cbxIsprintview);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.lbliSprintview);
            this.panel3.Controls.Add(this.lblIsused);
            this.panel3.Controls.Add(this.tbxY_val);
            this.panel3.Controls.Add(this.lblY_val);
            this.panel3.Controls.Add(this.tbxX_val);
            this.panel3.Controls.Add(this.lblX_val);
            this.panel3.Controls.Add(this.tbxPrintname);
            this.panel3.Controls.Add(this.lblPrintname);
            this.panel3.Controls.Add(this.tbxPrintcode);
            this.panel3.Controls.Add(this.lblPrintcode);
            this.panel3.Location = new System.Drawing.Point(781, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(221, 401);
            this.panel3.TabIndex = 19;
            // 
            // btnDesign
            // 
            this.btnDesign.Location = new System.Drawing.Point(13, 366);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(63, 23);
            this.btnDesign.TabIndex = 19;
            this.btnDesign.Text = "设置";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // tbxTmpName
            // 
            this.tbxTmpName.Location = new System.Drawing.Point(100, 328);
            this.tbxTmpName.Name = "tbxTmpName";
            this.tbxTmpName.Size = new System.Drawing.Size(100, 21);
            this.tbxTmpName.TabIndex = 18;
            this.tbxTmpName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxTmpName_KeyDown);
            // 
            // lblTmpName
            // 
            this.lblTmpName.AutoSize = true;
            this.lblTmpName.Location = new System.Drawing.Point(21, 331);
            this.lblTmpName.Name = "lblTmpName";
            this.lblTmpName.Size = new System.Drawing.Size(53, 12);
            this.lblTmpName.TabIndex = 17;
            this.lblTmpName.Text = "模板名称";
            // 
            // cbxIsused
            // 
            this.cbxIsused.FormattingEnabled = true;
            this.cbxIsused.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cbxIsused.Location = new System.Drawing.Point(100, 238);
            this.cbxIsused.Name = "cbxIsused";
            this.cbxIsused.Size = new System.Drawing.Size(100, 20);
            this.cbxIsused.TabIndex = 16;
            this.cbxIsused.SelectedIndexChanged += new System.EventHandler(this.cbxIsused_SelectedIndexChanged);
            this.cbxIsused.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxIsused_KeyDown);
            // 
            // cbxIsprintview
            // 
            this.cbxIsprintview.FormattingEnabled = true;
            this.cbxIsprintview.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cbxIsprintview.Location = new System.Drawing.Point(100, 288);
            this.cbxIsprintview.Name = "cbxIsprintview";
            this.cbxIsprintview.Size = new System.Drawing.Size(100, 20);
            this.cbxIsprintview.TabIndex = 15;
            this.cbxIsprintview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxiSprintview_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(151, 366);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(82, 366);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbliSprintview
            // 
            this.lbliSprintview.AutoSize = true;
            this.lbliSprintview.Location = new System.Drawing.Point(21, 291);
            this.lbliSprintview.Name = "lbliSprintview";
            this.lbliSprintview.Size = new System.Drawing.Size(53, 12);
            this.lbliSprintview.TabIndex = 10;
            this.lbliSprintview.Text = "打印预览";
            // 
            // lblIsused
            // 
            this.lblIsused.AutoSize = true;
            this.lblIsused.Location = new System.Drawing.Point(21, 241);
            this.lblIsused.Name = "lblIsused";
            this.lblIsused.Size = new System.Drawing.Size(53, 12);
            this.lblIsused.TabIndex = 8;
            this.lblIsused.Text = "是否停用";
            // 
            // tbxY_val
            // 
            this.tbxY_val.Location = new System.Drawing.Point(100, 184);
            this.tbxY_val.Name = "tbxY_val";
            this.tbxY_val.Size = new System.Drawing.Size(100, 21);
            this.tbxY_val.TabIndex = 7;
            this.tbxY_val.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxY_val_KeyDown);
            this.tbxY_val.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxY_val_KeyPress);
            // 
            // lblY_val
            // 
            this.lblY_val.AutoSize = true;
            this.lblY_val.Location = new System.Drawing.Point(21, 187);
            this.lblY_val.Name = "lblY_val";
            this.lblY_val.Size = new System.Drawing.Size(41, 12);
            this.lblY_val.TabIndex = 6;
            this.lblY_val.Text = "坐标轴";
            // 
            // tbxX_val
            // 
            this.tbxX_val.Location = new System.Drawing.Point(100, 130);
            this.tbxX_val.Name = "tbxX_val";
            this.tbxX_val.Size = new System.Drawing.Size(100, 21);
            this.tbxX_val.TabIndex = 5;
            this.tbxX_val.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxX_val_KeyDown);
            this.tbxX_val.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxX_val_KeyPress);
            // 
            // lblX_val
            // 
            this.lblX_val.AutoSize = true;
            this.lblX_val.Location = new System.Drawing.Point(21, 133);
            this.lblX_val.Name = "lblX_val";
            this.lblX_val.Size = new System.Drawing.Size(41, 12);
            this.lblX_val.TabIndex = 4;
            this.lblX_val.Text = "坐标值";
            // 
            // tbxPrintname
            // 
            this.tbxPrintname.Location = new System.Drawing.Point(100, 82);
            this.tbxPrintname.Name = "tbxPrintname";
            this.tbxPrintname.Size = new System.Drawing.Size(100, 21);
            this.tbxPrintname.TabIndex = 3;
            this.tbxPrintname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPrintname_KeyDown);
            // 
            // lblPrintname
            // 
            this.lblPrintname.AutoSize = true;
            this.lblPrintname.Location = new System.Drawing.Point(21, 85);
            this.lblPrintname.Name = "lblPrintname";
            this.lblPrintname.Size = new System.Drawing.Size(53, 12);
            this.lblPrintname.TabIndex = 2;
            this.lblPrintname.Text = "打印名称";
            // 
            // tbxPrintcode
            // 
            this.tbxPrintcode.Location = new System.Drawing.Point(100, 34);
            this.tbxPrintcode.Name = "tbxPrintcode";
            this.tbxPrintcode.Size = new System.Drawing.Size(100, 21);
            this.tbxPrintcode.TabIndex = 1;
            this.tbxPrintcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPrintcode_KeyDown);
            // 
            // lblPrintcode
            // 
            this.lblPrintcode.AutoSize = true;
            this.lblPrintcode.Location = new System.Drawing.Point(18, 37);
            this.lblPrintcode.Name = "lblPrintcode";
            this.lblPrintcode.Size = new System.Drawing.Size(53, 12);
            this.lblPrintcode.TabIndex = 0;
            this.lblPrintcode.Text = "打印编码";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(745, 401);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // lbl_stateshow
            // 
            this.lbl_stateshow.AutoSize = true;
            this.lbl_stateshow.ForeColor = System.Drawing.Color.Red;
            this.lbl_stateshow.Location = new System.Drawing.Point(898, 52);
            this.lbl_stateshow.Name = "lbl_stateshow";
            this.lbl_stateshow.Size = new System.Drawing.Size(0, 12);
            this.lbl_stateshow.TabIndex = 25;
            // 
            // btnChanagePrinter
            // 
            this.btnChanagePrinter.Location = new System.Drawing.Point(261, 23);
            this.btnChanagePrinter.Name = "btnChanagePrinter";
            this.btnChanagePrinter.Size = new System.Drawing.Size(75, 23);
            this.btnChanagePrinter.TabIndex = 26;
            this.btnChanagePrinter.Text = "选择打印机";
            this.btnChanagePrinter.UseVisualStyleBackColor = true;
            this.btnChanagePrinter.Click += new System.EventHandler(this.btnChanagePrinter_Click);
            // 
            // lblSysm_id
            // 
            this.lblSysm_id.AutoSize = true;
            this.lblSysm_id.Location = new System.Drawing.Point(774, 28);
            this.lblSysm_id.Name = "lblSysm_id";
            this.lblSysm_id.Size = new System.Drawing.Size(47, 12);
            this.lblSysm_id.TabIndex = 22;
            this.lblSysm_id.Text = "sysm_id";
            this.lblSysm_id.Visible = false;
            // 
            // FrmPrintSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 467);
            this.Controls.Add(this.btnChanagePrinter);
            this.Controls.Add(this.lbl_stateshow);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblOpstat);
            this.Controls.Add(this.lblSysm_id);
            this.Controls.Add(this.lblPrintId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel3);
            this.Name = "FrmPrintSetting";
            this.Text = "打印配置";
            this.Load += new System.EventHandler(this.FrmPrint_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOpstat;
        private System.Windows.Forms.Label lblPrintId;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbliSprintview;
        private System.Windows.Forms.Label lblIsused;
        private System.Windows.Forms.TextBox tbxY_val;
        private System.Windows.Forms.Label lblY_val;
        private System.Windows.Forms.TextBox tbxX_val;
        private System.Windows.Forms.Label lblX_val;
        private System.Windows.Forms.TextBox tbxPrintname;
        private System.Windows.Forms.Label lblPrintname;
        private System.Windows.Forms.TextBox tbxPrintcode;
        private System.Windows.Forms.Label lblPrintcode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbxIsprintview;
        private System.Windows.Forms.ComboBox cbxIsused;
        private System.Windows.Forms.Label lbl_stateshow;
        private System.Windows.Forms.TextBox tbxTmpName;
        private System.Windows.Forms.Label lblTmpName;
        private System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.Button btnChanagePrinter;
        private System.Windows.Forms.Label lblSysm_id;
    }
}