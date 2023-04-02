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
            this.CurrentlyRentedJackets = new System.Windows.Forms.Button();
            this.Button30DaysPast = new System.Windows.Forms.Button();
            this.CurrentlyRentedPants = new System.Windows.Forms.Button();
            this.flowLayoutPanelHome = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewDueIn10 = new System.Windows.Forms.DataGridView();
            this.dataGridViewPast30 = new System.Windows.Forms.DataGridView();
            this.DueIn10 = new System.Windows.Forms.Label();
            this.flowLayoutPanelHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDueIn10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPast30)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentlyRentedJackets
            // 
            this.CurrentlyRentedJackets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CurrentlyRentedJackets.BackColor = System.Drawing.Color.MidnightBlue;
            this.CurrentlyRentedJackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentlyRentedJackets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurrentlyRentedJackets.Location = new System.Drawing.Point(342, 113);
            this.CurrentlyRentedJackets.Margin = new System.Windows.Forms.Padding(100, 50, 100, 0);
            this.CurrentlyRentedJackets.Name = "CurrentlyRentedJackets";
            this.CurrentlyRentedJackets.Size = new System.Drawing.Size(340, 150);
            this.CurrentlyRentedJackets.TabIndex = 2;
            this.CurrentlyRentedJackets.Text = "Currently Rented";
            this.CurrentlyRentedJackets.UseVisualStyleBackColor = false;
            this.CurrentlyRentedJackets.Click += new System.EventHandler(this.CurrentlyRentedJackets_Click);
            // 
            // Button30DaysPast
            // 
            this.Button30DaysPast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button30DaysPast.BackColor = System.Drawing.Color.MidnightBlue;
            this.Button30DaysPast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button30DaysPast.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Button30DaysPast.Location = new System.Drawing.Point(542, 263);
            this.Button30DaysPast.Margin = new System.Windows.Forms.Padding(320, 0, 0, 0);
            this.Button30DaysPast.Name = "Button30DaysPast";
            this.Button30DaysPast.Size = new System.Drawing.Size(170, 100);
            this.Button30DaysPast.TabIndex = 1;
            this.Button30DaysPast.Text = "Coats";
            this.Button30DaysPast.UseVisualStyleBackColor = false;
            // 
            // CurrentlyRentedPants
            // 
            this.CurrentlyRentedPants.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CurrentlyRentedPants.BackColor = System.Drawing.Color.MidnightBlue;
            this.CurrentlyRentedPants.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentlyRentedPants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurrentlyRentedPants.Location = new System.Drawing.Point(312, 263);
            this.CurrentlyRentedPants.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.CurrentlyRentedPants.Name = "CurrentlyRentedPants";
            this.CurrentlyRentedPants.Size = new System.Drawing.Size(170, 100);
            this.CurrentlyRentedPants.TabIndex = 4;
            this.CurrentlyRentedPants.Text = "Pants";
            this.CurrentlyRentedPants.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanelHome
            // 
            this.flowLayoutPanelHome.BackColor = System.Drawing.Color.MidnightBlue;
            this.flowLayoutPanelHome.Controls.Add(this.DueIn10);
            this.flowLayoutPanelHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelHome.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelHome.Name = "flowLayoutPanelHome";
            this.flowLayoutPanelHome.Size = new System.Drawing.Size(1016, 35);
            this.flowLayoutPanelHome.TabIndex = 5;
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
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 489);
            this.Controls.Add(this.dataGridViewPast30);
            this.Controls.Add(this.dataGridViewDueIn10);
            this.Controls.Add(this.flowLayoutPanelHome);
            this.Controls.Add(this.CurrentlyRentedJackets);
            this.Controls.Add(this.CurrentlyRentedPants);
            this.Controls.Add(this.Button30DaysPast);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.flowLayoutPanelHome.ResumeLayout(false);
            this.flowLayoutPanelHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDueIn10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPast30)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CurrentlyRentedJackets;
        private System.Windows.Forms.Button Button30DaysPast;
        private System.Windows.Forms.Button CurrentlyRentedPants;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHome;
        private System.Windows.Forms.DataGridView dataGridViewDueIn10;
        private System.Windows.Forms.DataGridView dataGridViewPast30;
        private System.Windows.Forms.Label DueIn10;
    }
}