using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        //Initialize new Journal Object
        Journal _journal = new Journal();

        int userInput = 0;
        while (userInput != 5)
        {
            Console.WriteLine("Please select one of the following choices.");
            Console.Write("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nWhat would you like to do? ");
            userInput = int.Parse(Console.ReadLine());

            if (userInput == 1) //WRITE
            {
                Console.WriteLine("User Selected WRITE");
                Console.WriteLine();

                //Grabs Random Prompt
                PromptGenerator prompts = new PromptGenerator();
                string randomPrompt = prompts.getRandomPrompt();

                //Craete a new Entry object
                JournalEntry _entry = new JournalEntry();
                _entry.prompt = randomPrompt;
                _entry.date = DateTime.Now;
                _entry.response = _entry.getResponse();

                //Append to Journal Object
                _journal.Entries.Add(_entry);
            }
            else if (userInput == 2) //DISPLAY
            {
                Console.WriteLine("User Selected DISPLAY");
                Console.WriteLine();

                foreach (JournalEntry entry in _journal.Entries)
                {
                    entry.DisplayEntry();
                }
            }
            else if (userInput == 3) //LOAD
            {
                Console.WriteLine("User Selected LOAD");
                Console.WriteLine();

                Console.Write("What is the File name to be loaded? ");
                String fileName = Console.ReadLine();
                _journal.loadFile(fileName);
            }
            else if (userInput == 4) //SAVE
            {
                Console.WriteLine("User Selected SAVE");
                Console.WriteLine();

                Console.Write("What would you like the File name to be? ");
                String fileName = Console.ReadLine();

                _journal.saveToFile(fileName);
            }
            else if (userInput == 5)
            {
                Console.WriteLine("User Selected QUIT, Ok Bye!");
                Console.WriteLine();

                break;
            }
            else
            {
                Console.WriteLine("Invalid input, please select a number between 1 and 5.");
            }
        }
    }
}