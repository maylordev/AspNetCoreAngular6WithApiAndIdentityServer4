// using AspnetCore.EFCore_Dapper.Data.Mappings.Dapper;
// using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories.Common;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using LiveStreams.Api.Models.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace LiveStreams.Api.Repositories.Common
{
    public interface IBaseRepository<T> where T : class
    {

        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
    public abstract class BaseRepository<C, T> :
        IBaseRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }
        private readonly IConfiguration _config;
        protected readonly DbContext _dbContext;
        public BaseRepository(
            DbContext dbContext,
            IConfiguration config
            )
        {
            _dbContext = dbContext;
            _config = config;
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}