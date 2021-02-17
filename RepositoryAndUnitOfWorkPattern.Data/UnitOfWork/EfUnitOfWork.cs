using RepositoryAndUnitOfWorkPattern.Data.Context;
using RepositoryAndUnitOfWorkPattern.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWorkPattern.Data.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        #region Fields

        private bool _disposed;
        private readonly MyDbContext _dbContext;

        #endregion

        #region Ctor

        public EfUnitOfWork(MyDbContext dbContext) =>
            _dbContext = dbContext;

        #endregion

        #region Methods

        public IRepository<T> GetRepository<T>() where T : class, new() =>
            new EfRepository<T>(_dbContext);

        public Task<int> Save() =>
            _dbContext.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _dbContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
