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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnCreateClass = new System.Windows.Forms.Button();
            this.btnClassList = new System.Windows.Forms.Button();
            this.btnAcademyList = new System.Windows.Forms.Button();
            this.btnCreateAcademy = new System.Windows.Forms.Button();
            this.panelDocker = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.btnCreateClass);
            this.panelLeft.Controls.Add(this.btnClassList);
            this.panelLeft.Controls.Add(this.btnAcademyList);
            this.panelLeft.Controls.Add(this.btnCreateAcademy);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 450);
            this.panelLeft.TabIndex = 0;
            // 
            // btnCreateClass
            // 
            this.btnCreateClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateClass.ForeColor = System.Drawing.Color.Black;
            this.btnCreateClass.Location = new System.Drawing.Point(3, 210);
            this.btnCreateClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateClass.Name = "btnCreateClass";
            this.btnCreateClass.Size = new System.Drawing.Size(191, 50);
            this.btnCreateClass.TabIndex = 30;
            this.btnCreateClass.Text = "New Class";
            this.btnCreateClass.UseVisualStyleBackColor = true;
            this.btnCreateClass.Click += new System.EventHandler(this.btnCreateClass_Click);
            // 
            // btnClassList
            // 
            this.btnClassList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassList.ForeColor = System.Drawing.Color.Black;
            this.btnClassList.Location = new System.Drawing.Point(3, 102);
            this.btnClassList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClassList.Name = "btnClassList";
            this.btnClassList.Size = new System.Drawing.Size(191, 50);
            this.btnClassList.TabIndex = 29;
            this.btnClassList.Text = "All Classes";
            this.btnClassList.UseVisualStyleBackColor = true;
            this.btnClassList.Click += new System.EventHandler(this.btnClassList_Click);
            // 
            // btnAcademyList
            // 
            this.btnAcademyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcademyList.ForeColor = System.Drawing.Color.Black;
            this.btnAcademyList.Location = new System.Drawing.Point(3, 48);
            this.btnAcademyList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAcademyList.Name = "btnAcademyList";
            this.btnAcademyList.Size = new System.Drawing.Size(191, 50);
            this.btnAcademyList.TabIndex = 28;
            this.btnAcademyList.Text = "Academy List";
            this.btnAcademyList.UseVisualStyleBackColor = true;
            this.btnAcademyList.Click += new System.EventHandler(this.btnAcademyList_Click);
            // 
            // btnCreateAcademy
            // 
            this.btnCreateAcademy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAcademy.ForeColor = System.Drawing.Color.Black;
            this.btnCreateAcademy.Location = new System.Drawing.Point(3, 156);
            this.btnCreateAcademy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateAcademy.Name = "btnCreateAcademy";
            this.btnCreateAcademy.Size = new System.Drawing.Size(191, 50);
            this.btnCreateAcademy.TabIndex = 27;
            this.btnCreateAcademy.Text = "New Academy";
            this.btnCreateAcademy.UseVisualStyleBackColor = true;
            this.btnCreateAcademy.Click += new System.EventHandler(this.btnCreateAcademy_Click);
            // 
            // panelDocker
            // 
            this.panelDocker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDocker.Location = new System.Drawing.Point(200, 0);
            this.panelDocker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AcademyForm";
            this.Text = "AcademyForm";
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLeft;
        public System.Windows.Forms.Panel panelDocker;
        public System.Windows.Forms.Button btnCreateAcademy;
        public System.Windows.Forms.Button btnAcademyList;
        public System.Windows.Forms.Button btnClassList;
        public System.Windows.Forms.Button btnCreateClass;
    }
}