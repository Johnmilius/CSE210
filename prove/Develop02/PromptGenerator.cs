class PromptGenerator{
    public List<String> Prompts = new List<String>{
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn today that surprised me?",
        "What act of kindness did I witness or perform today?",
        "What challenge did I overcome today?",
        "What made me smile today?",
        "What is something I am grateful for today?",
        "How did I help someone today?",
        "What was the most peaceful moment of my day?",
        "What is one thing I want to remember about today?",
        "What did I do today that brought me closer to my goals?",
        "What is something I would like to improve for tomorrow?"
    };

    public string getRandomPrompt(){
        Random random = new Random();
        string randomPrompt = Prompts[random.Next(Prompts.Count)];
        return randomPrompt;
    }
}