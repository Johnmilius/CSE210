using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
        int x;
        x = 5;
        Console.WriteLine(x);
        Console.Write("There will be no new line after this. ");
        Console.WriteLine("This is on the same line");
        Console.WriteLine("");


        Console.Write("What is your First Name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your Last Name? ");
        string lastName = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine("Your name is " + lastName + ", " + firstName + " " + lastName + ".");
    }
}