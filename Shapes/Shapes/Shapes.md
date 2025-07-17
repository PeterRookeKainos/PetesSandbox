## Introduction

Demonstrate how C# can be used for Object Oriented Programming (OOP).

## The Challenge

### 1. Create a hierarchy of shape types with an abstract parent class

Write a console application that declares an abstract class called `Shape` with
a method called `GetArea()`. Then create subclasses of `Shape` for the following shapes.

* Triangle
* Rectangle
* Circle
* Hexagon

Each of these subclasses overrides the `GetArea()` method to calculate the area of
the matching shape.

The `GetArea()` method can output an area with a decimal component.

The class constructors of the subclasses can accept whatever parameters are necessary to
calculate the area of the shape represented by the subclass.

Write a console application that instantiates an object for each of the subclasses and
prints its area. You can hardcode parameters for the class constructors.

### 2. Replace the abstract Shape class with an interface

Replace the `Shape` abstract class with an `IShape` interface. The `IShape` interface
has a single method called `GetArea()`. 

Update your console application and confirm that it still successfully executes with no
exceptions.

## Useful Links

[Inheritance](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance)

[Abstract and Sealed Classes and Class Members](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)

[Interfaces - define behavior for multiple types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces)