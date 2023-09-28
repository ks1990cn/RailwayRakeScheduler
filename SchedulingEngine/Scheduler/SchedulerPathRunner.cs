using Google.OrTools.LinearSolver;
using static Google.OrTools.LinearSolver.Solver;

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
        public void TryToRunOnPath(List<int> shortestPath, List<int> terminalsOnWhichSchedulingImpossible, ref Dictionary<int, DateTime> schedulePerTerminal)
        {
           
        }

        public static DateTime? SolveForOptimalDepartureTimeFromSource(DateTime arrivalTimeDestination, DateTime[] timeRanges, DateTime specifiedDepartureTime)
        {
            // Create a new LP model.
            Solver solver = Solver.CreateSolver("DepartureTimeSolver");

            // Define the decision variables.
            Variable departureTimeFromSourceVariable = solver.MakeNumVar(0, Double.PositiveInfinity, "departureTimeFromSource");
            Variable arrivalTimeDestinationVariable = solver.MakeNumVar(arrivalTimeDestination.Ticks, arrivalTimeDestination.Ticks, "arrivalTimeDestination");

            // Define the constraints.
            solver.Add(arrivalTimeDestinationVariable - departureTimeFromSourceVariable == 10);

            foreach (DateTime timeRange in timeRanges)
            {
                Variable timeRangeVariable = solver.MakeNumVar(timeRange.Ticks, timeRange.Ticks, "timeRange");
                
                //solver.Add(timeRangeVariable - arrivalTimeDestinationVariable < 0);
                //solver.Add(arrivalTimeDestination < timeRange.AddTicks(1));
            }

            //solver.Add(departureTimeFromSourceVariable > specifiedDepartureTime.Ticks);

            // Define the objective function.
            solver.Minimize(departureTimeFromSourceVariable - specifiedDepartureTime.Ticks);

            // Solve the LP model.
            Solver.ResultStatus solution = solver.Solve();

            if (solution == Solver.ResultStatus.OPTIMAL)
            {
                
            }
            return null;
            // Get the optimal value for departureTimeFromSource.
            //return new DateTime(solver.Objective().Value());
        }
    }
}
