using System;

public class Stretching : Activity
{
    private List<string> _stretches;
    public Stretching()
        : base("Stretching", 0, "This activity will help you relax and improve flexibility by guiding you through a series of gentle stretches. Focus on your body and breathing as you stretch.")
    {
        _stretches = new List<string> {
            "Touch your toes",
            "Reach for the sky",
            "Shoulder shrug",
            "Neck tilt left",
            "Neck tilt right",
            "Arm circles",
            "Wrist shake",
            "Ankle rolls",
            "Side stretch left",
            "Side stretch right",
            "Leg shake",
            "Knee hug",
            "Stand tall",
            "Sit and reach",
            "Gentle back bend"
        };
    }

    public void StretchingActivity()
    {
        Console.WriteLine("Let's begin your stretching session!");
        Console.WriteLine("Press enter to Begin: ");
        Console.ReadLine();

        int durationInSeconds = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);

        while (DateTime.Now < endTime)
        {
            // Pick a random stretch for each round
            Console.Write($"Stretch and hold: {GetRandomStretch()}...");
            CountDown(5);
            Console.WriteLine();

            Console.Write("Release and relax...");
            CountDown(5);
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public string GetRandomStretch()
    {
        Random rand = new Random();
        int index = rand.Next(_stretches.Count);
        return _stretches[index];
    }
    
}
