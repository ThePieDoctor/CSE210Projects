using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);
        if (percent >= 90)
        {
            Console.WriteLine("You have an A.");
        }
        else if (percent >= 80)
        {
            Console.WriteLine("You have a B.");
        }
        else if (percent >= 70)
        {
            Console.WriteLine("You have a C.");
        }
        else if (percent >= 60)
        {
            Console.WriteLine("You have a D.");
        }
        else
        {
            Console.WriteLine("You have an F.");
        }
    }
}