namespace MTHIS.db
{
    partial class FrmDBConnectionConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDBConnectionConfiguration));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tbxChkDbType = new System.Windows.Forms.TextBox();
            this.tbxChkDbDriver = new System.Windows.Forms.TextBox();
            this.tbxChkDbIp = new System.Windows.Forms.TextBox();
            this.tbxChkDbPort = new System.Windows.Forms.TextBox();
            this.tbxChkDbName = new System.Windows.Forms.TextBox();
            this.tbxChkDbUser = new System.Windows.Forms.TextBox();
            this.tbxChkDbPass = new System.Windows.Forms.TextBox();
            this.btnChkDbInit = new System.Windows.Forms.Button();
            this.lblChkMsg = new System.Windows.Forms.Label();
            this.btnChkPing = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxLisDbType = new System.Windows.Forms.TextBox();
            this.tbxLisDbDriver = new System.Windows.Forms.TextBox();
            this.tbxLisDbIp = new System.Windows.Forms.TextBox();
            this.tbxLisDbPort = new System.Windows.Forms.TextBox();
            this.tbxLisDbName = new System.Windows.Forms.TextBox();
            this.tbxLisDbUser = new System.Windows.Forms.TextBox();
            this.tbxLisDbPass = new System.Windows.Forms.TextBox();
            this.btnHisDbInit = new System.Windows.Forms.Button();
            this.btnInstanllODBC = new System.Windows.Forms.Button();
            this.lblLisMsg = new System.Windows.Forms.Label();
            this.btnLisPing = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 32);
            this.button1.TabIndex = 38;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(29, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 32);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(329, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 45;
            this.button2.Text = "测试连接";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(26, 301);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 47);
            this.label13.TabIndex = 49;
            this.label13.Text = "初始化完成";
            this.label13.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(205, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 47;
            this.button3.Text = "初始化";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox10.Location = new System.Drawing.Point(106, 245);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(292, 26);
            this.textBox10.TabIndex = 43;
            // 
            // textBox19
            // 
            this.textBox19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox19.Location = new System.Drawing.Point(106, 200);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(292, 26);
            this.textBox19.TabIndex = 41;
            // 
            // textBox20
            // 
            this.textBox20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox20.Location = new System.Drawing.Point(106, 152);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(292, 26);
            this.textBox20.TabIndex = 40;
            // 
            // textBox21
            // 
            this.textBox21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox21.Location = new System.Drawing.Point(106, 103);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(217, 26);
            this.textBox21.TabIndex = 36;
            // 
            // textBox22
            // 
            this.textBox22.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox22.Location = new System.Drawing.Point(106, 56);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(292, 26);
            this.textBox22.TabIndex = 34;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(43, 246);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 19);
            this.label22.TabIndex = 46;
            this.label22.Text = "密码:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(24, 201);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(76, 19);
            this.label23.TabIndex = 44;
            this.label23.Text = "用户名:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(24, 153);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(76, 19);
            this.label24.TabIndex = 42;
            this.label24.Text = "数据库:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(43, 105);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 19);
            this.label25.TabIndex = 39;
            this.label25.Text = "地址：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(43, 57);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 19);
            this.label26.TabIndex = 35;
            this.label26.Text = "类型：";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(431, 447);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "CHK数据库连接";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnChkPing);
            this.groupBox4.Controls.Add(this.lblChkMsg);
            this.groupBox4.Controls.Add(this.btnChkDbInit);
            this.groupBox4.Controls.Add(this.tbxChkDbPass);
            this.groupBox4.Controls.Add(this.tbxChkDbUser);
            this.groupBox4.Controls.Add(this.tbxChkDbName);
            this.groupBox4.Controls.Add(this.tbxChkDbPort);
            this.groupBox4.Controls.Add(this.tbxChkDbIp);
            this.groupBox4.Controls.Add(this.tbxChkDbDriver);
            this.groupBox4.Controls.Add(this.tbxChkDbType);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Location = new System.Drawing.Point(3, 43);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(425, 398);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CHK数据库连接";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(43, 21);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(66, 19);
            this.label32.TabIndex = 35;
            this.label32.Text = "类型：";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(43, 111);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(66, 19);
            this.label31.TabIndex = 39;
            this.label31.Text = "地址：";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(43, 64);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 19);
            this.label27.TabIndex = 35;
            this.label27.Text = "驱动：";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(43, 156);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(66, 19);
            this.label33.TabIndex = 39;
            this.label33.Text = "端口：";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(24, 198);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(76, 19);
            this.label30.TabIndex = 42;
            this.label30.Text = "数据库:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(24, 246);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(76, 19);
            this.label29.TabIndex = 44;
            this.label29.Text = "用户名:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(43, 291);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(57, 19);
            this.label28.TabIndex = 46;
            this.label28.Text = "密码:";
            // 
            // tbxChkDbType
            // 
            this.tbxChkDbType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxChkDbType.Location = new System.Drawing.Point(106, 20);
            this.tbxChkDbType.Name = "tbxChkDbType";
            this.tbxChkDbType.Size = new System.Drawing.Size(292, 26);
            this.tbxChkDbType.TabIndex = 34;
            // 
            // tbxChkDbDriver
            // 
            this.tbxChkDbDriver.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxChkDbDriver.Location = new System.Drawing.Point(106, 63);
            this.tbxChkDbDriver.Name = "tbxChkDbDriver";
            this.tbxChkDbDriver.Size = new System.Drawing.Size(292, 26);
            this.tbxChkDbDriver.TabIndex = 34;
            // 
            // tbxChkDbIp
            // 
            this.tbxChkDbIp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxChkDbIp.Location = new System.Drawing.Point(106, 109);
            this.tbxChkDbIp.Name = "tbxChkDbIp";
            this.tbxChkDbIp.Size = new System.Drawing.Size(217, 26);
            this.tbxChkDbIp.TabIndex = 36;
            // 
            // tbxChkDbPort
            // 
            this.tbxChkDbPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxChkDbPort.Location = new System.Drawing.Point(106, 154);
            this.tbxChkDbPort.Name = "tbxChkDbPort";
            this.tbxChkDbPort.Size = new System.Drawing.Size(217, 26);
            this.tbxChkDbPort.TabIndex = 36;
            // 
            // tbxChkDbName
            // 
            this.tbxChkDbName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxChkDbName.Location = new System.Drawing.Point(106, 197);
            this.tbxChkDbName.Name = "tbxChkDbName";
            this.tbxChkDbName.Size = new System.Drawing.Size(292, 26);
            this.tbxChkDbName.TabIndex = 40;
            // 
            // tbxChkDbUser
            // 
            this.tbxChkDbUser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxChkDbUser.Location = new System.Drawing.Point(106, 245);
            this.tbxChkDbUser.Name = "tbxChkDbUser";
            this.tbxChkDbUser.Size = new System.Drawing.Size(292, 26);
            this.tbxChkDbUser.TabIndex = 41;
            // 
            // tbxChkDbPass
            // 
            this.tbxChkDbPass.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxChkDbPass.Location = new System.Drawing.Point(106, 290);
            this.tbxChkDbPass.Name = "tbxChkDbPass";
            this.tbxChkDbPass.Size = new System.Drawing.Size(292, 26);
            this.tbxChkDbPass.TabIndex = 43;
            // 
            // btnChkDbInit
            // 
            this.btnChkDbInit.Location = new System.Drawing.Point(205, 340);
            this.btnChkDbInit.Name = "btnChkDbInit";
            this.btnChkDbInit.Size = new System.Drawing.Size(75, 23);
            this.btnChkDbInit.TabIndex = 47;
            this.btnChkDbInit.Text = "初始化";
            this.btnChkDbInit.UseVisualStyleBackColor = true;
            this.btnChkDbInit.Click += new System.EventHandler(this.btnChkDbInit_Click);
            // 
            // lblChkMsg
            // 
            this.lblChkMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChkMsg.Location = new System.Drawing.Point(26, 331);
            this.lblChkMsg.Name = "lblChkMsg";
            this.lblChkMsg.Size = new System.Drawing.Size(115, 47);
            this.lblChkMsg.TabIndex = 49;
            this.lblChkMsg.Text = "初始化完成";
            this.lblChkMsg.Visible = false;
            // 
            // btnChkPing
            // 
            this.btnChkPing.Location = new System.Drawing.Point(329, 112);
            this.btnChkPing.Name = "btnChkPing";
            this.btnChkPing.Size = new System.Drawing.Size(75, 23);
            this.btnChkPing.TabIndex = 45;
            this.btnChkPing.Text = "测试连接";
            this.btnChkPing.UseVisualStyleBackColor = true;
            this.btnChkPing.Click += new System.EventHandler(this.btnChkPing_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(431, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HIS数据库连接";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLisPing);
            this.groupBox2.Controls.Add(this.lblLisMsg);
            this.groupBox2.Controls.Add(this.btnInstanllODBC);
            this.groupBox2.Controls.Add(this.btnHisDbInit);
            this.groupBox2.Controls.Add(this.tbxLisDbPass);
            this.groupBox2.Controls.Add(this.tbxLisDbUser);
            this.groupBox2.Controls.Add(this.tbxLisDbName);
            this.groupBox2.Controls.Add(this.tbxLisDbPort);
            this.groupBox2.Controls.Add(this.tbxLisDbIp);
            this.groupBox2.Controls.Add(this.tbxLisDbDriver);
            this.groupBox2.Controls.Add(this.tbxLisDbType);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Location = new System.Drawing.Point(6, 43);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(419, 365);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "体检数据库连接";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(24, 26);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(37, 20);
            this.label35.TabIndex = 35;
            this.label35.Text = "类型";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(24, 106);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(37, 20);
            this.label34.TabIndex = 39;
            this.label34.Text = "地址";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(24, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 20);
            this.label14.TabIndex = 35;
            this.label14.Text = "驱动";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(24, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 20);
            this.label12.TabIndex = 39;
            this.label12.Text = "端口";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(8, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "数据库";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(8, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "用户名";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(24, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "密码";
            // 
            // tbxLisDbType
            // 
            this.tbxLisDbType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxLisDbType.Location = new System.Drawing.Point(81, 24);
            this.tbxLisDbType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxLisDbType.Name = "tbxLisDbType";
            this.tbxLisDbType.Size = new System.Drawing.Size(321, 29);
            this.tbxLisDbType.TabIndex = 34;
            // 
            // tbxLisDbDriver
            // 
            this.tbxLisDbDriver.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxLisDbDriver.Location = new System.Drawing.Point(81, 65);
            this.tbxLisDbDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxLisDbDriver.Name = "tbxLisDbDriver";
            this.tbxLisDbDriver.Size = new System.Drawing.Size(321, 29);
            this.tbxLisDbDriver.TabIndex = 34;
            // 
            // tbxLisDbIp
            // 
            this.tbxLisDbIp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxLisDbIp.Location = new System.Drawing.Point(81, 105);
            this.tbxLisDbIp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxLisDbIp.Name = "tbxLisDbIp";
            this.tbxLisDbIp.Size = new System.Drawing.Size(222, 29);
            this.tbxLisDbIp.TabIndex = 36;
            // 
            // tbxLisDbPort
            // 
            this.tbxLisDbPort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxLisDbPort.Location = new System.Drawing.Point(81, 145);
            this.tbxLisDbPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxLisDbPort.Name = "tbxLisDbPort";
            this.tbxLisDbPort.Size = new System.Drawing.Size(321, 29);
            this.tbxLisDbPort.TabIndex = 36;
            // 
            // tbxLisDbName
            // 
            this.tbxLisDbName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxLisDbName.Location = new System.Drawing.Point(81, 185);
            this.tbxLisDbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxLisDbName.Name = "tbxLisDbName";
            this.tbxLisDbName.Size = new System.Drawing.Size(321, 29);
            this.tbxLisDbName.TabIndex = 40;
            // 
            // tbxLisDbUser
            // 
            this.tbxLisDbUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxLisDbUser.Location = new System.Drawing.Point(81, 225);
            this.tbxLisDbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxLisDbUser.Name = "tbxLisDbUser";
            this.tbxLisDbUser.Size = new System.Drawing.Size(321, 29);
            this.tbxLisDbUser.TabIndex = 41;
            // 
            // tbxLisDbPass
            // 
            this.tbxLisDbPass.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxLisDbPass.Location = new System.Drawing.Point(81, 265);
            this.tbxLisDbPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxLisDbPass.Name = "tbxLisDbPass";
            this.tbxLisDbPass.PasswordChar = '*';
            this.tbxLisDbPass.Size = new System.Drawing.Size(321, 29);
            this.tbxLisDbPass.TabIndex = 43;
            // 
            // btnHisDbInit
            // 
            this.btnHisDbInit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHisDbInit.Location = new System.Drawing.Point(317, 309);
            this.btnHisDbInit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHisDbInit.Name = "btnHisDbInit";
            this.btnHisDbInit.Size = new System.Drawing.Size(85, 28);
            this.btnHisDbInit.TabIndex = 47;
            this.btnHisDbInit.Text = "初始化";
            this.btnHisDbInit.UseVisualStyleBackColor = true;
            this.btnHisDbInit.Click += new System.EventHandler(this.btnLisDbInit_Click);
            // 
            // btnInstanllODBC
            // 
            this.btnInstanllODBC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInstanllODBC.Location = new System.Drawing.Point(213, 307);
            this.btnInstanllODBC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInstanllODBC.Name = "btnInstanllODBC";
            this.btnInstanllODBC.Size = new System.Drawing.Size(90, 32);
            this.btnInstanllODBC.TabIndex = 47;
            this.btnInstanllODBC.Text = "安装mysql-odbc";
            this.btnInstanllODBC.UseVisualStyleBackColor = true;
            this.btnInstanllODBC.Visible = false;
            this.btnInstanllODBC.Click += new System.EventHandler(this.btnInstanllODBC_Click);
            // 
            // lblLisMsg
            // 
            this.lblLisMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLisMsg.Location = new System.Drawing.Point(25, 314);
            this.lblLisMsg.Name = "lblLisMsg";
            this.lblLisMsg.Size = new System.Drawing.Size(159, 45);
            this.lblLisMsg.TabIndex = 49;
            this.lblLisMsg.Text = "初始化完成";
            this.lblLisMsg.Visible = false;
            // 
            // btnLisPing
            // 
            this.btnLisPing.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLisPing.Location = new System.Drawing.Point(317, 105);
            this.btnLisPing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLisPing.Name = "btnLisPing";
            this.btnLisPing.Size = new System.Drawing.Size(85, 28);
            this.btnLisPing.TabIndex = 45;
            this.btnLisPing.Text = "测试连接";
            this.btnLisPing.UseVisualStyleBackColor = true;
            this.btnLisPing.Click += new System.EventHandler(this.btnlistest_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(28, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 473);
            this.tabControl1.TabIndex = 2;
            // 
            // FrmDBConnectionConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(507, 544);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDBConnectionConfiguration";
            this.ShowIcon = false;
            this.Text = "数据库连接配置";
            this.Load += new System.EventHandler(this.FrmDBConnectionConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnChkPing;
        private System.Windows.Forms.Label lblChkMsg;
        private System.Windows.Forms.Button btnChkDbInit;
        private System.Windows.Forms.TextBox tbxChkDbPass;
        private System.Windows.Forms.TextBox tbxChkDbUser;
        private System.Windows.Forms.TextBox tbxChkDbName;
        private System.Windows.Forms.TextBox tbxChkDbPort;
        private System.Windows.Forms.TextBox tbxChkDbIp;
        private System.Windows.Forms.TextBox tbxChkDbDriver;
        private System.Windows.Forms.TextBox tbxChkDbType;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLisPing;
        private System.Windows.Forms.Label lblLisMsg;
        private System.Windows.Forms.Button btnInstanllODBC;
        private System.Windows.Forms.Button btnHisDbInit;
        private System.Windows.Forms.TextBox tbxLisDbPass;
        private System.Windows.Forms.TextBox tbxLisDbUser;
        private System.Windows.Forms.TextBox tbxLisDbName;
        private System.Windows.Forms.TextBox tbxLisDbPort;
        private System.Windows.Forms.TextBox tbxLisDbIp;
        private System.Windows.Forms.TextBox tbxLisDbDriver;
        private System.Windows.Forms.TextBox tbxLisDbType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TabControl tabControl1;
    }
}