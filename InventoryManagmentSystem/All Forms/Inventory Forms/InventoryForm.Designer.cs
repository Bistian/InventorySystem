﻿namespace InventoryManagmentSystem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            this.ItemLable = new System.Windows.Forms.Label();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.dataGridInv = new System.Windows.Forms.DataGridView();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.CheckRented = new System.Windows.Forms.CheckBox();
            this.checkActive = new System.Windows.Forms.CheckBox();
            this.checkRetired = new System.Windows.Forms.CheckBox();
            this.btnAddUser = new InventoryManagmentSystem.CustomButton();
            this.scOuter = new System.Windows.Forms.SplitContainer();
            this.scInner = new System.Windows.Forms.SplitContainer();
            this.btnToggleFilter = new System.Windows.Forms.Button();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_item_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_acquisition_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_manufacture_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.column_delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInv)).BeginInit();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scOuter)).BeginInit();
            this.scOuter.Panel1.SuspendLayout();
            this.scOuter.Panel2.SuspendLayout();
            this.scOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInner)).BeginInit();
            this.scInner.Panel2.SuspendLayout();
            this.scInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemLable
            // 
            this.ItemLable.AutoSize = true;
            this.ItemLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemLable.ForeColor = System.Drawing.SystemColors.Control;
            this.ItemLable.Location = new System.Drawing.Point(2, 15);
            this.ItemLable.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.ItemLable.Name = "ItemLable";
            this.ItemLable.Size = new System.Drawing.Size(124, 26);
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
            this.cbItemType.Location = new System.Drawing.Point(126, 8);
            this.cbItemType.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(103, 38);
            this.cbItemType.TabIndex = 1;
            this.cbItemType.SelectedIndexChanged += new System.EventHandler(this.comboBoxItem_SelectedIndexChanged);
            // 
            // dataGridInv
            // 
            this.dataGridInv.AllowUserToAddRows = false;
            this.dataGridInv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.column_item_id,
            this.column_item_type,
            this.column_brand,
            this.column_serial,
            this.column_condition,
            this.column_acquisition_date,
            this.column_manufacture_date,
            this.column_location,
            this.column_size,
            this.column_material,
            this.column_color,
            this.column_edit,
            this.column_delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridInv.EnableHeadersVisualStyles = false;
            this.dataGridInv.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridInv.Location = new System.Drawing.Point(0, 0);
            this.dataGridInv.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridInv.Name = "dataGridInv";
            this.dataGridInv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridInv.RowHeadersVisible = false;
            this.dataGridInv.RowHeadersWidth = 51;
            this.dataGridInv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridInv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridInv.RowTemplate.Height = 40;
            this.dataGridInv.RowTemplate.ReadOnly = true;
            this.dataGridInv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInv.Size = new System.Drawing.Size(910, 728);
            this.dataGridInv.TabIndex = 1;
            this.dataGridInv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridInv_CellClick);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSearch.Location = new System.Drawing.Point(229, 14);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(94, 26);
            this.labelSearch.TabIndex = 19;
            this.labelSearch.Text = "Search:";
            // 
            // searchBar
            // 
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(327, 6);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(182, 37);
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
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Maroon;
            this.TopPanel.Controls.Add(this.btnSave);
            this.TopPanel.Controls.Add(this.CheckRented);
            this.TopPanel.Controls.Add(this.checkActive);
            this.TopPanel.Controls.Add(this.checkRetired);
            this.TopPanel.Controls.Add(this.btnAddUser);
            this.TopPanel.Controls.Add(this.labelSearch);
            this.TopPanel.Controls.Add(this.ItemLable);
            this.TopPanel.Controls.Add(this.searchBar);
            this.TopPanel.Controls.Add(this.cbItemType);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(2);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1370, 78);
            this.TopPanel.TabIndex = 20;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Location = new System.Drawing.Point(620, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CheckRented
            // 
            this.CheckRented.AutoSize = true;
            this.CheckRented.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckRented.ForeColor = System.Drawing.SystemColors.Window;
            this.CheckRented.Location = new System.Drawing.Point(517, 21);
            this.CheckRented.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckRented.Name = "CheckRented";
            this.CheckRented.Size = new System.Drawing.Size(96, 28);
            this.CheckRented.TabIndex = 24;
            this.CheckRented.Text = "Rented";
            this.CheckRented.UseVisualStyleBackColor = true;
            this.CheckRented.CheckedChanged += new System.EventHandler(this.RentedCheck_CheckedChanged);
            // 
            // checkActive
            // 
            this.checkActive.AutoSize = true;
            this.checkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkActive.ForeColor = System.Drawing.SystemColors.Window;
            this.checkActive.Location = new System.Drawing.Point(517, 0);
            this.checkActive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkActive.Name = "checkActive";
            this.checkActive.Size = new System.Drawing.Size(86, 28);
            this.checkActive.TabIndex = 23;
            this.checkActive.Text = "Active";
            this.checkActive.UseVisualStyleBackColor = true;
            this.checkActive.Click += new System.EventHandler(this.checkActive_Click);
            // 
            // checkRetired
            // 
            this.checkRetired.AutoSize = true;
            this.checkRetired.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRetired.ForeColor = System.Drawing.SystemColors.Window;
            this.checkRetired.Location = new System.Drawing.Point(517, 45);
            this.checkRetired.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkRetired.Name = "checkRetired";
            this.checkRetired.Size = new System.Drawing.Size(96, 28);
            this.checkRetired.TabIndex = 21;
            this.checkRetired.Text = "Retired";
            this.checkRetired.UseVisualStyleBackColor = true;
            this.checkRetired.Click += new System.EventHandler(this.checkRetired_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnAddUser.ImageHover")));
            this.btnAddUser.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnAddUser.ImageNormal")));
            this.btnAddUser.Location = new System.Drawing.Point(620, 40);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(44, 33);
            this.btnAddUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddUser.TabIndex = 17;
            this.btnAddUser.TabStop = false;
            this.btnAddUser.Click += new System.EventHandler(this.UsersButton_Click_1);
            // 
            // scOuter
            // 
            this.scOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOuter.Location = new System.Drawing.Point(0, 78);
            this.scOuter.Name = "scOuter";
            // 
            // scOuter.Panel1
            // 
            this.scOuter.Panel1.Controls.Add(this.scInner);
            // 
            // scOuter.Panel2
            // 
            this.scOuter.Panel2.Controls.Add(this.dataGridInv);
            this.scOuter.Size = new System.Drawing.Size(1370, 728);
            this.scOuter.SplitterDistance = 456;
            this.scOuter.TabIndex = 21;
            // 
            // scInner
            // 
            this.scInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scInner.Location = new System.Drawing.Point(0, 0);
            this.scInner.Margin = new System.Windows.Forms.Padding(1);
            this.scInner.Name = "scInner";
            // 
            // scInner.Panel2
            // 
            this.scInner.Panel2.Controls.Add(this.btnToggleFilter);
            this.scInner.Size = new System.Drawing.Size(456, 728);
            this.scInner.SplitterDistance = 151;
            this.scInner.SplitterWidth = 36;
            this.scInner.TabIndex = 0;
            // 
            // btnToggleFilter
            // 
            this.btnToggleFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToggleFilter.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnToggleFilter.Location = new System.Drawing.Point(0, 0);
            this.btnToggleFilter.Margin = new System.Windows.Forms.Padding(1);
            this.btnToggleFilter.Name = "btnToggleFilter";
            this.btnToggleFilter.Size = new System.Drawing.Size(269, 728);
            this.btnToggleFilter.TabIndex = 0;
            this.btnToggleFilter.Text = "Toggle Filter";
            this.btnToggleFilter.UseVisualStyleBackColor = true;
            this.btnToggleFilter.Click += new System.EventHandler(this.btnToggleFilter_Click);
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
            // column_item_type
            // 
            this.column_item_type.HeaderText = "Type";
            this.column_item_type.Name = "column_item_type";
            this.column_item_type.ReadOnly = true;
            this.column_item_type.Visible = false;
            // 
            // column_brand
            // 
            this.column_brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_brand.HeaderText = "Brand";
            this.column_brand.MinimumWidth = 6;
            this.column_brand.Name = "column_brand";
            this.column_brand.ReadOnly = true;
            // 
            // column_serial
            // 
            this.column_serial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_serial.HeaderText = "Serial #";
            this.column_serial.MinimumWidth = 6;
            this.column_serial.Name = "column_serial";
            this.column_serial.ReadOnly = true;
            // 
            // column_condition
            // 
            this.column_condition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_condition.FillWeight = 60F;
            this.column_condition.HeaderText = "Condition";
            this.column_condition.MinimumWidth = 6;
            this.column_condition.Name = "column_condition";
            this.column_condition.ReadOnly = true;
            // 
            // column_acquisition_date
            // 
            this.column_acquisition_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_acquisition_date.HeaderText = "Acquisition";
            this.column_acquisition_date.MinimumWidth = 6;
            this.column_acquisition_date.Name = "column_acquisition_date";
            this.column_acquisition_date.ReadOnly = true;
            // 
            // column_manufacture_date
            // 
            this.column_manufacture_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_manufacture_date.HeaderText = "MFD";
            this.column_manufacture_date.MinimumWidth = 6;
            this.column_manufacture_date.Name = "column_manufacture_date";
            this.column_manufacture_date.ReadOnly = true;
            // 
            // column_location
            // 
            this.column_location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_location.HeaderText = "Location";
            this.column_location.MinimumWidth = 6;
            this.column_location.Name = "column_location";
            this.column_location.ReadOnly = true;
            this.column_location.Visible = false;
            // 
            // column_size
            // 
            this.column_size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_size.FillWeight = 40F;
            this.column_size.HeaderText = "Size";
            this.column_size.MinimumWidth = 6;
            this.column_size.Name = "column_size";
            this.column_size.ReadOnly = true;
            this.column_size.Visible = false;
            // 
            // column_material
            // 
            this.column_material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_material.FillWeight = 55F;
            this.column_material.HeaderText = "Material";
            this.column_material.MinimumWidth = 6;
            this.column_material.Name = "column_material";
            this.column_material.ReadOnly = true;
            this.column_material.Visible = false;
            // 
            // column_color
            // 
            this.column_color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_color.HeaderText = "Color";
            this.column_color.MinimumWidth = 8;
            this.column_color.Name = "column_color";
            this.column_color.ReadOnly = true;
            this.column_color.Visible = false;
            // 
            // column_edit
            // 
            this.column_edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_edit.FillWeight = 30F;
            this.column_edit.HeaderText = "";
            this.column_edit.Image = ((System.Drawing.Image)(resources.GetObject("column_edit.Image")));
            this.column_edit.MinimumWidth = 6;
            this.column_edit.Name = "column_edit";
            this.column_edit.ReadOnly = true;
            // 
            // column_delete
            // 
            this.column_delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_delete.FillWeight = 30F;
            this.column_delete.HeaderText = "";
            this.column_delete.MinimumWidth = 6;
            this.column_delete.Name = "column_delete";
            this.column_delete.ReadOnly = true;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1370, 806);
            this.Controls.Add(this.scOuter);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInv)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).EndInit();
            this.scOuter.Panel1.ResumeLayout(false);
            this.scOuter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scOuter)).EndInit();
            this.scOuter.ResumeLayout(false);
            this.scInner.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInner)).EndInit();
            this.scInner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label ItemLable;
        private System.Windows.Forms.DataGridView dataGridInv;
        private CustomButton btnAddUser;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.CheckBox checkRetired;
        private System.Windows.Forms.CheckBox checkActive;
        public System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.SplitContainer scOuter;
        private System.Windows.Forms.SplitContainer scInner;
        private System.Windows.Forms.Button btnToggleFilter;
        private System.Windows.Forms.CheckBox CheckRented;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_item_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_condition;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_acquisition_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_manufacture_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_material;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_color;
        private System.Windows.Forms.DataGridViewImageColumn column_edit;
        private System.Windows.Forms.DataGridViewImageColumn column_delete;
    }
}