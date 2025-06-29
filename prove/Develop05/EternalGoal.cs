public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete
        return false;
    }

    public override string DisplayGoal()
    {
        return $"[∞] {_name} ({_description})";
    }

    public override string FormatToFile()
    {
        return $"EternalGoal~~{_name}~~{_description}~~{_points}";
    }
}
