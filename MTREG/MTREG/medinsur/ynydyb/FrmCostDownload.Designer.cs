namespace MTREG.medinsur.ynydyb
{
    partial class FrmCostDownload
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
            this.btnCostdet = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.dgvCost = new System.Windows.Forms.DataGridView();
            this.xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yyzyh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fsflsh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jsflsh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zyh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.djh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jylx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcqh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ylfyze = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xjzfje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhzfje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tczfje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yysczyh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfdz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRe = new System.Windows.Forms.Button();
            this.btnRet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCost)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCostdet
            // 
            this.btnCostdet.Enabled = false;
            this.btnCostdet.Font = new System.Drawing.Font("宋体", 11F);
            this.btnCostdet.Location = new System.Drawing.Point(1024, 12);
            this.btnCostdet.Name = "btnCostdet";
            this.btnCostdet.Size = new System.Drawing.Size(75, 27);
            this.btnCostdet.TabIndex = 117;
            this.btnCostdet.Text = "查看明细";
            this.btnCostdet.UseVisualStyleBackColor = true;
            this.btnCostdet.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("宋体", 11F);
            this.btnView.Location = new System.Drawing.Point(946, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 27);
            this.btnView.TabIndex = 116;
            this.btnView.Text = "查看";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("宋体", 11F);
            this.lblFilePath.ForeColor = System.Drawing.Color.Red;
            this.lblFilePath.Location = new System.Drawing.Point(12, 36);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(187, 15);
            this.lblFilePath.TabIndex = 115;
            this.lblFilePath.Text = "文件的绝对路径名和文件名";
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Enabled = false;
            this.btnDownLoad.Font = new System.Drawing.Font("宋体", 11F);
            this.btnDownLoad.Location = new System.Drawing.Point(868, 12);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(75, 27);
            this.btnDownLoad.TabIndex = 114;
            this.btnDownLoad.Text = "下载";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Visible = false;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // dgvCost
            // 
            this.dgvCost.AllowUserToAddRows = false;
            this.dgvCost.AllowUserToDeleteRows = false;
            this.dgvCost.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xm,
            this.yyzyh,
            this.fsflsh,
            this.jsflsh,
            this.grbh,
            this.zyh,
            this.djh,
            this.jylx,
            this.tcqh,
            this.ylfyze,
            this.xjzfje,
            this.zhzfje,
            this.tczfje,
            this.yysczyh,
            this.sfdz});
            this.dgvCost.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvCost.Location = new System.Drawing.Point(1, 86);
            this.dgvCost.Name = "dgvCost";
            this.dgvCost.ReadOnly = true;
            this.dgvCost.RowHeadersWidth = 30;
            this.dgvCost.RowTemplate.Height = 23;
            this.dgvCost.Size = new System.Drawing.Size(1109, 461);
            this.dgvCost.TabIndex = 118;
            // 
            // xm
            // 
            this.xm.DataPropertyName = "xm";
            this.xm.HeaderText = "姓名";
            this.xm.Name = "xm";
            this.xm.ReadOnly = true;
            // 
            // yyzyh
            // 
            this.yyzyh.DataPropertyName = "yyzyh";
            this.yyzyh.HeaderText = "医院住院（门诊）号";
            this.yyzyh.Name = "yyzyh";
            this.yyzyh.ReadOnly = true;
            // 
            // fsflsh
            // 
            this.fsflsh.DataPropertyName = "fsflsh";
            this.fsflsh.HeaderText = "发送方流水号";
            this.fsflsh.Name = "fsflsh";
            this.fsflsh.ReadOnly = true;
            // 
            // jsflsh
            // 
            this.jsflsh.DataPropertyName = "jsflsh";
            this.jsflsh.HeaderText = "接收方流水号";
            this.jsflsh.Name = "jsflsh";
            this.jsflsh.ReadOnly = true;
            this.jsflsh.Width = 120;
            // 
            // grbh
            // 
            this.grbh.DataPropertyName = "grbh";
            this.grbh.HeaderText = "个人编号";
            this.grbh.Name = "grbh";
            this.grbh.ReadOnly = true;
            // 
            // zyh
            // 
            this.zyh.DataPropertyName = "zyh";
            this.zyh.HeaderText = "住院号";
            this.zyh.Name = "zyh";
            this.zyh.ReadOnly = true;
            this.zyh.Width = 130;
            // 
            // djh
            // 
            this.djh.DataPropertyName = "djh";
            this.djh.HeaderText = "单据号";
            this.djh.Name = "djh";
            this.djh.ReadOnly = true;
            this.djh.Width = 130;
            // 
            // jylx
            // 
            this.jylx.DataPropertyName = "jylx";
            this.jylx.HeaderText = "交易类型";
            this.jylx.Name = "jylx";
            this.jylx.ReadOnly = true;
            // 
            // tcqh
            // 
            this.tcqh.DataPropertyName = "tcqh";
            this.tcqh.HeaderText = "统筹区号";
            this.tcqh.Name = "tcqh";
            this.tcqh.ReadOnly = true;
            // 
            // ylfyze
            // 
            this.ylfyze.DataPropertyName = "ylfyze";
            this.ylfyze.HeaderText = "医疗费用总额";
            this.ylfyze.Name = "ylfyze";
            this.ylfyze.ReadOnly = true;
            this.ylfyze.Width = 130;
            // 
            // xjzfje
            // 
            this.xjzfje.DataPropertyName = "xjzfje";
            this.xjzfje.HeaderText = "现金支付金额";
            this.xjzfje.Name = "xjzfje";
            this.xjzfje.ReadOnly = true;
            // 
            // zhzfje
            // 
            this.zhzfje.DataPropertyName = "zhzfje";
            this.zhzfje.HeaderText = "账户支付金额";
            this.zhzfje.Name = "zhzfje";
            this.zhzfje.ReadOnly = true;
            // 
            // tczfje
            // 
            this.tczfje.DataPropertyName = "tczfje";
            this.tczfje.HeaderText = "统筹支付金额";
            this.tczfje.Name = "tczfje";
            this.tczfje.ReadOnly = true;
            // 
            // yysczyh
            // 
            this.yysczyh.DataPropertyName = "yysczyh";
            this.yysczyh.HeaderText = "医院上传住院号";
            this.yysczyh.Name = "yysczyh";
            this.yysczyh.ReadOnly = true;
            this.yysczyh.Width = 140;
            // 
            // sfdz
            // 
            this.sfdz.DataPropertyName = "sfdz";
            this.sfdz.HeaderText = "是否对账";
            this.sfdz.Name = "sfdz";
            this.sfdz.ReadOnly = true;
            // 
            // btnRe
            // 
            this.btnRe.Enabled = false;
            this.btnRe.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRe.Location = new System.Drawing.Point(1025, 49);
            this.btnRe.Name = "btnRe";
            this.btnRe.Size = new System.Drawing.Size(75, 27);
            this.btnRe.TabIndex = 120;
            this.btnRe.Text = "重发";
            this.btnRe.UseVisualStyleBackColor = true;
            this.btnRe.Visible = false;
            this.btnRe.Click += new System.EventHandler(this.btnRe_Click);
            // 
            // btnRet
            // 
            this.btnRet.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRet.Location = new System.Drawing.Point(948, 49);
            this.btnRet.Name = "btnRet";
            this.btnRet.Size = new System.Drawing.Size(75, 27);
            this.btnRet.TabIndex = 119;
            this.btnRet.Text = "冲正";
            this.btnRet.UseVisualStyleBackColor = true;
            this.btnRet.Click += new System.EventHandler(this.btnRet_Click);
            // 
            // FrmCostDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 547);
            this.Controls.Add(this.btnRe);
            this.Controls.Add(this.btnRet);
            this.Controls.Add(this.dgvCost);
            this.Controls.Add(this.btnCostdet);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnDownLoad);
            this.Name = "FrmCostDownload";
            this.Text = "总账批量数据下载";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCostdet;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.DataGridView dgvCost;
        private System.Windows.Forms.Button btnRe;
        private System.Windows.Forms.Button btnRet;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn yyzyh;
        private System.Windows.Forms.DataGridViewTextBoxColumn fsflsh;
        private System.Windows.Forms.DataGridViewTextBoxColumn jsflsh;
        private System.Windows.Forms.DataGridViewTextBoxColumn grbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn zyh;
        private System.Windows.Forms.DataGridViewTextBoxColumn djh;
        private System.Windows.Forms.DataGridViewTextBoxColumn jylx;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcqh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ylfyze;
        private System.Windows.Forms.DataGridViewTextBoxColumn xjzfje;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhzfje;
        private System.Windows.Forms.DataGridViewTextBoxColumn tczfje;
        private System.Windows.Forms.DataGridViewTextBoxColumn yysczyh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfdz;
    }
}