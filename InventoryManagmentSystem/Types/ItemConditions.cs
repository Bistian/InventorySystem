using System.Collections.Generic;

namespace InventoryManagmentSystem.Database.Types
{
    public static class ItemConditions
    {
        public const string New = nameof(New);
        public const string Used = nameof(Used);
        public const string Retired = nameof(Retired);

        // if you ever need to iterate them:
        public static readonly IReadOnlyList<string> All =
            new[] { New, Used, Retired };
    }
}
