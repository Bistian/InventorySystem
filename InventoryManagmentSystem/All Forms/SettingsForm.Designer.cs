namespace InventoryManagmentSystem
{
    partial class SettingsForm
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
            this.labelGeneralBehavior = new System.Windows.Forms.Label();
            this.labelHome = new System.Windows.Forms.Label();
            this.tbDueDays = new System.Windows.Forms.TextBox();
            this.labelDueDays = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelFontSize = new System.Windows.Forms.Label();
            this.tbFontSize = new System.Windows.Forms.TextBox();
            this.panelHome = new System.Windows.Forms.Panel();
            this.panelHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGeneralBehavior
            // 
            this.labelGeneralBehavior.AutoSize = true;
            this.labelGeneralBehavior.ForeColor = System.Drawing.SystemColors.Window;
            this.labelGeneralBehavior.Location = new System.Drawing.Point(380, 39);
            this.labelGeneralBehavior.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGeneralBehavior.Name = "labelGeneralBehavior";
            this.labelGeneralBehavior.Size = new System.Drawing.Size(112, 16);
            this.labelGeneralBehavior.TabIndex = 0;
            this.labelGeneralBehavior.Text = "General Behavior";
            this.labelGeneralBehavior.Visible = false;
            // 
            // labelHome
            // 
            this.labelHome.AutoSize = true;
            this.labelHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHome.ForeColor = System.Drawing.SystemColors.Window;
            this.labelHome.Location = new System.Drawing.Point(39, 8);
            this.labelHome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(193, 69);
            this.labelHome.TabIndex = 1;
            this.labelHome.Text = "Home";
            // 
            // tbDueDays
            // 
            this.tbDueDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDueDays.Location = new System.Drawing.Point(122, 81);
            this.tbDueDays.Margin = new System.Windows.Forms.Padding(4);
            this.tbDueDays.Name = "tbDueDays";
            this.tbDueDays.Size = new System.Drawing.Size(110, 45);
            this.tbDueDays.TabIndex = 2;
            // 
            // labelDueDays
            // 
            this.labelDueDays.AutoSize = true;
            this.labelDueDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDueDays.ForeColor = System.Drawing.SystemColors.Window;
            this.labelDueDays.Location = new System.Drawing.Point(16, 92);
            this.labelDueDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDueDays.Name = "labelDueDays";
            this.labelDueDays.Size = new System.Drawing.Size(113, 29);
            this.labelDueDays.TabIndex = 3;
            this.labelDueDays.Text = "Due days";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(51, 164);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 50);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelFontSize
            // 
            this.labelFontSize.AutoSize = true;
            this.labelFontSize.ForeColor = System.Drawing.SystemColors.Window;
            this.labelFontSize.Location = new System.Drawing.Point(380, 55);
            this.labelFontSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFontSize.Name = "labelFontSize";
            this.labelFontSize.Size = new System.Drawing.Size(62, 16);
            this.labelFontSize.TabIndex = 5;
            this.labelFontSize.Text = "Font Size";
            this.labelFontSize.Visible = false;
            // 
            // tbFontSize
            // 
            this.tbFontSize.Location = new System.Drawing.Point(457, 55);
            this.tbFontSize.Margin = new System.Windows.Forms.Padding(4);
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.Size = new System.Drawing.Size(63, 22);
            this.tbFontSize.TabIndex = 6;
            this.tbFontSize.Visible = false;
            // 
            // panelHome
            // 
            this.panelHome.Controls.Add(this.labelDueDays);
            this.panelHome.Controls.Add(this.labelHome);
            this.panelHome.Controls.Add(this.tbDueDays);
            this.panelHome.Controls.Add(this.btnSave);
            this.panelHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelHome.Location = new System.Drawing.Point(0, 0);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(260, 554);
            this.panelHome.TabIndex = 7;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.tbFontSize);
            this.Controls.Add(this.labelFontSize);
            this.Controls.Add(this.labelGeneralBehavior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.panelHome.ResumeLayout(false);
            this.panelHome.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGeneralBehavior;
        private System.Windows.Forms.Label labelHome;
        private System.Windows.Forms.TextBox tbDueDays;
        private System.Windows.Forms.Label labelDueDays;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labelFontSize;
        private System.Windows.Forms.TextBox tbFontSize;
        private System.Windows.Forms.Panel panelHome;
    }
}