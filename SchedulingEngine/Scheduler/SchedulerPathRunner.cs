namespace SchedulingEngine.Scheduler
{
    public class SchedulerPathRunner
    {
        /// <summary>
        /// This method will be responsible to try to run on given path considering other trains on path and schedule of terminals.
        /// If return false then algorithm will try to find any other path
        /// </summary>
        /// <param name="sourceTerminalId"></param>
        /// <param name="terminalId"></param>
        /// <param name="distancefromSources"></param>
        /// <returns></returns>
        public bool TryToRunOnPath(int sourceTerminalId, int terminalId, int distancefromSources)
        {
            if (terminalId == sourceTerminalId)
            {
                return true;
            }
            else
            {
                List<(DateTime, DateTime)> availableTerminalSchedules = GetAvailableTimesForTerminalSchedules();
            }
            return true;
        }

        /// <summary>
        /// Will return available terminal schedules based on arrival and departure of trains
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<(DateTime, DateTime)> GetAvailableTimesForTerminalSchedules()
        {
            return new List<(DateTime, DateTime)>();
        }
    }
}
