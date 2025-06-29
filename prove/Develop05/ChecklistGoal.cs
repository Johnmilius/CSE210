public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _maxTimesCompleted;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int maxTimesCompleted, int bonusPoints)
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

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public bool FirstTimeCompleted()
    {
        return _timesCompleted == _maxTimesCompleted;
    }

    public void SetTimesCompleted(int times)
    {
        _timesCompleted = times;
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _maxTimesCompleted;
    }

    public override string DisplayGoal()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Completed: {_timesCompleted}/{_maxTimesCompleted}";
    }

    public override string FormatToFile()
    {
        return $"ChecklistGoal~~{_name}~~{_description}~~{_points}~~{_timesCompleted}~~{_maxTimesCompleted}~~{_bonusPoints}";
    }
}
