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
            this.SaveButton = new System.Windows.Forms.Button();
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
            this.InventoryPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(566, 52);
            this.InventoryPanel.TabIndex = 21;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(536, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(27, 34);
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
            this.NewHelmetTxt.Location = new System.Drawing.Point(12, 13);
            this.NewHelmetTxt.Name = "NewHelmetTxt";
            this.NewHelmetTxt.Size = new System.Drawing.Size(124, 24);
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
            this.txtBoxSerialNumber.Location = new System.Drawing.Point(14, 92);
            this.txtBoxSerialNumber.Name = "txtBoxSerialNumber";
            this.txtBoxSerialNumber.Size = new System.Drawing.Size(182, 20);
            this.txtBoxSerialNumber.TabIndex = 30;
            // 
            // LableSerialNumber
            // 
            this.LableSerialNumber.AutoSize = true;
            this.LableSerialNumber.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableSerialNumber.Location = new System.Drawing.Point(10, 69);
            this.LableSerialNumber.Name = "LableSerialNumber";
            this.LableSerialNumber.Size = new System.Drawing.Size(109, 20);
            this.LableSerialNumber.TabIndex = 29;
            this.LableSerialNumber.Text = "Serial Number";
            // 
            // LableBrand
            // 
            this.LableBrand.AutoSize = true;
            this.LableBrand.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableBrand.Location = new System.Drawing.Point(10, 116);
            this.LableBrand.Name = "LableBrand";
            this.LableBrand.Size = new System.Drawing.Size(50, 20);
            this.LableBrand.TabIndex = 59;
            this.LableBrand.Text = "Brand";
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Location = new System.Drawing.Point(14, 138);
            this.comboBoxBrand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(92, 21);
            this.comboBoxBrand.TabIndex = 58;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColor.Location = new System.Drawing.Point(114, 116);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(44, 20);
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
            this.comboBoxColor.Location = new System.Drawing.Point(117, 138);
            this.comboBoxColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(78, 21);
            this.comboBoxColor.TabIndex = 62;
            // 
            // labelUsedNew
            // 
            this.labelUsedNew.AutoSize = true;
            this.labelUsedNew.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsedNew.Location = new System.Drawing.Point(204, 116);
            this.labelUsedNew.Name = "labelUsedNew";
            this.labelUsedNew.Size = new System.Drawing.Size(75, 20);
            this.labelUsedNew.TabIndex = 69;
            this.labelUsedNew.Text = "Condition";
            // 
            // comboBoxUsedNew
            // 
            this.comboBoxUsedNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxUsedNew.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxUsedNew.FormattingEnabled = true;
            this.comboBoxUsedNew.Items.AddRange(new object[] {
            "Used",
            "New"});
            this.comboBoxUsedNew.Location = new System.Drawing.Point(207, 138);
            this.comboBoxUsedNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxUsedNew.Name = "comboBoxUsedNew";
            this.comboBoxUsedNew.Size = new System.Drawing.Size(91, 21);
            this.comboBoxUsedNew.TabIndex = 68;
            // 
            // labelManufactureDate
            // 
            this.labelManufactureDate.AutoSize = true;
            this.labelManufactureDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManufactureDate.Location = new System.Drawing.Point(374, 96);
            this.labelManufactureDate.Name = "labelManufactureDate";
            this.labelManufactureDate.Size = new System.Drawing.Size(137, 20);
            this.labelManufactureDate.TabIndex = 71;
            this.labelManufactureDate.Text = "Manufacture Date";
            // 
            // dateTimePickerManufactureDate
            // 
            this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(345, 118);
            this.dateTimePickerManufactureDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
            this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(186, 20);
            this.dateTimePickerManufactureDate.TabIndex = 70;
            this.dateTimePickerManufactureDate.Value = new System.DateTime(2023, 3, 23, 16, 23, 38, 0);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.SaveButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.Location = new System.Drawing.Point(294, 176);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 43);
            this.SaveButton.TabIndex = 72;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Maroon;
            this.ClearButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(201, 176);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(87, 43);
            this.ClearButton.TabIndex = 73;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click_1);
            // 
            // NewHelmetModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(566, 230);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label NewHelmetTxt;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label labelUsedNew;
        private System.Windows.Forms.Label labelManufactureDate;
        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.ComboBox comboBoxBrand;
        public System.Windows.Forms.ComboBox comboBoxColor;
        public System.Windows.Forms.ComboBox comboBoxUsedNew;
        public System.Windows.Forms.DateTimePicker dateTimePickerManufactureDate;
    }
}