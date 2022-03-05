using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Tools;
using Microsoft.EntityFrameworkCore;
using DataLayer.Tools.Enums;

namespace DataLayer.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(Tools.Options options) : base()
        {
            Options = options;
        }
        protected Options Options { get; set; }
        private DataBaseContext _dataBaseContext;

        internal DataBaseContext DataBaseContext
        {
            get
            {
                if (_dataBaseContext == null)
                {
                    var optionsBuilder =
                        new DbContextOptionsBuilder<DataBaseContext>();

                    switch (Options.Provider)
                    {
                        case Tools.Enums.Provider.SqlServer:
                            {
                                optionsBuilder.UseSqlServer
                                    (connectionString: Options.ConnectionString);

                                break;
                            }

                        case Provider.MySQL:
                            {
                                //optionsBuilder.UseMySql
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Provider.Oracel:
                            {
                                //optionsBuilder.UseOracle
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Provider.PostgreSQL:
                            {
                                //optionsBuilder.UsePostgreSQL
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Provider.InMemmory:
                            {
                                //optionsBuilder.UseInMemoryDatabase(databaseName: "Temp");
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    _dataBaseContext = new DataBaseContext();
                    //_dataBaseContext = new DataBaseContext(options: optionsBuilder.Options);
                }
                return _dataBaseContext;
            }
        }
        public bool IsDisposed { get; protected set; }

        //**********************************************
        public virtual void Dispose(bool Disposing)
        {
            if (IsDisposed)
            {
                return;
            }
            else if (Disposing)
            {
                if (_dataBaseContext != null)
                {
                    //_dataBaseContext.Dispose();
                    _dataBaseContext = null;
                }
            }

            IsDisposed = true;
        }
        //**********************************************
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Repository<T> GetRepository<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public virtual void save()
        {
            _dataBaseContext.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            await _dataBaseContext.SaveChangesAsync();
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
