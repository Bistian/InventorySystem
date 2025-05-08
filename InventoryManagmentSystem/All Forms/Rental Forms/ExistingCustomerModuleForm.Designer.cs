using static System.Windows.Forms.AxHost;

namespace InventoryManagmentSystem
{
    partial class ExistingCustomerModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExistingCustomerModuleForm));
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.check_box_inactive = new System.Windows.Forms.CheckBox();
            this.check_box_active = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.column_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Academy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_drivers_license = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_update = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.InventoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.BackColor = System.Drawing.Color.Maroon;
            this.InventoryPanel.Controls.Add(this.check_box_inactive);
            this.InventoryPanel.Controls.Add(this.check_box_active);
            this.InventoryPanel.Controls.Add(this.label1);
            this.InventoryPanel.Controls.Add(this.searchBar);
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.InventoryPanel.Margin = new System.Windows.Forms.Padding(4);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(1500, 75);
            this.InventoryPanel.TabIndex = 24;
            // 
            // check_box_inactive
            // 
            this.check_box_inactive.AutoSize = true;
            this.check_box_inactive.ForeColor = System.Drawing.SystemColors.Window;
            this.check_box_inactive.Location = new System.Drawing.Point(540, 38);
            this.check_box_inactive.Margin = new System.Windows.Forms.Padding(6);
            this.check_box_inactive.Name = "cbInactive";
            this.check_box_inactive.Size = new System.Drawing.Size(118, 29);
            this.check_box_inactive.TabIndex = 21;
            this.check_box_inactive.Text = "Inactive";
            this.check_box_inactive.UseVisualStyleBackColor = true;
            this.check_box_inactive.CheckedChanged += new System.EventHandler(this.cbInactive_CheckedChanged);
            // 
            // check_box_active
            // 
            this.check_box_active.AutoSize = true;
            this.check_box_active.ForeColor = System.Drawing.SystemColors.Window;
            this.check_box_active.Location = new System.Drawing.Point(540, 6);
            this.check_box_active.Margin = new System.Windows.Forms.Padding(6);
            this.check_box_active.Name = "cbActive";
            this.check_box_active.Size = new System.Drawing.Size(103, 29);
            this.check_box_active.TabIndex = 20;
            this.check_box_active.Text = "Active";
            this.check_box_active.UseVisualStyleBackColor = true;
            this.check_box_active.CheckedChanged += new System.EventHandler(this.cbActive_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 52);
            this.label1.TabIndex = 19;
            this.label1.Text = "Search:";
            // 
            // searchBar
            // 
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(146, 8);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(380, 67);
            this.searchBar.TabIndex = 18;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.AllowUserToAddRows = false;
            this.dataGridUsers.AllowUserToDeleteRows = false;
            this.dataGridUsers.AllowUserToResizeRows = false;
            this.dataGridUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridUsers.ColumnHeadersHeight = 30;
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_count,
            this.column_id,
            this.column_name,
            this.Phone,
            this.Email,
            this.Academy,
            this.Address,
            this.column_drivers_license,
            this.column_update,
            this.Delete});
            this.dataGridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridUsers.EnableHeadersVisualStyles = false;
            this.dataGridUsers.Location = new System.Drawing.Point(0, 75);
            this.dataGridUsers.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.RowHeadersVisible = false;
            this.dataGridUsers.RowHeadersWidth = 51;
            this.dataGridUsers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridUsers.RowTemplate.Height = 40;
            this.dataGridUsers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridUsers.Size = new System.Drawing.Size(1500, 950);
            this.dataGridUsers.TabIndex = 26;
            this.dataGridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUsers_CellClick);
            // 
            // column_count
            // 
            this.column_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_count.FillWeight = 30F;
            this.column_count.HeaderText = "#";
            this.column_count.MinimumWidth = 10;
            this.column_count.Name = "column_count";
            // 
            // column_id
            // 
            this.column_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_id.HeaderText = "Id";
            this.column_id.MinimumWidth = 6;
            this.column_id.Name = "column_id";
            this.column_id.Visible = false;
            // 
            // column_name
            // 
            this.column_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_name.HeaderText = "Name";
            this.column_name.MinimumWidth = 6;
            this.column_name.Name = "column_name";
            // 
            // Phone
            // 
            this.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            // 
            // Academy
            // 
            this.Academy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Academy.FillWeight = 150F;
            this.Academy.HeaderText = "Academy / Department";
            this.Academy.MinimumWidth = 6;
            this.Academy.Name = "Academy";
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address.FillWeight = 150F;
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            // 
            // column_drivers_license
            // 
            this.column_drivers_license.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_drivers_license.HeaderText = "Driver License";
            this.column_drivers_license.MinimumWidth = 10;
            this.column_drivers_license.Name = "column_drivers_license";
            this.column_drivers_license.Visible = false;
            // 
            // column_update
            // 
            this.column_update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_update.FillWeight = 30F;
            this.column_update.HeaderText = "";
            this.column_update.Image = ((System.Drawing.Image)(resources.GetObject("column_update.Image")));
            this.column_update.MinimumWidth = 6;
            this.column_update.Name = "column_update";
            this.column_update.Visible = false;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Delete.FillWeight = 30F;
            this.Delete.HeaderText = "";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.Visible = false;
            // 
            // ExistingCustomerModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1500, 1025);
            this.Controls.Add(this.dataGridUsers);
            this.Controls.Add(this.InventoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExistingCustomerModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExistingCustomerModuleForm";
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.DataGridView dataGridUsers;
        private System.Windows.Forms.CheckBox check_box_inactive;
        private System.Windows.Forms.CheckBox check_box_active;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Academy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_drivers_license;
        private System.Windows.Forms.DataGridViewImageColumn column_update;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}