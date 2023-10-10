namespace InventoryManagmentSystem
{
    partial class SettingsForm
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
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBrands = new System.Windows.Forms.Button();
            this.btnPrices = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.tbUuid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(16, 15);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 28);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDatabase
            // 
            this.btnDatabase.Location = new System.Drawing.Point(17, 52);
            this.btnDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(100, 28);
            this.btnDatabase.TabIndex = 1;
            this.btnDatabase.Text = "Database";
            this.btnDatabase.UseVisualStyleBackColor = true;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(161, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 524);
            this.panel1.TabIndex = 2;
            // 
            // btnBrands
            // 
            this.btnBrands.Location = new System.Drawing.Point(17, 89);
            this.btnBrands.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrands.Name = "btnBrands";
            this.btnBrands.Size = new System.Drawing.Size(100, 28);
            this.btnBrands.TabIndex = 3;
            this.btnBrands.Text = "Brands";
            this.btnBrands.UseVisualStyleBackColor = true;
            this.btnBrands.Click += new System.EventHandler(this.btnBrands_Click);
            // 
            // btnPrices
            // 
            this.btnPrices.Location = new System.Drawing.Point(16, 124);
            this.btnPrices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrices.Name = "btnPrices";
            this.btnPrices.Size = new System.Drawing.Size(100, 28);
            this.btnPrices.TabIndex = 4;
            this.btnPrices.Text = "Prices";
            this.btnPrices.UseVisualStyleBackColor = true;
            this.btnPrices.Click += new System.EventHandler(this.btnPrices_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Enabled = false;
            this.btnAddItem.Location = new System.Drawing.Point(16, 420);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 28);
            this.btnAddItem.TabIndex = 7;
            this.btnAddItem.Text = "Add IDs";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Visible = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // cbItemType
            // 
            this.cbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemType.Enabled = false;
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Items.AddRange(new object[] {
            "Detached UUID"});
            this.cbItemType.Location = new System.Drawing.Point(16, 386);
            this.cbItemType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(100, 24);
            this.cbItemType.TabIndex = 8;
            this.cbItemType.Visible = false;
            // 
            // tbUuid
            // 
            this.tbUuid.Enabled = false;
            this.tbUuid.Location = new System.Drawing.Point(17, 354);
            this.tbUuid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbUuid.Name = "tbUuid";
            this.tbUuid.Size = new System.Drawing.Size(99, 22);
            this.tbUuid.TabIndex = 9;
            this.tbUuid.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tbUuid);
            this.Controls.Add(this.cbItemType);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnPrices);
            this.Controls.Add(this.btnBrands);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDatabase);
            this.Controls.Add(this.btnImport);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDatabase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBrands;
        private System.Windows.Forms.Button btnPrices;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.TextBox tbUuid;
    }
}