using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_Ui
{
    public class BButton : Button
    {
        //Fields
        private int _borderSize = 0;
        private int _borderRadius = 20;
        private Color _borderColor = Color.PaleVioletRed;

        public BButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = Color.MediumSlateBlue;
            ForeColor = Color.White;
            Resize += new EventHandler(Button_Resize);
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (_borderRadius > Height)
            {
                _borderRadius = Height;
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -_borderSize, -_borderSize);
            int smoothSize = 2;
            if (_borderSize > 0)
            {
                smoothSize = _borderSize;
            }

            if (_borderRadius > 2) // Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, _borderRadius))
                {
                    GraphicsPath pathBorder = GetFigurePath(rectBorder, _borderRadius - _borderSize);
                    Pen penSurface = new Pen(Parent.BackColor, smoothSize);
                    Pen penBorder = new Pen(_borderColor, _borderSize);

                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    // Button surface
                    Region = new Region(pathSurface);
                    // Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    // Button border
                    if (_borderSize >= 1)
                    {
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else // Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                // Button surface
                Region = new Region(rectSurface);
                // Button border
                if (_borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(_borderColor, _borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2f;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        [Category("B Code")]
        public int BorderSize
        {
            get { return _borderSize; }
            set
            {
                if (value >= _borderRadius && _borderRadius > 0)
                {
                    _borderSize = _borderRadius - 1;
                }
                else
                {
                    _borderSize = value;
                }
                Invalidate();
            }
        }

        [Category("B Code")]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                if (value <= Height)
                {
                    _borderRadius = value;
                }
                else
                {
                    _borderRadius = Height;
                }
                Invalidate();
            }
        }

        [Category("B Code")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public Color BackgroundColor
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        [Category("B Code")]
        public Color TextColor
        {
            get { return ForeColor; }
            set { ForeColor = value; }
        }
    }
}
