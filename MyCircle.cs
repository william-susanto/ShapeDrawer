using System;
using SplashKitSDK;
namespace ShapeDrawer
{
	public class MyCircle : Shape
	{
		int _radius;

		public MyCircle() : this(Color.Blue, 0, 0, 50)
		{
		}

		public MyCircle(Color color, float x, float y, int radius)
		{
			Clr = color;
			X = x;
			Y = y;
			_radius = radius;
		}


		public override void Draw()
		{
			if (Selected) DrawOutline();

			SplashKit.FillCircle(Clr, X, Y, _radius);
		}

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }

		public override bool IsAt(Point2D pt)
		{
			return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }

        public int Radius
		{
			get => _radius;
			set => _radius = value;
		}
	}
}

