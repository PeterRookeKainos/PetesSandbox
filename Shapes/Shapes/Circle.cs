namespace Shapes;

public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be negative.");
        }
        this.radius = radius;
    }

    public double GetArea()
    {
        // Area of a circle = π * r^2
        return (Math.PI * radius * radius);
    }
    
    // create getter for radius
    public double GetRadius()
    {
        return radius;
    }
    
    // create setter for radius
    public void SetRadius(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be negative.");
        }
        this.radius = radius;
    }
}