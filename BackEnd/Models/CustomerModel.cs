using System;
namespace BackEnd.Models
{
	public class CustomerModel
	{
        public int CustomerID { get; set; }
        public byte IDType { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}

