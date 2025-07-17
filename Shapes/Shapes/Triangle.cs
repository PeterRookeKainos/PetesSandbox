using System;

namespace Shapes;

public class Triangle : IShape
{
    private double point1;
    private double point2;
    private double point3;
    
    public Triangle(double p1, double p2, double p3)
    {
        point1 = p1;
        point2 = p2;
        point3 = p3;
    }

    public double GetArea()
    {
        //Console.WriteLine($"{point1}, {point2}, {point3}");
        return point1 * point2 * point3;
    }
    
    public double getPoint1()
    {
        return point1;
    }
    public double getPoint2()
    {
        return point2;
    }
    public double getPoint3()
    {
        return point3;
    }
}