using Newtonsoft.Json;

namespace InventoryManagmentSystem
{
    public class SettingsUser
    {
        [JsonProperty("FontTitleSize")]
        public int FontTitleSize { get; set; } = 16;
        [JsonProperty("FontTextSize")]
        public int FontTextSize { get; set; } = 12;
    }
}
