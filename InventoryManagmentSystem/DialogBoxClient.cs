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
    public partial class DialogBoxClient : Form
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

        private string client = "";
        public DialogBoxClient(string client)
        {
            InitializeComponent();
            this.client = client;
        }

        private string QueryItems()
        {
            //return ("SELECT Type, DueDate, SerialNumber FROM tbBoots WHERE Location='Client1'");
            return ("SELECT Type, DueDate, SerialNumber FROM tbPants " +
                "WHERE Location='" + client + "' " +
                "UNION SELECT Type, DueDate, SerialNumber FROM tbBoots " +
                "WHERE Location='" + client + "' " +
                "UNION SELECT Type, DueDate, SerialNumber FROM tbHelmets " +
                "WHERE Location='" + client + "' " +
                "UNION SELECT Type, DueDate, SerialNumber FROM tbJackets " +
                "WHERE Location='" + client + "' " +
                "ORDER BY DueDate");
        }

        private string QueryClient()
        {
            return ("SELECT phone, email FROM tbClients WHERE Name='" + client + "'");
        }

        private void DialogBoxClient_Load(object sender, EventArgs e)
        {
            SetLabels();
            SetTable();
        }

        private void SetLabels()
        {
            dataGridView1.Rows.Clear();
            cm = new SqlCommand(QueryClient(), con);
            con.Open();
            dr = cm.ExecuteReader();

            while(dr.Read())
            {
                textClient.Text = client;
                textPhone.Text = dr[0].ToString();
                textEmail.Text = dr[1].ToString();
            }

            dr.Close();
            con.Close();
        }

        private void SetTable()
        {
            // Change the styling for the date column.
            dataGridView1.Columns["DueDate"].DefaultCellStyle.Format = "d";

            dataGridView1.Rows.Clear();
            cm = new SqlCommand(QueryItems(), con);
            con.Open();
            dr = cm.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                ++i;
                dataGridView1.Rows.Add(i,
                    dr[0].ToString(),
                    dr[1],
                    dr[2].ToString()
                );
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
