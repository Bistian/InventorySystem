using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace InventoryManagmentSystem
{
    public class CustomDateTimePicker : DateTimePicker
    {
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int DTM_FIRST = 0x1000;
        private const int DTM_DROPDOWN = DTM_FIRST + 2;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                // Open the dropdown on left button click
                SendMessage(Handle, DTM_DROPDOWN, IntPtr.Zero, IntPtr.Zero);
            }

            base.WndProc(ref m);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    }
}
