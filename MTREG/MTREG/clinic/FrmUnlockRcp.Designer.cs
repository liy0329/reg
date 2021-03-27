namespace MTREG.clinic
{
    partial class FrmUnlockRcp
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
            this.cbxAllcheck = new System.Windows.Forms.CheckBox();
            this.dgvCliniCost = new System.Windows.Forms.DataGridView();
            this.dgvClinicRcp0 = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblIDCard = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblHspcard = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliniCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicRcp0)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxAllcheck
            // 
            this.cbxAllcheck.AutoSize = true;
            this.cbxAllcheck.Location = new System.Drawing.Point(80, 82);
            this.cbxAllcheck.Name = "cbxAllcheck";
            this.cbxAllcheck.Size = new System.Drawing.Size(15, 14);
            this.cbxAllcheck.TabIndex = 84;
            this.cbxAllcheck.UseVisualStyleBackColor = true;
            this.cbxAllcheck.CheckStateChanged += new System.EventHandler(this.cbxAllcheck_CheckStateChanged);
            // 
            // dgvCliniCost
            // 
            this.dgvCliniCost.AccessibleDescription = "";
            this.dgvCliniCost.AllowUserToAddRows = false;
            this.dgvCliniCost.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCliniCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCliniCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCliniCost.Location = new System.Drawing.Point(5, 100);
            this.dgvCliniCost.Name = "dgvCliniCost";
            this.dgvCliniCost.RowHeadersVisible = false;
            this.dgvCliniCost.RowTemplate.Height = 23;
            this.dgvCliniCost.Size = new System.Drawing.Size(498, 255);
            this.dgvCliniCost.TabIndex = 83;
            this.dgvCliniCost.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCliniCost_CellValueChanged);
            this.dgvCliniCost.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCliniCost_CurrentCellDirtyStateChanged);
            // 
            // dgvClinicRcp0
            // 
            this.dgvClinicRcp0.AllowUserToAddRows = false;
            this.dgvClinicRcp0.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClinicRcp0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClinicRcp0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClinicRcp0.Location = new System.Drawing.Point(507, 100);
            this.dgvClinicRcp0.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvClinicRcp0.Name = "dgvClinicRcp0";
            this.dgvClinicRcp0.RowHeadersVisible = false;
            this.dgvClinicRcp0.RowTemplate.Height = 23;
            this.dgvClinicRcp0.Size = new System.Drawing.Size(493, 255);
            this.dgvClinicRcp0.TabIndex = 85;
            this.dgvClinicRcp0.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClinicRcp0_CellValueChanged);
            this.dgvClinicRcp0.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvClinicRcp0_CurrentCellDirtyStateChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(634, 365);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 87;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(547, 365);
            this.btnOk.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 33);
            this.btnOk.TabIndex = 86;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbxAmount
            // 
            this.tbxAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.tbxAmount.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxAmount.Location = new System.Drawing.Point(207, 364);
            this.tbxAmount.Multiline = true;
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.ReadOnly = true;
            this.tbxAmount.Size = new System.Drawing.Size(158, 48);
            this.tbxAmount.TabIndex = 89;
            this.tbxAmount.Text = " ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(121, 372);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 29);
            this.label16.TabIndex = 88;
            this.label16.Text = "合计:";
            // 
            // lblIDCard
            // 
            this.lblIDCard.AutoSize = true;
            this.lblIDCard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIDCard.Location = new System.Drawing.Point(480, 44);
            this.lblIDCard.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIDCard.Name = "lblIDCard";
            this.lblIDCard.Size = new System.Drawing.Size(170, 16);
            this.lblIDCard.TabIndex = 101;
            this.lblIDCard.Text = "XXXXXXXXXXXXXXXXXX";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.Location = new System.Drawing.Point(480, 9);
            this.lblSex.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(44, 16);
            this.lblSex.TabIndex = 100;
            this.lblSex.Text = "XXXX";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoctor.Location = new System.Drawing.Point(288, 44);
            this.lblDoctor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(44, 16);
            this.lblDoctor.TabIndex = 99;
            this.lblDoctor.Text = "XXXX";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatientName.Location = new System.Drawing.Point(288, 9);
            this.lblPatientName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(44, 16);
            this.lblPatientName.TabIndex = 98;
            this.lblPatientName.Text = "XXXX";
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDepart.Location = new System.Drawing.Point(92, 44);
            this.lblDepart.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(44, 16);
            this.lblDepart.TabIndex = 97;
            this.lblDepart.Text = "XXXX";
            // 
            // lblHspcard
            // 
            this.lblHspcard.AutoSize = true;
            this.lblHspcard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHspcard.Location = new System.Drawing.Point(92, 9);
            this.lblHspcard.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHspcard.Name = "lblHspcard";
            this.lblHspcard.Size = new System.Drawing.Size(98, 16);
            this.lblHspcard.TabIndex = 96;
            this.lblHspcard.Text = "XXXXXXXXXX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(390, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 95;
            this.label6.Text = "身份证号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(388, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 94;
            this.label5.Text = "性    别:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(215, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 93;
            this.label3.Text = "医  生:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(214, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 92;
            this.label2.Text = "姓  名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 91;
            this.label1.Text = "科  室:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(20, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 90;
            this.label4.Text = "卡  号:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(20, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 102;
            this.label8.Text = "全选:";
            // 
            // FrmUnlockRcp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 421);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblIDCard);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblDepart);
            this.Controls.Add(this.lblHspcard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvClinicRcp0);
            this.Controls.Add(this.cbxAllcheck);
            this.Controls.Add(this.dgvCliniCost);
            this.Name = "FrmUnlockRcp";
            this.Text = "解锁处方";
            this.Load += new System.EventHandler(this.FrmUnlockRcp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliniCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicRcp0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxAllcheck;
        private System.Windows.Forms.DataGridView dgvCliniCost;
        private System.Windows.Forms.DataGridView dgvClinicRcp0;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbxAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblIDCard;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblHspcard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
    }
}