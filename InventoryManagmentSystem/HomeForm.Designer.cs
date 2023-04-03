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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ButtonCurrentlyRented = new System.Windows.Forms.Button();
            this.ButtonCurrentlyRentedJackets = new System.Windows.Forms.Button();
            this.ButtonCurrentlyRentedPants = new System.Windows.Forms.Button();
            this.flowLayoutPanelHome = new System.Windows.Forms.FlowLayoutPanel();
            this.DueIn10 = new System.Windows.Forms.Label();
            this.over30 = new System.Windows.Forms.Label();
            this.dataGridViewDueIn10 = new System.Windows.Forms.DataGridView();
            this.dataGridViewPast30 = new System.Windows.Forms.DataGridView();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.splitContainerPantsJackets = new System.Windows.Forms.SplitContainer();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanelHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDueIn10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPast30)).BeginInit();
            this.panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPantsJackets)).BeginInit();
            this.splitContainerPantsJackets.Panel1.SuspendLayout();
            this.splitContainerPantsJackets.Panel2.SuspendLayout();
            this.splitContainerPantsJackets.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonCurrentlyRented
            // 
            this.ButtonCurrentlyRented.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonCurrentlyRented.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCurrentlyRented.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCurrentlyRented.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCurrentlyRented.Location = new System.Drawing.Point(15, 15);
            this.ButtonCurrentlyRented.Margin = new System.Windows.Forms.Padding(100, 50, 100, 0);
            this.ButtonCurrentlyRented.Name = "ButtonCurrentlyRented";
            this.ButtonCurrentlyRented.Size = new System.Drawing.Size(382, 135);
            this.ButtonCurrentlyRented.TabIndex = 2;
            this.ButtonCurrentlyRented.Text = "Currently Rented";
            this.ButtonCurrentlyRented.UseVisualStyleBackColor = false;
            this.ButtonCurrentlyRented.Click += new System.EventHandler(this.ButtonCurrentlyRented_Click);
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
            this.ButtonCurrentlyRentedJackets.Size = new System.Drawing.Size(202, 100);
            this.ButtonCurrentlyRentedJackets.TabIndex = 1;
            this.ButtonCurrentlyRentedJackets.Text = "Coats";
            this.ButtonCurrentlyRentedJackets.UseVisualStyleBackColor = false;
            this.ButtonCurrentlyRentedJackets.Click += new System.EventHandler(this.ButtonCurrentlyRentedJackets_Click);
            // 
            // ButtonCurrentlyRentedPants
            // 
            this.ButtonCurrentlyRentedPants.BackColor = System.Drawing.Color.MidnightBlue;
            this.ButtonCurrentlyRentedPants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCurrentlyRentedPants.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCurrentlyRentedPants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCurrentlyRentedPants.Location = new System.Drawing.Point(0, 0);
            this.ButtonCurrentlyRentedPants.Margin = new System.Windows.Forms.Padding(15);
            this.ButtonCurrentlyRentedPants.Name = "ButtonCurrentlyRentedPants";
            this.ButtonCurrentlyRentedPants.Padding = new System.Windows.Forms.Padding(15);
            this.ButtonCurrentlyRentedPants.Size = new System.Drawing.Size(206, 100);
            this.ButtonCurrentlyRentedPants.TabIndex = 4;
            this.ButtonCurrentlyRentedPants.Text = "Pants";
            this.ButtonCurrentlyRentedPants.UseVisualStyleBackColor = false;
            this.ButtonCurrentlyRentedPants.Click += new System.EventHandler(this.ButtonCurrentlyRentedPants_Click);
            // 
            // flowLayoutPanelHome
            // 
            this.flowLayoutPanelHome.BackColor = System.Drawing.Color.MidnightBlue;
            this.flowLayoutPanelHome.Controls.Add(this.DueIn10);
            this.flowLayoutPanelHome.Controls.Add(this.over30);
            this.flowLayoutPanelHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelHome.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelHome.Name = "flowLayoutPanelHome";
            this.flowLayoutPanelHome.Size = new System.Drawing.Size(1016, 35);
            this.flowLayoutPanelHome.TabIndex = 5;
            // 
            // DueIn10
            // 
            this.DueIn10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DueIn10.AutoSize = true;
            this.DueIn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DueIn10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DueIn10.Location = new System.Drawing.Point(30, 10);
            this.DueIn10.Margin = new System.Windows.Forms.Padding(30, 10, 0, 0);
            this.DueIn10.Name = "DueIn10";
            this.DueIn10.Size = new System.Drawing.Size(215, 25);
            this.DueIn10.TabIndex = 0;
            this.DueIn10.Text = "Due Withinn 10 Days";
            // 
            // over30
            // 
            this.over30.AutoSize = true;
            this.over30.Dock = System.Windows.Forms.DockStyle.Right;
            this.over30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.over30.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.over30.Location = new System.Drawing.Point(745, 10);
            this.over30.Margin = new System.Windows.Forms.Padding(500, 10, 0, 0);
            this.over30.Name = "over30";
            this.over30.Size = new System.Drawing.Size(189, 25);
            this.over30.TabIndex = 1;
            this.over30.Text = "30 Days Over Due";
            // 
            // dataGridViewDueIn10
            // 
            this.dataGridViewDueIn10.AllowUserToAddRows = false;
            this.dataGridViewDueIn10.AllowUserToDeleteRows = false;
            this.dataGridViewDueIn10.AllowUserToResizeRows = false;
            this.dataGridViewDueIn10.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDueIn10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDueIn10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDueIn10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Rentee});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDueIn10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDueIn10.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewDueIn10.Location = new System.Drawing.Point(0, 35);
            this.dataGridViewDueIn10.Name = "dataGridViewDueIn10";
            this.dataGridViewDueIn10.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDueIn10.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDueIn10.RowHeadersVisible = false;
            this.dataGridViewDueIn10.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewDueIn10.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewDueIn10.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewDueIn10.RowTemplate.Height = 24;
            this.dataGridViewDueIn10.Size = new System.Drawing.Size(303, 454);
            this.dataGridViewDueIn10.TabIndex = 6;
            // 
            // dataGridViewPast30
            // 
            this.dataGridViewPast30.AllowUserToAddRows = false;
            this.dataGridViewPast30.AllowUserToDeleteRows = false;
            this.dataGridViewPast30.AllowUserToResizeRows = false;
            this.dataGridViewPast30.BackgroundColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPast30.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPast30.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPast30.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product2,
            this.Rentee2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPast30.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewPast30.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewPast30.Location = new System.Drawing.Point(715, 35);
            this.dataGridViewPast30.Name = "dataGridViewPast30";
            this.dataGridViewPast30.ReadOnly = true;
            this.dataGridViewPast30.RowHeadersVisible = false;
            this.dataGridViewPast30.RowHeadersWidth = 51;
            this.dataGridViewPast30.RowTemplate.Height = 24;
            this.dataGridViewPast30.Size = new System.Drawing.Size(301, 454);
            this.dataGridViewPast30.TabIndex = 7;
            // 
            // panelTotal
            // 
            this.panelTotal.Controls.Add(this.ButtonCurrentlyRented);
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTotal.Location = new System.Drawing.Point(303, 35);
            this.panelTotal.Margin = new System.Windows.Forms.Padding(20);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Padding = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.panelTotal.Size = new System.Drawing.Size(412, 150);
            this.panelTotal.TabIndex = 8;
            // 
            // splitContainerPantsJackets
            // 
            this.splitContainerPantsJackets.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerPantsJackets.Location = new System.Drawing.Point(303, 185);
            this.splitContainerPantsJackets.Margin = new System.Windows.Forms.Padding(15);
            this.splitContainerPantsJackets.Name = "splitContainerPantsJackets";
            // 
            // splitContainerPantsJackets.Panel1
            // 
            this.splitContainerPantsJackets.Panel1.Controls.Add(this.ButtonCurrentlyRentedPants);
            // 
            // splitContainerPantsJackets.Panel2
            // 
            this.splitContainerPantsJackets.Panel2.Controls.Add(this.ButtonCurrentlyRentedJackets);
            this.splitContainerPantsJackets.Size = new System.Drawing.Size(412, 100);
            this.splitContainerPantsJackets.SplitterDistance = 206;
            this.splitContainerPantsJackets.TabIndex = 0;
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
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 489);
            this.Controls.Add(this.splitContainerPantsJackets);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.dataGridViewPast30);
            this.Controls.Add(this.dataGridViewDueIn10);
            this.Controls.Add(this.flowLayoutPanelHome);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.flowLayoutPanelHome.ResumeLayout(false);
            this.flowLayoutPanelHome.PerformLayout();
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
        private System.Windows.Forms.Button ButtonCurrentlyRented;
        private System.Windows.Forms.Button ButtonCurrentlyRentedJackets;
        private System.Windows.Forms.Button ButtonCurrentlyRentedPants;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHome;
        private System.Windows.Forms.DataGridView dataGridViewDueIn10;
        private System.Windows.Forms.DataGridView dataGridViewPast30;
        private System.Windows.Forms.Label DueIn10;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.SplitContainer splitContainerPantsJackets;
        private System.Windows.Forms.Label over30;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentee2;
    }
}