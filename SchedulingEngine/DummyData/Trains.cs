using SchedulingEngine.Model;

namespace SchedulingEngine.DummyData
{
    public static class TrainDetails
    {
        public static List<Train> Trains { get; set; }
        public static int TotalNumberOfTrains { get; set; } = 100;
        static TrainDetails() 
        {
            Trains = GenerateRandomTrainsData();
        }

        private static List<Train> GenerateRandomTrainsData()
        {
            List<Train> data = new List<Train>();
            Random random = new Random();
            for (int numberOfTrains = 0; numberOfTrains < TotalNumberOfTrains; numberOfTrains++)
            {
                data.Add(new Train()
                {
                    TrainNumber = numberOfTrains,
                    LoadingCapacity = random.Next(100)
                });
            }

            return data;
        }

    }
}
