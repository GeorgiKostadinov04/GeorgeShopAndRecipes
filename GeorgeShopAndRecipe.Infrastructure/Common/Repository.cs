
using GeorgeShopAndRecipe.Infrastructure.Data;
using GeorgeShopAndRecipe.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace GeorgeShopAndRecipe.Infrastructure.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(ApplicationDbContext _context)
        {
            context = _context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
                
        }
    }
}
