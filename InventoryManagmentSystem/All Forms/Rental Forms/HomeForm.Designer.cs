namespace InventoryManagmentSystem
{
    partial class HomeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerRentalOptions = new System.Windows.Forms.SplitContainer();
            this.buttonNewCustomer = new System.Windows.Forms.Button();
            this.buttonActiveRental = new System.Windows.Forms.Button();
            this.labelDueDate = new System.Windows.Forms.Label();
            this.PastDue = new System.Windows.Forms.Label();
            this.PanelTitles = new System.Windows.Forms.Panel();
            this.dataGridViewDueIn10 = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewPast30 = new System.Windows.Forms.DataGridView();
            this.nums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRented = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.splitContainerItems = new System.Windows.Forms.SplitContainer();
            this.btnHelmets = new System.Windows.Forms.Button();
            this.btnPants = new System.Windows.Forms.Button();
            this.btnCoats = new System.Windows.Forms.Button();
            this.ButtonInStockBoots = new System.Windows.Forms.Button();
            this.ButtonInStockHelmets = new System.Windows.Forms.Button();
            this.ButtonInStockPants = new System.Windows.Forms.Button();
            this.ButtonInStockJackets = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRentalOptions)).BeginInit();
            this.splitContainerRentalOptions.Panel1.SuspendLayout();
            this.splitContainerRentalOptions.Panel2.SuspendLayout();
            this.splitContainerRentalOptions.SuspendLayout();
            this.PanelTitles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDueIn10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPast30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerItems)).BeginInit();
            this.splitContainerItems.Panel1.SuspendLayout();
            this.splitContainerItems.Panel2.SuspendLayout();
            this.splitContainerItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerRentalOptions
            // 
            this.splitContainerRentalOptions.BackColor = System.Drawing.Color.Black;
            this.splitContainerRentalOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainerRentalOptions.Location = new System.Drawing.Point(301, 531);
            this.splitContainerRentalOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerRentalOptions.Name = "splitContainerRentalOptions";
            // 
            // splitContainerRentalOptions.Panel1
            // 
            this.splitContainerRentalOptions.Panel1.Controls.Add(this.buttonNewCustomer);
            // 
            // splitContainerRentalOptions.Panel2
            // 
            this.splitContainerRentalOptions.Panel2.Controls.Add(this.buttonActiveRental);
            this.splitContainerRentalOptions.Size = new System.Drawing.Size(484, 89);
            this.splitContainerRentalOptions.SplitterDistance = 233;
            this.splitContainerRentalOptions.SplitterWidth = 10;
            this.splitContainerRentalOptions.TabIndex = 17;
            // 
            // buttonNewCustomer
            // 
            this.buttonNewCustomer.BackColor = System.Drawing.Color.Black;
            this.buttonNewCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewCustomer.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.buttonNewCustomer.FlatAppearance.BorderSize = 4;
            this.buttonNewCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.buttonNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewCustomer.ForeColor = System.Drawing.Color.Transparent;
            this.buttonNewCustomer.Location = new System.Drawing.Point(0, 0);
            this.buttonNewCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNewCustomer.Name = "buttonNewCustomer";
            this.buttonNewCustomer.Size = new System.Drawing.Size(233, 89);
            this.buttonNewCustomer.TabIndex = 18;
            this.buttonNewCustomer.Text = "New Customer";
            this.buttonNewCustomer.UseVisualStyleBackColor = false;
            this.buttonNewCustomer.Click += new System.EventHandler(this.buttonNewCustomer_Click);
            // 
            // buttonActiveRental
            // 
            this.buttonActiveRental.BackColor = System.Drawing.Color.Black;
            this.buttonActiveRental.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonActiveRental.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.buttonActiveRental.FlatAppearance.BorderSize = 4;
            this.buttonActiveRental.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.buttonActiveRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActiveRental.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActiveRental.ForeColor = System.Drawing.Color.Transparent;
            this.buttonActiveRental.Location = new System.Drawing.Point(0, 0);
            this.buttonActiveRental.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonActiveRental.Name = "buttonActiveRental";
            this.buttonActiveRental.Size = new System.Drawing.Size(241, 89);
            this.buttonActiveRental.TabIndex = 19;
            this.buttonActiveRental.Text = "Existing Customer";
            this.buttonActiveRental.UseVisualStyleBackColor = false;
            this.buttonActiveRental.Click += new System.EventHandler(this.buttonActiveRental_Click);
            // 
            // labelDueDate
            // 
            this.labelDueDate.AutoSize = true;
            this.labelDueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDueDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelDueDate.Location = new System.Drawing.Point(0, 0);
            this.labelDueDate.Margin = new System.Windows.Forms.Padding(29, 10, 0, 0);
            this.labelDueDate.Name = "labelDueDate";
            this.labelDueDate.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.labelDueDate.Size = new System.Drawing.Size(287, 29);
            this.labelDueDate.TabIndex = 1;
            this.labelDueDate.Text = "Due Withinn 10 Days";
            // 
            // PastDue
            // 
            this.PastDue.AutoSize = true;
            this.PastDue.Dock = System.Windows.Forms.DockStyle.Right;
            this.PastDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PastDue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PastDue.Location = new System.Drawing.Point(877, 0);
            this.PastDue.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.PastDue.Name = "PastDue";
            this.PastDue.Padding = new System.Windows.Forms.Padding(0, 0, 91, 0);
            this.PastDue.Size = new System.Drawing.Size(209, 29);
            this.PastDue.TabIndex = 2;
            this.PastDue.Text = "Past Due";
            // 
            // PanelTitles
            // 
            this.PanelTitles.BackColor = System.Drawing.Color.Maroon;
            this.PanelTitles.Controls.Add(this.PastDue);
            this.PanelTitles.Controls.Add(this.labelDueDate);
            this.PanelTitles.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitles.Location = new System.Drawing.Point(0, 0);
            this.PanelTitles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelTitles.Name = "PanelTitles";
            this.PanelTitles.Size = new System.Drawing.Size(1086, 25);
            this.PanelTitles.TabIndex = 2;
            // 
            // dataGridViewDueIn10
            // 
            this.dataGridViewDueIn10.AllowUserToAddRows = false;
            this.dataGridViewDueIn10.AllowUserToDeleteRows = false;
            this.dataGridViewDueIn10.AllowUserToResizeRows = false;
            this.dataGridViewDueIn10.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDueIn10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dataGridViewDueIn10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDueIn10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.Product,
            this.Rentee,
            this.Due});
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDueIn10.DefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridViewDueIn10.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewDueIn10.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewDueIn10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDueIn10.Name = "dataGridViewDueIn10";
            this.dataGridViewDueIn10.ReadOnly = true;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDueIn10.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.dataGridViewDueIn10.RowHeadersVisible = false;
            this.dataGridViewDueIn10.RowHeadersWidth = 51;
            this.dataGridViewDueIn10.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewDueIn10.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewDueIn10.RowTemplate.Height = 40;
            this.dataGridViewDueIn10.Size = new System.Drawing.Size(301, 595);
            this.dataGridViewDueIn10.TabIndex = 9;
            this.dataGridViewDueIn10.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDueIn10_CellClick);
            // 
            // num
            // 
            this.num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.num.FillWeight = 45F;
            this.num.HeaderText = "#";
            this.num.MinimumWidth = 6;
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product.HeaderText = "Product";
            this.Product.MinimumWidth = 6;
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // Rentee
            // 
            this.Rentee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rentee.HeaderText = "Rentee";
            this.Rentee.MinimumWidth = 6;
            this.Rentee.Name = "Rentee";
            this.Rentee.ReadOnly = true;
            // 
            // Due
            // 
            this.Due.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Due.HeaderText = "Due";
            this.Due.MinimumWidth = 6;
            this.Due.Name = "Due";
            this.Due.ReadOnly = true;
            // 
            // dataGridViewPast30
            // 
            this.dataGridViewPast30.AllowUserToAddRows = false;
            this.dataGridViewPast30.AllowUserToDeleteRows = false;
            this.dataGridViewPast30.AllowUserToResizeRows = false;
            this.dataGridViewPast30.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPast30.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dataGridViewPast30.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPast30.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nums,
            this.Product2,
            this.Rentee2,
            this.DueDate2});
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPast30.DefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridViewPast30.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewPast30.Location = new System.Drawing.Point(785, 25);
            this.dataGridViewPast30.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPast30.Name = "dataGridViewPast30";
            this.dataGridViewPast30.ReadOnly = true;
            this.dataGridViewPast30.RowHeadersVisible = false;
            this.dataGridViewPast30.RowHeadersWidth = 51;
            this.dataGridViewPast30.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPast30.RowTemplate.Height = 40;
            this.dataGridViewPast30.Size = new System.Drawing.Size(301, 595);
            this.dataGridViewPast30.TabIndex = 10;
            this.dataGridViewPast30.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPast30_CellClick);
            // 
            // nums
            // 
            this.nums.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nums.FillWeight = 45F;
            this.nums.HeaderText = "#";
            this.nums.MinimumWidth = 6;
            this.nums.Name = "nums";
            this.nums.ReadOnly = true;
            // 
            // Product2
            // 
            this.Product2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product2.HeaderText = "Product";
            this.Product2.MinimumWidth = 6;
            this.Product2.Name = "Product2";
            this.Product2.ReadOnly = true;
            // 
            // Rentee2
            // 
            this.Rentee2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rentee2.HeaderText = "Rentee";
            this.Rentee2.MinimumWidth = 6;
            this.Rentee2.Name = "Rentee2";
            this.Rentee2.ReadOnly = true;
            // 
            // DueDate2
            // 
            this.DueDate2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DueDate2.HeaderText = "Due";
            this.DueDate2.MinimumWidth = 6;
            this.DueDate2.Name = "DueDate2";
            this.DueDate2.ReadOnly = true;
            // 
            // btnRented
            // 
            this.btnRented.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRented.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRented.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRented.FlatAppearance.BorderSize = 2;
            this.btnRented.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnRented.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRented.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRented.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRented.Location = new System.Drawing.Point(0, 0);
            this.btnRented.Margin = new System.Windows.Forms.Padding(320, 0, 0, 0);
            this.btnRented.Name = "btnRented";
            this.btnRented.Size = new System.Drawing.Size(229, 100);
            this.btnRented.TabIndex = 2;
            this.btnRented.Text = "Rented";
            this.btnRented.UseVisualStyleBackColor = false;
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStock.FlatAppearance.BorderSize = 2;
            this.btnStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStock.Location = new System.Drawing.Point(0, 0);
            this.btnStock.Margin = new System.Windows.Forms.Padding(10000, 0, 0, 0);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(237, 100);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = false;
            // 
            // splitContainerItems
            // 
            this.splitContainerItems.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainerItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerItems.Location = new System.Drawing.Point(301, 25);
            this.splitContainerItems.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.splitContainerItems.Name = "splitContainerItems";
            // 
            // splitContainerItems.Panel1
            // 
            this.splitContainerItems.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainerItems.Panel1.Controls.Add(this.btnHelmets);
            this.splitContainerItems.Panel1.Controls.Add(this.btnPants);
            this.splitContainerItems.Panel1.Controls.Add(this.btnCoats);
            this.splitContainerItems.Panel1.Controls.Add(this.btnRented);
            // 
            // splitContainerItems.Panel2
            // 
            this.splitContainerItems.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainerItems.Panel2.Controls.Add(this.ButtonInStockBoots);
            this.splitContainerItems.Panel2.Controls.Add(this.ButtonInStockHelmets);
            this.splitContainerItems.Panel2.Controls.Add(this.ButtonInStockPants);
            this.splitContainerItems.Panel2.Controls.Add(this.ButtonInStockJackets);
            this.splitContainerItems.Panel2.Controls.Add(this.btnStock);
            this.splitContainerItems.Size = new System.Drawing.Size(484, 595);
            this.splitContainerItems.SplitterDistance = 233;
            this.splitContainerItems.SplitterWidth = 10;
            this.splitContainerItems.TabIndex = 12;
            // 
            // btnHelmets
            // 
            this.btnHelmets.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnHelmets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHelmets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnHelmets.FlatAppearance.BorderSize = 2;
            this.btnHelmets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnHelmets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelmets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelmets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHelmets.Location = new System.Drawing.Point(0, 214);
            this.btnHelmets.Margin = new System.Windows.Forms.Padding(320, 0, 0, 0);
            this.btnHelmets.Name = "btnHelmets";
            this.btnHelmets.Size = new System.Drawing.Size(229, 57);
            this.btnHelmets.TabIndex = 5;
            this.btnHelmets.Text = "Helmets";
            this.btnHelmets.UseVisualStyleBackColor = false;
            // 
            // btnPants
            // 
            this.btnPants.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPants.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPants.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPants.FlatAppearance.BorderSize = 2;
            this.btnPants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnPants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPants.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPants.Location = new System.Drawing.Point(0, 157);
            this.btnPants.Margin = new System.Windows.Forms.Padding(320, 0, 0, 0);
            this.btnPants.Name = "btnPants";
            this.btnPants.Size = new System.Drawing.Size(229, 57);
            this.btnPants.TabIndex = 4;
            this.btnPants.Text = "Pants";
            this.btnPants.UseVisualStyleBackColor = false;
            // 
            // btnCoats
            // 
            this.btnCoats.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCoats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCoats.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCoats.FlatAppearance.BorderSize = 2;
            this.btnCoats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnCoats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoats.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoats.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCoats.Location = new System.Drawing.Point(0, 100);
            this.btnCoats.Margin = new System.Windows.Forms.Padding(320, 0, 0, 0);
            this.btnCoats.Name = "btnCoats";
            this.btnCoats.Size = new System.Drawing.Size(229, 57);
            this.btnCoats.TabIndex = 3;
            this.btnCoats.Text = "Coats";
            this.btnCoats.UseVisualStyleBackColor = false;
            // 
            // ButtonInStockBoots
            // 
            this.ButtonInStockBoots.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonInStockBoots.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonInStockBoots.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonInStockBoots.FlatAppearance.BorderSize = 2;
            this.ButtonInStockBoots.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.ButtonInStockBoots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonInStockBoots.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonInStockBoots.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonInStockBoots.Location = new System.Drawing.Point(0, 271);
            this.ButtonInStockBoots.Margin = new System.Windows.Forms.Padding(10000, 0, 0, 0);
            this.ButtonInStockBoots.Name = "ButtonInStockBoots";
            this.ButtonInStockBoots.Size = new System.Drawing.Size(237, 57);
            this.ButtonInStockBoots.TabIndex = 22;
            this.ButtonInStockBoots.Text = "Boots";
            this.ButtonInStockBoots.UseVisualStyleBackColor = false;
            // 
            // ButtonInStockHelmets
            // 
            this.ButtonInStockHelmets.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonInStockHelmets.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonInStockHelmets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonInStockHelmets.FlatAppearance.BorderSize = 2;
            this.ButtonInStockHelmets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.ButtonInStockHelmets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonInStockHelmets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonInStockHelmets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonInStockHelmets.Location = new System.Drawing.Point(0, 214);
            this.ButtonInStockHelmets.Margin = new System.Windows.Forms.Padding(10000, 0, 0, 0);
            this.ButtonInStockHelmets.Name = "ButtonInStockHelmets";
            this.ButtonInStockHelmets.Size = new System.Drawing.Size(237, 57);
            this.ButtonInStockHelmets.TabIndex = 21;
            this.ButtonInStockHelmets.Text = "Helmets";
            this.ButtonInStockHelmets.UseVisualStyleBackColor = false;
            // 
            // ButtonInStockPants
            // 
            this.ButtonInStockPants.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonInStockPants.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonInStockPants.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonInStockPants.FlatAppearance.BorderSize = 2;
            this.ButtonInStockPants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.ButtonInStockPants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonInStockPants.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonInStockPants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonInStockPants.Location = new System.Drawing.Point(0, 157);
            this.ButtonInStockPants.Margin = new System.Windows.Forms.Padding(10000, 0, 0, 0);
            this.ButtonInStockPants.Name = "ButtonInStockPants";
            this.ButtonInStockPants.Size = new System.Drawing.Size(237, 57);
            this.ButtonInStockPants.TabIndex = 20;
            this.ButtonInStockPants.Text = "Pants";
            this.ButtonInStockPants.UseVisualStyleBackColor = false;
            // 
            // ButtonInStockJackets
            // 
            this.ButtonInStockJackets.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonInStockJackets.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonInStockJackets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonInStockJackets.FlatAppearance.BorderSize = 2;
            this.ButtonInStockJackets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.ButtonInStockJackets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonInStockJackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonInStockJackets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonInStockJackets.Location = new System.Drawing.Point(0, 100);
            this.ButtonInStockJackets.Margin = new System.Windows.Forms.Padding(10000, 0, 0, 0);
            this.ButtonInStockJackets.Name = "ButtonInStockJackets";
            this.ButtonInStockJackets.Size = new System.Drawing.Size(237, 57);
            this.ButtonInStockJackets.TabIndex = 19;
            this.ButtonInStockJackets.Text = "Coats";
            this.ButtonInStockJackets.UseVisualStyleBackColor = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 620);
            this.Controls.Add(this.splitContainerRentalOptions);
            this.Controls.Add(this.splitContainerItems);
            this.Controls.Add(this.dataGridViewPast30);
            this.Controls.Add(this.dataGridViewDueIn10);
            this.Controls.Add(this.PanelTitles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.splitContainerRentalOptions.Panel1.ResumeLayout(false);
            this.splitContainerRentalOptions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRentalOptions)).EndInit();
            this.splitContainerRentalOptions.ResumeLayout(false);
            this.PanelTitles.ResumeLayout(false);
            this.PanelTitles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDueIn10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPast30)).EndInit();
            this.splitContainerItems.Panel1.ResumeLayout(false);
            this.splitContainerItems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerItems)).EndInit();
            this.splitContainerItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerRentalOptions;
        private System.Windows.Forms.Label labelDueDate;
        private System.Windows.Forms.Label PastDue;
        private System.Windows.Forms.Panel PanelTitles;
        private System.Windows.Forms.DataGridView dataGridViewDueIn10;
        private System.Windows.Forms.DataGridView dataGridViewPast30;
        private System.Windows.Forms.SplitContainer splitContainerItems;
        private System.Windows.Forms.Button buttonNewCustomer;
        private System.Windows.Forms.Button buttonActiveRental;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn nums;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate2;
        private System.Windows.Forms.Button btnRented;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnHelmets;
        private System.Windows.Forms.Button btnPants;
        private System.Windows.Forms.Button btnCoats;
        private System.Windows.Forms.Button ButtonInStockBoots;
        private System.Windows.Forms.Button ButtonInStockHelmets;
        private System.Windows.Forms.Button ButtonInStockPants;
        private System.Windows.Forms.Button ButtonInStockJackets;
    }
}