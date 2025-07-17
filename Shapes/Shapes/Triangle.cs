using System;

namespace Shapes;

public class Triangle : IShape
{
    private int point1;
    private int point2;
    private int point3;
    
    public Triangle(int p1, int p2, int p3)
    {
        point1 = p1;
        point2 = p2;
        point3 = p2;
    }

    public int GetArea()
    {
        //Console.WriteLine($"{point1}, {point2}, {point3}");
        return point1 * point2 * point3;
    }
}