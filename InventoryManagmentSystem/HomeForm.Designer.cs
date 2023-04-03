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
            this.over30.Size = new System.Drawing.Size(215, 25);
            this.over30.TabIndex = 1;
            this.over30.Text = "Due Withinn 10 Days";
            // 
            // dataGridViewDueIn10
            // 
            this.dataGridViewDueIn10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDueIn10.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewDueIn10.Location = new System.Drawing.Point(0, 35);
            this.dataGridViewDueIn10.Name = "dataGridViewDueIn10";
            this.dataGridViewDueIn10.RowHeadersWidth = 51;
            this.dataGridViewDueIn10.RowTemplate.Height = 24;
            this.dataGridViewDueIn10.Size = new System.Drawing.Size(303, 454);
            this.dataGridViewDueIn10.TabIndex = 6;
            // 
            // dataGridViewPast30
            // 
            this.dataGridViewPast30.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPast30.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewPast30.Location = new System.Drawing.Point(715, 35);
            this.dataGridViewPast30.Name = "dataGridViewPast30";
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
    }
}