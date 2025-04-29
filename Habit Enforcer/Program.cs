using Habit_Enforcer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static List<String> habits = new List<String>();
    static HashSet<String> completedHabits = new HashSet<String>();
    static void Main(String[] args)
    {
        while (true)
        {
            Thread t = new Thread(() =>
            {
              
                Enforcer.Enforce(habits);
                
                
            });
            t.Start();
            Console.WriteLine("1: Add Habit");
            Console.WriteLine("2: Check Habits");
            Console.WriteLine("3: Complete Habit");

            Console.Write("\nChoice: ");
            string choice = Console.ReadLine();

            Console.WriteLine("\n");
            switch (choice)
            {
                case "1":
                    Console.Write("\nInput Habit: ");
                    string habit = Console.ReadLine();

                    if (!string.IsNullOrEmpty(habit))
                    {
                        habits.Add(habit.ToUpper());
                    }
                    Console.Clear();
                    break;
                case "2":
                    if (habits.Count > 0)
                    {
                        for (int i = 0; i < habits.Count(); i++)
                        {
                            Console.WriteLine(habits[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No habbits.");
                    }

                    Console.WriteLine("\n");
                    Console.WriteLine("Press 2 To Quit Program or Any Key to Return");

                    Console.Write("\nChoice: ");

                    string cont = Console.ReadLine();
                    Console.Clear();
                    if (!string.IsNullOrEmpty(cont) && cont == "2")
                    {
                        return;
                    }
                    break;

                case "3":
                    Console.Write("\nInput Habit Name: ");
                    string selectedHabit = Console.ReadLine();
                    foreach (string h in habits)
                    {
                        if (selectedHabit.ToUpper() == h)
                        {
                            habits.Remove(h.ToUpper());
                            completedHabits.Add(h.ToUpper());
                            break;
                        }
                    }
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Nice try that was not an option. I am now going to install malware onto your computer :)");
                    Console.WriteLine("███▒▒▒▒▒▒▒");
                    Console.WriteLine("Care to try again?");
                    break;
              
            }
            
        }

    }
}