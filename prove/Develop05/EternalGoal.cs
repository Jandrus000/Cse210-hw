public class EternalGoal : Goal 
{
    private int _timesCompleted;
    public EternalGoal (string title, string text, int points): base(title, text, points){}


    public override void DisplayGoal()
    {
        
        
        System.Console.WriteLine($"[ ] {_goalTitle} ({_goalDescription})-- Completed {_timesCompleted} times");
    }
    public override string GetGoalAsString()
    {
        return $"EternalGoal:{_goalTitle},{_goalDescription},{_points},{_timesCompleted}";
    }
    public override int RecordGoal()
    {
        _done = true;
        _timesCompleted += 1;
        return _points;
    }
    
    public override int GetTimesCompleted()
    {
        return _timesCompleted;
    }
    public override void SetTimesCompleted(int timesCompleted)
    {
        _timesCompleted = timesCompleted;
    }
}