using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class AccountingTableDALImpl : IAccountingTableDAL
    {
        AccountingSoftDBContext context;

        public AccountingTableDALImpl()
        {
            context = new AccountingSoftDBContext();
        }

        public AccountingTableDALImpl(AccountingSoftDBContext _Context)
        {
            context = _Context;
        }

        public bool Add(TblAccountingTable entity)
        {
            try
            {
                using (WorkUnit<TblAccountingTable> unit = new WorkUnit<TblAccountingTable>(context))
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

        public TblAccountingTable Get(int id)
        {
            try
            {
                TblAccountingTable a_table;
                using (WorkUnit<TblAccountingTable> unit = new WorkUnit<TblAccountingTable>(context))
                {
                    a_table = unit.genericDAL.Get(id);
                }
                return a_table;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TblAccountingTable> GetAll()
        {
            try
            {
                IEnumerable<TblAccountingTable> a_tables;
                using (WorkUnit<TblAccountingTable> unit = new WorkUnit<TblAccountingTable>(context))
                {
                    a_tables = unit.genericDAL.GetAll();
                }
                return a_tables;
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error o lanzar una excepción personalizada con un mensaje descriptivo.
                // Por ejemplo:
                throw new Exception("Error al obtener los datos de la base de datos.", ex);
            }
        }

        public bool Remove(TblAccountingTable entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblAccountingTable> unit = new WorkUnit<TblAccountingTable>(context))
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

        public bool Update(TblAccountingTable entity)
        {
            bool result = false;
            try
            {
                using (WorkUnit<TblAccountingTable> unit = new WorkUnit<TblAccountingTable>(context))
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
            TblAccountingTable entity = Get(id);
            //entity.Active = false;
            try
            {
                using (WorkUnit<TblAccountingTable> unit = new WorkUnit<TblAccountingTable>(context))
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

