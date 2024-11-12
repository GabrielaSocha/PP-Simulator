using Simulator.Maps;
namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));
        Console.WriteLine(p.NextDiagonal(Direction.Right));
        Lab5a();
        Lab5b();
    }

    static void Lab5a()
    {
        var rectangle0 = new Rectangle(new Point(1,0), new Point(4,3));
        Console.WriteLine(rectangle0.ToString());

        var rectangle = new Rectangle(new Point(4, 3), new Point(1, 0));
        Console.WriteLine(rectangle.ToString());

        var rectangle1 = new Rectangle(8, 5, 3, 1);
        Console.WriteLine(rectangle1.ToString());

        try
        {
            var rectangle2 = new Rectangle(new Point(0, 8), new Point(0, 5));
            Console.WriteLine(rectangle2.ToString());
        }
        catch (ArgumentException exept)
        {

            Console.WriteLine(exept.Message);
        }
        Console.WriteLine(rectangle0.Contains(new Point(2,1)));
        Console.WriteLine(rectangle0.Contains(new Point(5,8)));
    }
    static void Lab5b()
    {
        SmallSquareMap smallSquareMap = new SmallSquareMap(11);
        
        Point position = new Point(0,0);
        Console.WriteLine($"Your position: {position}");

        position = smallSquareMap.Next(position, Direction.Up);
        position = smallSquareMap.NextDiagonal(position, Direction.Up);
        Console.WriteLine($"Your position: {position}");

        try
        {
            SmallSquareMap smallSquareMap1 = new SmallSquareMap(30);

        }
        catch (ArgumentOutOfRangeException mapSize)
        {

            Console.WriteLine(mapSize.Message);
        }
        for (int i = 0; i < 11; i++)
        {
            position = smallSquareMap.NextDiagonal(position, Direction.Up);
            Console.WriteLine($"Your position: {position}");
        }
    }
    
}
