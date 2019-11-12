namespace SqlDataOperations
{
    public class ContactType
    {
        public int ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }
        public override string ToString()
        {
            return ContactTitle;
        }
    }
}
