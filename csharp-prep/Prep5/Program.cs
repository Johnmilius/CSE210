using System;
using System.Formats.Asn1;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
        Console.WriteLine();

        DisplayMessage();
        string name = PromptUserName();
        Console.WriteLine($"Your name is {name}");

        int number = PromptUserNumber();
        Console.WriteLine($"Your number is: {number}");

        int squaredNum = SquareNumber(number);
        DisplayResult(squaredNum, name);

    }

    static void DisplayMessage(){
        Console.WriteLine("Welcome to the Program");
    }

    static string PromptUserName(){
        Console.Write("What is your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int SquareNumber(int num){
        int square = num * num;
        return square;
    }

    static int PromptUserNumber()
    {
        int number = 0;

        Console.Write("What is your favorite number? ");
        number = int.Parse(Console.ReadLine());

        return number;
    }

    static void DisplayResult(int num, string name){
        Console.WriteLine($"{name}, the sqaure of your favorite number is {num}.");
    }
}