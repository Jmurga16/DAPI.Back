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
    public class CustomerController : ControllerBase
    {
        private ICustomerDAL customerDAL;

        TblCustomer Convert(CustomerModel customer)
        {
            return new TblCustomer
            {
                CustomerId = customer.CustomerID,
                IdType = customer.IDType,
                CustomerName = customer.CustomerName,
                CustomerAddress = customer.CustomerAddress,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber
            };
        }

        CustomerModel Convert(TblCustomer customer)
        {
            return new CustomerModel
            {
                CustomerID = customer.CustomerId,
                IDType = customer.IdType,
                CustomerName = customer.CustomerName,
                CustomerAddress = customer.CustomerAddress,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber
            };
        }

        
        public CustomerController()
        {
            customerDAL = new CustomerDALImpl(new AccountingSoftDBContext());
        }

        
        [HttpGet]
        public JsonResult Get()
        {
            List<TblCustomer> customers = new List<TblCustomer>();
            customers = customerDAL.GetAll().ToList();

            List<CustomerModel> result = new List<CustomerModel>();
            foreach (TblCustomer customer in customers)
            {
                result.Add(Convert(customer));
            }
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TblCustomer customer = customerDAL.Get(id);
            return new JsonResult(Convert(customer));
        }
        

        
        [HttpPost]
        public JsonResult Post([FromBody] CustomerModel customer)
        {
            TblCustomer entity = Convert(customer);
            customerDAL.Add(entity);
            return new JsonResult(Convert(entity));
        }
        

        
        [HttpPut]
        public JsonResult Put([FromBody] CustomerModel customer)
        {
            TblCustomer entity = Convert(customer);
            customerDAL.Update(entity);
            return new JsonResult(Convert(entity));
        }
        

        
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            TblCustomer customer = new TblCustomer { CustomerId = id };
            customerDAL.Remove(customer);
            return new JsonResult(customer);
        }
    }
}

