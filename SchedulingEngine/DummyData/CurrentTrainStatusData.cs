using SchedulingEngine.Model;

namespace SchedulingEngine.DummyData
{
    public static class CurrentTrainStatusData
    {
        public static List<CurrentTrainStatus> currentTrainStatuses { get; set; }
        static CurrentTrainStatusData()
        {
            currentTrainStatuses = GenerateCurrentTrainStatusData();
        }

        private static List<CurrentTrainStatus> GenerateCurrentTrainStatusData()
        {
            List<CurrentTrainStatus> currentTrainStatuses = new List<CurrentTrainStatus>();
            Random random = new Random();
            for (int numberOfTrains = 0; numberOfTrains < TrainDetails.TotalNumberOfTrains; numberOfTrains++)
            {
                currentTrainStatuses.Add(new CurrentTrainStatus()
                {
                    TrainNumber = numberOfTrains,
                    TerminalId = random.Next(numberOfTrains)
                });
            }
            return currentTrainStatuses;
        }
    }
}
