namespace InventoryManagmentSystem
{
    partial class WorkOrderModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkOrderModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.NewJacketTxt = new System.Windows.Forms.Label();
            this.MyLogo = new System.Windows.Forms.PictureBox();
            this.LableClientName = new System.Windows.Forms.Label();
            this.lableRentalOption = new System.Windows.Forms.Label();
            this.Item1 = new System.Windows.Forms.Label();
            this.Item2 = new System.Windows.Forms.Label();
            this.Item3 = new System.Windows.Forms.Label();
            this.Item4 = new System.Windows.Forms.Label();
            this.lablePrice = new System.Windows.Forms.Label();
            this.labelamount = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.CloseButton = new InventoryManagmentSystem.CustomButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.NewJacketTxt);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.MyLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 73);
            this.panel1.TabIndex = 1;
            // 
            // NewJacketTxt
            // 
            this.NewJacketTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewJacketTxt.AutoSize = true;
            this.NewJacketTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewJacketTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewJacketTxt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NewJacketTxt.Location = new System.Drawing.Point(222, 22);
            this.NewJacketTxt.Name = "NewJacketTxt";
            this.NewJacketTxt.Size = new System.Drawing.Size(148, 29);
            this.NewJacketTxt.TabIndex = 17;
            this.NewJacketTxt.Text = "Work Order";
            this.NewJacketTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MyLogo
            // 
            this.MyLogo.Image = ((System.Drawing.Image)(resources.GetObject("MyLogo.Image")));
            this.MyLogo.Location = new System.Drawing.Point(3, 3);
            this.MyLogo.Name = "MyLogo";
            this.MyLogo.Size = new System.Drawing.Size(64, 67);
            this.MyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MyLogo.TabIndex = 6;
            this.MyLogo.TabStop = false;
            // 
            // LableClientName
            // 
            this.LableClientName.AutoSize = true;
            this.LableClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableClientName.Location = new System.Drawing.Point(242, 108);
            this.LableClientName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LableClientName.Name = "LableClientName";
            this.LableClientName.Size = new System.Drawing.Size(112, 39);
            this.LableClientName.TabIndex = 2;
            this.LableClientName.Text = "Client";
            // 
            // lableRentalOption
            // 
            this.lableRentalOption.AutoSize = true;
            this.lableRentalOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableRentalOption.Location = new System.Drawing.Point(47, 186);
            this.lableRentalOption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lableRentalOption.Name = "lableRentalOption";
            this.lableRentalOption.Size = new System.Drawing.Size(166, 29);
            this.lableRentalOption.TabIndex = 3;
            this.lableRentalOption.Text = "Rental Option:";
            // 
            // Item1
            // 
            this.Item1.AutoSize = true;
            this.Item1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item1.Location = new System.Drawing.Point(95, 227);
            this.Item1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Item1.Name = "Item1";
            this.Item1.Size = new System.Drawing.Size(55, 24);
            this.Item1.TabIndex = 5;
            this.Item1.Text = "Item1";
            // 
            // Item2
            // 
            this.Item2.AutoSize = true;
            this.Item2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item2.Location = new System.Drawing.Point(95, 254);
            this.Item2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Item2.Name = "Item2";
            this.Item2.Size = new System.Drawing.Size(55, 24);
            this.Item2.TabIndex = 6;
            this.Item2.Text = "Item2";
            // 
            // Item3
            // 
            this.Item3.AutoSize = true;
            this.Item3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item3.Location = new System.Drawing.Point(95, 281);
            this.Item3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Item3.Name = "Item3";
            this.Item3.Size = new System.Drawing.Size(55, 24);
            this.Item3.TabIndex = 7;
            this.Item3.Text = "Item3";
            // 
            // Item4
            // 
            this.Item4.AutoSize = true;
            this.Item4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item4.Location = new System.Drawing.Point(95, 307);
            this.Item4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Item4.Name = "Item4";
            this.Item4.Size = new System.Drawing.Size(55, 24);
            this.Item4.TabIndex = 8;
            this.Item4.Text = "Item4";
            // 
            // lablePrice
            // 
            this.lablePrice.AutoSize = true;
            this.lablePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablePrice.Location = new System.Drawing.Point(314, 186);
            this.lablePrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lablePrice.Name = "lablePrice";
            this.lablePrice.Size = new System.Drawing.Size(89, 29);
            this.lablePrice.TabIndex = 9;
            this.lablePrice.Text = "Price =";
            // 
            // labelamount
            // 
            this.labelamount.AutoSize = true;
            this.labelamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelamount.Location = new System.Drawing.Point(399, 186);
            this.labelamount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelamount.Name = "labelamount";
            this.labelamount.Size = new System.Drawing.Size(92, 29);
            this.labelamount.TabIndex = 10;
            this.labelamount.Text = "amount";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Maroon;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnPrint.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPrint.Location = new System.Drawing.Point(514, 325);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageHover")));
            this.CloseButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseButton.ImageNormal")));
            this.CloseButton.Location = new System.Drawing.Point(563, 9);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(27, 34);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 13;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // WorkOrderModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelamount);
            this.Controls.Add(this.lablePrice);
            this.Controls.Add(this.Item4);
            this.Controls.Add(this.Item3);
            this.Controls.Add(this.Item2);
            this.Controls.Add(this.Item1);
            this.Controls.Add(this.lableRentalOption);
            this.Controls.Add(this.LableClientName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WorkOrderModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkOrderModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomButton CloseButton;
        private System.Windows.Forms.PictureBox MyLogo;
        private System.Windows.Forms.Label NewJacketTxt;
        private System.Windows.Forms.Label LableClientName;
        private System.Windows.Forms.Label Item1;
        private System.Windows.Forms.Label Item2;
        private System.Windows.Forms.Label Item3;
        private System.Windows.Forms.Label Item4;
        private System.Windows.Forms.Label lablePrice;
        private System.Windows.Forms.Label labelamount;
        public System.Windows.Forms.Label lableRentalOption;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}