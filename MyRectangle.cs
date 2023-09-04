using System;
using SplashKitSDK;
namespace ShapeDrawer
{
	public class MyRectangle : Shape
	{
        private int _width, _height;

		public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
		{ }

		public MyRectangle(Color clr, float x, float y, int w, int h) : base (clr)
		{
			X = x;
			Y = y;
			_width = w;
			_height = h;
		}

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Clr, X, Y, _width, _height);
        }

        public override void DrawOutline()
        {
            float outlineX = X - 2;
            float outlineY = Y - 2;
            int outlineWidth = _width + 4;
            int outlineHeight = _height + 4;
            SplashKit.FillRectangle(Color.Black, outlineX, outlineY, outlineWidth,outlineHeight);
        }

        public override bool IsAt(Point2D pt)
        {
            return pt.X <= (_width + X) && pt.X > X && pt.Y <= (_height + Y) && pt.Y > Y;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(_width);
            writer.WriteLine(_height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.ReadInteger();
            _height = reader.ReadInteger();
        }
    }
}

