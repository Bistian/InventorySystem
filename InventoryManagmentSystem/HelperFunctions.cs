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

        public static void RemoveLineBreaksFromString(ref string str)
        {
            str = str.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
        }

    }
}
