public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _maxTimesCompleted;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, string points, int maxTimesCompleted, int bonusPoints)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _maxTimesCompleted = maxTimesCompleted;
        _bonusPoints = bonusPoints;
    }

    public void RecordEvent()
    {
        if (_timesCompleted < _maxTimesCompleted)
        {
            _timesCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _maxTimesCompleted;
    }

    public override void DisplayGoal()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_name} ({_description}) -- Completed: {_timesCompleted}/{_maxTimesCompleted}");
    }
}
