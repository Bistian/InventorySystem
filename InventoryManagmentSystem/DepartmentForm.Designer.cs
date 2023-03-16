namespace InventoryManagmentSystem
{
    partial class DepartmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.UsersButton = new InventoryManagmentSystem.CustomButton();
            this.DepartmentsTxt = new System.Windows.Forms.Label();
            this.dataGridDept = new System.Windows.Forms.DataGridView();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UsersButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDept)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsersButton
            // 
            this.UsersButton.Image = ((System.Drawing.Image)(resources.GetObject("UsersButton.Image")));
            this.UsersButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("UsersButton.ImageHover")));
            this.UsersButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("UsersButton.ImageNormal")));
            this.UsersButton.Location = new System.Drawing.Point(991, 14);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(31, 32);
            this.UsersButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UsersButton.TabIndex = 15;
            this.UsersButton.TabStop = false;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // DepartmentsTxt
            // 
            this.DepartmentsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DepartmentsTxt.AutoSize = true;
            this.DepartmentsTxt.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentsTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepartmentsTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DepartmentsTxt.Location = new System.Drawing.Point(12, 14);
            this.DepartmentsTxt.Name = "DepartmentsTxt";
            this.DepartmentsTxt.Size = new System.Drawing.Size(196, 24);
            this.DepartmentsTxt.TabIndex = 14;
            this.DepartmentsTxt.Text = "Manage Departments";
            this.DepartmentsTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridDept
            // 
            this.dataGridDept.AllowUserToAddRows = false;
            this.dataGridDept.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridDept.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDept.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDept.ColumnHeadersHeight = 30;
            this.dataGridDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridDept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Edit,
            this.Delete});
            this.dataGridDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDept.EnableHeadersVisualStyles = false;
            this.dataGridDept.Location = new System.Drawing.Point(0, 0);
            this.dataGridDept.Name = "dataGridDept";
            this.dataGridDept.Size = new System.Drawing.Size(1034, 489);
            this.dataGridDept.TabIndex = 3;
            this.dataGridDept.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDept_CellContentClick);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.BottomPanel.Controls.Add(this.UsersButton);
            this.BottomPanel.Controls.Add(this.DepartmentsTxt);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 489);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1034, 53);
            this.BottomPanel.TabIndex = 2;
            // 
            // Column0
            // 
            this.Column0.HeaderText = "#";
            this.Column0.Name = "Column0";
            this.Column0.Width = 25;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Customer ID";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = 105;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Department Name";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 141;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Contact Name";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 116;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Phone";
            this.Column4.Name = "Column4";
            this.Column4.Width = 69;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Email";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Address";
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "City";
            this.Column7.Name = "Column7";
            this.Column7.Width = 55;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "State";
            this.Column8.Name = "Column8";
            this.Column8.Width = 62;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.HeaderText = "Zip";
            this.Column9.Name = "Column9";
            this.Column9.Width = 50;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit.HeaderText = "";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.Width = 5;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Width = 5;
            // 
            // DepartmentForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1034, 542);
            this.Controls.Add(this.dataGridDept);
            this.Controls.Add(this.BottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DepartmentForm";
            this.Text = "DepartmentForm";
            ((System.ComponentModel.ISupportInitialize)(this.UsersButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDept)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton UsersButton;
        private System.Windows.Forms.Label DepartmentsTxt;
        private System.Windows.Forms.DataGridView dataGridDept;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}