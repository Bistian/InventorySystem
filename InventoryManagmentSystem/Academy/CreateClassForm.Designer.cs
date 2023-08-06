namespace InventoryManagmentSystem
{
    partial class ClassForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelClassName = new System.Windows.Forms.Label();
            this.tbClassName = new System.Windows.Forms.TextBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dpStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridClasses = new System.Windows.Forms.DataGridView();
            this.column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_finished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.column_delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbAcademy = new System.Windows.Forms.ComboBox();
            this.labelAcademy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitle.Location = new System.Drawing.Point(11, 16);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(147, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Create Classes";
            // 
            // labelClassName
            // 
            this.labelClassName.AutoSize = true;
            this.labelClassName.Location = new System.Drawing.Point(13, 91);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(90, 18);
            this.labelClassName.TabIndex = 1;
            this.labelClassName.Text = "Class Name";
            // 
            // tbClassName
            // 
            this.tbClassName.Location = new System.Drawing.Point(16, 112);
            this.tbClassName.Name = "tbClassName";
            this.tbClassName.Size = new System.Drawing.Size(233, 24);
            this.tbClassName.TabIndex = 2;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(13, 139);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(74, 18);
            this.labelStartDate.TabIndex = 3;
            this.labelStartDate.Text = "Start Date";
            // 
            // dpStartDate
            // 
            this.dpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dpStartDate.Location = new System.Drawing.Point(16, 160);
            this.dpStartDate.Name = "dpStartDate";
            this.dpStartDate.Size = new System.Drawing.Size(233, 23);
            this.dpStartDate.TabIndex = 4;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(13, 186);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(69, 18);
            this.labelEndDate.TabIndex = 5;
            this.labelEndDate.Text = "End Date";
            // 
            // dpEndDate
            // 
            this.dpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dpEndDate.Location = new System.Drawing.Point(16, 207);
            this.dpEndDate.Name = "dpEndDate";
            this.dpEndDate.Size = new System.Drawing.Size(233, 23);
            this.dpEndDate.TabIndex = 6;
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
            this.dataGridClasses.EnableHeadersVisualStyles = false;
            this.dataGridClasses.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridClasses.Location = new System.Drawing.Point(255, 16);
            this.dataGridClasses.Name = "dataGridClasses";
            this.dataGridClasses.ReadOnly = true;
            this.dataGridClasses.RowHeadersVisible = false;
            this.dataGridClasses.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridClasses.RowTemplate.Height = 40;
            this.dataGridClasses.Size = new System.Drawing.Size(468, 243);
            this.dataGridClasses.TabIndex = 7;
            this.dataGridClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridClasses_CellClick);
            // 
            // column_number
            // 
            this.column_number.FillWeight = 25F;
            this.column_number.HeaderText = "#";
            this.column_number.Name = "column_number";
            this.column_number.ReadOnly = true;
            this.column_number.Width = 25;
            // 
            // column_id
            // 
            this.column_id.FillWeight = 1F;
            this.column_id.HeaderText = "Id";
            this.column_id.Name = "column_id";
            this.column_id.ReadOnly = true;
            this.column_id.Visible = false;
            // 
            // column_name
            // 
            this.column_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_name.FillWeight = 78.16801F;
            this.column_name.HeaderText = "Name";
            this.column_name.Name = "column_name";
            this.column_name.ReadOnly = true;
            // 
            // column_start_date
            // 
            this.column_start_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_start_date.FillWeight = 46.90081F;
            this.column_start_date.HeaderText = "Start";
            this.column_start_date.Name = "column_start_date";
            this.column_start_date.ReadOnly = true;
            // 
            // column_end_date
            // 
            this.column_end_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_end_date.FillWeight = 46.90081F;
            this.column_end_date.HeaderText = "End";
            this.column_end_date.Name = "column_end_date";
            this.column_end_date.ReadOnly = true;
            // 
            // column_finished
            // 
            this.column_finished.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_finished.FillWeight = 35F;
            this.column_finished.HeaderText = "Finished";
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
            this.column_delete.Name = "column_delete";
            this.column_delete.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAdd.Location = new System.Drawing.Point(16, 236);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(233, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbAcademy
            // 
            this.cbAcademy.FormattingEnabled = true;
            this.cbAcademy.Location = new System.Drawing.Point(16, 62);
            this.cbAcademy.Name = "cbAcademy";
            this.cbAcademy.Size = new System.Drawing.Size(233, 26);
            this.cbAcademy.TabIndex = 9;
            // 
            // labelAcademy
            // 
            this.labelAcademy.AutoSize = true;
            this.labelAcademy.Location = new System.Drawing.Point(13, 41);
            this.labelAcademy.Name = "labelAcademy";
            this.labelAcademy.Size = new System.Drawing.Size(69, 18);
            this.labelAcademy.TabIndex = 10;
            this.labelAcademy.Text = "Academy";
            // 
            // ClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(735, 273);
            this.Controls.Add(this.labelAcademy);
            this.Controls.Add(this.cbAcademy);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridClasses);
            this.Controls.Add(this.dpEndDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.dpStartDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.tbClassName);
            this.Controls.Add(this.labelClassName);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClasses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelClassName;
        private System.Windows.Forms.TextBox tbClassName;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dpStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dpEndDate;
        public System.Windows.Forms.DataGridView dataGridClasses;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_end_date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn column_finished;
        private System.Windows.Forms.DataGridViewImageColumn column_delete;
        private System.Windows.Forms.ComboBox cbAcademy;
        private System.Windows.Forms.Label labelAcademy;
    }
}