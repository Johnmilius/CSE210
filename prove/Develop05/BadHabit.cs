public class BadHabit : Goal
{
    public BadHabit(string name, string description, int points) : base(name, description, points)
    { }

    public override bool IsComplete()
    {
        return false;
    }

    public override string DisplayGoal()
    {
        return $"[ :( ] {_name} ({_description})";
    }

    public override string FormatToFile()
    {
        return $"BadHabit~~{_name}~~{_description}~~{_points}";
    }
}