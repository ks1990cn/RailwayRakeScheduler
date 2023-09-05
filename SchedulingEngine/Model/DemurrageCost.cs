namespace SchedulingEngine.Model
{
    /// <summary>
    /// Demurrage cost per terminal
    /// </summary>
    public static class DemurrageCost
    {
        public static int BaseChargesPerWagonPerHourFor6Hours { get; set; } = 150;

        public static double from6hourTo12Hours { get; set; } = BaseChargesPerWagonPerHourFor6Hours + (BaseChargesPerWagonPerHourFor6Hours / 10);

        public static double from12hourTo24Hours { get; set; } = BaseChargesPerWagonPerHourFor6Hours + (BaseChargesPerWagonPerHourFor6Hours / 4);

        public static double from24hourTo48Hours { get; set; } = BaseChargesPerWagonPerHourFor6Hours + (BaseChargesPerWagonPerHourFor6Hours / 2);

        public static double from48hourTo72Hours { get; set; } = BaseChargesPerWagonPerHourFor6Hours * 2;

        public static double beyond72Hours { get; set; } = BaseChargesPerWagonPerHourFor6Hours *3;
    }
}
