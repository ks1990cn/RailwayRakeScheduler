namespace SchedulingEngine.Model
{
    /// <summary>
    /// This will be master data while we map all terminals with table only
    /// </summary>
    public class CurrentTrainStatus
    {
        public int TerminalId { get; set; }

        public int TrainNumber { get; set; }

        public DateTime TrainArrivalTime { get; set; }

        public DateTime TrainScheduledTime { get; set; }
    }
}
