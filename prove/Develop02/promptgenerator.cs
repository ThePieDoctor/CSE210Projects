using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts;
    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What's a simple pleasure you enjoyed today?",
            "Describe a moment of unexpected kindness you witnessed or received.",
            "How will you make this day amazing?",
            "How will make tomorrow better than today?",
            "Who is someone you appreciate and why?",
            "What is something new you learned today?",
            "What is a goal you have for the next week?",
            "What is a new skill you would like to learn?",
            "What is your favorite candy and why?",
            "What is your favorite season and why?",
            "What is your favorite holiday and why?",
        };
    }
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}