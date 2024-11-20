namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
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
                x += SizeX;
            else if (x > SizeX- 1)
                x -= SizeX;

            if (y < 0)
                y += SizeY;
            else if (y > SizeY - 1)
                y -= SizeY;

            temp = new Point(x, y);
        }

        return temp;
    }
}
