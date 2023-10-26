namespace InventoryManagmentSystem.Academy
{
    partial class ClassRosterForm
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
            this.dataGridStudents = new System.Windows.Forms.DataGridView();
            this.column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_drivers_license = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudents)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridStudents
            // 
            this.dataGridStudents.AllowUserToAddRows = false;
            this.dataGridStudents.AllowUserToResizeColumns = false;
            this.dataGridStudents.AllowUserToResizeRows = false;
            this.dataGridStudents.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_number,
            this.column_drivers_license,
            this.column_student,
            this.column_phone,
            this.column_email});
            this.dataGridStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridStudents.EnableHeadersVisualStyles = false;
            this.dataGridStudents.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridStudents.Location = new System.Drawing.Point(0, 42);
            this.dataGridStudents.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridStudents.Name = "dataGridStudents";
            this.dataGridStudents.ReadOnly = true;
            this.dataGridStudents.RowHeadersVisible = false;
            this.dataGridStudents.RowHeadersWidth = 51;
            this.dataGridStudents.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridStudents.RowTemplate.Height = 40;
            this.dataGridStudents.Size = new System.Drawing.Size(933, 477);
            this.dataGridStudents.TabIndex = 29;
            this.dataGridStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridStudents_CellClick);
            // 
            // column_number
            // 
            this.column_number.FillWeight = 25F;
            this.column_number.HeaderText = "#";
            this.column_number.MinimumWidth = 6;
            this.column_number.Name = "column_number";
            this.column_number.ReadOnly = true;
            this.column_number.Width = 25;
            // 
            // column_drivers_license
            // 
            this.column_drivers_license.FillWeight = 1F;
            this.column_drivers_license.HeaderText = "DriversLicense";
            this.column_drivers_license.MinimumWidth = 6;
            this.column_drivers_license.Name = "column_drivers_license";
            this.column_drivers_license.ReadOnly = true;
            this.column_drivers_license.Visible = false;
            this.column_drivers_license.Width = 125;
            // 
            // column_student
            // 
            this.column_student.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_student.FillWeight = 78.16801F;
            this.column_student.HeaderText = "Student";
            this.column_student.MinimumWidth = 6;
            this.column_student.Name = "column_student";
            this.column_student.ReadOnly = true;
            // 
            // column_phone
            // 
            this.column_phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_phone.FillWeight = 70F;
            this.column_phone.HeaderText = "Phone";
            this.column_phone.MinimumWidth = 8;
            this.column_phone.Name = "column_phone";
            this.column_phone.ReadOnly = true;
            // 
            // column_email
            // 
            this.column_email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_email.HeaderText = "Email";
            this.column_email.MinimumWidth = 8;
            this.column_email.Name = "column_email";
            this.column_email.ReadOnly = true;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.button1);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Controls.Add(this.labelSearch);
            this.panelTop.Controls.Add(this.searchBar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(933, 42);
            this.panelTop.TabIndex = 28;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTitle.Location = new System.Drawing.Point(3, 3);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(142, 26);
            this.labelTitle.TabIndex = 24;
            this.labelTitle.Text = "Class Name";
            // 
            // labelSearch
            // 
            this.labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSearch.Location = new System.Drawing.Point(608, 9);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(71, 20);
            this.labelSearch.TabIndex = 23;
            this.labelSearch.Text = "Search:";
            // 
            // searchBar
            // 
            this.searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(694, 9);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(234, 21);
            this.searchBar.TabIndex = 22;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button1.Location = new System.Drawing.Point(565, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClassRosterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.dataGridStudents);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ClassRosterForm";
            this.Text = "ClassRosterForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudents)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridStudents;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_drivers_license;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_student;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_email;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button button1;
    }
}