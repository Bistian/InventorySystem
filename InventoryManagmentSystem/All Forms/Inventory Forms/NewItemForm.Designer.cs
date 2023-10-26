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
            this.comboBoxCondition = new System.Windows.Forms.ComboBox();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.lableBrand = new System.Windows.Forms.Label();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.txtBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.lableSerialNumber = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
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
            // comboBoxCondition
            // 
            this.comboBoxCondition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCondition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxCondition, "comboBoxCondition");
            this.comboBoxCondition.FormattingEnabled = true;
            this.comboBoxCondition.Items.AddRange(new object[] {
            resources.GetString("comboBoxCondition.Items"),
            resources.GetString("comboBoxCondition.Items1"),
            resources.GetString("comboBoxCondition.Items2")});
            this.comboBoxCondition.Name = "comboBoxCondition";
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
            this.comboBoxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxMaterial, "comboBoxMaterial");
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Items.AddRange(new object[] {
            resources.GetString("comboBoxMaterial.Items"),
            resources.GetString("comboBoxMaterial.Items1")});
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            // 
            // lableBrand
            // 
            resources.ApplyResources(this.lableBrand, "lableBrand");
            this.lableBrand.Name = "lableBrand";
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxBrand, "comboBoxBrand");
            this.comboBoxBrand.FormattingEnabled = true;
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
            resources.ApplyResources(this.comboBoxSize, "comboBoxSize");
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
            this.comboBoxSize.Name = "comboBoxSize";
            // 
            // txtBoxSerialNumber
            // 
            resources.ApplyResources(this.txtBoxSerialNumber, "txtBoxSerialNumber");
            this.txtBoxSerialNumber.Name = "txtBoxSerialNumber";
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
            // comboBoxColor
            // 
            this.comboBoxColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxColor, "comboBoxColor");
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Items.AddRange(new object[] {
            resources.GetString("comboBoxColor.Items"),
            resources.GetString("comboBoxColor.Items1")});
            this.comboBoxColor.Name = "comboBoxColor";
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
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.btnAddBrand);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.comboBoxMaterial);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.lableSerialNumber);
            this.Controls.Add(this.labelManufactureDate);
            this.Controls.Add(this.txtBoxSerialNumber);
            this.Controls.Add(this.dtManufacture);
            this.Controls.Add(this.comboBoxSize);
            this.Controls.Add(this.labelCondition);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.comboBoxCondition);
            this.Controls.Add(this.comboBoxBrand);
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
        public System.Windows.Forms.ComboBox comboBoxCondition;
        private System.Windows.Forms.Label labelMaterial;
        public System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.Label lableBrand;
        public System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.Label labelSize;
        public System.Windows.Forms.ComboBox comboBoxSize;
        public System.Windows.Forms.TextBox txtBoxSerialNumber;
        private System.Windows.Forms.Label lableSerialNumber;
        private System.Windows.Forms.Label labelColor;
        public System.Windows.Forms.ComboBox comboBoxColor;
        public System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.Label labelItemType;
        private CustomButton ButtonClose;
        private System.Windows.Forms.Label labelAcquisition;
        public System.Windows.Forms.DateTimePicker dtAcquisition;
    }
}