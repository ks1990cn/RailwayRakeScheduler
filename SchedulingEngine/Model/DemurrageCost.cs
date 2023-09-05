namespace SchedulingEngine.Model
{
    /// <summary>
    /// Demurrage cost per terminal
    /// </summary>
    public class DemurrageCost
    {
        public int TerminalId { get; set; }
        public double DemurrageCostPerHour { get; set; }
    }
}
