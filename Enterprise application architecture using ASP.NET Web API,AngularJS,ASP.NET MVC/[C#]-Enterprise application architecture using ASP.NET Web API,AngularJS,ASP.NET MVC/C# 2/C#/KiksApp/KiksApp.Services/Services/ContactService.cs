using KiksApp.Core.Data;
using KiksApp.Core.Entities;
using KiksApp.Core.Services;

namespace KiksApp.Services.Services
{
    public class ContactService : BaseService<Contact>, IContactService
    {
        public ContactService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
