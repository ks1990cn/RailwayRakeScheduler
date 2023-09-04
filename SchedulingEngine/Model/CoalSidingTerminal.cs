namespace SchedulingEngine.Model
{
    public class CoalSidingTerminal
    {
        public int TerminalID { get; set; }
        public string TerminalName { get; set; }
        public double AvailableCoalQuantity { get; set; }
        public DateTime LastAvailableCoalQuantityRecordedTime { get; set; }
    }
}
