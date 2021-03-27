namespace MTREG.medinsur.ynsyb
{
    partial class FrmItemcrossYNSYB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClear = new System.Windows.Forms.Button();
            this.tctItemType = new System.Windows.Forms.TabControl();
            this.tpgDrug = new System.Windows.Forms.TabPage();
            this.dgvDrugItem = new System.Windows.Forms.DataGridView();
            this.lblCrossId1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxForms1 = new System.Windows.Forms.TextBox();
            this.tbxUnit1 = new System.Windows.Forms.TextBox();
            this.tbxAlias1 = new System.Windows.Forms.TextBox();
            this.tbxCode1 = new System.Windows.Forms.TextBox();
            this.tbxName1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpgCost = new System.Windows.Forms.TabPage();
            this.dgvCostItem = new System.Windows.Forms.DataGridView();
            this.lblCrossId2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxUnit2 = new System.Windows.Forms.TextBox();
            this.tbxCode2 = new System.Windows.Forms.TextBox();
            this.tbxName2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tpgStuff = new System.Windows.Forms.TabPage();
            this.dgvStuffItem = new System.Windows.Forms.DataGridView();
            this.lblCrossId3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxUnit3 = new System.Windows.Forms.TextBox();
            this.tbxSpec3 = new System.Windows.Forms.TextBox();
            this.tbxCode3 = new System.Windows.Forms.TextBox();
            this.tbxName3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCancelCross = new System.Windows.Forms.Button();
            this.btnCross = new System.Windows.Forms.Button();
            this.cbxIsCross = new System.Windows.Forms.CheckBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvItemInfo = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxStuff = new System.Windows.Forms.CheckBox();
            this.cbxDiagnoseCost = new System.Windows.Forms.CheckBox();
            this.cbxDrug = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tctItemType.SuspendLayout();
            this.tpgDrug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrugItem)).BeginInit();
            this.tpgCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostItem)).BeginInit();
            this.tpgStuff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuffItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(754, 345);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 33);
            this.btnClear.TabIndex = 127;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tctItemType
            // 
            this.tctItemType.Controls.Add(this.tpgDrug);
            this.tctItemType.Controls.Add(this.tpgCost);
            this.tctItemType.Controls.Add(this.tpgStuff);
            this.tctItemType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tctItemType.Location = new System.Drawing.Point(522, 65);
            this.tctItemType.Name = "tctItemType";
            this.tctItemType.SelectedIndex = 0;
            this.tctItemType.Size = new System.Drawing.Size(319, 272);
            this.tctItemType.TabIndex = 126;
            this.tctItemType.Selected += new System.Windows.Forms.TabControlEventHandler(this.tctItemType_Selected);
            // 
            // tpgDrug
            // 
            this.tpgDrug.Controls.Add(this.dgvDrugItem);
            this.tpgDrug.Controls.Add(this.lblCrossId1);
            this.tpgDrug.Controls.Add(this.label8);
            this.tpgDrug.Controls.Add(this.label7);
            this.tpgDrug.Controls.Add(this.label6);
            this.tpgDrug.Controls.Add(this.label5);
            this.tpgDrug.Controls.Add(this.tbxForms1);
            this.tpgDrug.Controls.Add(this.tbxUnit1);
            this.tpgDrug.Controls.Add(this.tbxAlias1);
            this.tpgDrug.Controls.Add(this.tbxCode1);
            this.tpgDrug.Controls.Add(this.tbxName1);
            this.tpgDrug.Controls.Add(this.label2);
            this.tpgDrug.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpgDrug.Location = new System.Drawing.Point(4, 29);
            this.tpgDrug.Name = "tpgDrug";
            this.tpgDrug.Padding = new System.Windows.Forms.Padding(3);
            this.tpgDrug.Size = new System.Drawing.Size(311, 239);
            this.tpgDrug.TabIndex = 0;
            this.tpgDrug.Text = "药品";
            this.tpgDrug.UseVisualStyleBackColor = true;
            // 
            // dgvDrugItem
            // 
            this.dgvDrugItem.AllowUserToAddRows = false;
            this.dgvDrugItem.ColumnHeadersHeight = 30;
            this.dgvDrugItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDrugItem.Location = new System.Drawing.Point(3, 37);
            this.dgvDrugItem.Name = "dgvDrugItem";
            this.dgvDrugItem.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDrugItem.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDrugItem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDrugItem.RowTemplate.Height = 23;
            this.dgvDrugItem.Size = new System.Drawing.Size(312, 199);
            this.dgvDrugItem.TabIndex = 100;
            this.dgvDrugItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDrugItem_KeyDown);
            // 
            // lblCrossId1
            // 
            this.lblCrossId1.AutoSize = true;
            this.lblCrossId1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCrossId1.Location = new System.Drawing.Point(269, 37);
            this.lblCrossId1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCrossId1.Name = "lblCrossId1";
            this.lblCrossId1.Size = new System.Drawing.Size(31, 19);
            this.lblCrossId1.TabIndex = 126;
            this.lblCrossId1.Text = "id";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(37, 175);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 19);
            this.label8.TabIndex = 125;
            this.label8.Text = "剂型:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(37, 129);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 19);
            this.label7.TabIndex = 124;
            this.label7.Text = "单位:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(-3, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 19);
            this.label6.TabIndex = 123;
            this.label6.Text = "常用名称:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(37, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 122;
            this.label5.Text = "编码:";
            // 
            // tbxForms1
            // 
            this.tbxForms1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxForms1.Location = new System.Drawing.Point(109, 165);
            this.tbxForms1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxForms1.Name = "tbxForms1";
            this.tbxForms1.Size = new System.Drawing.Size(148, 29);
            this.tbxForms1.TabIndex = 121;
            // 
            // tbxUnit1
            // 
            this.tbxUnit1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxUnit1.Location = new System.Drawing.Point(109, 126);
            this.tbxUnit1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxUnit1.Name = "tbxUnit1";
            this.tbxUnit1.Size = new System.Drawing.Size(148, 29);
            this.tbxUnit1.TabIndex = 120;
            // 
            // tbxAlias1
            // 
            this.tbxAlias1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxAlias1.Location = new System.Drawing.Point(109, 87);
            this.tbxAlias1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxAlias1.Name = "tbxAlias1";
            this.tbxAlias1.Size = new System.Drawing.Size(148, 29);
            this.tbxAlias1.TabIndex = 119;
            // 
            // tbxCode1
            // 
            this.tbxCode1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCode1.Location = new System.Drawing.Point(109, 48);
            this.tbxCode1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxCode1.Name = "tbxCode1";
            this.tbxCode1.Size = new System.Drawing.Size(148, 29);
            this.tbxCode1.TabIndex = 118;
            // 
            // tbxName1
            // 
            this.tbxName1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxName1.Location = new System.Drawing.Point(109, 9);
            this.tbxName1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxName1.Name = "tbxName1";
            this.tbxName1.Size = new System.Drawing.Size(148, 29);
            this.tbxName1.TabIndex = 117;
            this.tbxName1.TextChanged += new System.EventHandler(this.tbxName1_TextChanged);
            this.tbxName1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(37, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 116;
            this.label2.Text = "名称:";
            // 
            // tpgCost
            // 
            this.tpgCost.Controls.Add(this.dgvCostItem);
            this.tpgCost.Controls.Add(this.lblCrossId2);
            this.tpgCost.Controls.Add(this.label10);
            this.tpgCost.Controls.Add(this.label12);
            this.tpgCost.Controls.Add(this.tbxUnit2);
            this.tpgCost.Controls.Add(this.tbxCode2);
            this.tpgCost.Controls.Add(this.tbxName2);
            this.tpgCost.Controls.Add(this.label14);
            this.tpgCost.Location = new System.Drawing.Point(4, 29);
            this.tpgCost.Name = "tpgCost";
            this.tpgCost.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCost.Size = new System.Drawing.Size(311, 239);
            this.tpgCost.TabIndex = 1;
            this.tpgCost.Text = "诊疗费用";
            this.tpgCost.UseVisualStyleBackColor = true;
            // 
            // dgvCostItem
            // 
            this.dgvCostItem.AllowUserToAddRows = false;
            this.dgvCostItem.ColumnHeadersHeight = 30;
            this.dgvCostItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCostItem.Location = new System.Drawing.Point(3, 60);
            this.dgvCostItem.Name = "dgvCostItem";
            this.dgvCostItem.RowHeadersVisible = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCostItem.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCostItem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCostItem.RowTemplate.Height = 23;
            this.dgvCostItem.Size = new System.Drawing.Size(312, 176);
            this.dgvCostItem.TabIndex = 128;
            this.dgvCostItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCostItem_KeyDown);
            // 
            // lblCrossId2
            // 
            this.lblCrossId2.AutoSize = true;
            this.lblCrossId2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCrossId2.Location = new System.Drawing.Point(159, 172);
            this.lblCrossId2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCrossId2.Name = "lblCrossId2";
            this.lblCrossId2.Size = new System.Drawing.Size(31, 19);
            this.lblCrossId2.TabIndex = 127;
            this.lblCrossId2.Text = "id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(28, 113);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 19);
            this.label10.TabIndex = 120;
            this.label10.Text = "单位:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(28, 71);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 19);
            this.label12.TabIndex = 119;
            this.label12.Text = "编码:";
            // 
            // tbxUnit2
            // 
            this.tbxUnit2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxUnit2.Location = new System.Drawing.Point(100, 110);
            this.tbxUnit2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxUnit2.Name = "tbxUnit2";
            this.tbxUnit2.Size = new System.Drawing.Size(148, 29);
            this.tbxUnit2.TabIndex = 118;
            // 
            // tbxCode2
            // 
            this.tbxCode2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCode2.Location = new System.Drawing.Point(100, 68);
            this.tbxCode2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxCode2.Name = "tbxCode2";
            this.tbxCode2.Size = new System.Drawing.Size(148, 29);
            this.tbxCode2.TabIndex = 117;
            // 
            // tbxName2
            // 
            this.tbxName2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxName2.Location = new System.Drawing.Point(100, 29);
            this.tbxName2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxName2.Name = "tbxName2";
            this.tbxName2.Size = new System.Drawing.Size(148, 29);
            this.tbxName2.TabIndex = 116;
            this.tbxName2.TextChanged += new System.EventHandler(this.tbxName2_TextChanged);
            this.tbxName2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName2_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(6, 32);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 19);
            this.label14.TabIndex = 115;
            this.label14.Text = "名  称:";
            // 
            // tpgStuff
            // 
            this.tpgStuff.Controls.Add(this.dgvStuffItem);
            this.tpgStuff.Controls.Add(this.lblCrossId3);
            this.tpgStuff.Controls.Add(this.label11);
            this.tpgStuff.Controls.Add(this.label15);
            this.tpgStuff.Controls.Add(this.label16);
            this.tpgStuff.Controls.Add(this.tbxUnit3);
            this.tpgStuff.Controls.Add(this.tbxSpec3);
            this.tpgStuff.Controls.Add(this.tbxCode3);
            this.tpgStuff.Controls.Add(this.tbxName3);
            this.tpgStuff.Controls.Add(this.label18);
            this.tpgStuff.Location = new System.Drawing.Point(4, 29);
            this.tpgStuff.Name = "tpgStuff";
            this.tpgStuff.Size = new System.Drawing.Size(311, 239);
            this.tpgStuff.TabIndex = 2;
            this.tpgStuff.Text = "材料";
            this.tpgStuff.UseVisualStyleBackColor = true;
            // 
            // dgvStuffItem
            // 
            this.dgvStuffItem.AllowUserToAddRows = false;
            this.dgvStuffItem.ColumnHeadersHeight = 30;
            this.dgvStuffItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvStuffItem.Location = new System.Drawing.Point(-1, 42);
            this.dgvStuffItem.Name = "dgvStuffItem";
            this.dgvStuffItem.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvStuffItem.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvStuffItem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvStuffItem.RowTemplate.Height = 23;
            this.dgvStuffItem.Size = new System.Drawing.Size(312, 194);
            this.dgvStuffItem.TabIndex = 128;
            this.dgvStuffItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvStuffItem_KeyDown);
            // 
            // lblCrossId3
            // 
            this.lblCrossId3.AutoSize = true;
            this.lblCrossId3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCrossId3.Location = new System.Drawing.Point(156, 180);
            this.lblCrossId3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCrossId3.Name = "lblCrossId3";
            this.lblCrossId3.Size = new System.Drawing.Size(31, 19);
            this.lblCrossId3.TabIndex = 127;
            this.lblCrossId3.Text = "id";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(29, 131);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 19);
            this.label11.TabIndex = 122;
            this.label11.Text = "单位:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(29, 92);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 19);
            this.label15.TabIndex = 121;
            this.label15.Text = "规格:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(29, 53);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 19);
            this.label16.TabIndex = 120;
            this.label16.Text = "编码:";
            // 
            // tbxUnit3
            // 
            this.tbxUnit3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxUnit3.Location = new System.Drawing.Point(100, 128);
            this.tbxUnit3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxUnit3.Name = "tbxUnit3";
            this.tbxUnit3.Size = new System.Drawing.Size(148, 29);
            this.tbxUnit3.TabIndex = 119;
            // 
            // tbxSpec3
            // 
            this.tbxSpec3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSpec3.Location = new System.Drawing.Point(100, 89);
            this.tbxSpec3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxSpec3.Name = "tbxSpec3";
            this.tbxSpec3.Size = new System.Drawing.Size(148, 29);
            this.tbxSpec3.TabIndex = 118;
            // 
            // tbxCode3
            // 
            this.tbxCode3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCode3.Location = new System.Drawing.Point(100, 50);
            this.tbxCode3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxCode3.Name = "tbxCode3";
            this.tbxCode3.Size = new System.Drawing.Size(148, 29);
            this.tbxCode3.TabIndex = 117;
            // 
            // tbxName3
            // 
            this.tbxName3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxName3.Location = new System.Drawing.Point(100, 11);
            this.tbxName3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxName3.Name = "tbxName3";
            this.tbxName3.Size = new System.Drawing.Size(148, 29);
            this.tbxName3.TabIndex = 116;
            this.tbxName3.TextChanged += new System.EventHandler(this.tbxName3_TextChanged);
            this.tbxName3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName3_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(6, 14);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 19);
            this.label18.TabIndex = 115;
            this.label18.Text = "名  称:";
            // 
            // btnCancelCross
            // 
            this.btnCancelCross.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelCross.Location = new System.Drawing.Point(639, 345);
            this.btnCancelCross.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancelCross.Name = "btnCancelCross";
            this.btnCancelCross.Size = new System.Drawing.Size(103, 33);
            this.btnCancelCross.TabIndex = 125;
            this.btnCancelCross.Text = "取消对照";
            this.btnCancelCross.UseVisualStyleBackColor = true;
            this.btnCancelCross.Click += new System.EventHandler(this.btnCancelCross_Click);
            // 
            // btnCross
            // 
            this.btnCross.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCross.Location = new System.Drawing.Point(522, 345);
            this.btnCross.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(95, 33);
            this.btnCross.TabIndex = 124;
            this.btnCross.Text = "对照";
            this.btnCross.UseVisualStyleBackColor = true;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // cbxIsCross
            // 
            this.cbxIsCross.AutoSize = true;
            this.cbxIsCross.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxIsCross.Location = new System.Drawing.Point(351, 100);
            this.cbxIsCross.Name = "cbxIsCross";
            this.cbxIsCross.Size = new System.Drawing.Size(85, 23);
            this.cbxIsCross.TabIndex = 123;
            this.cbxIsCross.Text = "已对照";
            this.cbxIsCross.UseVisualStyleBackColor = true;
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxName.Location = new System.Drawing.Point(86, 96);
            this.tbxName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(148, 29);
            this.tbxName.TabIndex = 121;
            this.tbxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 122;
            this.label3.Text = "名  称:";
            // 
            // dgvItemInfo
            // 
            this.dgvItemInfo.AllowUserToAddRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvItemInfo.ColumnHeadersHeight = 30;
            this.dgvItemInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.insurcode,
            this.name,
            this.unit,
            this.spec});
            this.dgvItemInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvItemInfo.Location = new System.Drawing.Point(11, 142);
            this.dgvItemInfo.Name = "dgvItemInfo";
            this.dgvItemInfo.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvItemInfo.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvItemInfo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvItemInfo.RowTemplate.Height = 23;
            this.dgvItemInfo.Size = new System.Drawing.Size(496, 232);
            this.dgvItemInfo.TabIndex = 120;
            this.dgvItemInfo.SelectionChanged += new System.EventHandler(this.dgvItemInfo_SelectionChanged);
            // 
            // code
            // 
            this.code.HeaderText = "编码";
            this.code.Name = "code";
            // 
            // insurcode
            // 
            this.insurcode.HeaderText = "医保内码";
            this.insurcode.Name = "insurcode";
            // 
            // name
            // 
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            // 
            // unit
            // 
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            // 
            // spec
            // 
            this.spec.HeaderText = "规格";
            this.spec.Name = "spec";
            // 
            // cbxStuff
            // 
            this.cbxStuff.AutoSize = true;
            this.cbxStuff.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxStuff.Location = new System.Drawing.Point(281, 64);
            this.cbxStuff.Name = "cbxStuff";
            this.cbxStuff.Size = new System.Drawing.Size(68, 23);
            this.cbxStuff.TabIndex = 119;
            this.cbxStuff.Text = "材料";
            this.cbxStuff.UseVisualStyleBackColor = true;
            this.cbxStuff.CheckedChanged += new System.EventHandler(this.cbxStuff_CheckedChanged);
            // 
            // cbxDiagnoseCost
            // 
            this.cbxDiagnoseCost.AutoSize = true;
            this.cbxDiagnoseCost.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxDiagnoseCost.Location = new System.Drawing.Point(126, 65);
            this.cbxDiagnoseCost.Name = "cbxDiagnoseCost";
            this.cbxDiagnoseCost.Size = new System.Drawing.Size(108, 23);
            this.cbxDiagnoseCost.TabIndex = 118;
            this.cbxDiagnoseCost.Text = "诊疗费用";
            this.cbxDiagnoseCost.UseVisualStyleBackColor = true;
            this.cbxDiagnoseCost.CheckedChanged += new System.EventHandler(this.cbxDiagnoseCost_CheckedChanged);
            // 
            // cbxDrug
            // 
            this.cbxDrug.AutoSize = true;
            this.cbxDrug.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxDrug.Location = new System.Drawing.Point(12, 64);
            this.cbxDrug.Name = "cbxDrug";
            this.cbxDrug.Size = new System.Drawing.Size(68, 23);
            this.cbxDrug.TabIndex = 117;
            this.cbxDrug.Text = "药品";
            this.cbxDrug.UseVisualStyleBackColor = true;
            this.cbxDrug.CheckedChanged += new System.EventHandler(this.cbxDrug_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(255, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 22);
            this.label1.TabIndex = 116;
            this.label1.Text = "云南省医保编码(三目录)对照";
            // 
            // FrmItemcrossYNSYB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 389);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tctItemType);
            this.Controls.Add(this.btnCancelCross);
            this.Controls.Add(this.btnCross);
            this.Controls.Add(this.cbxIsCross);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvItemInfo);
            this.Controls.Add(this.cbxStuff);
            this.Controls.Add(this.cbxDiagnoseCost);
            this.Controls.Add(this.cbxDrug);
            this.Controls.Add(this.label1);
            this.Name = "FrmItemcrossYNSYB";
            this.Text = "云南省医保编码对照";
            this.Load += new System.EventHandler(this.FrmItemcrossYNSYB_Load);
            this.tctItemType.ResumeLayout(false);
            this.tpgDrug.ResumeLayout(false);
            this.tpgDrug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrugItem)).EndInit();
            this.tpgCost.ResumeLayout(false);
            this.tpgCost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostItem)).EndInit();
            this.tpgStuff.ResumeLayout(false);
            this.tpgStuff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuffItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabControl tctItemType;
        private System.Windows.Forms.TabPage tpgDrug;
        private System.Windows.Forms.DataGridView dgvDrugItem;
        private System.Windows.Forms.Label lblCrossId1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxForms1;
        private System.Windows.Forms.TextBox tbxUnit1;
        private System.Windows.Forms.TextBox tbxAlias1;
        private System.Windows.Forms.TextBox tbxCode1;
        private System.Windows.Forms.TextBox tbxName1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tpgCost;
        private System.Windows.Forms.DataGridView dgvCostItem;
        private System.Windows.Forms.Label lblCrossId2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxUnit2;
        private System.Windows.Forms.TextBox tbxCode2;
        private System.Windows.Forms.TextBox tbxName2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tpgStuff;
        private System.Windows.Forms.DataGridView dgvStuffItem;
        private System.Windows.Forms.Label lblCrossId3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxUnit3;
        private System.Windows.Forms.TextBox tbxSpec3;
        private System.Windows.Forms.TextBox tbxCode3;
        private System.Windows.Forms.TextBox tbxName3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCancelCross;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.CheckBox cbxIsCross;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvItemInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn spec;
        private System.Windows.Forms.CheckBox cbxStuff;
        private System.Windows.Forms.CheckBox cbxDiagnoseCost;
        private System.Windows.Forms.CheckBox cbxDrug;
        private System.Windows.Forms.Label label1;
    }
}