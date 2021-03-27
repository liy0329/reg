namespace MTREG.medinsur.sjzsyb
{
    partial class FrmItemcrossSJZ
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_Jm = new System.Windows.Forms.TextBox();
            this.lbl_Jm = new System.Windows.Forms.Label();
            this.checkBox_sfdy = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_yp = new System.Windows.Forms.RadioButton();
            this.radioButton_fw = new System.Windows.Forms.RadioButton();
            this.radioButton_zl = new System.Windows.Forms.RadioButton();
            this.tabControl_Yymxb = new System.Windows.Forms.TabControl();
            this.tabPage_Yymx = new System.Windows.Forms.TabPage();
            this.dgvItemInfo = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl_Yymxb.SuspendLayout();
            this.tabPage_Yymx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TextBox_Jm);
            this.panel1.Controls.Add(this.lbl_Jm);
            this.panel1.Controls.Add(this.checkBox_sfdy);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 152);
            this.panel1.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "可根据简码、编码、汉字搜索";
            // 
            // TextBox_Jm
            // 
            this.TextBox_Jm.Location = new System.Drawing.Point(95, 82);
            this.TextBox_Jm.Name = "TextBox_Jm";
            this.TextBox_Jm.Size = new System.Drawing.Size(100, 21);
            this.TextBox_Jm.TabIndex = 0;
            this.TextBox_Jm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_Jm_KeyUp);
            // 
            // lbl_Jm
            // 
            this.lbl_Jm.AutoSize = true;
            this.lbl_Jm.Location = new System.Drawing.Point(39, 85);
            this.lbl_Jm.Name = "lbl_Jm";
            this.lbl_Jm.Size = new System.Drawing.Size(41, 12);
            this.lbl_Jm.TabIndex = 31;
            this.lbl_Jm.Text = "检索码";
            // 
            // checkBox_sfdy
            // 
            this.checkBox_sfdy.AutoSize = true;
            this.checkBox_sfdy.Checked = true;
            this.checkBox_sfdy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_sfdy.Location = new System.Drawing.Point(324, 25);
            this.checkBox_sfdy.Name = "checkBox_sfdy";
            this.checkBox_sfdy.Size = new System.Drawing.Size(60, 16);
            this.checkBox_sfdy.TabIndex = 7;
            this.checkBox_sfdy.Text = "未对应";
            this.checkBox_sfdy.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_yp);
            this.groupBox1.Controls.Add(this.radioButton_fw);
            this.groupBox1.Controls.Add(this.radioButton_zl);
            this.groupBox1.Location = new System.Drawing.Point(17, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 55);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_yp
            // 
            this.radioButton_yp.AutoSize = true;
            this.radioButton_yp.Checked = true;
            this.radioButton_yp.Location = new System.Drawing.Point(19, 21);
            this.radioButton_yp.Name = "radioButton_yp";
            this.radioButton_yp.Size = new System.Drawing.Size(47, 16);
            this.radioButton_yp.TabIndex = 3;
            this.radioButton_yp.TabStop = true;
            this.radioButton_yp.Text = "药品";
            this.radioButton_yp.UseVisualStyleBackColor = true;
            // 
            // radioButton_fw
            // 
            this.radioButton_fw.AutoSize = true;
            this.radioButton_fw.Location = new System.Drawing.Point(186, 21);
            this.radioButton_fw.Name = "radioButton_fw";
            this.radioButton_fw.Size = new System.Drawing.Size(71, 16);
            this.radioButton_fw.TabIndex = 5;
            this.radioButton_fw.Text = "服务设施";
            this.radioButton_fw.UseVisualStyleBackColor = true;
            // 
            // radioButton_zl
            // 
            this.radioButton_zl.AutoSize = true;
            this.radioButton_zl.Location = new System.Drawing.Point(102, 21);
            this.radioButton_zl.Name = "radioButton_zl";
            this.radioButton_zl.Size = new System.Drawing.Size(47, 16);
            this.radioButton_zl.TabIndex = 4;
            this.radioButton_zl.Text = "诊疗";
            this.radioButton_zl.UseVisualStyleBackColor = true;
            //this.radioButton_zl.CheckedChanged += new System.EventHandler(this.radioButton_zl_CheckedChanged);
            // 
            // tabControl_Yymxb
            // 
            this.tabControl_Yymxb.Controls.Add(this.tabPage_Yymx);
            this.tabControl_Yymxb.Location = new System.Drawing.Point(1, 154);
            this.tabControl_Yymxb.Name = "tabControl_Yymxb";
            this.tabControl_Yymxb.SelectedIndex = 0;
            this.tabControl_Yymxb.Size = new System.Drawing.Size(821, 446);
            this.tabControl_Yymxb.TabIndex = 40;
            // 
            // tabPage_Yymx
            // 
            this.tabPage_Yymx.Controls.Add(this.dgvItemInfo);
            this.tabPage_Yymx.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Yymx.Name = "tabPage_Yymx";
            this.tabPage_Yymx.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Yymx.Size = new System.Drawing.Size(813, 420);
            this.tabPage_Yymx.TabIndex = 0;
            this.tabPage_Yymx.Text = "对照信息";
            this.tabPage_Yymx.UseVisualStyleBackColor = true;
            // 
            // dgvItemInfo
            // 
            this.dgvItemInfo.AllowUserToAddRows = false;
            this.dgvItemInfo.AllowUserToDeleteRows = false;
            this.dgvItemInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemInfo.Location = new System.Drawing.Point(-4, 0);
            this.dgvItemInfo.Name = "dgvItemInfo";
            this.dgvItemInfo.ReadOnly = true;
            this.dgvItemInfo.RowHeadersVisible = false;
            this.dgvItemInfo.RowTemplate.Height = 23;
            this.dgvItemInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemInfo.Size = new System.Drawing.Size(817, 414);
            this.dgvItemInfo.TabIndex = 0;
            this.dgvItemInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemInfo_CellClick);
            this.dgvItemInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemInfo_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 33);
            this.button1.TabIndex = 41;
            this.button1.Text = "上传对照信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(631, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 33);
            this.button2.TabIndex = 42;
            this.button2.Text = "取消对应关系";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmItemcrossSJZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 602);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl_Yymxb);
            this.Controls.Add(this.panel1);
            this.Name = "FrmItemcrossSJZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "石家庄编码对照(橙色对照未通过，黄色未对照，白色对照通过)";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl_Yymxb.ResumeLayout(false);
            this.tabPage_Yymx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_Jm;
        private System.Windows.Forms.Label lbl_Jm;
        private System.Windows.Forms.CheckBox checkBox_sfdy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_yp;
        private System.Windows.Forms.RadioButton radioButton_fw;
        private System.Windows.Forms.RadioButton radioButton_zl;
        private System.Windows.Forms.TabControl tabControl_Yymxb;
        private System.Windows.Forms.TabPage tabPage_Yymx;
        private System.Windows.Forms.DataGridView dgvItemInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}