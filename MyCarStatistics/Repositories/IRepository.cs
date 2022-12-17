namespace MyCarStatistics.Repositories

{
    public interface IRepository : IDisposable
    {
       
        IQueryable<T> AllReadonly<T>() where T : class;
       
        Task<T> GetByIdAsync<T>(object id) where T : class;

        Task AddAsync<T>(T entity) where T : class;
               
        Task<int> SaveChangesAsync();
    }
}
