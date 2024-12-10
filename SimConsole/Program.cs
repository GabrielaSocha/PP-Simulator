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


            SmallTorusMap map = new(6, 8);
            List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Animals { Description = "Króliki", Size = 10},
                                            new Birds {Description = "Orły", Size = 10, CanFly = true},
                                            new Birds {Description = "Strusie", Size = 8, CanFly = false}];
            List<Point> points = [new(2, 2), new(3, 1), new(4, 2), new(3, 5), new(3, 3)];
            string moves = "dlrludllrlrdurldurllldddurrr";

            Simulation simulation = new(map, mappables, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);

            Console.WriteLine("Starting Positions: ");
            mapVisualizer.Draw();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            while (!simulation.Finished)
            {
                Console.WriteLine($"<{simulation.CurrentMappable.GetType().Name} - " +
                    $"{(simulation.CurrentMappable is Creature creature ? creature.Name + " from " + creature.Position : "")}> " +
                    $"goes {simulation.CurrentMoveName}");

                simulation.Turn();
                mapVisualizer.Draw();

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
