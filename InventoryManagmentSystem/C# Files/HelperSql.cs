using PdfSharp.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static InventoryManagmentSystem.Academy.AcademyForm;

namespace InventoryManagmentSystem
{
    public class SqlVariables
    {
        public string query;
        public SqlCommand command;
        public SqlConnection connection;
        public SqlVariables()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
    }

    public class HelperQuery
    {
        public static string ClientLateItems()
        {
            string query = @"
                SELECT cliets.Id, cliets.Name, Count
                FROM tbCliets as clients
                JOIN tbBoots ON tbBoots.Location = clients.DriversLicenseNumber
                WHERE DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) > 0
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        public static string ItemFindBySerialNumber(string itemType, string serialNumber)
        {
            return $"SELECT COUNT (*) FROM tbItems WHERE ItemType = '{itemType}' AND SerialNumber = '{serialNumber}'";
        }

        /// <summary>
        /// VALUES(@ItemType)
        /// </summary>
        /// <returns></returns>
        public static string ItemInsert()
        {
            string query = @"
                INSERT INTO tbItems(ItemType) 
                VALUES(@ItemType)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// VALUES(@ItemType)
        /// Catch uuid with Guid uuid = (Guid)command.ExecuteScalar()
        /// </summary>
        /// <returns></returns>
        public static string ItemInsertAndReturnUuid()
        {
            string query = $@"
                INSERT INTO tbItems(ItemType) 
                OUTPUT inserted.Id 
                VALUES(@ItemType)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// Value @Id
        /// </summary>
        /// <returns></returns>
        public static string ItemDelete()
        {
            return "DELETE FROM tbItems WHERE Id=@Id";
        }

        /// <summary>
        /// Select all columns from items.
        /// </summary>
        /// <param name="itemType">Filter for one item type.</param>
        /// <param name="searchTerm">Filter for a search term.</param>
        /// <returns></returns>
        public static string ItemSelect(string itemType = null, string searchTerm = null)
        {
            string query = "SELECT * FROM tbItems AS item";
            if(itemType != null)
            {
                string table = $"tb{char.ToUpper(itemType[0])}{itemType.Substring(1)}";
                if(itemType != "boots" && itemType != "pants")
                {
                    table += 's';
                }
                query += $" JOIN {table} AS type ON type.ItemId = item.id";
            }
            if(searchTerm != null && searchTerm != "")
            {
                string specificCondition = "";
                if(itemType.ToLower() == "boots")
                {
                    specificCondition = $" OR Size LIKE '%{searchTerm}%' OR Material LIKE '%{searchTerm}%'";
                }
                else if(searchTerm.ToLower() == "helmet")
                {
                    specificCondition = $" Color LIKE '%{searchTerm}%'";
                } 
                else
                {
                    specificCondition = $" OR Size LIKE '%{searchTerm}%'";
                }
                query += $@"
                    WHERE {searchTerm} (
                    Brand LIKE '%{searchTerm}%' OR 
                    SerialNumber LIKE '%{searchTerm}%' OR 
                    Condition LIKE '%{searchTerm}%' {specificCondition})
                ";
                HelperFunctions.RemoveLineBreaksFromString(ref query);
            }
            return query;
        }

        /// <summary>
        /// </summary>
        /// <returns>ItemId,SerialNumber,Brand,Condition,AcquisitionDate,ManufactureDate</returns>
        public static string ItemStandardColumns()
        {
            return "ItemId,Brand,AcquisitionDate,ManufactureDate";
        }

        /// <summary>
        /// </summary>
        /// <returns>@ItemId,@SerialNumber,@Brand,@Condition,@AcquisitionDate,@ManufactureDate</returns>
        public static string ItemStandardValues()
        {
            return "@ItemId,@Brand,@AcquisitionDate,@ManufactureDate";
        }
        
        public static string ItemTypeLoad()
        {
            return "SELECT ItemType FROM tbItemTypes";
        }

        /// <summary>
        /// VALUES(@ItemId,@ClientId,@RentDate)
        /// </summary>
        /// <returns></returns>
        public static string HistoryInsert()
        {
            string query = @"
                INSERT INTO tbHistories(ItemId,ClientId,RentDate) 
                VALUES(@ItemId,@ClientId,GETDATE())
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// VALUES(@ItemId,@ClientId,@ReturnDate)
        /// </summary>
        /// <returns></returns>
        public static string HistoryUpdate()
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
            return query;
        }

        /// <summary>
        /// Gets ClientId, Name, RentDate, ReturnDate
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static string HistoryClientAndDates(Guid itemId)
        {
            string query = $@"
                SELECT
                    h.ClientId,
                    c.Name,
                    h.RentDate,
                    h.ReturnDate
                FROM
                    tbHistories h
                    JOIN tbClients c ON h.ClientId = c.Id
                WHERE
                    h.ItemId = '{itemId}'; 
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// Get ItemId, ItemType, SerialNumber, Brand, ManufactureDate, Condition, LastRented.
        /// Does not repeat ItemId.
        /// </summary>
        /// <returns></returns>
        public static string HistoryGeneralInformation()
        {
            string query = @"
                SELECT
                    it.Id,
                    it.ItemType,
                    COALESCE(tb.SerialNumber, th.SerialNumber, tj.SerialNumber, tp.SerialNumber, tm.SerialNumber) AS SerialNumber,
                    COALESCE(tb.Brand, th.Brand, tj.Brand, tp.Brand, tm.Brand) AS Brand,
                    COALESCE(tb.Condition, th.Condition, tj.Condition, tp.Condition, tm.Condition) AS Condition,
                    COALESCE(tb.ManufactureDate, th.ManufactureDate, tj.ManufactureDate, tp.ManufactureDate, tm.ManufactureDate) AS ManufactureDate,
                    ih.LastRented
                FROM
                    (
                        SELECT
                            ih.ItemId,
                            MAX(ih.RentDate) AS LastRented
                        FROM
                            tbHistories ih
                        GROUP BY
                            ih.ItemId
                    ) AS ih
                    JOIN tbItems it ON ih.ItemId = it.Id
                    JOIN (
                        SELECT
                            ItemId,
                            MAX(RentDate) AS LastRented
                        FROM
                            tbHistories
                        GROUP BY
                            ItemId
                    ) AS ih2 ON ih.ItemId = ih2.ItemId AND ih.LastRented = ih2.LastRented
                    LEFT JOIN tbBoots tb ON it.ItemType = 'boots' AND tb.ItemId = it.Id
                    LEFT JOIN tbHelmets th ON it.ItemType = 'helmet' AND th.ItemId = it.Id
                    LEFT JOIN tbJackets tj ON it.ItemType = 'jacket' AND tj.ItemId = it.Id
                    LEFT JOIN tbPants tp ON it.ItemType = 'pants' AND tp.ItemId = it.Id
                    LEFT JOIN tbMasks tm ON it.ItemType = 'mask' AND tm.ItemId = it.Id;
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// VALUES(@ItemId,@SerialNumber,@Brand,@Condition,@Size,@ManufactureDate, @AcquisitionDate)
        /// </summary>
        /// <returns></returns>
        public static string JacketInsert()
        {
            string query = $@"
                INSERT INTO tbJackets({ItemStandardColumns()},Size) 
                VALUES({ItemStandardValues()},@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// Get count of how many items are rented.
        /// </summary>
        /// <param name="itemType">Optional: Specify what item type you want to count.</param>
        /// <returns></returns>
        public static string RentItems(string itemType = null)
        {
            string query = $@"
                SELECT * FROM tbItems 
                WHERE Location NOT IN ('Fire-Tec', 'FIRE TEC', 'FIRETEC') AND 
                    Location IS NOT NULL AND Condition NOT IN ('Retired')
            ";
            if(itemType != null)
            {
                itemType = itemType.ToLower();
                query = $"{query} AND ItemType = '{itemType}'";
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        public static string StockCount(string itemType = null)
        {
            string query = $@"
                SELECT * FROM tbItems
                WHERE Location IN ('Fire-Tec', 'FIRE TEC', 'FIRETEC') AND 
                    Location IS NOT NULL AND 
                    Condition NOT IN ('Retired')
            ";
            if(itemType != null)
            {
                itemType = itemType.ToLower();
                query = $"{query} AND ItemType = '{itemType}'";
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }
    }

    public class HelperDatabaseCall
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

        public static bool BootsInsert(SqlConnection connection, 
            Guid itemId, string brand, string acquisition, string manufacture, string size, string material)
        {
            string query = $@"
                INSERT INTO tbBoots({HelperQuery.ItemStandardColumns()},Material,Size) 
                VALUES({HelperQuery.ItemStandardValues()},@Material,@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
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
        /// Updates an entry of boots, all parameters not to be updated should be empty string "".
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
            query += $" WHERE Id = {itemId}";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (fieldsToUpdate.ContainsKey("brand")) { command.Parameters.AddWithValue("@Brand", brand); }
                if (fieldsToUpdate.ContainsKey("size")) { command.Parameters.AddWithValue("@Size", size); }
                if (fieldsToUpdate.ContainsKey("material")) { command.Parameters.AddWithValue("@Material", material); }
                if (fieldsToUpdate.ContainsKey("manufacture")) { command.Parameters.AddWithValue("@ManufactureDate", manufacture); }
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
            string query = $"SELECT Brand FROM tbBrands WHERE ItemType='{itemType}'";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    box.Items.Add(dataReader[0]);
                }
            }
            catch (Exception ex) {Console.WriteLine(ex.Message);}
            finally { connection.Close(); }
        }

        /// <summary>
        /// Returns a dictionary with classes id and name.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="AcademyId"></param>
        /// <returns></returns>
        public static Dictionary<Guid, string> ClassListNames(SqlConnection connection, Guid AcademyId)
        {
            string query = $"SELECT Id, Name, StartDate, EndDate FROM tbClasses WHERE AcademyId = '{AcademyId}'";
            connection.Close();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                Dictionary<Guid, string> dict = new Dictionary<Guid, string>(); 
                while (reader.Read())
                {
                    string className = reader.GetString(reader.GetOrdinal("Name"));
                    DateTime classStartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                    DateTime classEndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));

                    string starDate = $"{classStartDate.Month}/{classStartDate.Day}/{classStartDate.Year}";
                    string EndDate = $"{classEndDate.Month}/{classEndDate.Day}/{classEndDate.Year}";

                    dict.Add(reader.GetGuid(
                        reader.GetOrdinal("Id")), 
                        $"{className} {starDate} - {EndDate}" 
                    );
                }
                connection.Close();
                return dict;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine($"ERROR listing classes {ex.Message}");
                return null;
            }
        }

        public static bool HelmetInsert(SqlConnection connection,
            Guid itemId, string brand, string acquisition, string manufacture, string color)
        {
            string query = $@"
                INSERT INTO tbHelmets({HelperQuery.ItemStandardColumns()},Color) 
                VALUES({HelperQuery.ItemStandardValues()},@Color)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
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
            query += $" WHERE Id = {itemId}";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (fieldsToUpdate.ContainsKey("brand")) { command.Parameters.AddWithValue("@Brand", brand); }
                if (fieldsToUpdate.ContainsKey("manufacture")) { command.Parameters.AddWithValue("@ManufactureDate", manufacture); }
                if (fieldsToUpdate.ContainsKey("size")) { command.Parameters.AddWithValue("@Color", color); }
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
        public static void ItemDelete(SqlConnection connection, Guid uuid)
        {
            string query = HelperQuery.ItemDelete();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", uuid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        public static Dictionary<string, object> ItemFindBySerialNumber(SqlConnection connection, string itemType, string serialNumber)
        {
            // I am using item type just in case the serial numbers match between different items types.
            string query = $"SELECT * FROM tbItems WHERE ItemType = '{itemType}' AND SerialNumber = '{serialNumber}'";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                object obj = new object();
                var itemData = new Dictionary<string, object>();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        object value = reader.GetValue(i);
                        itemData.Add(columnName, value);
                    }
                }
                return itemData;
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return null;
        }
       
        public static Guid ItemGetIdBySerialNumber(SqlConnection connection, string itemType, string serialNumber)
        {
            Guid uuid = Guid.Empty;
            string query = $"SELECT Id FROM tbItems WHERE ItemType = @ItemType AND SerialNumber = @SerialNumber";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", itemType);
                command.Parameters.AddWithValue("@SerialNumber", serialNumber);
                uuid = (Guid)command.ExecuteScalar();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return uuid;
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

        public static List<string> ItemGetTypes(SqlConnection connection)
        {
            string query = HelperQuery.ItemTypeLoad();
            List<string> types = new List<string>();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    types.Add(dataReader[0].ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine($"{ex.Message}"); }
            finally { connection.Close(); }
            return types;
        }

        public static void ItemTypeLoadComboBox(SqlConnection connection, ComboBox comboBox)
        {
            string query = HelperQuery.ItemTypeLoad();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBox.Items.Add(dataReader[0]);
                }
            }
            catch (Exception ex) { Console.WriteLine($"{ex.Message}"); }
            finally { connection.Close(); }
        }

        public static bool JacketInsert(SqlConnection connection,
           Guid itemId, string brand, string acquisition, string manufacture, string size)
        {
            string query = $@"
                INSERT INTO tbJackets({HelperQuery.ItemStandardColumns()},Size) 
                VALUES({HelperQuery.ItemStandardValues()},@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
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
            query += $" WHERE Id = {itemId}";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
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

        public static bool MaskInsert(SqlConnection connection,
           Guid itemId, string brand, string acquisition, string manufacture, string size)
        {
            string query = $@"
                INSERT INTO tbMasks({HelperQuery.ItemStandardColumns()},Size) 
                VALUES({HelperQuery.ItemStandardValues()},@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
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
            query += $" WHERE Id = {itemId}";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
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

        public static bool PantsInsert(SqlConnection connection,
            Guid itemId, string brand, string acquisition, string manufacture, string size)
        {
            string query = $@"
                INSERT INTO tbPants({HelperQuery.ItemStandardColumns()},Size) 
                VALUES({HelperQuery.ItemStandardValues()},@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
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
            query += $" WHERE Id = {itemId}";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
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
    }
}
