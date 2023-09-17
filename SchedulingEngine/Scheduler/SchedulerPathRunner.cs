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

                var lastTerminal = graph[lastTerminalTravelled].Where(a => a.Item1 == terminalId).ToList();

                if (lastTerminal.Count > 0)
                {
                    var distanceFromLastToCurrentTerminal = lastTerminal.First().Item2;

                    //Store it in Database or List from Here, so we can retrieve everytime when required without calculating further
                    IsScheduleAvailableFromLastTerminalToCurrentTerminal(lastTerminalTravelled, terminalId, distanceFromLastToCurrentTerminal);
                }

            }
            return true;
        }

        private List<(DateTime,DateTime)> IsScheduleAvailableFromLastTerminalToCurrentTerminal(int lastTerminalTravelled, int terminalId, int distanceFromLastToCurrentTerminal)
        {
            return new List<(DateTime, DateTime)>();
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
