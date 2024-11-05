using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem.All_Forms
{
    public partial class SearchForm : BaseForm
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        DataGridView grid;
        public SearchForm(DataGridView grid)
        {
            InitializeComponent();
            HelperSql.ItemTypeLoadComboBox(connection, cb_item_type);
            string[] conditions = { "New", "Used", "Retired" };
            cb_condition.Items.AddRange(conditions);
            this.grid = grid;
        }

        private void ChangeVisibleColumns()
        {
            if (cb_item_type.Text == "boots")
            {
                grid.Columns["column_size"].Visible = true;
                grid.Columns["column_material"].Visible = true;
                grid.Columns["column_color"].Visible = false;
            }
            else if (cb_item_type.Text == "helmet")
            {
                grid.Columns["column_size"].Visible = false;
                grid.Columns["column_material"].Visible = false;
                grid.Columns["column_color"].Visible = true;
            }
            else if (cb_item_type.Text == "jacket" || cb_item_type.Text == "pants" || cb_item_type.Text == "mask")
            {
                grid.Columns["column_size"].Visible = true;
                grid.Columns["column_material"].Visible = false;
                grid.Columns["column_color"].Visible = false;
            }
        }

        private string SearchWithSerial()
        {
            string query = string.Empty;
            bool where = false;
            if(cb_item_type.Text == "boots")
            {
                query = "SELECT * FROM tbBoots";
                if(tb_serial_number.Text.Length > 0 || cb_condition.SelectedIndex != -1)
                {
                    if(tb_serial_number.Text.Length > 0 && cb_condition.SelectedIndex != -1)
                    {
                        query += $"JOIN tbItems ON (";
                    }

                }
                if(cb_brand.Text.Length > 0)
                {
                    where = true;
                    query += $" WHERE BRAND LIKE {cb_brand.Text}";
                }

                if(tb_size.Text.Length >= 0)
                {
                    if(where)
                    {
                        query += $" AND SIZE LIKE {tb_size.Text}";
                    }
                    else
                    {
                        where = true;
                        query = $" WHERE SIZE Like {tb_size.Text}";
                    }
                }
            }
            else if(cb_item_type.Text == "helmet")
            {

            }
            return query;
        }

        private string SearchBoots()
        {
            string query = $@"
                SELECT 
                    b.Brand, b.ManufactureDate, b.Size, b.Material, b.ItemId, b.AcquisitionDate, 
                    i.ItemType, i.SerialNumber, i.Condition, i.Location, 
                    c.Name 
                FROM tbBoots AS b 
                JOIN tbItems AS i ON b.ItemId = i.Id 
                JOIN tbClients AS c ON i.Location = c.Id";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            if(tb_serial_number.Text.Length > 0)
            {
                query = $" JOIN tbItems AS i ON SerialNumber LIKE '{tb_serial_number.Text}'";
                if(cb_condition.SelectedIndex != -1)
                {
                    query += $" AND Condition = '{cb_condition.Text}'";
                }
            }
            if(cb_brand.SelectedIndex == -1 && tb_size.Text.Length == 0 && cb_material.SelectedIndex == -1)
            {
                return query;
            }

            query += " WHERE";
            if(cb_brand.SelectedIndex != -1)
            {
                query += $" Brand = '{cb_brand.Text}'";
            }

            if(tb_size.Text.Length > 0)
            {
                if(cb_brand.SelectedIndex != -1)
                {
                    query += " AND";
                }
                query += $" Size = '{tb_size.Text}'";
            }

            if(cb_material.SelectedIndex != -1)
            {
                if (cb_brand.SelectedIndex != -1 || tb_size.Text.Length > 0)
                {
                    query += " AND";
                }
                query += $" Material = '{cb_material.Text}'";
            }
            return query;
        }

        private string SearchHelmets()
        {
            string query = "";
            return query;
        }

        private string SearchJackets()
        {
            string query = "";
            return query;
        }

        private string SearchMasks()
        {
            string query = "";
            return query;
        }

        private string SearchPants()
        {
            string query = "";
            return query;
        }

        private void cb_item_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cb_item_type.Text;
            ChangeVisibleColumns();
            HelperSql.BrandsFillComboBox(connection, type, cb_brand);
            if(type == "boots")
            {
                panel_color.Visible = false;
                panel_material.Visible = true;
                panel_size.Visible = true;
            }
            else if(type == "helmet")
            {
                panel_color.Visible = true;
                panel_material.Visible = false;
                panel_size.Visible = false;
            }
            else if(type == "jacket")
            {
                panel_color.Visible = false;
                panel_material.Visible = false;
                panel_size.Visible = true;
            }
            else if(type == "mask")
            {
                panel_color.Visible = false;
                panel_material.Visible = false;
                panel_size.Visible = false;
            }
            else if(type == "pants")
            {
                panel_color.Visible = false;
                panel_material.Visible = false;
                panel_size.Visible = true;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if(cb_item_type.SelectedIndex == -1) { return; }

            string itemType = cb_item_type.Text;
            string query = string.Empty;
            if(itemType == "boots")
            {
                query = SearchBoots();
            }
            else if (itemType == "helmet")
            {
                query = SearchHelmets();
            }
            else if (itemType == "jacket")
            {
                query = SearchJackets();
            }
            else if (itemType == "mask")
            {
                query = SearchMasks();
            }
            else if (itemType == "pants")
            {
                query = SearchPants();
            }
            else
            {
                Console.WriteLine("ERROR: Item type selection is not working");
                return;
            }

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                grid.Rows.Clear();
                int index = 0;
                while (reader.Read())
                {
                    if(itemType == "boots")
                    {
                        grid.Rows.Add( ++index, 
                            reader[4], // Item ID
                            reader[2], // Size
                            "Color",
                            reader[3], // Material
                            reader[0], // Brand
                            reader[10], // Condition
                            reader[9], // Serial Number
                            reader[1], // MFD
                            reader[5], // Acqusition
                            reader[11], // Location
                            reader[7], // Type
                            reader[11] // Client
                        );
                    }
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString());}
            finally { connection.Close();  }
        }
    }
}
