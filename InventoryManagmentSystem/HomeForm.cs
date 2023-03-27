using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

        //Makes date red if it is less than this number.
        int daysForWarning = 14;

        public HomeForm()
        {
            InitializeComponent();
            LoadRented();
            LoadPostDue();
        }

        private string QueryRented()
        {
            return ("SELECT Type, Location, DueDate, SerialNumber FROM tbPants " +
                "WHERE DueDate IS NOT NULL AND DueDate >= CONVERT(DATE, GETDATE()) " +
                "UNION SELECT Type, Location, DueDate, SerialNumber FROM tbBoots " +
                "WHERE DueDate IS NOT NULL AND DueDate >= CONVERT(DATE, GETDATE()) " +
                "UNION SELECT Type, Location, DueDate, SerialNumber FROM tbHelmets " +
                "WHERE DueDate IS NOT NULL AND DueDate >= CONVERT(DATE, GETDATE()) " +
                "UNION SELECT Type, Location, DueDate, SerialNumber FROM tbJackets " +
                "WHERE DueDate IS NOT NULL AND DueDate >= CONVERT(DATE, GETDATE()) " +
                "ORDER BY DueDate");
        }

        private string QueryPostDue()
        {
            return ("SELECT Type, Location, DueDate, SerialNumber FROM tbPants " +
                "WHERE DueDate IS NOT NULL AND DueDate < CONVERT(DATE, GETDATE()) " +
                "UNION SELECT Type, Location, DueDate, SerialNumber FROM tbBoots " +
                "WHERE DueDate IS NOT NULL AND DueDate < CONVERT(DATE, GETDATE()) " +
                "UNION SELECT Type, Location, DueDate, SerialNumber FROM tbHelmets " +
                "WHERE DueDate IS NOT NULL AND DueDate < CONVERT(DATE, GETDATE()) " +
                "UNION SELECT Type, Location, DueDate, SerialNumber FROM tbJackets " +
                "WHERE DueDate IS NOT NULL AND DueDate < CONVERT(DATE, GETDATE()) " +
                "ORDER BY DueDate");
        }

        public void LoadRented()
        {
            dataGridRented.Rows.Clear();
            cm = new SqlCommand(QueryRented(), con);
            con.Open();
            dr = cm.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                /*string s = DateTime.ParseExact(
                    dr[3].ToString(), 
                    "yyyy-MM-dd", 
                    CultureInfo.InvariantCulture).ToString();*/
                ++i;
                dataGridRented.Rows.Add(i,
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].ToString(),
                    dr[3].ToString()
                );
            }

            dr.Close();
            con.Close();
        }

        public void LoadPostDue()
        {
            dataGridPostDue.Rows.Clear();
            cm = new SqlCommand(QueryPostDue(), con);
            con.Open();
            dr = cm.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                ++i;
                dataGridPostDue.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }

            dr.Close();
            con.Close();
        }

        private void dataGridRented_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Is this the Due Date column?
            if (e.ColumnIndex != 3) { return; }

            //Check if the date is getting close.
            DateTime date = DateTime.Parse(e.Value.ToString());
            if ((date - DateTime.Now).TotalDays > daysForWarning) { return; }

            //Change cell color.
            e.CellStyle.ForeColor = Color.Red;
        }
    }
}
