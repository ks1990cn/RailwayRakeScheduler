using SchedulingEngine.Model;

namespace SchedulingEngine.DummyData
{
    public static class TerminalTrainScheduleData
    {
        public static Dictionary<int, List<(int, DateTime, DateTime, bool)>> TrainSchedulePerTerminal { get; set; }
        static TerminalTrainScheduleData()
        {
            TrainSchedulePerTerminal = GetTrainSchedulePerTerminal();
        }
        /// <summary>
        /// Generate dummy data for trains over terminals 6,1,3,5 (Currently we are routing on this)
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, List<(int, DateTime, DateTime, bool)>> GetTrainSchedulePerTerminal()
        {
            var TrainschedulePerTerminal = new Dictionary<int, List<(int, DateTime, DateTime, bool)>>();

            var terminals = new List<int>() { 6, 1, 3, 5 };
            Random random = new Random();

            var startTimes = new List<DateTime>()
            {
                new DateTime(2023, 1, 1, 2, 0, 0),
                new DateTime(2023, 1, 1,3,0,0),
                new DateTime(2023, 1, 1,16,0,0),
                new DateTime(2023, 1, 1,20,0,0)
            };
            var trainStartTime = new Dictionary<Train, DateTime>();

            GetTrainStartTimes(random, startTimes, trainStartTime);

            //Creating schedule of arrival and departure per terminal in the route.
            GenerateTrainSchedulePerTerminal(TrainschedulePerTerminal, terminals, trainStartTime);
            return TrainschedulePerTerminal;
        }

        /// <summary>
        /// time from next terminal is created as dummy values assuming train speed of 60 Km/hr & distances mentioned in graph edges.
        /// </summary>
        /// <param name="schedulePerTerminal"></param>
        /// <param name="terminals"></param>
        /// <param name="trainStartTime"></param>
        private static void GenerateTrainSchedulePerTerminal(Dictionary<int, List<(int, DateTime, DateTime, bool)>> schedulePerTerminal, List<int> terminals, Dictionary<Train, DateTime> trainStartTime)
        {
            foreach (var trains in trainStartTime)
            {
                var startTimeForCurrentTrain = trains.Value;
                var terminalArrivalTime = startTimeForCurrentTrain;
                var trainScheduleOnCurrentTerminal = new List<(int, DateTime, DateTime, bool)>();
                foreach (var terminal in terminals)
                {
                    var terminalDepartureTime = terminalArrivalTime.AddMinutes(5);
                    trainScheduleOnCurrentTerminal.Add((terminal, terminalArrivalTime, terminalDepartureTime, true));

                    switch (terminal)
                    {
                        case 6:
                            terminalArrivalTime = terminalDepartureTime.AddHours(10);
                            break;
                        case 1:
                            terminalArrivalTime = terminalDepartureTime.AddHours(7.5);
                            break;
                        case 3:
                            terminalArrivalTime = terminalDepartureTime.AddHours(5);
                            break;
                    }

                }
                schedulePerTerminal.Add(trains.Key.TrainNumber, trainScheduleOnCurrentTerminal);
            }
        }

        private static void GetTrainStartTimes(Random random, List<DateTime> startTimes, Dictionary<Train, DateTime> trainStartTime)
        {
            int count = 0;
            //Setting 4 random trains to be run.
            while (count < 4)
            {

                var randomTrains = TrainDetails.Trains.Where(a => a.TrainNumber == random.Next(1, 100)).ToList();

                if (randomTrains.Count > 0)
                {
                    var train = randomTrains.First();

                    trainStartTime.Add(train, startTimes[count]);
                    count++;
                }
            }
        }
    }
}
