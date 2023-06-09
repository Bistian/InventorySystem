namespace InventoryManagmentSystem
{
    partial class PricesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PricesForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labelBoots = new System.Windows.Forms.Label();
            this.tbBoots = new System.Windows.Forms.TextBox();
            this.labelHelmet = new System.Windows.Forms.Label();
            this.tbHelmet = new System.Windows.Forms.TextBox();
            this.labelJacket = new System.Windows.Forms.Label();
            this.tbJacket = new System.Windows.Forms.TextBox();
            this.labelPants = new System.Windows.Forms.Label();
            this.tbPants = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Boots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Helmets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jackets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pants = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.Update = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.NameColumn,
            this.Boots,
            this.Helmets,
            this.Jackets,
            this.Pants,
            this.Remove,
            this.Update});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(148, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(463, 266);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelName.ForeColor = System.Drawing.SystemColors.Window;
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(48, 18);
            this.labelName.TabIndex = 11;
            this.labelName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbName.Location = new System.Drawing.Point(12, 30);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 24);
            this.tbName.TabIndex = 10;
            // 
            // labelBoots
            // 
            this.labelBoots.AutoSize = true;
            this.labelBoots.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelBoots.ForeColor = System.Drawing.SystemColors.Window;
            this.labelBoots.Location = new System.Drawing.Point(12, 57);
            this.labelBoots.Name = "labelBoots";
            this.labelBoots.Size = new System.Drawing.Size(48, 18);
            this.labelBoots.TabIndex = 13;
            this.labelBoots.Text = "Boots";
            // 
            // tbBoots
            // 
            this.tbBoots.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbBoots.Location = new System.Drawing.Point(12, 78);
            this.tbBoots.Name = "tbBoots";
            this.tbBoots.Size = new System.Drawing.Size(121, 24);
            this.tbBoots.TabIndex = 12;
            this.tbBoots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBoots.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBoots_KeyPress);
            // 
            // labelHelmet
            // 
            this.labelHelmet.AutoSize = true;
            this.labelHelmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelHelmet.ForeColor = System.Drawing.SystemColors.Window;
            this.labelHelmet.Location = new System.Drawing.Point(12, 105);
            this.labelHelmet.Name = "labelHelmet";
            this.labelHelmet.Size = new System.Drawing.Size(55, 18);
            this.labelHelmet.TabIndex = 15;
            this.labelHelmet.Text = "Helmet";
            // 
            // tbHelmet
            // 
            this.tbHelmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbHelmet.Location = new System.Drawing.Point(12, 126);
            this.tbHelmet.Name = "tbHelmet";
            this.tbHelmet.Size = new System.Drawing.Size(121, 24);
            this.tbHelmet.TabIndex = 14;
            this.tbHelmet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbHelmet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelmet_KeyPress);
            // 
            // labelJacket
            // 
            this.labelJacket.AutoSize = true;
            this.labelJacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelJacket.ForeColor = System.Drawing.SystemColors.Window;
            this.labelJacket.Location = new System.Drawing.Point(12, 153);
            this.labelJacket.Name = "labelJacket";
            this.labelJacket.Size = new System.Drawing.Size(52, 18);
            this.labelJacket.TabIndex = 17;
            this.labelJacket.Text = "Jacket";
            // 
            // tbJacket
            // 
            this.tbJacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbJacket.Location = new System.Drawing.Point(12, 174);
            this.tbJacket.Name = "tbJacket";
            this.tbJacket.Size = new System.Drawing.Size(121, 24);
            this.tbJacket.TabIndex = 16;
            this.tbJacket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbJacket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbJacket_KeyPress);
            // 
            // labelPants
            // 
            this.labelPants.AutoSize = true;
            this.labelPants.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelPants.ForeColor = System.Drawing.SystemColors.Window;
            this.labelPants.Location = new System.Drawing.Point(12, 201);
            this.labelPants.Name = "labelPants";
            this.labelPants.Size = new System.Drawing.Size(46, 18);
            this.labelPants.TabIndex = 19;
            this.labelPants.Text = "Pants";
            // 
            // tbPants
            // 
            this.tbPants.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbPants.Location = new System.Drawing.Point(12, 222);
            this.tbPants.Name = "tbPants";
            this.tbPants.Size = new System.Drawing.Size(121, 24);
            this.tbPants.TabIndex = 18;
            this.tbPants.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPants.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPants_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAdd.Location = new System.Drawing.Point(12, 252);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add / Update";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Number
            // 
            this.Number.HeaderText = "#";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 25;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // Boots
            // 
            this.Boots.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Boots.HeaderText = "Boots";
            this.Boots.Name = "Boots";
            this.Boots.ReadOnly = true;
            // 
            // Helmets
            // 
            this.Helmets.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Helmets.HeaderText = "Helmets";
            this.Helmets.Name = "Helmets";
            this.Helmets.ReadOnly = true;
            // 
            // Jackets
            // 
            this.Jackets.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Jackets.HeaderText = "Jackets";
            this.Jackets.Name = "Jackets";
            this.Jackets.ReadOnly = true;
            // 
            // Pants
            // 
            this.Pants.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pants.HeaderText = "Pants";
            this.Pants.Name = "Pants";
            this.Pants.ReadOnly = true;
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remove.FillWeight = 50F;
            this.Remove.HeaderText = "";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            // 
            // Update
            // 
            this.Update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Update.FillWeight = 50F;
            this.Update.HeaderText = "";
            this.Update.Image = ((System.Drawing.Image)(resources.GetObject("Update.Image")));
            this.Update.Name = "Update";
            this.Update.ReadOnly = true;
            // 
            // PricesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelPants);
            this.Controls.Add(this.tbPants);
            this.Controls.Add(this.labelJacket);
            this.Controls.Add(this.tbJacket);
            this.Controls.Add(this.labelHelmet);
            this.Controls.Add(this.tbHelmet);
            this.Controls.Add(this.labelBoots);
            this.Controls.Add(this.tbBoots);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PricesForm";
            this.Text = "PricesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label labelBoots;
        private System.Windows.Forms.TextBox tbBoots;
        private System.Windows.Forms.Label labelHelmet;
        private System.Windows.Forms.TextBox tbHelmet;
        private System.Windows.Forms.Label labelJacket;
        private System.Windows.Forms.TextBox tbJacket;
        private System.Windows.Forms.Label labelPants;
        private System.Windows.Forms.TextBox tbPants;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Boots;
        private System.Windows.Forms.DataGridViewTextBoxColumn Helmets;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jackets;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pants;
        private System.Windows.Forms.DataGridViewImageColumn Remove;
        private System.Windows.Forms.DataGridViewImageColumn Update;
    }
}