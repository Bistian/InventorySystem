﻿using System;
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
    public partial class BrandForm : Form
    {
        #region SQL_Variables
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        SqlDataReader dataReader;
        #endregion SQL_Variables

        public bool close = false;

        public BrandForm()
        {
            InitializeComponent();
            LoadItemTypes();
            LoadTable();
            
#if DEBUG
            btnFiretecBrands.Enabled = true;
            btnFiretecBrands.Visible = true;
#endif
        }

        private void LoadItemTypes()
        {
            string query = "SELECT ItemType FROM tbItemTypes";
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    cbItemType.Items.Add(dataReader[0].ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cbItemType.SelectedIndex < 0) { return; }
            if(tbBrands.Text.Length == 0 ) { return; }
            if(ItemAddedExists()) 
            {
                string message = "Entry already exists.";
                HelperFunctions.YesNoMessageBox(message, "Confirmation");
                return; 
            }

            string query = "INSERT INTO tbBrands (ItemType, Brand) VALUES (@ItemType, @Brand)";

            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", cbItemType.Text);
                command.Parameters.AddWithValue("@Brand", tbBrands.Text);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            LoadTable();
            tbBrands.Text = "";
            if(close) { this.Close(); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 2) { return; }

            string message = "Do you want to delete this brand?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return; }

            string query = "DELETE FROM tbBrands WHERE ItemType=@ItemType AND Brand=@Brand";
            string provider = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", cbItemType.Text);
                command.Parameters.AddWithValue("@Brand", provider);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            LoadTable();
        }

        /// <summary>
        /// Check if item already exists within the table.
        /// </summary>
        /// <returns>true if it does exists.</returns>
        private bool ItemAddedExists()
        {
            bool found = false;
            string query = "SELECT * FROM tbBrands WHERE ItemType=@ItemType AND Brand=@Brand";
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", cbItemType.Text);
                command.Parameters.AddWithValue("@Brand", tbBrands.Text);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) { found = true; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();

            return found;
        }

        private void LoadTable()
        {
            dataGridView1.Rows.Clear();
            if(cbItemType.SelectedIndex < 0) { return; }

            int i = 0;
            string query = "SELECT * FROM tbBrands WHERE ItemType = '" + cbItemType.Text + "'";
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dataGridView1.Rows.Add(i++,
                        dataReader[1].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void AddFiretecBrands1()
        {
            List<string> bootList = new List<string>();
            bootList.Add("Croydon");
            bootList.Add("Saber");
            bootList.Add("Black Diamond");
            bootList.Add("Stc");

            List<string> helmetList = new List<string>();
            helmetList.Add("Cairns");
            helmetList.Add("Bullard");

            List<string> pantsList = new List<string>();
            pantsList.Add("Lakeland");
            pantsList.Add("Innotex");
            pantsList.Add("Viking");
            pantsList.Add("Morning Pride");
            pantsList.Add("Globe");
            pantsList.Add("FireDex");
            pantsList.Add("Honeywell");
            pantsList.Add("Skold");
            pantsList.Add("Frypel");
            pantsList.Add("Quaker");
            pantsList.Add("Janesville");
            pantsList.Add("Lion");
            pantsList.Add("Sperian");
            pantsList.Add("Veridian");

            List<string> academiesList = new List<string>();
            academiesList.Add("BFA");
            academiesList.Add("Ocala");
            academiesList.Add("Coral Springs");
            academiesList.Add("Pasco Hernando");
            academiesList.Add("Palm Beach");
            academiesList.Add("Miami Dade");
            academiesList.Add("Eastern");
            academiesList.Add("Monroe");
            academiesList.Add("Braxton");
            academiesList.Add("Barry");
            academiesList.Add("Citrus");
            academiesList.Add("SunCoast");
            academiesList.Add("Daytona");
            academiesList.Add("Ridge");
            academiesList.Add("Gateway");
            academiesList.Add("Aparicio Levy");
            academiesList.Add("Aparicio Levy");
            academiesList.Add("Resolve Maritime");
            academiesList.Add("S FL State (Avon Park)");
            academiesList.Add("Northwest");

            foreach (string item in bootList)
            {
                AddFiretecBrands2("boots", item);
            }

            foreach (string item in helmetList)
            {
                AddFiretecBrands2("helmets", item);
            }

            foreach (string item in pantsList)
            {
                AddFiretecBrands2("jackets/pants", item);
            }

            foreach (string item in academiesList)
            {
                AddFiretecBrands2("academies", item);
            }

            LoadTable();
        }

        private void AddFiretecBrands2(string itemType, string brand)
        {
            string query = "INSERT INTO tbBrands (ItemType, Brand) VALUES (@ItemType, @Brand)";

            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", itemType);
                command.Parameters.AddWithValue("@Brand", brand);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void btnFiretecBrands_Click(object sender, EventArgs e)
        {
            AddFiretecBrands1();
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
        }
    }
}
