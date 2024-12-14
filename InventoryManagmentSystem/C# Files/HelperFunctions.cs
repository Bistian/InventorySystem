using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace InventoryManagmentSystem
{
    public class HelperFunctions
    {
        /// <summary>
        /// Check if substring exists within target string.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="substring"></param>
        /// <returns>true if substring exists.</returns>
        public static bool IsSubstring(string target, string substring)
        {
            return target.ToLower().IndexOf(substring.ToLower()) != -1;
        }

        public static void DataGridFormatDate(DataGridView grid, string[] columns)
        {
            foreach(string col in columns)
            {
                grid.Columns[col].ValueType = typeof(DateTime);
            }

            grid.CellFormatting += (sender, e) =>
            {
                // Check if the cell value is of type DateTime
                if (grid.Columns[e.ColumnIndex].ValueType == typeof(DateTime))
                {
                    // Check if the cell value can be converted to a DateTime
                    if (e.Value != null && e.Value != DBNull.Value && DateTime.TryParse(e.Value.ToString(), out DateTime dateValue))
                    {
                        e.Value = dateValue.ToString("MM/dd/yyyy");
                        e.FormattingApplied = true;
                    }
                }
            };
        }

        public static void DataGridHideTime(DataGridView grid, string columnName)
        {
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (DateTime.TryParse(row.Cells[columnName].Value.ToString(), out DateTime dateValue))
                    {
                        row.Cells[columnName].Value = dateValue;
                    }
                }
                grid.Columns[columnName].DefaultCellStyle.Format = "d";
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static string DateCrop(string date, string format = null)
        {
            var d = DateTime.Parse(date);
            string Y = d.Year.ToString();
            string M = d.Month.ToString();
            string D = d.Day.ToString();
            if(format == "YYYY/MM/DD")
            {
                return $"{Y}/{M}/{D}";
            }
            if (format == "YYYY-MM-DD")
            {
                return $"{Y}-{M}-{D}";
            }
            if (format == "DD/MM/YYYY")
            {
                return $"{D}/{M}/{Y}";
            }
            if (format == "DD-MM-YYYY")
            {
                return $"{D}-{M}-{Y}";
            }
            if (format == "MM-DD-YYYY")
            {
                return $"{M}-{D}-{Y}";
            }
            return $"{M}/{D}/{Y}";
        }

        public static string MakeTableFromItemType(string itemType)
        {
            if(itemType.ToLower() == "pants" || itemType.ToLower() == "boots")
            {
                return $"tb{char.ToUpper(itemType[0]) + itemType.Substring(1)}";
            }
            return $"tb{char.ToUpper(itemType[0]) + itemType.Substring(1)}s";
        }

        public static void OpenChildForm(Form childForm, ref Panel panel)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public static void OpenChildFormToPanel(Panel panel, Form childForm, Form activeForm = null)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Performs the saving process of a pdf document.
        /// </summary>
        /// <param name="action">Function that makes the design of the save.</param>
        public static void PdfSaveDocument(Action<PdfDocument> action)
        {
            // Show the save file dialog box
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            action.Invoke(document);

            string filePath = saveFileDialog.FileName;
            document.Save(filePath);
            document.Close();
        }

        /// <summary>
        /// Whrite a line to a pdf document.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="font"></param>
        /// <param name="text">What is written on the line.</param>
        /// <param name="positionY">Where the line will be placed on the document.</param>
        public static void PdfWriteLine(XGraphics graphics, XFont font, string text, int positionY)
        {
            XStringFormat formatLabel = new XStringFormat();
            formatLabel.Alignment = XStringAlignment.Near;
            XRect position = new XRect(50, positionY, 100, font.Height);
            graphics.DrawString(text, font, XBrushes.Black, position, formatLabel);
        }

        /// <summary>
        /// This is needed to properly format a multiline string to be suitable for query --> @"Select...From..."
        /// </summary>
        /// <param name="str"></param>
        public static void RemoveLineBreaksFromString(ref string str)
        {
            str = str.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
        }

        /// <summary>
        /// Shortcut for making pop up messages for yes or no question.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool YesNoMessageBox(string message, string title)
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return false; }

            return true;
        }
    }
}
