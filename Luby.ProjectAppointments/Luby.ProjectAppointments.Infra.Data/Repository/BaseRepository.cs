using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using Luby.ProjectAppointments.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Infra.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DefaultContext Db;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(DefaultContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public async Task<IQueryable<T>> GetByAllAsync()
        {
            try
            {
                return DbSet.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await DbSet.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T obj)
        {
            try
            {
                if (obj.Id == Guid.Empty)
                {
                    obj.Id = Guid.NewGuid();
                }

                if (obj.CreatedIn == DateTime.MinValue)
                {
                    obj.CreatedIn = DateTime.UtcNow;
                }

                DbSet.Add(obj);


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        public async Task<T> UpdateAsync(T obj)
        {
            try
            {
                var current = await DbSet.SingleOrDefaultAsync(x => x.Id == obj.Id);
                if (current == null)
                {
                    return null;
                }

                obj.CreatedIn = current.CreatedIn;
                obj.UpdatedIn = current.UpdatedIn;

                Db.Entry(current).CurrentValues.SetValues(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        public async Task UpdateAsyncCollection(T entity, List<KeyValuePair<string, object>> valueObject, params Expression<Func<T, object>>[] navigation)
        {
            Guid id = (Guid)entity.GetType().GetProperty("Id").GetValue(entity, null);

            var dbEntity = await GetByIdAsync(id);

            var dbEntry = Db.Entry(dbEntity);

            if (valueObject != null)
            {
                foreach (KeyValuePair<string, object> vo in valueObject)
                {
                    Db.Entry(dbEntity).Reference(vo.Key).CurrentValue = vo.Value;
                }
            }

            dbEntry.CurrentValues.SetValues(entity);

            foreach (var property in navigation)
            {
                TreatList(entity, dbEntity, dbEntry, property);
            }

            dbEntry.CurrentValues.SetValues(entity);
            dbEntry.State = EntityState.Modified;
        }

        private void TreatList(T entity, T dbEntity, EntityEntry<T> dbEntry, Expression<Func<T, object>> property)
        {
            var propertyName = property.GetPropertyAccess().Name;
            var dbItemsEntry = dbEntry.Collection(propertyName);
            var accessor = dbItemsEntry.Metadata.GetCollectionAccessor();

            dbItemsEntry.Load();
            var dbItemsMap = ((IEnumerable<BaseEntity>)dbItemsEntry.CurrentValue)
                .ToDictionary(e => e.Id);

            var items = (IEnumerable<BaseEntity>)accessor.GetOrCreate(entity, false);

            foreach (var item in items)
            {
                EntityEntry entityEntryChild = null;
                if (!dbItemsMap.TryGetValue(item.Id, out var oldItem))
                {
                    accessor.Add(dbEntity, item, false);
                    Db.Entry(item).State = EntityState.Added;
                    entityEntryChild = Db.Entry(item); 
                }
                else
                {
                    Db.Entry(oldItem).CurrentValues.SetValues(item);
                    Db.Entry(oldItem).State = EntityState.Modified;

                    entityEntryChild = Db.Entry(oldItem); 

                    dbItemsMap.Remove(item.Id);
                }

            }

            foreach (var oldItem in dbItemsMap.Values)
            {
                accessor.Remove(dbEntity, oldItem);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var current = await DbSet.SingleOrDefaultAsync(x => x.Id == id);
                if (current == null)
                {
                    return false;
                }

                DbSet.Remove(current);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            var entries = Db.ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is BaseEntity && (
                                    e.State == EntityState.Added
                                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedIn = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedIn = DateTime.Now;
                }
            }

            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
