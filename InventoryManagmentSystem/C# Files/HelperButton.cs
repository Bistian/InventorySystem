using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagmentSystem.C__Files
{
    internal class HelperButton
    {
        public static void ScaleFont(Button b, float scale)
        {
            b.Font = new Font(b.Font.FontFamily, b.Font.Size * scale, b.Font.Style);
        }

        public static void ScaleSize(Button b, float scaleW, float scaleH)
        {
            b.Size = new Size((int)(b.Size.Width * scaleW), (int)(b.Size.Height * scaleH));
        }
    }
}
