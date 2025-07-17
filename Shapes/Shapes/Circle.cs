namespace Shapes;

public class Circle : IShape
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public int GetArea()
    {
        // Area of a circle = π * r^2
        return (int)(Math.PI * radius * radius);
    }
}