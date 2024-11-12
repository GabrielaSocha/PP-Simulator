﻿using System.Drawing;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }

    public SmallSquareMap(int size)
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
        if (Exist(p.Next(d)))
            return p.Next(d);
        return p;

    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p.NextDiagonal(d)))
            return p.NextDiagonal(d);
        return p;
    }

}
