namespace InventoryManagmentSystem
{
    partial class HomeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PastDue = new System.Windows.Forms.Label();
            this.Rented = new System.Windows.Forms.Label();
            this.dataGridPastDue = new System.Windows.Forms.DataGridView();
            this.dataGridRented = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPastDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRented)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PastDue
            // 
            this.PastDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PastDue.AutoSize = true;
            this.PastDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PastDue.ForeColor = System.Drawing.SystemColors.Window;
            this.PastDue.Location = new System.Drawing.Point(520, 9);
            this.PastDue.Name = "PastDue";
            this.PastDue.Size = new System.Drawing.Size(83, 20);
            this.PastDue.TabIndex = 5;
            this.PastDue.Text = "Past Due";
            // 
            // Rented
            // 
            this.Rented.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rented.AutoSize = true;
            this.Rented.BackColor = System.Drawing.Color.Maroon;
            this.Rented.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rented.ForeColor = System.Drawing.SystemColors.Window;
            this.Rented.Location = new System.Drawing.Point(3, 9);
            this.Rented.Name = "Rented";
            this.Rented.Size = new System.Drawing.Size(68, 20);
            this.Rented.TabIndex = 4;
            this.Rented.Text = "Rented";
            // 
            // dataGridPastDue
            // 
            this.dataGridPastDue.AllowUserToAddRows = false;
            this.dataGridPastDue.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridPastDue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPastDue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dataGridPastDue.Location = new System.Drawing.Point(520, 32);
            this.dataGridPastDue.Name = "dataGridPastDue";
            this.dataGridPastDue.RowHeadersVisible = false;
            this.dataGridPastDue.Size = new System.Drawing.Size(511, 507);
            this.dataGridPastDue.TabIndex = 3;
            this.dataGridPastDue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPastDue_CellClick);
            // 
            // dataGridRented
            // 
            this.dataGridRented.AllowUserToAddRows = false;
            this.dataGridRented.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridRented.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridRented.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.dataGridRented.Location = new System.Drawing.Point(3, 32);
            this.dataGridRented.Name = "dataGridRented";
            this.dataGridRented.RowHeadersVisible = false;
            this.dataGridRented.Size = new System.Drawing.Size(511, 507);
            this.dataGridRented.TabIndex = 2;
            this.dataGridRented.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRented_CellClick);
            this.dataGridRented.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridRented_CellFormatting);
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Num.FillWeight = 30F;
            this.Num.HeaderText = "#";
            this.Num.Name = "Num";
            // 
            // Product
            // 
            this.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            // 
            // Rentee
            // 
            this.Rentee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rentee.HeaderText = "Rentee";
            this.Rentee.Name = "Rentee";
            // 
            // DueDate
            // 
            this.DueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            // 
            // Serial
            // 
            this.Serial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Serial.HeaderText = "Serial #";
            this.Serial.Name = "Serial";
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
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.350554F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.64944F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1034, 542);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.FillWeight = 30F;
            this.Id.HeaderText = "#";
            this.Id.Name = "Id";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Rentee";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // DDate
            // 
            this.DDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DDate.HeaderText = "Due Date";
            this.DDate.Name = "DDate";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Serial #";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 542);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPastDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRented)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PastDue;
        private System.Windows.Forms.Label Rented;
        private System.Windows.Forms.DataGridView dataGridPastDue;
        private System.Windows.Forms.DataGridView dataGridRented;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}