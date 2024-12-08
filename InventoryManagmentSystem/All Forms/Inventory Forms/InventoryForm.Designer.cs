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
            this.dataGridInv = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_manufacture_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_acquisition_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_item_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.column_delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.scOuter = new System.Windows.Forms.SplitContainer();
            this.btnAddUser = new InventoryManagmentSystem.CustomButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.btn_filters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scOuter)).BeginInit();
            this.scOuter.Panel2.SuspendLayout();
            this.scOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.column_size,
            this.column_color,
            this.column_material,
            this.column_brand,
            this.column_condition,
            this.column_serial,
            this.column_manufacture_date,
            this.column_acquisition_date,
            this.column_location,
            this.column_item_type,
            this.column_client,
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
            this.dataGridInv.Size = new System.Drawing.Size(910, 733);
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
            this.column_item_id.Width = 125;
            // 
            // column_size
            // 
            this.column_size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_size.FillWeight = 40F;
            this.column_size.HeaderText = "Size";
            this.column_size.MinimumWidth = 6;
            this.column_size.Name = "column_size";
            this.column_size.ReadOnly = true;
            // 
            // column_color
            // 
            this.column_color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_color.HeaderText = "Color";
            this.column_color.MinimumWidth = 8;
            this.column_color.Name = "column_color";
            this.column_color.ReadOnly = true;
            // 
            // column_material
            // 
            this.column_material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_material.FillWeight = 55F;
            this.column_material.HeaderText = "Material";
            this.column_material.MinimumWidth = 6;
            this.column_material.Name = "column_material";
            this.column_material.ReadOnly = true;
            // 
            // column_brand
            // 
            this.column_brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_brand.HeaderText = "Brand";
            this.column_brand.MinimumWidth = 6;
            this.column_brand.Name = "column_brand";
            this.column_brand.ReadOnly = true;
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
            // column_serial
            // 
            this.column_serial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_serial.HeaderText = "Serial #";
            this.column_serial.MinimumWidth = 6;
            this.column_serial.Name = "column_serial";
            this.column_serial.ReadOnly = true;
            // 
            // column_manufacture_date
            // 
            this.column_manufacture_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_manufacture_date.HeaderText = "MFD";
            this.column_manufacture_date.MinimumWidth = 6;
            this.column_manufacture_date.Name = "column_manufacture_date";
            this.column_manufacture_date.ReadOnly = true;
            // 
            // column_acquisition_date
            // 
            this.column_acquisition_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_acquisition_date.HeaderText = "Acquisition";
            this.column_acquisition_date.MinimumWidth = 6;
            this.column_acquisition_date.Name = "column_acquisition_date";
            this.column_acquisition_date.ReadOnly = true;
            // 
            // column_location
            // 
            this.column_location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_location.HeaderText = "Location";
            this.column_location.MinimumWidth = 6;
            this.column_location.Name = "column_location";
            this.column_location.ReadOnly = true;
            // 
            // column_item_type
            // 
            this.column_item_type.HeaderText = "Type";
            this.column_item_type.MinimumWidth = 6;
            this.column_item_type.Name = "column_item_type";
            this.column_item_type.ReadOnly = true;
            this.column_item_type.Width = 125;
            // 
            // column_client
            // 
            this.column_client.HeaderText = "Client";
            this.column_client.MinimumWidth = 6;
            this.column_client.Name = "column_client";
            this.column_client.ReadOnly = true;
            this.column_client.Width = 125;
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
            // scOuter
            // 
            this.scOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOuter.Location = new System.Drawing.Point(0, 73);
            this.scOuter.Name = "scOuter";
            // 
            // scOuter.Panel2
            // 
            this.scOuter.Panel2.Controls.Add(this.dataGridInv);
            this.scOuter.Size = new System.Drawing.Size(1370, 733);
            this.scOuter.SplitterDistance = 456;
            this.scOuter.TabIndex = 21;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnAddUser.ImageHover")));
            this.btnAddUser.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnAddUser.ImageNormal")));
            this.btnAddUser.Location = new System.Drawing.Point(1283, 4);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(82, 64);
            this.btnAddUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddUser.TabIndex = 17;
            this.btnAddUser.TabStop = false;
            this.btnAddUser.Click += new System.EventHandler(this.Btn_Users_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Location = new System.Drawing.Point(1171, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 60);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Maroon;
            this.TopPanel.Controls.Add(this.btn_filters);
            this.TopPanel.Controls.Add(this.btnSave);
            this.TopPanel.Controls.Add(this.btnAddUser);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(2);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1370, 73);
            this.TopPanel.TabIndex = 20;
            // 
            // btn_filters
            // 
            this.btn_filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btn_filters.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_filters.Location = new System.Drawing.Point(28, 7);
            this.btn_filters.Name = "btn_filters";
            this.btn_filters.Size = new System.Drawing.Size(109, 60);
            this.btn_filters.TabIndex = 26;
            this.btn_filters.Text = "Filters";
            this.btn_filters.UseVisualStyleBackColor = true;
            this.btn_filters.Click += new System.EventHandler(this.Btn_Filter_Click);
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
            this.scOuter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scOuter)).EndInit();
            this.scOuter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridInv;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.SplitContainer scOuter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_material;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_condition;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_manufacture_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_acquisition_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_item_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_client;
        private System.Windows.Forms.DataGridViewImageColumn column_edit;
        private System.Windows.Forms.DataGridViewImageColumn column_delete;
        private CustomButton btnAddUser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button btn_filters;
    }
}