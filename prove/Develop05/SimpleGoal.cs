public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public void SetToComplete()
    {
        _isComplete = true;
    }

    public override string DisplayGoal()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    public override string FormatToFile()
    {
        return $"SimpleGoal~~{_name}~~{_description}~~{_points}~~{_isComplete}";
    }
}
