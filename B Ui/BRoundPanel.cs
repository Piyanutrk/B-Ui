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
    public class BRoundPanel : Panel
    {

        private Color _FillColor = Color.White;
        private Color _fillLineColor = Color.Black;

        private int _radius = 10;
        private int _fill_X = 6;
        private int _fill_Y = 6;
        private FillType _fillType = FillType.DrawRoundedRectangle;
        private float _fillLineWidth = 2.0f;


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.FillRoundedRectangle(new SolidBrush(Color.White), 10, 10, 10, 10, 10);
            //g.FillRoundedRectangle(new SolidBrush(Color.White), 10, 10, this.Width - 40, this.Height - 60, 10);
            //SolidBrush brush = new SolidBrush(
            //    Color.White
            //    );
            //g.FillRoundedRectangle(brush, 12, 12, this.Width - 44, this.Height - 64, 10);
            //g.DrawRoundedRectangle(new Pen(ControlPaint.Light(Color.Red, 0.00f)), 6, 6, this.Width-12, this.Height-12, 10);
            //g.DrawRoundedRectangle(new Pen(ControlPaint.Light(Color.White, 0.00f)), 12, 12, this.Width - 44, this.Height - 64, 10);            
            //g.FillRoundedRectangle(new SolidBrush(Color.White), 12, 12 + ((this.Height - 64) / 2), this.Width - 44, (this.Height - 64) / 2, 10);

            switch (_fillType)
            {
                case FillType.FillRoundedRectangle:
                    g.FillRoundedRectangle(new SolidBrush(_FillColor), _fill_X, _fill_Y,
                        this.Width - (_fill_X * 2), this.Height - (_fill_Y * 2), _radius);
                    break;
                case FillType.DrawRoundedRectangle:
                    g.DrawRoundedRectangle(new Pen(ControlPaint.Light(_fillLineColor, 0.00f), _fillLineWidth),
                        _fill_X, _fill_Y, this.Width - (_fill_X * 2), this.Height - (_fill_Y * 2), _radius);
                    g.FillRoundedRectangle(new SolidBrush(_FillColor), _fill_X + _fillLineWidth / 2, _fill_Y + _fillLineWidth / 2,
                        this.Width - ((_fill_X + _fillLineWidth / 2) * 2), this.Height - ((_fill_Y + _fillLineWidth / 2) * 2),
                        _radius - _fillLineWidth / 2);
                    break;
                default:
                    break;
            }
        }

        [Category("B Code")]
        public float FillLineWidth
        {
            get { return _fillLineWidth; }
            set
            {
                _fillLineWidth = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public Color FillLineColor
        {
            get { return _fillLineColor; }
            set
            {
                _fillLineColor = value;
                Invalidate();
            }
        }


        [Category("B Code")]
        public Color FillColor
        {
            get => _FillColor;
            set
            {
                _FillColor = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public int FillRadius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public int Fill_X
        {
            get { return _fill_X; }
            set
            {
                _fill_X = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public int Fill_Y
        {
            get { return _fill_Y; }
            set
            {
                _fill_Y = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public FillType Fill_Type
        {
            get { return _fillType; }
            set
            {
                _fillType = value;
                Invalidate();
            }
        }
    }

    public enum FillType { FillRoundedRectangle, DrawRoundedRectangle };

}
