namespace InventoryManagmentSystem
{
    partial class SetSelectionModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetSelectionModuleForm));
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.NewItemTxt = new System.Windows.Forms.Label();
            this.ButtonJacketBoots = new System.Windows.Forms.Button();
            this.ButtonHelmetOnly = new System.Windows.Forms.Button();
            this.ButonBootsOnly = new System.Windows.Forms.Button();
            this.ButtonFullSet = new System.Windows.Forms.Button();
            this.InventoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.BackColor = System.Drawing.Color.Maroon;
            this.InventoryPanel.Controls.Add(this.CloseButton);
            this.InventoryPanel.Controls.Add(this.NewItemTxt);
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(755, 64);
            this.InventoryPanel.TabIndex = 24;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(706, 8);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(36, 42);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 68;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // NewItemTxt
            // 
            this.NewItemTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewItemTxt.AutoSize = true;
            this.NewItemTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewItemTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewItemTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NewItemTxt.Location = new System.Drawing.Point(16, 16);
            this.NewItemTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NewItemTxt.Name = "NewItemTxt";
            this.NewItemTxt.Size = new System.Drawing.Size(261, 29);
            this.NewItemTxt.TabIndex = 16;
            this.NewItemTxt.Text = "Select a rental option";
            this.NewItemTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButtonJacketBoots
            // 
            this.ButtonJacketBoots.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonJacketBoots.Location = new System.Drawing.Point(597, 119);
            this.ButtonJacketBoots.Name = "ButtonJacketBoots";
            this.ButtonJacketBoots.Size = new System.Drawing.Size(146, 79);
            this.ButtonJacketBoots.TabIndex = 31;
            this.ButtonJacketBoots.Text = "Pants and Jacket";
            this.ButtonJacketBoots.UseVisualStyleBackColor = true;
            // 
            // ButtonHelmetOnly
            // 
            this.ButtonHelmetOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonHelmetOnly.Location = new System.Drawing.Point(402, 119);
            this.ButtonHelmetOnly.Name = "ButtonHelmetOnly";
            this.ButtonHelmetOnly.Size = new System.Drawing.Size(146, 79);
            this.ButtonHelmetOnly.TabIndex = 30;
            this.ButtonHelmetOnly.Text = "Set With Helmet Only";
            this.ButtonHelmetOnly.UseVisualStyleBackColor = true;
            // 
            // ButonBootsOnly
            // 
            this.ButonBootsOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButonBootsOnly.Location = new System.Drawing.Point(206, 119);
            this.ButonBootsOnly.Name = "ButonBootsOnly";
            this.ButonBootsOnly.Size = new System.Drawing.Size(146, 79);
            this.ButonBootsOnly.TabIndex = 29;
            this.ButonBootsOnly.Text = "Set With Boots Only";
            this.ButonBootsOnly.UseVisualStyleBackColor = true;
            // 
            // ButtonFullSet
            // 
            this.ButtonFullSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonFullSet.Location = new System.Drawing.Point(12, 119);
            this.ButtonFullSet.Name = "ButtonFullSet";
            this.ButtonFullSet.Size = new System.Drawing.Size(146, 79);
            this.ButtonFullSet.TabIndex = 28;
            this.ButtonFullSet.Text = "Full Set";
            this.ButtonFullSet.UseVisualStyleBackColor = true;
            // 
            // SetSelectionModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(755, 283);
            this.Controls.Add(this.ButtonJacketBoots);
            this.Controls.Add(this.ButtonHelmetOnly);
            this.Controls.Add(this.ButonBootsOnly);
            this.Controls.Add(this.ButtonFullSet);
            this.Controls.Add(this.InventoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetSelectionModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetSelectionModuleForm";
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label NewItemTxt;
        private System.Windows.Forms.Button ButtonJacketBoots;
        private System.Windows.Forms.Button ButtonHelmetOnly;
        private System.Windows.Forms.Button ButonBootsOnly;
        private System.Windows.Forms.Button ButtonFullSet;
    }
}