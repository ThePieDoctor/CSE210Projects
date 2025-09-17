using System;

class Program
{
    static void Main(string[] args)
    {

        int userinput = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        while (userinput != 0)
        {
            string input = Console.ReadLine();
            userinput = int.Parse(input);

            if (userinput != 0)
            {
                numbers.Add(userinput);
            }
        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}