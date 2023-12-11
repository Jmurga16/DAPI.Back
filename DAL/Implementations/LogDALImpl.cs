using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class LogDALImpl : ILogDAL
    {
        AccountingSoftDBContext context;

        public LogDALImpl()
        {
            context = new AccountingSoftDBContext();
        }

        public LogDALImpl(AccountingSoftDBContext _Context)
        {
            context = _Context;
        }

        public bool Add(TblLog entity)
        {
            try
            {
                using (WorkUnit<TblLog> unit = new WorkUnit<TblLog>(context))
                {
                    unit.genericDAL.Add(entity);
                    unit.Complete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TblLog Get(int id)
        {
            try
            {
                TblLog log;
                using (WorkUnit<TblLog> unit = new WorkUnit<TblLog>(context))
                {
                    log = unit.genericDAL.Get(id);
                    unit.Dispose();
                }
                return log;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TblLog> GetAll()
        {
            try
            {
                IEnumerable<TblLog> logs;
                using (WorkUnit<TblLog> unit = new WorkUnit<TblLog>(context))
                {
                    logs = unit.genericDAL.GetAll();
                    unit.Dispose();
                }
                return logs;
            }
            catch
            {
                return null;
            }
        }

        public bool Remove(TblLog entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblLog> unit = new WorkUnit<TblLog>(context))
                {
                    unit.genericDAL.Remove(entity);
                    result = unit.Complete();
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool Update(TblLog entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblLog> unit = new WorkUnit<TblLog>(context))
                {
                    unit.genericDAL.Update(entity);
                    result = unit.Complete();
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
             
        public bool Delete(int id)
        {
            bool result = false;
            TblLog entity;
            try
            {
                using (WorkUnit<TblLog> unit = new WorkUnit<TblLog>(context))
                {
                    entity = unit.genericDAL.Get(id);

                    unit.genericDAL.Update(entity);
                    result = unit.Complete();
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

    }
}

