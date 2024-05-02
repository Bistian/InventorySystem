namespace InventoryManagmentSystem
{
    partial class RentalForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridRented = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rented_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rented_rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rented_due_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rented_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridPastDue = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_past_due_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_past_due_rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_past_due_due_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_past_due_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rented = new System.Windows.Forms.Label();
            this.PastDue = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRented)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPastDue)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Maroon;
            this.panelTop.Controls.Add(this.labelSearch);
            this.panelTop.Controls.Add(this.searchBar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1379, 39);
            this.panelTop.TabIndex = 10;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSearch.Location = new System.Drawing.Point(9, 7);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(119, 32);
            this.labelSearch.TabIndex = 21;
            this.labelSearch.Text = "Search:";
            this.labelSearch.TextChanged += new System.EventHandler(this.labelSearch_TextChanged);
            // 
            // searchBar
            // 
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(109, 0);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(259, 45);
            this.searchBar.TabIndex = 20;
            this.searchBar.TextChanged += new System.EventHandler(this.labelSearch_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridRented, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridPastDue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Rented, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PastDue, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.350554F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.64944F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1379, 628);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // dataGridRented
            // 
            this.dataGridRented.AllowUserToAddRows = false;
            this.dataGridRented.AllowUserToDeleteRows = false;
            this.dataGridRented.AllowUserToResizeRows = false;
            this.dataGridRented.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridRented.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridRented.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridRented.ColumnHeadersHeight = 30;
            this.dataGridRented.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridRented.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.column_rented_id,
            this.column_rented_rentee,
            this.column_rented_due_date,
            this.column_rented_count});
            this.dataGridRented.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridRented.EnableHeadersVisualStyles = false;
            this.dataGridRented.Location = new System.Drawing.Point(4, 37);
            this.dataGridRented.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridRented.Name = "dataGridRented";
            this.dataGridRented.ReadOnly = true;
            this.dataGridRented.RowHeadersVisible = false;
            this.dataGridRented.RowHeadersWidth = 100;
            this.dataGridRented.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridRented.RowTemplate.Height = 40;
            this.dataGridRented.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridRented.Size = new System.Drawing.Size(681, 579);
            this.dataGridRented.TabIndex = 2;
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
            // column_rented_id
            // 
            this.column_rented_id.HeaderText = "Id";
            this.column_rented_id.MinimumWidth = 6;
            this.column_rented_id.Name = "column_rented_id";
            this.column_rented_id.ReadOnly = true;
            this.column_rented_id.Visible = false;
            this.column_rented_id.Width = 125;
            // 
            // column_rented_rentee
            // 
            this.column_rented_rentee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_rented_rentee.HeaderText = "Rentee";
            this.column_rented_rentee.MinimumWidth = 6;
            this.column_rented_rentee.Name = "column_rented_rentee";
            this.column_rented_rentee.ReadOnly = true;
            // 
            // column_rented_due_date
            // 
            this.column_rented_due_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_rented_due_date.HeaderText = "Due Date";
            this.column_rented_due_date.MinimumWidth = 6;
            this.column_rented_due_date.Name = "column_rented_due_date";
            this.column_rented_due_date.ReadOnly = true;
            // 
            // column_rented_count
            // 
            this.column_rented_count.HeaderText = "Count";
            this.column_rented_count.MinimumWidth = 6;
            this.column_rented_count.Name = "column_rented_count";
            this.column_rented_count.ReadOnly = true;
            this.column_rented_count.Width = 125;
            // 
            // dataGridPastDue
            // 
            this.dataGridPastDue.AllowUserToAddRows = false;
            this.dataGridPastDue.AllowUserToDeleteRows = false;
            this.dataGridPastDue.AllowUserToResizeRows = false;
            this.dataGridPastDue.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridPastDue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPastDue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridPastDue.ColumnHeadersHeight = 30;
            this.dataGridPastDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridPastDue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.column_past_due_id,
            this.column_past_due_rentee,
            this.column_past_due_due_date,
            this.column_past_due_count});
            this.dataGridPastDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPastDue.EnableHeadersVisualStyles = false;
            this.dataGridPastDue.Location = new System.Drawing.Point(693, 37);
            this.dataGridPastDue.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridPastDue.Name = "dataGridPastDue";
            this.dataGridPastDue.ReadOnly = true;
            this.dataGridPastDue.RowHeadersVisible = false;
            this.dataGridPastDue.RowHeadersWidth = 51;
            this.dataGridPastDue.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridPastDue.RowTemplate.Height = 40;
            this.dataGridPastDue.Size = new System.Drawing.Size(682, 579);
            this.dataGridPastDue.TabIndex = 3;
            this.dataGridPastDue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPastDue_CellClick_1);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.FillWeight = 30F;
            this.Id.HeaderText = "#";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // column_past_due_id
            // 
            this.column_past_due_id.HeaderText = "Id";
            this.column_past_due_id.MinimumWidth = 6;
            this.column_past_due_id.Name = "column_past_due_id";
            this.column_past_due_id.ReadOnly = true;
            this.column_past_due_id.Visible = false;
            this.column_past_due_id.Width = 125;
            // 
            // column_past_due_rentee
            // 
            this.column_past_due_rentee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_past_due_rentee.HeaderText = "Rentee";
            this.column_past_due_rentee.MinimumWidth = 6;
            this.column_past_due_rentee.Name = "column_past_due_rentee";
            this.column_past_due_rentee.ReadOnly = true;
            // 
            // column_past_due_due_date
            // 
            this.column_past_due_due_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_past_due_due_date.HeaderText = "Due Date";
            this.column_past_due_due_date.MinimumWidth = 6;
            this.column_past_due_due_date.Name = "column_past_due_due_date";
            this.column_past_due_due_date.ReadOnly = true;
            // 
            // column_past_due_count
            // 
            this.column_past_due_count.HeaderText = "Count";
            this.column_past_due_count.MinimumWidth = 6;
            this.column_past_due_count.Name = "column_past_due_count";
            this.column_past_due_count.ReadOnly = true;
            this.column_past_due_count.Width = 125;
            // 
            // Rented
            // 
            this.Rented.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rented.AutoSize = true;
            this.Rented.BackColor = System.Drawing.Color.Maroon;
            this.Rented.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rented.ForeColor = System.Drawing.SystemColors.Window;
            this.Rented.Location = new System.Drawing.Point(4, 1);
            this.Rented.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rented.Name = "Rented";
            this.Rented.Size = new System.Drawing.Size(112, 32);
            this.Rented.TabIndex = 4;
            this.Rented.Text = "Rented";
            // 
            // PastDue
            // 
            this.PastDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PastDue.AutoSize = true;
            this.PastDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PastDue.ForeColor = System.Drawing.SystemColors.Window;
            this.PastDue.Location = new System.Drawing.Point(693, 1);
            this.PastDue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PastDue.Name = "PastDue";
            this.PastDue.Size = new System.Drawing.Size(138, 32);
            this.PastDue.TabIndex = 5;
            this.PastDue.Text = "Past Due";
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 667);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RentalForm";
            this.Text = "HomeForm";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRented)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPastDue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridRented;
        private System.Windows.Forms.DataGridView dataGridPastDue;
        private System.Windows.Forms.Label Rented;
        private System.Windows.Forms.Label PastDue;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_past_due_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_past_due_rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_past_due_due_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_past_due_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rented_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rented_rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rented_due_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rented_count;
    }
}
