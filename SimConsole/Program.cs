using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            BigBounceMap bigBounceMap = new BigBounceMap(8, 6);

            Elf elf = new Elf();
            Orc orc = new Orc();
            Animals rabbits = new Animals() { Description = "Rabbits" };
            Birds ostrichs = new Birds() { Description = "Ostrichs" };
            Birds eagles = new Birds() { Description = "Eagles" };

            List<IMappable> mappables = new List<IMappable>() { elf, orc, rabbits, ostrichs, eagles };
            List<Point> points = [new(7, 2), new(4, 5), new(4, 2), new(7, 5), new(3, 3)];

            string moves = "rrrrrdllrlrdurldurllldddurrr";

            Simulation simulation = new(bigBounceMap, mappables, points, moves);
            SimulationHisotry simulationHisotry = new(simulation);

            simulationHisotry.DispalyMoveInfo(5);
            simulationHisotry.DispalyMoveInfo(10);
            simulationHisotry.DispalyMoveInfo(15);
            simulationHisotry.DispalyMoveInfo(20);
        
        }
    }
}
