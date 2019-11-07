using System;
using SampleArch.Model;
namespace SampleArch.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int id);
    }
}
