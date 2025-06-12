using System.Collections.Generic;

public class Listing : Activity
{
    private List<string> _prompts;

    public Listing()
        : base("Listing", 0, "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string> {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void ListingActivity()
    {
        Console.WriteLine("List as many reponses you can to the following prompt: ");
        Console.WriteLine();

        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.WriteLine("You may begin:");

        int NumOfItems = 0;

        int durationInSeconds = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            NumOfItems++;
        }
        Console.WriteLine($"You listed {NumOfItems}!");
    }

    public List<string> GetPrompts()
    {
        return _prompts;
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

}
