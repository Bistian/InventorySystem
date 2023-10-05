namespace InventoryManagmentSystem.Academy
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Location = new System.Drawing.Point(21, 258);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(373, 33);
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
            this.labelAcademy.Size = new System.Drawing.Size(150, 37);
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
            this.cbAcademy.Size = new System.Drawing.Size(370, 45);
            this.cbAcademy.TabIndex = 20;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAdd.Location = new System.Drawing.Point(20, 217);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(373, 33);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // labelClassName
            // 
            this.labelClassName.AutoSize = true;
            this.labelClassName.Location = new System.Drawing.Point(19, 125);
            this.labelClassName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(192, 37);
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
            this.labelTitle.Size = new System.Drawing.Size(0, 46);
            this.labelTitle.TabIndex = 12;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(23, 153);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(370, 45);
            this.comboBox1.TabIndex = 23;
            // 
            // AssignStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(489, 1317);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelAcademy);
            this.Controls.Add(this.cbAcademy);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelClassName);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
        private System.Windows.Forms.ComboBox comboBox1;
    }
}