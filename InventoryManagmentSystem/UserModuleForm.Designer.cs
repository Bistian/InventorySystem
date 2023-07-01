namespace InventoryManagmentSystem
{
    partial class UserModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseUserModuel = new InventoryManagmentSystem.CustomButton();
            this.DepartmentsTxt = new System.Windows.Forms.Label();
            this.PasswordLable = new System.Windows.Forms.Label();
            this.UserNameLable = new System.Windows.Forms.Label();
            this.e = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.PasswordConfTxt = new System.Windows.Forms.TextBox();
            this.NameTxtBox = new System.Windows.Forms.TextBox();
            this.NameLable = new System.Windows.Forms.Label();
            this.ShowPassword = new System.Windows.Forms.CheckBox();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 64);
            this.panel1.TabIndex = 0;
            // 
            // CloseUserModuel
            // 
            this.CloseUserModuel.Image = ((System.Drawing.Image)(resources.GetObject("CloseUserModuel.Image")));
            this.CloseUserModuel.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseUserModuel.ImageHover")));
            this.CloseUserModuel.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseUserModuel.ImageNormal")));
            this.CloseUserModuel.Location = new System.Drawing.Point(705, 15);
            this.CloseUserModuel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CloseUserModuel.Name = "CloseUserModuel";
            this.CloseUserModuel.Size = new System.Drawing.Size(33, 28);
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
            this.DepartmentsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentsTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepartmentsTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DepartmentsTxt.Location = new System.Drawing.Point(16, 16);
            this.DepartmentsTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DepartmentsTxt.Name = "DepartmentsTxt";
            this.DepartmentsTxt.Size = new System.Drawing.Size(169, 29);
            this.DepartmentsTxt.TabIndex = 15;
            this.DepartmentsTxt.Text = "User Moduel ";
            this.DepartmentsTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PasswordLable
            // 
            this.PasswordLable.AutoSize = true;
            this.PasswordLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLable.Location = new System.Drawing.Point(112, 153);
            this.PasswordLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLable.Name = "PasswordLable";
            this.PasswordLable.Size = new System.Drawing.Size(92, 24);
            this.PasswordLable.TabIndex = 7;
            this.PasswordLable.Text = "Password";
            // 
            // UserNameLable
            // 
            this.UserNameLable.AutoSize = true;
            this.UserNameLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLable.Location = new System.Drawing.Point(112, 97);
            this.UserNameLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNameLable.Name = "UserNameLable";
            this.UserNameLable.Size = new System.Drawing.Size(106, 24);
            this.UserNameLable.TabIndex = 5;
            this.UserNameLable.Text = "User Name";
            // 
            // e
            // 
            this.e.AutoSize = true;
            this.e.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e.Location = new System.Drawing.Point(112, 208);
            this.e.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(168, 24);
            this.e.TabIndex = 9;
            this.e.Text = "Re-type Password";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.SaveButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.Location = new System.Drawing.Point(231, 364);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(116, 53);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Maroon;
            this.ClearButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(413, 364);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(116, 53);
            this.ClearButton.TabIndex = 12;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Location = new System.Drawing.Point(117, 126);
            this.UserNameTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(504, 22);
            this.UserNameTxt.TabIndex = 15;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(117, 181);
            this.PasswordTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(504, 22);
            this.PasswordTxt.TabIndex = 16;
            // 
            // PasswordConfTxt
            // 
            this.PasswordConfTxt.Location = new System.Drawing.Point(117, 236);
            this.PasswordConfTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordConfTxt.Name = "PasswordConfTxt";
            this.PasswordConfTxt.Size = new System.Drawing.Size(504, 22);
            this.PasswordConfTxt.TabIndex = 17;
            // 
            // NameTxtBox
            // 
            this.NameTxtBox.Location = new System.Drawing.Point(117, 292);
            this.NameTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NameTxtBox.Name = "NameTxtBox";
            this.NameTxtBox.Size = new System.Drawing.Size(504, 22);
            this.NameTxtBox.TabIndex = 19;
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLable.Location = new System.Drawing.Point(112, 263);
            this.NameLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(60, 24);
            this.NameLable.TabIndex = 18;
            this.NameLable.Text = "Name";
            // 
            // ShowPassword
            // 
            this.ShowPassword.AutoSize = true;
            this.ShowPassword.Location = new System.Drawing.Point(487, 324);
            this.ShowPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(125, 20);
            this.ShowPassword.TabIndex = 20;
            this.ShowPassword.Text = "Show Password";
            this.ShowPassword.UseVisualStyleBackColor = true;
            this.ShowPassword.CheckedChanged += new System.EventHandler(this.ShowPassword_CheckedChanged);
            // 
            // UserModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(755, 432);
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.NameTxtBox);
            this.Controls.Add(this.NameLable);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.PasswordConfTxt);
            this.Controls.Add(this.UserNameTxt);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.e);
            this.Controls.Add(this.PasswordLable);
            this.Controls.Add(this.UserNameLable);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseUserModuel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DepartmentsTxt;
        private System.Windows.Forms.Label PasswordLable;
        private System.Windows.Forms.Label UserNameLable;
        private System.Windows.Forms.Label e;
        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.TextBox UserNameTxt;
        public System.Windows.Forms.TextBox PasswordTxt;
        public System.Windows.Forms.TextBox PasswordConfTxt;
        public System.Windows.Forms.TextBox NameTxtBox;
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.CheckBox ShowPassword;
        private CustomButton CloseUserModuel;
    }
}