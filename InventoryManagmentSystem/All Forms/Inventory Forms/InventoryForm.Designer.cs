namespace InventoryManagmentSystem
{
    partial class InventoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            this.ItemLable = new System.Windows.Forms.Label();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.dataGridInv = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_acquisition_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufactureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.checkActive = new System.Windows.Forms.CheckBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.checkRetired = new System.Windows.Forms.CheckBox();
            this.labelNewItem = new System.Windows.Forms.Label();
            this.UsersButton = new InventoryManagmentSystem.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInv)).BeginInit();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersButton)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemLable
            // 
            this.ItemLable.AutoSize = true;
            this.ItemLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemLable.ForeColor = System.Drawing.SystemColors.Control;
            this.ItemLable.Location = new System.Drawing.Point(3, 16);
            this.ItemLable.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ItemLable.Name = "ItemLable";
            this.ItemLable.Size = new System.Drawing.Size(156, 32);
            this.ItemLable.TabIndex = 0;
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
            this.cbItemType.Location = new System.Drawing.Point(131, 11);
            this.cbItemType.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(95, 46);
            this.cbItemType.TabIndex = 1;
            this.cbItemType.SelectedIndexChanged += new System.EventHandler(this.comboBoxItem_SelectedIndexChanged);
            // 
            // dataGridInv
            // 
            this.dataGridInv.AllowUserToAddRows = false;
            this.dataGridInv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.column_item_id,
            this.Brand,
            this.Serial,
            this.Condition,
            this.column_acquisition_date,
            this.ManufactureDate,
            this.Location,
            this.Size,
            this.Material,
            this.Color,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInv.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridInv.EnableHeadersVisualStyles = false;
            this.dataGridInv.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridInv.Location = new System.Drawing.Point(0, 55);
            this.dataGridInv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridInv.Name = "dataGridInv";
            this.dataGridInv.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInv.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridInv.RowHeadersVisible = false;
            this.dataGridInv.RowHeadersWidth = 51;
            this.dataGridInv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridInv.RowTemplate.Height = 40;
            this.dataGridInv.RowTemplate.ReadOnly = true;
            this.dataGridInv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInv.Size = new System.Drawing.Size(1177, 503);
            this.dataGridInv.TabIndex = 1;
            this.dataGridInv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridInv_CellClick);
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
            // column_item_id
            // 
            this.column_item_id.HeaderText = "Id";
            this.column_item_id.MinimumWidth = 6;
            this.column_item_id.Name = "column_item_id";
            this.column_item_id.ReadOnly = true;
            this.column_item_id.Visible = false;
            this.column_item_id.Width = 125;
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
            // Condition
            // 
            this.Condition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Condition.FillWeight = 60F;
            this.Condition.HeaderText = "Condition";
            this.Condition.MinimumWidth = 6;
            this.Condition.Name = "Condition";
            this.Condition.ReadOnly = true;
            // 
            // column_acquisition_date
            // 
            this.column_acquisition_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_acquisition_date.HeaderText = "Acquisition";
            this.column_acquisition_date.MinimumWidth = 6;
            this.column_acquisition_date.Name = "column_acquisition_date";
            this.column_acquisition_date.ReadOnly = true;
            // 
            // ManufactureDate
            // 
            this.ManufactureDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ManufactureDate.HeaderText = "MFD";
            this.ManufactureDate.MinimumWidth = 6;
            this.ManufactureDate.Name = "ManufactureDate";
            this.ManufactureDate.ReadOnly = true;
            // 
            // Location
            // 
            this.Location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Visible = false;
            // 
            // Size
            // 
            this.Size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Size.FillWeight = 40F;
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 6;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Visible = false;
            // 
            // Material
            // 
            this.Material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Material.FillWeight = 55F;
            this.Material.HeaderText = "Material";
            this.Material.MinimumWidth = 6;
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Visible = false;
            // 
            // Color
            // 
            this.Color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Color.HeaderText = "Color";
            this.Color.MinimumWidth = 8;
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Visible = false;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Edit.FillWeight = 30F;
            this.Edit.HeaderText = "";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.MinimumWidth = 6;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Delete.FillWeight = 30F;
            this.Delete.HeaderText = "";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSearch.Location = new System.Drawing.Point(233, 16);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(119, 32);
            this.labelSearch.TabIndex = 19;
            this.labelSearch.Text = "Search:";
            // 
            // searchBar
            // 
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(333, 9);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(208, 45);
            this.searchBar.TabIndex = 18;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 125;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 125;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Maroon;
            this.TopPanel.Controls.Add(this.checkActive);
            this.TopPanel.Controls.Add(this.checkAll);
            this.TopPanel.Controls.Add(this.checkRetired);
            this.TopPanel.Controls.Add(this.labelNewItem);
            this.TopPanel.Controls.Add(this.UsersButton);
            this.TopPanel.Controls.Add(this.labelSearch);
            this.TopPanel.Controls.Add(this.ItemLable);
            this.TopPanel.Controls.Add(this.searchBar);
            this.TopPanel.Controls.Add(this.cbItemType);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1177, 55);
            this.TopPanel.TabIndex = 20;
            // 
            // checkActive
            // 
            this.checkActive.AutoSize = true;
            this.checkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkActive.ForeColor = System.Drawing.SystemColors.Window;
            this.checkActive.Location = new System.Drawing.Point(549, -6);
            this.checkActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkActive.Name = "checkActive";
            this.checkActive.Size = new System.Drawing.Size(105, 33);
            this.checkActive.TabIndex = 23;
            this.checkActive.Text = "Active";
            this.checkActive.UseVisualStyleBackColor = true;
            this.checkActive.Click += new System.EventHandler(this.checkActive_Click);
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAll.ForeColor = System.Drawing.SystemColors.Window;
            this.checkAll.Location = new System.Drawing.Point(549, 35);
            this.checkAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(65, 33);
            this.checkAll.TabIndex = 22;
            this.checkAll.Text = "All";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.Click += new System.EventHandler(this.checkAll_Click);
            // 
            // checkRetired
            // 
            this.checkRetired.AutoSize = true;
            this.checkRetired.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRetired.ForeColor = System.Drawing.SystemColors.Window;
            this.checkRetired.Location = new System.Drawing.Point(549, 14);
            this.checkRetired.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkRetired.Name = "checkRetired";
            this.checkRetired.Size = new System.Drawing.Size(121, 33);
            this.checkRetired.TabIndex = 21;
            this.checkRetired.Text = "Retired";
            this.checkRetired.UseVisualStyleBackColor = true;
            this.checkRetired.Click += new System.EventHandler(this.checkRetired_Click);
            // 
            // labelNewItem
            // 
            this.labelNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNewItem.AutoSize = true;
            this.labelNewItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelNewItem.Location = new System.Drawing.Point(988, 17);
            this.labelNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.labelNewItem.Name = "labelNewItem";
            this.labelNewItem.Size = new System.Drawing.Size(148, 32);
            this.labelNewItem.TabIndex = 20;
            this.labelNewItem.Text = "New Item:";
            this.labelNewItem.Click += new System.EventHandler(this.labelNewItem_Click);
            // 
            // UsersButton
            // 
            this.UsersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersButton.Image = ((System.Drawing.Image)(resources.GetObject("UsersButton.Image")));
            this.UsersButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("UsersButton.ImageHover")));
            this.UsersButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("UsersButton.ImageNormal")));
            this.UsersButton.Location = new System.Drawing.Point(1105, 6);
            this.UsersButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(72, 45);
            this.UsersButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UsersButton.TabIndex = 17;
            this.UsersButton.TabStop = false;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click_1);
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 558);
            this.Controls.Add(this.dataGridInv);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInv)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label ItemLable;
        private System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.DataGridView dataGridInv;
        private CustomButton UsersButton;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label labelNewItem;
        private System.Windows.Forms.CheckBox checkRetired;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.CheckBox checkActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condition;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_acquisition_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufactureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}