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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RentalHistoryForm));
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.labelItemType = new System.Windows.Forms.Label();
            this.dataGridItems = new System.Windows.Forms.DataGridView();
            this.column_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_item_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_acquired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_last_rent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridHistory = new System.Windows.Forms.DataGridView();
            this.column_client_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rented = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelTop = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // cbItemType
            // 
            this.cbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Items.AddRange(new object[] {
            "All",
            "Boots",
            "Helmets",
            "Jackets",
            "Masks",
            "Pants"});
            this.cbItemType.Location = new System.Drawing.Point(74, 3);
            this.cbItemType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(140, 23);
            this.cbItemType.TabIndex = 0;
            this.cbItemType.SelectedIndexChanged += new System.EventHandler(this.cbItemType_SelectedIndexChanged);
            // 
            // labelItemType
            // 
            this.labelItemType.AutoSize = true;
            this.labelItemType.ForeColor = System.Drawing.SystemColors.Window;
            this.labelItemType.Location = new System.Drawing.Point(0, 7);
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
            this.column_item_id,
            this.column_item_type,
            this.column_serial,
            this.column_brand,
            this.column_acquired,
            this.column_last_rent});
            this.dataGridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridItems.EnableHeadersVisualStyles = false;
            this.dataGridItems.Location = new System.Drawing.Point(0, 0);
            this.dataGridItems.Name = "dataGridItems";
            this.dataGridItems.RowHeadersVisible = false;
            this.dataGridItems.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridItems.RowTemplate.Height = 40;
            this.dataGridItems.Size = new System.Drawing.Size(933, 150);
            this.dataGridItems.TabIndex = 2;
            this.dataGridItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridItems_CellClick);
            // 
            // column_item_id
            // 
            this.column_item_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_item_id.HeaderText = "Item ID";
            this.column_item_id.Name = "column_item_id";
            this.column_item_id.Visible = false;
            // 
            // column_item_type
            // 
            this.column_item_type.HeaderText = "Item Type";
            this.column_item_type.Name = "column_item_type";
            // 
            // column_serial
            // 
            this.column_serial.HeaderText = "Serial";
            this.column_serial.Name = "column_serial";
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
            this.column_client_id,
            this.column_customer_name,
            this.column_rented,
            this.column_returned});
            this.dataGridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridHistory.EnableHeadersVisualStyles = false;
            this.dataGridHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridHistory.Name = "dataGridHistory";
            this.dataGridHistory.RowHeadersVisible = false;
            this.dataGridHistory.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridHistory.RowTemplate.Height = 40;
            this.dataGridHistory.Size = new System.Drawing.Size(933, 331);
            this.dataGridHistory.TabIndex = 3;
            // 
            // column_client_id
            // 
            this.column_client_id.HeaderText = "Client ID";
            this.column_client_id.Name = "column_client_id";
            this.column_client_id.Visible = false;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridHistory);
            this.splitContainer1.Size = new System.Drawing.Size(933, 485);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 5;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.CloseButton);
            this.panelTop.Controls.Add(this.cbItemType);
            this.panelTop.Controls.Add(this.labelItemType);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(933, 30);
            this.panelTop.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panelTop);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(933, 519);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.TabIndex = 7;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(894, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(27, 34);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 69;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RentalHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RentalHistoryForm";
            this.Text = "RentalHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.Label labelItemType;
        private System.Windows.Forms.DataGridView dataGridItems;
        private System.Windows.Forms.DataGridView dataGridHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_item_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_acquired;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_last_rent;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_client_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rented;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_returned;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomButton CloseButton;
    }
}