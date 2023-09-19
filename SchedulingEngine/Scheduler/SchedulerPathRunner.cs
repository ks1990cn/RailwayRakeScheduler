namespace SchedulingEngine.Scheduler
{
    public class SchedulerPathRunner
    {
        public SchedulerPathRunner()
        {
                
        }
        /// <summary>
        /// This method will be responsible to try to run on given path considering other trains on path and schedule of terminals.
        /// If return false then algorithm will try to find any other path
        /// </summary>
        /// <param name="sourceTerminalId"></param>
        /// <param name="terminalId"></param>
        /// <param name="distancefromSources"></param>
        /// <returns></returns>
        public bool TryToRunOnPath(int sourceTerminalId, int terminalId, List<List<(int, int)>> graph, List<int> terminalsTravelled)
        {
            if (terminalsTravelled.Count > 0)
            {
                int lastTerminalTravelled = terminalsTravelled.Last();

                List<(DateTime, DateTime)> availableTerminalSchedules = GetAvailableTimesForTerminalSchedules(terminalId);

                var currentTerminalData = graph[lastTerminalTravelled].Where(a => a.Item1 == terminalId).ToList();

                if (currentTerminalData.Count > 0)
                {
                    var distanceFromLastToCurrentTerminal = currentTerminalData.First().Item2;


                }


            }
            return true;
        }

        /// <summary>
        /// Will return available terminal schedules based on arrival and departure of trains
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<(DateTime, DateTime)> GetAvailableTimesForTerminalSchedules(int terminalId)
        {
            return new List<(DateTime, DateTime)>();
        }
    }
}
