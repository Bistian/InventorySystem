namespace InventoryManagmentSystem
{
    partial class ReturnOrReplacecs
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
            this.gradientFlowLayoutPanel1 = new InventoryManagmentSystem.GradientFlowLayoutPanel();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.gradientFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientFlowLayoutPanel1
            // 
            this.gradientFlowLayoutPanel1.Controls.Add(this.buttonReturn);
            this.gradientFlowLayoutPanel1.Controls.Add(this.buttonReplace);
            this.gradientFlowLayoutPanel1.Controls.Add(this.Cancel);
            this.gradientFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientFlowLayoutPanel1.EndColor = System.Drawing.Color.MidnightBlue;
            this.gradientFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientFlowLayoutPanel1.Name = "gradientFlowLayoutPanel1";
            this.gradientFlowLayoutPanel1.Size = new System.Drawing.Size(650, 300);
            this.gradientFlowLayoutPanel1.StartColor = System.Drawing.Color.Empty;
            this.gradientFlowLayoutPanel1.TabIndex = 0;
            // 
            // buttonReturn
            // 
            this.buttonReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonReturn.Location = new System.Drawing.Point(110, 60);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(110, 60, 0, 3);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(200, 100);
            this.buttonReturn.TabIndex = 0;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonReplace
            // 
            this.buttonReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReplace.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonReplace.Location = new System.Drawing.Point(335, 60);
            this.buttonReplace.Margin = new System.Windows.Forms.Padding(25, 60, 3, 3);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(200, 100);
            this.buttonReplace.TabIndex = 1;
            this.buttonReplace.Text = "Replace";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Cancel.Location = new System.Drawing.Point(222, 183);
            this.Cancel.Margin = new System.Windows.Forms.Padding(222, 20, 3, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(200, 65);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ReturnOrReplacecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(650, 300);
            this.Controls.Add(this.gradientFlowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReturnOrReplacecs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReturnOrReplacecs";
            this.gradientFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GradientFlowLayoutPanel gradientFlowLayoutPanel1;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.Button Cancel;
    }
}