using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

        string userInput = "";

        Breathing test1 = new Breathing();
        test1.loadingScreen();

        while (userInput != "4")
        {
            Console.WriteLine("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. Quit");

            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();
        }

    }
}