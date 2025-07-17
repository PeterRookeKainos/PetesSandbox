namespace Shapes;

public class Hexagon : IShape
{
    private double sideLength;

    public Hexagon(double sideLength)
    {
        if (sideLength <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sideLength), "Side length must be a positive value.");
        }
        this.sideLength = sideLength;
    }

    public double GetArea()
    {
        // Area of a regular hexagon = (3 * √3 / 2) * s^2
        return (1.5 * Math.Sqrt(3) * sideLength * sideLength);
    }

    public double SideLength
    {
        get { return sideLength; }
        set { sideLength = value; }
    }
}