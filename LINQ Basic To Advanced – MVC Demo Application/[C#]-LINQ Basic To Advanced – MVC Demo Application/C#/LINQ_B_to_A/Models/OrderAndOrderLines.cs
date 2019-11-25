namespace LINQ_B_to_A.Models
{
    public partial class OrderAndOrderLines
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
    }
}