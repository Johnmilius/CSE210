public static class GameVisuals
{
    public static void LoadingSpinner(int times)
    {
        int timeSleep = 200;
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

    public static void WhiteSpaceCreater()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("");
        }
    }

}