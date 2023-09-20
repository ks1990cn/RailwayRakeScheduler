using SchedulingEngine.Model;

namespace SchedulingEngine.DummyData
{
    public static class TerminalsData
    {
        public static List<Terminal> Terminals { get; set; }

        static TerminalsData()
        {
            Terminals = new List<Terminal>();

            for (int i = 1; i <= 10; i++)
            {
                var terminal = new Terminal()
                {
                    TerminalId = i,
                    TerminalCode = $"T{i}",
                    TerminalName = $"Terminal {i}",
                    AvailableCoalQuantity = (i!=5) ? 0: 500,
                    Division = "Division A",
                    LastAvailableCoalQuantityRecordedTime = DateTime.Now,
                    State = "State A",
                    IsCoalSidingTerminal = (i == 6 || i == 5),
                    IsLoadingTerminal = (i == 6),
                    IsUnloadingTerminal = (i == 5)
                };

                Terminals.Add(terminal);
            }
        }
    }

}
