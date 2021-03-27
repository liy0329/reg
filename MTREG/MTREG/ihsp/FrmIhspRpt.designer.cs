namespace MTREG.ihsp
{
    partial class FrmIhspRpt
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
            this.tbxBillcode = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.rbtnBillcode = new System.Windows.Forms.RadioButton();
            this.rbtnOldBill = new System.Windows.Forms.RadioButton();
            this.rbtnNewBill = new System.Windows.Forms.RadioButton();
            this.lblCheque = new System.Windows.Forms.Label();
            this.lblBas_paytype = new System.Windows.Forms.Label();
            this.lblPrepamt = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblNewBill = new System.Windows.Forms.Label();
            this.lblOldBill = new System.Windows.Forms.Label();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblIhspcode = new System.Windows.Forms.Label();
            this.lblHspcard = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblInsurefee = new System.Windows.Forms.Label();
            this.lblSelffee = new System.Windows.Forms.Label();
            this.lblPatienttype = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblFeeamt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxBillcode
            // 
            this.tbxBillcode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxBillcode.Location = new System.Drawing.Point(368, 209);
            this.tbxBillcode.Multiline = true;
            this.tbxBillcode.Name = "tbxBillcode";
            this.tbxBillcode.Size = new System.Drawing.Size(100, 24);
            this.tbxBillcode.TabIndex = 108;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnPrint.Location = new System.Drawing.Point(597, 206);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(77, 27);
            this.btnPrint.TabIndex = 107;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rbtnBillcode
            // 
            this.rbtnBillcode.AutoSize = true;
            this.rbtnBillcode.Font = new System.Drawing.Font("宋体", 11F);
            this.rbtnBillcode.Location = new System.Drawing.Point(276, 214);
            this.rbtnBillcode.Name = "rbtnBillcode";
            this.rbtnBillcode.Size = new System.Drawing.Size(93, 19);
            this.rbtnBillcode.TabIndex = 104;
            this.rbtnBillcode.TabStop = true;
            this.rbtnBillcode.Text = "指发票号:";
            this.rbtnBillcode.UseVisualStyleBackColor = true;
            this.rbtnBillcode.CheckedChanged += new System.EventHandler(this.rbtnInvoicecode_CheckedChanged);
            // 
            // rbtnOldBill
            // 
            this.rbtnOldBill.AutoSize = true;
            this.rbtnOldBill.Font = new System.Drawing.Font("宋体", 11F);
            this.rbtnOldBill.Location = new System.Drawing.Point(276, 156);
            this.rbtnOldBill.Name = "rbtnOldBill";
            this.rbtnOldBill.Size = new System.Drawing.Size(93, 19);
            this.rbtnOldBill.TabIndex = 105;
            this.rbtnOldBill.TabStop = true;
            this.rbtnOldBill.Text = "原发票号:";
            this.rbtnOldBill.UseVisualStyleBackColor = true;
            // 
            // rbtnNewBill
            // 
            this.rbtnNewBill.AutoSize = true;
            this.rbtnNewBill.Font = new System.Drawing.Font("宋体", 11F);
            this.rbtnNewBill.Location = new System.Drawing.Point(276, 184);
            this.rbtnNewBill.Name = "rbtnNewBill";
            this.rbtnNewBill.Size = new System.Drawing.Size(93, 19);
            this.rbtnNewBill.TabIndex = 106;
            this.rbtnNewBill.TabStop = true;
            this.rbtnNewBill.Text = "新发票号:";
            this.rbtnNewBill.UseVisualStyleBackColor = true;
            // 
            // lblCheque
            // 
            this.lblCheque.AutoSize = true;
            this.lblCheque.Font = new System.Drawing.Font("宋体", 11F);
            this.lblCheque.Location = new System.Drawing.Point(652, 82);
            this.lblCheque.Name = "lblCheque";
            this.lblCheque.Size = new System.Drawing.Size(52, 15);
            this.lblCheque.TabIndex = 97;
            this.lblCheque.Text = "×××";
            // 
            // lblBas_paytype
            // 
            this.lblBas_paytype.AutoSize = true;
            this.lblBas_paytype.Font = new System.Drawing.Font("宋体", 11F);
            this.lblBas_paytype.Location = new System.Drawing.Point(517, 82);
            this.lblBas_paytype.Name = "lblBas_paytype";
            this.lblBas_paytype.Size = new System.Drawing.Size(52, 15);
            this.lblBas_paytype.TabIndex = 98;
            this.lblBas_paytype.Text = "×××";
            // 
            // lblPrepamt
            // 
            this.lblPrepamt.AutoSize = true;
            this.lblPrepamt.Font = new System.Drawing.Font("宋体", 11F);
            this.lblPrepamt.Location = new System.Drawing.Point(73, 115);
            this.lblPrepamt.Name = "lblPrepamt";
            this.lblPrepamt.Size = new System.Drawing.Size(52, 15);
            this.lblPrepamt.TabIndex = 95;
            this.lblPrepamt.Text = "×××";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("宋体", 11F);
            this.lblDoctor.Location = new System.Drawing.Point(214, 82);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(52, 15);
            this.lblDoctor.TabIndex = 96;
            this.lblDoctor.Text = "×××";
            // 
            // lblNewBill
            // 
            this.lblNewBill.AutoSize = true;
            this.lblNewBill.Font = new System.Drawing.Font("宋体", 11F);
            this.lblNewBill.Location = new System.Drawing.Point(365, 186);
            this.lblNewBill.Name = "lblNewBill";
            this.lblNewBill.Size = new System.Drawing.Size(71, 15);
            this.lblNewBill.TabIndex = 99;
            this.lblNewBill.Text = "00000002";
            // 
            // lblOldBill
            // 
            this.lblOldBill.AutoSize = true;
            this.lblOldBill.Font = new System.Drawing.Font("宋体", 11F);
            this.lblOldBill.Location = new System.Drawing.Point(365, 158);
            this.lblOldBill.Name = "lblOldBill";
            this.lblOldBill.Size = new System.Drawing.Size(71, 15);
            this.lblOldBill.TabIndex = 102;
            this.lblOldBill.Text = "00000001";
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.lblDepart.Location = new System.Drawing.Point(73, 82);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(52, 15);
            this.lblDepart.TabIndex = 103;
            this.lblDepart.Text = "×××";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("宋体", 11F);
            this.lblAge.Location = new System.Drawing.Point(652, 51);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(22, 15);
            this.lblAge.TabIndex = 100;
            this.lblAge.Text = "×";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("宋体", 11F);
            this.lblSex.Location = new System.Drawing.Point(517, 51);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(22, 15);
            this.lblSex.TabIndex = 101;
            this.lblSex.Text = "×";
            // 
            // lblIhspcode
            // 
            this.lblIhspcode.AutoSize = true;
            this.lblIhspcode.Font = new System.Drawing.Font("宋体", 11F);
            this.lblIhspcode.Location = new System.Drawing.Point(73, 51);
            this.lblIhspcode.Name = "lblIhspcode";
            this.lblIhspcode.Size = new System.Drawing.Size(67, 15);
            this.lblIhspcode.TabIndex = 93;
            this.lblIhspcode.Text = "××××";
            // 
            // lblHspcard
            // 
            this.lblHspcard.AutoSize = true;
            this.lblHspcard.Font = new System.Drawing.Font("宋体", 11F);
            this.lblHspcard.Location = new System.Drawing.Point(368, 51);
            this.lblHspcard.Name = "lblHspcard";
            this.lblHspcard.Size = new System.Drawing.Size(52, 15);
            this.lblHspcard.TabIndex = 94;
            this.lblHspcard.Text = "×××";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 11F);
            this.lblName.Location = new System.Drawing.Point(214, 51);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 15);
            this.lblName.TabIndex = 92;
            this.lblName.Text = "×××";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(19, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 84;
            this.label4.Text = "住院号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(327, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 85;
            this.label3.Text = "卡号:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11F);
            this.label11.Location = new System.Drawing.Point(596, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 83;
            this.label11.Text = "支票号:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(446, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 81;
            this.label10.Text = "交款方式:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11F);
            this.label9.Location = new System.Drawing.Point(19, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 82;
            this.label9.Text = "预交款:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(173, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 86;
            this.label8.Text = "医生:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.Location = new System.Drawing.Point(31, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 90;
            this.label7.Text = "科室:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(611, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 91;
            this.label6.Text = "年龄:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(476, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 89;
            this.label5.Text = "性别:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(173, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 87;
            this.label2.Text = "姓名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(268, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 22);
            this.label1.TabIndex = 88;
            this.label1.Text = "重打住院发票";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 11F);
            this.label12.Location = new System.Drawing.Point(446, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 15);
            this.label12.TabIndex = 82;
            this.label12.Text = "统筹支付:";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 11F);
            this.label13.Location = new System.Drawing.Point(297, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 15);
            this.label13.TabIndex = 81;
            this.label13.Text = "账户支付:";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 11F);
            this.label14.Location = new System.Drawing.Point(297, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 15);
            this.label14.TabIndex = 83;
            this.label14.Text = "患者类型:";
            // 
            // lblInsurefee
            // 
            this.lblInsurefee.AutoSize = true;
            this.lblInsurefee.Font = new System.Drawing.Font("宋体", 11F);
            this.lblInsurefee.Location = new System.Drawing.Point(517, 115);
            this.lblInsurefee.Name = "lblInsurefee";
            this.lblInsurefee.Size = new System.Drawing.Size(52, 15);
            this.lblInsurefee.TabIndex = 95;
            this.lblInsurefee.Text = "×××";
            this.lblInsurefee.Visible = false;
            // 
            // lblSelffee
            // 
            this.lblSelffee.AutoSize = true;
            this.lblSelffee.Font = new System.Drawing.Font("宋体", 11F);
            this.lblSelffee.Location = new System.Drawing.Point(368, 115);
            this.lblSelffee.Name = "lblSelffee";
            this.lblSelffee.Size = new System.Drawing.Size(52, 15);
            this.lblSelffee.TabIndex = 98;
            this.lblSelffee.Text = "×××";
            this.lblSelffee.Visible = false;
            // 
            // lblPatienttype
            // 
            this.lblPatienttype.AutoSize = true;
            this.lblPatienttype.Font = new System.Drawing.Font("宋体", 11F);
            this.lblPatienttype.Location = new System.Drawing.Point(368, 82);
            this.lblPatienttype.Name = "lblPatienttype";
            this.lblPatienttype.Size = new System.Drawing.Size(52, 15);
            this.lblPatienttype.TabIndex = 97;
            this.lblPatienttype.Text = "×××";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 11F);
            this.label15.Location = new System.Drawing.Point(158, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 15);
            this.label15.TabIndex = 82;
            this.label15.Text = "总费用:";
            // 
            // lblFeeamt
            // 
            this.lblFeeamt.AutoSize = true;
            this.lblFeeamt.Font = new System.Drawing.Font("宋体", 11F);
            this.lblFeeamt.Location = new System.Drawing.Point(213, 115);
            this.lblFeeamt.Name = "lblFeeamt";
            this.lblFeeamt.Size = new System.Drawing.Size(52, 15);
            this.lblFeeamt.TabIndex = 95;
            this.lblFeeamt.Text = "×××";
            // 
            // FrmIhspRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 248);
            this.Controls.Add(this.lblOldBill);
            this.Controls.Add(this.lblNewBill);
            this.Controls.Add(this.tbxBillcode);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rbtnBillcode);
            this.Controls.Add(this.rbtnOldBill);
            this.Controls.Add(this.rbtnNewBill);
            this.Controls.Add(this.lblPatienttype);
            this.Controls.Add(this.lblCheque);
            this.Controls.Add(this.lblSelffee);
            this.Controls.Add(this.lblBas_paytype);
            this.Controls.Add(this.lblInsurefee);
            this.Controls.Add(this.lblFeeamt);
            this.Controls.Add(this.lblPrepamt);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblDepart);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblIhspcode);
            this.Controls.Add(this.lblHspcard);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmIhspRpt";
            this.Text = "重打发票";
            this.Load += new System.EventHandler(this.FrmRePrint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxBillcode;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rbtnBillcode;
        private System.Windows.Forms.RadioButton rbtnOldBill;
        private System.Windows.Forms.RadioButton rbtnNewBill;
        private System.Windows.Forms.Label lblCheque;
        private System.Windows.Forms.Label lblBas_paytype;
        private System.Windows.Forms.Label lblPrepamt;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblNewBill;
        private System.Windows.Forms.Label lblOldBill;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblIhspcode;
        private System.Windows.Forms.Label lblHspcard;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblInsurefee;
        private System.Windows.Forms.Label lblSelffee;
        private System.Windows.Forms.Label lblPatienttype;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblFeeamt;
    }
}