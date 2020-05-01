using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Jane.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task<List<T>> GetAll();
    }
}
