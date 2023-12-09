using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public class HelperSql
    {
        /// <summary>
        /// Returns a dictionary with academies id and name.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static Dictionary<Guid, string> AcademyListNames(SqlConnection connection)
        {
            Dictionary<Guid, string> map = new Dictionary<Guid, string>();
            string query = "SELECT Id, Name FROM tbAcademies";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Create a map with the uuid as a key and the name as a value.
                    map.Add((Guid)reader[0], reader[1].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return map;
        }

        public static Boots BootsFindByItemId(SqlConnection connection, Guid itemId) 
        {
            string query = $"SELECT * FROM tbBoots WHERE ItemId=@ItemId";
            Boots boots = new Boots();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    boots.ItemId = itemId;
                    boots.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    boots.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    boots.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    boots.Size = reader[reader.GetOrdinal("Size")].ToString();
                    boots.Material = reader[reader.GetOrdinal("Material")].ToString();
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return boots;
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
                while (reader.Read())
                {
                    Item item = new Item();
                    item.Id = (Guid)reader[reader.GetOrdinal("Id")];
                    item.ItemType = reader[reader.GetOrdinal("ItemType")].ToString();
                    item.DueDate = reader[reader.GetOrdinal("DueDate")].ToString();
                    item.SerialNumber = reader[reader.GetOrdinal("SerialNumber")].ToString();
                    item.Condition = reader[reader.GetOrdinal("Condition")].ToString();
                    item.Location = reader[reader.GetOrdinal("Location")].ToString();
                    item.BusinessModel = reader[reader.GetOrdinal("BusinessModel")].ToString();
                    Boots boots = new Boots();
                    boots.ItemId = item.Id;
                    boots.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    boots.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    boots.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    boots.Size = reader[reader.GetOrdinal("Size")].ToString();
                    boots.Material = reader[reader.GetOrdinal("Material")].ToString();
                    item.Specifications = boots;
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static bool BootsInsert(SqlConnection connection, 
            Guid itemId, string brand, string acquisition, string manufacture, string size, string material)
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
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        /// <summary>
        /// Updates an entry of pants, all parameters not to be updated should be empty string "".
        /// </summary>
        /// <returns>Bool was successfull or not.</returns>
        public static bool BootsUpdate(SqlConnection connection, 
            Guid itemId, string brand, string size, string material, string manufacture)
        {
            Dictionary<string, string> fieldsToUpdate = new Dictionary<string, string>();
            if(!string.IsNullOrEmpty(brand))
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
            int count = fieldsToUpdate.Count;
            if(count == 0) { return false; }

            string query = $"UPDATE tbBoots SET ";
            if(fieldsToUpdate.ContainsKey("brand"))
            {
                query += "Brand = @Brand";
                if(--count > 0) { query += ", "; }
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
            if (fieldsToUpdate.ContainsKey("material"))
            {
                query += "ManufactureDate = @ManufactureDate";
            }
            query += $" WHERE ItemId = @ItemId";
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
                return true;
            }
            catch(Exception ex) { 
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
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                connection.Open();
                command.Parameters.AddWithValue("@ItemType", itemType);
                while (dataReader.Read())
                {
                    box.Items.Add(dataReader[0]);
                }
            }
            catch (Exception ex) {Console.WriteLine(ex.Message);}
            finally { connection.Close(); }
        }

        private static Dictionary<string, string> ClassFillWithReader(SqlDataReader reader)
        {
            var dict = new Dictionary<string, string>();

            string key = "Id";
            string value = reader[reader.GetOrdinal(key)].ToString();
            dict.Add(key, value);

            key = "AcademyId";
            value = reader[reader.GetOrdinal(key)].ToString();
            dict.Add(key, value);

            key = "Name";
            value = reader[reader.GetOrdinal(key)].ToString();
            dict.Add(key, value);

            key = "StartDate";
            DateTime startDate = reader.GetDateTime(reader.GetOrdinal(key));
            value = $"{startDate.Month}/{startDate.Day}/{startDate.Year}";
            dict.Add(key, value);

            key = "EndDate";
            DateTime endDate = reader.GetDateTime(reader.GetOrdinal(key));
            value = $"{endDate.Month}/{endDate.Day}/{endDate.Year}";
            dict.Add(key, value);

            key = "IsFinished";
            value = reader[reader.GetOrdinal(key)].ToString();
            dict.Add(key, value);

            return dict.Count > 0 ? dict : null;
        }

        public static List<Dictionary<string, string>> ClassListByAcademy(SqlConnection connection, Guid AcademyId)
        {
            var list = new List<Dictionary<string, string>>();
            string query = $"SELECT * FROM tbClasses WHERE AcademyId = @AcademyId";
            try
            {
                connection.Close();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AcademyId", AcademyId.ToString());
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var c = ClassFillWithReader(reader);
                    if(c != null) { list.Add(c); }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return list.Count > 0 ? list : null;
        }

        public static Dictionary<string, string> ClassFindByClassId(SqlConnection connection, Guid classId)
        {
            string query = "SELECT * FROM tbClasses WHERE Id=@Id";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", classId.ToString());
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    var c = ClassFillWithReader(reader);
                    if(c != null) { return c; }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return null;
        }

        private static Dictionary<string, string> ClientFillWithReader(SqlDataReader reader)
        {
            var client = new Dictionary<string, string>();
            string key = "Id";
            string value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "IdClass";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Name";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Phone";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Email";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Academy";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Type";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Status";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "DriversLicenseNumber";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Address";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Chest";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Sleeve";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Waist";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Inseam";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Hips";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Height";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Weight";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "Notes";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            key = "FireTecRepresentative";
            value = reader[reader.GetOrdinal(key)].ToString();
            client.Add(key, value);
            return client.Count > 0 ? client : null;
        }

        public static Dictionary<string, string> ClientFindByDriversLicense(SqlConnection connection, string license)
        {
            string query = $"SELECT * FROM tbClients WHERE DriversLicenseNumber=@License";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@License", license);
                SqlDataReader reader = command.ExecuteReader();
                return ClientFillWithReader(reader);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return null;
        }

        public static Dictionary<string, string> ClientFindByName(SqlConnection connection, string name)
        {
            string query = $"SELECT * FROM tbClients WHERE Name=@Name";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return ClientFillWithReader(reader);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return null;
        }

        public static List<Dictionary<string, string>> ClientFindBySearchBar(SqlConnection connection, string searchTerm)
        {
            var clients = new List<Dictionary<string, string>>();
            string query = "SELECT * FROM tbClients WHERE (Name LIKE %@searchTerm% OR Academy LIKE @searchTerm) AND Type = @ClientType";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var client = ClientFillWithReader(reader);
                    if(client != null) { clients.Add(client); }
                }
                return clients.Count > 0 ? clients : null;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return null;
        }

        public static Dictionary<string, string> ClientFindById(SqlConnection connection, Guid clientId)
        {
            string query = $"SELECT * FROM tbClients WHERE Id=@Id";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", clientId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return ClientFillWithReader(reader);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return null;
        }

        public static List<Dictionary<string, string>> ClientFindByType(SqlConnection connection, string clientType)
        {
            var clients = new List<Dictionary<string, string>>();
            string query = "SELECT * FROM tbClients WHERE Type=@Type";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Type", clientType);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var client = ClientFillWithReader(reader);
                    if(client != null) { clients.Add(client); }
                }
                return clients.Count > 0 ? clients : null;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return null;
        }

        public static Helmet HelmetFindByItemId(SqlConnection connection, Guid itemId)
        {
            string query = $"SELECT * FROM tbHelmets WHERE ItemId=@ItemId";
            Helmet helmet = new Helmet();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    helmet.ItemId = itemId;
                    helmet.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    helmet.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    helmet.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    helmet.Color = reader[reader.GetOrdinal("Color")].ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return helmet;
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
                while (reader.Read())
                {
                    Item item = new Item();
                    item.Id = (Guid)reader[reader.GetOrdinal("Id")];
                    item.ItemType = reader[reader.GetOrdinal("ItemType")].ToString();
                    item.DueDate = reader[reader.GetOrdinal("DueDate")].ToString();
                    item.SerialNumber = reader[reader.GetOrdinal("SerialNumber")].ToString();
                    item.Condition = reader[reader.GetOrdinal("Condition")].ToString();
                    item.Location = reader[reader.GetOrdinal("Location")].ToString();
                    item.BusinessModel = reader[reader.GetOrdinal("BusinessModel")].ToString();
                    Helmet helmet = new Helmet();
                    helmet.ItemId = item.Id;
                    helmet.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    helmet.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    helmet.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    helmet.Color = reader[reader.GetOrdinal("Color")].ToString();
                    item.Specifications = helmet;
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static bool HelmetInsert(SqlConnection connection,
            Guid itemId, string brand, string acquisition, string manufacture, string color)
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
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static bool HelmetUpdate(SqlConnection connection, Guid itemId, string brand, string manufacture, string color)
        {
            Dictionary<string, string> fieldsToUpdate = new Dictionary<string, string>();
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

            int count = fieldsToUpdate.Count;
            if (count == 0) { return false; }
            string query = $"UPDATE tbHelmets SET ";
            if (fieldsToUpdate.ContainsKey("brand"))
            {
                query += "Brand = @Brand";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("material"))
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
                if (fieldsToUpdate.ContainsKey("size")) { command.Parameters.AddWithValue("@Color", color); }
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

        /// <summary>
        /// Deletes an item from item table.
        /// </summary>
        /// <param name="uuid"></param>
        public static bool ItemDelete(SqlConnection connection, Guid uuid)
        {
            string query = $"SELECT ItemType FROM tbItems WHERE Id=@Id";
            string itemType = "";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", uuid.ToString());
                itemType = command.ExecuteReader().ToString();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }

            if(itemType == "") { return false; }
            string table = HelperFunctions.MakeTableFromItemType(itemType);

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

        private static List<Item> ItemFindBy(SqlConnection connection, SqlCommand command)
        {
            var items = new List<Item>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item();
                    item.Id = (Guid)reader[reader.GetOrdinal("Id")];
                    item.ItemType = reader[reader.GetOrdinal("ItemType")].ToString();
                    item.DueDate = reader[reader.GetOrdinal("DueDate")].ToString();
                    item.SerialNumber = reader[reader.GetOrdinal("SerialNumber")].ToString();
                    item.Condition = reader[reader.GetOrdinal("Condition")].ToString();
                    item.Location = reader[reader.GetOrdinal("Location")].ToString();
                    item.BusinessModel = reader[reader.GetOrdinal("BusinessModel")].ToString();
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }

            foreach (var item in items)
            {
                if (item.ItemType == "boots")
                {
                    item.Specifications = BootsFindByItemId(connection, item.Id);
                }
                else if (item.ItemType == "helmet")
                {
                    item.Specifications = HelmetFindByItemId(connection, item.Id);
                }
                else if (item.ItemType == "jacket")
                {
                    item.Specifications = JacketFindByItemId(connection, item.Id);
                }
                else if (item.ItemType == "mask")
                {
                    item.Specifications = MaskFindByItemId(connection, item.Id);
                }
                else if (item.ItemType == "pants")
                {
                    item.Specifications = PantsFindByItemId(connection, item.Id);
                }
            }

            return items;
        }

        public static List<Item> ItemFindByClientId(SqlConnection connection, Guid clientId)
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

        public static List<Item> ItemFindBySearchBar(SqlConnection connection, string searchTerm)
        {
            var items = new List<Item>();
            string query = "SELECT * FROM tbItems WHERE Location = 'Fire-Tec' AND SerialNumber LIKE @Search AND Condition != 'Retired'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Search", $"%{searchTerm}%");
            return ItemFindBy(connection , command);
        }

        public static Item ItemFindBySerialNumber(SqlConnection connection, string itemType, string serialNumber)
        {
            // I am using item type just in case the serial numbers match between different items types.
            string query = $"SELECT * FROM tbItems WHERE ItemType = @ItemType AND SerialNumber = @Serial";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ItemType", itemType);
            command.Parameters.AddWithValue("@Serial", serialNumber);
            var item = ItemFindBy(connection , command);
            if(item.Count > 0) { return item[0]; }
            return null;
        }

        /// <summary>
        /// Add an item to Items table.
        /// </summary>
        /// <returns>Created item's uuid or empty if it failed.</returns>
        public static Guid ItemInsertAndGetUuid(SqlConnection connection, string itemType, string serialNumber, string condition, string businessModel)
        {
            string query = @"
                INSERT INTO tbItems (ItemType, SerialNumber, Condition, BusinessModel)
                OUTPUT inserted.Id 
                VALUES (@ItemType, @SerialNumber, @Condition, @BusinessModel)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            Guid uuid = Guid.Empty;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", itemType);
                command.Parameters.AddWithValue("@SerialNumber", serialNumber);
                command.Parameters.AddWithValue("@Condition", condition);
                command.Parameters.AddWithValue("@BusinessModel", businessModel);
                uuid = (Guid)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR adding item: {ex.Message}");
                MessageBox.Show("Could not add item.");
            }
            finally { connection.Close(); }
            return uuid;
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
                if(itemType != null)
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
            catch(Exception ex) { Console.WriteLine(ex.Message); }
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
            if(itemType != null)
            {
                query += " AND ItemType=@ItemType";
            }

            uint stock = 0;
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                if(itemType != null) 
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
            catch(Exception ex) { Console.WriteLine(ex.Message); }
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

        public static bool ItemUpdate(SqlConnection connection, Guid itemId, string location, string dueDate = null)
        {
            string query = "UPDATE tbItems SET Location=@Location, DueDate=@DueDate WHERE Id=@ItemId";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Location", location);
                command.Parameters.AddWithValue("@DueDate", dueDate);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); } 
            finally { connection.Close(); }
            return false;
        }

        /// <summary>
        /// Find list using item id or client id.
        /// Use Guid.Empty on the id you don't want to search.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="itemId"></param>
        /// <param name="clietId"></param>
        /// <returns>List of histories</returns>
        public static List<History> HistoryFindItem(SqlConnection connection,  Guid itemId, Guid clietId)
        {
            string query;
            Guid id = Guid.Empty;
            if(itemId == Guid.Empty)
            {
                if(clietId == Guid.Empty) { return null; }
                else 
                { 
                    id = clietId;
                    query = $"SELECT * FROM tbHistories WHERE ClientId=@Id"; 
                }
            } 
            else 
            { 
                id = itemId;
                query = $"SELECT * FROM tbHistories WHERE ItemId=@Id'"; 
            }

            List<History> hList = new List<History>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    History h = new History();
                    h.Id = (int)reader[1];
                    h.ItemId = (Guid)reader[1];
                    h.ClientId = (Guid)reader[2];
                    h.RentDate = reader[3].ToString();
                    h.ReturnDate = reader[4].ToString();
                    hList.Add(h);
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return hList;
        }

        public static List<Dictionary<string,string>> HistoryNameAndType(SqlConnection connection, Guid itemId, Guid clietId)
        {
            string query = @"
                SELECT h.Id, h.ItemId, h.ClientId, h.RentDate, h.ReturnDate, i.ItemType, c.Name
                FROM tbHistories AS h
                JOIN tbItems AS i ON h.itemId = i.Id
                JOIN tbClients AS c ON h.ClientId = c.Id
            ";
            Guid uuid = Guid.Empty;
            if(itemId != Guid.Empty)
            {
                uuid = itemId;
                query = $"{query} WHERE h.ItemId = @uuid";
            }
            else if(clietId != Guid.Empty)
            {
                uuid = clietId;
                query = $"{query} WHERE h.ClientId = @uuid";
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            var list = new List<Dictionary<string, string>>();
            try
            {
                var command = new SqlCommand(query, connection);
                if(uuid != Guid.Empty)
                {
                    command.Parameters.AddWithValue("@uuid", uuid);
                }
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    var history = new Dictionary<string, string>();
                    string key = "Id";
                    string value = reader[reader.GetOrdinal(key)].ToString();
                    history.Add(key, value);

                    key = "ItemId";
                    value = reader[reader.GetOrdinal(key)].ToString();
                    history.Add(key, value);

                    key = "ClientId";
                    value = reader[reader.GetOrdinal(key)].ToString();
                    history.Add(key, value);

                    key = "RentDate";
                    value = reader[reader.GetOrdinal(key)].ToString();
                    history.Add(key, value);

                    key = "ReturnDate";
                    value = reader[reader.GetOrdinal(key)].ToString();
                    history.Add(key, value);

                    key = "ItemType";
                    value = reader[reader.GetOrdinal(key)].ToString();
                    history.Add(key, value);

                    key = "Name";
                    value = reader[reader.GetOrdinal(key)].ToString();
                    history.Add(key, value);

                    list.Add(history);
                }

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return list;
        }

        public static bool HistoryInsert(SqlConnection connection, Guid itemId, Guid clientId)
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
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static bool HistoryUpdate(SqlConnection connection, Guid ItemId, Guid ClientId)
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
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return false;
        }

        public static Jacket JacketFindByItemId(SqlConnection connection, Guid itemId)
        {
            string query = $"SELECT * FROM tbJackets WHERE ItemId=@ItemId";
            Jacket jacket = new Jacket();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    jacket.ItemId = itemId;
                    jacket.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    jacket.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    jacket.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    jacket.Size = reader[reader.GetOrdinal("Size")].ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return jacket;
        }

        public static List<Item> JacketFindAll(SqlConnection connection)
        {
            string query = @"SELECT * FROM tbItems JOIN tbJackets ON Id=ItemId";
            var items = new List<Item>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.Id = (Guid)reader[reader.GetOrdinal("Id")];
                    item.ItemType = reader[reader.GetOrdinal("ItemType")].ToString();
                    item.DueDate = reader[reader.GetOrdinal("DueDate")].ToString();
                    item.SerialNumber = reader[reader.GetOrdinal("SerialNumber")].ToString();
                    item.Condition = reader[reader.GetOrdinal("Condition")].ToString();
                    item.Location = reader[reader.GetOrdinal("Location")].ToString();
                    item.BusinessModel = reader[reader.GetOrdinal("BusinessModel")].ToString();
                    Jacket jacket = new Jacket();
                    jacket.ItemId = item.Id;
                    jacket.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    jacket.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    jacket.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    jacket.Size = reader[reader.GetOrdinal("Size")].ToString();
                    item.Specifications = jacket;
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static bool JacketInsert(SqlConnection connection,
           Guid itemId, string brand, string acquisition, string manufacture, string size)
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

        public static bool JacketUpdate(SqlConnection connection, Guid itemId, string brand, string manufacture, string size)
        {
            Dictionary<string, string> fieldsToUpdate = new Dictionary<string, string>();
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
            string query = $"UPDATE tbJackets SET ";
            if (fieldsToUpdate.ContainsKey("brand"))
            {
                query += "Brand = @Brand";
                if (--count > 0) { query += ", "; }
            }
            if (fieldsToUpdate.ContainsKey("material"))
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public static Mask MaskFindByItemId(SqlConnection connection, Guid itemId)
        {
            string query = $"SELECT * FROM tbMasks WHERE ItemId=@ItemId";
            Mask mask = new Mask();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mask.ItemId = itemId;
                    mask.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    mask.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    mask.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    mask.Size = reader[reader.GetOrdinal("Size")].ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return mask;
        }

        public static List<Item> MaskFindAll(SqlConnection connection)
        {
            string query = @"SELECT * FROM tbItems JOIN tbMasks ON Id=ItemId";
            var items = new List<Item>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.Id = (Guid)reader[reader.GetOrdinal("Id")];
                    item.ItemType = reader[reader.GetOrdinal("ItemType")].ToString();
                    item.DueDate = reader[reader.GetOrdinal("DueDate")].ToString();
                    item.SerialNumber = reader[reader.GetOrdinal("SerialNumber")].ToString();
                    item.Condition = reader[reader.GetOrdinal("Condition")].ToString();
                    item.Location = reader[reader.GetOrdinal("Location")].ToString();
                    item.BusinessModel = reader[reader.GetOrdinal("BusinessModel")].ToString();
                    Mask mask = new Mask();
                    mask.ItemId = item.Id;
                    mask.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    mask.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    mask.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    mask.Size = reader[reader.GetOrdinal("Size")].ToString();
                    item.Specifications = mask;
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static bool MaskInsert(SqlConnection connection,
           Guid itemId, string brand, string acquisition, string manufacture, string size)
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

        public static bool MaskUpdate(SqlConnection connection, Guid itemId, string brand, string manufacture, string size)
        {
            Dictionary<string, string> fieldsToUpdate = new Dictionary<string, string>();
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
            if (fieldsToUpdate.ContainsKey("material"))
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public static Pants PantsFindByItemId(SqlConnection connection, Guid itemId)
        {
            string query = $"SELECT * FROM tbMasks WHERE ItemId=@ItemId";
            Pants pants = new Pants();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pants.ItemId = itemId;
                    pants.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    pants.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    pants.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    pants.Size = reader[reader.GetOrdinal("Size")].ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return pants;
        }

        public static List<Item> PantsFindAll(SqlConnection connection)
        {
            string query = @"SELECT * FROM tbItems JOIN tbPants ON Id=ItemId";
            var items = new List<Item>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.Id = (Guid)reader[reader.GetOrdinal("Id")];
                    item.ItemType = reader[reader.GetOrdinal("ItemType")].ToString();
                    item.DueDate = reader[reader.GetOrdinal("DueDate")].ToString();
                    item.SerialNumber = reader[reader.GetOrdinal("SerialNumber")].ToString();
                    item.Condition = reader[reader.GetOrdinal("Condition")].ToString();
                    item.Location = reader[reader.GetOrdinal("Location")].ToString();
                    item.BusinessModel = reader[reader.GetOrdinal("BusinessModel")].ToString();
                    Pants pants = new Pants();
                    pants.ItemId = item.Id;
                    pants.Brand = reader[reader.GetOrdinal("Brand")].ToString();
                    pants.AcquisitionDate = reader[reader.GetOrdinal("AcquisitionDate")].ToString();
                    pants.ManufactureDate = reader[reader.GetOrdinal("ManufactureDate")].ToString();
                    pants.Size = reader[reader.GetOrdinal("Size")].ToString();
                    item.Specifications = pants;
                    items.Add(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return items;
        }

        public static bool PantsInsert(SqlConnection connection,
            Guid itemId, string brand, string acquisition, string manufacture, string size)
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

        public static bool PantsUpdate(SqlConnection connection, Guid itemId, string brand, string manufacture, string size)
        {
            Dictionary<string, string> fieldsToUpdate = new Dictionary<string, string>();
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
            if (fieldsToUpdate.ContainsKey("material"))
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
