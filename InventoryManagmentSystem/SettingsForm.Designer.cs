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
            this.btnAcademies = new System.Windows.Forms.Button();
            this.btnHistories = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.tbUuid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDatabase
            // 
            this.btnDatabase.Location = new System.Drawing.Point(13, 42);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(75, 23);
            this.btnDatabase.TabIndex = 1;
            this.btnDatabase.Text = "Database";
            this.btnDatabase.UseVisualStyleBackColor = true;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(121, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 426);
            this.panel1.TabIndex = 2;
            // 
            // btnBrands
            // 
            this.btnBrands.Location = new System.Drawing.Point(13, 72);
            this.btnBrands.Name = "btnBrands";
            this.btnBrands.Size = new System.Drawing.Size(75, 23);
            this.btnBrands.TabIndex = 3;
            this.btnBrands.Text = "Brands";
            this.btnBrands.UseVisualStyleBackColor = true;
            this.btnBrands.Click += new System.EventHandler(this.btnBrands_Click);
            // 
            // btnPrices
            // 
            this.btnPrices.Location = new System.Drawing.Point(12, 101);
            this.btnPrices.Name = "btnPrices";
            this.btnPrices.Size = new System.Drawing.Size(75, 23);
            this.btnPrices.TabIndex = 4;
            this.btnPrices.Text = "Prices";
            this.btnPrices.UseVisualStyleBackColor = true;
            this.btnPrices.Click += new System.EventHandler(this.btnPrices_Click);
            // 
            // btnAcademies
            // 
            this.btnAcademies.Location = new System.Drawing.Point(12, 130);
            this.btnAcademies.Name = "btnAcademies";
            this.btnAcademies.Size = new System.Drawing.Size(75, 23);
            this.btnAcademies.TabIndex = 5;
            this.btnAcademies.Text = "Academies";
            this.btnAcademies.UseVisualStyleBackColor = true;
            this.btnAcademies.Click += new System.EventHandler(this.btnAcademies_Click);
            // 
            // btnHistories
            // 
            this.btnHistories.Location = new System.Drawing.Point(13, 159);
            this.btnHistories.Name = "btnHistories";
            this.btnHistories.Size = new System.Drawing.Size(75, 23);
            this.btnHistories.TabIndex = 6;
            this.btnHistories.Text = "Histories";
            this.btnHistories.UseVisualStyleBackColor = true;
            this.btnHistories.Click += new System.EventHandler(this.btnHistories_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Enabled = false;
            this.btnAddItem.Location = new System.Drawing.Point(12, 341);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 7;
            this.btnAddItem.Text = "Add Item";
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
            this.cbItemType.Location = new System.Drawing.Point(12, 314);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(76, 21);
            this.cbItemType.TabIndex = 8;
            this.cbItemType.Visible = false;
            // 
            // tbUuid
            // 
            this.tbUuid.Enabled = false;
            this.tbUuid.Location = new System.Drawing.Point(13, 288);
            this.tbUuid.Name = "tbUuid";
            this.tbUuid.Size = new System.Drawing.Size(75, 20);
            this.tbUuid.TabIndex = 9;
            this.tbUuid.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbUuid);
            this.Controls.Add(this.cbItemType);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnHistories);
            this.Controls.Add(this.btnAcademies);
            this.Controls.Add(this.btnPrices);
            this.Controls.Add(this.btnBrands);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDatabase);
            this.Controls.Add(this.btnImport);
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
        private System.Windows.Forms.Button btnAcademies;
        private System.Windows.Forms.Button btnHistories;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.TextBox tbUuid;
    }
}