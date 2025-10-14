using System;

class Program
{
    static void Main(string[] args)
    {
        var shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5));       // side = 5
        shapes.Add(new Rectangle("Blue", 4, 6)); // width = 4, height = 6
        shapes.Add(new Circle("Green", 3));     // radius = 3
        shapes.Add(new Square("Yellow", 2.5));  // side = 2.5

        Console.WriteLine("Shapes and their areas:");
        Console.WriteLine();

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}