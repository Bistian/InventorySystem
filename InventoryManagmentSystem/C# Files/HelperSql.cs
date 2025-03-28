﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static InventoryManagmentSystem.Academy.AcademyForm;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace InventoryManagmentSystem
{
    public class HelperSql
    {
        private static string[] columnsClient =
        {
            "Id", "IdClass", "Name", "Phone", "Email", "Academy", "IsActive", "DriversLicenseNumber", "Address",
            "Chest", "Sleeve", "Waist", "Inseam", "Hips", "Height", "Weight",
            "Notes", "FireTecRepresentative"
        };

        public static List<Item> AcademyFillComboBox(SqlConnection connection, ComboBox box)
        {
            var list = new List<Item>();
            string query = "SELECT * FROM tbAcademies";
            string[] columns = { "Id", "Name", "ContactName", "Email", "Phone", "Street", "City", "State", "Zip" };
            try
            {
                var command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    list.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return list;
        }

        public static void AcademyFindAll(SqlConnection connection, DataGridView grid)
        {
            string query = "SELECT Id, Name, ContactName, Email, Phone, Street, City, State, Zip FROM tbAcademies";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                int count = 1;
                while(reader.Read())
                {
                    grid.Rows.Add(count++,
                        reader["Id"],
                        reader["Name"],
                        reader["ContactName"],
                        reader["Email"],
                        reader["Phone"],
                        reader["Street"],
                        reader["City"],
                        reader["State"],
                        reader["Zip"]
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine( ex.Message); }
            finally { connection.Close(); }
        }

        private static void AddParameterFromDictionary(SqlCommand command, Dictionary<string, string> dict, string key)
        {
            string value = dict.TryGetValue(key, out value) ? value : null;
            command.Parameters.AddWithValue($"@{key}", value);
        }

        /// <summary>Returns a dictionary with academies id and name.</summary>
        public static Dictionary<string, string> AcademyListNames(SqlConnection connection)
        {
            var map = new Dictionary<string, string>();
            string query = "SELECT Id, Name FROM tbAcademies";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Create a map with the uuid as a key and the name as a value.
                    map.Add(reader[0].ToString(), reader[1].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return map;
        }

        public static Item BootsFindByItemId(SqlConnection connection, string itemId)
        {
            string query = $"SELECT TOP 1 * FROM tbBoots WHERE ItemId=@ItemId";
            var item = new Item();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
                string[] columns = { "Brand", "AcquisitionDate", "ManufactureDate", "Size", "Material" };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item.AddColumn("Id", itemId);
                    item.AddByReaderAndColumnArray(reader, columns);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return item;
        }

        public static List<Item> BootsFindAll(SqlConnection connection)
        {
            string query = @"SELECT * FROM tbItems JOIN tbBoots ON Id=ItemId";
            var items = new List<Item>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                string[] columns = {
                    "Id","ItemType","DueDate","SerialNumber","Condition","Location", "BusinessModel",
                    "Brand","AcquisitionDate","ManufactureDate","Size","Material"
                };
                while (reader.Read())
                {
                    Item item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static void BootsFindAllInStock(SqlConnection connection, DataGridView grid, string search)
        {
            string query = $@"
                SELECT 
                    i.Id, i.ItemType, b.Brand, i.SerialNumber, b.Size, b.ManufactureDate, i.Condition, i.Location, b.Material 
                FROM tbBoots AS b
                LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                WHERE i.id = b.ItemId AND (i.condition = 'Used' OR i.condition = 'New')
            ";
            if(search.Length > 0)
            {
                 query = $@"
                SELECT 
                    i.Id, i.ItemType, b.Brand, i.SerialNumber, b.Size, b.ManufactureDate, i.Condition, i.Location, b.Material 
                FROM tbBoots AS b
                LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                WHERE i.id = b.ItemId AND i.SerialNumber LIKE @SerialNumber AND (i.condition = 'Used' OR i.condition = 'New')
            ";
            }


            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (search.Length > 0)
                {
                    command.Parameters.AddWithValue("@SerialNumber", $"%{search}%");
                }
                SqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    grid.Rows.Add(
                        ++index,
                        reader[0].ToString(), // id
                        reader[1], // type
                        reader[2], // brand
                        reader[3], // serial
                        reader[4], // size
                        reader[5], // MDF
                        reader[6], // condition
                        reader[7], // location
                        reader[8], // material
                        "Color"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        public static bool BootsInsert(SqlConnection connection,
            string itemId, string brand, string acquisition, string manufacture, string size, string material)
        {
            string query = $@"
                INSERT INTO tbBoots({ItemStandardColumns()},Material,Size) 
                VALUES({ItemStandardValues()},@Material,@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.Parameters.AddWithValue("@Brand", brand);
                command.Parameters.AddWithValue("@AcquisitionDate", acquisition);
                command.Parameters.AddWithValue("@ManufactureDate", manufacture);
                command.Parameters.AddWithValue("@Size", size);
                command.Parameters.AddWithValue("@Material", material);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        /// <summary>
        /// Updates an entry of pants, all parameters not to be updated should be empty string "".
        /// </summary>
        /// <returns>Bool was successfull or not.</returns>
        public static bool BootsUpdate(SqlConnection connection,
            string itemId, string brand, string size, string material,string condition, string manufacture, string SerialNumber)
        {
            Dictionary<string, string> fieldsToUpdate = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(brand))
            {
                fieldsToUpdate.Add("brand", brand);
            }
            if (!string.IsNullOrEmpty(size))
            {
                fieldsToUpdate.Add("size", size);
            }
            if (!string.IsNullOrEmpty(material))
            {
                fieldsToUpdate.Add("material", material);
            }
            if (!string.IsNullOrEmpty(manufacture))
            {
                fieldsToUpdate.Add("manufacture", manufacture);
            }
            if (!string.IsNullOrEmpty(condition))
            {
                fieldsToUpdate.Add("condition", condition);
            }
            if (!string.IsNullOrEmpty(SerialNumber))
            {
                fieldsToUpdate.Add("SerialNumber", SerialNumber);
            }

            int count = fieldsToUpdate.Count;
            if (count == 0) { return false; }

            string query = $"UPDATE tbBoots SET ";
            if (fieldsToUpdate.ContainsKey("brand"))
            {
                query += "Brand = @Brand";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("size"))
            {
                query += "Size = @Size";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("material"))
            {
                query += "Material = @Material";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("manufacture"))
            {
                query += "ManufactureDate = @ManufactureDate";
            }
            query += $" WHERE Cast(ItemId AS NVARCHAR(50)) = @ItemId";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (fieldsToUpdate.ContainsKey("brand")) { command.Parameters.AddWithValue("@Brand", brand); }
                if (fieldsToUpdate.ContainsKey("size")) { command.Parameters.AddWithValue("@Size", size); }
                if (fieldsToUpdate.ContainsKey("material")) { command.Parameters.AddWithValue("@Material", material); }
                if (fieldsToUpdate.ContainsKey("manufacture")) { command.Parameters.AddWithValue("@ManufactureDate", manufacture); }
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.ExecuteNonQuery();


                 query = $"UPDATE tbItems SET Condition = @Condition, SerialNumber = @SerialNumber " +
                    $"WHERE Cast(Id AS NVARCHAR(50)) = @ItemId";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Condition", condition);
                command.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public static void BrandsFillComboBox(SqlConnection connection, string itemType, ComboBox box)
        {
            box.Items.Clear();
            string query = $"SELECT Brand FROM tbBrands WHERE ItemType=@ItemType";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", itemType);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    box.Items.Add(dataReader[0]);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }

        public static List<Item> BrandsFindAll(SqlConnection connection)
        {
            var list = new List<Item>();
            string query = "SELECT * FROM tbBrands";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.AddColumn("Id", reader[0].ToString());
                    item.AddColumn("ItemType", reader[1].ToString());
                    item.AddColumn("Brand", reader[2].ToString());
                    list.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }

            return list;
        }

        public static void BrandsInsert(SqlConnection connection, string itemType, string brand)
        {
            // Is it duplicated?
            string query = "SELECT TOP 1 Id FROM tbBrands WHERE ItemType = @ItemType AND Brand = @Brand";
            int id = -1;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", itemType);
                command.Parameters.AddWithValue("Brand", brand);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = int.Parse(reader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            finally { connection.Close(); }

            if (id != -1)
            {
                string message = "Cannot add duplicated brand";
                DialogResult result = MessageBox.Show(message, "Duplicated Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            query = "INSERT INTO tbBrands (ItemType, Brand) VALUES (@ItemType, @Brand)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", itemType);
                command.Parameters.AddWithValue("@Brand", brand);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }

        public static void ClassFindAll(SqlConnection connection, DataGridView grid)
        {
            grid.Rows.Clear();
            string query = $@"
                SELECT c.*, a.Name as AcademyName
                FROM tbClasses as c 
                Join tbAcademies as a ON c.AcademyId = a.Id
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                int count = 1;
                while (reader.Read())
                {
                    grid.Rows.Add(
                        count++,
                        reader["Id"], 
                        reader["AcademyId"],
                        reader["AcademyName"],
                        reader["Name"],
                        reader["StartDate"],
                        reader["EndDate"],
                        reader["IsFinished"]
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }

        public static List<Item> ClassFindByAcademy(SqlConnection connection, string AcademyId)
        {
            var list = new List<Item>();
            string[] columns = { "Id", "AcademyId", "Name", "StartDate", "EndDate", "IsFinished" };
            string query = $"SELECT * FROM tbClasses WHERE AcademyId = @AcademyId";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AcademyId", AcademyId.ToString());
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    list.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return list;
        }

        public static Item ClassFindByClassId(SqlConnection connection, string classId)
        {
            string query = "SELECT TOP 1 * FROM tbClasses WHERE Id=@Id";
            string[] columns = { "Id", "Name", "StartDate", "EndDate", "IsFinished" };
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", classId.ToString());
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item(reader, columns);
                    if (item.Count() > 0)
                    {
                        return item;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return null;
        }

        public static void ClassFindByStatus(SqlConnection connection, DataGridView grid, bool active)
        {
            grid.Rows.Clear();
            string query = $@"
                SELECT c.*, a.Name AS AcademyName FROM tbClasses as c
                JOIN tbAcademies AS a ON a.Id = c.AcademyId
                WHERE IsFinished = @IsFinished";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IsFinished", active);
                SqlDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    grid.Rows.Add(
                        reader["Id"],
                        reader["AcademyId"],
                        count,
                        reader["AcademyName"],
                        reader["Name"],
                        reader["StartDate"],
                        reader["EndDate"],
                        reader["IsFinished"]
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }

        public static List<Item> ClientFindAll(SqlConnection connection)
        {
            string query = "SELECT * FROM tbClients";
            var list = new List<Item>();
            try
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Item(reader, columnsClient));
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return list;
        }

        public static List<Item> ClientFindAllProfiles(SqlConnection connection)
        {
            string query = "SELECT Id, IdClass, Name, Phone, Email, Academy, IsActive, DriversLicenseNumber, Address FROM tbClients";
            var list = new List<Item>();
            try
            {
                var command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item();
                    item.AddByReaderAndColumnArray(reader, columnsClient);
                    list.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return list;
        }

        public static Item ClientFindByDriversLicense(SqlConnection connection, string license, string Name)
        {
            var item = new Item();
            string query = $"SELECT TOP 1 * FROM tbClients WHERE DriversLicenseNumber=@License AND Name=@Name";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@License", license);
                command.Parameters.AddWithValue("@Name", Name);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item.AddByReaderAndColumnArray(reader, columnsClient);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return item;
        }

        public static Item ClientFindByName(SqlConnection connection, string name)
        {
            string query = $"SELECT * FROM tbClients WHERE Name=@Name";
            var item = new Item();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item.AddByReaderAndColumnArray(reader, columnsClient);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return item;
        }

        public static List<Item> ClientFindBySearchBar(SqlConnection connection, string searchTerm, bool isActive, bool isInactive)
        {
            var clients = new List<Item>();
            string query = "";

            if (isActive && isInactive)
            {
                query = $@"
                SELECT * 
                FROM tbClients 
                WHERE 
                (
                    Name LIKE @searchTerm
                    OR Academy LIKE @searchTerm
                ) 
            ";
            }
            else if (isActive)
            {
                query = $@"
                SELECT * 
                FROM tbClients 
                WHERE
                (
                    Name LIKE @searchTerm
                    AND IsActive = 'true'
                    OR Academy LIKE @searchTerm
                ) 
            ";
            }
            else if (isInactive)
            {
                query = $@"
                SELECT * 
                FROM tbClients 
                WHERE 
                (
                    Name LIKE @searchTerm
                    AND IsActive = 'false'
                    OR Academy LIKE @searchTerm
                ) 
            ";
            }

            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item();
                    item.AddByReaderAndColumnArray(reader, columnsClient);
                    clients.Add(item);
                }
                return clients.Count > 0 ? clients : null;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return null;
        }

        public static Item ClientFindById(SqlConnection connection, string clientId)
        {
            string query = $"SELECT TOP 1 * FROM tbClients WHERE Id=@Id";
            var item = new Item();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", clientId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item.AddByReaderAndColumnArray(reader, columnsClient);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return item;
        }

        public static Item ClientFindMeasurements(SqlConnection connection, string clientId)
        {
            string query = "SELECT TOP 1 * FROM tbClients WHERE Id=@Id";
            var item = new Item();
            try
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", clientId.ToString());
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item.AddByReaderAndColumnArray(reader, columnsClient);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return item;
        }

        public static void ClientFixActive(SqlConnection connection)
        {
            var clients = ClientFindAll(connection);
            for(int i = 0; i < clients.Count; ++i)
            {
                string id = clients[i].GetColumnValue("Id");
                var items = ClientFindRented(connection, id);
                if(items.Count > 0)
                {
                    ClientUpdateActivity(connection, id, true);
                }
                else
                {
                    ClientUpdateActivity(connection, id, false);
                }
            }
        }

        public static List<string> ClientFindRented(SqlConnection connection, string clientId)
        {
            List<string> items = new List<string>();

            string query = "SELECT Id FROM tbItems WHERE Location = @Location";
            try
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Location", clientId.ToString());
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(reader["Id"].ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static bool ClientInsert(SqlConnection connection, Dictionary<string, string> client)
        {
            //var exists = ClientFindByDriversLicense(connection, client["DriversLicenseNumber"]);
            ////if (exists.Count() > 0)
            ////{
            ////    MessageBox.Show("Client already exists.");
            ////    return false;
            ////}

            string query = $@"
                INSERT INTO tbClients(
                    Name, Phone, Email, DriversLicenseNumber, Address,
                    Chest, Sleeve, Waist, Inseam, Hips, Height, Weight,
                    FireTecRepresentative, Academy, IdClass, IsActive
                )
                VALUES(
                    @Name, @Phone, @Email, @DriversLicenseNumber, @Address, 
                    @Chest, @Sleeve, @Waist, @Inseam, @Hips, @Height, @Weight, 
                    @FireTecRepresentative, @Academy,  @IdClass, @IsActive
                )
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            try
            {
                var command = new SqlCommand(query, connection);

                AddParameterFromDictionary(command, client, "Name");
                AddParameterFromDictionary(command, client, "Phone");
                AddParameterFromDictionary(command, client, "Email");
                AddParameterFromDictionary(command, client, "DriversLicenseNumber");
                AddParameterFromDictionary(command, client, "Address");
                AddParameterFromDictionary(command, client, "Academy");
                AddParameterFromDictionary(command, client, "Chest");
                AddParameterFromDictionary(command, client, "Sleeve");
                AddParameterFromDictionary(command, client, "Waist");
                AddParameterFromDictionary(command, client, "Inseam");
                AddParameterFromDictionary(command, client, "Hips");
                AddParameterFromDictionary(command, client, "Height");
                AddParameterFromDictionary(command, client, "Weight");
                AddParameterFromDictionary(command, client, "FireTecRepresentative");

                client.TryGetValue("IdClass", out string classValue);
                if (classValue == null)
                {
                    command.Parameters.AddWithValue("@IdClass", Guid.Empty);
                }
                else
                {
                    command.Parameters.AddWithValue("@IdClass", Guid.Parse(classValue));
                }

                command.Parameters.AddWithValue("@IsActive", false);

                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Failed to insert client.");
                return false;
            }
            finally { connection.Close(); }
        }

        public static void ClientLoadToDataGrid(SqlConnection connection, DataGridView grid)
        {
            string query = "SELECT Id, Name, Phone, Email, Academy, DriversLicenseNumber, Address FROM tbClients";
            try
            {
                var command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    grid.Rows.Add(
                        ++index,
                        reader[0],
                        reader[1],
                        reader[2],
                        reader[3],
                        reader[4],
                        reader[6],
                        reader[5]
                                   );

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }

        public static bool ClientUpdateActivity(SqlConnection connection, string clientId, bool isActive)
        {
            string query = $@"
                UPDATE tbClients 
                SET IsActive = @IsActive
                WHERE Id = @Id
            ";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IsActive", isActive);
                command.Parameters.AddWithValue("@Id", clientId);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static bool ClientUpdateInfo(SqlConnection connection,
            string Id, string name, string phone, string email, string academy, string isActive, string drivers, string address)
        {
            Dictionary<string, string> fieldsToUpdate = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(name))
            {
                fieldsToUpdate.Add("name", name);
            }
            if (!string.IsNullOrEmpty(phone))
            {
                fieldsToUpdate.Add("phone", phone);
            }
            if (!string.IsNullOrEmpty(email))
            {
                fieldsToUpdate.Add("email", email);
            }
            if (!string.IsNullOrEmpty(academy))
            {
                fieldsToUpdate.Add("academy", academy);
            }
            if (!string.IsNullOrEmpty(isActive))
            {
                fieldsToUpdate.Add("isActive", isActive);
            }
            if (!string.IsNullOrEmpty(drivers))
            {
                fieldsToUpdate.Add("drivers", drivers);
            }
            if (!string.IsNullOrEmpty(address))
            {
                fieldsToUpdate.Add("address", address);
            }
            int count = fieldsToUpdate.Count;
            if (count == 0) { return false; }

            string query = $"UPDATE tbClients SET ";
            if (fieldsToUpdate.ContainsKey("name"))
            {
                query += "Name = @Name";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("phone"))
            {
                query += "Phone = @Phone";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("email"))
            {
                query += "Email = @Email";
            }
            if (fieldsToUpdate.ContainsKey("academy"))
            {
                query += "Academy = @Academy";
            }
            if (fieldsToUpdate.ContainsKey("isActive"))
            {
                query += "IsActive = @IsActive";
            }
            if (fieldsToUpdate.ContainsKey("drivers"))
            {
                query += "DriversLicenseNumber = @DriversLicenseNumber";
            }
            if (fieldsToUpdate.ContainsKey("address"))
            {
                query += "Address = @Address";
            }
            query += $" WHERE Id = @Id";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (fieldsToUpdate.ContainsKey("name")) { command.Parameters.AddWithValue("@Name", name); }
                if (fieldsToUpdate.ContainsKey("phone")) { command.Parameters.AddWithValue("@Phone", phone); }
                if (fieldsToUpdate.ContainsKey("email")) { command.Parameters.AddWithValue("@Email", email); }
                if (fieldsToUpdate.ContainsKey("academy")) { command.Parameters.AddWithValue("@Academy", academy); }
                if (fieldsToUpdate.ContainsKey("isActive")) { command.Parameters.AddWithValue("@IsActive", isActive); }
                if (fieldsToUpdate.ContainsKey("drivers")) { command.Parameters.AddWithValue("@DriversLicenseNumber", drivers); }
                if (fieldsToUpdate.ContainsKey("address")) { command.Parameters.AddWithValue("@Address", address); }
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public static bool ClientUpdateMeasurments(SqlConnection connection,
            string Id, string chest, string sleeve, string waist, string inseam, string hips, string height, string weight)
        {
            Dictionary<string, string> fieldsToUpdate = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(chest))
            {
                fieldsToUpdate.Add("chest", chest);
            }
            if (!string.IsNullOrEmpty(sleeve))
            {
                fieldsToUpdate.Add("sleeve", sleeve);
            }
            if (!string.IsNullOrEmpty(waist))
            {
                fieldsToUpdate.Add("waist", waist);
            }
            if (!string.IsNullOrEmpty(inseam))
            {
                fieldsToUpdate.Add("inseam", inseam);
            }
            if (!string.IsNullOrEmpty(hips))
            {
                fieldsToUpdate.Add("hips", hips);
            }
            if (!string.IsNullOrEmpty(height))
            {
                fieldsToUpdate.Add("height", height);
            }
            if (!string.IsNullOrEmpty(weight))
            {
                fieldsToUpdate.Add("weight", weight);
            }
            int count = fieldsToUpdate.Count;
            if (count == 0) { return false; }

            string query = $"UPDATE tbClients SET ";
            if (fieldsToUpdate.ContainsKey("chest"))
            {
                query += "Chest = @Chest";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("sleeve"))
            {
                query += "Sleeve = @Sleeve";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("waist"))
            {
                query += "Waist = @Waist";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("inseam"))
            {
                query += "Inseam = @Inseam";
            }
            if (fieldsToUpdate.ContainsKey("hips"))
            {
                query += "Hips = @Hips";
            }
            if (fieldsToUpdate.ContainsKey("height"))
            {
                query += "Height = @Height";
            }
            if (fieldsToUpdate.ContainsKey("weight"))
            {
                query += "Weight = @Weight";
            }
            query += $" WHERE Id = @Id";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (fieldsToUpdate.ContainsKey("chest")) { command.Parameters.AddWithValue("@Chest", chest); }
                if (fieldsToUpdate.ContainsKey("sleeve")) { command.Parameters.AddWithValue("@Sleeve", sleeve); }
                if (fieldsToUpdate.ContainsKey("waist")) { command.Parameters.AddWithValue("@Waist", waist); }
                if (fieldsToUpdate.ContainsKey("inseam")) { command.Parameters.AddWithValue("@Inseam", inseam); }
                if (fieldsToUpdate.ContainsKey("hips")) { command.Parameters.AddWithValue("@Hips", hips); }
                if (fieldsToUpdate.ContainsKey("height")) { command.Parameters.AddWithValue("@Height", height); }
                if (fieldsToUpdate.ContainsKey("weight")) { command.Parameters.AddWithValue("@Weight", weight); }
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public static Item HelmetFindByItemId(SqlConnection connection, string itemId)
        {
            string query = $"SELECT TOP 1 * FROM tbHelmets WHERE ItemId=@ItemId";
            var item = new Item();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                string[] columns = { "Brand", "AcquisitionDate", "ManufactureDate", "Color" };
                while (reader.Read())
                {
                    item.AddByReaderAndColumnArray(reader, columns);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return item;
        }

        public static List<Item> HelmetFindAll(SqlConnection connection)
        {
            string query = @"SELECT * FROM tbItems JOIN tbHelmets ON Id=ItemId";
            var items = new List<Item>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                string[] columns = {
                    "Id", "ItemType", "DueDate", "SerialNumber", "Condition", "Location", "BusinessModel",
                    "Brand", "AcquisitionDate", "ManufactureDate","Color"
                };
                while (reader.Read())
                {
                    Item item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static void HelmetFindAllInStock(SqlConnection connection, DataGridView grid, string search)
        {
            string query = $@"
                SELECT 
                    i.Id, i.ItemType, h.Brand, i.SerialNumber, h.ManufactureDate, i.Condition, i.Location, h.Color 
                FROM tbHelmets AS h
                LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                WHERE i.id = h.ItemId AND (i.condition = 'Used' OR i.condition = 'New')
            ";
            if(search.Length > 0)
            {
                 query = $@"
                SELECT 
                    i.Id, i.ItemType, h.Brand, i.SerialNumber, h.ManufactureDate, i.Condition, i.Location, h.Color 
                FROM tbHelmets AS h
                LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                WHERE i.id = h.ItemId AND i.SerialNumber LIKE @SerialNumber AND (i.condition = 'Used' OR i.condition = 'New')
            ";
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (search.Length > 0)
                {
                    command.Parameters.AddWithValue("@SerialNumber", $"%{search}%");
                }
                SqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    grid.Rows.Add(
                        ++index,
                        reader[0].ToString(), // id
                        reader[1], // type
                        reader[2], // brand
                        reader[3], // serial
                        "Size",
                        reader[4], // MDF
                        reader[5], // condition
                        reader[6], // location
                        "Material",
                        reader[7] // color
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        public static bool HelmetInsert(SqlConnection connection,
            string itemId, string brand, string acquisition, string manufacture, string color)
        {
            string query = $@"
                INSERT INTO tbHelmets({ItemStandardColumns()},Color) 
                VALUES({ItemStandardValues()},@Color)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.Parameters.AddWithValue("@Brand", brand);
                command.Parameters.AddWithValue("@AcquisitionDate", acquisition);
                command.Parameters.AddWithValue("@ManufactureDate", manufacture);
                command.Parameters.AddWithValue("@Color", color);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static bool HelmetUpdate(SqlConnection connection, string itemId, string brand, string manufacture,string condition, string color, string SerialNumber)
        {
            var fieldsToUpdate = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(brand))
            {
                fieldsToUpdate.Add("brand", brand);
            }
            if (!string.IsNullOrEmpty(manufacture))
            {
                fieldsToUpdate.Add("manufacture", manufacture);
            }
            if (!string.IsNullOrEmpty(color))
            {
                fieldsToUpdate.Add("color", color);
            }
            if (!string.IsNullOrEmpty(SerialNumber))
            {
                fieldsToUpdate.Add("SerialNumber", SerialNumber);
            }
            int count = fieldsToUpdate.Count;
            if (count == 0) { return false; }
            string query = $"UPDATE tbHelmets SET ";
            if (fieldsToUpdate.ContainsKey("brand"))
            {
                query += "Brand = @Brand";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("manufacture"))
            {
                query += "ManufactureDate = @ManufactureDate";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("color"))
            {
                query += "Color = @Color";
            }
            query += $" WHERE ItemId = @ItemId";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (fieldsToUpdate.ContainsKey("brand")) { command.Parameters.AddWithValue("@Brand", brand); }
                if (fieldsToUpdate.ContainsKey("manufacture")) { command.Parameters.AddWithValue("@ManufactureDate", manufacture); }
                if (fieldsToUpdate.ContainsKey("color")) { command.Parameters.AddWithValue("@Color", color); }
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.ExecuteNonQuery();

                query = $"UPDATE tbItems SET Condition = @Condition, SerialNumber = @SerialNumber " +
                   $"WHERE Cast(Id AS NVARCHAR(50)) = @ItemId";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Condition", condition);
                command.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        /// <summary> Finds history of an item or rent history of a item.</summary>
        public static List<Item> HistoryFindFull(SqlConnection connection, string itemId, string clietId)
        {
            string query = @"
                SELECT h.Id, h.ItemId, h.ClientId, h.RentDate, h.ReturnDate, 
                    i.ItemType, i.DueDate, i.SerialNumber, i.Condition, i.Location, i.BusinessModel,
                    c.Name, c.Phone, c.Email, c.Academy, c.DriversLicenseNumber
                FROM tbHistories AS h
                JOIN tbItems AS i ON h.itemId = i.Id
                JOIN tbClients AS c ON h.ClientId = c.Id
            ";
            string uuid = "";
            if (itemId != "")
            {
                uuid = itemId;
                query = $"{query} WHERE h.ItemId = @uuid";
            }
            else if (clietId != "")
            {
                uuid = clietId;
                query = $"{query} WHERE h.ClientId = @uuid";
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            var list = new List<Item>();
            string[] columns = {
                    "Id", "ItemId", "ClientId", "RentDate", "ReturnDate",
                    "ItemType", "DueDate", "SerialNumber", "Condition", "Location", "BusinessModel",
                    "Name", "Phone", "Email", "Academy", "DriversLicenseNumber"
            };
            try
            {
                var command = new SqlCommand(query, connection);
                if (uuid != "")
                {
                    command.Parameters.AddWithValue("@uuid", uuid);
                }
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    list.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return list;
        }

        public static bool HistoryInsert(SqlConnection connection, string itemId, string clientId)
        {
            string query = "INSERT INTO tbHistories(ItemId, ClientId, RentDate) VALUES(@ItemId, @ClientId, GETDATE())";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.Parameters.AddWithValue("@ClientId", clientId.ToString());
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static bool HistoryUpdate(SqlConnection connection, string ItemId, string ClientId)
        {
            string query = @"
                UPDATE h1
                SET h1.ReturnDate = GETDATE()
                FROM tbHistories AS h1
                JOIN (
                    SELECT
                        ItemId,
                        ClientId,
                        MAX(RentDate) AS LastRented
                    FROM
                        tbHistories
                    WHERE
                        ItemId = @ItemId AND ClientId = @ClientId
                    GROUP BY
                        ItemId, ClientId
                ) AS h2 ON h1.ItemId = h2.ItemId AND h1.ClientId = h2.ClientId AND h1.RentDate = h2.LastRented
                    WHERE h1.ReturnDate IS NULL;
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", ItemId.ToString());
                command.Parameters.AddWithValue("@ClientId", ClientId.ToString());
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        /// <summary>
        /// Deletes an item from item table.
        /// </summary>
        /// <param name="uuid"></param>
        public static bool ItemDelete(SqlConnection connection, string uuid)
        {
            // Find item
            string query = $"SELECT ItemType FROM tbItems WHERE Id=@Id";
            string itemType = "";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", uuid.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    itemType = reader["ItemType"].ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }

            if (itemType == "") { return false; }
            string table = HelperFunctions.MakeTableFromItemType(itemType);
            
            // Delete from specific table
            query = $"DELETE FROM {table} WHERE ItemId=@ItemId";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", uuid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }

            // Delete from items table
            query = "DELETE FROM tbItems WHERE Id=@Id";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", uuid);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public static List<Item> ItemFindAll(SqlConnection connection)
        {
            var list = new List<Item>();
            string query = "SELECT * FROM tbItems";
            string[] columns = { "Id", "ItemType", "DueDate", "SerialNumber", "Condition", "Location", "BusinessModel" };
            try
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    list.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return list;
        }

        public static void ItemFindAllWithSpecifications(SqlConnection connection, DataGridView grid)
        {
            string query = @"
                SELECT i.*, 
                    COALESCE(b.Brand, h.Brand, j.Brand, m.Brand, p.Brand) AS Brand,
                    COALESCE(b.AcquisitionDate, h.AcquisitionDate, j.AcquisitionDate, m.AcquisitionDate, p.AcquisitionDate) AS AcquisitionDate,
                    COALESCE(b.ManufactureDate, h.ManufactureDate, j.ManufactureDate, m.ManufactureDate, p.ManufactureDate) AS ManufactureDate,
                    COALESCE(b.Size, j.Size, m.Size, p.Size, '') AS Size,
                    COALESCE(b.Material, '') AS Material,
                    COALESCE(h.Color, '') AS Color
                FROM tbItems as i 
                LEFT JOIN tbBoots as b ON i.Id = b.ItemId
                LEFT JOIN tbHelmets as h ON i.Id = h.ItemId
                LEFT JOIN tbJackets as j ON i.Id = j.ItemId
                LEFT JOIN tbMasks as m ON i.Id = m.ItemId
                LEFT JOIN tbPants as p ON i.Id = p.ItemId
            ";
            string[] columns = {
                "Id", "ItemType", "DueDate", "SerialNumber", "Condition", "Location", "BusinessModel",
                "Brand", "AcquisitionDate", "ManufactureDate"
            };
            try
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                int count = 1;
                while (reader.Read())
                {
                    var item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    string type = item.GetColumnValue("ItemType");
                    string id = item.GetColumnValue("Id");
                    if (type == "boots")
                    {
                        string[] col = { "Size", "Material" };
                        item.AddByReaderAndColumnArray(reader, col);
                    }
                    else if (type == "helmet")
                    {
                        item.AddByReaderAndColumn(reader, "Color");
                    }
                    else if (type == "jacket")
                    {
                        item.AddByReaderAndColumn(reader, "Size");
                    }
                    else if (type == "mask")
                    {
                        item.AddByReaderAndColumn(reader, "Size");
                    }
                    else if (type == "pants")
                    {
                        item.AddByReaderAndColumn(reader, "Size");
                    }
                    else { continue; }
                    grid.Rows.Add(count,
                       item.GetColumnValue("Id"),
                       type,
                       item.GetColumnValue("Brand"),
                       item.GetColumnValue("SerialNumber"),
                       item.GetColumnValue("Condition"),
                       item.GetColumnValue("AcquisitionDate"),
                       item.GetColumnValue("ManufactureDate"),
                       item.GetColumnValue("Location"),
                       item.GetColumnValue("Size"),
                       item.GetColumnValue("Material"),
                       item.GetColumnValue("Color"));
                    count++;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }

        private static List<Item> ItemFindBy(SqlConnection connection, SqlCommand command)
        {
            var items = new List<Item>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                string[] keys = { "Id", "ItemType", "DueDate", "SerialNumber", "Condition", "Location", "BusinessModel" };
                while (reader.Read())
                {
                    var item = new Item();
                    foreach (string key in keys)
                    {
                        item.AddByReaderAndColumnArray(reader, keys);
                    }
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }

            foreach (var item in items)
            {
                var type = item.GetColumnValue("ItemType");
                var id = item.GetColumnValue("Id");
                var specifics = new Item();
                if (type == "boots")
                {
                    specifics = BootsFindByItemId(connection, id);
                }
                else if (type == "helmet")
                {
                    specifics = HelmetFindByItemId(connection, id);

                }
                else if (type == "jacket")
                {
                    specifics = JacketFindByItemId(connection, id);
                }
                else if (type == "mask")
                {
                    specifics = MaskFindByItemId(connection, id);
                }
                else if (type == "pants")
                {
                    specifics = PantsFindByItemId(connection, id);
                }
                item.CopyEntriesFromItem(specifics);
            }

            return items;
        }

        public static List<Item> ItemFindByClientId(SqlConnection connection, string clientId)
        {
            string query = $"SELECT * FROM tbItems WHERE Location=@Location";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Location", clientId.ToString());
            return ItemFindBy(connection, command);
        }

        public static List<Item> ItemFindByDueDate(SqlConnection connection, string dueDate, string itemType = null)
        {
            string query = "SELECT * FROM tbItems WHERE DueDate=@DueDate";
            if (itemType != null)
            {
                query = $"{query} AND ItemType=@ItemType";
            }
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DueDate", dueDate);
            if (itemType != null)
            {
                command.Parameters.AddWithValue("@ItemType", itemType);
            }
            return ItemFindBy(connection, command);
        }

        public static Item ItemFindById(SqlConnection connection, string Id)
        {
            string query = $"SELECT * FROM tbItems WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            var item = ItemFindBy(connection, command);
            if (item.Count > 0) { return item[0]; }
            return null;
        }

        public static List<Item> ItemFindBySearchBar(SqlConnection connection, string searchTerm)
        {
            var items = new List<Item>();
            string query = "SELECT * FROM tbItems WHERE Location = 'Fire-Tec' AND SerialNumber LIKE @Search AND Condition != 'Retired'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Search", $"%{searchTerm}%");
            return ItemFindBy(connection, command);
        }

        public static Item ItemFindBySerialNumber(SqlConnection connection, string itemType, string serialNumber)
        {
            // I am using item type just in case the serial numbers match between different list types.
            string query = $"SELECT * FROM tbItems WHERE ItemType = @ItemType AND SerialNumber = @Serial";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ItemType", itemType);
            command.Parameters.AddWithValue("@Serial", serialNumber);
            var item = ItemFindBy(connection, command);
            if (item.Count > 0) { return item[0]; }
            return null;
        }

        /// <summary>
        /// Add an item to Items table.
        /// </summary>
        /// <returns>Created item's uuid or empty if it failed.</returns>
        public static string ItemInsertAndGetUuid(SqlConnection connection, string itemType, string serialNumber, string condition, string businessModel)
        {
            string query = @"
                INSERT INTO tbItems (ItemType, SerialNumber, Condition, BusinessModel)
                OUTPUT inserted.Id 
                VALUES (@ItemType, @SerialNumber, @Condition, @BusinessModel)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            string uuid = "";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", itemType);
                command.Parameters.AddWithValue("@SerialNumber", serialNumber);
                command.Parameters.AddWithValue("@Condition", condition);
                command.Parameters.AddWithValue("@BusinessModel", businessModel);
                uuid = command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR adding item: {ex.Message}");
                MessageBox.Show("Could not add item.");
            }
            finally { connection.Close(); }
            return uuid;
        }

        public static bool ItemLoadDatagrid(SqlConnection connection, DataGridView grid, string condition)
        {
            string query = $@"
                SELECT 
                    i.Id, 
                    i.ItemType,
                    i.SerialNumber,
                    COALESCE(
                        b.Brand, 
                        h.Brand,
                        j.Brand,
                        m.Brand,
                        p.Brand
                    ),
                    COALESCE(b.Size, j.Size, p.Size, m.Size) AS size,
                    COALESCE(
                        b.AcquisitionDate, 
                        h.AcquisitionDate,
                        j.AcquisitionDate,
                        m.AcquisitionDate,
                        p.AcquisitionDate
                    ), 
                    COALESCE(
                        b.ManufactureDate, 
                        h.ManufactureDate,
                        j.ManufactureDate,
                        m.ManufactureDate,
                        p.ManufactureDate
                    ), 
                    i.Condition, 
                    i.Location,
                    c.Name,
                    b.Material AS material, 
                    h.Color AS color
                FROM 
                    tbItems AS i
                LEFT JOIN 
                    tbBoots AS b ON i.Id = b.ItemId
                LEFT JOIN 
                    tbHelmets AS h ON i.Id = h.ItemId
                LEFT JOIN 
                    tbJackets AS j ON i.Id = j.ItemId
                LEFT JOIN 
                    tbMasks AS m ON i.Id = m.ItemId
                LEFT JOIN 
                    tbPants AS p ON i.Id = p.ItemId
                LEFT JOIN 
                    tbClients AS c ON i.Location = CAST(c.Id AS VARCHAR(36))
                {condition}
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                var command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    int row = grid.Rows.Add(
                        ++index,
                        //ID
                        reader[0].ToString(),
                        //Size
                        reader[4].ToString(),
                        //Material
                        reader[10].ToString(),
                        //Color
                        reader[9].ToString(),
                        //Brand
                        reader[3].ToString(),
                        //Condition
                        reader[7].ToString(),
                        //SerialNumber
                        reader[2].ToString(),
                        //Acquisition Date
                        reader[6].ToString(),
                        //Manufacture Date
                        reader[5].ToString(),
                        //Location
                        reader[8].ToString(),
                        //Item Type
                        reader[1].ToString(),
                        //ClientName
                        reader[11].ToString()

                    );
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
                return false; 
            }
            finally { connection.Close(); }
            return true;
        }

        public static uint ItemRentCount(SqlConnection connection, string itemType = null)
        {
            string query = "SELECT COUNT(*) FROM tbItems WHERE Location != 'Fire-Tec' AND Location IS NOT NULL AND Condition != 'Retired'";
            if (itemType != null)
            {
                itemType = itemType.ToLower();
                query = $"{query} AND ItemType = @ItemType";
            }
            uint count = 0;
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (itemType != null)
                {
                    command.Parameters.AddWithValue("@ItemType", itemType.ToLower());
                }
                connection.Open();
                var result = command.ExecuteScalar();
                if (result != null && uint.TryParse(result.ToString(), out count))
                {
                    return count;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return count;
        }

        private static string ItemStandardColumns()
        {
            return "ItemId,Brand,AcquisitionDate,ManufactureDate";
        }

        private static string ItemStandardValues()
        {
            return "@ItemId,@Brand,@AcquisitionDate,@ManufactureDate";
        }

        public static uint ItemStockCount(SqlConnection connection, string itemType = null)
        {
            string query = "SELECT COUNT(*) FROM tbItems WHERE Location='Fire-Tec' AND Condition NOT IN ('Retired')"; ;
            if (itemType != null)
            {
                query += " AND ItemType=@ItemType";
            }

            uint stock = 0;
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (itemType != null)
                {
                    command.Parameters.AddWithValue("@ItemType", itemType);
                }
                connection.Open();
                var result = command.ExecuteScalar();
                if (result != null && uint.TryParse(result.ToString(), out stock))
                {
                    return stock;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return stock;
        }

        public static List<string> ItemTypeGet(SqlConnection connection)
        {
            string query = "SELECT ItemType FROM tbItemTypes";
            List<string> types = new List<string>();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    types.Add(reader[0].ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine($"{ex.Message}"); }
            finally { connection.Close(); }
            return types;
        }

        public static void ItemTypeLoadComboBox(SqlConnection connection, ComboBox comboBox)
        {
            string query = "SELECT ItemType FROM tbItemTypes";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox.Items.Add(reader[0]);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }

        public static bool ItemUpdate(SqlConnection connection, string itemId, string location, string dueDate = null)
        {
            string query;
            if (dueDate == null)
            {
                query = "UPDATE tbItems SET Location=@Location, DueDate=null WHERE Id=@ItemId";
            }
            else
            {
                query = "UPDATE tbItems SET Location=@Location, DueDate=@DueDate WHERE Id=@ItemId";
            }
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Location", location);
                if (dueDate != null) { command.Parameters.AddWithValue("@DueDate", dueDate); }
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static bool ItemUpdateBoots(SqlConnection connection, string itemId, string location, string dueDate = null)
        {
            string query;
            if (dueDate == null)
            {
                query = "UPDATE tbItems SET Location=@Location, DueDate=null WHERE Id=@ItemId";
            }
            else
            {
                query = "UPDATE tbItems SET Location=@Location, DueDate=null WHERE Id=@ItemId";
            }
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Location", location);
                if (dueDate != null) { command.Parameters.AddWithValue("@DueDate", dueDate); }
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static Item JacketFindByItemId(SqlConnection connection, string itemId)
        {
            string query = $"SELECT TOP 1 * FROM tbJackets WHERE ItemId=@ItemId";
            Item item = new Item();
            string[] columns = { "Brand", "AcquisitionDate", "ManufactureDate", "Size" };
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item.AddColumn("Id", itemId);
                    item.AddByReaderAndColumnArray(reader, columns);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return item;
        }

        public static List<Item> JacketFindAll(SqlConnection connection)
        {
            string query = @"SELECT * FROM tbItems JOIN tbJackets ON Id=ItemId";
            var list = new List<Item>();
            string[] columns = {
                "Id", "ItemType", "DueDate", "SerialNumber", "Condition", "Location", "BusinessModel",
                "Brand","AcquisitionDate","ManufactureDate","Size"
            };
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    list.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return list;
        }

        public static void JacketFindAllInStock(SqlConnection connection, DataGridView grid, string search)
        {
            string query = $@"
                    SELECT 
                        i.Id, i.ItemType, j.Brand, i.SerialNumber, j.Size, j.ManufactureDate, i.Condition, i.Location
                    FROM tbJackets AS j
                    LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                    WHERE i.id = j.ItemId AND (i.condition = 'Used' OR i.condition = 'New')
                ";

            if (search.Length > 0)
            {
                 query = $@"
                    SELECT 
                        i.Id, i.ItemType, j.Brand, i.SerialNumber, j.Size, j.ManufactureDate, i.Condition, i.Location
                    FROM tbJackets AS j
                    LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                    WHERE i.id = j.ItemId AND i.SerialNumber LIKE @SerialNumber AND (i.condition = 'Used' OR i.condition = 'New')
                ";

            }
         
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (search.Length > 0)
                {
                    command.Parameters.AddWithValue("@SerialNumber", $"%{search}%");
                }
                SqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    grid.Rows.Add(
                        ++index,
                        reader[0].ToString(), // id
                        reader[1], // type
                        reader[2], // brand
                        reader[3], // serial
                        reader[4], // size
                        reader[5], // MDF
                        reader[6], // condition
                        reader[7], // location
                        "Material",
                        "Color"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        public static bool JacketInsert(SqlConnection connection,
           string itemId, string brand, string acquisition, string manufacture, string size)
        {
            string query = $@"
                INSERT INTO tbJackets({ItemStandardColumns()},Size) 
                VALUES({ItemStandardValues()},@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.Parameters.AddWithValue("@Brand", brand);
                command.Parameters.AddWithValue("@AcquisitionDate", acquisition);
                command.Parameters.AddWithValue("@ManufactureDate", manufacture);
                command.Parameters.AddWithValue("@Size", size);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static bool JacketUpdate(SqlConnection connection, string itemId, string brand, string manufacture, string condition, string size, string SerialNumber)
        {
            var fieldsToUpdate = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(brand))
            {
                fieldsToUpdate.Add("brand", brand);
            }
            if (!string.IsNullOrEmpty(manufacture))
            {
                fieldsToUpdate.Add("manufacture", manufacture);
            }
            if (!string.IsNullOrEmpty(size))
            {
                fieldsToUpdate.Add("size", size);
            }
            if (!string.IsNullOrEmpty(SerialNumber))
            {
                fieldsToUpdate.Add("SerialNumber", SerialNumber);
            }

            int count = fieldsToUpdate.Count;
            if (count == 0) { return false; }
            string query = $"UPDATE tbJackets SET ";
            if (fieldsToUpdate.ContainsKey("brand"))
            {
                query += "Brand = @Brand";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("manufacture"))
            {
                query += "ManufactureDate = @ManufactureDate";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("size"))
            {
                query += "Size = @Size";
            }
            query += $" WHERE ItemId = @ItemId";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                if (fieldsToUpdate.ContainsKey("brand")) { command.Parameters.AddWithValue("@Brand", brand); }
                if (fieldsToUpdate.ContainsKey("manufacture")) { command.Parameters.AddWithValue("@ManufactureDate", manufacture); }
                if (fieldsToUpdate.ContainsKey("size")) { command.Parameters.AddWithValue("@Size", size); }
                command.ExecuteNonQuery();

                query = $"UPDATE tbItems SET Condition = @Condition, SerialNumber = @SerialNumber " +
                   $"WHERE Cast(Id AS NVARCHAR(50)) = @ItemId";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Condition", condition);
                command.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public static Item MaskFindByItemId(SqlConnection connection, string itemId)
        {
            string query = $"SELECT TOP 1 * FROM tbMasks WHERE ItemId=@ItemId";
            string[] columns = { "Brand", "AcquisitionDate", "ManufactureDate", "Size" };
            var item = new Item();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item.AddColumn("Id", itemId);
                    item.AddByReaderAndColumnArray(reader, columns);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return item;
        }

        public static List<Item> MaskFindAll(SqlConnection connection)
        {
            string query = @"SELECT * FROM tbItems JOIN tbMasks ON Id=ItemId";
            var items = new List<Item>();
            try
            {
                connection.Open();
                string[] columns = {
                    "Id", "ItemType", "DueDate", "SerialNumber", "Condition", "Location", "BusinessModel",
                    "Brand", "AcquisitionDate", "ManufactureDate","Size"};
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static void MaskFindAllInStock(SqlConnection connection, DataGridView grid, string search)
        {
            string query = $@"
                SELECT 
                    i.Id, i.ItemType, m.Brand, i.SerialNumber, m.Size, m.ManufactureDate, i.Condition, i.Location
                FROM tbMasks AS m
                LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                WHERE i.id = m.ItemId AND (i.condition = 'Used' OR i.condition = 'New')
            ";
            if(search.Length > 0)
            {
                 query = $@"
                SELECT 
                    i.Id, i.ItemType, m.Brand, i.SerialNumber, m.Size, m.ManufactureDate, i.Condition, i.Location
                FROM tbMasks AS m
                LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                WHERE i.id = m.ItemId AND i.SerialNumber LIKE @SerialNumber AND (i.condition = 'Used' OR i.condition = 'New')
            ";
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (search.Length > 0)
                {
                    command.Parameters.AddWithValue("@SerialNumber", $"%{search}%");
                }
                SqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    grid.Rows.Add(
                        ++index,
                        reader[0].ToString(), // id
                        reader[1], // type
                        reader[2], // brand
                        reader[3], // serial
                        reader[4], // size
                        reader[5], // MDF
                        reader[6], // condition
                        reader[7], // location
                        "Material",
                        "Color"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        public static bool MaskInsert(SqlConnection connection,
           string itemId, string brand, string acquisition, string manufacture, string size)
        {
            string query = $@"
                INSERT INTO tbMasks({ItemStandardColumns()},Size) 
                VALUES({ItemStandardValues()},@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.Parameters.AddWithValue("@Brand", brand);
                command.Parameters.AddWithValue("@AcquisitionDate", acquisition);
                command.Parameters.AddWithValue("@ManufactureDate", manufacture);
                command.Parameters.AddWithValue("@Size", size);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static bool MaskUpdate(SqlConnection connection, string itemId, string brand, string manufacture, string condition, string size)
        {
            var fieldsToUpdate = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(brand))
            {
                fieldsToUpdate.Add("brand", brand);
            }
            if (!string.IsNullOrEmpty(manufacture))
            {
                fieldsToUpdate.Add("manufacture", manufacture);
            }
            if (!string.IsNullOrEmpty(size))
            {
                fieldsToUpdate.Add("size", size);
            }

            int count = fieldsToUpdate.Count;
            if (count == 0) { return false; }
            string query = $"UPDATE tbMasks SET ";
            if (fieldsToUpdate.ContainsKey("brand"))
            {
                query += "Brand = @Brand";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("manufacture"))
            {
                query += "ManufactureDate = @ManufactureDate";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("size"))
            {
                query += "Size = @Size";
            }
            query += $" WHERE ItemId = @ItemId";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (fieldsToUpdate.ContainsKey("brand")) { command.Parameters.AddWithValue("@Brand", brand); }
                if (fieldsToUpdate.ContainsKey("manufacture")) { command.Parameters.AddWithValue("@ManufactureDate", manufacture); }
                if (fieldsToUpdate.ContainsKey("size")) { command.Parameters.AddWithValue("@Size", size); }
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.ExecuteNonQuery();

                query = $"UPDATE tbItems SET Condition = @Condition " +
                  $"WHERE Cast(Id AS NVARCHAR(50)) = @ItemId";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Condition", condition);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public static Item PantsFindByItemId(SqlConnection connection, string itemId)
        {
            string query = $"SELECT TOP 1 * FROM tbPants WHERE ItemId=@ItemId";
            string[] columns = { "Brand", "AcquisitionDate", "ManufactureDate", "Size" };
            var item = new Item();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item.AddColumn("Id", itemId);
                    item.AddByReaderAndColumnArray(reader, columns);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return item;
        }

        public static List<Item> PantsFindAll(SqlConnection connection)
        {
            string query = @"SELECT * FROM tbItems JOIN tbPants ON Id=ItemId";
            var items = new List<Item>();
            try
            {
                connection.Open();
                string[] columns = {
                    "Id", "ItemType", "DueDate", "SerialNumber", "Condition", "Location", "BusinessModel",
                    "Brand", "AcquisitionDate", "ManufactureDate","Size"};
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.AddByReaderAndColumnArray(reader, columns);
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static void PantsFindAllInStock(SqlConnection connection, DataGridView grid, string search)
        {
            string query = $@"
                SELECT 
                    i.Id, i.ItemType, p.Brand, i.SerialNumber, p.Size, p.ManufactureDate, i.Condition, i.Location
                FROM tbPants AS p
                LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                WHERE i.id = p.ItemId AND (i.condition = 'Used' OR i.condition = 'New')
            ";
            if(search.Length > 0)
            {
                 query = $@"
                SELECT 
                    i.Id, i.ItemType, p.Brand, i.SerialNumber, p.Size, p.ManufactureDate, i.Condition, i.Location
                FROM tbPants AS p
                LEFT JOIN tbItems AS i ON i.Location = 'Fire-Tec' OR i.Location IS NULL
                WHERE i.id = p.ItemId AND i.SerialNumber LIKE @SerialNumber AND (i.condition = 'Used' OR i.condition = 'New')
            ";
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (search.Length > 0)
                {
                    command.Parameters.AddWithValue("@SerialNumber", $"%{search}%");
                }
                SqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    grid.Rows.Add(
                        ++index,
                        reader[0].ToString(), // id
                        reader[1], // type
                        reader[2], // brand
                        reader[3], // serial
                        reader[4], // size
                        reader[5], // MDF
                        reader[6], // condition
                        reader[7], // location
                        "Material",
                        "Color"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        public static bool PantsInsert(SqlConnection connection,
            string itemId, string brand, string acquisition, string manufacture, string size)
        {
            string query = $@"
                INSERT INTO tbPants({ItemStandardColumns()},Size) 
                VALUES({ItemStandardValues()},@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.Parameters.AddWithValue("@Brand", brand);
                command.Parameters.AddWithValue("@AcquisitionDate", acquisition);
                command.Parameters.AddWithValue("@ManufactureDate", manufacture);
                command.Parameters.AddWithValue("@Size", size);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static bool PantsUpdate(SqlConnection connection, string itemId, string brand, string manufacture, string condition, string size)
        {
            var fieldsToUpdate = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(brand))
            {
                fieldsToUpdate.Add("brand", brand);
            }
            if (!string.IsNullOrEmpty(manufacture))
            {
                fieldsToUpdate.Add("manufacture", manufacture);
            }
            if (!string.IsNullOrEmpty(size))
            {
                fieldsToUpdate.Add("size", size);
            }

            int count = fieldsToUpdate.Count;
            if (count == 0) { return false; }
            string query = $"UPDATE tbPants SET ";
            if (fieldsToUpdate.ContainsKey("brand"))
            {
                query += "Brand = @Brand";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("manufacture"))
            {
                query += "ManufactureDate = @ManufactureDate";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("size"))
            {
                query += "Size = @Size";
            }
            query += $" WHERE ItemId = @ItemId";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (fieldsToUpdate.ContainsKey("brand")) { command.Parameters.AddWithValue("@Brand", brand); }
                if (fieldsToUpdate.ContainsKey("manufacture")) { command.Parameters.AddWithValue("@ManufactureDate", manufacture); }
                if (fieldsToUpdate.ContainsKey("size")) { command.Parameters.AddWithValue("@Size", size); }
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.ExecuteNonQuery();

                query = $"UPDATE tbItems SET Condition = @Condition " +
                  $"WHERE Cast(Id AS NVARCHAR(50)) = @ItemId";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Condition", condition);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }
    }
}
