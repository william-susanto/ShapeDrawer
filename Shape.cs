using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        float _x, _y;
        private bool _selected;
        Color _color;

        public Shape() : this(Color.Yellow)
        { }

        public Shape(Color c)
        {
            _color = c;
        }

        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract bool IsAt(Point2D pt);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(_color);
            writer.WriteLine(_x);
            writer.WriteLine(_y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            _color = reader.ReadColor();
            _x = reader.ReadInteger();
            _y = reader.ReadInteger();
        }

        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float Y
        {
            get => _y;
            set => _y = value;
        }

        public Color Clr
        {
            get => _color;
            set => _color = value;
        }

        public bool Selected
        {
            get => _selected;
            set => _selected = value;
        }
    }
}


