using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace B_Ui
{
    public class BPanelDropdown : Panel
    {
        private Timer _timer;
        private Button _buttonMenu;
        private bool _isCollapsed = true;

        private bool _setup = false;

        private Image _menuImage;

        private string _menuText = "Button Menu";
        private int _menuHeight = 50;
        private float _menuFontSize = 12f;

        private Color _menuBgColor = Color.Navy;
        private Color _menuForeColor = Color.White;
        private Image _menuImageDown;
        private Image _menuImageUp;

        public BPanelDropdown()
        {
            _buttonMenu = new Button();
            _buttonMenu.Name = "Menu";
            _buttonMenu.Dock = DockStyle.Top;
            _buttonMenu.FlatStyle = FlatStyle.Flat;
            _buttonMenu.FlatAppearance.BorderSize = 0;
            _buttonMenu.TextImageRelation = TextImageRelation.TextBeforeImage;
            _buttonMenu.TextAlign = ContentAlignment.MiddleRight;
            _buttonMenu.Click += ButtonMenu_Click;

            this.Controls.Add(_buttonMenu);

            Panel panel = new Panel()
            {
                Name = "layout1",
                Dock = DockStyle.Fill
            };

            this.Controls.Add(panel);


            _timer = new Timer();
            _timer.Interval = 15;
            _timer.Tick += _timer_Tick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!_setup)
            {
                List<Control> subMenu = new List<Control>();
                List<Control> menu = new List<Control>();

                foreach (Control item in Controls)
                {
                    if (!item.Name.Equals("Menu") && !item.Name.Equals("layout1"))
                    {
                        subMenu.Add(item);
                    }
                    else
                    {
                        menu.Add(item);
                    }
                }

                //subMenu.Reverse();
                subMenu.AddRange(menu);
                Controls.Clear();


                foreach (var item in subMenu)
                {
                    Controls.Add(item);
                }

                //_buttonMenu.Image = _menuImageDown;

                _setup = true;
            }

            _buttonMenu.Image = _menuImage != null ? _menuImage : _menuImageDown;

            _buttonMenu.BackColor = _menuBgColor;
            _buttonMenu.ForeColor = _menuForeColor;
            _buttonMenu.Text = _menuText;
            _buttonMenu.Height = _menuHeight;
            _buttonMenu.Font = new Font(this.Font.Name, _menuFontSize, FontStyle.Bold);

            base.OnPaint(e);
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_isCollapsed)
            {
                _buttonMenu.Image = _menuImageUp;
                _menuImage = _menuImageUp;

                this.Height += 10;
                if (this.Size == this.MaximumSize)
                {
                    _timer.Stop();
                    _isCollapsed = false;
                }
            }
            else
            {
                _buttonMenu.Image = _menuImageDown;
                _menuImage = _menuImageDown;

                this.Height -= 10;
                if (this.Size == this.MinimumSize)
                {
                    _timer.Stop();
                    _isCollapsed = true;
                }
            }
        }

        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            _timer.Start();
        }

        

        [Category("B Code")]
        public string MenuText
        {
            get { return _menuText; }
            set
            {
                _menuText = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public int MenuHeight
        {
            get { return _menuHeight; }
            set
            {
                _menuHeight = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public float MenuFontSize
        {
            get { return _menuFontSize; }
            set
            {
                _menuFontSize = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public Color MenuBgColor
        {
            get { return _menuBgColor; }
            set
            {
                _menuBgColor = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public Color MenuForeColor
        {
            get { return _menuForeColor; }
            set
            {
                _menuForeColor = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public Image MenuImageDown
        {
            get { return _menuImageDown; }
            set
            {
                _menuImageDown = value;
                Invalidate();
            }
        }

        [Category("B Code")]
        public Image MenuImageUp
        {
            get { return _menuImageUp; }
            set
            {
                _menuImageUp = value;
                Invalidate();
            }
        }

    }
}
