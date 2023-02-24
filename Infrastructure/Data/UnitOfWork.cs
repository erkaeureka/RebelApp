using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Interfaces;

namespace Infrastructure.Data {
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext {
        public TContext Context { get; set; }

        public UnitOfWork(TContext context) {
            Context = context;
        }

        public void Dispose() {
            Context.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity {
            return new Repository<T, TContext>(this);
        }

        public async Task<int> CommitAsync() {
            return await Context.SaveChangesAsync();
        }

        public async Task<int> CommitWithGuardAsync() {
            var entries = await CommitAsync();
            Guard.Against.NegativeOrZero(entries, nameof(entries));
            return entries;
        }
    }
}
