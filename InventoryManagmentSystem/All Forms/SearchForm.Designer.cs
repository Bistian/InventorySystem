﻿namespace InventoryManagmentSystem.All_Forms
{
    partial class SearchForm
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
            this.cb_item_type = new System.Windows.Forms.ComboBox();
            this.label_item_type = new System.Windows.Forms.Label();
            this.label_serial_number = new System.Windows.Forms.Label();
            this.label_condition = new System.Windows.Forms.Label();
            this.cb_condition = new System.Windows.Forms.ComboBox();
            this.tb_serial_number = new System.Windows.Forms.TextBox();
            this.tb_size = new System.Windows.Forms.TextBox();
            this.label_size = new System.Windows.Forms.Label();
            this.label_color = new System.Windows.Forms.Label();
            this.cb_color = new System.Windows.Forms.ComboBox();
            this.label_material = new System.Windows.Forms.Label();
            this.cb_material = new System.Windows.Forms.ComboBox();
            this.label_brand = new System.Windows.Forms.Label();
            this.cb_brand = new System.Windows.Forms.ComboBox();
            this.panel_item_type = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_serial_number = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_clear_serial = new System.Windows.Forms.Button();
            this.panel_brand = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_clear_brand = new System.Windows.Forms.Button();
            this.panel_condition = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_clear_condition = new System.Windows.Forms.Button();
            this.panel_size = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_clear_size = new System.Windows.Forms.Button();
            this.panel_color = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_clear_color = new System.Windows.Forms.Button();
            this.panel_material = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_clear_material = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel_check_box = new System.Windows.Forms.FlowLayoutPanel();
            this.check_in_stock = new System.Windows.Forms.CheckBox();
            this.check_rented = new System.Windows.Forms.CheckBox();
            this.panel_size_masks = new System.Windows.Forms.FlowLayoutPanel();
            this.label_size_masks = new System.Windows.Forms.Label();
            this.cb_size_masks = new System.Windows.Forms.ComboBox();
            this.btn_clear_size_masks = new System.Windows.Forms.Button();
            this.panel_item_type.SuspendLayout();
            this.panel_serial_number.SuspendLayout();
            this.panel_brand.SuspendLayout();
            this.panel_condition.SuspendLayout();
            this.panel_size.SuspendLayout();
            this.panel_color.SuspendLayout();
            this.panel_material.SuspendLayout();
            this.panel_check_box.SuspendLayout();
            this.panel_size_masks.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_item_type
            // 
            this.cb_item_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_item_type.FormattingEnabled = true;
            this.cb_item_type.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_item_type.Location = new System.Drawing.Point(4, 22);
            this.cb_item_type.Margin = new System.Windows.Forms.Padding(4);
            this.cb_item_type.Name = "cb_item_type";
            this.cb_item_type.Size = new System.Drawing.Size(228, 26);
            this.cb_item_type.Sorted = true;
            this.cb_item_type.TabIndex = 0;
            this.cb_item_type.SelectedIndexChanged += new System.EventHandler(this.cb_item_type_SelectedIndexChanged);
            // 
            // label_item_type
            // 
            this.label_item_type.AutoSize = true;
            this.label_item_type.Location = new System.Drawing.Point(4, 0);
            this.label_item_type.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_item_type.Name = "label_item_type";
            this.label_item_type.Size = new System.Drawing.Size(72, 18);
            this.label_item_type.TabIndex = 1;
            this.label_item_type.Text = "Item Type";
            // 
            // label_serial_number
            // 
            this.label_serial_number.AutoSize = true;
            this.label_serial_number.Location = new System.Drawing.Point(4, 0);
            this.label_serial_number.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_serial_number.Name = "label_serial_number";
            this.label_serial_number.Size = new System.Drawing.Size(102, 18);
            this.label_serial_number.TabIndex = 3;
            this.label_serial_number.Text = "Serial Number";
            // 
            // label_condition
            // 
            this.label_condition.AutoSize = true;
            this.label_condition.Location = new System.Drawing.Point(4, 0);
            this.label_condition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_condition.Name = "label_condition";
            this.label_condition.Size = new System.Drawing.Size(71, 18);
            this.label_condition.TabIndex = 5;
            this.label_condition.Text = "Condition";
            // 
            // cb_condition
            // 
            this.cb_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_condition.FormattingEnabled = true;
            this.cb_condition.Location = new System.Drawing.Point(4, 22);
            this.cb_condition.Margin = new System.Windows.Forms.Padding(4);
            this.cb_condition.Name = "cb_condition";
            this.cb_condition.Size = new System.Drawing.Size(192, 26);
            this.cb_condition.Sorted = true;
            this.cb_condition.TabIndex = 4;
            // 
            // tb_serial_number
            // 
            this.tb_serial_number.Location = new System.Drawing.Point(3, 21);
            this.tb_serial_number.Name = "tb_serial_number";
            this.tb_serial_number.Size = new System.Drawing.Size(193, 24);
            this.tb_serial_number.TabIndex = 6;
            // 
            // tb_size
            // 
            this.tb_size.Location = new System.Drawing.Point(3, 21);
            this.tb_size.Name = "tb_size";
            this.tb_size.Size = new System.Drawing.Size(193, 24);
            this.tb_size.TabIndex = 8;
            // 
            // label_size
            // 
            this.label_size.AutoSize = true;
            this.label_size.Location = new System.Drawing.Point(4, 0);
            this.label_size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_size.Name = "label_size";
            this.label_size.Size = new System.Drawing.Size(37, 18);
            this.label_size.TabIndex = 7;
            this.label_size.Text = "Size";
            // 
            // label_color
            // 
            this.label_color.AutoSize = true;
            this.label_color.Location = new System.Drawing.Point(4, 0);
            this.label_color.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_color.Name = "label_color";
            this.label_color.Size = new System.Drawing.Size(45, 18);
            this.label_color.TabIndex = 10;
            this.label_color.Text = "Color";
            // 
            // cb_color
            // 
            this.cb_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_color.FormattingEnabled = true;
            this.cb_color.Location = new System.Drawing.Point(4, 22);
            this.cb_color.Margin = new System.Windows.Forms.Padding(4);
            this.cb_color.Name = "cb_color";
            this.cb_color.Size = new System.Drawing.Size(192, 26);
            this.cb_color.Sorted = true;
            this.cb_color.TabIndex = 9;
            // 
            // label_material
            // 
            this.label_material.AutoSize = true;
            this.label_material.Location = new System.Drawing.Point(4, 0);
            this.label_material.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_material.Name = "label_material";
            this.label_material.Size = new System.Drawing.Size(60, 18);
            this.label_material.TabIndex = 12;
            this.label_material.Text = "Material";
            // 
            // cb_material
            // 
            this.cb_material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_material.FormattingEnabled = true;
            this.cb_material.Location = new System.Drawing.Point(4, 22);
            this.cb_material.Margin = new System.Windows.Forms.Padding(4);
            this.cb_material.Name = "cb_material";
            this.cb_material.Size = new System.Drawing.Size(192, 26);
            this.cb_material.Sorted = true;
            this.cb_material.TabIndex = 11;
            // 
            // label_brand
            // 
            this.label_brand.AutoSize = true;
            this.label_brand.Location = new System.Drawing.Point(4, 0);
            this.label_brand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_brand.Name = "label_brand";
            this.label_brand.Size = new System.Drawing.Size(47, 18);
            this.label_brand.TabIndex = 14;
            this.label_brand.Text = "Brand";
            // 
            // cb_brand
            // 
            this.cb_brand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_brand.FormattingEnabled = true;
            this.cb_brand.Location = new System.Drawing.Point(4, 22);
            this.cb_brand.Margin = new System.Windows.Forms.Padding(4);
            this.cb_brand.Name = "cb_brand";
            this.cb_brand.Size = new System.Drawing.Size(192, 26);
            this.cb_brand.Sorted = true;
            this.cb_brand.TabIndex = 13;
            // 
            // panel_item_type
            // 
            this.panel_item_type.Controls.Add(this.label_item_type);
            this.panel_item_type.Controls.Add(this.cb_item_type);
            this.panel_item_type.Location = new System.Drawing.Point(12, 12);
            this.panel_item_type.Name = "panel_item_type";
            this.panel_item_type.Size = new System.Drawing.Size(237, 60);
            this.panel_item_type.TabIndex = 15;
            // 
            // panel_serial_number
            // 
            this.panel_serial_number.Controls.Add(this.label_serial_number);
            this.panel_serial_number.Controls.Add(this.tb_serial_number);
            this.panel_serial_number.Controls.Add(this.btn_clear_serial);
            this.panel_serial_number.Location = new System.Drawing.Point(12, 78);
            this.panel_serial_number.Name = "panel_serial_number";
            this.panel_serial_number.Size = new System.Drawing.Size(237, 60);
            this.panel_serial_number.TabIndex = 16;
            // 
            // btn_clear_serial
            // 
            this.btn_clear_serial.Location = new System.Drawing.Point(202, 21);
            this.btn_clear_serial.Name = "btn_clear_serial";
            this.btn_clear_serial.Size = new System.Drawing.Size(26, 26);
            this.btn_clear_serial.TabIndex = 7;
            this.btn_clear_serial.Text = "X";
            this.btn_clear_serial.UseVisualStyleBackColor = true;
            this.btn_clear_serial.Click += new System.EventHandler(this.btn_clear_serial_Click);
            // 
            // panel_brand
            // 
            this.panel_brand.Controls.Add(this.label_brand);
            this.panel_brand.Controls.Add(this.cb_brand);
            this.panel_brand.Controls.Add(this.btn_clear_brand);
            this.panel_brand.Location = new System.Drawing.Point(12, 144);
            this.panel_brand.Name = "panel_brand";
            this.panel_brand.Size = new System.Drawing.Size(237, 60);
            this.panel_brand.TabIndex = 17;
            // 
            // btn_clear_brand
            // 
            this.btn_clear_brand.Location = new System.Drawing.Point(203, 21);
            this.btn_clear_brand.Name = "btn_clear_brand";
            this.btn_clear_brand.Size = new System.Drawing.Size(26, 26);
            this.btn_clear_brand.TabIndex = 15;
            this.btn_clear_brand.Text = "X";
            this.btn_clear_brand.UseVisualStyleBackColor = true;
            this.btn_clear_brand.Click += new System.EventHandler(this.btn_clear_brand_Click);
            // 
            // panel_condition
            // 
            this.panel_condition.Controls.Add(this.label_condition);
            this.panel_condition.Controls.Add(this.cb_condition);
            this.panel_condition.Controls.Add(this.btn_clear_condition);
            this.panel_condition.Location = new System.Drawing.Point(12, 210);
            this.panel_condition.Name = "panel_condition";
            this.panel_condition.Size = new System.Drawing.Size(237, 60);
            this.panel_condition.TabIndex = 18;
            // 
            // btn_clear_condition
            // 
            this.btn_clear_condition.Location = new System.Drawing.Point(203, 21);
            this.btn_clear_condition.Name = "btn_clear_condition";
            this.btn_clear_condition.Size = new System.Drawing.Size(26, 26);
            this.btn_clear_condition.TabIndex = 16;
            this.btn_clear_condition.Text = "X";
            this.btn_clear_condition.UseVisualStyleBackColor = true;
            this.btn_clear_condition.Click += new System.EventHandler(this.btn_clear_condition_Click);
            // 
            // panel_size
            // 
            this.panel_size.Controls.Add(this.label_size);
            this.panel_size.Controls.Add(this.tb_size);
            this.panel_size.Controls.Add(this.btn_clear_size);
            this.panel_size.Location = new System.Drawing.Point(12, 276);
            this.panel_size.Name = "panel_size";
            this.panel_size.Size = new System.Drawing.Size(237, 60);
            this.panel_size.TabIndex = 19;
            // 
            // btn_clear_size
            // 
            this.btn_clear_size.Location = new System.Drawing.Point(202, 21);
            this.btn_clear_size.Name = "btn_clear_size";
            this.btn_clear_size.Size = new System.Drawing.Size(26, 26);
            this.btn_clear_size.TabIndex = 17;
            this.btn_clear_size.Text = "X";
            this.btn_clear_size.UseVisualStyleBackColor = true;
            this.btn_clear_size.Click += new System.EventHandler(this.btn_clear_size_Click);
            // 
            // panel_color
            // 
            this.panel_color.Controls.Add(this.label_color);
            this.panel_color.Controls.Add(this.cb_color);
            this.panel_color.Controls.Add(this.btn_clear_color);
            this.panel_color.Location = new System.Drawing.Point(12, 408);
            this.panel_color.Name = "panel_color";
            this.panel_color.Size = new System.Drawing.Size(237, 60);
            this.panel_color.TabIndex = 20;
            // 
            // btn_clear_color
            // 
            this.btn_clear_color.Location = new System.Drawing.Point(203, 21);
            this.btn_clear_color.Name = "btn_clear_color";
            this.btn_clear_color.Size = new System.Drawing.Size(26, 26);
            this.btn_clear_color.TabIndex = 18;
            this.btn_clear_color.Text = "X";
            this.btn_clear_color.UseVisualStyleBackColor = true;
            this.btn_clear_color.Click += new System.EventHandler(this.btn_clear_color_Click);
            // 
            // panel_material
            // 
            this.panel_material.Controls.Add(this.label_material);
            this.panel_material.Controls.Add(this.cb_material);
            this.panel_material.Controls.Add(this.btn_clear_material);
            this.panel_material.Location = new System.Drawing.Point(12, 474);
            this.panel_material.Name = "panel_material";
            this.panel_material.Size = new System.Drawing.Size(237, 60);
            this.panel_material.TabIndex = 21;
            // 
            // btn_clear_material
            // 
            this.btn_clear_material.Location = new System.Drawing.Point(203, 21);
            this.btn_clear_material.Name = "btn_clear_material";
            this.btn_clear_material.Size = new System.Drawing.Size(26, 26);
            this.btn_clear_material.TabIndex = 19;
            this.btn_clear_material.Text = "X";
            this.btn_clear_material.UseVisualStyleBackColor = true;
            this.btn_clear_material.Click += new System.EventHandler(this.btn_clear_material_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(12, 606);
            this.btn_search.Name = "btn_search";
            this.btn_search.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.btn_search.Size = new System.Drawing.Size(237, 31);
            this.btn_search.TabIndex = 22;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // panel_check_box
            // 
            this.panel_check_box.Controls.Add(this.check_in_stock);
            this.panel_check_box.Controls.Add(this.check_rented);
            this.panel_check_box.Location = new System.Drawing.Point(12, 540);
            this.panel_check_box.Name = "panel_check_box";
            this.panel_check_box.Size = new System.Drawing.Size(237, 60);
            this.panel_check_box.TabIndex = 23;
            // 
            // check_in_stock
            // 
            this.check_in_stock.AutoSize = true;
            this.check_in_stock.Location = new System.Drawing.Point(3, 3);
            this.check_in_stock.Name = "check_in_stock";
            this.check_in_stock.Size = new System.Drawing.Size(81, 22);
            this.check_in_stock.TabIndex = 0;
            this.check_in_stock.Text = "In Stock";
            this.check_in_stock.UseVisualStyleBackColor = true;
            // 
            // check_rented
            // 
            this.check_rented.AutoSize = true;
            this.check_rented.Location = new System.Drawing.Point(90, 3);
            this.check_rented.Name = "check_rented";
            this.check_rented.Size = new System.Drawing.Size(74, 22);
            this.check_rented.TabIndex = 1;
            this.check_rented.Text = "Rented";
            this.check_rented.UseVisualStyleBackColor = true;
            // 
            // panel_size_masks
            // 
            this.panel_size_masks.Controls.Add(this.label_size_masks);
            this.panel_size_masks.Controls.Add(this.cb_size_masks);
            this.panel_size_masks.Controls.Add(this.btn_clear_size_masks);
            this.panel_size_masks.Location = new System.Drawing.Point(12, 342);
            this.panel_size_masks.Name = "panel_size_masks";
            this.panel_size_masks.Size = new System.Drawing.Size(237, 60);
            this.panel_size_masks.TabIndex = 24;
            // 
            // label_size_masks
            // 
            this.label_size_masks.AutoSize = true;
            this.label_size_masks.Location = new System.Drawing.Point(4, 0);
            this.label_size_masks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_size_masks.Name = "label_size_masks";
            this.label_size_masks.Size = new System.Drawing.Size(37, 18);
            this.label_size_masks.TabIndex = 7;
            this.label_size_masks.Text = "Size";
            // 
            // cb_size_masks
            // 
            this.cb_size_masks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_size_masks.FormattingEnabled = true;
            this.cb_size_masks.Location = new System.Drawing.Point(4, 22);
            this.cb_size_masks.Margin = new System.Windows.Forms.Padding(4);
            this.cb_size_masks.Name = "cb_size_masks";
            this.cb_size_masks.Size = new System.Drawing.Size(192, 26);
            this.cb_size_masks.TabIndex = 18;
            // 
            // btn_clear_size_masks
            // 
            this.btn_clear_size_masks.Location = new System.Drawing.Point(203, 21);
            this.btn_clear_size_masks.Name = "btn_clear_size_masks";
            this.btn_clear_size_masks.Size = new System.Drawing.Size(26, 26);
            this.btn_clear_size_masks.TabIndex = 17;
            this.btn_clear_size_masks.Text = "X";
            this.btn_clear_size_masks.UseVisualStyleBackColor = true;
            this.btn_clear_size_masks.Click += new System.EventHandler(this.btn_clear_size_pants_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 683);
            this.Controls.Add(this.panel_size_masks);
            this.Controls.Add(this.panel_check_box);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.panel_material);
            this.Controls.Add(this.panel_color);
            this.Controls.Add(this.panel_size);
            this.Controls.Add(this.panel_condition);
            this.Controls.Add(this.panel_brand);
            this.Controls.Add(this.panel_serial_number);
            this.Controls.Add(this.panel_item_type);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.panel_item_type.ResumeLayout(false);
            this.panel_item_type.PerformLayout();
            this.panel_serial_number.ResumeLayout(false);
            this.panel_serial_number.PerformLayout();
            this.panel_brand.ResumeLayout(false);
            this.panel_brand.PerformLayout();
            this.panel_condition.ResumeLayout(false);
            this.panel_condition.PerformLayout();
            this.panel_size.ResumeLayout(false);
            this.panel_size.PerformLayout();
            this.panel_color.ResumeLayout(false);
            this.panel_color.PerformLayout();
            this.panel_material.ResumeLayout(false);
            this.panel_material.PerformLayout();
            this.panel_check_box.ResumeLayout(false);
            this.panel_check_box.PerformLayout();
            this.panel_size_masks.ResumeLayout(false);
            this.panel_size_masks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_item_type;
        private System.Windows.Forms.Label label_item_type;
        private System.Windows.Forms.Label label_serial_number;
        private System.Windows.Forms.Label label_condition;
        private System.Windows.Forms.ComboBox cb_condition;
        private System.Windows.Forms.TextBox tb_serial_number;
        private System.Windows.Forms.TextBox tb_size;
        private System.Windows.Forms.Label label_size;
        private System.Windows.Forms.Label label_color;
        private System.Windows.Forms.ComboBox cb_color;
        private System.Windows.Forms.Label label_material;
        private System.Windows.Forms.ComboBox cb_material;
        private System.Windows.Forms.Label label_brand;
        private System.Windows.Forms.ComboBox cb_brand;
        private System.Windows.Forms.FlowLayoutPanel panel_serial_number;
        private System.Windows.Forms.FlowLayoutPanel panel_brand;
        private System.Windows.Forms.FlowLayoutPanel panel_condition;
        private System.Windows.Forms.FlowLayoutPanel panel_size;
        private System.Windows.Forms.FlowLayoutPanel panel_color;
        private System.Windows.Forms.FlowLayoutPanel panel_material;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.FlowLayoutPanel panel_check_box;
        private System.Windows.Forms.CheckBox check_in_stock;
        private System.Windows.Forms.CheckBox check_rented;
        public System.Windows.Forms.FlowLayoutPanel panel_item_type;
        private System.Windows.Forms.Button btn_clear_serial;
        private System.Windows.Forms.Button btn_clear_brand;
        private System.Windows.Forms.Button btn_clear_condition;
        private System.Windows.Forms.Button btn_clear_size;
        private System.Windows.Forms.Button btn_clear_color;
        private System.Windows.Forms.Button btn_clear_material;
        private System.Windows.Forms.FlowLayoutPanel panel_size_masks;
        private System.Windows.Forms.Label label_size_masks;
        private System.Windows.Forms.ComboBox cb_size_masks;
        private System.Windows.Forms.Button btn_clear_size_masks;
    }
}