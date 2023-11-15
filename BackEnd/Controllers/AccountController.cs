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
    public class AccountController : ControllerBase
    {
        private IAccountDAL accountDAL;

        TblAccountCatalog Convert(AccountModel account)
        {
            return new TblAccountCatalog
            {
                AccountId = account.AccountId,
                AccountName = account.AccountName,
                AccountType = account.AccountType,
                Conversion = account.Conversion
            };
        }

        AccountModel Convert(TblAccountCatalog account)
        {
            return new AccountModel
            {
                AccountId = account.AccountId,
                AccountName = account.AccountName,
                AccountType = account.AccountType,
                Conversion = account.Conversion
            };
        }

        
        public AccountController()
        {
            accountDAL = new AccountDALImpl(new AccountingSoftDBContext());
        }

        
        [HttpGet]
        public JsonResult Get()
        {
            List<TblAccountCatalog> accounts = new List<TblAccountCatalog>();
            accounts = accountDAL.GetAll().ToList();

            List<AccountModel> result = new List<AccountModel>();
            foreach (TblAccountCatalog account in accounts)
            {
                result.Add(Convert(account));
            }
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TblAccountCatalog account = accountDAL.Get(id);
            return new JsonResult(Convert(account));
        }
        

        
        [HttpPost]
        public JsonResult Post([FromBody] AccountModel account)
        {
            TblAccountCatalog entity = Convert(account);
            accountDAL.Add(entity);
            return new JsonResult(Convert(entity));
        }
        

        
        [HttpPut]
        public JsonResult Put([FromBody] AccountModel account)
        {
            TblAccountCatalog entity = Convert(account);
            accountDAL.Update(entity);
            return new JsonResult(Convert(entity));
        }
        

        
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            TblAccountCatalog account = new TblAccountCatalog { AccountId = id };
            accountDAL.Remove(account);
            return new JsonResult(account);
        }
    }
}

