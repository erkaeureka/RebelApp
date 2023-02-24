using Core.Entities;
using Core.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data {
    public class Repository<T, TContext> : IRepository<T> where T : class, IEntity where TContext : DbContext {
        private readonly IUnitOfWork<TContext> _unitOfWork;

        public Repository(IUnitOfWork<TContext> unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetAll() {
            return _unitOfWork.Context.Set<T>();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) {
            return _unitOfWork.Context.Set<T>().Where(predicate);
        }

        public async Task<T> FindAsync(params object[] keyValues) {
            return await _unitOfWork.Context.Set<T>().FindAsync(keyValues);
        }

        public T Find(params object[] keyValues) {
            return _unitOfWork.Context.Set<T>().Find(keyValues);
        }

        public T Add(T entity) {
            return _unitOfWork.Context.Set<T>().Add(entity).Entity;
        }

        public async Task<T> AddAsync(T entity) {
            var entry = await _unitOfWork.Context.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public void Add(IEnumerable<T> entities) {
            _unitOfWork.Context.Set<T>().AddRange(entities);
        }

        public T Update(T entity) {
            return _unitOfWork.Context.Set<T>().Update(entity).Entity;
        }

        public void Update(IEnumerable<T> entities) {
            _unitOfWork.Context.Set<T>().UpdateRange(entities);
        }

        public void Delete(params object[] keyValues) {
            Delete(Find(keyValues));
        }

        public async Task DeleteAsync(params object[] keyValues) {
            var entity = await FindAsync(keyValues);
            Delete(entity);
        }

        public void Delete(T entity) {
            if (entity != null) {
                if (entity is BaseEntity obj) {
                    obj.Delete();
                } else {
                    _unitOfWork.Context.Set<T>().Remove(entity);
                }
            }
        }

        public void Delete(params T[] entities) {
            if (entities is BaseEntity[] array) {
                foreach (var entity in array) {
                    Delete(entity);
                }
            } else {
                _unitOfWork.Context.Set<T>().RemoveRange(entities);
            }
        }

        public void Delete(IEnumerable<T> entities) {
            if (entities is IEnumerable<BaseEntity> list) {
                foreach (var entity in list) {
                    Delete(entity);
                }
            } else {
                _unitOfWork.Context.Set<T>().RemoveRange(entities);
            }
        }

        public T Attach(T entity) {
            return _unitOfWork.Context.Set<T>().Attach(entity).Entity;
        }

        public void Attach(IEnumerable<T> entities) {
            _unitOfWork.Context.Set<T>().AttachRange(entities);
        }
    }
}
