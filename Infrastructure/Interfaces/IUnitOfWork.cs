using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces {
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; set; }
    }
   
}
