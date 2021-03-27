namespace MTREG.ihsptab
{
    partial class FrmPreView
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
            this.rptPreviewCtrl = new FastReport.Preview.PreviewControl();
            this.lvPreviewItem = new System.Windows.Forms.ListView();
            this.btnDesign = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rptPreviewCtrl
            // 
            this.rptPreviewCtrl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptPreviewCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptPreviewCtrl.Font = new System.Drawing.Font("宋体", 9F);
            this.rptPreviewCtrl.Location = new System.Drawing.Point(152, 0);
            this.rptPreviewCtrl.Name = "rptPreviewCtrl";
            this.rptPreviewCtrl.PageOffset = new System.Drawing.Point(10, 10);
            this.rptPreviewCtrl.Size = new System.Drawing.Size(831, 557);
            this.rptPreviewCtrl.TabIndex = 0;
            this.rptPreviewCtrl.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
            // 
            // lvPreviewItem
            // 
            this.lvPreviewItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvPreviewItem.Location = new System.Drawing.Point(0, 0);
            this.lvPreviewItem.Name = "lvPreviewItem";
            this.lvPreviewItem.Size = new System.Drawing.Size(152, 557);
            this.lvPreviewItem.TabIndex = 1;
            this.lvPreviewItem.UseCompatibleStateImageBehavior = false;
            this.lvPreviewItem.SelectedIndexChanged += new System.EventHandler(this.lvPreviewItem_SelectedIndexChanged);
            // 
            // btnDesign
            // 
            this.btnDesign.Font = new System.Drawing.Font("宋体", 11F);
            this.btnDesign.Location = new System.Drawing.Point(74, 513);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(61, 23);
            this.btnDesign.TabIndex = 4;
            this.btnDesign.Text = "设计";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnPrint.Location = new System.Drawing.Point(74, 469);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmPreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 557);
            this.Controls.Add(this.rptPreviewCtrl);
            this.Controls.Add(this.btnDesign);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lvPreviewItem);
            this.Name = "FrmPreView";
            this.Text = "FrmPreView";
            this.Load += new System.EventHandler(this.FrmPreView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Preview.PreviewControl rptPreviewCtrl;
        private System.Windows.Forms.ListView lvPreviewItem;
        private System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.Button btnPrint;
    }
}