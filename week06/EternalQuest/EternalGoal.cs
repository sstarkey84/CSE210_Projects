using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override void RecordEvent()
    {
        
    }
    public override string GetStringRepresentation()
    {
        return $"EnternalGoal:{_shortName}, {_description}, {_points}";
    }
}