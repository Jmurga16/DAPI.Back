using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class SeatDALImpl : ISeatDAL
    {
        AccountingSoftDBContext context;

        public SeatDALImpl()
        {
            context = new AccountingSoftDBContext();
        }

        public SeatDALImpl(AccountingSoftDBContext _Context)
        {
            context = _Context;
        }

        public bool Add(TblSeat entity)
        {
            try
            {
                using (WorkUnit<TblSeat> unit = new WorkUnit<TblSeat>(context))
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

        public TblSeat Get(int id)
        {
            try
            {
                TblSeat account;
                using (WorkUnit<TblSeat> unit = new WorkUnit<TblSeat>(context))
                {
                    account = unit.genericDAL.Get(id);
                    unit.Dispose();
                }
                return account;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TblSeat> GetAll()
        {
            try
            {
                IEnumerable<TblSeat> accounts;
                using (WorkUnit<TblSeat> unit = new WorkUnit<TblSeat>(context))
                {
                    accounts = unit.genericDAL.GetAll();
                }
                return accounts;
            }
            catch
            {
                return null;
            }
        }

        public bool Remove(TblSeat entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblSeat> unit = new WorkUnit<TblSeat>(context))
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

        public bool Update(TblSeat entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblSeat> unit = new WorkUnit<TblSeat>(context))
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
            TblSeat entity;
            try
            {
                using (WorkUnit<TblSeat> unit = new WorkUnit<TblSeat>(context))
                {
                    entity = unit.genericDAL.Get(id);
                    entity.STATUS = false;
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

        public bool Post(int id)
        {
            bool result = false;
            TblSeat entity;
            try
            {
                using (WorkUnit<TblSeat> unit = new WorkUnit<TblSeat>(context))
                {
                    entity = unit.genericDAL.Get(id);
                    entity.STATUS = true;
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
