using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts;
    private static readonly Random _random = new Random();

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    protected override void PerformActivity()
    {
        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($" --- {GetRandomPrompt()} --- \n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }
        
        Console.WriteLine($"You listed {count} items!");
    }
}