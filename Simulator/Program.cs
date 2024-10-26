namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        var c = new Creature("Shrek");
        c.SayHi();
    }
}
