namespace InventoryManagmentSystem.Academy
{
    partial class AcademyManagerForm
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
            this.btnCreateAcademy = new System.Windows.Forms.Button();
            this.btnCreateClass = new System.Windows.Forms.Button();
            this.panelDocker = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitle.Location = new System.Drawing.Point(13, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(178, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Academy Manager";
            // 
            // btnCreateAcademy
            // 
            this.btnCreateAcademy.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCreateAcademy.Location = new System.Drawing.Point(13, 42);
            this.btnCreateAcademy.Name = "btnCreateAcademy";
            this.btnCreateAcademy.Size = new System.Drawing.Size(178, 23);
            this.btnCreateAcademy.TabIndex = 1;
            this.btnCreateAcademy.Text = "Create Academy";
            this.btnCreateAcademy.UseVisualStyleBackColor = true;
            this.btnCreateAcademy.Click += new System.EventHandler(this.btnCreateAcademy_Click);
            // 
            // btnCreateClass
            // 
            this.btnCreateClass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCreateClass.Location = new System.Drawing.Point(13, 71);
            this.btnCreateClass.Name = "btnCreateClass";
            this.btnCreateClass.Size = new System.Drawing.Size(178, 23);
            this.btnCreateClass.TabIndex = 2;
            this.btnCreateClass.Text = "Create Class";
            this.btnCreateClass.UseVisualStyleBackColor = true;
            // 
            // panelDocker
            // 
            this.panelDocker.Location = new System.Drawing.Point(197, 13);
            this.panelDocker.Name = "panelDocker";
            this.panelDocker.Size = new System.Drawing.Size(724, 494);
            this.panelDocker.TabIndex = 3;
            // 
            // AcademyManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.panelDocker);
            this.Controls.Add(this.btnCreateClass);
            this.Controls.Add(this.btnCreateAcademy);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AcademyManagerForm";
            this.Text = "AcademyManagerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnCreateAcademy;
        private System.Windows.Forms.Button btnCreateClass;
        private System.Windows.Forms.Panel panelDocker;
    }
}