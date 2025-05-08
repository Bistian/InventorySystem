using System.Collections.Generic;

namespace InventoryManagmentSystem.Database.Types
{
    public static class BusinessModels
    {
        public const string Rent = nameof(Rent);
        public const string Sell = nameof(Sell);

        // if you ever need to iterate them:
        public static readonly IReadOnlyList<string> All =
            new[] { Rent, Sell };
    }
}
