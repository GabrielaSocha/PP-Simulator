namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string drc)
    {
        List<Direction> directions = new();

        foreach (char c in drc.ToUpper())
        {
            switch (c)
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;

            }
        }
        return directions;
    }
}
