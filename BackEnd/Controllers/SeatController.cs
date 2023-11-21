using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private ISeatDAL seatDAL;
       

        public SeatController()
        {
            seatDAL = new SeatDALImpl(new AccountingSoftDBContext());            
        }

        TblSeat Convert(SeatModel entity)
        {
            return new TblSeat
            {
                ID = entity.ID,
                DATE_SEAT = entity.DATE_SEAT,
                CURRENCY = entity.CURRENCY,
                EXCHANGE_RATE = entity.EXCHANGE_RATE,
                REFERENCE = entity.REFERENCE,
                CUSTOMER_ID = entity.CUSTOMER_ID,
                STATUS = entity.STATUS
            };
        }

        SeatModel Convert(TblSeat entity)
        {
            return new SeatModel
            {
                ID = entity.ID,
                DATE_SEAT = entity.DATE_SEAT,
                CURRENCY = entity.CURRENCY,
                EXCHANGE_RATE = entity.EXCHANGE_RATE,
                REFERENCE = entity.REFERENCE,
                CUSTOMER_ID = entity.CUSTOMER_ID,
                STATUS = entity.STATUS
            };
        }

        #region Metodos para Asientos 
        [HttpGet]
        public JsonResult Get()
        {
            List<TblSeat> seats = new List<TblSeat>();
            seats = seatDAL.GetAll().ToList();

            List<SeatModel> result = new List<SeatModel>();
            foreach (TblSeat seat in seats)
            {
                result.Add(Convert(seat));
            }
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TblSeat seat = seatDAL.Get(id);
            return new JsonResult(Convert(seat));
        }

        [HttpPost]
        public JsonResult Post([FromBody] SeatModel seat)
        {
            TblSeat entity = Convert(seat);
            entity.ID = null;
            seatDAL.Add(entity);
            return new JsonResult(Convert(entity));
        }

        [HttpPut]
        public JsonResult Put([FromBody] SeatModel seat)
        {
            TblSeat entity = Convert(seat);
            seatDAL.Update(entity);
            return new JsonResult(Convert(entity));
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            TblSeat seat = new TblSeat { ID = id };
            seatDAL.Remove(seat);
            return new JsonResult(seat);
        }

        #endregion


    }
}
