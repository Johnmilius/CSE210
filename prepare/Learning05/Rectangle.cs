public class Rectangle : Shape
{
    private int _length;
    private int _width;

    public Rectangle(string color, int length, int width)
        : base(color)
    {
        _length = length;
        _width = width;
    }

    public override int GetArea()
    {
        return _length * _width;
    }
}
