using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class HomeForm : Form
    {
        #region SQL_Variables
        //Database Path
        static string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database\\dbMS.mdf;");
        //Creating command
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + dbPath + " Integrated Security=True;Connect Timeout=30");
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;
        #endregion SQL_Variables

        public HomeForm()
        {
            InitializeComponent();
            LoadRented();
        }

        private string QueryInventory()
        {
            return "SELECT Type, Location, DueDate, SerialNumber FROM tbPants WHERE DueDate IS NOT NULL JOIN tbBoots WHERE DueDate IS NOT NULL JOIN tbHelmets WHERE DueDate IS NOT NULL JOIN tbJackets WHERE DueDate IS NOT NULL";
        }

        public void LoadRented()
        {
            string sql = "SELECT Type, Location, DueDate, SerialNumber FROM tbBoots WHERE DueDate IS NOT NULL";
            //sql = "SELECT Type, Location, DueDate, SerialNumber FROM tbBoots";
            int i = 0;
            dataGridRented.Rows.Clear();
            cm = new SqlCommand(sql, con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                ++i;
                dataGridRented.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }

            dr.Close();
            con.Close();
        }

        public void LoadPastDue()
        {

        }
    }
}
