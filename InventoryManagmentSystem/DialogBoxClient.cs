using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class DialogBoxClient : Form
    {

        #region SQL_Variables
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection con = new SqlConnection(connectionString);
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;
        #endregion SQL_Variables

        private string client = "";
        public DialogBoxClient(string client)
        {
            InitializeComponent();
            this.client = client;
        }

        private string QueryClient()
        {
            return ("SELECT Phone, Email, Academy, DayNight FROM tbClients WHERE Name='" + client + "'");
        }

        private void DialogBoxClient_Load(object sender, EventArgs e)
        {
            SetLabels();
        }

        private void SetLabels()
        {
            cm = new SqlCommand(QueryClient(), con);
            con.Open();
            dr = cm.ExecuteReader();

            while(dr.Read())
            {
                textClient.Text = client;
                textPhone.Text = dr[0].ToString();
                textEmail.Text = dr[1].ToString();
                textAcademy.Text = dr[2].ToString();
                textDayNight.Text = dr[3].ToString();
            }

            dr.Close();
            con.Close();
        }

        private void CloseUserModuel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
