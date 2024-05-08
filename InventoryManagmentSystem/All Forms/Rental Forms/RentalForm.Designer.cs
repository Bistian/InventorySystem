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
            this.ItemLable = new System.Windows.Forms.Label();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridRented = new System.Windows.Forms.DataGridView();
            this.dataGridPastDue = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_past_due_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_past_due_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rented = new System.Windows.Forms.Label();
            this.PastDue = new System.Windows.Forms.Label();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_reted_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panelTop.Controls.Add(this.ItemLable);
            this.panelTop.Controls.Add(this.cbItemType);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1551, 44);
            this.panelTop.TabIndex = 10;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSearch.Location = new System.Drawing.Point(602, 6);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(94, 26);
            this.labelSearch.TabIndex = 21;
            this.labelSearch.Text = "Search:";
            this.labelSearch.TextChanged += new System.EventHandler(this.labelSearch_TextChanged);
            // 
            // searchBar
            // 
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(714, -3);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(234, 37);
            this.searchBar.TabIndex = 20;
            this.searchBar.TextChanged += new System.EventHandler(this.labelSearch_TextChanged);
            // 
            // ItemLable
            // 
            this.ItemLable.AutoSize = true;
            this.ItemLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemLable.ForeColor = System.Drawing.SystemColors.Control;
            this.ItemLable.Location = new System.Drawing.Point(15, 15);
            this.ItemLable.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ItemLable.Name = "ItemLable";
            this.ItemLable.Size = new System.Drawing.Size(124, 26);
            this.ItemLable.TabIndex = 2;
            this.ItemLable.Text = "Item Type:";
            // 
            // cbItemType
            // 
            this.cbItemType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbItemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.IntegralHeight = false;
            this.cbItemType.Items.AddRange(new object[] {
            "Jacket",
            "Pants",
            "Boots",
            "Helmet",
            "Mask",
            "All"});
            this.cbItemType.Location = new System.Drawing.Point(159, 8);
            this.cbItemType.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(132, 38);
            this.cbItemType.TabIndex = 3;
            this.cbItemType.SelectedIndexChanged += new System.EventHandler(this.cbItemType_SelectedIndexChanged);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 44);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.350554F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.64944F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1551, 706);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridRented.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridRented.ColumnHeadersHeight = 30;
            this.dataGridRented.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridRented.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.column_id,
            this.Rentee,
            this.DueDate,
            this.column_reted_count});
            this.dataGridRented.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridRented.EnableHeadersVisualStyles = false;
            this.dataGridRented.Location = new System.Drawing.Point(4, 41);
            this.dataGridRented.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridRented.Name = "dataGridRented";
            this.dataGridRented.ReadOnly = true;
            this.dataGridRented.RowHeadersVisible = false;
            this.dataGridRented.RowHeadersWidth = 100;
            this.dataGridRented.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridRented.RowTemplate.Height = 40;
            this.dataGridRented.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridRented.Size = new System.Drawing.Size(767, 652);
            this.dataGridRented.TabIndex = 2;
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
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
            this.dataGridViewTextBoxColumn2,
            this.DDate,
            this.column_past_due_count});
            this.dataGridPastDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPastDue.EnableHeadersVisualStyles = false;
            this.dataGridPastDue.Location = new System.Drawing.Point(779, 41);
            this.dataGridPastDue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridPastDue.Name = "dataGridPastDue";
            this.dataGridPastDue.ReadOnly = true;
            this.dataGridPastDue.RowHeadersVisible = false;
            this.dataGridPastDue.RowHeadersWidth = 51;
            this.dataGridPastDue.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridPastDue.RowTemplate.Height = 40;
            this.dataGridPastDue.Size = new System.Drawing.Size(768, 652);
            this.dataGridPastDue.TabIndex = 3;
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
            this.column_past_due_id.Name = "column_past_due_id";
            this.column_past_due_id.ReadOnly = true;
            this.column_past_due_id.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Rentee";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DDate
            // 
            this.DDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DDate.HeaderText = "Due Date";
            this.DDate.MinimumWidth = 6;
            this.DDate.Name = "DDate";
            this.DDate.ReadOnly = true;
            // 
            // column_past_due_count
            // 
            this.column_past_due_count.HeaderText = "Count";
            this.column_past_due_count.Name = "column_past_due_count";
            this.column_past_due_count.ReadOnly = true;
            // 
            // Rented
            // 
            this.Rented.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rented.AutoSize = true;
            this.Rented.BackColor = System.Drawing.Color.Maroon;
            this.Rented.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rented.ForeColor = System.Drawing.SystemColors.Window;
            this.Rented.Location = new System.Drawing.Point(4, 11);
            this.Rented.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rented.Name = "Rented";
            this.Rented.Size = new System.Drawing.Size(88, 26);
            this.Rented.TabIndex = 4;
            this.Rented.Text = "Rented";
            // 
            // PastDue
            // 
            this.PastDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PastDue.AutoSize = true;
            this.PastDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PastDue.ForeColor = System.Drawing.SystemColors.Window;
            this.PastDue.Location = new System.Drawing.Point(779, 11);
            this.PastDue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PastDue.Name = "PastDue";
            this.PastDue.Size = new System.Drawing.Size(110, 26);
            this.PastDue.TabIndex = 5;
            this.PastDue.Text = "Past Due";
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
            // column_id
            // 
            this.column_id.HeaderText = "Id";
            this.column_id.Name = "column_id";
            this.column_id.ReadOnly = true;
            this.column_id.Visible = false;
            // 
            // Rentee
            // 
            this.Rentee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rentee.HeaderText = "Rentee";
            this.Rentee.MinimumWidth = 6;
            this.Rentee.Name = "Rentee";
            this.Rentee.ReadOnly = true;
            // 
            // DueDate
            // 
            this.DueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.MinimumWidth = 6;
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            // 
            // column_reted_count
            // 
            this.column_reted_count.HeaderText = "Count";
            this.column_reted_count.Name = "column_reted_count";
            this.column_reted_count.ReadOnly = true;
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1551, 750);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Label ItemLable;
        public System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_past_due_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_past_due_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_reted_count;
    }
}
