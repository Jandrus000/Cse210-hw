using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        int totalPoints = 0;
        string response = "";
        List<Goal> goals = new List<Goal>();

        while(response != "7")
        {
            //Display menu
            System.Console.WriteLine();
            System.Console.WriteLine($"You have {totalPoints}");
            System.Console.WriteLine();
            System.Console.WriteLine("Menu Options:");
            System.Console.WriteLine("\t1. Create New Goal");
            System.Console.WriteLine("\t2. List Goals");
            System.Console.WriteLine("\t3. Save Goals");
            System.Console.WriteLine("\t4. Load Goals");
            System.Console.WriteLine("\t5. Record Event");
            System.Console.WriteLine("\t6. Edit Goal");
            System.Console.WriteLine("\t7. Quit");
            System.Console.Write("Select a choice from the menu: ");
            response = Console.ReadLine();
            
            //Create a new goal
            if(response == "1")
            {
                System.Console.WriteLine("The type of goals are:");
                System.Console.WriteLine("\t1. Simple Goal");
                System.Console.WriteLine("\t2. Eternal Goal");
                System.Console.WriteLine("\t3. Checklist Goal");
                System.Console.Write("Which type of goal would you like to create? ");
                string goalResponse = Console.ReadLine();

                string title = "";
                string description = "";
                int points = 0;
                int milestone = 0;
                int milestonePoints = 0;
                if(goalResponse == "1" || goalResponse == "2" || goalResponse == "3")
                {
                
                    System.Console.Write("What is the name of you goal? ");
                    title = Console.ReadLine();
                    System.Console.Write("Write a short description of you goal? ");
                    description = Console.ReadLine();
                    System.Console.Write("What is the amount of points associated with this goal? ");
                    points = int.Parse(Console.ReadLine());
                }
                if (goalResponse == "1")
                {
                    var simpleGoal = new SimpleGoal(title,description,points);
                    goals.Add(simpleGoal);
                }
                if (goalResponse == "2")
                {
                    var eternalGoal = new EternalGoal(title,description,points);
                    goals.Add(eternalGoal);
                }
                if (goalResponse == "3")
                {
                    System.Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    milestone = int.Parse(Console.ReadLine());
                    System.Console.Write("What is the bonus for accomplishing it that many times? ");
                    milestonePoints = int.Parse(Console.ReadLine());
                    var checklistGoal = new ChecklistGoal(title, description, points, milestone, milestonePoints);
                    goals.Add(checklistGoal);
                }
                    
            }
            //display goals
            else if(response == "2")
            {
                int counter = 1;
                foreach (var goal in goals)
                {
                    System.Console.Write($"{counter}. ");
                    goal.DisplayGoal();
                    counter++;
                }
            }
            //save goals
            else if(response == "3")
            {
                System.Console.Write("What is the filename for the goal file? ");
                string fileName = Console.ReadLine();

                using (StreamWriter outputFile = new StreamWriter(fileName))
                {
                    
                    outputFile.WriteLine(totalPoints);
                    foreach (var goal in goals)
                    {
                        outputFile.WriteLine(goal.GetGoalAsString());
                    }
                }

            }
            //load goals
            else if(response == "4")
            {
                System.Console.Write("What is the filename for the goal file? ");
                string fileName = Console.ReadLine();

                string[] lines = System.IO.File.ReadAllLines(fileName);

        
                totalPoints = int.Parse(lines[0]);
                for (int i =1; i < lines.Length; i++)
                {
                    string[] goalType = lines[i].Split(":");
                    string[] goalParts = goalType[1].Split(",");
                    string title = goalParts[0];
                    string description = goalParts[1];
                    int points = int.Parse(goalParts[2]);

                    if(goalType[0] == "SimpleGoal")
                    {
                        bool done = Convert.ToBoolean(goalParts[3]);
                        var simpleGoal = new SimpleGoal(title, description, points);
                        simpleGoal.SetDone(done);
                        goals.Add(simpleGoal);
                    }
                    if(goalType[0] == "EternalGoal")
                    {
                        int timesCompleted = int.Parse(goalParts[3]);
                        var eternalGoal = new EternalGoal(title, description, points);
                        eternalGoal.SetTimesCompleted(timesCompleted);
                        goals.Add(eternalGoal);
                    }
                    if(goalType[0] == "CheckListGoal")
                    {
                        bool done = Convert.ToBoolean(goalParts[3]);
                        int milestonePoints = int.Parse(goalParts[4]);
                        int milestone = int.Parse(goalParts[5]);
                        int timesCompleted = int.Parse(goalParts[6]);
                        var checklistGoal = new ChecklistGoal(title, description, points, milestone, milestonePoints);
                        checklistGoal.SetDone(done);
                        checklistGoal.SetTimesCompleted(timesCompleted);
                        goals.Add(checklistGoal);
                    }
                }
            }
            //record event
            else if(response == "5")
            {
                System.Console.WriteLine("The goals are:");
                int count = 1;
                foreach (var goal in goals)
                {
                    System.Console.WriteLine($"\t{count}. {goal.GetTitle()}");
                    count += 1;
                }
                System.Console.Write("What goal did you accomplish? ");
                int recordResponse = int.Parse(Console.ReadLine());
                int newPoints =+ goals[recordResponse-1].RecordGoal();
                System.Console.WriteLine($"Congratulations! You have earned {newPoints} points!");
                totalPoints += newPoints;
                System.Console.WriteLine($"\nYou now have {totalPoints} points.\n");
            }
            //edit goal
            //assignment exceeds requirements by allowing the user to go back and edit 
            //goal details if they were initally inputted incorrectly
            else if(response == "6")
            {
                int counter = 1;
                System.Console.WriteLine("--NOTE: changing goal point amount will not subtract or add points from the existing point total--");
                System.Console.WriteLine("These are your goals: ");

                foreach (var goal in goals)
                {
                    System.Console.Write($"\t{counter}. ");
                    goal.DisplayGoal();
                    counter++;
                }

                System.Console.Write("Which one would you like to edit? ");
                int editResponse = int.Parse(Console.ReadLine());
                System.Console.WriteLine("These are the parts of the goal: ");
                System.Console.WriteLine("\t1. Title");
                System.Console.WriteLine("\t2. Description");
                System.Console.WriteLine("\t3. Point value");
                System.Console.WriteLine("\t4. Status (completed or not)");
                if(goals[editResponse-1] is EternalGoal || goals[editResponse-1] is ChecklistGoal)
                    System.Console.WriteLine("\t5. Times completed");
                if(goals[editResponse-1] is ChecklistGoal)
                {
                    System.Console.WriteLine("\t6. Milestone amount");
                    System.Console.WriteLine("\t7. Milestone point value");
                }

                System.Console.Write("Which part would you like to change? ");
                string goalPartResponse = Console.ReadLine();
                if(goalPartResponse == "1")
                {
                    System.Console.Write("What would you like to change the title to? ");
                    string changeToResponse = Console.ReadLine();
                    goals[editResponse-1].SetTitle(changeToResponse);
                }
                if(goalPartResponse == "2")
                {
                    System.Console.Write("What would you like to change the description to? ");
                    string changeToResponse = Console.ReadLine();
                    goals[editResponse-1].SetGoalText(changeToResponse);
                }
                if(goalPartResponse == "3")
                {
                    System.Console.Write("What would you like to change the point value to? ");
                    int changeToResponse = int.Parse(Console.ReadLine());
                    goals[editResponse-1].SetPoints(changeToResponse);
                }
                if(goalPartResponse == "4")
                {
                    System.Console.Write("What would you like to status to (enter \"y\" for completed and \"n\" for not completed)? ");
                    bool changeToResponse = Convert.ToBoolean(Console.ReadLine());
                    goals[editResponse-1].SetDone(changeToResponse);
                }
                if(goalPartResponse == "5" && (goals[editResponse-1] is EternalGoal || goals[editResponse-1] is ChecklistGoal))
                {
                    System.Console.Write("What would you like to change the times completed to? ");
                    int changeToResponse = int.Parse(Console.ReadLine());
                    goals[editResponse-1].SetTimesCompleted(changeToResponse);
                }
                if(goalPartResponse == "6" && goals[editResponse-1] is ChecklistGoal)
                {
                    System.Console.Write("What would you like to change the milestone to? ");
                    int changeToResponse = int.Parse(Console.ReadLine());
                    goals[editResponse-1].SetMilestone(changeToResponse);
                }
                if(goalPartResponse == "7" && goals[editResponse-1] is ChecklistGoal)
                {
                    System.Console.Write("What would you like to change the milestone bonus to? ");
                    int changeToResponse = int.Parse(Console.ReadLine());
                    goals[editResponse-1].SetMilestonePoints(changeToResponse);
                }

                System.Console.Clear();
                System.Console.WriteLine("Goal has been updated");
                
            }
        

        }
        

    }
}