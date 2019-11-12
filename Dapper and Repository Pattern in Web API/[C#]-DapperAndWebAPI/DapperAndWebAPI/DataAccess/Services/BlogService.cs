using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class BlogService : IBlogService
    {
        IUnitOfWork _unitOfWork;
        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Blog>> GetAllBlogByPageIndex(int pageIndex, int pageSize)
        {
            return await _unitOfWork.BlogRepository.GetAllBlogByPageIndex(pageIndex, pageSize);
        }
    }
}
