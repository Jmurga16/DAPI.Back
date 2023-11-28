using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IEmployeeDAL employeeDAL;

        TblEmployee Convert(EmployeeModel employee)
        {
            return new TblEmployee
            {
                Username = employee.Username,
                EmailAddress = employee.EmailAddress,
                Password = employee.Password
            };
        }

        EmployeeModel Convert(TblEmployee employee)
        {
            return new EmployeeModel
            {
                Username = employee.Username,
                EmailAddress = employee.EmailAddress,
                Password = employee.Password
            };
        }

        #region Constructor
        public LoginController()
        {
            employeeDAL = new EmployeeDALImpl(new AccountingSoftDBContext());
        }

        #endregion

        #region Consulta
        [HttpGet]
        public JsonResult Get()
        {
            List<TblEmployee> employees = new List<TblEmployee>();
            employees = employeeDAL.GetAll().ToList();

            List<EmployeeModel> result = new List<EmployeeModel>();
            foreach (TblEmployee employee in employees)
            {
                result.Add(Convert(employee));
            }
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TblEmployee employee = employeeDAL.Get(id);
            return new JsonResult(Convert(employee));
        }


        [HttpPost("auth")]
        public JsonResult Post([FromBody] LoginModel login)
        {
            bool result = false;
            var IdEmployee = 0;

            List<TblEmployee> employees = new List<TblEmployee>();
            employees = employeeDAL.GetAll().ToList();

            foreach (TblEmployee employee in employees)
            {
                Console.WriteLine(employee);
                if (employee.Username == login.username && employee.Password == login.password)
                {
                    IdEmployee = employee.EmployeeId;
                    result = true;
                }
            }

            return new JsonResult(new { success = result, employeeId = IdEmployee });

        }

    }
}
#endregion