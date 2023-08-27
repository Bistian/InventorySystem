namespace InventoryManagmentSystem
{
    partial class CreateClassForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelClassName = new System.Windows.Forms.Label();
            this.tbClassName = new System.Windows.Forms.TextBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dpStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbAcademy = new System.Windows.Forms.ComboBox();
            this.labelAcademy = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnResetStart = new System.Windows.Forms.Button();
            this.btnResetEnd = new System.Windows.Forms.Button();
            this.btnResetName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(18, 23);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(215, 31);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Create Classes";
            // 
            // labelClassName
            // 
            this.labelClassName.AutoSize = true;
            this.labelClassName.Location = new System.Drawing.Point(21, 128);
            this.labelClassName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(132, 26);
            this.labelClassName.TabIndex = 1;
            this.labelClassName.Text = "Class Name";
            // 
            // tbClassName
            // 
            this.tbClassName.Location = new System.Drawing.Point(25, 157);
            this.tbClassName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbClassName.Name = "tbClassName";
            this.tbClassName.Size = new System.Drawing.Size(370, 32);
            this.tbClassName.TabIndex = 2;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(21, 196);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(110, 26);
            this.labelStartDate.TabIndex = 3;
            this.labelStartDate.Text = "Start Date";
            // 
            // dpStartDate
            // 
            this.dpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dpStartDate.Location = new System.Drawing.Point(25, 225);
            this.dpStartDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dpStartDate.Name = "dpStartDate";
            this.dpStartDate.Size = new System.Drawing.Size(370, 23);
            this.dpStartDate.TabIndex = 4;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(21, 262);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(103, 26);
            this.labelEndDate.TabIndex = 5;
            this.labelEndDate.Text = "End Date";
            // 
            // dpEndDate
            // 
            this.dpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dpEndDate.Location = new System.Drawing.Point(25, 292);
            this.dpEndDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dpEndDate.Name = "dpEndDate";
            this.dpEndDate.Size = new System.Drawing.Size(370, 23);
            this.dpEndDate.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAdd.Location = new System.Drawing.Point(25, 333);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(373, 33);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbAcademy
            // 
            this.cbAcademy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcademy.FormattingEnabled = true;
            this.cbAcademy.Location = new System.Drawing.Point(25, 87);
            this.cbAcademy.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbAcademy.Name = "cbAcademy";
            this.cbAcademy.Size = new System.Drawing.Size(370, 34);
            this.cbAcademy.TabIndex = 9;
            // 
            // labelAcademy
            // 
            this.labelAcademy.AutoSize = true;
            this.labelAcademy.Location = new System.Drawing.Point(21, 58);
            this.labelAcademy.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelAcademy.Name = "labelAcademy";
            this.labelAcademy.Size = new System.Drawing.Size(104, 26);
            this.labelAcademy.TabIndex = 10;
            this.labelAcademy.Text = "Academy";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Location = new System.Drawing.Point(26, 374);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(373, 33);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResetStart
            // 
            this.btnResetStart.Enabled = false;
            this.btnResetStart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnResetStart.Location = new System.Drawing.Point(403, 225);
            this.btnResetStart.Name = "btnResetStart";
            this.btnResetStart.Size = new System.Drawing.Size(39, 23);
            this.btnResetStart.TabIndex = 12;
            this.btnResetStart.Text = "X";
            this.btnResetStart.UseVisualStyleBackColor = true;
            this.btnResetStart.Visible = false;
            // 
            // btnResetEnd
            // 
            this.btnResetEnd.Enabled = false;
            this.btnResetEnd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnResetEnd.Location = new System.Drawing.Point(403, 292);
            this.btnResetEnd.Name = "btnResetEnd";
            this.btnResetEnd.Size = new System.Drawing.Size(39, 23);
            this.btnResetEnd.TabIndex = 13;
            this.btnResetEnd.Text = "X";
            this.btnResetEnd.UseVisualStyleBackColor = true;
            this.btnResetEnd.Visible = false;
            // 
            // btnResetName
            // 
            this.btnResetName.Enabled = false;
            this.btnResetName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnResetName.Location = new System.Drawing.Point(403, 157);
            this.btnResetName.Name = "btnResetName";
            this.btnResetName.Size = new System.Drawing.Size(39, 32);
            this.btnResetName.TabIndex = 14;
            this.btnResetName.Text = "X";
            this.btnResetName.UseVisualStyleBackColor = true;
            this.btnResetName.Visible = false;
            // 
            // CreateClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1467, 726);
            this.Controls.Add(this.btnResetName);
            this.Controls.Add(this.btnResetEnd);
            this.Controls.Add(this.btnResetStart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelAcademy);
            this.Controls.Add(this.cbAcademy);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dpEndDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.dpStartDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.tbClassName);
            this.Controls.Add(this.labelClassName);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Name = "CreateClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelClassName;
        private System.Windows.Forms.TextBox tbClassName;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dpStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dpEndDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbAcademy;
        private System.Windows.Forms.Label labelAcademy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnResetStart;
        private System.Windows.Forms.Button btnResetEnd;
        private System.Windows.Forms.Button btnResetName;
    }
}