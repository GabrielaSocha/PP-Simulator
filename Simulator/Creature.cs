namespace Simulator;

public class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get { return name; }
        init
        {
            if (string.IsNullOrEmpty(value))
                return;
            value = value.Trim();
            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd().PadRight(3, '#');
            }
            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }
            name = value;
        }

    }
    private int level = 1;
    public int Level
    {
        get { return level; }
        init
        {
            if (value == null)
                return;
            if (value < 1)
                value = 1;
            if (value > 10)
                value = 10;
            level = value;
        }
    }
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }
    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
            Go(direction);
    }

    public void Go(string directionstr)
    {
        foreach(var direction in DirectionParser.Parse(directionstr))
            Go(direction);
    }

}
