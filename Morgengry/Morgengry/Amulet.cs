namespace Morgengry
{
    public class Amulet : Merchandise
    {
        public string Design
        { get; set; }


        public Level Quality
        { get; set; }

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

    }
}
