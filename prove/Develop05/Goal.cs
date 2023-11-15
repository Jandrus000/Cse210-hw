using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Xml.Schema;

public class Goal
{
    protected bool _done;
    protected string _goalDescription;
    protected string _goalTitle;
    protected int _points;

    public Goal(string title, string text, int points)
    {
        _goalTitle = title;
        _goalDescription = text;
        _points = points;
    }

    public virtual void DisplayGoal()
    {

    }
    public virtual string GetGoalAsString()
    {
        return "";
    }

    public virtual int RecordGoal()
    {
        _done = true;
        return _points;
    }



    //Getters and Setters
    public string GetTitle()
    {
        return _goalTitle;
    }
    public void SetTitle(string title)
    {
        _goalTitle = title;
    }
    public void SetGoalText(string text)
    {
        _goalDescription = text;
    }
    public string GetGoalText()
    {
        return _goalDescription;
    }
    public void SetDone(bool done)
    {
        _done = done;
    }
    public bool GetDone()
    {
        return _done;
    }
    public void SetPoints(int points)
    {
        _points = points;
    }
    public int GetPoints()
    {
        return _points;
    }

    public virtual void SetTimesCompleted(int timesCompleted)
    {

    }
    public virtual int GetTimesCompleted()
    {
        return 0;
    }

    public virtual void SetMilestone(int milestone)
    {

    }
    public virtual int GetMilestone()
    {
        return 0;
    }

    public virtual void SetMilestonePoints(int milestonePoints)
    {

    }
    public virtual int GetMilestonePoints()
    {
        return 0;
    }

}