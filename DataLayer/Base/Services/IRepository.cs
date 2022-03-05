using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Base
{
    public interface IRepository<T> where T : Models.Base.Entity
    {
        void Insert(T entity);
        Task InsertAsync(T entity);

        void Update(T entity);
        Task UpdateAsync(T entity);

        void Delete(T entity);
        Task DeleteAsync(T entity);

        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);

        bool DeleteById(Guid id);
        Task<bool> DeleteByIdAsync(Guid id);

        IList<T> GetAll();
        Task<IList<T>> GetAllAsync();

        Task<int> Count();
    } 
}
