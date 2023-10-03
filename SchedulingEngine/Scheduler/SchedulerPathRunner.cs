using Google.OrTools.LinearSolver;

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
        public void TryToRunOnPath(List<int> shortestPath, List<int> terminalsOnWhichSchedulingImpossible, Dictionary<int, List<(int, DateTime, DateTime, bool)>> existingTrainSchedulePerTerminal, ref Dictionary<int, DateTime> schedulePerTerminal)
        {
            DateTime specifiedDepartureTime = new DateTime(2023, 1, 1, 10, 0, 0);
            for (int i = 0; i < shortestPath.Count - 1; i++)
            {
                List<(DateTime, DateTime)> availableTimeSlot = new List<(DateTime, DateTime)>();

                var trainScheduleForNextStation = existingTrainSchedulePerTerminal.
                    Select(a => a.Value.First(b => b.Item1 == shortestPath[i + 1])).ToList();

                SolveForOptimalDepartureTimeFromSource(specifiedDepartureTime, trainScheduleForNextStation);
            }
        }

        private void SolveForOptimalDepartureTimeFromSource(DateTime specifiedDepartureTime, List<(int, DateTime, DateTime, bool)> trainScheduleForNextStation)
        {
            // Create the solver.
            Solver solver = Solver.CreateSolver("SCIP");

            // Create variables.
            var departureTimeFromSource = solver.MakeIntVar(specifiedDepartureTime.Ticks, DateTime.MaxValue.Ticks, "departureTimeFromSource");

            // Define the arrival time at the destination (change this to your specific constraints).
            var arrivalTimeDestination = solver.MakeIntVar(specifiedDepartureTime.AddHours(10).Ticks, DateTime.MaxValue.Ticks, "arrivalTimeDestination");

            // Add constraints.
            solver.Add(arrivalTimeDestination >= departureTimeFromSource + 10);
            solver.Add(departureTimeFromSource >= specifiedDepartureTime.Ticks);
            Solver.ResultStatus resultStatus;
            bool overlapFound = false;
            // Solve the problem.
            do
            {
                resultStatus = solver.Solve();
                overlapFound = false;
                if (resultStatus == Solver.ResultStatus.OPTIMAL)
                {
                    // Get the optimal departureTimeFromSource value.
                    var optimalDepartureTime = new DateTime((long)departureTimeFromSource.SolutionValue());

                    var optimalArrivalTime = new DateTime((long)arrivalTimeDestination.SolutionValue());

                    foreach (var item in trainScheduleForNextStation)
                    {
                        //overlap of schedule, lets find solution again and skip this range
                        if (item.Item2 <= optimalArrivalTime && item.Item3 >= optimalArrivalTime)
                        {
                            // Create a boolean variable to represent the condition.
                            var conditionVariable = solver.MakeIntVar(item.Item2.Ticks, item.Item3.Ticks,"conditionVariable");
                            //departureTimeFromSource should not be in above condition.
                            solver.Add(departureTimeFromSource != conditionVariable);
                            overlapFound = true;
                        }
                    }
                    specifiedDepartureTime = optimalDepartureTime;
                    Console.WriteLine($"Optimal departureTimeFromSource: {optimalDepartureTime}");
                }
                else
                {
                    Console.WriteLine("No optimal solution found.");
                    break;
                }
            } while (overlapFound);
          
        }
    }
}
