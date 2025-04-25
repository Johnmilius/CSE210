using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        Console.WriteLine("What is your grade? ");
        string gradeString = Console.ReadLine();
        int grade = int.Parse(gradeString);
        string letterGrade = "";
        bool passed = true;

        if (grade >= 90){
            letterGrade = "A";
            passed = true;
        }
        else if (grade >= 80 && grade < 90){
            letterGrade = "B";
            passed = true;
        }
        else if (grade >= 70 && grade < 80){
            letterGrade = "C";
            passed = true;
        }
        else if (grade >= 60 && grade < 70){
            letterGrade = "D";
            passed = false;
        }
        else if (grade < 60){
            letterGrade = "F";
            passed = false;
        }

        
        Console.WriteLine($"Your Grade is a {letterGrade}.");
        if (passed) {
            Console.WriteLine("You passed!");
        }
        else {
            Console.WriteLine("You failed.");
        }
    }
}