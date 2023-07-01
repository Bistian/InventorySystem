using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public class HelperFunctions
    {
        public static bool YesNoMessageBox(string message, string title)
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return false; }

            return true;
        }

        public static string RemoveLineBreaksFromString(string str)
        {
            return str.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
        }

    }

    public class SqlVariables
    {
        public string query;
        public SqlCommand command;
        public SqlConnection connection;
        public SqlVariables()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
    }

    /*public class SqlHelper
    {
       
    }*/
}
