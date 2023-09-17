using SchedulingEngine.Scheduler;

internal class Program
{
    private static async Task Main(string[] args)
    {
        int V = 11;
        PathFinder dijkstra = new PathFinder(V);

        //dijkstra.AddEdge(0, 1, 2);
        //dijkstra.AddEdge(0, 4, 1);
        //dijkstra.AddEdge(1, 2, 4);
        //dijkstra.AddEdge(1, 4, 3);
        //dijkstra.AddEdge(2, 3, 5);
        //dijkstra.AddEdge(2, 4, 5);
        //dijkstra.AddEdge(3, 4, 7);
        //dijkstra.AddEdge(3, 5, 2);
        //dijkstra.AddEdge(4, 5, 4);
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
        dijkstra.ScheduledShortestPath(6, 5);
    }
}