using System;

class Program
{
    static void Main(string[] args)
    {


        // A program to compute Area of a Circle

        // Get radius from user
        Console.Write("Enter the radius of the circle: ");
        string text = Console.ReadLine();
        double radius = double.Parse(text);

        //compute area
        double area = Math.PI * radius * radius;

        //display area
        Console.WriteLine($"The area of the circle with radius {radius} is {area}");

        int x = 0;
        string s = "goodbye";
        float f = 3.14F;
        double d = 5.21;
        long n = 25;
        bool b = true;
        char c = 'a';

        Console.WriteLine($"Hello Sandbox World! {s}, {f}, {d}, {n}, {b}, {c}, {x}");
    }
}