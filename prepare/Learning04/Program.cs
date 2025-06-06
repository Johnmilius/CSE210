using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");
        MathAssignment math = new MathAssignment("John Milius", "Fractions", "7.3", "8-19");
        Console.WriteLine(math.GetSummary());         // Output: John Milius - Fractions
        Console.WriteLine(math.GetHomeworkList());    // Output: Section 7.3 Problems 8-19

        Console.WriteLine();

        WritingAssignment writing = new WritingAssignment("John Milius", "Figurative", "The Forest");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());

    }
}