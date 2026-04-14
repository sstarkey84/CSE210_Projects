using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    public GoalManager()
    {
        
    }
    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                running = false;
                Console.WriteLine("Goodbye.");
            }
            else
            {
                Console.WriteLine("Invalid option.  Please select 1 through 6.");
            }
            Console.WriteLine();
        }
    }
    public void DisplayPlayerInfo()
        {
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine();
        }
    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            return;
        }
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        if (goalType != "1" && goalType != "2" && goalType != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is the description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (goalType == "3")
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        Console.WriteLine("Goal created.");
    }
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }
        Goal selectedGoal = _goals[goalNumber - 1];
        if (selectedGoal is SimpleGoal)
        {
            if (!selectedGoal.IsComplete())
            {
                selectedGoal.RecordEvent();
                _score += selectedGoal.GetPoints();
                Console.WriteLine($"Congratulations.  You have earned {selectedGoal.GetPoints()} points.");
            }
            else
            {
                Console.WriteLine("That goal is already complete.");
            }
        }
        else if (selectedGoal is EternalGoal)
        {
            selectedGoal.RecordEvent();
            _score += selectedGoal.GetPoints();
            Console.WriteLine($"Congratulations. You have earned {selectedGoal.GetPoints()} points.");
        }
        else if (selectedGoal is ChecklistGoal)
        {
            ChecklistGoal checklistGoal = (ChecklistGoal)selectedGoal;
            if (!checklistGoal.IsComplete())
            {
                checklistGoal.RecordEvent();
                _score += checklistGoal.GetPoints();

                if (checklistGoal.IsComplete())
                {
                    _score += checklistGoal.GetBonus();
                    Console.WriteLine($"Bonus earned.  You received {checklistGoal.GetBonus()} extra points.");
                }
                else
                {
                    Console.WriteLine($"Progress recorded.  You earned {checklistGoal.GetPoints()} points.");
                }
            }
            else
            {
                Console.WriteLine($"That goal is already complete.");
            }
        }
    }
    
    public void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        
        List<string> lines = new List<string>();
        lines.Add(_score.ToString());

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }
        File.WriteAllLines(filename, lines);
        Console.WriteLine("Goals saved.");
    }
    public void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = int.Parse(lines[0]);
        
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
            }
        }
        Console.WriteLine("Loaded.");
    }
}