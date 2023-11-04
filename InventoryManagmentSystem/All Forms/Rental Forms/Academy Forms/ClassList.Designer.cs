namespace InventoryManagmentSystem.Academy
{
    partial class ClassList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassList));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelAcademyName = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.dataGridClasses = new System.Windows.Forms.DataGridView();
            this.column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_academy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_finished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.column_update = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClasses)).BeginInit();
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
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(666, 27);
            this.panelTop.TabIndex = 26;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Location = new System.Drawing.Point(407, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelAcademyName
            // 
            this.labelAcademyName.AutoSize = true;
            this.labelAcademyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAcademyName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelAcademyName.Location = new System.Drawing.Point(2, 5);
            this.labelAcademyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAcademyName.Name = "labelAcademyName";
            this.labelAcademyName.Size = new System.Drawing.Size(117, 26);
            this.labelAcademyName.TabIndex = 22;
            this.labelAcademyName.Text = "Class List";
            // 
            // labelSearch
            // 
            this.labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSearch.Location = new System.Drawing.Point(450, 5);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(71, 20);
            this.labelSearch.TabIndex = 21;
            this.labelSearch.Text = "Search:";
            // 
            // searchBar
            // 
            this.searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(507, 5);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(157, 21);
            this.searchBar.TabIndex = 20;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // dataGridClasses
            // 
            this.dataGridClasses.AllowUserToAddRows = false;
            this.dataGridClasses.AllowUserToResizeColumns = false;
            this.dataGridClasses.AllowUserToResizeRows = false;
            this.dataGridClasses.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridClasses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridClasses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_number,
            this.column_id,
            this.column_academy,
            this.column_name,
            this.column_start_date,
            this.column_end_date,
            this.column_finished,
            this.column_update});
            this.dataGridClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridClasses.EnableHeadersVisualStyles = false;
            this.dataGridClasses.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridClasses.Location = new System.Drawing.Point(0, 27);
            this.dataGridClasses.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridClasses.Name = "dataGridClasses";
            this.dataGridClasses.ReadOnly = true;
            this.dataGridClasses.RowHeadersVisible = false;
            this.dataGridClasses.RowHeadersWidth = 51;
            this.dataGridClasses.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridClasses.RowTemplate.Height = 40;
            this.dataGridClasses.Size = new System.Drawing.Size(666, 443);
            this.dataGridClasses.TabIndex = 27;
            this.dataGridClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridClasses_CellClick);
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
            // column_id
            // 
            this.column_id.FillWeight = 1F;
            this.column_id.HeaderText = "Id";
            this.column_id.MinimumWidth = 6;
            this.column_id.Name = "column_id";
            this.column_id.ReadOnly = true;
            this.column_id.Visible = false;
            this.column_id.Width = 125;
            // 
            // column_academy
            // 
            this.column_academy.HeaderText = "Academy";
            this.column_academy.MinimumWidth = 8;
            this.column_academy.Name = "column_academy";
            this.column_academy.ReadOnly = true;
            this.column_academy.Width = 150;
            // 
            // column_name
            // 
            this.column_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_name.FillWeight = 78.16801F;
            this.column_name.HeaderText = "Name";
            this.column_name.MinimumWidth = 6;
            this.column_name.Name = "column_name";
            this.column_name.ReadOnly = true;
            // 
            // column_start_date
            // 
            this.column_start_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_start_date.FillWeight = 46.90081F;
            this.column_start_date.HeaderText = "Start";
            this.column_start_date.MinimumWidth = 6;
            this.column_start_date.Name = "column_start_date";
            this.column_start_date.ReadOnly = true;
            // 
            // column_end_date
            // 
            this.column_end_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_end_date.FillWeight = 46.90081F;
            this.column_end_date.HeaderText = "End";
            this.column_end_date.MinimumWidth = 6;
            this.column_end_date.Name = "column_end_date";
            this.column_end_date.ReadOnly = true;
            // 
            // column_finished
            // 
            this.column_finished.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_finished.FillWeight = 35F;
            this.column_finished.HeaderText = "Finished";
            this.column_finished.MinimumWidth = 6;
            this.column_finished.Name = "column_finished";
            this.column_finished.ReadOnly = true;
            this.column_finished.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column_finished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // column_update
            // 
            this.column_update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_update.FillWeight = 19.542F;
            this.column_update.HeaderText = "";
            this.column_update.Image = ((System.Drawing.Image)(resources.GetObject("column_update.Image")));
            this.column_update.MinimumWidth = 6;
            this.column_update.Name = "column_update";
            this.column_update.ReadOnly = true;
            // 
            // ClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(666, 470);
            this.Controls.Add(this.dataGridClasses);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClassList";
            this.Text = "ClassList";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClasses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox searchBar;
        public System.Windows.Forms.DataGridView dataGridClasses;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_academy;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_end_date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn column_finished;
        private System.Windows.Forms.DataGridViewImageColumn column_update;
        private System.Windows.Forms.Label labelAcademyName;
        private System.Windows.Forms.Button btnSave;
    }
}