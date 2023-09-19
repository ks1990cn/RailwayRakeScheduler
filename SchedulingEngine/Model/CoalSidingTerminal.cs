namespace SchedulingEngine.Model
{
    public class Terminal
    {
        public int TerminalId { get; set; }
        public string TerminalCode { get; set; }
        public string TerminalName { get; set; }
        public double AvailableCoalQuantity { get; set; }
        public string Division { get; set; }
        public DateTime LastAvailableCoalQuantityRecordedTime { get; set; }
        public string State { get; set; }
        public bool IsCoalSidingTerminal { get; set; }
        public bool IsLoadingTerminal { get; set; }
        public bool IsUnloadingTerminal { get; set; }   
    }
}
