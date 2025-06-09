using System.Collections.Generic;

public class Listing : Activity
{
    private List<string> _prompts;
    private int _numOfResponses;

    public Listing(string name, string beginningMessage, string endMessage, string description)
        : base(name, beginningMessage, endMessage, description)
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
    
}
