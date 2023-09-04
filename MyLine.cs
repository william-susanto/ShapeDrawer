using System;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyLine : Shape
    {

        private float _endX, _endY;

        public MyLine() : this(Color.Black, 0, 0)
        { }

        public MyLine(Color color, float x, float y)
        {
            X = x;
            Y = y;
            Clr = color;
        }

        public override void Draw()
        {
            if (Selected) DrawOutline();
            _endX = X + 150;
            _endY = Y;
            SplashKit.DrawLine(Clr, X, Y, _endX, _endY);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 10);
            SplashKit.DrawCircle(Color.Black, _endX, _endY, 10);
        }

        public override bool IsAt(Point2D pt)
        {
            return pt.X <= _endX && pt.X >= X && pt.Y <= Y+2 && pt.Y >= Y-2;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_endX);
            writer.WriteLine(_endY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _endX = reader.ReadSingle();
            _endY = reader.ReadSingle();
        }

        public float EndX
        {
            get => _endX;
            set => _endX = value;
        }

        public float EndY
        {
            get => _endY;
            set => _endY = value;
        }
    }
}

