
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Verifying Constructors and Methods ---");

        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
 
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        Console.WriteLine("\n--- Verifying Getters and Setters ---");
        
        Fraction testFraction = new Fraction(2, 3);
        Console.WriteLine($"Original fraction: {testFraction.GetFractionString()}");

        Console.WriteLine($"Getter - Top: {testFraction.GetTop()}");
        Console.WriteLine($"Getter - Bottom: {testFraction.GetBottom()}");

        testFraction.SetTop(7);
        testFraction.SetBottom(8);

        Console.WriteLine($"New fraction after using setters: {testFraction.GetFractionString()}");
        Console.WriteLine($"New decimal value: {testFraction.GetDecimalValue()}");
    }
}