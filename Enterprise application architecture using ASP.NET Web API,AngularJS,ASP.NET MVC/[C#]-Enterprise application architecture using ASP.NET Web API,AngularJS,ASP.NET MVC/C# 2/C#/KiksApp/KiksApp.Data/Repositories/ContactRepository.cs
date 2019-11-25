using KiksApp.Core.Data.Repositories;
using KiksApp.Core.Entities;

namespace KiksApp.Data.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(IDbContext context) : base (context)
        {
        }
    }
}
