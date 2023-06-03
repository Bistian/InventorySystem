namespace InventoryManagmentSystem
{
    partial class NewJacketModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewJacketModuleForm));
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.customButton1 = new InventoryManagmentSystem.CustomButton();
            this.NewJacketTxt = new System.Windows.Forms.Label();
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
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.comboBoxSize = new System.Windows.Forms.TextBox();
            this.InventoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.BackColor = System.Drawing.Color.Maroon;
            this.InventoryPanel.Controls.Add(this.customButton1);
            this.InventoryPanel.Controls.Add(this.NewJacketTxt);
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.InventoryPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(755, 64);
            this.InventoryPanel.TabIndex = 22;
            // 
            // customButton1
            // 
            this.customButton1.Image = ((System.Drawing.Image)(resources.GetObject("customButton1.Image")));
            this.customButton1.ImageHover = ((System.Drawing.Image)(resources.GetObject("customButton1.ImageHover")));
            this.customButton1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("customButton1.ImageNormal")));
            this.customButton1.Location = new System.Drawing.Point(707, 4);
            this.customButton1.Margin = new System.Windows.Forms.Padding(4);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(36, 42);
            this.customButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.customButton1.TabIndex = 69;
            this.customButton1.TabStop = false;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // NewJacketTxt
            // 
            this.NewJacketTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewJacketTxt.AutoSize = true;
            this.NewJacketTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewJacketTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewJacketTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NewJacketTxt.Location = new System.Drawing.Point(16, 16);
            this.NewJacketTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NewJacketTxt.Name = "NewJacketTxt";
            this.NewJacketTxt.Size = new System.Drawing.Size(148, 29);
            this.NewJacketTxt.TabIndex = 16;
            this.NewJacketTxt.Text = "New Jacket";
            this.NewJacketTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LableBrand
            // 
            this.LableBrand.AutoSize = true;
            this.LableBrand.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableBrand.Location = new System.Drawing.Point(25, 144);
            this.LableBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LableBrand.Name = "LableBrand";
            this.LableBrand.Size = new System.Drawing.Size(60, 24);
            this.LableBrand.TabIndex = 73;
            this.LableBrand.Text = "Brand";
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Items.AddRange(new object[] {
            "Lakeland",
            "Innotex",
            "Viking",
            "Morning Pride",
            "Globe",
            "FireDex",
            "Honeywell",
            "Skold",
            "Frypel",
            "Quaker",
            "Janesville",
            "Lion",
            "Sperian",
            "Veridian"});
            this.comboBoxBrand.Location = new System.Drawing.Point(29, 171);
            this.comboBoxBrand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(113, 24);
            this.comboBoxBrand.TabIndex = 3;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSize.Location = new System.Drawing.Point(285, 85);
            this.labelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(47, 24);
            this.labelSize.TabIndex = 71;
            this.labelSize.Text = "Size";
            // 
            // txtBoxSerialNumber
            // 
            this.txtBoxSerialNumber.Location = new System.Drawing.Point(29, 114);
            this.txtBoxSerialNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxSerialNumber.Name = "txtBoxSerialNumber";
            this.txtBoxSerialNumber.Size = new System.Drawing.Size(241, 22);
            this.txtBoxSerialNumber.TabIndex = 1;
            // 
            // LableSerialNumber
            // 
            this.LableSerialNumber.AutoSize = true;
            this.LableSerialNumber.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableSerialNumber.Location = new System.Drawing.Point(24, 86);
            this.LableSerialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LableSerialNumber.Name = "LableSerialNumber";
            this.LableSerialNumber.Size = new System.Drawing.Size(137, 24);
            this.LableSerialNumber.TabIndex = 68;
            this.LableSerialNumber.Text = "Serial Number";
            // 
            // labelUsedNew
            // 
            this.labelUsedNew.AutoSize = true;
            this.labelUsedNew.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsedNew.Location = new System.Drawing.Point(145, 144);
            this.labelUsedNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsedNew.Name = "labelUsedNew";
            this.labelUsedNew.Size = new System.Drawing.Size(97, 24);
            this.labelUsedNew.TabIndex = 83;
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
            this.comboBoxUsedNew.Location = new System.Drawing.Point(149, 171);
            this.comboBoxUsedNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxUsedNew.Name = "comboBoxUsedNew";
            this.comboBoxUsedNew.Size = new System.Drawing.Size(121, 24);
            this.comboBoxUsedNew.TabIndex = 4;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Maroon;
            this.ClearButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(247, 217);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(116, 53);
            this.ClearButton.TabIndex = 87;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click_1);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.SaveButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.Location = new System.Drawing.Point(371, 217);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(116, 53);
            this.SaveButton.TabIndex = 86;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labelManufactureDate
            // 
            this.labelManufactureDate.AutoSize = true;
            this.labelManufactureDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManufactureDate.Location = new System.Drawing.Point(512, 118);
            this.labelManufactureDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelManufactureDate.Name = "labelManufactureDate";
            this.labelManufactureDate.Size = new System.Drawing.Size(168, 24);
            this.labelManufactureDate.TabIndex = 85;
            this.labelManufactureDate.Text = "Manufacture Date";
            // 
            // dateTimePickerManufactureDate
            // 
            this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(473, 145);
            this.dateTimePickerManufactureDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
            this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(247, 22);
            this.dateTimePickerManufactureDate.TabIndex = 84;
            this.dateTimePickerManufactureDate.Value = new System.DateTime(2023, 3, 23, 16, 23, 38, 0);
            // 
            // CloseButton
            // 
            this.CloseButton.ImageHover = null;
            this.CloseButton.ImageNormal = null;
            this.CloseButton.Location = new System.Drawing.Point(715, 4);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(36, 42);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 68;
            this.CloseButton.TabStop = false;
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.Location = new System.Drawing.Point(289, 113);
            this.comboBoxSize.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(121, 22);
            this.comboBoxSize.TabIndex = 2;
            // 
            // NewJacketModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(755, 283);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NewJacketModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewJacketModuleForm";
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label NewJacketTxt;
        private System.Windows.Forms.Label LableBrand;
        private System.Windows.Forms.Label labelSize;
        public System.Windows.Forms.TextBox txtBoxSerialNumber;
        private System.Windows.Forms.Label LableSerialNumber;
        private System.Windows.Forms.Label labelUsedNew;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label labelManufactureDate;
        private CustomButton customButton1;
        public System.Windows.Forms.TextBox comboBoxSize;
        public System.Windows.Forms.ComboBox comboBoxBrand;
        public System.Windows.Forms.ComboBox comboBoxUsedNew;
        public System.Windows.Forms.DateTimePicker dateTimePickerManufactureDate;
    }
}