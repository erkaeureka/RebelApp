using Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;
        Task<int> CommitAsync();
        Task<int> CommitWithGuardAsync();
    }
}
