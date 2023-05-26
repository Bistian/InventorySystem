namespace InventoryManagmentSystem
{
    partial class NewItemModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewItemModuleForm));
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.NewItemTxt = new System.Windows.Forms.Label();
            this.Helmet = new System.Windows.Forms.Button();
            this.Jacket = new System.Windows.Forms.Button();
            this.Pants = new System.Windows.Forms.Button();
            this.Boots = new System.Windows.Forms.Button();
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
            this.InventoryPanel.TabIndex = 23;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(715, 4);
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
            this.NewItemTxt.Size = new System.Drawing.Size(259, 29);
            this.NewItemTxt.TabIndex = 16;
            this.NewItemTxt.Text = "Select an item to add";
            this.NewItemTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Helmet
            // 
            this.Helmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helmet.Location = new System.Drawing.Point(12, 127);
            this.Helmet.Name = "Helmet";
            this.Helmet.Size = new System.Drawing.Size(146, 79);
            this.Helmet.TabIndex = 24;
            this.Helmet.Text = "New Helmet";
            this.Helmet.UseVisualStyleBackColor = true;
            this.Helmet.Click += new System.EventHandler(this.Helmet_Click);
            // 
            // Jacket
            // 
            this.Jacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jacket.Location = new System.Drawing.Point(206, 127);
            this.Jacket.Name = "Jacket";
            this.Jacket.Size = new System.Drawing.Size(146, 79);
            this.Jacket.TabIndex = 25;
            this.Jacket.Text = "New Jacket";
            this.Jacket.UseVisualStyleBackColor = true;
            this.Jacket.Click += new System.EventHandler(this.Jacket_Click);
            // 
            // Pants
            // 
            this.Pants.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pants.Location = new System.Drawing.Point(402, 127);
            this.Pants.Name = "Pants";
            this.Pants.Size = new System.Drawing.Size(146, 79);
            this.Pants.TabIndex = 26;
            this.Pants.Text = "New Pants";
            this.Pants.UseVisualStyleBackColor = true;
            this.Pants.Click += new System.EventHandler(this.Pants_Click);
            // 
            // Boots
            // 
            this.Boots.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boots.Location = new System.Drawing.Point(597, 127);
            this.Boots.Name = "Boots";
            this.Boots.Size = new System.Drawing.Size(146, 79);
            this.Boots.TabIndex = 27;
            this.Boots.Text = "New Boots";
            this.Boots.UseVisualStyleBackColor = true;
            this.Boots.Click += new System.EventHandler(this.Boots_Click);
            // 
            // NewItemModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(755, 283);
            this.Controls.Add(this.Boots);
            this.Controls.Add(this.Pants);
            this.Controls.Add(this.Jacket);
            this.Controls.Add(this.Helmet);
            this.Controls.Add(this.InventoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewItemModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewItemModuleForm";
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label NewItemTxt;
        private System.Windows.Forms.Button Helmet;
        private System.Windows.Forms.Button Jacket;
        private System.Windows.Forms.Button Pants;
        private System.Windows.Forms.Button Boots;
    }
}