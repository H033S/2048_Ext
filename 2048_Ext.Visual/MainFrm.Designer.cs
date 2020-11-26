namespace _2048_Ext.Visual
{
    partial class mainfrm
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
            this.optgbox = new System.Windows.Forms.GroupBox();
            this.exitBttn = new System.Windows.Forms.Button();
            this.newBttn = new System.Windows.Forms.Button();
            this.loadBttn = new System.Windows.Forms.Button();
            this.columnUpDwn = new System.Windows.Forms.NumericUpDown();
            this.columnlbl = new System.Windows.Forms.Label();
            this.rowUpDwn = new System.Windows.Forms.NumericUpDown();
            this.nameOfPlayertbx = new System.Windows.Forms.TextBox();
            this.rowslbl = new System.Windows.Forms.Label();
            this.nameOfPlayerlbl = new System.Windows.Forms.Label();
            this.loadFDlog = new System.Windows.Forms.OpenFileDialog();
            this.optgbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowUpDwn)).BeginInit();
            this.SuspendLayout();
            // 
            // optgbox
            // 
            this.optgbox.BackColor = System.Drawing.Color.LightSkyBlue;
            this.optgbox.Controls.Add(this.exitBttn);
            this.optgbox.Controls.Add(this.newBttn);
            this.optgbox.Controls.Add(this.loadBttn);
            this.optgbox.Controls.Add(this.columnUpDwn);
            this.optgbox.Controls.Add(this.columnlbl);
            this.optgbox.Controls.Add(this.rowUpDwn);
            this.optgbox.Controls.Add(this.nameOfPlayertbx);
            this.optgbox.Controls.Add(this.rowslbl);
            this.optgbox.Controls.Add(this.nameOfPlayerlbl);
            this.optgbox.Location = new System.Drawing.Point(12, 12);
            this.optgbox.Name = "optgbox";
            this.optgbox.Size = new System.Drawing.Size(338, 246);
            this.optgbox.TabIndex = 0;
            this.optgbox.TabStop = false;
            // 
            // exitBttn
            // 
            this.exitBttn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exitBttn.Location = new System.Drawing.Point(51, 195);
            this.exitBttn.Name = "exitBttn";
            this.exitBttn.Size = new System.Drawing.Size(230, 28);
            this.exitBttn.TabIndex = 5;
            this.exitBttn.Text = "Exit";
            this.exitBttn.UseVisualStyleBackColor = true;
            this.exitBttn.Click += new System.EventHandler(this.exitBttn_Click);
            // 
            // newBttn
            // 
            this.newBttn.Location = new System.Drawing.Point(51, 127);
            this.newBttn.Name = "newBttn";
            this.newBttn.Size = new System.Drawing.Size(230, 28);
            this.newBttn.TabIndex = 5;
            this.newBttn.Text = "New Game";
            this.newBttn.UseVisualStyleBackColor = true;
            this.newBttn.Click += new System.EventHandler(this.newBttn_Click);
            // 
            // loadBttn
            // 
            this.loadBttn.Location = new System.Drawing.Point(51, 161);
            this.loadBttn.Name = "loadBttn";
            this.loadBttn.Size = new System.Drawing.Size(230, 28);
            this.loadBttn.TabIndex = 5;
            this.loadBttn.Text = "Load Game";
            this.loadBttn.UseVisualStyleBackColor = true;
            this.loadBttn.Click += new System.EventHandler(this.loadBttn_Click_1);
            // 
            // columnUpDwn
            // 
            this.columnUpDwn.Location = new System.Drawing.Point(220, 68);
            this.columnUpDwn.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.columnUpDwn.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.columnUpDwn.Name = "columnUpDwn";
            this.columnUpDwn.ReadOnly = true;
            this.columnUpDwn.Size = new System.Drawing.Size(48, 22);
            this.columnUpDwn.TabIndex = 4;
            this.columnUpDwn.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // columnlbl
            // 
            this.columnlbl.AutoSize = true;
            this.columnlbl.Location = new System.Drawing.Point(152, 70);
            this.columnlbl.Name = "columnlbl";
            this.columnlbl.Size = new System.Drawing.Size(62, 17);
            this.columnlbl.TabIndex = 3;
            this.columnlbl.Text = "Columns";
            // 
            // rowUpDwn
            // 
            this.rowUpDwn.Location = new System.Drawing.Point(87, 68);
            this.rowUpDwn.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.rowUpDwn.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.rowUpDwn.Name = "rowUpDwn";
            this.rowUpDwn.ReadOnly = true;
            this.rowUpDwn.Size = new System.Drawing.Size(48, 22);
            this.rowUpDwn.TabIndex = 2;
            this.rowUpDwn.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nameOfPlayertbx
            // 
            this.nameOfPlayertbx.Location = new System.Drawing.Point(65, 18);
            this.nameOfPlayertbx.Name = "nameOfPlayertbx";
            this.nameOfPlayertbx.Size = new System.Drawing.Size(239, 22);
            this.nameOfPlayertbx.TabIndex = 1;
            // 
            // rowslbl
            // 
            this.rowslbl.AutoSize = true;
            this.rowslbl.Location = new System.Drawing.Point(39, 70);
            this.rowslbl.Name = "rowslbl";
            this.rowslbl.Size = new System.Drawing.Size(42, 17);
            this.rowslbl.TabIndex = 0;
            this.rowslbl.Text = "Rows";
            // 
            // nameOfPlayerlbl
            // 
            this.nameOfPlayerlbl.AutoSize = true;
            this.nameOfPlayerlbl.Location = new System.Drawing.Point(6, 18);
            this.nameOfPlayerlbl.Name = "nameOfPlayerlbl";
            this.nameOfPlayerlbl.Size = new System.Drawing.Size(53, 17);
            this.nameOfPlayerlbl.TabIndex = 0;
            this.nameOfPlayerlbl.Text = "Name :";
            // 
            // loadFDlog
            // 
            this.loadFDlog.FileName = "LoadGame";
            // 
            // mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(361, 272);
            this.Controls.Add(this.optgbox);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainfrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048 Ext";
            this.optgbox.ResumeLayout(false);
            this.optgbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowUpDwn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox optgbox;
        private System.Windows.Forms.Label nameOfPlayerlbl;
        private System.Windows.Forms.NumericUpDown rowUpDwn;
        private System.Windows.Forms.TextBox nameOfPlayertbx;
        private System.Windows.Forms.Label rowslbl;
        private System.Windows.Forms.Button exitBttn;
        private System.Windows.Forms.Button newBttn;
        private System.Windows.Forms.Button loadBttn;
        private System.Windows.Forms.NumericUpDown columnUpDwn;
        private System.Windows.Forms.Label columnlbl;
        private System.Windows.Forms.OpenFileDialog loadFDlog;
    }
}

