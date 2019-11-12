namespace MVPDemo.Models
{
    public class CustomerModel 
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }

        public string FullName
        {
            get 
            { 
                return firstName + " " + lastName; 
            }
        }
        
        public CustomerModel()
        { 
        }
        
        public CustomerModel(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }    
    }
}