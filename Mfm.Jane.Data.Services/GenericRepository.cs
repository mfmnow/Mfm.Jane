using System.Collections.Generic;
using System.Threading.Tasks;
using Mfm.Jane.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mfm.Jane.Data.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly JaneTestDbContext _context;

        public GenericRepository(JaneTestDbContext janeTestDbContext)
        {
            _context = janeTestDbContext;
        }

        public virtual async Task Create(T entity)
        {
            _context.Set<T>();
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
