namespace MVCDemo7ExceptionHandling
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public Person()
        {
            Id = 1;
            Name = "Sai";
            Age = 30;
            Street = "50 Heaven St";
            City = "Mansfield";
            State = "MA";
            Zipcode = 02048;
        }
    }
}