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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerRentalOptions = new System.Windows.Forms.SplitContainer();
            this.buttonNewCustomer = new System.Windows.Forms.Button();
            this.buttonActiveRental = new System.Windows.Forms.Button();
            this.labelDueDate = new System.Windows.Forms.Label();
            this.PastDue = new System.Windows.Forms.Label();
            this.PanelTitles = new System.Windows.Forms.Panel();
            this.Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDueIn10 = new System.Windows.Forms.DataGridView();
            this.DueDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewPast30 = new System.Windows.Forms.DataGridView();
            this.ButtonCurrentlyRented = new System.Windows.Forms.Button();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.ButtonCurrentlyRentedJackets = new System.Windows.Forms.Button();
            this.ButtonCurrentlyRentedPants = new System.Windows.Forms.Button();
            this.splitContainerPantsJackets = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRentalOptions)).BeginInit();
            this.splitContainerRentalOptions.Panel1.SuspendLayout();
            this.splitContainerRentalOptions.Panel2.SuspendLayout();
            this.splitContainerRentalOptions.SuspendLayout();
            this.PanelTitles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDueIn10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPast30)).BeginInit();
            this.panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPantsJackets)).BeginInit();
            this.splitContainerPantsJackets.Panel1.SuspendLayout();
            this.splitContainerPantsJackets.Panel2.SuspendLayout();
            this.splitContainerPantsJackets.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerRentalOptions
            // 
            this.splitContainerRentalOptions.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerRentalOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainerRentalOptions.Location = new System.Drawing.Point(716, 1238);
            this.splitContainerRentalOptions.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainerRentalOptions.Name = "splitContainerRentalOptions";
            // 
            // splitContainerRentalOptions.Panel1
            // 
            this.splitContainerRentalOptions.Panel1.Controls.Add(this.buttonNewCustomer);
            // 
            // splitContainerRentalOptions.Panel2
            // 
            this.splitContainerRentalOptions.Panel2.Controls.Add(this.buttonActiveRental);
            this.splitContainerRentalOptions.Size = new System.Drawing.Size(1310, 205);
            this.splitContainerRentalOptions.SplitterDistance = 645;
            this.splitContainerRentalOptions.SplitterWidth = 10;
            this.splitContainerRentalOptions.TabIndex = 17;
            // 
            // buttonNewCustomer
            // 
            this.buttonNewCustomer.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonNewCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.buttonNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewCustomer.ForeColor = System.Drawing.Color.Transparent;
            this.buttonNewCustomer.Location = new System.Drawing.Point(0, 0);
            this.buttonNewCustomer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonNewCustomer.Name = "buttonNewCustomer";
            this.buttonNewCustomer.Size = new System.Drawing.Size(645, 205);
            this.buttonNewCustomer.TabIndex = 18;
            this.buttonNewCustomer.Text = "New Customer";
            this.buttonNewCustomer.UseVisualStyleBackColor = false;
            this.buttonNewCustomer.Click += new System.EventHandler(this.buttonNewCustomer_Click);
            // 
            // buttonActiveRental
            // 
            this.buttonActiveRental.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonActiveRental.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonActiveRental.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.buttonActiveRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActiveRental.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActiveRental.ForeColor = System.Drawing.Color.Transparent;
            this.buttonActiveRental.Location = new System.Drawing.Point(0, 0);
            this.buttonActiveRental.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonActiveRental.Name = "buttonActiveRental";
            this.buttonActiveRental.Size = new System.Drawing.Size(655, 205);
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
            this.labelDueDate.Margin = new System.Windows.Forms.Padding(70, 23, 0, 0);
            this.labelDueDate.Name = "labelDueDate";
            this.labelDueDate.Padding = new System.Windows.Forms.Padding(82, 0, 0, 0);
            this.labelDueDate.Size = new System.Drawing.Size(652, 64);
            this.labelDueDate.TabIndex = 1;
            this.labelDueDate.Text = "Due Withinn 10 Days";
            // 
            // PastDue
            // 
            this.PastDue.AutoSize = true;
            this.PastDue.Dock = System.Windows.Forms.DockStyle.Right;
            this.PastDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PastDue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PastDue.Location = new System.Drawing.Point(2263, 0);
            this.PastDue.Margin = new System.Windows.Forms.Padding(0, 23, 0, 0);
            this.PastDue.Name = "PastDue";
            this.PastDue.Padding = new System.Windows.Forms.Padding(0, 0, 215, 0);
            this.PastDue.Size = new System.Drawing.Size(479, 64);
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
            this.PanelTitles.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PanelTitles.Name = "PanelTitles";
            this.PanelTitles.Size = new System.Drawing.Size(2742, 57);
            this.PanelTitles.TabIndex = 2;
            // 
            // Due
            // 
            this.Due.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Due.HeaderText = "Due";
            this.Due.MinimumWidth = 6;
            this.Due.Name = "Due";
            this.Due.ReadOnly = true;
            // 
            // Rentee
            // 
            this.Rentee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rentee.HeaderText = "Rentee";
            this.Rentee.MinimumWidth = 6;
            this.Rentee.Name = "Rentee";
            this.Rentee.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product.HeaderText = "Product";
            this.Product.MinimumWidth = 6;
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // num
            // 
            this.num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.num.FillWeight = 30F;
            this.num.HeaderText = "#";
            this.num.MinimumWidth = 6;
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // dataGridViewDueIn10
            // 
            this.dataGridViewDueIn10.AllowUserToAddRows = false;
            this.dataGridViewDueIn10.AllowUserToDeleteRows = false;
            this.dataGridViewDueIn10.AllowUserToResizeRows = false;
            this.dataGridViewDueIn10.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDueIn10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDueIn10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDueIn10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.Product,
            this.Rentee,
            this.Due});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDueIn10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDueIn10.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewDueIn10.Location = new System.Drawing.Point(0, 57);
            this.dataGridViewDueIn10.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridViewDueIn10.Name = "dataGridViewDueIn10";
            this.dataGridViewDueIn10.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDueIn10.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDueIn10.RowHeadersVisible = false;
            this.dataGridViewDueIn10.RowHeadersWidth = 51;
            this.dataGridViewDueIn10.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewDueIn10.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewDueIn10.RowTemplate.Height = 40;
            this.dataGridViewDueIn10.Size = new System.Drawing.Size(716, 1386);
            this.dataGridViewDueIn10.TabIndex = 9;
            this.dataGridViewDueIn10.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDueIn10_CellClick);
            // 
            // DueDate2
            // 
            this.DueDate2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DueDate2.HeaderText = "Due";
            this.DueDate2.MinimumWidth = 6;
            this.DueDate2.Name = "DueDate2";
            this.DueDate2.ReadOnly = true;
            // 
            // Rentee2
            // 
            this.Rentee2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rentee2.HeaderText = "Rentee";
            this.Rentee2.MinimumWidth = 6;
            this.Rentee2.Name = "Rentee2";
            this.Rentee2.ReadOnly = true;
            // 
            // Product2
            // 
            this.Product2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product2.HeaderText = "Product";
            this.Product2.MinimumWidth = 6;
            this.Product2.Name = "Product2";
            this.Product2.ReadOnly = true;
            // 
            // nums
            // 
            this.nums.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nums.FillWeight = 30F;
            this.nums.HeaderText = "#";
            this.nums.MinimumWidth = 6;
            this.nums.Name = "nums";
            this.nums.ReadOnly = true;
            // 
            // dataGridViewPast30
            // 
            this.dataGridViewPast30.AllowUserToAddRows = false;
            this.dataGridViewPast30.AllowUserToDeleteRows = false;
            this.dataGridViewPast30.AllowUserToResizeRows = false;
            this.dataGridViewPast30.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPast30.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewPast30.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPast30.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nums,
            this.Product2,
            this.Rentee2,
            this.DueDate2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPast30.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPast30.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewPast30.Location = new System.Drawing.Point(2026, 57);
            this.dataGridViewPast30.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridViewPast30.Name = "dataGridViewPast30";
            this.dataGridViewPast30.ReadOnly = true;
            this.dataGridViewPast30.RowHeadersVisible = false;
            this.dataGridViewPast30.RowHeadersWidth = 51;
            this.dataGridViewPast30.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPast30.RowTemplate.Height = 40;
            this.dataGridViewPast30.Size = new System.Drawing.Size(716, 1386);
            this.dataGridViewPast30.TabIndex = 10;
            this.dataGridViewPast30.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPast30_CellClick);
            // 
            // ButtonCurrentlyRented
            // 
            this.ButtonCurrentlyRented.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonCurrentlyRented.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCurrentlyRented.FlatAppearance.BorderSize = 0;
            this.ButtonCurrentlyRented.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.ButtonCurrentlyRented.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCurrentlyRented.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCurrentlyRented.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCurrentlyRented.Location = new System.Drawing.Point(32, 31);
            this.ButtonCurrentlyRented.Margin = new System.Windows.Forms.Padding(238, 117, 238, 0);
            this.ButtonCurrentlyRented.Name = "ButtonCurrentlyRented";
            this.ButtonCurrentlyRented.Size = new System.Drawing.Size(1246, 316);
            this.ButtonCurrentlyRented.TabIndex = 2;
            this.ButtonCurrentlyRented.Text = "Currently Rented";
            this.ButtonCurrentlyRented.UseVisualStyleBackColor = false;
            this.ButtonCurrentlyRented.Click += new System.EventHandler(this.ButtonCurrentlyRented_Click_1);
            // 
            // panelTotal
            // 
            this.panelTotal.Controls.Add(this.ButtonCurrentlyRented);
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTotal.Location = new System.Drawing.Point(716, 57);
            this.panelTotal.Margin = new System.Windows.Forms.Padding(48, 46, 48, 46);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Padding = new System.Windows.Forms.Padding(32, 31, 32, 0);
            this.panelTotal.Size = new System.Drawing.Size(1310, 347);
            this.panelTotal.TabIndex = 11;
            // 
            // ButtonCurrentlyRentedJackets
            // 
            this.ButtonCurrentlyRentedJackets.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonCurrentlyRentedJackets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCurrentlyRentedJackets.FlatAppearance.BorderSize = 2;
            this.ButtonCurrentlyRentedJackets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.ButtonCurrentlyRentedJackets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCurrentlyRentedJackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCurrentlyRentedJackets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCurrentlyRentedJackets.Location = new System.Drawing.Point(0, 0);
            this.ButtonCurrentlyRentedJackets.Margin = new System.Windows.Forms.Padding(760, 0, 0, 0);
            this.ButtonCurrentlyRentedJackets.Name = "ButtonCurrentlyRentedJackets";
            this.ButtonCurrentlyRentedJackets.Size = new System.Drawing.Size(658, 231);
            this.ButtonCurrentlyRentedJackets.TabIndex = 1;
            this.ButtonCurrentlyRentedJackets.Text = "Coats";
            this.ButtonCurrentlyRentedJackets.UseVisualStyleBackColor = false;
            this.ButtonCurrentlyRentedJackets.Click += new System.EventHandler(this.ButtonCurrentlyRentedJackets_Click);
            // 
            // ButtonCurrentlyRentedPants
            // 
            this.ButtonCurrentlyRentedPants.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonCurrentlyRentedPants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCurrentlyRentedPants.FlatAppearance.BorderSize = 2;
            this.ButtonCurrentlyRentedPants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.ButtonCurrentlyRentedPants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCurrentlyRentedPants.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCurrentlyRentedPants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCurrentlyRentedPants.Location = new System.Drawing.Point(0, 0);
            this.ButtonCurrentlyRentedPants.Margin = new System.Windows.Forms.Padding(32, 31, 32, 31);
            this.ButtonCurrentlyRentedPants.Name = "ButtonCurrentlyRentedPants";
            this.ButtonCurrentlyRentedPants.Padding = new System.Windows.Forms.Padding(32, 31, 32, 31);
            this.ButtonCurrentlyRentedPants.Size = new System.Drawing.Size(642, 231);
            this.ButtonCurrentlyRentedPants.TabIndex = 4;
            this.ButtonCurrentlyRentedPants.Text = "Pants";
            this.ButtonCurrentlyRentedPants.UseVisualStyleBackColor = false;
            this.ButtonCurrentlyRentedPants.Click += new System.EventHandler(this.ButtonCurrentlyRentedPants_Click);
            // 
            // splitContainerPantsJackets
            // 
            this.splitContainerPantsJackets.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerPantsJackets.Location = new System.Drawing.Point(716, 404);
            this.splitContainerPantsJackets.Margin = new System.Windows.Forms.Padding(32, 31, 32, 31);
            this.splitContainerPantsJackets.Name = "splitContainerPantsJackets";
            // 
            // splitContainerPantsJackets.Panel1
            // 
            this.splitContainerPantsJackets.Panel1.Controls.Add(this.ButtonCurrentlyRentedPants);
            // 
            // splitContainerPantsJackets.Panel2
            // 
            this.splitContainerPantsJackets.Panel2.Controls.Add(this.ButtonCurrentlyRentedJackets);
            this.splitContainerPantsJackets.Size = new System.Drawing.Size(1310, 231);
            this.splitContainerPantsJackets.SplitterDistance = 642;
            this.splitContainerPantsJackets.SplitterWidth = 10;
            this.splitContainerPantsJackets.TabIndex = 12;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2742, 1443);
            this.Controls.Add(this.splitContainerRentalOptions);
            this.Controls.Add(this.splitContainerPantsJackets);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.dataGridViewPast30);
            this.Controls.Add(this.dataGridViewDueIn10);
            this.Controls.Add(this.PanelTitles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.panelTotal.ResumeLayout(false);
            this.splitContainerPantsJackets.Panel1.ResumeLayout(false);
            this.splitContainerPantsJackets.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPantsJackets)).EndInit();
            this.splitContainerPantsJackets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerRentalOptions;
        private System.Windows.Forms.Label labelDueDate;
        private System.Windows.Forms.Label PastDue;
        private System.Windows.Forms.Panel PanelTitles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridView dataGridViewDueIn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nums;
        private System.Windows.Forms.DataGridView dataGridViewPast30;
        private System.Windows.Forms.Button ButtonCurrentlyRented;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Button ButtonCurrentlyRentedJackets;
        private System.Windows.Forms.Button ButtonCurrentlyRentedPants;
        private System.Windows.Forms.SplitContainer splitContainerPantsJackets;
        private System.Windows.Forms.Button buttonNewCustomer;
        private System.Windows.Forms.Button buttonActiveRental;
    }
}