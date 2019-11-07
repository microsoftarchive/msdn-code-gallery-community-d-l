using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<IEnumerable<Blog>> GetAllBlogByPageIndex(int pageIndex, int pageSize);
    }
}
