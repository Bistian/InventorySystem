namespace InventoryManagmentSystem
{
    partial class CreateAcademyForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAcademyForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.tbAcademyName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.dataGridAcademies = new System.Windows.Forms.DataGridView();
            this.column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_zip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_update = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelState = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.labelStreet = new System.Windows.Forms.Label();
            this.tbStreet = new System.Windows.Forms.TextBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.labelZip = new System.Windows.Forms.Label();
            this.tbZip = new System.Windows.Forms.TextBox();
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
            this.tbAcademyName.Size = new System.Drawing.Size(166, 21);
            this.tbAcademyName.TabIndex = 2;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(18, 38);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 15);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name";
            // 
            // dataGridAcademies
            // 
            this.dataGridAcademies.AllowUserToAddRows = false;
            this.dataGridAcademies.AllowUserToResizeColumns = false;
            this.dataGridAcademies.AllowUserToResizeRows = false;
            this.dataGridAcademies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridAcademies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAcademies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridAcademies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAcademies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_number,
            this.column_id,
            this.column_name,
            this.column_email,
            this.column_phone,
            this.column_street,
            this.column_city,
            this.column_state,
            this.column_zip,
            this.column_update});
            this.dataGridAcademies.EnableHeadersVisualStyles = false;
            this.dataGridAcademies.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridAcademies.Location = new System.Drawing.Point(194, 9);
            this.dataGridAcademies.Name = "dataGridAcademies";
            this.dataGridAcademies.ReadOnly = true;
            this.dataGridAcademies.RowHeadersVisible = false;
            this.dataGridAcademies.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridAcademies.RowTemplate.Height = 40;
            this.dataGridAcademies.Size = new System.Drawing.Size(727, 309);
            this.dataGridAcademies.TabIndex = 6;
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
            // column_email
            // 
            this.column_email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_email.HeaderText = "Email";
            this.column_email.Name = "column_email";
            this.column_email.ReadOnly = true;
            // 
            // column_phone
            // 
            this.column_phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_phone.HeaderText = "Phone";
            this.column_phone.Name = "column_phone";
            this.column_phone.ReadOnly = true;
            // 
            // column_street
            // 
            this.column_street.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_street.HeaderText = "Street";
            this.column_street.Name = "column_street";
            this.column_street.ReadOnly = true;
            // 
            // column_city
            // 
            this.column_city.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_city.HeaderText = "City";
            this.column_city.Name = "column_city";
            this.column_city.ReadOnly = true;
            // 
            // column_state
            // 
            this.column_state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_state.FillWeight = 30F;
            this.column_state.HeaderText = "State";
            this.column_state.Name = "column_state";
            this.column_state.ReadOnly = true;
            // 
            // column_zip
            // 
            this.column_zip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_zip.FillWeight = 50F;
            this.column_zip.HeaderText = "Zip";
            this.column_zip.Name = "column_zip";
            this.column_zip.ReadOnly = true;
            // 
            // column_update
            // 
            this.column_update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_update.FillWeight = 25F;
            this.column_update.HeaderText = "";
            this.column_update.Image = ((System.Drawing.Image)(resources.GetObject("column_update.Image")));
            this.column_update.Name = "column_update";
            this.column_update.ReadOnly = true;
            this.column_update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.column_update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAdd.Location = new System.Drawing.Point(21, 295);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(166, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(18, 248);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(35, 15);
            this.labelState.TabIndex = 4;
            this.labelState.Text = "State";
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.cbState.Location = new System.Drawing.Point(21, 266);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(54, 23);
            this.cbState.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Email";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(21, 98);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(166, 21);
            this.tbEmail.TabIndex = 8;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(18, 122);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(43, 15);
            this.labelPhone.TabIndex = 11;
            this.labelPhone.Text = "Phone";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(21, 140);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(166, 21);
            this.tbPhone.TabIndex = 10;
            // 
            // labelStreet
            // 
            this.labelStreet.AutoSize = true;
            this.labelStreet.Location = new System.Drawing.Point(18, 164);
            this.labelStreet.Name = "labelStreet";
            this.labelStreet.Size = new System.Drawing.Size(39, 15);
            this.labelStreet.TabIndex = 13;
            this.labelStreet.Text = "Street";
            // 
            // tbStreet
            // 
            this.tbStreet.Location = new System.Drawing.Point(21, 182);
            this.tbStreet.Name = "tbStreet";
            this.tbStreet.Size = new System.Drawing.Size(166, 21);
            this.tbStreet.TabIndex = 12;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(18, 206);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(26, 15);
            this.labelCity.TabIndex = 15;
            this.labelCity.Text = "City";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(21, 224);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(166, 21);
            this.tbCity.TabIndex = 14;
            // 
            // labelZip
            // 
            this.labelZip.AutoSize = true;
            this.labelZip.Location = new System.Drawing.Point(78, 248);
            this.labelZip.Name = "labelZip";
            this.labelZip.Size = new System.Drawing.Size(24, 15);
            this.labelZip.TabIndex = 16;
            this.labelZip.Text = "Zip";
            // 
            // tbZip
            // 
            this.tbZip.Location = new System.Drawing.Point(81, 266);
            this.tbZip.Name = "tbZip";
            this.tbZip.Size = new System.Drawing.Size(106, 21);
            this.tbZip.TabIndex = 17;
            // 
            // CreateAcademyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(933, 330);
            this.Controls.Add(this.tbZip);
            this.Controls.Add(this.labelZip);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.labelStreet);
            this.Controls.Add(this.tbStreet);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridAcademies);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.tbAcademyName);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CreateAcademyForm";
            this.Text = "Create Academy";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAcademies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox tbAcademyName;
        private System.Windows.Forms.Label labelName;
        public System.Windows.Forms.DataGridView dataGridAcademies;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label labelStreet;
        private System.Windows.Forms.TextBox tbStreet;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_street;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_city;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_zip;
        private System.Windows.Forms.DataGridViewImageColumn column_update;
        private System.Windows.Forms.Label labelZip;
        private System.Windows.Forms.TextBox tbZip;
    }
}