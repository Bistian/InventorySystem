namespace InventoryManagmentSystem
{
    partial class InventoryModuleForm
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
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.InventoryTxt = new System.Windows.Forms.Label();
            this.InventoryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.BackColor = System.Drawing.Color.Maroon;
            this.InventoryPanel.Controls.Add(this.InventoryTxt);
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(755, 64);
            this.InventoryPanel.TabIndex = 21;
            // 
            // InventoryTxt
            // 
            this.InventoryTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryTxt.AutoSize = true;
            this.InventoryTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.InventoryTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InventoryTxt.Location = new System.Drawing.Point(16, 16);
            this.InventoryTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InventoryTxt.Name = "InventoryTxt";
            this.InventoryTxt.Size = new System.Drawing.Size(219, 29);
            this.InventoryTxt.TabIndex = 15;
            this.InventoryTxt.Text = "Inventory Moduel ";
            this.InventoryTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InventoryModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(755, 350);
            this.Controls.Add(this.InventoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InventoryModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryModuleForm";
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private System.Windows.Forms.Label InventoryTxt;
    }
}