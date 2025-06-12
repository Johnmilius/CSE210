using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

        string userInput = "";
        while (userInput != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. Start stretching activity\n   5. Quit");

            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();
            Console.WriteLine();

            if (userInput == "1")
            {
                Console.WriteLine();
                // Code to start breathing activity
                Console.WriteLine("Starting breathing activity...");
                Console.WriteLine();

                Breathing breathing1 = new Breathing();

                breathing1.DisplayActivityIntro();
                breathing1.BreathingActivity();
                breathing1.DisplayActivityOutro();
            }
            else if (userInput == "2")
            {
                Console.WriteLine();
                // Code to start reflecting activity
                Console.WriteLine("Starting reflecting activity...");
                Console.WriteLine();

                Reflection reflection1 = new Reflection();

                reflection1.DisplayActivityIntro();
                reflection1.ReflectionActivity();
                reflection1.DisplayActivityOutro();

            }
            else if (userInput == "3")
            {
                Console.WriteLine();
                // Code to start listing activity
                Console.WriteLine("Starting listing activity...");
                Console.WriteLine();

                Listing listing1 = new Listing();

                listing1.DisplayActivityIntro();
                listing1.ListingActivity();
                listing1.DisplayActivityOutro();

            }
            else if (userInput == "4")
            {
                Console.WriteLine();
                // Code to start stretching activity
                Console.WriteLine("Starting stretching activity...");
                Console.WriteLine();

                Stretching stretching1 = new Stretching();

                stretching1.DisplayActivityIntro();
                stretching1.StretchingActivity();
                stretching1.DisplayActivityOutro();
            }
            else if (userInput == "5")
            {
                Console.WriteLine("Quitting program. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please select 1, 2, 3, 4, or 5.");
            }
        }
    }
}