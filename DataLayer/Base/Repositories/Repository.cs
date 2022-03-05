using DataLayer.Tools;
using Microsoft.EntityFrameworkCore;
using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Base
{
    public class Repository<T> : Object, IRepository<T> where T : Entity
    {
        internal DataBaseContext _dataBaseContext { get; }
        internal DbSet<T> DbSet { get; }
        internal Repository(DataBaseContext dataBaseContext) : base()
        {
            _dataBaseContext =
                dataBaseContext ?? throw new System.ArgumentNullException(paramName: nameof(dataBaseContext));
            // **************************************************
            DbSet = _dataBaseContext.Set<T>();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }
            DbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }
            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });
        }

        public virtual bool DeleteById(Guid id)
        {
            T entity = GetById(id);
            if (entity == null)
            {
                return false;
            }

            Delete(entity);
            return true;
        }

        public virtual async Task<bool> DeleteByIdAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);

            if (entity == null)
            {
                return false;
            }
            await DeleteAsync(entity);
            return true;
        }

        public virtual IList<T> GetAll()
        {
            var res = DbSet.ToList();
            return res;
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            var res = await DbSet.ToListAsync();
            return res;
        }

        public virtual T GetById(Guid id)
        {
            var res = DbSet.Find(keyValues: id);
            return res;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var res = await DbSet.FindAsync(keyValues: id);
            return res;
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }
            DbSet.Add(entity);
        }

        public virtual async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }
            await DbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }
            DbSet.Update(entity);

            //Microsoft.EntityFrameworkCore.EntityState
            //	entityState = DatabaseContext.Entry(entity).State;

            //if (entityState == Microsoft.EntityFrameworkCore.EntityState.Detached)
            //{
            //	DbSet.Attach(entity);
            //}

            ////entityState =
            ////	DatabaseContext.Entry(entity).State;

            ////DatabaseContext.Entry(entity).State =
            ////	Microsoft.EntityFrameworkCore.EntityState.Modified;

            ////entityState =
            ////	DatabaseContext.Entry(entity).State;

            //_ =
            //	DatabaseContext.Entry(entity).State;

            //DatabaseContext.Entry(entity).State =
            //	Microsoft.EntityFrameworkCore.EntityState.Modified;

            //_ =
            //	DatabaseContext.Entry(entity).State;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }
            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });
        }

        public async Task<int> Count()
        {
            int result = await DbSet.CountAsync();
            return result;
        }

    }
}
