using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesireFM
{
    class TransparentLabel:Label
    {
        private int _opacity = 125;
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this._opacity > 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(this._opacity, this.BackColor)),
                                         this.ClientRectangle);
            }
        }
    }
}
