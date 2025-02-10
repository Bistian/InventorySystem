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
            this.label_font_text = new System.Windows.Forms.Label();
            this.panelHome = new System.Windows.Forms.Panel();
            this.label_font_title = new System.Windows.Forms.Label();
            this.numeric_font_text = new System.Windows.Forms.NumericUpDown();
            this.numeric_font_title = new System.Windows.Forms.NumericUpDown();
            this.button_save = new System.Windows.Forms.Button();
            this.panelHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_font_text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_font_title)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGeneralBehavior
            // 
            this.labelGeneralBehavior.AutoSize = true;
            this.labelGeneralBehavior.ForeColor = System.Drawing.SystemColors.Window;
            this.labelGeneralBehavior.Location = new System.Drawing.Point(285, 32);
            this.labelGeneralBehavior.Name = "labelGeneralBehavior";
            this.labelGeneralBehavior.Size = new System.Drawing.Size(89, 13);
            this.labelGeneralBehavior.TabIndex = 0;
            this.labelGeneralBehavior.Text = "General Behavior";
            this.labelGeneralBehavior.Visible = false;
            // 
            // labelHome
            // 
            this.labelHome.AutoSize = true;
            this.labelHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHome.ForeColor = System.Drawing.SystemColors.Window;
            this.labelHome.Location = new System.Drawing.Point(29, 6);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(157, 55);
            this.labelHome.TabIndex = 1;
            this.labelHome.Text = "Home";
            // 
            // tbDueDays
            // 
            this.tbDueDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDueDays.Location = new System.Drawing.Point(92, 66);
            this.tbDueDays.Name = "tbDueDays";
            this.tbDueDays.Size = new System.Drawing.Size(84, 37);
            this.tbDueDays.TabIndex = 2;
            // 
            // labelDueDays
            // 
            this.labelDueDays.AutoSize = true;
            this.labelDueDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDueDays.ForeColor = System.Drawing.SystemColors.Window;
            this.labelDueDays.Location = new System.Drawing.Point(12, 75);
            this.labelDueDays.Name = "labelDueDays";
            this.labelDueDays.Size = new System.Drawing.Size(89, 24);
            this.labelDueDays.TabIndex = 3;
            this.labelDueDays.Text = "Due days";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            // 
            // label_font_text
            // 
            this.label_font_text.AutoSize = true;
            this.label_font_text.ForeColor = System.Drawing.SystemColors.Window;
            this.label_font_text.Location = new System.Drawing.Point(285, 45);
            this.label_font_text.Name = "label_font_text";
            this.label_font_text.Size = new System.Drawing.Size(52, 13);
            this.label_font_text.TabIndex = 5;
            this.label_font_text.Text = "Font Text";
            this.label_font_text.Visible = false;
            // 
            // panelHome
            // 
            this.panelHome.Controls.Add(this.labelDueDays);
            this.panelHome.Controls.Add(this.labelHome);
            this.panelHome.Controls.Add(this.tbDueDays);
            this.panelHome.Controls.Add(this.btnSave);
            this.panelHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelHome.Location = new System.Drawing.Point(0, 0);
            this.panelHome.Margin = new System.Windows.Forms.Padding(2);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(195, 450);
            this.panelHome.TabIndex = 7;
            // 
            // label_font_title
            // 
            this.label_font_title.AutoSize = true;
            this.label_font_title.ForeColor = System.Drawing.SystemColors.Window;
            this.label_font_title.Location = new System.Drawing.Point(285, 71);
            this.label_font_title.Name = "label_font_title";
            this.label_font_title.Size = new System.Drawing.Size(51, 13);
            this.label_font_title.TabIndex = 8;
            this.label_font_title.Text = "Font Title";
            this.label_font_title.Visible = false;
            // 
            // numeric_font_text
            // 
            this.numeric_font_text.Location = new System.Drawing.Point(357, 43);
            this.numeric_font_text.Name = "numeric_font_text";
            this.numeric_font_text.Size = new System.Drawing.Size(32, 20);
            this.numeric_font_text.TabIndex = 10;
            // 
            // numeric_font_title
            // 
            this.numeric_font_title.Location = new System.Drawing.Point(357, 69);
            this.numeric_font_title.Name = "numeric_font_title";
            this.numeric_font_title.Size = new System.Drawing.Size(32, 20);
            this.numeric_font_title.TabIndex = 11;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(260, 171);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 12;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.btn_save);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.numeric_font_title);
            this.Controls.Add(this.numeric_font_text);
            this.Controls.Add(this.label_font_title);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.label_font_text);
            this.Controls.Add(this.labelGeneralBehavior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.panelHome.ResumeLayout(false);
            this.panelHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_font_text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_font_title)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGeneralBehavior;
        private System.Windows.Forms.Label labelHome;
        private System.Windows.Forms.TextBox tbDueDays;
        private System.Windows.Forms.Label labelDueDays;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label_font_text;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Label label_font_title;
        private System.Windows.Forms.NumericUpDown numeric_font_text;
        private System.Windows.Forms.NumericUpDown numeric_font_title;
        private System.Windows.Forms.Button button_save;
    }
}