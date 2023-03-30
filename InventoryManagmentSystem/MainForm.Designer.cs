namespace InventoryManagmentSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.UsersButton = new InventoryManagmentSystem.CustomButton();
            this.UsersTxt = new System.Windows.Forms.Label();
            this.DepartmentsTxt = new System.Windows.Forms.Label();
            this.HomeTex = new System.Windows.Forms.Label();
            this.DepatmensButton = new InventoryManagmentSystem.CustomButton();
            this.InventoryTxt = new System.Windows.Forms.Label();
            this.HomeButton = new InventoryManagmentSystem.CustomButton();
            this.InventoryButton = new InventoryManagmentSystem.CustomButton();
            this.MyLogo = new System.Windows.Forms.PictureBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepatmensButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Maroon;
            this.TopPanel.Controls.Add(this.UsersButton);
            this.TopPanel.Controls.Add(this.UsersTxt);
            this.TopPanel.Controls.Add(this.DepartmentsTxt);
            this.TopPanel.Controls.Add(this.HomeTex);
            this.TopPanel.Controls.Add(this.DepatmensButton);
            this.TopPanel.Controls.Add(this.InventoryTxt);
            this.TopPanel.Controls.Add(this.HomeButton);
            this.TopPanel.Controls.Add(this.InventoryButton);
            this.TopPanel.Controls.Add(this.MyLogo);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(4);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1034, 90);
            this.TopPanel.TabIndex = 0;
            // 
            // UsersButton
            // 
            this.UsersButton.Image = ((System.Drawing.Image)(resources.GetObject("UsersButton.Image")));
            this.UsersButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("UsersButton.ImageHover")));
            this.UsersButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("UsersButton.ImageNormal")));
            this.UsersButton.Location = new System.Drawing.Point(512, 3);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(55, 67);
            this.UsersButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UsersButton.TabIndex = 14;
            this.UsersButton.TabStop = false;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // UsersTxt
            // 
            this.UsersTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersTxt.AutoSize = true;
            this.UsersTxt.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UsersTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UsersTxt.Location = new System.Drawing.Point(509, 65);
            this.UsersTxt.Name = "UsersTxt";
            this.UsersTxt.Size = new System.Drawing.Size(58, 24);
            this.UsersTxt.TabIndex = 15;
            this.UsersTxt.Text = "Users";
            this.UsersTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.DepartmentsTxt.Location = new System.Drawing.Point(356, 64);
            this.DepartmentsTxt.Name = "DepartmentsTxt";
            this.DepartmentsTxt.Size = new System.Drawing.Size(124, 24);
            this.DepartmentsTxt.TabIndex = 13;
            this.DepartmentsTxt.Text = "Departments";
            this.DepartmentsTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HomeTex
            // 
            this.HomeTex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HomeTex.AutoSize = true;
            this.HomeTex.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeTex.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HomeTex.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HomeTex.Location = new System.Drawing.Point(125, 64);
            this.HomeTex.Name = "HomeTex";
            this.HomeTex.Size = new System.Drawing.Size(61, 24);
            this.HomeTex.TabIndex = 11;
            this.HomeTex.Text = "Home";
            this.HomeTex.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DepatmensButton
            // 
            this.DepatmensButton.Image = ((System.Drawing.Image)(resources.GetObject("DepatmensButton.Image")));
            this.DepatmensButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("DepatmensButton.ImageHover")));
            this.DepatmensButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("DepatmensButton.ImageNormal")));
            this.DepatmensButton.Location = new System.Drawing.Point(387, 12);
            this.DepatmensButton.Name = "DepatmensButton";
            this.DepatmensButton.Size = new System.Drawing.Size(55, 50);
            this.DepatmensButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DepatmensButton.TabIndex = 12;
            this.DepatmensButton.TabStop = false;
            this.DepatmensButton.Click += new System.EventHandler(this.DepatmensButton_Click);
            // 
            // InventoryTxt
            // 
            this.InventoryTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryTxt.AutoSize = true;
            this.InventoryTxt.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.InventoryTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InventoryTxt.Location = new System.Drawing.Point(234, 64);
            this.InventoryTxt.Name = "InventoryTxt";
            this.InventoryTxt.Size = new System.Drawing.Size(102, 24);
            this.InventoryTxt.TabIndex = 9;
            this.InventoryTxt.Text = "Inventory ";
            this.InventoryTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HomeButton
            // 
            this.HomeButton.Image = ((System.Drawing.Image)(resources.GetObject("HomeButton.Image")));
            this.HomeButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("HomeButton.ImageHover")));
            this.HomeButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("HomeButton.ImageNormal")));
            this.HomeButton.Location = new System.Drawing.Point(124, 12);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(55, 50);
            this.HomeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HomeButton.TabIndex = 10;
            this.HomeButton.TabStop = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // InventoryButton
            // 
            this.InventoryButton.Image = ((System.Drawing.Image)(resources.GetObject("InventoryButton.Image")));
            this.InventoryButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("InventoryButton.ImageHover")));
            this.InventoryButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("InventoryButton.ImageNormal")));
            this.InventoryButton.Location = new System.Drawing.Point(252, 12);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(55, 50);
            this.InventoryButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InventoryButton.TabIndex = 0;
            this.InventoryButton.TabStop = false;
            // 
            // MyLogo
            // 
            this.MyLogo.Image = ((System.Drawing.Image)(resources.GetObject("MyLogo.Image")));
            this.MyLogo.Location = new System.Drawing.Point(12, 12);
            this.MyLogo.Name = "MyLogo";
            this.MyLogo.Size = new System.Drawing.Size(64, 67);
            this.MyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MyLogo.TabIndex = 9;
            this.MyLogo.TabStop = false;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.Maroon;
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 632);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(4);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1034, 19);
            this.BottomPanel.TabIndex = 1;
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 90);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1034, 542);
            this.MainPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 651);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepatmensButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PictureBox MyLogo;
        private CustomButton InventoryButton;
        private System.Windows.Forms.Label InventoryTxt;
        private System.Windows.Forms.Label HomeTex;
        private CustomButton HomeButton;
        private System.Windows.Forms.Label DepartmentsTxt;
        private CustomButton DepatmensButton;
        private CustomButton UsersButton;
        private System.Windows.Forms.Label UsersTxt;
    }
}