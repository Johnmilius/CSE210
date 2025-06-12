public class Breathing : Activity
{
    public Breathing()
        : base("Breathing", 0, "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {

    }

    public void breathingActivity()
    {
        int durationInSeconds = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breath in... ");
            CountDown(4);
            Console.WriteLine();
            Console.Write("Now Breath out... ");
            CountDown(6);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
