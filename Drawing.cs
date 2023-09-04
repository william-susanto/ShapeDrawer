using System.Runtime.InteropServices;

namespace ShapeDrawer;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;

public class Drawing
{
    private readonly List<Shape> _shapes;
    private Color _background;

    public Drawing(Color background)
    {
        _shapes = new List<Shape>();
        _background = background;
    }

    public Drawing() : this(Color.White)
    { }

    public void SelectShapesAt(Point2D pt)
    {
        foreach (Shape s in _shapes)
        {
            s.Selected = s.IsAt(pt);
        }
    }

    public void Draw()
    {
        SplashKit.ClearScreen(_background);

        foreach (Shape s in _shapes)
        {
            s.Draw();
        }
    }

    public void AddShape(Shape s)
    {
        _shapes.Add(s);
    }

    public void RemoveShape(Shape s)
    {
        _shapes.Remove(s);
    }

    public void Save(string fp)
    {
        StreamWriter writer = new StreamWriter(fp);

        try
        {
            writer.WriteColor(_background);
            writer.WriteLine(ShapeCount);

            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
        }
        finally
        {
            writer.Close();
        }
    }

    public void Load(string fp)
    {
        StreamReader reader = new StreamReader(fp);

        try
        {


            Shape s;
            _background = reader.ReadColor();
            int count = reader.ReadInteger();

            for (int i = 0; i < count; i++)
            {
                string kind = reader.ReadLine();

                switch (kind)
                {
                    case "Rectangle":
                        s = new MyRectangle();
                        break;

                    case "Circle":
                        s = new MyCircle();
                        break;
                    case "Line":
                        s = new MyLine();
                        break;
                    default:
                        throw new InvalidCastException("Unknown shape kind: " + kind);
                }

                s.LoadFrom(reader);
                _shapes.Add(s);
            }
        }
        finally
        {
            reader.Close();
        }
    }

    public int ShapeCount
    {
        get => _shapes.Count;
    }

    public Color Background
    {
        get
        {
            return _background;
        }
        set
        {
            _background = value;
        }
    }

    public List<Shape> SelectedShapes
    {
        get
        {
            List<Shape> result = new List<Shape>();
            foreach (Shape s in _shapes)
            {
                if (s.Selected)
                {
                    result.Add(s);
                }
            }
            return result;
        }
    }
}