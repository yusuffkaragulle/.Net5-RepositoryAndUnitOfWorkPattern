using RepositoryAndUnitOfWorkPattern.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWorkPattern.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task<int> Save();
    }
}
