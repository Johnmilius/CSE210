public class Activity
{
    private string _name;
    private int _duration;
    private string _description;

    public Activity(string name, int duration, string description)
    {
        _name = name;
        _duration = duration;
        _description = description;
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

    public void breathingCountDown(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

        public void loadingScreen()
    {
        Console.WriteLine("Get ready...");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("|");
            Thread.Sleep(300);
            Console.Write("\b \b");

            Console.Write($"\\");
            Thread.Sleep(300);
            Console.Write("\b \b");

            Console.Write("-");
            Thread.Sleep(300);
            Console.Write("\b \b");

            Console.Write("/");
            Thread.Sleep(300);
            Console.Write("\b \b");

        }

        Console.Write("Breath in...");
        this.breathingCountDown(3);

    }






}
