using System.Collections.Generic;

public class Listing : Activity
{
    private List<string> _prompts;
    private int _numOfResponses;

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
        _numOfResponses = 0;
    }

    public List<string> GetPrompts()
    {
        return _prompts;
    }

    public int GetNumOfResponses()
    {
        return _numOfResponses;
    }
}
