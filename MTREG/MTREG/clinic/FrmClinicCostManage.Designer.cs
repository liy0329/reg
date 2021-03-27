namespace MTREG.clinic
{
    partial class FrmClinicCostManage
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
            this.tbxmobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbChargeby = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxIsLocked = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpEtime = new System.Windows.Forms.DateTimePicker();
            this.dtpStime = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.dgvCostdet = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIsret = new System.Windows.Forms.ComboBox();
            this.btnRePrint = new System.Windows.Forms.Button();
            this.labsfzs = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.labtfzs = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labssje = new System.Windows.Forms.Label();
            this.labtfje = new System.Windows.Forms.Label();
            this.labsfje = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostdet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxmobile
            // 
            this.tbxmobile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxmobile.Location = new System.Drawing.Point(513, 10);
            this.tbxmobile.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.tbxmobile.Name = "tbxmobile";
            this.tbxmobile.Size = new System.Drawing.Size(210, 35);
            this.tbxmobile.TabIndex = 1;
            this.tbxmobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPatientName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(440, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "电话:";
            // 
            // tbxPatientName
            // 
            this.tbxPatientName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPatientName.Location = new System.Drawing.Point(513, 57);
            this.tbxPatientName.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.tbxPatientName.Name = "tbxPatientName";
            this.tbxPatientName.Size = new System.Drawing.Size(210, 35);
            this.tbxPatientName.TabIndex = 2;
            this.tbxPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPatientName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(440, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "姓名:";
            // 
            // cmbDepart
            // 
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 24;
            this.cmbDepart.Location = new System.Drawing.Point(832, 10);
            this.cmbDepart.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(160, 32);
            this.cmbDepart.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(759, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 24);
            this.label11.TabIndex = 51;
            this.label11.Text = "科室:";
            // 
            // cmbChargeby
            // 
            this.cmbChargeby.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbChargeby.FormattingEnabled = true;
            this.cmbChargeby.ItemHeight = 24;
            this.cmbChargeby.Location = new System.Drawing.Point(832, 57);
            this.cmbChargeby.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.cmbChargeby.Name = "cmbChargeby";
            this.cmbChargeby.Size = new System.Drawing.Size(160, 32);
            this.cmbChargeby.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(735, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 53;
            this.label4.Text = "收费员:";
            // 
            // cbxIsLocked
            // 
            this.cbxIsLocked.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxIsLocked.FormattingEnabled = true;
            this.cbxIsLocked.ItemHeight = 24;
            this.cbxIsLocked.Location = new System.Drawing.Point(1302, 12);
            this.cbxIsLocked.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.cbxIsLocked.Name = "cbxIsLocked";
            this.cbxIsLocked.Size = new System.Drawing.Size(142, 32);
            this.cbxIsLocked.TabIndex = 7;
            this.cbxIsLocked.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(1174, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 24);
            this.label5.TabIndex = 55;
            this.label5.Text = "是否解锁:";
            this.label5.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(8, 63);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 24);
            this.label15.TabIndex = 62;
            this.label15.Text = "终止时间:";
            // 
            // dtpEtime
            // 
            this.dtpEtime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEtime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEtime.Location = new System.Drawing.Point(130, 58);
            this.dtpEtime.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.Size = new System.Drawing.Size(289, 35);
            this.dtpEtime.TabIndex = 6;
            // 
            // dtpStime
            // 
            this.dtpStime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStime.Location = new System.Drawing.Point(130, 12);
            this.dtpStime.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.dtpStime.Name = "dtpStime";
            this.dtpStime.Size = new System.Drawing.Size(289, 35);
            this.dtpStime.TabIndex = 5;
            this.dtpStime.Value = new System.DateTime(2017, 6, 23, 0, 0, 0, 0);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(8, 20);
            this.label18.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 24);
            this.label18.TabIndex = 61;
            this.label18.Text = "开始时间:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(1012, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.TabIndex = 63;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.Enabled = false;
            this.btnRefund.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRefund.Location = new System.Drawing.Point(1336, 10);
            this.btnRefund.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(108, 40);
            this.btnRefund.TabIndex = 65;
            this.btnRefund.Text = "退费";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Visible = false;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoice.ColumnHeadersHeight = 25;
            this.dgvInvoice.Location = new System.Drawing.Point(8, 102);
            this.dgvInvoice.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvInvoice.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoice.RowTemplate.Height = 23;
            this.dgvInvoice.Size = new System.Drawing.Size(1467, 374);
            this.dgvInvoice.TabIndex = 66;
            this.dgvInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellContentClick);
            this.dgvInvoice.SelectionChanged += new System.EventHandler(this.dgvInvoice_SelectionChanged);
            // 
            // dgvCostdet
            // 
            this.dgvCostdet.AllowUserToAddRows = false;
            this.dgvCostdet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCostdet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCostdet.ColumnHeadersHeight = 25;
            this.dgvCostdet.Location = new System.Drawing.Point(8, 508);
            this.dgvCostdet.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.dgvCostdet.Name = "dgvCostdet";
            this.dgvCostdet.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvCostdet.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCostdet.RowTemplate.Height = 23;
            this.dgvCostdet.Size = new System.Drawing.Size(1467, 280);
            this.dgvCostdet.TabIndex = 66;
            this.dgvCostdet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCostdet_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(3, 477);
            this.label6.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 55;
            this.label6.Text = "费用明细";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 11F);
            this.btnReset.Location = new System.Drawing.Point(1150, 54);
            this.btnReset.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 40);
            this.btnReset.TabIndex = 63;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(1174, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 24);
            this.label3.TabIndex = 53;
            this.label3.Text = "是否退费:";
            this.label3.Visible = false;
            // 
            // cmbIsret
            // 
            this.cmbIsret.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbIsret.FormattingEnabled = true;
            this.cmbIsret.ItemHeight = 24;
            this.cmbIsret.Location = new System.Drawing.Point(1302, 51);
            this.cmbIsret.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.cmbIsret.Name = "cmbIsret";
            this.cmbIsret.Size = new System.Drawing.Size(142, 32);
            this.cmbIsret.TabIndex = 4;
            this.cmbIsret.Visible = false;
            // 
            // btnRePrint
            // 
            this.btnRePrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRePrint.Location = new System.Drawing.Point(1012, 54);
            this.btnRePrint.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.btnRePrint.Name = "btnRePrint";
            this.btnRePrint.Size = new System.Drawing.Size(120, 40);
            this.btnRePrint.TabIndex = 64;
            this.btnRePrint.Text = "打印发票";
            this.btnRePrint.UseVisualStyleBackColor = true;
            this.btnRePrint.Click += new System.EventHandler(this.btnRePrint_Click);
            // 
            // labsfzs
            // 
            this.labsfzs.AutoSize = true;
            this.labsfzs.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labsfzs.ForeColor = System.Drawing.Color.Red;
            this.labsfzs.Location = new System.Drawing.Point(1134, 480);
            this.labsfzs.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.labsfzs.Name = "labsfzs";
            this.labsfzs.Size = new System.Drawing.Size(22, 24);
            this.labsfzs.TabIndex = 87;
            this.labsfzs.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(1242, 478);
            this.label19.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 24);
            this.label19.TabIndex = 86;
            this.label19.Text = "退费张数:";
            // 
            // labtfzs
            // 
            this.labtfzs.AutoSize = true;
            this.labtfzs.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labtfzs.ForeColor = System.Drawing.Color.Red;
            this.labtfzs.Location = new System.Drawing.Point(1359, 483);
            this.labtfzs.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.labtfzs.Name = "labtfzs";
            this.labtfzs.Size = new System.Drawing.Size(22, 24);
            this.labtfzs.TabIndex = 85;
            this.labtfzs.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(1002, 480);
            this.label16.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 24);
            this.label16.TabIndex = 84;
            this.label16.Text = "收费张数:";
            // 
            // labssje
            // 
            this.labssje.AutoSize = true;
            this.labssje.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labssje.ForeColor = System.Drawing.Color.Red;
            this.labssje.Location = new System.Drawing.Point(802, 480);
            this.labssje.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.labssje.Name = "labssje";
            this.labssje.Size = new System.Drawing.Size(22, 24);
            this.labssje.TabIndex = 83;
            this.labssje.Text = "0";
            // 
            // labtfje
            // 
            this.labtfje.AutoSize = true;
            this.labtfje.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labtfje.ForeColor = System.Drawing.Color.Red;
            this.labtfje.Location = new System.Drawing.Point(549, 482);
            this.labtfje.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.labtfje.Name = "labtfje";
            this.labtfje.Size = new System.Drawing.Size(22, 24);
            this.labtfje.TabIndex = 82;
            this.labtfje.Text = "0";
            // 
            // labsfje
            // 
            this.labsfje.AutoSize = true;
            this.labsfje.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labsfje.ForeColor = System.Drawing.Color.Red;
            this.labsfje.Location = new System.Drawing.Point(309, 480);
            this.labsfje.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.labsfje.Name = "labsfje";
            this.labsfje.Size = new System.Drawing.Size(22, 24);
            this.labsfje.TabIndex = 81;
            this.labsfje.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(680, 480);
            this.label9.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 24);
            this.label9.TabIndex = 80;
            this.label9.Text = "实收金额:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(423, 480);
            this.label8.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 24);
            this.label8.TabIndex = 79;
            this.label8.Text = "退费金额:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(171, 480);
            this.label7.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 24);
            this.label7.TabIndex = 78;
            this.label7.Text = "收费金额:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(1150, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 40);
            this.button1.TabIndex = 88;
            this.button1.Text = "读卡查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmClinicCostManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 802);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labsfzs);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.labtfzs);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.labssje);
            this.Controls.Add(this.labtfje);
            this.Controls.Add(this.labsfje);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvCostdet);
            this.Controls.Add(this.dgvInvoice);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRePrint);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpEtime);
            this.Controls.Add(this.dtpStime);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cbxIsLocked);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbIsret);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbChargeby);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxPatientName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxmobile);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmClinicCostManage";
            this.Text = "收费管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmChargeManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxmobile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbChargeby;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxIsLocked;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpStime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.DataGridView dgvCostdet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIsret;
        private System.Windows.Forms.Button btnRePrint;
        private System.Windows.Forms.Label labsfzs;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labtfzs;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labssje;
        private System.Windows.Forms.Label labtfje;
        private System.Windows.Forms.Label labsfje;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}