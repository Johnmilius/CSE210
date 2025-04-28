using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        Console.WriteLine("");

        //Get magic Number
        Console.WriteLine("What is the magic number? ");
        string strMagicNumber = Console.ReadLine();
        int magicNumber = int.Parse(strMagicNumber);

        //Get loop for guess the end game when guessed right
        int userGuess = magicNumber + 1; // The plus one makes it not end the loop without guessing. 
        string strUserGuess = "";

        while (userGuess != magicNumber)
        {

            Console.WriteLine("What is your guess? ");
            strUserGuess = Console.ReadLine();
            userGuess = int.Parse(strUserGuess);

            //Check if guess equals the magic number
            if (magicNumber == userGuess)
            {
                Console.WriteLine($"You Guessed the Maigc number of {magicNumber}");
            }
            else
            {
                if (magicNumber < userGuess) { Console.WriteLine("Lower"); }
                else { Console.WriteLine("Higher"); }
            }

        }

    }
}