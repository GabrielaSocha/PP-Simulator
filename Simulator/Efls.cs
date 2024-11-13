using System;

namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }
    private int counterS = 0;
    public void Sing()
    {
        counterS++;
        if (counterS == 3)
        {
            if (agility < 10) agility++;
            counterS = 0;
        }

    }
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public Elf() { }
    public override int Power => 8 * Level + 2 * Agility;
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    public override string Info => $"{Name} [{Level}][{Agility}]";
}
