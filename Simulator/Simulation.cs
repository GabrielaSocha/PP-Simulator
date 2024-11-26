using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    private int _currentTurn = 0;
    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[_currentTurn % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => DirectionParser.Parse(Moves[_currentTurn % Moves.Length].ToString())[0].ToString();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("The creatures list cannot be empty.");
        }

        if (positions == null || positions.Count != creatures.Count)
        {
            throw new ArgumentException("The number of positions must match the number of creatures.");
        }

        if (string.IsNullOrWhiteSpace(moves))
        {
            throw new ArgumentException("Moves cannot be empty or null.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        for (int i = 0; i < creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }
        foreach (var direction in DirectionParser.Parse(moves))
            Moves += direction.ToString()[0];
    }

    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation is already finished.");
        }
        CurrentCreature.Go(DirectionParser.Parse(Moves[_currentTurn].ToString())[0]);
        _currentTurn++;

        if (_currentTurn >= Moves.Length)
        {
            Finished = true;
        }
    }
}
