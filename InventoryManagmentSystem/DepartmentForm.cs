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
using System.Reflection;
using System.Configuration;

namespace InventoryManagmentSystem
{
    public partial class DepartmentForm : Form
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

        //Initialize
        public DepartmentForm()
        {

            InitializeComponent();
            LoadDepartment();
        }

        public void LoadDepartment()
        {
            int i = 0;
            dataGridDept.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbDepartment", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridDept.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            DeptModuleForm ModForm = new DeptModuleForm(true);
            ModForm.SaveButton.Enabled = true;
            ModForm.ShowDialog();
            LoadDepartment();
        }

        //Search Bar
        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadDepartment(); }

            //SQL
            int i = 0;
            dataGridDept.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbDepartment WHERE DeptName LIKE '%" + searchTerm + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridDept.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
            }

            dr.Close();
            con.Close();
        }

        private void dataGridDept_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dataGridDept.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                DeptModuleForm DepartmentModule = new DeptModuleForm();
                DepartmentModule.DeptNameTxtBox.Text = dataGridDept.Rows[e.RowIndex].Cells[2].Value.ToString();
                DepartmentModule.DeptContactTxtBox.Text = dataGridDept.Rows[e.RowIndex].Cells[3].Value.ToString();
                DepartmentModule.DeptPhoneTxtBox.Text = dataGridDept.Rows[e.RowIndex].Cells[4].Value.ToString();
                DepartmentModule.DeptEmailTxtBox.Text = dataGridDept.Rows[e.RowIndex].Cells[5].Value.ToString();
                DepartmentModule.DeptAddressTxtBox.Text = dataGridDept.Rows[e.RowIndex].Cells[6].Value.ToString();
                DepartmentModule.DeptCityTxtBox.Text = dataGridDept.Rows[e.RowIndex].Cells[7].Value.ToString();
                DepartmentModule.DeptStateTxtBox.Text = dataGridDept.Rows[e.RowIndex].Cells[8].Value.ToString();
                DepartmentModule.DeptZipTxtBox.Text = dataGridDept.Rows[e.RowIndex].Cells[9].Value.ToString();

                DepartmentModule.SaveButton.Enabled = true;
                DepartmentModule.DeptNameTxtBox.Enabled = false;
                DepartmentModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Department?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbDepartment WHERE DeptID LIKE '" + dataGridDept.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Department has been successfully deleted");
                }
            }
            LoadDepartment();
        }
    }
}
