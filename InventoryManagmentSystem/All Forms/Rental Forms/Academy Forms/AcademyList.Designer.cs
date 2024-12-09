namespace InventoryManagmentSystem.Academy
{
    partial class AcademyList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcademyList));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelAcademyName = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.dataGridAcademies = new System.Windows.Forms.DataGridView();
            this.column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_contact_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_zip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_update = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelBot = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAcademies)).BeginInit();
            this.panelBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnSave);
            this.panelTop.Controls.Add(this.labelAcademyName);
            this.panelTop.Controls.Add(this.labelSearch);
            this.panelTop.Controls.Add(this.searchBar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1500, 43);
            this.panelTop.TabIndex = 25;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1447, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 28);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelAcademyName
            // 
            this.labelAcademyName.AutoSize = true;
            this.labelAcademyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAcademyName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelAcademyName.Location = new System.Drawing.Point(3, 4);
            this.labelAcademyName.Name = "labelAcademyName";
            this.labelAcademyName.Size = new System.Drawing.Size(189, 31);
            this.labelAcademyName.TabIndex = 23;
            this.labelAcademyName.Text = "Academy List";
            // 
            // labelSearch
            // 
            this.labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSearch.Location = new System.Drawing.Point(1028, 12);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(115, 31);
            this.labelSearch.TabIndex = 21;
            this.labelSearch.Text = "Search:";
            // 
            // searchBar
            // 
            this.searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(1131, 4);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(310, 41);
            this.searchBar.TabIndex = 20;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // dataGridAcademies
            // 
            this.dataGridAcademies.AllowUserToAddRows = false;
            this.dataGridAcademies.AllowUserToResizeColumns = false;
            this.dataGridAcademies.AllowUserToResizeRows = false;
            this.dataGridAcademies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridAcademies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAcademies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridAcademies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAcademies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_number,
            this.column_id,
            this.column_name,
            this.column_contact_name,
            this.column_email,
            this.column_phone,
            this.column_street,
            this.column_city,
            this.column_state,
            this.column_zip,
            this.column_update});
            this.dataGridAcademies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAcademies.EnableHeadersVisualStyles = false;
            this.dataGridAcademies.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridAcademies.Location = new System.Drawing.Point(0, 0);
            this.dataGridAcademies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridAcademies.Name = "dataGridAcademies";
            this.dataGridAcademies.ReadOnly = true;
            this.dataGridAcademies.RowHeadersVisible = false;
            this.dataGridAcademies.RowHeadersWidth = 51;
            this.dataGridAcademies.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridAcademies.RowTemplate.Height = 40;
            this.dataGridAcademies.Size = new System.Drawing.Size(1500, 726);
            this.dataGridAcademies.TabIndex = 26;
            this.dataGridAcademies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAcademies_CellClick);
            // 
            // column_number
            // 
            this.column_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_number.FillWeight = 30F;
            this.column_number.HeaderText = "#";
            this.column_number.MinimumWidth = 6;
            this.column_number.Name = "column_number";
            this.column_number.ReadOnly = true;
            // 
            // column_id
            // 
            this.column_id.HeaderText = "Id";
            this.column_id.MinimumWidth = 6;
            this.column_id.Name = "column_id";
            this.column_id.ReadOnly = true;
            this.column_id.Visible = false;
            this.column_id.Width = 125;
            // 
            // column_name
            // 
            this.column_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_name.HeaderText = "Name";
            this.column_name.MinimumWidth = 6;
            this.column_name.Name = "column_name";
            this.column_name.ReadOnly = true;
            // 
            // column_contact_name
            // 
            this.column_contact_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_contact_name.HeaderText = "Contact Name";
            this.column_contact_name.MinimumWidth = 6;
            this.column_contact_name.Name = "column_contact_name";
            this.column_contact_name.ReadOnly = true;
            // 
            // column_email
            // 
            this.column_email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_email.HeaderText = "Email";
            this.column_email.MinimumWidth = 6;
            this.column_email.Name = "column_email";
            this.column_email.ReadOnly = true;
            // 
            // column_phone
            // 
            this.column_phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_phone.HeaderText = "Phone";
            this.column_phone.MinimumWidth = 6;
            this.column_phone.Name = "column_phone";
            this.column_phone.ReadOnly = true;
            // 
            // column_street
            // 
            this.column_street.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_street.HeaderText = "Street";
            this.column_street.MinimumWidth = 6;
            this.column_street.Name = "column_street";
            this.column_street.ReadOnly = true;
            // 
            // column_city
            // 
            this.column_city.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_city.HeaderText = "City";
            this.column_city.MinimumWidth = 6;
            this.column_city.Name = "column_city";
            this.column_city.ReadOnly = true;
            // 
            // column_state
            // 
            this.column_state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_state.FillWeight = 30F;
            this.column_state.HeaderText = "State";
            this.column_state.MinimumWidth = 6;
            this.column_state.Name = "column_state";
            this.column_state.ReadOnly = true;
            // 
            // column_zip
            // 
            this.column_zip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_zip.FillWeight = 50F;
            this.column_zip.HeaderText = "Zip";
            this.column_zip.MinimumWidth = 6;
            this.column_zip.Name = "column_zip";
            this.column_zip.ReadOnly = true;
            // 
            // column_update
            // 
            this.column_update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_update.FillWeight = 25F;
            this.column_update.HeaderText = "";
            this.column_update.Image = ((System.Drawing.Image)(resources.GetObject("column_update.Image")));
            this.column_update.MinimumWidth = 6;
            this.column_update.Name = "column_update";
            this.column_update.ReadOnly = true;
            this.column_update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.column_update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panelBot
            // 
            this.panelBot.Controls.Add(this.dataGridAcademies);
            this.panelBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBot.Location = new System.Drawing.Point(0, 43);
            this.panelBot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBot.Name = "panelBot";
            this.panelBot.Size = new System.Drawing.Size(1500, 726);
            this.panelBot.TabIndex = 27;
            // 
            // AcademyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1500, 769);
            this.Controls.Add(this.panelBot);
            this.Controls.Add(this.panelTop);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AcademyList";
            this.Text = "AcademyList";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAcademies)).EndInit();
            this.panelBot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        public System.Windows.Forms.DataGridView dataGridAcademies;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.Panel panelBot;
        private System.Windows.Forms.Label labelAcademyName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_contact_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_street;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_city;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_zip;
        private System.Windows.Forms.DataGridViewImageColumn column_update;
    }
}