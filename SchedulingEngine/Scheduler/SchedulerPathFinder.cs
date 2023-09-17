namespace SchedulingEngine.Scheduler
{
    /// <summary>
    /// Based on Dijkstra's algorithm
    /// </summary>
    public class PathFinder
    {
        private int V; // Number of vertices in the graph
        private List<List<(int, int)>> graph;
        List<int> prev; // Store the previous vertices in the shortest path
        SchedulerPathRunner schedulerPathRunner;
        public PathFinder(int v)
        {
            V = v;
            graph = new List<List<(int, int)>>(V);
            prev = new List<int>(V);
            schedulerPathRunner = new SchedulerPathRunner();    
            for (int i = 0; i < V; i++)
            {
                graph.Add(new List<(int, int)>());
            }
        }

        // Add an edge to the graph
        public void AddEdge(int u, int v, int w)
        {
            graph[u].Add((v, w));
            graph[v].Add((u, w)); // If the graph is undirected
        }

        // Find the vertex with the minimum distance value from the set of vertices not yet included in the shortest path tree
        private int MinDistance(List<int> dist, List<bool> sptSet, int src)
        {
            int min = int.MaxValue;
            int minIndex = -1;
            for (int v = 0; v < V; v++)
            {
                //Here we will check if we can run on given path and able to find time slot for it.
                bool canUseThisPath = schedulerPathRunner.TryToRunOnPath(src, v, dist[v]);
                if (!sptSet[v] && dist[v] < min && canUseThisPath)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        private List<int> GetTerminalsWhichAreTraveresed(int dest)
        {
            List<int> path = new List<int>();
            int current = dest;

            while (current != -1)
            {
                path.Insert(0, current);
                current = prev[current];
            }
            return path;
        }

        public void ScheduledShortestPath(int src, int dest)
        {
            List<int> dist = new List<int>(V);
            //Shortest path tree set
            List<bool> sptSet = new List<bool>(V);

            for (int i = 0; i < V; i++)
            {
                dist.Add(int.MaxValue);
                sptSet.Add(false);
                prev.Add(-1); // Initialize prev with -1 to indicate no previous vertex
            }

            dist[src] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinDistance(dist, sptSet,src);

                if (u == -1) continue;

                sptSet[u] = true;

                foreach (var edge in graph[u])
                {
                    int v = edge.Item1;
                    int weight = edge.Item2;
                    if (!sptSet[v] && dist[u] != int.MaxValue && (dist[u] + weight < dist[v]))
                    {
                        dist[v] = dist[u] + weight;
                        prev[v] = u; // Update the previous vertex for v
                    }
                }
            }

            // Reconstruct and print the shortest path from source to destination
            Console.WriteLine("Scheduled shortest path from " + src + " to " + dest + ":");
            PrintShortestPath(dest);
        }

        // Print the shortest path from source to destination
        private void PrintShortestPath(int dest)
        {
            List<int> path = GetTerminalsWhichAreTraveresed(dest);

            foreach (var vertex in path)
            {
                Console.Write(vertex + " ");
            }

            Console.WriteLine();
        }

    }

}
