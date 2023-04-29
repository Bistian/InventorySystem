using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

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

            if(RentalOption == "Full Set")
            {
                if(DayNight == "Day")
                {
                    labelamount.Text = "$708";
                }
                else if (DayNight == "Night")
                {
                    labelamount.Text = "$801";
                }

                Item1.Text = "Helmet";
                Item2.Text = "Jacket";
                Item3.Text = "Pants";
                Item4.Text = "Boots";
            }
            else if(RentalOption == "Set Helmet Only")
            {
                if (DayNight == "Day")
                {
                    labelamount.Text = "$595";
                }
                else if (DayNight == "Night")
                {
                    labelamount.Text = "$687";
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
                    labelamount.Text = "$636";
                }
                else if (DayNight == "Night")
                {
                    labelamount.Text = "$729";
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
                    labelamount.Text = "$518";
                }
                else if (DayNight == "Night")
                {
                    labelamount.Text = "$610";
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

            // Create a new PDF document
            PdfDocument pdfDocument = new PdfDocument();

            // Add a new page to the PDF
            PdfPage pdfPage = pdfDocument.AddPage();

            // Get the graphics object of the PDF page
            XGraphics graphics = XGraphics.FromPdfPage(pdfPage);

            // Save the PDF to a file
            pdfDocument.Save("Form.pdf");
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if(this.BackgroundImage != null)
                {
                   /* // Draw the contents of the form onto the PrintPageEventArgs
                    this.DrawToBitmap(new Bitmap(this.Width, this.Height), new Rectangle(Point.Empty, this.Size));
                    e.Graphics.DrawImageUnscaled(this.BackgroundImage, this.Location);  */
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
