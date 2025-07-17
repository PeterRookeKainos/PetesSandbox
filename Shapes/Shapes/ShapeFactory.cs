namespace Shapes;

/*  
 * The factory class will implement the IShape interface, but it will not implement the GetArea method.
 * The GetArea method will be implemented in the concrete classes that inherit from the IShape interface.
 * Reference: https://refactoring.guru/design-patterns/factory-method 
 * "Every problem in programming can be solved with a layer of abstraction, except for the problem of too many layers of abstraction."
 */

public class ShapeFactory 
{
    
    // Factory method to create a shape based on type
    public IShape CreateShape(string shapeType, params double[] dimensions)
    {
        return shapeType.ToLower() switch
        {
            "triangle" => new Triangle(dimensions[0], dimensions[1], dimensions[2]),
            "rectangle" => new Rectangle(dimensions[0], dimensions[1]),
            "circle" => new Circle(dimensions[0]),
            "hexagon" => new Hexagon(dimensions[0]),
            _ => throw new ArgumentException("Invalid shape type")
        };
    }
}