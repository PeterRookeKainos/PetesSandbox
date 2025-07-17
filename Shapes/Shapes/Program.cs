namespace Shapes;

// create a class to run the code
public class Program
{
    public static void Main(string[] args)
    {
        IShape triangle = new Triangle(3, 4, 5);
        int area = triangle.GetArea();
        Console.WriteLine($"The area of the triangle is: {area}");
        
        IShape rectangle = new Rectangle(5, 10);
        area = rectangle.GetArea();
        Console.WriteLine($"The area of the rectangle is: {area}");
        
        IShape circle = new Circle(3);
        area = circle.GetArea();
        Console.WriteLine($"The area of the circle is: {area}");
        
        IShape hexagon = new Hexagon(6);
        area = hexagon.GetArea();
        Console.WriteLine($"The area of the hexagon is: {area}");
    }
}






/*
public class RunIt
{
    public static String Main()
    {
        RunIt.Main();
    }  
}
*/