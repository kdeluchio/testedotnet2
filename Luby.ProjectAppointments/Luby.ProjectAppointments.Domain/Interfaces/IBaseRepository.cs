using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Domain.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task UpdateAsyncCollection(T entity, List<KeyValuePair<string, object>> valueObject, params Expression<Func<T, object>>[] navigation);
        Task<bool> DeleteAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<IQueryable<T>> GetByAllAsync();
        Task<int> SaveChangesAsync();
    }
}
