using System;
namespace BackEnd.Models
{
	public class EmployeeModel
	{
        public int EmployeeId { get; set; }
        public byte RoleId { get; set; }
        public byte DepartmentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Identification { get; set; }
        public byte Genre { get; set; }
        public string Username { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}

