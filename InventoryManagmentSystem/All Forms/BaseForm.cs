using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem.All_Forms
{
    public partial class BaseForm : Form
    {
        protected int FontSize { get; } = 11;

        protected BaseForm() 
        {
            this.Load += (sender, e) =>
            {
                this.Font = new Font(this.Font.FontFamily, FontSize);
            };
        }
    }
}
