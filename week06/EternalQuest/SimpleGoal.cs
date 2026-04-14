using System;
using System.ComponentModel;

public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }
    public SimpleGoal(string name, string description, int points, bool IsComplete) : base(name, description, points)
    {
        _isComplete = IsComplete;
    }
    public override void RecordEvent()
    {
        _isComplete = true;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
   public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName}, {_description}, {_points}, {_isComplete}";
    }
}