namespace Shapes;

// This interface defines a contract for shapes, requiring any implementing class to provide a method to calculate the area.
// The GetArea method returns an integer representing the area of the shape.
// This allows for polymorphism, where different shapes can be treated uniformly while still providing their specific area calculations.
// Example implementing classes would include Circle, Rectangle, Triangle, etc., each providing their own logic for calculating the area.

public interface IShape
{
    public double GetArea();
}