using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class CustomButton : PictureBox
    {
        public CustomButton()
        {
            InitializeComponent();
        }

        private Image NormalImage;
        private Image HoverImage;

        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }
        }

        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }
        }

        private void CustomButton_MouseHover(object sender, EventArgs e)
        {
            this.Image = HoverImage;
        }

        private void CustomButton_MouseLeave(object sender, EventArgs e)
        {
            this.Image = NormalImage;
        }
    }
}
