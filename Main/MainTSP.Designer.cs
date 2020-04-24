namespace Main
{
    partial class MainTSP
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numMutation = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numCrossOver = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numPopSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numGenLimit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numCities = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ptbMap = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPath.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtPath.Location = new System.Drawing.Point(180, 495);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(748, 50);
            this.txtPath.TabIndex = 10;
            this.txtPath.Text = "Waiting for solution...";
            this.txtPath.DoubleClick += new System.EventHandler(this.txtPath_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalCost);
            this.groupBox2.Location = new System.Drawing.Point(-4, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 46);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total cost";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTotalCost.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCost.Location = new System.Drawing.Point(7, 19);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalCost.Size = new System.Drawing.Size(17, 18);
            this.lblTotalCost.TabIndex = 0;
            this.lblTotalCost.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numMutation);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numCrossOver);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numPopSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numGenLimit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numCities);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 307);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // numMutation
            // 
            this.numMutation.DecimalPlaces = 2;
            this.numMutation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMutation.Location = new System.Drawing.Point(9, 275);
            this.numMutation.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMutation.Name = "numMutation";
            this.numMutation.Size = new System.Drawing.Size(163, 20);
            this.numMutation.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mutation prob. (0.40 - 1.00)";
            // 
            // numCrossOver
            // 
            this.numCrossOver.DecimalPlaces = 2;
            this.numCrossOver.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCrossOver.Location = new System.Drawing.Point(9, 217);
            this.numCrossOver.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCrossOver.Name = "numCrossOver";
            this.numCrossOver.Size = new System.Drawing.Size(163, 20);
            this.numCrossOver.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Crossover prob. (0.00 - 1.00)";
            // 
            // numPopSize
            // 
            this.numPopSize.Location = new System.Drawing.Point(9, 157);
            this.numPopSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPopSize.Name = "numPopSize";
            this.numPopSize.Size = new System.Drawing.Size(163, 20);
            this.numPopSize.TabIndex = 2;
            this.numPopSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Population size (>1)";
            // 
            // numGenLimit
            // 
            this.numGenLimit.Location = new System.Drawing.Point(9, 100);
            this.numGenLimit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numGenLimit.Name = "numGenLimit";
            this.numGenLimit.Size = new System.Drawing.Size(163, 20);
            this.numGenLimit.TabIndex = 1;
            this.numGenLimit.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Generations limit (>1)";
            // 
            // numCities
            // 
            this.numCities.Location = new System.Drawing.Point(9, 44);
            this.numCities.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCities.Name = "numCities";
            this.numCities.Size = new System.Drawing.Size(163, 20);
            this.numCities.TabIndex = 0;
            this.numCities.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of cities (4-99)";
            // 
            // btnRandomize
            // 
            this.btnRandomize.ForeColor = System.Drawing.Color.Crimson;
            this.btnRandomize.Image = global::Main.Properties.Resources.package_games_board;
            this.btnRandomize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRandomize.Location = new System.Drawing.Point(31, 374);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(109, 37);
            this.btnRandomize.TabIndex = 9;
            this.btnRandomize.Text = "Randomize Data";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnSearch.Image = global::Main.Properties.Resources.gnome_edit_find;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(26, 489);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 58);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Solve !!\r\n";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnRefresh.Image = global::Main.Properties.Resources.arrow_refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(31, 428);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 37);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ptbMap
            // 
            this.ptbMap.BackColor = System.Drawing.SystemColors.Window;
            this.ptbMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbMap.Image = global::Main.Properties.Resources.world_map_146505_1280;
            this.ptbMap.Location = new System.Drawing.Point(174, 1);
            this.ptbMap.Name = "ptbMap";
            this.ptbMap.Size = new System.Drawing.Size(728, 488);
            this.ptbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMap.TabIndex = 6;
            this.ptbMap.TabStop = false;
            this.ptbMap.Paint += new System.Windows.Forms.PaintEventHandler(this.ptbMap_Paint);
            this.ptbMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbMap_MouseDown);
            this.ptbMap.MouseLeave += new System.EventHandler(this.ptbMap_MouseLeave);
            this.ptbMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbMap_MouseMove);
            // 
            // MainTSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 576);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnRandomize);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ptbMap);
            this.Name = "MainTSP";
            this.Text = "Genetic For TSP";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnRandomize;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numMutation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCrossOver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPopSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numGenLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbMap;
    }
}

