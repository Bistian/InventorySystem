using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.C__Files
{
    public class ComboBoxItem
    {
            public string Name
            {
                get; set;
            }
            public string ID
            {
                get; set;
            }  // Change ID from int to Guid

            public ComboBoxItem(string id, string name)
            {
                ID = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name; // Ensures only "Name" is displayed in the ComboBox
            }
        
    }
}
