namespace MTREG.ihsp
{
    partial class FrmIhspNotice
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxHspcard = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvIhspNotice = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.tbxDepart = new System.Windows.Forms.TextBox();
            this.tbxDepCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbxDepart = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspNotice)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 11F);
            this.btnCancel.Location = new System.Drawing.Point(579, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 11F);
            this.btnOk.Location = new System.Drawing.Point(517, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(61, 24);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxName.Location = new System.Drawing.Point(90, 42);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(138, 24);
            this.tbxName.TabIndex = 1;
            this.tbxName.Tag = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(35, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 84;
            this.label2.Text = "姓名:";
            // 
            // tbxHspcard
            // 
            this.tbxHspcard.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxHspcard.Location = new System.Drawing.Point(283, 43);
            this.tbxHspcard.Name = "tbxHspcard";
            this.tbxHspcard.Size = new System.Drawing.Size(140, 24);
            this.tbxHspcard.TabIndex = 2;
            this.tbxHspcard.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(239, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 101;
            this.label1.Text = "卡号:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(451, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 24);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvIhspNotice
            // 
            this.dgvIhspNotice.AllowUserToAddRows = false;
            this.dgvIhspNotice.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvIhspNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIhspNotice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIhspNotice.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIhspNotice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIhspNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIhspNotice.GridColor = System.Drawing.Color.White;
            this.dgvIhspNotice.Location = new System.Drawing.Point(0, 76);
            this.dgvIhspNotice.Name = "dgvIhspNotice";
            this.dgvIhspNotice.ReadOnly = true;
            this.dgvIhspNotice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhspNotice.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIhspNotice.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvIhspNotice.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIhspNotice.RowTemplate.Height = 23;
            this.dgvIhspNotice.Size = new System.Drawing.Size(764, 274);
            this.dgvIhspNotice.TabIndex = 104;
            this.dgvIhspNotice.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIhspNotice_CellDoubleClick);
            this.dgvIhspNotice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIhspNotice_CellDoubleClick_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(448, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 84;
            this.label3.Text = "科室:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.tbxDepart);
            this.panel1.Controls.Add(this.tbxName);
            this.panel1.Controls.Add(this.tbxDepCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxHspcard);
            this.panel1.Controls.Add(this.dtpStartTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 76);
            this.panel1.TabIndex = 105;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndTime.Location = new System.Drawing.Point(285, 7);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(140, 25);
            this.dtpEndTime.TabIndex = 109;
            // 
            // tbxDepart
            // 
            this.tbxDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxDepart.Location = new System.Drawing.Point(499, 43);
            this.tbxDepart.Name = "tbxDepart";
            this.tbxDepart.Size = new System.Drawing.Size(124, 24);
            this.tbxDepart.TabIndex = 108;
            this.tbxDepart.TextChanged += new System.EventHandler(this.tbxDepart_TextChanged);
            this.tbxDepart.Enter += new System.EventHandler(this.tbxDepart_Enter);
            this.tbxDepart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDepart_KeyDown);
            this.tbxDepart.Leave += new System.EventHandler(this.tbxDepart_Leave);
            // 
            // tbxDepCode
            // 
            this.tbxDepCode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxDepCode.Location = new System.Drawing.Point(499, 43);
            this.tbxDepCode.Name = "tbxDepCode";
            this.tbxDepCode.Size = new System.Drawing.Size(124, 24);
            this.tbxDepCode.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(257, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 111;
            this.label4.Text = "至";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartTime.Location = new System.Drawing.Point(92, 7);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(138, 25);
            this.dtpStartTime.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(5, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 110;
            this.label5.Text = "通知时间:";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 11F);
            this.btnReset.Location = new System.Drawing.Point(534, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(61, 24);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 36);
            this.panel2.TabIndex = 106;
            // 
            // lbxDepart
            // 
            this.lbxDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.lbxDepart.FormattingEnabled = true;
            this.lbxDepart.ItemHeight = 15;
            this.lbxDepart.Location = new System.Drawing.Point(499, 65);
            this.lbxDepart.Name = "lbxDepart";
            this.lbxDepart.Size = new System.Drawing.Size(124, 94);
            this.lbxDepart.TabIndex = 109;
            this.lbxDepart.Visible = false;
            this.lbxDepart.SelectedIndexChanged += new System.EventHandler(this.lbxDepart_SelectedIndexChanged);
            this.lbxDepart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxDepart_KeyDown);
            this.lbxDepart.Leave += new System.EventHandler(this.lbxDepart_Leave);
            this.lbxDepart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxDepart_MouseDown);
            // 
            // FrmIhspNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 386);
            this.Controls.Add(this.lbxDepart);
            this.Controls.Add(this.dgvIhspNotice);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIhspNotice";
            this.Text = "入院通知书";
            this.Activated += new System.EventHandler(this.FrmIhspNotice_Activated);
            this.Load += new System.EventHandler(this.FrmIhspNotice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspNotice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxHspcard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvIhspNotice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbxDepCode;
        private System.Windows.Forms.TextBox tbxDepart;
        private System.Windows.Forms.ListBox lbxDepart;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label5;
    }
}