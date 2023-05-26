using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public class GradientFlowLayoutPanel : FlowLayoutPanel
    {
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
        bool doOnce = true;
        protected override void OnPaint(PaintEventArgs e)
        {
                using (var brush = new LinearGradientBrush(ClientRectangle, StartColor, EndColor, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }

                base.OnPaint(e);
        }
    }
}
