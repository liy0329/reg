namespace MTREG.medinsur
{
    partial class FrmInsurtype
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInsurtype = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewLinkColumn();
            this.iffactory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iftechiq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurtype)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 80);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F);
            this.label1.Location = new System.Drawing.Point(213, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "医保接口类型列表";
            // 
            // dgvInsurtype
            // 
            this.dgvInsurtype.AllowUserToAddRows = false;
            this.dgvInsurtype.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsurtype.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInsurtype.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsurtype.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.iffactory,
            this.iftechiq,
            this.keyname,
            this.updateat});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsurtype.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInsurtype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInsurtype.Location = new System.Drawing.Point(0, 80);
            this.dgvInsurtype.Name = "dgvInsurtype";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsurtype.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInsurtype.RowTemplate.Height = 23;
            this.dgvInsurtype.Size = new System.Drawing.Size(612, 315);
            this.dgvInsurtype.TabIndex = 1;
            this.dgvInsurtype.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsurtype_CellContentClick);
            this.dgvInsurtype.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvInsurtype_RowPostPaint);
            // 
            // name
            // 
            this.name.HeaderText = "接口名称";
            this.name.Name = "name";
            // 
            // iffactory
            // 
            this.iffactory.HeaderText = "接口厂家";
            this.iffactory.Name = "iffactory";
            this.iffactory.ReadOnly = true;
            // 
            // iftechiq
            // 
            this.iftechiq.HeaderText = "接口技术";
            this.iftechiq.Name = "iftechiq";
            this.iftechiq.ReadOnly = true;
            this.iftechiq.Width = 150;
            // 
            // keyname
            // 
            this.keyname.HeaderText = "接口关键字";
            this.keyname.Name = "keyname";
            this.keyname.ReadOnly = true;
            this.keyname.Width = 120;
            // 
            // updateat
            // 
            this.updateat.HeaderText = "更新时间";
            this.updateat.Name = "updateat";
            this.updateat.ReadOnly = true;
            // 
            // FrmInsurtype
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 395);
            this.Controls.Add(this.dgvInsurtype);
            this.Controls.Add(this.panel1);
            this.Name = "FrmInsurtype";
            this.Text = "词典对照";
            this.Load += new System.EventHandler(this.FrmInsurtype_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurtype)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInsurtype;
        private System.Windows.Forms.DataGridViewLinkColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn iffactory;
        private System.Windows.Forms.DataGridViewTextBoxColumn iftechiq;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyname;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateat;

    }
}