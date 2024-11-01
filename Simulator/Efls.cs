using System;

namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    public int Agility
    {
        get { return agility; }
        init
        {
            if (value < 0) value = 0;
            if (value > 10) value = 10;
            agility = value;
        }
    }
    public static int counterS = 0;
    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
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
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
}
