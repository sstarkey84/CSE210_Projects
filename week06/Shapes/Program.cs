using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square square1 = new Square("Red", 5);
        Rectangle rect1 = new Rectangle("Green", 6, 3);
        Circle cir1 = new Circle("Yellow", 8);

        shapes.Add(square1);
        shapes.Add(rect1);
        shapes.Add(cir1);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} {s.GetType().Name} has an area of {area:F0}.");
        }
    }
}