using System;
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

        /// <summary>
        /// VALUES(@ItemId,@SerialNumber,@Brand,@Condition,@Material,@Size,@ManufactureDate,@AcquisitionDate)
        /// </summary>
        /// <returns></returns>
        public static string BootsInsert()
        {
            string query = $@"
                INSERT INTO tbBoots({ItemStandardColumns()},Material,Size) 
                VALUES({ItemStandardValues()},@Material,@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }


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
        /// </summary>
        /// <returns>ItemId,SerialNumber,Brand,Condition,AcquisitionDate,ManufactureDate</returns>
        public static string ItemStandardColumns()
        {
            return "ItemId,Brand,SerialNumber,Condition,AcquisitionDate,ManufactureDate";
        }

        /// <summary>
        /// </summary>
        /// <returns>@ItemId,@SerialNumber,@Brand,@Condition,@AcquisitionDate,@ManufactureDate</returns>
        public static string ItemStandardValues()
        {
            return "@ItemId,@Brand,@SerialNumber,@Condition,@AcquisitionDate,@ManufactureDate";
        }
        
        public static string ItemTypeLoad()
        {
            return "SELECT ItemType FROM tbItemTypes";
        }

        /// <summary>
        /// VALUES(@ItemId,@SerialNumber,@Brand,@Condition,@Color,@ManufactureDate,@AcquisitionDate)
        /// </summary>
        /// <returns></returns>
        public static string HelmetInsert()
        {
            string query = $@"
                INSERT INTO tbHelmets({ItemStandardColumns()},Color) 
                VALUES({ItemStandardValues()},@Color)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
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
        /// VALUES(@ItemId,@SerialNumber,@Brand,@Condition,@Size,@ManufactureDate,@AcquisitionDate)
        /// </summary>
        /// <returns></returns>
        public static string MaskInsert()
        {
            string query = $@"
                INSERT INTO tbMasks({ItemStandardColumns()},Size) 
                VALUES({ItemStandardValues()},@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// VALUES(@ItemId,@SerialNumber,@Brand,@Condition,@Size,@ManufactureDate,@AcquisitionDate)
        /// </summary>
        /// <returns></returns>
        public static string PantsInsert()
        {
            string query = $@"
                INSERT INTO tbPants({ItemStandardColumns()},Size) 
                VALUES({ItemStandardValues()},@Size)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }


    }

    public class HelperDatabaseCall
    {
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

        /// <summary>
        /// Add an item to Items table.
        /// </summary>
        /// <returns>Created item's uuid or empty if it failed.</returns>
        public static Guid ItemInsertAndGetUuid(SqlConnection connection, string itemType)
        {
            string query = HelperQuery.ItemInsertAndReturnUuid();
            Guid uuid = Guid.Empty;
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", itemType);
                uuid = (Guid)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR adding item: {ex.Message}");
                MessageBox.Show("Could not add item.");
            }
            connection.Close();
            return uuid;
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
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            connection.Close();
        }

        public static string TableFindByItemType(string itemType)
        {
            itemType = itemType.ToLower();
            if (itemType == "boots")
            {
                return "tbBoots";
            }
            else if (itemType == "helmet")
            {
                return "tbHelmets";
            }
            else if (itemType == "jacket")
            {
                return "tbJackets";
            }
            else if(itemType == "mask")
            {
                return "tbMasks";
            }
            else if(itemType == "pants")
            {
                return "tbPants";
            }
            return null;
        }
    }
}
