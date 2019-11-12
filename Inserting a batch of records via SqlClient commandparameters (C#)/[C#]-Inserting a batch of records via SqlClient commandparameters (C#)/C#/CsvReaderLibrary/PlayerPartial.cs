namespace CsvReaderLibrary
{
    public class PlayerPartial
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public decimal Age { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
