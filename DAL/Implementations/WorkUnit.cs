using System;
using DAL.Interfaces;
using Entities.Entities;
namespace DAL.Implementations
{
    public class WorkUnit<T> : IDisposable where T : class
    {
        private readonly AccountingSoftDBContext context;
        public IDALGeneric<T> genericDAL;

        public WorkUnit(AccountingSoftDBContext _context)
        {
            context = _context;
            genericDAL = new DALGenericImpl<T>(context);
        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

