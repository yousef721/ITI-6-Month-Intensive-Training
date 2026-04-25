using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lap08
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            // Subscribe to mouse click event
            MouseMove += Form3_MouseMove;
        }

        private void Form3_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Get graphics object for the form
                Graphics g = CreateGraphics();
                g.FillEllipse(Brushes.Blue, e.X, e.Y, 100, 100);
            }
        }

    }
}
