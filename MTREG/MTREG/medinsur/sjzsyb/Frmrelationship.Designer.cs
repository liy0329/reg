namespace MTREG.medinsur.sjzsyb
{
    partial class Frmrelationship
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBt_FWssml = new System.Windows.Forms.RadioButton();
            this.rdBt_Zlml = new System.Windows.Forms.RadioButton();
            this.rdBt_YPml = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ybpymgl = new System.Windows.Forms.TextBox();
            this.tb_ybxmmcgl = new System.Windows.Forms.TextBox();
            this.tb_ybxmbmgl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tB_HISpymgl = new System.Windows.Forms.TextBox();
            this.cmB_HISlxgl = new System.Windows.Forms.ComboBox();
            this.bt_HISTB = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dv_dzxx = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dv_insuritem = new System.Windows.Forms.DataGridView();
            this.dV_item = new System.Windows.Forms.DataGridView();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dv_dzxx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv_insuritem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dV_item)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBt_FWssml);
            this.groupBox1.Controls.Add(this.rdBt_Zlml);
            this.groupBox1.Controls.Add(this.rdBt_YPml);
            this.groupBox1.Location = new System.Drawing.Point(19, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(341, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "收费项目类别";
            // 
            // rdBt_FWssml
            // 
            this.rdBt_FWssml.AutoSize = true;
            this.rdBt_FWssml.Location = new System.Drawing.Point(191, 19);
            this.rdBt_FWssml.Margin = new System.Windows.Forms.Padding(2);
            this.rdBt_FWssml.Name = "rdBt_FWssml";
            this.rdBt_FWssml.Size = new System.Drawing.Size(95, 16);
            this.rdBt_FWssml.TabIndex = 0;
            this.rdBt_FWssml.TabStop = true;
            this.rdBt_FWssml.Text = "服务设施目录";
            this.rdBt_FWssml.UseVisualStyleBackColor = true;
            // 
            // rdBt_Zlml
            // 
            this.rdBt_Zlml.AutoSize = true;
            this.rdBt_Zlml.Location = new System.Drawing.Point(101, 19);
            this.rdBt_Zlml.Margin = new System.Windows.Forms.Padding(2);
            this.rdBt_Zlml.Name = "rdBt_Zlml";
            this.rdBt_Zlml.Size = new System.Drawing.Size(71, 16);
            this.rdBt_Zlml.TabIndex = 0;
            this.rdBt_Zlml.TabStop = true;
            this.rdBt_Zlml.Text = "诊疗目录";
            this.rdBt_Zlml.UseVisualStyleBackColor = true;
            // 
            // rdBt_YPml
            // 
            this.rdBt_YPml.AutoSize = true;
            this.rdBt_YPml.Location = new System.Drawing.Point(15, 19);
            this.rdBt_YPml.Margin = new System.Windows.Forms.Padding(2);
            this.rdBt_YPml.Name = "rdBt_YPml";
            this.rdBt_YPml.Size = new System.Drawing.Size(71, 16);
            this.rdBt_YPml.TabIndex = 0;
            this.rdBt_YPml.TabStop = true;
            this.rdBt_YPml.Text = "药品目录";
            this.rdBt_YPml.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(377, 81);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "拼音码模糊过滤";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 19);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "三目对照申请上报";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "医保拼音码过滤";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "医保项目名称过滤";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "医保项目编码过滤";
            // 
            // tb_ybpymgl
            // 
            this.tb_ybpymgl.Location = new System.Drawing.Point(186, 55);
            this.tb_ybpymgl.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ybpymgl.Name = "tb_ybpymgl";
            this.tb_ybpymgl.Size = new System.Drawing.Size(152, 21);
            this.tb_ybpymgl.TabIndex = 4;
            this.tb_ybpymgl.TextChanged += new System.EventHandler(this.tb_ybpymgl_TextChanged);
            // 
            // tb_ybxmmcgl
            // 
            this.tb_ybxmmcgl.Location = new System.Drawing.Point(186, 77);
            this.tb_ybxmmcgl.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ybxmmcgl.Name = "tb_ybxmmcgl";
            this.tb_ybxmmcgl.Size = new System.Drawing.Size(152, 21);
            this.tb_ybxmmcgl.TabIndex = 4;
            this.tb_ybxmmcgl.TextChanged += new System.EventHandler(this.tb_ybxmmcgl_TextChanged);
            this.tb_ybxmmcgl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ybxmmcgl_KeyDown);
            // 
            // tb_ybxmbmgl
            // 
            this.tb_ybxmbmgl.Location = new System.Drawing.Point(186, 99);
            this.tb_ybxmbmgl.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ybxmbmgl.Name = "tb_ybxmbmgl";
            this.tb_ybxmbmgl.Size = new System.Drawing.Size(152, 21);
            this.tb_ybxmbmgl.TabIndex = 4;
            this.tb_ybxmbmgl.TextChanged += new System.EventHandler(this.tb_ybxmbmgl_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "HIS拼音码过滤";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(631, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "HIS类型过滤";
            // 
            // tB_HISpymgl
            // 
            this.tB_HISpymgl.Location = new System.Drawing.Point(716, 55);
            this.tB_HISpymgl.Margin = new System.Windows.Forms.Padding(2);
            this.tB_HISpymgl.Name = "tB_HISpymgl";
            this.tB_HISpymgl.Size = new System.Drawing.Size(151, 21);
            this.tB_HISpymgl.TabIndex = 4;
            this.tB_HISpymgl.TextChanged += new System.EventHandler(this.tB_HISpymgl_TextChanged);
            this.tB_HISpymgl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_HISpymgl_KeyDown);
            // 
            // cmB_HISlxgl
            // 
            this.cmB_HISlxgl.FormattingEnabled = true;
            this.cmB_HISlxgl.Location = new System.Drawing.Point(716, 79);
            this.cmB_HISlxgl.Margin = new System.Windows.Forms.Padding(2);
            this.cmB_HISlxgl.Name = "cmB_HISlxgl";
            this.cmB_HISlxgl.Size = new System.Drawing.Size(151, 20);
            this.cmB_HISlxgl.TabIndex = 6;
            this.cmB_HISlxgl.SelectedIndexChanged += new System.EventHandler(this.cmB_HISlxgl_SelectedIndexChanged);
            // 
            // bt_HISTB
            // 
            this.bt_HISTB.Location = new System.Drawing.Point(668, 100);
            this.bt_HISTB.Margin = new System.Windows.Forms.Padding(2);
            this.bt_HISTB.Name = "bt_HISTB";
            this.bt_HISTB.Size = new System.Drawing.Size(107, 23);
            this.bt_HISTB.TabIndex = 7;
            this.bt_HISTB.Text = "HIS项目表同步";
            this.bt_HISTB.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dv_dzxx);
            this.panel3.Location = new System.Drawing.Point(6, 442);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1059, 267);
            this.panel3.TabIndex = 10;
            // 
            // dv_dzxx
            // 
            this.dv_dzxx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dv_dzxx.Location = new System.Drawing.Point(2, 10);
            this.dv_dzxx.Margin = new System.Windows.Forms.Padding(2);
            this.dv_dzxx.Name = "dv_dzxx";
            this.dv_dzxx.RowHeadersVisible = false;
            this.dv_dzxx.RowTemplate.Height = 30;
            this.dv_dzxx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dv_dzxx.Size = new System.Drawing.Size(1055, 255);
            this.dv_dzxx.TabIndex = 0;
            this.dv_dzxx.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dv_dzxx_CellClick);
            this.dv_dzxx.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dv_dzxx_CellContentDoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(925, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "三目下载";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(797, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "三目对照关系下载";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dv_insuritem
            // 
            this.dv_insuritem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dv_insuritem.Location = new System.Drawing.Point(6, 125);
            this.dv_insuritem.Name = "dv_insuritem";
            this.dv_insuritem.RowTemplate.Height = 23;
            this.dv_insuritem.Size = new System.Drawing.Size(532, 287);
            this.dv_insuritem.TabIndex = 13;
            this.dv_insuritem.DataSourceChanged += new System.EventHandler(this.dv_insuritem_DataSourceChanged);
            this.dv_insuritem.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dv_insuritem_CellContentDoubleClick);
            // 
            // dV_item
            // 
            this.dV_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dV_item.Location = new System.Drawing.Point(557, 125);
            this.dV_item.Name = "dV_item";
            this.dV_item.RowTemplate.Height = 23;
            this.dV_item.Size = new System.Drawing.Size(508, 287);
            this.dV_item.TabIndex = 14;
            this.dV_item.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dV_item_CellClick);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImportExcel.Location = new System.Drawing.Point(961, 416);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(98, 26);
            this.btnImportExcel.TabIndex = 90;
            this.btnImportExcel.Text = "导出Excel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // Frmrelationship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 713);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.dV_item);
            this.Controls.Add(this.dv_insuritem);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.bt_HISTB);
            this.Controls.Add(this.cmB_HISlxgl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_ybxmbmgl);
            this.Controls.Add(this.tb_ybxmmcgl);
            this.Controls.Add(this.tB_HISpymgl);
            this.Controls.Add(this.tb_ybpymgl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frmrelationship";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "市医保三目对照关系申报";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Frmrelationship_Load);
            this.SizeChanged += new System.EventHandler(this.Frmrelationship_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dv_dzxx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv_insuritem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dV_item)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBt_FWssml;
        private System.Windows.Forms.RadioButton rdBt_Zlml;
        private System.Windows.Forms.RadioButton rdBt_YPml;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_ybpymgl;
        private System.Windows.Forms.TextBox tb_ybxmmcgl;
        private System.Windows.Forms.TextBox tb_ybxmbmgl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tB_HISpymgl;
        private System.Windows.Forms.ComboBox cmB_HISlxgl;
        private System.Windows.Forms.Button bt_HISTB;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dv_dzxx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dv_insuritem;
        private System.Windows.Forms.DataGridView dV_item;
        private System.Windows.Forms.Button btnImportExcel;
    }
}