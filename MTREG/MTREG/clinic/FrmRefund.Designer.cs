namespace MTREG.clinic
{
    partial class FrmRefund
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHspcard = new System.Windows.Forms.Label();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblIDCard = new System.Windows.Forms.Label();
            this.dgvCliniCost = new System.Windows.Forms.DataGridView();
            this.cbxAllcheck = new System.Windows.Forms.CheckBox();
            this.dgvClinicRcp0 = new System.Windows.Forms.DataGridView();
            this.checkrcp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbPatientType = new System.Windows.Forms.ComboBox();
            this.tbxPayfee = new System.Windows.Forms.TextBox();
            this.lblSelffee = new System.Windows.Forms.Label();
            this.tbxInsurfee = new System.Windows.Forms.TextBox();
            this.lblInsurfee = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxInsuraccountfee = new System.Windows.Forms.TextBox();
            this.lblInsuraccountfee = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblinvoiceCode = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPayType = new System.Windows.Forms.ComboBox();
            this.lblInvoiceMsg = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliniCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicRcp0)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "卡  号:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "科  室:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(190, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "姓  名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(192, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "医  生:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(321, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 45;
            this.label5.Text = "性    别:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(323, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "身份证号:";
            // 
            // lblHspcard
            // 
            this.lblHspcard.AutoSize = true;
            this.lblHspcard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHspcard.Location = new System.Drawing.Point(75, 18);
            this.lblHspcard.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHspcard.Name = "lblHspcard";
            this.lblHspcard.Size = new System.Drawing.Size(98, 16);
            this.lblHspcard.TabIndex = 47;
            this.lblHspcard.Text = "XXXXXXXXXX";
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDepart.Location = new System.Drawing.Point(75, 53);
            this.lblDepart.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(44, 16);
            this.lblDepart.TabIndex = 48;
            this.lblDepart.Text = "XXXX";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatientName.Location = new System.Drawing.Point(257, 18);
            this.lblPatientName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(44, 16);
            this.lblPatientName.TabIndex = 49;
            this.lblPatientName.Text = "XXXX";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoctor.Location = new System.Drawing.Point(260, 53);
            this.lblDoctor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(44, 16);
            this.lblDoctor.TabIndex = 50;
            this.lblDoctor.Text = "XXXX";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.Location = new System.Drawing.Point(404, 18);
            this.lblSex.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(44, 16);
            this.lblSex.TabIndex = 51;
            this.lblSex.Text = "XXXX";
            // 
            // lblIDCard
            // 
            this.lblIDCard.AutoSize = true;
            this.lblIDCard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIDCard.Location = new System.Drawing.Point(407, 53);
            this.lblIDCard.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIDCard.Name = "lblIDCard";
            this.lblIDCard.Size = new System.Drawing.Size(170, 16);
            this.lblIDCard.TabIndex = 52;
            this.lblIDCard.Text = "XXXXXXXXXXXXXXXXXX";
            // 
            // dgvCliniCost
            // 
            this.dgvCliniCost.AccessibleDescription = "";
            this.dgvCliniCost.AllowUserToAddRows = false;
            this.dgvCliniCost.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCliniCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCliniCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCliniCost.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCliniCost.Location = new System.Drawing.Point(6, 101);
            this.dgvCliniCost.Name = "dgvCliniCost";
            this.dgvCliniCost.RowHeadersVisible = false;
            this.dgvCliniCost.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvCliniCost.RowTemplate.Height = 23;
            this.dgvCliniCost.Size = new System.Drawing.Size(494, 276);
            this.dgvCliniCost.TabIndex = 66;
            this.dgvCliniCost.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCliniCost_CellContentClick);
            this.dgvCliniCost.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCliniCost_CellValueChanged);
            this.dgvCliniCost.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCliniCost_CurrentCellDirtyStateChanged);
            // 
            // cbxAllcheck
            // 
            this.cbxAllcheck.AutoSize = true;
            this.cbxAllcheck.Location = new System.Drawing.Point(54, 85);
            this.cbxAllcheck.Name = "cbxAllcheck";
            this.cbxAllcheck.Size = new System.Drawing.Size(15, 14);
            this.cbxAllcheck.TabIndex = 68;
            this.cbxAllcheck.UseVisualStyleBackColor = true;
            this.cbxAllcheck.Visible = false;
            this.cbxAllcheck.CheckStateChanged += new System.EventHandler(this.cbxAllcheck_CheckStateChanged);
            // 
            // dgvClinicRcp0
            // 
            this.dgvClinicRcp0.AllowUserToAddRows = false;
            this.dgvClinicRcp0.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClinicRcp0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClinicRcp0.ColumnHeadersHeight = 25;
            this.dgvClinicRcp0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkrcp});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClinicRcp0.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvClinicRcp0.Location = new System.Drawing.Point(509, 101);
            this.dgvClinicRcp0.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvClinicRcp0.Name = "dgvClinicRcp0";
            this.dgvClinicRcp0.RowHeadersVisible = false;
            this.dgvClinicRcp0.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvClinicRcp0.RowTemplate.Height = 23;
            this.dgvClinicRcp0.Size = new System.Drawing.Size(603, 276);
            this.dgvClinicRcp0.TabIndex = 69;
            this.dgvClinicRcp0.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClinicRcp0_CellValueChanged);
            this.dgvClinicRcp0.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvClinicRcp0_CurrentCellDirtyStateChanged);
            // 
            // checkrcp
            // 
            this.checkrcp.HeaderText = "";
            this.checkrcp.Name = "checkrcp";
            this.checkrcp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checkrcp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checkrcp.Width = 5;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(1033, 399);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 33);
            this.btnClose.TabIndex = 71;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(952, 399);
            this.btnOk.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 33);
            this.btnOk.TabIndex = 70;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbxAmount
            // 
            this.tbxAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.tbxAmount.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxAmount.Location = new System.Drawing.Point(819, 397);
            this.tbxAmount.Multiline = true;
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.ReadOnly = true;
            this.tbxAmount.Size = new System.Drawing.Size(97, 39);
            this.tbxAmount.TabIndex = 73;
            this.tbxAmount.Text = " ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(737, 403);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 29);
            this.label16.TabIndex = 72;
            this.label16.Text = "合计:";
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.ItemHeight = 16;
            this.cmbPatientType.Location = new System.Drawing.Point(566, 15);
            this.cmbPatientType.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.Size = new System.Drawing.Size(125, 24);
            this.cmbPatientType.TabIndex = 75;
            this.cmbPatientType.SelectionChangeCommitted += new System.EventHandler(this.cmbPatientType_SelectionChangeCommitted);
            // 
            // tbxPayfee
            // 
            this.tbxPayfee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.tbxPayfee.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPayfee.Location = new System.Drawing.Point(423, 397);
            this.tbxPayfee.Multiline = true;
            this.tbxPayfee.Name = "tbxPayfee";
            this.tbxPayfee.ReadOnly = true;
            this.tbxPayfee.Size = new System.Drawing.Size(102, 39);
            this.tbxPayfee.TabIndex = 77;
            this.tbxPayfee.Text = " ";
            // 
            // lblSelffee
            // 
            this.lblSelffee.AutoSize = true;
            this.lblSelffee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelffee.Location = new System.Drawing.Point(352, 410);
            this.lblSelffee.Name = "lblSelffee";
            this.lblSelffee.Size = new System.Drawing.Size(75, 14);
            this.lblSelffee.TabIndex = 76;
            this.lblSelffee.Text = "自费金额:";
            // 
            // tbxInsurfee
            // 
            this.tbxInsurfee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.tbxInsurfee.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInsurfee.Location = new System.Drawing.Point(90, 396);
            this.tbxInsurfee.Multiline = true;
            this.tbxInsurfee.Name = "tbxInsurfee";
            this.tbxInsurfee.ReadOnly = true;
            this.tbxInsurfee.Size = new System.Drawing.Size(87, 42);
            this.tbxInsurfee.TabIndex = 79;
            this.tbxInsurfee.Text = " ";
            // 
            // lblInsurfee
            // 
            this.lblInsurfee.AutoSize = true;
            this.lblInsurfee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInsurfee.Location = new System.Drawing.Point(18, 408);
            this.lblInsurfee.Name = "lblInsurfee";
            this.lblInsurfee.Size = new System.Drawing.Size(75, 14);
            this.lblInsurfee.TabIndex = 78;
            this.lblInsurfee.Text = "医保报销:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(481, 19);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 80;
            this.label7.Text = "患者类型:";
            // 
            // tbxInsuraccountfee
            // 
            this.tbxInsuraccountfee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.tbxInsuraccountfee.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInsuraccountfee.Location = new System.Drawing.Point(254, 397);
            this.tbxInsuraccountfee.Multiline = true;
            this.tbxInsuraccountfee.Name = "tbxInsuraccountfee";
            this.tbxInsuraccountfee.ReadOnly = true;
            this.tbxInsuraccountfee.Size = new System.Drawing.Size(88, 42);
            this.tbxInsuraccountfee.TabIndex = 105;
            this.tbxInsuraccountfee.Text = " ";
            // 
            // lblInsuraccountfee
            // 
            this.lblInsuraccountfee.AutoSize = true;
            this.lblInsuraccountfee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInsuraccountfee.Location = new System.Drawing.Point(183, 410);
            this.lblInsuraccountfee.Name = "lblInsuraccountfee";
            this.lblInsuraccountfee.Size = new System.Drawing.Size(75, 14);
            this.lblInsuraccountfee.TabIndex = 104;
            this.lblInsuraccountfee.Text = "个人账户:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(5, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 42;
            this.label8.Text = "全选:";
            this.label8.Visible = false;
            // 
            // lblinvoiceCode
            // 
            this.lblinvoiceCode.AutoSize = true;
            this.lblinvoiceCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblinvoiceCode.Location = new System.Drawing.Point(684, 53);
            this.lblinvoiceCode.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblinvoiceCode.Name = "lblinvoiceCode";
            this.lblinvoiceCode.Size = new System.Drawing.Size(170, 16);
            this.lblinvoiceCode.TabIndex = 107;
            this.lblinvoiceCode.Text = "XXXXXXXXXXXXXXXXXX";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(600, 53);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 106;
            this.label10.Text = "发票号:";
            // 
            // cmbPayType
            // 
            this.cmbPayType.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbPayType.FormattingEnabled = true;
            this.cmbPayType.Location = new System.Drawing.Point(531, 403);
            this.cmbPayType.Name = "cmbPayType";
            this.cmbPayType.Size = new System.Drawing.Size(97, 24);
            this.cmbPayType.TabIndex = 157;
            this.cmbPayType.SelectedValueChanged += new System.EventHandler(this.cmbPayType_SelectedValueChanged);
            // 
            // lblInvoiceMsg
            // 
            this.lblInvoiceMsg.AutoSize = true;
            this.lblInvoiceMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInvoiceMsg.ForeColor = System.Drawing.Color.Red;
            this.lblInvoiceMsg.Location = new System.Drawing.Point(798, 19);
            this.lblInvoiceMsg.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInvoiceMsg.Name = "lblInvoiceMsg";
            this.lblInvoiceMsg.Size = new System.Drawing.Size(35, 16);
            this.lblInvoiceMsg.TabIndex = 158;
            this.lblInvoiceMsg.Text = "xxx";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(881, 53);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 16);
            this.label9.TabIndex = 159;
            this.label9.Text = "xxx";
            // 
            // FrmRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 446);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblInvoiceMsg);
            this.Controls.Add(this.cmbPayType);
            this.Controls.Add(this.lblinvoiceCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbPatientType);
            this.Controls.Add(this.tbxInsuraccountfee);
            this.Controls.Add(this.lblInsuraccountfee);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxInsurfee);
            this.Controls.Add(this.lblInsurfee);
            this.Controls.Add(this.tbxPayfee);
            this.Controls.Add(this.lblSelffee);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvClinicRcp0);
            this.Controls.Add(this.cbxAllcheck);
            this.Controls.Add(this.dgvCliniCost);
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
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "FrmRefund";
            this.Text = "退费";
            this.Load += new System.EventHandler(this.FrmRefund_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliniCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicRcp0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHspcard;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblIDCard;
        private System.Windows.Forms.DataGridView dgvCliniCost;
        private System.Windows.Forms.CheckBox cbxAllcheck;
        private System.Windows.Forms.DataGridView dgvClinicRcp0;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbxAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbPatientType;
        private System.Windows.Forms.TextBox tbxPayfee;
        private System.Windows.Forms.Label lblSelffee;
        private System.Windows.Forms.TextBox tbxInsurfee;
        private System.Windows.Forms.Label lblInsurfee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxInsuraccountfee;
        private System.Windows.Forms.Label lblInsuraccountfee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkrcp;
        private System.Windows.Forms.Label lblinvoiceCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPayType;
        private System.Windows.Forms.Label lblInvoiceMsg;
        private System.Windows.Forms.Label label9;
    }
}