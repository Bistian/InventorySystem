using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem.All_Forms
{
    public partial class SearchForm : BaseForm
    {
        private Form Parent;
        private DataGridView grid;

        public SearchForm(DataGridView grid, Form parent)
        {
            InitializeComponent();
            Program.ItemService.LoadComboBoxWithItemTypes(cb_item_type);

            panel_serial_number.Visible = false;
            panel_size.Visible = false;
            panel_size_masks.Visible = false;
            panel_material.Visible = false;
            panel_condition.Visible = false;
            panel_color.Visible = false;
            panel_brand.Visible = false;
            panel_check_box.Visible = false;
            btn_search.Visible = false;

            string[] conditions = { "New", "Used", "Retired" };
            cb_condition.Items.AddRange(conditions);
            string[] materials = { "Rubber", "Lether" };
            cb_material.Items.AddRange(materials);
            string[] colors = { "Yellow", "Black" };
            cb_color.Items.AddRange(colors);
            string[] sizes = { "SM", "MD", "LG" };
            cb_size_masks.Items.AddRange(sizes);
            this.grid = grid;
            tb_size.KeyPress += new KeyPressEventHandler(TbSizeKeyPress);
            Parent = parent;
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

        private void SearchBoots()
        {
            // Removed client name due to table error
            // JOIN tbClients AS c ON i.Location = c.Id
            string query = @"
                SELECT
                    b.ItemId, b.Size, b.Material, b.Brand,
                    i.Condition, i.SerialNumber, b.ManufactureDate,
                    b.AcquisitionDate, i.Location, i.ItemType
                FROM tbBoots AS b
                JOIN tbItems AS i ON b.ItemId = i.Id";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool and = false;
            if (tb_serial_number.Text.Length > 0)
            {
                and = true;
                query += " WHERE i.SerialNumber LIKE @SerialNumber";
            }

            if (cb_brand.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND b.Brand = '{cb_brand.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE b.Brand = '{cb_brand.Text}'";
                }
            }

            if (tb_size.Text.Length > 0)
            {
                if (and)
                {
                    query += " AND b.Size = @Size";
                }
                else
                {
                    and = true;
                    query += " WHERE b.Size = @Size";
                }
            }

            if (cb_material.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND Material = '{cb_material.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE Material = '{cb_material.Text}'";
                }
            }

            if (cb_condition.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND i.Condition = '{cb_condition.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE i.Condition = '{cb_condition.Text}'";
                }
            }
            // Search for rented or in stock
            if (check_in_stock.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_rented.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_retired.Checked)
            {
                query += " AND i.Condition = 'Retired'";
            }

            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    if (tb_serial_number.Text.Length > 0)
                    {
                        command.Parameters.AddWithValue("@SerialNumber", $"%{tb_serial_number.Text}%");
                    }
                    if (tb_size.Text.Length > 0)
                    {
                        command.Parameters.AddWithValue("@Size", tb_size.Text);
                    }
                    SqlDataReader reader = command.ExecuteReader();
                    grid.Rows.Clear();
                    int index = 0;
                    while (reader.Read())
                    {
                        grid.Rows.Add(++index,
                            reader[0], // Item2 ID
                            reader[1], // Size
                            "Color",
                            reader[2], // Material
                            reader[3], // Brand
                            reader[4], // Condition
                            reader[5], // Serial Number
                            reader[6], // MFD
                            reader[7], // Acqusition
                            reader[8], // Location
                            reader[9] // Type
                                      // reader[11] // Client
                        );
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                finally { connection.Close(); }
            }
        }

        private void SearchHelmets()
        {
            // Removed client name due to table error
            // JOIN tbClients AS c ON i.Location = c.Id
            string query = @"
                SELECT
                    h.ItemId, h.Color, h.Brand,
                    i.Condition, i.SerialNumber, h.ManufactureDate,
                    h.AcquisitionDate, i.Location, i.ItemType
                FROM tbHelmets AS h
                JOIN tbItems AS i ON h.ItemId = i.Id ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool and = false;
            if (tb_serial_number.Text.Length > 0)
            {
                and = true;
                query += " WHERE i.SerialNumber LIKE @SerialNumber";
            }

            if (cb_brand.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND h.Brand = '{cb_brand.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE h.Brand = '{cb_brand.Text}'";
                }
            }

            if (cb_color.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND h.Color = '{cb_color.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE h.Color = '{cb_color.Text}'";
                }
            }

            if (cb_condition.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND i.Condition = '{cb_condition.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE i.Condition = '{cb_condition.Text}'";
                }
            }
            // Search for rented or in stock
            if (check_in_stock.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_rented.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_retired.Checked)
            {
                query += " AND i.Condition = 'Retired'";
            }

            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    if (tb_serial_number.Text.Length > 0)
                    {
                        command.Parameters.AddWithValue("@SerialNumber", $"%{tb_serial_number.Text}%");
                    }
                    SqlDataReader reader = command.ExecuteReader();
                    grid.Rows.Clear();
                    int index = 0;
                    while (reader.Read())
                    {
                        grid.Rows.Add(++index,
                            reader[0], // Item2 ID
                            "Size",
                            reader[1], // Color
                            "Material",
                            reader[2], // Brand
                            reader[3], // Condition
                            reader[4], // Serial Number
                            reader[5], // MFD
                            reader[6], // Acqusition
                            reader[7], // Location
                            reader[8] // Type
                                      // reader[11] // Client
                        );
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                finally { connection.Close(); }
            }
        }

        private void SearchJackets()
        {
            // Removed client name due to table error
            // JOIN tbClients AS c ON i.Location = c.Id
            string query = @"
                SELECT
                    j.ItemId, j.Size, j.Brand,
                    i.Condition, i.SerialNumber, j.ManufactureDate,
                    j.AcquisitionDate, i.Location, i.ItemType
                FROM tbJackets AS j
                JOIN tbItems AS i ON j.ItemId = i.Id ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool and = false;
            if (tb_serial_number.Text.Length > 0)
            {
                and = true;
                query += " WHERE i.SerialNumber LIKE @SerialNumber";
            }

            if (cb_brand.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND j.Brand = '{cb_brand.Text}'";
                }
                else
                {
                    query += $" WHERE j.Brand = '{cb_brand.Text}'";
                    and = true;
                }
            }

            if (tb_size.Text.Length > 0)
            {
                if (and)
                {
                    query += $" AND j.Size LIKE @Size";
                }
                else
                {
                    and = true;
                    query += $" WHERE j.Size LIKE @Size";
                }
            }

            if (cb_condition.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND i.Condition = '{cb_condition.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE i.Condition = '{cb_condition.Text}'";
                }
            }
            // Search for rented or in stock
            if (check_in_stock.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_rented.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_retired.Checked)
            {
                query += " AND i.Condition = 'Retired'";
            }
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
            {
                connection.Open();
                if (tb_serial_number.Text.Length > 0)
                {
                    command.Parameters.AddWithValue("@SerialNumber", $"%{tb_serial_number.Text}%");
                }
                if (tb_size.Text.Length > 0)
                {
                    command.Parameters.AddWithValue("@Size", $"{tb_size.Text}%");
                }
                SqlDataReader reader = command.ExecuteReader();
                grid.Rows.Clear();
                int index = 0;
                while (reader.Read())
                {
                    grid.Rows.Add(++index,
                        reader[0], // Item2 ID
                        reader[1], // Size
                        "Color",
                        "Material",
                        reader[2], // Brand
                        reader[3], // Condition
                        reader[4], // Serial Number
                        reader[5], // MFD
                        reader[6], // Acqusition
                        reader[7], // Location
                        reader[8] // Type
                                  // reader[11] // Client
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }
            }
        }

        private void SearchMasks()
        {
            // Removed client name due to table error
            // JOIN tbClients AS c ON i.Location = c.Id
            string query = @"
                SELECT
                    m.ItemId, m.Size, m.Brand,
                    i.Condition, i.SerialNumber, m.ManufactureDate,
                    m.AcquisitionDate, i.Location, i.ItemType
                FROM tbMasks AS m
                JOIN tbItems AS i ON m.ItemId = i.Id ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool and = false;
            if (tb_serial_number.Text.Length > 0)
            {
                and = true;
                query += " WHERE i.SerialNumber LIKE @SerialNumber";
            }

            if (cb_brand.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND m.Brand = '{cb_brand.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE m.Brand = '{cb_brand.Text}'";
                }
            }

            if (cb_size_masks.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND m.Size LIKE @Size";
                }
                else
                {
                    and = true;
                    query += $" WHERE m.Size LIKE @Size";
                }
            }

            if (cb_condition.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND i.Condition = '{cb_condition.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE i.Condition = '{cb_condition.Text}'";
                }
            }
            // Search for rented or in stock
            if (check_in_stock.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_rented.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_retired.Checked)
            {
                query += " AND i.Condition = 'Retired'";
            }
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
            {
                connection.Open();
                if (tb_serial_number.Text.Length > 0)
                {
                    command.Parameters.AddWithValue("@SerialNumber", $"%{tb_serial_number.Text}%");
                }
                if (cb_size_masks.SelectedIndex != -1)
                {
                    command.Parameters.AddWithValue("@Size", $"{cb_size_masks.Text}%");
                }
                SqlDataReader reader = command.ExecuteReader();
                grid.Rows.Clear();
                int index = 0;
                while (reader.Read())
                {
                    grid.Rows.Add(++index,
                        reader[0], // Item2 ID
                        reader[1], // Size
                        "Color",
                        "Material",
                        reader[2], // Brand
                        reader[3], // Condition
                        reader[4], // Serial Number
                        reader[5], // MFD
                        reader[6], // Acqusition
                        reader[7], // Location
                        reader[8] // Type
                                  // reader[11] // Client
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }
            }
        }

        private void SearchPants()
        {
            // Removed client name due to table error
            // JOIN tbClients AS c ON i.Location = c.Id
            string query = @"
                SELECT
                    p.ItemId, p.Size, p.Brand,
                    i.Condition, i.SerialNumber, p.ManufactureDate,
                    p.AcquisitionDate, i.Location, i.ItemType
                FROM tbPants AS p
                JOIN tbItems AS i ON p.ItemId = i.Id ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool and = false;
            if (tb_serial_number.Text.Length > 0)
            {
                and = true;
                query += " WHERE i.SerialNumber LIKE @SerialNumber";
            }

            if (cb_brand.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND p.Brand = '{cb_brand.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE p.Brand = '{cb_brand.Text}'";
                }
            }

            if (tb_size.Text.Length > 0)
            {
                if (and)
                {
                    query += $" AND p.Size LIKE @Size";
                }
                else
                {
                    and = true;
                    query += $" WHERE p.Size LIKE @Size";
                }
            }

            if (cb_condition.SelectedIndex != -1)
            {
                if (and)
                {
                    query += $" AND i.Condition = '{cb_condition.Text}'";
                }
                else
                {
                    and = true;
                    query += $" WHERE i.Condition = '{cb_condition.Text}'";
                }
            }
            // Search for rented or in stock
            if (check_in_stock.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NULL OR i.Location = 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_rented.Checked)
            {
                if (and)
                {
                    query += " AND (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
                else
                {
                    query += " WHERE (i.Location IS NOT NULL AND i.Location != 'Fire-Tec') AND i.Condition != 'Retired'";
                }
            }
            else if (check_retired.Checked)
            {
                query += " AND i.Condition = 'Retired'";
            }

            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
            {
                connection.Open();
                if (tb_serial_number.Text.Length > 0)
                {
                    command.Parameters.AddWithValue("@SerialNumber", $"%{tb_serial_number.Text}%");
                }
                if (tb_size.Text.Length > 0)
                {
                    command.Parameters.AddWithValue("@Size", $"{tb_size.Text}%");
                }
                SqlDataReader reader = command.ExecuteReader();
                grid.Rows.Clear();
                int index = 0;
                while (reader.Read())
                {
                    grid.Rows.Add(++index,
                        reader[0], // Item2 ID
                        reader[1], // Size
                        "Color",
                        "Material",
                        reader[2], // Brand
                        reader[3], // Condition
                        reader[4], // Serial Number
                        reader[5], // MFD
                        reader[6], // Acqusition
                        reader[7], // Location
                        reader[8] // Type
                                  // reader[11] // Client
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }
            }
        }

        private void TbSizeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (cb_item_type.Text == "jacket" || cb_item_type.Text == "pants")
            {
                // Allow control keys such as backspace
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 'x')
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == 'x' && (sender as System.Windows.Forms.TextBox).Text.Contains("x"))
                {
                    e.Handled = true;
                }

                if ((cb_item_type.Text == "jacket" || cb_item_type.Text == "pants") && e.KeyChar == 'x')
                {
                    if ((sender as System.Windows.Forms.TextBox).Text.Contains("X"))
                    {
                        e.Handled = true;
                    }
                    e.KeyChar = 'X';
                }
            }
            else if (cb_item_type.Text == "boots")
            {
                // Allow control keys such as backspace
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
        }

        private void cb_item_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel_serial_number.Visible == false)
            {
                panel_serial_number.Visible = true;
                panel_brand.Visible = true;
                panel_condition.Visible = true;
                panel_check_box.Visible = true;
                btn_search.Visible = true;
            }
            string type = cb_item_type.Text;
            ChangeVisibleColumns();

            Program.BrandService.FillComboBox(cb_brand, type);
            if (type == "boots")
            {
                panel_color.Visible = false;
                panel_material.Visible = true;
                panel_size.Visible = true;
                panel_size_masks.Visible = false;
            }
            else if (type == "helmet")
            {
                panel_color.Visible = true;
                panel_material.Visible = false;
                panel_size.Visible = false;
                panel_size_masks.Visible = false;
            }
            else if (type == "jacket")
            {
                panel_color.Visible = false;
                panel_material.Visible = false;
                panel_size.Visible = true;
                panel_size_masks.Visible = false;
            }
            else if (type == "mask")
            {
                panel_color.Visible = false;
                panel_material.Visible = false;
                panel_size.Visible = false;
                panel_size_masks.Visible = true;
            }
            else if (type == "pants")
            {
                panel_color.Visible = false;
                panel_material.Visible = false;
                panel_size.Visible = true;
                panel_size_masks.Visible = false;
            }
            InventoryForm Parent = this.Parent as InventoryForm;
            Parent.ItemTypeGlobal = type;
            btn_search_Click(sender, e);
        }

        public void btn_search_Click(object sender, EventArgs e)
        {
            if (cb_item_type.SelectedIndex == -1) { return; }

            string itemType = cb_item_type.Text;
            if (itemType == "boots")
            {
                SearchBoots();
            }
            else if (itemType == "helmet")
            {
                SearchHelmets();
            }
            else if (itemType == "jacket")
            {
                SearchJackets();
            }
            else if (itemType == "mask")
            {
                SearchMasks();
            }
            else if (itemType == "pants")
            {
                SearchPants();
            }
            else
            {
                Console.WriteLine("ERROR: Item type selection is not working");
                return;
            }
        }

        private void btn_clear_serial_Click(object sender, EventArgs e)
        {
            tb_serial_number.Text = string.Empty;
        }

        private void btn_clear_brand_Click(object sender, EventArgs e)
        {
            cb_brand.SelectedIndex = -1;
        }

        private void btn_clear_condition_Click(object sender, EventArgs e)
        {
            cb_condition.SelectedIndex = -1;
        }

        private void btn_clear_size_Click(object sender, EventArgs e)
        {
            tb_size.Text = string.Empty;
        }

        private void btn_clear_color_Click(object sender, EventArgs e)
        {
            cb_color.SelectedIndex = -1;
        }

        private void btn_clear_material_Click(object sender, EventArgs e)
        {
            cb_material.SelectedIndex = -1;
        }

        private void btn_clear_size_pants_Click(object sender, EventArgs e)
        {
            cb_size_masks.SelectedIndex = -1;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
        }

        private void panel_item_type_Paint(object sender, PaintEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void tb_serial_number_TextChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void cb_brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void cb_condition_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void tb_size_TextChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void cb_size_masks_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void cb_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void cb_material_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void check_in_stock_CheckedChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void check_rented_CheckedChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }
    }
}
