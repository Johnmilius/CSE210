using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (input == "1")
            {
                // Create New Goal logic here
                Console.WriteLine("[Create New Goal]");
            }
            else if (input == "2")
            {
                // List Goals logic here
                Console.WriteLine("[List Goals]");
            }
            else if (input == "3")
            {
                // Save Goals logic here
                Console.WriteLine("[Save Goals]");
            }
            else if (input == "4")
            {
                // Load Goals logic here
                Console.WriteLine("[Load Goals]");
            }
            else if (input == "5")
            {
                // Record Event logic here
                Console.WriteLine("[Record Event]");
            }
            else if (input == "6")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
            Console.WriteLine();
        }
    }
}