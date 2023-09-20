using SchedulingEngine.DummyData;

namespace SchedulingEngine.Scheduler
{
    public class SchedulerPathRunner
    {
        private const int averageRunningTimeOfTrain = 60;
        DateTime ScheduledDepartureTimeFromSource;
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
        public bool TryToRunOnPath(int sourceTerminalId, int terminalId, List<List<(int, int)>> graph, List<int> terminalsTravelled, Model.Train schedulingTrain)
        {
            if (terminalsTravelled.Count > 0)
            {
                int lastTerminalTravelled = terminalsTravelled.Last();

                List<(DateTime, DateTime)> availableTerminalSchedules = GetAvailableTimesForTerminalSchedules(terminalId);

                var currentTerminalData = graph[lastTerminalTravelled].Where(a => a.Item1 == terminalId).ToList();

                if (currentTerminalData.Count > 0)
                {
                    var distanceFromLastToCurrentTerminal = currentTerminalData.First().Item2;

                    double timeTaken = distanceFromLastToCurrentTerminal / averageRunningTimeOfTrain;

                    if(lastTerminalTravelled == sourceTerminalId)
                    {
                       ScheduledDepartureTimeFromSource = TerminalTrainScheduleData.TrainSchedulePerTerminal.First(a => a.Key == schedulingTrain.TrainNumber).Value.
                                                                First(a=>a.Item1 == schedulingTrain.TrainNumber).Item3;
                    }
                    var expectedArrivalTimeOnCurrentTerminal = ScheduledDepartureTimeFromSource.AddHours(timeTaken);

                    foreach (var existingTimeSlot in availableTerminalSchedules)
                    {
                        
                    }
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
