using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract bool IsComplete();
    public abstract string DisplayGoal();
    public abstract string FormatToFile();

    public int GetPoints()
    {
        return _points;
    }
}