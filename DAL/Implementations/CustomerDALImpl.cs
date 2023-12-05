using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class CustomerDALImpl : ICustomerDAL
    {
        AccountingSoftDBContext context;

        public CustomerDALImpl()
        {
            context = new AccountingSoftDBContext();
        }

        public CustomerDALImpl(AccountingSoftDBContext _Context)
        {
            context = _Context;
        }

        public bool Add(TblCustomer entity)
        {
            try
            {
                using (WorkUnit<TblCustomer> unit = new WorkUnit<TblCustomer>(context))
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

        public TblCustomer Get(int id)
        {
            try
            {
                TblCustomer customer;
                using (WorkUnit<TblCustomer> unit = new WorkUnit<TblCustomer>(context))
                {
                    customer = unit.genericDAL.Get(id);
                }
                return customer;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TblCustomer> GetAll()
        {
            try
            {
                IEnumerable<TblCustomer> customers;
                using (WorkUnit<TblCustomer> unit = new WorkUnit<TblCustomer>(context))
                {
                    customers = unit.genericDAL.GetAll();
                }
                return customers;
            }
            catch
            {
                return null;
            }
        }

        public bool Remove(TblCustomer entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblCustomer> unit = new WorkUnit<TblCustomer>(context))
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

        public bool Update(TblCustomer entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblCustomer> unit = new WorkUnit<TblCustomer>(context))
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
            TblCustomer entity;
            try
            {
                using (WorkUnit<TblCustomer> unit = new WorkUnit<TblCustomer>(context))
                {
                    entity = unit.genericDAL.Get(id);
                    entity.Active = false;

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

