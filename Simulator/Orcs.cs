namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }

    public static int counterO = 0;
    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        counterO++;
        if (counterO == 2)
        {
            if (rage < 10) rage++;
            counterO = 0;
        }

    }

    public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public Orc() { }
    public override int Power => 7 * Level + 3 * Rage;
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    public override string Info => $"{Name} [{Level}][{Rage}]";

}
