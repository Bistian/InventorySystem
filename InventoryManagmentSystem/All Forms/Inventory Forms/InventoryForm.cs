﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using InventoryManagmentSystem.Rental_Forms;
using InventoryManagmentSystem.All_Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace InventoryManagmentSystem
{
    public partial class InventoryForm : BaseForm
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary> Key/Value pair list. Key = column name </summary>
        private List<string[]> filterList = new List<string[]>();
        private FilterForm filterForm;

        public InventoryForm(string ItemType)
        {
            InitializeComponent();
            checkActive.Checked = true;
            HelperSql.ItemTypeLoadComboBox(connection, cbItemType);
            string[] columns = { "column_acquisition_date", "column_manufacture_date" };
            HelperFunctions.DataGridFormatDate(dataGridInv, columns);
            HelperSql.ItemFindAllWithSpecifications(connection, dataGridInv);
            DisplayItems();
            SetItemType(ItemType);
            InitSearchContainer();
        }

        private void SetItemType(string itemType)
        {
            if (itemType == null) { return; }
            if (cbItemType.Items.Count == 0) { return; }

            int index = cbItemType.Items.IndexOf(itemType);
            if (index == -1) { return; }

            cbItemType.SelectedIndex = index;
        }

        /// <summary> Toggle visibility of rows </summary>
        private void DisplayItems()
        {
            foreach(DataGridViewRow row in dataGridInv.Rows)
            {
                string condition = row.Cells["column_condition"].Value.ToString();
                string location = row.Cells["column_location"].Value.ToString();
                string type = row.Cells["column_item_type"].Value.ToString();
                if (checkActive.Checked && (location != "Fire-Tec" || condition == "Retired"))
                {
                    row.Visible = false;
                    continue;
                }
                if (checkRetired.Checked && condition != "Retired")
                {
                    row.Visible = false;
                    continue;
                }
                if (CheckRented.Checked && location == "Fire-Tec")
                {
                    row.Visible = false;
                    continue;
                }

                if(cbItemType.Text == "")
                {
                    row.Visible = true;
                    continue;
                }

                if (type != cbItemType.Text)
                {
                    row.Visible = false;
                    continue;
                }

                bool isSearchBarMatching = SearchBarIsMatching(row);
                if (!isSearchBarMatching) 
                {
                    row.Visible = false;
                    continue; 
                }

                if(FilterUseExtra(row))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
               
            }
        }

        /// <summary> Use Exatra filters </summary>
        private bool FilterUseExtra(DataGridViewRow row)
        {
            if (filterList.Count == 0) { return true; }

            // Check if column to filter exists and if value at least partially matches.
            foreach (var filter in filterList)
            {
                string filterName = filter[0].ToLower();
                string filterValue = filter[1];
                string columnName = "";
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Get the column name of the current cell
                    string name = cell.OwningColumn.HeaderText;
                    string[] splitName = name.Split('_');
                    if(filterName == splitName[1] + splitName[2])
                    {
                        columnName = name;
                        break;
                    }
                }

                if(columnName == "")
                {
                    // Someone messed up the name of a column, type != item_type...
                    return true;
                }

                string columnValue = row.Cells[columnName].Value.ToString();
                if (columnValue == string.Empty) { continue; }

                if (!HelperFunctions.IsSubstring(columnValue, filterValue))
                {
                    return true;
                }
            }
            return false;
        }

        private void InitSearchContainer()
        {
            this.scOuter.SplitterDistance = (int)(Width * 0.3);

            int innerWidth = this.scInner.Width;
            btnToggleFilter.Text = "<";

            // Show selected items.
            var list = new List<string>() { "SerialNumber", "Condition", "Location", "Size", "Color", "Material" };
            Action<List<string[]>> callback = (filters) =>
            {
                filterList.Clear();
                filterList = filters;
                DisplayItems();
            };

            filterForm = new FilterForm(this, list, callback);
            filterForm.TopLevel = false;
            this.scInner.Panel1.Controls.Add(filterForm);
            filterForm.Dock = DockStyle.Fill;
            filterForm.Show();
            ToggleFilter();
        }

        private bool SearchBarIsMatching(DataGridViewRow row)
        {
            if(searchBar.Text.Length == 0) { return true; }
            string like = searchBar.Text;
            string serial = row.Cells["column_serial"].Value.ToString();
            string brand = row.Cells["column_brand"].Value.ToString();

            if (HelperFunctions.IsSubstring(serial, like)) { return true; }
            if (HelperFunctions.IsSubstring(brand, like)) { return true; }

            string type = row.Cells["column_item_type"].Value.ToString();
            if (type == "boots")
            {
                string size = row.Cells["column_size"].Value.ToString();
                return size == like ? true : false;
            }
            else if (type == "helmet")
            {
                string color = row.Cells["column_color"].Value.ToString();
                return color == like ? true : false;
            }
            else if (type == "jacket")
            {
                string size = row.Cells["column_size"].Value.ToString();
                return size == like ? true : false;
            }
            else if (type == "mask")
            {
                string size = row.Cells["column_size"].Value.ToString();
                return size == like ? true : false;
            }
            else if (type == "pants")
            {
                string size = row.Cells["column_size"].Value.ToString();
                return size == like ? true : false;
            }
            return false;
        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset search bar.
            searchBar.Text = "";
            ChangeVisibleColumns();
            DisplayItems();
        }

        private void ChangeVisibleColumns()
        {
            if (cbItemType.Text == "boots")
            {
                dataGridInv.Columns["column_size"].Visible = true;
                dataGridInv.Columns["column_material"].Visible = true;
                dataGridInv.Columns["column_color"].Visible = false;
            }
            else if (cbItemType.Text == "helmet")
            {
                dataGridInv.Columns["column_size"].Visible = false;
                dataGridInv.Columns["column_material"].Visible = false;
                dataGridInv.Columns["column_color"].Visible = true;
            }
            else if (cbItemType.Text == "jacket" || cbItemType.Text == "pants" || cbItemType.Text == "mask")
            {
                dataGridInv.Columns["column_size"].Visible = true;
                dataGridInv.Columns["column_material"].Visible = false;
                dataGridInv.Columns["column_color"].Visible = false;
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            if (cbItemType.SelectedIndex < 0) { return; }
            DisplayItems();
        }

        private void dataGridInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            var row = dataGridInv.Rows[e.RowIndex];
            string colName = dataGridInv.Columns[e.ColumnIndex].Name;
            string itemType = cbItemType.Text.ToLower();
            string ClientId = dataGridInv.Rows[e.RowIndex].Cells["column_location"].Value.ToString();
            string serialNumber = dataGridInv.Rows[e.RowIndex].Cells["column_serial"].Value.ToString();
            try
            {
                if (colName == "column_edit")
                {
                    if (itemType == "boots") { UpdateBoots(e); }
                    else if (itemType == "helmet") { UpdateHelmet(e); }
                    else if (itemType == "jacket" || itemType == "pants" || itemType == "mask") { UpdateJacketOrPantsOrMasks(e); }

                    dataGridInv.Rows.Clear();
                    HelperSql.ItemFindAllWithSpecifications(connection, dataGridInv);
                    searchBar.Text = dataGridInv.Rows[e.RowIndex].Cells["column_serial"].Value.ToString();
                    DisplayItems();
                }
                else if (colName == "column_delete")
                {
                    DeleteItem(serialNumber);
                    DisplayItems();
                }
                else
                {
                    if(ClientId == "Fire-Tec")
                    {
                        string itemId = row.Cells["column_item_id"].Value.ToString();
                        var form = new RentalHistoryForm(itemId, string.Empty);

                        if(form.IsDisposed) { MessageBox.Show("No history found"); }
                        else
                        {
                            var parentForm = this.ParentForm as MainForm;
                            parentForm.openChildForm(form);
                        }
                    }
                    else
                    {
                        var parentForm = this.ParentForm as MainForm;
                        NewRentalModuleForm Profile = new NewRentalModuleForm(null, "");
                        try
                        {
                            Profile.LoadProfile(ClientId, null);
                            parentForm.openChildForm(Profile);

                            this.Dispose();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Item UpdateCreateItem(DataGridViewCellEventArgs e)
        {
            var item = new Item();
            item.AddColumn("ItemType", cbItemType.Text);
            item.AddColumn("SerialNumber", GetCellValueAsString(e, "column_serial"));
            item.AddColumn("Brand", GetCellValueAsString(e, "column_brand"));
            item.AddColumn("Condition", GetCellValueAsString(e, "column_condition"));
            item.AddColumn("ManufactureDate", GetCellValueAsString(e, "column_manufacture_date"));
            item.AddColumn("AcquisitionDate", GetCellValueAsString(e, "column_acquisition_date"));
            item.AddColumn("Size", GetCellValueAsString(e, "column_size"));
            item.AddColumn("Color", GetCellValueAsString(e, "column_color"));
            item.AddColumn("Material", GetCellValueAsString(e, "column_material"));
            return item;
        }

        private void UpdateBoots(DataGridViewCellEventArgs e)
        {
            var item = UpdateCreateItem(e);
            NewItemForm itemForm = new NewItemForm(item);
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }

        private void UpdateHelmet(DataGridViewCellEventArgs e)
        {

            var item = UpdateCreateItem(e);
            NewItemForm itemForm = new NewItemForm(item);
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }

        private void UpdateJacketOrPantsOrMasks(DataGridViewCellEventArgs e)
        {
            var item = UpdateCreateItem(e);
            NewItemForm itemForm = new NewItemForm(item);
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }
        
        private void DeleteItem(string serialNumber)
        {
            string message = "Are you sure you want to delete this item?";
            string title = "Delete Record";
            if (!HelperFunctions.YesNoMessageBox(message, title)) { return; }

            string query = $"SELECT ItemId FROM tbItems WHERE SerialNumber = '{serialNumber}'";
            // TODO: Do I really want to delete?
            Guid uuid;
            
            string table = "tb" + CapitalizeFirstLetter(cbItemType.Text);

            if(cbItemType.Text == "jacket" || cbItemType.Text == "helmet" || cbItemType.Text == "mask")
            {
                table += "s";
            }
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE tbItems SET Condition = @Condition WHERE SerialNumber LIKE '{serialNumber}'", connection);
                command.Parameters.AddWithValue("@Condition", "Retired");
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Item has been successfully deleted");
            }
            catch(Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                MessageBox.Show("Failed to delete the item.");
            }
        }

        static string CapitalizeFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return char.ToUpper(str[0]) + str.Substring(1);
        }

        private string GetCellValueAsString(DataGridViewCellEventArgs e, string cellName)
        {
            return dataGridInv.Rows[e.RowIndex].Cells[cellName].Value.ToString();
        }

        private void ToggleFilter()
        {
            if (btnToggleFilter.Text == ">")
            {
                filterForm.Visible = true;
                scOuter.SplitterDistance = (int)(Width * 0.3);
                scInner.SplitterDistance = (int)(scInner.Width * 1.15);
                btnToggleFilter.Text = "<";
            }
            else
            {
                filterForm.Visible = false;
                // Calculate the desired splitter distance
                int minInnerWidth = scOuter.Panel1MinSize + scInner.Panel1MinSize + scInner.SplitterWidth;

                // Ensure the splitter distance is within the valid range
                int maxSplitterDistance = scInner.Width - scInner.Panel2MinSize;
                int minSplitterDistance = scInner.Panel1MinSize;

                // Clamp the desired splitter distance within the valid range
                int validSplitterDistance = Math.Max(minSplitterDistance, Math.Min(minInnerWidth, maxSplitterDistance));

                // Set the splitter distance
                scInner.SplitterDistance = validSplitterDistance;

                // Clamp outer no inner min
                scOuter.SplitterDistance = (int)(minInnerWidth * 1.15);
                btnToggleFilter.Text = ">";
            }
        }

        private void checkRetired_Click(object sender, EventArgs e)
        {
            if(checkRetired.Checked)
            {
                CheckRented.Checked = false;
                checkActive.Checked = false;
            }
            DisplayItems();
        }

        private void checkActive_Click(object sender, EventArgs e)
        {
            if(checkActive.Checked)
            {
                checkRetired.Checked = false;
                CheckRented.Checked = false;
            }     
            DisplayItems();
        }

        private void UsersButton_Click_1(object sender, EventArgs e)
        {
            NewItemForm ModForm = new NewItemForm();
            ModForm.ShowDialog();
            DisplayItems();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var names = new List<string> {"Active", "Inactive", "Brand", "Size","Condition"};
            var filterForm = new FilterForm(this, names, checkedItems =>
            {
                foreach(var item in checkedItems)
                {
                    filterList.Add(item);
                }
            });
            filterForm.Show();
        }

        private void btnToggleFilter_Click(object sender, EventArgs e)
        {
            ToggleFilter();
        }

        private void RentedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckRented.Checked)
            {
                checkActive.Checked = false;
                checkRetired.Checked = false;

            }
            DisplayItems();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HelperFunctions.PdfSaveDocument(WriteListToPdf);
        }

        private void WriteListToPdf(PdfDocument document)
        {
            /* Format 
                Brand: Muffin
                Serial: 123456
                Condition: Used
                Acquisition: 1934/01/01
                Manufactured: 1478/12/31
             */

            // Add a new page to the PDF
            PdfPage page = document.AddPage();
            // Get the graphics object of the PDF page
            XGraphics graphics = XGraphics.FromPdfPage(page);

            const int startY = 50;
            int positionY = startY;
            int ExtraLineSpace = 10;

            XFont fontTitle = new XFont("Arial", 16, XFontStyle.Bold);
            double maxPageHeight = page.Height.Point;
            int lineHeight = (int)fontTitle.Height;

            // Title add caps and s to de end.
            string title = char.ToUpper(cbItemType.Text[0]) + cbItemType.Text.Substring(1);
            if (!title.EndsWith("s"))
            {
                title += "s";
            }
            HelperFunctions.PdfWriteLine(graphics, fontTitle, title, positionY);
            positionY += lineHeight + ExtraLineSpace;

            string text = "";
            XFont font = new XFont("Arial", 12, XFontStyle.Regular);
            foreach (DataGridViewRow row in dataGridInv.Rows)
            {
                if (!row.Visible)
                {
                    continue;
                }
                // Check if adding the next line exceeds the page height
                if (positionY + (lineHeight * 5) > maxPageHeight)
                {
                    // Add a new page
                    page = document.AddPage();
                    graphics = XGraphics.FromPdfPage(page);
                    positionY = startY;

                    HelperFunctions.PdfWriteLine(graphics, fontTitle, title, positionY);
                    positionY += lineHeight + ExtraLineSpace;
                }

                text = $"Brand: {row.Cells["column_brand"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"Serial: {row.Cells["column_serial"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"Condition: {row.Cells["column_condition"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"Acquisition Date: {row.Cells["column_acquisition_date"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight + ExtraLineSpace;

                text = $"Manufacure Date: {row.Cells["column_manufacture_date"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight + ExtraLineSpace;
            }
        }
    }
}