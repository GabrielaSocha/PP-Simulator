using Simulator.Maps;
using System.Xml.Linq;

namespace Simulator;

public class Animals : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; protected set; }

    private string description = "Unknown";
    public required string Description
    {
        get => description;
        init
        {
            if (string.IsNullOrEmpty(value)) return;
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }
    public uint Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";

    public virtual char Symbol => 'A';

    public virtual void Go(Direction direction)
    {
        if (Map == null) throw new ArgumentNullException("Map not set!");

        Point NextPos = Map.Next(Position, direction);

        if (NextPos.Equals(Position)) return;

        Map.Move(this, Position, NextPos);
        Position = NextPos;
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        Map = map;
        Position = point;

        map.Add(this, Position);
    }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
