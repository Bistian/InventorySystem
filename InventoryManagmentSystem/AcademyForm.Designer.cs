namespace InventoryManagmentSystem
{
    partial class AcademyForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.tbAcademyName = new System.Windows.Forms.TextBox();
            this.labelAcademyName = new System.Windows.Forms.Label();
            this.labelBrand = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.dataGridAcademies = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAcademies)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitle.Location = new System.Drawing.Point(13, 9);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(174, 25);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Create Academies";
            // 
            // tbAcademyName
            // 
            this.tbAcademyName.Location = new System.Drawing.Point(21, 56);
            this.tbAcademyName.Name = "tbAcademyName";
            this.tbAcademyName.Size = new System.Drawing.Size(127, 21);
            this.tbAcademyName.TabIndex = 2;
            // 
            // labelAcademyName
            // 
            this.labelAcademyName.AutoSize = true;
            this.labelAcademyName.Location = new System.Drawing.Point(18, 38);
            this.labelAcademyName.Name = "labelAcademyName";
            this.labelAcademyName.Size = new System.Drawing.Size(94, 15);
            this.labelAcademyName.TabIndex = 3;
            this.labelAcademyName.Text = "Academy Name";
            // 
            // labelBrand
            // 
            this.labelBrand.AutoSize = true;
            this.labelBrand.Location = new System.Drawing.Point(18, 80);
            this.labelBrand.Name = "labelBrand";
            this.labelBrand.Size = new System.Drawing.Size(40, 15);
            this.labelBrand.TabIndex = 4;
            this.labelBrand.Text = "Brand";
            // 
            // cbBrand
            // 
            this.cbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(21, 99);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(127, 23);
            this.cbBrand.TabIndex = 5;
            // 
            // dataGridAcademies
            // 
            this.dataGridAcademies.AllowUserToAddRows = false;
            this.dataGridAcademies.AllowUserToResizeColumns = false;
            this.dataGridAcademies.AllowUserToResizeRows = false;
            this.dataGridAcademies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridAcademies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAcademies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridAcademies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAcademies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_number,
            this.column_id,
            this.column_name,
            this.column_brand,
            this.column_delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridAcademies.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridAcademies.EnableHeadersVisualStyles = false;
            this.dataGridAcademies.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridAcademies.Location = new System.Drawing.Point(194, 9);
            this.dataGridAcademies.Name = "dataGridAcademies";
            this.dataGridAcademies.ReadOnly = true;
            this.dataGridAcademies.RowHeadersVisible = false;
            this.dataGridAcademies.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridAcademies.RowTemplate.Height = 40;
            this.dataGridAcademies.Size = new System.Drawing.Size(295, 143);
            this.dataGridAcademies.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAdd.Location = new System.Drawing.Point(21, 129);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(127, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // column_number
            // 
            this.column_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_number.FillWeight = 30F;
            this.column_number.HeaderText = "#";
            this.column_number.Name = "column_number";
            this.column_number.ReadOnly = true;
            // 
            // column_id
            // 
            this.column_id.HeaderText = "Id";
            this.column_id.Name = "column_id";
            this.column_id.ReadOnly = true;
            this.column_id.Visible = false;
            // 
            // column_name
            // 
            this.column_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_name.HeaderText = "Name";
            this.column_name.Name = "column_name";
            this.column_name.ReadOnly = true;
            // 
            // column_brand
            // 
            this.column_brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_brand.HeaderText = "Brand";
            this.column_brand.Name = "column_brand";
            this.column_brand.ReadOnly = true;
            // 
            // column_delete
            // 
            this.column_delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_delete.FillWeight = 25F;
            this.column_delete.HeaderText = "";
            this.column_delete.Name = "column_delete";
            this.column_delete.ReadOnly = true;
            this.column_delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.column_delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AcademyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridAcademies);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.labelBrand);
            this.Controls.Add(this.labelAcademyName);
            this.Controls.Add(this.tbAcademyName);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AcademyForm";
            this.Text = "AcademyForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAcademies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox tbAcademyName;
        private System.Windows.Forms.Label labelAcademyName;
        private System.Windows.Forms.Label labelBrand;
        private System.Windows.Forms.ComboBox cbBrand;
        public System.Windows.Forms.DataGridView dataGridAcademies;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_brand;
        private System.Windows.Forms.DataGridViewImageColumn column_delete;
    }
}