using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        bool running = true;
        int totalPoints = 0;

        while (running)
        {
            Console.WriteLine($"You have {totalPoints} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string menuInput = Console.ReadLine();
            Console.WriteLine();

            if (menuInput == "1")
            {
                // Create New Goal logic here
                Console.WriteLine("[Create New Goal]");
                Console.WriteLine("The Types of Goals are: ");
                Console.WriteLine("  1. Simple Goal");
                Console.WriteLine("  2. Eternal Goal");
                Console.WriteLine("  3. Checklist Goal");
                Console.WriteLine("  4. Bad Habit");
                Console.Write("Which Type of Goal would you like to create? ");
                string createGoalInput = Console.ReadLine();

                if (createGoalInput == "1") // SIMPLE GOAL
                {
                    Console.Write("What is the name of your Goal? > ");
                    string newGoalName = Console.ReadLine();
                    Console.Write("What is a short description of your it? > ");
                    string newGoalDescription = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this Goal? > ");
                    int newGoalPoints = int.Parse(Console.ReadLine());

                    SimpleGoal newGoal = new SimpleGoal(newGoalName, newGoalDescription, newGoalPoints);
                    goals.Add(newGoal);
                }
                else if (createGoalInput == "2") // ETERNAL GOAL
                {
                    Console.Write("What is the name of your Goal? > ");
                    string newGoalName = Console.ReadLine();
                    Console.Write("What is a short description of your it? > ");
                    string newGoalDescription = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this Goal? > ");
                    int newGoalPoints = int.Parse(Console.ReadLine());

                    EternalGoal newGoal = new EternalGoal(newGoalName, newGoalDescription, newGoalPoints);
                    goals.Add(newGoal);
                }
                else if (createGoalInput == "3") // CHECKLIST GOAL
                {
                    Console.Write("What is the name of your Goal? > ");
                    string newGoalName = Console.ReadLine();
                    Console.Write("What is a short description of your it? > ");
                    string newGoalDescription = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this Goal? > ");
                    int newGoalPoints = int.Parse(Console.ReadLine());
                    Console.Write("How many times do you need to accomplish this goal to achieve the bonus points? >");
                    int newGoalTimesToComplete = int.Parse(Console.ReadLine());
                    Console.Write("What is the amount of Bonus points associated with this Goal? > ");
                    int newGoalBonusPoints = int.Parse(Console.ReadLine());

                    ChecklistGoal newGoal = new ChecklistGoal(newGoalName, newGoalDescription, newGoalPoints, newGoalTimesToComplete, newGoalBonusPoints);
                    goals.Add(newGoal);
                }
                else if (createGoalInput == "4") // BAD HABIT
                {
                    Console.Write("What is the name of your Bad Habit? > ");
                    string newGoalName = Console.ReadLine();
                    Console.Write("What is a short description of your bad habit? > ");
                    string newGoalDescription = Console.ReadLine();
                    Console.Write("What is the amount of negitive points associated with this Bad Habit? > ");
                    int newGoalPoints = int.Parse(Console.ReadLine());

                    BadHabit newGoal = new BadHabit(newGoalName, newGoalDescription, newGoalPoints);
                    goals.Add(newGoal);
                }
            }
            else if (menuInput == "2")
            {
                // List Goals logic here
                Console.WriteLine("[List Goals]");
                int index = 1;
                foreach (Goal currentGoal in goals)
                {
                    Console.WriteLine($"{index}. {currentGoal.DisplayGoal()}");
                    index++;
                }
            }
            else if (menuInput == "3")
            {
                // Save Goals logic here
                Console.WriteLine("[Save Goals]");

                Console.Write("What is the name of the file you wish to save to? > ");
                string fileName = Console.ReadLine();

                List<string> lines = new List<string>();
                lines.Add($"{totalPoints}");
                foreach (Goal currentGoal in goals)
                {
                    lines.Add(currentGoal.FormatToFile());
                }
                File.WriteAllLines(fileName, lines);
            }
            else if (menuInput == "4")
            {
                // Load Goals logic here
                Console.WriteLine("[Load Goals]");
                Console.Write("What is the name of the file you wish to load from? > ");
                string fileName = Console.ReadLine();
                goals.Clear();

                string[] lines = File.ReadAllLines(fileName);
                totalPoints = int.Parse(lines[0]);

                foreach (string line in lines)
                {
                    List<string> lineSplit = new List<string>(line.Split("~~"));
                    string goalType = lineSplit[0];

                    if (goalType == "SimpleGoal")
                    {
                        string name = lineSplit[1];
                        string description = lineSplit[2];
                        int points = int.Parse(lineSplit[3]);
                        bool isComplete = bool.Parse(lineSplit[4]);
                        SimpleGoal goal = new SimpleGoal(name, description, points);
                        if (isComplete)
                        {
                            goal.SetToComplete();
                        }
                        goals.Add(goal);
                    }
                    else if (goalType == "EternalGoal")
                    {
                        string name = lineSplit[1];
                        string description = lineSplit[2];
                        int points = int.Parse(lineSplit[3]);
                        EternalGoal goal = new EternalGoal(name, description, points);
                        goals.Add(goal);
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        string name = lineSplit[1];
                        string description = lineSplit[2];
                        int points = int.Parse(lineSplit[3]);
                        int timesCompleted = int.Parse(lineSplit[4]);
                        int maxTimesCompleted = int.Parse(lineSplit[5]);
                        int bonusPoints = int.Parse(lineSplit[6]);
                        ChecklistGoal goal = new ChecklistGoal(name, description, points, maxTimesCompleted, bonusPoints);
                        goal.SetTimesCompleted(timesCompleted);
                        goals.Add(goal);
                    }
                    else if (goalType == "BadHabit")
                    {
                        string name = lineSplit[1];
                        string description = lineSplit[2];
                        int points = int.Parse(lineSplit[3]);
                        BadHabit goal = new BadHabit(name, description, points);
                        goals.Add(goal);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Goals have been loaded");
                Console.WriteLine();
            }
            else if (menuInput == "5")
            {
                // Record Event logic here
                Console.WriteLine("[Record Event]");

                int index = 1;
                foreach (Goal currentGoal in goals)
                {
                    Console.WriteLine($"{index}. {currentGoal.DisplayGoal()}");
                    index++;
                }

                Console.WriteLine();
                Console.Write("Which goal did you accomplish or habit you did? > ");
                int accomplishedGoalINDEX = int.Parse(Console.ReadLine()) - 1;

                Goal accomplishedGoal = goals[accomplishedGoalINDEX];

                totalPoints += accomplishedGoal.GetPoints();

                if (accomplishedGoal is SimpleGoal simpleGoal)
                {
                    simpleGoal.SetToComplete();
                }
                else if (accomplishedGoal is ChecklistGoal checklistGoal)
                {
                    checklistGoal.RecordEvent();
                    if (checklistGoal.FirstTimeCompleted())
                    {
                        totalPoints += checklistGoal.GetBonusPoints();
                    }
                }
                else if (accomplishedGoal is BadHabit badHabit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Try to avoid this habit next time!");
                }
            }
            else if (menuInput == "6")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
            Console.WriteLine();
        }
    }
}