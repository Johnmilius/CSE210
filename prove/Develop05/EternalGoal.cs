public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete
        return false;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[∞] {_name} ({_description})");
    }
}
