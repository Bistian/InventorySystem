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
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sebas\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dataGridUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUser", con);
            con.Open();
            dr = cm.ExecuteReader();

            while(dr.Read())
            {
                i++;
                dataGridUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            UserModuleForm userModuel = new UserModuleForm();
            userModuel.SaveButton.Enabled = true;
            userModuel.UpdateButton.Enabled = false;
            userModuel.ShowDialog();
            LoadUser();
        }

        private void dataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dataGridUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.UserNameTxt.Text = dataGridUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.PasswordTxt.Text = dataGridUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.NameTxtBox.Text = dataGridUser.Rows[e.RowIndex].Cells[3].Value.ToString();

                userModule.SaveButton.Enabled = false;
                userModule.UpdateButton.Enabled = true;
                userModule.UserNameTxt.Enabled = false;
                userModule.ShowDialog();
            }
            else if(colName == "Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dataGridUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully deleted");
                }
            }
            LoadUser();

        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            UserModuleForm ModForm = new UserModuleForm();
            ModForm.SaveButton.Enabled = true;
            ModForm.UpdateButton.Enabled = false;
            ModForm.ShowDialog();
            LoadUser();
        }
    }
}