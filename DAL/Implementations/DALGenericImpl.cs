using System;
using DAL.Interfaces;
using Entities.Entities;
namespace DAL.Implementations
{
    public class DALGenericImpl<TEntity> : IDALGeneric<TEntity> where TEntity : class
    {
        protected readonly AccountingSoftDBContext Context;

        public DALGenericImpl(AccountingSoftDBContext context)
        {
            Context = context;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TEntity Get(int id)
        {
            try
            {
                return Context.Set<TEntity>().Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Context.Set<TEntity>().ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Attach(entity);
                Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return true;
            }
            catch
            {
                return false; ;
            }
        }
    }
}

