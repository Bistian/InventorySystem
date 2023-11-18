namespace InventoryManagmentSystem.Rental_Forms
{
    partial class NewItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewItemForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonClose = new InventoryManagmentSystem.CustomButton();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.labelManufactureDate = new System.Windows.Forms.Label();
            this.dtManufacture = new System.Windows.Forms.DateTimePicker();
            this.labelCondition = new System.Windows.Forms.Label();
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.lableBrand = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.lableSerialNumber = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.labelItemType = new System.Windows.Forms.Label();
            this.labelAcquisition = new System.Windows.Forms.Label();
            this.dtAcquisition = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.ButtonClose);
            this.panel1.Controls.Add(this.labelTitle);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Name = "panel1";
            // 
            // ButtonClose
            // 
            resources.ApplyResources(this.ButtonClose, "ButtonClose");
            this.ButtonClose.ImageHover = ((System.Drawing.Image)(resources.GetObject("ButtonClose.ImageHover")));
            this.ButtonClose.ImageNormal = ((System.Drawing.Image)(resources.GetObject("ButtonClose.ImageNormal")));
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.TabStop = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTitle.Name = "labelTitle";
            // 
            // btnAddBrand
            // 
            resources.ApplyResources(this.btnAddBrand, "btnAddBrand");
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
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
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // labelManufactureDate
            // 
            resources.ApplyResources(this.labelManufactureDate, "labelManufactureDate");
            this.labelManufactureDate.Name = "labelManufactureDate";
            // 
            // dtManufacture
            // 
            resources.ApplyResources(this.dtManufacture, "dtManufacture");
            this.dtManufacture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtManufacture.Name = "dtManufacture";
            // 
            // labelCondition
            // 
            resources.ApplyResources(this.labelCondition, "labelCondition");
            this.labelCondition.Name = "labelCondition";
            // 
            // cbCondition
            // 
            this.cbCondition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCondition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbCondition, "cbCondition");
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Items.AddRange(new object[] {
            resources.GetString("cbCondition.Items"),
            resources.GetString("cbCondition.Items1"),
            resources.GetString("cbCondition.Items2")});
            this.cbCondition.Name = "cbCondition";
            // 
            // labelMaterial
            // 
            resources.ApplyResources(this.labelMaterial, "labelMaterial");
            this.labelMaterial.Name = "labelMaterial";
            // 
            // cbMaterial
            // 
            this.cbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbMaterial, "cbMaterial");
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Items.AddRange(new object[] {
            resources.GetString("cbMaterial.Items"),
            resources.GetString("cbMaterial.Items1")});
            this.cbMaterial.Name = "cbMaterial";
            // 
            // lableBrand
            // 
            resources.ApplyResources(this.lableBrand, "lableBrand");
            this.lableBrand.Name = "lableBrand";
            // 
            // cbBrand
            // 
            this.cbBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbBrand, "cbBrand");
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Name = "cbBrand";
            // 
            // labelSize
            // 
            resources.ApplyResources(this.labelSize, "labelSize");
            this.labelSize.Name = "labelSize";
            // 
            // cbSize
            // 
            this.cbSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cbSize, "cbSize");
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Items.AddRange(new object[] {
            resources.GetString("cbSize.Items"),
            resources.GetString("cbSize.Items1"),
            resources.GetString("cbSize.Items2"),
            resources.GetString("cbSize.Items3"),
            resources.GetString("cbSize.Items4"),
            resources.GetString("cbSize.Items5"),
            resources.GetString("cbSize.Items6"),
            resources.GetString("cbSize.Items7"),
            resources.GetString("cbSize.Items8"),
            resources.GetString("cbSize.Items9"),
            resources.GetString("cbSize.Items10"),
            resources.GetString("cbSize.Items11"),
            resources.GetString("cbSize.Items12"),
            resources.GetString("cbSize.Items13"),
            resources.GetString("cbSize.Items14"),
            resources.GetString("cbSize.Items15"),
            resources.GetString("cbSize.Items16"),
            resources.GetString("cbSize.Items17"),
            resources.GetString("cbSize.Items18"),
            resources.GetString("cbSize.Items19"),
            resources.GetString("cbSize.Items20"),
            resources.GetString("cbSize.Items21"),
            resources.GetString("cbSize.Items22")});
            this.cbSize.Name = "cbSize";
            // 
            // tbSerialNumber
            // 
            resources.ApplyResources(this.tbSerialNumber, "tbSerialNumber");
            this.tbSerialNumber.Name = "tbSerialNumber";
            // 
            // lableSerialNumber
            // 
            resources.ApplyResources(this.lableSerialNumber, "lableSerialNumber");
            this.lableSerialNumber.Name = "lableSerialNumber";
            // 
            // labelColor
            // 
            resources.ApplyResources(this.labelColor, "labelColor");
            this.labelColor.Name = "labelColor";
            // 
            // cbColor
            // 
            this.cbColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            resources.GetString("cbColor.Items"),
            resources.GetString("cbColor.Items1")});
            this.cbColor.Name = "cbColor";
            // 
            // cbItemType
            // 
            this.cbItemType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbItemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbItemType, "cbItemType");
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.SelectedIndexChanged += new System.EventHandler(this.cbItemType_SelectedIndexChanged);
            // 
            // labelItemType
            // 
            resources.ApplyResources(this.labelItemType, "labelItemType");
            this.labelItemType.Name = "labelItemType";
            // 
            // labelAcquisition
            // 
            resources.ApplyResources(this.labelAcquisition, "labelAcquisition");
            this.labelAcquisition.Name = "labelAcquisition";
            // 
            // dtAcquisition
            // 
            resources.ApplyResources(this.dtAcquisition, "dtAcquisition");
            this.dtAcquisition.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAcquisition.Name = "dtAcquisition";
            // 
            // NewItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.labelAcquisition);
            this.Controls.Add(this.dtAcquisition);
            this.Controls.Add(this.labelItemType);
            this.Controls.Add(this.cbItemType);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.btnAddBrand);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.cbMaterial);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.lableSerialNumber);
            this.Controls.Add(this.labelManufactureDate);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.dtManufacture);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.labelCondition);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.cbCondition);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.labelMaterial);
            this.Controls.Add(this.lableBrand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewItemForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnAddBrand;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label labelManufactureDate;
        public System.Windows.Forms.DateTimePicker dtManufacture;
        private System.Windows.Forms.Label labelCondition;
        public System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.Label labelMaterial;
        public System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.Label lableBrand;
        public System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.Label labelSize;
        public System.Windows.Forms.ComboBox cbSize;
        public System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Label lableSerialNumber;
        private System.Windows.Forms.Label labelColor;
        public System.Windows.Forms.ComboBox cbColor;
        public System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.Label labelItemType;
        private CustomButton ButtonClose;
        private System.Windows.Forms.Label labelAcquisition;
        public System.Windows.Forms.DateTimePicker dtAcquisition;
    }
}