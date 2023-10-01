using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

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

        public static string BrandsLoad()
        {
            return "SELECT * FROM tbBrands";
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
        public static Dictionary<Guid, string> ClassListNames(SqlConnection connection, Guid AcademyId)
        {
            string query = $"SELECT Id, Name FROM tbClasses WHERE AcademyId = '{AcademyId}'";
            connection.Close();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                Dictionary<Guid, string> dict = new Dictionary<Guid, string>(); ;
                while (reader.Read())
                {
                    dict.Add(reader.GetGuid(
                        reader.GetOrdinal("Id")), 
                        reader.GetString(reader.GetOrdinal("Name"))
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
    }
}
