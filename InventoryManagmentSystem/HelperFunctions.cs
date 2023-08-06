using System.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public class HelperFunctions
    {

        /// <summary>
        /// Add item types from database to a combobox.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="comboBox"></param>
        public static void LoadItemTypes(SqlConnection connection, ref ComboBox comboBox)
        {
            string query = HelperQuery.ItemTypeLoad();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox.Items.Add(reader[0]);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
            connection.Close();
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
