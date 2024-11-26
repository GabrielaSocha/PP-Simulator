using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            SmallSquareMap map = new(8);
            List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
            List<Point> points = [new(2, 2), new(3, 1)];
            string moves = "lrudru";

            //SmallSquareMap map = new(8);
            //List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
            //List<Point> points = [new(2, 2), new(3, 1)];
            //string moves = "druuldrulllu";

            Simulation simulation = new(map, creatures, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);


            Console.WriteLine("Starting Positions: ");
            mapVisualizer.Draw();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            while (!simulation.Finished)
            {
                Console.WriteLine($"<{simulation.CurrentCreature.GetType().Name} - {simulation.CurrentCreature.Info}> " +
                    $"from {simulation.CurrentCreature.Position} goes {simulation.CurrentMoveName}");

                simulation.Turn();
                mapVisualizer.Draw();

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
