using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ILogDAL logDAL;
        private IEmployeeDAL employeeDAL;

        public LogController()
        {
            logDAL = new LogDALImpl(new AccountingSoftDBContext());
        }

        TblLog Convert(LogModel log)
        {
            return new TblLog
            {
                LogId = log.LogId,
                EmployeeId = log.EmployeeId,
                LogDescription = log.LogDescription,
                DateTime = log.DateTime,
                Employee = log.Employee
            };
        }

        LogModel Convert(TblLog log)
        {
            return new LogModel
            {
                LogId = log.LogId,
                EmployeeId = log.EmployeeId,
                LogDescription = log.LogDescription,
                DateTime = log.DateTime,
            };
        }

        [HttpGet]
        public JsonResult Get()
        {
            List<TblLog> logs = new List<TblLog>();
            logs = logDAL.GetAll().ToList();

            return new JsonResult(logs);
        }

        [HttpGet("{Union}")]
        public JsonResult Get2()
        {

            List<TblLog> logs = new List<TblLog>();
            logs = logDAL.GetAll().ToList();

            List<TblEmployee> employees = new List<TblEmployee>();
            employees = employeeDAL.GetAll().ToList();


            List<LogModel> result = new List<LogModel>();
            foreach (TblLog log in logs)
            {
                foreach (TblEmployee employee in employees)
                {
                    if (log.EmployeeId == employee.EmployeeId)
                    {
                        log.Employee = employee;
                    }
                }
                result.Add(Convert(log));
            }

            return new JsonResult(result);

        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TblLog log = logDAL.Get(id);
            return new JsonResult(log);
        }



        [HttpPost]
        public JsonResult Post([FromBody] LogModel log)
        {
            TblLog entity = Convert(log);
            logDAL.Add(entity);
            return new JsonResult(Convert(entity));
        }



        [HttpPut]
        public JsonResult Put([FromBody] LogModel log)
        {
            TblLog entity = Convert(log);
            logDAL.Update(entity);
            return new JsonResult(Convert(entity));
        }



        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            TblLog log = new TblLog { LogId = id };
            logDAL.Delete(id);

            return new JsonResult(log);
        }
    }
}
