namespace SchedulingEngine.DummyData
{
    public static class TerminalTrainScheduleData
    {
        public static Dictionary<int,List<(int, DateTime, DateTime, bool)>> TrainSchedulePerTerminal { get; set; }
        static TerminalTrainScheduleData()
        {
            TrainSchedulePerTerminal = GetTrainSchedulePerTerminal();
        }
         
        /// <summary>
        /// Train Number
        /// Arrival time
        /// Departure time
        /// Is Halt
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, List<(int, DateTime, DateTime, bool)>> GetTrainSchedulePerTerminal()
        {
            var schedulePerTerminal =new Dictionary<int, List<(int, DateTime, DateTime, bool)>>();

            var terminals = new List<int>() { 6,1,3,5};

            var startTimes = new List<DateTime>() {
                
                new DateTime(0, 0, 0, 2, 0, 0),
                new DateTime(0,0,0,3,0,0),
                new DateTime(0,0,0,16,0,0),
                new DateTime(0,0,0,20,0,0)
            };
            foreach (var startTime in startTimes)
            {
                foreach (var terminal in terminals)
                {
                    var trainsOnTerminal = new List<(int, DateTime, DateTime, bool)>();

                    Random random = new Random();

                    var randomTrain = TrainDetails.Trains.First(a => a.TrainNumber == random.Next(1, 100));

                    schedulePerTerminal.Add(terminal, trainsOnTerminal);
                }
            }
           
            return new Dictionary<int, List<(int, DateTime, DateTime, bool)>>();
        }
    }
}
