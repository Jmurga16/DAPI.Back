﻿using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatDetailController : ControllerBase
    {
        private ISeatDetailDAL seatDetailDAL;


        public SeatDetailController()
        {
            seatDetailDAL = new SeatDetailDALImpl(new AccountingSoftDBContext());
        }

        TblSeatDetail Convert(SeatDetailModel entity)
        {
            return new TblSeatDetail
            {
                ID = entity.ID,
                SEAT_ID = entity.SEAT_ID,
                ACCOUNT_ID = entity.ACCOUNT_ID,
                AMOUNT = entity.AMOUNT,
                DESCRIPTION = entity.DESCRIPTION,
                Active = entity.Active
            };
        }

        SeatDetailModel Convert(TblSeatDetail entity)
        {
            return new SeatDetailModel
            {
                ID = entity.ID,
                SEAT_ID = entity.SEAT_ID,
                ACCOUNT_ID = entity.ACCOUNT_ID,
                AMOUNT = entity.AMOUNT,
                DESCRIPTION = entity.DESCRIPTION,
                Active = entity.Active
            };
        }

        #region Metodos para Detalle de Asientos 
        [HttpGet]
        public JsonResult Get()
        {
            List<TblSeatDetail> seatDetails = new List<TblSeatDetail>();
            seatDetails = seatDetailDAL.GetAll().Where(a => a.Active).ToList();


            return new JsonResult(seatDetails);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TblSeatDetail seatDetail = seatDetailDAL.Get(id);
            return new JsonResult(Convert(seatDetail));
        }

        [HttpPost]
        public JsonResult Post([FromBody] SeatDetailModel seatDetail)
        {
            TblSeatDetail entity = Convert(seatDetail);
            entity.ID = null;
            seatDetailDAL.Add(entity);
            return new JsonResult(Convert(entity));
        }

        [HttpPut]
        public JsonResult Put([FromBody] SeatDetailModel seatDetail)
        {
            TblSeatDetail entity = Convert(seatDetail);
            seatDetailDAL.Update(entity);
            return new JsonResult(Convert(entity));
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            TblSeatDetail seatDetail = new TblSeatDetail { ID = id };
            seatDetailDAL.Remove(seatDetail);
            return new JsonResult(seatDetail);
        }

        [HttpGet("GetBySeat/{id}")]
        public JsonResult GetBySeat(int id)
        {

            List<TblSeatDetail> seatDetails = new List<TblSeatDetail>();
            seatDetails = seatDetailDAL.GetAll().Where(a => a.Active).ToList();

            List<TblSeatDetail> result = new List<TblSeatDetail>();

            foreach (TblSeatDetail detail in seatDetails)
            {
                if (detail.SEAT_ID == id)
                {
                    result.Add(detail);
                }
            }


            return new JsonResult(result);
        }

        #endregion
    }
}
