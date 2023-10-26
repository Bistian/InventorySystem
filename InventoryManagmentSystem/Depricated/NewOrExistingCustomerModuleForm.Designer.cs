namespace InventoryManagmentSystem
{
    partial class NewOrExistingCustomerModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOrExistingCustomerModuleForm));
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.customButton1 = new InventoryManagmentSystem.CustomButton();
            this.NewCustomerTxt = new System.Windows.Forms.Label();
            this.ButtonExistingCustomer = new System.Windows.Forms.Button();
            this.ButtonNewCustomer = new System.Windows.Forms.Button();
            this.InventoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.BackColor = System.Drawing.Color.Maroon;
            this.InventoryPanel.Controls.Add(this.customButton1);
            this.InventoryPanel.Controls.Add(this.NewCustomerTxt);
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(474, 64);
            this.InventoryPanel.TabIndex = 23;
            // 
            // customButton1
            // 
            this.customButton1.Image = ((System.Drawing.Image)(resources.GetObject("customButton1.Image")));
            this.customButton1.ImageHover = ((System.Drawing.Image)(resources.GetObject("customButton1.ImageHover")));
            this.customButton1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("customButton1.ImageNormal")));
            this.customButton1.Location = new System.Drawing.Point(421, 13);
            this.customButton1.Margin = new System.Windows.Forms.Padding(4);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(36, 42);
            this.customButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.customButton1.TabIndex = 69;
            this.customButton1.TabStop = false;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // NewCustomerTxt
            // 
            this.NewCustomerTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewCustomerTxt.AutoSize = true;
            this.NewCustomerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCustomerTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewCustomerTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NewCustomerTxt.Location = new System.Drawing.Point(16, 16);
            this.NewCustomerTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NewCustomerTxt.Name = "NewCustomerTxt";
            this.NewCustomerTxt.Size = new System.Drawing.Size(321, 29);
            this.NewCustomerTxt.TabIndex = 16;
            this.NewCustomerTxt.Text = "New or existing customer?";
            this.NewCustomerTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButtonExistingCustomer
            // 
            this.ButtonExistingCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExistingCustomer.Location = new System.Drawing.Point(261, 122);
            this.ButtonExistingCustomer.Name = "ButtonExistingCustomer";
            this.ButtonExistingCustomer.Size = new System.Drawing.Size(146, 79);
            this.ButtonExistingCustomer.TabIndex = 27;
            this.ButtonExistingCustomer.Text = "Existing Customer";
            this.ButtonExistingCustomer.UseVisualStyleBackColor = true;
            this.ButtonExistingCustomer.Click += new System.EventHandler(this.ButtonExistingCustomer_Click);
            // 
            // ButtonNewCustomer
            // 
            this.ButtonNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNewCustomer.Location = new System.Drawing.Point(67, 122);
            this.ButtonNewCustomer.Name = "ButtonNewCustomer";
            this.ButtonNewCustomer.Size = new System.Drawing.Size(146, 79);
            this.ButtonNewCustomer.TabIndex = 26;
            this.ButtonNewCustomer.Text = "New Customer";
            this.ButtonNewCustomer.UseVisualStyleBackColor = true;
            this.ButtonNewCustomer.Click += new System.EventHandler(this.ButtonNewCustomer_Click);
            // 
            // NewOrExistingCustomerModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(474, 257);
            this.Controls.Add(this.ButtonExistingCustomer);
            this.Controls.Add(this.ButtonNewCustomer);
            this.Controls.Add(this.InventoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewOrExistingCustomerModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewOrExistingCustomerModuleForm";
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private CustomButton customButton1;
        private System.Windows.Forms.Label NewCustomerTxt;
        private System.Windows.Forms.Button ButtonExistingCustomer;
        private System.Windows.Forms.Button ButtonNewCustomer;
    }
}