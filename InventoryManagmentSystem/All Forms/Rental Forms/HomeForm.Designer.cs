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
            this.dataGridViewBeforeDue = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewPastDue = new System.Windows.Forms.DataGridView();
            this.nums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rentee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_due2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_count2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnPastDue = new System.Windows.Forms.Button();
            this.splitContainerItems = new System.Windows.Forms.SplitContainer();
            this.btnHelmets = new System.Windows.Forms.Button();
            this.btnPants = new System.Windows.Forms.Button();
            this.btnCoats = new System.Windows.Forms.Button();
            this.btnRented = new System.Windows.Forms.Button();
            this.ButtonInStockBoots = new System.Windows.Forms.Button();
            this.ButtonInStockHelmets = new System.Windows.Forms.Button();
            this.ButtonInStockPants = new System.Windows.Forms.Button();
            this.ButtonInStockJackets = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRentalOptions)).BeginInit();
            this.splitContainerRentalOptions.Panel1.SuspendLayout();
            this.splitContainerRentalOptions.Panel2.SuspendLayout();
            this.splitContainerRentalOptions.SuspendLayout();
            this.PanelTitles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBeforeDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPastDue)).BeginInit();
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
            this.splitContainerRentalOptions.Location = new System.Drawing.Point(452, 830);
            this.splitContainerRentalOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainerRentalOptions.Name = "splitContainerRentalOptions";
            // 
            // splitContainerRentalOptions.Panel1
            // 
            this.splitContainerRentalOptions.Panel1.Controls.Add(this.buttonNewCustomer);
            // 
            // splitContainerRentalOptions.Panel2
            // 
            this.splitContainerRentalOptions.Panel2.Controls.Add(this.buttonActiveRental);
            this.splitContainerRentalOptions.Size = new System.Drawing.Size(724, 139);
            this.splitContainerRentalOptions.SplitterDistance = 342;
            this.splitContainerRentalOptions.SplitterWidth = 16;
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
            this.buttonNewCustomer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonNewCustomer.Name = "buttonNewCustomer";
            this.buttonNewCustomer.Size = new System.Drawing.Size(342, 139);
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
            this.buttonActiveRental.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonActiveRental.Name = "buttonActiveRental";
            this.buttonActiveRental.Size = new System.Drawing.Size(366, 139);
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
            this.labelDueDate.Margin = new System.Windows.Forms.Padding(44, 16, 0, 0);
            this.labelDueDate.Name = "labelDueDate";
            this.labelDueDate.Padding = new System.Windows.Forms.Padding(52, 0, 0, 0);
            this.labelDueDate.Size = new System.Drawing.Size(440, 42);
            this.labelDueDate.TabIndex = 1;
            this.labelDueDate.Text = "Due Withinn 10 Days";
            // 
            // PastDue
            // 
            this.PastDue.AutoSize = true;
            this.PastDue.Dock = System.Windows.Forms.DockStyle.Right;
            this.PastDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PastDue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PastDue.Location = new System.Drawing.Point(1312, 0);
            this.PastDue.Margin = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.PastDue.Name = "PastDue";
            this.PastDue.Padding = new System.Windows.Forms.Padding(0, 0, 136, 0);
            this.PastDue.Size = new System.Drawing.Size(316, 42);
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
            this.PanelTitles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PanelTitles.Name = "PanelTitles";
            this.PanelTitles.Size = new System.Drawing.Size(1628, 39);
            this.PanelTitles.TabIndex = 2;
            // 
            // dataGridViewBeforeDue
            // 
            this.dataGridViewBeforeDue.AllowUserToAddRows = false;
            this.dataGridViewBeforeDue.AllowUserToDeleteRows = false;
            this.dataGridViewBeforeDue.AllowUserToResizeRows = false;
            this.dataGridViewBeforeDue.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBeforeDue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBeforeDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBeforeDue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.column_id,
            this.column_rentee,
            this.column_due,
            this.column_count});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBeforeDue.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBeforeDue.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewBeforeDue.Location = new System.Drawing.Point(0, 39);
            this.dataGridViewBeforeDue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewBeforeDue.Name = "dataGridViewBeforeDue";
            this.dataGridViewBeforeDue.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBeforeDue.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBeforeDue.RowHeadersVisible = false;
            this.dataGridViewBeforeDue.RowHeadersWidth = 51;
            this.dataGridViewBeforeDue.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewBeforeDue.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewBeforeDue.RowTemplate.Height = 40;
            this.dataGridViewBeforeDue.Size = new System.Drawing.Size(452, 930);
            this.dataGridViewBeforeDue.TabIndex = 9;
            this.dataGridViewBeforeDue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBeforeDue_CellClick);
            // 
            // num
            // 
            this.num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.num.FillWeight = 40F;
            this.num.HeaderText = "#";
            this.num.MinimumWidth = 6;
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // column_id
            // 
            this.column_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_id.HeaderText = "Id";
            this.column_id.MinimumWidth = 6;
            this.column_id.Name = "column_id";
            this.column_id.ReadOnly = true;
            this.column_id.Visible = false;
            // 
            // column_rentee
            // 
            this.column_rentee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_rentee.HeaderText = "Rentee";
            this.column_rentee.MinimumWidth = 6;
            this.column_rentee.Name = "column_rentee";
            this.column_rentee.ReadOnly = true;
            // 
            // column_due
            // 
            this.column_due.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_due.FillWeight = 80F;
            this.column_due.HeaderText = "Due";
            this.column_due.MinimumWidth = 6;
            this.column_due.Name = "column_due";
            this.column_due.ReadOnly = true;
            // 
            // column_count
            // 
            this.column_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_count.FillWeight = 60F;
            this.column_count.HeaderText = "Count";
            this.column_count.MinimumWidth = 10;
            this.column_count.Name = "column_count";
            this.column_count.ReadOnly = true;
            // 
            // dataGridViewPastDue
            // 
            this.dataGridViewPastDue.AllowUserToAddRows = false;
            this.dataGridViewPastDue.AllowUserToDeleteRows = false;
            this.dataGridViewPastDue.AllowUserToResizeRows = false;
            this.dataGridViewPastDue.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPastDue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewPastDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPastDue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nums,
            this.column_id2,
            this.column_rentee2,
            this.column_due2,
            this.column_count2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPastDue.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPastDue.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewPastDue.Location = new System.Drawing.Point(1176, 39);
            this.dataGridViewPastDue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewPastDue.Name = "dataGridViewPastDue";
            this.dataGridViewPastDue.ReadOnly = true;
            this.dataGridViewPastDue.RowHeadersVisible = false;
            this.dataGridViewPastDue.RowHeadersWidth = 51;
            this.dataGridViewPastDue.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPastDue.RowTemplate.Height = 40;
            this.dataGridViewPastDue.Size = new System.Drawing.Size(452, 930);
            this.dataGridViewPastDue.TabIndex = 10;
            this.dataGridViewPastDue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPastDue_CellClick);
            // 
            // nums
            // 
            this.nums.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nums.FillWeight = 40F;
            this.nums.HeaderText = "#";
            this.nums.MinimumWidth = 6;
            this.nums.Name = "nums";
            this.nums.ReadOnly = true;
            // 
            // column_id2
            // 
            this.column_id2.HeaderText = "Id";
            this.column_id2.MinimumWidth = 10;
            this.column_id2.Name = "column_id2";
            this.column_id2.ReadOnly = true;
            this.column_id2.Visible = false;
            this.column_id2.Width = 200;
            // 
            // column_rentee2
            // 
            this.column_rentee2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_rentee2.HeaderText = "Rentee";
            this.column_rentee2.MinimumWidth = 6;
            this.column_rentee2.Name = "column_rentee2";
            this.column_rentee2.ReadOnly = true;
            // 
            // column_due2
            // 
            this.column_due2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_due2.FillWeight = 80F;
            this.column_due2.HeaderText = "Due";
            this.column_due2.MinimumWidth = 6;
            this.column_due2.Name = "column_due2";
            this.column_due2.ReadOnly = true;
            // 
            // column_count2
            // 
            this.column_count2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_count2.FillWeight = 60F;
            this.column_count2.HeaderText = "Count";
            this.column_count2.MinimumWidth = 10;
            this.column_count2.Name = "column_count2";
            this.column_count2.ReadOnly = true;
            // 
            // BtnPastDue
            // 
            this.BtnPastDue.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnPastDue.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnPastDue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnPastDue.FlatAppearance.BorderSize = 2;
            this.BtnPastDue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtnPastDue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPastDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPastDue.ForeColor = System.Drawing.Color.Red;
            this.BtnPastDue.Location = new System.Drawing.Point(452, 39);
            this.BtnPastDue.Margin = new System.Windows.Forms.Padding(480, 0, 0, 0);
            this.BtnPastDue.Name = "BtnPastDue";
            this.BtnPastDue.Size = new System.Drawing.Size(724, 156);
            this.BtnPastDue.TabIndex = 18;
            this.BtnPastDue.Text = "Past Due!";
            this.BtnPastDue.UseVisualStyleBackColor = false;
            this.BtnPastDue.Click += new System.EventHandler(this.BtnPastDue_Click);
            // 
            // splitContainerItems
            // 
            this.splitContainerItems.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainerItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerItems.Location = new System.Drawing.Point(452, 195);
            this.splitContainerItems.Margin = new System.Windows.Forms.Padding(20, 22, 20, 22);
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
            this.splitContainerItems.Size = new System.Drawing.Size(724, 635);
            this.splitContainerItems.SplitterDistance = 328;
            this.splitContainerItems.SplitterWidth = 16;
            this.splitContainerItems.TabIndex = 19;
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
            this.btnHelmets.Location = new System.Drawing.Point(0, 334);
            this.btnHelmets.Margin = new System.Windows.Forms.Padding(480, 0, 0, 0);
            this.btnHelmets.Name = "btnHelmets";
            this.btnHelmets.Size = new System.Drawing.Size(324, 89);
            this.btnHelmets.TabIndex = 5;
            this.btnHelmets.Text = "Helmets";
            this.btnHelmets.UseVisualStyleBackColor = false;
            this.btnHelmets.Click += new System.EventHandler(this.btnHelmets_Click_1);
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
            this.btnPants.Location = new System.Drawing.Point(0, 245);
            this.btnPants.Margin = new System.Windows.Forms.Padding(480, 0, 0, 0);
            this.btnPants.Name = "btnPants";
            this.btnPants.Size = new System.Drawing.Size(324, 89);
            this.btnPants.TabIndex = 4;
            this.btnPants.Text = "Pants";
            this.btnPants.UseVisualStyleBackColor = false;
            this.btnPants.Click += new System.EventHandler(this.btnPants_Click_1);
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
            this.btnCoats.Location = new System.Drawing.Point(0, 156);
            this.btnCoats.Margin = new System.Windows.Forms.Padding(480, 0, 0, 0);
            this.btnCoats.Name = "btnCoats";
            this.btnCoats.Size = new System.Drawing.Size(324, 89);
            this.btnCoats.TabIndex = 3;
            this.btnCoats.Text = "Jackets";
            this.btnCoats.UseVisualStyleBackColor = false;
            this.btnCoats.Click += new System.EventHandler(this.btnCoats_Click_1);
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
            this.btnRented.Margin = new System.Windows.Forms.Padding(480, 0, 0, 0);
            this.btnRented.Name = "btnRented";
            this.btnRented.Size = new System.Drawing.Size(324, 156);
            this.btnRented.TabIndex = 2;
            this.btnRented.Text = "Rented";
            this.btnRented.UseVisualStyleBackColor = false;
            this.btnRented.Click += new System.EventHandler(this.btnRented_Click_1);
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
            this.ButtonInStockBoots.Location = new System.Drawing.Point(0, 423);
            this.ButtonInStockBoots.Margin = new System.Windows.Forms.Padding(15000, 0, 0, 0);
            this.ButtonInStockBoots.Name = "ButtonInStockBoots";
            this.ButtonInStockBoots.Size = new System.Drawing.Size(376, 89);
            this.ButtonInStockBoots.TabIndex = 22;
            this.ButtonInStockBoots.Text = "Boots";
            this.ButtonInStockBoots.UseVisualStyleBackColor = false;
            this.ButtonInStockBoots.Click += new System.EventHandler(this.ButtonInStockBoots_Click_1);
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
            this.ButtonInStockHelmets.Location = new System.Drawing.Point(0, 334);
            this.ButtonInStockHelmets.Margin = new System.Windows.Forms.Padding(15000, 0, 0, 0);
            this.ButtonInStockHelmets.Name = "ButtonInStockHelmets";
            this.ButtonInStockHelmets.Size = new System.Drawing.Size(376, 89);
            this.ButtonInStockHelmets.TabIndex = 21;
            this.ButtonInStockHelmets.Text = "Helmets";
            this.ButtonInStockHelmets.UseVisualStyleBackColor = false;
            this.ButtonInStockHelmets.Click += new System.EventHandler(this.ButtonInStockHelmets_Click_1);
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
            this.ButtonInStockPants.Location = new System.Drawing.Point(0, 245);
            this.ButtonInStockPants.Margin = new System.Windows.Forms.Padding(15000, 0, 0, 0);
            this.ButtonInStockPants.Name = "ButtonInStockPants";
            this.ButtonInStockPants.Size = new System.Drawing.Size(376, 89);
            this.ButtonInStockPants.TabIndex = 20;
            this.ButtonInStockPants.Text = "Pants";
            this.ButtonInStockPants.UseVisualStyleBackColor = false;
            this.ButtonInStockPants.Click += new System.EventHandler(this.ButtonInStockPants_Click_1);
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
            this.ButtonInStockJackets.Location = new System.Drawing.Point(0, 156);
            this.ButtonInStockJackets.Margin = new System.Windows.Forms.Padding(15000, 0, 0, 0);
            this.ButtonInStockJackets.Name = "ButtonInStockJackets";
            this.ButtonInStockJackets.Size = new System.Drawing.Size(376, 89);
            this.ButtonInStockJackets.TabIndex = 19;
            this.ButtonInStockJackets.Text = "Jackets";
            this.ButtonInStockJackets.UseVisualStyleBackColor = false;
            this.ButtonInStockJackets.Click += new System.EventHandler(this.ButtonInStockJackets_Click);
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
            this.btnStock.Margin = new System.Windows.Forms.Padding(15000, 0, 0, 0);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(376, 156);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click_1);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1628, 969);
            this.Controls.Add(this.splitContainerItems);
            this.Controls.Add(this.BtnPastDue);
            this.Controls.Add(this.splitContainerRentalOptions);
            this.Controls.Add(this.dataGridViewPastDue);
            this.Controls.Add(this.dataGridViewBeforeDue);
            this.Controls.Add(this.PanelTitles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.splitContainerRentalOptions.Panel1.ResumeLayout(false);
            this.splitContainerRentalOptions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRentalOptions)).EndInit();
            this.splitContainerRentalOptions.ResumeLayout(false);
            this.PanelTitles.ResumeLayout(false);
            this.PanelTitles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBeforeDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPastDue)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridViewBeforeDue;
        private System.Windows.Forms.DataGridView dataGridViewPastDue;
        private System.Windows.Forms.Button buttonNewCustomer;
        private System.Windows.Forms.Button buttonActiveRental;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_due;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn nums;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rentee2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_due2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_count2;
        private System.Windows.Forms.Button BtnPastDue;
        private System.Windows.Forms.SplitContainer splitContainerItems;
        private System.Windows.Forms.Button btnHelmets;
        private System.Windows.Forms.Button btnPants;
        private System.Windows.Forms.Button btnCoats;
        private System.Windows.Forms.Button btnRented;
        private System.Windows.Forms.Button ButtonInStockBoots;
        private System.Windows.Forms.Button ButtonInStockHelmets;
        private System.Windows.Forms.Button ButtonInStockPants;
        private System.Windows.Forms.Button ButtonInStockJackets;
        private System.Windows.Forms.Button btnStock;
    }
}