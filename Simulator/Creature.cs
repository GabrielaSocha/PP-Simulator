using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

public class Creature
{
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }
}
