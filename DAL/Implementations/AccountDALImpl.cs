using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class AccountDALImpl : IAccountDAL
    {
        AccountingSoftDBContext context;

        public AccountDALImpl()
        {
            context = new AccountingSoftDBContext();
        }

        public AccountDALImpl(AccountingSoftDBContext _Context)
        {
            context = _Context;
        }

        public bool Add(TblAccountCatalog entity)
        {
            try
            {
                using (WorkUnit<TblAccountCatalog> unit = new WorkUnit<TblAccountCatalog>(context))
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

        public TblAccountCatalog Get(int id)
        {
            try
            {
                TblAccountCatalog account;
                using (WorkUnit<TblAccountCatalog> unit = new WorkUnit<TblAccountCatalog>(context))
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

        public IEnumerable<TblAccountCatalog> GetAll()
        {
            try
            {
                IEnumerable<TblAccountCatalog> accounts;
                using (WorkUnit<TblAccountCatalog> unit = new WorkUnit<TblAccountCatalog>(context))
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

        public bool Remove(TblAccountCatalog entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblAccountCatalog> unit = new WorkUnit<TblAccountCatalog>(context))
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

        public bool Update(TblAccountCatalog entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblAccountCatalog> unit = new WorkUnit<TblAccountCatalog>(context))
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

