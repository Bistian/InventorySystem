namespace InventoryManagmentSystem
{
    partial class RentalHistoryForm
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
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.labelItemType = new System.Windows.Forms.Label();
            this.dataGridItems = new System.Windows.Forms.DataGridView();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_acquired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_last_rent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridHistory = new System.Windows.Forms.DataGridView();
            this.column_customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rented = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // cbItemType
            // 
            this.cbItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Items.AddRange(new object[] {
            "Boots",
            "Helmets",
            "Jackets",
            "Masks",
            "Pants"});
            this.cbItemType.Location = new System.Drawing.Point(86, 2);
            this.cbItemType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(140, 23);
            this.cbItemType.TabIndex = 0;
            // 
            // labelItemType
            // 
            this.labelItemType.AutoSize = true;
            this.labelItemType.ForeColor = System.Drawing.SystemColors.Window;
            this.labelItemType.Location = new System.Drawing.Point(12, 9);
            this.labelItemType.Name = "labelItemType";
            this.labelItemType.Size = new System.Drawing.Size(67, 16);
            this.labelItemType.TabIndex = 1;
            this.labelItemType.Text = "Item Type";
            // 
            // dataGridItems
            // 
            this.dataGridItems.AllowUserToAddRows = false;
            this.dataGridItems.AllowUserToDeleteRows = false;
            this.dataGridItems.AllowUserToResizeRows = false;
            this.dataGridItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridItems.ColumnHeadersHeight = 30;
            this.dataGridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_id,
            this.column_brand,
            this.column_acquired,
            this.column_last_rent});
            this.dataGridItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridItems.EnableHeadersVisualStyles = false;
            this.dataGridItems.Location = new System.Drawing.Point(15, 29);
            this.dataGridItems.Name = "dataGridItems";
            this.dataGridItems.RowHeadersVisible = false;
            this.dataGridItems.Size = new System.Drawing.Size(461, 403);
            this.dataGridItems.TabIndex = 2;
            // 
            // column_id
            // 
            this.column_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_id.HeaderText = "ID";
            this.column_id.Name = "column_id";
            // 
            // column_brand
            // 
            this.column_brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_brand.HeaderText = "Brand";
            this.column_brand.Name = "column_brand";
            // 
            // column_acquired
            // 
            this.column_acquired.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_acquired.HeaderText = "Acquired";
            this.column_acquired.Name = "column_acquired";
            // 
            // column_last_rent
            // 
            this.column_last_rent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_last_rent.HeaderText = "Last Rented";
            this.column_last_rent.Name = "column_last_rent";
            // 
            // dataGridHistory
            // 
            this.dataGridHistory.AllowUserToAddRows = false;
            this.dataGridHistory.AllowUserToDeleteRows = false;
            this.dataGridHistory.AllowUserToResizeRows = false;
            this.dataGridHistory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridHistory.ColumnHeadersHeight = 30;
            this.dataGridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_customer_id,
            this.column_customer_name,
            this.column_rented,
            this.column_returned});
            this.dataGridHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridHistory.EnableHeadersVisualStyles = false;
            this.dataGridHistory.Location = new System.Drawing.Point(482, 29);
            this.dataGridHistory.Name = "dataGridHistory";
            this.dataGridHistory.RowHeadersVisible = false;
            this.dataGridHistory.Size = new System.Drawing.Size(439, 403);
            this.dataGridHistory.TabIndex = 3;
            // 
            // column_customer_id
            // 
            this.column_customer_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_customer_id.HeaderText = "Customer ID";
            this.column_customer_id.Name = "column_customer_id";
            // 
            // column_customer_name
            // 
            this.column_customer_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_customer_name.HeaderText = "Customer Name";
            this.column_customer_name.Name = "column_customer_name";
            // 
            // column_rented
            // 
            this.column_rented.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_rented.HeaderText = "Rented";
            this.column_rented.Name = "column_rented";
            // 
            // column_returned
            // 
            this.column_returned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_returned.HeaderText = "Returned";
            this.column_returned.Name = "column_returned";
            // 
            // RentalHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.dataGridHistory);
            this.Controls.Add(this.dataGridItems);
            this.Controls.Add(this.labelItemType);
            this.Controls.Add(this.cbItemType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RentalHistoryForm";
            this.Text = "RentalHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.Label labelItemType;
        private System.Windows.Forms.DataGridView dataGridItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_acquired;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_last_rent;
        private System.Windows.Forms.DataGridView dataGridHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_customer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rented;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_returned;
    }
}