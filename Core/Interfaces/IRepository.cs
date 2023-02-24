using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IRepository<T> where T : IEntity {
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(params object[] keyValues);
        T Find(params object[] keyValues);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        void Add(IEnumerable<T> entities);
        T Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(params object[] keyValues);
        Task DeleteAsync(params object[] keyValues);
        void Delete(T entity);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);
        T Attach(T entity);
        void Attach(IEnumerable<T> entities);
    }
}
