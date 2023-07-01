namespace InventoryManagmentSystem
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.flowLayoutPatchNotes = new System.Windows.Forms.FlowLayoutPanel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPatchNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPatchNotes
            // 
            this.flowLayoutPatchNotes.AutoScroll = true;
            this.flowLayoutPatchNotes.Controls.Add(this.labelVersion);
            this.flowLayoutPatchNotes.Controls.Add(this.textBox1);
            this.flowLayoutPatchNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPatchNotes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPatchNotes.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPatchNotes.Name = "flowLayoutPatchNotes";
            this.flowLayoutPatchNotes.Size = new System.Drawing.Size(1196, 668);
            this.flowLayoutPatchNotes.TabIndex = 0;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(3, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(1071, 54);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version 1.5 patch notes";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Maroon;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(50, 74);
            this.textBox1.Margin = new System.Windows.Forms.Padding(50, 20, 3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1024, 556);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1196, 668);
            this.Controls.Add(this.flowLayoutPatchNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.flowLayoutPatchNotes.ResumeLayout(false);
            this.flowLayoutPatchNotes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPatchNotes;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TextBox textBox1;
    }
}