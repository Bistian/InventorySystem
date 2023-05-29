namespace InventoryManagmentSystem
{
    partial class DatabaseCreationModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseCreationModule));
            this.panelTop = new System.Windows.Forms.Panel();
            this.ButtonClose = new InventoryManagmentSystem.CustomButton();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.returntxt = new System.Windows.Forms.Label();
            this.btnNewDatabase = new System.Windows.Forms.Button();
            this.btnFindDatabase = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Maroon;
            this.panelTop.Controls.Add(this.ButtonClose);
            this.panelTop.Controls.Add(this.CloseButton);
            this.panelTop.Controls.Add(this.returntxt);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(423, 52);
            this.panelTop.TabIndex = 42;
            // 
            // ButtonClose
            // 
            this.ButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("ButtonClose.Image")));
            this.ButtonClose.ImageHover = ((System.Drawing.Image)(resources.GetObject("ButtonClose.ImageHover")));
            this.ButtonClose.ImageNormal = ((System.Drawing.Image)(resources.GetObject("ButtonClose.ImageNormal")));
            this.ButtonClose.Location = new System.Drawing.Point(381, 14);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(25, 23);
            this.ButtonClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButtonClose.TabIndex = 44;
            this.ButtonClose.TabStop = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(807, 9);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(27, 34);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 68;
            this.CloseButton.TabStop = false;
            // 
            // returntxt
            // 
            this.returntxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returntxt.AutoSize = true;
            this.returntxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returntxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.returntxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.returntxt.Location = new System.Drawing.Point(12, 13);
            this.returntxt.Name = "returntxt";
            this.returntxt.Size = new System.Drawing.Size(355, 24);
            this.returntxt.TabIndex = 16;
            this.returntxt.Text = "You do not have a database selected";
            this.returntxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnNewDatabase
            // 
            this.btnNewDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewDatabase.Location = new System.Drawing.Point(227, 95);
            this.btnNewDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewDatabase.Name = "btnNewDatabase";
            this.btnNewDatabase.Size = new System.Drawing.Size(179, 54);
            this.btnNewDatabase.TabIndex = 43;
            this.btnNewDatabase.Text = "New Database";
            this.btnNewDatabase.UseVisualStyleBackColor = true;
            this.btnNewDatabase.Click += new System.EventHandler(this.btnNewDatabase_Click);
            // 
            // btnFindDatabase
            // 
            this.btnFindDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindDatabase.Location = new System.Drawing.Point(16, 95);
            this.btnFindDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.btnFindDatabase.Name = "btnFindDatabase";
            this.btnFindDatabase.Size = new System.Drawing.Size(179, 54);
            this.btnFindDatabase.TabIndex = 44;
            this.btnFindDatabase.Text = "Find Database";
            this.btnFindDatabase.UseVisualStyleBackColor = true;
            this.btnFindDatabase.Click += new System.EventHandler(this.btnFindDatabase_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(16, 77);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 45;
            this.labelName.Text = "label1";
            this.labelName.Visible = false;
            // 
            // DatabaseCreationModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(423, 202);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnFindDatabase);
            this.Controls.Add(this.btnNewDatabase);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DatabaseCreationModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DatabaseCreationModule";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label returntxt;
        private System.Windows.Forms.Button btnNewDatabase;
        private CustomButton ButtonClose;
        private System.Windows.Forms.Button btnFindDatabase;
        private System.Windows.Forms.Label labelName;
    }
}