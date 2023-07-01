namespace InventoryManagmentSystem
{
    partial class NewPantsModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPantsModuleForm));
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.NewPantsTxt = new System.Windows.Forms.Label();
            this.LableBrand = new System.Windows.Forms.Label();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.txtBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.LableSerialNumber = new System.Windows.Forms.Label();
            this.labelUsedNew = new System.Windows.Forms.Label();
            this.comboBoxUsedNew = new System.Windows.Forms.ComboBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.labelManufactureDate = new System.Windows.Forms.Label();
            this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSize = new System.Windows.Forms.TextBox();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.InventoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.BackColor = System.Drawing.Color.Maroon;
            this.InventoryPanel.Controls.Add(this.CloseButton);
            this.InventoryPanel.Controls.Add(this.NewPantsTxt);
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.InventoryPanel.Margin = new System.Windows.Forms.Padding(2);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(566, 52);
            this.InventoryPanel.TabIndex = 22;
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
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // NewPantsTxt
            // 
            this.NewPantsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewPantsTxt.AutoSize = true;
            this.NewPantsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPantsTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewPantsTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NewPantsTxt.Location = new System.Drawing.Point(12, 13);
            this.NewPantsTxt.Name = "NewPantsTxt";
            this.NewPantsTxt.Size = new System.Drawing.Size(109, 24);
            this.NewPantsTxt.TabIndex = 16;
            this.NewPantsTxt.Text = "New Pants";
            this.NewPantsTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LableBrand
            // 
            this.LableBrand.AutoSize = true;
            this.LableBrand.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableBrand.Location = new System.Drawing.Point(18, 116);
            this.LableBrand.Name = "LableBrand";
            this.LableBrand.Size = new System.Drawing.Size(50, 20);
            this.LableBrand.TabIndex = 87;
            this.LableBrand.Text = "Brand";
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Location = new System.Drawing.Point(21, 138);
            this.comboBoxBrand.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(86, 21);
            this.comboBoxBrand.TabIndex = 3;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSize.Location = new System.Drawing.Point(213, 68);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(38, 20);
            this.labelSize.TabIndex = 85;
            this.labelSize.Text = "Size";
            // 
            // txtBoxSerialNumber
            // 
            this.txtBoxSerialNumber.Location = new System.Drawing.Point(21, 92);
            this.txtBoxSerialNumber.Name = "txtBoxSerialNumber";
            this.txtBoxSerialNumber.Size = new System.Drawing.Size(182, 20);
            this.txtBoxSerialNumber.TabIndex = 1;
            // 
            // LableSerialNumber
            // 
            this.LableSerialNumber.AutoSize = true;
            this.LableSerialNumber.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableSerialNumber.Location = new System.Drawing.Point(17, 69);
            this.LableSerialNumber.Name = "LableSerialNumber";
            this.LableSerialNumber.Size = new System.Drawing.Size(109, 20);
            this.LableSerialNumber.TabIndex = 82;
            this.LableSerialNumber.Text = "Serial Number";
            // 
            // labelUsedNew
            // 
            this.labelUsedNew.AutoSize = true;
            this.labelUsedNew.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsedNew.Location = new System.Drawing.Point(108, 116);
            this.labelUsedNew.Name = "labelUsedNew";
            this.labelUsedNew.Size = new System.Drawing.Size(75, 20);
            this.labelUsedNew.TabIndex = 95;
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
            this.comboBoxUsedNew.Location = new System.Drawing.Point(111, 138);
            this.comboBoxUsedNew.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxUsedNew.Name = "comboBoxUsedNew";
            this.comboBoxUsedNew.Size = new System.Drawing.Size(92, 21);
            this.comboBoxUsedNew.TabIndex = 4;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Maroon;
            this.ClearButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(198, 176);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(87, 43);
            this.ClearButton.TabIndex = 99;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click_1);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.SaveButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.Location = new System.Drawing.Point(291, 176);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 43);
            this.SaveButton.TabIndex = 98;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labelManufactureDate
            // 
            this.labelManufactureDate.AutoSize = true;
            this.labelManufactureDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManufactureDate.Location = new System.Drawing.Point(384, 96);
            this.labelManufactureDate.Name = "labelManufactureDate";
            this.labelManufactureDate.Size = new System.Drawing.Size(137, 20);
            this.labelManufactureDate.TabIndex = 97;
            this.labelManufactureDate.Text = "Manufacture Date";
            // 
            // dateTimePickerManufactureDate
            // 
            this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(355, 118);
            this.dateTimePickerManufactureDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
            this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(186, 20);
            this.dateTimePickerManufactureDate.TabIndex = 96;
            this.dateTimePickerManufactureDate.Value = new System.DateTime(2023, 3, 23, 16, 23, 38, 0);
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.Location = new System.Drawing.Point(216, 91);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(92, 20);
            this.comboBoxSize.TabIndex = 2;
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAddBrand.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddBrand.Location = new System.Drawing.Point(22, 164);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(86, 23);
            this.btnAddBrand.TabIndex = 90;
            this.btnAddBrand.Text = "Add Brand";
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // NewPantsModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(566, 230);
            this.Controls.Add(this.btnAddBrand);
            this.Controls.Add(this.comboBoxSize);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.labelManufactureDate);
            this.Controls.Add(this.dateTimePickerManufactureDate);
            this.Controls.Add(this.labelUsedNew);
            this.Controls.Add(this.comboBoxUsedNew);
            this.Controls.Add(this.LableBrand);
            this.Controls.Add(this.comboBoxBrand);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.txtBoxSerialNumber);
            this.Controls.Add(this.LableSerialNumber);
            this.Controls.Add(this.InventoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewPantsModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewPantsModuleForm";
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label NewPantsTxt;
        private System.Windows.Forms.Label LableBrand;
        private System.Windows.Forms.Label labelSize;
        public System.Windows.Forms.TextBox txtBoxSerialNumber;
        private System.Windows.Forms.Label LableSerialNumber;
        private System.Windows.Forms.Label labelUsedNew;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label labelManufactureDate;
        public System.Windows.Forms.TextBox comboBoxSize;
        public System.Windows.Forms.ComboBox comboBoxBrand;
        public System.Windows.Forms.ComboBox comboBoxUsedNew;
        public System.Windows.Forms.DateTimePicker dateTimePickerManufactureDate;
        private System.Windows.Forms.Button btnAddBrand;
    }
}