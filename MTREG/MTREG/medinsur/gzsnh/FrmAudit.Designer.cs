namespace MTREG.medinsur.gzsnh
{
    partial class FrmAudit
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_typeno = new System.Windows.Forms.ComboBox();
            this.btnCommite = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_reason = new System.Windows.Forms.TextBox();
            this.cbx_sqlx = new System.Windows.Forms.ComboBox();
            this.tbx_shjg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(36, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "审核内容";
            // 
            // cbx_typeno
            // 
            this.cbx_typeno.FormattingEnabled = true;
            this.cbx_typeno.Location = new System.Drawing.Point(103, 394);
            this.cbx_typeno.Name = "cbx_typeno";
            this.cbx_typeno.Size = new System.Drawing.Size(121, 20);
            this.cbx_typeno.TabIndex = 16;
            // 
            // btnCommite
            // 
            this.btnCommite.Location = new System.Drawing.Point(415, 425);
            this.btnCommite.Name = "btnCommite";
            this.btnCommite.Size = new System.Drawing.Size(75, 23);
            this.btnCommite.TabIndex = 15;
            this.btnCommite.Text = "提交审核";
            this.btnCommite.UseVisualStyleBackColor = true;
            this.btnCommite.Click += new System.EventHandler(this.btnCommite_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(103, 425);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "审核状态查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "原因及费用超支情况";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "申请类型";
            // 
            // tbx_reason
            // 
            this.tbx_reason.Location = new System.Drawing.Point(415, 357);
            this.tbx_reason.Name = "tbx_reason";
            this.tbx_reason.Size = new System.Drawing.Size(360, 21);
            this.tbx_reason.TabIndex = 11;
            // 
            // cbx_sqlx
            // 
            this.cbx_sqlx.FormattingEnabled = true;
            this.cbx_sqlx.Location = new System.Drawing.Point(103, 357);
            this.cbx_sqlx.Name = "cbx_sqlx";
            this.cbx_sqlx.Size = new System.Drawing.Size(121, 20);
            this.cbx_sqlx.TabIndex = 10;
            // 
            // tbx_shjg
            // 
            this.tbx_shjg.Location = new System.Drawing.Point(8, 9);
            this.tbx_shjg.Multiline = true;
            this.tbx_shjg.Name = "tbx_shjg";
            this.tbx_shjg.Size = new System.Drawing.Size(767, 332);
            this.tbx_shjg.TabIndex = 9;
            // 
            // FrmAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 465);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_typeno);
            this.Controls.Add(this.btnCommite);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_reason);
            this.Controls.Add(this.cbx_sqlx);
            this.Controls.Add(this.tbx_shjg);
            this.Name = "FrmAudit";
            this.Text = "住院审核状态查询";
            this.Load += new System.EventHandler(this.FrmAudit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_typeno;
        private System.Windows.Forms.Button btnCommite;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_reason;
        private System.Windows.Forms.ComboBox cbx_sqlx;
        private System.Windows.Forms.TextBox tbx_shjg;
    }
}