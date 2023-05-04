namespace InventoryManagmentSystem
{
    partial class RentalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RentalForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonNewRental = new InventoryManagmentSystem.CustomButton();
            this.labelRentals = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridRented = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridPastDue = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rented = new System.Windows.Forms.Label();
            this.PastDue = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonNewRental)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRented)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPastDue)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelBottom.Controls.Add(this.button1);
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Controls.Add(this.ButtonNewRental);
            this.panelBottom.Controls.Add(this.labelRentals);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 499);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1034, 43);
            this.panelBottom.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(806, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 27);
            this.button1.TabIndex = 19;
            this.button1.Text = "Return";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(890, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 12, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "New Rental";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButtonNewRental
            // 
            this.ButtonNewRental.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNewRental.Image = ((System.Drawing.Image)(resources.GetObject("ButtonNewRental.Image")));
            this.ButtonNewRental.ImageHover = ((System.Drawing.Image)(resources.GetObject("ButtonNewRental.ImageHover")));
            this.ButtonNewRental.ImageNormal = ((System.Drawing.Image)(resources.GetObject("ButtonNewRental.ImageNormal")));
            this.ButtonNewRental.Location = new System.Drawing.Point(974, 15);
            this.ButtonNewRental.Margin = new System.Windows.Forms.Padding(562, 12, 2, 2);
            this.ButtonNewRental.Name = "ButtonNewRental";
            this.ButtonNewRental.Size = new System.Drawing.Size(35, 19);
            this.ButtonNewRental.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButtonNewRental.TabIndex = 17;
            this.ButtonNewRental.TabStop = false;
            this.ButtonNewRental.Click += new System.EventHandler(this.ButtonNewRental_Click);
            // 
            // labelRentals
            // 
            this.labelRentals.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelRentals.AutoSize = true;
            this.labelRentals.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRentals.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelRentals.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelRentals.Location = new System.Drawing.Point(9, 12);
            this.labelRentals.Margin = new System.Windows.Forms.Padding(2, 12, 2, 0);
            this.labelRentals.Name = "labelRentals";
            this.labelRentals.Size = new System.Drawing.Size(76, 24);
            this.labelRentals.TabIndex = 15;
            this.labelRentals.Text = "Rentals";
            this.labelRentals.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridRented, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridPastDue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Rented, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PastDue, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.350554F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.64944F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1034, 499);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // dataGridRented
            // 
            this.dataGridRented.AllowUserToAddRows = false;
            this.dataGridRented.AllowUserToDeleteRows = false;
            this.dataGridRented.AllowUserToResizeRows = false;
            this.dataGridRented.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridRented.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridRented.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridRented.ColumnHeadersHeight = 30;
            this.dataGridRented.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridRented.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Product,
            this.Rentee,
            this.DueDate,
            this.Serial});
            this.dataGridRented.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridRented.EnableHeadersVisualStyles = false;
            this.dataGridRented.Location = new System.Drawing.Point(3, 29);
            this.dataGridRented.Name = "dataGridRented";
            this.dataGridRented.ReadOnly = true;
            this.dataGridRented.RowHeadersVisible = false;
            this.dataGridRented.RowHeadersWidth = 51;
            this.dataGridRented.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridRented.Size = new System.Drawing.Size(511, 460);
            this.dataGridRented.TabIndex = 2;
            this.dataGridRented.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRented_CellClick);
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Num.FillWeight = 30F;
            this.Num.HeaderText = "#";
            this.Num.MinimumWidth = 6;
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product.HeaderText = "Product";
            this.Product.MinimumWidth = 6;
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // Rentee
            // 
            this.Rentee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rentee.HeaderText = "Rentee";
            this.Rentee.MinimumWidth = 6;
            this.Rentee.Name = "Rentee";
            this.Rentee.ReadOnly = true;
            // 
            // DueDate
            // 
            this.DueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.MinimumWidth = 6;
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            // 
            // Serial
            // 
            this.Serial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Serial.HeaderText = "Serial #";
            this.Serial.MinimumWidth = 6;
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            // 
            // dataGridPastDue
            // 
            this.dataGridPastDue.AllowUserToAddRows = false;
            this.dataGridPastDue.AllowUserToDeleteRows = false;
            this.dataGridPastDue.AllowUserToResizeRows = false;
            this.dataGridPastDue.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridPastDue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPastDue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridPastDue.ColumnHeadersHeight = 30;
            this.dataGridPastDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridPastDue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.DDate,
            this.dataGridViewTextBoxColumn4});
            this.dataGridPastDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPastDue.EnableHeadersVisualStyles = false;
            this.dataGridPastDue.Location = new System.Drawing.Point(520, 29);
            this.dataGridPastDue.Name = "dataGridPastDue";
            this.dataGridPastDue.ReadOnly = true;
            this.dataGridPastDue.RowHeadersVisible = false;
            this.dataGridPastDue.RowHeadersWidth = 51;
            this.dataGridPastDue.Size = new System.Drawing.Size(511, 460);
            this.dataGridPastDue.TabIndex = 3;
            this.dataGridPastDue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPastDue_CellClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.FillWeight = 30F;
            this.Id.HeaderText = "#";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Rentee";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DDate
            // 
            this.DDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DDate.HeaderText = "Due Date";
            this.DDate.MinimumWidth = 6;
            this.DDate.Name = "DDate";
            this.DDate.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Serial #";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Rented
            // 
            this.Rented.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rented.AutoSize = true;
            this.Rented.BackColor = System.Drawing.Color.Maroon;
            this.Rented.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rented.ForeColor = System.Drawing.SystemColors.Window;
            this.Rented.Location = new System.Drawing.Point(3, 6);
            this.Rented.Name = "Rented";
            this.Rented.Size = new System.Drawing.Size(68, 20);
            this.Rented.TabIndex = 4;
            this.Rented.Text = "Rented";
            // 
            // PastDue
            // 
            this.PastDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PastDue.AutoSize = true;
            this.PastDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PastDue.ForeColor = System.Drawing.SystemColors.Window;
            this.PastDue.Location = new System.Drawing.Point(520, 6);
            this.PastDue.Name = "PastDue";
            this.PastDue.Size = new System.Drawing.Size(83, 20);
            this.PastDue.TabIndex = 5;
            this.PastDue.Text = "Past Due";
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 542);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RentalForm";
            this.Text = "HomeForm";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonNewRental)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRented)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPastDue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private CustomButton ButtonNewRental;
        private System.Windows.Forms.Label labelRentals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridRented;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridView dataGridPastDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label Rented;
        private System.Windows.Forms.Label PastDue;
        private System.Windows.Forms.Button button1;
    }
}
