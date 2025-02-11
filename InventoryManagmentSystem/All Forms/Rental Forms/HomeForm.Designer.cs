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
            this.table_layout_panel_main = new System.Windows.Forms.TableLayoutPanel();
            this.table_layout_panel_right = new System.Windows.Forms.TableLayoutPanel();
            this.grid_past_due = new System.Windows.Forms.DataGridView();
            this.nums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rentee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_due2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_count2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_past_due = new System.Windows.Forms.Label();
            this.table_layout_panel_left = new System.Windows.Forms.TableLayoutPanel();
            this.label_due_date = new System.Windows.Forms.Label();
            this.grid_before_due = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_layout_panel_mid = new System.Windows.Forms.TableLayoutPanel();
            this.btn_past_due = new System.Windows.Forms.Button();
            this.table_layout_panel_buttons = new System.Windows.Forms.TableLayoutPanel();
            this.table_layout_panel_stock = new System.Windows.Forms.TableLayoutPanel();
            this.btn_stock = new System.Windows.Forms.Button();
            this.label_date_rented = new System.Windows.Forms.Label();
            this.btn_existing_customer = new System.Windows.Forms.Button();
            this.btn_new_customer = new System.Windows.Forms.Button();
            this.btn_stock_pants = new System.Windows.Forms.Button();
            this.btn_stock_jackets = new System.Windows.Forms.Button();
            this.btn_rented = new System.Windows.Forms.Button();
            this.btn_stock_helmets = new System.Windows.Forms.Button();
            this.btn_helmets = new System.Windows.Forms.Button();
            this.btn_pants = new System.Windows.Forms.Button();
            this.btn_jackets = new System.Windows.Forms.Button();
            this.btn_stock_boots = new System.Windows.Forms.Button();
            this.panel_form = new System.Windows.Forms.Panel();
            this.table_layout_panel_main.SuspendLayout();
            this.table_layout_panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_past_due)).BeginInit();
            this.table_layout_panel_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_before_due)).BeginInit();
            this.table_layout_panel_mid.SuspendLayout();
            this.table_layout_panel_buttons.SuspendLayout();
            this.table_layout_panel_stock.SuspendLayout();
            this.panel_form.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_layout_panel_main
            // 
            this.table_layout_panel_main.AutoScroll = true;
            this.table_layout_panel_main.AutoSize = true;
            this.table_layout_panel_main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table_layout_panel_main.ColumnCount = 3;
            this.table_layout_panel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_layout_panel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_layout_panel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_layout_panel_main.Controls.Add(this.table_layout_panel_right, 2, 0);
            this.table_layout_panel_main.Controls.Add(this.table_layout_panel_left, 0, 0);
            this.table_layout_panel_main.Controls.Add(this.table_layout_panel_mid, 1, 0);
            this.table_layout_panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_panel_main.Location = new System.Drawing.Point(0, 0);
            this.table_layout_panel_main.Margin = new System.Windows.Forms.Padding(0);
            this.table_layout_panel_main.Name = "table_layout_panel_main";
            this.table_layout_panel_main.RowCount = 1;
            this.table_layout_panel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_panel_main.Size = new System.Drawing.Size(992, 600);
            this.table_layout_panel_main.TabIndex = 24;
            // 
            // table_layout_panel_right
            // 
            this.table_layout_panel_right.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table_layout_panel_right.ColumnCount = 1;
            this.table_layout_panel_right.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_panel_right.Controls.Add(this.grid_past_due, 0, 1);
            this.table_layout_panel_right.Controls.Add(this.label_past_due, 0, 0);
            this.table_layout_panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_panel_right.Location = new System.Drawing.Point(660, 0);
            this.table_layout_panel_right.Margin = new System.Windows.Forms.Padding(0);
            this.table_layout_panel_right.Name = "table_layout_panel_right";
            this.table_layout_panel_right.RowCount = 2;
            this.table_layout_panel_right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.table_layout_panel_right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.table_layout_panel_right.Size = new System.Drawing.Size(332, 600);
            this.table_layout_panel_right.TabIndex = 52;
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
            this.grid_past_due.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_past_due.Location = new System.Drawing.Point(0, 42);
            this.grid_past_due.Margin = new System.Windows.Forms.Padding(0);
            this.grid_past_due.Name = "grid_past_due";
            this.grid_past_due.ReadOnly = true;
            this.grid_past_due.RowHeadersVisible = false;
            this.grid_past_due.RowHeadersWidth = 51;
            this.grid_past_due.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_past_due.RowTemplate.Height = 40;
            this.grid_past_due.Size = new System.Drawing.Size(332, 558);
            this.grid_past_due.TabIndex = 16;
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
            // label_past_due
            // 
            this.label_past_due.AutoSize = true;
            this.label_past_due.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_past_due.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_past_due.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_past_due.Location = new System.Drawing.Point(0, 0);
            this.label_past_due.Margin = new System.Windows.Forms.Padding(0);
            this.label_past_due.Name = "label_past_due";
            this.label_past_due.Size = new System.Drawing.Size(332, 42);
            this.label_past_due.TabIndex = 15;
            this.label_past_due.Text = "Past Due";
            this.label_past_due.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // table_layout_panel_left
            // 
            this.table_layout_panel_left.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table_layout_panel_left.ColumnCount = 1;
            this.table_layout_panel_left.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_panel_left.Controls.Add(this.label_due_date, 0, 0);
            this.table_layout_panel_left.Controls.Add(this.grid_before_due, 0, 1);
            this.table_layout_panel_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_panel_left.Location = new System.Drawing.Point(0, 0);
            this.table_layout_panel_left.Margin = new System.Windows.Forms.Padding(0);
            this.table_layout_panel_left.Name = "table_layout_panel_left";
            this.table_layout_panel_left.RowCount = 2;
            this.table_layout_panel_left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.table_layout_panel_left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.table_layout_panel_left.Size = new System.Drawing.Size(330, 600);
            this.table_layout_panel_left.TabIndex = 25;
            // 
            // label_due_date
            // 
            this.label_due_date.AutoSize = true;
            this.label_due_date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_due_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_due_date.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_due_date.Location = new System.Drawing.Point(0, 0);
            this.label_due_date.Margin = new System.Windows.Forms.Padding(0);
            this.label_due_date.Name = "label_due_date";
            this.label_due_date.Size = new System.Drawing.Size(330, 42);
            this.label_due_date.TabIndex = 13;
            this.label_due_date.Text = "Due Withinn 10 Days";
            this.label_due_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.grid_before_due.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_before_due.Location = new System.Drawing.Point(0, 42);
            this.grid_before_due.Margin = new System.Windows.Forms.Padding(0);
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
            this.grid_before_due.Size = new System.Drawing.Size(330, 558);
            this.grid_before_due.TabIndex = 12;
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
            // table_layout_panel_mid
            // 
            this.table_layout_panel_mid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table_layout_panel_mid.ColumnCount = 1;
            this.table_layout_panel_mid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_panel_mid.Controls.Add(this.btn_past_due, 0, 0);
            this.table_layout_panel_mid.Controls.Add(this.table_layout_panel_buttons, 0, 1);
            this.table_layout_panel_mid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_panel_mid.Location = new System.Drawing.Point(330, 0);
            this.table_layout_panel_mid.Margin = new System.Windows.Forms.Padding(0);
            this.table_layout_panel_mid.Name = "table_layout_panel_mid";
            this.table_layout_panel_mid.RowCount = 2;
            this.table_layout_panel_mid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.table_layout_panel_mid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.table_layout_panel_mid.Size = new System.Drawing.Size(330, 600);
            this.table_layout_panel_mid.TabIndex = 50;
            // 
            // btn_past_due
            // 
            this.btn_past_due.AutoSize = true;
            this.btn_past_due.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_past_due.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_past_due.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_past_due.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_past_due.FlatAppearance.BorderSize = 2;
            this.btn_past_due.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_past_due.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_past_due.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_past_due.ForeColor = System.Drawing.Color.Red;
            this.btn_past_due.Location = new System.Drawing.Point(0, 0);
            this.btn_past_due.Margin = new System.Windows.Forms.Padding(0);
            this.btn_past_due.Name = "btn_past_due";
            this.btn_past_due.Size = new System.Drawing.Size(330, 60);
            this.btn_past_due.TabIndex = 49;
            this.btn_past_due.Text = "Past Due!";
            this.btn_past_due.UseVisualStyleBackColor = false;
            // 
            // table_layout_panel_buttons
            // 
            this.table_layout_panel_buttons.AutoSize = true;
            this.table_layout_panel_buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table_layout_panel_buttons.ColumnCount = 2;
            this.table_layout_panel_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_layout_panel_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_layout_panel_buttons.Controls.Add(this.table_layout_panel_stock, 0, 0);
            this.table_layout_panel_buttons.Controls.Add(this.btn_existing_customer, 1, 5);
            this.table_layout_panel_buttons.Controls.Add(this.btn_new_customer, 0, 5);
            this.table_layout_panel_buttons.Controls.Add(this.btn_stock_pants, 0, 3);
            this.table_layout_panel_buttons.Controls.Add(this.btn_stock_jackets, 0, 2);
            this.table_layout_panel_buttons.Controls.Add(this.btn_rented, 1, 0);
            this.table_layout_panel_buttons.Controls.Add(this.btn_stock_helmets, 0, 1);
            this.table_layout_panel_buttons.Controls.Add(this.btn_helmets, 1, 1);
            this.table_layout_panel_buttons.Controls.Add(this.btn_pants, 1, 3);
            this.table_layout_panel_buttons.Controls.Add(this.btn_jackets, 1, 2);
            this.table_layout_panel_buttons.Controls.Add(this.btn_stock_boots, 0, 4);
            this.table_layout_panel_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_panel_buttons.Location = new System.Drawing.Point(3, 63);
            this.table_layout_panel_buttons.Name = "table_layout_panel_buttons";
            this.table_layout_panel_buttons.RowCount = 6;
            this.table_layout_panel_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table_layout_panel_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table_layout_panel_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table_layout_panel_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table_layout_panel_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table_layout_panel_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table_layout_panel_buttons.Size = new System.Drawing.Size(324, 534);
            this.table_layout_panel_buttons.TabIndex = 48;
            // 
            // table_layout_panel_stock
            // 
            this.table_layout_panel_stock.ColumnCount = 1;
            this.table_layout_panel_stock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_panel_stock.Controls.Add(this.btn_stock, 0, 0);
            this.table_layout_panel_stock.Controls.Add(this.label_date_rented, 0, 1);
            this.table_layout_panel_stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_panel_stock.Location = new System.Drawing.Point(0, 0);
            this.table_layout_panel_stock.Margin = new System.Windows.Forms.Padding(0);
            this.table_layout_panel_stock.Name = "table_layout_panel_stock";
            this.table_layout_panel_stock.RowCount = 2;
            this.table_layout_panel_stock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.table_layout_panel_stock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table_layout_panel_stock.Size = new System.Drawing.Size(162, 89);
            this.table_layout_panel_stock.TabIndex = 25;
            // 
            // btn_stock
            // 
            this.btn_stock.AutoSize = true;
            this.btn_stock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_stock.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_stock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock.FlatAppearance.BorderSize = 2;
            this.btn_stock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock.Location = new System.Drawing.Point(0, 0);
            this.btn_stock.Margin = new System.Windows.Forms.Padding(0);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Size = new System.Drawing.Size(162, 71);
            this.btn_stock.TabIndex = 40;
            this.btn_stock.Text = "Stock";
            this.btn_stock.UseVisualStyleBackColor = false;
            // 
            // label_date_rented
            // 
            this.label_date_rented.AutoSize = true;
            this.label_date_rented.BackColor = System.Drawing.Color.MidnightBlue;
            this.label_date_rented.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_date_rented.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label_date_rented.Location = new System.Drawing.Point(2, 71);
            this.label_date_rented.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.label_date_rented.Name = "label_date_rented";
            this.label_date_rented.Size = new System.Drawing.Size(158, 16);
            this.label_date_rented.TabIndex = 46;
            this.label_date_rented.Text = "Date Rented";
            this.label_date_rented.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_existing_customer
            // 
            this.btn_existing_customer.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_existing_customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_existing_customer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_existing_customer.FlatAppearance.BorderSize = 2;
            this.btn_existing_customer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_existing_customer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_existing_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_existing_customer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_existing_customer.Location = new System.Drawing.Point(162, 445);
            this.btn_existing_customer.Margin = new System.Windows.Forms.Padding(0);
            this.btn_existing_customer.Name = "btn_existing_customer";
            this.btn_existing_customer.Size = new System.Drawing.Size(162, 89);
            this.btn_existing_customer.TabIndex = 47;
            this.btn_existing_customer.Text = "Existing Customer";
            this.btn_existing_customer.UseVisualStyleBackColor = false;
            // 
            // btn_new_customer
            // 
            this.btn_new_customer.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_new_customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_new_customer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_new_customer.FlatAppearance.BorderSize = 2;
            this.btn_new_customer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_new_customer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_customer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_new_customer.Location = new System.Drawing.Point(0, 445);
            this.btn_new_customer.Margin = new System.Windows.Forms.Padding(0);
            this.btn_new_customer.Name = "btn_new_customer";
            this.btn_new_customer.Size = new System.Drawing.Size(162, 89);
            this.btn_new_customer.TabIndex = 43;
            this.btn_new_customer.Text = "New Customer";
            this.btn_new_customer.UseVisualStyleBackColor = false;
            // 
            // btn_stock_pants
            // 
            this.btn_stock_pants.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock_pants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_stock_pants.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock_pants.FlatAppearance.BorderSize = 2;
            this.btn_stock_pants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock_pants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock_pants.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock_pants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock_pants.Location = new System.Drawing.Point(0, 267);
            this.btn_stock_pants.Margin = new System.Windows.Forms.Padding(0);
            this.btn_stock_pants.Name = "btn_stock_pants";
            this.btn_stock_pants.Size = new System.Drawing.Size(162, 89);
            this.btn_stock_pants.TabIndex = 45;
            this.btn_stock_pants.Text = "Pants";
            this.btn_stock_pants.UseVisualStyleBackColor = false;
            // 
            // btn_stock_jackets
            // 
            this.btn_stock_jackets.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock_jackets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_stock_jackets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock_jackets.FlatAppearance.BorderSize = 2;
            this.btn_stock_jackets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock_jackets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock_jackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock_jackets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock_jackets.Location = new System.Drawing.Point(0, 178);
            this.btn_stock_jackets.Margin = new System.Windows.Forms.Padding(0);
            this.btn_stock_jackets.Name = "btn_stock_jackets";
            this.btn_stock_jackets.Size = new System.Drawing.Size(162, 89);
            this.btn_stock_jackets.TabIndex = 41;
            this.btn_stock_jackets.Text = "Jackets";
            this.btn_stock_jackets.UseVisualStyleBackColor = false;
            // 
            // btn_rented
            // 
            this.btn_rented.AutoSize = true;
            this.btn_rented.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_rented.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_rented.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_rented.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_rented.FlatAppearance.BorderSize = 2;
            this.btn_rented.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_rented.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rented.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rented.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_rented.Location = new System.Drawing.Point(162, 0);
            this.btn_rented.Margin = new System.Windows.Forms.Padding(0);
            this.btn_rented.Name = "btn_rented";
            this.btn_rented.Size = new System.Drawing.Size(162, 89);
            this.btn_rented.TabIndex = 42;
            this.btn_rented.Text = "Rented";
            this.btn_rented.UseVisualStyleBackColor = false;
            // 
            // btn_stock_helmets
            // 
            this.btn_stock_helmets.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock_helmets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_stock_helmets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock_helmets.FlatAppearance.BorderSize = 2;
            this.btn_stock_helmets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock_helmets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock_helmets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock_helmets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock_helmets.Location = new System.Drawing.Point(0, 89);
            this.btn_stock_helmets.Margin = new System.Windows.Forms.Padding(0);
            this.btn_stock_helmets.Name = "btn_stock_helmets";
            this.btn_stock_helmets.Size = new System.Drawing.Size(162, 89);
            this.btn_stock_helmets.TabIndex = 44;
            this.btn_stock_helmets.Text = "Helmets";
            this.btn_stock_helmets.UseVisualStyleBackColor = false;
            // 
            // btn_helmets
            // 
            this.btn_helmets.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_helmets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_helmets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_helmets.FlatAppearance.BorderSize = 2;
            this.btn_helmets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_helmets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_helmets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_helmets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_helmets.Location = new System.Drawing.Point(162, 89);
            this.btn_helmets.Margin = new System.Windows.Forms.Padding(0);
            this.btn_helmets.Name = "btn_helmets";
            this.btn_helmets.Size = new System.Drawing.Size(162, 89);
            this.btn_helmets.TabIndex = 39;
            this.btn_helmets.Text = "Helmets";
            this.btn_helmets.UseVisualStyleBackColor = false;
            // 
            // btn_pants
            // 
            this.btn_pants.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_pants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_pants.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_pants.FlatAppearance.BorderSize = 2;
            this.btn_pants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_pants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pants.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pants.Location = new System.Drawing.Point(162, 267);
            this.btn_pants.Margin = new System.Windows.Forms.Padding(0);
            this.btn_pants.Name = "btn_pants";
            this.btn_pants.Size = new System.Drawing.Size(162, 89);
            this.btn_pants.TabIndex = 38;
            this.btn_pants.Text = "Pants";
            this.btn_pants.UseVisualStyleBackColor = false;
            // 
            // btn_jackets
            // 
            this.btn_jackets.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_jackets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_jackets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_jackets.FlatAppearance.BorderSize = 2;
            this.btn_jackets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_jackets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_jackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_jackets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_jackets.Location = new System.Drawing.Point(162, 178);
            this.btn_jackets.Margin = new System.Windows.Forms.Padding(0);
            this.btn_jackets.Name = "btn_jackets";
            this.btn_jackets.Size = new System.Drawing.Size(162, 89);
            this.btn_jackets.TabIndex = 37;
            this.btn_jackets.Text = "Jackets";
            this.btn_jackets.UseVisualStyleBackColor = false;
            // 
            // btn_stock_boots
            // 
            this.btn_stock_boots.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_stock_boots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_stock_boots.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_stock_boots.FlatAppearance.BorderSize = 2;
            this.btn_stock_boots.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btn_stock_boots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock_boots.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock_boots.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock_boots.Location = new System.Drawing.Point(0, 356);
            this.btn_stock_boots.Margin = new System.Windows.Forms.Padding(0);
            this.btn_stock_boots.Name = "btn_stock_boots";
            this.btn_stock_boots.Size = new System.Drawing.Size(162, 89);
            this.btn_stock_boots.TabIndex = 36;
            this.btn_stock_boots.Text = "Boots";
            this.btn_stock_boots.UseVisualStyleBackColor = false;
            // 
            // panel_form
            // 
            this.panel_form.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel_form.Controls.Add(this.table_layout_panel_main);
            this.panel_form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_form.Location = new System.Drawing.Point(0, 0);
            this.panel_form.Name = "panel_form";
            this.panel_form.Size = new System.Drawing.Size(992, 600);
            this.panel_form.TabIndex = 25;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 600);
            this.Controls.Add(this.panel_form);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.table_layout_panel_main.ResumeLayout(false);
            this.table_layout_panel_right.ResumeLayout(false);
            this.table_layout_panel_right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_past_due)).EndInit();
            this.table_layout_panel_left.ResumeLayout(false);
            this.table_layout_panel_left.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_before_due)).EndInit();
            this.table_layout_panel_mid.ResumeLayout(false);
            this.table_layout_panel_mid.PerformLayout();
            this.table_layout_panel_buttons.ResumeLayout(false);
            this.table_layout_panel_buttons.PerformLayout();
            this.table_layout_panel_stock.ResumeLayout(false);
            this.table_layout_panel_stock.PerformLayout();
            this.panel_form.ResumeLayout(false);
            this.panel_form.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_layout_panel_main;
        private System.Windows.Forms.TableLayoutPanel table_layout_panel_right;
        private System.Windows.Forms.DataGridView grid_past_due;
        private System.Windows.Forms.DataGridViewTextBoxColumn nums;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rentee2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_due2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_count2;
        private System.Windows.Forms.Label label_past_due;
        private System.Windows.Forms.TableLayoutPanel table_layout_panel_left;
        private System.Windows.Forms.Label label_due_date;
        private System.Windows.Forms.DataGridView grid_before_due;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_due;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_count;
        private System.Windows.Forms.TableLayoutPanel table_layout_panel_mid;
        private System.Windows.Forms.Button btn_past_due;
        private System.Windows.Forms.TableLayoutPanel table_layout_panel_buttons;
        private System.Windows.Forms.Button btn_existing_customer;
        private System.Windows.Forms.Button btn_stock;
        private System.Windows.Forms.Button btn_new_customer;
        private System.Windows.Forms.Button btn_stock_pants;
        private System.Windows.Forms.Button btn_stock_jackets;
        private System.Windows.Forms.Button btn_rented;
        private System.Windows.Forms.Button btn_stock_helmets;
        private System.Windows.Forms.Button btn_helmets;
        private System.Windows.Forms.Button btn_pants;
        private System.Windows.Forms.Button btn_jackets;
        private System.Windows.Forms.Button btn_stock_boots;
        private System.Windows.Forms.Label label_date_rented;
        private System.Windows.Forms.Panel panel_form;
        private System.Windows.Forms.TableLayoutPanel table_layout_panel_stock;
    }
}