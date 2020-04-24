namespace Main
{
    partial class FrmPathDetail
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
            this.lvwPathDetail = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwPathDetail
            // 
            this.lvwPathDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPathDetail.FullRowSelect = true;
            this.lvwPathDetail.GridLines = true;
            this.lvwPathDetail.Location = new System.Drawing.Point(0, 0);
            this.lvwPathDetail.Name = "lvwPathDetail";
            this.lvwPathDetail.Size = new System.Drawing.Size(398, 382);
            this.lvwPathDetail.TabIndex = 1;
            this.lvwPathDetail.UseCompatibleStateImageBehavior = false;
            this.lvwPathDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwPathDetail_KeyDown);
            // 
            // FrmPathDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 382);
            this.Controls.Add(this.lvwPathDetail);
            this.Name = "FrmPathDetail";
            this.Text = "Path Details";
            this.Load += new System.EventHandler(this.FrmPathDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPathDetail;
    }
}