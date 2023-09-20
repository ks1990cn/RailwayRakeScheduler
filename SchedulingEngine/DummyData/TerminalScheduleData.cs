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
            return new Dictionary<int, List<(int, DateTime, DateTime, bool)>>();
        }
    }
}
