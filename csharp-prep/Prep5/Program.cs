using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string username = GetName();
        int usernumber = GetFavNumber();

        int squarednumber = SquareNumber(usernumber);

        int birthYear;
        PromptUserBirthYear(out birthYear);

        DisplayResult(username, squarednumber, birthYear);
    }
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string GetName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}!");
        return name;
    }
    static int GetFavNumber()
    {
        Console.Write("What is your favorite number? ");
        string favNumber = Console.ReadLine();
        int number = int.Parse(favNumber);
        Console.WriteLine($"Your favorite is {number}.");
        return number;
    }
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write($"Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());

    }
    static int SquareNumber(int number)
    {
        int square = number * number;
        Console.WriteLine($"The square of {number} is {square}.");
        return square;
    }
    static void DisplayResult(string name, int square, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will turn {2025 - birthYear} years old this year.");
    }
}