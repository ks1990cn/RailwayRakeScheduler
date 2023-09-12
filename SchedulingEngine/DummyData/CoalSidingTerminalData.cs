using SchedulingEngine.Model;

namespace SchedulingEngine.DummyData
{
    public static class CoalSidingTerminalData
    {
        public static List<CoalSidingTerminal> coalSidingTerminals { get; set; }
        public static int TotalNumberOfTerminals { get; set; } = 500;
        static CoalSidingTerminalData()
        {
            coalSidingTerminals = GenerateCoalSidingTerminalData();
        }

        private static List<CoalSidingTerminal> GenerateCoalSidingTerminalData()
        {
            List<CoalSidingTerminal> coalSidingTerminals = new List<CoalSidingTerminal>();
            Random random = new Random();
            for (int numberOfTerminals = 0; numberOfTerminals < TotalNumberOfTerminals; numberOfTerminals++)
            {
                var terminalName = GenerateRandomString(random, 4);
                
                //Regenerate if dupliate
                if (coalSidingTerminals.Any(a=>a.TerminalCode == terminalName))
                {
                    terminalName = GenerateRandomString(random, 4);
                }
                coalSidingTerminals.Add(new CoalSidingTerminal()
                {
                    TerminalId = numberOfTerminals,
                    TerminalCode = terminalName
                });
            }
            return coalSidingTerminals;
        }
        static string GenerateRandomString(Random random, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] randomChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomChars);
        }
    }
}
