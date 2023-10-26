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
            this.SuspendLayout();
            // 
            // labelGeneralBehavior
            // 
            this.labelGeneralBehavior.AutoSize = true;
            this.labelGeneralBehavior.ForeColor = System.Drawing.SystemColors.Window;
            this.labelGeneralBehavior.Location = new System.Drawing.Point(12, 9);
            this.labelGeneralBehavior.Name = "labelGeneralBehavior";
            this.labelGeneralBehavior.Size = new System.Drawing.Size(89, 13);
            this.labelGeneralBehavior.TabIndex = 0;
            this.labelGeneralBehavior.Text = "General Behavior";
            // 
            // labelHome
            // 
            this.labelHome.AutoSize = true;
            this.labelHome.ForeColor = System.Drawing.SystemColors.Window;
            this.labelHome.Location = new System.Drawing.Point(12, 157);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(35, 13);
            this.labelHome.TabIndex = 1;
            this.labelHome.Text = "Home";
            // 
            // tbDueDays
            // 
            this.tbDueDays.Location = new System.Drawing.Point(70, 167);
            this.tbDueDays.Name = "tbDueDays";
            this.tbDueDays.Size = new System.Drawing.Size(48, 20);
            this.tbDueDays.TabIndex = 2;
            // 
            // labelDueDays
            // 
            this.labelDueDays.AutoSize = true;
            this.labelDueDays.ForeColor = System.Drawing.SystemColors.Window;
            this.labelDueDays.Location = new System.Drawing.Point(12, 170);
            this.labelDueDays.Name = "labelDueDays";
            this.labelDueDays.Size = new System.Drawing.Size(52, 13);
            this.labelDueDays.TabIndex = 3;
            this.labelDueDays.Text = "Due days";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelFontSize
            // 
            this.labelFontSize.AutoSize = true;
            this.labelFontSize.ForeColor = System.Drawing.SystemColors.Window;
            this.labelFontSize.Location = new System.Drawing.Point(12, 22);
            this.labelFontSize.Name = "labelFontSize";
            this.labelFontSize.Size = new System.Drawing.Size(51, 13);
            this.labelFontSize.TabIndex = 5;
            this.labelFontSize.Text = "Font Size";
            // 
            // tbFontSize
            // 
            this.tbFontSize.Location = new System.Drawing.Point(70, 22);
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.Size = new System.Drawing.Size(48, 20);
            this.tbFontSize.TabIndex = 6;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbFontSize);
            this.Controls.Add(this.labelFontSize);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelDueDays);
            this.Controls.Add(this.tbDueDays);
            this.Controls.Add(this.labelHome);
            this.Controls.Add(this.labelGeneralBehavior);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
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
    }
}