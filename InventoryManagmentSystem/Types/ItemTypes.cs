using System.Collections.Generic;

namespace InventoryManagmentSystem.Database.Types
{
    public static class ItemTypes
    {
        public const string Boots = nameof(Boots);
        public const string Helmet = nameof(Helmet);
        public const string Jacket = nameof(Jacket);
        public const string Mask = nameof(Mask);
        public const string Pants = nameof(Pants);

        // if you ever need to iterate them:
        public static readonly IReadOnlyList<string> All =
            new[] { Boots, Helmet, Jacket, Mask, Pants };
    }
}
