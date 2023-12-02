using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

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
                AccountCode = account.AccountCode,
                AccountType = account.AccountType,
                Conversion = account.Conversion,
                Active = account.Active,
            };
        }

        AccountModel Convert(TblAccountCatalog account)
        {
            return new AccountModel
            {
                AccountId = account.AccountId,
                AccountName = account.AccountName,
                AccountCode = account.AccountCode,
                AccountType = account.AccountType,
                Conversion = account.Conversion,
                Active = account.Active,
            };
        }

        AccountSelectResponseModel ConvertToSelect(TblAccountCatalog account)
        {
            return new AccountSelectResponseModel
            {
                id = account.AccountId,
                text = account.AccountCode + " | " + account.AccountName,
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
            accounts = accountDAL.GetAll().Where(a => a.Active).ToList();

            return new JsonResult(accounts);
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
            var success = accountDAL.Delete(id);

            return new JsonResult(success);
        }

        [HttpGet("Select")]
        public JsonResult GetSelect()
        {
            List<TblAccountCatalog> accounts = new List<TblAccountCatalog>();
            accounts = accountDAL.GetAll().ToList();

            List<AccountSelectResponseModel> result = new List<AccountSelectResponseModel>();
            foreach (TblAccountCatalog account in accounts)
            {
                result.Add(ConvertToSelect(account));
            }

            var response = new
            {
                results = result
            };

            return new JsonResult(response);
        }


    }
}

