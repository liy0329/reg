namespace MTREG.clinic
{
    partial class FrmMemberSett
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxHspcard = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAgeunit = new System.Windows.Forms.ComboBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.tbxAge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxClinicCode = new System.Windows.Forms.TextBox();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPatienttype = new System.Windows.Forms.ComboBox();
            this.btnReadHealthcard = new System.Windows.Forms.Button();
            this.btnSett = new System.Windows.Forms.Button();
            this.dgvUnsettInvoice = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.billcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSettInvoice = new System.Windows.Forms.DataGridView();
            this.dgvCostdet = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurefee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selffee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.lblInsurefee = new System.Windows.Forms.Label();
            this.lblInsuraccountfee = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFeeamt = new System.Windows.Forms.Label();
            this.btnRePrint = new System.Windows.Forms.Button();
            this.btnRetcard = new System.Windows.Forms.Button();
            this.lblReadCardMsg = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnsettInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostdet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxName
            // 
            this.tbxName.Enabled = false;
            this.tbxName.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxName.Location = new System.Drawing.Point(208, 14);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(105, 24);
            this.tbxName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(168, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 35;
            this.label8.Text = "姓名:";
            // 
            // tbxHspcard
            // 
            this.tbxHspcard.Enabled = false;
            this.tbxHspcard.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxHspcard.Location = new System.Drawing.Point(64, 14);
            this.tbxHspcard.Name = "tbxHspcard";
            this.tbxHspcard.Size = new System.Drawing.Size(105, 24);
            this.tbxHspcard.TabIndex = 1;
            this.tbxHspcard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxHspcard_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(24, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "卡号:";
            // 
            // cmbAgeunit
            // 
            this.cmbAgeunit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeunit.Enabled = false;
            this.cmbAgeunit.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbAgeunit.FormattingEnabled = true;
            this.cmbAgeunit.ItemHeight = 15;
            this.cmbAgeunit.Location = new System.Drawing.Point(577, 13);
            this.cmbAgeunit.Name = "cmbAgeunit";
            this.cmbAgeunit.Size = new System.Drawing.Size(38, 23);
            this.cmbAgeunit.TabIndex = 5;
            // 
            // cmbSex
            // 
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.Enabled = false;
            this.cmbSex.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.ItemHeight = 15;
            this.cmbSex.Items.AddRange(new object[] {
            "男",
            "女",
            "未"});
            this.cmbSex.Location = new System.Drawing.Point(358, 14);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(105, 23);
            this.cmbSex.TabIndex = 3;
            // 
            // tbxAge
            // 
            this.tbxAge.Enabled = false;
            this.tbxAge.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxAge.Location = new System.Drawing.Point(515, 13);
            this.tbxAge.Name = "tbxAge";
            this.tbxAge.Size = new System.Drawing.Size(56, 24);
            this.tbxAge.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(474, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 42;
            this.label10.Text = "年龄:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11F);
            this.label9.Location = new System.Drawing.Point(318, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 41;
            this.label9.Text = "性别:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(9, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "门诊号:";
            // 
            // tbxClinicCode
            // 
            this.tbxClinicCode.Enabled = false;
            this.tbxClinicCode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxClinicCode.Location = new System.Drawing.Point(64, 51);
            this.tbxClinicCode.Name = "tbxClinicCode";
            this.tbxClinicCode.Size = new System.Drawing.Size(105, 24);
            this.tbxClinicCode.TabIndex = 7;
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.Enabled = false;
            this.cmbDoctor.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.ItemHeight = 15;
            this.cmbDoctor.Location = new System.Drawing.Point(358, 51);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(105, 23);
            this.cmbDoctor.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 11F);
            this.label14.Location = new System.Drawing.Point(318, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 15);
            this.label14.TabIndex = 61;
            this.label14.Text = "医生:";
            // 
            // cmbDepart
            // 
            this.cmbDepart.Enabled = false;
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 15;
            this.cmbDepart.Location = new System.Drawing.Point(208, 52);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(105, 23);
            this.cmbDepart.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 11F);
            this.label13.Location = new System.Drawing.Point(168, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 15);
            this.label13.TabIndex = 60;
            this.label13.Text = "科室:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(468, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 61;
            this.label4.Text = "就诊类别:";
            // 
            // cmbPatienttype
            // 
            this.cmbPatienttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatienttype.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbPatienttype.FormattingEnabled = true;
            this.cmbPatienttype.ItemHeight = 15;
            this.cmbPatienttype.Location = new System.Drawing.Point(539, 51);
            this.cmbPatienttype.Name = "cmbPatienttype";
            this.cmbPatienttype.Size = new System.Drawing.Size(100, 23);
            this.cmbPatienttype.TabIndex = 11;
            this.cmbPatienttype.SelectionChangeCommitted += new System.EventHandler(this.cmbPatienttype_SelectionChangeCommitted);
            // 
            // btnReadHealthcard
            // 
            this.btnReadHealthcard.Font = new System.Drawing.Font("宋体", 11F);
            this.btnReadHealthcard.Location = new System.Drawing.Point(668, 55);
            this.btnReadHealthcard.Name = "btnReadHealthcard";
            this.btnReadHealthcard.Size = new System.Drawing.Size(64, 25);
            this.btnReadHealthcard.TabIndex = 12;
            this.btnReadHealthcard.Text = "门诊卡";
            this.btnReadHealthcard.UseVisualStyleBackColor = true;
            this.btnReadHealthcard.Click += new System.EventHandler(this.btnReadHealthcard_Click);
            // 
            // btnSett
            // 
            this.btnSett.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSett.Location = new System.Drawing.Point(839, 8);
            this.btnSett.Name = "btnSett";
            this.btnSett.Size = new System.Drawing.Size(68, 25);
            this.btnSett.TabIndex = 13;
            this.btnSett.Text = "打印";
            this.btnSett.UseVisualStyleBackColor = true;
            this.btnSett.Click += new System.EventHandler(this.btnSett_Click);
            // 
            // dgvUnsettInvoice
            // 
            this.dgvUnsettInvoice.AllowUserToAddRows = false;
            this.dgvUnsettInvoice.AllowUserToDeleteRows = false;
            this.dgvUnsettInvoice.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnsettInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvUnsettInvoice.ColumnHeadersHeight = 25;
            this.dgvUnsettInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.billcode});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUnsettInvoice.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvUnsettInvoice.GridColor = System.Drawing.SystemColors.Control;
            this.dgvUnsettInvoice.Location = new System.Drawing.Point(13, 87);
            this.dgvUnsettInvoice.Name = "dgvUnsettInvoice";
            this.dgvUnsettInvoice.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnsettInvoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvUnsettInvoice.RowHeadersVisible = false;
            this.dgvUnsettInvoice.RowHeadersWidth = 40;
            this.dgvUnsettInvoice.RowTemplate.Height = 25;
            this.dgvUnsettInvoice.Size = new System.Drawing.Size(189, 178);
            this.dgvUnsettInvoice.TabIndex = 64;
            this.dgvUnsettInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnsettInvoice_CellContentClick);
            // 
            // check
            // 
            this.check.HeaderText = "选择";
            this.check.Name = "check";
            this.check.ReadOnly = true;
            this.check.Width = 50;
            // 
            // billcode
            // 
            this.billcode.DataPropertyName = "billcode";
            this.billcode.FillWeight = 250F;
            this.billcode.HeaderText = "单号";
            this.billcode.Name = "billcode";
            this.billcode.ReadOnly = true;
            this.billcode.Width = 150;
            // 
            // dgvSettInvoice
            // 
            this.dgvSettInvoice.AllowUserToAddRows = false;
            this.dgvSettInvoice.AllowUserToDeleteRows = false;
            this.dgvSettInvoice.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSettInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSettInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSettInvoice.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSettInvoice.GridColor = System.Drawing.SystemColors.Control;
            this.dgvSettInvoice.Location = new System.Drawing.Point(12, 275);
            this.dgvSettInvoice.Name = "dgvSettInvoice";
            this.dgvSettInvoice.ReadOnly = true;
            this.dgvSettInvoice.RowHeadersVisible = false;
            this.dgvSettInvoice.RowTemplate.Height = 25;
            this.dgvSettInvoice.Size = new System.Drawing.Size(190, 178);
            this.dgvSettInvoice.TabIndex = 64;
            this.dgvSettInvoice.SelectionChanged += new System.EventHandler(this.dgvSettInvoice_SelectionChanged);
            // 
            // dgvCostdet
            // 
            this.dgvCostdet.AllowUserToAddRows = false;
            this.dgvCostdet.AllowUserToDeleteRows = false;
            this.dgvCostdet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCostdet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCostdet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostdet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.spec,
            this.unit,
            this.num,
            this.prc,
            this.fee,
            this.insurefee,
            this.selffee,
            this.id});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCostdet.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvCostdet.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCostdet.Location = new System.Drawing.Point(208, 87);
            this.dgvCostdet.Name = "dgvCostdet";
            this.dgvCostdet.ReadOnly = true;
            this.dgvCostdet.RowHeadersVisible = false;
            this.dgvCostdet.RowHeadersWidth = 30;
            this.dgvCostdet.RowTemplate.Height = 25;
            this.dgvCostdet.Size = new System.Drawing.Size(681, 346);
            this.dgvCostdet.TabIndex = 64;
            this.dgvCostdet.DataSourceChanged += new System.EventHandler(this.dgvCostdet_DataSourceChanged);
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // spec
            // 
            this.spec.DataPropertyName = "spec";
            this.spec.HeaderText = "规格";
            this.spec.Name = "spec";
            this.spec.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // num
            // 
            this.num.DataPropertyName = "num";
            this.num.HeaderText = "数量";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // prc
            // 
            this.prc.DataPropertyName = "prc";
            this.prc.HeaderText = "单价";
            this.prc.Name = "prc";
            this.prc.ReadOnly = true;
            // 
            // fee
            // 
            this.fee.DataPropertyName = "fee";
            this.fee.HeaderText = "费用";
            this.fee.Name = "fee";
            this.fee.ReadOnly = true;
            // 
            // insurefee
            // 
            this.insurefee.DataPropertyName = "insurefee";
            this.insurefee.HeaderText = "医保报销";
            this.insurefee.Name = "insurefee";
            this.insurefee.ReadOnly = true;
            // 
            // selffee
            // 
            this.selffee.DataPropertyName = "selffee";
            this.selffee.HeaderText = "账户支付";
            this.selffee.Name = "selffee";
            this.selffee.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(205, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 35;
            this.label5.Text = "医保报销:";
            // 
            // lblInsurefee
            // 
            this.lblInsurefee.AutoSize = true;
            this.lblInsurefee.Font = new System.Drawing.Font("宋体", 11F);
            this.lblInsurefee.Location = new System.Drawing.Point(269, 437);
            this.lblInsurefee.Name = "lblInsurefee";
            this.lblInsurefee.Size = new System.Drawing.Size(103, 15);
            this.lblInsurefee.TabIndex = 35;
            this.lblInsurefee.Text = "            ";
            // 
            // lblInsuraccountfee
            // 
            this.lblInsuraccountfee.AutoSize = true;
            this.lblInsuraccountfee.Font = new System.Drawing.Font("宋体", 11F);
            this.lblInsuraccountfee.Location = new System.Drawing.Point(447, 437);
            this.lblInsuraccountfee.Name = "lblInsuraccountfee";
            this.lblInsuraccountfee.Size = new System.Drawing.Size(127, 15);
            this.lblInsuraccountfee.TabIndex = 66;
            this.lblInsuraccountfee.Text = "               ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11F);
            this.label11.Location = new System.Drawing.Point(378, 437);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 65;
            this.label11.Text = "账户支付:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 11F);
            this.label12.Location = new System.Drawing.Point(558, 437);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 15);
            this.label12.TabIndex = 65;
            this.label12.Text = "总金额:";
            // 
            // lblFeeamt
            // 
            this.lblFeeamt.AutoSize = true;
            this.lblFeeamt.Font = new System.Drawing.Font("宋体", 11F);
            this.lblFeeamt.Location = new System.Drawing.Point(614, 437);
            this.lblFeeamt.Name = "lblFeeamt";
            this.lblFeeamt.Size = new System.Drawing.Size(151, 15);
            this.lblFeeamt.TabIndex = 66;
            this.lblFeeamt.Text = "                  ";
            // 
            // btnRePrint
            // 
            this.btnRePrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRePrint.Location = new System.Drawing.Point(752, 52);
            this.btnRePrint.Name = "btnRePrint";
            this.btnRePrint.Size = new System.Drawing.Size(68, 25);
            this.btnRePrint.TabIndex = 13;
            this.btnRePrint.Text = "打印";
            this.btnRePrint.UseVisualStyleBackColor = true;
            // 
            // btnRetcard
            // 
            this.btnRetcard.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRetcard.Location = new System.Drawing.Point(839, 50);
            this.btnRetcard.Name = "btnRetcard";
            this.btnRetcard.Size = new System.Drawing.Size(68, 25);
            this.btnRetcard.TabIndex = 13;
            this.btnRetcard.Text = "退费";
            this.btnRetcard.UseVisualStyleBackColor = true;
            this.btnRetcard.Visible = false;
            this.btnRetcard.Click += new System.EventHandler(this.btnRetcard_Click);
            // 
            // lblReadCardMsg
            // 
            this.lblReadCardMsg.AutoSize = true;
            this.lblReadCardMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadCardMsg.ForeColor = System.Drawing.Color.Blue;
            this.lblReadCardMsg.Location = new System.Drawing.Point(614, 33);
            this.lblReadCardMsg.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReadCardMsg.Name = "lblReadCardMsg";
            this.lblReadCardMsg.Size = new System.Drawing.Size(127, 16);
            this.lblReadCardMsg.TabIndex = 104;
            this.lblReadCardMsg.Text = "读卡是否成功法";
            this.lblReadCardMsg.Visible = false;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStartDate.Location = new System.Drawing.Point(695, 14);
            this.dtpStartDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(134, 24);
            this.dtpStartDate.TabIndex = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(625, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 106;
            this.label1.Text = "处方日期:";
            // 
            // FrmMemberSett
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 465);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.tbxClinicCode);
            this.Controls.Add(this.lblReadCardMsg);
            this.Controls.Add(this.lblFeeamt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblInsuraccountfee);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvSettInvoice);
            this.Controls.Add(this.dgvCostdet);
            this.Controls.Add(this.dgvUnsettInvoice);
            this.Controls.Add(this.btnRetcard);
            this.Controls.Add(this.btnRePrint);
            this.Controls.Add(this.btnSett);
            this.Controls.Add(this.btnReadHealthcard);
            this.Controls.Add(this.cmbPatienttype);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbAgeunit);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.tbxAge);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbxHspcard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblInsurefee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Name = "FrmMemberSett";
            this.Text = "会员卡结算";
            this.Load += new System.EventHandler(this.FrmMemberSett_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnsettInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxHspcard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAgeunit;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.TextBox tbxAge;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxClinicCode;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPatienttype;
        private System.Windows.Forms.Button btnReadHealthcard;
        private System.Windows.Forms.Button btnSett;
        private System.Windows.Forms.DataGridView dgvUnsettInvoice;
        private System.Windows.Forms.DataGridView dgvSettInvoice;
        private System.Windows.Forms.DataGridView dgvCostdet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblInsurefee;
        private System.Windows.Forms.Label lblInsuraccountfee;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblFeeamt;
        private System.Windows.Forms.Button btnRePrint;
        private System.Windows.Forms.Button btnRetcard;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn billcode;
        private System.Windows.Forms.Label lblReadCardMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn prc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurefee;
        private System.Windows.Forms.DataGridViewTextBoxColumn selffee;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
    }
}