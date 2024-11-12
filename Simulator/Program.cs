namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));
        Console.WriteLine(p.NextDiagonal(Direction.Right));
        Lab5a();
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
    
}
