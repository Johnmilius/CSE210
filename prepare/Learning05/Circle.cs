using System;

public class Circle : Shape
{
    private int _radius;

    public Circle(string color, int radius)
        : base(color)
    {
        _radius = radius;
    }

    public override int GetArea()
    {
        // Area = π * r^2, rounded to nearest int
        return (int)Math.Round(Math.PI * _radius * _radius);
    }
}
