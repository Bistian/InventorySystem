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
            this.splitContainerRentalOptions = new System.Windows.Forms.SplitContainer();
            this.btn_new_customer = new System.Windows.Forms.Button();
            this.btn_existing_customer = new System.Windows.Forms.Button();
            this.label_due_date = new System.Windows.Forms.Label();
            this.label_past_due = new System.Windows.Forms.Label();
            this.PanelTitles = new System.Windows.Forms.Panel();
            this.grid_before_due = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_past_due = new System.Windows.Forms.DataGridView();
            this.nums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rentee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_due2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_count2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_past_due = new System.Windows.Forms.Button();
            this.splitContainerItems = new System.Windows.Forms.SplitContainer();
            this.label_date_rented = new System.Windows.Forms.Label();
            this.btn_helmets = new System.Windows.Forms.Button();
            this.btn_pants = new System.Windows.Forms.Button();
            this.btn_jackets = new System.Windows.Forms.Button();
            this.btn_rented = new System.Windows.Forms.Button();
            this.btn_stock_boots = new System.Windows.Forms.Button();
            this.btn_stock_helmets = new System.Windows.Forms.Button();
            this.btn_stock_pants = new System.Windows.Forms.Button();
            this.btn_stock_jackets = new System.Windows.Forms.Button();
            this.btn_stock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRentalOptions)).BeginInit();
            this.splitContainerRentalOptions.Panel1.SuspendLayout();
            this.splitContainerRentalOptions.Panel2.SuspendLayout();
            this.splitContainerRentalOptions.SuspendLayout();
            this.PanelTitles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_before_due)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_past_due)).BeginInit();
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
            this.splitContainerRentalOptions.Location = new System.Drawing.Point(226, 432);
            this.splitContainerRentalOptions.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerRentalOptions.Name = "splitContainerRentalOptions";
            // 
            // splitContainerRentalOptions.Panel1
            // 
            this.splitContainerRentalOptions.Panel1.Controls.Add(this.btn_new_customer);
            // 
            // splitContainerRentalOptions.Panel2
            // 
            this.splitContainerRentalOptions.Panel2.Controls.Add(this.btn_existing_customer);
            this.splitContainerRentalOptions.Size = new System.Drawing.Size(362, 72);
            this.splitContainerRentalOptions.SplitterDistance = 169;
            this.splitContainerRentalOptions.SplitterWidth = 8;
            this.splitContainerRentalOptions.TabIndex = 17;
            // 
            // btn_new_customer
            // 
            this.btn_new_customer.BackColor = System.Drawing.Color.Black;
            this.btn_new_customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_new_customer.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btn_new_customer.FlatAppearance.BorderSize = 4;
            this.btn_new_customer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_new_customer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_customer.ForeColor = System.Drawing.Color.Transparent;
            this.btn_new_customer.Location = new System.Drawing.Point(0, 0);
            this.btn_new_customer.Margin = new System.Windows.Forms.Padding(2);
            this.btn_new_customer.Name = "btn_new_customer";
            this.btn_new_customer.Size = new System.Drawing.Size(169, 72);
            this.btn_new_customer.TabIndex = 18;
            this.btn_new_customer.Text = "New Customer";
            this.btn_new_customer.UseVisualStyleBackColor = false;
            this.btn_new_customer.Click += new System.EventHandler(this.buttonNewCustomer_Click);
            // 
            // btn_existing_customer
            // 
            this.btn_existing_customer.BackColor = System.Drawing.Color.Black;
            this.btn_existing_customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_existing_customer.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btn_existing_customer.FlatAppearance.BorderSize = 4;
            this.btn_existing_customer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_existing_customer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_existing_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_existing_customer.ForeColor = System.Drawing.Color.Transparent;
            this.btn_existing_customer.Location = new System.Drawing.Point(0, 0);
            this.btn_existing_customer.Margin = new System.Windows.Forms.Padding(2);
            this.btn_existing_customer.Name = "btn_existing_customer";
            this.btn_existing_customer.Size = new System.Drawing.Size(185, 72);
            this.btn_existing_customer.TabIndex = 19;
            this.btn_existing_customer.Text = "Existing Customer";
            this.btn_existing_customer.UseVisualStyleBackColor = false;
            this.btn_existing_customer.Click += new System.EventHandler(this.buttonActiveRental_Click);
            // 
            // label_due_date
            // 
            this.label_due_date.AutoSize = true;
            this.label_due_date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_due_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_due_date.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_due_date.Location = new System.Drawing.Point(0, 0);
            this.label_due_date.Margin = new System.Windows.Forms.Padding(22, 8, 0, 0);
            this.label_due_date.Name = "label_due_date";
            this.label_due_date.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.label_due_date.Size = new System.Drawing.Size(229, 24);
            this.label_due_date.TabIndex = 1;
            this.label_due_date.Text = "Due Withinn 10 Days";
            // 
            // label_past_due
            // 
            this.label_past_due.AutoSize = true;
            this.label_past_due.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_past_due.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_past_due.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_past_due.Location = new System.Drawing.Point(653, 0);
            this.label_past_due.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label_past_due.Name = "label_past_due";
            this.label_past_due.Padding = new System.Windows.Forms.Padding(0, 0, 68, 0);
            this.label_past_due.Size = new System.Drawing.Size(161, 24);
            this.label_past_due.TabIndex = 2;
            this.label_past_due.Text = "Past Due";
            // 
            // PanelTitles
            // 
            this.PanelTitles.BackColor = System.Drawing.Color.Maroon;
            this.PanelTitles.Controls.Add(this.label_past_due);
            this.PanelTitles.Controls.Add(this.label_due_date);
            this.PanelTitles.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitles.Location = new System.Drawing.Point(0, 0);
            this.PanelTitles.Margin = new System.Windows.Forms.Padding(2);
            this.PanelTitles.Name = "PanelTitles";
            this.PanelTitles.Size = new System.Drawing.Size(814, 20);
            this.PanelTitles.TabIndex = 2;
            // 
            // grid_before_due
            // 
            this.grid_before_due.AllowUserToAddRows = false;
            this.grid_before_due.AllowUserToDeleteRows = false;
            this.grid_before_due.AllowUserToResizeRows = false;
            this.grid_before_due.BackgroundColor = System.Drawing.Color.Maroon;
            this.grid_before_due.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_before_due.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.column_id,
            this.column_rentee,
            this.column_due,
            this.column_count});
            this.grid_before_due.Dock = System.Windows.Forms.DockStyle.Left;
            this.grid_before_due.Location = new System.Drawing.Point(0, 20);
            this.grid_before_due.Margin = new System.Windows.Forms.Padding(2);
            this.grid_before_due.Name = "grid_before_due";
            this.grid_before_due.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_before_due.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_before_due.RowHeadersVisible = false;
            this.grid_before_due.RowHeadersWidth = 51;
            this.grid_before_due.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_before_due.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.grid_before_due.RowTemplate.Height = 40;
            this.grid_before_due.Size = new System.Drawing.Size(226, 484);
            this.grid_before_due.TabIndex = 9;
            this.grid_before_due.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBeforeDue_CellClick);
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
            // grid_past_due
            // 
            this.grid_past_due.AllowUserToAddRows = false;
            this.grid_past_due.AllowUserToDeleteRows = false;
            this.grid_past_due.AllowUserToResizeRows = false;
            this.grid_past_due.BackgroundColor = System.Drawing.Color.Maroon;
            this.grid_past_due.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_past_due.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nums,
            this.column_id2,
            this.column_rentee2,
            this.column_due2,
            this.column_count2});
            this.grid_past_due.Dock = System.Windows.Forms.DockStyle.Right;
            this.grid_past_due.Location = new System.Drawing.Point(588, 20);
            this.grid_past_due.Margin = new System.Windows.Forms.Padding(2);
            this.grid_past_due.Name = "grid_past_due";
            this.grid_past_due.ReadOnly = true;
            this.grid_past_due.RowHeadersVisible = false;
            this.grid_past_due.RowHeadersWidth = 51;
            this.grid_past_due.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_past_due.RowTemplate.Height = 40;
            this.grid_past_due.Size = new System.Drawing.Size(226, 484);
            this.grid_past_due.TabIndex = 10;
            this.grid_past_due.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPastDue_CellClick);
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
            // btn_past_due
            // 
            this.btn_past_due.AutoSize = true;
            this.btn_past_due.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_past_due.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_past_due.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_past_due.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_past_due.FlatAppearance.BorderSize = 2;
            this.btn_past_due.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_past_due.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_past_due.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_past_due.ForeColor = System.Drawing.Color.Red;
            this.btn_past_due.Location = new System.Drawing.Point(226, 20);
            this.btn_past_due.Margin = new System.Windows.Forms.Padding(240, 0, 0, 0);
            this.btn_past_due.Name = "btn_past_due";
            this.btn_past_due.Size = new System.Drawing.Size(362, 51);
            this.btn_past_due.TabIndex = 18;
            this.btn_past_due.Text = "Past Due!";
            this.btn_past_due.UseVisualStyleBackColor = false;
            // 
            // splitContainerItems
            // 
            this.splitContainerItems.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainerItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerItems.Location = new System.Drawing.Point(226, 71);
            this.splitContainerItems.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.splitContainerItems.Name = "splitContainerItems";
            // 
            // splitContainerItems.Panel1
            // 
            this.splitContainerItems.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainerItems.Panel1.Controls.Add(this.label_date_rented);
            this.splitContainerItems.Panel1.Controls.Add(this.btn_helmets);
            this.splitContainerItems.Panel1.Controls.Add(this.btn_pants);
            this.splitContainerItems.Panel1.Controls.Add(this.btn_jackets);
            this.splitContainerItems.Panel1.Controls.Add(this.btn_rented);
            // 
            // splitContainerItems.Panel2
            // 
            this.splitContainerItems.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainerItems.Panel2.Controls.Add(this.btn_stock_boots);
            this.splitContainerItems.Panel2.Controls.Add(this.btn_stock_helmets);
            this.splitContainerItems.Panel2.Controls.Add(this.btn_stock_pants);
            this.splitContainerItems.Panel2.Controls.Add(this.btn_stock_jackets);
            this.splitContainerItems.Panel2.Controls.Add(this.btn_stock);
            this.splitContainerItems.Size = new System.Drawing.Size(362, 361);
            this.splitContainerItems.SplitterDistance = 161;
            this.splitContainerItems.SplitterWidth = 8;
            this.splitContainerItems.TabIndex = 19;
            // 
            // label_date_rented
            // 
            this.label_date_rented.AutoSize = true;
            this.label_date_rented.Location = new System.Drawing.Point(4, 4);
            this.label_date_rented.Name = "label_date_rented";
            this.label_date_rented.Size = new System.Drawing.Size(68, 13);
            this.label_date_rented.TabIndex = 6;
            this.label_date_rented.Text = "Date Rented";
            // 
            // btn_helmets
            // 
            this.btn_helmets.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_helmets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_helmets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_helmets.FlatAppearance.BorderSize = 2;
            this.btn_helmets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_helmets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_helmets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_helmets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_helmets.Location = new System.Drawing.Point(0, 143);
            this.btn_helmets.Margin = new System.Windows.Forms.Padding(240, 0, 0, 0);
            this.btn_helmets.Name = "btn_helmets";
            this.btn_helmets.Size = new System.Drawing.Size(157, 46);
            this.btn_helmets.TabIndex = 5;
            this.btn_helmets.Text = "Helmets";
            this.btn_helmets.UseVisualStyleBackColor = false;
            // 
            // btn_pants
            // 
            this.btn_pants.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_pants.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_pants.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_pants.FlatAppearance.BorderSize = 2;
            this.btn_pants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_pants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pants.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pants.Location = new System.Drawing.Point(0, 97);
            this.btn_pants.Margin = new System.Windows.Forms.Padding(240, 0, 0, 0);
            this.btn_pants.Name = "btn_pants";
            this.btn_pants.Size = new System.Drawing.Size(157, 46);
            this.btn_pants.TabIndex = 4;
            this.btn_pants.Text = "Pants";
            this.btn_pants.UseVisualStyleBackColor = false;
            this.btn_pants.Click += new System.EventHandler(this.btnPants_Click_1);
            // 
            // btn_jackets
            // 
            this.btn_jackets.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_jackets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_jackets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_jackets.FlatAppearance.BorderSize = 2;
            this.btn_jackets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_jackets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_jackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_jackets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_jackets.Location = new System.Drawing.Point(0, 51);
            this.btn_jackets.Margin = new System.Windows.Forms.Padding(240, 0, 0, 0);
            this.btn_jackets.Name = "btn_jackets";
            this.btn_jackets.Size = new System.Drawing.Size(157, 46);
            this.btn_jackets.TabIndex = 3;
            this.btn_jackets.Text = "Jackets";
            this.btn_jackets.UseVisualStyleBackColor = false;
            // 
            // btn_rented
            // 
            this.btn_rented.AutoSize = true;
            this.btn_rented.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_rented.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_rented.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_rented.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_rented.FlatAppearance.BorderSize = 2;
            this.btn_rented.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_rented.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rented.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rented.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_rented.Location = new System.Drawing.Point(0, 0);
            this.btn_rented.Margin = new System.Windows.Forms.Padding(240, 0, 0, 0);
            this.btn_rented.Name = "btn_rented";
            this.btn_rented.Size = new System.Drawing.Size(157, 51);
            this.btn_rented.TabIndex = 2;
            this.btn_rented.Text = "Rented";
            this.btn_rented.UseVisualStyleBackColor = false;
            // 
            // btn_stock_boots
            // 
            this.btn_stock_boots.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock_boots.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_stock_boots.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock_boots.FlatAppearance.BorderSize = 2;
            this.btn_stock_boots.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock_boots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock_boots.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock_boots.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock_boots.Location = new System.Drawing.Point(0, 189);
            this.btn_stock_boots.Margin = new System.Windows.Forms.Padding(7500, 0, 0, 0);
            this.btn_stock_boots.Name = "btn_stock_boots";
            this.btn_stock_boots.Size = new System.Drawing.Size(189, 46);
            this.btn_stock_boots.TabIndex = 22;
            this.btn_stock_boots.Text = "Boots";
            this.btn_stock_boots.UseVisualStyleBackColor = false;
            // 
            // btn_stock_helmets
            // 
            this.btn_stock_helmets.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock_helmets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_stock_helmets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock_helmets.FlatAppearance.BorderSize = 2;
            this.btn_stock_helmets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock_helmets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock_helmets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock_helmets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock_helmets.Location = new System.Drawing.Point(0, 143);
            this.btn_stock_helmets.Margin = new System.Windows.Forms.Padding(7500, 0, 0, 0);
            this.btn_stock_helmets.Name = "btn_stock_helmets";
            this.btn_stock_helmets.Size = new System.Drawing.Size(189, 46);
            this.btn_stock_helmets.TabIndex = 21;
            this.btn_stock_helmets.Text = "Helmets";
            this.btn_stock_helmets.UseVisualStyleBackColor = false;
            // 
            // btn_stock_pants
            // 
            this.btn_stock_pants.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock_pants.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_stock_pants.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock_pants.FlatAppearance.BorderSize = 2;
            this.btn_stock_pants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock_pants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock_pants.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock_pants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock_pants.Location = new System.Drawing.Point(0, 97);
            this.btn_stock_pants.Margin = new System.Windows.Forms.Padding(7500, 0, 0, 0);
            this.btn_stock_pants.Name = "btn_stock_pants";
            this.btn_stock_pants.Size = new System.Drawing.Size(189, 46);
            this.btn_stock_pants.TabIndex = 20;
            this.btn_stock_pants.Text = "Pants";
            this.btn_stock_pants.UseVisualStyleBackColor = false;
            // 
            // btn_stock_jackets
            // 
            this.btn_stock_jackets.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock_jackets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_stock_jackets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock_jackets.FlatAppearance.BorderSize = 2;
            this.btn_stock_jackets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock_jackets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock_jackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock_jackets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock_jackets.Location = new System.Drawing.Point(0, 51);
            this.btn_stock_jackets.Margin = new System.Windows.Forms.Padding(7500, 0, 0, 0);
            this.btn_stock_jackets.Name = "btn_stock_jackets";
            this.btn_stock_jackets.Size = new System.Drawing.Size(189, 46);
            this.btn_stock_jackets.TabIndex = 19;
            this.btn_stock_jackets.Text = "Jackets";
            this.btn_stock_jackets.UseVisualStyleBackColor = false;
            // 
            // btn_stock
            // 
            this.btn_stock.AutoSize = true;
            this.btn_stock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_stock.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_stock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock.FlatAppearance.BorderSize = 2;
            this.btn_stock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock.Location = new System.Drawing.Point(0, 0);
            this.btn_stock.Margin = new System.Windows.Forms.Padding(7500, 0, 0, 0);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Size = new System.Drawing.Size(189, 51);
            this.btn_stock.TabIndex = 2;
            this.btn_stock.Text = "Stock";
            this.btn_stock.UseVisualStyleBackColor = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 504);
            this.Controls.Add(this.splitContainerItems);
            this.Controls.Add(this.btn_past_due);
            this.Controls.Add(this.splitContainerRentalOptions);
            this.Controls.Add(this.grid_past_due);
            this.Controls.Add(this.grid_before_due);
            this.Controls.Add(this.PanelTitles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.splitContainerRentalOptions.Panel1.ResumeLayout(false);
            this.splitContainerRentalOptions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRentalOptions)).EndInit();
            this.splitContainerRentalOptions.ResumeLayout(false);
            this.PanelTitles.ResumeLayout(false);
            this.PanelTitles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_before_due)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_past_due)).EndInit();
            this.splitContainerItems.Panel1.ResumeLayout(false);
            this.splitContainerItems.Panel1.PerformLayout();
            this.splitContainerItems.Panel2.ResumeLayout(false);
            this.splitContainerItems.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerItems)).EndInit();
            this.splitContainerItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerRentalOptions;
        private System.Windows.Forms.Label label_due_date;
        private System.Windows.Forms.Label label_past_due;
        private System.Windows.Forms.Panel PanelTitles;
        private System.Windows.Forms.DataGridView grid_before_due;
        private System.Windows.Forms.DataGridView grid_past_due;
        private System.Windows.Forms.Button btn_new_customer;
        private System.Windows.Forms.Button btn_existing_customer;
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
        private System.Windows.Forms.Button btn_past_due;
        private System.Windows.Forms.SplitContainer splitContainerItems;
        private System.Windows.Forms.Button btn_helmets;
        private System.Windows.Forms.Button btn_pants;
        private System.Windows.Forms.Button btn_jackets;
        private System.Windows.Forms.Button btn_rented;
        private System.Windows.Forms.Button btn_stock_boots;
        private System.Windows.Forms.Button btn_stock_helmets;
        private System.Windows.Forms.Button btn_stock_pants;
        private System.Windows.Forms.Button btn_stock_jackets;
        private System.Windows.Forms.Button btn_stock;
        private System.Windows.Forms.Label label_date_rented;
    }
}