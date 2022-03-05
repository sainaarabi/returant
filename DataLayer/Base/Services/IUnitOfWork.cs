using Models.Base;
using System;
using System.Threading.Tasks;

namespace DataLayer.Base
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsDisposed { get; }

        void save();
        Task SaveAsync();
        Repository<T> GetRepository<T>() where T : Entity;
    }
}
