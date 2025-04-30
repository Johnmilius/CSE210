using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        Console.WriteLine("");

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userInput = 1;

        List<int> numbers = new List<int>();

        while (userInput != 0)
        {
            Console.Write("Enter Number: ");
            userInput = int.Parse(Console.ReadLine());

            numbers.Add(userInput);
        }

        numbers.RemoveAt(numbers.Count - 1);

        int sum = 0;
        int largestNumber = -1000;

        foreach (int num in numbers)
        {
            sum += num;
            if (num > largestNumber) { largestNumber = num; }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The Average is: {sum / numbers.Count}");
        Console.WriteLine($"The Largest Number is {largestNumber}");
    }
}