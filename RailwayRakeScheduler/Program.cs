using SchedulingEngine.Scheduler;

internal class Program
{
    private static void Main(string[] args)
    {
        int V = 6;
        Dijkstra dijkstra = new Dijkstra(V);

        dijkstra.AddEdge(0, 1, 2);
        dijkstra.AddEdge(0, 4, 1);
        dijkstra.AddEdge(1, 2, 4);
        dijkstra.AddEdge(1, 4, 3);
        dijkstra.AddEdge(2, 3, 5);
        dijkstra.AddEdge(2, 4, 5);
        dijkstra.AddEdge(3, 4, 7);
        dijkstra.AddEdge(3, 5, 2);
        dijkstra.AddEdge(4, 5, 4);

        dijkstra.ShortestPath(0,5);
    }
}