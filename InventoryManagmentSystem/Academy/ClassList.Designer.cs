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
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.dataGridClasses = new System.Windows.Forms.DataGridView();
            this.column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_finished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.column_delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelSearch);
            this.panelTop.Controls.Add(this.searchBar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(888, 33);
            this.panelTop.TabIndex = 26;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSearch.Location = new System.Drawing.Point(5, 8);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(88, 25);
            this.labelSearch.TabIndex = 21;
            this.labelSearch.Text = "Search:";
            // 
            // searchBar
            // 
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(81, 8);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(208, 24);
            this.searchBar.TabIndex = 20;
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
            this.column_name,
            this.column_start_date,
            this.column_end_date,
            this.column_finished,
            this.column_delete});
            this.dataGridClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridClasses.EnableHeadersVisualStyles = false;
            this.dataGridClasses.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridClasses.Location = new System.Drawing.Point(0, 33);
            this.dataGridClasses.Name = "dataGridClasses";
            this.dataGridClasses.ReadOnly = true;
            this.dataGridClasses.RowHeadersVisible = false;
            this.dataGridClasses.RowHeadersWidth = 51;
            this.dataGridClasses.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridClasses.RowTemplate.Height = 40;
            this.dataGridClasses.Size = new System.Drawing.Size(888, 545);
            this.dataGridClasses.TabIndex = 27;
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
            // column_delete
            // 
            this.column_delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_delete.FillWeight = 19.542F;
            this.column_delete.HeaderText = "";
            this.column_delete.MinimumWidth = 6;
            this.column_delete.Name = "column_delete";
            this.column_delete.ReadOnly = true;
            // 
            // ClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(888, 578);
            this.Controls.Add(this.dataGridClasses);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_end_date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn column_finished;
        private System.Windows.Forms.DataGridViewImageColumn column_delete;
    }
}