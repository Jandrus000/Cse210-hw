public class SimpleGoal : Goal 
{
    public SimpleGoal (string title, string text, int points): base(title, text,points){}

    public override void DisplayGoal()
    {
        string check=" ";
        if (_done)
            check = "X";
        
        System.Console.WriteLine($"[{check}] {_goalTitle} ({_goalDescription})");
    }
    public override string GetGoalAsString()
    {
        return $"SimpleGoal:{_goalTitle},{_goalDescription},{_points},{_done}";
    }
}