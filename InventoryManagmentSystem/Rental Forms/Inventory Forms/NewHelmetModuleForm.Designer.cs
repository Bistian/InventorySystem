namespace InventoryManagmentSystem
{
    partial class NewHelmetModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewHelmetModuleForm));
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.NewHelmetTxt = new System.Windows.Forms.Label();
            this.InventoryTxt = new System.Windows.Forms.Label();
            this.txtBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.LableSerialNumber = new System.Windows.Forms.Label();
            this.LableBrand = new System.Windows.Forms.Label();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.labelUsedNew = new System.Windows.Forms.Label();
            this.comboBoxUsedNew = new System.Windows.Forms.ComboBox();
            this.labelManufactureDate = new System.Windows.Forms.Label();
            this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.InventoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.BackColor = System.Drawing.Color.Maroon;
            this.InventoryPanel.Controls.Add(this.CloseButton);
            this.InventoryPanel.Controls.Add(this.NewHelmetTxt);
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(755, 64);
            this.InventoryPanel.TabIndex = 21;
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
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click_1);
            // 
            // NewHelmetTxt
            // 
            this.NewHelmetTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewHelmetTxt.AutoSize = true;
            this.NewHelmetTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewHelmetTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewHelmetTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NewHelmetTxt.Location = new System.Drawing.Point(16, 16);
            this.NewHelmetTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NewHelmetTxt.Name = "NewHelmetTxt";
            this.NewHelmetTxt.Size = new System.Drawing.Size(156, 29);
            this.NewHelmetTxt.TabIndex = 16;
            this.NewHelmetTxt.Text = "New Helmet";
            this.NewHelmetTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InventoryTxt
            // 
            this.InventoryTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryTxt.AutoSize = true;
            this.InventoryTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.InventoryTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InventoryTxt.Location = new System.Drawing.Point(16, 16);
            this.InventoryTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InventoryTxt.Name = "InventoryTxt";
            this.InventoryTxt.Size = new System.Drawing.Size(156, 29);
            this.InventoryTxt.TabIndex = 15;
            this.InventoryTxt.Text = "New Helmet";
            this.InventoryTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBoxSerialNumber
            // 
            this.txtBoxSerialNumber.Location = new System.Drawing.Point(18, 113);
            this.txtBoxSerialNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxSerialNumber.Name = "txtBoxSerialNumber";
            this.txtBoxSerialNumber.Size = new System.Drawing.Size(241, 22);
            this.txtBoxSerialNumber.TabIndex = 30;
            // 
            // LableSerialNumber
            // 
            this.LableSerialNumber.AutoSize = true;
            this.LableSerialNumber.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableSerialNumber.Location = new System.Drawing.Point(13, 85);
            this.LableSerialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LableSerialNumber.Name = "LableSerialNumber";
            this.LableSerialNumber.Size = new System.Drawing.Size(137, 24);
            this.LableSerialNumber.TabIndex = 29;
            this.LableSerialNumber.Text = "Serial Number";
            // 
            // LableBrand
            // 
            this.LableBrand.AutoSize = true;
            this.LableBrand.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableBrand.Location = new System.Drawing.Point(14, 143);
            this.LableBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LableBrand.Name = "LableBrand";
            this.LableBrand.Size = new System.Drawing.Size(60, 24);
            this.LableBrand.TabIndex = 59;
            this.LableBrand.Text = "Brand";
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Items.AddRange(new object[] {
            "Cairns",
            "Bullard"});
            this.comboBoxBrand.Location = new System.Drawing.Point(18, 170);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(121, 24);
            this.comboBoxBrand.TabIndex = 58;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColor.Location = new System.Drawing.Point(152, 143);
            this.labelColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(58, 24);
            this.labelColor.TabIndex = 63;
            this.labelColor.Text = "Color";
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Items.AddRange(new object[] {
            "Black",
            "Yellow"});
            this.comboBoxColor.Location = new System.Drawing.Point(156, 170);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(103, 24);
            this.comboBoxColor.TabIndex = 62;
            // 
            // labelUsedNew
            // 
            this.labelUsedNew.AutoSize = true;
            this.labelUsedNew.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsedNew.Location = new System.Drawing.Point(272, 143);
            this.labelUsedNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsedNew.Name = "labelUsedNew";
            this.labelUsedNew.Size = new System.Drawing.Size(124, 24);
            this.labelUsedNew.TabIndex = 69;
            this.labelUsedNew.Text = "Used or New";
            // 
            // comboBoxUsedNew
            // 
            this.comboBoxUsedNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxUsedNew.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxUsedNew.FormattingEnabled = true;
            this.comboBoxUsedNew.Items.AddRange(new object[] {
            "Used",
            "New"});
            this.comboBoxUsedNew.Location = new System.Drawing.Point(276, 170);
            this.comboBoxUsedNew.Name = "comboBoxUsedNew";
            this.comboBoxUsedNew.Size = new System.Drawing.Size(120, 24);
            this.comboBoxUsedNew.TabIndex = 68;
            // 
            // labelManufactureDate
            // 
            this.labelManufactureDate.AutoSize = true;
            this.labelManufactureDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManufactureDate.Location = new System.Drawing.Point(499, 118);
            this.labelManufactureDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelManufactureDate.Name = "labelManufactureDate";
            this.labelManufactureDate.Size = new System.Drawing.Size(168, 24);
            this.labelManufactureDate.TabIndex = 71;
            this.labelManufactureDate.Text = "Manufacture Date";
            // 
            // dateTimePickerManufactureDate
            // 
            this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(460, 145);
            this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
            this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(246, 22);
            this.dateTimePickerManufactureDate.TabIndex = 70;
            this.dateTimePickerManufactureDate.Value = new System.DateTime(2023, 3, 23, 16, 23, 38, 0);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(387, 217);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 53);
            this.button1.TabIndex = 72;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Maroon;
            this.ClearButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(263, 217);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(116, 53);
            this.ClearButton.TabIndex = 73;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click_1);
            // 
            // NewHelmetModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(755, 283);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelManufactureDate);
            this.Controls.Add(this.dateTimePickerManufactureDate);
            this.Controls.Add(this.labelUsedNew);
            this.Controls.Add(this.comboBoxUsedNew);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.LableBrand);
            this.Controls.Add(this.comboBoxBrand);
            this.Controls.Add(this.txtBoxSerialNumber);
            this.Controls.Add(this.LableSerialNumber);
            this.Controls.Add(this.InventoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewHelmetModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryModuleForm";
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private System.Windows.Forms.Label InventoryTxt;
        public System.Windows.Forms.TextBox txtBoxSerialNumber;
        private System.Windows.Forms.Label LableSerialNumber;
        private CustomButton CloseUserModuel;
        private System.Windows.Forms.Label LableBrand;
        private System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.Label NewHelmetTxt;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label labelUsedNew;
        private System.Windows.Forms.ComboBox comboBoxUsedNew;
        private System.Windows.Forms.Label labelManufactureDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerManufactureDate;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button ClearButton;
    }
}