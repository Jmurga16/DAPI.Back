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
    public class AccountingSeatController : ControllerBase
    {
        private IAccountingSeatsDAL accountingSeatsDAL;

        TblAccountingSeat Convert(AccountingSeatModel a_seat)
        {
            return new TblAccountingSeat
            {
                SeatId = a_seat.SeatId,
                AccountId = a_seat.AccountId,
                CreationDate = a_seat.CreationDate,
                Currency = a_seat.Currency,
                SeatValue = a_seat.SeatValue,
                CustomerId = a_seat.CustomerId,
                Reference = a_seat.Reference
            };
        }

        AccountingSeatModel Convert(TblAccountingSeat a_Seat)
        {
            return new AccountingSeatModel
            {
                SeatId = a_Seat.SeatId,
                AccountId = a_Seat.AccountId,
                CreationDate = a_Seat.CreationDate,
                Currency = a_Seat.Currency,
                SeatValue = a_Seat.SeatValue,
                CustomerId = a_Seat.CustomerId,
                Reference = a_Seat.Reference
            };
        }

        
        public AccountingSeatController()
        {
            accountingSeatsDAL = new AccountingSeatsDALImpl(new AccountingSoftDBContext());
        }

        
        [HttpGet]
        public JsonResult Get()
        {
            List<TblAccountingSeat> a_Seats = new List<TblAccountingSeat>();
            a_Seats = accountingSeatsDAL.GetAll().ToList();

            List<AccountingSeatModel> result = new List<AccountingSeatModel>();
            foreach (TblAccountingSeat a_Seat in a_Seats)
            {
                result.Add(Convert(a_Seat));
            }
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TblAccountingSeat a_Seat = accountingSeatsDAL.Get(id);
            return new JsonResult(Convert(a_Seat));
        }
        

        
        [HttpPost]
        public JsonResult Post([FromBody] AccountingSeatModel a_seat)
        {
            TblAccountingSeat entity = Convert(a_seat);
            accountingSeatsDAL.Add(entity);
            return new JsonResult(Convert(entity));
        }
        

        
        [HttpPut]
        public JsonResult Put([FromBody] AccountingSeatModel a_seat)
        {
            TblAccountingSeat entity = Convert(a_seat);
            accountingSeatsDAL.Update(entity);
            return new JsonResult(Convert(entity));
        }
        

        
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            TblAccountingSeat A_Seat = new TblAccountingSeat { SeatId = id };
            accountingSeatsDAL.Remove(A_Seat);
            return new JsonResult(A_Seat);
        }
    }
}

