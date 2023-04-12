namespace InventoryManagmentSystem
{
    partial class NewRentalModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRentalModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.TxtCustomerInfo = new System.Windows.Forms.Label();
            this.labelAcademy = new System.Windows.Forms.Label();
            this.comboBoxAcademy = new System.Windows.Forms.ComboBox();
            this.labelDayNight = new System.Windows.Forms.Label();
            this.comboDayNight = new System.Windows.Forms.ComboBox();
            this.txtBoxCustomerName = new System.Windows.Forms.TextBox();
            this.LableCustomerName = new System.Windows.Forms.Label();
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtBoxDriversLicense = new System.Windows.Forms.TextBox();
            this.labelDriversLicense = new System.Windows.Forms.Label();
            this.txtBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.txtBoxRep = new System.Windows.Forms.TextBox();
            this.labelRep = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ButtonContinue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.TxtCustomerInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 67);
            this.panel1.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(485, 13);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(36, 42);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 69;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TxtCustomerInfo
            // 
            this.TxtCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCustomerInfo.AutoSize = true;
            this.TxtCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCustomerInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TxtCustomerInfo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TxtCustomerInfo.Location = new System.Drawing.Point(13, 16);
            this.TxtCustomerInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtCustomerInfo.Name = "TxtCustomerInfo";
            this.TxtCustomerInfo.Size = new System.Drawing.Size(175, 29);
            this.TxtCustomerInfo.TabIndex = 17;
            this.TxtCustomerInfo.Text = "Customer Info";
            this.TxtCustomerInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelAcademy
            // 
            this.labelAcademy.AutoSize = true;
            this.labelAcademy.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAcademy.Location = new System.Drawing.Point(24, 102);
            this.labelAcademy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAcademy.Name = "labelAcademy";
            this.labelAcademy.Size = new System.Drawing.Size(90, 24);
            this.labelAcademy.TabIndex = 87;
            this.labelAcademy.Text = "Academy";
            // 
            // comboBoxAcademy
            // 
            this.comboBoxAcademy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxAcademy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxAcademy.FormattingEnabled = true;
            this.comboBoxAcademy.Items.AddRange(new object[] {
            "BFA",
            "OCALA",
            "CORAL SPRING",
            "PASCO HERNANDO",
            "PALM BEACH",
            "MIAMI DADE",
            "EASTERN",
            "MONROE",
            "BRAXTON",
            "BARRY",
            "CITRUS",
            "SUNCOAST",
            "DAYTONA",
            "RIDGE",
            "GATEWAY",
            "APARICIO LEVY",
            "RESOLVE MARITIME",
            "SOUTH FL STATE (AVON PARK)",
            "NORTHWEST"});
            this.comboBoxAcademy.Location = new System.Drawing.Point(28, 129);
            this.comboBoxAcademy.Name = "comboBoxAcademy";
            this.comboBoxAcademy.Size = new System.Drawing.Size(101, 24);
            this.comboBoxAcademy.TabIndex = 86;
            // 
            // labelDayNight
            // 
            this.labelDayNight.AutoSize = true;
            this.labelDayNight.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDayNight.Location = new System.Drawing.Point(144, 102);
            this.labelDayNight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDayNight.Name = "labelDayNight";
            this.labelDayNight.Size = new System.Drawing.Size(109, 24);
            this.labelDayNight.TabIndex = 89;
            this.labelDayNight.Text = "Day / Night";
            // 
            // comboDayNight
            // 
            this.comboDayNight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboDayNight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboDayNight.FormattingEnabled = true;
            this.comboDayNight.Items.AddRange(new object[] {
            "Day",
            "Night"});
            this.comboDayNight.Location = new System.Drawing.Point(148, 129);
            this.comboDayNight.Name = "comboDayNight";
            this.comboDayNight.Size = new System.Drawing.Size(103, 24);
            this.comboDayNight.TabIndex = 88;
            // 
            // txtBoxCustomerName
            // 
            this.txtBoxCustomerName.Location = new System.Drawing.Point(277, 129);
            this.txtBoxCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxCustomerName.Name = "txtBoxCustomerName";
            this.txtBoxCustomerName.Size = new System.Drawing.Size(221, 22);
            this.txtBoxCustomerName.TabIndex = 91;
            // 
            // LableCustomerName
            // 
            this.LableCustomerName.AutoSize = true;
            this.LableCustomerName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableCustomerName.Location = new System.Drawing.Point(272, 101);
            this.LableCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LableCustomerName.Name = "LableCustomerName";
            this.LableCustomerName.Size = new System.Drawing.Size(151, 24);
            this.LableCustomerName.TabIndex = 90;
            this.LableCustomerName.Text = "Customer Name";
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.Location = new System.Drawing.Point(29, 184);
            this.txtBoxPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.Size = new System.Drawing.Size(222, 22);
            this.txtBoxPhone.TabIndex = 93;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhone.Location = new System.Drawing.Point(24, 156);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(65, 24);
            this.labelPhone.TabIndex = 92;
            this.labelPhone.Text = "Phone";
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Location = new System.Drawing.Point(274, 184);
            this.txtBoxEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.Size = new System.Drawing.Size(224, 22);
            this.txtBoxEmail.TabIndex = 95;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(269, 156);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(59, 24);
            this.labelEmail.TabIndex = 94;
            this.labelEmail.Text = "Email";
            // 
            // txtBoxDriversLicense
            // 
            this.txtBoxDriversLicense.Location = new System.Drawing.Point(28, 239);
            this.txtBoxDriversLicense.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxDriversLicense.Name = "txtBoxDriversLicense";
            this.txtBoxDriversLicense.Size = new System.Drawing.Size(223, 22);
            this.txtBoxDriversLicense.TabIndex = 97;
            // 
            // labelDriversLicense
            // 
            this.labelDriversLicense.AutoSize = true;
            this.labelDriversLicense.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDriversLicense.Location = new System.Drawing.Point(23, 211);
            this.labelDriversLicense.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDriversLicense.Name = "labelDriversLicense";
            this.labelDriversLicense.Size = new System.Drawing.Size(165, 24);
            this.labelDriversLicense.TabIndex = 96;
            this.labelDriversLicense.Text = "Drivers License #";
            // 
            // txtBoxAddress
            // 
            this.txtBoxAddress.Location = new System.Drawing.Point(275, 239);
            this.txtBoxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxAddress.Name = "txtBoxAddress";
            this.txtBoxAddress.Size = new System.Drawing.Size(223, 22);
            this.txtBoxAddress.TabIndex = 99;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(270, 211);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(79, 24);
            this.labelAddress.TabIndex = 98;
            this.labelAddress.Text = "Address";
            // 
            // txtBoxRep
            // 
            this.txtBoxRep.Location = new System.Drawing.Point(148, 321);
            this.txtBoxRep.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxRep.Name = "txtBoxRep";
            this.txtBoxRep.Size = new System.Drawing.Size(223, 22);
            this.txtBoxRep.TabIndex = 101;
            // 
            // labelRep
            // 
            this.labelRep.AutoSize = true;
            this.labelRep.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRep.Location = new System.Drawing.Point(143, 293);
            this.labelRep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRep.Name = "labelRep";
            this.labelRep.Size = new System.Drawing.Size(227, 24);
            this.labelRep.TabIndex = 100;
            this.labelRep.Text = "Fire-Tec Representative";
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Maroon;
            this.ClearButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(278, 367);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(116, 53);
            this.ClearButton.TabIndex = 103;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ButtonContinue
            // 
            this.ButtonContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ButtonContinue.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonContinue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonContinue.Location = new System.Drawing.Point(123, 367);
            this.ButtonContinue.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonContinue.Name = "ButtonContinue";
            this.ButtonContinue.Size = new System.Drawing.Size(116, 53);
            this.ButtonContinue.TabIndex = 102;
            this.ButtonContinue.Text = "Continue";
            this.ButtonContinue.UseVisualStyleBackColor = false;
            this.ButtonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // NewRentalModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(534, 433);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ButtonContinue);
            this.Controls.Add(this.txtBoxRep);
            this.Controls.Add(this.labelRep);
            this.Controls.Add(this.txtBoxAddress);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.txtBoxDriversLicense);
            this.Controls.Add(this.labelDriversLicense);
            this.Controls.Add(this.txtBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.txtBoxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.txtBoxCustomerName);
            this.Controls.Add(this.LableCustomerName);
            this.Controls.Add(this.labelDayNight);
            this.Controls.Add(this.comboDayNight);
            this.Controls.Add(this.labelAcademy);
            this.Controls.Add(this.comboBoxAcademy);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewRentalModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewRentalModule";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TxtCustomerInfo;
        private System.Windows.Forms.Label labelAcademy;
        private System.Windows.Forms.ComboBox comboBoxAcademy;
        private System.Windows.Forms.Label labelDayNight;
        private System.Windows.Forms.ComboBox comboDayNight;
        public System.Windows.Forms.TextBox txtBoxCustomerName;
        private System.Windows.Forms.Label LableCustomerName;
        public System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.Label labelPhone;
        public System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        public System.Windows.Forms.TextBox txtBoxDriversLicense;
        private System.Windows.Forms.Label labelDriversLicense;
        public System.Windows.Forms.TextBox txtBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        public System.Windows.Forms.TextBox txtBoxRep;
        private System.Windows.Forms.Label labelRep;
        private CustomButton CloseButton;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.Button ButtonContinue;
    }
}