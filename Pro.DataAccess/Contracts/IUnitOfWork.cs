using Pro.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pro.DataAccess
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
      //  ISickRepository SickRepository { get; }
        DataBaseContext _Context { get; }
        Task Commit();
    }
}
