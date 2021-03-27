namespace MTREG.netpay
{
    partial class FrmNetPayManage
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
            this.btnNetPayCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpEtime = new System.Windows.Forms.DateTimePicker();
            this.dtpStime = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbChargeby = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_NetPay = new System.Windows.Forms.DataGridView();
            this.outerOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.innerOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceOuterOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hzxm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ksmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zfzt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCancel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jyrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hisstat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jylx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbJylx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefundQuery = new System.Windows.Forms.Button();
            this.btnNetPayTradeRefund = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NetPay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNetPayCancel
            // 
            this.btnNetPayCancel.Font = new System.Drawing.Font("宋体", 11F);
            this.btnNetPayCancel.Location = new System.Drawing.Point(748, 49);
            this.btnNetPayCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnNetPayCancel.Name = "btnNetPayCancel";
            this.btnNetPayCancel.Size = new System.Drawing.Size(80, 27);
            this.btnNetPayCancel.TabIndex = 75;
            this.btnNetPayCancel.Text = "撤销支付";
            this.btnNetPayCancel.UseVisualStyleBackColor = true;
            this.btnNetPayCancel.Click += new System.EventHandler(this.btnNetPayCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(748, 18);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 27);
            this.btnSearch.TabIndex = 74;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(32, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 16);
            this.label15.TabIndex = 73;
            this.label15.Text = "终止时间:";
            // 
            // dtpEtime
            // 
            this.dtpEtime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEtime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEtime.Location = new System.Drawing.Point(114, 44);
            this.dtpEtime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.Size = new System.Drawing.Size(194, 26);
            this.dtpEtime.TabIndex = 69;
            // 
            // dtpStime
            // 
            this.dtpStime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStime.Location = new System.Drawing.Point(114, 13);
            this.dtpStime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpStime.Name = "dtpStime";
            this.dtpStime.Size = new System.Drawing.Size(194, 26);
            this.dtpStime.TabIndex = 68;
            this.dtpStime.Value = new System.DateTime(2017, 6, 23, 0, 0, 0, 0);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(32, 18);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 72;
            this.label18.Text = "开始时间:";
            // 
            // cmbChargeby
            // 
            this.cmbChargeby.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbChargeby.FormattingEnabled = true;
            this.cmbChargeby.ItemHeight = 16;
            this.cmbChargeby.Location = new System.Drawing.Point(382, 45);
            this.cmbChargeby.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbChargeby.Name = "cmbChargeby";
            this.cmbChargeby.Size = new System.Drawing.Size(128, 24);
            this.cmbChargeby.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(317, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 71;
            this.label4.Text = "收费员:";
            // 
            // tbxPatientName
            // 
            this.tbxPatientName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPatientName.Location = new System.Drawing.Point(369, 16);
            this.tbxPatientName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxPatientName.Name = "tbxPatientName";
            this.tbxPatientName.Size = new System.Drawing.Size(141, 26);
            this.tbxPatientName.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(320, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 70;
            this.label1.Text = "姓名:";
            // 
            // dgv_NetPay
            // 
            this.dgv_NetPay.AllowUserToAddRows = false;
            this.dgv_NetPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NetPay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.outerOrderNo,
            this.innerOrderNo,
            this.ddlx,
            this.ddly,
            this.sourceOuterOrderNo,
            this.hzxm,
            this.ksmc,
            this.zfzt,
            this.isCancel,
            this.jyrq,
            this.hisstat,
            this.jylx});
            this.dgv_NetPay.Location = new System.Drawing.Point(12, 84);
            this.dgv_NetPay.Name = "dgv_NetPay";
            this.dgv_NetPay.ReadOnly = true;
            this.dgv_NetPay.RowTemplate.Height = 23;
            this.dgv_NetPay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_NetPay.Size = new System.Drawing.Size(990, 425);
            this.dgv_NetPay.TabIndex = 76;
            this.dgv_NetPay.SelectionChanged += new System.EventHandler(this.dgv_NetPay_SelectionChanged);
            // 
            // outerOrderNo
            // 
            this.outerOrderNo.DataPropertyName = "outerOrderNo";
            this.outerOrderNo.FillWeight = 120F;
            this.outerOrderNo.HeaderText = "订单号";
            this.outerOrderNo.Name = "outerOrderNo";
            this.outerOrderNo.ReadOnly = true;
            // 
            // innerOrderNo
            // 
            this.innerOrderNo.DataPropertyName = "innerOrderNo";
            this.innerOrderNo.HeaderText = "系统标识";
            this.innerOrderNo.Name = "innerOrderNo";
            this.innerOrderNo.Width = 150;
            // 
            // ddlx
            // 
            this.ddlx.DataPropertyName = "ddlx";
            this.ddlx.HeaderText = "订单类型";
            this.ddlx.Name = "ddlx";
            this.ddlx.ReadOnly = true;
            this.ddlx.Width = 55;
            // 
            // ddly
            // 
            this.ddly.DataPropertyName = "ddly";
            this.ddly.HeaderText = "订单来源";
            this.ddly.Name = "ddly";
            this.ddly.ReadOnly = true;
            this.ddly.Width = 55;
            // 
            // sourceOuterOrderNo
            // 
            this.sourceOuterOrderNo.DataPropertyName = "sourceOuterOrderNo";
            this.sourceOuterOrderNo.HeaderText = "原订单号";
            this.sourceOuterOrderNo.Name = "sourceOuterOrderNo";
            // 
            // hzxm
            // 
            this.hzxm.DataPropertyName = "hzxm";
            this.hzxm.HeaderText = "患者姓名";
            this.hzxm.Name = "hzxm";
            this.hzxm.ReadOnly = true;
            this.hzxm.Width = 60;
            // 
            // ksmc
            // 
            this.ksmc.DataPropertyName = "ksmc";
            this.ksmc.HeaderText = "科室";
            this.ksmc.Name = "ksmc";
            this.ksmc.ReadOnly = true;
            // 
            // zfzt
            // 
            this.zfzt.DataPropertyName = "zfzt";
            this.zfzt.FillWeight = 60F;
            this.zfzt.HeaderText = "支付状态";
            this.zfzt.Name = "zfzt";
            this.zfzt.ReadOnly = true;
            this.zfzt.Width = 40;
            // 
            // isCancel
            // 
            this.isCancel.DataPropertyName = "isCancel";
            this.isCancel.HeaderText = "撤销状态";
            this.isCancel.Name = "isCancel";
            this.isCancel.Width = 50;
            // 
            // jyrq
            // 
            this.jyrq.DataPropertyName = "jyrq";
            this.jyrq.HeaderText = "交易时间";
            this.jyrq.Name = "jyrq";
            this.jyrq.ReadOnly = true;
            // 
            // hisstat
            // 
            this.hisstat.DataPropertyName = "hisstat";
            this.hisstat.HeaderText = "HIS状态";
            this.hisstat.Name = "hisstat";
            this.hisstat.ReadOnly = true;
            this.hisstat.Width = 60;
            // 
            // jylx
            // 
            this.jylx.DataPropertyName = "jylx";
            this.jylx.HeaderText = "交易类型";
            this.jylx.Name = "jylx";
            this.jylx.Width = 60;
            // 
            // cmbJylx
            // 
            this.cmbJylx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbJylx.FormattingEnabled = true;
            this.cmbJylx.ItemHeight = 16;
            this.cmbJylx.Location = new System.Drawing.Point(592, 15);
            this.cmbJylx.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbJylx.Name = "cmbJylx";
            this.cmbJylx.Size = new System.Drawing.Size(128, 24);
            this.cmbJylx.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(513, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 78;
            this.label2.Text = "交易类型:";
            // 
            // btnRefundQuery
            // 
            this.btnRefundQuery.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRefundQuery.Location = new System.Drawing.Point(618, 49);
            this.btnRefundQuery.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRefundQuery.Name = "btnRefundQuery";
            this.btnRefundQuery.Size = new System.Drawing.Size(118, 27);
            this.btnRefundQuery.TabIndex = 79;
            this.btnRefundQuery.Text = "退单状态查询";
            this.btnRefundQuery.UseVisualStyleBackColor = true;
            this.btnRefundQuery.Click += new System.EventHandler(this.btnRefundQuery_Click);
            // 
            // btnNetPayTradeRefund
            // 
            this.btnNetPayTradeRefund.Enabled = false;
            this.btnNetPayTradeRefund.Font = new System.Drawing.Font("宋体", 11F);
            this.btnNetPayTradeRefund.Location = new System.Drawing.Point(849, 49);
            this.btnNetPayTradeRefund.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnNetPayTradeRefund.Name = "btnNetPayTradeRefund";
            this.btnNetPayTradeRefund.Size = new System.Drawing.Size(80, 27);
            this.btnNetPayTradeRefund.TabIndex = 80;
            this.btnNetPayTradeRefund.Text = "退款";
            this.btnNetPayTradeRefund.UseVisualStyleBackColor = true;
            // 
            // FrmNetPayManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 521);
            this.Controls.Add(this.btnNetPayTradeRefund);
            this.Controls.Add(this.btnRefundQuery);
            this.Controls.Add(this.cmbJylx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_NetPay);
            this.Controls.Add(this.btnNetPayCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpEtime);
            this.Controls.Add(this.dtpStime);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbChargeby);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxPatientName);
            this.Controls.Add(this.label1);
            this.Name = "FrmNetPayManage";
            this.Text = "支付管理";
            this.Load += new System.EventHandler(this.FrmNetPayManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NetPay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNetPayCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpStime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbChargeby;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_NetPay;
        private System.Windows.Forms.ComboBox cmbJylx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefundQuery;
        private System.Windows.Forms.Button btnNetPayTradeRefund;
        private System.Windows.Forms.DataGridViewTextBoxColumn outerOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn innerOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddly;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceOuterOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn hzxm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ksmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn zfzt;
        private System.Windows.Forms.DataGridViewTextBoxColumn isCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn jyrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn hisstat;
        private System.Windows.Forms.DataGridViewTextBoxColumn jylx;
    }
}