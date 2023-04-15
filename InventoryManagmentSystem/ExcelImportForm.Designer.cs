namespace InventoryManagmentSystem
{
    partial class ExcelImportForm
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
            this.btnManual = new System.Windows.Forms.Button();
            this.comboBoxTbSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnStandard = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnManual
            // 
            this.btnManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManual.Enabled = false;
            this.btnManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManual.Location = new System.Drawing.Point(17, 162);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(121, 23);
            this.btnManual.TabIndex = 0;
            this.btnManual.Text = "Manual Import";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Visible = false;
            this.btnManual.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // comboBoxTbSelect
            // 
            this.comboBoxTbSelect.Enabled = false;
            this.comboBoxTbSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboBoxTbSelect.FormattingEnabled = true;
            this.comboBoxTbSelect.Location = new System.Drawing.Point(17, 206);
            this.comboBoxTbSelect.Name = "comboBoxTbSelect";
            this.comboBoxTbSelect.Size = new System.Drawing.Size(121, 23);
            this.comboBoxTbSelect.TabIndex = 1;
            this.comboBoxTbSelect.Visible = false;
            this.comboBoxTbSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxTbSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(14, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Databse Table";
            this.label1.Visible = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTitle.Location = new System.Drawing.Point(12, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(119, 25);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Excel Import";
            // 
            // btnStandard
            // 
            this.btnStandard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandard.Location = new System.Drawing.Point(12, 41);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(121, 23);
            this.btnStandard.TabIndex = 4;
            this.btnStandard.Text = "Standard Import";
            this.btnStandard.UseVisualStyleBackColor = true;
            this.btnStandard.Click += new System.EventHandler(this.btnStandard_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.ForestGreen;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.Location = new System.Drawing.Point(12, 73);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(121, 10);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // ExcelImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(325, 261);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnStandard);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTbSelect);
            this.Controls.Add(this.btnManual);
            this.Name = "ExcelImportForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ExcelImport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.ComboBox comboBoxTbSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}