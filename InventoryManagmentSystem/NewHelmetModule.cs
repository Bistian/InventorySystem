using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagmentSystem
{
    public partial class NewHelmetModule : Form
    {
        #region SQL_Variables
        //Database Path
        static string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database\\dbMS.mdf;");
        //Creating command
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + dbPath + " Integrated Security=True;Connect Timeout=30");
        //Creating command
        SqlCommand cm = new SqlCommand();
        bool isNewItem;
        #endregion SQL_Variables

        public NewHelmetModule()
        {
            InitializeComponent();
        }

        private void CloseUserModuel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this department?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //cm = new SqlCommand("INSERT INTO tbHelmets(DeptName,ContactName,Phone,Email,Address,City,State,Zip)VALUES(@DeptName,@ContactName,@Phone,@Email,@Address,@City,@State,@Zip)", con);
                    //cm.Parameters.AddWithValue("@DeptName", DeptNameTxtBox.Text);
                    //cm.Parameters.AddWithValue("@ContactName", DeptContactTxtBox.Text);
                    //cm.Parameters.AddWithValue("@Phone", DeptPhoneTxtBox.Text);
                    //cm.Parameters.AddWithValue("@Email", DeptEmailTxtBox.Text);
                    //cm.Parameters.AddWithValue("@Address", DeptAddressTxtBox.Text);
                    //cm.Parameters.AddWithValue("@City", DeptCityTxtBox.Text);
                    //cm.Parameters.AddWithValue("@State", DeptStateTxtBox.Text);
                    //cm.Parameters.AddWithValue("@Zip", DeptZipTxtBox.Text);
                    //con.Open();
                    //cm.ExecuteNonQuery();
                    //con.Close();
                    //MessageBox.Show("Department has been successfully saved");
                    //Clear();
                    //this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
