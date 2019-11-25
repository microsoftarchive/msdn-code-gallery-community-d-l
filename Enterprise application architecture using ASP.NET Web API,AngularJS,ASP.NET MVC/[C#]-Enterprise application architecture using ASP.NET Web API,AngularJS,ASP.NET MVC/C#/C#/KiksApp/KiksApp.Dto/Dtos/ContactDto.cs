namespace KiksApp.Dto.Dtos
{
    public class ContactDto : BaseDto
    {
        public ContactDto()
        {

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string MobilePhone { get; set; }

        //for simplification
        public string Address { get; set; }

        public string Description { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
