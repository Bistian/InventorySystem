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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ItemLable = new System.Windows.Forms.Label();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.dataGridInv = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.labelInv = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.UsersButton = new InventoryManagmentSystem.CustomButton();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufactureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsedNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInv)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersButton)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.flowLayoutPanel1.Controls.Add(this.ItemLable);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxItem);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ItemLable
            // 
            this.ItemLable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ItemLable.AutoSize = true;
            this.ItemLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemLable.ForeColor = System.Drawing.SystemColors.Control;
            this.ItemLable.Location = new System.Drawing.Point(2, 9);
            this.ItemLable.Margin = new System.Windows.Forms.Padding(2, 8, 0, 0);
            this.ItemLable.Name = "ItemLable";
            this.ItemLable.Size = new System.Drawing.Size(45, 20);
            this.ItemLable.TabIndex = 0;
            this.ItemLable.Text = "Item:";
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Items.AddRange(new object[] {
            "Helmets",
            "Jackets",
            "Pants",
            "Boots"});
            this.comboBoxItem.Location = new System.Drawing.Point(47, 8);
            this.comboBoxItem.Margin = new System.Windows.Forms.Padding(0, 8, 0, 2);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(92, 21);
            this.comboBoxItem.TabIndex = 1;
            this.comboBoxItem.SelectedIndexChanged += new System.EventHandler(this.comboBoxItem_SelectedIndexChanged);
            // 
            // dataGridInv
            // 
            this.dataGridInv.AllowUserToAddRows = false;
            this.dataGridInv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Type,
            this.Brand,
            this.Serial,
            this.Size,
            this.ManufactureDate,
            this.UsedNew,
            this.ColorMaterial,
            this.Location,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridInv.EnableHeadersVisualStyles = false;
            this.dataGridInv.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridInv.Location = new System.Drawing.Point(0, 32);
            this.dataGridInv.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridInv.Name = "dataGridInv";
            this.dataGridInv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridInv.RowHeadersVisible = false;
            this.dataGridInv.RowHeadersWidth = 51;
            this.dataGridInv.RowTemplate.Height = 24;
            this.dataGridInv.RowTemplate.ReadOnly = true;
            this.dataGridInv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInv.Size = new System.Drawing.Size(776, 365);
            this.dataGridInv.TabIndex = 1;
            this.dataGridInv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridInv_CellClick);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Controls.Add(this.searchBar);
            this.panelBottom.Controls.Add(this.UsersButton);
            this.panelBottom.Controls.Add(this.labelInv);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 354);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(776, 43);
            this.panelBottom.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(419, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Search";
            // 
            // searchBar
            // 
            this.searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar.Location = new System.Drawing.Point(497, 13);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(208, 20);
            this.searchBar.TabIndex = 18;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // labelInv
            // 
            this.labelInv.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelInv.AutoSize = true;
            this.labelInv.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelInv.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelInv.Location = new System.Drawing.Point(9, 12);
            this.labelInv.Margin = new System.Windows.Forms.Padding(2, 12, 2, 0);
            this.labelInv.Name = "labelInv";
            this.labelInv.Size = new System.Drawing.Size(168, 24);
            this.labelInv.TabIndex = 15;
            this.labelInv.Text = "Manage Inventory";
            this.labelInv.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // UsersButton
            // 
            this.UsersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersButton.Image = ((System.Drawing.Image)(resources.GetObject("UsersButton.Image")));
            this.UsersButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("UsersButton.ImageHover")));
            this.UsersButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("UsersButton.ImageNormal")));
            this.UsersButton.Location = new System.Drawing.Point(712, 12);
            this.UsersButton.Margin = new System.Windows.Forms.Padding(562, 12, 2, 2);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(38, 21);
            this.UsersButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UsersButton.TabIndex = 17;
            this.UsersButton.TabStop = false;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click_1);
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
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.FillWeight = 50F;
            this.Type.HeaderText = "Item";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
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
            // Size
            // 
            this.Size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Size.FillWeight = 40F;
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 6;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            // 
            // ManufactureDate
            // 
            this.ManufactureDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ManufactureDate.FillWeight = 120F;
            this.ManufactureDate.HeaderText = "MFD";
            this.ManufactureDate.MinimumWidth = 6;
            this.ManufactureDate.Name = "ManufactureDate";
            this.ManufactureDate.ReadOnly = true;
            // 
            // UsedNew
            // 
            this.UsedNew.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UsedNew.FillWeight = 50F;
            this.UsedNew.HeaderText = "Used";
            this.UsedNew.MinimumWidth = 6;
            this.UsedNew.Name = "UsedNew";
            this.UsedNew.ReadOnly = true;
            // 
            // ColorMaterial
            // 
            this.ColorMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColorMaterial.FillWeight = 55F;
            this.ColorMaterial.HeaderText = "Color / Material";
            this.ColorMaterial.MinimumWidth = 6;
            this.ColorMaterial.Name = "ColorMaterial";
            this.ColorMaterial.ReadOnly = true;
            // 
            // Location
            // 
            this.Location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.MinimumWidth = 6;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 25;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 25;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 397);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.dataGridInv);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInv)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label ItemLable;
        private System.Windows.Forms.ComboBox comboBoxItem;
        private System.Windows.Forms.DataGridView dataGridInv;
        private System.Windows.Forms.Panel panelBottom;
        private CustomButton UsersButton;
        private System.Windows.Forms.Label labelInv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufactureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsedNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}