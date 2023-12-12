using BackEnd.Models;
using BackEnd.Services;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IEmployeeDAL employeeDAL;
        private IEmailSenderService senderService;
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

        [HttpPost("recover/{correo}")]
        public JsonResult RecoverPassword(string correo)
        {
            bool result = false;
            var IdEmployee = 0;
            var password = "";

            List<TblEmployee> employees = new List<TblEmployee>();
            employees = employeeDAL.GetAll().ToList();

            foreach (TblEmployee employee in employees)
            {
                if (employee.EmailAddress == correo)
                {
                    IdEmployee = employee.EmployeeId;
                    password = employee.Password;
                    result = true;
                }
            }

            MailRequest request = new MailRequest();
            request.Email = correo;
            request.Subject = "Recover Password";
            request.Body = "Your password is: " + password;

            //SendEmail(request);

            return new JsonResult(new { success = result, employeeId = IdEmployee, password = password });

        }

        [HttpPost("change/{id}/{password}")]
        public JsonResult ChangePassword(int id,string password)
        {
            bool result = false;
            
            result = employeeDAL.ChangePassword(id,password);
            
            return new JsonResult(result);

        }


        private void SendEmail(MailRequest request)
        {
            senderService.SendEmailAsync(request);
        }

    }
}
#endregion