namespace InventoryManagmentSystem
{
    partial class SetSelectionModuleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetSelectionModuleForm));
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.NewItemTxt = new System.Windows.Forms.Label();
            this.comboBoxSet = new System.Windows.Forms.ComboBox();
            this.labelRentalOptions = new System.Windows.Forms.Label();
            this.textBoxHelmet = new System.Windows.Forms.TextBox();
            this.textBoxJacket = new System.Windows.Forms.TextBox();
            this.textBoxPants = new System.Windows.Forms.TextBox();
            this.textBoxBoots = new System.Windows.Forms.TextBox();
            this.lableHelmet = new System.Windows.Forms.Label();
            this.labelJacket = new System.Windows.Forms.Label();
            this.labelPants = new System.Windows.Forms.Label();
            this.labelBoots = new System.Windows.Forms.Label();
            this.BtnNewItem = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.btnContinue = new System.Windows.Forms.Button();
            this.labelDueDate = new System.Windows.Forms.Label();
            this.DatepickerDue = new System.Windows.Forms.DateTimePicker();
            this.dataGridInv = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufactureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsedNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewClient = new System.Windows.Forms.DataGridView();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelClientName = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.InventoryPanel.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).BeginInit();
            this.panelTitle.SuspendLayout();
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
            this.InventoryPanel.Size = new System.Drawing.Size(1140, 64);
            this.InventoryPanel.TabIndex = 24;
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
            this.NewItemTxt.Size = new System.Drawing.Size(261, 29);
            this.NewItemTxt.TabIndex = 16;
            this.NewItemTxt.Text = "Select a rental option";
            this.NewItemTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBoxSet
            // 
            this.comboBoxSet.FormattingEnabled = true;
            this.comboBoxSet.Items.AddRange(new object[] {
            "Full Set",
            "Set Helmet Only",
            "Set Boots Only",
            "Pants & Jacket"});
            this.comboBoxSet.Location = new System.Drawing.Point(21, 77);
            this.comboBoxSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSet.Name = "comboBoxSet";
            this.comboBoxSet.Size = new System.Drawing.Size(215, 24);
            this.comboBoxSet.TabIndex = 25;
            this.comboBoxSet.SelectedIndexChanged += new System.EventHandler(this.comboBoxSet_SelectedIndexChanged);
            // 
            // labelRentalOptions
            // 
            this.labelRentalOptions.AutoSize = true;
            this.labelRentalOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRentalOptions.ForeColor = System.Drawing.Color.White;
            this.labelRentalOptions.Location = new System.Drawing.Point(16, 38);
            this.labelRentalOptions.Name = "labelRentalOptions";
            this.labelRentalOptions.Size = new System.Drawing.Size(194, 31);
            this.labelRentalOptions.TabIndex = 26;
            this.labelRentalOptions.Text = "Rental Options";
            // 
            // textBoxHelmet
            // 
            this.textBoxHelmet.Location = new System.Drawing.Point(13, 210);
            this.textBoxHelmet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxHelmet.Name = "textBoxHelmet";
            this.textBoxHelmet.Size = new System.Drawing.Size(176, 22);
            this.textBoxHelmet.TabIndex = 27;
            this.textBoxHelmet.Click += new System.EventHandler(this.textBoxHelmet_TextChanged);
            this.textBoxHelmet.TextChanged += new System.EventHandler(this.textBoxHelmet_TextChanged);
            // 
            // textBoxJacket
            // 
            this.textBoxJacket.Location = new System.Drawing.Point(12, 265);
            this.textBoxJacket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxJacket.Name = "textBoxJacket";
            this.textBoxJacket.Size = new System.Drawing.Size(176, 22);
            this.textBoxJacket.TabIndex = 28;
            this.textBoxJacket.Click += new System.EventHandler(this.textBoxJacket_TextChanged);
            this.textBoxJacket.TextChanged += new System.EventHandler(this.textBoxJacket_TextChanged);
            // 
            // textBoxPants
            // 
            this.textBoxPants.Location = new System.Drawing.Point(13, 323);
            this.textBoxPants.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPants.Name = "textBoxPants";
            this.textBoxPants.Size = new System.Drawing.Size(176, 22);
            this.textBoxPants.TabIndex = 29;
            this.textBoxPants.Click += new System.EventHandler(this.textBoxPants_TextChanged);
            this.textBoxPants.TextChanged += new System.EventHandler(this.textBoxPants_TextChanged);
            // 
            // textBoxBoots
            // 
            this.textBoxBoots.Location = new System.Drawing.Point(12, 379);
            this.textBoxBoots.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBoots.Name = "textBoxBoots";
            this.textBoxBoots.Size = new System.Drawing.Size(176, 22);
            this.textBoxBoots.TabIndex = 30;
            this.textBoxBoots.Click += new System.EventHandler(this.textBoxBoots_TextChanged);
            this.textBoxBoots.TextChanged += new System.EventHandler(this.textBoxBoots_TextChanged);
            // 
            // lableHelmet
            // 
            this.lableHelmet.AutoSize = true;
            this.lableHelmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableHelmet.ForeColor = System.Drawing.Color.White;
            this.lableHelmet.Location = new System.Drawing.Point(9, 188);
            this.lableHelmet.Name = "lableHelmet";
            this.lableHelmet.Size = new System.Drawing.Size(121, 20);
            this.lableHelmet.TabIndex = 31;
            this.lableHelmet.Text = "Search Helmet";
            // 
            // labelJacket
            // 
            this.labelJacket.AutoSize = true;
            this.labelJacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJacket.ForeColor = System.Drawing.Color.White;
            this.labelJacket.Location = new System.Drawing.Point(8, 243);
            this.labelJacket.Name = "labelJacket";
            this.labelJacket.Size = new System.Drawing.Size(116, 20);
            this.labelJacket.TabIndex = 32;
            this.labelJacket.Text = "Search Jacket";
            // 
            // labelPants
            // 
            this.labelPants.AutoSize = true;
            this.labelPants.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPants.ForeColor = System.Drawing.Color.White;
            this.labelPants.Location = new System.Drawing.Point(9, 301);
            this.labelPants.Name = "labelPants";
            this.labelPants.Size = new System.Drawing.Size(110, 20);
            this.labelPants.TabIndex = 33;
            this.labelPants.Text = "Search Pants";
            // 
            // labelBoots
            // 
            this.labelBoots.AutoSize = true;
            this.labelBoots.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoots.ForeColor = System.Drawing.Color.White;
            this.labelBoots.Location = new System.Drawing.Point(8, 357);
            this.labelBoots.Name = "labelBoots";
            this.labelBoots.Size = new System.Drawing.Size(111, 20);
            this.labelBoots.TabIndex = 34;
            this.labelBoots.Text = "Search Boots";
            // 
            // BtnNewItem
            // 
            this.BtnNewItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewItem.Location = new System.Drawing.Point(13, 415);
            this.BtnNewItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnNewItem.Name = "BtnNewItem";
            this.BtnNewItem.Size = new System.Drawing.Size(107, 28);
            this.BtnNewItem.TabIndex = 35;
            this.BtnNewItem.Text = "New Item";
            this.BtnNewItem.UseVisualStyleBackColor = true;
            this.BtnNewItem.Click += new System.EventHandler(this.BtnNewItem_Click);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.Transparent;
            this.panelInput.Controls.Add(this.btnContinue);
            this.panelInput.Controls.Add(this.labelDueDate);
            this.panelInput.Controls.Add(this.DatepickerDue);
            this.panelInput.Controls.Add(this.textBoxBoots);
            this.panelInput.Controls.Add(this.comboBoxSet);
            this.panelInput.Controls.Add(this.BtnNewItem);
            this.panelInput.Controls.Add(this.labelRentalOptions);
            this.panelInput.Controls.Add(this.labelBoots);
            this.panelInput.Controls.Add(this.textBoxHelmet);
            this.panelInput.Controls.Add(this.labelPants);
            this.panelInput.Controls.Add(this.textBoxJacket);
            this.panelInput.Controls.Add(this.labelJacket);
            this.panelInput.Controls.Add(this.textBoxPants);
            this.panelInput.Controls.Add(this.lableHelmet);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInput.Location = new System.Drawing.Point(0, 64);
            this.panelInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(248, 454);
            this.panelInput.TabIndex = 37;
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Lime;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(134, 415);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(107, 28);
            this.btnContinue.TabIndex = 38;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // labelDueDate
            // 
            this.labelDueDate.AutoSize = true;
            this.labelDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDueDate.ForeColor = System.Drawing.Color.White;
            this.labelDueDate.Location = new System.Drawing.Point(80, 113);
            this.labelDueDate.Name = "labelDueDate";
            this.labelDueDate.Size = new System.Drawing.Size(94, 25);
            this.labelDueDate.TabIndex = 37;
            this.labelDueDate.Text = "Due Date";
            // 
            // DatepickerDue
            // 
            this.DatepickerDue.Location = new System.Drawing.Point(3, 141);
            this.DatepickerDue.Name = "DatepickerDue";
            this.DatepickerDue.Size = new System.Drawing.Size(239, 22);
            this.DatepickerDue.TabIndex = 36;
            // 
            // dataGridInv
            // 
            this.dataGridInv.AllowUserToAddRows = false;
            this.dataGridInv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Type,
            this.Brand,
            this.Serial,
            this.Size,
            this.ManufactureDate,
            this.UsedNew,
            this.ColorMaterial});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridInv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridInv.EnableHeadersVisualStyles = false;
            this.dataGridInv.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridInv.Location = new System.Drawing.Point(248, 64);
            this.dataGridInv.Name = "dataGridInv";
            this.dataGridInv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridInv.RowHeadersVisible = false;
            this.dataGridInv.RowHeadersWidth = 51;
            this.dataGridInv.RowTemplate.Height = 24;
            this.dataGridInv.RowTemplate.ReadOnly = true;
            this.dataGridInv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInv.Size = new System.Drawing.Size(892, 278);
            this.dataGridInv.TabIndex = 39;
            this.dataGridInv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridInv_CellContentClick);
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Num.FillWeight = 30F;
            this.Num.HeaderText = "#";
            this.Num.MinimumWidth = 6;
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.FillWeight = 50F;
            this.Type.HeaderText = "Item";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Brand
            // 
            this.Brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brand.HeaderText = "Brand";
            this.Brand.MinimumWidth = 6;
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            // 
            // Serial
            // 
            this.Serial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Serial.HeaderText = "Serial #";
            this.Serial.MinimumWidth = 6;
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            // 
            // Size
            // 
            this.Size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Size.FillWeight = 40F;
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 6;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            // 
            // ManufactureDate
            // 
            this.ManufactureDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ManufactureDate.FillWeight = 120F;
            this.ManufactureDate.HeaderText = "MFD";
            this.ManufactureDate.MinimumWidth = 6;
            this.ManufactureDate.Name = "ManufactureDate";
            this.ManufactureDate.ReadOnly = true;
            // 
            // UsedNew
            // 
            this.UsedNew.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UsedNew.FillWeight = 50F;
            this.UsedNew.HeaderText = "Used";
            this.UsedNew.MinimumWidth = 6;
            this.UsedNew.Name = "UsedNew";
            this.UsedNew.ReadOnly = true;
            // 
            // ColorMaterial
            // 
            this.ColorMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColorMaterial.FillWeight = 60F;
            this.ColorMaterial.HeaderText = "Color / Material";
            this.ColorMaterial.MinimumWidth = 6;
            this.ColorMaterial.Name = "ColorMaterial";
            this.ColorMaterial.ReadOnly = true;
            // 
            // dataGridViewClient
            // 
            this.dataGridViewClient.AllowUserToAddRows = false;
            this.dataGridViewClient.AllowUserToDeleteRows = false;
            this.dataGridViewClient.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewClient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewClient.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewClient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Item,
            this.DueDate,
            this.SerialNum});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewClient.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewClient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewClient.EnableHeadersVisualStyles = false;
            this.dataGridViewClient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewClient.Location = new System.Drawing.Point(248, 386);
            this.dataGridViewClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.dataGridViewClient.Name = "dataGridViewClient";
            this.dataGridViewClient.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClient.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewClient.RowHeadersVisible = false;
            this.dataGridViewClient.RowHeadersWidth = 15;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Transparent;
            this.dataGridViewClient.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewClient.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dataGridViewClient.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewClient.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dataGridViewClient.Size = new System.Drawing.Size(892, 132);
            this.dataGridViewClient.TabIndex = 40;
            this.dataGridViewClient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClient_CellContentClick);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Maroon;
            this.panelTitle.Controls.Add(this.labelClientName);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTitle.Location = new System.Drawing.Point(248, 360);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(892, 26);
            this.panelTitle.TabIndex = 41;
            // 
            // labelClientName
            // 
            this.labelClientName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClientName.AutoSize = true;
            this.labelClientName.BackColor = System.Drawing.Color.Transparent;
            this.labelClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientName.ForeColor = System.Drawing.Color.White;
            this.labelClientName.Location = new System.Drawing.Point(5, 0);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(52, 20);
            this.labelClientName.TabIndex = 0;
            this.labelClientName.Text = "Client";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.FillWeight = 30F;
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.MinimumWidth = 6;
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "DueDate";
            this.DueDate.MinimumWidth = 6;
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            // 
            // SerialNum
            // 
            this.SerialNum.HeaderText = "Serial #";
            this.SerialNum.MinimumWidth = 6;
            this.SerialNum.Name = "SerialNum";
            this.SerialNum.ReadOnly = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(1076, 11);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(36, 42);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 68;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SetSelectionModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1140, 518);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.dataGridViewClient);
            this.Controls.Add(this.dataGridInv);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.InventoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetSelectionModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetSelectionModuleForm";
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label NewItemTxt;
        private System.Windows.Forms.ComboBox comboBoxSet;
        private System.Windows.Forms.Label labelRentalOptions;
        private System.Windows.Forms.TextBox textBoxHelmet;
        private System.Windows.Forms.TextBox textBoxJacket;
        private System.Windows.Forms.TextBox textBoxPants;
        private System.Windows.Forms.TextBox textBoxBoots;
        private System.Windows.Forms.Label lableHelmet;
        private System.Windows.Forms.Label labelJacket;
        private System.Windows.Forms.Label labelPants;
        private System.Windows.Forms.Label labelBoots;
        private System.Windows.Forms.Button BtnNewItem;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.DataGridView dataGridInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufactureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsedNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorMaterial;
        private System.Windows.Forms.DataGridView dataGridViewClient;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.Label labelDueDate;
        private System.Windows.Forms.DateTimePicker DatepickerDue;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNum;
    }
}