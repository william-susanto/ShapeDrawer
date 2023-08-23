using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private int _width;
        private int _height;
        private bool _selected;

        public Shape()
        {
            Color = Color.Green;
            X = 0.0F;
            Y = 0.0F;
            _width = 100;
            _height = 100;
        }

        public void Draw()
        {
            if (_selected)
            {
                DrawOutline();
            }

            SplashKit.FillRectangle(Color, X, Y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            if (pt.X <= (_width + X) && pt.X > X && pt.Y <= (_height + Y) && pt.Y > Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DrawOutline()
        {
            float outlineX = X - 2;
            float outlineY = Y - 2;
            int outlineWidth = _width + 4;
            int outlineHeight = _height + 4;

            SplashKit.FillRectangle(Color.Black, outlineX, outlineY, outlineWidth, outlineHeight);
        }

        public Color Color { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
    }
}


