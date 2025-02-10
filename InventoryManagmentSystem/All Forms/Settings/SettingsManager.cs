using System;
using System.IO;
using System.Linq;
using InventoryManagmentSystem.Properties;
using Newtonsoft.Json;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace InventoryManagmentSystem
{
    internal class SettingsManager
    {
        private readonly string _settingsFilePath;
        private JObject _settingsJson;
        public event EventHandler SettingsChanged; // Event for notifying changes

        public SettingsManager()
        {
            _settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");
            LoadSettings();
        }

        public T GetSetting<T>(string key, T defaultValue = default)
        {
            JToken token = _settingsJson.SelectToken(key);
            return token != null ? token.ToObject<T>() : defaultValue;
        }

        public void LoadSettings()
        {
            if (File.Exists(_settingsFilePath))
            {
                string json = File.ReadAllText(_settingsFilePath);
                _settingsJson = JObject.Parse(json);
            }
            else
            {
                _settingsJson = new JObject();
            }
        }

        public void SaveSettings()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_settingsJson, Formatting.Indented);
                File.WriteAllText(_settingsFilePath, json);
                SettingsChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}");
            }
        }

        public void SetSetting<T>(string key, T value)
        {
            // Split the key by '.' because of the json's format
            var parts = key.Split('.');

            // Start at the root JObject
            JObject current = _settingsJson;

            // Traverse or create nested objects for all but the last key segment.
            for (int i = 0; i < parts.Length - 1; i++)
            {
                var part = parts[i];
                // If the part doesn't exist or isn't an object, create a new JObject for it.
                if (current[part] == null || current[part].Type != JTokenType.Object)
                {
                    current[part] = new JObject();
                }
                current = (JObject)current[part];
            }

            // Set the final property
            current[parts.Last()] = JToken.FromObject(value);
        }
    }

}

