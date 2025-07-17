namespace Shapes;

public class Hexagon : IShape
{
    private int sideLength;

    public Hexagon(int sideLength)
    {
        this.sideLength = sideLength;
    }

    public int GetArea()
    {
        // Area of a regular hexagon = (3 * √3 / 2) * s^2
        return (int)(1.5 * Math.Sqrt(3) * sideLength * sideLength);
    }
}