namespace MTREG.ihsp
{
    partial class FrmIhspPay
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
            this.tbxPayMan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCheque = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPayFee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRetIhspPay = new System.Windows.Forms.Button();
            this.cmbPayType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lable18 = new System.Windows.Forms.Label();
            this.lable20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblHspcard = new System.Windows.Forms.Label();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFeeamt = new System.Windows.Forms.Label();
            this.lblBalanceamt = new System.Windows.Forms.Label();
            this.lblPrepamt = new System.Windows.Forms.Label();
            this.btnRePrint = new System.Windows.Forms.Button();
            this.btnAddIhspPay = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBillcode = new System.Windows.Forms.Label();
            this.dgvIhspPayinadv = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblIhspcode = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInvoiceMsg = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tbx_authCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspPayinadv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxPayMan
            // 
            this.tbxPayMan.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxPayMan.Location = new System.Drawing.Point(533, 82);
            this.tbxPayMan.Name = "tbxPayMan";
            this.tbxPayMan.Size = new System.Drawing.Size(91, 24);
            this.tbxPayMan.TabIndex = 4;
            this.tbxPayMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPayMan_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(478, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "交款人:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(158, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "交款方式:";
            // 
            // tbxCheque
            // 
            this.tbxCheque.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxCheque.Location = new System.Drawing.Point(377, 82);
            this.tbxCheque.Name = "tbxCheque";
            this.tbxCheque.Size = new System.Drawing.Size(95, 24);
            this.tbxCheque.TabIndex = 3;
            this.tbxCheque.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCheque_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(321, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "支票号:";
            // 
            // tbxPayFee
            // 
            this.tbxPayFee.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxPayFee.Location = new System.Drawing.Point(82, 82);
            this.tbxPayFee.Name = "tbxPayFee";
            this.tbxPayFee.Size = new System.Drawing.Size(70, 24);
            this.tbxPayFee.TabIndex = 9;
            this.tbxPayFee.TextChanged += new System.EventHandler(this.tbxPayFee_TextChanged);
            this.tbxPayFee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPayFee_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(12, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "交款金额:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 11F);
            this.btnClose.Location = new System.Drawing.Point(630, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 25);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // btnRetIhspPay
            // 
            this.btnRetIhspPay.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRetIhspPay.Location = new System.Drawing.Point(168, 115);
            this.btnRetIhspPay.Name = "btnRetIhspPay";
            this.btnRetIhspPay.Size = new System.Drawing.Size(73, 25);
            this.btnRetIhspPay.TabIndex = 7;
            this.btnRetIhspPay.Text = "撤销";
            this.btnRetIhspPay.UseVisualStyleBackColor = true;
            this.btnRetIhspPay.Click += new System.EventHandler(this.btnRetChrg_Click);
            this.btnRetIhspPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRetChrg_KeyDown);
            // 
            // cmbPayType
            // 
            this.cmbPayType.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbPayType.FormattingEnabled = true;
            this.cmbPayType.ItemHeight = 15;
            this.cmbPayType.Location = new System.Drawing.Point(229, 82);
            this.cmbPayType.Name = "cmbPayType";
            this.cmbPayType.Size = new System.Drawing.Size(87, 23);
            this.cmbPayType.TabIndex = 2;
            this.cmbPayType.SelectedValueChanged += new System.EventHandler(this.cmbPayType_SelectedValueChanged);
            this.cmbPayType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPayType_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(306, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "就诊卡号:";
            // 
            // lable18
            // 
            this.lable18.AutoSize = true;
            this.lable18.Font = new System.Drawing.Font("宋体", 11F);
            this.lable18.Location = new System.Drawing.Point(177, 13);
            this.lable18.Name = "lable18";
            this.lable18.Size = new System.Drawing.Size(45, 15);
            this.lable18.TabIndex = 5;
            this.lable18.Text = "姓名:";
            // 
            // lable20
            // 
            this.lable20.AutoSize = true;
            this.lable20.Font = new System.Drawing.Font("宋体", 11F);
            this.lable20.Location = new System.Drawing.Point(493, 13);
            this.lable20.Name = "lable20";
            this.lable20.Size = new System.Drawing.Size(45, 15);
            this.lable20.TabIndex = 5;
            this.lable20.Text = "科室:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(5, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "已用金额:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11F);
            this.label9.Location = new System.Drawing.Point(147, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "剩余金额:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(306, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "预付金额:";
            // 
            // lblHspcard
            // 
            this.lblHspcard.AutoSize = true;
            this.lblHspcard.Font = new System.Drawing.Font("宋体", 11F);
            this.lblHspcard.Location = new System.Drawing.Point(374, 13);
            this.lblHspcard.Name = "lblHspcard";
            this.lblHspcard.Size = new System.Drawing.Size(52, 15);
            this.lblHspcard.TabIndex = 75;
            this.lblHspcard.Text = "×××";
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.lblDepart.Location = new System.Drawing.Point(531, 13);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(52, 15);
            this.lblDepart.TabIndex = 75;
            this.lblDepart.Text = "×××";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 11F);
            this.lblName.Location = new System.Drawing.Point(215, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 15);
            this.lblName.TabIndex = 75;
            this.lblName.Text = "×××";
            // 
            // lblFeeamt
            // 
            this.lblFeeamt.AutoSize = true;
            this.lblFeeamt.Font = new System.Drawing.Font("宋体", 11F);
            this.lblFeeamt.Location = new System.Drawing.Point(73, 43);
            this.lblFeeamt.Name = "lblFeeamt";
            this.lblFeeamt.Size = new System.Drawing.Size(52, 15);
            this.lblFeeamt.TabIndex = 75;
            this.lblFeeamt.Text = "×××";
            // 
            // lblBalanceamt
            // 
            this.lblBalanceamt.AutoSize = true;
            this.lblBalanceamt.Font = new System.Drawing.Font("宋体", 11F);
            this.lblBalanceamt.Location = new System.Drawing.Point(215, 43);
            this.lblBalanceamt.Name = "lblBalanceamt";
            this.lblBalanceamt.Size = new System.Drawing.Size(52, 15);
            this.lblBalanceamt.TabIndex = 75;
            this.lblBalanceamt.Text = "×××";
            // 
            // lblPrepamt
            // 
            this.lblPrepamt.AutoSize = true;
            this.lblPrepamt.Font = new System.Drawing.Font("宋体", 11F);
            this.lblPrepamt.Location = new System.Drawing.Point(374, 43);
            this.lblPrepamt.Name = "lblPrepamt";
            this.lblPrepamt.Size = new System.Drawing.Size(52, 15);
            this.lblPrepamt.TabIndex = 75;
            this.lblPrepamt.Text = "×××";
            // 
            // btnRePrint
            // 
            this.btnRePrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRePrint.Location = new System.Drawing.Point(83, 114);
            this.btnRePrint.Name = "btnRePrint";
            this.btnRePrint.Size = new System.Drawing.Size(80, 25);
            this.btnRePrint.TabIndex = 6;
            this.btnRePrint.Text = "重打";
            this.btnRePrint.UseVisualStyleBackColor = true;
            this.btnRePrint.Click += new System.EventHandler(this.btnRePrint_Click);
            this.btnRePrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRePrint_KeyDown);
            // 
            // btnAddIhspPay
            // 
            this.btnAddIhspPay.Font = new System.Drawing.Font("宋体", 11F);
            this.btnAddIhspPay.Location = new System.Drawing.Point(8, 114);
            this.btnAddIhspPay.Name = "btnAddIhspPay";
            this.btnAddIhspPay.Size = new System.Drawing.Size(73, 25);
            this.btnAddIhspPay.TabIndex = 5;
            this.btnAddIhspPay.Text = "缴费";
            this.btnAddIhspPay.UseVisualStyleBackColor = true;
            this.btnAddIhspPay.Click += new System.EventHandler(this.btnAddIhspPay_Click);
            this.btnAddIhspPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDoChrg_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11F);
            this.label11.Location = new System.Drawing.Point(478, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 77;
            this.label11.Text = "单据号:";
            // 
            // lblBillcode
            // 
            this.lblBillcode.AutoSize = true;
            this.lblBillcode.Font = new System.Drawing.Font("宋体", 11F);
            this.lblBillcode.Location = new System.Drawing.Point(531, 43);
            this.lblBillcode.Name = "lblBillcode";
            this.lblBillcode.Size = new System.Drawing.Size(52, 15);
            this.lblBillcode.TabIndex = 75;
            this.lblBillcode.Text = "×××";
            // 
            // dgvIhspPayinadv
            // 
            this.dgvIhspPayinadv.AllowUserToAddRows = false;
            this.dgvIhspPayinadv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhspPayinadv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIhspPayinadv.ColumnHeadersHeight = 30;
            this.dgvIhspPayinadv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIhspPayinadv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIhspPayinadv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIhspPayinadv.Location = new System.Drawing.Point(0, 146);
            this.dgvIhspPayinadv.Name = "dgvIhspPayinadv";
            this.dgvIhspPayinadv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhspPayinadv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIhspPayinadv.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvIhspPayinadv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIhspPayinadv.RowTemplate.Height = 23;
            this.dgvIhspPayinadv.Size = new System.Drawing.Size(812, 344);
            this.dgvIhspPayinadv.TabIndex = 78;
            this.dgvIhspPayinadv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHospitalPayinadv_CellContentClick_1);
            this.dgvIhspPayinadv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvHospitalPayinadv_CellPainting);
            this.dgvIhspPayinadv.SelectionChanged += new System.EventHandler(this.dgvIhspPayinadv_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(20, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "住院号:";
            // 
            // lblIhspcode
            // 
            this.lblIhspcode.AutoSize = true;
            this.lblIhspcode.Font = new System.Drawing.Font("宋体", 11F);
            this.lblIhspcode.Location = new System.Drawing.Point(73, 13);
            this.lblIhspcode.Name = "lblIhspcode";
            this.lblIhspcode.Size = new System.Drawing.Size(52, 15);
            this.lblIhspcode.TabIndex = 75;
            this.lblIhspcode.Text = "×××";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInvoiceMsg);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.tbx_authCode);
            this.panel1.Controls.Add(this.tbxPayFee);
            this.panel1.Controls.Add(this.tbxPayMan);
            this.panel1.Controls.Add(this.tbxCheque);
            this.panel1.Controls.Add(this.cmbPayType);
            this.panel1.Controls.Add(this.lblBillcode);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblFeeamt);
            this.panel1.Controls.Add(this.lblPrepamt);
            this.panel1.Controls.Add(this.lblBalanceamt);
            this.panel1.Controls.Add(this.lblIhspcode);
            this.panel1.Controls.Add(this.lblDepart);
            this.panel1.Controls.Add(this.lblHspcard);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lable18);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lable20);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnRetIhspPay);
            this.panel1.Controls.Add(this.btnAddIhspPay);
            this.panel1.Controls.Add(this.btnRePrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 146);
            this.panel1.TabIndex = 79;
            // 
            // lblInvoiceMsg
            // 
            this.lblInvoiceMsg.AutoSize = true;
            this.lblInvoiceMsg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInvoiceMsg.ForeColor = System.Drawing.Color.Red;
            this.lblInvoiceMsg.Location = new System.Drawing.Point(450, 121);
            this.lblInvoiceMsg.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInvoiceMsg.Name = "lblInvoiceMsg";
            this.lblInvoiceMsg.Size = new System.Drawing.Size(191, 14);
            this.lblInvoiceMsg.TabIndex = 728;
            this.lblInvoiceMsg.Text = "                       ";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(259, 119);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(68, 16);
            this.label33.TabIndex = 727;
            this.label33.Text = "付款码:";
            // 
            // tbx_authCode
            // 
            this.tbx_authCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_authCode.Location = new System.Drawing.Point(332, 113);
            this.tbx_authCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_authCode.Name = "tbx_authCode";
            this.tbx_authCode.Size = new System.Drawing.Size(94, 26);
            this.tbx_authCode.TabIndex = 726;
            // 
            // FrmIhspPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 490);
            this.Controls.Add(this.dgvIhspPayinadv);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIhspPay";
            this.Text = "预付款";
            this.Activated += new System.EventHandler(this.FrmIhspPay_Activated);
            this.Load += new System.EventHandler(this.FrmIhspPay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspPayinadv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPayMan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxCheque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPayFee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRetIhspPay;
        private System.Windows.Forms.ComboBox cmbPayType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lable18;
        private System.Windows.Forms.Label lable20;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblHspcard;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFeeamt;
        private System.Windows.Forms.Label lblBalanceamt;
        private System.Windows.Forms.Label lblPrepamt;
        private System.Windows.Forms.Button btnRePrint;
        private System.Windows.Forms.Button btnAddIhspPay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBillcode;
        private System.Windows.Forms.DataGridView dgvIhspPayinadv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIhspcode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInvoiceMsg;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbx_authCode;
    }
}