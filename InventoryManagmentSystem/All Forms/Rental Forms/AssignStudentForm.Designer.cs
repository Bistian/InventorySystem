namespace InventoryManagmentSystem
{
    partial class AssignStudentForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelAcademy = new System.Windows.Forms.Label();
            this.cbAcademy = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelClassName = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.cbClasses = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Location = new System.Drawing.Point(21, 258);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(340, 33);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // labelAcademy
            // 
            this.labelAcademy.AutoSize = true;
            this.labelAcademy.Location = new System.Drawing.Point(19, 55);
            this.labelAcademy.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelAcademy.Name = "labelAcademy";
            this.labelAcademy.Size = new System.Drawing.Size(127, 31);
            this.labelAcademy.TabIndex = 21;
            this.labelAcademy.Text = "Academy";
            // 
            // cbAcademy
            // 
            this.cbAcademy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcademy.FormattingEnabled = true;
            this.cbAcademy.Location = new System.Drawing.Point(23, 84);
            this.cbAcademy.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbAcademy.Name = "cbAcademy";
            this.cbAcademy.Size = new System.Drawing.Size(338, 39);
            this.cbAcademy.TabIndex = 20;
            this.cbAcademy.SelectedIndexChanged += new System.EventHandler(this.cbAcademy_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAdd.Location = new System.Drawing.Point(20, 217);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(341, 33);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelClassName
            // 
            this.labelClassName.AutoSize = true;
            this.labelClassName.Location = new System.Drawing.Point(19, 125);
            this.labelClassName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(162, 31);
            this.labelClassName.TabIndex = 13;
            this.labelClassName.Text = "Class Name";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(16, 20);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(235, 38);
            this.labelTitle.TabIndex = 12;
            this.labelTitle.Text = "Enroll Student";
            // 
            // cbClasses
            // 
            this.cbClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasses.Enabled = false;
            this.cbClasses.FormattingEnabled = true;
            this.cbClasses.Location = new System.Drawing.Point(23, 153);
            this.cbClasses.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbClasses.Name = "cbClasses";
            this.cbClasses.Size = new System.Drawing.Size(338, 39);
            this.cbClasses.TabIndex = 23;
            // 
            // AssignStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(489, 1061);
            this.Controls.Add(this.cbClasses);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelAcademy);
            this.Controls.Add(this.cbAcademy);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelClassName);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AssignStudentForm";
            this.Text = "AssignStudentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelAcademy;
        private System.Windows.Forms.ComboBox cbAcademy;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelClassName;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ComboBox cbClasses;
    }
}
