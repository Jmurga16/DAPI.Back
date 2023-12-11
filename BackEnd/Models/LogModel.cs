using Entities.Entities;
using System;
namespace BackEnd.Models
{
	public class LogModel
	{
        public int LogId { get; set; }
        public int EmployeeId { get; set; }
        public string? LogDescription { get; set; }
        public DateTime DateTime { get; set; }
        public TblEmployee? Employee { get; set; } = null!;
    }
}

