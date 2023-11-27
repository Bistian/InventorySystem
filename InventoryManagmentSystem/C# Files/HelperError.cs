using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem.C__Files
{
    internal class HelperError
    {
        public static void HandleDataGridView(DataGridView grid)
        {
            grid.DataError += DataGridView_DataError;
        }

        private static void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine($"DataError at row {e.RowIndex}, column {e.ColumnIndex}: {e.Exception.Message}");
            // Prevent the default error dialog
            e.ThrowException = false;
        }
    }
}
