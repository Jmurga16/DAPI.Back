using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using DAL.Implementations;
using Entities.Entities;
using BackEnd.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingTableController : ControllerBase
    {
        private IAccountingTableDAL accountingtableDAL;

        TblAccountingTable Convert(AccountingTableModel a_table)
        {
            return new TblAccountingTable
            {
                ID = a_table.ID,
                MONTO = a_table.MONTO,
                Currency = a_table.Currency,
                ID_CUENTA = a_table.ID_CUENTA,
                DESCRIPCION = a_table.DESCRIPCION,
                ID_ASIENTO = a_table.ID_ASIENTO
                
            };
        }

        AccountingTableModel Convert(TblAccountingTable a_table)
        {
            return new AccountingTableModel
            {
                ID = a_table.ID,
                MONTO = a_table.MONTO,
                Currency = a_table.Currency,
                ID_CUENTA = a_table.ID_CUENTA,
                DESCRIPCION = a_table.DESCRIPCION,
                ID_ASIENTO = a_table.ID_ASIENTO
            };
        }

        
        public AccountingTableController()
        {
            accountingtableDAL = new AccountingTableDALImpl(new AccountingSoftDBContext());
        }

        
        [HttpGet]
        public JsonResult Get()
        {
            List<TblAccountingTable> a_Tables = new List<TblAccountingTable>();
            a_Tables = accountingtableDAL.GetAll().ToList();

            List<AccountingTableModel> result = new List<AccountingTableModel>();
            foreach (TblAccountingTable a_Table in a_Tables)
            {
                result.Add(Convert(a_Table));
            }
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TblAccountingTable a_Table = accountingtableDAL.Get(id);
            return new JsonResult(Convert(a_Table));
        }
        

        
        [HttpPost]
        public JsonResult Post([FromBody] AccountingTableModel a_table)
        {
            TblAccountingTable entity = Convert(a_table);
            accountingtableDAL.Add(entity);
            return new JsonResult(Convert(entity));
        }
        

        
        [HttpPut]
        public JsonResult Put([FromBody] AccountingTableModel a_table)
        {
            TblAccountingTable entity = Convert(a_table);
            accountingtableDAL.Update(entity);
            return new JsonResult(Convert(entity));
        }
        

        
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            TblAccountingTable A_Table = new TblAccountingTable { ID = id };
            accountingtableDAL.Remove(A_Table);
            return new JsonResult(A_Table);
        }
    }
}

