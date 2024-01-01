using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventoryManagmentSystem
{
    public class Item
    {
        private Dictionary<string, string> item;
        public Item(Dictionary<string, string> dict = null) 
        {
            item = dict == null ? new Dictionary<string, string>() : dict;
        }
        public Item(SqlDataReader reader, string[] columns)
        {
            item = new Dictionary<string, string>();
            AddByReaderAndColumnArray(reader, columns);
        }

        ~Item()
        {
            item.Clear();
        }

        public bool AddColumn(string key, string value)
        {
            if(item.ContainsKey(key))
            {
                return false;
            }
            item[key] = value;
            return true;
        }

        public bool AddByReaderAndColumn(SqlDataReader reader, string key)
        {
            try 
            {
                string value = reader[reader.GetOrdinal(key)].ToString();
                return AddColumn(key, value);
            } catch { return false; }
        }

        public void AddByReaderAndColumnArray(SqlDataReader reader, string[] keys)
        {
            foreach(string key in keys)
            {
                try
                {
                    string value = reader[reader.GetOrdinal(key)].ToString();
                    AddColumn(key, value);
                }
                catch {}
            }
        }

        public void Clear()
        {
            item.Clear();
        }

        public void CopyEntriesFromDictionary(Dictionary<string, string> dict)
        {
            foreach(var key in dict.Keys)
            {
                AddColumn(key, dict[key]);
            }
        }

        public void CopyEntriesFromItem(Item toCopy)
        {
            var entries = toCopy.ListAllColumns();
            foreach(var entry in entries)
            {
                AddColumn(entry[0], entry[1]);
            }
        }

        public int Count()
        {
            return item.Count;
        }

        public string GetColumnValue(string key) 
        {
            if (item.TryGetValue(key, out string existingValue))
            {
                return existingValue;
            }
            return "";
        }

        public bool IsEmpty()
        {
            return item.Count == 0;
        }

        public List<string> ListColumnNames()
        {
            var list = new List<string>();
            foreach (var key in item.Keys)
            {
                list.Add(key);
            }
            return list;
        }

        public List<string[]> ListAllColumns()
        {
            var list = new List<string[]>();
            foreach (var key in item.Keys)
            {
                string[] entry = { key, item[key] };
                list.Add(entry);
            }
            return list;
        }

        public bool RemoveColumn(string key)
        {
            if(item.ContainsKey(key))
            {
                item.Remove(key);
                return true;
            }
            return false;
        }
    }
}
