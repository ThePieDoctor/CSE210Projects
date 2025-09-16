using System;

class Program
{
    static void Main(string[] args)
    {
        int userguess = -1;

        Console.WriteLine("What is the magic number?");
        string number = Console.ReadLine();
        int num = int.Parse(number);

        while (userguess != num)
        {
            Console.WriteLine("What is your guess?");
            string guess = Console.ReadLine();
            userguess = int.Parse(guess);

            if (userguess < num)
            {
                Console.WriteLine("Higher: Guess again.");
            }
            else if (userguess > num)
            {
                Console.WriteLine("Lower: Guess again.");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}