class JournalEntry
{
    public String response;
    public DateTime date;
    public String prompt;

    public string getResponse()
    {
        String response = "";

        Console.Write($"{prompt}\n> ");
        response = Console.ReadLine();
        response += "";
        Console.WriteLine();
        return response;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {date} - Prompt: {prompt}");
        Console.WriteLine($"{response}");
        Console.WriteLine();
    }

    public string formatToFile()
    {
        String entry_str = "";
        entry_str += $"\n{date}~~{prompt}~~{response}";
        return entry_str;
    }
}