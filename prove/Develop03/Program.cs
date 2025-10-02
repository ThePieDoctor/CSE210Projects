using System;
namespace ScriptureMemorizer;
class Program
{
    static void Main(string[] args)
    {
// User can add more scriptures below following same format
        var scriptures = new List<Scripture>();
        scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding."));
        scriptures.Add(new Scripture(new Reference("1 Nephi", 3, 7),
            "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."));
        scriptures.Add(new Scripture(new Reference("Mosiah", 2, 17),
            "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."));
        scriptures.Add(new Scripture(new Reference("4 Nephi", 1, 12),
            "And they did not walk any more after the performances and ordinances of the law of Moses; but they did walk after the commandments which they had received from their Lord and their God, continuing in fasting and prayer, and in meeting together oft both to pray and to hear the word of the Lord."));
        scriptures.Add(new Scripture(new Reference("Matthew", 26, 41),
            "Watch and pray, that ye enter not into temptation: the spirit indeed is willing, but the flesh is weak."));

        var rand = new Random();
        var selected = scriptures[rand.Next(scriptures.Count)];
        var reference = selected.GetReference();

        string userInput = "";
        while (userInput.ToLower() != "quit" && !selected.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine($"{reference.GetDisplayText()} {selected.GetDisplayText()}");
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                selected.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine($"{reference.GetDisplayText()} {selected.GetDisplayText()}");
        Console.WriteLine("\nGreat job! Hopefully you memorized it.");
    }
}