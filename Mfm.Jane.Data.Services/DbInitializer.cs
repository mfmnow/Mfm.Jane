using Mfm.Jane.Data.Contracts;

namespace Mfm.Jane.Data.Services
{
    public class DbInitializer: IDbInitializer
    {
        private readonly IJaneTestDbContext _context;
        public DbInitializer(IJaneTestDbContext janeTestDbContext)
        {
            _context = janeTestDbContext;
        }
        public void Initialize()
        {
            _context.EnsureCreated();
        }
    }
}
