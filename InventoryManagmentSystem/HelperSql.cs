using System;
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
        /// VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Material,@Size,@ManufactureDate)
        /// </summary>
        /// <returns></returns>
        public static string BootsInsert()
        {
            string query = @"
                INSERT INTO tbBoots(ItemId,SerialNumber,Brand,UsedNew,Material,Size,ManufactureDate) 
                VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Material,@Size,@ManufactureDate)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Color,@ManufactureDate)
        /// </summary>
        /// <returns></returns>
        public static string HelmetInsert()
        {
            string query = @"
                INSERT INTO tbHelmets(ItemId,SerialNumber,Brand,UsedNew,Color,ManufactureDate) 
                VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Color,@ManufactureDate)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// VALUES(@ItemId,@ClientId,@RentDate,@ReturnDate)
        /// </summary>
        /// <returns></returns>
        public static string HistoryInsert()
        {
            string query = @"
                INSERT INTO tbHistories(ItemId,ClientId,RentDate,ReturnDate) 
                VALUES(@ItemId,@ClientId,@RentDate,@ReturnDate)
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
        /// Get ItemId, ItemType, SerialNumber, Brand, ManufactureDate, LastRented.
        /// Does not repeat ItemId.
        /// </summary>
        /// <returns></returns>
        public static string HistoryGeneralInformation()
        {
            string query = @"
                SELECT
                    it.Id,
                    it.ItemType,
                    COALESCE(tb.SerialNumber, th.SerialNumber, tj.SerialNumber, tp.SerialNumber) AS SerialNumber,
                    COALESCE(tb.Brand, th.Brand, tj.Brand, tp.Brand) AS Brand,
                    COALESCE(tb.ManufactureDate, th.ManufactureDate, tj.ManufactureDate, tp.ManufactureDate) AS ManufactureDate,
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
                    LEFT JOIN tbBoots tb ON it.ItemType = 'Boots' AND tb.ItemId = it.Id
                    LEFT JOIN tbHelmets th ON it.ItemType = 'Helmet' AND th.ItemId = it.Id
                    LEFT JOIN tbJackets tj ON it.ItemType = 'Jacket' AND tj.ItemId = it.Id
                    LEFT JOIN tbPants tp ON it.ItemType = 'Pants' AND tp.ItemId = it.Id;
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Size,@ManufactureDate)
        /// </summary>
        /// <returns></returns>
        public static string JacketInsert()
        {
            string query = @"
                INSERT INTO tbJackets(ItemId,SerialNumber,Brand,UsedNew,Size,ManufactureDate) 
                VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Size,@ManufactureDate)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Size,@ManufactureDate)
        /// </summary>
        /// <returns></returns>
        public static string MaskInsert()
        {
            string query = @"
                INSERT INTO tbMasks(ItemId,SerialNumber,Brand,UsedNew,Size,ManufactureDate) 
                VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Size,@ManufactureDate)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Size,@ManufactureDate)
        /// </summary>
        /// <returns></returns>
        public static string PantsInsert()
        {
            string query = @"
                INSERT INTO tbPants(ItemId,SerialNumber,Brand,UsedNew,Size,ManufactureDate) 
                VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Size,@ManufactureDate)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }


    }

    public class HelperDatabaseCall
    {
        /// <summary>
        /// Add an item to Items table.
        /// </summary>
        /// <returns>Created item's uuid or empty if it failed.</returns>
        public static Guid ItemInsertAndGetUuid(SqlCommand command, SqlConnection connection, string itemType)
        {
            string query = HelperQuery.ItemInsertAndReturnUuid();
            Guid uuid = Guid.Empty;
            connection.Open();
            try
            {
                command = new SqlCommand(query, connection);
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
        public static void DeleteItem(SqlCommand command, SqlConnection connection, Guid uuid)
        {
            string query = HelperQuery.ItemDelete();
            connection.Open();
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", uuid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

    }
}
    