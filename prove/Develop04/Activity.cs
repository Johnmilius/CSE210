public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, int duration, string description)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayActivityIntro()
    {
        Console.WriteLine($"Welcome to the {GetName()} Activity");
        Console.WriteLine();

        Console.WriteLine(GetDescription());
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        int seconds = int.Parse(Console.ReadLine());
        SetDuration(seconds);

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        LoadingSpinner(2);

        Console.WriteLine();
    }

    public void DisplayActivityOutro()
    {
        Console.WriteLine("Well Done!");
        Console.WriteLine();

        LoadingSpinner(2);

        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");

        LoadingSpinner(2);

    }

    public void CountDown(int count)
    {
        for (int i = count; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void LoadingSpinner(int times)
    {
        int timeSleep = 500;
        for (int i = 0; i < times; i++)
        {
            Console.Write("|");
            Thread.Sleep(timeSleep);
            Console.Write("\b \b");

            Console.Write($"\\");
            Thread.Sleep(timeSleep);
            Console.Write("\b \b");

            Console.Write("-");
            Thread.Sleep(timeSleep);
            Console.Write("\b \b");

            Console.Write("/");
            Thread.Sleep(timeSleep);
            Console.Write("\b \b");

        }
    }
}
