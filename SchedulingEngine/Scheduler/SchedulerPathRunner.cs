using SchedulingEngine.DummyData;

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
        /// <returns></returns>
        public bool TryToRunOnPath(List<int> shortestPath, List<int> terminalsOnWhichSchedulingImpossible, ref Dictionary<int, DateTime> schedulePerTerminal)
        {
            return true;
        }
    }
}
