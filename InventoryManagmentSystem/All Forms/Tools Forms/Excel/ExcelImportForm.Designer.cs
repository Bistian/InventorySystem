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
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
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
            // btnImport
            // 
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(12, 41);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(121, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.labelTitle);
            this.Name = "ExcelImportForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ExcelImport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
