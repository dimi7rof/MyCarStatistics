using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Data;

namespace MyCarStatistics.Repositories
{
    public class Repository : IRepository
    {        
        protected DbContext Context { get; set; }
        protected DbSet<T> DbSet<T>() where T : class
           => this.Context.Set<T>();        

        public Repository(ApplicationDbContext context)
            => Context = context;        

        public async Task AddAsync<T>(T entity) where T : class
           => await DbSet<T>().AddAsync(entity);     
        
        public IQueryable<T> AllReadonly<T>() where T : class
            => this.DbSet<T>().AsNoTracking();    
        
        public void Dispose()
           => this.Context.Dispose();

        public async Task<T> GetByIdAsync<T>(object id) where T : class
           => await DbSet<T>().FindAsync(id);  
        
        public async Task<int> SaveChangesAsync()
            => await this.Context.SaveChangesAsync();        
    }
}
