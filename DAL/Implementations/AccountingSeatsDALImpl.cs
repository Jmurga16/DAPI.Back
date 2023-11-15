using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class AccountingSeatsDALImpl : IAccountingSeatsDAL
    {
        AccountingSoftDBContext context;

        public AccountingSeatsDALImpl()
        {
            context = new AccountingSoftDBContext();
        }

        public AccountingSeatsDALImpl(AccountingSoftDBContext _Context)
        {
            context = _Context;
        }

        public bool Add(TblAccountingSeat entity)
        {
            try
            {
                using (WorkUnit<TblAccountingSeat> unit = new WorkUnit<TblAccountingSeat>(context))
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

        public TblAccountingSeat Get(int id)
        {
            try
            {
                TblAccountingSeat a_Seats;
                using (WorkUnit<TblAccountingSeat> unit = new WorkUnit<TblAccountingSeat>(context))
                {
                    a_Seats = unit.genericDAL.Get(id);
                }
                return a_Seats;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TblAccountingSeat> GetAll()
        {
            try
            {
                IEnumerable<TblAccountingSeat> a_Seats;
                using (WorkUnit<TblAccountingSeat> unit = new WorkUnit<TblAccountingSeat>(context))
                {
                    a_Seats = unit.genericDAL.GetAll();
                }
                return a_Seats;
            }
            catch
            {
                return null;
            }
        }

        public bool Remove(TblAccountingSeat entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblAccountingSeat> unit = new WorkUnit<TblAccountingSeat>(context))
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

        public bool Update(TblAccountingSeat entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblAccountingSeat> unit = new WorkUnit<TblAccountingSeat>(context))
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

