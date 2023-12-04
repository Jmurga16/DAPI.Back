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
    public class EmployeeController : ControllerBase
    {
        private IEmployeeDAL employeeDAL;
        private IEnumerable<TblEmployee> employees;

        TblEmployee Convert(EmployeeModel employee)
        {
            return new TblEmployee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Username = employee.Username,
                EmailAddress = employee.EmailAddress,
                Password = employee.Password,
                Active = employee.Active,
            };
        }

        EmployeeModel Convert(TblEmployee employee)
        {
            return new EmployeeModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Username = employee.Username,
                EmailAddress = employee.EmailAddress,
                Password = employee.Password,
                Active = employee.Active,

            };
        }

        public EmployeeController()
        {
            employeeDAL = new EmployeeDALImpl(new AccountingSoftDBContext());
        }


        [HttpGet]
        public JsonResult Get()
        {

            List<TblEmployee> employees = new List<TblEmployee>();
            employees = employeeDAL.GetAll().Where(a => a.Active).ToList();

            return new JsonResult(employees);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TblEmployee employee = employeeDAL.Get(id);
            return new JsonResult(Convert(employee));
        }



        [HttpPost]
        public JsonResult Post([FromBody] EmployeeModel employee)
        {
            TblEmployee entity = Convert(employee);
            employeeDAL.Add(entity);
            return new JsonResult(Convert(entity));
        }



        [HttpPut]
        public JsonResult Put([FromBody] EmployeeModel employee)
        {
            TblEmployee entity = Convert(employee);
            employeeDAL.Update(entity);
            return new JsonResult(Convert(entity));
        }



        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            
            TblEmployee employee = new TblEmployee { EmployeeId = id };
            employeeDAL.Delete(id);

            return new JsonResult(employee);

        }
    }
}