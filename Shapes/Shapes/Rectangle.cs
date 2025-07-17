namespace Shapes;

public class Rectangle : IShape
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int GetArea()
    {
        return width * height;
    }
}