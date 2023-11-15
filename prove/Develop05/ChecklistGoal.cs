public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _milestone;
    private int _milestonePoints;

    public ChecklistGoal(string title, string text, int points, int milestone, int milestonePoints): base(title, text, points)
    {
        _milestone = milestone;
        _milestonePoints = milestonePoints;
    }

    public override void DisplayGoal()
    {
        string check=" ";
        if (_done)
            check = "X";
        
        System.Console.WriteLine($"[{check}] {_goalTitle} ({_goalDescription}) -- Currently Completed: {_timesCompleted}/{_milestone}");
    }

    public override string GetGoalAsString()
    {
        return $"CheckListGoal:{_goalTitle},{_goalDescription},{_points},{_done},{_milestonePoints},{_milestone},{_timesCompleted}";
    }
    public override int RecordGoal()
    {
        _timesCompleted += 1;
        if(_timesCompleted == _milestone)
            _done = true;
            return _milestonePoints;
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

    public override void SetMilestone(int milestone)
    {
        _milestone = milestone;
    }
    public override int GetMilestone()
    {
        return _milestone;
    }

    public override void SetMilestonePoints(int milestonePoints)
    {
        _milestonePoints = milestonePoints;
    }
    public override int GetMilestonePoints()
    {
        return _milestone;
    }
}