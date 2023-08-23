using System.Runtime.InteropServices;

namespace ShapeDrawer;
using System.Collections.Generic;
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
    {
        _shapes = new List<Shape>();
    }

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
        Console.WriteLine(_background.GetHashCode());

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