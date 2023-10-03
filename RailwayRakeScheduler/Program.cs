using SchedulingEngine.DummyData;
using SchedulingEngine.Scheduler;

internal class Program
{
    private static async Task Main(string[] args)
    {
        int V = 11;

        PathFinder dijkstra = new PathFinder(V);

        SchedulerPathRunner schedulerPathRunner = new SchedulerPathRunner();
        
        CreateGraphData(dijkstra);
        
        var schedulingTrain = TrainDetails.Trains.First(a => a.TrainNumber == 0);

        List<int> terminalsOnWhichSchedulingImpossible = new List<int>();

        Dictionary<int, DateTime> SchedulePerTerminal = new Dictionary<int, DateTime>();

        var existingTrainSchedulePerTerminal = TerminalTrainScheduleData.TrainSchedulePerTerminal;

        do
        {
            // TODO: Here we can fetch any existing shortest path from Database

            dijkstra.ScheduledShortestPath(6, 5);

            var shortestPathFound = dijkstra.ResultPath;

            schedulerPathRunner.TryToRunOnPath(shortestPathFound, terminalsOnWhichSchedulingImpossible, existingTrainSchedulePerTerminal, ref SchedulePerTerminal);

            if (terminalsOnWhichSchedulingImpossible.Count() == 0)
            {
                foreach (var schedules in SchedulePerTerminal)
                {
                    Console.WriteLine(schedules.Key + " " + schedules.Value);
                }
            }

        } while (terminalsOnWhichSchedulingImpossible.Any());

    }

    private static void CreateGraphData(PathFinder dijkstra)
    {
        dijkstra.AddEdge(6, 1, 600);
        dijkstra.AddEdge(1, 2, 700);
        dijkstra.AddEdge(2, 9, 200);
        dijkstra.AddEdge(9, 10, 200);
        dijkstra.AddEdge(10, 8, 200);
        dijkstra.AddEdge(10, 7, 200);
        dijkstra.AddEdge(8, 7, 800);
        dijkstra.AddEdge(7, 2, 300);
        dijkstra.AddEdge(7, 4, 200);
        dijkstra.AddEdge(8, 4, 400);
        dijkstra.AddEdge(4, 3, 200);
        dijkstra.AddEdge(1, 3, 450);
        dijkstra.AddEdge(3, 5, 300);
        dijkstra.AddEdge(4, 5, 200);
    }
}