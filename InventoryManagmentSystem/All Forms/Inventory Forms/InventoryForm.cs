using System;
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
        private SearchForm searchForm;
        public string ItemTypeGlobal;

        public InventoryForm()
        {
            InitializeComponent();
            string[] columns = { "column_acquisition_date", "column_manufacture_date" };
            HelperFunctions.DataGridFormatDate(dataGridInv, columns);
            InitSearchContainer();
        }
      
        private void InitSearchContainer()
        {
            // Show selected items.
            var list = new List<string>() { "SerialNumber", "Condition", "Location", "Size", "Color", "Material" };
            Action<List<string[]>> callback = (filters) =>
            {
                filterList.Clear();
                filterList = filters;
            };

            searchForm = new SearchForm(dataGridInv, this);
            searchForm.TopLevel = false;
            scOuter.Panel1.Controls.Add(searchForm);
            searchForm.Dock = DockStyle.Fill;
            searchForm.AutoScroll = true;
            searchForm.Show();
            searchForm.Visible = false;
            ToggleFilter();
        }

        private void dataGridInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            var row = dataGridInv.Rows[e.RowIndex];
            string colName = dataGridInv.Columns[e.ColumnIndex].Name;
            string ClientId = dataGridInv.Rows[e.RowIndex].Cells["column_location"].Value.ToString();
            string serialNumber = dataGridInv.Rows[e.RowIndex].Cells["column_serial"].Value.ToString();
            string itemId = dataGridInv.Rows[e.RowIndex].Cells["column_item_id"].Value.ToString();
            try
            {
               string ItemType = dataGridInv.Rows[e.RowIndex].Cells["column_item_type"].Value.ToString();
                if (colName == "column_edit")
                {
                    if (ItemType == "boots") { UpdateBoots(e); }
                    else if (ItemType == "helmet") { UpdateHelmet(e); }
                    else if (ItemType == "jacket" || ItemType == "pants" || ItemType == "mask") { UpdateJacketOrPantsOrMasks(e); }
                    //Refresh Data Grid
                    searchForm.btn_search_Click(sender, e);
                }
                else if (colName == "column_delete")
                {
                   // DeleteItem(itemId);
                }
                else
                {
                    if(ClientId == "Fire-Tec")
                    {
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
            string ItemType = dataGridInv.Rows[e.RowIndex].Cells["column_item_type"].Value.ToString();
            var item = new Item();
            item.AddColumn("ItemType", ItemType);
            item.AddColumn("Id", GetCellValueAsString(e, "column_item_id"));
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
        
        private void DeleteItem(string itemId)
        {
            //Deleting from item specific tables
            string message = "Are you sure you want to delete this item?";
            string title = "Delete Record";
            if (!HelperFunctions.YesNoMessageBox(message, title)) { return; }

            bool isDeleted = HelperSql.ItemDelete(connection, itemId);

            if (isDeleted)
            {
                message = "Item deleted succesfully";
                MessageBox.Show(message, "Deleted", MessageBoxButtons.OK);
                dataGridInv.Rows.Clear();
            }
            else
            {
                message = "Failed to delete item";
                MessageBox.Show(message, "Fail", MessageBoxButtons.OK);
            }
        }

        private string GetCellValueAsString(DataGridViewCellEventArgs e, string cellName)
        {
            return dataGridInv.Rows[e.RowIndex].Cells[cellName].Value.ToString();
        }

        private void ToggleFilter()
        {
            if (btn_filters.Text == "Open Filters")
            {
                searchForm.Visible = true;
                scOuter.Panel1.Visible = true;
                scOuter.SplitterDistance = searchForm.panel_item_type.Width;
                btn_filters.Text = "Close Filters";
            }
            else
            {
                searchForm.Visible = false;
                scOuter.Panel1.Visible = false;
                // Calculate the desired splitter distance
                int minInnerWidth = scOuter.Panel1MinSize + scOuter.Panel1.Width + scOuter.Panel1.Width;

                // Ensure the splitter distance is within the valid range
                int maxSplitterDistance = scOuter.Panel1.Width - scOuter.Panel1.Width;
                int minSplitterDistance = scOuter.Panel1.Width;

                // Clamp the desired splitter distance within the valid range
                int validSplitterDistance = Math.Max(minSplitterDistance, Math.Min(minInnerWidth, maxSplitterDistance));

                // Set the splitter distance
                scOuter.SplitterDistance = validSplitterDistance;

                // Clamp outer no inner min
                scOuter.SplitterDistance = 0;
                btn_filters.Text = "Open Filters";
            }
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
            if (ItemTypeGlobal == null)
            {
                string message = "Nothing Selected";
                string header = "Failed Save";
                MessageBox.Show(message, header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string title = char.ToUpper(ItemTypeGlobal[0]) + ItemTypeGlobal.Substring(1);
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

        private void Btn_Users_Click(object sender, EventArgs e)
        {
            NewItemForm ModForm = new NewItemForm();
            ModForm.ShowDialog();
        }

        private void Btn_ToggleFilter_Click(object sender, EventArgs e)
        {
            ToggleFilter();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            HelperFunctions.PdfSaveDocument(WriteListToPdf);
        }

        private void Btn_Filter_Click(object sender, EventArgs e)
        {
            ToggleFilter();
        }
    }
}