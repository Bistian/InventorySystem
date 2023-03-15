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
    public partial class Login : Form
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

        //Initialize
        public Login()
        {
            InitializeComponent();
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked == false)
            {
                PasswordTxt.UseSystemPasswordChar = true;
            }
            else
            {
                PasswordTxt.UseSystemPasswordChar = false;
            }
        }

        private void ClearLable_Click(object sender, EventArgs e)
        {
            UserNameTxt.Clear();
            PasswordTxt.Clear();
        }

        private void MyLogo_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM tbUser WHERE username = @username AND password = @password", con);
                cm.Parameters.AddWithValue("@username", UserNameTxt.Text);
                cm.Parameters.AddWithValue("@password", PasswordTxt.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    //MessageBox.Show("Welcome " + dr["fullname"].ToString(), "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm main = new MainForm();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password :(", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Dispose();
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }
    }
}
