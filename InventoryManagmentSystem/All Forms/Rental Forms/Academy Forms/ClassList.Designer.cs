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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassList));
            this.panelTop = new System.Windows.Forms.Panel();
            this.checkBoth = new System.Windows.Forms.CheckBox();
            this.checkInactive = new System.Windows.Forms.CheckBox();
            this.checkActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelAcademyName = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.dataGridClasses = new System.Windows.Forms.DataGridView();
            this.column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_academy_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_academy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_finished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.column_update = new System.Windows.Forms.DataGridViewImageColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClasses)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.flowLayoutPanel1);
            this.panelTop.Controls.Add(this.panel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1741, 44);
            this.panelTop.TabIndex = 26;
            // 
            // checkBoth
            // 
            this.checkBoth.AutoSize = true;
            this.checkBoth.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBoth.Location = new System.Drawing.Point(310, 4);
            this.checkBoth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoth.Name = "checkBoth";
            this.checkBoth.Size = new System.Drawing.Size(56, 20);
            this.checkBoth.TabIndex = 26;
            this.checkBoth.Text = "Both";
            this.checkBoth.UseVisualStyleBackColor = true;
            this.checkBoth.CheckedChanged += new System.EventHandler(this.CheckBox_Checked_Changed);
            // 
            // checkInactive
            // 
            this.checkInactive.AutoSize = true;
            this.checkInactive.ForeColor = System.Drawing.SystemColors.Window;
            this.checkInactive.Location = new System.Drawing.Point(227, 4);
            this.checkInactive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkInactive.Name = "checkInactive";
            this.checkInactive.Size = new System.Drawing.Size(75, 20);
            this.checkInactive.TabIndex = 25;
            this.checkInactive.Text = "Inactive";
            this.checkInactive.UseVisualStyleBackColor = true;
            this.checkInactive.CheckedChanged += new System.EventHandler(this.CheckBox_Checked_Changed);
            // 
            // checkActive
            // 
            this.checkActive.AutoSize = true;
            this.checkActive.ForeColor = System.Drawing.SystemColors.Window;
            this.checkActive.Location = new System.Drawing.Point(153, 4);
            this.checkActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkActive.Name = "checkActive";
            this.checkActive.Size = new System.Drawing.Size(66, 20);
            this.checkActive.TabIndex = 24;
            this.checkActive.Text = "Active";
            this.checkActive.UseVisualStyleBackColor = true;
            this.checkActive.CheckedChanged += new System.EventHandler(this.CheckBox_Checked_Changed);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Location = new System.Drawing.Point(428, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 28);
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
            this.labelAcademyName.Location = new System.Drawing.Point(3, 0);
            this.labelAcademyName.Name = "labelAcademyName";
            this.labelAcademyName.Size = new System.Drawing.Size(143, 31);
            this.labelAcademyName.TabIndex = 22;
            this.labelAcademyName.Text = "Class List";
            // 
            // labelSearch
            // 
            this.labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSearch.Location = new System.Drawing.Point(5, 7);
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
            this.searchBar.Location = new System.Drawing.Point(107, 4);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(313, 41);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridClasses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_number,
            this.column_id,
            this.column_academy_id,
            this.column_academy,
            this.column_name,
            this.column_start_date,
            this.column_end_date,
            this.column_finished,
            this.column_update});
            this.dataGridClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridClasses.EnableHeadersVisualStyles = false;
            this.dataGridClasses.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridClasses.Location = new System.Drawing.Point(0, 44);
            this.dataGridClasses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridClasses.Name = "dataGridClasses";
            this.dataGridClasses.ReadOnly = true;
            this.dataGridClasses.RowHeadersVisible = false;
            this.dataGridClasses.RowHeadersWidth = 51;
            this.dataGridClasses.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridClasses.RowTemplate.Height = 40;
            this.dataGridClasses.Size = new System.Drawing.Size(1741, 791);
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
            // column_academy_id
            // 
            this.column_academy_id.HeaderText = "Academy Id";
            this.column_academy_id.MinimumWidth = 6;
            this.column_academy_id.Name = "column_academy_id";
            this.column_academy_id.ReadOnly = true;
            this.column_academy_id.Visible = false;
            this.column_academy_id.Width = 125;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelAcademyName);
            this.flowLayoutPanel1.Controls.Add(this.checkActive);
            this.flowLayoutPanel1.Controls.Add(this.checkInactive);
            this.flowLayoutPanel1.Controls.Add(this.checkBoth);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(854, 44);
            this.flowLayoutPanel1.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelSearch);
            this.panel1.Controls.Add(this.searchBar);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1256, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 44);
            this.panel1.TabIndex = 28;
            // 
            // ClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1741, 835);
            this.Controls.Add(this.dataGridClasses);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClassList";
            this.Text = "ClassList";
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClasses)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox searchBar;
        public System.Windows.Forms.DataGridView dataGridClasses;
        private System.Windows.Forms.Label labelAcademyName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkActive;
        private System.Windows.Forms.CheckBox checkInactive;
        private System.Windows.Forms.CheckBox checkBoth;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_academy_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_academy;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_end_date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn column_finished;
        private System.Windows.Forms.DataGridViewImageColumn column_update;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}