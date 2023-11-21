using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class SeatDetailDALImpl : ISeatDetailDAL
    {
        AccountingSoftDBContext context;

        public SeatDetailDALImpl()
        {
            context = new AccountingSoftDBContext();
        }

        public SeatDetailDALImpl(AccountingSoftDBContext _Context)
        {
            context = _Context;
        }

        public bool Add(TblSeatDetail entity)
        {
            try
            {
                using (WorkUnit<TblSeatDetail> unit = new WorkUnit<TblSeatDetail>(context))
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

        public TblSeatDetail Get(int id)
        {
            try
            {
                TblSeatDetail account;
                using (WorkUnit<TblSeatDetail> unit = new WorkUnit<TblSeatDetail>(context))
                {
                    account = unit.genericDAL.Get(id);
                }
                return account;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TblSeatDetail> GetAll()
        {
            try
            {
                IEnumerable<TblSeatDetail> accounts;
                using (WorkUnit<TblSeatDetail> unit = new WorkUnit<TblSeatDetail>(context))
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

        public bool Remove(TblSeatDetail entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblSeatDetail> unit = new WorkUnit<TblSeatDetail>(context))
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

        public bool Update(TblSeatDetail entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblSeatDetail> unit = new WorkUnit<TblSeatDetail>(context))
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
    }
}
