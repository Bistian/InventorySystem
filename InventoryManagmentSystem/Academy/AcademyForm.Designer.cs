namespace InventoryManagmentSystem.Academy
{
    partial class AcademyForm
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
            this.labelAcademies = new System.Windows.Forms.Label();
            this.btnRezsize = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelDocker = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAcademies
            // 
            this.labelAcademies.AutoSize = true;
            this.labelAcademies.BackColor = System.Drawing.Color.Transparent;
            this.labelAcademies.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAcademies.ForeColor = System.Drawing.Color.White;
            this.labelAcademies.Location = new System.Drawing.Point(12, 9);
            this.labelAcademies.Name = "labelAcademies";
            this.labelAcademies.Size = new System.Drawing.Size(170, 36);
            this.labelAcademies.TabIndex = 25;
            this.labelAcademies.Text = "Academies";
            // 
            // btnRezsize
            // 
            this.btnRezsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezsize.Location = new System.Drawing.Point(12, 69);
            this.btnRezsize.Name = "btnRezsize";
            this.btnRezsize.Size = new System.Drawing.Size(62, 38);
            this.btnRezsize.TabIndex = 26;
            this.btnRezsize.Text = "Min";
            this.btnRezsize.UseVisualStyleBackColor = true;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.btnRezsize);
            this.panelLeft.Controls.Add(this.labelAcademies);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 450);
            this.panelLeft.TabIndex = 0;
            // 
            // panelDocker
            // 
            this.panelDocker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDocker.Location = new System.Drawing.Point(200, 0);
            this.panelDocker.Name = "panelDocker";
            this.panelDocker.Size = new System.Drawing.Size(872, 450);
            this.panelDocker.TabIndex = 27;
            // 
            // AcademyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1072, 450);
            this.Controls.Add(this.panelDocker);
            this.Controls.Add(this.panelLeft);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AcademyForm";
            this.Text = "AcademyForm";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelAcademies;
        private System.Windows.Forms.Button btnRezsize;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelDocker;
    }
}