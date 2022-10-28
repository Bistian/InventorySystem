namespace InventoryManagmentSystem
{
    partial class DeptModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeptModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseUserModuel = new InventoryManagmentSystem.CustomButton();
            this.DepartmentsTxt = new System.Windows.Forms.Label();
            this.DeptNameTxtBox = new System.Windows.Forms.TextBox();
            this.DeptNameLable = new System.Windows.Forms.Label();
            this.DeptAddressTxtBox = new System.Windows.Forms.TextBox();
            this.DeptAddressLable = new System.Windows.Forms.Label();
            this.DeptCityTxtBox = new System.Windows.Forms.TextBox();
            this.DeptCityLable = new System.Windows.Forms.Label();
            this.DeptStateTxtBox = new System.Windows.Forms.TextBox();
            this.DeptStateLable = new System.Windows.Forms.Label();
            this.DeptZipTxtBox = new System.Windows.Forms.TextBox();
            this.DeptZipLable = new System.Windows.Forms.Label();
            this.DeptContactTxtBox = new System.Windows.Forms.TextBox();
            this.DeptContactLable = new System.Windows.Forms.Label();
            this.DepPhoneTxtBox = new System.Windows.Forms.TextBox();
            this.DeptPhoneLable = new System.Windows.Forms.Label();
            this.DeptEmailTxtBox = new System.Windows.Forms.TextBox();
            this.DeptEmailLable = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DeptIDLable = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseUserModuel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.CloseUserModuel);
            this.panel1.Controls.Add(this.DepartmentsTxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 52);
            this.panel1.TabIndex = 21;
            // 
            // CloseUserModuel
            // 
            this.CloseUserModuel.Image = ((System.Drawing.Image)(resources.GetObject("CloseUserModuel.Image")));
            this.CloseUserModuel.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseUserModuel.ImageHover")));
            this.CloseUserModuel.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseUserModuel.ImageNormal")));
            this.CloseUserModuel.Location = new System.Drawing.Point(529, 12);
            this.CloseUserModuel.Name = "CloseUserModuel";
            this.CloseUserModuel.Size = new System.Drawing.Size(25, 23);
            this.CloseUserModuel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseUserModuel.TabIndex = 21;
            this.CloseUserModuel.TabStop = false;
            this.CloseUserModuel.Click += new System.EventHandler(this.CloseUserModuel_Click);
            // 
            // DepartmentsTxt
            // 
            this.DepartmentsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DepartmentsTxt.AutoSize = true;
            this.DepartmentsTxt.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentsTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepartmentsTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DepartmentsTxt.Location = new System.Drawing.Point(12, 13);
            this.DepartmentsTxt.Name = "DepartmentsTxt";
            this.DepartmentsTxt.Size = new System.Drawing.Size(200, 24);
            this.DepartmentsTxt.TabIndex = 15;
            this.DepartmentsTxt.Text = "Departments Moduel ";
            this.DepartmentsTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DeptNameTxtBox
            // 
            this.DeptNameTxtBox.Location = new System.Drawing.Point(16, 92);
            this.DeptNameTxtBox.Name = "DeptNameTxtBox";
            this.DeptNameTxtBox.Size = new System.Drawing.Size(287, 20);
            this.DeptNameTxtBox.TabIndex = 28;
            // 
            // DeptNameLable
            // 
            this.DeptNameLable.AutoSize = true;
            this.DeptNameLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptNameLable.Location = new System.Drawing.Point(12, 69);
            this.DeptNameLable.Name = "DeptNameLable";
            this.DeptNameLable.Size = new System.Drawing.Size(139, 20);
            this.DeptNameLable.TabIndex = 22;
            this.DeptNameLable.Text = "Department Name";
            // 
            // DeptAddressTxtBox
            // 
            this.DeptAddressTxtBox.Location = new System.Drawing.Point(16, 135);
            this.DeptAddressTxtBox.Name = "DeptAddressTxtBox";
            this.DeptAddressTxtBox.Size = new System.Drawing.Size(287, 20);
            this.DeptAddressTxtBox.TabIndex = 34;
            // 
            // DeptAddressLable
            // 
            this.DeptAddressLable.AutoSize = true;
            this.DeptAddressLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptAddressLable.Location = new System.Drawing.Point(12, 112);
            this.DeptAddressLable.Name = "DeptAddressLable";
            this.DeptAddressLable.Size = new System.Drawing.Size(64, 20);
            this.DeptAddressLable.TabIndex = 33;
            this.DeptAddressLable.Text = "Address";
            // 
            // DeptCityTxtBox
            // 
            this.DeptCityTxtBox.Location = new System.Drawing.Point(16, 178);
            this.DeptCityTxtBox.Name = "DeptCityTxtBox";
            this.DeptCityTxtBox.Size = new System.Drawing.Size(113, 20);
            this.DeptCityTxtBox.TabIndex = 38;
            // 
            // DeptCityLable
            // 
            this.DeptCityLable.AutoSize = true;
            this.DeptCityLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptCityLable.Location = new System.Drawing.Point(12, 155);
            this.DeptCityLable.Name = "DeptCityLable";
            this.DeptCityLable.Size = new System.Drawing.Size(36, 20);
            this.DeptCityLable.TabIndex = 37;
            this.DeptCityLable.Text = "City";
            // 
            // DeptStateTxtBox
            // 
            this.DeptStateTxtBox.Location = new System.Drawing.Point(135, 178);
            this.DeptStateTxtBox.Name = "DeptStateTxtBox";
            this.DeptStateTxtBox.Size = new System.Drawing.Size(58, 20);
            this.DeptStateTxtBox.TabIndex = 40;
            // 
            // DeptStateLable
            // 
            this.DeptStateLable.AutoSize = true;
            this.DeptStateLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptStateLable.Location = new System.Drawing.Point(131, 155);
            this.DeptStateLable.Name = "DeptStateLable";
            this.DeptStateLable.Size = new System.Drawing.Size(46, 20);
            this.DeptStateLable.TabIndex = 39;
            this.DeptStateLable.Text = "State";
            // 
            // DeptZipTxtBox
            // 
            this.DeptZipTxtBox.Location = new System.Drawing.Point(199, 178);
            this.DeptZipTxtBox.Name = "DeptZipTxtBox";
            this.DeptZipTxtBox.Size = new System.Drawing.Size(104, 20);
            this.DeptZipTxtBox.TabIndex = 42;
            // 
            // DeptZipLable
            // 
            this.DeptZipLable.AutoSize = true;
            this.DeptZipLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptZipLable.Location = new System.Drawing.Point(195, 155);
            this.DeptZipLable.Name = "DeptZipLable";
            this.DeptZipLable.Size = new System.Drawing.Size(30, 20);
            this.DeptZipLable.TabIndex = 41;
            this.DeptZipLable.Text = "Zip";
            // 
            // DeptContactTxtBox
            // 
            this.DeptContactTxtBox.Location = new System.Drawing.Point(329, 92);
            this.DeptContactTxtBox.Name = "DeptContactTxtBox";
            this.DeptContactTxtBox.Size = new System.Drawing.Size(216, 20);
            this.DeptContactTxtBox.TabIndex = 44;
            // 
            // DeptContactLable
            // 
            this.DeptContactLable.AutoSize = true;
            this.DeptContactLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptContactLable.Location = new System.Drawing.Point(329, 69);
            this.DeptContactLable.Name = "DeptContactLable";
            this.DeptContactLable.Size = new System.Drawing.Size(108, 20);
            this.DeptContactLable.TabIndex = 43;
            this.DeptContactLable.Text = "Contact Name";
            // 
            // DepPhoneTxtBox
            // 
            this.DepPhoneTxtBox.Location = new System.Drawing.Point(329, 135);
            this.DepPhoneTxtBox.Name = "DepPhoneTxtBox";
            this.DepPhoneTxtBox.Size = new System.Drawing.Size(216, 20);
            this.DepPhoneTxtBox.TabIndex = 48;
            // 
            // DeptPhoneLable
            // 
            this.DeptPhoneLable.AutoSize = true;
            this.DeptPhoneLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptPhoneLable.Location = new System.Drawing.Point(329, 112);
            this.DeptPhoneLable.Name = "DeptPhoneLable";
            this.DeptPhoneLable.Size = new System.Drawing.Size(67, 20);
            this.DeptPhoneLable.TabIndex = 47;
            this.DeptPhoneLable.Text = "Phone #";
            // 
            // DeptEmailTxtBox
            // 
            this.DeptEmailTxtBox.Location = new System.Drawing.Point(329, 181);
            this.DeptEmailTxtBox.Name = "DeptEmailTxtBox";
            this.DeptEmailTxtBox.Size = new System.Drawing.Size(216, 20);
            this.DeptEmailTxtBox.TabIndex = 50;
            // 
            // DeptEmailLable
            // 
            this.DeptEmailLable.AutoSize = true;
            this.DeptEmailLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptEmailLable.Location = new System.Drawing.Point(329, 158);
            this.DeptEmailLable.Name = "DeptEmailLable";
            this.DeptEmailLable.Size = new System.Drawing.Size(47, 20);
            this.DeptEmailLable.TabIndex = 49;
            this.DeptEmailLable.Text = "Email";
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Maroon;
            this.ClearButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(322, 226);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(87, 43);
            this.ClearButton.TabIndex = 53;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.UpdateButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UpdateButton.Location = new System.Drawing.Point(229, 226);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(87, 43);
            this.UpdateButton.TabIndex = 52;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.SaveButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.Location = new System.Drawing.Point(136, 226);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 43);
            this.SaveButton.TabIndex = 51;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DeptIDLable
            // 
            this.DeptIDLable.AutoSize = true;
            this.DeptIDLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptIDLable.Location = new System.Drawing.Point(12, 236);
            this.DeptIDLable.Name = "DeptIDLable";
            this.DeptIDLable.Size = new System.Drawing.Size(62, 20);
            this.DeptIDLable.TabIndex = 54;
            this.DeptIDLable.Text = "Dept ID";
            // 
            // DeptModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(566, 281);
            this.Controls.Add(this.DeptIDLable);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeptEmailTxtBox);
            this.Controls.Add(this.DeptEmailLable);
            this.Controls.Add(this.DepPhoneTxtBox);
            this.Controls.Add(this.DeptPhoneLable);
            this.Controls.Add(this.DeptContactTxtBox);
            this.Controls.Add(this.DeptContactLable);
            this.Controls.Add(this.DeptZipTxtBox);
            this.Controls.Add(this.DeptZipLable);
            this.Controls.Add(this.DeptStateTxtBox);
            this.Controls.Add(this.DeptStateLable);
            this.Controls.Add(this.DeptCityTxtBox);
            this.Controls.Add(this.DeptCityLable);
            this.Controls.Add(this.DeptAddressTxtBox);
            this.Controls.Add(this.DeptAddressLable);
            this.Controls.Add(this.DeptNameTxtBox);
            this.Controls.Add(this.DeptNameLable);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeptModuleForm";
            this.Text = "DeptModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseUserModuel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private CustomButton CloseUserModuel;
        private System.Windows.Forms.Label DepartmentsTxt;
        public System.Windows.Forms.TextBox DeptNameTxtBox;
        private System.Windows.Forms.Label DeptNameLable;
        public System.Windows.Forms.TextBox DeptAddressTxtBox;
        private System.Windows.Forms.Label DeptAddressLable;
        public System.Windows.Forms.TextBox DeptCityTxtBox;
        private System.Windows.Forms.Label DeptCityLable;
        public System.Windows.Forms.TextBox DeptStateTxtBox;
        private System.Windows.Forms.Label DeptStateLable;
        public System.Windows.Forms.TextBox DeptZipTxtBox;
        private System.Windows.Forms.Label DeptZipLable;
        public System.Windows.Forms.TextBox DeptContactTxtBox;
        private System.Windows.Forms.Label DeptContactLable;
        public System.Windows.Forms.TextBox DepPhoneTxtBox;
        private System.Windows.Forms.Label DeptPhoneLable;
        public System.Windows.Forms.TextBox DeptEmailTxtBox;
        private System.Windows.Forms.Label DeptEmailLable;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.Button UpdateButton;
        public System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label DeptIDLable;
    }
}