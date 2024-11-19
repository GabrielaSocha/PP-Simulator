namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20) throw new ArgumentOutOfRangeException("Złe wymiary mapy");
        Size = size;
    }
    public override bool Exist(Point p)
    {
        if (p.X < 0 || p.X > Size - 1 || p.Y < 0 || p.Y > Size - 1)
            return false;
        return true;
    }

    public override Point Next(Point p, Direction d)
    {
        return InMapPoint(p.Next(d));
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return InMapPoint(p.NextDiagonal(d));
    }

    private Point InMapPoint(Point p)
    {
        Point temp = new Point(p.X, p.Y);

        while (!Exist(temp))
        {
            int x = temp.X;
            int y = temp.Y;

            if (x < 0)
                x += Size;
            else if (x > Size - 1)
                x -= Size;

            if (y < 0)
                y += Size;
            else if (y > Size - 1)
                y -= Size;

            temp = new Point(x, y);
        }

        return temp;
    }
}
