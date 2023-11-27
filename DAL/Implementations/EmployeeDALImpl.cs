using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class EmployeeDALImpl : IEmployeeDAL
    {
        AccountingSoftDBContext context;

        public EmployeeDALImpl()
        {
            context = new AccountingSoftDBContext();
        }

        public EmployeeDALImpl(AccountingSoftDBContext _Context)
        {
            context = _Context;
        }

        public bool Add(TblEmployee entity)
        {
            try
            {
                using (WorkUnit<TblEmployee> unit = new WorkUnit<TblEmployee>(context))
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

        public TblEmployee Get(int id)
        {
            try
            {
                TblEmployee employee;
                using (WorkUnit<TblEmployee> unit = new WorkUnit<TblEmployee>(context))
                {
                    employee = unit.genericDAL.Get(id);
                }
                return employee;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TblEmployee> GetAll()
        {
            try
            {
                IEnumerable<TblEmployee> employees;
                using (WorkUnit<TblEmployee> unit = new WorkUnit<TblEmployee>(context))
                {
                    employees = unit.genericDAL.GetAll();
                }
                return employees;
            }
            catch(Exception ex)  
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Remove(TblEmployee entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblEmployee> unit = new WorkUnit<TblEmployee>(context))
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

        public bool Update(TblEmployee entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblEmployee> unit = new WorkUnit<TblEmployee>(context))
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

