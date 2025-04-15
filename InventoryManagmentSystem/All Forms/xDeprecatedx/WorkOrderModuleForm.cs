using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;

namespace InventoryManagmentSystem
{
    public partial class WorkOrderModuleForm : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="currClient">Client Name</param>
        /// <param name="DayNight">Period</param>
        /// <param name="RentalOption">Rental Selection</param>
        public WorkOrderModuleForm(string currClient, string DayNight, string RentalOption)
        {
            InitializeComponent();

            LableClientName.Text = currClient;
            lableRentalOption.Text = RentalOption;

            if (RentalOption == "Full Set")
            {
                if (DayNight == "Day")
                {
                    labelAmount.Text = "$708";
                }
                else if (DayNight == "Night")
                {
                    labelAmount.Text = "$801";
                }

                Item1.Text = "Helmet";
                Item2.Text = "Jacket";
                Item3.Text = "Pants";
                Item4.Text = "Boots";
            }
            else if (RentalOption == "Set Helmet Only")
            {
                if (DayNight == "Day")
                {
                    labelAmount.Text = "$595";
                }
                else if (DayNight == "Night")
                {
                    labelAmount.Text = "$687";
                }

                Item1.Text = "Helmet";
                Item2.Text = "Jacket";
                Item3.Text = "Pants";
                Item4.Visible = false;
            }
            else if (RentalOption == "Set Boots Only")
            {
                if (DayNight == "Day")
                {
                    labelAmount.Text = "$636";
                }
                else if (DayNight == "Night")
                {
                    labelAmount.Text = "$729";
                }

                Item1.Text = "Jacket";
                Item2.Text = "Pants";
                Item3.Text = "Boots";
                Item4.Visible = false;
            }
            else if (RentalOption == "Pants & Jacket")
            {
                if (DayNight == "Day")
                {
                    labelAmount.Text = "$518";
                }
                else if (DayNight == "Night")
                {
                    labelAmount.Text = "$610";
                }

                Item1.Text = "Jacket";
                Item2.Text = "Pants";
                Item3.Visible = false;
                Item4.Visible = false;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /*// Show the print dialog
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() != DialogResult.OK)
                return;

            // Create a PrintDocument and set its properties
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = "My Form";
            printDocument.PrinterSettings = printDialog.PrinterSettings;
            printDocument.DefaultPageSettings.Landscape = true; // Example page setting
            printDocument.PrintPage += PrintPage;

            // Print the document
            printDocument.Print();*/

            /*    // Create a new PrintDocument object
                PrintDocument pd = new PrintDocument();

                // Set the PrintPage event handler
                pd.PrintPage += new PrintPageEventHandler(this.PrintPage);

                // Show the print dialog and start the print job
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    pd.PrinterSettings = printDialog1.PrinterSettings;
                    pd.Print();
                }*/

            /* PrintDialog printDialog1 = new PrintDialog();
             printDialog1.Document = printDocument1;

             if (printDialog1.ShowDialog() == DialogResult.OK)
             {
                 printDocument1.Print();
             }*/

            // Show the save file dialog box
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Create a new PDF document
                PdfDocument document = new PdfDocument();

                // Add a new page to the PDF
                PdfPage page = document.AddPage();

                // Get the graphics object of the PDF page
                XGraphics graphics = XGraphics.FromPdfPage(page);

                // Vertical position of each line.
                int yPosition = 50;
                string font = "Arial";

                // =========== Add Title ===========

                // Format title
                XFont fontTitle = new XFont(font, 18, XFontStyleEx.Bold);
                XStringFormat formatLabel = new XStringFormat();
                formatLabel.Alignment = XStringAlignment.Near;

                graphics.DrawString(
                    labelFormTitle.Text,
                    fontTitle,
                    XBrushes.Black,
                    new XRect(50, yPosition, 100, fontTitle.Height), formatLabel);

                yPosition += (int)fontTitle.Height + 10;

                // =========== Add Fields ===========
                XFont clientLabel = new XFont(font, 16, XFontStyleEx.Bold);
                XFont fontLabel = new XFont(font, 12, XFontStyleEx.Bold);

                graphics.DrawString(
                        LableClientName.Text,
                        fontLabel,
                        XBrushes.Black,
                        new XRect(50, yPosition, 100, clientLabel.Height), formatLabel);
                yPosition += (int)fontLabel.Height + 10;

                string rented = "";
                if (Item1.Text != "Item1")
                {
                    rented += Item1.Text + "  ";
                }
                if (Item2.Text != "Item2")
                {
                    rented += Item2.Text + "  ";
                }
                if (Item3.Text != "Item3")
                {
                    rented += Item3.Text + "  ";
                }
                if (Item4.Text != "Item4")
                {
                    rented += Item4.Text + "  ";
                }

                graphics.DrawString(
                        rented,
                        fontLabel,
                        XBrushes.Black,
                        new XRect(50, yPosition, 100, fontLabel.Height), formatLabel);
                yPosition += (int)fontLabel.Height + 10;

                graphics.DrawString(
                    "Price = " + labelAmount.Text,
                    fontLabel,
                    XBrushes.Black,
                    new XRect(50, yPosition, 100, fontLabel.Height), formatLabel);

                document.Save(saveFileDialog.FileName);
                document.Close();
            }
        }
    }
}