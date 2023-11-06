using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");
        Square square = new Square("red", 2);
        

        Rectangle rectangle = new Rectangle("blue", 2, 4);
        

        Circle circle = new Circle("green", 2);
        

        List<Shape> shapes = new List<Shape>();
        shapes.Add(circle);
        shapes.Add(rectangle);
        shapes.Add(square);

        foreach (var shape in shapes)
        {
            System.Console.WriteLine(shape.GetColor());
            System.Console.WriteLine(shape.GetArea());
        }
    }
}