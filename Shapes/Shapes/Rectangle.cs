namespace Shapes;

public class Rectangle : IShape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Width and height must be positive values.");
        }
        this.width = width;
        this.height = height;
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }
    
    public double Height 
    {
        get { return height; }
        set { height = value; }
    }

    public double GetArea()
    {
        return width * height;
    }
}