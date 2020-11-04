namespace Morgengry
{
    public class Amulet : Merchandise
    {
        public static double LowQualityValue
        { get; set; }
        public static double MediumQualityValue
        { get; set; }
        public static double HighQualityValue
        { get; set; }

        public string Design
        { get; set; }
        public Level Quality
        { get; set; }

        static Amulet()
        {
            LowQualityValue = 12.5;
            MediumQualityValue = 20;
            HighQualityValue = 27.5;
        }

        public Amulet(string itemId, Level Quality, string Design)
        {
            ItemId = itemId;
            this.Design = Design;
            this.Quality = Quality;
        }
        public Amulet(string itemId, Level Quality)
        : this(itemId, Quality, "")
        { }
        public Amulet(string itemId)
        : this(itemId, Level.medium, "")
        { }

        public override string ToString()
        {
            return $"ItemId: {ItemId}, Quality: {Quality}, Design: {Design}";
        }

        public override double GetValue()
        {
            switch (Quality)
            {
                case Level.low:
                    return LowQualityValue;
                case Level.medium:
                    return MediumQualityValue;
                case Level.high:
                    return HighQualityValue;
                default:
                    return 0;
            }
        }

        public override string CreateLineToSave()
        {
            return $"AMULET;{ItemId};{Design};{Quality}";
        }

    }
}
