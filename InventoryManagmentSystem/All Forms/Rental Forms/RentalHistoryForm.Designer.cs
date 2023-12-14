namespace InventoryManagmentSystem
{
    partial class RentalHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RentalHistoryForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridHistory = new System.Windows.Forms.DataGridView();
            this.column_history_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_client_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_client_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_item_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_serial_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_rented = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Controls.Add(this.CloseButton);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1241, 30);
            this.panelTop.TabIndex = 6;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTitle.Location = new System.Drawing.Point(-5, 3);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(147, 25);
            this.labelTitle.TabIndex = 70;
            this.labelTitle.Text = "Rental History";
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(164, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(39, 45);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 69;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panelTop);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridHistory);
            this.splitContainer2.Size = new System.Drawing.Size(1241, 519);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.TabIndex = 7;
            // 
            // dataGridHistory
            // 
            this.dataGridHistory.AllowUserToAddRows = false;
            this.dataGridHistory.AllowUserToDeleteRows = false;
            this.dataGridHistory.AllowUserToResizeRows = false;
            this.dataGridHistory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHistory.ColumnHeadersHeight = 30;
            this.dataGridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_history_id,
            this.column_client_id,
            this.column_item_id,
            this.column_client_name,
            this.column_item_type,
            this.column_serial_number,
            this.column_rented,
            this.column_returned});
            this.dataGridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridHistory.EnableHeadersVisualStyles = false;
            this.dataGridHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridHistory.Name = "dataGridHistory";
            this.dataGridHistory.RowHeadersVisible = false;
            this.dataGridHistory.RowHeadersWidth = 62;
            this.dataGridHistory.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridHistory.RowTemplate.Height = 40;
            this.dataGridHistory.Size = new System.Drawing.Size(1241, 485);
            this.dataGridHistory.TabIndex = 3;
            this.dataGridHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHistory_CellClick);
            // 
            // column_history_id
            // 
            this.column_history_id.HeaderText = "History ID";
            this.column_history_id.Name = "column_history_id";
            this.column_history_id.Visible = false;
            // 
            // column_client_id
            // 
            this.column_client_id.HeaderText = "Client ID";
            this.column_client_id.MinimumWidth = 8;
            this.column_client_id.Name = "column_client_id";
            this.column_client_id.Visible = false;
            this.column_client_id.Width = 150;
            // 
            // column_item_id
            // 
            this.column_item_id.HeaderText = "Item ID";
            this.column_item_id.Name = "column_item_id";
            this.column_item_id.Visible = false;
            // 
            // column_client_name
            // 
            this.column_client_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_client_name.HeaderText = "Client Name";
            this.column_client_name.Name = "column_client_name";
            // 
            // column_item_type
            // 
            this.column_item_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_item_type.HeaderText = "Item Type";
            this.column_item_type.Name = "column_item_type";
            // 
            // column_serial_number
            // 
            this.column_serial_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_serial_number.HeaderText = "Serial Number";
            this.column_serial_number.Name = "column_serial_number";
            // 
            // column_rented
            // 
            this.column_rented.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_rented.HeaderText = "Rented";
            this.column_rented.MinimumWidth = 8;
            this.column_rented.Name = "column_rented";
            // 
            // column_returned
            // 
            this.column_returned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_returned.HeaderText = "Returned";
            this.column_returned.MinimumWidth = 8;
            this.column_returned.Name = "column_returned";
            // 
            // RentalHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1241, 519);
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RentalHistoryForm";
            this.Text = "RentalHistoryForm";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomButton CloseButton;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_history_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_client_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_client_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_item_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_serial_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_rented;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_returned;
    }
}