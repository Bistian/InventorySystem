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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelTitles = new System.Windows.Forms.Panel();
            this.over30 = new System.Windows.Forms.Label();
            this.DueIn10 = new System.Windows.Forms.Label();
            this.dataGridViewDueIn10 = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewPast30 = new System.Windows.Forms.DataGridView();
            this.nums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.ButtonCurrentlyRented = new System.Windows.Forms.Button();
            this.splitContainerPantsJackets = new System.Windows.Forms.SplitContainer();
            this.ButtonCurrentlyRentedPants = new System.Windows.Forms.Button();
            this.ButtonCurrentlyRentedJackets = new System.Windows.Forms.Button();
            this.PanelTitles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDueIn10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPast30)).BeginInit();
            this.panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPantsJackets)).BeginInit();
            this.splitContainerPantsJackets.Panel1.SuspendLayout();
            this.splitContainerPantsJackets.Panel2.SuspendLayout();
            this.splitContainerPantsJackets.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitles
            // 
            this.PanelTitles.BackColor = System.Drawing.Color.Maroon;
            this.PanelTitles.Controls.Add(this.over30);
            this.PanelTitles.Controls.Add(this.DueIn10);
            this.PanelTitles.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitles.Location = new System.Drawing.Point(0, 0);
            this.PanelTitles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelTitles.Name = "PanelTitles";
            this.PanelTitles.Size = new System.Drawing.Size(1016, 25);
            this.PanelTitles.TabIndex = 2;
            // 
            // over30
            // 
            this.over30.AutoSize = true;
            this.over30.Dock = System.Windows.Forms.DockStyle.Right;
            this.over30.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.over30.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.over30.Location = new System.Drawing.Point(743, 0);
            this.over30.Margin = new System.Windows.Forms.Padding(500, 10, 0, 0);
            this.over30.Name = "over30";
            this.over30.Padding = new System.Windows.Forms.Padding(0, 0, 51, 0);
            this.over30.Size = new System.Drawing.Size(273, 29);
            this.over30.TabIndex = 2;
            this.over30.Text = "30 Days Over Due";
            // 
            // DueIn10
            // 
            this.DueIn10.AutoSize = true;
            this.DueIn10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DueIn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DueIn10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DueIn10.Location = new System.Drawing.Point(0, 0);
            this.DueIn10.Margin = new System.Windows.Forms.Padding(29, 10, 0, 0);
            this.DueIn10.Name = "DueIn10";
            this.DueIn10.Padding = new System.Windows.Forms.Padding(51, 0, 0, 0);
            this.DueIn10.Size = new System.Drawing.Size(303, 29);
            this.DueIn10.TabIndex = 1;
            this.DueIn10.Text = "Due Withinn 10 Days";
            // 
            // dataGridViewDueIn10
            // 
            this.dataGridViewDueIn10.AllowUserToAddRows = false;
            this.dataGridViewDueIn10.AllowUserToDeleteRows = false;
            this.dataGridViewDueIn10.AllowUserToResizeRows = false;
            this.dataGridViewDueIn10.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDueIn10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDueIn10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDueIn10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.Product,
            this.Rentee,
            this.Due});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDueIn10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDueIn10.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewDueIn10.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewDueIn10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDueIn10.Name = "dataGridViewDueIn10";
            this.dataGridViewDueIn10.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDueIn10.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDueIn10.RowHeadersVisible = false;
            this.dataGridViewDueIn10.RowHeadersWidth = 51;
            this.dataGridViewDueIn10.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewDueIn10.RowTemplate.Height = 24;
            this.dataGridViewDueIn10.Size = new System.Drawing.Size(301, 464);
            this.dataGridViewDueIn10.TabIndex = 9;
            this.dataGridViewDueIn10.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDueIn10_CellClick);
            // 
            // num
            // 
            this.num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.num.FillWeight = 30F;
            this.num.HeaderText = "#";
            this.num.MinimumWidth = 6;
            this.num.Name = "num";
            this.num.ReadOnly = true;
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
            // Due
            // 
            this.Due.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Due.HeaderText = "Due";
            this.Due.MinimumWidth = 6;
            this.Due.Name = "Due";
            this.Due.ReadOnly = true;
            // 
            // dataGridViewPast30
            // 
            this.dataGridViewPast30.AllowUserToAddRows = false;
            this.dataGridViewPast30.AllowUserToDeleteRows = false;
            this.dataGridViewPast30.AllowUserToResizeRows = false;
            this.dataGridViewPast30.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPast30.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewPast30.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPast30.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nums,
            this.Product2,
            this.Rentee2,
            this.DueDate2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPast30.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPast30.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewPast30.Location = new System.Drawing.Point(715, 25);
            this.dataGridViewPast30.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPast30.Name = "dataGridViewPast30";
            this.dataGridViewPast30.ReadOnly = true;
            this.dataGridViewPast30.RowHeadersVisible = false;
            this.dataGridViewPast30.RowHeadersWidth = 51;
            this.dataGridViewPast30.RowTemplate.Height = 24;
            this.dataGridViewPast30.Size = new System.Drawing.Size(301, 464);
            this.dataGridViewPast30.TabIndex = 10;
            this.dataGridViewPast30.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPast30_CellClick);
            // 
            // nums
            // 
            this.nums.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nums.FillWeight = 30F;
            this.nums.HeaderText = "#";
            this.nums.MinimumWidth = 6;
            this.nums.Name = "nums";
            this.nums.ReadOnly = true;
            // 
            // Product2
            // 
            this.Product2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product2.HeaderText = "Product";
            this.Product2.MinimumWidth = 6;
            this.Product2.Name = "Product2";
            this.Product2.ReadOnly = true;
            // 
            // Rentee2
            // 
            this.Rentee2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rentee2.HeaderText = "Rentee";
            this.Rentee2.MinimumWidth = 6;
            this.Rentee2.Name = "Rentee2";
            this.Rentee2.ReadOnly = true;
            // 
            // DueDate2
            // 
            this.DueDate2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DueDate2.HeaderText = "Due";
            this.DueDate2.MinimumWidth = 6;
            this.DueDate2.Name = "DueDate2";
            this.DueDate2.ReadOnly = true;
            // 
            // panelTotal
            // 
            this.panelTotal.Controls.Add(this.ButtonCurrentlyRented);
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTotal.Location = new System.Drawing.Point(301, 25);
            this.panelTotal.Margin = new System.Windows.Forms.Padding(20);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Padding = new System.Windows.Forms.Padding(13, 14, 13, 0);
            this.panelTotal.Size = new System.Drawing.Size(414, 150);
            this.panelTotal.TabIndex = 11;
            // 
            // ButtonCurrentlyRented
            // 
            this.ButtonCurrentlyRented.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonCurrentlyRented.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCurrentlyRented.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCurrentlyRented.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCurrentlyRented.Location = new System.Drawing.Point(13, 14);
            this.ButtonCurrentlyRented.Margin = new System.Windows.Forms.Padding(100, 50, 100, 0);
            this.ButtonCurrentlyRented.Name = "ButtonCurrentlyRented";
            this.ButtonCurrentlyRented.Size = new System.Drawing.Size(388, 136);
            this.ButtonCurrentlyRented.TabIndex = 2;
            this.ButtonCurrentlyRented.Text = "Currently Rented";
            this.ButtonCurrentlyRented.UseVisualStyleBackColor = false;
            this.ButtonCurrentlyRented.Click += new System.EventHandler(this.ButtonCurrentlyRented_Click_1);
            // 
            // splitContainerPantsJackets
            // 
            this.splitContainerPantsJackets.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerPantsJackets.Location = new System.Drawing.Point(301, 175);
            this.splitContainerPantsJackets.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.splitContainerPantsJackets.Name = "splitContainerPantsJackets";
            // 
            // splitContainerPantsJackets.Panel1
            // 
            this.splitContainerPantsJackets.Panel1.Controls.Add(this.ButtonCurrentlyRentedPants);
            // 
            // splitContainerPantsJackets.Panel2
            // 
            this.splitContainerPantsJackets.Panel2.Controls.Add(this.ButtonCurrentlyRentedJackets);
            this.splitContainerPantsJackets.Size = new System.Drawing.Size(414, 100);
            this.splitContainerPantsJackets.SplitterDistance = 205;
            this.splitContainerPantsJackets.TabIndex = 12;
            // 
            // ButtonCurrentlyRentedPants
            // 
            this.ButtonCurrentlyRentedPants.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonCurrentlyRentedPants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCurrentlyRentedPants.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCurrentlyRentedPants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCurrentlyRentedPants.Location = new System.Drawing.Point(0, 0);
            this.ButtonCurrentlyRentedPants.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.ButtonCurrentlyRentedPants.Name = "ButtonCurrentlyRentedPants";
            this.ButtonCurrentlyRentedPants.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.ButtonCurrentlyRentedPants.Size = new System.Drawing.Size(205, 100);
            this.ButtonCurrentlyRentedPants.TabIndex = 4;
            this.ButtonCurrentlyRentedPants.Text = "Pants";
            this.ButtonCurrentlyRentedPants.UseVisualStyleBackColor = false;
            this.ButtonCurrentlyRentedPants.Click += new System.EventHandler(this.ButtonCurrentlyRentedPants_Click);
            // 
            // ButtonCurrentlyRentedJackets
            // 
            this.ButtonCurrentlyRentedJackets.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonCurrentlyRentedJackets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCurrentlyRentedJackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCurrentlyRentedJackets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCurrentlyRentedJackets.Location = new System.Drawing.Point(0, 0);
            this.ButtonCurrentlyRentedJackets.Margin = new System.Windows.Forms.Padding(320, 0, 0, 0);
            this.ButtonCurrentlyRentedJackets.Name = "ButtonCurrentlyRentedJackets";
            this.ButtonCurrentlyRentedJackets.Size = new System.Drawing.Size(205, 100);
            this.ButtonCurrentlyRentedJackets.TabIndex = 1;
            this.ButtonCurrentlyRentedJackets.Text = "Coats";
            this.ButtonCurrentlyRentedJackets.UseVisualStyleBackColor = false;
            this.ButtonCurrentlyRentedJackets.Click += new System.EventHandler(this.ButtonCurrentlyRentedJackets_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 489);
            this.Controls.Add(this.splitContainerPantsJackets);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.dataGridViewPast30);
            this.Controls.Add(this.dataGridViewDueIn10);
            this.Controls.Add(this.PanelTitles);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.PanelTitles.ResumeLayout(false);
            this.PanelTitles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDueIn10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPast30)).EndInit();
            this.panelTotal.ResumeLayout(false);
            this.splitContainerPantsJackets.Panel1.ResumeLayout(false);
            this.splitContainerPantsJackets.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPantsJackets)).EndInit();
            this.splitContainerPantsJackets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelTitles;
        private System.Windows.Forms.Label over30;
        private System.Windows.Forms.Label DueIn10;
        private System.Windows.Forms.DataGridView dataGridViewDueIn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Due;
        private System.Windows.Forms.DataGridView dataGridViewPast30;
        private System.Windows.Forms.DataGridViewTextBoxColumn nums;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate2;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Button ButtonCurrentlyRented;
        private System.Windows.Forms.SplitContainer splitContainerPantsJackets;
        private System.Windows.Forms.Button ButtonCurrentlyRentedPants;
        private System.Windows.Forms.Button ButtonCurrentlyRentedJackets;
    }
}