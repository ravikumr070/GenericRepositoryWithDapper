using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepository;
namespace Repository.Country
{
    public interface ICountryService : IRepository<Country>
    {
        Task<IEnumerable<Country>> FindAllWithAsync(Country t);
    }
}
