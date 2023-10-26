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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExistingCustomerModuleForm));
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Academy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.column_update = new System.Windows.Forms.DataGridViewImageColumn();
            this.cbClientType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InventoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.BackColor = System.Drawing.Color.Maroon;
            this.InventoryPanel.Controls.Add(this.label2);
            this.InventoryPanel.Controls.Add(this.cbClientType);
            this.InventoryPanel.Controls.Add(this.label1);
            this.InventoryPanel.Controls.Add(this.searchBar);
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.InventoryPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(1000, 48);
            this.InventoryPanel.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "Search:";
            // 
            // searchBar
            // 
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(97, 5);
            this.searchBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(254, 45);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridUsers.ColumnHeadersHeight = 30;
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_name,
            this.Phone,
            this.Email,
            this.Academy,
            this.Address,
            this.column_id,
            this.Delete,
            this.column_update});
            this.dataGridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridUsers.EnableHeadersVisualStyles = false;
            this.dataGridUsers.Location = new System.Drawing.Point(0, 48);
            this.dataGridUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.RowHeadersVisible = false;
            this.dataGridUsers.RowHeadersWidth = 51;
            this.dataGridUsers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridUsers.RowTemplate.Height = 40;
            this.dataGridUsers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridUsers.Size = new System.Drawing.Size(1000, 608);
            this.dataGridUsers.TabIndex = 26;
            this.dataGridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUsers_CellClick);
            this.dataGridUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUsers_CellContentClick);
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
            // column_id
            // 
            this.column_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_id.HeaderText = "ID";
            this.column_id.MinimumWidth = 6;
            this.column_id.Name = "column_id";
            this.column_id.Visible = false;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Delete.FillWeight = 30F;
            this.Delete.HeaderText = "";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            // 
            // column_update
            // 
            this.column_update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_update.FillWeight = 30F;
            this.column_update.HeaderText = "";
            this.column_update.Image = ((System.Drawing.Image)(resources.GetObject("column_update.Image")));
            this.column_update.MinimumWidth = 6;
            this.column_update.Name = "column_update";
            // 
            // cbClientType
            // 
            this.cbClientType.AllowDrop = true;
            this.cbClientType.DisplayMember = "Individual";
            this.cbClientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClientType.FormattingEnabled = true;
            this.cbClientType.Items.AddRange(new object[] {
            "Individuals",
            "Departments",
            "Academies"});
            this.cbClientType.Location = new System.Drawing.Point(427, 4);
            this.cbClientType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbClientType.Name = "cbClientType";
            this.cbClientType.Size = new System.Drawing.Size(121, 26);
            this.cbClientType.TabIndex = 27;
            this.cbClientType.Visible = false;
            this.cbClientType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(317, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Client Type:";
            this.label2.Visible = false;
            // 
            // ExistingCustomerModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1000, 656);
            this.Controls.Add(this.dataGridUsers);
            this.Controls.Add(this.InventoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Academy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_id;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewImageColumn column_update;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClientType;
    }
}