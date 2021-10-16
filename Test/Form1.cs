using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            RectangleInflateTest2(e);
        }

        private void RectangleInflateTest2(PaintEventArgs e)
        {
            // Create a rectangle.
            Rectangle rect = new Rectangle(100, 100, 50, 50);

            // Draw the uninflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Black, rect);

            // Set up the inflate size.
            Size inflateSize = new Size(10, 0);

            // Call Inflate.
            rect.Inflate(inflateSize);

            // Draw the inflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Red, rect);

            Rectangle r = Rectangle.Inflate(rect, -10, -10);
            e.Graphics.DrawRectangle(Pens.Blue, r);

        }

        private void bButton4_MouseHover(object sender, EventArgs e)
        {
            bButton4.ForeColor = Color.White;
        }

        private void bButton4_MouseLeave(object sender, EventArgs e)
        {
            bButton4.ForeColor = bButton4.BorderColor;
        }
    }
}
