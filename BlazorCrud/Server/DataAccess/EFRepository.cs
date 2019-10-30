using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorCrud.Server.DataAccess
{
    public class EFRepository : IEntityRepository
    {
        private readonly DataBaseContext _db;

        private bool _disposed = false;

        public EFRepository(string connectionString)
        {
            _db = new DataBaseContext(connectionString);
        }

        ~EFRepository()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _db.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<T> FindAsync<T>(params object[] id) where T : class => GetSet<T>().FindAsync(id).AsTask();

        public Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class => GetSet<T>().FirstOrDefaultAsync(predicate);

        public T Add<T>(T entity) where T : class => GetSet<T>().Add(entity).Entity;

        public T Update<T>(T entity) where T : class
        {
            var existing = _db.Entry(entity);
            existing.State = EntityState.Modified;
            existing.CurrentValues.SetValues(entity);
            return existing.Entity;
        }

        public Task SaveChangesAsync() => _db.SaveChangesAsync();

        public IQueryable<T> Query<T>() where T : class => GetSet<T>().AsQueryable();

        public async Task<IList<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            // use AsNoTracking to turn off tracking for each object loaded;
            // should yield a small performance boost in production
            var set = GetSet<T>().AsNoTracking();

            var result = predicate != null ? set.Where(predicate) : set;

            return await result.ToListAsync();
        }

        private DbSet<T> GetSet<T>() where T : class
        {
            if (!_disposed)
            {
                return _db.Set<T>() ?? throw new ArgumentException($"Invalid entity type `{typeof(T)}`", nameof(T)); 
            }

            throw new ObjectDisposedException(nameof(_db));
        }
    }
}
