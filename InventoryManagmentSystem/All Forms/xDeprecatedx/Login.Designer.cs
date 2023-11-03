namespace InventoryManagmentSystem
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.Title = new System.Windows.Forms.Label();
            this.MyLogo = new System.Windows.Forms.PictureBox();
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.UserNameLable = new System.Windows.Forms.Label();
            this.PasswordLable = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.FireTecLogo = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PleaseLoginLable = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ShowPassword = new System.Windows.Forms.CheckBox();
            this.ClearLable = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FireTecLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.MyLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 90);
            this.panel1.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(384, -1);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(36, 42);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 13;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Title.Location = new System.Drawing.Point(143, 9);
            this.Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(201, 53);
            this.Title.TabIndex = 7;
            this.Title.Text = " Inventory Managment";
            // 
            // MyLogo
            // 
            this.MyLogo.Image = ((System.Drawing.Image)(resources.GetObject("MyLogo.Image")));
            this.MyLogo.Location = new System.Drawing.Point(4, 4);
            this.MyLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MyLogo.Name = "MyLogo";
            this.MyLogo.Size = new System.Drawing.Size(85, 82);
            this.MyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MyLogo.TabIndex = 6;
            this.MyLogo.TabStop = false;
            this.MyLogo.Click += new System.EventHandler(this.MyLogo_Click);
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Location = new System.Drawing.Point(31, 340);
            this.UserNameTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(367, 22);
            this.UserNameTxt.TabIndex = 0;
            // 
            // UserNameLable
            // 
            this.UserNameLable.AutoSize = true;
            this.UserNameLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLable.Location = new System.Drawing.Point(25, 311);
            this.UserNameLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNameLable.Name = "UserNameLable";
            this.UserNameLable.Size = new System.Drawing.Size(113, 24);
            this.UserNameLable.TabIndex = 1;
            this.UserNameLable.Text = "User Name:";
            // 
            // PasswordLable
            // 
            this.PasswordLable.AutoSize = true;
            this.PasswordLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLable.Location = new System.Drawing.Point(25, 396);
            this.PasswordLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLable.Name = "PasswordLable";
            this.PasswordLable.Size = new System.Drawing.Size(99, 24);
            this.PasswordLable.TabIndex = 3;
            this.PasswordLable.Text = "Password:";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(31, 425);
            this.PasswordTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(367, 22);
            this.PasswordTxt.TabIndex = 2;
            this.PasswordTxt.UseSystemPasswordChar = true;
            this.PasswordTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Maroon;
            this.LoginButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoginButton.Location = new System.Drawing.Point(31, 502);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(368, 53);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // FireTecLogo
            // 
            this.FireTecLogo.Image = ((System.Drawing.Image)(resources.GetObject("FireTecLogo.Image")));
            this.FireTecLogo.Location = new System.Drawing.Point(124, 97);
            this.FireTecLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FireTecLogo.Name = "FireTecLogo";
            this.FireTecLogo.Size = new System.Drawing.Size(185, 151);
            this.FireTecLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FireTecLogo.TabIndex = 5;
            this.FireTecLogo.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // PleaseLoginLable
            // 
            this.PleaseLoginLable.AutoSize = true;
            this.PleaseLoginLable.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PleaseLoginLable.ForeColor = System.Drawing.Color.Maroon;
            this.PleaseLoginLable.Location = new System.Drawing.Point(143, 261);
            this.PleaseLoginLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PleaseLoginLable.Name = "PleaseLoginLable";
            this.PleaseLoginLable.Size = new System.Drawing.Size(130, 26);
            this.PleaseLoginLable.TabIndex = 6;
            this.PleaseLoginLable.Text = "Please Login";
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ShowPassword
            // 
            this.ShowPassword.AutoSize = true;
            this.ShowPassword.Location = new System.Drawing.Point(263, 457);
            this.ShowPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(125, 20);
            this.ShowPassword.TabIndex = 7;
            this.ShowPassword.Text = "Show Password";
            this.ShowPassword.UseVisualStyleBackColor = true;
            this.ShowPassword.CheckedChanged += new System.EventHandler(this.ShowPassword_CheckedChanged);
            // 
            // ClearLable
            // 
            this.ClearLable.AutoSize = true;
            this.ClearLable.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearLable.ForeColor = System.Drawing.Color.Red;
            this.ClearLable.Location = new System.Drawing.Point(25, 628);
            this.ClearLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ClearLable.Name = "ClearLable";
            this.ClearLable.Size = new System.Drawing.Size(57, 24);
            this.ClearLable.TabIndex = 8;
            this.ClearLable.Text = "Clear";
            this.ClearLable.Click += new System.EventHandler(this.ClearLable_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 689);
            this.Controls.Add(this.ClearLable);
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.PleaseLoginLable);
            this.Controls.Add(this.FireTecLogo);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordLable);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.UserNameLable);
            this.Controls.Add(this.UserNameTxt);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FireTecLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox MyLogo;
        private System.Windows.Forms.TextBox UserNameTxt;
        private System.Windows.Forms.Label UserNameLable;
        private System.Windows.Forms.Label PasswordLable;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.PictureBox FireTecLogo;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label PleaseLoginLable;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.CheckBox ShowPassword;
        private System.Windows.Forms.Label ClearLable;
        private CustomButton CloseButton;
    }
}

