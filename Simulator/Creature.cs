using System.ComponentModel.DataAnnotations;
using Simulator.Maps;
namespace Simulator;

public abstract class Creature
{
    public Map? Map { get; private set; }

    public Point Position { get; private set; }


    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            if (string.IsNullOrEmpty(name)) return;
            name = Validator.Shortener(value, 3, 25, '#');
        }

    }
    private int level = 1;
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
        
    }
    public abstract string Greeting();
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

    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
        map.Add(this, Position);
    }
    public void Go(Direction direction)
    {
        if (Map == null) throw new ArgumentNullException(nameof(Map), "Chose map");
        Point GoNext = Map.Next(Position, direction);

        if (GoNext.Equals(Position)) return;

        Map.Move(this, Position, GoNext);
        Position = GoNext;

    }
  
    public abstract int Power { get; }
    public abstract string Info { get; }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

}
