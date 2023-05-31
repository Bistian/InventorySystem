namespace InventoryManagmentSystem
{
    partial class NewBootModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewBootModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.NewBootTxt = new System.Windows.Forms.Label();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.LableBrand = new System.Windows.Forms.Label();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.txtBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.LableSerialNumber = new System.Windows.Forms.Label();
            this.labelUsedNew = new System.Windows.Forms.Label();
            this.comboBoxUsedNew = new System.Windows.Forms.ComboBox();
            this.labelManufactureDate = new System.Windows.Forms.Label();
            this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.NewBootTxt);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Name = "panel1";
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // NewBootTxt
            // 
            resources.ApplyResources(this.NewBootTxt, "NewBootTxt");
            this.NewBootTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewBootTxt.Name = "NewBootTxt";
            // 
            // labelMaterial
            // 
            resources.ApplyResources(this.labelMaterial, "labelMaterial");
            this.labelMaterial.Name = "labelMaterial";
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Items.AddRange(new object[] {
            resources.GetString("comboBoxMaterial.Items"),
            resources.GetString("comboBoxMaterial.Items1")});
            resources.ApplyResources(this.comboBoxMaterial, "comboBoxMaterial");
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            // 
            // LableBrand
            // 
            resources.ApplyResources(this.LableBrand, "LableBrand");
            this.LableBrand.Name = "LableBrand";
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Items.AddRange(new object[] {
            resources.GetString("comboBoxBrand.Items"),
            resources.GetString("comboBoxBrand.Items1"),
            resources.GetString("comboBoxBrand.Items2"),
            resources.GetString("comboBoxBrand.Items3")});
            resources.ApplyResources(this.comboBoxBrand, "comboBoxBrand");
            this.comboBoxBrand.Name = "comboBoxBrand";
            // 
            // labelSize
            // 
            resources.ApplyResources(this.labelSize, "labelSize");
            this.labelSize.Name = "labelSize";
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Items.AddRange(new object[] {
            resources.GetString("comboBoxSize.Items"),
            resources.GetString("comboBoxSize.Items1"),
            resources.GetString("comboBoxSize.Items2"),
            resources.GetString("comboBoxSize.Items3"),
            resources.GetString("comboBoxSize.Items4"),
            resources.GetString("comboBoxSize.Items5"),
            resources.GetString("comboBoxSize.Items6"),
            resources.GetString("comboBoxSize.Items7"),
            resources.GetString("comboBoxSize.Items8"),
            resources.GetString("comboBoxSize.Items9"),
            resources.GetString("comboBoxSize.Items10"),
            resources.GetString("comboBoxSize.Items11"),
            resources.GetString("comboBoxSize.Items12"),
            resources.GetString("comboBoxSize.Items13"),
            resources.GetString("comboBoxSize.Items14"),
            resources.GetString("comboBoxSize.Items15"),
            resources.GetString("comboBoxSize.Items16"),
            resources.GetString("comboBoxSize.Items17"),
            resources.GetString("comboBoxSize.Items18"),
            resources.GetString("comboBoxSize.Items19"),
            resources.GetString("comboBoxSize.Items20"),
            resources.GetString("comboBoxSize.Items21"),
            resources.GetString("comboBoxSize.Items22")});
            resources.ApplyResources(this.comboBoxSize, "comboBoxSize");
            this.comboBoxSize.Name = "comboBoxSize";
            // 
            // txtBoxSerialNumber
            // 
            resources.ApplyResources(this.txtBoxSerialNumber, "txtBoxSerialNumber");
            this.txtBoxSerialNumber.Name = "txtBoxSerialNumber";
            // 
            // LableSerialNumber
            // 
            resources.ApplyResources(this.LableSerialNumber, "LableSerialNumber");
            this.LableSerialNumber.Name = "LableSerialNumber";
            // 
            // labelUsedNew
            // 
            resources.ApplyResources(this.labelUsedNew, "labelUsedNew");
            this.labelUsedNew.Name = "labelUsedNew";
            // 
            // comboBoxUsedNew
            // 
            this.comboBoxUsedNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxUsedNew.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxUsedNew.FormattingEnabled = true;
            this.comboBoxUsedNew.Items.AddRange(new object[] {
            resources.GetString("comboBoxUsedNew.Items"),
            resources.GetString("comboBoxUsedNew.Items1")});
            resources.ApplyResources(this.comboBoxUsedNew, "comboBoxUsedNew");
            this.comboBoxUsedNew.Name = "comboBoxUsedNew";
            // 
            // labelManufactureDate
            // 
            resources.ApplyResources(this.labelManufactureDate, "labelManufactureDate");
            this.labelManufactureDate.Name = "labelManufactureDate";
            // 
            // dateTimePickerManufactureDate
            // 
            this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.dateTimePickerManufactureDate, "dateTimePickerManufactureDate");
            this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.ClearButton, "ClearButton");
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // NewBootModuleForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.labelManufactureDate);
            this.Controls.Add(this.dateTimePickerManufactureDate);
            this.Controls.Add(this.labelUsedNew);
            this.Controls.Add(this.comboBoxUsedNew);
            this.Controls.Add(this.labelMaterial);
            this.Controls.Add(this.comboBoxMaterial);
            this.Controls.Add(this.LableBrand);
            this.Controls.Add(this.comboBoxBrand);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.comboBoxSize);
            this.Controls.Add(this.txtBoxSerialNumber);
            this.Controls.Add(this.LableSerialNumber);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewBootModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NewBootTxt;
        private System.Windows.Forms.Label labelMaterial;
        private System.Windows.Forms.Label LableBrand;
        private System.Windows.Forms.Label labelSize;
        public System.Windows.Forms.TextBox txtBoxSerialNumber;
        private System.Windows.Forms.Label LableSerialNumber;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label labelUsedNew;
        private System.Windows.Forms.Label labelManufactureDate;
        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.ComboBox comboBoxMaterial;
        public System.Windows.Forms.ComboBox comboBoxBrand;
        public System.Windows.Forms.ComboBox comboBoxSize;
        public System.Windows.Forms.ComboBox comboBoxUsedNew;
        public System.Windows.Forms.DateTimePicker dateTimePickerManufactureDate;
    }
}