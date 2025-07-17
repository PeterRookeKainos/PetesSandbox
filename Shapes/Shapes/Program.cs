namespace Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        // Create instances of different shapes and calculate their areas
        IShape triangle = new Triangle(3, 4, 5);
        var area = triangle.GetArea();
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
        
        // Create a factory instance and use it to create shapes
        ShapeFactory shapeFactory = new ShapeFactory();
        
        // Using the factory to create shapes and calculate their areas
        IShape shape = shapeFactory.CreateShape("triangle", 3, 4, 5);
        area = shape.GetArea();
        Console.WriteLine($"The area of the shape triangle created by factory is: {area}");
        
        shape = shapeFactory.CreateShape("rectangle", 5, 10);
        area = shape.GetArea();
        Console.WriteLine($"The area of the shape rectangle created by factory is: {area}");
        
        shape = shapeFactory.CreateShape("circle", 3);
        area = shape.GetArea();
        Console.WriteLine($"The area of the shape circle created by factory is: {area}");
        
        shape = shapeFactory.CreateShape("hexagon", 6);
        area = shape.GetArea();
        Console.WriteLine($"The area of the shape hexagon created by factory is: {area}");
    }
}