using Repository;

namespace RepositoryProxy
{
    public interface IRepositoryProxy : IRepository
    {
        bool Online { get; }
    }
}