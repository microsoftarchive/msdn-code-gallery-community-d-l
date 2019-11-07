namespace CreateDynamicTextBoxes_CS
{
    public class Customer
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public override string ToString()
        {
            return $"{CompanyName}, {ContactName}, {ContactTitle}";
        }
    }
}
