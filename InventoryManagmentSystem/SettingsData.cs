using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem
{
    internal class SettingsData
    {
        private static SettingsData instance;
        private string filePath;
        /// <summary>
        /// If a variable has get or set, it will be added to the config file. 
        /// Add variables that are not to be tracked here.
        /// </summary>
        private Dictionary<string, bool> untrackedProperties = new Dictionary<string, bool> {
            // Add more variables to be left out of the config file.
            {"Instance", true },
        };
        /// <summary>
        /// For a variable to be written on the config file, it needs to be here with its default value.
        /// </summary>
        private Dictionary<string, string> defaultData = new Dictionary<string, string>
        {
            // Add more variables here
            { "dueDaysFromToday", "14" },
            { "fontSize", "12" },
        };
        /// <summary>
        /// Current values of settings' variables.
        /// </summary>
        public Dictionary<string, string> currentData;
        /// <summary>
        /// Used to filter items based on their due date in relation to today.
        /// </summary>
        public int dueDaysFromToday { get; set; }
        /// <summary>
        /// Size of the letters.
        /// </summary>
        public float fontSize { get; set; }
        
        public static SettingsData Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SettingsData();
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string fileName = "config.txt";
                    instance.filePath = Path.Combine(baseDirectory, fileName);
                    instance.UpdateFieldsUsingTextFile();
                }
                return instance;
            }
        }

        private bool CreateSettingsFile()
        {
            try
            {
                // Create or overwrite the text file at the specified path
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    // Write the data in the specified format
                    foreach (var kvp in defaultData)
                    {
                        writer.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                }
                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        private Dictionary<string, string> ReadTextFile()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            try
            {
                // Read the text file and parse the lines
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new char[] { ':' }, 2, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        string variableName = parts[0].Trim();
                        string variableValue = parts[1].Trim();
                        data[variableName] = variableValue;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return data;
        }
       
        public void RevertToDefault()
        {
            currentData = defaultData;
            UpdateSettingsFile(defaultData);
        }

        public void SaveChanges()
        {
            try
            {
                UpdateCurrentData();
                UpdateSettingsFile(currentData);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateCurrentData()
        {
            Dictionary<string, string> updatedData = new Dictionary<string, string>();
            Type type = typeof(SettingsData);
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (untrackedProperties.ContainsKey(property.Name))
                {
                    continue;
                }
                string propertyName = property.Name;
                object propertyValue = property.GetValue(this);
                updatedData[propertyName] = propertyValue.ToString();
            }
            currentData = updatedData;
        }

        /// <summary>
        /// Goes through all variables of SettingsData and set their values based on the given dictionary.
        /// </summary>
        /// <param name="data">Dictionary with variable names and values.</param>
        private void UpdateFields(Dictionary<string, string> data)
        {
            Type type = typeof(SettingsData);
            foreach (var kvp in data)
            {
                PropertyInfo property = type.GetProperty(kvp.Key);
                if (property != null)
                {
                    object value = Convert.ChangeType(kvp.Value, property.PropertyType);
                    property.SetValue(this, value);
                }
            }
        }
        
        private void UpdateFieldsUsingTextFile()
        {
            if (!File.Exists(filePath))
            {
                if (!CreateSettingsFile())
                {
                    return;
                }
            }

            // TODO: Update existing file if new fields are added.

            currentData = ReadTextFile();
            UpdateFields(currentData);
        }

        private void UpdateSettingsFile(Dictionary<string, string> data)
        {
            try
            {
                // Create or overwrite the text file at the specified path
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    // Write the data in the specified format
                    foreach (var kvp in data)
                    {
                        writer.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                }

                Console.WriteLine("Text file updated with new data.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
