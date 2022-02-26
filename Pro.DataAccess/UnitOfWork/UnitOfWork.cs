using Pro.DataAccess.Contracts;
using Pro.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Pro.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataBaseContext _Context { get; }
         private IMapper _mapper;
    //    private ISickRepository _sickRepository;
       
        private readonly IConfiguration _configuration;

        public UnitOfWork(DataBaseContext context, IMapper mapper, IConfiguration configuration)
        {
            _Context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class
        {
            IBaseRepository<TEntity> repository = new BaseRepository<TEntity, DataBaseContext>(_Context);
            return repository;
        }

   

        public async Task Commit()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
